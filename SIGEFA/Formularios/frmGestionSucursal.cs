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
    public partial class frmGestionSucursal : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Empresa (2)Editar Empresa (3)Consulta Empresa

        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        clsAdmSucursal AdmSuc = new clsAdmSucursal();
        public clsSucursal suc = new clsSucursal();

        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();

        public frmGestionSucursal()
        {
            InitializeComponent();
        }
          

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtNombre.Text != "")
                {
                    if (txtCodSucursal.Text== "")
                    {
                        suc.CodSucursal= 0;
                    }
                    else
                    {
                        suc.CodSucursal = Convert.ToInt32(txtCodSucursal.Text);
                    }
                    suc.Nombre= txtNombre.Text;
                    suc.Ubicacion = txtUbicacion.Text;
                    suc.Telefono = txtTelefono.Text;
                    suc.Descripcion = txtDescripcion.Text;
                    suc.Estado = cbActivo.Checked;
                    suc.CodEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue);
                    suc.CodUser = frmLogin.iCodUser;

                    if (Proceso == 1)
                    {
                        if (AdmSuc.insert(suc))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmSuc.update(suc))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void CargaEmpresas()
        {
            cboEmpresa.DataSource = AdmEmp.CargaEmpresas();
            cboEmpresa.DisplayMember = "razonsocial";
            cboEmpresa.ValueMember = "codEmpresa";
            cboEmpresa.SelectedIndex = 0;
        }

        private void frmGestionEmpresa_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            
            if (Proceso == 2)
            {
                CargaSucursal();
            }
            else if (Proceso == 3)
            {
                CargaSucursal();
                ext.sololectura(groupBox1.Controls);
                btnAceptar.Visible = false;
                btnCancelar.Text = "Aceptar";
                btnCancelar.ImageIndex = 1;
            }
        }

        private void CargaSucursal()
        {
            suc = AdmSuc.CargaSucursal(suc.CodSucursal);

            txtCodSucursal.Text = suc.CodSucursal.ToString();
            txtNombre.Text = suc.Nombre;
            txtUbicacion.Text = suc.Ubicacion;
            txtTelefono.Text = suc.Telefono;
            txtDescripcion.Text = suc.Descripcion;
            cbActivo.Checked = suc.Estado;
        }       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void txtRUC_Leave(object sender, EventArgs e)
        {
            //if (Proceso == 1 && txtCodEmpresa.Text == "")
            //{
            //    if (admEmp.VerificaRUC(txtRUC.Text))
            //    {
            //        MessageBox.Show("El RUC ingresado ya se encuentra registrado", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtRUC.Focus();
            //        ext.limpiar(groupBox1.Controls);
            //        cbActivoE.Checked = true;
            //    }
            //}
            //if (txtRUC.Text.Length != 11)
            //{
            //    MessageBox.Show("El RUC ingresado no es válido", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtRUC.Focus();
            //    ext.limpiar(groupBox1.Controls);
            //}
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F2)
            //{
            //    if (ext.rucsunat(txtRUC.Text))
            //    {
            //        txtRazonSocial.Text = ext.RazonSocial;
            //        txtDireccion.Text = ext.DireccionLegal;
            //    }
            //    else
            //    {
            //        ext.limpiar(this.Controls);
            //        cbActivoE.Checked = true;
            //    }
            //}
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }
             

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text.Length == 11)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0 && c.Visible)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void cboEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUbicacion.Focus();
            }
        }

        private void txtUbicacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            btnAceptar.Focus();
        }       
    }
}
