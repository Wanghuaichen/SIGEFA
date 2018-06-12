using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmAutorizado : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAutorizado AdmAut = new clsAdmAutorizado();
        public clsAutorizado aut = new clsAutorizado();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmAutorizado()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvAutorizados.DataSource = data;
            data.DataSource = AdmAut.MuestraAutorizados();
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnGuardar.Visible = !Estado;            
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            txtCodigo.Text = aut.CodAutorizado.ToString();
            txtDescripcion.Text = aut.Nombre;
        }

        private void frmAutorizado_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codCaracteristica";
            if (Proceso == 3)
            {
                bloquearbotones();
            }
        }

        private void bloquearbotones()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnReporte.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutorizados.CurrentRow.Index != -1 && aut.CodAutorizado != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Autorizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmAut.delete(aut.CodAutorizado))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                this.Close();
            }
            else
            {
                Proceso = 0;
                CambiarEstados(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    aut.Nombre = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        aut.CodUser = frmLogin.iCodUser;
                        if (AdmAut.insert(aut))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmAut.update(aut))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void dgvAutorizados_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvAutorizados.Rows.Count >= 1 && e.Row.Selected)
            {
                aut.CodAutorizado = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                aut.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                aut.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                aut.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;               
            }
            else if(dgvAutorizados.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvAutorizados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvAutorizados.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvAutorizados.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void dgvAutorizados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {               
                this.Close();
            }
        }

        private void dgvAutorizados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Autorizados");
            // Columnas
            foreach (DataGridViewColumn column in dgvAutorizados.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvAutorizados.Rows.Count; i++)
            {
                DataGridViewRow row = dgvAutorizados.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvAutorizados.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmAutorizadoRP frm = new frmAutorizadoRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void frmAutorizado_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
