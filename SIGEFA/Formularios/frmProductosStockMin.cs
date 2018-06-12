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
    public partial class frmProductosStockMin : DevComponents.DotNetBar.Office2007Form
    {
        clsConsultasExternas ext = new clsConsultasExternas();
        clsSerie ser = new clsSerie();
        clsAdmAlmacen Admalmac = new clsAdmAlmacen();
        clsAdmTipoArticulo AdmTip = new clsAdmTipoArticulo();
        public Int32 codalmacen = 0;

        public frmProductosStockMin()
        {
            InitializeComponent();
        }

        private void CargaTipoArticulos()
        {
            cbTipoArticulo.DataSource = AdmTip.MuestraTipoArticulos();
            cbTipoArticulo.DisplayMember = "descripcion";
            cbTipoArticulo.ValueMember = "codTipoArticulo";
            cbTipoArticulo.SelectedIndex = 0;
        }

        private void frmProductosLista_Load(object sender, EventArgs e)
        {
            CargaTipoArticulos();
            Int32 codTipArt = Int32.Parse(cbTipoArticulo.SelectedValue.ToString());
            dgvProductos.DataSource = Admalmac.RelacionProductosStockMin(codTipArt, codalmacen);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductosLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
            clsReporteKardex dso = new clsReporteKardex();
            CRStockAgotar rpt = new CRStockAgotar();
            frmRptKardex frm = new frmRptKardex();
            Int32 codTipArt = Int32.Parse(cbTipoArticulo.SelectedValue.ToString());
            rptoption = rpt.PrintOptions;
            rptoption.PrinterName = ser.NombreImpresora;
            rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
            rpt.SetDataSource(dso.StockPorAgotar(codTipArt, codalmacen).Tables[0]);
            frm.crvKardex.ReportSource = rpt;
            frm.Show();
        }
    }
}
