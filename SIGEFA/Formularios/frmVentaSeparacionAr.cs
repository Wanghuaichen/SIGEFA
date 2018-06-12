using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Entidades;
using SIGEFA.Administradores;

namespace SIGEFA.Formularios
{
    public partial class frmVentaSeparacionAr : DevComponents.DotNetBar.OfficeForm
    {
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmVendedor AdmVen = new clsAdmVendedor();
        clsMoneda moneda = new clsMoneda();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsTransaccion tran = new clsTransaccion();
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        clsAdmAlmacen Admalmac = new clsAdmAlmacen();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsValidar ok = new clsValidar();
        
        
        clsFormaPago fpago = new clsFormaPago();
        clsSeparacion sepa = new clsSeparacion();
        clsAdmSeparacion admSepa = new clsAdmSeparacion();

        public Int32 CodDocumento;
        public Int32 CodTransaccion;
        public Int32 Proceso = 0;
        public Int32 Procede = 0;
        public Int32 CodCliente;
        public Int32 CodVendedor;
        public Int32 codFormaPago;
        public Int32 CodSerie, CodSerieG = 0, numG = 0, manual = 0;
        Decimal TipoCambio = 0, ret = 0;

        public List<clsDetalleNotaSalida> detalle = new List<clsDetalleNotaSalida>();
        public List<clsDetalleSeparacionVenta> detalle1 = new List<clsDetalleSeparacionVenta>();
        public List<clsDetalleGuiaRemision> detalleg = new List<clsDetalleGuiaRemision>();


        public frmVentaSeparacionAr()
        {
            InitializeComponent();
        }

        private void frmVentaSeparacionAr_Load(object sender, EventArgs e)
        {
            inicializarPagina();
        }

        private void inicializarPagina()
        {
            CargaMoneda();
            dtpFecha.MaxDate = DateTime.Today.Date;
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            CargaVendedores();
            CargaFormaPagos();
            btnNuevo.Focus();
            cargaAlmacenes();
        }

        private void cargaAlmacenes()
        {
            cmbAlmacen.DataSource = Admalmac.CargaAlmacen2(frmLogin.iCodEmpresa);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen; ;
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagosCuotas();
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            //Se agrego estas lineas
            cmbFormaPago.SelectedIndex = 0;
            
        }

