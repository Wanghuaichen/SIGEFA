using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using System.Data;

namespace SIGEFA.Formularios
{
    public partial class frmPedido : DevComponents.DotNetBar.Office2007Form
    {
        public frmPedido()
        {
            InitializeComponent();
        }

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
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        
        Int32 CodLista = 0;
        public Int32 CantRegistros = 0;

        public List<Int32> config = new List<Int32>();
        public List<clsDetallePedido> detalle = new List<clsDetallePedido>();
        public String CodPedido;
        public Int32 CodCotizacion;
        public Int32 CodProveedor;
        public Int32 CodCliente = 1;//PARA QUE CARGE AUTOMATICAMENTE DE LA BASE EL CLIENTE POR DEFECTO QUE ES 1
        public String NombreCliente;
        public Int32 CodDocumento;
        public Int32 CodAutorizado;
        public Int32 Tipo;
        public decimal tipoCambio = 0;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        clsConsultasExternas ext = new clsConsultasExternas();



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmDetalleSalida"] != null)
                {
                    Application.OpenForms["frmDetalleSalida"].Activate();
                }
                else
                {
                    frmDetalleSalida form = new frmDetalleSalida();
                    form.Procede = 3;
                    form.Proceso = 1;

                    form.bvalorventa = chkvalor.Checked;
                    form.Codlista = CodLista;
                    form.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    form.tc = Convert.ToDouble(txtTipoCambio.Text);
                    form.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    form.codTipodoc = doc.CodTipoDocumento;
                    form.ShowDialog();


                }
            }
            catch (Exception ex)
            {
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0 && dgvDetalle.Rows.Count > 0)
            {
                if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value) == 0)
                {
                    dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                    CantRegistros = CantRegistros + 1;
                    lblCantidadRegistros.Text = "Cantidad Registros: " + CantRegistros;
                }
                else
                {
                    if (MessageBox.Show("¿Realmente desea eliminar el item seleccionado?", "Pedido Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //if (AdmNota.deletedetalle(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value)))
                        if (AdmPedido.deletedetalle(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value)))
                        {
                            MessageBox.Show("El detalle se eliminó correctamente", "Pedido Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                            CantRegistros = CantRegistros + 1;
                            lblCantidadRegistros.Text = "Cantidad Registros: " + CantRegistros;
                        }
                    }
                }
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
                    Int32 coddet = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value);
                    frmDetalleSalida form = new frmDetalleSalida();
                    form.Proceso = 2;
                    form.Procede = 3;
                    //form.Margen = Convert.ToDecimal(txtMargen.Text) / 100;
                    form.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.CargaProducto(Convert.ToInt32(form.txtCodigo.Text));
                    int index = form.cmbUnidad.FindString(row.Cells[unidad.Name].Value.ToString());
                    form.cmbUnidad.SelectedIndex = index;
                    if (form.cmbUnidad.Items.Count > 0)
                    {
                        form.cmbUnidad_SelectionChangeCommitted(sender, e);
                    }
                    form.txtCantidad.Text = Decimal.ToInt32(Convert.ToDecimal(row.Cells[cantidad.Name].Value.ToString())).ToString();
                    form.txtPrecio.Text = row.Cells[preciounit.Name].Value.ToString();
                    //form.txtPMSoles.Text = row.Cells[preciounitariomargen.Name].Value.ToString();
                    //  form.txtPMDolares.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(row.Cells[preciounitariomargen.Name].Value) / Convert.ToDecimal(txtTipoCambio.Text));
                    form.txtDscto1.Text = row.Cells[dscto1.Name].Value.ToString();
                    form.txtDscto2.Text = row.Cells[dscto2.Name].Value.ToString();
                    form.txtDscto3.Text = row.Cells[dscto3.Name].Value.ToString();
                    form.txtPrecioNeto.Text = row.Cells[importe.Name].Value.ToString();
                    form.txtPrecioNetoDolares.Text = String.Format("{0:#,##0.00}", Convert.ToDecimal(row.Cells[importe.Name].Value) / Convert.ToDecimal(txtTipoCambio.Text));
                    form.ShowDialog();
                    dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value = coddet;
                }
            }
        }


        private void CargaCliente()
        {
            cli = AdmCli.MuestraCliente(CodCliente);
            //if (cmbTipoCodigo.SelectedIndex == 0)
            //{
            //    if (cli.Dni != "")
            //    {
            //        txtCodCliente.Text = cli.Dni;
            //        txtNombreCliente.Text = cli.Nombre;
            //        txtDireccion.Text = cli.DireccionLegal;
            //    }
            //    else
            //    {
            //        cmbTipoCodigo.SelectedIndex = 1;
            //        txtCodCliente.Text = cli.Ruc;
            //        txtNombreCliente.Text = cli.RazonSocial;
            //        txtDireccion.Text = cli.DireccionLegal;
            //    }
            //}
            //else
            //{
            //    txtCodCliente.Text = cli.Ruc;
            //    txtNombreCliente.Text = cli.RazonSocial;
            //    txtDireccion.Text = cli.DireccionLegal;
            //}
            txtCodCliente.Text = cli.CodigoPersonalizado;
            txtNombreCliente.Text = cli.RazonSocial;
            txtDireccion.Text = cli.DireccionLegal;

            cbListaPrecios.SelectedValue = cli.CodListaPrecio;
            //EventArgs eee = new EventArgs();
            //cbListaPrecios_SelectionChangeCommitted(cbListaPrecios, eee);
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
                if (Application.OpenForms["frmClientesLista"] != null)
                {
                    Application.OpenForms["frmClientesLista"].Activate();
                }
                else
                {
                    frmClientesLista form = new frmClientesLista();
                    form.Proceso = 3;
                    form.ShowDialog();
                    txtCodCliente.Text = "";
                    txtDireccion.Text = "";
                    txtNombreCliente.Text = "";
                    cli = form.cli;
                    CodCliente = cli.CodCliente;
                    if (CodCliente != 0) { NombreCliente = cli.Nombre; CargaCliente(); ProcessTabKey(true); }
                }
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (CodCliente == 0)
            {
                txtCodCliente.Focus();
            }
            VerificarCabecera();
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
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
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
                    txtDocRef.Text = doc.Sigla;
                    txtNombreCliente.Text = "";
                    txtCodCliente.Text = "";
                    txtDocRef.Enabled = true;
                    btnGuardar.Enabled = true;
                    lbDocumento.Visible = true;
                    if (CodDocumento != 0) { ProcessTabKey(true); }
                    if (CodDocumento == 1)
                    {
                        txtCodCliente.Text = "C0001";
                        BuscaCliente();
                        //txtNombreCliente.Enabled = true;
                        //txtCodCliente.Enabled = false;
                    }
                    else
                    {
                        txtCodCliente.Enabled = true;
                        txtDocRef.Enabled = true;
                        txtCodCliente.Text = "";
                        txtNombreCliente.Text = "";
                        txtDireccion.Text = "";
                    }
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
            DataTable newData = new DataTable();
            dgvDetalle.Rows.Clear();
            try
            {
                newData = AdmPedido.CargaDetalle(Convert.ToInt32(pedido.CodPedido));
                foreach (DataRow row in newData.Rows)
                {
                    dgvDetalle.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                        row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(),
                        row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(),
                        row[15].ToString(), row[16].ToString(), row[17].ToString(), row[18].ToString(),
                        row[19].ToString(), row[20].ToString(), row[21].ToString(), row[23].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 2;
        }
        private void CargaNotaSalida()
        {
            cmbFormaPago.SelectedValue = nota.FormaPago;
            dtpFechaPago.Value = nota.FechaPago;
            txtComentario.Text = nota.Comentario;
            txtBruto.Text = String.Format("{0:#,##0.00}", nota.MontoBruto);
            txtDscto.Text = String.Format("{0:#,##0.00}", nota.MontoDscto);
            txtValorVenta.Text = String.Format("{0:#,##0.00}", nota.Total - nota.Igv);
            txtIGV.Text = String.Format("{0:#,##0.00}", nota.Igv);
            txtPrecioVenta.Text = String.Format("{0:#,##0.00}", nota.Total);
            CargaDetalle();
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
           
             CargaFormaPagos();
             CargaMoneda();
            // CargaListaPrecios();
            dtpFecha.MaxDate = DateTime.Today.Date;
            CargaCliente();
            if (Proceso == 1)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
                txtDocRef.Focus();
            }
            else if (Proceso == 2)
            {
                btnEditar.Visible = false;
                CargaPedido();
            }
            else if (Proceso == 3)
            {
                CargaPedido();
                sololectura(true);
            }
        }
        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }
        //private void CargaListaPrecios()
        //{
        //    cbListaPrecios.DataSource = admLista.MuestraListas(frmLogin.iCodAlmacen);
        //    cbListaPrecios.DisplayMember = "nombre";
        //    cbListaPrecios.ValueMember = "codListaPrecio";
        //    cbListaPrecios.SelectedIndex = -1;
        //}

        private void frmPedido_Shown(object sender, EventArgs e)
        {
            if (Proceso == 1)
            {
                txtDocRef.Text = "NP";
                //txtCodCliente.Text = "C0001";
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                txtDocRef_KeyPress(txtDocRef, ee);
                //BuscaCliente();
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
            btnNuevo.Focus();
            btnGuardar.Enabled = true;
        }

        private void CargaPedido()
        {
            try
            {
                pedido = AdmPedido.CargaPedido(Convert.ToInt32(CodPedido));
                if (pedido != null)
                {
                    txtPedido.Text = pedido.Numeracion.ToString("0000");
                    doc.CodTipoDocumento = pedido.CodTipoDocumento;
                    if (pedido.CodCotizacion != 0)
                    {
                        coti = AdmCot.CargaCotizacion(pedido.CodCotizacion, frmLogin.iCodAlmacen);
                        txtCotizacion.Text = coti.CodCotizacion;
                    }

                    if (txtCodCliente.Enabled)
                    {
                        if (pedido.SiglaDocumento.Equals("BV"))
                        {
                            CodCliente = pedido.CodCliente;
                            cli.CodCliente = CodCliente;
                            txtCodCliente.Text = pedido.CodigoPersonalizado;
                            if (pedido.RazonSocialCliente != "") txtNombreCliente.Text = pedido.RazonSocialCliente;
                            else txtNombreCliente.Text = pedido.Nombre;
                            // txtNombreCliente.Enabled = false;
                            txtDireccion.Text = pedido.Direccion;

                        }
                        else
                        {
                            CodCliente = pedido.CodCliente;
                            cli.CodCliente = CodCliente;
                            txtCodCliente.Text = pedido.CodigoPersonalizado;
                            if (pedido.RazonSocialCliente != "") txtNombreCliente.Text = pedido.RazonSocialCliente;
                            else txtNombreCliente.Text = pedido.Nombre;
                            txtDireccion.Text = pedido.Direccion;
                        }
                    }
                   // txtNombreCliente.Enabled = true;
                    dtpFecha.Value = pedido.FechaPedido;
                    cmbMoneda.SelectedValue = pedido.Moneda;
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
                    CargaDetalle();
                    if (Proceso == 2)
                    {
                        pedido.Detalle = new List<clsDetallePedido>();
                        RecorreDetallePedido();
                        lblCantidadRegistros.Text = "Cantidad Registros: " + CantRegistros;
                    }
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

        private void RecorreDetallePedido()
        {
            pedido.Detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    CantRegistros++;
                    añadedetallePedido(row);
                }
            }
        }
        /*
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

        */
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (VerificarStockDisponible())
                //{

                Boolean verificaroll = true;

                    if (verificarPrecioVenta())
                    {
                        if (dgvDetalle.RowCount == 0)
                        {
                            MessageBox.Show("No se puedo Guardar, no existen productos en el pedido!", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnNuevo.Focus();
                        }
                        else if (superValidator1.Validate())
                        {
                            if (Proceso != 0)
                            {
                                pedido.CodAlmacen = frmLogin.iCodAlmacen;
                                pedido.CodCliente = cli.CodCliente;
                                pedido.CodTipoDocumento = doc.CodTipoDocumento;
                                if (pedido.CodTipoDocumento == 1)
                                {
                                    pedido.Nombrecliente = txtNombreCliente.Text;
                                }
                                else
                                {
                                    pedido.Nombrecliente = "";
                                }
                                pedido.CodCotizacion = CodCotizacion;
                                pedido.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                                if (txtTipoCambio.Visible)
                                {
                                    pedido.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                                }
                                pedido.FechaPedido = dtpFecha.Value.Date;
                                pedido.FechaEntrega = dtpFechaEntrega.Value.Date;
                                pedido.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                                pedido.FechaPago = dtpFecha.Value.AddDays(fpago.Dias);
                                pedido.CodListaPrecio = Convert.ToInt32(cbListaPrecios.SelectedValue);
                                if (fpago.Dias == 0)
                                {
                                    nota.FechaCancelado = dtpFecha.Value.Date;
                                    nota.Cancelado = 1; // Para saber si la nota esta pendiente de pago o esta cancelada
                                }
                                pedido.Comentario = txtComentario.Text;
                                pedido.CodAutorizado = CodAutorizado;
                                pedido.MontoBruto = Convert.ToDouble(txtBruto.Text);
                                pedido.MontoDscto = Convert.ToDouble(txtDscto.Text);
                                pedido.Igv = Convert.ToDouble(txtIGV.Text);
                                pedido.Total = Convert.ToDouble(txtPrecioVenta.Text);
                                pedido.CodUser = frmLogin.iCodUser;
                                pedido.Estado = 1;
                                // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas
                                if (Proceso == 1)
                                {
                                    if (AdmPedido.insert(pedido))
                                    {
                                        RecorreDetalle();

                                        if (detalle.Count > 0)
                                        {
                                            foreach (clsDetallePedido det in detalle)
                                            {
                                                det.Codtipodoc = pedido.CodTipoDocumento;
                                                AdmPedido.insertdetalle(det);

                                                if (det.CodDetallePedido == 0)
                                                {
                                                    MessageBox.Show("Error No se puede Registrar los Datos, falta Stock de Productos por favo Verifique", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    AdmPedido.rollbackpedido(Convert.ToInt32(pedido.CodPedido));

                                                    verificaroll = false;

                                                    //break;
                                                    return;
                                                }
                                            }
                                        }

                                        if (verificaroll == true)
                                        {
                                            CodPedido = pedido.CodPedido;
                                            CantRegistros = 0;
                                            CargaPedido();

                                            MessageBox.Show("Los datos se guardaron correctamente!\nPedido: " + Convert.ToInt32(pedido.Numeracion) + "\nTotal: " + pedido.Total + " Soles.", "Pedido Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            NuevoPedido();

                                            frmPedidosPendientes form = (frmPedidosPendientes)Application.OpenForms["frmPedidosPendientes"];

                                            if (form != null) form.CargaLista();
                                        }


                                    }

                                }

                                else if (Proceso == 2)
                                {
                                    if (AdmPedido.update(pedido))
                                    {
                                        RecorreDetalle();
                                        foreach (clsDetallePedido det in pedido.Detalle)
                                        {
                                            foreach (clsDetallePedido det1 in detalle)
                                            {
                                                if (det.CodDetallePedido == det1.CodDetallePedido && det1.CodDetallePedido != 0)
                                                {
                                                    AdmPedido.updatedetalle(det1);
                                                }
                                            }
                                        }
                                        foreach (clsDetallePedido deta in detalle)
                                        {
                                            if (deta.CodDetallePedido == 0)
                                            {
                                                AdmPedido.insertdetalle(deta);
                                            }
                                        }

                                        CodPedido = pedido.CodPedido;
                                        CantRegistros = 0;
                                        CargaPedido();
                                        MessageBox.Show(
                                            "Los datos se guardaron correctamente!\nPedido: " +
                                            Convert.ToInt32(pedido.Numeracion) + "\nTotal: " + pedido.Total + " Soles.",
                                            "Pedido Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        NuevoPedido();

                                        frmPedidosPendientes form =
                                            (frmPedidosPendientes)Application.OpenForms["frmPedidosPendientes"];
                                        if (form != null) form.CargaLista();

                                    }
                                }

                            }
                        }
                    }
                //}
                //else {
                //    List<String> productos = new List<String>();
                //    String variable = "   ";
                //    foreach (DataGridViewRow row in dgvDetalle.Rows)
                //    {
                //        Decimal x = AdmNota.VerificarStock(Convert.ToInt32(row.Cells[codproducto.Name].Value), frmLogin.iCodAlmacen,0);
                //        if (Convert.ToDecimal(row.Cells[cantidad.Name].Value) >= x)
                //        {
                //            productos.Add(row.Cells[descripcion.Name].Value.ToString());
                //        }
                //    }

                //    for (int i = 0; i < productos.Count; i++)
                //    {
                //        variable = variable.Insert(i, " , " + productos[i] + " ");
                //    }
                //    MessageBox.Show("Producto(s) : " + variable + "  , esta Agotado el Stock Disponible. Porfavor Verifique !!!", 
                //        "Pedido - Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message.ToString());
            }
        }

        public void NuevoPedido()
        {
            frmPedido form = new frmPedido();
            form.MdiParent = this.MdiParent;
            form.Proceso = 1;
            form.CantRegistros = 0;
            form.txtDocRef.Focus();
            form.Show();
            this.Close();
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
            clsDetallePedido deta = new clsDetallePedido();
            deta.CodDetallePedido = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodPedido = Convert.ToInt32(pedido.CodPedido);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioMargen = Convert.ToDecimal(fila.Cells[preciounitariomargen.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.Precioigv = Convert.ToBoolean(Convert.ToInt32(fila.Cells[precioconigv.Name].Value));
            deta.Valorpromedio = Convert.ToDecimal(fila.Cells[valorpromedio.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            deta.CodProv = Convert.ToInt32(fila.Cells[codProve.Name].Value);
            detalle.Add(deta);
        }

        private void añadedetallePedido(DataGridViewRow fila)
        {
            clsDetallePedido deta = new clsDetallePedido();
            deta.CodDetallePedido = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodPedido = Convert.ToInt32(pedido.CodPedido);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.PrecioMargen = Convert.ToDecimal(fila.Cells[preciounitariomargen.Name].Value);
            deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.Precioigv = Convert.ToBoolean(Convert.ToInt32(fila.Cells[precioconigv.Name].Value));
            deta.Valorpromedio = Convert.ToDecimal(fila.Cells[valorpromedio.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            deta.CodProv = Convert.ToInt32(fila.Cells[codProve.Name].Value);
            pedido.Detalle.Add(deta);
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            //if (Validacion && Proceso == 1)
            //{
            //    btnDetalle.Enabled = true;
            //}
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
            //ext.limpiar(this.Controls);
            frmPedido form = new frmPedido();
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
            //if (cmbFormaPago.SelectedIndex != -1)
            //{
            //    fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            //    dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias);
            //}
        }

        private void cbListaPrecios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Listap = admLista.CargaListaPrecio(Convert.ToInt32(cbListaPrecios.SelectedValue));
            CodLista = Convert.ToInt32(cbListaPrecios.SelectedValue);
           // actualizaprecios();
            calculatotales();
        }

        //private void actualizaprecios()
        //{
        //    Int32 codProduct = 0;
        //    Decimal precioa, cantidada, brutoa, montodescuentoa, valorventaa, igva, precioventaa, precioreala, valorreala, factorigva;
        //  //  DataTable precios = admLista.CargaListaPrecio(Convert.ToInt32(cbListaPrecios.SelectedValue));

        //    foreach (DataGridViewRow row in dgvDetalle.Rows)
        //    {
        //        codProduct = Convert.ToInt32(row.Cells[codproducto.Name].Value);
        //        foreach (DataRow r in precios.Rows)
        //        {
        //            if (codProduct == Convert.ToInt32(r["codProducto"].ToString()))
        //            {
        //                precioa = Convert.ToDecimal(r["precio"]);
        //                row.Cells[importe.Name].Value = String.Format("{0:#,##0.00}", r["precio"]);
        //                cantidada = Convert.ToDecimal(row.Cells[cantidad.Name].Value);
        //                brutoa = cantidada * precioa;
        //                row.Cells[importe.Name].Value = String.Format("{0:#,##0.00}", brutoa);

        //                precioventaa = brutoa * (1 - (Convert.ToDecimal(row.Cells[dscto1.Name].Value) / 100)) * (1 - (Convert.ToDecimal(row.Cells[dscto2.Name].Value) / 100)) * (1 - (Convert.ToDecimal(row.Cells[dscto3.Name].Value) / 100));
        //                montodescuentoa = brutoa - precioventaa;
        //                row.Cells[montodscto.Name].Value = String.Format("{0:#,##0.00}", montodescuentoa);
        //                if (r["precioneto"].ToString().Equals(r["precio"].ToString()))
        //                {
        //                    valorventaa = precioventaa;
        //                }
        //                else
        //                {
        //                    factorigva = frmLogin.Configuracion.IGV / 100 + 1;
        //                    valorventaa = precioventaa / factorigva;
        //                }
        //                igva = precioventaa - valorventaa;
        //                precioreala = precioventaa / cantidada;
        //                valorreala = valorventaa / cantidada;
        //                row.Cells[precioventa.Name].Value = String.Format("{0:#,##0.00}", precioventaa);
        //                row.Cells[valorventa.Name].Value = String.Format("{0:#,##0.00}", valorventaa);
        //                row.Cells[precioreal.Name].Value = String.Format("{0:#,##0.00}", precioreala);
        //                row.Cells[valoreal.Name].Value = String.Format("{0:#,##0.00}", valorreala);
        //                row.Cells[igv.Name].Value = String.Format("{0:#,##0.00}", igva);
        //            }
        //        }
        //    }
        //}

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
            // txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
            txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);
            txtIGV.Text = String.Format("{0:#,##0.00}", bruto - descuen - valor);
            txtPrecioVenta.Text = String.Format("{0:#,##0.00}", bruto - descuen);
            txtPrecioVenta.Text = txtBruto.Text;
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
                coti = AdmCot.CargaCotizacion(Convert.ToInt32(CodCotizacion),frmLogin.iCodAlmacen);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void Recalcular()
        {
            Double bruto = 0;
            Double descuen = 0;
            Double valor = 0;
            Double figv = 0;
            Double pven = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                bruto = bruto + Convert.ToDouble(row.Cells[importe.Name].Value);
                descuen = descuen + Convert.ToDouble(row.Cells[montodscto.Name].Value);
                valor = valor + Convert.ToDouble(row.Cells[valorventa.Name].Value);
                figv = figv + Convert.ToDouble(row.Cells[igv.Name].Value);
                pven = pven + Convert.ToDouble(row.Cells[precioventa.Name].Value);
            }
            txtBruto.Text = String.Format("{0:#,##0.00}", bruto);
            txtDscto.Text = String.Format("{0:#,##0.00}", descuen);
            txtValorVenta.Text = String.Format("{0:#,##0.00}", valor);
            txtIGV.Text = String.Format("{0:#,##0.00}", figv);
            txtPrecioVenta.Text = String.Format("{0:#,##0.00}", pven);
        }



        private void CargaDetalleCotizacion()
        {
            dgvDetalle.DataSource = AdmCot.CargaDetalle(Convert.ToInt32(coti.CodCotizacion),frmLogin.iCodAlmacen);
        }

        private void calculadescuentogeneral()
        {
            Decimal brutodg = 0;
            Decimal dsctodg = 0;
            Decimal DsctoGlobal = 0;
            Decimal precioventadg = 0;
            Decimal valorventadg = 0;

            if (txtBruto.Text != "") { brutodg = Convert.ToDecimal(txtBruto.Text); } else { brutodg = 0; }
            if (txtDscto.Text != "") { dsctodg = Convert.ToDecimal(txtDscto.Text); } else { dsctodg = 0; }

            if (txtDscto.Text != "" && txtPrecioVenta.Text != "")
            {
                DsctoGlobal = (Convert.ToDecimal(txtBruto.Text) - dsctodg) * (Convert.ToDecimal(txtDscto.Text) / 100);
                //txtDsctoGobal.Text = String.Format("{0:#,##0.00}", DsctoGlobal.ToString());
                precioventadg = brutodg - dsctodg - DsctoGlobal;
                txtPrecioVenta.Text = String.Format("{0:#,##0.00}", precioventadg);
                valorventadg = precioventadg / (1 + (Convert.ToDecimal(frmLogin.Configuracion.IGV) / 100));
                txtValorVenta.Text = String.Format("{0:#,##0.00}", valorventadg);
                txtIGV.Text = String.Format("{0:#,##0.00}", precioventadg - valorventadg);
            }
        }


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
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
            }
        }

        private void dgvDetalle_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {

                //calculatotales();
                Recalcular();//nuevo calculo
                calculadescuentogeneral();

            }
        }

        private void txtDocRef_Leave_1(object sender, EventArgs e)
        {
            //txtCodCliente.Text = "C0001";
            //if(txtCodCliente!=""){
            //    BuscaCliente();


        }

        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
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
                dtpFecha.Focus();
            }
        }

        private void dtpFechaEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNuevo.Focus();
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1 || Proceso == 2)
            {
                if (txtDscto.Text != "")
                {
                    //calculatotales();
                    Recalcular();//nuevo calculo
                    //calculadescuentogeneral();
                }
                else
                {
                    Recalcular();
                }

            }
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
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

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 1 || Proceso == 2)
            {
                if (txtPDescuento.Text != "")
                {
                    calculatotales();
                    Recalcular();//nuevo calculo
                    calculadescuentogeneral();
                }
                else
                {
                    Recalcular();
                }
            }
        }

        public Boolean verificarPrecioVenta()
        {
            Boolean valor = false;
            if (Convert.ToDecimal(txtPrecioVenta.Text) >= 700 && CodCliente == 1)
            {
                MessageBox.Show("Precio venta > S/. 700, registrar(DNI, datos completos del cliente) o seleccionar cliente para guardar pedido", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Application.OpenForms["frmClientesLista"] != null)
                {
                    Application.OpenForms["frmClientesLista"].Activate();
                }
                else
                {
                    frmClientesLista form = new frmClientesLista();
                    form.Proceso = 3;
                    form.ShowDialog();
                    txtCodCliente.Text = "";
                    txtDireccion.Text = "";
                    txtNombreCliente.Text = "";
                    if (form.exit)
                    {
                        cli = form.cli;
                        CodCliente = cli.CodCliente;
                        if (CodCliente != 0)
                        {
                            NombreCliente = cli.Nombre;
                            CargaCliente();
                            valor = true;
                            ProcessTabKey(true);
                        }
                    }
                    else
                    {
                        txtCodCliente.Focus();
                        valor = false;
                    }
                }
            }
            else
            {
                valor = true;
            }
            return valor;
        }

        public Boolean VerificarStockDisponible()
        {
            try
            {
                Boolean valor = false;

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {

                    Decimal x = AdmNota.VerificarStock(Convert.ToInt32(row.Cells[codproducto.Name].Value), frmLogin.iCodAlmacen,0);

                    if (Convert.ToDecimal(row.Cells[cantidad.Name].Value) <= x)
                    {
                        valor = true;
                    }

                    else
                    {
                        valor = false;
                        break;
                    }
                }

                return valor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
                return false;
            }
        }

    }
}
