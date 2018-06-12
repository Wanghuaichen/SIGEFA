using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmCancelarPagoMasivo : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmFactura Admfac=new clsAdmFactura();
        clsFactura fac=new clsFactura();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida notaS = new clsNotaSalida();
        clsAdmLetra AdmLetra = new clsAdmLetra();
        clsLetra letra = new clsLetra();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmMetodoPago admMPago = new clsAdmMetodoPago();
        clsValidar val = new clsValidar();
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        clsAdmVendedor AdmVen = new clsAdmVendedor();
        clsMoneda Mon = new clsMoneda();
        clsAdmMoneda AdmMoned = new clsAdmMoneda();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        public clsFacturaVenta venta = new clsFacturaVenta();
        clsSerie ser = new clsSerie();
        clsAdmSerie Admser = new clsAdmSerie();
        clsConsultasExternas ext = new clsConsultasExternas();
        //*** Para la Carga de tarjetas y Bancos ***
        clsAdmBanco AdmBan = new clsAdmBanco();
        clsAdmTarjetaPago AdmTar = new clsAdmTarjetaPago();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();

        //******* Carga de las Cuentas Ctes ********
        clsAdmCtaCte AdmCtaCte = new clsAdmCtaCte();
        clsCtaCte CtaCte = new clsCtaCte();

        clsReporteFlujoCaja ds = new clsReporteFlujoCaja();

        public String CodNota;
        public Int32 CodLetra;
        public Int32 tipo;
        Boolean tipopago;
        public Int32 Procede = 0; // (1)Venta

        public Int32 mon = 0;
        public Double Monto = 0;
        public Int32 CodDocumento;
        public Int32 CodSerie;

        public Int32 CodCliente;
        clsNotaIngreso notaI = new clsNotaIngreso();
        clsAdmNotaIngreso AdmNotaI = new clsAdmNotaIngreso();
        private clsUsuario clsentuser = new clsUsuario();
        String sigl;
        private clsAdmUsuario admuser = new clsAdmUsuario();
        private Boolean aprobar = false;
        public int VentComp = 0; // (1) VENTAS - (2) COMPRAS
        clsCliente cli = new clsCliente();
        clsAdmCliente Admcli = new clsAdmCliente();
        public frmCancelarPagoMasivo()
        {
            InitializeComponent();
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMoned.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = -1;
        }

        //*** Para la Carga de tarjetas y Bancos ***

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
                cboBanco.DataSource = AdmBan.MuestraBancos();
                cboBanco.DisplayMember = "descripcion";
                cboBanco.ValueMember = "codbanco";
                cboBanco.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void muestra_botones(Boolean activo)
        {
            label16.Visible = activo;
            txtSerie.Visible = activo;
        }

        private void posiciona_textbox()
        {
            txtSerie.Location = new Point(94, 15);
            txtNumero.Location = new Point(151, 15);
        }

        private void valida_serie(String sigl)
        {
            txtDocRef.Text = sigl;
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtDocRef_KeyPress(txtDocRef, ee);
            txtSerie_KeyPress(txtDocRef, ee);
        }
        
        private void frmCancelarPagoMasivo_Load(object sender, EventArgs e)
        {
            cargaMoneda();
            CargarBancos();
            CargarTarjetas();
            cboTarjeta.SelectedIndex = -1;
            cboBanco.SelectedIndex = -1;
            //valida_serie();

            if (tipo == 1)
            {
                
                CargaFactura();
                txtTipoCambio.Enabled = true;
                txtTipoCambio.ReadOnly = false;
                this.Text = "CANCELAR PAGO";
                sigl = "RP";
                valida_serie(sigl);
                muestra_botones(true);
                posiciona_textbox();
            }
            else if (tipo == 2)
            {
                CargaLetra();
            }
            else if (tipo == 3)
            {
                CargaVendedores();
                cbovendedor.Visible = true;
                CargaNotaSalida();
                sigl = "RC";
                valida_serie(sigl);
                muestra_botones(true);
                posiciona_textbox();
                this.Text = "COBRANZA VENTAS";
                //if (venta != null) 
                //{
                //    if (venta.FormaPago == 6)
                //    {
                //        cbovendedor.SelectedValue = 5;
                //    }
                //    else
                //    {
                //        cbovendedor.SelectedValue = venta.CodVendedor;
                //    }
                //}
            }
            else if (tipo == 4)
            {
                CargaVendedores();
                cbovendedor.Visible = true;
                CargaLetra();
                if (letra != null)
                {                    
                    cbovendedor.SelectedValue = 5;                   
                }
            }
            CargaMetodosPagos();
            cmbMetodoPago_SelectionChangeCommitted(cmbMetodoPago, null);
            //cmbMoneda.SelectedIndex = 0;
            Mon = AdmMoned.CargaMoneda(mon);
            if (tipo == 1 || tipo == 2)
            {
                if (Mon != null)
                {
                    txtMoneda.Text = Mon.SDescripcion;
                    tc = AdmTc.CargaTipoCambio(DateTime.Now.Date, 2);
                    if (tc != null)
                    {
                        txtTipoCambio.Text = tc.Venta.ToString();
                        //txtTipoCambio.ReadOnly = true;
                    }
                    else
                    {
                        txtTipoCambio.Text = "";
                        txtTipoCambio.ReadOnly = false;
                    }
                    cmbMoneda.SelectedValue = Mon.IcodMoneda;
                }
            }
            else if(tipo == 3 || tipo == 4)
            {
                if (Mon != null)
                {
                    txtMoneda.Text = Mon.SDescripcion;
                    tc = AdmTc.CargaTipoCambio(DateTime.Now.Date, 2);
                    if (tc != null)
                    {
                        txtTipoCambio.Text = tc.Compra.ToString();
                        txtTipoCambio.ReadOnly = true;
                    }
                    else
                    {
                        txtTipoCambio.Text = "";
                        txtTipoCambio.ReadOnly = false;
                    }
                    cmbMoneda.SelectedValue = Mon.IcodMoneda;
                }
            }

        }

        private void CargaMetodosPagos()
        {
            cmbMetodoPago.DataSource = admMPago.CargaMetodoPagos();
            cmbMetodoPago.DisplayMember = "descripcion";
            cmbMetodoPago.ValueMember = "codMetodoPago";            
        }

        private void CargaVendedores()
        {
            cbovendedor.DataSource = AdmVen.MuestraVendedoresDestaque();
            cbovendedor.DisplayMember = "apellido";
            cbovendedor.ValueMember = "codVendedor";
            cbovendedor.SelectedIndex =0;
        }

        private void CargaFactura()
        {
            try
            {
                
                fac = Admfac.CargaFactura(Convert.ToInt32(CodNota));
                if (fac != null)
                {
                    txtDocumento.Text = fac.DocumentoFactura;
                    mon = fac.Moneda;
                    Mon=AdmMoned.CargaMoneda(mon);
                    txtMoneda.Text = Mon.SDescripcion;
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", fac.Pendiente.ToString());   
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Cancelar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaLetra()
        {
            try
            {                
                letra = AdmLetra.CargaLetra(CodLetra);
                if (letra != null)
                {
                    txtDocumento.Text = letra.NumDocumento;
                    if (letra.CodMoneda == 1) { txtMoneda.Text = "NUEVOS SOLES"; } else { txtMoneda.Text = "DOLARES"; }
                    cmbMoneda.SelectedValue = letra.CodMoneda;
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", letra.MontoPendiente);
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Cancelar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private Boolean creoCorrelativo = false;
        private void CargaNotaSalida()
        {
            try
            {
                venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(CodNota));
                Mon = AdmMoned.CargaMoneda(venta.Moneda);
                if (venta != null)
                {
                    mon = venta.Moneda;
                    txtDocumento.Text = venta.SiglaDocumento + " " + venta.Serie + " " + venta.NumDoc;
                    if (venta.Serie == "")
                    {
                        //creoCorrelativo=true
                    }
                    if (venta.Moneda == 1) { txtMoneda.Text = "NUEVOS SOLES"; } else { txtMoneda.Text = "DOLARES"; }
                    cmbMoneda.SelectedValue = venta.Moneda;
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", venta.Pendiente);
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Cancelar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {         
            if (superValidator1.Validate())
            {
                if (tipo == 1 || tipo == 2)//Pagos - salidas de dinero
                {
                    Pag.CodNota = fac.CodFactura.ToString();
                    Pag.CodLetra = letra.CodLetra;
                    Pag.CodTipoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue); //metodo de pago
                    Pag.CodMoneda =Convert.ToInt32(cmbMoneda.SelectedValue);
                    
                    Pag.Tipo = tipopago;// total o parcial
                    Pag.IngresoEgreso = false;//egreso
                    if (txtTipoCambio.Text == "") { Pag.TipoCambio = 0; } else { Pag.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text); };
                    Pag.MontoPagado = Convert.ToDecimal(txtMontoPago.Text);
                    Pag.MontoCobrado = Convert.ToDecimal(txtMontoPago.Text);
                    Pag.Vuelto = 0;
                    Pag.NOperacion = txtOperacion.Text;
                    Pag.NCheque = txtCheque.Text;
                    Pag.FechaPago = dtpFecha.Value;
                    Pag.Observacion = txtObservacion.Text;
                    Pag.CodUser = frmLogin.iCodUser;
                    Pag.CodAlmacen = frmLogin.iCodAlmacen;
                    Pag.CodSerie = CodSerie;
                    Pag.Serie = txtSerie.Text;
                    Pag.NumDoc = txtNumero.Text;
                    Decimal montoNC = 0;
                    Decimal montpen = Convert.ToDecimal(txtMontoPendiente.Text);
                    montoNC = Convert.ToDecimal(txtMontoPago.Text);
                    if (Convert.ToDecimal(txtMontoPago.Text) > montpen) { montoNC = montpen; }

                    if (Admpag.insert(Pag))
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.DialogResult = DialogResult.Yes;
                        if (VentComp == 2)
                        {
                            notaS.DocumentoReferencia = Convert.ToInt32(CodNota);// Nota Actual
                            AdmVenta.ActualizaPendienteCredito(montoNC, Convert.ToInt32(notaS.CodNotaSalida), notaS.CodAlmacen, 2);
                            AdmNotaS.ActualizaNCreditoCompraSinAplicar(notaS);
                        } 
                        Deshabilita_botones(false);
                        btnImprimir.Visible = true;
                        //this.Close();

                    }
                }
                else if (tipo == 3 || tipo == 4)//Cobros - ingresos de dinero
                {
                    Pag.CodNota = venta.CodFacturaVenta.ToString();
                    Pag.CodLetra = letra.CodLetra;
                    Pag.CodTipoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue); //metodo de pago
                    Pag.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    Pag.CodCobrador = Convert.ToInt32(cbovendedor.SelectedValue); //Cobrador
                    Pag.Tipo = tipopago;// total o parcial
                    Pag.IngresoEgreso = true;//ingreso
                    if (txtTipoCambio.Text == "") { Pag.TipoCambio = 0; } else { Pag.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text); };
                    Pag.MontoPagado = Convert.ToDecimal(txtMontoPago.Text);
                    Pag.MontoCobrado = Convert.ToDecimal(txtMontoPago.Text);
                    Pag.Vuelto = 0;
                    Pag.codCtaCte = Convert.ToInt32(cboNumCta.SelectedValue);
                    Pag.CtaCte = Convert.ToString(cboNumCta.Text);
                    Pag.NOperacion = txtOperacion.Text;
                    Pag.NCheque = txtCheque.Text;
                    Pag.FechaPago = dtpFecha.Value;
                    Pag.Observacion = txtObservacion.Text;
                    Pag.CodUser = frmLogin.iCodUser;
                    Pag.CodAlmacen = frmLogin.iCodAlmacen;
                    Pag.CodSerie = CodSerie;
                    /* SI NECECITA APROBACION NO CREA NUMERACION    */
                    if (aprobar)
                    {
                        Pag.Serie = "";
                        Pag.NumDoc = "";
                        Pag.Referencia = "";
                    }
                    else
                    {
                        Pag.Serie = txtSerie.Text;
                        Pag.NumDoc = txtNumero.Text;
                        Pag.Referencia = txtNc.Text;
                    }
                    /* SI NECECITA APROBACION NO CREA NUMERACION    */

                    //***** Datos para las operaciones de Venta ******
                    Pag.CodBanco = Convert.ToInt32(cboBanco.SelectedValue);
                    Pag.NOperacion = Convert.ToString(txtOperacion.Text.Trim());
                    Pag.CodTarjeta = Convert.ToInt32(cboTarjeta.SelectedValue);
                    Pag.NCheque = Convert.ToString(txtCheque.Text.Trim());
                    //************************************************


                    //********* Verificando campos faltantes **********
                    if (Convert.ToInt32(cmbMetodoPago.SelectedValue) == 6 || Convert.ToInt32(cmbMetodoPago.SelectedValue)==9)
                    {
                        if (txtOperacion.Text.Trim() == "" || cboBanco.Text == "" || txtMontoPago.Text=="")
                        {
                            MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { Pagar(); btnImprimir.Visible = false;  }
                    }
                    else if (Convert.ToInt32(cmbMetodoPago.SelectedValue)==8)
                    {
                        if (txtOperacion.Text.Trim() == "" || cboTarjeta.Text == "" || txtMontoPago.Text == "")
                        {
                            MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { Pagar(); }
                    }
                    else if (Convert.ToInt32(cmbMetodoPago.SelectedValue)==7)
                    {
                        if (txtCheque.Text.Trim() == "" || cboBanco.Text == "" || txtOperacion.Text.Trim() == "" || txtMontoPago.Text == "")
                        {
                            MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { Pagar(); btnImprimir.Visible = false;  }
                    }
                    else if (Convert.ToInt32(cmbMetodoPago.SelectedValue)==10)
                    {
                        if (txtNc.Text.Trim() == "" || txtMontoPago.Text == "")
                        {
                            MessageBox.Show("Ingresar Datos Necesarios", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Decimal montoNC = 0;
                            Decimal montpen = Convert.ToDecimal(txtMontoPendiente.Text);
                            montoNC = Convert.ToDecimal(txtMontoPago.Text);
                            if (Convert.ToDecimal(txtMontoPago.Text) > montpen) { montoNC = montpen; }
                            Pagar();
                            if (VentComp == 1)
                            {
                                notaI.CodReferencia = Convert.ToInt32(CodNota);// Nota Actual                                
                                AdmVenta.ActualizaPendienteCredito(montoNC, Convert.ToInt32(notaI.CodNotaIngreso), notaI.CodAlmacen, 1);
                                AdmNotaI.ActualizaNCreditoVentaSinAplicar(notaI);
                            }
                        }
                    }
                    else
                    {
                        Pagar();
                    }
 
                }

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
                txtObservacion.Text = p.Observacion;
                txtOperacion.Text = p.NOperacion;
                txtMontoPago.Text = p.MontoCobrado.ToString();
                dtpFecha.Value = p.FechaPago;
                cbovendedor.SelectedValue = p.CodCobrador;
                txtSerie.Text = p.Serie;
                txtNumero.Text = p.NumDoc;
            }
        }

        private void Deshabilita_botones(Boolean Estado)
        {
            cboBanco.Enabled = Estado;
            cboNumCta.Enabled = Estado;
            cboTarjeta.Enabled = Estado;
            cbovendedor.Enabled = Estado;
            txtCheque.Enabled = Estado;
            txtOperacion.Enabled = Estado;
            txtObservacion.Enabled = Estado;
            txtMontoPago.Enabled = Estado;
            dtpFecha.Enabled = Estado;
            btnAceptar.Enabled = Estado;
            btnCancelar.Enabled = Estado;
            txtSerie.Enabled = Estado;
            txtNumero.Enabled = Estado;
            txtNumero.Visible = !Estado;
        }

        private void Pagar()
        {
            try
            {
                if (Convert.ToInt32(cmbMetodoPago.SelectedValue) != 6 && Convert.ToInt32(cmbMetodoPago.SelectedValue) != 7 && Convert.ToInt32(cmbMetodoPago.SelectedValue) != 9)
                {
                    Pag.Aprobado = 2;
                }
                else
                {
                    Pag.Aprobado = 1;
                }
                   
                    if (Admpag.insert(Pag))
                    {
                        MessageBox.Show("Pago Realizado Correctamente", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnImprimir.Visible = true;
                        cargaPago(Pag);
                        Deshabilita_botones(false);

                        //PARA ENVIAR EMAIL A TESORERIA
                        if (Pag.Aprobado == 1)
                        {
                            if (EnviaCorreo(Pag))
                            {
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("EL CORREO NO SE PUDO ENVIAR COMUNIQUESE CON SOPORTE TECNICO");
                                this.Close();
                            }

                        }


                        //if (Convert.ToDouble(txtMontoPendiente.Text).Equals(Convert.ToDouble(txtMontoPago.Text)))
                        //{
                        //    this.Close();
                        //}
                        //else
                        //{
                        //    txtMontoPendiente.Text = Convert.ToString(Convert.ToDouble(txtMontoPendiente.Text) - Convert.ToDouble(txtMontoPago.Text));
                        //    txtMontoPago.Text = "";
                        //    txtMontoPago.Focus();
                        //}
                    }
                    txtMontoPendiente.Text = Convert.ToString(Convert.ToDouble(txtMontoPendiente.Text) - Convert.ToDouble(txtMontoPago.Text));
                    //    txtMontoPago.Text = "";
                    //    txtMontoPago.Focus();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

        }


        private bool EnviaCorreo(clsPago Pag)
        {
            clsentuser = null;
            try
            {
                clsentuser = admuser.MuestraUsuario(frmLogin.iCodUser);
                DataTable correosTesoreria = new DataTable();
                String sRutaPrincipal = "";
                String sArchivo = "";
                String sRutaFinal = "";
                String sUserCredential = clsentuser.Email;
                String sPassCredential = clsentuser.ContraEmail;
                MailMessage correo = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                String destino = "";
                String asunto = "";
                String cuerpo = "";
                String ccs = string.Empty;
                smtp.Host = clsentuser.Host;
                if (clsentuser.Host == "smtp.gmail.com" || clsentuser.Host == "smtp.live.com")
                {
                    smtp.EnableSsl = true;
                }
                smtp.Credentials = new System.Net.NetworkCredential(sUserCredential, sPassCredential);
                correo.From = new MailAddress(clsentuser.Email);
                correosTesoreria = admuser.correoTesoreria();

                if (correosTesoreria != null)
                {
                    if (correosTesoreria.Rows.Count > 1)
                    {
                        for (int i = 0; i <= correosTesoreria.Rows.Count - 1; i++)
                        {
                            destino += correosTesoreria.Rows[i]["email"].ToString() + ",";
                        }
                        destino = destino.TrimEnd(',');
                        correo.To.Add(destino.Trim() + "," + admuser.MuestraUsuarioNivel().Email);
                    }
                    else if (correosTesoreria.Rows.Count == 1)
                    {
                        destino = correosTesoreria.Rows[0]["email"].ToString();
                        correo.To.Add(destino.Trim() + "," + admuser.MuestraUsuarioNivel().Email);
                    }
                }
                asunto = "PAGO POR APROBAR";
                cuerpo = "EL SIGUIENTE PAGO: N. " + Pag.Serie + "-" + Pag.NumDoc + " NECESITA APROBACION." + Environment.NewLine
                    + "SUCURSAL: " + frmLogin.sAlmacen + Environment.NewLine + "USUARIO: " + frmLogin.sUsuario + Environment.NewLine
                    + DateTime.Now + Environment.NewLine;

                correo.Subject = asunto;
                correo.Body = cuerpo;
                correo.IsBodyHtml = false;
                correo.Priority = System.Net.Mail.MailPriority.Normal;
                #region adjuntos
                //String arch_adj = "";
                ////aquí se añaden los archivos adjuntos
                //if (tipo == 1) arch_adj = @"C:\Ordenes de Compra\" + link_adjunto.Text;
                //else if (tipo == 2) arch_adj = @"C:\Cotizaciones\" + link_adjunto.Text;
                ////String arch_adj = @"C:\Ordenes de Compra\" + link_adjunto.Text;
                //correo.Attachments.Add(new Attachment(arch_adj));
                //if (dgvadjuntos.RowCount >= 1)
                //{
                //    Int32 iFila = 0;
                //    Int32 iRow = 0;
                //    DataGridViewRow Row;

                //    iRow = dgvadjuntos.Rows.Count;
                //    for (iFila = 0; iFila < iRow; iFila++)
                //    {
                //        Row = dgvadjuntos.Rows[iFila];
                //        sArchivo = Row.Cells[1].Value.ToString().Trim();
                //        sRutaFinal = sArchivo;
                //        correo.Attachments.Add(new Attachment(sRutaFinal));
                //    }
                //}
                #endregion
                smtp.Send(correo);
                MessageBox.Show("Correo Enviado Satisfactoriamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
                txtTipoCambio.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipoCambio.Text = "";
                txtTipoCambio.ReadOnly = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Admpag.AnularPago(Pag.CodPago))
            //    {
            //        MessageBox.Show("Pago Cancelada", "Gestion de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close();
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            this.Close();
        }

        private void txtMontoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
            
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {            
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;            
        }

        private void frmCancelarPagoMasivo_Shown(object sender, EventArgs e)
        {
            if (txtSerie.Visible) txtSerie.Focus();
            else txtMontoPago.Focus();
        }

        private void txtMontoPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMontoPago.Text != "")
                {
                    if (txtMontoPago.Text != "0")
                    {
                        if (Convert.ToDouble(txtMontoPago.Text) >= Convert.ToDouble(txtMontoPendiente.Text))
                        {
                            unSelected(Convert.ToDecimal(txtMontoPago.Text), Convert.ToDecimal(txtMontoPendiente.Text),
                                dataFacturas.Rows);
                            if (tipo == 1)
                            {
                                txtParcial.Text = "PAGO TOTAL";
                            }
                            else
                            {
                                txtParcial.Text = "COBRO TOTAL";
                            }

                            tipopago = true;
                        }
                        else
                        {
                            if (tipo == 1)
                            {
                                txtParcial.Text = "PAGO PARCIAL";
                            }
                            else
                            {
                                txtParcial.Text = "COBRO PARCIAL";
                            }
                            tipopago = false;
                        }
                    }
                }
                else
                {
                    txtParcial.Text = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void unSelected(Decimal txtMontoPagoD, Decimal txtMontoPendienteD, DataGridViewRowCollection dataGVRCollection)
        {
            //try
            //{
            //    Decimal resultD = txtMontoPendienteD - txtMontoPagoD;
            //    List<Int32> idresults= new List<int>();
            //    foreach (DataGridViewRow row in dataGVRCollection)
            //    {
            //        if (Convert.ToDecimal(row.Cells["pendientes"].Value)>resultD)
            //        {
                        
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtMontoPago_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Double box_double = 0;
                Double.TryParse(txtMontoPago.Text, out box_double);
                if (box_double > Convert.ToDouble(txtMontoPendiente.Text) && txtMontoPago.Text != "")
                {
                    txtMontoPago.Text = txtMontoPendiente.Text;
                    txtMontoPago.Select(txtMontoPago.Text.Length, 0);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cmbMetodoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                buscaAprobacion(Convert.ToInt32(cmbMetodoPago.SelectedValue));
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
                    if (Application.OpenForms["frmListaNCreditosSinAplicar"] != null)
                    {
                        Application.OpenForms["frmListaNCreditosSinAplicar"].Activate();
                    }
                    else
                    {
                        frmListaNCreditosSinAplicar form = new frmListaNCreditosSinAplicar();
                        form.CodCliente = CodCliente;
                        form.VentComp = VentComp;
                        form.ShowDialog();
                        if (VentComp == 1)
                        {
                            notaI = form.nota;
                            txtNc.Text = notaI.NumDoc;
                            txtMontoPago.Text = notaI.Total.ToString();
                        }
                        else
                        {
                            notaS = form.notaS;
                            txtNc.Text = notaS.Docref;
                            txtMontoPago.Text = notaS.Total.ToString();
                        }      
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        private void buscaAprobacion(int p)
        {
            DataTable nuevaDataMetodo = new DataTable();
            try
            {
                nuevaDataMetodo = null;
                nuevaDataMetodo = (DataTable)cmbMetodoPago.DataSource;
                DataRow dataRow = nuevaDataMetodo.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["codMetodoPago"]) == p);
                if (dataRow != null)
                {
                    if (Convert.ToInt32(dataRow["aprobacion"].ToString()) == 0)
                    {
                        aprobar = false;
                    }
                    else if (Convert.ToInt32(dataRow["aprobacion"].ToString()) == 1)
                    {
                        aprobar = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargaCtaCte()
        {
            try
            {
                cboNumCta.DataSource = AdmCtaCte.ListaCtasBanco(Convert.ToInt32(cboBanco.SelectedValue),frmLogin.iCodAlmacen);
                cboNumCta.DisplayMember = "cuentaCorriente";
                cboNumCta.ValueMember = "codCuentaCorriente";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

        }

        private void cboBanco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbMetodoPago.Text == "DEPOSITO" || cmbMetodoPago.Text == "TRANSFERENCIA")
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

        private void txtOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {//Para obligar a que sólo se introduzcan números 
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {   //Para obligar a que sólo se introduzcan números 
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (tipo == 3)
            {
                CRImpresionPago rpt = new CRImpresionPago();
                frmRptImpresionPago frm = new frmRptImpresionPago();
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                rpt.SetDataSource(ds.ReporteImpresionPago(Pag.CodPago, frmLogin.iCodAlmacen));
                frm.cRVImpresionPago.ReportSource = rpt;
                frm.Show();
            }
            else if (tipo == 1)
            {
                CRImpresionCobro rpt = new CRImpresionCobro();
                frmRptImpresionPago frm = new frmRptImpresionPago();
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                rpt.SetDataSource(ds.ReporteImpresionCobro(Pag.CodPago, frmLogin.iCodAlmacen));
                frm.cRVImpresionPago.ReportSource = rpt;
                frm.Show();
            }
        }

        private void cmbMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VentaEnMoneda();
        }

        private void VentaEnMoneda()
        {
            Decimal TipoCambio = 0;

            TipoCambio = Convert.ToDecimal(txtTipoCambio.Text.Trim());
            if (mon == 1)
            {
                if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                {
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(venta.Pendiente) / TipoCambio);
                }
                else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                {
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(venta.Pendiente));
                }
            }
            else 
            {
                if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                {
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(venta.Pendiente));
                }
                else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                {
                    txtMontoPendiente.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(venta.Pendiente) * TipoCambio);
                }
            }
            
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                
            else
                e.IsValid = true;
        }

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                
            else
                e.IsValid = true;
        }

        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Enabled)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator7_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Enabled)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
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
                    form.Sigla = sigl;
                    form.Proceso = 3;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                    txtSerie.Text = ser.Serie;
                    if (CodSerie != 0)
                    {
                        ProcessTabKey(true);
                        if (txtSerie.Text == "") txtSerie.Focus();
                    }
                }
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (BuscaSerie())
                {
                    txtSerie.Text = ser.Serie;
                    if (ser.PreImpreso)
                    {
                        txtNumero.Text = "";
                        txtNumero.Visible = true;
                        txtNumero.Focus();
                    }
                    else
                    {
                        txtNumero.Text = "";
                        txtNumero.Visible = false;
                        txtNumero.Text = ser.Numeracion.ToString();
                    }

                    ProcessTabKey(true);
                }
                //else
                //{
                //    MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda",
                //                "Cancelar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private Boolean BuscaSerie()
        {
            ser = Admser.BuscaSeriexDocumento(CodDocumento, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            //if (BuscaSerie2())
            if (BuscaSerie2())
            {
                txtSerie.Text = ser.Serie;
                if (ser.PreImpreso)
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = true;
                    txtNumero.Focus();
                }
                else
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = false;
                    txtNumero.Text = ser.Numeracion.ToString();
                }
            }
        }

        private Boolean BuscaSerie2()
        {
            ser = Admser.MuestraSerie(CodSerie, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtNumero.Visible = false;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "" && txtNumero.Visible)
            {
                txtNumero.Focus();
            }
        }

        private void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtDocRef.Text != "")
                {
                    if (BuscaTipoDocumento())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaTipoDocumento()
        {
            doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
            if (doc != null)
            {
                CodDocumento = doc.CodTipoDocumento;
                txtDocRef.Text = doc.Sigla;
                return true;
            }
            else
            {
                CodDocumento = 0;
                txtDocRef.Text = "";
                return false;
            }
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
        }

        private void customValidator1_ValidateValue_1(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false; 
        }

        private void txtCodClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmClientesLista"] != null)
                {
                    Application.OpenForms["frmClientesLista"].Activate();
                }
                else
                {
                    frmClientesLista form = new frmClientesLista();
                    form.Proceso = 3;
                    //form.Tipo = cmbTipoCodigo.SelectedIndex;
                    form.ShowDialog();
                    cli = form.cli;
                    CodCliente = cli.CodCliente;
                    if (CodCliente != 0)
                    {
                        CargaCliente();
                    }
                }
            }
        }

        private void CargaCliente()
        {
            try
            {
                cli = Admcli.MuestraCliente(CodCliente);
                txtNombreCliente.Text = cli.RazonSocial;
                txtCodClientes.Text = cli.CodigoPersonalizado.ToString();
                if (CodCliente>0)
                {
                    CargaFacturasxPagar(CodCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaFacturasxPagar(int CodCliente)
        {
            try
            {
                if (dataFacturas.DataSource!=null)
                {
                    dataFacturas.DataSource = null;
                }
                else
                {
                    dataFacturas.AutoGenerateColumns = false;
                    dataFacturas.DataSource = AdmVenta.ListaFacturas_ventaCliente(CodCliente);
                    dataFacturas.SelectAll();
                    if (dataFacturas.DataSource != null)
                    {
                        CargaMontoPendiente(dataFacturas.SelectedRows);    
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaMontoPendiente(DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection)
        {
            try
            {
                Decimal montopendienteS=0;
                foreach (DataGridViewRow row in dataGridViewSelectedRowCollection)
                {
                    montopendienteS = montopendienteS + Convert.ToDecimal(row.Cells[pendientes.Name].Value);
                }
                txtMontoPendiente.Text = montopendienteS.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCodClientes.Text != "")
                {
                    try
                    {
                        cli = Admcli.MuestraCliente(CodCliente);
                        txtNombreCliente.Text = cli.RazonSocial;
                        txtCodClientes.Text = cli.CodigoPersonalizado.ToString();
                        if (CodCliente > 0)
                        {
                            CargaFacturasxPagar(CodCliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataFacturas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataFacturas.DataSource != null)
            {
                CargaMontoPendiente(dataFacturas.SelectedRows);
            }
        }

        

       

        
    }
}