        private void CargaVendedores()
        {
            cbovendedor.DataSource = AdmVen.MuestraVendedoresDestaque();
            cbovendedor.DisplayMember = "apellido";
            cbovendedor.ValueMember = "codVendedor";
            cbovendedor.SelectedIndex = 0;
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void frmVentaSeparacionAr_Shown(object sender, EventArgs e)
        {
            txtTransaccion.Focus();
            txtTransaccion.Text = "FT";
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtTransaccion_KeyPress(txtTransaccion, ee);
            cmbAlmacen.Visible = true;
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
        }

        private void txtTransaccion_KeyPress(TextBox txtTransaccion, KeyPressEventArgs ee)
        {
            if (ee.KeyChar == (char)Keys.Return)
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

        private bool BuscaTransaccion()
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
        }

        private void CargaCliente()
        {
            cli = AdmCli.MuestraCliente(CodCliente);
            cli = AdmCli.CargaDeuda(cli);
            if (cli.Cantidad > 0)
            {
                DialogResult dlgResult = MessageBox.Show("El cliente selecionado presenta" + Environment.NewLine + "Facturas pendientes = " + cli.Cantidad + Environment.NewLine + "Deuda Total = " + cli.Deuda + " soles" + Environment.NewLine + "Linea de crédito = " + cli.LineaCredito + Environment.NewLine + " Desea continuar con la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    ret = 1;
                    //txtCotizacion.Text = "";
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
           
             txtCodCliente.Text = cli.RucDni;
            
            txtNombreCliente.Text = cli.RazonSocial;
            txtDireccionCliente.Text = cli.DireccionLegal;
            txtCodigoCli.Text = cli.CodCliente.ToString();


            
            cmbFormaPago.SelectedIndex = 0;
            
            if (cli.FormaPago != 0)
            {
                EventArgs ee = new EventArgs();                

            }
            else
            {
                dtpFechaPago.Value = DateTime.Today;
            }
            if (cli.CodVendedor != 0)
            {

                cbovendedor.SelectedValue = cli.CodVendedor;

            }

            cmbMoneda.SelectedValue = cli.Moneda;
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
                        txtCodDocumento.Text = CodDocumento.ToString();
                        txtDocRef.Text = doc.Sigla;
                        if (CodDocumento != 0) { ProcessTabKey(true); }
                    }
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

        private bool BuscaTipoDocumento()
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

            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbFormaPago.Focus();
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
                    txtNumero.Visible = true;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDetalle.Text == "")
                {
                    RecorreDetalle();
                    if (Application.OpenForms["frmDetalleSalida"] != null)
                    {
                        Application.OpenForms["frmDetalleSalida"].Activate();
                    }
                    else
                    {
                        frmDetalleSalida form = new frmDetalleSalida();
                        form.Procede = 5;
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
                        //form.Codlista = Convert.ToInt32(cbListaPrecios.SelectedValue);
                        form.tc = tc.Compra;
                        //form.productoscargadosSep = detalle1;
                        form.alma = Convert.ToInt32(cmbAlmacen.SelectedValue);
                        form.ShowDialog();

                        //dgvDetalle.Rows.Add("", form.detalle.CodProducto, form.detalle.Referencia, form.detalle.Descripcion, form.detalle.CodUnidad
                        //    , form.detalle.Unidad, form.detalle.SerieLote, form.detalle.Cantidad, form.detalle.PrecioUnitario, form.detalle.Importe
                        //    , form.detalle.Descuento1, form.detalle.Descuento2, form.detalle.Descuento3, form.detalle.MontoDescuento, form.detalle.ValorVenta
                        //    , form.detalle.Igv, form.detalle.PrecioVenta, form.detalle.PrecioReal, form.detalle.ValoReal);            
                    }
                }
                else { MessageBox.Show("No Puede Seguir Agregando más Detalles", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        }

        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleSeparacionVenta deta = new clsDetalleSeparacionVenta();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodSeparacion = Convert.ToInt32(sepa.CodSeparacion);
            deta.CodAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            
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
            
            
            detalle1.Add(deta);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Double totalsoles;
                if (Proceso != 0)
                {
                    sepa.CodAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
                    sepa.CodTipoTransaccion = tran.CodTransaccion;
                    sepa.CodCliente = Convert.ToInt32(txtCodigoCli.Text);
                    sepa.CodTipoDocumento = doc.CodTipoDocumento;

                    sepa.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);

                    sepa.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    sepa.FechaRegistro = dtpFecha.Value;

                    sepa.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    sepa.CodVendedor = Convert.ToInt32(cbovendedor.SelectedValue);
                    sepa.Comentario = txtComentario.Text;
                    sepa.Bruto = Convert.ToDecimal(txtBruto.Text);

                    sepa.MontoDescuento = Convert.ToDecimal(txtDscto.Text);
                    sepa.Igv = Convert.ToDecimal(txtIGV.Text);
                    sepa.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                    sepa.CodUsuario = frmLogin.iCodUser;

                    sepa.CodSerie = ser.CodSerie;
                    sepa.Serie = txtSerie.Text;
                    sepa.NumDocumento = txtNumero.Text;
                    if (dgvDetalle.Rows.Count > 0)
                    {
                        if (admSepa.insert(sepa))
                        {
                            RecorreDetalle();
                            if (detalle1.Count > 0)
                            {
                                foreach (clsDetalleSeparacionVenta det in detalle1)
                                {
                                    admSepa.InsertarDetalleSepa(det);
                                    if (det.CodDetalleSeparacion != 0)
                                    {
                                        btnGuardar.Enabled = false;
                                        MessageBox.Show("Los datos se guardaron correctamente", "Venta",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Verifique su Stock", "Venta",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los datos no se guardaron correctamente", "Venta",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Agregue Productos Para la venta", "Venta",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtTransaccion_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                txtTransaccion.Focus();
            }
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            Int32 codProducto = 0;
            if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
            {
                codProducto = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value.ToString());
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

        private void txtDocRef_KeyDown_1(object sender, KeyEventArgs e)
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
                        txtCodDocumento.Text = CodDocumento.ToString();
                        txtDocRef.Text = doc.Sigla;
                        if (CodDocumento != 0) { ProcessTabKey(true); }
                    
                }
            }
        }

    }
}