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
    public partial class frmGrupo : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmGrupo AdmGru = new clsAdmGrupo();
        public clsLinea lin = new clsLinea();        
        clsGrupo gru = new clsGrupo();
        public Int32 LineaSeleccionada;
        public String Cabecera;
        public Int32 Proceso = 0; //(1) Nueva Linea (2)Editar Linea
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmGrupo()
        {
            InitializeComponent();
        }

        private void frmGrupo_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codGrupo";
            groupBox1.Text = lin.Referencia + " " + lin.Descripcion + ": Grupos";
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
            txtCodigo.Text = gru.CodGrupo.ToString();
            txtReferencia.Text = gru.Referencia;
            txtDescripcion.Text = gru.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    gru.CodLinea = lin.CodLinea;
                    gru.Referencia = txtReferencia.Text;
                    gru.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        gru.CodUser = frmLogin.iCodUser;
                        if (AdmGru.insert(gru))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmGru.update(gru))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
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

        private void CargaLista()
        {
            dgvGrupos.DataSource = data;
            data.DataSource = AdmGru.MuestraGrupos(lin.CodLinea);
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;                      
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            txtReferencia.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();
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

        private void dgvGrupos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvGrupos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvGrupos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvGrupos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvGrupos.Rows.Count >= 1 && e.Row.Selected)
            {
                gru.CodGrupo = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                gru.CodLinea = Convert.ToInt32(e.Row.Cells[Linea.Name].Value);
                gru.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
                gru.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                gru.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                gru.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvGrupos.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;            
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
            if (dgvGrupos.CurrentRow.Index != -1 && gru.CodGrupo != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmGru.delete(gru.CodGrupo))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 6;
            frm.CodCotizacion = lin.CodLinea;
            frm.ShowDialog();
        }

        private void frmGrupo_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
