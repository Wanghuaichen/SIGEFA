using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using SIGEFA.Reportes;
using System.IO;
using SIGEFA.Reportes.clsReportes;


namespace SIGEFA.Formularios
{
    public partial class frmGestionCotizacion : DevComponents.DotNetBar.Office2007Form
    {
        public frmGestionCotizacion()
        {
            
            InitializeComponent();
            dtpVigencia.Value = dtpFecha.Value.AddDays(frmLogin.Configuracion.DiasVigencia);
        }
              
        
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        clsAdmAutorizado AdmAut = new clsAdmAutorizado();
        clsAutorizado aut = new clsAutorizado();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();  
        clsAdmCotizacion AdmCoti = new clsAdmCotizacion();
        clsAdmMoneda AdmMon = new clsAdmMoneda();        
        clsCotizacion cotizacion = new clsCotizacion();
        clsValidar ok = new clsValidar();
        clsAdmListaPrecio admLista = new clsAdmListaPrecio();
        clsListaPrecio Listap = new clsListaPrecio();
        Int32 CodLista = 0;
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();

        

        public List<Int32> config = new List<Int32>();
        public List<clsDetalleCotizacion> detalle = new List<clsDetalleCotizacion>();
        public List<clsDetalleCotizacion> detalle1 = new List<clsDetalleCotizacion>();
        public String CodCotizacion;        
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodAutorizado;
        public Int32 Tipo;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        clsConsultasExternas ext = new clsConsultasExternas();

        public Int32 aprobado = 0;

        Decimal TipoCambio = 0;
        String Moneda = "";
        public String referenciaSinRegistro = "";

