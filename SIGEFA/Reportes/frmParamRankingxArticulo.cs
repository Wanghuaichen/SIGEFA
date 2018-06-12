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
    public partial class frmParamRankingxArticulo : DevComponents.DotNetBar.Office2007Form
    {
        clsReporteRankingxArticulo ds = new clsReporteRankingxArticulo();

        public frmParamRankingxArticulo()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRRankingArticulo rpt = new CRRankingArticulo();
            frmRptRankingArticulo frm = new frmRptRankingArticulo();
            rpt.SetDataSource(ds.Reporte_Ranking(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0]);
            frm.crvRankingArticulo.ReportSource = rpt;
            frm.Show();
        }
    }
}
