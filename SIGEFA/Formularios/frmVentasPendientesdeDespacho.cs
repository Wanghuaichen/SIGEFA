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
//using SIGEFA.SunatFacElec;

namespace SIGEFA.Formularios
{

    public partial class frmVentasPendientesdeDespacho : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida nota = new clsNotaSalida();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsFacturaVenta venta = new clsFacturaVenta();
        clsPago pag = new clsPago();
        clsAdmPago admPago = new clsAdmPago();
        clsDocumentorescom docres = new clsDocumentorescom();
        clsDetalleDocumentoRescom detres = new clsDetalleDocumentoRescom();
        clsAdmDocumentoeRescom admdocres = new clsAdmDocumentoeRescom();

        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento admdoc = new clsAdmTipoDocumento();
        clsSerie ser = new clsSerie();

        List<clsFacturaVenta> listadocumentos = new List<clsFacturaVenta>();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        Int32 CodTipoDoc = 0;



        public frmVentasPendientesdeDespacho()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvVentas.DataSource = data;
            data.DataSource = AdmVenta.VentasPendientesdedespacho(frmLogin.iCodAlmacen, dtpDesde.Value, dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVentas.ClearSelection();

            dgvVentas.ReadOnly = false;
        }

        private void frmPedidosPendientes_Load(object sender, EventArgs e)
        {
            CargaLista();            
        }

        private void dgvPedidosPendientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvVentas.Rows.Count >= 1 && e.Row.Selected)
            {
                venta.CodFacturaVenta= e.Row.Cells[codigo.Name].Value.ToString();               
            }
        }

        private void dtpDesde_CloseUp(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpHasta_CloseUp(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnGenerarComunicaciondeBaja_Click(object sender, EventArgs e)
        {
            /*listadocumentos.Clear();
            if (dgvVentas.RowCount > 0) 
            {
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["item"].EditedFormattedValue))
                    {
                        venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(row.Cells[codigo.Name].Value));
                        if (venta != null) 
                        {
                            listadocumentos.Add(venta);
                        }
                    }
                }

                SIGEFA.SunatFacElec.Conexion mel = new SunatFacElec.Conexion();
                

                if (listadocumentos.Count > 0) 
                {
                    mel.GeneraXML_RA(listadocumentos);           
                    docres.CodSerie = ser.CodSerie;
                    docres.Numeracion = ser.Numeracion.ToString().PadLeft(5,'0');
                    docres.Tipodocumento = doc.Tipodoccodsunat;
                    docres.CodUser = frmLogin.iCodUser;
                    docres.Fecharegistro = DateTime.Now;
                    docres.Codtipodocumento = doc.CodTipoDocumento;

                    if (docres != null) 
                    {
                        if (admdocres.InsertRescom(docres)) 
                        {
                            foreach (clsFacturaVenta vent in listadocumentos) 
                            {
                                detres = new clsDetalleDocumentoRescom();

                                detres.Coddocumentorescom = docres.Codigonuevo;
                                detres.CodFacturaV = Convert.ToInt32(vent.CodFacturaVenta);
                                detres.CodTipoDocumento = vent.CodTipoDocumento;
                                detres.NumDocumento = vent.NumDoc;
                                detres.CodAlmacen = vent.CodAlmacen;
                                detres.CodCliente = vent.CodCliente;
                                detres.CodSerie = vent.CodSerie;
                                detres.Serie = vent.Serie;
                                detres.Bruto = Convert.ToDecimal(vent.MontoBruto);
                                detres.Montodscto = Convert.ToDecimal(vent.MontoDscto);
                                detres.Valorventa = (Convert.ToDecimal(vent.Total) - Convert.ToDecimal(vent.Igv));
                                detres.Igv = Convert.ToDecimal(vent.Igv);
                                detres.Total = Convert.ToDecimal(vent.Total);
                                detres.CodUsuario = frmLogin.iCodUser;
                                detres.Fecharegistro = DateTime.Now;

                                admdocres.InsertDetRescom(detres);
                            }
                        }
                    }
                }

            }*/
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void dgvVentas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVentas.IsCurrentCellDirty)
            {
                dgvVentas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

       
        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow != null)
            {
                DataGridViewRow row = dgvVentas.CurrentRow;
                if (dgvVentas.Rows.Count >= 1)
                {
                    frmVentaxEentregar form = new frmVentaxEentregar();
                    form.MdiParent = this.MdiParent;
                    form.CodVenta = venta.CodFacturaVenta;
                    form.Proceso = 3;
                    form.Show();
                }

                CargaLista();
            }
        }

        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvVentas.SelectedRows[0];
            venta.CodFacturaVenta = Row.Cells[codigo.Name].Value.ToString();
            
            Decimal totalM = Convert.ToDecimal(Row.Cells[importe.Name].Value.ToString());
            frmDespachos form = new frmDespachos();
            form.codfactura = Convert.ToInt32(venta.CodFacturaVenta);            
            form.ShowDialog();
            //CargaLista();
        }

        private void dgvVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVentas.ContextMenuStrip = new ContextMenuStrip();
            if (e.RowIndex != -1)
            {
                dgvVentas.Rows[e.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {
                    if (dgvVentas.SelectedCells.Count > 0)
                    {
                        dgvVentas.ContextMenuStrip = contextMenuStrip1;
                        if (Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells[codigo.Name].Value) > 0)
                        {
                            MuestraDespachosToolStripMenuItem.Enabled = true;
                            
                        }
                    }
                }
            }
        }

        private void dgvVentas_Click(object sender, EventArgs e)
        {
            if (dgvVentas.RowCount > 0) 
            {
                if (dgvVentas.CurrentRow.Cells[estado.Name].Value.ToString() == "PENDIENTE")
                {
                    btnIrPedido.Enabled = true;
                }
                else if (dgvVentas.CurrentRow.Cells[estado.Name].Value.ToString() == "ATENDIDO")
                {
                    btnIrPedido.Enabled = false;
                }
            }
        }

       
    }
}
