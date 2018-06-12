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


namespace SIGEFA.Formularios
{
    public partial class frmConsultorExt : DevComponents.DotNetBar.Office2007Form
    {
        public frmConsultorExt()
        {
            InitializeComponent();
        }
        clsFacturaVenta fv = new clsFacturaVenta();
        clsAdmProducto AdmProd = new clsAdmProducto();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
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
        clsAdmPedido AdmPedido = new clsAdmPedido();
        clsPedido pedido = new clsPedido();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsValidar ok = new clsValidar();
        clsAdmListaPrecio admLista = new clsAdmListaPrecio();
        clsListaPrecio Listap = new clsListaPrecio();
        clsAdmCotizacion AdmCot = new clsAdmCotizacion();
        clsCotizacion coti = new clsCotizacion();
        Int32 CodLista = 1;

        public List<Int32> listNotas = new List<Int32>();

        public List<Int32> config = new List<Int32>();
        public List<clsDetallePedido> detalle = new List<clsDetallePedido>();
        public String CodPedido;
        public Int32 CodCotizacion;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodAutorizado;
        public Int32 Tipo;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        clsConsultasExternas ext = new clsConsultasExternas();

        public Int32 CodVendedor;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDetalleSalida"] != null)
            {
                Application.OpenForms["frmDetalleSalida"].Activate();
            }
            else
            {
                frmDetalleSalida form = new frmDetalleSalida();
                form.Procede = 41;
                form.Proceso = 1;
                form.Moneda = 1;
                form.consultorext = false;
                form.Codlista = CodLista;
                form.ShowDialog();
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


                    if(Proceso == 1)
                    form.Proceso = 2;

                    if (Proceso == 2)
                    {
                        form.Proceso = 3;
                        form.codDetalle = Int32.Parse(row.Cells[coddetalle.Name].Value.ToString());

                    }

                    form.Procede = 41;
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.txtControlStock.Text = row.Cells[serielote.Name].Value.ToString();
                    form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
                    form.txtPrecio.Text = row.Cells[preciounit.Name].Value.ToString();
                    form.txtDscto1.Text = row.Cells[dscto1.Name].Value.ToString();
                    form.txtDscto2.Text = row.Cells[dscto2.Name].Value.ToString();
                    form.txtDscto3.Text = row.Cells[dscto3.Name].Value.ToString();
                    form.txtPrecioNeto.Text = row.Cells[importe.Name].Value.ToString();
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

            cbListaPrecios.SelectedValue = cli.CodListaPrecio;
            if (cli.CodListaPrecio != 0)
            {
                EventArgs ee = new EventArgs();
                cbListaPrecios_SelectionChangeCommitted(cbListaPrecios, ee);
            }
            else
            {
                CodLista = 0;
            }
        }

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtCodCliente.Text, Tipo);
            if (cli != null)
            {
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
                if (Application.OpenForms["frmListaVendedores"] != null)
                {
                    Application.OpenForms["frmListaVendedores"].Activate();
                }
                else
                {
                    frmListaVendedores form = new frmListaVendedores();
                    form.ShowDialog();
                    if (txtCodCliente.Text != "" && txtNombreCliente.Text != "")
                    {
                        btnGuardar.Enabled = true;
                        txtComentario.Focus();
                    }
                    txtComentario.Focus();
                }
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {   

        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {   

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("x");
            if (txtTipoCambio.Visible)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
                if (Proceso == 1)
                {
                    if (tc != null)
                    {
                        txtTipoCambio.Text = tc.Venta.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpFecha.Value = DateTime.Now.Date;
                        dtpFecha.Focus();
                    }
                }
            }
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {

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
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                lbDocumento.Text = doc.Descripcion;
                lbDocumento.Visible = true;
                return true;
            }
            else
            {
                CodDocumento = 0;
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
                    frmDocumentos form = new frmDocumentos();
                    form.Proceso = 3;
                    form.ShowDialog();
                    doc = form.doc;
                    CodDocumento = doc.CodTipoDocumento;
                    txtDocRef.Text = doc.Sigla;                    
                    lbDocumento.Text = doc.Descripcion;
                    lbDocumento.Visible = true;
                    if (CodDocumento != 0) { ProcessTabKey(true); }                    
                }
            }
        }

