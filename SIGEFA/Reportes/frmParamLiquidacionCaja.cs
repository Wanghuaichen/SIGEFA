using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Reportes
{
    public partial class frmParamLiquidacionCaja : DevComponents.DotNetBar.Office2007Form
    {
        clsReporteFlujoCaja ds = new clsReporteFlujoCaja();

        public frmParamLiquidacionCaja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Visualizar Reporte
            //CRFlujoCaja rpt = new CRFlujoCaja();
            //frmReporteFlujoCaja frm = new frmReporteFlujoCaja();
            //rpt.SetDataSource(ds.ReporteFlujoCaja(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0]);
            ////rpt.SetDataSource(ds.ReportePagosFacturaVenta(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0]);
            //frm.cRVFlujoCaja.ReportSource = rpt;
            //frm.Show();

            CRLiquidacionCaja rpt1 = new CRLiquidacionCaja();
            frmRptLiquidacionCaja frm1 = new frmRptLiquidacionCaja();
            rpt1.SetDataSource(ds.ReportePagosFacturaVenta(frmLogin.iCodAlmacen).Tables[0]);
            frm1.cRVLiquidacionCaja.ReportSource = rpt1;
            frm1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
