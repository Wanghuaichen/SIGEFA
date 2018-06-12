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
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmRecibos_CajaChica : DevComponents.DotNetBar.Office2007Form
    {
        clsValidar val = new clsValidar();       
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsSerie ser = new clsSerie();
        clsAdmSerie Admser = new clsAdmSerie();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmMoneda AdmMoned = new clsAdmMoneda();
        clsCaja caja = new clsCaja();
        clsCajaChicaMov cajachica = new clsCajaChicaMov();
        clsAdmAperturaCierre admcajachica = new clsAdmAperturaCierre();

        public Int32 CodtipoCajaChica = 0;
        public Int32 Tipo = 0;

        public Int32 Proceso = 0, tipocaja=0;
        public Int32 CodCaja = 0;

        public Decimal SaldoCaja = 0;

        String sigl;
        public Int32 CodDocumento = 0, codrecibo = 0;
        public Int32 CodSerie;
        //public Int32 codmovcaja = 0;

        public frmRecibos_CajaChica()
        {
            InitializeComponent();
        }

        private void frmRecibos_CajaChica_Load(object sender, EventArgs e)
        {
            cargaMoneda();
            CargaTipoCambio();
            if (Proceso == 3) {
                SoloLectura(true);
            }
        }
        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMoned.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            //cmbMoneda.SelectedIndex = -1;
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
        private void valida_serie(String sigl)
        {
            //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            //txtSerie_KeyPress(sigl, ee);
        }


        private void SoloLectura(Boolean estado)
        {
           
            txtDescripcion.Enabled = !estado;
            txtMonto.Enabled = !estado;
            dtpFecha.Enabled = !estado;
            btnGuardar.Visible = !estado;
            txtNombre.Enabled = !estado;
            
            txtDni.Enabled = !estado;            
        }
       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0)
                {
                    cajachica.CodSucursal = frmLogin.iCodSucursal;
                    cajachica.Codcaja = CodCaja;
                    cajachica.CodPago = 0;
                    cajachica.Concepto = txtDescripcion.Text;
                    cajachica.Monto = Convert.ToDecimal(txtMonto.Text.Trim());
                    cajachica.Nombre = txtNombre.Text;
                    cajachica.Dni = txtDni.Text;
                    if (cmbTipo.SelectedIndex == 0) { cajachica.Tipo = 1; /* tipo 1 => ingreso */  }
                    else if (cmbTipo.SelectedIndex == 1) { cajachica.Tipo = 2; /* tipo 1 => egreso  */ }
                    cajachica.Tipomovimiento = 2; // 2 movimiento
                    cajachica.Fecha = dtpFecha.Value;
                    cajachica.Tipodocumento = CodDocumento;
                    cajachica.CodSerie = CodSerie;
                    cajachica.Serie = txtSerie.Text;
                    cajachica.NumDocumento1 = txtNumero.Text.Trim();
                    cajachica.Toneladas = 0;
                    cajachica.CodTipoPagoCaja = 5; // 5 =>  efectivo
                    cajachica.Estado = 1;
                    cajachica.CodUser = frmLogin.iCodUser;
                    cajachica.Codalmacen = frmLogin.iCodAlmacen;
                    cajachica.Codmoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    cajachica.Tcventa = Convert.ToDecimal(txtTipoCambio.Text);

                    if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2) 
                    {
                        cajachica.Monto = (cajachica.Monto * cajachica.Tcventa);
                    }
                    
                    if (Proceso == 1)
                    {
                        if (admcajachica.InsertMovCajaChica(cajachica))
                        {
                            codrecibo = cajachica.CodMovCaja;
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //txtCodigo.Text = cajachica.CodMovCaja.ToString();

                        }
                    }
                    else if (Proceso == 2)
                    {
                        //recibo.CodRecibos = Convert.ToInt32(txtCodigo.Text.Trim());

                        //if (AdmRecibo.update(recibo))
                        //{
                        //    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                    SoloLectura(true);
                    Proceso = 0;
                    btnReporte2.Visible = true;
                    btnReporte2.Enabled = true;
                }
            }
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
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

        private void txtNumeracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }
               

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMonto.Text != "")
            {
                Decimal Monto = Convert.ToDecimal(txtMonto.Text.Trim()) + (Convert.ToDecimal(lblSaldoCaja.Text.Trim()));
                if (Convert.ToDecimal(txtMonto.Text.Trim()) > Monto)
                {
                    MessageBox.Show("Saldo Insuficiente en Caja Chica", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonto.Text = Monto.ToString();
                    txtMonto.SelectAll();
                }
            }
        }

        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTipo.Text == "INGRESO")
            {
                txtDocRef.Text = "RCHI";
                doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
                CodDocumento = doc.CodTipoDocumento;
                //cmbtipopagoser.Enabled = true;
                //carga(1);

            }
            else if (cmbTipo.Text == "EGRESO")
            {
                txtDocRef.Text = "RCHE";
                doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
                CodDocumento = doc.CodTipoDocumento;
                //cmbtipopagoser.Enabled = true;
                //carga(0);
            }
        }

        private void carga(Int32 tipo)
        {
            //cmbtipopagoser.DataSource = AdmFlu.ListaPagoCajaChica(tipo);
            //cmbtipopagoser.DisplayMember = "descripcion";
            //cmbtipopagoser.ValueMember = "codtipopagocajachica";
            //cmbtipopagoser.SelectedIndex = -1;            
        }

       

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipo.Text == "INGRESO")
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeEgresosCajaChica rpt = new CRRecibodeEgresosCajaChica();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(1, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();

                }
                else if (cmbTipo.Text == "EGRESO")
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosMovilidadAgazajosFestividades rpt = new CRReciboEgresosMovilidadAgazajosFestividades();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(2, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }

                /*Int32 tip = Convert.ToInt32(cmbTipo.SelectedValue);


                if (tip == 1)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeEgresosCajaChica rpt = new CRRecibodeEgresosCajaChica();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(tip, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();

                }
                else if (tip == 2)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosMovilidadAgazajosFestividades rpt = new CRReciboEgresosMovilidadAgazajosFestividades();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(tip, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 3)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosMovilidsdCajaChica rpt = new CRReciboEgresosMovilidsdCajaChica();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(tip, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 4)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosPorTercerosCajaChica rpt = new CRReciboEgresosPorTercerosCajaChica();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(tip, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 6)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeIngresosCajaChica rpt = new CRRecibodeIngresosCajaChica();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboCajaChica(tip, codrecibo));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }*/
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento el siguiente error" + ex.ToString(), "Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    txtNumero.Text = ser.Numeracion.ToString().PadLeft(9, '0');
                    txtdoc.Text = txtDocRef.Text + " " + ser.Serie + " - " + ser.Numeracion.ToString().PadLeft(9, '0');
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
