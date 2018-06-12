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
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmNotadeDebitoCompra : DevComponents.DotNetBar.Office2007Form
    {
        ClsNotasCreditoDebitoCompra ds = new ClsNotasCreditoDebitoCompra();
        //clsReporteNotaCredito ds = new clsReporteNotaCredito();
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        clsTransaccion tran = new clsTransaccion();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        clsAdmNotaIngreso AdmNota = new clsAdmNotaIngreso();
        clsNotaIngreso nota = new clsNotaIngreso();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida notaS = new clsNotaSalida();
        clsAdmAutorizado AdmAut = new clsAdmAutorizado();
        clsAutorizado aut = new clsAutorizado();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsValidar ok = new clsValidar();
        clsDetalleNotaIngreso detaSelec = new clsDetalleNotaIngreso();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmSerie AdmSerie = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsProducto pro = new clsProducto();
        clsConsultasExternas ext = new clsConsultasExternas();
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        public List<clsDetalleFactura> detallefact = new List<clsDetalleFactura>();
        public List<clsDetalleNotaSalida> detalleS = new List<clsDetalleNotaSalida>();
        public String CodNota;
        public Int32 CodNotaS;
        public Int32 CodNotaI;
        public Int32 CodTransaccion;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodOrdenCompra;
        public Int32 CodAutorizado;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Tipo;

        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsAdmFactura AdmFactura = new clsAdmFactura();
        clsFactura factur = new clsFactura();        
        DataTable dt1 = new DataTable();
        clsAdmFactura AdmFact = new clsAdmFactura();
        public Int32 CodFactura;
        public String DocRef;

        public frmNotadeDebitoCompra()
        {
            InitializeComponent();
        }

        private void frmNotadeDebitoCompra_Load(object sender, EventArgs e)
        {
            CargaMoneda();
            CargaFormaPagos();
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            if (Proceso == 1)
            {
                Bloqueabotones();
            }
            if (Proceso == 2)
            {
                CargaNotaSalida();

            }
            else if (Proceso == 3)
            { 
                CargaNotaSalida();
                sololectura(true);
            }
            else if (Proceso == 4)
            {
                CargaNotaSalida();
                sololectura(true);
            }
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            //Se agrego estas lineas
            cmbFormaPago.SelectedIndex = 0;            
            //Fin se agrego estas lineas
        }

        private void frmNotadeDebitoCompra_Shown(object sender, EventArgs e)
        {
            txtTransaccion.Focus();
            txtTransaccion.Text = "NDC";
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtTransaccion_KeyPress(txtTransaccion, ee);
            ser = AdmSerie.BuscaSeriexDocumento(6, frmLogin.iCodAlmacen);
            //txtSerie.Text = ser.Serie;
            //txtNumDoc.Text = ser.Numeracion.ToString().PadLeft(4, '0');
            cmbMotivo.Focus();
            if (txtOtros.Visible) { lblOtros.Visible = true; }
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

        private void txtTransaccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTransaccion.ReadOnly == false)
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
                        form.Proceso = 3;
                        form.ShowDialog();
                        tran = form.tran;
                        CodTransaccion = tran.CodTransaccion;
                        txtTransaccion.Text = tran.Sigla;
                        if (CodTransaccion != 0) { CargaTransaccion(); ProcessTabKey(true); } else { BorrarTransaccion(); }
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

        private void BorrarTransaccion()
        {
            txtTransaccion.Text = "";
            lbNombreTransaccion.Text = "";
            lbNombreTransaccion.Visible = false;
            foreach (Control t in groupBox1.Controls)
            {
                if (t.Tag != null)
                {                   
                    t.Visible = false;                    
                }
            }
        }

        private Boolean BuscaTransaccion()
        {
            tran = AdmTran.MuestraTransaccionS(txtTransaccion.Text, 0);
            if (tran != null)
            {
                CodTransaccion = tran.CodTransaccion;
                tran.Configuracion = AdmTran.MuestraConfiguracion(tran.CodTransaccion);
                txtTransaccion.Text = tran.Sigla;
                lbNombreTransaccion.Text = tran.Descripcion;
                lbNombreTransaccion.Visible = true;
                foreach (Control t in groupBox1.Controls)
                {
                    if (t.Tag != null)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtTransaccion.Text != "")
                {
                    if (BuscaTransaccion())
                    {                        
                        ProcessTabKey(true);
                        cmbMotivo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Codigo de transacción no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDetalleIngreso"] != null)
            {
                Application.OpenForms["frmDetalleIngreso"].Activate();
            }
            else
            {
                frmDetalleIngreso form = new frmDetalleIngreso();
                form.Procede = 7;
                form.Proceso = 1;
                form.bvalorventa = cbValorVenta.Checked;
                form.ShowDialog();
            }
        }

        private void VerificarCabecera()
        {
            if (CodTransaccion == 0 || CodDocumento == 0)
            {
                Validacion = false;
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDetalleIngreso"] != null)
            {
                Application.OpenForms["frmDetalleIngreso"].Activate();
            }
            else
            {
                frmDetalleIngreso form = new frmDetalleIngreso();
                //form.MdiParent = this;
                form.Procede = 7;
                form.Proceso = 1;
                form.bvalorventa = cbValorVenta.Checked;
                form.ShowDialog();
            }
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedValue = 1;
        }        

        private void sololectura(Boolean estado)
        {            
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;            
            cmbMoneda.Enabled = !estado;
            txtCodProveedor.ReadOnly = estado;
            txtDocRef.ReadOnly = !estado;  
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
            btnImprimir.Visible = estado;
            btnNuevaGuia.Visible = estado;
            txtTransaccion.Enabled = !estado;
            cmbMotivo.Enabled = !estado;
            txtCodProveedor.Enabled = !estado;
            txtComentario.Enabled = !estado;
            txtDocRef.Enabled = !estado;
            txtSerie.Enabled = !estado;
            txtNumDoc.Enabled = !estado;
            if (txtOtros.Visible) { txtOtros.Enabled = !estado; lblOtros.Visible = true; }
        }

        private void Bloqueabotones()
        {
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
                
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.Visible)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
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

        //private void CargaNotaSalidaND()
        //{
        //    try
        //    {
        //        notaS = AdmNotaS.CargaNotaSalida(CodNotaS);   
        //        if (notaS != null)
        //        {
        //            txtDocRef.Text = factur.DocumentoFactura;
        //            cmbMoneda.SelectedValue = notaS.Moneda;
        //            txtTipoCambio.Text = factur.TipoCambio.ToString();
        //            CargaDetalleNota();
        //        }
        //        else
        //        {
        //            MessageBox.Show("El documento solicitado no existe", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        private void CargaNotaSalida()
        {
            try
            {
                factur = AdmFact.CargaFactura(CodNotaS);
                if (factur != null)
                {
                    txtTransaccion.Text = factur.SiglaTransaccion;
                    cmbMotivo.SelectedItem = factur.Motivo;
                    if (cmbMotivo.SelectedIndex == -1) {
                        cmbMotivo.SelectedItem = "Otros";
                        lblOtros.Visible = true;
                        txtOtros.Visible = true;
                        txtOtros.Text = factur.Motivo;
                    }
                    String[] A = factur.DocumentoFactura.Split('-');
                    txtCodProveedor.Text = factur.RUCProveedor;
                    txtNombreProveedor.Text = factur.RazonSocialProveedor;
                    txtComentario.Text = factur.Comentario;
                    txtDocRef.Text = DocRef;
                    cmbMoneda.SelectedValue = factur.Moneda;
                    dtpFecha.Value = factur.FechaIngreso;
                    txtTipoCambio.Text = factur.TipoCambio.ToString();                    
                    CargaDetalleNotaS();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void CargaDetalleNotaS()
        {
            dt1.Clear();
            dt1 = AdmFact.CargaDetalle(CodNotaS);
            dgvDetalle.DataSource = dt1;
            dgvDetalle.Columns["stockdisponible"].Visible = false;
            dgvDetalle.Columns["maxPorcDescto"].Visible = false;
            CalculaTotales();
        }

        private void CargaDetalleNota()
        {
            dt1.Clear();
            if (cmbMotivo.SelectedIndex == 0)
            {
                //dt1 = AdmNotaS.CargaDetalleNotaSalidaNDC(CodNotaS, frmLogin.iCodAlmacen);
                dt1 = AdmFactura.CargaDetalle(Convert.ToInt32(factur.CodFactura));
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 1)
            {
                //BUSCAR CONCEPTO GASTOS FINANCIEROS
                dt1 = AdmPro.BuscarProducto(1516);
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 2)
            {
                //BUSCAR CONCEPTO INTERES COMPENSATORIOS
                dt1 = AdmPro.BuscarProducto(1519);
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 3)
            {
                //BUSCAR CONCEPTO INTERES MORATORIO
                dt1 = AdmPro.BuscarProducto(1520);
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 4)
            {
                //BUSCAR CONCEPTO ANULACION
                dt1 = AdmPro.BuscarProducto(1521);
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 5)
            {
                //BUSCAR CONCEPTO OTROS
                dt1 = AdmPro.BuscarProducto(1522);
                dgvDetalle.DataSource = dt1;
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                dgvDetalle.Columns["stockdisponible"].Visible = false;
                dgvDetalle.Columns["maxPorcDescto"].Visible = false;
                btnEliminar.Visible = false;
            }
            CalculaTotales();
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {
                CalculaTotales();
            }
        }

        private void CalculaTotales()
        {
            Double bruto = 0;
            Double descuen = 0;
            Double valor = 0;
            Double igvt = 0;
            Double preciot = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                bruto = bruto + Convert.ToDouble(row.Cells[importe.Name].Value);
                descuen = descuen + Convert.ToDouble(row.Cells[montodscto.Name].Value);
                valor = valor + Convert.ToDouble(row.Cells[valorventa.Name].Value);
                igvt = igvt + Convert.ToDouble(row.Cells[igv.Name].Value);
                preciot = preciot + Convert.ToDouble(row.Cells[precioventa.Name].Value);
            }
            txtBruto.Text = String.Format("{0:#,##0.00}", bruto);
            txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
            txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);
            txtIGV.Text = String.Format("{0:#,##0.00}", igvt);
            txtPrecioVenta.Text = String.Format("{0:#,##0.00}", preciot);
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                dtpFecha.Focus();
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
        }      

        private void txtNDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtTransaccion_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                txtTransaccion.Focus();
            }
            else if (CodTransaccion != 7)
            {
                cmbMotivo.Focus();
            }
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text != "")
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0 )
            {
                if (cmbMotivo.SelectedIndex==-1)
                {
                    MessageBox.Show("Por favor seleccionar un motivo!");
                    cmbMotivo.Focus();
                }
                else
                {
                    factur.CodAlmacen = frmLogin.iCodAlmacen;
                    factur.CodProveedor = prov.CodProveedor;
                    factur.CodTipoTransaccion = tran.CodTransaccion;
                    factur.CodTipoDocumento = 6; // CODIGO DOCUMENTO DE LA NOTA DEBITO COMPRAS 
                    factur.DocumentoFactura = "ND" + "-" + txtSerie.Text.PadLeft(4, '0') + "-" + txtNumDoc.Text.PadLeft(4, '0');
                    factur.CodSerie = ser.CodSerie;
                    factur.Serie = txtSerie.Text.PadLeft(4, '0');
                    factur.CodReferencia = CodFactura; // REFERENCIA A FACTURA ANTERIOR
                    factur.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    factur.FechaIngreso = dtpFecha.Value.Date;
                    factur.FormaPago = 0;
                    factur.Comentario = txtComentario.Text;
                    if (txtTipoCambio.Visible) { factur.TipoCambio = Convert.ToDouble(txtTipoCambio.Text); }
                    factur.MontoBruto = Convert.ToDouble(txtBruto.Text);
                    factur.MontoDscto = Convert.ToDouble(txtDscto.Text);
                    factur.Igv = Convert.ToDouble(txtIGV.Text);
                    factur.Total = Convert.ToDouble(txtPrecioVenta.Text);
                    factur.CodUser = frmLogin.iCodUser;
                    factur.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    factur.Motivo = cmbMotivo.SelectedItem.ToString();
                    factur.Cancelado = 0;
                    DocRef = txtDocRef.Text;
                    if (txtOtros.Visible){ factur.Motivo = txtOtros.Text; }
                    factur.Estado = 1;                                      
                    if (Proceso == 1)
                    {
                        if (factur.Total != 0)
                        {
                            if (txtSerie.Text != "" && txtNumDoc.Text != "")
                            {
                                if (AdmFactura.insert(factur))
                                {
                                    RecorreDetalleF();
                                    if (detallefact.Count > 0)
                                    {
                                        foreach (clsDetalleFactura det in detallefact)
                                        {
                                            AdmFact.insertdetalle(det);
                                        }
                                    }
                                    MessageBox.Show("Los datos se guardaron correctamente!", "Nota de Débito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvDetalle.Enabled = false;
                                    CodNotaS = factur.CodFacturaNueva;
                                    CargaNotaSalida();
                                    sololectura(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor ingrese Serie y Correlativo del Documento!", "Nota de Débito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtSerie.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El valor ingresado no es correcto!", "Nota de Debito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clsDetalleNotaIngreso deta = new clsDetalleNotaIngreso();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
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
            deta.FechaIngreso = dtpFecha.Value;
            deta.CodUser = frmLogin.iCodUser;
            detalle.Add(deta);
        }

        private void RecorreDetalleF()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalleF(row);
                }
            }
            //nota.Detalle = detalle;
        }

        private void añadedetalleF(DataGridViewRow fila)
        {
            clsDetalleFactura detafac = new clsDetalleFactura();
            detafac.CodFactura = factur.CodFacturaNueva;
            detafac.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            detafac.CodNotaIngreso = "0"; 
            detafac.CodAlmacen = frmLogin.iCodAlmacen;            
            detafac.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);           
            detafac.SerieLote = "0";
            detafac.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue.ToString());
            detafac.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);            
            detafac.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);            
            detafac.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);            
            detafac.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);           
            detafac.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);            
            detafac.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);            
            detafac.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);           
            detafac.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);           
            detafac.Flete = Convert.ToDouble(fila.Cells[flete.Name].Value);            
            detafac.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);           
            detafac.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);            
            detafac.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);       
            detafac.CodUser = frmLogin.iCodUser;
            detafac.CodProveedor = prov.CodProveedor;
            detallefact.Add(detafac);
        }

        private void CargaFilaDetalle(DataGridViewRow fila)
        {            
            detaSelec.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            detaSelec.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
            detaSelec.CodAlmacen = frmLogin.iCodAlmacen;
            detaSelec.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            detaSelec.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            detaSelec.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            detaSelec.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            detaSelec.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            detaSelec.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            detaSelec.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            detaSelec.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            detaSelec.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            detaSelec.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            detaSelec.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            detaSelec.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            detaSelec.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            detaSelec.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            detaSelec.FechaIngreso = dtpFecha.Value;
            detaSelec.CodUser = frmLogin.iCodUser;            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDetalle.SelectedRows[0];
                if (Application.OpenForms["frmDetalleIngreso"] != null)
                {
                    Application.OpenForms["frmDetalleIngreso"].Activate();
                }
                else
                {
                    frmDetalleIngreso form = new frmDetalleIngreso();
                    form.Proceso = 2;
                    form.Procede = 7;
                    form.bvalorventa = cbValorVenta.Checked;
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

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (!this.Visible)
                return;
            if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
            {
                CargaFilaDetalle(e.Row);
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            }
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                CalculaTotales();
            }
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = 7;   //MODIFICACION ALEX PARA QUE REGRESE
                    form.ShowDialog();
                    dt1.Clear();
                    dgvDetalle.DataSource = dt1;
                    if (CodProveedor != 0) { CargaProveedor(); txtDocRef.Focus(); } else { BorrarProveedor(); }
                }
            }
        }

        private void CargaProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtCodProveedor.Text = prov.Ruc;
            txtNombreProveedor.Text = prov.RazonSocial;
        }

        private void BorrarProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtCodProveedor.Text = "";
            txtNombreProveedor.Text = "";
        }

        private Boolean BuscaProveedor()
        {
            prov = AdmProv.BuscaProveedor(txtCodProveedor.Text);
            if (prov != null)
            {
                txtNombreProveedor.Text = prov.RazonSocial;
                CodProveedor = prov.CodProveedor;
                return true;
            }
            else
            {
                txtNombreProveedor.Text = "";
                CodProveedor = 0;
                return false;
            }
        }
        
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Double cantidad1, precio, bruto, montodescuento, valorventa1, igv1, precioventa1, precioreal1, valorreal, factorigv, dsc1, dsc2, dsc3, preunitario;
            try
            {

                if (dgvDetalle.Focused) //&& e.ColumnIndex == dgvDetalle.Columns[cantidad.Name].Index)
                {
                    pro = AdmPro.CargaProducto(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[codproducto.Name].Value), frmLogin.iCodAlmacen);
                    cantidad1 = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value);
                    precio = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);
                    bruto = cantidad1 * precio;
                    dsc1 = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[dscto1.Name].Value);
                    dsc2 = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[dscto2.Name].Value);
                    dsc3 = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[dscto3.Name].Value);
                    precioventa1 = bruto * (1 - (dsc1 / 100)) * (1 - (dsc2 / 100)) * (1 - (dsc3 / 100));
                    montodescuento = bruto - precioventa1;
                    if (pro.ConIgv)
                    {
                        //DEBE TOMAR EL DATO DE IGV DE LA CONFIGURACION DEL SISTEMA                        
                        factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                        valorventa1 = precioventa1 / factorigv;                        
                    }
                    else
                    {                       
                        valorventa1 = precioventa1;                                            
                    }
                    //precioreal1 = precioventa1 / cantidad1;
                    //valorreal = valorventa1 / cantidad1;
                    igv1 = precioventa1 - valorventa1;

                    dgvDetalle.CurrentRow.Cells[importe.Name].Value = bruto;
                    dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = montodescuento;
                    dgvDetalle.CurrentRow.Cells[valorventa.Name].Value = valorventa1;
                    dgvDetalle.CurrentRow.Cells[igv.Name].Value = igv1;
                    dgvDetalle.CurrentRow.Cells[precioventa.Name].Value = precioventa1;
                    //dgvDetalle.CurrentRow.Cells[precioreal.Name].Value = precioreal1;
                    //dgvDetalle.CurrentRow.Cells[valoreal.Name].Value = valorreal;
                    CalculaTotales();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ser = AdmSerie.MuestraSerie(factur.CodSerie, frmLogin.iCodAlmacen);
                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rd.Load("CRNotaDebito.rpt");
                CRNotaDebito rpt = new CRNotaDebito();
                rd.SetDataSource(ds.ReportNotaDebitoCompra(Convert.ToInt32(CodNotaS), frmLogin.iCodAlmacen));
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(1100, 1850, 200, 1300));
                //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                rd.PrintToPrinter(1, false, 1, 1);
                rd.Close();
                rd.Dispose();

                //CRNotaDebito rpt = new CRNotaDebito();
                //frmRptNotaCredito frm = new frmRptNotaCredito();
                //CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                //rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                //rpt.SetDataSource(ds.ReportNotaDebitoCompra(Convert.ToInt32(CodNotaS), frmLogin.iCodAlmacen).Tables[0]);
                //frm.crvNotaCredito.ReportSource = rpt;
                //frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema " + ex.Message, "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevaGuia_Click(object sender, EventArgs e)
        {
            frmNotadeDebitoCompra form2 = new frmNotadeDebitoCompra();
            form2.MdiParent = this.MdiParent;
            form2.Proceso = 1;
            form2.Show();
            this.Close();
        }

        private void cmbMotivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                CargaDetalleNota();
            }
            if (cmbMotivo.SelectedIndex == 0)
            {
                dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                lblOtros.Visible = false;
                txtOtros.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 1)
            {
                dgvDetalle.Columns[preciounit.Name].HeaderText = "Gasto";
                lblOtros.Visible = false;
                txtOtros.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 2 || cmbMotivo.SelectedIndex == 3)
            {
                dgvDetalle.Columns[preciounit.Name].HeaderText = "Interés";
                lblOtros.Visible = false;
                txtOtros.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 4)
            {
                dgvDetalle.Columns[preciounit.Name].HeaderText = "Valor";
                lblOtros.Visible = false;
                txtOtros.Visible = false;
            }
            else if (cmbMotivo.SelectedIndex == 5)
            {
                dgvDetalle.Columns[preciounit.Name].HeaderText = "Valor";
                lblOtros.Visible = true;
                txtOtros.Visible = true;
                txtOtros.Focus();
            }
        }
    
        private void CargaFacturaGrid()
        {
            try
            {
                factur = AdmFactura.CargaFactura(CodFactura);
                if (factur != null)
                {
                    txtDocRef.Text = factur.DocumentoFactura;
                    txtTipoCambio.Text = factur.TipoCambio.ToString();
                    cmbMoneda.SelectedValue = factur.Moneda;
                    CargaDetalleNota();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmListaFacturasPorProveedor"] != null)
                {
                    Application.OpenForms["frmListaFacturasPorProveedor"].Activate();
                }
                else
                {
                    frmListaFacturasPorProveedor form = new frmListaFacturasPorProveedor();
                    form.CodProveedor = CodProveedor;
                    form.tipo = 2;
                    form.ShowDialog();
                    if (form.factura != null && form.factura.CodFactura != 0) { factur = form.factura; CodFactura = Convert.ToInt32(factur.CodFactura); } else { }
                    if (CodFactura != 0) { CargaFacturaGrid(); txtComentario.Focus(); }
                }
            }          
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        
    }
}
