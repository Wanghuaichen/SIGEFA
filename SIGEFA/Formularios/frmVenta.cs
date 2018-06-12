using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
//using ConsultaRuc;
using System.IO;
using System.Diagnostics;

namespace SIGEFA.Formularios
{
    public partial class frmVenta : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmSerie AdmSerie = new clsAdmSerie();
        clsCaja aper = new clsCaja();
        clsAdmAperturaCierre AdmAper = new clsAdmAperturaCierre();
        clsReporteFactura ds = new clsReporteFactura();
        clsReporteFlujoCaja dsf = new clsReporteFlujoCaja();
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        clsTransaccion tran = new clsTransaccion();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsAdmPedido Admped = new clsAdmPedido();
        clsPedido pedido = new clsPedido();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        clsAdmAutorizado AdmAut = new clsAdmAutorizado();
        clsAutorizado aut = new clsAutorizado();
        clsAdmNotaSalida AdmNota = new clsAdmNotaSalida();
        clsNotaSalida nota = new clsNotaSalida();
        clsAdmGuiaRemision AdmGuia = new clsAdmGuiaRemision();
        clsGuiaRemision guia = new clsGuiaRemision();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsListaPrecio Listap = new clsListaPrecio();
        clsAdmVendedor AdmVen = new clsAdmVendedor();
        clsFacturaVenta venta = new clsFacturaVenta();
        clsFacturaVenta factura = new clsFacturaVenta();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsMoneda moneda = new clsMoneda();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsAdmListaPrecio admLista = new clsAdmListaPrecio();
        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        clsCotizacion coti = new clsCotizacion();
        clsDetalleCotizacion detaCoti = new clsDetalleCotizacion();
        clsAdmCotizacion AdmCoti = new clsAdmCotizacion();
        clsAdmAlmacen Admalmac = new clsAdmAlmacen();
        clsPago Pag = new clsPago();
        clsAdmPago AdmPagos = new clsAdmPago();
        clsSeparacion separacion = new clsSeparacion();
        public Boolean banderagrabada, banderaexonerada, banderainafecta, banderadelete = false, bandera = false;

        SIGEFA.SunatFacElec.Conexion conex = new SunatFacElec.Conexion();
        public Byte[] firmadigital { get; set; }

        public Decimal montogratuitas, montogravadas, montoexoneradas = 0, montoinafectas = 0;
        
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleNotaSalida> detalle = new List<clsDetalleNotaSalida>();
        public List<clsDetalleFacturaVenta> detalle1 = new List<clsDetalleFacturaVenta>(); 
        public List<clsDetalleGuiaRemision> detalleg = new List<clsDetalleGuiaRemision>();
        public List<Int32> documento = new List<Int32>(); 
        public List<Int32> codsalida = new List<Int32>(); 
        private List<Int32> correlativo = new List<Int32>(); 
        private List<clsFacturaVenta> ltaventa = new List<clsFacturaVenta>();  
        private List<Int32> codpro = new List<Int32>();
        clsFormaPago forma = new clsFormaPago();
        public String CodNota, CodVenta;
        public Int32 CodTransaccion;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodSerie, CodSerieG=0, numG=0, manual=0;
        public String numSerie;
        public Int32 CodAutorizado;
        public Int32 CodPedido;
        public Int32 CodGuia;
        public Int32 Tipo;
        public Int32 codForma, codListaP;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Procede = 0; //(1) Sin Guia (2)Con Guia
        public DataTable datoscarga2 = new DataTable();
        public DataTable datos = new DataTable();
        public Int32 tip;
        public Int32 CodVendedor;
        public Int32 CodSalConsulExt;
        public Int32 CodSeparacion = 0;
        DataTable NuevaTabla = new DataTable();

        public bool consultorext;

        public static BindingSource data = new BindingSource();

        Int32 CodLista = 0;
        Boolean Validacion = true;
        Decimal TipoCambio = 0, ret=0;
        public Int32 mon = 0;//MOD6
        Int32 item = 1;
        public Int32 CodEmpresaTransporte;

        private String Salida = "";
        private Int32 codCotizacion;

        public String CodPago;

        clsVehiculoTransporte vehiculotransporte = new clsVehiculoTransporte();
        clsAdmVehiculoTransporte admVehiculoTransporte = new clsAdmVehiculoTransporte();
        clsConductor conductor = new clsConductor();
        clsAdmConductor admConductor = new clsAdmConductor();
        clsAdmEmpresaTransporte AdmET = new clsAdmEmpresaTransporte();
        clsEmpresaTransporte empT = new clsEmpresaTransporte();

        public Int32 CodigoCaja = 0;
        clsCaja Caja = new clsCaja();
        clsAdmAperturaCierre AdmCaja = new clsAdmAperturaCierre();

        List<Int32> ListaEmpresa = new List<int>();
        private int tipounidad;

        public int Tipounidad
        {
            get { return tipounidad; }
            set { tipounidad = value; }
        }

        private string tipoimpuesto;

        public string Tipoimpuesto
        {
            get { return tipoimpuesto; }
            set { tipoimpuesto = value; }
        }

        private int codtipoarticulo;

        public int Codtipoarticulo
        {
            get { return codtipoarticulo; }
            set { codtipoarticulo = value; }
        }
     

