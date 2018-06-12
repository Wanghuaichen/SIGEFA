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
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmCajaChicaRegistro : DevComponents.DotNetBar.Office2007Form
    {
        clsValidar val = new clsValidar();
        clsTipoPagoCaja TPcaja = new clsTipoPagoCaja();
        clsAdmTipoPagoCaja AdmTPcaja = new clsAdmTipoPagoCaja();
        //clsCajaChica Caja = new clsCajaChica();
        //clsAdmCajaChica AdmCaja = new clsAdmCajaChica();
        clsAdmVehiculoTransporte admVehiculo = new clsAdmVehiculoTransporte();

        public Int32 CodtipoCajaChica = 0, codRec;
        public Int32 Tipo = 0, CodRecibo=0, tipoCaja=0;

        public Int32 Proceso = 0, tip=0;
        public Int32 AperturaCaja = 0;

        public Decimal SaldoCaja = 0, monto=0;

        private void CargaVehiculo()
        {
            cmbPlaca.DataSource = admVehiculo.CargaVehiculoTransportes();
            cmbPlaca.DisplayMember = "placa";
            cmbPlaca.ValueMember = "codVehiculoTransporte";
            cmbPlaca.SelectedIndex = -1;
        }



        public frmCajaChicaRegistro()
        {
            InitializeComponent();
        }

        private void frmCajaChicaRegistro_Load(object sender, EventArgs e)
        {
            //dtpFecha.MaxDate = System.DateTime.Now.Date;
            CargaFormaPagoCaja();
            CargaVehiculo();
            traersaldo();
            if (Tipo == 1)
            {
                cboTipoPagoCaja.Visible = false;
                lblTipoPagoCaja.Visible = false;
                lblGuiaRemision.Visible = false;
                txtGuiaRemision.Visible = false;
                lblReciboLiquidacion.Visible = false;
                txtReciboLiquidacion.Visible = false;
                lblTipo.Visible = false;
                cboTipo.Visible = false;
                lblToneladas.Visible = false;
                txtToneladas.Visible = false;
                lbPlaca.Visible = false;
                cmbPlaca.Visible = false;
                this.Text = "REGISTRO INGRESOS";
                if (tip == 2) {
                    label6.Visible = false;
                    txtRecibo.Visible = false;
                    label9.Visible = false;
                    txtMontoPendiente.Visible = false;
                    label11.Visible = false;
                    txtRazonSocial.Visible = false;
                    label10.Visible = false;
                    cmbDocumento.Visible = false;
                    label8.Visible = false;
                    txtDocumento.Visible = false;
                }
            }
            else if (Tipo == 2)
            {
                this.Text = "REGISTRO EGRESOS";
            }
            //****************************************

            if (AperturaCaja == 1)
            {
                txtDescripcion.Text = "APERTURA DE CAJA POR MONTO INICIAL";
                txtDescripcion.Enabled = false;
                txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
                txtDocumento.Enabled = false;
                txtDocumento.BackColor = System.Drawing.Color.WhiteSmoke;
                txtMonto.Text = saldoultimaapertura.ToString();
            }
            if (AperturaCaja == 2)
            {
                txtDescripcion.Text = "INGRESO A CAJA A PARTIR DE CHEQUE DE LIQUIDACION";
                txtDescripcion.Enabled = false;
                txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
                txtDocumento.Enabled = false;
                txtDocumento.BackColor = System.Drawing.Color.WhiteSmoke;
                txtMonto.Enabled = false;
                txtMonto.BackColor = System.Drawing.Color.WhiteSmoke;
                dtpFecha.Enabled = false;
            }
            else
            {
                if (Proceso == 1)
                {
                    cboTipo.SelectedIndex = 0;
                }
                else if (Proceso == 2)
                {
                    //CargaRegistro();
                    cboTipoPagoCaja.SelectedValue = CodtipoCajaChica;
                }
                else if (Proceso == 3)
                {
                    //CargaRegistro();
                    cboTipoPagoCaja.SelectedValue = CodtipoCajaChica;
                    SoloLectura(true);
                }
            }
        }
        Decimal saldoultimaapertura = 0;
        private void traersaldo()
        {
           //saldoultimaapertura = AdmCaja.traersaldo();
        }

        private void CargaRegistro()
        {
            //if (Caja != null)
            //{
            //    txtCodigo.Text = Caja.CodCajaChica.ToString();
            //    txtDescripcion.Text = Caja.Concepto;
            //    txtDocumento.Text = Caja.NumDocumento;
            //    txtMonto.Text = Caja.Monto.ToString();
            //    dtpFecha.Value = Caja.Fecha;
            //    txtGuiaRemision.Text = Caja.NumGuia;
            //    txtReciboLiquidacion.Text = Caja.NumRecLiquidacion;
            //    cboTipo.SelectedIndex = Caja.CargaDescarga;
            //    txtToneladas.Text = Caja.Toneladas.ToString();
            //}
        }

        private void CargaFormaPagoCaja()
        {
            try
            {
                cboTipoPagoCaja.DataSource = AdmTPcaja.ListaTipoPagoCaja();
                cboTipoPagoCaja.DisplayMember = "descripcion";
                cboTipoPagoCaja.ValueMember = "codTipoPagoCaja";
                cboTipoPagoCaja.SelectedIndex = 0;
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void SoloLectura(Boolean estado)
        {
            txtCodigo.Enabled = !estado;
            cboTipoPagoCaja.Enabled = !estado;
            txtDescripcion.Enabled = !estado;
            txtDocumento.Enabled = !estado;
            txtMonto.Enabled = !estado;
            dtpFecha.Enabled = !estado;
            txtGuiaRemision.Enabled = !estado;
            txtReciboLiquidacion.Enabled = !estado;
            cboTipo.Enabled = !estado;
            txtToneladas.Enabled = !estado;
            btnGuardar.Visible = !estado;
            txtRazonSocial.Enabled = !estado;
            cmbDocumento.Enabled = !estado;
        }
        
        public void SOLONumeros(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (superValidator1.Validate())
            //{
            //    if (Proceso != 0 && txtDescripcion.Text != "")
            //    {
            //        Caja.Concepto = txtDescripcion.Text.Trim();
            //        Caja.Monto = Convert.ToDecimal(txtMonto.Text.Trim());
            //        Caja.tipo = Tipo;
            //        Caja.Fecha = dtpFecha.Value;
            //        Caja.RazonSocial = txtRazonSocial.Text;
            //        Caja.TipoDocumento = cmbDocumento.Text;
            //        Caja.Tipocaja = tipoCaja;
            //        if (cboTipoPagoCaja.Text == "ESTIBA")
            //        {
            //            if (superValidator2.Validate())
            //            {
            //                //if (superValidator3.Validate())
            //                //{
            //                    Caja.NumDocumento = txtDocumento.Text.Trim();
            //                    Caja.NumGuia = txtGuiaRemision.Text.Trim();
            //                    Caja.NumRecLiquidacion = txtReciboLiquidacion.Text.Trim();
            //                    Caja.Toneladas = Convert.ToDecimal(txtToneladas.Text.Trim());
            //                    Caja.CargaDescarga = Convert.ToInt32(cboTipo.SelectedIndex);
            //                //}
            //            }
            //        }
            //        else if (cboTipoPagoCaja.Text == "PEAJE" || cboTipoPagoCaja.Text == "ABASTECIMIENTO DE COMBUSTIBLE")
            //        {
            //            Caja.NumDocumento = txtDocumento.Text.Trim();
            //            Caja.CodVehiculo = Convert.ToInt32(cmbPlaca.SelectedValue);
            //        }
            //        else
            //        { Caja.NumDocumento = txtDocumento.Text.Trim(); }

            //        Caja.CodUser = frmLogin.iCodUser;
            //        if (Tipo == 1) { } else if (Tipo == 2) { Caja.CodTipoPagoCaja = Convert.ToInt32(cboTipoPagoCaja.SelectedValue); }
            //        Caja.CodSucursal = frmLogin.iCodSucursal;

            //        if (AperturaCaja == 1) { Caja.Caso = 1; }
            //        else if (AperturaCaja == 2) { Caja.Caso = 2; }
            //        else { Caja.Caso = 0; }
            //        Caja.CodRecibo = codRec;
            //        if (Proceso == 1)
            //        {
            //            if (AdmCaja.insert(Caja))
            //            {
            //                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else if (Proceso == 2)
            //        {
            //            Caja.CodCajaChica = Convert.ToInt32(txtCodigo.Text.Trim());
            //            if (AdmCaja.update(Caja))
            //            {
            //                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }

            //        Proceso = 0;
            //        this.Close();
            //    }
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipoPagoCaja_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipoPagoCaja.Text == "ESTIBA")
            {
                txtGuiaRemision.Enabled = true;
                txtToneladas.Enabled = true;
                cboTipo.Enabled = true;
                txtReciboLiquidacion.Enabled = true;
            }
            else if (cboTipoPagoCaja.Text == "PEAJE" || cboTipoPagoCaja.Text == "ABASTECIMIENTO DE COMBUSTIBLE")
            {
                cmbPlaca.Enabled = true;
            }
            else
            {
                txtGuiaRemision.Enabled = false;
                txtToneladas.Enabled = false;
                cboTipo.Enabled = false;
                txtReciboLiquidacion.Enabled = false;
            }


            foreach (Control t in panel1.Controls)
            {
                if (t.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (t.Enabled == true)
                    { t.BackColor = System.Drawing.Color.Aquamarine; }
                    else
                    { t.BackColor = System.Drawing.Color.WhiteSmoke; }
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

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumerosDoc(sender, e);
        }

        private void txtGuiaRemision_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.SOLONumerosDoc(sender, e);
        }

        private void txtReciboLiquidacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumerosDoc(sender, e);
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRecibo.Text != "")
            {
                if (txtMonto.Text != "")
                {
                    if (Convert.ToDecimal(txtMonto.Text.Trim())> monto)
                    {
                        MessageBox.Show("Saldo Incorrecto. El Monto debe ser >= " + txtMontoPendiente.Text, "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMonto.Text = "";
                    }
                }
            }
            else
            {
                if (txtMonto.Text != "")
                {
                    if (Tipo == 2)
                    {
                        Decimal Monto = Convert.ToDecimal(lblEgreso.Text.Trim()) + (Convert.ToDecimal(lblSaldoCaja.Text.Trim()));
                        if (Convert.ToDecimal(txtMonto.Text.Trim()) > Monto)
                        {
                            MessageBox.Show("Saldo Insuficiente en Caja Chica", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMonto.Text = Monto.ToString();
                            txtMonto.SelectAll();
                        }
                    }
                }
            }
        }

        private void txtRecibo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmRecibosSinSustentar"] != null)
                {
                    Application.OpenForms["frmRecibosSinSustentar"].Activate();
                }
                else
                {
                    txtMonto.Text = "";
                    frmRecibosSinSustentar form = new frmRecibosSinSustentar();
                    form.tipocaja = tipoCaja;
                    form.ShowDialog();
                }
            }
        }

        private void customValidator2_ValidateValue_1(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && Tipo != 1)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue_1(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0 && Tipo!=1)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }
    }
}