        public String nombreArchivo = "";
        private clsDocumentosImpresos ds = new clsDocumentosImpresos();//cotizacion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                RecorreDetalle();
                if (Application.OpenForms["frmDetalleSalida"] != null)
                {
                    Application.OpenForms["frmDetalleSalida"].Activate();
                }
                else
                {
                    frmDetalleSalida form = new frmDetalleSalida();
                    form.Procede = 4;
                    form.Proceso = 1;
                    form.Tipo = 1;
                    form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    form.Codlista = Convert.ToInt32(cbListaPrecios.SelectedValue);
                    form.tc = tc.Compra;
                    form.productoscotizados = detalle1;
                    form.ShowDialog();
                    //dgvDetalle.Rows.Add("", form.detalle.CodProducto, form.detalle.Referencia, form.detalle.Descripcion, form.detalle.CodUnidad
                    //    , form.detalle.Unidad, form.detalle.SerieLote, form.detalle.Cantidad, form.detalle.PrecioUnitario, form.detalle.Importe
                    //    , form.detalle.Descuento1, form.detalle.Descuento2, form.detalle.Descuento3, form.detalle.MontoDescuento, form.detalle.ValorVenta
                    //    , form.detalle.Igv, form.detalle.PrecioVenta, form.detalle.PrecioReal, form.detalle.ValoReal);            
                }
            }catch(Exception ex)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.SelectedRows[0]);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDetalle.SelectedRows[0];
                if (Application.OpenForms["frmDetalleSalida"] != null)
                {
                    Application.OpenForms["frmDetalleSalida"].Activate();
                }
                else
                {
                    frmDetalleSalida form = new frmDetalleSalida();
                    form.Proceso = 2;
                    form.Procede = 4;
                    form.Codlista = Convert.ToInt32(cbListaPrecios.SelectedValue);
                    form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.Tipo = 1;  
                    form.Codlista = Convert.ToInt32(cbListaPrecios.SelectedValue);
                    form.tc = tc.Compra;    
                    form.BuscaProducto();                    
                    form.txtControlStock.Text = row.Cells[serielote.Name].Value.ToString();
                    form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
                    form.txtPrecio.Text = String.Format("{0:#,##0.00}", row.Cells[preciounit.Name].Value);
                    
                    form.txtDscto1.Text = String.Format("{0:#,##0.00}", row.Cells[dscto1.Name].Value);
                    //form.txtDescMax.Text = String.Format("{0:#,##0.0}", row.Cells[dsctoMax.Name].Value);
                    form.txtPrecioNeto.Text = String.Format("{0:#,##0.00}", row.Cells[importe.Name].Value);
                    
                    form.ShowDialog();                              
                }
            }
        }
               

        private void CargaCliente()
        {
            cli = AdmCli.MuestraCliente(CodCliente);
            
            txtCodCliente.Text = cli.CodigoPersonalizado;
            txtNombreCliente.Text = cli.RazonSocial;
            txtDireccion.Text = cli.DireccionLegal;

            //cmbFormaPago.SelectedValue = cli.FormaPago;
            //if (cli.FormaPago != 0)
            //{
            //    EventArgs ee = new EventArgs();
            //    cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);
            //}

        }

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtCodCliente.Text, Tipo);
            if (cli != null)
            {
                txtCodCliente.Text = cli.Dni;
                txtNombreCliente.Text = cli.RazonSocial;
                CodCliente = cli.CodCliente;
                txtDireccion.Text = cli.DireccionLegal;
                cbListaPrecios.SelectedValue = cli.CodListaPrecio;                
                return true;
            }
            else
            {
                txtNombreCliente.Text = "";
                CodCliente = 0;
                txtDireccion.Text = "";
                cbListaPrecios.SelectedIndex = -1;                
                return false;
            }
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmClientesLista"] != null)
                {
                    Application.OpenForms["frmClientesLista"].Activate();
                }
                else
                {
                    frmClientesLista form = new frmClientesLista();
                    form.Proceso = 3;
                    //form.Tipo = cmbTipoCodigo.SelectedIndex;
                    form.ShowDialog();
                    cli = form.cli;
                    CodCliente = cli.CodCliente;                    
                    if (CodCliente != 0) { CargaCliente();
                        btnNuevo.Enabled = true; ProcessTabKey(true); }
                }
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {            
            //if (CodCliente == 0)
            //{
            //    txtCodCliente.Focus();
            //}
            //VerificarCabecera();
            //if (Validacion && Proceso == 1)
            //{
            //    btnGuardar.Enabled = true;
            //}
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCodCliente.Text != "")
                {
                    if (BuscaCliente())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.Visible)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
                if (Proceso == 1)
                {
                    if (tc != null)
                    {
                        txtTipoCambio.Text = tc.Compra.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpFecha.Value = DateTime.Now.Date;
                        dtpFecha.Focus();
                    }
                }
            }
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            //if (CodTransaccion == 0)
            //{
            //    dtpFecha.Focus();
            //}
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbMoneda_Leave(object sender, EventArgs e)
        {

        }       
           

        private void VerificarCabecera()
        {
            Validacion = true;            
            if (txtCodCliente.Visible && CodCliente == 0)
            {
                Validacion = false;
            }          
            
            if (Validacion && Proceso == 1)
            {
                btnGuardar.Enabled = true;
            }
        }

        private void sololectura(Boolean estado)
        {
            dtpFecha.Enabled = !estado;
            dtpVigencia.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtCodCliente.Enabled = !estado;
            cmbMoneda.Enabled = !estado;            
            txtCotizacion.ReadOnly = estado;    
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            txtComentario.Enabled = !estado;
            cbListaPrecios.Enabled = !estado;
            btnNuevo.Visible = !estado;
            btnEditar.Visible = !estado;
            btnEliminar.Visible = !estado;
            btnGuardar.Visible = !estado;
            btnImprimir.Visible = estado;
            btnEnviar.Visible = estado;
            btnNewCotizacion.Visible = !estado;
        }

        private void CargaDetalle()
        {
            //dgvDetalle.DataSource = AdmPedido.CargaDetalle(Convert.ToInt32(pedido.CodPedido));
            dgvDetalle.DataSource = AdmCoti.CargaDetalle(Convert.ToInt32(cotizacion.CodCotizacion), frmLogin.iCodAlmacen);
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
            cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null);
            
            //cmbFormaPago.SelectedIndex = -1;
        }


        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }        

        private void frmGestionCotizacion_Load(object sender, EventArgs e)
        {
            if (aprobado == 0)
            {
                chbAprobado.Checked = false;
            }
            else
            {
                chbAprobado.Checked = true;
            }
            dtpFecha.MaxDate = DateTime.Today.Date;
            CargaMoneda();
            CargaFormaPagos();

            if (Proceso == 1)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2); 
            }
            else if (Proceso == 2)
            {
                CargaCotizacion();
            }
            else if (Proceso == 3)
            {
                CargaCotizacion();
                sololectura(true);
            }
        }

        private void CargaListaPreciosXFormaPago()
        {
            cbListaPrecios.DataSource = admLista.MuestraListaPrecioxFormaPago(frmLogin.iCodSucursal,Convert.ToInt32(cmbFormaPago.SelectedValue));
            cbListaPrecios.DisplayMember = "nombre";
            cbListaPrecios.ValueMember = "codListaPrecio";
            if (cbListaPrecios.Items.Count > 0)
            {
                cbListaPrecios.SelectedIndex = 0;
            }
        }

        private void frmGestionCotizacion_Shown(object sender, EventArgs e)
        {           
            //btnNuevo.Focus();
            if (Proceso == 1)
            {
                if (txtTipoCambio.Visible)
                {
                    if (tc == null)
                    {
                        //MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                    }
                    else
                    {
                        txtTipoCambio.Text = tc.Compra.ToString();
                        TipoCambio = Convert.ToDecimal(txtTipoCambio.Text.Trim());
                    }
                }
            }

            CargaListaPreciosXFormaPago();
            Moneda = cmbMoneda.Text;
        }

        private void CargaCotizacion()
        {
            try
            {
                //if (Proceso == 1)
                //{
                //    cotizacion = AdmCoti.CargaCotizacion(Convert.ToInt32(CodCotizacion), frmLogin.iCodAlmacen);
                //    if (cotizacion != null)
                //    {
                //        txtCotizacion.Text = cotizacion.CodCotizacion;

                //        if (txtCodCliente.Enabled)
                //        {
                //            CodCliente = cotizacion.CodCliente;
                //            //txtCodCliente.Text = cotizacion.DNI;
                //            txtCodCliente.Text = cotizacion.CodigoPersonalizado;
                //            txtNombreCliente.Text = cotizacion.Nombre;
                //            txtDireccion.Text = cotizacion.Direccion;
                //        }
                //        dtpFecha.Value = cotizacion.FechaCotizacion;
                //        dtpVigencia.Value = cotizacion.FechaVigencia;
                //        cmbMoneda.SelectedValue = cotizacion.Moneda;
                //        txtTipoCambio.Text = cotizacion.TipoCambio.ToString();
                //        cbListaPrecios.SelectedValue = cotizacion.CodListaPrecio;

                //        txtComentario.Text = cotizacion.Comentario;
                //        txtBruto.Text = String.Format("{0:#,##0.00}", cotizacion.MontoBruto);
                //        txtDscto.Text = String.Format("{0:#,##0.00}", cotizacion.MontoDscto);
                //        txtValorVenta.Text = String.Format("{0:#,##0.00}", cotizacion.Total - cotizacion.Igv);
                //        txtIGV.Text = String.Format("{0:#,##0.00}", cotizacion.Igv);
                //        txtPrecioVenta.Text = String.Format("{0:#,##0.00}", cotizacion.Total);
                //        //CargaDetalle();
                //    }
                //    else
                //    {
                //        MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK,
                //            MessageBoxIcon.Information);
                //    }
                //}
                //else
                //{
                cotizacion = AdmCoti.CargaCotizacion(Convert.ToInt32(CodCotizacion), frmLogin.iCodAlmacen);
                if (cotizacion != null)
                {
                    txtCotizacion.Text = cotizacion.CodCotizacion;

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = cotizacion.CodCliente;
                        //txtCodCliente.Text = cotizacion.DNI;
                        txtCodCliente.Text = cotizacion.CodigoPersonalizado;
                        txtNombreCliente.Text = cotizacion.Nombre;
                        txtDireccion.Text = cotizacion.Direccion;
                    }
                    dtpFecha.Value = cotizacion.FechaCotizacion;
                    dtpVigencia.Value = cotizacion.FechaVigencia;
                    cmbMoneda.SelectedValue = cotizacion.Moneda;
                    txtTipoCambio.Text = cotizacion.TipoCambio.ToString();
                    cbListaPrecios.SelectedValue = cotizacion.CodListaPrecio;

                    txtComentario.Text = cotizacion.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.00}", cotizacion.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", cotizacion.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", cotizacion.Total - cotizacion.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", cotizacion.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", cotizacion.Total);
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                // }
            }
            catch (Exception ex)
            {
                return;
            }
        }


        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {
                actualizaimportes();


                if (dgvDetalle.RowCount > 0)
                {
                    int Indice = 0;
                    Indice = dgvDetalle.RowCount-1;

                    //if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                    //{
                    //    if (TipoCambio != 0)
                    //    {
                    //        dgvDetalle[8, Indice].Value = Convert.ToDecimal(dgvDetalle[8, Indice].Value) * TipoCambio;
                    //        dgvDetalle[9, Indice].Value = Convert.ToDecimal(dgvDetalle[9, Indice].Value) * TipoCambio;
                    //        dgvDetalle[13, Indice].Value = Convert.ToDecimal(dgvDetalle[13, Indice].Value) * TipoCambio;
                    //        dgvDetalle[14, Indice].Value = Convert.ToDecimal(dgvDetalle[14, Indice].Value) * TipoCambio;
                    //        dgvDetalle[15, Indice].Value = Convert.ToDecimal(dgvDetalle[15, Indice].Value) * TipoCambio;
                    //        dgvDetalle[16, Indice].Value = Convert.ToDecimal(dgvDetalle[16, Indice].Value) * TipoCambio;
                    //    }
                    //}
                    //else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                    //{

                    //}
                }
            }
        }

        public void actualizaimportes()
        {
            if (Proceso != 0)
            {
                Decimal bruto = 0;
                Decimal descuen = 0;
                Decimal valor = 0;
                Decimal preciovent = 0;
                Decimal igvt = 0;

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                    //descuen = descuen + (Convert.ToDouble(row.Cells[importe.Name].Value) * ((Convert.ToDouble(row.Cells[dscto1.Name].Value)) / 100));
                    descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                    valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                    preciovent = preciovent + Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                    igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                }

                txtBruto.Text = String.Format("{0:#,##0.00}", bruto);
                txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);
                //txtIGV.Text = String.Format("{0:#,##0.00}", bruto - valor);
                txtIGV.Text = String.Format("{0:#,##0.00}", igvt);
                //txtPrecioVenta.Text = String.Format("{0:#,##0.00}", bruto);
                txtPrecioVenta.Text = String.Format("{0:#,##0.00}", preciovent);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0)
                {
                    cotizacion.CodSucursal = frmLogin.iCodSucursal;
                    cotizacion.CodAlmacen = frmLogin.iCodAlmacen;
                    cotizacion.CodCliente = cli.CodCliente;
                    cotizacion.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    cotizacion.DocRef = doc.CodTipoDocumento;
                    cotizacion.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    cotizacion.FechaCotizacion = dtpFecha.Value.Date;
                    cotizacion.FechaVigencia = dtpVigencia.Value.Date;
                    cotizacion.Vigencia = dtpVigencia.Value.Day - dtpFecha.Value.Day;
                    cotizacion.Comentario = txtComentario.Text;
                    cotizacion.CodListaPrecio = Convert.ToInt32(cbListaPrecios.SelectedValue);
                    cotizacion.MontoBruto = Convert.ToDecimal(txtBruto.Text);
                    cotizacion.MontoDscto = Convert.ToDecimal(txtDscto.Text);
                    cotizacion.Igv = Convert.ToDecimal(txtIGV.Text);
                    cotizacion.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                    cotizacion.CodUser = frmLogin.iCodUser;
                    cotizacion.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    cotizacion.Estado = 1;// Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                    if (Proceso == 1)
                    {
                        if (AdmCoti.insert(cotizacion))
                        {
                            RecorreDetalle();
                            if (detalle.Count > 0)
                            {
                                foreach (clsDetalleCotizacion det in detalle)
                                {
                                    AdmCoti.insertdetalle(det);
                                }
                            }
                            MessageBox.Show("Los datos se guardaron correctamente", "Cotizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CodCotizacion = cotizacion.CodCotizacion;
                            Proceso = 0;
                            CargaCotizacion();
                            sololectura(true);                            
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmCoti.update(cotizacion))
                        {
                            RecorreDetalle();
                            foreach (clsDetalleCotizacion det in cotizacion.Detalle)
                            {
                                foreach (clsDetalleCotizacion det1 in detalle)
                                {
                                    if (det.Equals(det1))
                                    {
                                        AdmCoti.updatedetalle(det1);
                                        return;
                                    }
                                }
                                AdmCoti.deletedetalle(det.CodDetalleCotizacion);
                            }
                            foreach (clsDetalleCotizacion deta in detalle)
                            {
                                if (deta.CodDetalleCotizacion == 0)
                                {
                                    AdmCoti.insertdetalle(deta);
                                }
                            }

                            MessageBox.Show("Los datos se actualizaron correctamente", "Nota de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void RecorreDetalle()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle(row);
                }
            }
            //pedido.Detalle = detalle;
        }
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleCotizacion deta = new clsDetalleCotizacion();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.Referencia = fila.Cells[referencia.Name].Value.ToString();
            if (deta.CodProducto == 1514)
            {
                deta.Descripcion = fila.Cells[descripcion.Name].Value.ToString();
            }
            else deta.Descripcion = "";
            deta.CodCotizacion = Convert.ToInt32(cotizacion.CodCotizacion);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            //deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            //deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            deta.CantidadPendiente = Convert.ToDouble(fila.Cells[cantidad.Name].Value);

            detalle.Add(deta);
            if (deta.CodProducto != 1514)
            { detalle1.Add(deta); }

        }

        private void txtCotizacion_Leave(object sender, EventArgs e)
        {
            //VerificarCabecera();
            //if (Validacion && Proceso == 1)
            //{
            //    btnDetalle.Enabled = true;
            //}
        }

        

       

       

        

       

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                actualizaimportes();
                //calculatotales();
            }
        }

        
      

        private void btnNewCotizacion_Click(object sender, EventArgs e)
        {
            //ext.limpiar(this.Controls);
            frmGestionCotizacion form = new frmGestionCotizacion();
            form.MdiParent = this.MdiParent;
            form.Proceso = 1;            
            
            form.Show();
            this.Close();
        }

        private void txtComentario_Leave(object sender, EventArgs e)
        {
            //VerificarCabecera();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
          {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.CodCotizacion = Convert.ToInt32(cotizacion.CodCotizacion);
            frm.tipo = 1;    
            frm.ShowDialog();    
        }

        private void cbListaPrecios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Listap = admLista.CargaListaPrecio(Convert.ToInt32(cbListaPrecios.SelectedValue));
            CodLista = Convert.ToInt32(cbListaPrecios.SelectedValue);
            actualizaprecios();
            calculatotales();
            //activa_botones();
            
        }

        private void activa_botones()
        {
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void actualizaprecios()
        {
            Int32 codProduct = 0;
            Double precioa, cantidada, brutoa, montodescuentoa, valorventaa, igva, precioventaa, precioreala, valorreala, factorigva;
            DataTable precios = admLista.CargaListaPrecios(Convert.ToInt32(cbListaPrecios.SelectedValue));

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                codProduct = Convert.ToInt32(row.Cells[codproducto.Name].Value);
                foreach (DataRow r in precios.Rows)
                {
                    if (codProduct == Convert.ToInt32(r["codProducto"].ToString()))
                    {
                        if (cmbMoneda.SelectedIndex == 1)
                        {
                            precioa = Convert.ToDouble(r["precio"]);
                            row.Cells[preciounit.Name].Value = String.Format("{0:#,##0.00}", r["precio"]);
                            cantidada = Convert.ToDouble(row.Cells[cantidad.Name].Value);
                            brutoa = cantidada * precioa;
                            row.Cells[importe.Name].Value = String.Format("{0:#,##0.00}", brutoa);

                            precioventaa = brutoa * (1 - (Convert.ToDouble(row.Cells[dscto1.Name].Value) / 100)) * (1 - (Convert.ToDouble(row.Cells[dscto2.Name].Value) / 100)) * (1 - (Convert.ToDouble(row.Cells[dscto3.Name].Value) / 100));
                            montodescuentoa = brutoa - precioventaa;
                            row.Cells[montodscto.Name].Value = String.Format("{0:#,##0.00}", montodescuentoa);
                            if (r["precioneto"].ToString().Equals(r["precio"].ToString()))
                            {
                                valorventaa = precioventaa;
                            }
                            else
                            {
                                factorigva = frmLogin.Configuracion.IGV / 100 + 1;
                                valorventaa = precioventaa / factorigva;
                            }
                            igva = precioventaa - valorventaa;
                            precioreala = precioventaa / cantidada;
                            valorreala = valorventaa / cantidada;
                            row.Cells[precioventa.Name].Value = String.Format("{0:#,##0.00}", precioventaa);
                            row.Cells[valorventa.Name].Value = String.Format("{0:#,##0.00}", valorventaa);
                            row.Cells[precioreal.Name].Value = String.Format("{0:#,##0.00}", precioreala);
                            row.Cells[valoreal.Name].Value = String.Format("{0:#,##0.00}", valorreala);
                        }
                        else
                        {
                            precioa = Convert.ToDouble(r["precio"]) * Convert.ToDouble(txtTipoCambio.Text);
                            row.Cells[preciounit.Name].Value = String.Format("{0:#,##0.00}", precioa);
                            cantidada = Convert.ToDouble(row.Cells[cantidad.Name].Value);
                            brutoa = cantidada * precioa;
                            row.Cells[importe.Name].Value = String.Format("{0:#,##0.00}", brutoa);

                            precioventaa = brutoa * (1 - (Convert.ToDouble(row.Cells[dscto1.Name].Value) / 100)) * (1 - (Convert.ToDouble(row.Cells[dscto2.Name].Value) / 100)) * (1 - (Convert.ToDouble(row.Cells[dscto3.Name].Value) / 100));
                            montodescuentoa = brutoa - precioventaa;
                            row.Cells[montodscto.Name].Value = String.Format("{0:#,##0.00}", montodescuentoa);
                            if (r["precioneto"].ToString().Equals(r["precio"].ToString()))
                            {
                                valorventaa = precioventaa;
                            }
                            else
                            {
                                factorigva = frmLogin.Configuracion.IGV / 100 + 1;
                                valorventaa = precioventaa / factorigva;
                            }
                            igva = precioventaa - valorventaa;
                            precioreala = precioventaa / cantidada;
                            valorreala = valorventaa / cantidada;
                            row.Cells[precioventa.Name].Value = String.Format("{0:#,##0.00}", precioventaa);
                            row.Cells[valorventa.Name].Value = String.Format("{0:#,##0.00}", valorventaa);
                            row.Cells[precioreal.Name].Value = String.Format("{0:#,##0.00}", precioreala);
                            row.Cells[valoreal.Name].Value = String.Format("{0:#,##0.00}", valorreala);
                            row.Cells[igv.Name].Value = String.Format("{0:#,##0.00}", igva);
                        }
                    }
                }
            }
        }

        private void calculatotales()
        {
            if (Proceso != 0)
            {
                Double bruto = 0;
                Double descuen = 0;
                Double valor = 0;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    bruto = bruto + Convert.ToDouble(row.Cells[importe.Name].Value);
                    descuen = descuen + Convert.ToDouble(row.Cells[montodscto.Name].Value);
                    valor = valor + Convert.ToDouble(row.Cells[valorventa.Name].Value);
                }
                txtBruto.Text = String.Format("{0:#,##0.00}", bruto);
                txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);
                txtIGV.Text = String.Format("{0:#,##0.00}", bruto - descuen - valor);
                txtPrecioVenta.Text = String.Format("{0:#,##0.00}", bruto - descuen);
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvDetalle.Columns[importe.Name].Index)
                {
                    actualizaimportes();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvDetalle_Resize(object sender, EventArgs e)
        {
            Int32 Tamaño = (dgvDetalle.Size.Width) - 1083;
            this.dgvDetalle.Columns["descripcion"].Width = 250 + Tamaño;
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaListaPreciosXFormaPago();

            EventArgs eeee = new EventArgs();
            cbListaPrecios_SelectionChangeCommitted(cbListaPrecios, eeee);
        }

        private void cmbMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            if (cmbMoneda.Text != Moneda)
            {
                if (dgvDetalle.RowCount > 0)
                {
                    CotizaEnMoneda();
                }
            }

            Moneda = cmbMoneda.Text;
            actualizaimportes();
            
        }

        private void CotizaEnMoneda()
        {
            Decimal TipoCambio = 0;
                
            TipoCambio = Convert.ToDecimal(txtTipoCambio.Text.Trim());


            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (cmbMoneda.SelectedIndex == 1)
                { 
                    row.Cells[preciounit.Name].Value = Convert.ToDecimal(row.Cells[preciounit.Name].Value) / TipoCambio;
                    row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) / TipoCambio;
                    row.Cells[montodscto.Name].Value = Convert.ToDecimal(row.Cells[montodscto.Name].Value) / TipoCambio;
                    row.Cells[valorventa.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / TipoCambio;
                    row.Cells[igv.Name].Value = Convert.ToDecimal(row.Cells[igv.Name].Value) / TipoCambio;
                    row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / TipoCambio;
                }
                else if (cmbMoneda.SelectedIndex == 0)
                { 
                    row.Cells[preciounit.Name].Value = Convert.ToDecimal(row.Cells[preciounit.Name].Value) * TipoCambio;
                    row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) * TipoCambio;
                    row.Cells[montodscto.Name].Value = Convert.ToDecimal(row.Cells[montodscto.Name].Value) * TipoCambio;
                    row.Cells[valorventa.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) * TipoCambio;
                    row.Cells[igv.Name].Value = Convert.ToDecimal(row.Cells[igv.Name].Value) * TipoCambio;
                    row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) * TipoCambio;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (chbAprobado.Checked)
            {
                Boolean rpta = AdmCoti.updateAprobado(Convert.ToInt32(cotizacion.CodCotizacion));
                if (rpta.Equals(true))
                {
                    MessageBox.Show("Esta cotizacion será atendida !!");
                    chbAprobado.Checked = true;
                    Close();
                }

            }
            else
            {
                
            }
        }

        private Boolean BuscaTipoDocumento()
        {
            doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
            if (doc != null)
            {
                CodDocumento = doc.CodTipoDocumento;
                return true;
            }
            else
            {
                CodDocumento = 0;
                return false;
            }

        }

        public void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtDocRef.Text != "")
                {
                    if (BuscaTipoDocumento())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (dgvDetalle.Rows.Count > 0)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            //ComboBox c = (ComboBox)e.ControlToValidate;
            //if (c.Enabled)
            //    if (Proceso != 0)
            //        if (c.SelectedIndex != -1)
            //            e.IsValid = true;
            //        else
            //            e.IsValid = false;
            //    else
            //        e.IsValid = true;
            //else
                e.IsValid = true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cotizacion.CodCotizacion!=null)
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar la Cotización", "Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        PdfRtfWordFormatOptions crformattype = new PdfRtfWordFormatOptions();
                        DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
                        ExportOptions objexport;
                        dfoption.DiskFileName = @"C:\Cotizaciones\Cotizacion_" + cotizacion.CodCotizacion + ".pdf";
                        ReportDocument document = new ReportDocument();
                        CRCotizacion cot = new CRCotizacion();
                        cot.SetDataSource(ds.Cotizacion(Convert.ToInt32(cotizacion.CodCotizacion)));
                        objexport = cot.ExportOptions;
                        objexport.ExportDestinationType = ExportDestinationType.DiskFile;
                        objexport.ExportFormatType = ExportFormatType.PortableDocFormat;
                        objexport.DestinationOptions = dfoption;
                        objexport.FormatOptions = crformattype;
                        cot.Export();

                        DirectoryInfo Dir = new DirectoryInfo(@"C:\Cotizaciones");

                        foreach (FileInfo Fi in Dir.GetFiles())
                        {
                            //Dt.Rows.Add(idfile, Fi.Name.ToString());
                            //idfile++;
                            if (Fi.Name.Contains(cotizacion.CodCotizacion))
                            {
                                nombreArchivo = Fi.Name;
                            }
                        }


                        if (Application.OpenForms["frmCorreoElectronico"] != null)
                        {
                            Application.OpenForms["frmCorreoElectronico"].Activate();
                        }
                        else
                        {
                            frmCorreoElectronico form = new frmCorreoElectronico();
                            form.link_adjunto.Text = nombreArchivo;
                            form.txtcuerpo.Text = "ESTIMADOS SRs.: " + cotizacion.RazonSocialCliente + Environment.NewLine + Environment.NewLine + "\t LES ADJUNTO LA COTIZACIÓN.  N- " + cotizacion.CodCotizacion + "." +
                                                            Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "\t\t\t \t\t  ATT. " +
                                                           Environment.NewLine + "\t\t\t\t" + frmLogin.sApellidoUSer + ", " + frmLogin.sNombreUser;
                            form.tipo = 2;
                            form.ShowDialog();
                            if (form.enviado == 1)
                            {
                                MessageBox.Show("La Cotización ha envio correctamente", "Cotización",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("La Cotización, No se Pudo enviar, Verifique!", "Cotización",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Enviar la Cotización", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
    }
}
