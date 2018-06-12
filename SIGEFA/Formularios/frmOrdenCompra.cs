using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmOrdenCompra : DevComponents.DotNetBar.Office2007Form
    {

        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Ord = new clsOrdenCompra();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsFormaPago fpago = new clsFormaPago();
        clsValidar ok = new clsValidar();
        clsDetalleOrdenCompra detaSelec = new clsDetalleOrdenCompra();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto prodeta = new clsProducto();
        clsReporteOrdeCompra ds = new clsReporteOrdeCompra();
        clsTipoDocumento tidoc = new clsTipoDocumento();
        clsAdmTipoDocumento Admtipodoc = new clsAdmTipoDocumento();
        clsSerie serie = new clsSerie();
        clsAdmSerie admser = new clsAdmSerie();
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleOrdenCompra> detalle = new List<clsDetalleOrdenCompra>();        
        public Int32 CodProveedor;
        public Int32 CodOrdenCompra;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Procede = 0; //(3) Orden de Compra 
        public Int32 Tipo;

        public frmOrdenCompra()
        {
            InitializeComponent();
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1); // 1 FORMAS DE PAGO PARA LA VENTA
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
            
        }

        private void CargaProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);            
            txtCodProv.Text = prov.Ruc;
            txtNombreProv.Text = prov.RazonSocial;
            txtCodProveedor.Text = prov.CodProveedor.ToString();
           // cmbFormaPago.SelectedValue = prov.FormaPago;

        }

        private void BorrarProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtCodProv.Text = "";
            txtNombreProv.Text = "";
        }

        private Boolean BuscaProveedor()
        {
            prov = AdmProv.BuscaProveedor(txtCodProv.Text);
            if (prov != null)
            {
                txtNombreProv.Text = prov.RazonSocial;
                CodProveedor = prov.CodProveedor;
                return true;
            }
            else
            {
                txtNombreProv.Text = "";
                CodProveedor = 0;
                return false;
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            RecorreDetalle();
            if (Application.OpenForms["frmDetalleIngreso"] != null)
            {
                Application.OpenForms["frmDetalleIngreso"].Activate();
            }
            else
            {
                frmDetalleIngreso form = new frmDetalleIngreso();
                //form.MdiParent = this;
                form.Procede = Procede;
                form.Proceso = 1;
                form.bvalorventa = cbValorVenta.Checked;
                form.codproveedor = Convert.ToInt32(txtCodProveedor.Text);
                //form.productoscarga = detalle;
                form.ShowDialog();
            }
        }

        private void VerificarCabecera()
        {
            Validacion = true;
            if (txtCodProv.Visible && CodProveedor == 0)
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
                    form.Procede = Procede;
                    form.Proceso = 1;
                    form.bvalorventa = cbValorVenta.Checked;
                    //form.productoscarga = detalle;
                    form.ShowDialog();
                }
            }catch(Exception ex)
            {

            }
        }

        private void txtCodProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCodProv.Text != "")
                {
                    if (BuscaProveedor())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El proveedor no existe, Presione F1 para consultar la tabla de ayuda", "Orden Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }
                }
            }
        }

        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            cargaMoneda();
            cmbMoneda.SelectedIndex = 0;
            CargaFormaPagos();
            //tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date);
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
            tidoc = Admtipodoc.CargaTipoDocumento(13);// 13 orden de compra
            serie = admser.BuscaSeriexDocumento(tidoc.CodTipoDocumento, frmLogin.iCodAlmacen);
            if (serie == null) 
            {
                MessageBox.Show("Debe agregar Serie para este tipo de Documento" + Environment.NewLine + "Porfavor Cierre esta Ventana Cree la Serie y Vuelva Abrir", "Orden Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }

            if (Proceso == 1)
            {
                //txtOrdenCompra.Text = admser.traeNumeracion(frmLogin.iCodAlmacen, tidoc.CodTipoDocumento).ToString();
            }
            if (Proceso == 2)
            {
                CargaOrdenCompra();
            }
            else if (Proceso == 3)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
            else if (Proceso == 4)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
            else if (Proceso == 5)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            //cmbMoneda.SelectedIndex = -1;
        }

        private void sololectura(Boolean estado)
        {            
            dtpFecha.Enabled = !estado;
            txtCodProv.ReadOnly = estado;
            cmbMoneda.Enabled = !estado;
            txtCodProv.Enabled = !estado;
            btnDetalle.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtOrdenCompra.ReadOnly = estado;
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
        }

        private void CargaOrdenCompra()
        {
            try
            {
                Ord = AdmOrden.CargaOrdenCompra(Convert.ToInt32(CodOrdenCompra));
                if (Ord != null)
                {
                    txtOrdenCompra.Text = Ord.CodOrdenCompra.ToString().PadLeft(11,'0');
                    if (txtCodProv.Enabled)
                    {
                        CodProveedor = Ord.CodProveedor;
                        txtCodProv.Text = Ord.RUCProveedor;
                        txtNombreProv.Text = Ord.RazonSocialProveedor;
                        BuscaProveedor();
                    }
                    dtpFecha.Value = Ord.FechaIngreso;
                    cmbMoneda.SelectedIndex = Ord.Moneda;
                    txtTipoCambio.Text = Ord.TipoCambio.ToString();
                    if (txtOrdenCompra.Enabled)
                    {
                        //se carga el codigo de la orden de compra
                        //txtOrdenCompra.Text = 
                    }
                    cmbFormaPago.SelectedValue = Ord.FormaPago;
                    dtpFechaPago.Value = Ord.FechaPago;
                    txtComentario.Text = Ord.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.0000}", Ord.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.0000}", Ord.MontoDscto);
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", Ord.Total - Ord.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.0000}", Ord.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", Ord.Total);
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmOrden.CargaDetalle(Convert.ToInt32(Ord.CodOrdenCompra));
            RecorreDetalle();
            Ord.Detalle = detalle;
        }

        private void txtCodProv_KeyDown(object sender, KeyEventArgs e)
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
                    form.Procede = 3;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CodProveedor = form.GetCodProveeder();
                        txtCodProveedor.Text = CodProveedor.ToString();
                        CargaProveedor();
                        ProcessTabKey(true);
                    }
                }
            }
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {
                calculatotales();
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

        private void txtCodProv_Leave(object sender, EventArgs e)
        {
            if (CodProveedor == 0)
            {
                txtCodProv.Focus();
            }
            else
            {
                VerificarCabecera();
                if (Validacion)
                {
                    btnDetalle.Enabled = true;
                }
            }
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
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
                Ord.CodAlmacen = frmLogin.iCodAlmacen;
                Ord.CodProveedor = CodProveedor;
                Ord.Comentario = txtComentario.Text;
                Ord.CodTipoDocumento = tidoc.CodTipoDocumento;
                Ord.CodSerie = serie.CodSerie;
                Ord.NumDoc = serie.Numeracion.ToString();
                Ord.FechaIngreso = dtpFecha.Value;
                Ord.CodUser = frmLogin.iCodUser;                
                Ord.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                if (txtTipoCambio.Visible) { Ord.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text); }
                Ord.MontoBruto = Convert.ToDecimal(txtBruto.Text);
                Ord.MontoDscto = Convert.ToDecimal(txtDscto.Text);
                Ord.Igv = Convert.ToDecimal(txtIGV.Text);
                Ord.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                Ord.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                Ord.FechaPago = dtpFechaPago.Value;
                                               
                if (Proceso == 1)
                {                    
                    if (AdmOrden.insert(Ord))
                    {
                        Int32 cuenta = 0;
                        RecorreDetalle();
                        if (detalle.Count > 0)
                        {  
                            foreach (clsDetalleOrdenCompra det in detalle)
                            {
                                if (AdmOrden.insertdetalle(det)) { cuenta++; }
                            }
                        }
                        if (detalle.Count == cuenta)
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtOrdenCompra.Text = Ord.CodOrdenCompraNuevo.ToString().PadLeft(11, '0');
                            sololectura(true);
                        }
                    }
                }
                else if (Proceso == 2)
                {
                    if (AdmOrden.update(Ord))
                    {
                        RecorreDetalle();
                        foreach (clsDetalleOrdenCompra det in Ord.Detalle)
                        {
                            foreach (clsDetalleOrdenCompra det1 in detalle)
                            {
                                if (det.CodDetalleOrdenCompra == det1.CodDetalleOrdenCompra)
                                {
                                    AdmOrden.updatedetalle(det1);                                    
                                }                               
                            }
                            AdmOrden.deletedetalle(det.CodDetalleOrdenCompra);
                        }
                        foreach (clsDetalleOrdenCompra deta in detalle)
                        {
                            if (deta.CodDetalleOrdenCompra == 0)
                            {
                                AdmOrden.insertdetalle(deta);
                            }
                        }                        
                        MessageBox.Show("Los datos se actualizaron correctamente", "Orden Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
            clsDetalleOrdenCompra deta = new clsDetalleOrdenCompra();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodOrdenCompra = Convert.ToInt32(Ord.CodOrdenCompraNuevo);
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
            deta.Flete = Convert.ToDouble(fila.Cells[flete.Name].Value);
            deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            deta.FechaIngreso = dtpFecha.Value;
            deta.CodUser = frmLogin.iCodUser;
            if (txtCodProveedor.Text == "") txtCodProveedor.Text = "0";
            deta.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
            detalle.Add(deta);
        }

        private void CargaFilaDetalle(DataGridViewRow fila)
        {            
            detaSelec.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            detaSelec.CodOrdenCompra = Convert.ToInt32(Ord.CodOrdenCompra);
            detaSelec.CodAlmacen = frmLogin.iCodAlmacen;
            detaSelec.Moneda = cmbMoneda.SelectedIndex;
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
            detaSelec.Flete = Convert.ToDouble(fila.Cells[flete.Name].Value);
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
                    form.Procede = 10;
                    form.bvalorventa = cbValorVenta.Checked;
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.txtReferencia.ReadOnly = true;
                    form.txtControlStock.Text = row.Cells[serielote.Name].Value.ToString();
                    form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
                    form.txtPrecio.Text = row.Cells[preciounit.Name].Value.ToString();
                    form.txtDscto1.Text = row.Cells[dscto1.Name].Value.ToString();
                    form.txtDscto2.Text = row.Cells[dscto2.Name].Value.ToString();
                    form.txtDscto3.Text = row.Cells[dscto3.Name].Value.ToString();
                    form.txtPrecioNeto.Text = row.Cells[importe.Name].Value.ToString();
                    form.txtCantidad.Focus();
                    form.ShowDialog();                    
                }
            }
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            }
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                calculatotales();
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
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
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
                if (Proceso != 0 && c.Visible)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
            {
                if (Proceso == 1)
                {
                    calculatotales();
                }
            }
        }

        private void txtPDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void recalculadetalle()
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                row.Cells[valorventaconflete.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) + Convert.ToDecimal(row.Cells[flete.Name].Value);
                row.Cells[pvconflete.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) + Convert.ToDecimal(row.Cells[flete.Name].Value);
                if (Convert.ToDecimal(row.Cells[flete.Name].Value) > 0.00m && row.Cells[flete.Name].Value.ToString() != "")
                {
                    row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventaconflete.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                    row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[pvconflete.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                }
                else 
                {
                    row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value);
                    row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidad.Name].Value); 
                }
            }

        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.Visible)
                return;
            if (dgvDetalle.Rows.Count >= 1 && dgvDetalle.CurrentRow.Index == e.RowIndex && e.RowIndex != -1)
            {
                CargaFilaDetalle(dgvDetalle.CurrentRow);
            }            
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.Visible)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
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

        private void frmOrdenCompra_Shown(object sender, EventArgs e)
        {
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CROrdenCompra rpt = new CROrdenCompra();
                frmRptOrdenCompra frm = new frmRptOrdenCompra();
                rpt.SetDataSource(ds.OrdenCompra(Convert.ToInt32(txtOrdenCompra.Text)).Tables[0]);
                frm.crvOrdenCompra.ReportSource = rpt;
                frm.Show();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