        private void VentaEnMoneda()//MOD6
        {
            Decimal TipoCambio = 0;

            TipoCambio = Convert.ToDecimal(txtTipoCambio.Text.Trim());

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (mon == 1)
                {
                    if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                    {
                        row.Cells[preciounit.Name].Value = Convert.ToDecimal(row.Cells[preciounit.Name].Value) / TipoCambio;
                        row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) / TipoCambio;
                        row.Cells[montodscto.Name].Value = Convert.ToDecimal(row.Cells[montodscto.Name].Value) / TipoCambio;
                        row.Cells[valorventa.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / TipoCambio;
                        row.Cells[igv.Name].Value = Convert.ToDecimal(row.Cells[igv.Name].Value) / TipoCambio;
                        row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / TipoCambio;
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
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
        }

        public frmVenta()
        {
            InitializeComponent();
        }

        public void frmVenta_Load(object sender, EventArgs e)
        {
            iniciaformulario();
            CargaTransportista();
            CargaVehiculoTrasnporte();
            CargaBoleta();
        }

        private void CargaBoleta()
        {
            try
            {
                //if (Proceso != 3 && Proceso!=5)
                //{
                //    txtDocRef.Text = "BV"; //NV
                //    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                //    txtDocRef_KeyPress(txtDocRef, ee);
                //    //txtSerie.Text = "001";
                //    txtSerie_KeyPress(txtDocRef, ee);
                //    txtCodigoCli.Text = cli.CodCliente.ToString();
                //}

                txtTransaccion.Focus();
                txtTransaccion.Text = "FT";
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtTransaccion_KeyPress(txtTransaccion, ee);
                cmbAlmacen.Visible = true;
                cargaAlmacenes();
                btnNuevo.Focus();
                if (Proceso == 1)
                {
                    txtDocRef.Text = "BV";
                    txtCodCliente.Text = "C00000435";
                    KeyPressEventArgs ee1 = new KeyPressEventArgs((char)Keys.Return);
                    txtDocRef_KeyPress(txtDocRef, ee1);
                    txtSerie_KeyPress(txtDocRef, ee1);
                    BuscaCliente();
                    txtCodCliente.Focus();

                    if (txtTipoCambio.Visible)
                    {
                        if (tc == null)
                        {
                            MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            txtTipoCambio.Text = tc.Compra.ToString();
                            txtcodpedido.Text = "0";
                            txtcodpedido.Enabled = false;
                        }
                    }
                }
                else if (Proceso == 4)
                {
                    Proceso = 1;
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtDetalle.Text == "")
                //{
                    //RecorreDetalle();
                    if (Application.OpenForms["frmDetalleSalida"] != null)
                    {
                        Application.OpenForms["frmDetalleSalida"].Activate();
                    }
                    else
                    {
                        frmDetalleSalida form = new frmDetalleSalida();
                        form.Procede = 2;
                        form.Proceso = 1;
                        form.consultorext = checkBox1.Checked;
                        if (checkBox1.Checked == true)
                        {
                            form.CodVendedor = CodVendedor;
                            form.Procede = 42;
                            form.Proceso = 1;
                            form.consultorext = checkBox1.Checked;
                        }
                        form.Tipo = 2;
                        form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                        form.Codlista = 0;//Convert.ToInt32(cbListaPrecios.SelectedValue);
                        form.tc = tc.Compra;
                        form.productoscargados = detalle1;
                        form.alma = Convert.ToInt32(cmbAlmacen.SelectedValue);
                        form.cliEspecial = cli.CliEspecial;
                        form.ShowDialog();


                    }
                //}
                //else { MessageBox.Show("No Puede Seguir Agregando más Detalles", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                
                    dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                    calculatotales();
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
                    form.Procede = 2;
                    form.alma = Convert.ToInt32(cmbAlmacen.SelectedValue);
                    form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    form.tc = Convert.ToDouble(txtTipoCambio.Text);
                    form.Codlista = 0;//Convert.ToInt32(cbListaPrecios.SelectedValue);
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.BuscaProducto();
                    form.txtControlStock.Text = row.Cells[serielote.Name].Value.ToString();
                    form.txtCantidad.Text = String.Format("{0:#,##0.00}",row.Cells[cantidad.Name].Value);
                    form.txtPrecio.Text = String.Format("{0:#,##0.00}", row.Cells[preciounit.Name].Value);
                    form.txtDscto1.Text = String.Format("{0:#,##0.00}",row.Cells[dscto1.Name].Value);
                    form.txtPrecioNeto.Text = String.Format("{0:#,##0.00}",row.Cells[importe.Name].Value);
                    form.ShowDialog();
                }
            }
        }

        private void txtTransaccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtTransaccion.ReadOnly)
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (Application.OpenForms["frmTransacciones"] != null)
                    {
                        Application.OpenForms["frmTransacciones"].Activate();
                    }
                    else
                    {
                        frmTransacciones form = new frmTransacciones();
                        form.Proceso = 4;
                        form.ShowDialog();
                        if (CodTransaccion != 0)
                        {
                            CargaTransaccion();
                            ProcessTabKey(true);
                        }
                    }

                }
            }
            
        }

        private void CargaTransaccion()
        {
            tran = AdmTran.MuestraTransaccion(CodTransaccion);
            tran.Configuracion = AdmTran.MuestraConfiguracion(tran.CodTransaccion);
            txtTransaccion.Text = tran.Sigla;
            lbNombreTransaccion.Text = tran.Descripcion;
            lbNombreTransaccion.Visible = true;
            foreach (Control t in groupBox1.Controls)
            {
                if (t.Tag != null)
                {
                    if (t.Tag != "")
                    {
                        Int32 con = Convert.ToInt32(t.Tag);
                        if (tran.Configuracion.Contains(con))
                        {
                            t.Visible = true;
                        }
                        else
                        {
                            t.Visible = false;
                        }
                    }
                }
            }
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            //Se agrego estas lineas
            cmbFormaPago.SelectedIndex = 0;
            cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null);
            //Fin se agrego estas lineas
        }

        private void CargaVendedores()
        {
            cbovendedor.DataSource = AdmVen.MuestraVendedoresDestaque();
            cbovendedor.DisplayMember = "apellido";
            cbovendedor.ValueMember = "codVendedor";
            cbovendedor.SelectedIndex = 0;
        }

        private void CargaVendedores2()
        {
            cbovendedor.DataSource = AdmVen.MuestraVendedoresDestaque2();
            cbovendedor.DisplayMember = "apellido";
            cbovendedor.ValueMember = "codVendedor";
            cbovendedor.SelectedIndex = 0;
        }

        private void CargaListaPrecios(int codForma)
        {
            /*cbListaPrecios.DataSource = admLista.MuestraListaPrecioxFormaPago(frmLogin.iCodSucursal, codForma);
            cbListaPrecios.DisplayMember = "nombre";
            cbListaPrecios.ValueMember = "codListaPrecio";
            if (cbListaPrecios.Items.Count > 0)
            {
                cbListaPrecios.SelectedIndex = 0;
            }*/
        }

        //public void llenardetalle2(Int32 codNota)
        //{
        //    data.DataSource = null;
        //    DataTable datoscarga = new DataTable();

        //    datoscarga = AdmVenta.MuestraDetalleGuiaVenta(frmLogin.iCodAlmacen,codNota);
        //    if (datoscarga != null)
        //    {
        //        datoscarga2.Merge(datoscarga);
        //    }

        //    datos = datoscarga2;

        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        for (int j = i + 1; j < datos.Rows.Count; j++)
        //        {
        //            if (Convert.ToDouble(datos.Rows[i]["preciounitario"])
        //                    .Equals(Convert.ToDouble(datos.Rows[j]["preciounitario"])) &&
        //                Convert.ToInt32(datos.Rows[i]["codProducto"])
        //                    .Equals(Convert.ToInt32(datos.Rows[j]["codProducto"])))
        //            {
        //                datos.Rows[i]["cantidad"] = Convert.ToDouble(datos.Rows[i]["cantidad"]) +
        //                                            Convert.ToDouble(datos.Rows[j]["cantidad"]);
        //                datos.Rows[j]["codSalida"] = Convert.ToInt32(datos.Rows[j]["codSalida"]);
        //                AdmNota.deletedetalle(Convert.ToInt32(datos.Rows[j]["codDetalle"]));
        //                datos.Rows.RemoveAt(j);
        //            }
        //        }
        //    }
        //    dgvDetalle.DataSource = datos;
        //    recalculadetalle();
        //    dgvDetalle.ClearSelection();
            
        //}

        private void recalculadetalle()
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                //if (Convert.ToInt32(row.Cells[stockPend.Name].Value) != 0)
                //{
                    row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[cantidad.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                    row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[cantidad.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                    row.Cells[valorventa.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) / Convert.ToDecimal(frmLogin.Configuracion.IGV / 100 + 1);
                    row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                    row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                    row.Cells[igv.Name].Value = Convert.ToDecimal(row.Cells[importe.Name].Value) - Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                //}
            }
        }
        
        private void txtTransaccion_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                txtTransaccion.Focus();
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtTransaccion.Text != "")
                {
                    if (BuscaTransaccion())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de transacción no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaTransaccion()
        {
            tran = AdmTran.MuestraTransaccionS(txtTransaccion.Text, 1);
            if (tran != null)
            {
                CodTransaccion = tran.CodTransaccion;
                tran.Configuracion = AdmTran.MuestraConfiguracion(tran.CodTransaccion);
                txtTransaccion.Text = tran.Sigla;
                lbNombreTransaccion.Text = tran.Descripcion;
                lbNombreTransaccion.Visible = true;
                foreach (Control t in groupBox1.Controls)
                {
                    if (t.Tag != null && t.Tag!="")
                    {
                        Int32 con = Convert.ToInt32(t.Tag);
                        if (tran.Configuracion.Contains(con))
                        {
                            t.Visible = true;
                        }
                        else
                        {
                            t.Visible = false;
                        }
                    }
                }
                return true;
            }
            else
            {
                lbNombreTransaccion.Text = "";
                lbNombreTransaccion.Visible = false;
                foreach (Control t in groupBox1.Controls)
                {
                    if (t.Tag != null)
                    {
                        t.Visible = false;
                    }
                }
                return false;
            }
        }

        List<clsNotaCredito> ncredito = new List<clsNotaCredito>();
        clsAdmNotaCredito admNotac = new clsAdmNotaCredito();
        private void CargaCliente()
        {
            try
            {
                cli = AdmCli.MuestraCliente(CodCliente);
                if(cli !=null){
                    cli = AdmCli.CargaDeuda(cli);
                    ncredito = admNotac.BuscarNotasXCliente(CodCliente);
                    if (cli.Cantidad > 0)
                    {
                        DialogResult dlgResult = MessageBox.Show("El cliente selecionado presenta" + Environment.NewLine + "Facturas pendientes = " + cli.Cantidad + Environment.NewLine + "Deuda Total = " + cli.Deuda + " soles" + Environment.NewLine + "Linea de crédito = " + cli.LineaCredito + Environment.NewLine + " Desea continuar con la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            ret = 1;
                            txtCotizacion.Text = "";
                            return;
                        }
                        else
                        {
                            cargadatoscliente();
                            ret = 0;
                        }
                    }
                    else
                    {
                        cargadatoscliente();
                        ret = 0;
                    }

                    if (ncredito.Count > 0)
                    {
                        labelnotacredito.Visible = true;
                    }
                    else
                    {
                        labelnotacredito.Visible = false;
                    }
                }
                else{
                    MessageBox.Show("Cliente no identificado, Por favor verifique...!");
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        //private void cargadatoscliente()
        //{
        //    txtCodCliente.Text = cli.Dni;
        //    if (cli.Ruc != "")
        //    {
        //        txtDocRef.Text = "FT";
        //        KeyPressEventArgs ee = new KeyPressEventArgs((char) Keys.Return);

        //        txtDocRef_KeyPress(txtDocRef, ee);
        //        txtSerie.Text = "001";
        //        txtSerie_KeyPress(txtDocRef, ee);
        //        //txtCodCliente.Text = cli.Ruc;
        //    }
        //    else
        //    {
                
        //        txtDocRef.Text = "BV";
        //        KeyPressEventArgs ee = new KeyPressEventArgs((char) Keys.Return);
        //        txtDocRef_KeyPress(txtDocRef, ee);
        //        txtSerie.Text = "001";
        //        txtSerie_KeyPress(txtDocRef, ee);
        //        //txtCodigoCli.Text = cli.Dni;
        //    }
                
        //    txtNombreCliente.Text = cli.RazonSocial;
        //    txtDireccionCliente.Text = cli.DireccionLegal;
        //    txtCodigoCli.Text = cli.CodCliente.ToString();
        //    if (cli.Moneda == 1)
        //    {
        //        txtLineaCredito.Text = cli.LineaCredito.ToString();
        //        txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
        //        txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString();
        //        lbLineaCredito.Text = "Línea de Crédito (S/.):";
        //        label23.Text = "Línea Disponible (S/.):";
        //        label25.Text = "Línea C. en Uso (S/.):";
        //    }
        //    else 
        //    {
        //        txtLineaCredito.Text = cli.LineaCredito.ToString();
        //        txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
        //        txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString();
        //        lbLineaCredito.Text = "Línea de Crédito ($.):";
        //        label23.Text = "Línea Disponible ($.):";
        //        label25.Text = "Línea C. en Uso ($.):";
        //    }
           
        //    cmbFormaPago.SelectedValue = cli.FormaPago;
        //    forma = AdmPago.BuscaFormaPagoVenta(cli.FormaPago);    
        //    if (cli.CodListaPrecio != null) 
        //    { 
        //        cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null); 
        //        cbListaPrecios.SelectedValue = cli.CodListaPrecio; 
        //    }
        //    //cmbFormaPago.SelectedIndex = 0;
        //    if (cli.FormaPago != 0)
        //    {
        //        EventArgs ee = new EventArgs();
        //        cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);
               
        //    }
        //    else
        //    {
        //        dtpFechaPago.Value = DateTime.Today;
        //    }
        //    if (cli.CodVendedor != 0)
        //    {
               
        //        cbovendedor.SelectedValue = cli.CodVendedor;
        //    }
        //    txtPDescuento.Text = cli.Descuento.ToString();
        //    cmbMoneda.SelectedValue = cli.Moneda;
        //}

        private void cargadatoscliente()
        {
            txtCodCliente.Text = cli.Dni;
            if (cli.Ruc != "" && cli.Dni == "")
            {
                txtDocRef.Text = "FT";
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtDocRef_KeyPress(txtDocRef, ee);
                //txtSerie.Text = "001";
                txtSerie_KeyPress(txtDocRef, ee);
                txtCodCliente.Text = cli.Ruc;
            }
            else if (cli.Dni != "" && cli.Ruc == "")
            {

                txtDocRef.Text = "BV";
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtDocRef_KeyPress(txtDocRef, ee);
                //txtSerie.Text = "001";
                txtSerie_KeyPress(txtDocRef, ee);
                txtCodigoCli.Text = cli.Dni;
            }
            //else if(cli.Carnetext!=""){
             
            //        txtDocRef.Text = "BV";
            //        KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            //        txtDocRef_KeyPress(txtDocRef, ee);                   
            //        txtSerie_KeyPress(txtDocRef, ee);
            //        txtCodCliente.Text = cli.Carnetext;               

            //}
            else if (cli.Ruc != "" && cli.Dni != "")
            {
                if (MessageBox.Show("Si para FT(Factura) o No para BV(Boleta)", "Seleccione Tipo de Doc. Ref.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    txtDocRef.Text = "BV";
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    txtDocRef_KeyPress(txtDocRef, ee);
                    //txtSerie.Text = "001";
                    txtSerie_KeyPress(txtDocRef, ee);
                    txtCodigoCli.Text = cli.Dni;
                }
                else
                {
                    txtDocRef.Text = "FT";
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    txtDocRef_KeyPress(txtDocRef, ee);
                    //txtSerie.Text = "001";
                    txtSerie_KeyPress(txtDocRef, ee);
                    txtCodCliente.Text = cli.Ruc;
                }
            }
            txtNombreCliente.Text = cli.RazonSocial;
            txtDireccionCliente.Text = cli.DireccionLegal;
            txtCodigoCli.Text = cli.CodCliente.ToString();
            txtCodCliente.Text = cli.RucDni.ToString();
          
            if (cli.Moneda == 1)
            {
                txtLineaCredito.Text = cli.LineaCredito.ToString();
                txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
                txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString();
                lbLineaCredito.Text = "Línea de Crédito (S/.):";
                label23.Text = "Línea Disponible (S/.):";
                label25.Text = "Línea C. en Uso (S/.):";

                if (cli.LineaCredito > 0) { cmbFormaPago.Enabled = true; } else { cmbFormaPago.Enabled = false; }
            }
            else
            {
                txtLineaCredito.Text = cli.LineaCredito.ToString();
                txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
                txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString();
                lbLineaCredito.Text = "Línea de Crédito ($.):";
                label23.Text = "Línea Disponible ($.):";
                label25.Text = "Línea C. en Uso ($.):";
                if (cli.LineaCredito > 0) { cmbFormaPago.Enabled = true; } else { cmbFormaPago.Enabled = false; }
            }

            //cmbFormaPago.SelectedValue = cli.FormaPago;
            //Se cambio por la linea de arriba
            cmbFormaPago.SelectedIndex = 0;
            //Fin se cambio por la linea de arriba
            forma = AdmPago.BuscaFormaPagoVenta(cli.FormaPago);
            //if (cli.CodListaPrecio != null)
            //{
            //    cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null);
            //    txtplazo.Text = cmbFormaPago.Text;
            //    cbListaPrecios.SelectedValue = cli.CodListaPrecio;
            //}
            //cmbFormaPago.SelectedIndex = 0;
            if (cli.FormaPago != 0)
            {
                cmbFormaPago.SelectedValue = cli.FormaPago;
                EventArgs ee = new EventArgs();
                cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);

            }
            else
            {
                dtpFechaPago.Value = DateTime.Today;
            }
            if (cli.CodVendedor != 0)
            {
                cbovendedor.SelectedValue = cli.CodVendedor;
                //txtvendedor.Text = cbovendedor.Text;
            }
            txtPDescuento.Text = cli.Descuento.ToString();
            cmbMoneda.SelectedValue = cli.Moneda;
            mon = cli.Moneda;//MOD6
            txtMoneda.Text = cmbMoneda.Text;
            txttasa.Text = cli.Tasa.ToString();
        }

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtCodCliente.Text, Tipo);
            
            if (cli != null)
            {
                cli = AdmCli.CargaDeuda(cli);
                if (cli.Cantidad > 0)
                {
                    DialogResult dlgResult = MessageBox.Show("El cliente selecionado presenta" + Environment.NewLine + "Facturas pendientes = " + cli.Cantidad + Environment.NewLine + "Deuda Total = " + cli.Deuda + " soles" + Environment.NewLine + "Linea de crédito = " + cli.LineaCredito + Environment.NewLine + " Desea continuar con la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        txtNombreCliente.Text = "";
                        CodCliente = 0;
                        
                        txtPDescuento.Text = "";
                        return false;                       
                    }
                    else
                    {
                        CodCliente = cli.CodCliente;
                        cargadatoscliente();
                        return true;
                    }
                }
                else
                {
                    CodCliente = cli.CodCliente;
                    cargadatoscliente();
                    return true; 
                }
            }
            else
            {
                MessageBox.Show("El Cliente no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodCliente.Text = "";
                txtNombreCliente.Text = "";
                CodCliente = 0;
                
                txtPDescuento.Text = "";
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
                    if (CodCliente != 0)
                    {
                        CargaCliente();
                        btnNuevo.Enabled = true; ProcessTabKey(true);
                        txtDocRef.Focus();
                    }                    
                }
            }
            else if (e.KeyCode == Keys.Enter) {


                if (txtCodCliente.Text != "")
                {
                    if (BuscaCliente())
                    {
                        ProcessTabKey(true);                       
                    }
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

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }                      
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTipoCambio.Visible)
                {
                    tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
                    if (tc != null)
                    {
                        txtTipoCambio.Text = tc.Compra.ToString();
                        dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias);
                    }
                    else
                    {
                        MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpFecha.Value = DateTime.Now.Date;
                        dtpFecha.Focus();
                    }
                }
                cmbMoneda.Focus();
            }
            catch (Exception ex) { dtpFecha.Value = DateTime.Now.Date; dtpFecha.Focus(); }
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                dtpFecha.Focus();
            }
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
            if (CodTransaccion == 0)
            {
                cmbMoneda.Focus();
            }
            if (cmbMoneda.SelectedValue != null)
            {
                if (cmbMoneda.SelectedText.Equals("NUEVOS SOLES"))
                {
                    label8.Visible = false;
                    txtTipoCambio.Visible = false;
                }
            }
        }

        private void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
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
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaTipoDocumento()
        {
            doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
            if (doc != null)
            {
                CodDocumento = doc.CodTipoDocumento;
                txtCodDocumento.Text = CodDocumento.ToString();
                return true;
            }
            else
            {
                CodDocumento = 0;
                txtCodDocumento.Text = CodDocumento.ToString();
                return false;
            }
        }

        private Boolean BuscaSerie()
        {
            //ser = Admser.BuscaSerie(txtSerie.Text,CodDocumento,frmLogin.iCodAlmacen);
            ser = Admser.BuscaSeriexDocumento(CodDocumento, frmLogin.iCodAlmacen);
            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }

        }
        
        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmDocumentos"] != null)
                {
                    Application.OpenForms["frmDocumentos"].Activate();
                }
                else
                {
                   // if (cli.Ruc != "")
                   // {
                        frmDocumentos form = new frmDocumentos();
                        form.Proceso = 3;
                        form.ShowDialog();
                        doc = form.doc;
                        CodDocumento = doc.CodTipoDocumento;
                        txtCodDocumento.Text = CodDocumento.ToString();
                        txtDocRef.Text = doc.Sigla;
                        if (CodDocumento != 0) { ProcessTabKey(true); }
                   // }
                }
            }
        }

        private void VerificarCabecera()
        {
            Validacion = true;
            if (CodTransaccion == 0 || CodDocumento == 0)
            {
                Validacion = false;
            }
            if (txtCodCliente.Visible && CodCliente == 0)
            {
                Validacion = false;
            }
            //if (txtPedido.Visible && CodPedido == 0)
            //{
            //    Validacion = false;
            //}
            if (txtAutorizacion.Visible && CodAutorizado == 0)
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
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            cmbMoneda.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtNumero.Visible = estado;
            txtNumero.ReadOnly = estado;
            //txtPedido.ReadOnly = estado;
            txtComentario.ReadOnly = estado;
            txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnNuevo.Visible = !estado;
           // btnEditar.Visible = !estado;
            btnEliminar.Visible = !estado;
            btnGuardar.Visible = !estado;
           // btnImprimir.Visible = estado;
            btnNuevaVenta.Visible = estado;
           // ckbguia.Enabled = !estado;
            cbovendedor.Enabled = !estado;
            //cbListaPrecios.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtSerie.ReadOnly = estado;
            //txtGuias.Enabled = !estado;
            txtCotizacion.Enabled = !estado;
            lblAlmacen.Visible=!estado;
            cmbAlmacen.Visible=!estado;
            //txtDetalle.Enabled = !estado;
            //groupBox5.Visible = !estado;
        }

        private void BloquearEdicion(Boolean estado)// para bloquear la edicion de la factura en caso de cargar datos de una cotizacion vigente
        {
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            cmbMoneda.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtNumero.Visible = estado;
            txtNumero.ReadOnly = estado;
            //txtPedido.ReadOnly = estado;
            txtComentario.ReadOnly = estado;
            txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnNuevo.Visible = !estado;
            //btnEditar.Visible = !estado;
            //btnEliminar.Visible = !estado;//MOD5
            //btnGuardar.Visible = !estado;
            //btnImprimir.Visible = estado;
            //btnNuevaVenta.Visible = estado;
            //ckbguia.Enabled = !estado;
            cbovendedor.Enabled = !estado;
            //cbListaPrecios.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtSerie.ReadOnly = estado;
            //txtGuias.Enabled = !estado;
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmVenta.CargaDetalle(Convert.ToInt32(venta.CodFacturaVenta), frmLogin.iCodAlmacen);
        }

        private void CargaDetalleCotizacion()
        {
            dgvDetalle.DataSource = AdmCoti.CargaDetalle(Convert.ToInt32(coti.CodCotizacion), frmLogin.iCodAlmacen);
        }

        private void CargaDetalleGuia()
        {
            dgvDetalle.DataSource = AdmGuia.CargaDetalle(Convert.ToInt32(guia.CodGuiaRemision));
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
           
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        public DateTime fecha1, fecha2;

       
        private void CargaTransportista()
        {
           /* cmbTransportista.DataSource = admConductor.CargaConductores();
            cmbTransportista.DisplayMember = "nombre";
            cmbTransportista.ValueMember = "codConductor";
            cmbTransportista.SelectedIndex = -1;*/
        }

        private void CargaVehiculoTrasnporte()
        {
           /* cmbVehiculo.DataSource = admVehiculoTransporte.CargaVehiculoTransportes();
            cmbVehiculo.DisplayMember = "placa";
            cmbVehiculo.ValueMember = "codVehiculoTransporte";
            cmbVehiculo.SelectedIndex = -1;*/
        }

        private void iniciaformulario()
        {
            CargaMoneda();
            dtpFecha.MaxDate = DateTime.Today.Date;
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            CargaFormaPagos();
            CargaVendedores();
            if (Proceso == 2)
            {
                CargaVenta();
            }
            else if (Proceso == 3)
            {
                CargaVenta();
                sololectura(true);
                groupBox3.Visible = false;
                //groupBox5.Visible = false;
                btnImprimir.Visible = true;
                
            }
            else if (Proceso == 4)
            {
                txtcodpedido.Text = CodPedido.ToString().PadLeft(11, '0');
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtcodpedido_KeyPress(txtcodpedido, ee);
                Procede = 4;//PEDIDO VENTA
               
            }
            else if (Proceso == 5)
            {
                txtcodpedido.Text = CodSeparacion.ToString().PadLeft(11, '0');
                Procede = 7;//SEPARACION VENTA
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtcodpedido_KeyPress(txtcodpedido, ee);
            }

            if (consultorext == true)
            {
                checkBox1.Checked = true;
                CargaVendedores2();
                cbovendedor.SelectedIndex = 0;
                CodVendedor = Int32.Parse(cbovendedor.SelectedValue.ToString());
                //  cbovendedor.SelectedValue = CodVendedor;
                //  cbovendedor.Enabled = false;
            }
            else
            {
                //Sin Vendedor
                checkBox1.Checked = false;
                CargaVendedores();

            }
            txtCodigoCli.Visible = false;
        }

        private void cargaAlmacenes()
        {
            cmbAlmacen.DataSource = Admalmac.CargaAlmacen2(frmLogin.iCodEmpresa);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen; ;
        }

        private void frmVenta_Shown(object sender, EventArgs e)
        {
            //txtTransaccion.Focus();
            //txtTransaccion.Text = "FT";
            //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            //txtTransaccion_KeyPress(txtTransaccion, ee);
            //cmbAlmacen.Visible = true;
            //cargaAlmacenes();
            //btnNuevo.Focus();
            //if (Proceso == 1)
            //{
            //    txtDocRef.Text = "BV";
            //    txtCodCliente.Text = "C000001";
            //    KeyPressEventArgs ee1 = new KeyPressEventArgs((char)Keys.Return);
            //    txtDocRef_KeyPress(txtDocRef, ee1);
            //    txtSerie_KeyPress(txtDocRef, ee1);
            //    BuscaCliente();
            //    txtCodCliente.Focus();

            //    if (txtTipoCambio.Visible)
            //    {
            //        if (tc == null)
            //        {
            //            MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //        else
            //        {
            //            txtTipoCambio.Text = tc.Compra.ToString();
            //            txtcodpedido.Text = "0";
            //            txtcodpedido.Enabled = false;
            //        }
            //    }
            //}
            //else if (Proceso == 4)
            //{
            //    Proceso = 1;
            //}
        }

        public Boolean xgenerar = false;
        private void CargaVenta()
        {
            try
            {
                venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(CodVenta));
                
                if (venta != null)
                {
                    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                    guia = AdmGuia.CargaGuiaVenta(Convert.ToInt32(CodVenta));

                    txtNumDoc.Text = venta.CodFacturaVenta;
                    CodTransaccion = venta.CodTipoTransaccion;
                    CargaTransaccion();                    

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = venta.CodCliente;
                        cli = AdmCli.MuestraCliente(CodCliente);
                        txtCodCliente.Text = venta.DNI;
                        txtNombreCliente.Text = venta.RazonSocialCliente;
                        txtDireccionCliente.Text = venta.Direccion;
                        txtLineaCredito.Text = cli.LineaCredito.ToString();
                        txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
                        txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString(); 
                    }
                    dtpFecha.Value = venta.FechaSalida;
                    cmbMoneda.SelectedValue = venta.Moneda;
                    txtTipoCambio.Text = venta.TipoCambio.ToString();
                    if (txtAutorizacion.Enabled)
                    {
                        //se guarda el codigo del autorizado y se cargan los datos de este
                    }
                    //if (txtDocRef.Enabled)
                    //{
                        CodDocumento = venta.CodTipoDocumento;
                        txtCodDocumento.Text = CodDocumento.ToString();
                        txtDocRef.Text = venta.SiglaDocumento;
                        txtSerie.Text = venta.Serie;
                        if (Procede != 4) txtNumero.Text = venta.NumDoc;
                        else txtNumero.Text = numSerie;
                    /* para poder generar a la hora de imprimir */
                        if (txtSerie.Text == "" && txtNumero.Text == "")
                        {
                            xgenerar = true;
                        }
                        //}
                        /* para poder generar a la hora de imprimir */
                    if (cbovendedor.Enabled)
                    {
                        if (venta.CodVendedor != 0)
                        {
                            cbovendedor.SelectedValue = venta.CodVendedor;
                        }
                    }
                    if (guia != null)
                    {
                        if (guia.CodFactura == Convert.ToInt32(venta.CodFacturaVenta))
                        {
                           // ckbguia.Checked = true;
                            //txtGuias.Text = guia.CodGuiaRemision;
                        }
                        else
                        {
                            //ckbguia.Checked = false;
                            //*txtGuias.Text = "";
                        }
                    }
                    cmbFormaPago.SelectedValue = venta.FormaPago;
                    cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null);
                    //cbListaPrecios.SelectedValue = venta.CodListaPrecio;
                    dtpFechaPago.Value = venta.FechaPago;
                    txtComentario.Text = venta.Comentario;
                   // txtDetalle.Text = venta.Detallecomentario;
                    txtBruto.Text = String.Format("{0:#,##0.00}", venta.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", venta.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", venta.Total - venta.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", venta.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", venta.Total);
                    CargaDetalle();

                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

       

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                //if (txtSerie.Text != "")
                //{
                    if (BuscaSerie())
                    {
                        txtSerie.Text = ser.Serie.ToString();
                        if (ser.PreImpreso)
                        {
                            txtNumero.Visible = true;
                            txtNumero.Enabled = false;
                           // ckbguia.Visible = false;
                            txtNumero.Focus();
                            txtNumero.Text = "";
                        }
                        else
                        {
                            txtNumero.Text = "";
                            //txtNumero.Enabled = true;
                            txtNumero.Enabled = false;
                            //txtNumero.Visible = false;
                            txtNumero.Text = ser.Numeracion.ToString();
                        }

                        ProcessTabKey(true);
                        cmbFormaPago.Focus();
                    }
                    //else
                    //{
                    //    MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda",
                    //            "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                //}
            }
            if (e.KeyChar == (char) Keys.Enter)
            {
                cmbFormaPago.Focus();
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (BuscaSerie2())
            {
                txtSerie.Text = ser.Serie.ToString();
                if (ser.PreImpreso)
                {
                    txtNumero.Visible = true;
                    txtNumero.Text = "";
                    //ckbguia.Visible = false;
                    txtNumero.Focus();
                }
                else
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = false;
                    txtNumero.Text = ser.Numeracion.ToString();
                }
            }
            
        }
        private Boolean BuscaSerie2()
        {
            ser = Admser.MuestraSerie(CodSerie, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }
        }
        private Boolean BuscaSerie3(int codDocumento)
        {
            ser = Admser.MuestraSerie(codDocumento, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            //if (txtNumero.Text == "")
            //{
            //    txtNumero.Focus();
            //}
            //else
            //{
            //    VerificarCabecera();
               
            //}
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Procede != 2 || Procede != 3)
            {
                if (Proceso == 1)
                {
                    if (txtPDescuento.Text != "")
                    {
                        calculatotales();
                        calculadescuentogeneral();
                    }
                    else
                    {
                        calculatotales();
                    }

                    if (dgvDetalle.RowCount > 0)
                    {
                        int Indice = 0;
                        Indice = dgvDetalle.RowCount - 1;

                        if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                        {
                            if (TipoCambio != 0)
                            {
                                dgvDetalle[8, Indice].Value = Convert.ToDecimal(dgvDetalle[8, Indice].Value)*TipoCambio;
                                dgvDetalle[9, Indice].Value = Convert.ToDecimal(dgvDetalle[9, Indice].Value)*TipoCambio;
                                dgvDetalle[13, Indice].Value = Convert.ToDecimal(dgvDetalle[13, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[14, Indice].Value = Convert.ToDecimal(dgvDetalle[14, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[15, Indice].Value = Convert.ToDecimal(dgvDetalle[15, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[16, Indice].Value = Convert.ToDecimal(dgvDetalle[16, Indice].Value)*
                                                               TipoCambio;
                            }
                        }
                        else if (Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                        {
                        }
                    }
                }
            }
        }

        public void calculatotales()
        {
            if (Proceso != 0)
            {
                if (Procede != 3)
                {
                    Decimal bruto = 0;
                    Decimal descuen = 0;
                    Decimal valor = 0;
                    Decimal preciovent = 0;
                    Decimal igvt = 0;

                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                        descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                        valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                        preciovent = preciovent + Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                        igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                    }
                    txtBruto.Text = String.Format("{0:#,##0.00}", bruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);

                    //txtIGV.Text = String.Format("{0:#,##0.00}", bruto - descuen - valor);
                    txtIGV.Text = String.Format("{0:#,##0.00}", igvt);
                    //txtPrecioVenta.Text = String.Format("{0:#,##0.00}", bruto);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", preciovent);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                Double totalsoles = 0;
                aper = AdmAper.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, 1, frmLogin.iCodAlmacen, frmLogin.iCodUser);//1 caja ventas
                if (aper != null)
                {
                    if (superValidator1.Validate())
                    {
                        if (Convert.ToInt32(cli.Moneda) != Convert.ToInt32(cmbMoneda.SelectedValue))
                        {
                            if (Convert.ToInt32(cli.Moneda) == 2 || Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                                totalsoles = Convert.ToDouble(txtPrecioVenta.Text) / Convert.ToDouble(txtTipoCambio.Text);
                            else if (Convert.ToInt32(cli.Moneda) == 1 || Convert.ToInt32(cmbMoneda.SelectedValue) == 2)
                                totalsoles = Convert.ToDouble(txtPrecioVenta.Text) * Convert.ToDouble(txtTipoCambio.Text);

                        }
                        else
                        {
                            totalsoles = Convert.ToDouble(txtPrecioVenta.Text);
                        }
                        if ((totalsoles > Convert.ToDouble(txtLineaCreditoDisponible.Text)) && Convert.ToInt32(cmbFormaPago.SelectedValue) != 6 && txtCodigoCli.Text != "")
                        {
                            MessageBox.Show("El Monto Excede a la Línea de Crédito");
                        }
                        else
                        {
                            if (Proceso != 0)
                            {
                                GeneraListaEnpresas();
                                venta.CodSucursal = frmLogin.iCodSucursal;
                                venta.CodAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
                                venta.CodTipoTransaccion = tran.CodTransaccion;
                                if (txtCodigoCli.Text != "")
                                {
                                    venta.CodCliente = Convert.ToInt32(txtCodigoCli.Text);
                                }
                                else
                                {
                                    venta.CodCliente = 0;
                                }

                                venta.CodTipoDocumento = doc.CodTipoDocumento;
                                venta.Detallecomentario = "";
                                venta.CodCotizacion = 0; 

                                switch (txtDocRef.Text) {

                                    case "BV":
                                        venta.Boletafactura = 1;
                                        break;

                                    case "FT":
                                        venta.Boletafactura = 2;
                                        break;
                                
                                }

                               
                                venta.CodSerie = CodSerie;               
                                venta.Serie = txtSerie.Text;
                                venta.NumDoc = txtNumero.Text;
                                venta.Estado = 1;
                                venta.Consultorext = false;
                                venta.Codsalidaconsulext = 0;
                                venta.CodPedido = Convert.ToInt32(pedido.CodPedido);                               
                                venta.Nombre=txtNombreCliente.Text.ToString();
                                venta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);            
                                if (txtTipoCambio.Visible)
                                {
                                    venta.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                                }
                                venta.FechaSalida = dtpFecha.Value;
                                venta.FechaPago = dtpFechaPago.Value;
                                venta.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                                venta.CodListaPrecio = 0;// Convert.ToInt32(cbListaPrecios.SelectedValue);
                                venta.CodVendedor = Convert.ToInt32(cbovendedor.SelectedValue);
                                venta.Comentario = txtComentario.Text;
                                venta.CodUser = frmLogin.iCodUser;
                                venta.Entregado = Convert.ToInt32(rbtnPendiente.Checked);  

                                //venta.MontoBruto = Convert.ToDouble(txtBruto.Text);
                                //venta.MontoBruto = Convert.ToDouble(txtValorVenta.Text);
                               // venta.MontoDscto = Convert.ToDouble(txtDscto.Text);
                                //venta.Igv = Convert.ToDouble(txtIGV.Text);
                                //venta.Total = Convert.ToDouble(txtPrecioVenta.Text);
                               
                                //txtDetalle.Text = txtDetalle.Text.Replace(" - ", "");
                               // txtDetalle.Text = txtDetalle.Text.Replace("\r\n", "\r\n - ");
                                //if (txtDetalle.Text != "") txtDetalle.Text = " - " + txtDetalle.Text;
                                //txtDetalle.Text;
                                venta.CodSeparacion = Convert.ToInt32(separacion.CodSeparacion);                                                  
                                venta.CodigoBarras = DateTime.Today.Year.ToString().Substring(2, 2) + DateTime.Today.Month.ToString().PadLeft(2, '0') +
                                    DateTime.Today.Day.ToString().PadLeft(2, '0') + DateTime.Now.ToShortTimeString().Substring(0, 2) + DateTime.Now.ToShortTimeString().Substring(3, 2) +
                                    venta.CodSerie.ToString().PadLeft(3, '0') + CodCliente;
                                venta.CodigoBarrasCifrado = ok.Encode(venta.CodigoBarras);
                                pedido.CodigoBarras = venta.CodigoBarras;
                                pedido.CodigoBarrasCifrado = venta.CodigoBarrasCifrado;


                                if (CodTransaccion == 5)
                                {
                                    venta.TipoDocumentoAnticipo = "";//cmbTipoDocumentoAnticipo.SelectedValue.ToString();
                                    venta.DocumentoReferenciaAnticipo = "";
                                    venta.MontoAnticipo = 0m;
                                }
                                else
                                {
                                    venta.TipoDocumentoAnticipo = "";
                                    venta.DocumentoReferenciaAnticipo = "";
                                    venta.MontoAnticipo = 0m;
                                }

                                clsFacturaVenta factura = new clsFacturaVenta();
                                factura = AdmVenta.FechaCorrelativoAnterior(venta.CodSerie);


                                foreach (Int32 lista in ListaEmpresa)
                                {
                                    if (mdi_Menu.MontoTopeBoleta > 0)
                                    {
                                        CrearTablaTemporal();
                                        OrdenarTablaTemporal();
                                        CreaBoletas(lista);
                                    }
                                    else { 
                                        
                                        ArmaCabecera(lista);
                                    
                                    }
                                    venta.CodEmpresa = lista;
                                    if (Proceso == 1)
                                    {
                                        if (factura.FechaSalida > venta.FechaSalida.Date)
                                        {
                                            MessageBox.Show("Error No se puede Registrar los Datos. Verifique Fecha");
                                        }
                                        else
                                        {
                                            if (AdmVenta.insert(venta))
                                                {
                                                    RecorreDetalle(lista);

                                                    if (detalle1.Count > 0)
                                                    {
                                                        foreach (clsDetalleFacturaVenta det in detalle1)
                                                        {
                                                            AdmVenta.insertdetalle(det);
                                                            if (det.CodDetalleVenta == 0)
                                                            {
                                                                MessageBox.Show("Error No se puede Registrar los Datos. Falta Stock de Productos");
                                                                //AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 0);
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    MessageBox.Show("Los datos se guardaron correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    txtNumDoc.Text = venta.CodFacturaVenta.PadLeft(11, '0');
                                                    ltaventa.Add(venta);

                                                    if (ncredito.Count > 0)
                                                    {
                                                        frmCancelarPago form = new frmCancelarPago();
                                                        form.CodNota = venta.CodFacturaVenta;
                                                        form.VentComp = 1;
                                                        form.tipo = 3;
                                                        form.CodCliente = cli.CodCliente;
                                                        form.ShowDialog();
                                                    }
                                                    else
                                                    {
                                                        if (fpago.Dias == 0 && venta.CodTipoTransaccion == 7)
                                                        //se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                                                        {
                                                            ingresarpago();
                                                        }
                                                        CodVenta = venta.CodFacturaVenta;
                                                        //Proceso = 0;
                                                        if (venta.FormaPago != 6)
                                                        {
                                                            btnImprimir.Visible = true;
                                                        }
                                                    }
                                                    //FACTURACION ELECTRONICA
                                                    if (lista == 1 && venta.CodTipoDocumento != 26)
                                                    {
                                                        conex.GeneraXML(cli, venta, detalle1);
                                                        // contingencia xml - SUNAT
                                                        if (conex.enviado != 0)
                                                        {
                                                            var resultado = conex.respuestaserver;

                                                            if (resultado != null)
                                                            {
                                                                String cad = resultado.Item1;
                                                                String[] codigores;

                                                                codigores = cad.Split('.');

                                                                if (codigores.Length > 0)
                                                                {
                                                                    switch (codigores[1])
                                                                    {
                                                                        case "sunat":conex.enviado = 2; break;
                                                                        case "1033": conex.enviado = 2; break;
                                                                        case "0130": conex.enviado = 2; break;
                                                                        case "0131": conex.enviado = 2; break;
                                                                        case "0132": conex.enviado = 2; break;
                                                                        case "0133": conex.enviado = 2; break;
                                                                        case "0134": conex.enviado = 2; break;
                                                                        case "0135": conex.enviado = 2; break;
                                                                        case "0136": conex.enviado = 2; break;
                                                                        case "0137": conex.enviado = 2; break;
                                                                        case "0138": conex.enviado = 2; break;
                                                                    }
                                                                }

                                                                Boolean actualiza = AdmVenta.actualizaEstadoEnvio(conex.enviado, Convert.ToInt32(venta.CodFacturaVenta));
                                                                if (actualiza && conex.enviado == 2)
                                                                {
                                                                    Boolean actualizaError = AdmVenta.actualizaEstadoEnvioConError(conex.CodigoErrorEnvio, Convert.ToInt32(venta.CodFacturaVenta));
                                                                    if (actualizaError && conex.CodigoErrorEnvio == 1)
                                                                    {
                                                                        //AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 1);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        firmadigital = conex.LogoEmp;
                                                       
                                                    }

                                                fnImprimir();
                                            }
                                            //}
                                        }
                                    }
                                }





                                //if (Proceso == 1 || Proceso == 5)
                                //{
                                //    if (factura.FechaSalida > venta.FechaSalida.Date)
                                //    {
                                //        MessageBox.Show("Error No se puede Registrar los Datos. Verifique Fecha");
                                //    }
                                //    else
                                //    {
                                //        if (VerificarDetracciones())
                                //        {
                                //            if (AdmVenta.insert(venta))
                                //            {
                                //                RecorreDetalle();
                                //                if (detalle1.Count > 0)
                                //                {
                                //                    foreach (clsDetalleFacturaVenta det in detalle1)
                                //                    {
                                //                        AdmVenta.insertdetalle(det);
                                //                        if (det.CodDetalleVenta == 0)
                                //                        {
                                //                            MessageBox.Show("Error No se puede Registrar los Datos. Falta Stock de Productos");
                                //                            AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 0);
                                //                            //break;
                                //                            return;
                                //                        }

                                //                    }


                                //                }
                                //                /*if (ckbguia.Checked)
                                //                {
                                //                    guia.CodAlmacen = frmLogin.iCodAlmacen;
                                //                    guia.CodTipoDocumento = 11; //codigo de documento Guia de Remision
                                //                    guia.CodSerie = Convert.ToInt32(txtcodserie.Text); //codigo de serie 001 de la guia de remision
                                //                    guia.CodMotivo = 0; //codigo de motivo venta
                                //                    if (CodPedido != 0)
                                //                    {
                                //                        guia.CodPedido = CodPedido;
                                //                    }
                                //                    guia.FechaEmision = dtpFecha.Value;
                                //                    guia.FechaTraslado = venta.FechaSalida;
                                //                    guia.CodCliente = Convert.ToInt32(txtCodigoCli.Text);
                                //                    if (cmbVehiculo.SelectedValue == null) guia.CodVehiculoTransporte = 0;
                                //                    else guia.CodVehiculoTransporte = Convert.ToInt32(cmbVehiculo.SelectedValue); //codigo del vehiculo de la empresa
                                //                    if (cmbTransportista.SelectedValue == null) cmbTransportista.SelectedValue = 0;
                                //                    else cmbTransportista.SelectedValue = Convert.ToInt32(cmbTransportista.SelectedValue); // codigo del conductor
                                //                    guia.CodEmpresaTransporte = CodEmpresaTransporte;
                                //                    guia.Facturado = 1;
                                //                    guia.CodFactura = Convert.ToInt32(venta.CodFacturaVenta);
                                //                    guia.Comentario = txtComentario.Text;
                                //                    guia.CodUser = frmLogin.iCodUser;
                                //                    guia.Estado = 1;
                                //                    // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                                //                    if (AdmGuia.insert(guia))
                                //                    {
                                //                        RecorreDetalleGuia();
                                //                        if (detalleg.Count > 0)
                                //                        {
                                //                            foreach (clsDetalleGuiaRemision detg in detalleg)
                                //                            {
                                //                                AdmGuia.insertdetalle(detg);
                                //                                AdmNota.ActualizaCantidadPendienteVenta(detg.Cantidad, detg.CodProducto, Convert.ToInt32(venta.CodFacturaVenta));
                                //                            }
                                //                            AdmGuia.insertrelacionguia(Convert.ToInt32(guia.CodGuiaRemision), guia.CodFactura, frmLogin.iCodAlmacen, frmLogin.iCodUser, 0);
                                //                        }
                                //                        MessageBox.Show("Se ha generado la guia de remision correspondiente",
                                //                            "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //                        //this.Close();                                
                                //                    }
                                //                }*/

                                //                MessageBox.Show("Los datos se guardaron correctamente", "Venta",
                                //                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                                //                /*******Factura Electronica**********************/






                                //                txtNumDoc.Text = venta.CodFacturaVenta.PadLeft(11, '0');
                                //                ltaventa.Add(venta);
                                //                if (ncredito.Count > 0)
                                //                {
                                //                    frmCancelarPago form = new frmCancelarPago();
                                //                    form.CodNota = venta.CodFacturaVenta;
                                //                    form.VentComp = 1;
                                //                    form.tipo = 3;
                                //                    form.CodCliente = cli.CodCliente;
                                //                    form.ShowDialog();
                                //                    this.Close();
                                //                }
                                //                else
                                //                {
                                //                    if (fpago.Dias == 0 && venta.CodTipoTransaccion == 7)
                                //                    //se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                                //                    {

                                //                        if (venta.CodSeparacion != 0)
                                //                        {
                                //                            MessageBox.Show("Debe de retirar de caja de separacion " + venta.Total, "Venta",
                                //                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //                            xgenerar = true;
                                //                            fnImprimir();
                                                          
                                //                            //fnImprimir();
                                //                            //this.Close();
                                //                        }

                                //                        //ingresarpago();//aqui cambiar esto
                                //                        if (Procede != 7)
                                //                        {
                                //                            frmCancelarPago form = new frmCancelarPago();
                                //                            form.CodNota = venta.CodFacturaVenta;
                                //                            form.tipo = 3;
                                //                            form.tip = 3;
                                //                            form.Monto = venta.Total;
                                //                            form.venta = venta;
                                //                            form.montoPag = 0;
                                //                            form.ShowDialog();
                                //                        }
                                //                    }
                                //                    CodVenta = venta.CodFacturaVenta;
                                //                    Proceso = 0;
                                //                    if (venta.FormaPago != 6)
                                //                    {
                                //                        btnImprimir.Visible = true;
                                //                        xgenerar = true;
                                //                        btnGuardar.Visible = false;
                                //                        //this.Close();
                                //                    }

                                //                }
                                //            }
                                //        }
                                //    }

                                //}
                                //else if (Proceso == 2)
                                //{
                                //    if (VerificarDetracciones())
                                //    {
                                //        if (AdmVenta.update(venta))
                                //        {
                                //            RecorreDetalle();
                                //            foreach (clsDetalleFacturaVenta det in venta.Detalle)
                                //            {
                                //                foreach (clsDetalleFacturaVenta det1 in detalle1)
                                //                {
                                //                    if (det.Equals(det1))
                                //                    {
                                //                        AdmVenta.updatedetalle(det1);
                                //                        return;
                                //                    }
                                //                }

                                //            }
                                //            foreach (clsDetalleFacturaVenta deta in detalle1)
                                //            {
                                //                if (deta.CodDetalleVenta == 0)
                                //                {
                                //                    AdmVenta.insertdetalle(deta);
                                //                }
                                //            }

                                //            MessageBox.Show("Los datos se actualizaron correctamente", "Venta",
                                //                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //            this.Close();
                                //        }
                                //    }
                                //}
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe Aperturar Caja", "Apertura Caja", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }


        private void RecorreDetalle(Int32 codigo)
        {
            detalle.Clear();
            detalle1.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle(row, codigo);
                }
            }
        }



        private void añadedetalle(DataGridViewRow fila, Int32 cod)
        {
            if (cod == frmLogin.iCodEmpresa)
            {
                clsDetalleFacturaVenta deta = new clsDetalleFacturaVenta();
                deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
                deta.CodVenta = Convert.ToInt32(venta.CodFacturaVenta);
                deta.CodAlmacen =frmLogin.iCodAlmacen;
                deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
                deta.SerieLote = "";
                deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
                deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
                deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
                deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
                deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
                if (!chkVentaGratuita.Checked && !chkVentaDsctoGlobal.Checked)
                {
                    deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
                }
                deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
                deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
                deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
                deta.CodUser = frmLogin.iCodUser;
                deta.CantidadPendiente = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
                deta.Moneda = 1;
                deta.Descripcion = fila.Cells[descripcion.Name].Value.ToString();
                deta.CodTipoArticulo = codtipoarticulo;
                if (!chkVentaGratuita.Checked && !chkVentaDsctoGlobal.Checked)
                {
                    deta.Tipoimpuesto = fila.Cells[MiTipoImpuesto.Name].Value.ToString(); //Tipoimpuesto;

                }
                else {

                    deta.Tipoimpuesto = "21"; 
                }

                deta.Entregado = rbtnPendiente.Checked;
                deta.TipoUnidad = Tipounidad;
                deta.CodDetalleCotizacion = 0;
                //if (Procede == 4)//pedido
                //{
                deta.CodDetallePedido = 0;// Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
                //}
                //else// venta
                //{
                //    deta.CodDetallePedido = 0;
                //}
                detalle1.Add(deta);
            }
        }

        private void ImprimeEspecial(Int32 lista)
        {
            if (detalle1.Count > 0)
            {
                foreach (clsDetalleFacturaVenta det in detalle1)
                {
                    AdmVenta.insertdetalle(det);
                    if (det.CodDetalleVenta == 0)
                    {
                        MessageBox.Show("Error No se puede Registrar los Datos. Falta Stock de Productos");
                        AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 0);
                        return;
                    }
                }
            }
            MessageBox.Show("Los datos se guardaron correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNumDoc.Text = venta.CodFacturaVenta.PadLeft(11, '0');
            ltaventa.Add(venta);

            if (ncredito.Count > 0)
            {
                frmCancelarPago form = new frmCancelarPago();
                form.CodNota = venta.CodFacturaVenta;
                form.VentComp = 1;
                form.tipo = 3;
                form.CodCliente = cli.CodCliente;
                form.ShowDialog();
            }
            else
            {
                if (fpago.Dias == 0 && venta.CodTipoTransaccion == 7)
                //se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                {
                    ingresarpago();
                }
                CodVenta = venta.CodFacturaVenta;
                //Proceso = 0;
                if (venta.FormaPago != 6)
                {
                    btnImprimir.Visible = true;
                }
            }
            //FACTURACION ELECTRONICA
            if (lista != 3)
            {
                conex.GeneraXML(cli, venta, detalle1);
                // contingencia xml - SUNAT
                if (conex.enviado != 0)
                {
                    var resultado = conex.respuestaserver;

                    if (resultado != null)
                    {
                        String cad = resultado.Item1;
                        String[] codigores;

                        codigores = cad.Split('.');

                        if (codigores.Length > 0)
                        {
                            switch (codigores[1])
                            {
                                case "sunat": conex.enviado = 2; break;
                                case "1033": conex.enviado = 2; break;
                                case "0130": conex.enviado = 2; break;
                                case "0131": conex.enviado = 2; break;
                                case "0132": conex.enviado = 2; break;
                                case "0133": conex.enviado = 2; break;
                                case "0134": conex.enviado = 2; break;
                                case "0135": conex.enviado = 2; break;
                                case "0136": conex.enviado = 2; break;
                                case "0137": conex.enviado = 2; break;
                                case "0138": conex.enviado = 2; break;
                            }
                        }

                        Boolean actualiza = AdmVenta.actualizaEstadoEnvio(conex.enviado, Convert.ToInt32(venta.CodFacturaVenta));
                        if (actualiza && conex.enviado == 2)
                        {
                            Boolean actualizaError = AdmVenta.actualizaEstadoEnvioConError(conex.CodigoErrorEnvio, Convert.ToInt32(venta.CodFacturaVenta));
                            if (actualizaError && conex.CodigoErrorEnvio == 1)
                            {
                                AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 1);
                            }
                        }
                    }
                }
                firmadigital = conex.LogoEmp;
            }
            fnImprimir();
        }


        private void RecorreDetalleEspecial(Int32 codigo, Int32 codEmpresa)
        {
            detalle.Clear();
            detalle1.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataRow row in NuevaTabla.Rows)
                {
                    AñadeDetalleEspecial(row, codigo, codEmpresa);
                }
            }
        }

        private void AñadeDetalleEspecial(DataRow row, Int32 codigo, Int32 codEmpresa)
        {
            if (codigo == Convert.ToInt32(row[0]) && codEmpresa == Convert.ToInt32(row[25]))
            {
                clsDetalleFacturaVenta deta = new clsDetalleFacturaVenta();
                deta.CodProducto = Convert.ToInt32(row[1]);
                deta.CodVenta = Convert.ToInt32(venta.CodFacturaVenta);
                deta.CodAlmacen = Convert.ToInt32(row[22]);
                deta.UnidadIngresada = Convert.ToInt32(row[4]);
                deta.SerieLote = "";
                deta.Cantidad = Convert.ToDouble(row[6]);
                deta.PrecioUnitario = Convert.ToDouble(row[7]);
                deta.Subtotal = Convert.ToDouble(row[8]);
                deta.Descuento1 = Convert.ToDouble(row[9]);
                deta.MontoDescuento = Convert.ToDouble(row[12]);
                deta.Igv = Convert.ToDouble(row[14]);
                deta.Importe = Convert.ToDouble(row[15]);
                deta.PrecioReal = Convert.ToDouble(row[17]);
                deta.ValoReal = Convert.ToDouble(row[16]);
                deta.CodUser = frmLogin.iCodUser;
                deta.CantidadPendiente = Convert.ToDouble(row[6]);
                deta.Moneda = 1;
                deta.Descripcion = row[3].ToString();
                deta.CodTipoArticulo = Convert.ToInt32(row[20]);
                deta.Tipoimpuesto = row[21].ToString();
                deta.Entregado = rbtnPendiente.Checked;
                deta.TipoUnidad = Convert.ToInt32(row[24]);
                deta.CodDetalleCotizacion = 0;
                //if (Procede == 4)//pedido
                //{
                deta.CodDetallePedido = 0;
                //}
                //else// venta
                //{
                //    deta.CodDetallePedido = 0;
                //}
                detalle1.Add(deta);
            }
        }

        private void NuevaCabecera(Int32 codbol)
        {
            ser = AdmSerie.CargaSerieEmpresa(venta.CodEmpresa, doc.CodTipoDocumento);
            venta.CodSerie = ser.CodSerie;
            venta.Serie = ser.Serie;
            venta.NumDoc = ser.Numeracion.ToString().PadLeft(8, '0');

            if (chkVentaGratuita.Checked) { venta.Tipoventa = 4; }  // venta gratuita
            else if (chkVentaDsctoGlobal.Checked)
            {
                venta.Tipoventa = 5; // venta con descuento Global
            }

            detalle.Clear();
            detalle1.Clear();

            Decimal bruto = 0; Decimal Dscto = 0; Decimal igv = 0; Decimal valor = 0;
            String montoBruto, montodescuento, montoigv, montovv, montotal;
            montogratuitas = 0; montoexoneradas = 0; montogravadas = 0; montoinafectas = 0;
            banderagrabada = false; banderaexonerada = false; banderainafecta = false;



            if (NuevaTabla.Rows.Count > 0)
            {
                foreach (DataRow row in NuevaTabla.Rows)
                {
                    if (Convert.ToInt32(row[0]) == codbol)
                    {

                        if (venta.CodEmpresa == Convert.ToInt32(row[25]))
                        {
                            bruto = bruto + Convert.ToDecimal(row[15]);
                            Dscto = Dscto + Convert.ToDecimal(row[12]);
                            valor = valor + Convert.ToDecimal(row[13]);


                            if (Convert.ToString(row[21]) == "21") // gratuitas
                            {
                                montogratuitas = montogratuitas + (Convert.ToDecimal(row[7]) * Convert.ToDecimal(row[6]));
                            }

                            if (Convert.ToString(row[21]) == "10" || Convert.ToString(row[21]) == "11" ||
                                Convert.ToString(row[21]) == "12" || Convert.ToString(row[21]) == "13" ||
                                Convert.ToString(row[21]) == "14" || Convert.ToString(row[21]) == "15" ||
                                Convert.ToString(row[21]) == "16" || Convert.ToString(row[21]) == "17")   // gravadas
                            {
                                montogravadas = montogravadas + (Convert.ToDecimal(row[13])); banderagrabada = true;
                            }

                            if (Convert.ToString(row[21]) == "20") // exoneradas
                            {
                                montoexoneradas = montoexoneradas + (Convert.ToDecimal(row[7]) * Convert.ToDecimal(row[6]) - Convert.ToDecimal(row[12]));
                                banderaexonerada = true;
                            }

                            if (Convert.ToString(row[21]) == "30" || Convert.ToString(row[21]) == "31" ||
                                Convert.ToString(row[21]) == "32" || Convert.ToString(row[21]) == "33" ||
                                Convert.ToString(row[21]) == "34" || Convert.ToString(row[21]) == "35" ||
                                Convert.ToString(row[21]) == "36") // inafectas
                            {
                                montoinafectas = montoinafectas + (Convert.ToDecimal(row[7]) * Convert.ToDecimal(row[6]) - Convert.ToDecimal(row[12]));
                                banderainafecta = true;
                            }
                        }
                    }
                }

                venta.Gratuitas = montogratuitas;
                venta.Exoneradas = montoexoneradas;
                venta.Gravadas = montogravadas;
                venta.Inafectas = montoinafectas;
                if (chkVentaGratuita.Checked) { venta.Tipoventa = 4; }  // venta gratuita
                else if (chkVentaDsctoGlobal.Checked)
                {
                    venta.Tipoventa = 5; // venta con descuento Global
                }
                else if (banderagrabada == true && banderaexonerada == false && banderainafecta == false)
                {
                    venta.Tipoventa = 1;  // venta grabada
                }
                else if (banderagrabada == false && banderaexonerada == true && banderainafecta == false)
                {
                    venta.Tipoventa = 2;  // venta exonerada
                }
                else if (banderagrabada == false && banderaexonerada == false && banderainafecta == true)
                {
                    venta.Tipoventa = 3;  // venta inafecta
                }
                else if (banderagrabada == true && banderaexonerada == true && banderainafecta == false)
                {
                    venta.Tipoventa = 6;  // venta grabada + exonerada
                }
                else if (banderagrabada == true && banderaexonerada == false && banderainafecta == true)
                {
                    venta.Tipoventa = 7;  // venta grabada + inafecta
                }
                montodescuento = String.Format("{0:#,##0.00}", Dscto);
                montoBruto = String.Format("{0:#,##0.00}", bruto);
                montovv = String.Format("{0:#,##0.00}", valor);
                montoigv = String.Format("{0:#,##0.00}", bruto - Dscto - valor);
                montotal = String.Format("{0:#,##0.00}", bruto - Dscto);

                venta.MontoBruto = Convert.ToDouble(montoBruto);
                venta.MontoDscto = Convert.ToDouble(montodescuento);
                venta.Igv = Convert.ToDouble(montoigv);
                venta.Total = Convert.ToDouble(montotal);
            }


            /* foreach (DataRow row in NuevaTabla.Rows)
             {
                 if (Convert.ToInt32(row[0]) == codbol)
                 {
                     //vamos armar la cabecera
                 }
             }*/

        }


        private void CrearTablaTemporal()
        {
            NuevaTabla = new DataTable("TablaDetalle");
            // Columnas
            foreach (DataGridViewColumn column in dgvDetalle.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                NuevaTabla.Columns.Add(dc);
            }

            // Datos de la grilla
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                DataGridViewRow row = dgvDetalle.Rows[i];
                DataRow dr = NuevaTabla.NewRow();
                for (int j = 0; j < dgvDetalle.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                NuevaTabla.Rows.Add(dr);
            }
        }


        private void OrdenarTablaTemporal()
        {
            DataTable t1 = new DataTable();
            t1 = new DataTable("Tabla1");
            foreach (DataGridViewColumn column in dgvDetalle.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                t1.Columns.Add(dc);
            }

            foreach (Int32 cod in ListaEmpresa)
            {
                foreach (DataRow row in NuevaTabla.Rows)
                {
                    if (Convert.ToInt32(row[25]) == cod)
                    {
                        DataRow dr = t1.NewRow();
                        for (Int32 i = 0; i < NuevaTabla.Columns.Count; i++)
                        {
                            dr[i] = row[i];
                        }
                        t1.Rows.Add(dr);
                    }
                }
            }

            NuevaTabla.Clear();
            NuevaTabla = t1;
        }


        private void CreaBoletas(Int32 lista)
        {
            DataTable dt1 = new DataTable();
            Decimal bruto = 0; Decimal Ncantidad = 0; Decimal Nimporte = 0; Decimal valorV = 0;
            item = 1;
            foreach (DataGridViewColumn column in dgvDetalle.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt1.Columns.Add(dc);
            }

            foreach (DataRow row in NuevaTabla.Rows)
            {
                if (Convert.ToInt32(row[25]) == lista)
                {
                    bruto = bruto + Convert.ToDecimal(row[15]);

                    if (bruto <= mdi_Menu.MontoTopeBoleta)
                    {
                        DataRow dr = dt1.NewRow();
                        for (Int32 i = 0; i < NuevaTabla.Columns.Count; i++)
                        {
                            if (i == 0) { dr[i] = item; } else { dr[i] = row[i]; }
                        }
                        dt1.Rows.Add(dr);
                    }
                    else
                    {
                        bruto = bruto - Convert.ToDecimal(row[15]);
                        decimal ValorRestante = mdi_Menu.MontoTopeBoleta - bruto;
                        decimal cantidad = Math.Truncate(ValorRestante / Convert.ToDecimal(row[7]));

                        decimal cantidadRestante = Convert.ToDecimal(row[6]) - cantidad;

                        DataRow dr = dt1.NewRow();
                        valorV = (Convert.ToDecimal(row[13]) / Convert.ToDecimal(row[6]));
                        bruto = bruto + (Convert.ToDecimal(row[7]) * cantidad);
                        for (Int32 j = 0; j < NuevaTabla.Columns.Count; j++)
                        {
                            if (j == 0) { dr[j] = item; }
                            else if (j == 6) { dr[j] = cantidad; }
                            else if (j == 13) { dr[j] = Math.Round((cantidad * valorV), 4); }
                            else if (j == 14) { dr[j] = ((cantidad * Convert.ToDecimal(dr[7])) - Convert.ToDecimal(dr[13])); }
                            else if (j == 15) { dr[j] = (cantidad * Convert.ToDecimal(dr[7])); }
                            else { dr[j] = row[j]; }
                        }
                        item = item + 1;
                        bruto = 0;
                        dt1.Rows.Add(dr);

                        if (cantidadRestante > 0)
                        {
                            DataRow dr1 = dt1.NewRow();
                            bruto = bruto + (cantidadRestante * Convert.ToDecimal(dr[7]));
                            for (Int32 j = 0; j < NuevaTabla.Columns.Count; j++)
                            {
                                if (j == 0) { dr1[j] = item; }
                                else if (j == 6) { dr1[j] = cantidadRestante; }
                                else if (j == 13) { dr1[j] = (cantidadRestante * valorV); }
                                else if (j == 14) { dr1[j] = ((cantidadRestante * Convert.ToDecimal(dr[7])) - Convert.ToDecimal(dr1[13])); }
                                else if (j == 15) { dr1[j] = (cantidadRestante * Convert.ToDecimal(dr[7])); }
                                else { dr1[j] = row[j]; }
                            }
                            dt1.Rows.Add(dr1);
                        }

                        //break;
                    }
                }


            }

            NuevaTabla.Clear();
            NuevaTabla = dt1;
        }
        private void GeneraListaEnpresas()
        {
            Boolean bandera = false;
            ListaEmpresa.Clear();
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                bandera = false;
                if (ListaEmpresa.Count == 0)
                {
                    ListaEmpresa.Add(frmLogin.iCodEmpresa);
                }
                else
                {
                    foreach (Int32 lista in ListaEmpresa)
                    {
                        if (lista ==frmLogin.iCodEmpresa)
                        {
                            bandera = true;
                        }
                    }

                    if (!bandera)
                    {
                        ListaEmpresa.Add(frmLogin.iCodEmpresa);
                    }
                }
            }
        }


        private void ArmaCabecera(Int32 CodigoE)
        {
            /*ser = AdmSerie.CargaSerieEmpresa(frmLogin.iCodAlmacen, doc.CodTipoDocumento);
            venta.CodSerie = ser.CodSerie;
            venta.Serie = ser.Serie;
            venta.NumDoc = ser.Numeracion.ToString().PadLeft(8, '0');*/

            //ser = AdmSerie.CargaSerieEmpresa(frmLogin.iCodAlmacen, doc.CodTipoDocumento);
            venta.CodSerie = CodSerie;
            venta.Serie = txtSerie.Text;
            venta.NumDoc = txtNumero.Text;

            if (chkVentaGratuita.Checked) { 
             venta.Tipoventa = 4; Tipoimpuesto = "21";
            }  // venta gratuita
            else if (chkVentaDsctoGlobal.Checked)
            {
                venta.Tipoventa = 5; Tipoimpuesto = "0";// venta con descuento Global
            }

            detalle.Clear();
            detalle1.Clear();

            Decimal bruto = 0; Decimal Dscto = 0; Decimal igv = 0; Decimal valor = 0;
            String montoBruto, montodescuento, montoigv="0", montovv, montotal="0";
            montogratuitas = 0; montoexoneradas = 0; montogravadas = 0; montoinafectas = 0;
            banderagrabada = false; banderaexonerada = false; banderainafecta = false;
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {

                    if (CodigoE == frmLogin.iCodEmpresa)
                    {
                        if (Tipoimpuesto != "21") { Tipoimpuesto = row.Cells[MiTipoImpuesto.Name].Value.ToString(); }
                        bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                        Dscto = Dscto + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                        valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);


                        if (Tipoimpuesto == "21") // gratuitas
                        {
                            montogratuitas = montogratuitas + (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                        }

                        if (Tipoimpuesto == "10" || Tipoimpuesto == "11" ||
                            Tipoimpuesto == "12" || Tipoimpuesto == "13" ||
                            Tipoimpuesto == "14" || Tipoimpuesto == "15" ||
                            Tipoimpuesto == "16" || Tipoimpuesto == "17")   // gravadas
                        {
                            
                                montogravadas = montogravadas + (Convert.ToDecimal(row.Cells[valorventa.Name].Value)); banderagrabada = true;
                            
                        }

                        if (Tipoimpuesto == "20") // exoneradas
                        {
                            montoexoneradas = montoexoneradas + (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value) - Convert.ToDecimal(row.Cells[montodscto.Name].Value));
                            banderaexonerada = true;
                        }

                        if (Tipoimpuesto == "30" || Tipoimpuesto == "31" ||
                           Tipoimpuesto == "32" || Tipoimpuesto == "33" ||
                            Tipoimpuesto == "34" || Tipoimpuesto == "35" ||
                           Tipoimpuesto == "36") // inafectas
                        {
                            montoinafectas = montoinafectas + (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value) - Convert.ToDecimal(row.Cells[montodscto.Name].Value));
                            banderainafecta = true;
                        }
                    }
                }

                venta.Gratuitas = montogratuitas;
                venta.Exoneradas = montoexoneradas;
                venta.Gravadas = montogravadas;
                venta.Inafectas = montoinafectas;
                //if (chkVentaGratuita.Checked) { venta.Tipoventa = 4; }  // venta gratuita
                //else if (chkVentaDsctoGlobal.Checked)
                //{
                //    venta.Tipoventa = 5; // venta con descuento Global
                //}
                if (banderagrabada == true && banderaexonerada == false && banderainafecta == false)
                {
                    venta.Tipoventa = 1;  // venta grabada
                }
                else if (banderagrabada == false && banderaexonerada == true && banderainafecta == false)
                {
                    venta.Tipoventa = 2;  // venta exonerada
                }
                else if (banderagrabada == false && banderaexonerada == false && banderainafecta == true)
                {
                    venta.Tipoventa = 3;  // venta inafecta
                }
                else if (banderagrabada == true && banderaexonerada == true && banderainafecta == false)
                {
                    venta.Tipoventa = 6;  // venta grabada + exonerada
                }
                else if (banderagrabada == true && banderaexonerada == false && banderainafecta == true)
                {
                    venta.Tipoventa = 7;  // venta grabada + inafecta
                }
                montodescuento = String.Format("{0:#,##0.00}", Dscto);
                montoBruto = String.Format("{0:#,##0.00}", bruto - Dscto);
                montovv = String.Format("{0:#,##0.00}", valor);

                if (Tipoimpuesto != "21" && Tipoimpuesto != "0")
                {
                    montoigv = String.Format("{0:#,##0.00}", bruto - Dscto - valor);
                   
                }

                montotal = String.Format("{0:#,##0.00}", bruto - Dscto);
                venta.MontoBruto = Convert.ToDouble(montoBruto);
                venta.MontoDscto = Convert.ToDouble(montodescuento);
                venta.Igv = Convert.ToDouble(montoigv);
                venta.Total = Convert.ToDouble(montotal);
            }
        }

        private void VerificaSaldoCaja()
        {
            Caja = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, 1, frmLogin.iCodAlmacen, frmLogin.iCodUser);//1 caja ventas
            CodigoCaja = Caja.Codcaja;
        }

        private void ingresarpago()
        {
            //Se quito para enviar el pago directo cuando es contado por defecto efectivo
            frmCancelarPago form = new frmCancelarPago();
            form.CodNota = venta.CodFacturaVenta;
            form.tipo = 3;
            form.tip = 3;
            form.Monto = venta.Total;
            form.venta = venta;
            form.montoPag = 0;
            form.ShowDialog();
            //FIn se quito para enviar el pago directo cuando es contado por defecto efectivo

            /* VerificaSaldoCaja();

             Pag.CodNota = venta.CodFacturaVenta.ToString();
             Pag.CodLetra = 0;
             Pag.CodTipoPago = 5; //metodo de pago
             Pag.CodMoneda = venta.Moneda;
             //Pag.CodCobrador = Convert.ToInt32(cbovendedor.SelectedValue); //Cobrador
             Pag.CodCobrador = Convert.ToInt32(frmLogin.iCodUser);
             Pag.Tipo = true;// total o parcial
             Pag.IngresoEgreso = true;//ingreso
             Pag.TipoCambio = Convert.ToDecimal(venta.TipoCambio);
             Pag.MontoPagado = Convert.ToDecimal(venta.Total);
             Pag.MontoCobrado = Convert.ToDecimal(venta.Total);
             Pag.Vuelto = 0;
             Pag.codCtaCte = 0;
             Pag.CtaCte = "";
             Pag.NOperacion = "";
             Pag.NCheque = "";
             Pag.FechaPago = venta.FechaPago.Date;
             Pag.Observacion = "";
             Pag.CodUser = frmLogin.iCodUser;
             Pag.CodAlmacen = frmLogin.iCodAlmacen;
             //Pag.CodSerie = CodSerie;
             Pag.CodSucursal = frmLogin.iCodSucursal;
             Pag.CodDoc = 18;
             Pag.Serie = "";
             Pag.NumDoc = "";
             Pag.Referencia = "";
             Pag.Codcaja = CodigoCaja; 
             Pag.CodBanco = 0;
             Pag.CodTarjeta = 0;
             Pag.Aprobado = 4;
             //montoPag = 1;
             if (AdmPagos.insert(Pag))
             {
                 xgenerar = true;
                 fnImprimir();
                 //Reiniciar Formulario
                 //nuevaVenta();
                 this.Close();
             }*/
        }

        private void nuevaVenta()
        {
            frmVenta form = new frmVenta();
            form.MdiParent = this.MdiParent;
            form.Proceso = 1;
            form.Show();
            this.Close();
            
        }

        private void RecorreDetalle()
        {
            detalle.Clear();
            detalle1.Clear();

            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle(row);
                }
            }
            //nota.Detalle = detalle;
        }
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleFacturaVenta deta = new clsDetalleFacturaVenta();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodVenta = Convert.ToInt32(venta.CodFacturaVenta);
            deta.CodAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            //deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            //deta.Subtotal = Convert.ToDouble(fila.Cells[valorventa.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            //  deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            deta.CantidadPendiente = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            deta.Entregado = rbtnPendiente.Checked;
            deta.CodDetalleSeparacion = CodSeparacion;
            if (Procede == 3)//cotizacion
            {
                deta.CodDetalleCotizacion = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            }
            else// venta 
            {
                deta.CodDetalleCotizacion = 0;
            }
            
            if (Procede == 4)//pedido
            {
                deta.CodDetallePedido = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            }
            else// venta
            {
                deta.CodDetallePedido = 0;
            }
            detalle1.Add(deta);
        }

        private void RecorreDetalleGuia()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalleguia(row);
                }
            }
            //nota.Detalle = detalle;
        }
        private void añadedetalleguia(DataGridViewRow fila)
        {
            clsDetalleGuiaRemision deta = new clsDetalleGuiaRemision();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodGuiaRemision = Convert.ToInt32(guia.CodGuiaRemision);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            if (Convert.ToBoolean(guia.Facturado)) { deta.CantidadPendiente = 0; deta.Pendiente = false; } else { deta.CantidadPendiente = deta.Cantidad; deta.Pendiente = true; }
            deta.CodUser = frmLogin.iCodUser;
            detalleg.Add(deta);
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            //VerificarCabecera();
            //if (Validacion && Proceso == 1)
            //{
            //    btnDetalle.Enabled = true;
            //}
        }

        private void txtAutorizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmAutorizado"] != null)
                {
                    Application.OpenForms["frmAutorizado"].Activate();
                }
                else
                {
                    frmAutorizado form = new frmAutorizado();
                    form.Proceso = 3;                   
                    form.ShowDialog();
                    aut = form.aut;
                    CodAutorizado = aut.CodAutorizado;
                    if (CodAutorizado != 0) { CargaAutorizado(); ProcessTabKey(true); }
                }
            }
        }

        private void CargaAutorizado()
        {
            aut = AdmAut.MuestraAutorizado(CodAutorizado);
            txtAutorizacion.Text = aut.CodAutorizado.ToString();
                       
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmSerie"] != null)
                {
                    Application.OpenForms["frmSerie"].Activate();
                }
                else
                {
                    frmSerie form = new frmSerie();
                    form.Proceso = 3;
                    form.DocSeleccionado = CodDocumento;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                    manual=Convert.ToInt32(ser.PreImpreso);
                    if (CodSerie != 0)
                    {
                        txtSerie.Text = ser.Serie;                        
                        //if (Procede != 4) txtNumero.Text = ser.Numeracion.ToString();
                        //else txtNumero.Text = numSerie;
                    }
                    if (CodSerie != 0) { ProcessTabKey(true); }
                }
            }
        }

       
        private void txtCodDocumento_TextChanged(object sender, EventArgs e)
        {   
            txtSerie.Text = "";
            txtNumero.Text = "";
            CodSerie = 0;           
        }

        private void txtComentario_Leave(object sender, EventArgs e)
        {
            //VerificarCabecera();
        }

        public void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
                if (cli.CliEspecial == false)
                {
                    if (fpago.Dias > forma.Dias)
                    {
                        DialogResult result =
                            MessageBox.Show("Esta forma de pago excede a la Forma de Pago del Cliente" + Environment.NewLine +
                                            "Máx.FormaPago del Cliente = " + forma.Descripcion, "Facturación Venta",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            cmbFormaPago.SelectedValue = forma.CodFormaPago;
                            //cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, eeee);
                        }
                    }
                }
                else
                {
                    DialogResult result =
                           MessageBox.Show("Desea cambiar la forma de pago  del Cliente ?", "Facturación Venta",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        //Ver que hacer
                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }

            
        }      

        private void txtPDescuento_TextChanged(object sender, EventArgs e)
        {
            calculadescuentogeneral();
        }

        private void txtPDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                calculadescuentogeneral();             
            }            
        }

        private void calculadescuentogeneral()
        {
           
        }

        public void fnImprimir()
        {            
            try
            {
               
                if (venta.CodTipoDocumento == 7 || venta.CodTipoDocumento == 26) //antes era 7
                {

                    frmRptFactura form = new frmRptFactura();
                    CRReporteNotaVenta rpt = new CRReporteNotaVenta();
                    DataSet jes = new DataSet();
                    rpt.Load("CRReporteNotaVenta.rpt");

                    jes = ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta));

                   
                    rpt.SetDataSource(jes);
                    form.crvReporteFactura.ReportSource = rpt;
                    form.ShowDialog();
                    //rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaArch.Replace(".xml", ".pdf"));

                    rpt.Close();
                    rpt.Dispose();
                    /* frmRptFactura frm = new frmRptFactura();
                     CRFacturaXXX rpt = new CRFacturaXXX();
                     rpt.Load("CRFacturaXXX.rpt");                    

                     rpt.SetDataSource(ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta)));
                     //CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                     //rptoption.PrinterName = ser.NombreImpresora;
                     //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                     //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(50, 0, 0, 0));
                     //rpt.PrintToPrinter(1, false, 1, 1);
                     //rpt.Close();
                     //rpt.Dispose();
                     frm.crvReporteFactura.ReportSource = rpt;
                     frm.ShowDialog();  */
                }
                else { btnImprimir_Click(new object(), new EventArgs());}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void btnImprimir_Click(object sender, EventArgs e)
        {           
            try
            {

                if (venta.CodTipoDocumento == 7 || venta.CodTipoDocumento == 26) { fnImprimir(); }
                else
                {
                    DataSet jes = new DataSet();
                    frmRptFactura frm = new frmRptFactura();
                    CRFacturaFomatoContinuo rpt = new CRFacturaFomatoContinuo();

                    rpt.Load("CRNotaCreditoVenta.rpt");
                    jes = ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta));

                    String nombrearchivo = "";

                    venta = AdmVenta.BuscaFacturaVenta(Convert.ToInt32(venta.CodFacturaVenta), frmLogin.iCodAlmacen);
                    if (venta.CodTipoDocumento == 1)
                    {
                        nombrearchivo = frmLogin.RUC + "-03-B" + venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                        Process.Start(@"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\BOLETAS\\"+ nombrearchivo+".pdf");
                    }
                    else if (venta.CodTipoDocumento == 2)
                    {
                        nombrearchivo = frmLogin.RUC + "-01-F" + venta.Serie + "-" + venta.NumDoc.PadLeft(8, '0');
                        Process.Start(@"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\FACTURAS\\" + nombrearchivo + ".pdf");
                    }

                    firmadigital = CargarImagen(@"C:\DOCUMENTOS-" + frmLogin.RUC + "\\CERTIFIK\\QR\\" + nombrearchivo + ".jpeg");

                    foreach (DataTable mel in jes.Tables)
                    {
                        foreach (DataRow changesRow in mel.Rows)
                        {
                            changesRow["firma"] = firmadigital;
                        }

                        if (mel.HasErrors)
                        {
                            foreach (DataRow changesRow in mel.Rows)
                            {
                                if ((int)changesRow["Item", DataRowVersion.Current] > 100)
                                {
                                    changesRow.RejectChanges();
                                    changesRow.ClearErrors();
                                }
                            }
                        }
                    }

                   
                    //UTILIZADO PARA IMPRIMIR EN TICKETERA
                    /*rpt.SetDataSource(jes);
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);

                    rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(50, 0, 0, 0));
                    rpt.PrintToPrinter(1, false, 1, 1);
                    rpt.Close();
                    rpt.Dispose();*/
                }              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        public static Byte[] CargarImagen(string rutaArchivo)
        {
            if (rutaArchivo != "")
            {
                try
                {
                    FileStream Archivo = new FileStream(rutaArchivo, FileMode.Open);//Creo el archivo
                    BinaryReader binRead = new BinaryReader(Archivo);//Cargo el Archivo en modo binario
                    Byte[] imagenEnBytes = new Byte[(Int64)Archivo.Length]; //Creo un Array de Bytes donde guardare la imagen
                    binRead.Read(imagenEnBytes, 0, (int)Archivo.Length);//Cargo la imagen en el array de Bytes
                    binRead.Close();
                    Archivo.Close();
                    return imagenEnBytes;//Devuelvo la imagen convertida en un array de bytes
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return new Byte[0];
                }
            }
            return new byte[0];
        }

        private void printaRecibo(string CodPago)
        {
            try
            {
                /* MUESTRO LA FACTURA PARA IMPRIMIRLA */
                CRImpresionPago rpt = new CRImpresionPago();
                frmRptImpresionPago frm = new frmRptImpresionPago();
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza"); 
                rpt.SetDataSource(dsf.ReporteImpresionPago(Convert.ToInt32(CodPago), frmLogin.iCodAlmacen));
                frm.cRVImpresionPago.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        clsTipoDocumento doc2 = new clsTipoDocumento();
        clsSerie seri2 = new clsSerie();
        private String siglaPago, seriePago, numeroPago;
        private Int32 codDocumentoPago = 0;
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

        private void printaFactura()
        {
            try
            {
                if (frmLogin.iCodAlmacen != 0)
                {
                    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    CRFacturaFomatoContinuo rpt = new CRFacturaFomatoContinuo();
                    rd.Load("CRFacturaFomatoContinuo.rpt");
                    rd.SetDataSource(ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta)));
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza");           

                    rd.PrintToPrinter(1, false, 1, 1);
                    if (AdmVenta.ActualizaEstadoImpreso(Convert.ToInt32(venta.CodFacturaVenta)))
                    {
                        rpta = true;
                    }
                    else
                    {
                        rpta = false;
                    }
                    rd.Close();
                    rd.Dispose();
                }
                //else
                //{
                //    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                //    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    CRReporteFactura rpt = new CRReporteFactura();
                //    rd.Load("CRReporteFactura.rpt");
                //    rd.SetDataSource(ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta)));
                //    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                //    rptoption.PrinterName = ser.NombreImpresora;
                //    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza");           

                //    rd.PrintToPrinter(1, false, 1, 1);
                //    if (AdmVenta.ActualizaEstadoImpreso(Convert.ToInt32(venta.CodFacturaVenta)))
                //    {
                //        rpta = true;
                //    }
                //    else
                //    {
                //        rpta = false;
                //    }
                //    rd.Close();
                //    rd.Dispose();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printaBoleta()
        {
            try
            {

                if (ser.CodDocumento == 26) 
                {
                    /*DataSet jes = new DataSet();
                    frmRptFactura frm = new frmRptFactura();
                    CRFacturaXXX rpt = new CRFacturaXXX();
                    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                    rpt.Load("CRFacturaXXX.rpt");
                    jes = ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta));
                    rpt.SetDataSource(jes);
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                    rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(50, 0, 0, 0));
                    rpt.PrintToPrinter(1, false, 1, 1);
                    rpt.Close();
                    rpt.Dispose();*/

                    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    CRFacturaFomatoContinuo rpt = new CRFacturaFomatoContinuo();
                    rd.Load("CRFacturaFomatoContinuo.rpt");
                    rd.SetDataSource(ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta)));
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza");           
                    rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(50, 0, 0, 0));
                    rd.PrintToPrinter(1, false, 1, 1);
                    rd.Close();
                    rd.Dispose();


                }
                else if (ser.CodDocumento == 1)
                {
                    ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //CRBoleta rpt = new CRBoleta();
                    //rd.Load("CRBoleta.rpt");
                    CRFacturaFomatoContinuo rpt = new CRFacturaFomatoContinuo();
                    rd.Load("CRFacturaFomatoContinuo.rpt");
                    rd.SetDataSource(ds.ReporteFactura2(Convert.ToInt32(venta.CodFacturaVenta)));
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza");           
                    rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(50, 0, 0, 0));
                    rd.PrintToPrinter(1, false, 1, 1);
                    if (AdmVenta.ActualizaEstadoImpreso(Convert.ToInt32(venta.CodFacturaVenta)))
                    {
                        rpta = true;
                    }
                    else
                    {
                        rpta = false;
                    }
                    rd.Close();
                    rd.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema " + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ActualizaCorrelativos(int CodSerie, string txtSeries, string txtNumeros, string CodVenta)
        {
            try
            {
                if (AdmVenta.actualizaFactura_venta(CodSerie, txtSeries, txtNumeros, CodVenta))
                {
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

        

       /* private Boolean BuscaGuia()
        {
            guia = AdmGuia.BuscaGuiaRemision(txtGuias.Text, frmLogin.iCodAlmacen);            
            if (guia != null)
            {
                CodGuia = Convert.ToInt32(guia.CodGuiaRemision);
                return true;
            }
            else
            {
                CodGuia = 0;
                return false;
            }
        }

        private void CargaGuia()
        {
            try
            {
                guia = AdmGuia.CargaGuiaRemision(Convert.ToInt32(CodGuia));
                if (guia != null)
                {
                    txtGuias.Text = guia.CodGuiaRemision;
                    

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = guia.CodCliente;

                        if (txtCodCliente.Enabled)
                        {
                            CodCliente = guia.CodCliente;
                            cli = AdmCli.MuestraCliente(CodCliente);
                            txtCodCliente.Text = cli.CodigoPersonalizado;
                            if (cli.Ruc != "")
                            {
                                txtDocRef.Text = "FT";
                                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                                txtTransaccion_KeyPress(txtDocRef, ee);
                                
                                txtTransaccion_KeyPress(txtDocRef, ee);
                            }
                            else
                            {
                                txtDocRef.Text = "BV";
                                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                                txtTransaccion_KeyPress(txtDocRef, ee);
                              
                                txtTransaccion_KeyPress(txtDocRef, ee);
                            }

                            txtNombreCliente.Text = cli.RazonSocial;
                            
                            if (cli.CodListaPrecio != 0)
                            {
                                EventArgs ee = new EventArgs();
                                cbListaPrecios_SelectionChangeCommitted(cbListaPrecios, ee);
                            }
                            else
                            {
                                CodLista = 0;
                            }

                           
                            if (cli.FormaPago != 0)
                            {
                                EventArgs ee = new EventArgs();
                                cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);
                            }
                            else
                            {
                                dtpFechaPago.Value = DateTime.Today;
                            }

                            txtPDescuento.Text = cli.Descuento.ToString();

                        }   
                    }
                    //dtpFecha.Value = guia.FechaEmision;                  
                    txtComentario.Text = guia.Comentario;

                    CargaDetalleGuia();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
 
        }*/

        public void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            frmVenta form2 = new frmVenta();
            form2.MdiParent = this.MdiParent;
            form2.consultorext = consultorext;
            form2.Proceso = 1;
            form2.Show();
            this.Close();
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Procede == 1)
            {
                if (Proceso == 1)
                {
                    if (txtPDescuento.Text != "")
                    {
                        calculatotales();
                        calculadescuentogeneral();
                    }
                    else
                    {
                        calculatotales();
                    }

                    if (dgvDetalle.RowCount > 0)
                    {
                        int Indice = 0;
                        Indice = dgvDetalle.RowCount - 1;

                        if (cmbMoneda.SelectedIndex == 0)
                        {
                            if (TipoCambio != 0)
                            {
                                dgvDetalle[8, Indice].Value = Convert.ToDecimal(dgvDetalle[8, Indice].Value)*TipoCambio;
                                dgvDetalle[9, Indice].Value = Convert.ToDecimal(dgvDetalle[9, Indice].Value)*TipoCambio;
                                dgvDetalle[13, Indice].Value = Convert.ToDecimal(dgvDetalle[13, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[14, Indice].Value = Convert.ToDecimal(dgvDetalle[14, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[15, Indice].Value = Convert.ToDecimal(dgvDetalle[15, Indice].Value)*
                                                               TipoCambio;
                                dgvDetalle[16, Indice].Value = Convert.ToDecimal(dgvDetalle[16, Indice].Value)*
                                                               TipoCambio;
                            }
                        }
                        else if (cmbMoneda.SelectedIndex == 1)
                        {
                        }
                    }
                }
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Procede == 1 || Procede == 2)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
                {
                    if (Proceso == 1 || Proceso == 2)
                    {
                        if (txtPDescuento.Text != "")
                        {
                            calculatotales();
                            calculadescuentogeneral();
                        }
                        else
                        {
                            calculatotales();
                        }
                    }
                }
            }
        }  

     

    

        private void cmbMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvDetalle.RowCount > 0)
            {
                VentaEnMoneda();
            }
            calculatotales();
            mon = Convert.ToInt32(cmbMoneda.SelectedValue);
            calculatotales();
            txtComentario.Focus();
        }

        private void txtGuias_KeyDown(object sender, KeyEventArgs e)
        {
          
           
        }

        

        public void txtCotizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCotizacion.Text != "")
                {
                    if (BuscaCotizacion())
                    {
                        CargaCotizacion();
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Cotizacion no existe o ya no esta vigente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ext.limpiar(this.Controls);
                        cargaAlmacenes();
                    }
                }
            }
        }

        private Boolean BuscaCotizacion()
        {
            coti = AdmCoti.BuscaCotizacion(txtCotizacion.Text, frmLogin.iCodAlmacen);
            if (coti != null)
            {
                codCotizacion = Convert.ToInt32(coti.CodCotizacion);
                return true;
            }
            else
            {
                codCotizacion = 0;
                return false;
            }

        }

        private void CargaCotizacion()
        {
            try
            {
                coti = AdmCoti.CargaCotizacion(Convert.ToInt32(codCotizacion), frmLogin.iCodAlmacen);
                if (coti != null)
                {
                    txtCotizacion.Text = coti.CodCotizacion;
                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = coti.CodCliente;
                        CargaCliente();
                        //
                        if (ret == 0)
                        {
                           
                                txtCodigoCli.Text = coti.CodCliente.ToString();
                                txtCodCliente.Text = coti.CodigoPersonalizado;
                                txtNombreCliente.Text = coti.Nombre;
                                txtDireccionCliente.Text = coti.Direccion;                            
                                txtLineaCredito.Text = cli.LineaCredito.ToString();
                                txtLineaCreditoDisponible.Text = cli.LineaCreditoDisponible.ToString();
                                txtLineaCreditoUso.Text = cli.LineaCreditoUsado.ToString();

                            
                            if (coti.RUCCliente != "")// hay que automatizar esto dependiendo de la sucursal la serie varia por sucursal
                            {
                                txtDocRef.Text = "FT";
                                KeyPressEventArgs ee = new KeyPressEventArgs((char) Keys.Return);
                                txtDocRef_KeyPress(txtDocRef, ee);
                               // txtSerie.Text = "001";
                                txtSerie_KeyPress(txtDocRef, ee);
                            }
                            else
                            {
                                txtDocRef.Text = "BV";
                                KeyPressEventArgs ee = new KeyPressEventArgs((char) Keys.Return);
                                txtDocRef_KeyPress(txtDocRef, ee);
                               // txtSerie.Text = "001";
                                txtSerie_KeyPress(txtDocRef, ee);
                            }
                          
                            cmbMoneda.SelectedValue = coti.Moneda;
                            txtTipoCambio.Text = coti.TipoCambio.ToString();
                            
                            txtComentario.Text = coti.Comentario;
                            txtBruto.Text = String.Format("{0:#,##0.00}", coti.MontoBruto);
                            txtDscto.Text = String.Format("{0:#,##0.00}", coti.MontoDscto);
                            txtValorVenta.Text = String.Format("{0:#,##0.00}", coti.Total - coti.Igv);
                            txtIGV.Text = String.Format("{0:#,##0.00}", coti.Igv);
                            txtPrecioVenta.Text = String.Format("{0:#,##0.00}", coti.Total);
                            CargaDetalleCotizacion();
                            BloquearEdicion(true);
                        }
                    }
                   
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void txtCotizacion_Leave(object sender, EventArgs e)
        {
            //VerificarCabecera();
        }

        public void txtGuias_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == (char)Keys.Return)
            {
                if (txtGuias.Text != "")
                {
                    if (BuscaGuia())
                    {
                        CargaGuia();
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Pedido no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }*/
        }

        
        public List<Int32> carga_Correlativos()
        {
            Int32 j = 0;
            datos = AdmVenta.ListaFacturaVenta(frmLogin.iCodAlmacen);
            ser = Admser.MuestraSerie(8, frmLogin.iCodAlmacen);
            correlativo.Clear();
            for (int i = ser.Inicio; i < ser.Numeracion; i++)
            {
                if(j< datos.Rows.Count)
                {
                    if(i == Convert.ToInt32(datos.Rows[j]["numDocumento"]))
                    {
                        j++;
                        fecha1 = Convert.ToDateTime(datos.Rows[j-1]["fechasalida"]);
                    }
                    
                    else
                    {
                        correlativo.Add(i);
                        fecha2 = Convert.ToDateTime(datos.Rows[j]["fechasalida"]);
                    }
                    
                }
            }
            return correlativo;
        }

        private Boolean rpta;

        public Boolean valida_existente(Int32 serie)
        {
            datos = AdmVenta.ListaFacturaVenta(frmLogin.iCodAlmacen);
            for (Int32 j = 0; j < datos.Rows.Count; j++)
            {
                if (serie == Convert.ToInt32(datos.Rows[j]["numDocumento"]))
                {
                    rpta = false;
                }
                else rpta = true;
            }
            return rpta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFacturasManuales frm = new frmFacturasManuales();
            carga_Correlativos();
            frm.num_correlativo = carga_Correlativos();
            frm.ShowDialog();
        }

       

        private void cmbAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbAlmacen.Enabled = false;
            btnNuevo.Focus();
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            cmbAlmacen_SelectionChangeCommitted(sender, e);
        }

        private void ckbguia_CheckedChanged(object sender, EventArgs e)
        {
           /* if (ckbguia.Checked == true) groupBox5.Visible = true;
            else groupBox5.Visible = false;*/
        }

        private void txtRazonSocialTransporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmEmpresaTransporte"] != null)
                {
                    Application.OpenForms["frmEmpresaTransporte"].Activate();
                }
                else
                {
                    frmEmpresaTransporte form = new frmEmpresaTransporte();
                    form.Proceso = 3;
                    form.ShowDialog();
                    empT = form.emp;
                    CodEmpresaTransporte = empT.CodEmpresaTranporte;
                    if (CodEmpresaTransporte != 0) { CargaEmpresaTransporte(); ProcessTabKey(true); }
                }
            }
        }

        private void CargaEmpresaTransporte()
        {
          /*  empT = AdmET.MuestraEmpresaTranporte(empT.CodEmpresaTranporte);
            if (empT != null)
            {
                txtRazonSocialTransporte.Text = empT.RazonSocial;
            }
            else
            {
                txtRazonSocialTransporte.Text = "";
            }*/
        }

       private void txtSerieG_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.F1)
           {
               if (Application.OpenForms["frmSerie"] != null)
               {
                   Application.OpenForms["frmSerie"].Activate();
               }
               else
               {
                   frmSerie form = new frmSerie();
                   form.DocSeleccionado = 11;
                   //form.Sigla = doc.Sigla;
                   form.Proceso = 3;
                   form.ShowDialog();
                   ser = form.ser;
                   CodSerieG = ser.CodSerie;
                   numG = ser.Numeracion;
                   if (CodSerieG != 0)
                   {
                       if (ser.PreImpreso)
                       {
                           CodSerieG = ser.CodSerie;
                           /*txtSerieG.Text = ser.Serie;
                           txtcodserie.Text = ser.CodSerie.ToString();
                           txtNumeroG.Visible = true;
                           txtNumeroG.Enabled = true;
                           txtNumeroG.Text = "";*/
                       }
                       else
                       {
                           CodSerieG = ser.CodSerie;
                           //txtSerieG.Text = ser.Serie;
                           //txtcodserie.Text = ser.CodSerie.ToString();
                           //txtNumeroG.Visible = false;
                       }

                   }
                   if (CodSerieG != 0) { ProcessTabKey(true); }
               }
           }
       }

       public Boolean VerificarDetracciones()
       {
           Boolean grav = false;
           Decimal sumadet = 0;
           if (CodDocumento == 2)
           {
               if (dgvDetalle.Rows.Count > 0)
               {
                   foreach (DataGridViewRow row in dgvDetalle.Rows)
                   {
                       if (Convert.ToDecimal(row.Cells[igv.Name].Value) != 0)
                       {
                           grav = true;
                       }
                       else
                       {
                           if (Convert.ToDecimal(row.Cells[precioventa.Name].Value) == 0)
                           {
                               grav = true;
                           }
                           else
                           {
                               sumadet = sumadet + Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                           }
                       }
                   }
               }
               if (sumadet <= 700)
               {
                   return true;
               }
               else
               {
                   if (grav)
                   {
                       MessageBox.Show("Operacion no permitida, por estar afecta a detracción!", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       return false;
                   }
                   else
                   {
                       return true;
                   }
               }
           }
           else
           {
               return true;
           }
       }

       protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
       {

           if (keyData == (Keys.Control | Keys.G))
           {
               btnGuardar.PerformClick();
               return true;
           }
           else
           {
               return false;
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
           if (Proceso != 0 && e.ControlToValidate.Visible)
               if (e.ControlToValidate.Text != "")
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           /*ComboBox c = (ComboBox)e.ControlToValidate;
           if (txtRazonSocialTransporte.Text == "")
               if (c.Enabled)
                   if (Proceso != 0 && c.Visible)
                       if (c.SelectedIndex != -1)
                           e.IsValid = true;
                       else
                           e.IsValid = false;
                   else
                       e.IsValid = true;
               else
                   e.IsValid = true;
           else e.IsValid = true;*/
       }

       private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           /*ComboBox c = (ComboBox)e.ControlToValidate;
           if (txtRazonSocialTransporte.Text == "")
               if (c.Enabled)
                   if (Proceso != 0 && c.Visible)
                       if (c.SelectedIndex != -1)
                           e.IsValid = true;
                       else
                           e.IsValid = false;
                   else
                       e.IsValid = true;
               else
                   e.IsValid = true;
           else e.IsValid = true;*/
       }

       private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0)
               if (dgvDetalle.Rows.Count > 0)
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0)
               if (e.ControlToValidate.Text != "")
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void customValidator7_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

       private void customValidator8_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           ComboBox c = (ComboBox)e.ControlToValidate;
           if (c.Enabled)
               if (Proceso != 0)
                   if (c.SelectedIndex != -1)
                       e.IsValid = true;
                   else
                       e.IsValid = true;
               else
                   e.IsValid = true;
           else
               e.IsValid = true;
       }

       private void customValidator9_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0 && e.ControlToValidate.Visible)
               if (e.ControlToValidate.Text != "")
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void customValidator10_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0 && e.ControlToValidate.Visible)
               if (e.ControlToValidate.Text != "")
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void customValidator11_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0 && e.ControlToValidate.Visible)
               if (e.ControlToValidate.Text != "")
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void txtNumero_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               cmbFormaPago.Focus();
           }
       }

       private void cmbFormaPago_KeyDown(object sender, KeyEventArgs e)
       {
       }

       private void cbListaPrecios_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               cbovendedor.Focus();
           }
       }

       private void cbovendedor_SelectionChangeCommitted(object sender, EventArgs e)
       {
           dtpFecha.Focus();
       }

       private void cbovendedor_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               dtpFecha.Focus();
           }
       }

       private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               cmbMoneda.Focus();
           }
       }

       private void cmbMoneda_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               txtComentario.Focus();
           }
       }

       private void txtComentario_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               cmbAlmacen.Focus();
           }
       }

       private void cmbAlmacen_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               btnNuevo.Focus();
           }
       }

       private void checkBox1_CheckedChanged(object sender, EventArgs e)
       {
           if (checkBox1.Checked == true)
           {
               checkBox1.Text = "ConsultorExterno";

           }
           else
           {
               checkBox1.Text = "Venta Normal";
           }
       }

       

       public void txtcodpedido_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (e.KeyChar == (char)Keys.Return)
           {
               if (txtcodpedido.Text != "")
               {
                   //if (BuscaPedido())
                   //{
                   //    if (pedido.Pendiente == 1)
                   //    {
                   //        CargaPedido();
                   //        btnGuardar.Focus();
                   //    }
                   //    else
                   //    {
                   //        MessageBox.Show("Pedido ya esta facturado, ingresar datos correctamente!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   //        LimpiarPedido();
                   //    }
                   //}
                   //else
                   //{
                   //    MessageBox.Show("Pedido no existe, ingresar datos correctamente!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   //    // LimpiarPedido();
                   //}
                   if (Procede == 4)
                   {
                       if (BuscaPedido())
                       {
                           if (pedido.Pendiente == 1)
                           {
                               CargaPedido();
                               btnGuardar.Focus();
                           }
                           else
                           {
                               MessageBox.Show("Pedido ya esta facturado, ingresar datos correctamente!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               LimpiarPedido();
                           }
                       }
                       else
                       {
                           MessageBox.Show("Pedido no existe, ingresar datos correctamente!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           // LimpiarPedido();
                       }
                   }
                   else if (Procede == 7)
                   {
                       if (BuscarSeparacion())
                       {
                           if (separacion.Pendiente == 0)
                           {
                               CargaSeparacion();
                               btnGuardar.Focus();
                           }
                           else
                           {
                               MessageBox.Show("Todavia no se Cancela!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               LimpiarPedido();
                           }
                       }
                       else
                       {
                           MessageBox.Show("no existe, ingresar datos correctamente!", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                   }
               }
           }
       }

       private void CargaSeparacion()
       {
           try
           {
               separacion = Admsepa.BuscarSeparacion(CodSeparacion, frmLogin.iCodAlmacen);
               if (separacion != null)
               {
                   if (txtCodCliente.Enabled)
                   {
                       CodCliente = separacion.CodCliente;
                       if (CodCliente > 0)
                       {
                           CargaCliente();
                       }

                       //dtpFecha.Value = Convert.ToDateTime(separacion.FechaPedido);
                       cmbMoneda.SelectedValue = separacion.Moneda;
                       txtCodigoCli.Text = separacion.CodCliente.ToString();
                       txtTipoCambio.Text = separacion.TipoCambio.ToString();

                       txtComentario.Text = separacion.Comentario;
                       txtBruto.Text = String.Format("{0:#,##0.00}", separacion.Bruto);
                       txtDscto.Text = String.Format("{0:#,##0.00}", separacion.MontoDescuento);
                       txtValorVenta.Text = String.Format("{0:#,##0.00}", separacion.Total - separacion.Igv);
                       txtIGV.Text = String.Format("{0:#,##0.00}", separacion.Igv);
                       txtPrecioVenta.Text = String.Format("{0:#,##0.00}", separacion.Total);
                       CargaDetalleSeparacion();
                       btnGuardar.Focus();
                   }
               }
           }
           catch (Exception ex)
           {
           }
       }

       private void CargaDetalleSeparacion()
       {
           try
           {
               DataTable newDataDetalle = new DataTable();
               dgvDetalle.Rows.Clear();
               newDataDetalle = Admsepa.CargaDetalle(Convert.ToInt32(separacion.CodSeparacion));
               foreach (DataRow row in newDataDetalle.Rows)
               {
                   dgvDetalle.Rows.Add(row[0].ToString(), "0", row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                       row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(),
                       row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(),
                       row[15].ToString(), row[16].ToString(), row[18].ToString(), row[17].ToString(),
                       "0", "0", row[22].ToString(), DateTime.Now);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       clsAdmSeparacion Admsepa = new clsAdmSeparacion();

       private bool BuscarSeparacion()
       {
           separacion = Admsepa.BuscarSeparacionXid(Convert.ToInt32(txtcodpedido.Text), frmLogin.iCodAlmacen);
           if (separacion != null)
           {
               CodSeparacion = Convert.ToInt32(separacion.CodSeparacion);
               return true;
           }
           else
           {
               CodSeparacion = 0;
               return false;
           }
       }
       
       private bool BuscaPedido()
       {
            pedido = Admped.BuscaPedido(txtcodpedido.Text, frmLogin.iCodAlmacen);
            
            if (pedido != null)
            {
                CodPedido = Convert.ToInt32(pedido.CodPedido);
                return true;
            }
            else
            {
                CodPedido = 0;
                return false;
            }        
       }

       private void CargaPedido()
       {
           try
           {
               pedido = Admped.CargaPedido(Convert.ToInt32(CodPedido));
               if (pedido != null)
               {
                   //txtcodpedido.Text = Convert.ToInt32(pedido.CodPedido).ToString();
                   if (txtCodCliente.Enabled)
                   {
                       CodCliente = pedido.CodCliente;
                       if (CodCliente > 0) 
                       {
                           CargaCliente();
                       }
                       /*txtCodCliente.Text = pedido.CodigoPersonalizado;
                       if (pedido.CodTipoDocumento == 1)
                       {
                           txtNombreCliente.Text = pedido.Nombre;
                       }
                       else
                       {
                           txtCodCliente.Text = pedido.RUCCliente;                           
                           txtNombreCliente.Text = pedido.RazonSocialCliente;
                       }
                       txtDireccionCliente.Text = pedido.Direccion;
                       btnGuardar.Enabled = true;*/
                   }
                   dtpFecha.Value = pedido.FechaPedido;
                   //CargaMoneda();
                   cmbMoneda.SelectedValue = pedido.Moneda;
                   txtCodigoCli.Text = pedido.CodCliente.ToString();
                   txtTipoCambio.Text = pedido.TipoCambio.ToString();

                   if (txtAutorizacion.Enabled)
                   {
                       txtAutorizacion.Text = pedido.CodAutorizado.ToString();
                      
                   }
                   if (txtDocRef.Enabled)
                   {
                       txtDocRef.Focus();                       
                   }
                   txtComentario.Text = pedido.Comentario;
                   txtBruto.Text = String.Format("{0:#,##0.00}", pedido.MontoBruto);
                   txtDscto.Text = String.Format("{0:#,##0.00}", pedido.MontoDscto);
                   txtValorVenta.Text = String.Format("{0:#,##0.00}", pedido.Total - pedido.Igv);
                   txtIGV.Text = String.Format("{0:#,##0.00}", pedido.Igv);
                   txtPrecioVenta.Text = String.Format("{0:#,##0.00}", pedido.Total);
                   CargaDetallePedido();
                   btnGuardar.Focus();
               }
               else
               {
                   MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void CargaDetallePedido()
       {
           //DgvDetalle.DataSource = Admped.CargaDetalle(Convert.ToInt32(pedido.CodPedido));
           try
           {
               DataTable newDataDetalle = new DataTable();
               dgvDetalle.Rows.Clear();
               newDataDetalle = Admped.CargaDetalle(Convert.ToInt32(pedido.CodPedido));
               foreach (DataRow row in newDataDetalle.Rows)
               {
                   dgvDetalle.Rows.Add(row[0].ToString(), "0", row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                       row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(),
                       row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(),
                       row[15].ToString(), row[16].ToString(), row[18].ToString(), row[17].ToString(),
                       "0", "0", row[22].ToString(), DateTime.Now);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }


       public void LimpiarPedido()
       {
           if (dgvDetalle.RowCount > 0)
           {
               DataTable dt1 = (DataTable)dgvDetalle.DataSource;
               dt1.Clear();
           }
           txtCodCliente.Text = "";
           CodCliente = 0;
           CodPedido = 0;
           txtNombreCliente.Text = "";
           txtTransaccion.Text = "";
           txtDocRef.Text = "";
           txtSerie.Text = "";
           txtNumero.Text = "";
           txtcodpedido.Text = "";
           txtcodpedido.Focus();
           if (cmbFormaPago.Items.Count > 0) cmbFormaPago.SelectedIndex = 0;
       }

   

       private void chkVentaGratuita_CheckedChanged(object sender, EventArgs e)
       {
           if (chkVentaGratuita.Checked == true)
           {               
               chkVentaDsctoGlobal.Checked = false;
           } 
       }

       private void chkVentaDsctoGlobal_CheckedChanged(object sender, EventArgs e)
       {
           if (chkVentaDsctoGlobal.Checked == true)
           {
               chkVentaGratuita.Checked = false;               
           }  
       }

       private void groupBox3_Enter(object sender, EventArgs e)
       {

       }
    }
}