        private void VerificarCabecera()
        {
            Validacion = true;
            if (CodDocumento == 0)
            {
                Validacion = false;
            }
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
            dtpFechaEntrega.Enabled = !estado;
            cbListaPrecios.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            txtCotizacion.Enabled = !estado;
            cmbMoneda.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtPedido.ReadOnly = estado;
            txtComentario.ReadOnly = estado;            
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnNuevo.Visible = !estado;
            btnEditar.Visible = !estado;
            btnEliminar.Visible = !estado;
            btnGuardar.Visible = !estado;
            btnNewPedido.Visible = estado;
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmPedido.CargaDetalleEntrega(Convert.ToInt32(pedido.CodPedido));

        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
            if (CodDocumento == 0)
            {
                txtDocRef.Focus();
            }
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(0);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 2;
        }

        private void frmConsultorExt_Load(object sender, EventArgs e)
        {
            cmbMoneda.SelectedIndex = 0;
            CargaListaPrecios();
            CargaFormaPagos();

            cbListaPrecios.SelectedIndex = 0;

            dtpFecha.MaxDate = DateTime.Today.Date;
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));

            if (Proceso == 1) 
            {
                button3.Visible = false;
            }
            else if (Proceso == 2)//Editar Entrega
            {
                CargaPedido();
                button1.Visible = false;
                label6.Visible = true;
                textBox1.Visible = true;
            }
            else if (Proceso == 3)//Liquidar Entregar
            {
                CargaPedido();
                sololectura(true);

                dgvDetalle.Columns["montodscto"].Visible = false;
                dgvDetalle.Columns["valorventa"].Visible = false;
                dgvDetalle.Columns["igv"].Visible = false;
                dgvDetalle.Columns["precioventa"].Visible = false;

                dgvDetalle.Columns["cantidadvend"].Visible = true;
                dgvDetalle.Columns["cantidaddev"].Visible = true;
                //dgvDetalle.Columns["importedev"].Visible = true;
                //dgvDetalle.Columns["importevend"].Visible = true;
 
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                btnNewPedido.Visible = false;
                label6.Visible = true;
                textBox1.Visible = true;
                panel1.Visible = false;

            }
            else if (Proceso == 4)//Consultar Liquidado
            {
                CargaPedido();
                sololectura(true);
                
                btnNewPedido.Visible = false;
                label6.Visible = true;
                textBox1.Visible = true;

                panel1.Visible = false;
                dgvDetalle.Columns["montodscto"].Visible = false;
                dgvDetalle.Columns["valorventa"].Visible = false;
                dgvDetalle.Columns["igv"].Visible = false;
                dgvDetalle.Columns["precioventa"].Visible = false;

                dgvDetalle.Columns["cantidadvend"].Visible = true;
                dgvDetalle.Columns["cantidaddev"].Visible = true;
                //dgvDetalle.Columns["importedev"].Visible = true;
                //dgvDetalle.Columns["importevend"].Visible = true;

            }
            txtDocRef.Text = "SD";
        }

        private void CargaListaPrecios()
        {
            cbListaPrecios.DataSource = admLista.MuestraListas(frmLogin.iCodAlmacen);
            cbListaPrecios.DisplayMember = "nombre";
            cbListaPrecios.ValueMember = "codListaPrecio";
            cbListaPrecios.SelectedIndex = -1;
        }

        private void frmConsultorExt_Shown(object sender, EventArgs e)
        {           
            btnNuevo.Focus();
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
                        txtTipoCambio.Text = tc.Venta.ToString();
                    }
                }
            }
        }

        private void CargaPedido()
        {
            try
            {
                pedido = AdmPedido.CargaEntrega(Convert.ToInt32(CodPedido));
                if (pedido != null)
                {
                    txtPedido.Text = pedido.CodPedido;
                    if (pedido.CodCotizacion != 0)
                    {
                        coti = AdmCot.CargaCotizacion(pedido.CodCotizacion,frmLogin.iCodAlmacen);
                        txtCotizacion.Text = coti.CodCotizacion;
                    }
                  
                    if (txtCodCliente.Enabled)
                    {
                        CodVendedor = pedido.CodCliente;
                        txtCodCliente.Text = pedido.CodigoPersonalizado;
                        txtNombreCliente.Text = pedido.Nombre;
                        txtDireccion.Text = pedido.Direccion;
                    }
                    dtpFecha.Value = pedido.FechaPedido;
                    cmbMoneda.SelectedIndex = pedido.Moneda;
                    txtTipoCambio.Text = pedido.TipoCambio.ToString();
                    cbListaPrecios.SelectedValue = pedido.CodListaPrecio;
                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = pedido.CodTipoDocumento;
                        txtDocRef.Text = pedido.SiglaDocumento;
                        lbDocumento.Text = pedido.DescripcionDocumento;
                    }                    
                    txtComentario.Text = pedido.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.00}", pedido.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", pedido.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", pedido.Total - pedido.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", pedido.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", pedido.Total);
                    textBox1.Text = pedido.SEntregado;
                    
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            }
        }

        private void actualizaimportes()
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
                    pedido.CodAlmacen = frmLogin.iCodAlmacen;
                    pedido.CodCliente = CodVendedor;
                    //pedido.CodTipoDocumento = doc.CodTipoDocumento;
                    pedido.CodTipoDocumento = 46;
                    pedido.CodCotizacion = CodCotizacion;
                    pedido.Moneda = cmbMoneda.SelectedIndex;
                    if (txtTipoCambio.Visible) { pedido.TipoCambio = Convert.ToDouble(txtTipoCambio.Text); }
                    pedido.FechaPedido = dtpFecha.Value.Date;
                    pedido.FechaEntrega = dtpFechaEntrega.Value.Date;
                    pedido.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    pedido.FechaPago = dtpFecha.Value.AddDays(fpago.Dias);
                    pedido.CodListaPrecio = Convert.ToInt32(cbListaPrecios.SelectedValue);
                    if (fpago.Dias == 0)
                    {
                        nota.FechaCancelado = dtpFecha.Value.Date;
                        nota.Cancelado = 1;// Para saber si la nota esta pendiente de pago o esta cancelada
                    }
                    pedido.Comentario = txtComentario.Text;
                    pedido.CodAutorizado = CodAutorizado;
                    pedido.MontoBruto = Convert.ToDouble(txtBruto.Text);
                    pedido.MontoDscto = Convert.ToDouble(txtDscto.Text);
                    pedido.Igv = Convert.ToDouble(txtIGV.Text);
                    pedido.Total = Convert.ToDouble(txtPrecioVenta.Text);
                    pedido.CodUser = frmLogin.iCodUser;
                    pedido.Estado = 1;// Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                    if (Proceso == 1)
                    {
                        if (AdmPedido.insertEntConsExt(pedido))
                        {
                            RecorreDetalle();
                            if (detalle.Count > 0)
                            {
                                foreach (clsDetallePedido det in detalle)
                                {
                                    AdmPedido.insertdetalleconsultor(det);
                                }
                            }
                            MessageBox.Show("Los datos se guardaron correctamente", "Nota de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CodPedido = pedido.CodPedido;
                  //          txtPedido.Text = CodPedido;

                            //CargaPedido();
                            sololectura(true);                            
                        }
                    }
                    else if (Proceso == 2 || Proceso == 3)
                    {
                        if (AdmPedido.update(pedido))
                        {
                            RecorreDetalle();
                            foreach (clsDetallePedido det1 in detalle)
                            {

                                AdmPedido.updatedetallesalidaconsultext(det1);
                             //   return;

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
        }
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetallePedido deta = new clsDetallePedido();
            deta.CodDetallePedido = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodPedido = Convert.ToInt32(pedido.CodPedido);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            deta.DCantidadVendida = Convert.ToDouble(fila.Cells[cantidadvend.Name].Value);
            deta.DCantidadDevuelta = Convert.ToDouble(fila.Cells[cantidaddev.Name].Value);
            deta.IImpDevuelto = Convert.ToDouble(fila.Cells[importedev.Name].Value);
            deta.IImpVend = Convert.ToDouble(fila.Cells[importevend.Name].Value);
            detalle.Add(deta);
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                actualizaimportes();
            }
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
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
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            DataGridView tabla = (DataGridView)e.ControlToValidate;
            if (Proceso != 0)
                if (tabla.Rows.Count >= 1)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void btnNewPedido_Click(object sender, EventArgs e)
        {
            frmConsultorExt form = new frmConsultorExt();
            form.MdiParent = this.MdiParent;
            form.Proceso = 1;            
            form.txtDocRef.Focus();
            form.Show();
            this.Close();
        }

        private void txtComentario_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            //dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias); 
        }

        private void cbListaPrecios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CodLista = Convert.ToInt32(cbListaPrecios.SelectedValue);
            actualizaprecios();
            calculatotales();
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
                        row.Cells[igv.Name].Value = String.Format("{0:#,##0.00}", igva);
                    }
                }
            }
        }

        private void calculatotales()
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

        private void txtCotizacion_KeyPress(object sender, KeyPressEventArgs e)
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
                        MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaCotizacion()
        {
            coti = AdmCot.BuscaCotizacion(txtCotizacion.Text, frmLogin.iCodAlmacen);            
            if (coti != null)
            {
                CodCotizacion = Convert.ToInt32(coti.CodCotizacion);                
                return true;
            }
            else
            {
                CodCotizacion = 0;
                return false;
            }
        }

        private void CargaCotizacion()
        {
            try
            {
                coti = AdmCot.CargaCotizacion(Convert.ToInt32(CodCotizacion), frmLogin.iCodAlmacen);
                if (coti != null)
                {                    
                    txtCotizacion.Text = coti.CodCotizacion;

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = coti.CodCliente;
                        cli = AdmCli.MuestraCliente(CodCliente);
                        txtCodCliente.Text = coti.CodigoPersonalizado;
                        txtNombreCliente.Text = coti.Nombre;
                        txtDireccion.Text = coti.Direccion;
                       
                    }                    
                    cmbMoneda.SelectedIndex = coti.Moneda;
                    txtTipoCambio.Text = coti.TipoCambio.ToString();
                    cbListaPrecios.SelectedValue = coti.CodListaPrecio;
                                       
                    txtComentario.Text = coti.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.00}", coti.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", coti.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", coti.Total - coti.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", coti.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", coti.Total);
                    CargaDetalleCotizacion();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaDetalleCotizacion()
        {
            dgvDetalle.DataSource = AdmCot.CargaDetalle(Convert.ToInt32(coti.CodCotizacion), frmLogin.iCodAlmacen);            
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("¿ Al liquidar la entrega esta será cerrada y no podra hacer operaciones sobre ella, Desea liquidar la entrega del dia ?", "Confirmar Liquidación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
            {
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToInt32(row.Cells[cantidadvend.Name].Value)==0)
                    {
                        row.Cells[cantidaddev.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[cantidad.Name].Value));
                    }
                }
                RecorreDetalle();
                foreach (clsDetallePedido det1 in detalle)
                    AdmPedido.updatedetallesalidaconsultext(det1);

                foreach (Int32 x in listNotas)
                {
                    fv = AdmVenta.CargaFacturaVenta(x);
                    fv.Codsalidaconsulext = Int32.Parse(CodPedido);
                    AdmVenta.updatensconsultext(fv);
                }
                if (AdmPedido.liquidar(Convert.ToInt32(CodPedido)))
                {
                    MessageBox.Show("La entrega ha sido liquidada", "Liquidación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmVentasDiarias"] != null)
            {
                Application.OpenForms["frmVentasDiarias"].Activate();
            }
            else
            {
                frmVentasDiarias form = new frmVentasDiarias();
                form.codVendedor = CodVendedor;
                form.ShowDialog();

                foreach (Int32 x in listNotas)
                {
                    List<clsProducto> prodvendidos = AdmProd.VentasProductosCount(x);
                    foreach (clsProducto prod in prodvendidos)
                    {
                        if (prodvendidos == null)
                            return;

                        if (prodvendidos.Count <= 0)
                            return;
                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            bool encontro = false;
                            if (prod.CodProducto == Convert.ToInt32(row.Cells[codproducto.Name].Value))
                            {
                                row.Cells[cantidadvend.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[cantidadvend.Name].Value) + Convert.ToDouble(prod.StockActual));
                                row.Cells[cantidaddev.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[cantidad.Name].Value) - Convert.ToDouble(row.Cells[cantidadvend.Name].Value));
                                //row.Cells[importevend.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[cantidadvend.Name].Value) * Convert.ToDouble(row.Cells[preciounit.Name].Value));
                                //row.Cells[importedev.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[importe.Name].Value) - Convert.ToDouble(row.Cells[importevend.Name].Value));
                                encontro = true;
                            }
                            if (encontro == false)
                            {
                                row.Cells[cantidaddev.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[cantidad.Name].Value) - Convert.ToDouble(row.Cells[cantidadvend.Name].Value));
                            //    row.Cells[importedev.Name].Value = String.Format("{0:#,##0.00}", 0);
                            //    row.Cells[importevend.Name].Value = String.Format("{0:#,##0.00}", 0);
                            }
                        }
                    }
                }
                button1.Enabled = true;
                panel1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCliVisitados"] != null)
            {
                Application.OpenForms["frmCliVisitados"].Activate();
            }
            else
            {
                frmCliVisitados form = new frmCliVisitados();
                form.codEntConsExt = Convert.ToInt32(CodPedido);
                form.proceso = Proceso;
                form.ShowDialog();
            }
        }

    }
}
