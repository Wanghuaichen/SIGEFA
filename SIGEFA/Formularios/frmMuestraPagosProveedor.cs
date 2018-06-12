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
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmMuestraPagosProveedor : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        public Int32 CodNota;
        public Boolean InOut;
        public Int32 tipo;
        public Int32 tipodocumento = 0;
        clsSerie ser = new clsSerie();
        clsReporteFlujoCaja ds = new clsReporteFlujoCaja();
        clsConsultasExternas ext = new clsConsultasExternas();


        public frmMuestraPagosProveedor()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvPagos.DataSource = data;
            if (tipodocumento == 1)
            {
                data.DataSource = Admpag.MuestraListaPagosPorNota(CodNota, InOut, tipo, frmLogin.iCodAlmacen);
            }
            else if (tipodocumento == 2)
            {
                data.DataSource = Admpag.MuestraListaPagosPorNota(CodNota, InOut, 1, frmLogin.iCodAlmacen);              
            }
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPagos.ClearSelection();
        }

        private void frmMuestraPagosProveedor_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count >= 1 && dgvPagos.Rows[e.RowIndex].Selected)
            {
                DataGridViewCell celda = dgvPagos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (celda.Value.ToString() == "Imprimir pago")
                {
                    Pag.CodPago = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codpago.Name].Value);
                    CRImpresionCobro rpt = new CRImpresionCobro();
                    frmRptImpresionPago frm = new frmRptImpresionPago();
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                    rpt.SetDataSource(ds.ReporteImpresionCobro(Pag.CodPago, frmLogin.iCodAlmacen));
                    frm.cRVImpresionPago.ReportSource = rpt;
                    frm.Show();
                }
            }
        }


    }
}
