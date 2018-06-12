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
    public partial class frmNotadeCredito : DevComponents.DotNetBar.Office2007Form
    {
        //clsReporteNotaCredito ds = new clsReporteNotaCredito();
        clsNotasCreditoDebitoVenta ds = new clsNotasCreditoDebitoVenta();
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
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida notaS = new clsNotaSalida();
        clsAdmNotaIngreso AdmNota = new clsAdmNotaIngreso();
        clsNotaIngreso nota = new clsNotaIngreso();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsFacturaVenta venta = new clsFacturaVenta();
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
        clsNotaCredito notc = new clsNotaCredito();
        clsAdmNotaCredito AdmFact = new clsAdmNotaCredito();
        clsAdmSerie Admser = new clsAdmSerie();
        clsPago pag = new clsPago();

        public List<Int32> config = new List<Int32>();
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        public List<clsDetalleNotaCredito> detalleNotaCredito = new List<clsDetalleNotaCredito>();
        public String CodNota;
        public Int32 CodNotaS;
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

        //CODIGO NUEVO
        Int32 cantprod = 0;
        Decimal precprod = 0;
        private TextBox txtedit = new TextBox();
        List<Int32> cantpr = new List<Int32>();
        List<Decimal> cantprec = new List<Decimal>();
        public Int32 CodSerie, CodSerieG = 0, numG = 0, manual = 0;
        DataTable dtPagos = new DataTable();
        public Decimal montogratuitas, montogravadas, montoexoneradas, montoinafectas = 0;
        SIGEFA.SunatFacElec.Conexion con = new SIGEFA.SunatFacElec.Conexion();

        clsAdmPago admPago = new clsAdmPago();


        public frmNotadeCredito()
        {
            InitializeComponent();
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
            doc = Admdoc.BuscaTipoDocumento(txtDocRefe.Text);
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
                //form.MdiParent = this;
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
            try
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
            catch (Exception ex)
            {
            }
        }

        private void frmNotaIngreso_Load(object sender, EventArgs e)
        {
                        
            CargaMoneda();
            CargaFormaPagos();
            cargatipoNC();
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            if (Proceso == 1)
            {
                Bloqueabotones();
            }
            if (Proceso == 2)
            {
                CargaNotaCredito();
            }
            else if (Proceso == 3)
            {
                CargaNotaCredito();
                sololectura(true);
            }
            else if (Proceso == 4)
            {
                CargaNotaCredito();
                sololectura(true);
            }
        }

        private void cargatipoNC()
        {
            cmbMotivo.DataSource = AdmPro.MuestratipoNC();
            cmbMotivo.DisplayMember = "denominacion";
            cmbMotivo.ValueMember = "codigosunat";
            cmbMotivo.SelectedIndex = -1;
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(0);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;

        }

        private void sololectura(Boolean estado)
        {
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;
            cmbMoneda.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            txtCodCliente.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtSerie.Enabled = !estado;
            cmbMovimiento.Enabled = !estado;
            txtDocRef.Enabled = !estado;
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
            cmbMotivo.Enabled = !estado;
            cbAplicada.Enabled = !estado;
        }

        private void Bloqueabotones()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void CargaNotaCredito()
        {
            try
            { 
                notc = AdmFact.CargaNotaCredito(Convert.ToInt32(CodNota));
                ser = AdmSerie.MuestraSerie(notc.CodSerie, frmLogin.iCodAlmacen);
                if (notc != null)
                {
                    if (notc.CodReferencia != 0) { notaS = AdmNotaS.CargaNotaSalidaCreditoVentas(Convert.ToInt32(notc.CodReferencia)); }
                    txtNumDoc.Text = notc.CodNotaCredito.ToString();
                    CodTransaccion = notc.CodTipoTransaccion;
                    CargaTransaccion();

                    CodCliente = notaS.CodCliente;
                    CargaCliente();
                    cmbFormaPago.SelectedValue = notc.FormaPago;
                    dtpFecha.Value = notc.FechaIngreso;
                    cmbMoneda.SelectedValue = notc.Moneda;
                    txtTipoCambio.Text = notc.TipoCambio.ToString();
                    txtComentario.Text = notc.Comentario.ToString();
                    //cbAplicada.Checked = Convert.ToBoolean(notc.Aplicada);
                    txtComentario.Text = notc.Comentario;
                    cmbMotivo.SelectedIndex = Convert.ToInt32(notc.Motivo.ToString());
                    cmbMovimiento.SelectedIndex = Convert.ToInt32(notc.MovimientoNC.ToString());
                    txtSerie.Text = notc.Serie;
                    txtNumero.Text = notc.DocumentoNotaCredito;
                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = notc.CodTipoDocumento;
                        txtDocRef.Text = notaS.SiglaDocumento + " " + notaS.Serie + " " + notaS.NumDoc;
                    }
                    txtBruto.Text = String.Format("{0:#,##0.00}", notc.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", notc.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", notc.Total - notc.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", notc.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", notc.Total);
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

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmFact.CargaDetalle(Convert.ToInt32(notc.CodNotaCredito));
            RecorreDetalle();
            nota.Detalle = detalle;
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



        private void frmNotaIngreso_Shown(object sender, EventArgs e)
        {
            txtTransaccion.Focus();
            txtTransaccion.Text = "NCV";
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtTransaccion_KeyPress(txtTransaccion, ee);
            txtDocRefe.Text = "NC";
            KeyPressEventArgs ee1 = new KeyPressEventArgs((char)Keys.Return);
            txtDocRefe_Leave(txtDocRefe, ee1);

            ser = AdmSerie.BuscaSeriexDocumento(4, frmLogin.iCodAlmacen);
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
                        txtTipoCambio.Text = tc.Venta.ToString();
                    }
                }
            }
        }

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmListaDocumentosPorCliente"] != null)
                {
                    Application.OpenForms["frmListaDocumentosPorCliente"].Activate();
                }
                else
                {
                    frmListaDocumentosPorCliente form = new frmListaDocumentosPorCliente();
                    form.Text = "Documentos";
                    form.tipo = 1;
                    form.CodCliente = cli.CodCliente;
                    form.ShowDialog();
                    if (form.venta != null && form.venta.CodFacturaVenta != "") { venta = form.venta; CodNotaS = Convert.ToInt32(venta.CodFacturaVenta); } else { }
                    if (CodNotaS != 0) { CargaNotaSalida(); ProcessTabKey(true); }
                }
            }
        }

        private void CargaNotaSalida()
        {
            try
            {
                venta = AdmVenta.CargaFacturaVenta(CodNotaS);
                if (venta != null)
                {
                    txtDocRef.Text = venta.SiglaDocumento + " - " + venta.Serie + " - " + venta.NumDoc;
                    txtTipoCambio.Text = venta.TipoCambio.ToString();
                    cmbMoneda.SelectedValue = venta.Moneda;
                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = venta.CodCliente;
                        cli = AdmCli.MuestraCliente(CodCliente);
                        //txtCodCliente.Text = cli.RucDni;
                        txtNombreCliente.Text = cli.Nombre;
                    }

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

        private void BorrarNota()
        {
            try
            {
                CodNotaS = 0;
                notaS = new clsNotaSalida();
                txtDocRef.Text = "";

                DataTable dt = (DataTable)dgvDetalle.DataSource;
                dt.Clear();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaDetalleNota()
        {
            dgvDetalle.DataSource = AdmVenta.CargaDetalleVentaCredito(CodNotaS, frmLogin.iCodAlmacen);          
            dgvDetalle.Columns["stockdisponible"].Visible = false;
            dgvDetalle.Columns["maxPorcDescto"].Visible = false;
            if (dgvDetalle.Rows.Count > 0)
            {
                cantpr = new List<Int32>();
                cantprec = new List<Decimal>();
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    cantpr.Add(Convert.ToInt32(row.Cells[cantidad.Name].Value));
                    cantprec.Add(Convert.ToDecimal(row.Cells[preciounit.Name].Value));
                }
            }
        }

        

        private void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            bool x = false;
            bool y = false;

            if (Proceso != 0)
            {
                if (txtNumero.Text != "")
                {
                    if (cmbMotivo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor seleccionar un motivo!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMotivo.Focus();
                    }
                    else if (cmbMovimiento.SelectedIndex == -1 && cmbMotivo.SelectedIndex != 1)
                    {
                        MessageBox.Show("Por favor seleccionar un movimiento!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMovimiento.Focus();
                    }
                    else
                    {
                        if (dgvDetalle.Rows.Count > 0)
                        {
                            this.cargarTotalesSunat();
                            //************************************* NOTA CREDITO ************************************
                            notc.CodAlmacen = frmLogin.iCodAlmacen;
                            notc.CodTipoTransaccion = tran.CodTransaccion;
                            notc.CodTipoDocumento = 4;
                            notc.DocumentoNotaCredito = txtNumero.Text;//doc.Sigla + "-" +txtSerie.Text+"-"+txtNumero.Text;
                            notc.NumFac = txtNumero.Text.ToString();
                            notc.FechaIngreso = dtpFecha.Value.Date;
                            notc.Cancelado = 0;
                            notc.Comentario = txtComentario.Text;
                            notc.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            notc.MontoBruto = Convert.ToDouble(txtValorVenta.Text);
                            notc.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            notc.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                            notc.Igv = Convert.ToDouble(txtIGV.Text);
                            notc.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            notc.Estado = 1;
                            notc.CodUser = frmLogin.iCodUser;
                            notc.CodSerie = CodSerie;
                            notc.Serie = txtSerie.Text;
                            notc.CodReferencia = Convert.ToInt32(venta.CodFacturaVenta);
                            notc.CodCliente = CodCliente;
                            notc.Motivo = cmbMotivo.SelectedValue.ToString();
                            if (cmbMotivo.SelectedIndex == 1)
                            {
                                notc.MovimientoNC = 0;
                            }
                            {
                                notc.MovimientoNC = Convert.ToInt32(cmbMovimiento.SelectedIndex);
                            }
                            notc.FormaPago = venta.FormaPago;
                            notc.FechaPago = venta.FechaPago;

                            notc.Gratuitas = montogratuitas;
                            notc.Exoneradas = montoexoneradas;
                            notc.Gravadas = montogravadas;
                            notc.Inafectas = montoinafectas;
                            notc.Tipofacturacion = venta.Tipoventa;
                            //-********************************************************************* NOTA INGRESO ****************************
                            nota.CodAlmacen = frmLogin.iCodAlmacen;
                            nota.NumDoc = txtNumero.Text;
                            nota.CodTipoTransaccion = tran.CodTransaccion;
                            nota.CodTipoDocumento = 4; // DOCUMENTO NC
                            nota.CodSerie = ser.CodSerie;
                            nota.Serie = ser.Serie;
                            if (CodNotaS != 0) { nota.CodReferencia = CodNotaS; }
                            nota.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            nota.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                            nota.FechaIngreso = dtpFecha.Value.Date;
                            if (fpago.Dias == 0)
                            {
                                nota.FechaCancelado = dtpFecha.Value.Date;
                                nota.Cancelado = 1;// Para saber si la nota esta pendiente de pago o esta cancelada
                            }
                            nota.Aplicada = 0;
                            if (cbAplicada.Checked)
                            {
                                nota.Aplicada = 1;
                                nota.CodAplicada = nota.CodReferencia;
                            }
                            nota.FormaPago = 0;
                            nota.Motivo = cmbMotivo.SelectedValue.ToString();

                            nota.MontoBruto = Convert.ToDouble(txtValorVenta.Text);
                            nota.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            nota.Igv = Convert.ToDouble(txtIGV.Text);
                            nota.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            nota.CodUser = frmLogin.iCodUser;
                            nota.Estado = 1;// Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas
                            //nota.Comentario = "";

                            if (cmbMotivo.SelectedIndex == 1)
                            {
                                nota.MovimientoNC = 0;
                            }
                            {
                                nota.MovimientoNC = Convert.ToInt32(cmbMovimiento.SelectedIndex);
                            }
                            if (Proceso == 1)
                            {
                                if (nota.Total != 0)
                                {
                                    AdmNota.VerificarNCVentaAplicada(nota);
                                    if (!nota.Comentario.Equals("0"))
                                    {
                                        DialogResult dlgResult = MessageBox.Show(nota.Comentario, "Nota Crédito Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dlgResult == DialogResult.Yes)
                                        {
                                            nota.Aplicada = 0;
                                            nota.Comentario = txtComentario.Text;
                                            if (Convert.ToString(cmbMotivo.SelectedValue) == "04" || Convert.ToString(cmbMotivo.SelectedValue) == "05"
                                                || Convert.ToString(cmbMotivo.SelectedValue) == "09")//***** SOLO INGRESO DE NOTA DE CREDITO - SIN DEVOLUCION DE PRODUCTOS*
                                            {
                                                notc.CodNotaIngreso = 0;
                                                if (AdmFact.insert(notc))
                                                {
                                                    RecorreDetalle();
                                                    if (detalleNotaCredito.Count > 0)
                                                    {
                                                        foreach (clsDetalleNotaCredito det in detalleNotaCredito)
                                                        {
                                                            if (Convert.ToString(cmbMotivo.SelectedValue) == "04")
                                                            {
                                                                det.CodNotaIngreso = "0";
                                                            }
                                                            AdmFact.insertdetalle(det);
                                                        }
                                                    }
                                                    MessageBox.Show("Los datos se guardaron correctamente", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    CodNota = notc.CodNotaCreditoNueva.ToString();
                                                    con.GeneraXML_NC(cli, notc, detalleNotaCredito);
                                                    dtPagos = admPago.GetPagosVenta(frmLogin.iCodAlmacen, Convert.ToInt32(venta.CodFacturaVenta));
                                                    pag = admPago.MuestraPagoVenta(frmLogin.iCodAlmacen, Convert.ToInt32(venta.CodFacturaVenta));

                                                    if (!AdmVenta.ValidaAnulacionVenta(Convert.ToInt32(venta.CodFacturaVenta)))
                                                    {
                                                        if (AdmVenta.anular(Convert.ToInt32(venta.CodFacturaVenta)))
                                                        {
                                                            MessageBox.Show("El documento ha sido anulado correctamente", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                            foreach (DataRow fila in dtPagos.Rows)
                                                            {
                                                                admPago.AnularPago(Convert.ToInt32(fila[0]));
                                                            }
                                                            //CargaLista();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("La Venta ya esta Anulada", "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);// para Information
                                                    }

                                                    x = AdmFact.actualizarCodNotaCreditoFV(Convert.ToInt32(venta.CodFacturaVenta), Convert.ToInt32(CodNota));
                                                    AdmFact.anularFactura_venta(Convert.ToInt32(venta.CodFacturaVenta));
                                                    
                                                   /* if (dgvDetalle.Rows.Count > 0)
                                                    {
                                                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                                                        {
                                                            //añadedetalle(row);
                                                            y = AdmFact.actualizarStockNotaCredito(Convert.ToInt32(row.Cells[codproducto.Name].Value.ToString()), Convert.ToInt32(row.Cells[cantidad.Name].Value.ToString()));
                                                        }
                                                    }

                                                    if (!x || !y)
                                                    {

                                                        MessageBox.Show("Error en la actualización de stock", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }


                                                    CargaNotaCredito();*/
                                                    sololectura(true);
                                                }
                                            }
                                            else//**** DEVOLUCION DE PRODUCTOS - NOTA INGRESO Y NOTA DE CREDITO
                                            {
                                                if (AdmNota.insert(nota))
                                                {
                                                    notc.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                                                    AdmFact.insert(notc);
                                                    //********************** ANULACION DE LA FACTURA *******************************
                                                    /*AdmFact.anularFactura_venta(Convert.ToInt32(venta.CodFacturaVenta));*/
                                                    RecorreDetalle();
                                                    if (detalle.Count > 0)
                                                    {
                                                        foreach (clsDetalleNotaIngreso det in detalle)
                                                        {
                                                            AdmNota.insertdetalle(det);
                                                        }
                                                    }
                                                    if (detalleNotaCredito.Count > 0)
                                                    {
                                                        foreach (clsDetalleNotaCredito det in detalleNotaCredito)
                                                        {
                                                            AdmFact.insertdetalle(det);
                                                        }
                                                    }
                                                    MessageBox.Show("Los datos se guardaron correctamente", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    CodNota = notc.CodNotaCreditoNueva.ToString();
                                                    con.GeneraXML_NC(cli, notc, detalleNotaCredito);
                                                    dtPagos = admPago.GetPagosVenta(frmLogin.iCodAlmacen, Convert.ToInt32(venta.CodFacturaVenta));
                                                    pag = admPago.MuestraPagoVenta(frmLogin.iCodAlmacen, Convert.ToInt32(venta.CodFacturaVenta));

                                                    if (!AdmVenta.ValidaAnulacionVenta(Convert.ToInt32(venta.CodFacturaVenta)))
                                                    {
                                                        if (AdmVenta.anular(Convert.ToInt32(venta.CodFacturaVenta)))
                                                        {
                                                            //MessageBox.Show("El documento ha sido anulado correctamente", "Ventas",MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                            foreach (DataRow fila in dtPagos.Rows)
                                                            {
                                                                admPago.AnularPago(Convert.ToInt32(fila[0]));
                                                            }
                                                            //CargaLista();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("La Venta ya esta Anulada", "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);// para Information
                                                    }

                                                    x = AdmFact.actualizarCodNotaCreditoFV(Convert.ToInt32(venta.CodFacturaVenta),Convert.ToInt32( CodNota));
                                                    AdmFact.anularFactura_venta(Convert.ToInt32(venta.CodFacturaVenta));

                                                   /* if (dgvDetalle.Rows.Count > 0)
                                                    {
                                                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                                                        {
                                                            //añadedetalle(row);
                                                            y = AdmFact.actualizarStockNotaCredito(Convert.ToInt32(row.Cells[codproducto.Name].Value.ToString()), Convert.ToDouble(row.Cells[cantidad.Name].Value.ToString()));
                                                        }
                                                    }


                                                    if (!x || !y) {

                                                        MessageBox.Show("Error en la actualización de stock", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }

                                                    CargaNotaCredito();*/
                                                    sololectura(true);
                                                }
                                            }
                                        }
                                    }
                                }
                                else { MessageBox.Show("Ingrese valor correctamente!", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                        }
                        else
                        {
                            //CargaNotaSalida();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese numero de Nota Credito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cargarTotalesSunat()
        {
            montogratuitas = 0;
            montogravadas = 0;
            montoexoneradas = 0;
            montoinafectas = 0;
            if (dgvDetalle.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "10" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "11" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "12" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "13" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "14" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "15" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "16" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "17")   // gravadas
                    {
                        montogravadas = montogravadas + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                    }

                    if (Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "20") // exoneradas
                    {
                        montoexoneradas = montoexoneradas + (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                    }

                    if (Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "30" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "31" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "32" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "33" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "34" || Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "35" ||
                        Convert.ToString(row.Cells[tipoimpuesto.Name].Value) == "36") // inafectas
                    {
                        montoinafectas = montoinafectas + (Convert.ToDecimal(row.Cells[preciounit.Name].Value) * Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                    }
                }
            }
            else
            {
                montogratuitas = 0m;
                montoexoneradas = 0m;
                montogravadas = 0m;
                montoinafectas = 0m;
            }
        }

        private void RecorreDetalle()
        {
            detalle.Clear();
            detalleNotaCredito.Clear();
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
            clsDetalleNotaIngreso deta = new clsDetalleNotaIngreso();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            //deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[valorventa.Name].Value);
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

            clsDetalleNotaCredito detafac = new clsDetalleNotaCredito();
            detafac.CodNotaCredito = notc.CodNotaCreditoNueva;           
            detafac.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);            
            detafac.CodNotaIngreso = nota.CodNotaIngreso;            
            detafac.CodAlmacen = frmLogin.iCodAlmacen;            
            detafac.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);            
            detafac.SerieLote = "0";            
            detafac.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);           
            detafac.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);            
            detafac.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);            
            detafac.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);           
            detafac.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);           
            detafac.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);            
            detafac.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);            
            detafac.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);                      
            detafac.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);            
            detafac.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);            
            detafac.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);            
            detafac.FechaIngreso = dtpFecha.Value;
            detafac.DescripcionNC = Convert.ToString(fila.Cells[descripcion.Name].Value);
            detafac.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);        
            detafac.CodUser = frmLogin.iCodUser;
            detafac.TipoImpuesto = fila.Cells[tipoimpuesto.Name].Value.ToString();
            detalleNotaCredito.Add(detafac);
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
                if (dgvDetalle.Rows.Count > 0)
                {
                    cantpr = new List<Int32>();
                    cantprec = new List<Decimal>();
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        cantpr.Add(Convert.ToInt32(row.Cells[cantidad.Name].Value));
                        cantprec.Add(Convert.ToDecimal(row.Cells[preciounit.Name].Value));
                    }
                }
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
                    if (CodCliente != 0) { CargaCliente(); BorrarNota(); ProcessTabKey(true); }
                }
            }
        }

        private void CargaCliente()
        {
            cli = AdmCli.MuestraCliente(CodCliente);
            if (cli != null)
            {
                txtCodCliente.Text = cli.CodigoPersonalizado;
                txtNombreCliente.Text = cli.RazonSocial;
                txtDireccionCliente.Text = cli.DireccionLegal;
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ok.enteros(e);
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

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtCodCliente.Text, Tipo);
            if (cli != null)
            {
                txtCodCliente.Text = cli.CodigoPersonalizado;
                txtNombreCliente.Text = cli.RazonSocial;
                CodCliente = cli.CodCliente;
                return true;
            }
            else
            {
                txtNombreCliente.Text = "";
                CodCliente = 0;
                return false;
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (CodCliente == 0)
            {
                txtCodCliente.Focus();
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           /* Double cantidad1, precio, bruto, montodescuento, valorventa1, igv1, precioventa1, precioreal1, valorreal, factorigv, dsc1, dsc2, dsc3, preunitario;
            try
            {
                if (cmbMotivo.SelectedIndex == 0 || cmbMotivo.SelectedIndex == 3)
                {
                    if (cantprod < Convert.ToInt32(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value))
                    {
                        MessageBox.Show("La cantidad del producto debe ser menor", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDetalle.CurrentRow.Cells[cantidad.Name].Value = Convert.ToString(cantprod);
                    }
                }

                else if (cmbMotivo.SelectedIndex == 2)
                {
                    if (precprod < Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value))
                    {
                        MessageBox.Show("El precio descuento debe ser menor", "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].Value = Convert.ToString(precprod);
                    }
                }
                //if (dgvDetalle.Focused && e.ColumnIndex == dgvDetalle.Columns[cantidad.Name].Index)
                if (dgvDetalle.Focused)
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
            }*/


            try
            {
                Double igvsis = 0, impor = 0, imptotal = 0, cant = 0, preuni = 0, valorven = 0, igvT = 0;
                if (Convert.ToString(cmbMotivo.SelectedValue) == "04")//descuento
                {
                    DataGridViewRow row = dgvDetalle.Rows[e.RowIndex];
                    impor = Convert.ToDouble(row.Cells[importe.Name].Value);
                    if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[tipoimpuesto.Name].Value) == 10)
                    {
                        igvsis = frmLogin.Configuracion.IGV;
                        imptotal = impor / (1 + igvsis / 100);
                    }
                    else
                    {
                        imptotal = impor;
                    }
                    row.Cells[valorventa.Name].Value = imptotal;
                    row.Cells[igv.Name].Value = impor - imptotal;
                    row.Cells[precioventa.Name].Value = impor;
                }
                else if (Convert.ToString(cmbMotivo.SelectedValue) == "05" || Convert.ToString(cmbMotivo.SelectedValue) == "07" ||
                        Convert.ToString(cmbMotivo.SelectedValue) == "09")//devolucion
                {
                    DataGridViewRow row = dgvDetalle.Rows[e.RowIndex];
                    cant = Convert.ToInt32(row.Cells[cantidad.Name].Value);
                    preuni = Convert.ToDouble(row.Cells[preciounit.Name].Value);
                    impor = cant * preuni;
                    row.Cells[importe.Name].Value = impor;
                    if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[tipoimpuesto.Name].Value) == 10)
                    {
                        igvsis = frmLogin.Configuracion.IGV;
                        valorven = impor / (1 + igvsis / 100);
                    }
                    else
                    {
                        valorven = impor;
                    }
                    igvT = impor - valorven;
                    row.Cells[valorventa.Name].Value = impor - igvT;
                    row.Cells[igv.Name].Value = igvT;
                    row.Cells[precioventa.Name].Value = impor;
                }
                this.CalculaTotales();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ser = AdmSerie.MuestraSerie(nota.CodSerie, frmLogin.iCodAlmacen);
                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rd.Load("CRNotaCreditoVenta.rpt");
                CRNotaCreditoVenta rpt = new CRNotaCreditoVenta();
                rd.SetDataSource(ds.ReportNotaCreditoVenta(Convert.ToInt32(nota.CodNotaIngreso), frmLogin.iCodAlmacen));
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(530, 2900, 70, 500));
                //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                rd.PrintToPrinter(1, false, 1, 1);
                rd.Close();
                rd.Dispose();


                //CRNotaCreditoVenta rpt = new CRNotaCreditoVenta();
                //frmRptNotaCredito frm = new frmRptNotaCredito();
                //rpt.SetDataSource(ds.ReportNotaCreditoVenta(Convert.ToInt32(nota.CodNotaIngreso), frmLogin.iCodAlmacen).Tables[0]);
                //CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                //rptoption.PrinterName = ser.NombreImpresora;//Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]);
                //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(530, 2900, 70, 500));
                //frm.crvNotaCredito.ReportSource = rpt;
                //frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevaGuia_Click(object sender, EventArgs e)
        {
            frmNotadeCredito form2 = new frmNotadeCredito();
            form2.MdiParent = this.MdiParent;
            form2.Proceso = 1;
            form2.Show();
            this.Close();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvDetalle.Rows.Count > 0)
            {
                if (Proceso != 3)
                {
                    if (cmbMotivo.SelectedIndex == 1)
                    {
                        dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true;
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                    }
                }

                Int32 fila = dgvDetalle.CurrentRow.Index;
                cantprod = cantpr[fila];
                precprod = cantprec[fila];
            }*/

            if (dgvDetalle.Rows.Count > 0)
            {
                if (Proceso != 3)
                {
                    if (Convert.ToString(cmbMotivo.SelectedValue) != "05" && Convert.ToString(cmbMotivo.SelectedValue) != "07" && Convert.ToString(cmbMotivo.SelectedValue) != "09")
                    {
                        dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true;
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                    }
                    Int32 fila = dgvDetalle.CurrentRow.Index;
                    cantprod = cantpr[fila];
                    precprod = cantprec[fila];
                }
            }
        }

        private void cmbMotivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*if (dgvDetalle.Rows.Count > 0)
            {
                if (cmbMotivo.SelectedIndex == 0 || cmbMotivo.SelectedIndex == 3)
                {
                    dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                    dgvDetalle.Columns["cantidad"].ReadOnly = false;
                    dgvDetalle.Columns["preciounit"].ReadOnly = true;
                    btnEliminar.Visible = true;
                }
                else if (cmbMotivo.SelectedIndex == 2)
                {
                    dgvDetalle.Columns[preciounit.Name].HeaderText = "Descuento";
                    dgvDetalle.Columns["cantidad"].ReadOnly = true;
                    dgvDetalle.Columns["preciounit"].ReadOnly = false;
                    btnEliminar.Visible = true;
                }
                else if (cmbMotivo.SelectedIndex == 1)
                {
                    dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                    dgvDetalle.Columns["cantidad"].ReadOnly = true;
                    dgvDetalle.Columns["preciounit"].ReadOnly = true;
                    btnEliminar.Visible = false;
                }
                CargaNotaSalida(); 
            }
            */


            if (dgvDetalle.Rows.Count > 0)
            {
                if (Convert.ToString(cmbMotivo.SelectedValue) == "05" || Convert.ToString(cmbMotivo.SelectedValue) == "07" ||
                    Convert.ToString(cmbMotivo.SelectedValue) == "09")  //devolucion de producto
                {
                    if (Convert.ToString(cmbMotivo.SelectedValue) == "07")
                    {
                        dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                        dgvDetalle.Columns[preciounit.Name].ReadOnly = true;
                        dgvDetalle.Columns[preciounit.Name].DefaultCellStyle.BackColor = Color.White;
                        dgvDetalle.Columns[cantidad.Name].DefaultCellStyle.BackColor = Color.PeachPuff;
                        dgvDetalle.Columns[cantidad.Name].ReadOnly = false;
                        dgvDetalle.Columns[importe.Name].DefaultCellStyle.BackColor = Color.White;
                        dgvDetalle.Columns[descripcion.Name].ReadOnly = true;
                        dgvDetalle.Columns[cantidad.Name].ReadOnly = true;
                    }
                    else
                    {
                        dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                        dgvDetalle.Columns[preciounit.Name].ReadOnly = false;
                        dgvDetalle.Columns[preciounit.Name].DefaultCellStyle.BackColor = Color.PeachPuff;
                        dgvDetalle.Columns[cantidad.Name].DefaultCellStyle.BackColor = Color.White;
                        dgvDetalle.Columns[importe.Name].DefaultCellStyle.BackColor = Color.White;
                        dgvDetalle.Columns[descripcion.Name].ReadOnly = true;
                        dgvDetalle.Columns[cantidad.Name].ReadOnly = true;
                    }
                    btnEliminar.Visible = false;
                    cmbMovimiento.Visible = true;

                    txtComentario.Text = cmbMotivo.GetItemText(cmbMotivo.SelectedItem);

                    dgvDetalle.Columns["unidad"].Visible = true;
                    dgvDetalle.Columns["cantidad"].Visible = true;
                    dgvDetalle.Columns["preciounit"].Visible = true;

                    btnEliminar.Visible = true;
                }
                else if (Convert.ToString(cmbMotivo.SelectedValue) == "04")  //descuento 
                {
                    try
                    {
                        DataTable dt = (DataTable)dgvDetalle.DataSource;
                        dt.Clear();
                        //dt.Rows.Add(0, 0, 0, "Descuento", 0, "",
                        //            "", "0", Convert.ToDouble(0), Convert.ToDouble(0), 0, 0, 0, 0, 0, 0, 0, 0, 0.00, 0, 0, "10");
                        dt.Rows.Add(0, 0, "00", "DESCUENTO GLOBAL", 0, "", "", "0", Convert.ToDouble(0), Convert.ToDouble(0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, frmLogin.iCodUser, DateTime.Now, "10");
                        dgvDetalle.DataSource = dt;
                        dgvDetalle.Columns[importe.Name].DefaultCellStyle.BackColor = Color.PeachPuff;
                        dgvDetalle.Columns["unidad"].Visible = false;
                        dgvDetalle.Columns["cantidad"].Visible = false;
                        dgvDetalle.Columns["importe"].ReadOnly = false;
                        dgvDetalle.Columns["preciounit"].Visible = false;

                        txtComentario.Text = cmbMotivo.GetItemText(cmbMotivo.SelectedItem);

                        btnEliminar.Visible = false;
                        cmbMovimiento.Visible = true;
                        dgvDetalle.ClearSelection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (Convert.ToString(cmbMotivo.SelectedValue) == "01" || Convert.ToString(cmbMotivo.SelectedValue) == "02" ||
                         Convert.ToString(cmbMotivo.SelectedValue) == "08" || Convert.ToString(cmbMotivo.SelectedValue) == "10" ||
                         Convert.ToString(cmbMotivo.SelectedValue) == "06" || Convert.ToString(cmbMotivo.SelectedValue) == "03")//  anulacion de operacion
                {
                    dgvDetalle.Columns[preciounit.Name].HeaderText = "P. Unit.";
                    dgvDetalle.Columns[cantidad.Name].DefaultCellStyle.BackColor = Color.White;
                    dgvDetalle.Columns[descripcion.Name].DefaultCellStyle.BackColor = Color.White;
                    dgvDetalle.Columns[importe.Name].DefaultCellStyle.BackColor = Color.White;
                    dgvDetalle.Columns[preciounit.Name].DefaultCellStyle.BackColor = Color.White;
                    dgvDetalle.Columns["descripcion"].ReadOnly = true;
                    dgvDetalle.Columns["importe"].ReadOnly = true;
                    btnEliminar.Visible = false;
                    cmbMovimiento.Visible = true;

                    txtComentario.Text = cmbMotivo.GetItemText(cmbMotivo.SelectedItem);

                    dgvDetalle.Columns["unidad"].Visible = true;
                    dgvDetalle.Columns["cantidad"].Visible = true;
                    dgvDetalle.Columns["preciounit"].Visible = true;
                }
                if (Convert.ToString(cmbMotivo.SelectedValue) != "04")
                {
                    CargaNotaSalida();
                }
            }

        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtedit = e.Control as TextBox;
            if (txtedit != null)
            {
                txtedit.KeyPress -= new KeyPressEventHandler(dgvDetalle_KeyPress);
                txtedit.KeyPress += new KeyPressEventHandler(dgvDetalle_KeyPress);
                txtedit.KeyUp -= new KeyEventHandler(dgvDetalle_KeyUp);
                txtedit.KeyUp += new KeyEventHandler(dgvDetalle_KeyUp);
                txtedit.Leave -= new EventHandler(dgvDetalle_Leave);
                txtedit.Leave += new EventHandler(dgvDetalle_Leave);
            }
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 10 || dgvDetalle.CurrentCell.ColumnIndex == 11)
            {
                ok.SOLONumeros(sender, e);
            }
        }

        private void dgvDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaTotales();
        }

        private void dgvDetalle_Leave(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void txtDocRefe_KeyDown(object sender, KeyEventArgs e)
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
                        txtDocRefe.Text = doc.Sigla;
                        if (CodDocumento != 0) { ProcessTabKey(true); }
                    }
                }
            }
        }

        private void txtDocRefe_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDocRefe_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias);
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {

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

                        txtNumero.Enabled = false;

                        txtNumero.Text = ser.Numeracion.ToString();
                    }

                    ProcessTabKey(true);

                }

            }
            if (e.KeyChar == (char)Keys.Enter)
            {
               
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

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.ClearSelection();
            if (dgvDetalle.Rows.Count > 0)
            {
                if (Proceso != 3)
                {
                    if (Convert.ToString(cmbMotivo.SelectedValue) == "05" || Convert.ToString(cmbMotivo.SelectedValue) == "09")
                    {
                        dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true;
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
                    }
                    else if (Convert.ToString(cmbMotivo.SelectedValue) == "07")
                    {
                        dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = false;
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                    }
                    Int32 fila = dgvDetalle.CurrentRow.Index;
                    cantprod = cantpr[fila];
                    precprod = cantprec[fila];
                }
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
