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
    public partial class frmNotaSalida : DevComponents.DotNetBar.Office2007Form
    {
        //private clsReporteFactura ds = new clsReporteFactura();
        private clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        private clsTransaccion tran = new clsTransaccion();
        private clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        private clsTipoDocumento doc = new clsTipoDocumento();
        private clsAdmSerie Admser = new clsAdmSerie();
        private clsSerie ser = new clsSerie();
        private clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        private clsTipoCambio tc = new clsTipoCambio();
        private clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        private clsFormaPago pag = new clsFormaPago();
        private clsAdmCliente AdmCli = new clsAdmCliente();
        private clsCliente cli = new clsCliente();
        private clsAdmNotaSalida AdmNota = new clsAdmNotaSalida();
        private clsNotaSalida nota = new clsNotaSalida();
        private clsValidar ok = new clsValidar();
        private clsConsultasExternas ext = new clsConsultasExternas();
        private clsMoneda mon = new clsMoneda();
        private clsAdmMoneda AdmMon = new clsAdmMoneda();
        private clsFacturaVenta venta = new clsFacturaVenta();
        private clsAdmFacturaVenta admVenta = new clsAdmFacturaVenta();

        private clsValidar val = new clsValidar();

        public List<Int32> config = new List<Int32>();
        public List<Int32> documento = new List<Int32>();
        public List<clsDetalleNotaSalida> detalle = new List<clsDetalleNotaSalida>();
        
        public static BindingSource data = new BindingSource();
        private TextBox txtedit = new TextBox();

        public String CodNota;
        public Int32 CodTransaccion;
        public Int32 CodProveedor;
        public Int32 CodNotaI;
        public Int32 CodCliente;
        public Int32 CodDocumento, tipomoneda;
        public Int32 CodPedido;
        public Int32 CodSerie, CodSerieG = 0, numG = 0;
        public Int32 Tipo, Manual;
        private Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Proce = 0; // (1) SalidaxVenta    
        public Int32 Procede = 1;
        
        private DataTable datosAlmacena = new DataTable();
        private Int32 cont1 = 0;
        Decimal Qnueva = 0, QOriginal = 0, QPorDespachar = 0, QDespachada = 0, QPorDespachar2 = 0, QDespachada2 = 0;

        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmGuiaRemision AdmGuia = new clsAdmGuiaRemision();
        clsGuiaRemision guia = new clsGuiaRemision();
        clsGuia ds = new clsGuia();

        public Int32 CodEmpresaTransporte;
        clsVehiculoTransporte vehiculotransporte = new clsVehiculoTransporte();
        clsAdmVehiculoTransporte admVehiculoTransporte = new clsAdmVehiculoTransporte();
        clsConductor conductor = new clsConductor();
        clsAdmConductor admConductor = new clsAdmConductor();
        clsAdmEmpresaTransporte AdmET = new clsAdmEmpresaTransporte();
        clsEmpresaTransporte empT = new clsEmpresaTransporte();
        public List<clsDetalleGuiaRemision> detalleg = new List<clsDetalleGuiaRemision>();
        clsAdmSerie admSerie = new clsAdmSerie();

        Int32 cantprod = 0;
        List<Int32> cantpr = new List<Int32>();

        public frmNotaSalida()
        {
            InitializeComponent();
        }

        private void txtTransaccion_KeyDown(object sender, KeyEventArgs e)
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
                    tran = form.tran;
                    CodTransaccion = tran.CodTransaccion;
                    txtTransaccion.Text = tran.Sigla;
                    dgvDetalle.Rows.Clear();
                    if (CodTransaccion != 0)
                    {
                        CargaTransaccion();
                        ProcessTabKey(true);
                        if (tran.CodTransaccion == 12)
                        {
                            label5.Visible = false;
                            txtDocRef.Visible = false;
                            txtNumero.Visible = false;
                            ckbguia.Visible = true;
                            groupBox5.Visible = true;
                            txtCodCliente.Visible = true;
                            txtNombreCliente.Visible = true;                         
                            label15.Visible = true;
                            label15.Text = "Proveedor";
                            btnDetalle.Enabled = false;
                            txtCodCliente.Focus();
                        }
                        else
                        {
                            label15.Text = "Cliente";
                            groupBox5.Visible = false;
                            ckbguia.Visible = false;
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
            if (tran.CodTransaccion == 7)
            {
                desactiva_botones(false);
            }
        }

        private void desactiva_botones(Boolean band)
        {
            if (Proceso == 1)
            {
                txtDocRef.ReadOnly = !band;
                txtSerie.ReadOnly = !band;
                txtCodCliente.ReadOnly = !band;
                
                cantnueva.Visible = !band;
                cantdespachada.ReadOnly = !band;
            }
            txtCodCliente.Enabled = band;
            label3.Visible = band;
            label17.Visible = band;
            label19.Visible = band;
            txtTipoCambio.Visible = band;
            label16.Visible = band;
            cmbFormaPago.Visible = band;
            dtpFechaPago.Visible = band;
            cmbMoneda.Visible = band;
            serielote.Visible = band;
            preciounit.Visible = band;
            importe.Visible = band;
            montodscto.Visible = band;
            valorventa.Visible = band;
            igv.Visible = band;
            precioventa.Visible = band;
            label10.Visible = band;
            txtBruto.Visible = band;
            label11.Visible = band;
            txtDscto.Visible = band;
            label12.Visible = band;
            txtValorVenta.Visible = band;
            label13.Visible = band;
            txtIGV.Visible = band;
            label14.Visible = band;
            txtPrecioVenta.Visible = band;
            btnNuevo.Visible = band;
            btnEditar.Visible = band;
            btnEliminar.Visible = !band;
            btnImprimir.Visible = band;
            btnDetalle.Visible = band;
            cantdespachada.Visible = !band;
            cantpordespachar.Visible = !band;
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
            if (e.KeyChar == (char) Keys.Return)
            {
                if (txtTransaccion.Text != "")
                {
                    if (BuscaTransaccion())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Codigo de transacción no existe, Presione F1 para consultar la tabla de ayuda",
                            "NOTA DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CargaCliente()
        {
            //cli = AdmCli.MuestraClienteNota(CodCliente);
            cli = AdmCli.MuestraCliente(CodCliente);
            if (cli != null)
            {
                txtCodigoCli.Text = cli.CodCliente.ToString();
                txtCodCliente.Text = cli.CodigoPersonalizado;
                txtNombreCliente.Text = cli.RazonSocial;
                txtDireccion.Text = cli.DireccionLegal;
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
                txtDireccion.Text = cli.DireccionLegal;
                //cbListaPrecios.SelectedValue = cli.CodListaPrecio;
                cmbFormaPago.SelectedValue = cli.FormaPago;
                txtPorcDescuento.Text = cli.Descuento.ToString();
                return true;
            }
            else
            {
                txtNombreCliente.Text = "";
                CodCliente = 0;
                return false;
            }
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (tran.CodTransaccion != 12)
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
                            ProcessTabKey(true);
                        }
                    }
                }
            }
            else
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
                        form.Procede = 8;  //MODIFICACION ALEX PARA QUE REGRESE
                        form.ShowDialog();
                        CodCliente = 0;
                    }
                }
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (tran.CodTransaccion != 12)
            {
                if (CodCliente == 0)
                {
                    txtCodCliente.Focus();
                }
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char) Keys.Return)
            {
                if (txtCodCliente.Text != "")
                {
                    if (BuscaCliente())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no existe, Presione F1 para consultar la tabla de ayuda",
                            "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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
                    MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFecha.Value = DateTime.Now.Date;
                    dtpFecha.Focus();
                }
            }
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
            if (e.KeyChar == (char) Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
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

        private void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                if (txtDocRef.Text != "")
                {
                    if (BuscaTipoDocumento())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda",
                            "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    form.Proceso = 4;
                    form.Procedencia = 2;
                    form.Transaccion = txtTransaccion.Text;
                    form.ShowDialog();
                    doc = form.doc;
                    CodDocumento = doc.CodTipoDocumento;
                    txtDocRef.Text = doc.Sigla;
                    //txtSerie.Text = ser.Serie;
                    if (CodDocumento != 0)
                    {
                        ProcessTabKey(true);
                    }
                }
            }
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
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
            if (txtFactura.Visible && CodPedido == 0)
            {
                Validacion = false;
            }
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void frmNotaSalida_Load(object sender, EventArgs e)
        {
            CargaFormaPagos();
            CargaMoneda();
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            CargaTransportista();
            CargaVehiculoTrasnporte();
            if (Proceso == 2)
            {
                CargaNotaSalida();
            }
            else if (Proceso == 3)
            {
                CargaNotaSalida();
                sololectura(true);
                deshabilita_botones(false);
                desactiva_botones(false);
            }
            else if (Proceso == 4)
            {
                CargaNotaSalida();
                sololectura(true);
            }
        }

        private void deshabilita_botones(Boolean activo)
        {
            btnGuardar.Visible = !activo;
            btnGuardar.Enabled = activo;
            label8.Visible = !activo;
            txtFactura.Visible = !activo;
            label10.Visible = activo;
            txtBruto.Visible = activo;
            label11.Visible = activo;
            txtDscto.Visible = activo;
            label12.Visible = activo;
            txtValorVenta.Visible = activo;
            label13.Visible = activo;
            txtIGV.Visible = activo;
            label14.Visible = activo;
            txtPrecioVenta.Visible = activo;
            btnNuevo.Visible = activo;
            btnEditar.Visible = activo;
            btnEliminar.Visible = activo;
            label7.Visible = !activo;
            txtNumDoc.Visible = !activo;
            txtNumDoc.Enabled = activo;
            txtNumero.Visible = activo;
            groupBox5.Enabled = !activo;
            ckbguia.Enabled = !activo;
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            //cmbFormaPago.SelectedIndex = -1;
        }

        private void CargaNotaSalida()
        {
            try
            {
                nota = AdmNota.CargaNotaSalida(Convert.ToInt32(CodNota));
                venta = admVenta.CargaFacturaVenta(Convert.ToInt32(nota.DocumentoReferencia));
                //ser = Admser.MuestraSerie(nota.CodSerie, frmLogin.iCodAlmacen);

                if (nota != null)
                {
                    if (Proceso != 1)
                    {
                        dtpFecha.Value = nota.FechaSalida;
                        txtNumDoc.Text = nota.CodNotaSalida;
                    }

                    CodTransaccion = nota.CodTipoTransaccion;

                    if (Proceso != 1) CargaTransaccion();

                    if (txtCodCliente.Enabled)
                    {

                        cli = AdmCli.MuestraCliente(nota.CodCliente);
                        if (cli != null)
                        {
                            CodCliente = nota.CodCliente;
                            if (nota.RUCCliente != "") txtCodCliente.Text = nota.RUCCliente;
                            else txtCodCliente.Text = nota.DNI;
                            txtNombreCliente.Text = nota.RazonSocialCliente;
                            txtDireccion.Text = nota.Direccion;
                        }
                    }

                    cmbFormaPago.SelectedValue = nota.FormaPago;
                    dtpFechaPago.Value = nota.FechaPago;
                    cmbMoneda.SelectedValue = nota.Moneda;
                    txtTipoCambio.Text = nota.TipoCambio.ToString();

                    if (txtAutorizacion.Enabled)
                    {
                        //se guarda el codigo del autorizado y se cargan los datos de este
                    }
                    if (txtDocRef.Enabled)
                    {
                        if (Proceso != 1)
                        {
                            CodDocumento = nota.CodTipoDocumento;
                            txtDocRef.Text = nota.SiglaDocumento;
                            if (CodTransaccion == 7) txtSerie.Text = nota.NumDoc;
                            else
                            {
                                txtSerie.Text = nota.Serie;
                                txtNumero.Text = nota.NumDoc;
                            }

                            BuscaTipoDocumento();
                        }
                    }
                    if (txtFactura.Enabled)
                    {
                        if (venta != null)
                        {
                            txtCodFac.Text = nota.DocumentoReferencia.ToString();
                            txtFactura.Text = venta.SiglaDocumento + "-" + venta.Serie + "-" + venta.NumDoc;
                        }
                    }
                    txtComentario.Text = nota.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.00}", nota.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.00}", nota.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.00}", nota.Total - nota.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.00}", nota.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.00}", nota.Total);
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void sololectura(Boolean estado)
        {
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            cmbMoneda.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtSerie.ReadOnly = estado;
            txtNumero.ReadOnly = estado;
            txtNumero.Visible = estado;
            txtFactura.ReadOnly = estado;
            txtComentario.ReadOnly = estado;
            txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            btnNuevo.Visible = !estado;
            btnEditar.Visible = !estado;
            btnEliminar.Visible = !estado;
            btnGuardar.Visible = !estado;
            btnImprimir.Visible = !estado;
            cmbFormaPago.Enabled = !estado;
            dtpFechaPago.Visible = estado;
            dtpFechaPago.Enabled = !estado;
            txtNumDoc.Visible = estado;
            txtNumDoc.ReadOnly = estado;
            label7.Visible = estado;
            ext.sololectura(groupBox1.Controls);
            txtDocRef.Enabled = !estado;
            txtNumero.Enabled = !estado;
            txtCodCliente.Enabled = !estado;
            txtTransaccion.Enabled = !estado;
            if (groupBox5.Visible) { groupBox5.Enabled = !estado;}
        }

        private void CargaDetalle()
        {
            if (CodTransaccion == 7)
            {
                dgvDetalle.DataSource = AdmNota.CargaDetalleNotaSalida(Convert.ToInt32(nota.CodNotaSalida), Proceso);
                RecorreDetalle();
                nota.Detalle = detalle;
            }
            else
            {
                dgvDetalle.DataSource = AdmNota.CargaDetalle(Convert.ToInt32(nota.CodNotaSalida));
                RecorreDetalle();
                nota.Detalle = detalle;
            }

            if (Proceso == 3 && CodTransaccion == 7)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[cantidad.Name].Value) ==
                        Convert.ToDecimal(row.Cells[cantdespachada.Name].Value))
                    {
                        cont1++;
                    }
                }
                if (cont1 == dgvDetalle.Rows.Count)
                {
                    if (CodDocumento == 1 || CodDocumento == 2) dgvDetalle.Columns["cantdespachada"].ReadOnly = false;
                    else dgvDetalle.Columns["cantdespachada"].ReadOnly = true;
                }
                else
                {
                    dgvDetalle.Columns["cantdespachada"].ReadOnly = true;
                }
            }
        }

        private void frmNotaSalida_Shown(object sender, EventArgs e)
        {
            if (Proceso == 1)
            {
                if (txtTipoCambio.Visible)
                {
                    if (tc == null)
                    {
                        MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        txtTipoCambio.Text = tc.Compra.ToString();
                    }
                }
            }
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
            if (CodDocumento == 0)
            {
                txtDocRef.Focus();
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
                    form.DocSeleccionado = doc.CodTipoDocumento;
                    form.Sigla = doc.Sigla;
                    form.Proceso = 3;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                    txtSerie.Text = ser.Serie;
                    if (CodSerie != 0)
                    {
                        ProcessTabKey(true);
                    }
                }
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char) Keys.Return)
            {
                if (BuscaSerie())
                {
                    txtSerie.Text = ser.Serie.ToString();
                    if (ser.PreImpreso)
                    {
                        txtNumero.Text = "";
                        txtNumero.Visible = true;
                        txtNumero.Focus();
                        Manual = 2;
                    }
                    else
                    {
                        if (CodTransaccion == 7)
                        {
                            txtNumero.Visible = false;
                            txtNumero.Text = Convert.ToString(ser.Numeracion + 1);
                            Manual = 1;
                        }
                    }
                    ProcessTabKey(true);
                }
                else
                {
                    MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda",
                        "Facturación Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private Boolean BuscaSerie()
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

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            //BuscaSerieDocumento();
            if (CodDocumento == 0)
            {
                txtDocRef.Focus();
            }

            if (BuscaSerie())
            {
                txtSerie.Text = ser.Serie.ToString();
                if (ser.PreImpreso)
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = true;
                    txtNumero.Focus();
                    Manual = 2;
                }
                else
                {
                    if (CodTransaccion == 7)
                    {
                        txtNumero.Visible = false;
                        txtNumero.Text = Convert.ToString(ser.Numeracion + 1);
                        Manual = 1;
                    }
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char) Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Visible && txtNumero.Text == "")
            {
                txtNumero.Focus();
            }
            else
            {
                txtFactura.Focus();
                VerificarCabecera();
                //if (Validacion)
                //{
                //    btnDetalle.Enabled = true;
                //}
            }
            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {

                if (tran.CodTransaccion != 12)
                {
                    if (Application.OpenForms["frmDetalleSalida"] != null)
                    {
                        Application.OpenForms["frmDetalleSalida"].Activate();
                    }
                    else
                    {
                        frmDetalleSalida form = new frmDetalleSalida();
                        form.Procede = 1;
                        form.Proceso = 1;
                        form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                        form.tc = Convert.ToDouble(txtTipoCambio.Text);
                        form.ShowDialog();
                        dgvDetalle.Columns[cantidad.Name].ReadOnly = true;
                    }
                }
                else
                {
                    if (Application.OpenForms["frmMuestraNotasIngresoProveedor"] != null)
                    {
                        Application.OpenForms["frmMuestraNotasIngresoProveedor"].Activate();
                    }
                    else
                    {
                        if (CodProveedor != 0)
                        {
                            frmMuestraNotasIngresoProveedor form = new frmMuestraNotasIngresoProveedor();
                            form.CodProveedor = CodProveedor;
                            form.ShowDialog();
                            dgvDetalle.Columns[cantidad.Name].ReadOnly = false;
                            cantpr = new List<Int32>();
                            foreach (DataGridViewRow row in dgvDetalle.Rows)
                            {
                                cantpr.Add(Convert.ToInt32(row.Cells[cantidad.Name].Value));
                            }
                        }
                        else { txtCodCliente.Focus(); }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1 && CodTransaccion != 7)
            {
                Decimal bruto = 0;
                Decimal descuen = 0;
                Decimal valor = 0;
                Decimal igvt = 0;
                Decimal preciot = 0;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                    descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                    valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                    igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                    preciot = preciot + Convert.ToDecimal(row.Cells[precioventa.Name].Value);

                }
                txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
                txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
                txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text != "")
            {
                btnGuardar.Enabled = true;
            }
        }

        private Int32 verificarCamposVacios()
        {
            //Int32 valor = 1;
            //foreach (DataGridViewRow row in dgvDetalle.Rows)
            //{
            //    String cant = "";
            //    String precio = "";
            //    String impor = "";
            //    String IG = "";
            //    String MontDes = "";
            //    String d1 = "";
            //    String d2 = "";
            //    String d3 = "";

            //    cant = Convert.ToString(Convert.ToInt32(row.Cells[cantidad.Name].Value));
            //    impor = Convert.ToString(row.Cells[importe.Name]);
            //    IG = Convert.ToString(row.Cells[igv.Name]);
            //    MontDes = Convert.ToString(row.Cells[montodscto.Name]);
            //    precio = Convert.ToString(row.Cells[preciounit.Name].Value);
            //    d1 = Convert.ToString(row.Cells[dscto1.Name].Value);
            //    d2 = Convert.ToString(row.Cells[dscto2.Name].Value);
            //    d3 = Convert.ToString(row.Cells[dscto3.Name].Value);

            //    //if (d1 != "" || d2 != "" || d3 != "")
            //    //{
            //    //    calculatotales();
            //    //}

            //    if (cant == "" || precio == "" || impor == "" || IG == "")
            //    {
            //        valor = 1;
            //    }
            //    else
            //    {
            //        valor = 0;
            //    }

            //}
            //return valor;
            
            Int32 valor = 0;
            if (CodTransaccion == 7)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    String canti = "";
                    canti = Convert.ToString(Convert.ToDecimal(row.Cells[cantnueva.Name].Value));
                    if (canti == "" || canti == "0.00" || canti == "0")
                    {
                        valor = 1;
                    }
                }

            }
            return valor;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Proceso == 1 && tran.CodTransaccion == 7) datosAlmacena = (DataTable)dgvDetalle.DataSource;
            if (Proceso != 0)
            {
                if (verificarCamposVacios() == 1)
                {
                    MessageBox.Show("Debe completar Detalle de Nota, Datos Vacios");
                }
                else
                {
                    nota.CodSucursal = frmLogin.iCodSucursal;
                    nota.CodAlmacen = frmLogin.iCodAlmacen;
                    nota.CodTipoTransaccion = tran.CodTransaccion;
                    if (Proceso == 3 && nota.CodTipoTransaccion == 7) Proceso = 2;
                    if (nota.CodTipoTransaccion == 12)
                    {
                        nota.CodTipoDocumento = 10;
                    }
                    else
                    {
                        nota.CodTipoDocumento = doc.CodTipoDocumento;
                        nota.CodSerie = CodSerie;
                    }
                    nota.CodCliente = cli.CodCliente;
                    //nota.CodTipoDocumento = doc.CodTipoDocumento;
                    //nota.CodSerie = CodSerie;
                    if (nota.CodTipoTransaccion == 7 && Proceso == 2) nota.NumDoc = txtSerie.Text;
                    else if (nota.CodTipoTransaccion == 7) nota.NumDoc = txtSerie.Text + "-" + txtNumero.Text;
                    else
                    {
                        nota.Serie = txtSerie.Text;
                        nota.NumDoc = txtNumero.Text;
                    }
                    if (txtFactura.Visible) nota.DocumentoReferencia = Convert.ToInt32(txtCodFac.Text);
                    nota.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    if (txtTipoCambio.Visible) nota.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                    nota.FechaSalida = dtpFecha.Value.Date;
                    nota.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    nota.FechaPago = dtpFechaPago.Value.Date;
                    nota.Comentario = txtComentario.Text;
                    nota.MontoBruto = Convert.ToDouble(txtBruto.Text);
                    //nota.MontoBruto = Convert.ToDouble(txtValorVenta.Text);
                    nota.MontoDscto = Convert.ToDouble(txtDscto.Text);
                    nota.Igv = Convert.ToDouble(txtIGV.Text);
                    nota.Total = Convert.ToDouble(txtPrecioVenta.Text);
                    nota.CodUser = frmLogin.iCodUser;
                    nota.Estado = 1;
                    nota.codVehiculoTransporte = 0;
                    nota.codConductor = 0;
                    nota.codalmacenreceptor = 0;
                    nota.Codtransferencia = 0;
                    if (CodProveedor != 0) { nota.CodProveedor = CodProveedor; }
                    // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                    if (Proceso == 1)
                    {
                        if (AdmNota.insert(nota))
                        {
                            RecorreDetalle();

                            if (detalle.Count > 0)
                            {
                                foreach (clsDetalleNotaSalida det in detalle)
                                {
                                    AdmNota.insertdetalle(det);
                                }
                            }
                            MessageBox.Show("Los datos se guardaron correctamente", "Nota de Salida",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CodNota = nota.CodNotaSalida;
                            txtNumDoc.Text = nota.CodNotaSalida.PadLeft(11, '0');
                            CargaNotaSalida();
                            if (Proceso == 1 && tran.CodTransaccion == 7) dgvDetalle.DataSource = datosAlmacena;
                            sololectura(true);
                        }
                        if (ckbguia.Checked)
                        {
                            if (!txtcodserie.Text.Equals(""))
                            {
                                guia.CodAlmacen = frmLogin.iCodAlmacen;
                                guia.CodTipoDocumento = 11; //codigo de documento Guia de Remision
                                guia.CodSerie = Convert.ToInt32(txtcodserie.Text); //codigo de serie 001 de la guia de remision
                                guia.CodMotivo = 4; //codigo de devolucion

                                guia.FechaEmision = dtpFecha.Value;
                                guia.FechaTraslado = nota.FechaSalida;
                                guia.CodProveedor = Convert.ToInt32(CodProveedor);
                                if (cmbVehiculo.SelectedValue == null) guia.CodVehiculoTransporte = 0;
                                else guia.CodVehiculoTransporte = Convert.ToInt32(cmbVehiculo.SelectedValue); //codigo del vehiculo de la empresa
                                if (cmbTransportista.SelectedValue == null) guia.CodConductor = 0;
                                else guia.CodConductor = Convert.ToInt32(cmbTransportista.SelectedValue.ToString()); // codigo del conductor
                                //if (cmbTransportista.SelectedValue == null) cmbTransportista.SelectedValue = 0;
                                //else cmbTransportista.SelectedValue = Convert.ToInt32(cmbTransportista.SelectedValue); 
                                guia.CodEmpresaTransporte = CodEmpresaTransporte;
                                guia.Facturado = 0;
                                if (CodNotaI > 0)
                                {
                                    guia.CodFactura = CodNotaI;
                                }
                                else
                                {
                                    guia.CodFactura = Convert.ToInt32(nota.CodNotaSalida);
                                }
                                guia.Comentario = txtComentario.Text;
                                guia.CodUser = frmLogin.iCodUser;
                                guia.Estado = 1;
                                // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                                if (AdmGuia.insert(guia))
                                {
                                    RecorreDetalleGuia();
                                    if (detalleg.Count > 0)
                                    {
                                        foreach (clsDetalleGuiaRemision detg in detalleg)
                                        {
                                            AdmGuia.insertdetalle(detg);
                                            AdmGuia.insertrelacionguia(Convert.ToInt32(guia.CodGuiaRemision), guia.CodFactura, frmLogin.iCodAlmacen, frmLogin.iCodUser, 0);
                                        }
                                        MessageBox.Show("Se ha generado la guia de remision correspondiente!",
                                            "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmNota.update(nota))
                        {
                            RecorreDetalle();
                            foreach (clsDetalleNotaSalida det in nota.Detalle)
                            {
                                foreach (clsDetalleNotaSalida det1 in detalle)
                                {
                                    if (det.Equals(det1))
                                    {
                                        AdmNota.updatedetalle(det1);
                                    }
                                }
                                AdmNota.deletedetalle(det.CodDetalleSalida);
                            }
                            foreach (clsDetalleNotaSalida deta in detalle)
                            {
                                if (deta.CodDetalleSalida == 0)
                                {
                                    AdmNota.insertdetalle(deta);
                                }
                            }

                            MessageBox.Show("Los datos se actualizaron correctamente", "Nota de Ingreso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //nota.Detalle = detalle;
        }
        
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleNotaSalida deta = new clsDetalleNotaSalida();
            if (Proceso == 2) deta.CodDetalleSalida = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            if (Proceso == 2 && CodTransaccion == 7)
            {
                deta.Cantidad = Convert.ToDouble(fila.Cells[cantdespachada.Name].Value);
                deta.CantidadPendiente = Convert.ToDouble(fila.Cells[cantpordespachar.Name].Value);
            }
            else if (Proceso == 1 && CodTransaccion == 7)
            {
                deta.Cantidad = Convert.ToDouble(fila.Cells[cantnueva.Name].Value);
                deta.CantidadPendiente = Convert.ToDouble(fila.Cells[cantpordespachar.Name].Value);
            }
            else deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodNotaSalida = Convert.ToInt32(nota.CodNotaSalida);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            //deta.Subtotal = Convert.ToDouble(fila.Cells[valorventa.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            //deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            //deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            detalle.Add(deta);
        }

        public void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pag = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            dtpFechaPago.Value = dtpFecha.Value.AddDays(pag.Dias);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tran.CodTransaccion != 12)
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
                        form.Procede = 1;
                        form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                        form.tc = Convert.ToDouble(txtTipoCambio.Text);
                        form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                        form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                        form.txtControlStock.Text = row.Cells[serielote.Name].Value.ToString();
                        form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
                        form.txtPrecio.Text = row.Cells[preciounit.Name].Value.ToString();
                        form.txtDscto1.Text = row.Cells[dscto1.Name].Value.ToString();
                        //form.txtDscto2.Text = row.Cells[dscto2.Name].Value.ToString();
                        //form.txtDscto3.Text = row.Cells[dscto3.Name].Value.ToString();
                        //form.txtPrecioNeto.Text = row.Cells[importe.Name].Value.ToString();
                        form.txtDescMax.Text = row.Cells[maxpdscto.Name].Value.ToString();
                        form.ShowDialog();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Proceso == 1)
            {
                if (dgvDetalle.CurrentRow.Index != -1)
                {
                    dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                    if (tran.CodTransaccion == 12)
                    {
                        cantpr = new List<Int32>();
                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            cantpr.Add(Convert.ToInt32(row.Cells[cantidad.Name].Value));
                        }
                    }
                }
            }
            else if (Proceso == 2)
            {
                if (dgvDetalle.CurrentRow.Index != -1)
                {
                    DialogResult dlgResult =
                        MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente",
                            "Detalle Nota Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (
                            AdmNota.deletedetalle(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value)))
                        {
                            MessageBox.Show("Los datos han sido eliminado correctamente", "Detalle Nota Salida",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaDetalle();
                        }
                    }
                }
            }
        }

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
                    form.Procede = 1;
                    form.Proceso = 1;
                    if (tran.CodTransaccion == 12)
                    {
                        form.Tipo = 3;
                        form.codTran = tran.CodTransaccion;
                    }
                    form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    form.tc = Convert.ToDouble(txtTipoCambio.Text);
                    form.productosNotaSalida = detalle;
                    form.codProveedor = CodProveedor;
                    form.codTipodoc = doc.CodTipoDocumento;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtComentario_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            

            if (tran.CodTransaccion == 12)
            {
                if (Convert.ToInt32(guia.CodGuiaRemision) != 0)
                {
                    ser = admSerie.MuestraSerie(Convert.ToInt32(txtcodserie.Text), frmLogin.iCodAlmacen);
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rd.Load("CRGuiaRemisionSD.rpt");
                    CRGuiaRemisionSD rpt = new CRGuiaRemisionSD();
                    rd.SetDataSource(ds.GuiaRemisionSD(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen));
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                    rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                    //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                    rd.PrintToPrinter(1, false, 1, 1);
                    rd.Close();
                    rd.Dispose();
                }
            }
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                Decimal bruto = 0;
                Decimal descuen = 0;
                Decimal valor = 0;
                Decimal igvt = 0;
                Decimal preciot = 0;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                    descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                    valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                    igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                    preciot = preciot + Convert.ToDecimal(row.Cells[precioventa.Name].Value);

                }
                txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
                txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
                txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
            {
                if (Proceso == 1 && CodTransaccion != 7)
                {
                    Decimal bruto = 0;
                    Decimal descuen = 0;
                    Decimal valor = 0;
                    Decimal igvt = 0;
                    Decimal preciot = 0;
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                        descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                        valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                        igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                        preciot = preciot + Convert.ToDecimal(row.Cells[precioventa.Name].Value);

                    }
                    txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
                    txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                    txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
                }
            }
        }

        private void txtFactura_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmMercaderiaEntregar"] != null)
                {
                    Application.OpenForms["frmMercaderiaEntregar"].Activate();
                }
                else
                {
                    frmMercaderiaEntregar form = new frmMercaderiaEntregar();
                    form.proceso = 11;
                    form.tipo = Manual;
                    form.ShowDialog();
                    if (form.salida != null && form.salida.CodNotaSalida != "")
                    {
                        nota = form.salida;
                        CodNota = nota.CodNotaSalida;
                    }
                    if (Convert.ToInt32(CodNota) != 0) { CargaNotaSalida(); ProcessTabKey(true); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex.Message);
            }
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 )
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
                if (e.ControlToValidate.Text != "" ) 
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void recalculadetalle()
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (Proceso == 3)
                {
                    row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[cantdespachada.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                    row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[cantdespachada.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                }
                else if (Proceso == 1)
                {
                    if (tran.CodTransaccion != 12)
                    {
                        row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[cantnueva.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                        row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[cantnueva.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                    }
                    else
                    {
                        row.Cells[importe.Name].Value = Convert.ToDecimal(row.Cells[cantidad.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                        row.Cells[precioventa.Name].Value = Convert.ToDecimal(row.Cells[cantidad.Name].Value) * Convert.ToDecimal(row.Cells[preciounit.Name].Value);
                    }
                }
                row.Cells[valorventa.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / Convert.ToDecimal(frmLogin.Configuracion.IGV / 100 + 1);
                row.Cells[igv.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) - Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
            }
        }

        private void calculatotales()
        {
            Decimal bruto = 0;
            Decimal descuen = 0;
            Decimal valor = 0;
            Decimal igvt = 0;
            Decimal preciot = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
                igvt = igvt + Convert.ToDecimal(row.Cells[igv.Name].Value);
                preciot = preciot + Convert.ToDecimal(row.Cells[precioventa.Name].Value);

            }
            txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
            txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
            txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
            txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
            txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetalle.Rows.Count > 0 && dgvDetalle.CurrentRow.Selected)
                {
                    QPorDespachar = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantpordespachar2.Name].Value);
                    QOriginal = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value);
                    QDespachada = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantdespachada2.Name].Value);

                    //if (QPorDespachar == 0) QDespachada = QOriginal;
                    //else QDespachada = QOriginal - QPorDespachar;

                    if (Proceso == 3)
                    {
                        if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantdespachada" &&
                            txtedit.Text != "")
                        {
                            Qnueva = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantdespachada.Name].Value);

                            if (Qnueva > QOriginal || Qnueva == 0)
                            {
                                MessageBox.Show("Cantidad Debe Ser Menor o Igual que: " + QOriginal);
                                dgvDetalle.CurrentRow.Cells[cantdespachada.Name].Value = QOriginal;
                            }
                            else
                            {
                                dgvDetalle.CurrentRow.Cells[cantpordespachar.Name].Value = (QOriginal - Qnueva);
                            }
                        }
                        btnGuardar.Enabled = true;
                    }
                    else if (Proceso == 1)
                    {
                        if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantnueva" &&
                            txtedit.Text != "")
                        {
                            Qnueva = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantnueva.Name].Value);

                            if ((Qnueva > QOriginal && Qnueva > QPorDespachar || Qnueva > QPorDespachar )|| Qnueva==0)
                            {
                                MessageBox.Show("Cantidad Debe Ser Menor o Igual que: " + QPorDespachar);
                                dgvDetalle.CurrentRow.Cells[cantnueva.Name].Value = 0;
                            }
                            else
                            {
                                dgvDetalle.CurrentRow.Cells[cantpordespachar.Name].Value = (QOriginal - Qnueva - QDespachada);
                                dgvDetalle.CurrentRow.Cells[cantdespachada.Name].Value = (QDespachada + Qnueva);
                            }
                        }
                        if (tran.CodTransaccion == 12)
                        {
                            if (cantprod < Convert.ToInt32(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value))
                            {
                                MessageBox.Show("La cantidad del producto debe ser menor", "Nota de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvDetalle.CurrentRow.Cells[cantidad.Name].Value = Convert.ToString(cantprod);
                            }
                        }
                    }
                    recalculadetalle();
                    calculatotales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == cantdespachada.Index)//CantidadDespachada
            {
                ok.SOLONumeros(sender, e);
            }
            else if (dgvDetalle.CurrentCell.ColumnIndex == cantnueva.Index)
            {
                ok.SOLONumeros(sender, e);
            }
            else if (dgvDetalle.CurrentCell.ColumnIndex == cantidad.Index)
            {
                ok.SOLONumeros(sender, e);
            }
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

        private void dgvDetalle_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvDetalle_Leave(object sender, EventArgs e)
        {

        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            if (CodTransaccion == 7)
            {
                txtNumero.Text = "";
                txtNumero.Visible = false;
            }
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
            empT = AdmET.MuestraEmpresaTranporte(empT.CodEmpresaTranporte);
            if (empT != null)
            {
                txtRazonSocialTransporte.Text = empT.RazonSocial;
            }
            else
            {
                txtRazonSocialTransporte.Text = "";
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
                            txtSerieG.Text = ser.Serie;
                            txtcodserie.Text = ser.CodSerie.ToString();
                            txtNumeroG.Visible = true;
                            txtNumeroG.Enabled = true;
                            txtNumeroG.Text = "";
                        }
                        else
                        {
                            CodSerieG = ser.CodSerie;
                            txtSerieG.Text = ser.Serie;
                            txtcodserie.Text = ser.CodSerie.ToString();
                            txtNumeroG.Visible = false;
                        }

                    }
                    if (CodSerieG != 0) { ProcessTabKey(true); }
                }
            }
        }

        private void ckbguia_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbguia.Checked == true) groupBox5.Visible = true;
            else groupBox5.Visible = false;
        }

        private void CargaTransportista()
        {
            cmbTransportista.DataSource = admConductor.CargaConductores();
            cmbTransportista.DisplayMember = "nombre";
            cmbTransportista.ValueMember = "codConductor";
            cmbTransportista.SelectedIndex = -1;
        }

        private void CargaVehiculoTrasnporte()
        {
            cmbVehiculo.DataSource = admVehiculoTransporte.CargaVehiculoTransportes();
            cmbVehiculo.DisplayMember = "placa";
            cmbVehiculo.ValueMember = "codVehiculoTransporte";
            cmbVehiculo.SelectedIndex = -1;
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Int32 fila = dgvDetalle.CurrentRow.Index;
            cantprod = cantpr[fila];*/
        }

    }
}
