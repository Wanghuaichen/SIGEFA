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
    public partial class frmCajaDiariaRegistro : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmMoneda AdmMoned = new clsAdmMoneda();
        clsAdmBanco AdmBan = new clsAdmBanco();
        clsAdmTarjetaPago AdmTar = new clsAdmTarjetaPago();
        clsValidar val = new clsValidar();
        clsAdmCtaCte AdmCtaCte = new clsAdmCtaCte();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmMetodoPago admMPago = new clsAdmMetodoPago();
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsSerie ser = new clsSerie();
        clsAdmSerie Admser = new clsAdmSerie();
        public Int32 direccioncaja = 0;

        public Boolean Tipo; // true => ingreso       false => egreso
        public Int32 codigocaja = 0;
        public Int32 Proceso = 0;
        public Decimal SaldoCaja = 0;
        public Int32 CodDocumento;
        public Int32 CodSerie;

        public frmCajaDiariaRegistro()
        {
            InitializeComponent();
        }

        private void frmCajaChicaRegistro_Load(object sender, EventArgs e)
        {

            cargaMoneda();
            CargarBancos();
            CargarTarjetas();
            cboTarjeta.SelectedIndex = -1;
            cboBanco.SelectedIndex = -1;
            CargaTipoCambio();
            CargaMetodosPagos();
            //cmbMetodoPago_SelectionChangeCommitted(cmbMetodoPago, null);
            txtDocRef.Visible = true;
            txtSerie.Visible = true;
            txtNumero.Visible = true;
            txtNumero.Enabled = false;
            label16.Visible = true;
            if (Tipo)
            {
                cboTipo.SelectedIndex = 0;
                
            }
            else { cboTipo.SelectedIndex = 1; }
        }

        private void CargaMetodosPagos()
        {
            cmbMetodoPago.DataSource = admMPago.CargaMetodoPagos();
            cmbMetodoPago.DisplayMember = "descripcion";
            cmbMetodoPago.ValueMember = "codMetodoPago";
        }

        private void CargaTipoCambio()
        {
            tc = AdmTc.CargaTipoCambio(DateTime.Now.Date, 2);
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
            }
            else
            {
                txtTipoCambio.Text = "";
                txtTipoCambio.ReadOnly = false;
            }
        }

        private void CargarTarjetas()
        {
            try
            {
                cboTarjeta.DataSource = AdmTar.MuestraTarjetas(frmLogin.iCodAlmacen);
                cboTarjeta.DisplayMember = "tipo";
                cboTarjeta.ValueMember = "codtarjeta";
                cboTarjeta.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void CargarBancos()
        {
            try
            {
                //cboBanco.DataSource = AdmBan.MuestraBancos();
                cboBanco.DataSource = AdmCtaCte.ListaBancoxMoneda(Convert.ToInt32(cmbMoneda.SelectedValue));
                cboBanco.DisplayMember = "descripcion";
                cboBanco.ValueMember = "codbanco";
                cboBanco.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMoned.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            //cmbMoneda.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Pag.CodNota = null;
            Pag.CodLetra = 0;
            Pag.CodTipoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue); //metodo de pago
            Pag.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            //Pag.CodCobrador = Convert.ToInt32(cbovendedor.SelectedValue); //Cobrador
            Pag.CodCobrador = Convert.ToInt32(frmLogin.iCodUser);
            Pag.Tipo = true;// 1 total o parcial
            Pag.IngresoEgreso = Tipo;// true => ingreso       false => egreso
            if (txtTipoCambio.Text == "") { Pag.TipoCambio = 0; } else { Pag.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text); };
            Pag.MontoPagado = Convert.ToDecimal(txtMontoPago.Text);
            Pag.MontoCobrado = Convert.ToDecimal(txtMontoPago.Text);
            Pag.Vuelto = 0;
            Pag.codCtaCte = Convert.ToInt32(cboNumCta.SelectedValue);
            Pag.CtaCte = Convert.ToString(cboNumCta.Text);
            Pag.NOperacion = txtOperacion.Text;
            Pag.NCheque = txtCheque.Text;
            Pag.FechaPago = dtpfecha.Value;
            Pag.Observacion = txtDescripcion.Text;
            Pag.CodUser = frmLogin.iCodUser;
            Pag.CodAlmacen = frmLogin.iCodAlmacen;
            Pag.CodSerie = CodSerie;
            Pag.CodSucursal = frmLogin.iCodSucursal;
            Pag.CodDoc = CodDocumento;
            Pag.Codcaja = codigocaja;
           
            
            Pag.Serie = txtSerie.Text;
            Pag.NumDoc = txtNumero.Text;
            Pag.Referencia = txtNc.Text;
           
            /* SI NECECITA APROBACION NO CREA NUMERACION    */

            //***** Datos para las operaciones de Venta ******
            Pag.CodBanco = Convert.ToInt32(cboBanco.SelectedValue);
            Pag.NOperacion = Convert.ToString(txtOperacion.Text.Trim());
            Pag.CodTarjeta = Convert.ToInt32(cboTarjeta.SelectedValue);
            Pag.NCheque = Convert.ToString(txtCheque.Text.Trim());
            //************************************************


            //********* Verificando campos faltantes **********
            if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 6 || Convert.ToInt32(cmbMetodoPago.SelectedValue) == 9)
            {
                if (txtOperacion.Text.Trim() == "" || cboBanco.Text == "" || txtMontoPago.Text == "")
                {
                    MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { Pagar(); }
            }
            else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 8)
            {
                if (txtOperacion.Text.Trim() == "" || cboTarjeta.Text == "" || txtMontoPago.Text == "")
                {
                    MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { Pagar(); }
            }
            else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 7)
            {
                if (txtCheque.Text.Trim() == "" || cboBanco.Text == "" || txtOperacion.Text.Trim() == "" || txtMontoPago.Text == "")
                {
                    MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { Pagar();  }
            }
            else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 5)
            {
                if (Admpag.insert(Pag))
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Deshabilita_botones(false);
                }
            }  
           
        }

        private void Pagar()
        {
            if (Admpag.insert(Pag))
            {
                MessageBox.Show("Pago Realizado Correctamente", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //btnImprimir.Visible = true;
                cargaPago(Pag);
                Deshabilita_botones(false);
            }

        }

        private void cargaPago(clsPago p)
        {
            p = Admpag.MuestraPagoVenta(frmLogin.iCodAlmacen, Pag.CodPago);
            if (p != null)
            {
                cmbMetodoPago.SelectedValue = p.CodTipoPago;
                cboBanco.SelectedValue = p.CodBanco;
                cboTarjeta.SelectedValue = p.CodTarjeta;
                cboNumCta.SelectedValue = p.codCtaCte;
                txtTipoCambio.Text = p.TipoCambio.ToString();
                txtCheque.Text = p.NCheque;
                txtDescripcion.Text = p.Observacion;
                txtOperacion.Text = p.NOperacion;
                txtMontoPago.Text = p.MontoCobrado.ToString();
                dtpfecha.Value = p.FechaPago;
                //cbovendedor.SelectedValue = p.CodCobrador;
                txtSerie.Text = p.Serie;
                txtNumero.Text = p.NumDoc;
            }
        }
        private void Deshabilita_botones(Boolean Estado)
        {
            cboBanco.Enabled = Estado;
            cboNumCta.Enabled = Estado;
            cboTarjeta.Enabled = Estado;
            //cbovendedor.Enabled = Estado;
            txtCheque.Enabled = Estado;
            txtOperacion.Enabled = Estado;
            txtDescripcion.Enabled = Estado;
            txtMontoPago.Enabled = Estado;
            dtpfecha.Enabled = Estado;
            btnGuardar.Enabled = Estado;
            btnSalir.Enabled = !Estado;
            txtSerie.Enabled = Estado;
            txtNumero.Enabled = Estado;
            txtNumero.Visible = !Estado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //val.SOLONumerosDoc(sender, e);
        }

        private void txtGuiaRemision_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumerosDoc(sender, e);
        }

        private void txtReciboLiquidacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumerosDoc(sender, e);
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void cmbMetodoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 5)
                {
                    cboTarjeta.Enabled = false;
                    cboBanco.Enabled = false;
                    cboBanco.SelectedIndex = -1;
                    cboTarjeta.SelectedIndex = -1;
                    txtCheque.Text = "";
                    txtNc.Text = "";
                    txtMontoPago.Text = "";
                    txtOperacion.Text = "";
                    txtOperacion.Enabled = false;
                    txtCheque.Enabled = false;
                    txtMontoPago.Enabled = true;
                    cboNumCta.Enabled = false;
                    cboNumCta.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 6 || Convert.ToInt32(cmbMetodoPago.SelectedValue) == 9)
                {
                    cboTarjeta.Enabled = false;
                    cboBanco.Enabled = true;
                    cboBanco.SelectedIndex = -1;
                    cboTarjeta.SelectedIndex = -1;
                    cboBanco.Focus();
                    txtCheque.Text = "";
                    txtOperacion.Text = "";
                    txtNc.Text = "";
                    txtMontoPago.Text = "";
                    txtOperacion.Enabled = true;
                    txtCheque.Enabled = false;
                    txtMontoPago.Enabled = true;
                    cboNumCta.Enabled = false;
                    cboNumCta.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 7)
                {
                    cboTarjeta.Enabled = false;
                    cboBanco.Enabled = true;
                    cboBanco.Focus();
                    cboBanco.SelectedIndex = -1;
                    cboTarjeta.SelectedIndex = -1;
                    txtOperacion.Text = "";
                    txtNc.Text = "";
                    txtMontoPago.Text = "";
                    txtCheque.Text = "";
                    txtOperacion.Enabled = true;
                    txtCheque.Enabled = true;
                    txtMontoPago.Enabled = true;
                    cboNumCta.Enabled = false;
                    cboNumCta.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 8)
                {
                    cboTarjeta.Enabled = true;
                    cboBanco.Enabled = false;
                    cboTarjeta.Focus();
                    cboBanco.SelectedIndex = -1;
                    cboTarjeta.SelectedIndex = -1;
                    txtOperacion.Text = "";
                    txtNc.Text = "";
                    txtMontoPago.Text = "";
                    txtCheque.Text = "";
                    txtOperacion.Enabled = true;
                    txtCheque.Enabled = false;
                    txtMontoPago.Enabled = true;
                    cboNumCta.Enabled = false;
                    cboNumCta.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 10)
                {
                    cboTarjeta.Enabled = false;
                    cboBanco.Enabled = false;
                    cboBanco.SelectedIndex = -1;
                    cboTarjeta.SelectedIndex = -1;
                    txtOperacion.Text = "";
                    txtCheque.Text = "";
                    txtNc.Text = "";
                    txtMontoPago.Text = "";
                    txtOperacion.Enabled = false;
                    txtCheque.Enabled = false;
                    txtNc.Enabled = false;
                    cboNumCta.Enabled = false;
                    txtMontoPago.Enabled = false;
                    cboNumCta.SelectedIndex = -1;
                    //if (Application.OpenForms["frmListaNCreditosSinAplicar"] != null)
                    //{
                    //    Application.OpenForms["frmListaNCreditosSinAplicar"].Activate();
                    //}
                    //else
                    //{
                    //    frmListaNCreditosSinAplicar form = new frmListaNCreditosSinAplicar();
                    //    form.CodCliente = CodCliente;
                    //    form.VentComp = VentComp;
                    //    form.ShowDialog();
                    //    if (VentComp == 1)
                    //    {
                    //        notaI = form.nota;
                    //        txtNc.Text = notaI.NumDoc;
                    //        txtMontoPago.Text = notaI.Total.ToString();
                    //    }
                    //    else
                    //    {
                    //        notaS = form.notaS;
                    //        txtNc.Text = notaS.Docref;
                    //        txtMontoPago.Text = notaS.Total.ToString();
                    //    }
                    //}
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cboBanco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //if (cmbMetodoPago.Text == "DEPOSITO" || cmbMetodoPago.Text == "TRANSFERENCIA")
                if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 6 || Convert.ToInt32(cmbMetodoPago.SelectedValue) == 9)
                {
                    cboNumCta.Enabled = true;
                    CargaCtaCte();
                }
                else
                {
                    cboNumCta.SelectedIndex = -1;
                    cboNumCta.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void CargaCtaCte()
        {
            try
            {
                //cboNumCta.DataSource = AdmCtaCte.ListaCtasBanco(Convert.ToInt32(cboBanco.SelectedValue),frmLogin.iCodAlmacen);
                cboNumCta.DataSource = AdmCtaCte.ListaCtaCtexBancoxMoneda(Convert.ToInt32(cboBanco.SelectedValue),
                    Convert.ToInt32(cmbMoneda.SelectedValue));
                cboNumCta.DisplayMember = "cuentaCorriente";
                cboNumCta.ValueMember = "codCuentaCorriente";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

        }

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmDocumentos"] != null)
                {
                    Application.OpenForms["frmDocumentos"].Close();
                }
                else
                {
                    frmDocumentos form = new frmDocumentos();
                    form.Proceso = 3;
                    form.Procedencia = 1;
                    form.direccioncaja = direccioncaja;
                    form.ShowDialog();
                    doc = form.doc;
                    CodDocumento = doc.CodTipoDocumento;
                    txtDocRef.Text = doc.Sigla;
                    if (CodDocumento != 0) { ProcessTabKey(true); } else { txtDocRef.Text = ""; }
                }
            }  
        }        

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmSerie"] != null)
                {
                    Application.OpenForms["frmSerie"].Activate();
                }
                else
                {
                    frmSerie form = new frmSerie();
                    //form.DocSeleccionado = 18;
                    form.DocSeleccionado = CodDocumento;
                    form.Sigla = txtDocRef.Text;
                    form.Proceso = 3;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                    txtSerie.Text = ser.Serie;
                    txtNumero.Text = ser.Numeracion.ToString().PadLeft(9,'0');
                    txtDocumento.Text = txtDocRef.Text + " " + ser.Serie + " - " + ser.Numeracion.ToString().PadLeft(9, '0');
                    if (CodSerie != 0)
                    {
                        ProcessTabKey(true);
                        if (txtSerie.Text == "") txtSerie.Focus();
                    }
                }
            }
        }
    }
}
