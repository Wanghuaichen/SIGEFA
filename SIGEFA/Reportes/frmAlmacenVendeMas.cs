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
    public partial class frmAlmacenVendeMas : Form
    {
        clsReportAlmacenVendeMas ds = new clsReportAlmacenVendeMas();

        public frmAlmacenVendeMas()
        {
            InitializeComponent();
        }

        private void frmAlmacenVendeMas_Load(object sender, EventArgs e)
        {
            dtpFecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            dtpFecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRAlmacenVendeMas rpt = new CRAlmacenVendeMas();
            frmRptAlmacenVendeMas frm = new frmRptAlmacenVendeMas();
            //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue)).Tables[0]);
            rpt.SetDataSource(ds.Reporte(dtpFecha1.Value, dtpFecha2.Value).Tables[0]);
            frm.cRVAlmacenVendeMas.ReportSource = rpt;
            //frm.crvRptVentCredContDia.ReportSource = rpt;
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
