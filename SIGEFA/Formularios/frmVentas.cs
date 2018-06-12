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

namespace SIGEFA.Formularios
{

    public partial class frmVentas : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida nota = new clsNotaSalida();
        clsNotaIngreso nota2 = new clsNotaIngreso();
      
        clsTransaccion trans = new clsTransaccion();
        clsSerie ser = new clsSerie();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsAdmSerie Admser = new clsAdmSerie(); 
        clsAdmTransaccion admTrans = new clsAdmTransaccion();
        clsAdmNotaIngreso AdmIngreso= new clsAdmNotaIngreso();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsFacturaVenta venta = new clsFacturaVenta();
        clsPago pag = new clsPago();
        clsAdmPago admPago = new clsAdmPago();
        DataTable dt_AnulaVenta = new DataTable();
        DataTable dt_AnulaPago = new DataTable();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta
        List<clsDetalleNotaIngreso> lstNotaIng = new List<clsDetalleNotaIngreso>();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;        



        public frmVentas()
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
            data.DataSource = AdmVenta.Ventas(frmLogin.iCodAlmacen, dtpDesde.Value, dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVentas.ClearSelection();
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow != null)
            {
                DataGridViewRow row = dgvVentas.CurrentRow;
                if (dgvVentas.Rows.Count >= 1)
                {
                    frmVenta form = new frmVenta();
                    form.MdiParent = this.MdiParent;
                    form.CodVenta= venta.CodFacturaVenta;
                    form.Proceso = 3; 
                    form.Show();
                }
            }
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

