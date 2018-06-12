using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmNotaIngreso : DevComponents.DotNetBar.Office2007Form
    {
        clsFactura fac = new clsFactura();
        clsAdmFactura AdmFact = new clsAdmFactura();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
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
        clsAdmAutorizado AdmAut = new clsAdmAutorizado();
        clsAutorizado aut = new clsAutorizado();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsValidar ok = new clsValidar();
        clsDetalleNotaIngreso detaSelec = new clsDetalleNotaIngreso();
        clsAdmProducto Admpro = new clsAdmProducto();
        clsProducto prod = new clsProducto();
        clsAdmOrdenCompra AdmOrd = new clsAdmOrdenCompra();
        clsOrdenCompra Orde = new clsOrdenCompra();
        private Decimal Qnueva = 0, QIngresado = 0, QPorAtender = 0;
        public List<Int32> codProd = new List<int>();
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        public List<clsDetalleFactura> detalleFactura= new List<clsDetalleFactura>();
        public String CodNota;
        public Int32 CodTransaccion, codOrdenCompra_nota=0, CodAlmacenOrden=0;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodOrdenCompra;
        public Int32 CodAutorizado;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Tipo;
        private Int32 proce = 0; //(1) Nota IngresoxCompra.
        TextBox txtedit = new TextBox();
        clsValidar val = new clsValidar();
        public DataTable data = new DataTable();
        Decimal total, montoflete;
        public frmNotaIngreso()
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
                if (txtTransaccion.Text.Equals("IOC"))
                {
                    bloqueaBotones2();
                    proce = 1;
                    txtDocRef.Focus();
                    btnDetalle.Visible = true;
                }
            }
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(0);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;
            
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

        private void CargaProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);            
            txtCodProv.Text = prov.Ruc;
            txtNombreProv.Text = prov.RazonSocial;
            txtCodProveedor.Text = prov.CodProveedor.ToString();
        }

        private void BorrarProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtCodProv.Text = "";
            txtNombreProv.Text = "";
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

        private void bloqueaBotones2()
        {
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label19.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label12.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            cmbFormaPago.Visible = false;
            cmbMoneda.Visible = false;
            txtDscto.Visible = false;
            txtTipoCambio.Visible = false;
            cbValorVenta.Visible = false;
            txtValorVenta.Visible = false;
            txtPrecioVenta.Visible = false;
            txtBruto.Visible = false;
            txtFlete.Visible = false;
            txtIGV.Visible = false;
            dtpFechaPago.Visible = false;
            // txtCodProv.Enabled = false;
            txtOrdenCompra.Focus();
            dgvDetalle.Visible = false;
            dgvDetalle2.Visible = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            //btnDetalle.Visible = false;
            btnGuardar.Enabled = true;
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
            try
            {
                RecorreDetalle();
                if (proce == 1)
                {
                    if (txtCodProveedor.Text != "")
                    {
                        if (Application.OpenForms["frmDetalleGuia"] != null)
                        {
                            Application.OpenForms["frmDetalleGuia"].Activate();
                        }
                        else
                        {
                            frmDetalleGuia form = new frmDetalleGuia();
                            form.Procede = 10;
                            form.Proceso = 1;
                            form.codproveedor = Convert.ToInt32(txtCodProveedor.Text);
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese Proveedor");
                        txtCodProv.Focus();
                    }

                }
                else
                {
                    if (txtTransaccion.Text.Equals("IN"))
                    {
                        if (Application.OpenForms["frmDetalleIngreso"] != null)
                        {
                            Application.OpenForms["frmDetalleIngreso"].Activate();
                        }
                        else
                        {
                            frmDetalleIngreso form = new frmDetalleIngreso();
                            //form.MdiParent = this;
                            form.Procede = 6;
                            form.Proceso = 1;
                            form.codproveedor = 0;
                            form.bvalorventa = cbValorVenta.Checked;
                            form.productoscargados = detalle;
                            form.ShowDialog();
                            serielote.Visible = false;
                        }
                    }
                    else if (txtCodProveedor.Text != "")
                    {
                        codProd.Clear();
                        if (dgvDetalle.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dgvDetalle.Rows)
                            {
                                codProd.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
                            }
                        }
                        else
                        {
                            codProd.Add(0);
                        }

                        if (Application.OpenForms["frmDetalleIngreso"] != null)
                        {
                            Application.OpenForms["frmDetalleIngreso"].Activate();
                        }
                        else
                        {
                            frmDetalleIngreso form = new frmDetalleIngreso();
                            //form.MdiParent = this;
                            form.Procede = 6;
                            form.Proceso = 1;
                            form.codproveedor = Convert.ToInt32(txtCodProveedor.Text);
                            form.bvalorventa = cbValorVenta.Checked;
                            //form.productoscargados = detalle;
                            form.ShowDialog();
                            serielote.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese Proveedor");
                        txtCodProv.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        

        private void VerificarCabecera()
        {
            Validacion = true;
            if (CodTransaccion == 0)
            {
                Validacion = false;
            }
            if (txtCodProv.Visible && CodProveedor == 0)
            {
                Validacion = false;
            }
            if (txtOrdenCompra.Visible && CodOrdenCompra == 0)
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
                    form.Procede = 6;
                    form.Proceso = 1;
                    form.bvalorventa = cbValorVenta.Checked;
                    form.productoscargados = detalle;
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
                        MessageBox.Show("El proveedor no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }
                }
            }
        }

        private void frmNotaIngreso_Load(object sender, EventArgs e)
        {
            cargaMoneda();
            CargaFormaPagos();
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            txtTipoCambio.Text = tc.Venta.ToString();
            if (Proceso == 1)
            {
                Bloqueabotones();
            }
            if (Proceso == 2)
            {
                CargaNotaIngreso();
            }
            else if (Proceso == 3)
            {
                CargaNotaIngreso();
                sololectura(true);
            }
            else if (Proceso == 4)
            {
                CargaNotaIngreso();
                sololectura(true);
            }
            else if (Proceso == 5)
            {
                CargaNotaIngreso();
                sololectura(true);
            }
            else if (Proceso == 7)
            {
                txtOrdenCompra.Text = CodOrdenCompra.ToString();
                CargaOrden();
                txtOrdenCompra.Visible = true;
                label8.Visible = true;
                btnGuardar.Enabled = true;
                Proceso = 1;
                btnEditar.Visible = false;
                btnDetalle.Visible = false;
            }
        }
        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex =-1;

        }
        private void sololectura(Boolean estado)
        {            
            txtTransaccion.ReadOnly = estado;
            dtpFecha.Enabled = !estado;
            txtCodProv.ReadOnly = estado;
            cmbMoneda.Enabled = !estado;
            cmbFormaPago.Enabled = !estado;
            txtDocRef.ReadOnly = estado;
            txtNDocRef.ReadOnly = estado;
            txtOrdenCompra.ReadOnly = estado;
            txtComentario.ReadOnly = estado;
            txtAutorizacion.ReadOnly = estado;
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            txtFlete.ReadOnly = estado;
            btnNuevo.Visible = !estado;
            btnEditar.Visible = !estado;
            btnEliminar.Visible = !estado;
            btnGuardar.Visible = !estado;
        }

        private void Bloqueabotones()
        {
            //btnNuevo.Visible = false;
            //btnEditar.Visible = false;
            //btnEliminar.Visible = false;
        }

        private void CargaNotaIngreso()
        {
            try
            {
                nota = AdmNota.CargaNotaIngreso(Convert.ToInt32(CodNota));
                if (nota != null)
                {
                    txtNumDoc.Text = nota.CodNotaIngreso;
                    CodTransaccion = nota.CodTipoTransaccion;
                    CargaTransaccion();
                    if (txtCodProv.Enabled)
                    {
                        CodProveedor = nota.CodProveedor;
                        txtCodProv.Text = nota.RUCProveedor;                        
                        txtNombreProv.Text = nota.RazonSocialProveedor;
                        BuscaProveedor();
                    }
                    dtpFecha.Value = nota.FechaIngreso;
                    //cmbMoneda.SelectedIndex = nota.Moneda;
                    cmbMoneda.SelectedValue = nota.Moneda;
                    txtTipoCambio.Text = nota.TipoCambio.ToString();
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    if (txtAutorizacion.Enabled)
                    {
                        //se guarda el codigo del autorizado y se cargan los datos de este
                    }
                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = nota.CodTipoDocumento;
                        txtDocRef.Text = nota.SiglaDocumento;
                        txtNDocRef.Text = nota.NumDoc;
                        BuscaTipoDocumento();
                        //doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
                        //if (doc != null)
                        //{
                        //    CodDocumento = doc.CodTipoDocumento;
                        //}
                    }
                    if (txtOrdenCompra.Enabled)
                    {
                        //se carga el codigo de la orden de compra
                        //txtOrdenCompra.Text = 
                    }
                    cmbFormaPago.SelectedValue = nota.FormaPago;
                    dtpFechaPago.Value = nota.FechaPago;
                    txtComentario.Text = nota.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.0000}", nota.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.0000}", nota.MontoDscto);
                    txtFlete.Text = String.Format("{0:#,##0.0000}", nota.Flete);
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", nota.Total - nota.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.0000}", nota.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", nota.Total);
                    if (CodTransaccion == 14) { bloqueaBotones2(); bloquearBotonesOIC(); }
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

        private void bloquearBotonesOIC()
        {
            dgvDetalle2.Visible = false; 
            dgvDetalle.Visible = true;
            txtOrdenCompra.Visible = false;
            label8.Visible = false;
            serielote.Visible = false;
            preciounit.Visible = false;
            importe.Visible = false;
            montodscto.Visible = false;
            valorventa.Visible = false;
            igv.Visible = false;
            flete.Visible = false;
            precioventa.Visible = false;
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmNota.CargaDetalle(Convert.ToInt32(nota.CodNotaIngreso));
            RecorreDetalle();
            nota.Detalle = detalle;            
            if (tran.CodTransaccion == 15)
            {
                //TRANSFERENCIA DIRECTA 
                dgvDetalle.Columns["serielote"].Visible = false;
                dgvDetalle.Columns["preciounit"].Visible = false;
                dgvDetalle.Columns["importe"].Visible = false;
                dgvDetalle.Columns["montodscto"].Visible = false;
                dgvDetalle.Columns["valorventa"].Visible = false;
                dgvDetalle.Columns["igv"].Visible = false;
                dgvDetalle.Columns["flete"].Visible = false;
                dgvDetalle.Columns["precioventa"].Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                txtTipoCambio.Visible = false;
                cmbMoneda.Visible = false;
                cbValorVenta.Visible = false;
                label10.Visible = false;
                txtBruto.Visible = false;
                label11.Visible = false;
                txtDscto.Visible = false;
                label19.Visible = false;
                txtFlete.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                txtValorVenta.Visible = false;
                txtIGV.Visible = false;
                txtPrecioVenta.Visible = false;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
                dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias);
            }
            else
            {
                MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFecha.Value = DateTime.Now.Date;
                dtpFecha.Focus();
            }
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
                    form.Procede = 4;
                    form.ShowDialog();
                    if (CodProveedor != 0) { CargaProveedor(); ProcessTabKey(true); } else { BorrarProveedor(); }
                }
            }
        }

        private void frmNotaIngreso_Shown(object sender, EventArgs e)
        {
            if (Proceso == 1 && txtTransaccion.Text == "FT")
            {
                if (tc == null)
                {
                    MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtTipoCambio.Text = tc.Venta.ToString();
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    txtTipoCambio.ReadOnly = false;
                }
            }
            if (txtTransaccion.Text == "FT")
            {
                cmbFormaPago.Visible = true;
                label17.Visible = true;
                dtpFechaPago.Visible = true;
            }
        }

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmDocumentos"] != null)
                {
                    Application.OpenForms["frmDocumentos"].Close();
                }
                else
                {
                    frmDocumentos form = new frmDocumentos();
                    form.Proceso = 3;
                    form.Procedencia = 1;
                    form.Transaccion = txtTransaccion.Text;
                    form.ShowDialog();
                    doc = form.doc;
                    CodDocumento = doc.CodTipoDocumento;
                    txtDocRef.Text = doc.Sigla;
                    if (CodDocumento != 0) { ProcessTabKey(true); } else { txtDocRef.Text = ""; }
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
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            BuscaTipoDocumento();
            VerificarCabecera();
            if (Validacion)
            {
                btnDetalle.Enabled = true;
            }
            if (CodDocumento == 0)
            {
                
            }
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1 || Proceso == 7)
            {
                calculatotales();
            }
        }

        private void calculatotales()
        {
            if (proce == 1)
            {
                Decimal bruto = 0;
                Double descuen = 0;
                Decimal valor = 0;
                Decimal igvt = 0;
                Decimal preciot = 0;
                foreach (DataGridViewRow row in dgvDetalle2.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[cantn.Name].Value) != 0)
                    {
                        bruto = bruto + Convert.ToDecimal(row.Cells[subtotal.Name].Value);
                        valor = valor + Convert.ToDecimal(row.Cells[valorventa1.Name].Value);
                        igvt = igvt + Convert.ToDecimal(row.Cells[igv1.Name].Value);
                        preciot = preciot + Convert.ToDecimal(row.Cells[importe1.Name].Value);
                    }
                    
                }
                txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
                txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
            }
            else
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
                txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
                txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                txtIGV.Text = String.Format("{0:#,##0.0000}", igvt);
                txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", preciot);
            }
            
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
                    btnDetalle.Visible = true;
                }
            }
        }

        private void txtNDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtNDocRef_Leave(object sender, EventArgs e)
        {
            if (txtNDocRef.Text == "")
            {
                
            }
            else
            {
                VerificarCabecera();
                if (Validacion)
                {
                    btnDetalle.Enabled = true;
                }

                txtNDocRef.Text = Convert.ToInt32(txtNDocRef.Text).ToString().PadLeft(8, '0');
            }
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtOrdenCompra_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void txtAutorizacion_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void txtTransaccion_Leave(object sender, EventArgs e)
        {
            if (CodTransaccion == 0)
            {
                
            }
            if (txtTransaccion.Text.Equals("FT") || txtTransaccion.Text.Equals("IN"))
            { btnDetalle.Visible = true; }
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
            if (proce == 1)
            {
                Int32 valor = 0;
                foreach (DataGridViewRow row in dgvDetalle2.Rows)
                {
                    String canti = "";
                    String cantin = "";
                    

                    canti = Convert.ToString(Convert.ToDecimal(row.Cells[cant.Name].Value));
                    cantin = Convert.ToString(Convert.ToDecimal(row.Cells[cantn.Name].Value));
                    if (Convert.ToInt32(row.Cells[codetord.Name].Value)!=0)
                    {
                        if (canti == "" || cantin == "" || cantin == "0.00")
                        {
                            valor = 1;
                        }
                    }
                    
                   

                }
                return valor;
            }
            else
            {
                Int32 valor = 1;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    String cant = "";
                    String precio = "";
                    String impor = "";
                    String IG = "";
                    String MontDes = "";
                    String d1 = "";
                    String d2 = "";
                    String d3 = "";

                    cant = Convert.ToString(Convert.ToDecimal(row.Cells[cantidad.Name].Value));
                    impor = Convert.ToString(row.Cells[importe.Name]);
                    IG = Convert.ToString(row.Cells[igv.Name]);
                    MontDes = Convert.ToString(row.Cells[montodscto.Name]);
                    precio = Convert.ToString(row.Cells[preciounit.Name].Value);
                    d1 = Convert.ToString(row.Cells[dscto1.Name].Value);
                    d2 = Convert.ToString(row.Cells[dscto2.Name].Value);
                    d3 = Convert.ToString(row.Cells[dscto3.Name].Value);

                    if (d1 != "" || d2 != "" || d3 != "")
                    {
                        calculatotales();
                    }

                    if (cant == "" || precio == "" || impor == "" || IG == "" || cant == "0")
                    {
                        valor = 1;
                    }
                    else
                    {
                        valor = 0;
                    }

                }
                return valor;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (verificarCamposVacios() == 1)
                {
                    MessageBox.Show("Debe completar Detalle de Nota, Datos Vacios");
                }
                else
                {
                    if (proce == 1)
                    {
                        if (Proceso != 0)
                        {
                            nota.CodAlmacen = frmLogin.iCodAlmacen;
                            nota.CodTipoTransaccion = tran.CodTransaccion;
                            nota.CodProveedor = prov.CodProveedor;
                            nota.CodTipoDocumento = doc.CodTipoDocumento;
                            nota.NumDoc = txtNDocRef.Text;
                            nota.FechaIngreso = dtpFecha.Value.Date;
                            nota.Comentario = txtComentario.Text;
                            nota.CodUser = frmLogin.iCodUser;
                            nota.CodOrdenCompra = codOrdenCompra_nota;
                            nota.codalmacenemisor = 0;
                            if (txtFlete.Text == "")
                            {
                                nota.Flete = 0;
                            }
                            else
                            {
                                nota.Flete =Convert.ToDouble(txtFlete.Text);
                            }
                            
                            if (codOrdenCompra_nota != 0)
                            {
                                //Orde = AdmOrd.BuscaCabeceraOrden(codOrdenCompra_nota);
                                //nota.Moneda = Orde.Moneda;
                                //nota.TipoCambio = Convert.ToDouble(Orde.Tipocambio);
                                //nota.FormaPago = Convert.ToInt32(Orde.Formapago);
                                //nota.FechaPago = Orde.Fechapago;
                            }
                            else {
                                nota.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                                if (txtTipoCambio.Text != "")
                                    nota.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                                else nota.TipoCambio = 0;
                                if (cmbFormaPago.SelectedValue == null)
                                    nota.FormaPago = 0;
                                else
                                nota.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                                nota.FechaPago = dtpFecha.Value.Date;
                            }
                            
                            nota.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            if (txtDscto.Text != "")
                                nota.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            else nota.MontoDscto = 0;
                            if (txtFlete.Text != "")
                                nota.Flete = Convert.ToDouble(txtFlete.Text);
                            else nota.Flete = 0;
                            nota.Igv = Convert.ToDouble(txtIGV.Text);
                            nota.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            nota.CodUser = frmLogin.iCodUser;
                            nota.Estado = 1;
                            nota.Codtransferencia = 0;
                            // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                            if (Proceso == 1)
                            {
                                if (AdmNota.insert(nota))
                                {

                                    RecorreDetalle();
                                    if (detalle.Count > 0)
                                    {
                                        foreach (clsDetalleNotaIngreso det in detalle)
                                        {
                                            AdmNota.insertdetalle(det);
                                            AdmNota.ActualizaCantidadPendiente(det.Cantidad, det.CodProducto,
                                                codOrdenCompra_nota,det.CoddetalleOrden);
                                            if (CodAlmacenOrden != frmLogin.iCodAlmacen && txtTransaccion.Text == "IOC")
                                                AdmNota.ActualizaCantidadPendiente2(det.Cantidad, det.CodProducto, CodAlmacenOrden, frmLogin.iCodUser);
                                        }
                                    }
                                    MessageBox.Show("Los datos se guardaron correctamente", "Nota de Ingreso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else if (Proceso == 2)
                            {
                                if (AdmNota.update(nota))
                                {
                                    RecorreDetalle();
                                    foreach (clsDetalleNotaIngreso det in nota.Detalle)
                                    {
                                        foreach (clsDetalleNotaIngreso det1 in detalle)
                                        {
                                            if (det.CodDetalleIngreso == det1.CodDetalleIngreso)
                                            {
                                                AdmNota.updatedetalle(det1);
                                            }
                                        }
                                        AdmNota.deletedetalle(det.CodDetalleIngreso);
                                    }
                                    foreach (clsDetalleNotaIngreso deta in detalle)
                                    {
                                        if (deta.CodDetalleIngreso == 0)
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
                    else
                    {
                        if (Proceso != 0)
                        {
                            //if (txtFlete.Text != "")
                            //{
                            //    if (Convert.ToDouble(txtFlete.Text) > 0)
                            //    {
                            //        prorrateodeflete();
                            //        recalculadetalle();
                            //        calculatotales();
                            //    }
                            //}

                            nota.CodAlmacen = frmLogin.iCodAlmacen;
                            fac.CodAlmacen = frmLogin.iCodAlmacen;
                            nota.CodTipoTransaccion = tran.CodTransaccion;
                            fac.CodTipoTransaccion = tran.CodTransaccion;
                            nota.CodProveedor = prov.CodProveedor;
                            fac.CodProveedor = prov.CodProveedor;
                            nota.CodTipoDocumento = doc.CodTipoDocumento;
                            fac.CodTipoDocumento = doc.CodTipoDocumento;
                            nota.NumDoc = txtNDocRef.Text;
                            fac.DocumentoFactura = doc.Sigla + "-" + txtNDocRef.Text;
                            nota.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            fac.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            if (txtTipoCambio.Visible)
                            {
                                fac.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                                nota.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                            }
                            nota.FechaIngreso = dtpFecha.Value.Date;
                            fac.FechaIngreso = dtpFecha.Value.Date;
                            nota.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                            fac.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                            nota.FechaPago = dtpFechaPago.Value.Date;
                            fac.FechaPago = dtpFechaPago.Value.Date;
                            if (fpago.Dias == 0)
                            {
                                nota.FechaCancelado = dtpFecha.Value.Date;   
                                fac.FechaCancelado = dtpFecha.Value.Date;
                            }
                            nota.Cancelado = 0;// Para saber si la nota esta pendiente de pago o esta cancelada
                            fac.Cancelado = 0;// Para saber si la nota esta pendiente de pago o esta cancelada 
                            fac.Comentario = txtComentario.Text;
                            fac.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            fac.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            nota.Comentario = txtComentario.Text;
                            nota.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            nota.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            if (txtFlete.Text != "")
                            {
                                nota.Flete = Convert.ToDouble(txtFlete.Text);
                                fac.Flete = Convert.ToDouble(txtFlete.Text);
                            }
                            fac.Igv = Convert.ToDouble(txtIGV.Text);
                            fac.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            fac.CodUser = frmLogin.iCodUser;
                           
                            nota.Igv = Convert.ToDouble(txtIGV.Text);
                            nota.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            nota.CodUser = frmLogin.iCodUser;
                            nota.codalmacenemisor = 0;
                            nota.Estado = 1;
                            fac.Estado = 1;
                            nota.Codtransferencia = 0;

                            if (txtOrdenCompra.Text != "" && txtOrdenCompra.Text != ".") 
                            {
                                nota.CodOrdenCompra = Convert.ToInt32(txtOrdenCompra.Text);
                            }
                            else { nota.CodOrdenCompra = 0; }
                            // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas

                            if (Proceso == 1)
                            {
                                if (txtTransaccion.Text.Equals("IN"))
                                {
                                    if (AdmNota.insert(nota))
                                    {
                                        RecorreDetalle();
                                        if (detalle.Count > 0)
                                        {
                                            foreach (clsDetalleNotaIngreso det in detalle)
                                            {
                                                AdmNota.insertdetalle(det);
                                            }
                                        }
                                        MessageBox.Show("Los datos se guardaron correctamente", "Nota de Ingreso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (fpago.Dias == 0 && nota.CodTipoTransaccion == 1)//se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                                        {
                                            ingresarpago();
                                        }
                                        this.Close();
                                    }
                                }
                                else if (AdmNota.insert(nota))
                                {
                                    fac.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                                    if (AdmFact.insert(fac))
                                    {
                                        RecorreDetalle();
                                        if (detalle.Count > 0)
                                        {
                                            foreach (clsDetalleNotaIngreso det in detalle)
                                            {
                                                AdmNota.insertdetalle(det);
                                            }
                                        }
                                        if (detalleFactura.Count > 0)
                                        {
                                            foreach (clsDetalleFactura det in detalleFactura)
                                            {
                                                AdmFact.insertdetalle(det);
                                            }
                                        }
                                        MessageBox.Show("Los datos se guardaron correctamente", "Nota de Ingreso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (fpago.Dias == 0 && nota.CodTipoTransaccion == 1)//se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                                        {
                                            ingresarpago();
                                        }
                                        this.Close();
                                    }
                                }
                            }
                            // falta implementar update 
                            else if (Proceso == 2)
                            {
                                if (AdmNota.update(nota))
                                {
                                    RecorreDetalle();
                                    foreach (clsDetalleNotaIngreso det in nota.Detalle)
                                    {
                                        foreach (clsDetalleNotaIngreso det1 in detalle)
                                        {
                                            if (det.CodDetalleIngreso == det1.CodDetalleIngreso)
                                            {
                                                AdmNota.updatedetalle(det1);
                                            }
                                        }
                                        AdmNota.deletedetalle(det.CodDetalleIngreso);
                                    }
                                    foreach (clsDetalleNotaIngreso deta in detalle)
                                    {
                                        if (deta.CodDetalleIngreso == 0)
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
            }
        }

        private void ingresarpago()
        {   
            frmCancelarPago form = new frmCancelarPago();
            form.CodNota = fac.CodFacturaNueva.ToString();
            form.tipo = 1; // (1)pago de nota de salida (2) pago de letra
            form.ShowDialog();  
        }

        private void RecorreDetalle()
        {
            if (proce == 1)
            {
                detalle.Clear();
                if (dgvDetalle2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle2.Rows)
                    {
                        añadedetalle(row);
                    }
                }
            }
            else
            {
                detalle.Clear();
                detalleFactura.Clear();
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        añadedetalle(row);
                    }
                }
            }
            //nota.Detalle = detalle;
        }

        private void añadedetalle(DataGridViewRow fila)
        {
            if (proce == 1)
            {
                clsDetalleNotaIngreso deta1 = new clsDetalleNotaIngreso();
                deta1.CodProducto = Convert.ToInt32(fila.Cells[coprod.Name].Value);
                deta1.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                deta1.CodAlmacen = frmLogin.iCodAlmacen;
                deta1.UnidadIngresada = Convert.ToInt32(fila.Cells[coduni.Name].Value);
                deta1.SerieLote = "0"; // esta pendiente
                deta1.Cantidad = Convert.ToDouble(fila.Cells[cantn.Name].Value);
                deta1.FechaIngreso = dtpFecha.Value;
                deta1.CodUser = frmLogin.iCodUser;
                deta1.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                deta1.CoddetalleOrden = Convert.ToInt32(fila.Cells[codetord.Name].Value);
                deta1.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounitario.Name].Value);
                deta1.Subtotal = Convert.ToDouble(fila.Cells[subtotal.Name].Value);
                deta1.Descuento1 = Convert.ToDouble(fila.Cells[descuento1.Name].Value);
                deta1.Descuento2 = Convert.ToDouble(fila.Cells[descuento2.Name].Value);
                deta1.Descuento3 = Convert.ToDouble(fila.Cells[descuento3.Name].Value);
                deta1.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto1.Name].Value);
                deta1.Igv = Convert.ToDouble(fila.Cells[igv1.Name].Value);
                deta1.Importe = Convert.ToDouble(fila.Cells[importe1.Name].Value);
                deta1.PrecioReal = Convert.ToDouble(fila.Cells[precioreal1.Name].Value);
                deta1.ValoReal = Convert.ToDouble(fila.Cells[valoreal1.Name].Value);
                deta1.Flete = Convert.ToDouble(fila.Cells[flete1.Name].Value);
                deta1.Bonificacion = Convert.ToBoolean(fila.Cells[Bonificacion.Name].Value);
                //if (codOrdenCompra_nota != 0)
                //{
                //    //Orde = AdmOrd.BuscaCabeceraOrden(codOrdenCompra_nota);
                //    //deta1.Moneda= Orde.Moneda;
                //}
                //else {
                    deta1.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                //}

                
                detalle.Add(deta1);

            }
            else
            {
                clsDetalleNotaIngreso deta = new clsDetalleNotaIngreso();
                clsDetalleFactura detafac = new clsDetalleFactura();
                detafac.CodFactura = fac.CodFacturaNueva;
                deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
                detafac.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
                deta.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                detafac.CodNotaIngreso = nota.CodNotaIngreso;
                deta.CodAlmacen = frmLogin.iCodAlmacen;
                detafac.CodAlmacen = frmLogin.iCodAlmacen;
                deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
                detafac.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
                deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
                detafac.SerieLote = "0"; 
                deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
                detafac.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
                deta.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
                detafac.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
                deta.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
                detafac.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
                deta.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
                detafac.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
                deta.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
                detafac.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
                deta.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
                detafac.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
                deta.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
                detafac.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
                deta.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
                detafac.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
                deta.Flete = Convert.ToDouble(fila.Cells[flete0.Name].Value);
                detafac.Flete = Convert.ToDouble(fila.Cells[flete0.Name].Value);
                deta.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
                detafac.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
                deta.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
                detafac.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
                deta.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
                detafac.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
                deta.FechaIngreso = dtpFecha.Value;
                detafac.FechaIngreso = dtpFecha.Value;
                deta.Bonificacion = false;
                //if (codOrdenCompra_nota != 0)
                //{
                //    Orde = AdmOrd.BuscaCabeceraOrden(codOrdenCompra_nota);
                //    deta.Moneda = Orde.Moneda;
                //    detafac.Moneda = Orde.Moneda;
                //}
                //else {
                    deta.Moneda =Convert.ToInt32(cmbMoneda.SelectedValue);
                    detafac.Moneda=Convert.ToInt32(cmbMoneda.SelectedValue);
                //}
                deta.CodUser = frmLogin.iCodUser;
                detafac.CodUser = frmLogin.iCodUser;
                if (txtCodProveedor.Text != "") detafac.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);  else detafac.CodProveedor = 0;
                detalle.Add(deta);
                detalleFactura.Add(detafac);
            }
        }

        private void CargaFilaDetalle(DataGridViewRow fila)
        {
            if (proce == 1)
            {
                detaSelec.CodProducto = Convert.ToInt32(fila.Cells[coprod.Name].Value);
                detaSelec.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                detaSelec.CodAlmacen = frmLogin.iCodAlmacen;
                detaSelec.UnidadIngresada = Convert.ToInt32(fila.Cells[coduni.Name].Value);
                detaSelec.Flete = Convert.ToDouble(fila.Cells[flete1.Name].Value);
                //detaSelec.SerieLote = fila.Cells[serielote.Name].Value.ToString();
                if (fila.Cells[cantn.Name].Value != DBNull.Value)
                {
                    detaSelec.Cantidad = Convert.ToDouble(fila.Cells[cantn.Name].Value);
                }
                else
                {
                    detaSelec.Cantidad = 0;
                }
                detaSelec.FechaIngreso = dtpFecha.Value;
                detaSelec.CodUser = frmLogin.iCodUser;
            }
            else
            {
                detaSelec.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
                detaSelec.CodNotaIngreso = Convert.ToInt32(nota.CodNotaIngreso);
                detaSelec.CodAlmacen = frmLogin.iCodAlmacen;
                detaSelec.Moneda = cmbMoneda.SelectedIndex;
                detaSelec.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
                detaSelec.SerieLote = fila.Cells[serielote.Name].Value.ToString();
                if (fila.Cells[cantidad.Name].Value != DBNull.Value)
                {
                    detaSelec.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
                }
                else
                {
                    detaSelec.Cantidad = 0;
                }
                detaSelec.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
                detaSelec.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
                detaSelec.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
                detaSelec.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
                detaSelec.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
                detaSelec.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
                detaSelec.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
                if (fila.Cells[flete0.Name].Value != DBNull.Value)
                {
                    detaSelec.Flete = Convert.ToDouble(fila.Cells[flete0.Name].Value);
                }
                else
                {
                    detaSelec.Flete = 0;
                }
                //detaSelec.Flete = Convert.ToDouble(fila.Cells[flete.Name].Value);//AQUI EL ERROR
                detaSelec.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
                detaSelec.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
                detaSelec.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
                detaSelec.FechaIngreso = dtpFecha.Value;
                detaSelec.CodUser = frmLogin.iCodUser;
            }
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
                    form.Procede = 6;
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
            lbAutorizado.Text = aut.Nombre;
        }

        private void txtAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtAutorizacion.Text != "")
                {
                    if (BuscaAutorizado())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El codigo no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaAutorizado()
        {
            aut = AdmAut.MuestraAutorizado(Convert.ToInt32(txtAutorizacion.Text));
            if (aut != null)
            {
                lbAutorizado.Text = aut.Nombre;
                CodAutorizado = aut.CodAutorizado;
                return true;
            }
            else
            {
                lbAutorizado.Text = "";
                CodAutorizado = 0;
                return false;
            }
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
           {
               detaSelec.CodProducto = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value);
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
                codProd.Remove(detaSelec.CodProducto);
            }
            if (dgvDetalle2.SelectedRows.Count > 0)
            {
                dgvDetalle2.Rows.Remove(dgvDetalle2.CurrentRow);
            }

            if (dgvDetalle2.Rows.Count == 0)
            {
                data.Clear();
            }

            dgvDetalle2.Refresh();
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                
                calculatotales();
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
                    if (CodCliente != 0) { CargaCliente(); ProcessTabKey(true); }
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
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
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
            if (e.KeyChar == (char)Keys.Return)
            {
                //prorrateodeflete();
                //recalculadetalle();
                //calculatotales();
            }   
        }

        private void prorrateodeflete()
        {
            if (txtFlete.Text != "" && dgvDetalle.Rows.Count >= 1)
            {
                Double precior = 0;
                Double factorflete = 0;
                Double fleter = 0;
                Double totalr = 0;
                Double dflete = Convert.ToDouble(txtFlete.Text);

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    totalr = totalr + Convert.ToDouble(row.Cells[precioventa.Name].Value);
                }

                factorflete = dflete / totalr;

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    precior = Convert.ToDouble(row.Cells[precioventa.Name].Value);                    
                    fleter = precior * factorflete;
                    row.Cells[flete0.Name].Value = String.Format("{0:#,##0.0000}", fleter);
                }
            }
        }

        private void recalculadetalle()
        {
            if (proce == 1)
            {
                Decimal vvflete = 0;
                Decimal pvflete = 0;
                foreach (DataGridViewRow row in dgvDetalle2.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[cantn.Name].Value) != 0)
                    {
                        vvflete = Convert.ToDecimal(row.Cells[valorventa1.Name].Value) +
                                  Convert.ToDecimal(row.Cells[flete1.Name].Value);
                        pvflete = Convert.ToDecimal(row.Cells[importe1.Name].Value) +
                                  Convert.ToDecimal(row.Cells[flete1.Name].Value);
                        if (Convert.ToDouble(row.Cells[flete1.Name].Value) > 0.00 &&
                            row.Cells[flete1.Name].Value.ToString() != "")
                        {
                            row.Cells[valoreal1.Name].Value = vvflete / Convert.ToDecimal(row.Cells[cantn.Name].Value);
                            row.Cells[precioreal1.Name].Value = pvflete / Convert.ToDecimal(row.Cells[cantn.Name].Value);
                        }
                        else
                        {
                            row.Cells[valoreal1.Name].Value = Convert.ToDecimal(row.Cells[valorventa1.Name].Value) /
                                                              Convert.ToDecimal(row.Cells[cantn.Name].Value);
                            row.Cells[precioreal1.Name].Value = Convert.ToDecimal(row.Cells[importe1.Name].Value) /
                                                                Convert.ToDecimal(row.Cells[cantn.Name].Value);
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    row.Cells[valorventaconflete.Name].Value = (Convert.ToDouble(row.Cells[valorventa.Name].Value) + Convert.ToDouble(row.Cells[flete0.Name].Value)).ToString("###.####");
                    row.Cells[pvconflete.Name].Value = (Convert.ToDouble(row.Cells[precioventa.Name].Value) + Convert.ToDouble(row.Cells[flete0.Name].Value)).ToString("###.####");
                    if (Convert.ToDouble(row.Cells[flete0.Name].Value) > 0.00 && row.Cells[flete0.Name].Value.ToString() != "")
                    {
                        row.Cells[valoreal.Name].Value = (Convert.ToDouble(row.Cells[valorventaconflete.Name].Value) / Convert.ToDouble(row.Cells[cantidad.Name].Value)).ToString("###.####");
                        row.Cells[precioreal.Name].Value = (Convert.ToDouble(row.Cells[pvconflete.Name].Value) / Convert.ToDouble(row.Cells[cantidad.Name].Value)).ToString("###.####");
                    }
                    else
                    {
                        row.Cells[valoreal.Name].Value = (Convert.ToDouble(row.Cells[valorventa.Name].Value) / Convert.ToDouble(row.Cells[cantidad.Name].Value)).ToString("###.####");
                        row.Cells[precioreal.Name].Value = (Convert.ToDouble(row.Cells[precioventa.Name].Value) / Convert.ToDouble(row.Cells[cantidad.Name].Value)).ToString("###.####");
                    }
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

        private void txtOrdenCompra_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CargaOrden()
        {
            try
            {
                Orde = AdmOrd.CargaOrdenCompra(Convert.ToInt32(CodOrdenCompra));
                if (Orde != null)
                {
                    txtOrdenCompra.Text = Orde.CodOrdenCompra.ToString().PadLeft(6, '0');
                    CodTransaccion = 1; // 1 TRANSACCION --> INGRESO POR COMPRA
                    CargaTransaccion();
                    
                    if (txtCodProv.Enabled)
                    {
                        CodProveedor = Orde.CodProveedor;

                        if (txtCodProv.Enabled)
                        {
                            CodProveedor = Orde.CodProveedor;
                            prov = AdmProv.MuestraProveedor(CodProveedor);
                            txtCodProv.Text = prov.Ruc;
                            //cmbFormaPago.SelectedValue = prov.FormaPago;

                            txtNombreProv.Text = prov.RazonSocial;
                            txtCodProveedor.Text = prov.CodProveedor.ToString();

                            //cmbFormaPago.SelectedValue = prov.FormaPago;
                            if (Convert.ToInt32(cmbFormaPago.SelectedValue) != 0)
                            {
                                EventArgs ee = new EventArgs();
                                cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);
                            }
                            else
                            {
                                dtpFechaPago.Value = DateTime.Today;
                            }
                        }
                    }
                    txtComentario.Text = Orde.Comentario;
                    cmbMoneda.SelectedValue = Orde.Moneda;

                    CargaDetalleOrden();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaDetalleOrden()
        {
            //dgvDetalle.DataSource = AdmOrden.CargaDetalle(Convert.ToInt32(orden.CodOrdenCompra));
            DataTable newData = new DataTable();
            dgvDetalle.Rows.Clear();
            try
            {
                newData = AdmOrd.CargaDetalle(Convert.ToInt32(Orde.CodOrdenCompra));
                foreach (DataRow row in newData.Rows)
                {

                    dgvDetalle.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[5].ToString(),
                        row[4].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(),
                        row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(),
                        row[15].ToString(), row[17].ToString(), 0, row[16].ToString(), row[17].ToString(),
                        row[18].ToString(), row[19].ToString(), row[18].ToString(), row[20].ToString(), row[21].ToString(),
                        row[22].ToString(), row[23].ToString(), "", "", 0);
                }
                dgvDetalle.ClearSelection();
                RecorreDetalle();
                nota.Detalle = detalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        

        private void dgvDetalle2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtedit = e.Control as TextBox;
            if (txtedit != null)
            {
                txtedit.KeyPress -= new KeyPressEventHandler(dgvDetalle2_KeyPress);
                txtedit.KeyPress += new KeyPressEventHandler(dgvDetalle2_KeyPress);
                txtedit.KeyUp -= new KeyEventHandler(dgvDetalle2_KeyUp);
                txtedit.KeyUp += new KeyEventHandler(dgvDetalle2_KeyUp);
            }
        }

        private void dgvDetalle2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle2.CurrentCell.ColumnIndex == 7)//CantidadNueva
            {
                val.SOLONumeros(sender,e);
            }
        }

        private void dgvDetalle2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvDetalle2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetalle2_CellEndEdit(sender, e);
            if (!this.Visible)
                return;
            if (dgvDetalle2.Rows.Count >= 1 && dgvDetalle2.CurrentRow.Index == e.RowIndex && e.RowIndex != -1)
            {
                CargaFilaDetalle(dgvDetalle2.CurrentRow);
            } 
            
        }

        private void dgvDetalle2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                QIngresado = Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[SaldoIngresado1.Name].Value);
                QPorAtender = Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[cantidadPendiente1.Name].Value);

                if (dgvDetalle2.Columns[dgvDetalle2.CurrentCell.ColumnIndex].Name == "cantn" && txtedit.Text != "" &&
                    Convert.ToInt32(dgvDetalle2.CurrentRow.Cells[codetord.Name].Value) != 0)
                {
                    if (Convert.ToDouble(txtedit.Text) >
                        Convert.ToDouble(dgvDetalle2.CurrentRow.Cells[cantidadPendiente1.Name].Value))
                    {
                        MessageBox.Show("Cantidad Nueva Debe Ser Menor o Igual que la Cantidad de la Orden");
                        dgvDetalle2.CurrentRow.Cells[cantn.Name].Value = 0.00;
                    }
                    else
                    {
                        Qnueva = Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[cantn.Name].Value);

                        dgvDetalle2.CurrentRow.Cells[SaldoIngresado.Name].Value = (QIngresado + Qnueva);
                        dgvDetalle2.CurrentRow.Cells[cantidadPendiente.Name].Value = (QPorAtender - Qnueva);

                        dgvDetalle2.CurrentRow.Cells[subtotal.Name].Value =
                            Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[cantn.Name].Value)*
                            Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[preciounitario.Name].Value);
                        importes();
                        calculatotales();
                    }

                }
                else if (dgvDetalle2.Columns[dgvDetalle2.CurrentCell.ColumnIndex].Name == "cantn" && txtedit.Text != "" &&
                    Convert.ToInt32(dgvDetalle2.CurrentRow.Cells[codetord.Name].Value) == 0)
                {
                    
                    dgvDetalle2.CurrentRow.Cells[SaldoIngresado.Name].Value = txtedit.Text;
                    dgvDetalle2.CurrentRow.Cells[SaldoIngresado1.Name].Value = txtedit.Text;
                    dgvDetalle2.CurrentRow.Cells[cant.Name].Value = txtedit.Text;
                    dgvDetalle2.CurrentRow.Cells[cantn.Name].Value = txtedit.Text;
                    
                    dgvDetalle2.CurrentRow.Cells[subtotal.Name].Value =
                        Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[cantn.Name].Value) *
                        Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[preciounitario.Name].Value);
                    importes();
                    calculatotales();
                  
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void importes()
        {
            Decimal precio = 0;
            Decimal valor = 0;
            Decimal Igv = 0;
            prod = Admpro.CargaProductoDetalle(Convert.ToInt32(dgvDetalle2.CurrentRow.Cells[coprod.Name].Value), frmLogin.iCodAlmacen, 1, 0);
            //if (cbValorVenta.Checked)
            //{
                if (prod.ConIgv)
                {

                    precio = Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[subtotal.Name].Value);
                    valor = precio / Convert.ToDecimal(frmLogin.Configuracion.IGV / 100 + 1);
                    Igv = precio - valor;
                }
                else
                {
                    precio = Convert.ToDecimal(dgvDetalle2.CurrentRow.Cells[subtotal.Name].Value);
                    valor = precio;
                    Igv = precio - valor;

                }
                dgvDetalle2.CurrentRow.Cells[importe1.Name].Value = precio;
                dgvDetalle2.CurrentRow.Cells[valorventa1.Name].Value = valor;
                dgvDetalle2.CurrentRow.Cells[igv1.Name].Value = Igv;
            //}
            //recalculadetalle();
        }

        private void dgvDetalle2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetalle2_CellEndEdit(sender, e);
        }

        private void dgvDetalle2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {            
        }

        private void txtDocRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDetalle2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {
                calculatotales();
            }
        }

        private void dgvDetalle2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Proceso == 1)
            {
                calculatotales();
            }
        }

        private void customValidator8_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void customValidator9_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void txtOrdenCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFlete_Leave(object sender, EventArgs e)
        {
            
            if (txtFlete.Text != "")
            {
                if (Convert.ToDouble(txtFlete.Text) > 0)
                {
                    prorrateodeflete();
                    recalculadetalle();
                    calculatotales();
                }
            }
        }

        private void RecorreDetalle1()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle1(row);
                }
            }            
        }

        private void añadedetalle1(DataGridViewRow fila)
        {
            try
            {
                Decimal fleteprod = 0;
                Decimal Subtotal = Convert.ToDecimal(fila.Cells[precioventa.Name].Value);
                fleteprod = ((montoflete / total) * Subtotal);
                fila.Cells[flete0.Name].Value = fleteprod.ToString("#.###.####");
                
                
                fila.Cells[valorventaconflete.Name].Value = (Convert.ToDecimal(fila.Cells[valorventa.Name].Value) + fleteprod).ToString("###.####");
                fila.Cells[pvconflete.Name].Value = (Convert.ToDecimal(fila.Cells[precioventa.Name].Value) + fleteprod).ToString("###.##");

                calculatotales();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSerieDocRef_Leave(object sender, EventArgs e)
        {
            if (txtSerieDocRef.Text != "") 
            {
                txtSerieDocRef.Text = Convert.ToInt32(txtSerieDocRef.Text).ToString().PadLeft(3,'0');
            }
        }

        private void txtSerieDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }


    
    }
}
