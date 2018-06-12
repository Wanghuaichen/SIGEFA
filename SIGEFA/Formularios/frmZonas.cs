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
    public partial class frmZonas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmZona AdmZona = new clsAdmZona();
        clsZona zon = new clsZona();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmZonas()
        {
            InitializeComponent();
        }

        private void frmZonas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codZona";
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
            txtCodigo.Text = zon.CodZona.ToString();
            txtDescripcion.Text = zon.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    zon.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        zon.CodUser = frmLogin.iCodUser;
                        if (AdmZona.insert(zon))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmZona.update(zon))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvZonas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvZonas.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvZonas.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvZonas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvZonas.Rows.Count >= 1 && e.Row.Selected)
            {
                zon.CodZona = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                zon.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                zon.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                zon.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvZonas.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargaLista()
        {
            dgvZonas.DataSource = data;
            data.DataSource = AdmZona.MuestraZonas();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvZonas.ClearSelection();
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
            txtDescripcion.Text = "";
            superValidator1.Validate();     
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvZonas.CurrentRow.Index != -1 && zon.CodZona != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Zonas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmZona.delete(zon.CodZona))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Zonas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 12;
            frm.ShowDialog();
        }

        private void frmZonas_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
