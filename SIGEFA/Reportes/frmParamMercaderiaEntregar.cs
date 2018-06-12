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
    public partial class frmParamMercaderiaEntregar : Form
    {
        clsReportMercaderiaxEntregar ds = new clsReportMercaderiaxEntregar();

        public frmParamMercaderiaEntregar()
        {
            InitializeComponent();
        }

        private void frmParamMercaderiaEntregar_Load(object sender, EventArgs e)
        {
            dtpFecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            dtpFecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            //dtpFecha1.Value = Convert.ToDateTime(System.DateTime.Now);
            //dtpFecha2.Value = Convert.ToDateTime(System.DateTime.Now);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRMercaderiaEntregar rpt = new CRMercaderiaEntregar();
            frmRptMercaderiaEntregar frm = new frmRptMercaderiaEntregar();
            //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue)).Tables[0]);
            rpt.SetDataSource(ds.ReportMercaderiaEntregar(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0]);
            frm.cRMercaderiaEntregar.ReportSource = rpt;
            //frm.crvRptVentCredContDia.ReportSource = rpt;
            frm.Show();
        }
    }
}
