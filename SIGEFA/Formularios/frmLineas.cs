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
    public partial class frmLineas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmLinea AdmLin = new clsAdmLinea();
        public clsFamilia fam = new clsFamilia();
        clsLinea lin = new clsLinea();
        public Int32 FamiliaSeleccionada;
        public String Cabecera;
        public Int32 Proceso = 0; //(1) Nueva Linea (2)Editar Linea
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 procede = 0;

        public frmLineas()
        {
            InitializeComponent();
        }

        private void frmLineas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codLinea";
            groupBox1.Text = fam.Referencia + " " + fam.Descripcion + ": Lineas";
            if (procede == 1)
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnGuardar.Visible = false;
                //btnGrupos.Visible = false;
                btnNuevo.Visible = false;
                btnReporte.Visible = false;
                btnSalir.Visible = false;
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
            txtCodigo.Text = lin.CodLinea.ToString();
            txtReferencia.Text = lin.Referencia;
            txtDescripcion.Text = lin.Descripcion;
        }        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    lin.CodFamilia = fam.CodFamilia;
                    lin.Referencia = txtReferencia.Text;
                    lin.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        lin.CodUser = frmLogin.iCodUser;
                        if (AdmLin.insert(lin))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Linea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmLin.update(lin))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Linea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void CargaLista()
        {
            dgvLineas.DataSource = data;
            data.DataSource = AdmLin.MuestraLineas(fam.CodFamilia);
            data.Filter = String.Empty;
            filtro = String.Empty;

        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnGuardar.Visible = !Estado;
            btnGrupos.Visible = Estado;
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

        private void dgvLineas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvLineas.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvLineas.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvLineas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvLineas.Rows.Count >= 1 && e.Row.Selected)
            {
                lin.CodLinea = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                lin.CodFamilia = Convert.ToInt32(e.Row.Cells[familia.Name].Value);
                lin.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
                lin.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                lin.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                lin.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnGrupos.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvLineas.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnGrupos.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGrupo"] != null)
            {
                Application.OpenForms["frmGrupo"].Activate();
            }
            else
            {
                frmGrupo frm = new frmGrupo();
                //frm.MdiParent = this.MdiParent;
                //frm.LineaSeleccionada = lin.CodLinea;
                //frm.Cabecera = lin.Referencia + " " + lin.Descripcion;
                frm.lin = lin;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLineas.CurrentRow.Index != -1 && lin.CodLinea != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Linea", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmLin.delete(lin.CodLinea))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Linea", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            frm.tipo = 5;
            frm.CodCotizacion=fam.CodFamilia;
            frm.ShowDialog();
        }

        private void frmLineas_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
