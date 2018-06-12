using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmGestionNombreLE : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Empresa (2)Editar Empresa (3)Consulta Empresa
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        public clsEmpresa emp = new clsEmpresa();
        clsAdmLibrosElectronicos admlibro = new clsAdmLibrosElectronicos();
        clsLibrosElectronicos libro = new clsLibrosElectronicos();
        clsRegistroElectronico registro = new clsRegistroElectronico();
        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        clsAdmMoneda admMoneda = new clsAdmMoneda();
        public DateTime Hoy = DateTime.Today;

        public frmGestionNombreLE()
        {
            InitializeComponent();
        }
        
        private void CargaEmpresa()
        {
            emp = admEmp.CargaEmpresa(frmLogin.iCodEmpresa);           
            txtRUC.Text = emp.Ruc;   
            
        }

        private void CargaLibrosElectronicos()
        {
            cmbLibrosElectronicos.DataSource = admlibro.CargaLibrosElectronicos();
            cmbLibrosElectronicos.DisplayMember = "descripcion";
            cmbLibrosElectronicos.ValueMember = "codlibro";
            cmbLibrosElectronicos .SelectedIndex = -1;
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
                    
                }
            }
            
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (ext.rucsunat(txtRUC.Text))
                {
                    
                }
                else
                {
                    ext.limpiar(this.Controls);
                    
                }
            }
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

        private void CargaRegistrosElectronicos(Int32 codlibro)
        {
            cmbRegistroElectronico.DataSource = admlibro.CargaRegistrosElectronicos(codlibro);
            cmbRegistroElectronico.DisplayMember = "descripcion";
            cmbRegistroElectronico.ValueMember = "codlibroregistro";
            cmbRegistroElectronico.SelectedIndex = -1;
        }

        private void frmGestionNombreLE_Load(object sender, EventArgs e)
        {
            CargaEmpresa();
            CargaLibrosElectronicos();
            CargaMoneda();
            CargaOperaciones();
            CargaContenido();
            CargaGenerado();
        }

        private void CargaGenerado()
        {
            cmbGenerado.DataSource = admlibro.CargaGeneradoPor();
            cmbGenerado.DisplayMember = "descripcion";
            cmbGenerado.ValueMember = "codigo";
            cmbGenerado.SelectedIndex = -1;
        }

        private void CargaContenido()
        {
            cmbContenido.DataSource = admlibro.CargaContenido();
            cmbContenido.DisplayMember = "descripcion";
            cmbContenido.ValueMember = "codigo";
            cmbContenido.SelectedIndex = -1;
        }

        private void CargaOperaciones()
        {
            cmbOperaciones.DataSource = admlibro.CargaOperaciones();
            cmbOperaciones.DisplayMember = "descripcion";
            cmbOperaciones.ValueMember = "codigo";
            cmbOperaciones.SelectedIndex = -1;
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = admMoneda.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = -1;
        }

        private void cmbLibrosElectronicos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((Int32)cmbLibrosElectronicos.SelectedValue > 0) 
            {
                libro = admlibro.MuestraLE((Int32)cmbLibrosElectronicos.SelectedValue);
                if (libro != null)
                {
                    CargaRegistrosElectronicos(libro.Codlibro);                    

                    if (libro.Aplicaanio == 1)
                    {
                        txtAnio.Text = Hoy.Year.ToString();
                    }
                    else { txtAnio.Text = "AAAA"; }

                    if (libro.Aplicames == 1)
                    {
                        Int32 mes = 0;
                        mes = Convert.ToInt32(Hoy.Month);
                        if (mes > 0 && mes < 13) 
                        {
                            if (mes < 10)
                            {
                                txtMes.Text = "0" + mes;
                            }
                            else 
                            {
                                txtMes.Text = mes.ToString();
                            }
                        }
                    }
                    else { txtMes.Text = "00"; }

                    if (libro.Aplicadia == 1)
                    {
                        Int32 dia = 0;
                        dia = Convert.ToInt32(Hoy.Day);
                        if (dia > 0 && dia < 32)
                        {
                            if (dia < 10)
                            {
                                txtMes.Text = "0" + dia;
                            }
                            else
                            {
                                txtMes.Text = dia.ToString();
                            }
                        }
                    }
                    else { txtDia.Text = "00"; }

                    if (libro.Aplicaoportunidad == 1)
                    {
                        MessageBox.Show("solo para inventario y balance");
                    }
                    else { txtCodOportunidad.Text = "00"; }
                }
            }
        }

        private void cmbRegistroElectronico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((Int32)cmbRegistroElectronico.SelectedValue > 0) 
            {
                registro = admlibro.MuestraRE((Int32)cmbRegistroElectronico.SelectedValue);

                if (registro != null) 
                {
                    txtIndicadorLE.Text = registro.Codigo;
                }
            }
        }

        private void cmbMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((Int32)cmbMoneda.SelectedValue > 0) 
            {
                txtMoneda.Text = cmbMoneda.SelectedValue.ToString();
            }
        }

        private void cmbOperaciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbOperaciones.SelectedValue) != -1) 
            {
                txtoperaciones.Text = cmbOperaciones.SelectedValue.ToString();
            }
        }

        private void cmbContenido_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbContenido.SelectedValue) != -1)
            {
               txtContenido.Text = cmbContenido.SelectedValue.ToString();
            }
        }

        private void cmbGenerado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbGenerado.SelectedValue) != -1)
            {
               txtGenerado.Text = cmbGenerado.SelectedValue.ToString();
            }
        }

        private void btnGenerarNombre_Click(object sender, EventArgs e)
        {
            if (txtRUC.Text != "")
            {
                String NomenclaturaArchivo = "";
                if (txtCodEmpresa.Text != "")
                {
                    NomenclaturaArchivo = NomenclaturaArchivo + txtCodEmpresa.Text + txtRUC.Text + txtAnio.Text + txtMes.Text + txtDia.Text + txtIndicadorLE.Text +
                                          txtCodOportunidad.Text + txtoperaciones.Text + txtContenido.Text + txtMoneda.Text + txtGenerado.Text;
                }

                txtNombreNomenclatura.Text = NomenclaturaArchivo;
                btnAceptar.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;

            this.Close();
        }

        public String GetNombre() 
        {
            String nombrearchivo = txtNombreNomenclatura.Text;
            return nombrearchivo;
        }
                   
    }
}
