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
    public partial class frmListadoDeCajas : DevComponents.DotNetBar.OfficeForm
    {

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmAperturaCierre AdmCaja = new clsAdmAperturaCierre();
        Int32 codCaja = 0;
        DateTime FechaCaja;

        public frmListadoDeCajas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoDeCajas_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            
            dgvCarjas.DataSource = data;
            data.DataSource = AdmCaja.ConsultaCajas(frmLogin.iCodAlmacen, dtpDesde.Value, dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCarjas.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvCarjas_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (dgvCarjas.Rows.Count >= 1 && e.RowIndex != -1)
            {
                codCaja = Convert.ToInt32(dgvCarjas.Rows[e.RowIndex].Cells[codigo.Name].Value);
                FechaCaja = Convert.ToDateTime(dgvCarjas.Rows[e.RowIndex].Cells[fechaapertura.Name].Value);
            } 
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
            clsReporteCaja dso = new clsReporteCaja();
            CRCierre rpt = new CRCierre();
            frmRptCaja frm = new frmRptCaja();
            //rptoption = rpt.PrintOptions;
            //rptoption.PrinterName = ser.NombreImpresora;
            //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
            rpt.SetDataSource(dso.RptMuestraCierreCaja(frmLogin.iCodSucursal, FechaCaja, codCaja, frmLogin.iCodAlmacen).Tables[0]);
            frm.crvKardex.ReportSource = rpt;
            frm.Show();
        }
    }
}