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
    public partial class frmFamilias : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmFamilia AdmFam = new clsAdmFamilia();
        clsFamilia fam = new clsFamilia();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar
        
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public Int32 procede = 0;

        public frmFamilias()
        {
            InitializeComponent();
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
            Proceso = 2;
            groupBox2.Text = "Editar Registro";            
            txtCodigo.Text = fam.CodFamilia.ToString();
            txtReferencia.Text = fam.Referencia;
            txtDescripcion.Text = fam.Descripcion;
        }

        private void CargaLista()
        {
            dgvFamilias.DataSource = data;
            data.DataSource = AdmFam.MuestraFamilias();
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnGuardar.Visible = !Estado;
            btnLineas.Visible = Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            txtReferencia.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();      
        }

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codFamilia";
            if (procede == 1)
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnGuardar.Visible = false;
                btnLineas.Visible = false;
                btnNuevo.Visible = false;
                btnReporte.Visible = false;
                btnSalir.Visible = false;
            }
        }

        private void dgvFamilias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvFamilias.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvFamilias.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvFamilias_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvFamilias.Rows.Count >= 1 && e.Row.Selected)
            {
                fam.CodFamilia = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                fam.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
                fam.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                fam.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                fam.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnLineas.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if(dgvFamilias.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnLineas.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    fam.Referencia = txtReferencia.Text;
                    fam.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        fam.CodUser = frmLogin.iCodUser;
                        if (AdmFam.insert(fam))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmFam.update(fam))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
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

        private void btnLineas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmLineas"] != null)
            {
                Application.OpenForms["frmLineas"].Activate();
            }
            else
            {
                frmLineas frm = new frmLineas();
                //frm.MdiParent = this.MdiParent;
                //frm.FamiliaSeleccionada = fam.CodFamilia;
                frm.fam = fam;
                //frm.Cabecera = fam.Referencia + " " + fam.Descripcion;
                frm.ShowDialog();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFamilias.CurrentRow.Index != -1 && fam.CodFamilia != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Familia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmFam.delete(fam.CodFamilia))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Familias");
            // Columnas
            foreach (DataGridViewColumn column in dgvFamilias.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvFamilias.Rows.Count; i++)
            {
                DataGridViewRow row = dgvFamilias.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvFamilias.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmFamiliasRP frm = new frmFamiliasRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void dgvFamilias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (procede == 1) 
            //{
            //    frmListaPrecios form = (frmListaPrecios)Application.OpenForms["frmListaPrecios"];
            //    form.txtNomFamilia.Text = fam.Descripcion.ToString();
            //    form.txtCodFamilia.Text = fam.CodFamilia.ToString();
            //    this.Close();
            //}
            
        }

        private void frmFamilias_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

    }
}
