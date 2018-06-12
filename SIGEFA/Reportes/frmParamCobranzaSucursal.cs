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
    public partial class frmParamCobranzaSucursal : Form
    {
        clsReporteInformeSucursal ds = new clsReporteInformeSucursal();
        public frmParamCobranzaSucursal()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRResumenCobranza rpt = new CRResumenCobranza();
            frmRptCobranzaSucursal frm = new frmRptCobranzaSucursal();
            //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue)).Tables[0]);
            DataTable dt = ds.ReportCobranzaSucursal(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodSucursal).Tables[0];
            rpt.SetDataSource(dt);
            if (dt.Rows.Count > 0)
            {
                frm.cRVRptCobranzaSucursal.ReportSource = rpt;
                //frm.crvRptVentCredContDia.ReportSource = rpt;
                frm.Show();
            }
        }

        private void frmParamCobranzaSucursal_Load(object sender, EventArgs e)
        {
            dtpFecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now.Date);
            dtpFecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now.Date);
            dtpFecha1.Value = Convert.ToDateTime(System.DateTime.Now.Date);
            dtpFecha2.Value = Convert.ToDateTime(System.DateTime.Now.Date);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
