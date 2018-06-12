using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Reportes.clsReportes;
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmFacturasLetrasXVencer : DevComponents.DotNetBar.OfficeForm
    {
        clsAdmAlmacen Admalmac = new clsAdmAlmacen();

        public frmFacturasLetrasXVencer()
        {
            InitializeComponent();
        }

        private void frmFacturasLetrasXVencer_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Admalmac.AlertaFacturasLetrasXVencer();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
            clsReporteFactura dso = new clsReporteFactura();
            CRFacturasLetrasXvencer rpt = new CRFacturasLetrasXvencer();
            frmRptKardex frm = new frmRptKardex();
            rpt.SetDataSource(dso.RPTFacturasLetraXvencer());
            frm.crvKardex.ReportSource = rpt;
            frm.Show();
        }
    }
}