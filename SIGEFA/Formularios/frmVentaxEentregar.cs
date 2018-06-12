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
//using SIGEFA.SunatFacElec;

namespace SIGEFA.Formularios
{
    public partial class frmVentaxEentregar : DevComponents.DotNetBar.Office2007Form
    {
        //SIGEFA.SunatFacElec.Conexion conex = new SunatFacElec.Conexion();
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


        public Byte[] firmadigital { get; set; } 
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
        public Int32 CodSerie, CodSerieG = 0, numG = 0, manual = 0;
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

        public bool consultorext;

        public static BindingSource data = new BindingSource();

        Int32 CodLista = 0;
        Boolean Validacion = true;
        Decimal TipoCambio = 0, ret = 0;
        public Int32 mon = 0;//MOD6

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

        public Decimal montogratuitas, montogravadas, montoexoneradas, montoinafectas = 0;

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

        public frmVentaxEentregar()
        {
            InitializeComponent();
        }

        public void frmVenta_Load(object sender, EventArgs e)
        {
            iniciaformulario();
        }

        public Boolean banderadelete = false;
        
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
                        ProcessTabKey(false);
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
                    if (t.Tag != null && t.Tag != "")
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
            cli = AdmCli.MuestraCliente(CodCliente);
            cli = AdmCli.CargaDeuda(cli);
            ncredito = admNotac.BuscarNotasXCliente(CodCliente);
            if (cli.Cantidad > 0)
            {
                DialogResult dlgResult = MessageBox.Show("El cliente selecionado presenta" + Environment.NewLine + "Facturas pendientes = " + cli.Cantidad + Environment.NewLine + "Deuda Total = " + cli.Deuda + " soles" + Environment.NewLine + "Linea de crédito = " + cli.LineaCredito + Environment.NewLine + " Desea continuar con la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    ret = 1;
                   
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
            
        }
      
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
            if (cli.Moneda == 1)
            {
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
               
            }
            //txtPDescuento.Text = cli.Descuento.ToString();
            cmbMoneda.SelectedValue = cli.Moneda;
            mon = cli.Moneda;//MOD6           
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

                        //txtPDescuento.Text = "";
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

                //txtPDescuento.Text = "";
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
                        btnImprimir.Enabled = true; ProcessTabKey(true);
                        txtDocRef.Focus();
                    }
                }
            }
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
                }
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
                
                return true;
            }
            else
            {
                CodDocumento = 0;
               
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
                    if (cli.Ruc != "")
                    {
                        frmDocumentos form = new frmDocumentos();
                        form.Proceso = 3;
                        form.ShowDialog();
                        doc = form.doc;
                        CodDocumento = doc.CodTipoDocumento;
                        
                        txtDocRef.Text = doc.Sigla;
                        if (CodDocumento != 0) { ProcessTabKey(true); }
                    }
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
            //if (txtAutorizacion.Visible && CodAutorizado == 0)
            //{
            //    Validacion = false;
            //}
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
           
            //txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnImprimir.Visible = !estado;
            //btnEditar.Visible = !estado;
           
            btnGuardar.Visible = !estado;
            // btnImprimir.Visible = estado;
                    
            cbovendedor.Enabled = !estado;            
            cmbFormaPago.Enabled = !estado;
            txtSerie.ReadOnly = estado;
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
           
            //txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnImprimir.Visible = !estado;           
            cbovendedor.Enabled = !estado;            
            cmbFormaPago.Enabled = !estado;
            txtSerie.ReadOnly = estado;
            
        }

        private void CargaDetalle()
        {            
            try
            {
                DataTable newDataDetalle = new DataTable();
                dgvDetalle.Rows.Clear();
                newDataDetalle = AdmVenta.CargaDetallexEntregar(Convert.ToInt32(venta.CodFacturaVenta), frmLogin.iCodAlmacen);
                foreach (DataRow row in newDataDetalle.Rows)
                {
                    dgvDetalle.Rows.Add(row[0].ToString(),"0", row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), 
                                        row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), 
                                        row[14].ToString(), row[15].ToString(), row[16].ToString(), row[18].ToString(), row[17].ToString(), row[18].ToString(), row[19].ToString(),
                                        row[20].ToString(), row[21].ToString(),  row[22].ToString(), row[23].ToString(), row[24].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            darformatogrilla();            
        }

        private void darformatogrilla()
        {
            if (dgvDetalle.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[CantidadPendiente.Name].Value) > 0)
                    {
                        
                        row.Cells[CantidadEntregada.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDecimal(row.Cells[cantidad.Name].Value) - Convert.ToDecimal(row.Cells[CantidadPendiente.Name].Value));
                        
                    }

                    row.Cells[CantidadxSalir.Name].Style.BackColor = Color.PeachPuff;
                    row.Cells[CantidadxSalir.Name].Value = 0m;
                }
            }

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
                btnGuardar.Enabled = false;
            }          
                
                CargaVendedores();

        }

        private void frmVenta_Shown(object sender, EventArgs e)
        {
            txtTransaccion.Focus();
            txtTransaccion.Text = "FT";
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtTransaccion_KeyPress(txtTransaccion, ee);           
            txtCodCliente.Focus();
            if (Proceso == 1)
            {
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
                    }
                }
            }
            else if (Proceso == 4)
            {
                Proceso = 1;
            }
        }

        public Boolean xgenerar = false;
        private void CargaVenta()
        {
            try
            {
                venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(CodVenta));
                ser = Admser.MuestraSerie(venta.CodSerie, frmLogin.iCodAlmacen);
                guia = AdmGuia.CargaGuiaVenta(Convert.ToInt32(CodVenta));

                if (venta != null)
                {
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
                    }
                    dtpFecha.Value = venta.FechaSalida;
                    cmbMoneda.SelectedValue = venta.Moneda;
                    txtTipoCambio.Text = venta.TipoCambio.ToString();
                    //if (txtAutorizacion.Enabled)
                    //{
                        
                    //}
                    
                    CodDocumento = venta.CodTipoDocumento;
                   
                    txtDocRef.Text = venta.SiglaDocumento;
                    txtSerie.Text = venta.Serie;
                    if (Procede != 4) txtNumero.Text = venta.NumDoc;
                    else txtNumero.Text = numSerie;
                    
                    if (txtSerie.Text == "" && txtNumero.Text == "")
                    {
                        xgenerar = true;
                    }
                   
                    if (cbovendedor.Enabled)
                    {
                        if (venta.CodVendedor != 0)
                        {
                            cbovendedor.SelectedValue = venta.CodVendedor;
                        }
                    }
                    
                    cmbFormaPago.SelectedValue = venta.FormaPago;
                    cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, null);
                    
                    dtpFechaPago.Value = venta.FechaPago;
                    

                    txtBruto.Text = String.Format("{0:#,##0.00}", venta.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", venta.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", venta.Total - venta.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", venta.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", venta.Total);
                    //txtgravadas.Text = String.Format("{0:#,##0.00}", venta.Gravadas);
                    //txtexoneradas.Text = String.Format("{0:#,##0.00}", venta.Exoneradas);
                    //txtinafectas.Text = String.Format("{0:#,##0.00}", venta.Inafectas);
                    //txtgratuitas.Text = String.Format("{0:#,##0.00}", venta.Gratuitas);
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
            if (e.KeyChar == (char)Keys.Enter)
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
                        calculatotales();
                   

                    if (dgvDetalle.RowCount > 0)
                    {
                        int Indice = 0;
                        Indice = dgvDetalle.RowCount - 1;

                        if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                        {
                            if (TipoCambio != 0)
                            {
                                dgvDetalle[8, Indice].Value = Convert.ToDecimal(dgvDetalle[8, Indice].Value) * TipoCambio;
                                dgvDetalle[9, Indice].Value = Convert.ToDecimal(dgvDetalle[9, Indice].Value) * TipoCambio;
                                dgvDetalle[13, Indice].Value = Convert.ToDecimal(dgvDetalle[13, Indice].Value) *
                                                               TipoCambio;
                                dgvDetalle[14, Indice].Value = Convert.ToDecimal(dgvDetalle[14, Indice].Value) *
                                                               TipoCambio;
                                dgvDetalle[15, Indice].Value = Convert.ToDecimal(dgvDetalle[15, Indice].Value) *
                                                               TipoCambio;
                                dgvDetalle[16, Indice].Value = Convert.ToDecimal(dgvDetalle[16, Indice].Value) *
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

                        if (Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "21" && banderadelete) // gratuitas
                        {
                            montogratuitas = montogratuitas - (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                            montosventa();
                            banderadelete = false;
                        }

                        if (Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "10" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "11" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "12" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "13" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "14" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "15" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "16" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "17" && banderadelete)   // gravadas
                        {
                            montogravadas = montogravadas - (Convert.ToDecimal(row.Cells[valorventa.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                            montosventa();
                            banderadelete = false;
                        }

                        if (Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "20" && banderadelete) // exoneradas
                        {
                            montoexoneradas = montoexoneradas - (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                            montosventa();
                            banderadelete = false;
                        }

                        if (Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "30" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "31" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "32" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "33" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "34" && banderadelete || Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "35" && banderadelete ||
                            Convert.ToString(row.Cells[TipoImpuesto.Name].Value) == "36" && banderadelete) // inafectas
                        {
                            montoinafectas = montoinafectas - (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                            montosventa();
                            banderadelete = false;
                        }
                    }
                    if (dgvDetalle.RowCount == 0) 
                    {
                        montogratuitas = 0m;
                        montoexoneradas = 0m;
                        montogravadas = 0m;
                        montoinafectas = 0m;
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

        public void montosventa() 
        {
            if (Proceso != 0 && Proceso != 3)
            {
                if (montogravadas > 0) 
                {
                    txtgravadas.Clear();
                    txtgravadas.Text = String.Format("{0:#,##0.00}", montogravadas);
                }
                if (montogratuitas > 0)
                {
                    txtgratuitas.Clear();
                    txtgratuitas.Text = String.Format("{0:#,##0.00}", montogratuitas);
                }
                if (montoexoneradas > 0)
                {
                    txtexoneradas.Clear();
                    txtexoneradas.Text = String.Format("{0:#,##0.00}", montoexoneradas);
                }
                if (montoinafectas > 0)
                {
                    txtinafectas.Clear();
                    txtinafectas.Text = String.Format("{0:#,##0.00}", montoinafectas);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0)
            {
                venta.CodSucursal = frmLogin.iCodSucursal;
                venta.CodFacturaVenta = CodVenta;               
                venta.CodCliente = Convert.ToInt32(venta.CodCliente);
                venta.CodAlmacen = frmLogin.iCodAlmacen;
                venta.CodUser = frmLogin.iCodUser;     
                venta.Estado = 1;
                venta.FechaRegistro = DateTime.Now;

                if (Proceso == 3)
                {
                    if (AdmVenta.insertventaentregar(venta))
                    {
                        RecorreDetalle();
                        if (detalle1.Count > 0)
                        {
                            foreach (clsDetalleFacturaVenta det in detalle1)
                            {
                                AdmVenta.insertdetalleventaentregar(det);
                                if (det.CodDetalleVenta == 0)
                                {
                                    MessageBox.Show("Error No se puede Registrar los Datos. Falta Stock de Productos");
                                    AdmVenta.rollback(Convert.ToInt32(venta.CodFacturaVenta), 0);
                                    //break;
                                    return;
                                }

                            }


                        }
                        MessageBox.Show("Los datos se guardaron correctamente", "Venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtNumDoc.Text = venta.CodFacturaVenta.PadLeft(11, '0');
                        VerificaFactura(Convert.ToInt32(CodVenta));
                        btnImprimir.Visible = false;
                        this.Close();
                    }
                }
            }
                
            
        }
        public List<Int32> listacodigos = new List<Int32>();
        private void VerificaFactura(Int32 codigo)
        {
            Int32 contador = 0;
            DataTable newDataDetalle = new DataTable();
            dgvDetalle.Rows.Clear();
            newDataDetalle = AdmVenta.CargaDetallexEntregar(Convert.ToInt32(venta.CodFacturaVenta), frmLogin.iCodAlmacen);
            foreach (DataRow row in newDataDetalle.Rows)
            {
                listacodigos.Add(Convert.ToInt32(row[0]));
            }

            if (listacodigos.Count > 0) 
            {
                foreach (Int32 lista in listacodigos) 
                {
                    if (AdmVenta.GetCantidadPendiente(lista) == 0) 
                    {
                        if (AdmVenta.CambiaEstadoDetalle(lista)) 
                        {
                            contador++;
                        }
                    }
                }
            }

            if (listacodigos.Count == contador)
            {
                if (AdmVenta.CambiaEstadoFactura(Convert.ToInt32(CodVenta)))
                {
                    contador = 0;
                    listacodigos.Clear();
                }
            }
        }

        private void VerificaSaldoCaja()
        {
            Caja = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, 1, frmLogin.iCodAlmacen, frmLogin.iCodUser);//1 caja ventas
            CodigoCaja = Caja.Codcaja;
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
            deta.CodDetalleVenta = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodVenta = Convert.ToInt32(venta.CodFacturaVenta);
            deta.Codventaentregar = Convert.ToInt32(venta.Codventaentregar);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.CodUnidad = Convert.ToInt32(fila.Cells[codunidad.Name].Value);            
            deta.Cantidad = Convert.ToDouble(fila.Cells[CantidadxSalir.Name].Value);            
            deta.CodUser = frmLogin.iCodUser;
            deta.FechaRegistro = DateTime.Now;            
            deta.CantidadPendiente = Convert.ToDouble(fila.Cells[CantidadPendiente.Name].Value);
            
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
                    manual = Convert.ToInt32(ser.PreImpreso);
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

        public void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
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

        private void txtPDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);            
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

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Procede == 1 || Procede == 2)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
                {
                    if (Proceso == 1 || Proceso == 2)
                    {
                         calculatotales();                       
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
            
        }

        public List<Int32> carga_Correlativos()
        {
            Int32 j = 0;
            datos = AdmVenta.ListaFacturaVenta(frmLogin.iCodAlmacen);
            ser = Admser.MuestraSerie(8, frmLogin.iCodAlmacen);
            correlativo.Clear();
            for (int i = ser.Inicio; i < ser.Numeracion; i++)
            {
                if (j < datos.Rows.Count)
                {
                    if (i == Convert.ToInt32(datos.Rows[j]["numDocumento"]))
                    {
                        j++;
                        fecha1 = Convert.ToDateTime(datos.Rows[j - 1]["fechasalida"]);
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

                }
            }
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
                        }
                        else
                        {
                            CodSerieG = ser.CodSerie;
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

        private void cmbAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnImprimir.Focus();
            }
        } 

        private void chkVentaGratuita_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentaGratuita.Checked == true) 
            {
                chkVentaInafecta.Checked = false;
                chkVentaExonerada.Checked = false;
                chkVentaDsctoGlobal.Checked = false;
            }            
        }

        private void chkVentaInafecta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentaInafecta.Checked == true)
            {
                chkVentaGratuita.Checked = false;
                chkVentaExonerada.Checked = false;
                chkVentaDsctoGlobal.Checked = false;
            }            
        }

        private void chkVentaExonerada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentaExonerada.Checked == true)
            {
                chkVentaGratuita.Checked = false;
                chkVentaInafecta.Checked = false;
                chkVentaDsctoGlobal.Checked = false;
            }  
        }

        private void chkVentaDsctoGlobal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVentaDsctoGlobal.Checked == true)
            {
                chkVentaGratuita.Checked = false;
                chkVentaInafecta.Checked = false;
                chkVentaExonerada.Checked = false;
            }  
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {           
            Decimal cantidadsal = 0;
            if (dgvDetalle.RowCount > 0)
            {                
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    cantidadsal = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[CantidadxSalir.Name].Value);
                    if (e.ColumnIndex == 28)
                    {
                        if (cantidadsal >= 0 && cantidadsal <= Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[CantidadPendiente.Name].Value))
                        {
                            row.Cells[CantidadxSalir.Name].Style.BackColor = Color.PeachPuff;
                            btnGuardar.Enabled = true;
                        }
                        else 
                        {
                            MessageBox.Show("La cantidad a entregar no debe superar" + Environment.NewLine + "la cantidad Pendiente ni ser menor que cero","ADVERTENCIA", MessageBoxButtons.OK);
                            row.Cells[CantidadxSalir.Name].Style.BackColor = Color.Red;
                            btnGuardar.Enabled = false;
                        }
                    }                   
                }
            }
        }

        private void dgvDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetalle.IsCurrentCellDirty) 
            {
                dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaFactura(Convert.ToInt32(CodVenta));

                if (frmLogin.iCodAlmacen != 0)
                {
                    
                    frmRptFactura frm = new frmRptFactura();
                    CRSalidaDespacho rpt = new CRSalidaDespacho();
                    rpt.Load("CRSalidaDespacho.rpt");                    
                    rpt.SetDataSource(ds.salidadespacho(Convert.ToInt32(venta.CodFacturaVenta), venta.Codventaentregar));

                    frm.crvReporteFactura.ReportSource = rpt;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            }
        }

        
       
    }
}
