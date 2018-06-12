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
    public partial class frmMuestraPagos : DevComponents.DotNetBar.Office2007Form
    {
        clsSerie ser = new clsSerie();
        clsReporteFlujoCaja ds = new clsReporteFlujoCaja();
        clsConsultasExternas ext = new clsConsultasExternas();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        public Int32 CodNota;
        public Boolean InOut;
        public Int32 tipo;
        public Decimal montoTotal;
        public String CodPago;
        clsTipoDocumento doc2 = new clsTipoDocumento();
        clsSerie seri2 = new clsSerie();
        clsAdmSerie Admser = new clsAdmSerie();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        private Int32 codDocumentoPago = 0;
        clsAdmPago AdmPagos = new clsAdmPago();
        public Int32 codCuota;


        public frmMuestraPagos()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            if (tipo == 5)
            {
                dgvPagos.DataSource = data;
                data.DataSource = Admpag.MuestraListaPagosPorNota(codCuota, InOut, tipo, frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvPagos.ClearSelection();
            }
            else
            {
                dgvPagos.DataSource = data;
                data.DataSource = Admpag.MuestraListaPagosPorNota(CodNota, InOut, tipo, frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvPagos.ClearSelection();
            }
        }

        private void frmMuestraPagos_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPagos.Rows.Count >= 1 && e.RowIndex>-1)
                {
                    DataGridViewCell celda = dgvPagos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (celda.Value.ToString() == "Imprimir pago")
                    {
                        Pag.CodPago = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codpago.Name].Value);
                        CRImpresionPago rpt = new CRImpresionPago();
                        frmRptImpresionPago frm = new frmRptImpresionPago();
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                        rpt.SetDataSource(ds.ReporteImpresionPago(Pag.CodPago, frmLogin.iCodAlmacen));
                        frm.cRVImpresionPago.ReportSource = rpt;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "MuestraPago:dgvPagos_CellContentClick"); }
        }

        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow Row = dgvPagos.SelectedRows[0];
                Pag.CodPago = Convert.ToInt32(Row.Cells[codpago.Name].Value.ToString());
                CodPago = Pag.CodPago.ToString();
                if (ActualizaCobro(CodPago))
                {
                    //printaRecibo(CodPago);
                        if (CodPago != "")
                        {
                            printaRecibo(CodPago);
                        }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void printaRecibo(string CodPago)
        {
            try
            {
                CRImpresionPago rpt = new CRImpresionPago();
                frmRptImpresionPago frm = new frmRptImpresionPago();
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                rpt.SetDataSource(ds.ReporteImpresionPago(Convert.ToInt32(CodPago), frmLogin.iCodAlmacen));
                frm.cRVImpresionPago.ReportSource = rpt;
                frm.ShowDialog();
                if (dgvPagos.DataSource!=null)
                {
                    dgvPagos.AutoGenerateColumns = false;
                    dgvPagos.DataSource = null;
                    CargaLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String siglaPago, seriePago, numeroPago;
        private bool ActualizaCobro(string CodPago)
        {
            String sigl = "";
            Boolean devuelve = false;
            try
            {
                sigl = "RC";
                if (valida_serie(sigl))
                {
                    seri2 = null;
                    seri2 = Admser.BuscaSeriexDocumento(codDocumentoPago, frmLogin.iCodAlmacen);
                    if (seri2 != null)
                    {
                        seriePago = seri2.Serie;
                        numeroPago = seri2.Numeracion.ToString();
                        if (AdmPagos.ActualizaPagoAprobado(seriePago, numeroPago, Convert.ToInt32(CodPago)))
                        {
                            devuelve = true;
                        }
                        else
                        {
                            devuelve = false;
                        }
                    }
                }

                return devuelve;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private Boolean valida_serie(string sigl)
        {
            doc2 = null;
            try
            {
                doc2 = Admdoc.BuscaTipoDocumento(sigl);
                if (doc2 != null)
                {
                    codDocumentoPago = doc2.CodTipoDocumento;
                    siglaPago = doc2.Sigla;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private void dgvPagos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (dgvPagos.Rows.Count >= 1 && e.Row.Selected)
                {
                    int contador = 0;
                    foreach (DataGridViewRow row in dgvPagos.Rows)
                    {
                        if (row.Cells[aprobados.Name].Value.ToString() == "FINALIZADO")
                        {
                            contador = contador + 1;
                        }
                    }
                    if (contador == dgvPagos.Rows.Count)
                    {
                        btnFinalizar.Enabled = true;
                    }
                    else
                    {
                        btnFinalizar.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal montosTotal = 0;
                montoTotal = Decimal.Round(montoTotal, 2);
                foreach (DataGridViewRow row in dgvPagos.Rows)
                {
                    Pag.CodNota = row.Cells[codfacturas.Name].Value.ToString();
                    montosTotal = montosTotal + Convert.ToDecimal(row.Cells[monto.Name].Value.ToString());
                }

                //DataGridViewRow Row = dgvPagos.SelectedRows[0];
                //Pag.CodPago = Convert.ToInt32(Row.Cells[codpago.Name].Value.ToString());
                //Pag.CodNota = Row.Cells[codfacturas.Name].Value.ToString();
                
                if (montoTotal >= montosTotal)
                {
                    //Pag.
                    /* MUESTRO LA FACTURA PARA IMPRIMIRLA */

                    if (Application.OpenForms["frmVenta"] != null)
                    {
                        Application.OpenForms["frmVenta"].Activate();
                    }
                    else
                    {
                        frmVenta form1 = new frmVenta();
                        //form1.MdiParent = this;
                        form1.Proceso = 3;
                        form1.tip = 1;
                        form1.CodVenta = Pag.CodNota;
                        form1.CodPago = "0"; //  ------------------>>>>> aqui me quede 
                        form1.WindowState = FormWindowState.Normal;
                        form1.StartPosition = FormStartPosition.CenterScreen;
                        form1.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
