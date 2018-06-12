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
    public partial class frmCaja : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmStatusCajaChica AdmSta = new clsAdmStatusCajaChica();
        clsStatusCajaChica sta = new clsStatusCajaChica();
        clsAdmAperturaCierre AdmApe = new clsAdmAperturaCierre();
        clsCaja ape = new clsCaja();
        clsReporteFlujoCaja ds = new clsReporteFlujoCaja();
        clsFlujoCaja flu = new clsFlujoCaja();
        clsAdmFlujoCaja admFlu = new clsAdmFlujoCaja();
        clsTipoCambio tcambio = new clsTipoCambio();
        clsAdmTipoCambio admTipoCambio =new clsAdmTipoCambio();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        Int32 StadoCaja = 0; //Verificacion del estado de Cierre de Caja
        private Double Ingresado = 0;
        private Double Soles = 0;

        public Boolean depo;
        public DateTime fecha_Depo;
        private Decimal TotalVentasMesSoles = 0, TotalVentasMesDolar = 0;

        public frmCaja()
        {
            InitializeComponent();
        }

        private void CargaStatusFlujosCaja()
        {
            try
            {
                sta = AdmSta.CargaStatusFlujosCaja(dtpfechaDesde.Value, dtpfechaHasta.Value, frmLogin.iCodSucursal);
                if (sta != null)
                {
                    lbAperturaCaja.Text = Convert.ToString(sta.AperturaCaja);

                    lbTotalVentas_S.Text = Convert.ToString(sta.TotalVentas);
                    lbTotalVentas_D.Text = Convert.ToString(sta.TotalVentasDolar);
                    lbIngresos_S.Text = Convert.ToString(sta.Ingresos);
                    lbSubTotalIngresos_S.Text = Convert.ToString(sta.TotalVentas + sta.Ingresos+sta.CobranzaSolesTotal);
                    lbSubTotalIngresos_D.Text = Convert.ToString(sta.TotalVentasDolar+sta.CobranzaDolaresTotal);

                    lbMontoDepositado_S.Text = Convert.ToString(sta.MontoDepositado);
                    lbEgresos_S.Text = Convert.ToString(sta.Egresos);
                    lbSubTotalEgresos_S.Text = Convert.ToString((sta.MontoDepositado + sta.Egresos));

                    lbTotalVentasCredito_S.Text = Convert.ToString(sta.PorCobrar);
                    lbVentasCredito_D.Text = Convert.ToString(sta.PorCobrarDolar);
                    lbTotalComprasCredito_S.Text = Convert.ToString(sta.PorPagar);
                    lbComprasCredito_D.Text = Convert.ToString(sta.PorPagarDolar);

                    lbEfectivo_S.Text = Convert.ToString(sta.SumaVentasEfectivoDia);
                    lbEfectivo_D.Text = Convert.ToString(sta.SumaVentasEfectivoDiaDolar);
                    lbDeposito_S.Text = Convert.ToString(sta.SumaVentasDepositoDia);
                    lbDeposito_D.Text = Convert.ToString(sta.SumaVentasDepositoDiaDolar);
                    lbTarjeta_S.Text = Convert.ToString(sta.SumaVentasTarjetaDia);
                    lbTarjeta_D.Text = Convert.ToString(sta.SumaVentasTarjetaDiaDolar);
                    lbCheque_S.Text = Convert.ToString(sta.SumaVentasChequeDia);
                    lbCheque_D.Text = Convert.ToString(sta.SumaVentasChequeDiaDolar);
                    lbTransferencia_S.Text = Convert.ToString(sta.SumaVentasTransferenciaDia);
                    lb_Transferencia_D.Text = Convert.ToString(sta.SumaVentasTransferenciaDiaDolar);

                    lbTotalCaja.Text = Convert.ToString((sta.AperturaCaja + (sta.TotalVentas + sta.Ingresos+sta.CobranzaSolesTotal) - (sta.MontoDepositado + sta.Egresos)));
                    lbTotalCajaDolares.Text = Convert.ToString((sta.TotalVentasDolar + sta.IngresosDolar + sta.CobranzaDolaresTotal) - (sta.EgresosDolar));


                    lbEfectivoMes_S.Text = Convert.ToString(sta.SumaVentasEfectivoMes);
                    lbEfectivoMes_D.Text = Convert.ToString(sta.SumaVentasEfectivoMesDolar);
                    lbDepositoMes_S.Text = Convert.ToString(sta.SumaVentasDepositoMes);
                    lbDepositoMes_D.Text = Convert.ToString(sta.SumaVentasDepositoMesDolar);
                    lbTarjetaMes_S.Text = Convert.ToString(sta.SumaVentasTarjetaMes);
                    lbTarjetaMes_D.Text = Convert.ToString(sta.SumaVentasTarjetaMesDolar);
                    lbChequeMes_S.Text = Convert.ToString(sta.SumaVentasChequeMes);
                    lbChequeMes_D.Text = Convert.ToString(sta.SumaVentasChequeMesDolar);
                    lbTransferenciaMes_S.Text = Convert.ToString(sta.SumaVentasTransferenciaMes);
                    lbTransferenciaMes_D.Text = Convert.ToString(sta.SumaVentasTransferenciaMesDolar);
                    TotalVentasMesSoles = sta.SumaVentasEfectivoMes + sta.SumaVentasDepositoMes +
                                          sta.SumaVentasTarjetaMes + sta.SumaVentasChequeMes +
                                          sta.SumaVentasTransferenciaMes;
                    TotalVentasMesDolar = sta.SumaVentasEfectivoMesDolar + sta.SumaVentasDepositoMesDolar +
                                          sta.SumaVentasTarjetaMesDolar + sta.SumaVentasChequeMesDolar +
                                          sta.SumaVentasTransferenciaMesDolar;
                    lbTotalVentasMes_S.Text = Convert.ToString(TotalVentasMesSoles);
                    lbTotalVentasMes_D.Text = Convert.ToString(TotalVentasMesDolar);
                    lbPorCobrarMes_S.Text = Convert.ToString(sta.PorCobrarMes);
                    lbPorCobrarMes_D.Text = Convert.ToString(sta.PorCobrarMesDolar);
                    lbTotalMes_S.Text = Convert.ToString((sta.TotalVentasMes + sta.PorCobrarMes));
                    lbTotalMes_D.Text = Convert.ToString((sta.TotalVentasMesDolar + sta.PorCobrarMesDolar));
                    lbTotalCobranzas_S.Text = Convert.ToString(sta.CobranzaSolesTotal);
                    lbTotalCobranzas_D.Text = Convert.ToString(sta.CobranzaDolaresTotal);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void CargaStatusFlujosCaja_SP() //*** Carga de Caja Sin Periodo ***
        {
            try
            {
                sta = AdmSta.CargaStatusFlujosCaja_SP(dtpfechaDesde.Value, frmLogin.iCodSucursal);
                if (sta != null)
                {
                    lbAperturaCaja.Text = Convert.ToString(sta.AperturaCaja);

                    lbTotalVentas_S.Text = Convert.ToString(sta.TotalVentas);
                    lbTotalVentas_D.Text = Convert.ToString(sta.TotalVentasDolar);
                    lbIngresos_S.Text = Convert.ToString(sta.Ingresos);
                    lbSubTotalIngresos_S.Text = Convert.ToString(sta.TotalVentas + sta.Ingresos+sta.CobranzaSolesTotal);
                    lbSubTotalIngresos_D.Text = Convert.ToString(sta.TotalVentasDolar+sta.CobranzaDolaresTotal);

                    lbMontoDepositado_S.Text = Convert.ToString(sta.MontoDepositado);
                    lbEgresos_S.Text = Convert.ToString(sta.Egresos);
                    lbSubTotalEgresos_S.Text = Convert.ToString((sta.MontoDepositado + sta.Egresos));

                    lbTotalVentasCredito_S.Text = Convert.ToString(sta.PorCobrar);
                    lbVentasCredito_D.Text = Convert.ToString(sta.PorCobrarDolar);
                    lbTotalComprasCredito_S.Text = Convert.ToString(sta.PorPagar);
                    lbComprasCredito_D.Text = Convert.ToString(sta.PorPagarDolar);

                    lbEfectivo_S.Text = Convert.ToString(sta.SumaVentasEfectivoDia);
                    lbEfectivo_D.Text = Convert.ToString(sta.SumaVentasEfectivoDiaDolar);
                    lbDeposito_S.Text = Convert.ToString(sta.SumaVentasDepositoDia);
                    lbDeposito_D.Text = Convert.ToString(sta.SumaVentasDepositoDiaDolar);
                    lbTarjeta_S.Text = Convert.ToString(sta.SumaVentasTarjetaDia);
                    lbTarjeta_D.Text = Convert.ToString(sta.SumaVentasTarjetaDiaDolar);
                    lbCheque_S.Text = Convert.ToString(sta.SumaVentasChequeDia);
                    lbCheque_D.Text = Convert.ToString(sta.SumaVentasChequeDiaDolar);
                    lbTransferencia_S.Text = Convert.ToString(sta.SumaVentasTransferenciaDia);
                    lb_Transferencia_D.Text = Convert.ToString(sta.SumaVentasTransferenciaDiaDolar);

                    lbTotalCaja.Text = Convert.ToString((sta.AperturaCaja + (sta.TotalVentas + sta.Ingresos+sta.CobranzaSolesTotal) - (sta.MontoDepositado + sta.Egresos)));
                    lbTotalCajaDolares.Text = Convert.ToString((sta.TotalVentasDolar + sta.IngresosDolar+ sta.CobranzaDolaresTotal) - (sta.EgresosDolar));

                    lbEfectivoMes_S.Text = Convert.ToString(sta.SumaVentasEfectivoMes);
                    lbEfectivoMes_D.Text = Convert.ToString(sta.SumaVentasEfectivoMesDolar);
                    lbDepositoMes_S.Text = Convert.ToString(sta.SumaVentasDepositoMes);
                    lbDepositoMes_D.Text = Convert.ToString(sta.SumaVentasDepositoMesDolar);
                    lbTarjetaMes_S.Text = Convert.ToString(sta.SumaVentasTarjetaMes);
                    lbTarjetaMes_D.Text = Convert.ToString(sta.SumaVentasTarjetaMesDolar);
                    lbChequeMes_S.Text = Convert.ToString(sta.SumaVentasChequeMes);
                    lbChequeMes_D.Text = Convert.ToString(sta.SumaVentasChequeMesDolar);
                    lbTransferenciaMes_S.Text = Convert.ToString(sta.SumaVentasTransferenciaMes);
                    lbTransferenciaMes_D.Text = Convert.ToString(sta.SumaVentasTransferenciaMesDolar);
                    TotalVentasMesSoles = sta.SumaVentasEfectivoMes + sta.SumaVentasDepositoMes +
                                          sta.SumaVentasTarjetaMes + sta.SumaVentasChequeMes +
                                          sta.SumaVentasTransferenciaMes;
                    TotalVentasMesDolar = sta.SumaVentasEfectivoMesDolar + sta.SumaVentasDepositoMesDolar +
                                          sta.SumaVentasTarjetaMesDolar + sta.SumaVentasChequeMesDolar +
                                          sta.SumaVentasTransferenciaMesDolar;
                    lbTotalVentasMes_S.Text = Convert.ToString(TotalVentasMesSoles);
                    lbTotalVentasMes_D.Text = Convert.ToString(TotalVentasMesDolar);
                    lbPorCobrarMes_S.Text = Convert.ToString(sta.PorCobrarMes);
                    lbPorCobrarMes_D.Text = Convert.ToString(sta.PorCobrarMesDolar);
                    lbTotalMes_S.Text = Convert.ToString((sta.TotalVentasMes + sta.PorCobrarMes));
                    lbTotalMes_D.Text = Convert.ToString((sta.TotalVentasMesDolar + sta.PorCobrarMesDolar));
                    lbTotalCobranzas_S.Text = Convert.ToString(sta.CobranzaSolesTotal);
                    lbTotalCobranzas_D.Text = Convert.ToString(sta.CobranzaDolaresTotal);
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
                    //btnAnularCierre.Visible = true;
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
                //dtpfechaHasta.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaHasta.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
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
                {
                    CargaStatusFlujosCaja_SP();
                }
                else
                {
                    CargaStatusFlujosCaja();
                }

                gbApertura.Text = "  APERTURA DE CAJA  " + Convert.ToString(dtpfechaDesde.Text) + "  ";
                dtpfechaHasta.MinDate = Convert.ToDateTime(dtpfechaDesde.Value);

                if (dtpfechaDesde.Value.Date == dtpfechaHasta.Value.Date)
                {
                    VerificarCierreCaja();
                    btnCerrarCaja.Visible = true;
                   // btnAnularCierre.Visible = true;
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
                    //btnAnularCierre.Visible = true;
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
                //dtpfechaDesde.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaDesde.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                //dtpfechaHasta.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                dtpfechaHasta.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
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
                tcambio = admTipoCambio.CargaTipoCambio(dtpfechaDesde.Value, 2);

                flu.MontoCierre = Convert.ToDecimal(lbTotalCaja.Text);
                flu.CodAlmacen = frmLogin.iCodAlmacen;
                flu.CodSucursal = frmLogin.iCodSucursal;
                flu.FechaCierre = dtpfechaHasta.Value;
                flu.MontoDepositado = Convert.ToDecimal(lbMontoDepositado_S.Text);
                flu.MontoIngresado = Convert.ToDecimal(lbEfectivo_S.Text) + Convert.ToDecimal(lbEfectivo_D.Text)*Convert.ToDecimal(tcambio.Venta);
                flu.MontoDisponible = Convert.ToDecimal(lbAperturaCaja.Text) + (Convert.ToDecimal(lbEfectivo_S.Text) + Convert.ToDecimal(lbEfectivo_D.Text)) - Convert.ToDecimal(lbMontoDepositado_S.Text);
                flu.CodUser = frmLogin.iCodUser;
                flu.Deposito = depo;
                flu.FechaDeposito = fecha_Depo;

                if (admFlu.Update(flu))
                {
                    //this.Close();
                    VerificarCierreCaja();
                }
                btnImprimir.Visible = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btnAnularCierre_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (AdmApe.AnularCierre(frmLogin.iCodAlmacen))
            //    {
            //        VerificarCierreCaja();
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //frmParamLiquidacionCaja frm = new frmParamLiquidacionCaja();
            //frm.ShowDialog();
            //CRLiquidacionCaja2 rpt1 = new CRLiquidacionCaja2();
            CRLiquidacion rpt1 = new CRLiquidacion();
            frmRptLiquidacionCaja frm1 = new frmRptLiquidacionCaja();
            rpt1.SetDataSource(ds.ReportLiquidacion(frmLogin.iCodSucursal, dtpfechaDesde.Value).Tables[0]);
            frm1.cRVLiquidacionCaja.ReportSource = rpt1;
            frm1.Show();

            //CRLiquidacion3 rpt2 = new CRLiquidacion3();
            //frmRptLiquidacionCaja frm2 = new frmRptLiquidacionCaja();
            //rpt2.SetDataSource(ds.ReporteLiquidacionCaja2(frmLogin.iCodSucursal, dtpfechaDesde.Value).Tables[0]);
            //frm2.cRVLiquidacionCaja.ReportSource = rpt2;
            //frm2.Show();

            //CRLiquidacion4 rpt3 = new CRLiquidacion4();
            //frmRptLiquidacionCaja frm3 = new frmRptLiquidacionCaja();
            //rpt3.SetDataSource(ds.ReporteLiquidacionCaja3(frmLogin.iCodSucursal, dtpfechaDesde.Value).Tables[0]);
            //frm3.cRVLiquidacionCaja.ReportSource = rpt3;
            //frm3.Show();

        }

        

        

        

        

       

       

       

        

        

        

        
    }
}
