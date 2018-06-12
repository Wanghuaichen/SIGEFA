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
    public partial class frmEmpresaTransporte : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresaTransporte AdmET = new clsAdmEmpresaTransporte();
        clsValidar valida = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        public clsEmpresaTransporte emp = new clsEmpresaTransporte();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Consulta


        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmEmpresaTransporte()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvEmpresaTransporte.DataSource = data;
            data.DataSource = AdmET.MuestraEmpresaTranportes();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvEmpresaTransporte.ClearSelection();
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
            txtRazonSocial.Text = "";
            superValidator1.Validate();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            ext.limpiar(groupBox2.Controls);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ext.limpiar(groupBox2.Controls);
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            cargaEmpresaTransporte();
        }

        private void cargaEmpresaTransporte()
        {
            emp = AdmET.MuestraEmpresaTranporte(emp.CodEmpresaTranporte);
            if (emp != null)
            {
                txtCodigo.Text = emp.CodEmpresaTranporte.ToString();
                txtRuc.Text = emp.Ruc;
                txtRazonSocial.Text = emp.RazonSocial;
                txtTelefono.Text = emp.Telefono;
                txtDireccion.Text = emp.Direccion;
            }
        }

        private void frmEmpresaTransporte_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codEmpresaTransporte";
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
            if (dgvEmpresaTransporte.CurrentRow.Index != -1 && emp.CodEmpresaTranporte != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "EmpresaTransporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmET.delete(emp.CodEmpresaTranporte))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "EmpresaTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (btnGuardar.Text == "Guardar")
            {
                if (superValidator1.Validate())
                {
                    if (Proceso != 0)
                    {

                        emp.Ruc = txtRuc.Text;
                        emp.RazonSocial = txtRazonSocial.Text;
                        emp.Telefono = txtTelefono.Text;
                        emp.Direccion = txtDireccion.Text;

                        if (Proceso == 1)
                        {
                            emp.CodUser = frmLogin.iCodUser;
                            if (AdmET.insert(emp))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion EmpresaTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                                Proceso = 0;
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmET.update(emp))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion EmpresaTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                                Proceso = 0;
                            }
                        }
                        //Proceso = 0;
                    }
                }
            }
            else if (btnGuardar.Text == "Aceptar")
            {
                if (Proceso == 3)
                {
                    this.Close();
                }
            }
        }

        private void dgvEmpresaTransportes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvEmpresaTransporte.Rows.Count >= 1 && e.Row.Selected)
            {
                emp.CodEmpresaTranporte = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                //cond.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                //cond.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                //cond.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;               
            }
            else if(dgvEmpresaTransporte.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvEmpresaTransportes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvEmpresaTransporte.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvEmpresaTransporte.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
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

        private void dgvEmpresaTransportes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {               
                this.Close();
            }
        }

        private void dgvEmpresaTransportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 11;
            frm.ShowDialog();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.enteros(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.enteros(e);
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

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //ruc(txtRUC.Text);

                if (ext.rucsunat(txtRuc.Text))
                {
                    txtRazonSocial.Text = ext.RazonSocial;
                    txtDireccion.Text = ext.DireccionLegal;
                }
                else
                {
                    ext.limpiar(this.Controls);
                }
            }
        }

        private void frmEmpresaTransporte_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
