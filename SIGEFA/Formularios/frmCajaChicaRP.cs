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
    public partial class frmCajaChicaRP : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmStatusCajaChica AdmSta = new clsAdmStatusCajaChica();
        clsStatusCajaChica sta = new clsStatusCajaChica();
        clsAdmAperturaCierre AdmApe = new clsAdmAperturaCierre();
        clsCaja ape = new clsCaja();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        Int32 StadoCaja = 0; //Verificacion del estado de Cierre de Caja

        public frmCajaChicaRP()
        {
            InitializeComponent();
        }

        private void CargaStatusFlujosCaja()
        {
            try
            {
                sta = AdmSta.CargaStatusFlujosCajaChica(dtpfechaDesde.Value, dtpfechaHasta.Value);
                if (sta != null)
                {
                    lbAperturaCaja.Text = Convert.ToString(sta.AperturaCaja);

                    lbTotalVentas.Text = Convert.ToString(sta.TotalVentas);
                    lbIngresos.Text = Convert.ToString(sta.Ingresos);
                    lbSubTotalIngresos.Text = Convert.ToString(sta.TotalVentas + sta.Ingresos);

                    lbTotalPagos.Text = Convert.ToString(sta.TotalPagos);
                    lbEgresos.Text = Convert.ToString(sta.Egresos);
                    lbSubTotalEgresos.Text = Convert.ToString(sta.TotalPagos + sta.Egresos);

                    lbTotalVentasCredito.Text = Convert.ToString(sta.PorPagar);
                    lbTotalComprasCredito.Text = Convert.ToString(sta.PorCobrar);

                    Decimal Ingresos = Convert.ToDecimal(sta.TotalVentas + sta.Ingresos);
                    Decimal Egresos = Convert.ToDecimal(sta.TotalPagos + sta.Egresos);

                    Decimal Entradas = Convert.ToDecimal(sta.AperturaCaja + sta.TotalVentas + sta.Ingresos);
                    Decimal Salidas = Convert.ToDecimal(sta.TotalPagos + sta.Egresos);

                    lbTotalCaja.Text = Convert.ToString(Entradas - Salidas + sta.SumaAperturasCaja - sta.SumaCierresCaja);

                    lbTotalVentasCredito.Text = Convert.ToString(sta.PorCobrar);
                    lbTotalComprasCredito.Text = Convert.ToString(sta.PorPagar);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void CargaStatusFlujosCaja_SP() //*** Carga de CajaChica Sin Periodo ***
        {
            try
            {
                sta = AdmSta.CargaStatusFlujosCajaChica_SP(dtpfechaDesde.Value);
                if (sta != null)
                {
                    lbAperturaCaja.Text = Convert.ToString(sta.AperturaCaja);

                    lbTotalVentas.Text = Convert.ToString(sta.TotalVentas);
                    lbIngresos.Text = Convert.ToString(sta.Ingresos);
                    lbSubTotalIngresos.Text = Convert.ToString(sta.TotalVentas + sta.Ingresos);

                    lbTotalPagos.Text = Convert.ToString(sta.TotalPagos);
                    lbEgresos.Text = Convert.ToString(sta.Egresos);
                    lbSubTotalEgresos.Text = Convert.ToString(sta.TotalPagos + sta.Egresos);

                    lbTotalVentasCredito.Text = Convert.ToString(sta.PorPagar);
                    lbTotalComprasCredito.Text = Convert.ToString(sta.PorCobrar);
                    lbTotalCaja.Text = Convert.ToString(sta.AperturaCaja + (sta.TotalVentas + sta.Ingresos) - (sta.TotalPagos + sta.Egresos));

                    lbTotalVentasCredito.Text = Convert.ToString(sta.PorCobrar);
                    lbTotalComprasCredito.Text = Convert.ToString(sta.PorPagar);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void VerificarCierreCaja()
        {
            try
            {
                sta = AdmSta.VerificaStadoCaja();
                if (sta != null)
                {
                    StadoCaja = Convert.ToInt32(sta.Cantidad);
                }

                if (StadoCaja == 0)
                {
                    btnAnularCierre.Visible = false;
                    btnCerrarCaja.Enabled = true;
                    btnCerrarCaja.Visible = true;
                }
                else
                {
                    btnAnularCierre.Visible = true;
                    btnCerrarCaja.Enabled = false;
                    btnCerrarCaja.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void frmCajaChica_Load(object sender, EventArgs e)
        {
            try
            {
                dtpfechaDesde.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaHasta.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());

                gbApertura.Text = "  APERTURA DE CAJA  " + Convert.ToString(dtpfechaDesde.Text) + "  ";
                gbCierre.Text = "  CIERRE DE CAJA  " + Convert.ToString(dtpfechaHasta.Text) + "  ";

                CargaStatusFlujosCaja_SP();
                VerificarCierreCaja();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void dtpfechaDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpfechaDesde.Value.Date == dtpfechaHasta.Value.Date)
                { CargaStatusFlujosCaja_SP(); }
                else
                { CargaStatusFlujosCaja(); }

                gbApertura.Text = "  APERTURA DE CAJA  " + Convert.ToString(dtpfechaDesde.Text) + "  ";
                dtpfechaHasta.MinDate = Convert.ToDateTime(dtpfechaDesde.Value);

                if (dtpfechaDesde.Value.Date == dtpfechaHasta.Value.Date)
                {
                    VerificarCierreCaja();
                    btnCerrarCaja.Visible = true;
                    btnAnularCierre.Visible = true;
                }
                else
                {
                    btnCerrarCaja.Enabled = false;
                    btnCerrarCaja.Visible = false;
                    btnAnularCierre.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void dtpfechaHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpfechaDesde.Value.Date == dtpfechaHasta.Value.Date)
                { CargaStatusFlujosCaja_SP(); }
                else
                { CargaStatusFlujosCaja(); }

                VerificarCierreCaja();
                gbCierre.Text = "  CIERRE DE CAJA  " + Convert.ToString(dtpfechaHasta.Text) + "  ";
                dtpfechaDesde.MaxDate = Convert.ToDateTime(dtpfechaHasta.Value);

                if (dtpfechaDesde.Value.Date == dtpfechaHasta.Value.Date)
                {
                    VerificarCierreCaja();
                    btnCerrarCaja.Visible = true;
                    btnAnularCierre.Visible = true;
                }
                else
                {
                    btnCerrarCaja.Enabled = false;
                    btnCerrarCaja.Visible = false;
                    btnAnularCierre.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dtpfechaDesde.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaHasta.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());

                dtpfechaDesde.Value = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaHasta.Value = Convert.ToDateTime(System.DateTime.Now.ToString());

                CargaStatusFlujosCaja_SP();
                VerificarCierreCaja();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                ape.Montocierre = Convert.ToDecimal(lbTotalCaja.Text);
                ape.Codsucursal = frmLogin.iCodAlmacen;
                ape.CodUser = frmLogin.iCodUser;
                if (AdmApe.UpdateCierre(ape))
                {
                    //this.Close();
                    VerificarCierreCaja();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btnAnularCierre_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdmApe.AnularCierre(frmLogin.iCodAlmacen))
                {
                    VerificarCierreCaja();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        

        

        

        
    }
}
