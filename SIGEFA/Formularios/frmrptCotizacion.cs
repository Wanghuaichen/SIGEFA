using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Reportes.clsReportes;
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmrptCotizacion : Form
    {
        public Int32 CodCotizacion;
        DataSet data = null;
        public Int32 tipo = 0;

        public frmrptCotizacion()
        {
            InitializeComponent();
        }

        private void frmrptCotizacion_Load(object sender, EventArgs e)
        {
            if (tipo == 1)//cotizacion
            {
                generareporte();
            }
            else if (tipo == 2)//requerimiento
            {
                generareporteRequerimiento();
            }
            else if (tipo == 3)//ordencompra
            {
                generareporteOrden();
            }
            else if (tipo == 4)//Sucursales
            {
               generareporteSucursal(); 
            }
            else if (tipo == 5)//linea
            {
                generareporteLinea();
            }
            else if (tipo == 6) //grupo
            {
                generareporteGrupo();
            }
            else if (tipo == 7)// forma de pago
            {
                generareportemetodopago();
            }else if (tipo == 8)
            {
                generareporteListaPrecio();// Lista de Precios
            }else if (tipo == 9)
            {
                generareporteVehiculoTransporte();// vehiculos de transporte
            }else if (tipo == 10)
            {
                generareporteconductores();//Empresa Transporte
            }else if (tipo == 11)
            {
                generareporteEmpresaTransporte();
            }else if (tipo == 12)// zonas
            {
                generareportezonas();
            }
            else if (tipo == 13)// Vendedores
            {
                generareporteVendedores();
            }
            else if (tipo == 14)// Destaque
            {
                generareporteDestaques();
            }
            else if (tipo == 15)// TarjetaPago
            {
                generareporteTarjetaPago();
            }
            else if (tipo == 16)
            {
                generareporteTransferenciaxDevoluc();
            }
            else if (tipo == 17) 
            {
                generareporteRendiciones();
            }
            else if (tipo == 18)//COtizacion de Compra //MOD3
            {
                generareporteCotizacionCompra();
            }
            
            
        }

        private void generareporteRendiciones()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Rendiciones(CodCotizacion);
                CRRendiciones myDataReport = new CRRendiciones();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

       

        private void generareporteTransferenciaxDevoluc()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.TransferenciaxDevolucion(CodCotizacion);
                CRTransferenciaxDevolucion myDataReport = new CRTransferenciaxDevolucion();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteTarjetaPago()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.TarjetaPago();
                CRTarjetadePago myDataReport = new CRTarjetadePago();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteDestaques()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Destaques();
                CRDestaque myDataReport = new CRDestaque();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteVendedores()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Vendedores();
                CRVendedores myDataReport = new CRVendedores();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareportezonas()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Zonas();
                CRZonas myDataReport = new CRZonas();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteEmpresaTransporte()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.EmpresaTransporte();
                CREmpresaTransporte myDataReport = new CREmpresaTransporte();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteconductores()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Conductores();
                CRConductores myDataReport = new CRConductores();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteVehiculoTransporte()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.VehiculoTransporte();
                CRVehiculoTransporte myDataReport = new CRVehiculoTransporte();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteListaPrecio()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.ListaPrecios();
                CRListaPrecios myDataReport = new CRListaPrecios();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareportemetodopago()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.MetodoPago();
                CRMetodoPago myDataReport = new CRMetodoPago();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteGrupo()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Grupos(CodCotizacion);
                CRGrupos myDataReport = new CRGrupos();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteLinea()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Lineas(CodCotizacion);
                CRLineas myDataReport = new CRLineas();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteSucursal()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Sucursal();
                CRSucursales myDataReport = new CRSucursales();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporte()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Cotizacion(CodCotizacion);
                CRCotizacion myDataReport = new CRCotizacion();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteRequerimiento()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Requerimiento(CodCotizacion);
                CRRequerimiento myDataReport = new CRRequerimiento();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void generareporteOrden()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Orden(CodCotizacion);
                CROrdenCompra myDataReport = new CROrdenCompra();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void generareporteCotizacionCompra()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.Orden(CodCotizacion);
                CRCotizacionCompra myDataReport = new CRCotizacionCompra();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
