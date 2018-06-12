using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Reportes
{
    public partial class frmParamPagosDia : DevComponents.DotNetBar.Office2007Form
    {
        clsReportePagosDia ds = new clsReportePagosDia();
        clsAdmMoneda AdmMon = new clsAdmMoneda();

        public frmParamPagosDia()
        {
            InitializeComponent();
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }   

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRPagosDia rpt = new CRPagosDia();
            frmRptPagosxDia frm = new frmRptPagosxDia();
            rpt.SetDataSource(ds.Reporte(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen, Convert.ToInt32(cmbMoneda.SelectedValue)).Tables[0]);
            frm.crvPagosDia.ReportSource = rpt;
            frm.Show();
        }

        private void frmParamPagosDia_Load(object sender, EventArgs e)
        {
            CargaMoneda();
        }
    }
}
