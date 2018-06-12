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
    public partial class frmParamVentCredContSucursal : Form
    {
        clsReporteInformeSucursal ds = new clsReporteInformeSucursal();
 
        public frmParamVentCredContSucursal()
        {
            InitializeComponent();
        }

        private void frmParamVentCredContSucursal_Load(object sender, EventArgs e)
        {
            dtpFecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            dtpFecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            //dtpFecha1.Value = Convert.ToDateTime(System.DateTime.Now);
            //dtpFecha2.Value = Convert.ToDateTime(System.DateTime.Now);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRResumenVentas rpt = new CRResumenVentas();
            frmRptVentCredContSucursal frm = new frmRptVentCredContSucursal();
            //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue)).Tables[0]);
            DataTable dt = ds.ReportVentasContCredSucursal(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodSucursal).Tables[0];
            rpt.SetDataSource(dt);
            if (dt.Rows.Count > 0)
            {
                frm.cRVRptVentCredContSucursal.ReportSource = rpt;
                //frm.crvRptVentCredContDia.ReportSource = rpt;
                frm.Show();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
