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
    public partial class frmGestionEmpresa : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Empresa (2)Editar Empresa (3)Consulta Empresa
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        public clsEmpresa emp = new clsEmpresa();

        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();

        public frmGestionEmpresa()
        {
            InitializeComponent();
        }
          

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtRUC.Text != "")
                {
                    Double CodEmp = 0;
                    if (txtCodEmpresa.Text == "")
                    {
                        CodEmp = 0;
                    }
                    else
                    {
                        CodEmp = Convert.ToDouble(txtCodEmpresa.Text);
                    }
                    emp.Ruc = txtRUC.Text;
                    emp.RazonSocial = txtRazonSocial.Text;
                    emp.Direccion = txtDireccion.Text;
                    emp.Telefono = txtTelefono.Text;
                    emp.Fax = txtFax.Text;
                    emp.Representante = txtRepresentante.Text;
                    emp.CodUser = frmLogin.iCodUser;
                    emp.Estado = cbActivoE.Checked;

                    if (Proceso == 1)
                    {
                        if (admEmp.insert(emp))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (admEmp.update(emp))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }



        private void frmGestionEmpresa_Load(object sender, EventArgs e)
        {
            if (Proceso == 2)
            {
                CargaEmpresa();
            }
            else if (Proceso == 3)
            {
                CargaEmpresa();
                ext.sololectura(groupBox1.Controls);
                btnAceptar.Visible = false;
                btnCancelar.Text = "Aceptar";
                btnCancelar.ImageIndex = 1;
            }

        }

        private void CargaEmpresa()
        {
            emp = admEmp.CargaEmpresa(emp.CodEmpresa);
            txtCodEmpresa.Text = emp.CodEmpresa.ToString();
            txtRUC.Text = emp.Ruc;
            txtRazonSocial.Text = emp.RazonSocial;
            txtDireccion.Text = emp.Direccion;
            txtTelefono.Text = emp.Telefono;
            txtFax.Text = emp.Fax;
            txtRepresentante.Text = emp.Representante;
            cbActivoE.Checked = emp.Estado;
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
            if (Proceso == 1 && txtCodEmpresa.Text == "")
            {
                if (admEmp.VerificaRUC(txtRUC.Text))
                {
                    MessageBox.Show("El RUC ingresado ya se encuentra registrado", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRUC.Focus();
                    ext.limpiar(groupBox1.Controls);
                    cbActivoE.Checked = true;
                }
            }
            //if (txtRUC.Text.Length != 11)
            //{
            //    MessageBox.Show("El RUC ingresado no es válido", "Gestion Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtRUC.Focus();
            //    ext.limpiar(groupBox1.Controls);
            //}
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ext.rucsunat(txtRUC.Text))
                {
                    txtRazonSocial.Text = ext.RazonSocial;
                    txtDireccion.Text = ext.DireccionLegal;
                }
                else
                {
                    ext.limpiar(this.Controls);
                    cbActivoE.Checked = true;
                }
            }
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

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
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
                txtFax.Focus();
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentante.Focus();
            }
        }

        private void txtRepresentante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }              
    }
}
