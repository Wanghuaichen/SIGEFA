using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class F2TransferenciaEntreAlmacenes : DevComponents.DotNetBar.Office2007Form
    {
        clsReporteTransferencias ds = new clsReporteTransferencias();
        clsAdmAlmacen admAlmacen = new clsAdmAlmacen();
        clsAlmacen almacen = new clsAlmacen();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoDocumento admtd = new clsAdmTipoDocumento();
        clsTransaccion tran = new clsTransaccion();
        clsAdmTransaccion admTransaccion = new clsAdmTransaccion();
        clsAdmTransferencia admTransferencia = new clsAdmTransferencia();
        clsTransferencia transfer = new clsTransferencia();
        List<clsDetalleTransferencia> detalle = new List<clsDetalleTransferencia>();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmNotaSalida admNS =new clsAdmNotaSalida();
        clsNotaSalida NS = new clsNotaSalida();
        clsAdmNotaIngreso admNI = new clsAdmNotaIngreso();
        clsNotaIngreso NI = new clsNotaIngreso();
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        clsSerie ser = new clsSerie();
        clsAdmSerie admSerie = new clsAdmSerie();
        public Int32 CodSerie, num;

        public List<clsDetalleNotaSalida> detalleNS = new List<clsDetalleNotaSalida>();
        public List<clsDetalleNotaIngreso> detalleNI = new List<clsDetalleNotaIngreso>();

        public Int32 CodTransaccion;
        public Int32 CodDocumento;
        public Int32 Proceso;
        public int CodTransDirecta;
        public Int32 caso;

        public F2TransferenciaEntreAlmacenes()
        {
            InitializeComponent();
        }

        private void CargaTransaccion()
        {
            tran = AdmTran.MuestraTransaccion(CodTransaccion);
            tran.Configuracion = AdmTran.MuestraConfiguracion(tran.CodTransaccion);
            txtTransaccion.Text = tran.Sigla;
            lbNombreTransaccion.Text = tran.Descripcion;
            lbNombreTransaccion.Visible = true;
        }

        private void F2TransferenciaEntreAlmacenes_Load(object sender, EventArgs e)
        {
            doc = admtd.BuscaTipoDocumento("CI");// TIPO DOCUMENTO CI COTIZACION INTERNA (DOCUMENTO PEDIDO POR CARSALSI)
            CodTransaccion = 15; //TRANSFERENCIA DIRECTA
            CargaTransaccion();
            txtDocRef.Text = doc.Sigla;
            CodDocumento = doc.CodTipoDocumento;
            cmbMoneda.SelectedIndex = 0;
            dtpFecha.MaxDate = DateTime.Today.Date;
            if (Proceso == 1)
            {
                txtCodAlmacen.Text = frmLogin.iCodAlmacen.ToString();
                almacen = admAlmacen.CargaAlmacen(frmLogin.iCodAlmacen);
                txtOrigen.Text = almacen.Descripcion;
                CargaAlmacenDestino(frmLogin.iCodEmpresa, frmLogin.iCodAlmacen);
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
                btnAprobar.Visible = false;
                btnRechazar.Visible = false;
                sololectura(true);
            }
            else if (Proceso == 2)
            {
                CargaTransferencia();
            }
            else if (Proceso == 3)
            {
                 CargaTransferencia();
                tran = admTransaccion.MuestraTransaccionS("TD", 1);
                doc = admtd.BuscaTipoDocumento(transfer.SiglaDocumento);
                txtCodAlmacen.Text = transfer.CodAlmacenOrigen.ToString();
                almacen = admAlmacen.CargaAlmacen(transfer.CodAlmacenOrigen);
                txtOrigen.Text = almacen.Descripcion;
                txtDocRef.Text = doc.Sigla;
                CargaAlmacenDestino(frmLogin.iCodEmpresa, transfer.CodAlmacenOrigen);
                sololectura(false);
                if (caso == 0) // TRANFERENCIA PENDIENTES
                {
                    txtDocSal.Visible = false;
                    txtDocIng.Visible = false;
                    label7.Visible = false;
                    label6.Visible = false;
                    txtDocSal.Enabled = false;
                    txtDocIng.Enabled = false;
                    btnAprobar.Visible = true;
                    btnRechazar.Visible = true;
                    btnImprimir.Visible = false;
                    MessageBox.Show("Puede Imprimir, Aprobar o Rechazar la Transferencia","Transferencia Directa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (caso == 1) // TRANFERENCIA APROBADAS
                {
                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    label7.Visible = true;
                    label6.Visible = true;
                    txtDocSal.Enabled = false;
                    txtDocIng.Enabled = false;
                    txtdescripcion.Enabled = false;
                    
                    NS = admNS.CargaNS(CodTransDirecta);
                    if (NS!=null) txtDocSal.Text = NS.CodNotaSalida;
                    NI = admNI.CargaNI(CodTransDirecta);
                    if (NI != null) txtDocIng.Text = NI.CodNotaIngreso;
                    txtdescripcion.Text = transfer.DescripcionRechazo;
                }
                else if (caso == 2 || caso == 3)  // TRANFERENCIA ENVIADAS
                {
                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    txtDocSal.Enabled = false;
                    txtDocIng.Enabled = false;
                    txtDocSal.Visible = true;
                    txtDocIng.Visible = true;
                    label7.Visible = true;
                    label6.Visible = true;
                    txtdescripcion.Enabled = false;
                    NS = admNS.CargaNS(CodTransDirecta);
                    if (NS != null)  txtDocSal.Text = NS.CodNotaSalida;
                    NI = admNI.CargaNI(CodTransDirecta);
                    if (NI != null) txtDocIng.Text = NI.CodNotaIngreso;
                    txtdescripcion.Text = transfer.DescripcionRechazo;
                }
                //dgvDetalle.Columns["preciounitario"].DefaultCellStyle.Format = "#,0.0000";
               // dgvDetalle.Columns["subtotal"].DefaultCellStyle.Format = "#,0.0000";
            }
        }

        private void sololectura(Boolean estado)
        {
            txtTransaccion.Enabled = estado;
            txtDocRef.Enabled = estado;
            txtCodAlmacen.Enabled = estado;
            txtComentario.Enabled = estado;
            dtpFecha.Enabled = estado;
            txtdescripcion.Visible = !estado;
            label8.Visible = !estado;
            cmbMoneda.Enabled = false;
            txtOrigen.Enabled = estado;
            cmbDestino.Enabled = estado;
            btnGuardar.Visible = estado;
            btnEliminar.Visible = estado;
            btnDetalle.Visible = estado;
            txtDocIng.Visible = !estado;
            txtDocSal.Visible = !estado;
            label7.Visible = !estado;
            label6.Visible = !estado;
            btnImprimir.Visible = !estado;
            btnImprimir.Enabled = !estado;
        }

        private void CargaAlmacenDestino(int codempres, int codal)
        {
            cmbDestino.DataSource = admAlmacen.ListaAlmacen2();
            cmbDestino.DisplayMember = "nombre";
            cmbDestino.ValueMember = "codAlmacen";
            if (Proceso == 3)
            {
                cmbDestino.SelectedValue = transfer.CodAlmacenDestino;
                cmbDestino_SelectionChangeCommitted(new object(),new EventArgs());
            }
            else
            {
                cmbDestino.SelectedValue = -1;
            }
            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {

                if (Application.OpenForms["frmDetalleGuia"] != null)
                {
                    Application.OpenForms["frmDetalleGuia"].Activate();
                }
                else
                {
                    frmDetalleGuia form = new frmDetalleGuia();
                    form.Procede = 3;
                    form.ShowDialog();
                }
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cerrarformulario();
        }

        private void cmbDestino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDireccion.Clear();
            if (Convert.ToInt32(cmbDestino.SelectedValue) >= 0)
            {
                almacen = admAlmacen.CargaAlmacen(Convert.ToInt32(cmbDestino.SelectedValue));
                txtDireccion.Text = almacen.Ubicacion;
                transfer.CodAlmacenDestino = Convert.ToInt32(cmbDestino.SelectedValue);
            }
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
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
                txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);               
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
               
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.RowCount > 0)
            {
                if (cmbDestino.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione almacen destino para guardar transferencia!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Proceso != 0)
                {
                    if (txtcodserie.Text != "" && txtNumero.Text != "")
                    {
                        transfer.CodAlmacenOrigen = frmLogin.iCodAlmacen;
                        transfer.CodTipoDocumento = 24; // Documento COTIZACION INTERNA (documento solicitado por carsalsi)
                        if (cmbMoneda.SelectedIndex == 0) { transfer.Moneda = 1; } else { transfer.Moneda = 2; }
                        transfer.FechaEnvio = dtpFecha.Value;
                        transfer.FechaEntrega = dtpFecha.Value;
                        transfer.FormaPago = 0;
                        transfer.FechaPago = dtpFecha.Value.Date;
                        transfer.CodListaPrecio = 0;
                        transfer.Comentario = txtComentario.Text;
                        transfer.DescripcionRechazo = txtdescripcion.Text;
                        transfer.MontoBruto = Convert.ToDecimal(txtBruto.Text);
                        transfer.MontoDscto = 0.00m;
                        transfer.Igv = 0.00m;
                        transfer.Total = Convert.ToDecimal(txtValorVenta.Text);
                        transfer.CodUser = frmLogin.iCodUser;
                        transfer.Estado = 1;
                        transfer.Codserie = Convert.ToInt32(txtcodserie.Text);
                        transfer.Serie = txtSerie.Text;
                        transfer.Numerodocumento = txtNumero.Text;

                        if (Proceso == 1)
                        {
                            if (admTransferencia.insert(transfer))
                            {
                                RecorreDetalle();
                                if (detalle.Count > 0)
                                {
                                    foreach (clsDetalleTransferencia det in detalle)
                                    {
                                        admTransferencia.insertdetalle(det);
                                    }
                                }
                                MessageBox.Show("Los datos se guardaron correctamente!", "Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (transfer.CodTransDir != null) { CodTransDirecta = Convert.ToInt32(transfer.CodTransDir); }
                                CargaTransferencia();
                                sololectura(true);
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (admTransferencia.update(transfer))
                            {
                                RecorreDetalle();
                                foreach (clsDetalleTransferencia det in transfer.Detalle)
                                {
                                    foreach (clsDetalleTransferencia det1 in detalle)
                                    {
                                        if (det.Equals(det1))
                                        {
                                            admTransferencia.updatedetalle(det1);
                                            return;
                                        }
                                    }
                                    admTransferencia.deletedetalle(det.CodDetalleTransfer);
                                }
                                foreach (clsDetalleTransferencia deta in detalle)
                                {
                                    if (deta.CodDetalleTransfer == 0)
                                    {
                                        admTransferencia.insertdetalle(deta);
                                    }
                                }

                                MessageBox.Show("Los datos se actualizaron correctamente!", "Transferencia Directa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    cerrarformulario();
                }
            }
            else
            {
                MessageBox.Show("Se necesita agregar datos a la tabla detalle para guardar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocIng.Focus();
            }
        }

        private void CargaTransferencia()
        {
            try
            {
                transfer = admTransferencia.CargaTransferencia(Convert.ToInt32(CodTransDirecta));
                if (transfer != null)
                {
                    txtCodTransDir.Text = transfer.CodTransDir;
                    dtpFecha.Value = transfer.FechaEnvio;
                    txtcodserie.Text = transfer.Codserie.ToString();
                    txtSerie.Text = transfer.Serie.ToString();
                    txtNumero.Text = transfer.Numerodocumento.ToString();
                    if (transfer.Moneda == 1)
                    {
                        cmbMoneda.SelectedIndex = 0;
                    }
                    else { cmbMoneda.SelectedIndex = 1; }
                    //txtTipoCambio.Text = transfer.TipoCambio.ToString();
                    //cbListaPrecios.SelectedValue = transfer.CodListaPrecio;
                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = transfer.CodTipoDocumento;
                        txtDocRef.Text = transfer.SiglaDocumento;

                        //lbDocumento.Text = transfer.DescripcionDocumento;
                    }
                    txtComentario.Text = transfer.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.0000}", transfer.MontoBruto);
                   
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", transfer.Total - transfer.Igv);
                   
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = admTransferencia.CargaDetalle(Convert.ToInt32(transfer.CodTransDir));
            valorpromedio.Visible = false;
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
            clsDetalleTransferencia deta = new clsDetalleTransferencia();

            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodTransDir = Convert.ToInt32(transfer.CodTransDir);
            deta.CodAlmacenOrigen = Convert.ToInt32(txtCodAlmacen.Text);
            deta.CodAlmacenDestino = transfer.CodAlmacenDestino;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.CantidadPendiente = deta.Cantidad;
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            //deta.CodProv = Convert.ToInt32(fila.Cells[codprovee.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            //deta.Precioigv = Convert.ToBoolean(fila.Cells[precioconigv.Name].Value);
            deta.Valorpromedio = Convert.ToDecimal(fila.Cells[valorpromedio.Name].Value);
            deta.CodUser = frmLogin.iCodUser;


            detalle.Add(deta);
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocSal.Text != "")
                {
                    if (txtDocIng.Text != "")
                    {
                        if (dgvDetalle.RowCount > 0)
                        {
                            NS.NumDoc = txtNumero.Text;
                            NS.CodAlmacen = Convert.ToInt32(txtCodAlmacen.Text);
                            NS.CodCliente = 0;
                            NS.CodNotaCredito = 0;
                            //NS.NombreCliente1 = "";
                            NS.CodSucursal = frmLogin.iCodSucursal;
                            NS.RazonSocialCliente = "";
                            NS.CodAutorizado = 0;
                            NS.FechaSalida = dtpFecha.Value.Date;
                            NS.DocumentoReferencia = 0;
                            NS.CodTipoTransaccion = tran.CodTransaccion;
                            NS.CodTipoDocumento = doc.CodTipoDocumento;
                            NS.CodSerie = Convert.ToInt32(txtcodserie.Text);
                            NS.Serie = txtSerie.Text;
                            if (cmbMoneda.SelectedIndex == 0) { NS.Moneda = 1; }
                            else if (cmbMoneda.SelectedIndex == 1) { NS.Moneda = 2; }
                            NS.FechaSalida = dtpFecha.Value.Date;
                            NS.FormaPago = 0;
                            NS.FechaPago = dtpFecha.Value.Date;
                            NS.Comentario = txtComentario.Text;
                            NS.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            NS.MontoDscto = 0;
                            NS.Igv = 0;
                            NS.Total = Convert.ToDouble(txtValorVenta.Text);
                            NS.CodUser = transfer.CodUser;
                            NS.Estado = 1;
                            NS.Codtransferencia = CodTransDirecta;
                            //NS.DocumentoReferencia = Convert.ToInt32(transfer.CodTransDir);
                            if (admNS.insert(NS))
                            {
                                //NS.CodNotaSalida;
                                RecorreDetalleNS();
                                if (detalleNS.Count > 0)
                                {
                                    foreach (clsDetalleNotaSalida det in detalleNS)
                                    {
                                        admNS.insertdetalle(det);
                                    }
                                }
                                //MessageBox.Show("Los datos de la Nota de Salida se guardaron correctamente", "Transferencia Directa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            NI.NumDoc = txtNumero.Text;
                            NI.CodAlmacen = Convert.ToInt32(cmbDestino.SelectedValue);
                            //NI.cod = 0;
                            //NS.NombreCliente1 = "";
                            NI.CodAutorizado = 0;
                            NI.CodReferencia = 0;
                            NI.CodTipoTransaccion = tran.CodTransaccion;
                            NI.CodTipoDocumento = doc.CodTipoDocumento;
                            NI.CodSerie = Convert.ToInt32(txtSerie.Text);
                            NI.Serie = txtSerie.Text;
                            if (cmbMoneda.SelectedIndex == 0) { NI.Moneda = 1; }
                            else if (cmbMoneda.SelectedIndex == 1) { NI.Moneda = 1; }
                            //NI.Moneda = cmbMoneda.SelectedIndex;
                            NI.FechaIngreso = dtpFecha.Value.Date;
                            NI.FormaPago = 0;
                            NI.FechaPago = dtpFecha.Value.Date;
                            NI.Comentario = txtComentario.Text;
                            NS.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            NI.MontoDscto = 0;
                            NI.Igv = 0;
                            NI.Total = Convert.ToDouble(txtValorVenta.Text);
                            NI.CodUser = transfer.CodUser;
                            NI.Estado = 1;
                            NI.Codtransferencia = CodTransDirecta;
                            //NI.CodReferencia = Convert.ToInt32(transfer.CodTransDir);
                            if (admNI.insert(NI))
                            {
                                RecorreDetalleNI();
                                if (detalleNI.Count > 0)
                                {
                                    foreach (clsDetalleNotaIngreso det1 in detalleNI)
                                    {
                                        admNI.insertdetalle(det1);
                                    }
                                }
                                MessageBox.Show("Se aprobo la transferencia, datos guardados correctamente!", "Transferencia Directa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            admTransferencia.Aprobar(CodTransDirecta);
                            Proceso = 3;
                            caso = 1; // APROBADAS
                            CodTransDirecta = Convert.ToInt32(transfer.CodTransDir);
                            F2TransferenciaEntreAlmacenes_Load(sender, e);
                            F2TransferenciasPendientes form = (F2TransferenciasPendientes)Application.OpenForms["F2TransferenciasPendientes"];
                            if (form != null) form.CargaLista();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el Numero de Documento correctamente!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDocIng.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Numero de Documento correctamente!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocSal.Focus();
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void cerrarformulario()
        {
           this.Close();
        }

        private void RecorreDetalleNI()
        {
            detalleNI.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalleNI(row);
                }
            }
        }

        private void añadedetalleNI(DataGridViewRow fila)
        {
            clsDetalleNotaIngreso deta1 = new clsDetalleNotaIngreso();

            deta1.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta1.CodNotaIngreso = Convert.ToInt32(NI.CodNotaIngreso);
            deta1.CodAlmacen = Convert.ToInt32(cmbDestino.SelectedValue);
            deta1.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta1.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta1.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta1.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta1.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta1.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta1.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta1.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta1.MontoDescuento = 0;
            deta1.ValoReal = (deta1.PrecioUnitario/1.18);
            deta1.Igv = (deta1.ValoReal * 0.18);
            deta1.PrecioReal = (deta1.ValoReal * 1.18);
            deta1.CodUser = frmLogin.iCodUser;
            deta1.Importe = (deta1.PrecioUnitario * deta1.Cantidad);
            deta1.Subtotal = deta1.Importe;
            deta1.PrecioReal = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta1.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta1.CodProveedor = 0;
            deta1.FechaIngreso = dtpFecha.Value;
            
            detalleNI.Add(deta1);
        }

        private void RecorreDetalleNS()
        {
            detalleNS.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalleNS(row);
                }
            }
        }

        private void añadedetalleNS(DataGridViewRow fila)
        {

            clsDetalleNotaSalida deta = new clsDetalleNotaSalida();

            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodNotaSalida = Convert.ToInt32(NS.CodNotaSalida);
            deta.CodAlmacen = transfer.CodAlmacenOrigen;
            deta.CodAlmacen = Convert.ToInt32(txtCodAlmacen.Text);
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.ValorPromedio = Convert.ToDouble(fila.Cells[valorpromedio.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            detalleNS.Add(deta);
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (txtdescripcion.Text != "")
            {
                if (caso == 0)
                {
                    // TRANFERENCIA PENDIENTES
                    if (admTransferencia.rechazado(CodTransDirecta, txtdescripcion.Text))
                    {
                        MessageBox.Show("Se rechazo la transferencia, datos guardados correctamente!", "Transferencia Directa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        F2TransferenciasPendientes form = (F2TransferenciasPendientes)Application.OpenForms["F2TransferenciasPendientes"];
                        form.CargaLista();
                        cerrarformulario();
                        //RecorreDetalle();
                        //if (detalle.Count > 0)
                        //{
                        //    foreach (clsDetalleTransferencia det in detalle)
                        //    {
                        //        admTransferencia.devuelveproductos(det);
                        //    }
                        //}
                    }
                }
            }
            else
            {
                MessageBox.Show("Describa el motivo del rechazo!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdescripcion.Focus(); 
            }
        }
        
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                CRTransferenciaDirecta rpt = new CRTransferenciaDirecta();
                //frmTransferenciaDirecta frm = new frmTransferenciaDirecta();
                frmTransferenciaDirecta frm = new frmTransferenciaDirecta();
                rpt.SetDataSource(ds.RptTransferenciaDirecta(caso, frmLogin.iCodAlmacen, CodTransDirecta).Tables[0]);
                frm.crvTransferenciaPendiente.ReportSource = rpt;
                frm.ShowDialog();
                rpt.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0 && dgvDetalle.Rows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
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
                    num = ser.Numeracion;
                    if (CodSerie != 0)
                    {
                        if (ser.PreImpreso)
                        {
                            CodSerie = ser.CodSerie;
                            txtSerie.Text = ser.Serie;
                            txtcodserie.Text = ser.CodSerie.ToString();
                            txtNumero.Enabled = true;
                            txtNumero.Text = "";
                        }
                        else
                        {
                            CodSerie = ser.CodSerie;
                            txtSerie.Text = ser.Serie;
                            txtcodserie.Text = ser.CodSerie.ToString().PadLeft(3, '0');
                            txtNumero.Text = ser.Numeracion.ToString().PadLeft(6, '0');
                            txtNumero.Enabled = false;
                        }

                    }
                    else
                    {
                        txtDocRef.Focus();
                    }
                    if (CodSerie != 0) { ProcessTabKey(true); }
                }
            }
        }
    }
}