        private void dgvPedidosPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvVentas.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmVenta form = new frmVenta();
                form.MdiParent = this.MdiParent;
                form.CodVenta = venta.CodFacturaVenta;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void LeeProductos() {
            try {

                lstNotaIng.Clear();
                foreach (DataRow row3 in dt_AnulaVenta.Rows)
                {
                    clsDetalleNotaIngreso DetIng = new clsDetalleNotaIngreso();
                    DetIng.CodProducto = Convert.ToInt32(row3[1]);
                    DetIng.CodNotaIngreso =Convert.ToInt32(nota2.CodNotaIngreso);
                    DetIng.CodAlmacen=Convert.ToInt32(row3[3]);
                    DetIng.UnidadIngresada=Convert.ToInt32(row3[4]);
                    DetIng.Cantidad=Convert.ToDouble(row3[6]);
                    DetIng.PrecioUnitario = Convert.ToDouble(row3[29]);                    
                    DetIng.Descuento1 = Convert.ToDouble(row3[9]);
                    DetIng.Descuento2= Convert.ToDouble(row3[10]);
                    DetIng.Descuento3 = Convert.ToDouble(row3[11]);
                    DetIng.MontoDescuento = Convert.ToDouble(row3[12]);                   
                    DetIng.Importe = Convert.ToDouble(row3[29]) * DetIng.Cantidad ;
                    DetIng.Subtotal =DetIng.PrecioUnitario * DetIng.Cantidad;
                    DetIng.Igv = DetIng.Importe - DetIng.Subtotal;
                    DetIng.PrecioReal = Convert.ToDouble(row3[29]) * Convert.ToDouble(frmLogin.Configuracion.IGV / 100 + 1) ;
                    DetIng.ValoReal = Convert.ToDouble(row3[29]);
                    DetIng.CodUser = Convert.ToInt32(row3[17]);
                    DetIng.Estado = true;
                    //DetIng.ValoReal = Convert.ToDouble(row3[29]);
                    lstNotaIng.Add(DetIng);
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow != null)
                {
                    DataGridViewRow row = dgvVentas.CurrentRow;
                    if (btnAnular.Text == "Anular")
                    {
                        if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow.Index != -1)
                        {
                            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el documento seleccionado", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgResult == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {

                                venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(venta.CodFacturaVenta));
                                dt_AnulaPago = admPago.MuestraPagoVentaAnula(frmLogin.iCodAlmacen, Convert.ToInt32(venta.CodFacturaVenta));

                                if (venta.Anulado == 1)
                                {
                                    MessageBox.Show("El documento ya se a anulado anteriormente..!", "Ventas",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                nota2 = AdmVenta.BuscaNotaSalida(Convert.ToInt32(venta.CodFacturaVenta), frmLogin.iCodAlmacen);
                                Boolean verifica = false;
                                Int32 CodNotaSalida;
                                if (AdmVenta.anular(Convert.ToInt32(venta.CodFacturaVenta)))
                                {
                                    if (nota2 != null)
                                    {
                                        CodNotaSalida =Convert.ToInt32(nota2.CodNotaIngreso);
                                        trans = admTrans.MuestraTransaccion(8); //8 Ingreso por Devolucion
                                        nota2.CodTipoTransaccion = trans.CodTransaccion;                                      
                                        doc = Admdoc.BuscaTipoDocumento("DIA"); // DOCUMENTO INTERNO ANULACION
                                        ser = Admser.BuscaSeriexDocumento(doc.CodTipoDocumento, frmLogin.iCodAlmacen);
                                       
                                        nota2.Serie = ser.Serie;
                                        nota2.NumDoc =Convert.ToString(ser.Numeracion);
                                        nota2.DescripcionTransaccion = trans.Descripcion;
                                        nota2.CodTipoDocumento = doc.CodTipoDocumento;
                                        nota2.CodSerie = ser.CodSerie;
                                        nota2.CodReferencia = nota2.DocumentoReferencia;
                                        if (!AdmIngreso.insert(nota2)) {
                                            MessageBox.Show("No se pudo registrar el ingreso..!", "Ventas",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                        
                                    }
                                    else {
                                        MessageBox.Show("Error al consultar Venta", "Ventas",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    
                                    dt_AnulaVenta = AdmVenta.CargaDetalleNotaSalida(Convert.ToInt32(CodNotaSalida), frmLogin.iCodAlmacen);
                                    LeeProductos();

                                    foreach (clsDetalleNotaIngreso det in lstNotaIng)
                                    {
                                        if (!AdmIngreso.insertdetalle(det)) {
                                              MessageBox.Show("No se puede devolver productos..!", "Ventas",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                verifica = false;
                                        }
                                        
                                        /*if (venta.Anulado != 1)
                                         {
                                            if (!AdmVenta.UpdateKardex(Convert.ToInt32(nota2.CodNotaIngreso), Convert.ToInt32(det.CodProducto), frmLogin.iCodAlmacen, Convert.ToDecimal(det.Cantidad),Convert.ToDecimal(det.Importe)))
                                            {
                                              
                                            
                                            }
                                        }*/
                                    }

                                    foreach (DataRow row2 in dt_AnulaPago.Rows)
                                    {
                                        if (!admPago.AnularPago(Convert.ToInt32(row2[0])))
                                        {
                                            MessageBox.Show("No se ha podido eliminar el pago", "Pagos",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            verifica = false;
                                        }
                                    }


                                    verifica = true;
                                    if (verifica == true)
                                    {
                                        MessageBox.Show("El documento ha sido anulado correctamente", "Ventas",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El documento no se ha  anulado correctamente", "Ventas",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    CargaLista();
                                }


                            }
                        }

                    }
                    else if (btnAnular.Text == "Activar")
                    {
                        if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow.Index != -1)
                        {
                            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea activar el documento seleccionado", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgResult == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                if (AdmVenta.activar(Convert.ToInt32(venta.CodFacturaVenta)))
                                {
                                    MessageBox.Show("El documento ha sido activado correctamente", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargaLista();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.Rows.Count >= 1 && e.RowIndex != -1)
            {
                btnIrPedido.Enabled = true;
                if (dgvVentas.Rows[e.RowIndex].Cells[estado.Name].Value.ToString() == "ACTIVO")
                {
                    btnAnular.Text = "Anular";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 4;
                }
                else
                {
                   /* btnAnular.Text = "Activar";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 6;*/
                }
            } 
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ListaGuias");
            // Columnas
            foreach (DataGridViewColumn column in dgvVentas.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvVentas.Rows.Count; i++)
            {
                DataGridViewRow row = dgvVentas.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvVentas.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\ListaVentasRPT.xml", XmlWriteMode.WriteSchema);


            CRListaVentas rpt = new CRListaVentas();
            frmListaVentas frm = new frmListaVentas();
            rpt.SetDataSource(ds);
            frm.crvListaGuias.ReportSource = rpt;
            frm.Show();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnVistaSucursales_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow != null)
            {
                if (btnVistaSucursales.Text == "Activar Vista")
                {
                    if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow.Index != -1)
                    {
                        DialogResult dlgResult = MessageBox.Show("¿Esta seguro que desea activar la vista de este documento en otras sucursales?", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            if (AdmVenta.VistaSucursal(Convert.ToInt32(venta.CodFacturaVenta), 1))
                            {
                                MessageBox.Show("El documento puede ser visualizado desde cualquier sucursal correctamente", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaLista();
                            }
                        }
                    }
                }
                //else if (btnVistaSucursales.Text == "Desactivar Vista")
                //{
                //    if (dgvVentas.Rows.Count >= 1 && dgvVentas.CurrentRow.Index != -1)
                //    {
                //        DialogResult dlgResult = MessageBox.Show("¿Esta seguro que desea desactivar la vista de este documento en otras sucursales?", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (dlgResult == DialogResult.No)
                //        {
                //            return;
                //        }
                //        else
                //        {
                //            if (AdmVenta.VistaSucursal(Convert.ToInt32(venta.CodFacturaVenta), 2))
                //            {
                //                MessageBox.Show("El documento puede ser visualizado desde cualquier sucursal correctamente", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                CargaLista();
                //            }
                //        }
                //    }
                //}
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea cambiar venta a pendiente de entrega", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
            {
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    DataGridViewCheckBoxCell cellSeleccion = row.Cells["pendiente"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cellSeleccion.Value))
                    {
                        AdmVenta.VentaPendiente(Convert.ToInt32(row.Cells[codigo.Name].Value));
                    }
                }
            }
        }

       
    }
}
