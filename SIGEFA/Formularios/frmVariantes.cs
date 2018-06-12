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
    public partial class frmVariantes : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmVariante AdmVar = new clsAdmVariante();
        clsVariante var = new clsVariante();
        public Int32 CaracteristicaSeleccionada;
        public Int32 Proceso = 0; //(1) Nueva Variante (2)Editar Variante
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmVariantes()
        {
            InitializeComponent();
        }

        private void frmVariantes_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codVariante";
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
            txtCodigo.Text = var.CodVariante.ToString();
            txtDescripcion.Text = var.Descripcion;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVariantes.CurrentRow.Index != -1 && var.CodVariante != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Variante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmVar.delete(var.CodVariante))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Variante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    var.CodCaracteristica = CaracteristicaSeleccionada;
                    var.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        var.CodUser = frmLogin.iCodUser;
                        if (AdmVar.insert(var))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Variante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmVar.update(var))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Variante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
            dgvVariantes.DataSource = data;
            data.DataSource = AdmVar.MuestraVariantes(CaracteristicaSeleccionada);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVariantes.ClearSelection();
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

        private void dgvVariantes_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvVariantes.Rows.Count >= 1 && e.Row.Selected)
            {
                var.CodVariante = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                var.CodCaracteristica = Convert.ToInt32(e.Row.Cells[Caracteristica.Name].Value);
                var.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                var.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                var.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvVariantes.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvVariantes_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvVariantes.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvVariantes.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
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

        private void frmVariantes_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
