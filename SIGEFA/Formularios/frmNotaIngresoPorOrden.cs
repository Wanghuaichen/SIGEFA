using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmNotaIngresoPorOrden : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsMoneda Mon = new clsMoneda();
        clsAdmOrdenCompra AdmOrd = new clsAdmOrdenCompra();
        clsOrdenCompra Ord = new clsOrdenCompra();
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
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto prodeta = new clsProducto();
        clsValidar val = new clsValidar();
        clsFactura fac = new clsFactura();
        clsAdmFactura AdmFact = new clsAdmFactura();
        clsDetalleFactura detaSelec1 = new clsDetalleFactura();
        public String codigosNota = "";
        clsPago Pag = new clsPago();//MOD7
        clsAdmPago Admpag = new clsAdmPago();//MOD7

        public List<Int32> config = new List<Int32>();
        public List<Int32> documento = new List<Int32>(); 
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        public List<clsDetalleFactura> detalle1 = new List<clsDetalleFactura>();
        public DataTable datoscarga2 = new DataTable();
        public String CodNota;
        public Int32 CodTransaccion;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodOrdenCompra;
        public Int32 CodAutorizado;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Tipo, codOrdenCompra_nota = 0, codFac = 0, vOrigOC=0;

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        TextBox txtedit = new TextBox();
        Decimal sumadet = 0;//MOD7

        public frmNotaIngresoPorOrden()
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
        public void llenardetalle2()
        {
            data.DataSource = null;
            DataTable datoscarga = new DataTable();
            //datoscarga = AdmNota.MuestraOrdenAlmacen(frmLogin.iCodAlmacen, frmLogin.iCodUser);
            datoscarga = AdmNota.MuestraGuia(frmLogin.iCodAlmacen, frmLogin.iCodUser);
            if (datoscarga != null)
            {
                datoscarga2.Merge(datoscarga);
            }
            dgvDetalle.DataSource = datoscarga2;
            if(vOrigOC==0)
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = false;
            else
                dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
            dgvDetalle.ClearSelection();
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
            txtOrdenCompra.Visible = true;
            label8.Visible = true;
            CargaFormaPagos();
            cargaMoneda();
            if (txtTransaccion.Text.Equals("IOC"))
            {
                label17.Visible = true;
                cmbFormaPago.Visible = true;
                dtpFechaPago.Visible = true;
            }
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
                if (codFac != 0)
                {
                    CargaFactura();
                    sololectura(true);
                }
                else
                {
                    CargaNotaIngreso();
                    sololectura(true);
                }
               
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
            else if (Proceso == 6)
            {
                CargaNotaIngreso();
                sololectura(true);
            }
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = -1;
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
            txtBruto.ReadOnly = estado;
            txtDscto.ReadOnly = estado;
            txtValorVenta.ReadOnly = estado;
            txtIGV.ReadOnly = estado;
            txtPrecioVenta.ReadOnly = estado;
            txtFlete.ReadOnly = estado;
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
                    dtpFecha.Value = nota.FechaIngreso;
                    cmbMoneda.SelectedValue = nota.Moneda;
                    txtTipoCambio.Text = nota.TipoCambio.ToString();
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    
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
                        txtCodProv.Text = nota.RUCProveedor;
                        txtCodProveedor.Text = nota.CodProveedor.ToString();
                        txtNombreProv.Text = nota.RazonSocialProveedor;
                        txtOrdenCompra.Text = nota.SDocumentoOrden;
                        txtOrdenCompra.Visible = true;
                        txtOrdenCompra.Enabled = false;
                        label8.Visible = true;
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
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso Por Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CargaFactura()
        {
            try
            {
                fac = AdmFact.CargaFactura(Convert.ToInt32(codFac));
                if (fac != null)
                {
                    txtNumDoc.Text = fac.CodFactura.ToString().PadLeft(9, '0');
                    CodTransaccion = fac.CodTipoTransaccion;
                    CargaTransaccion();
                    dtpFecha.Value = fac.FechaIngreso;
                    cmbMoneda.SelectedValue = fac.Moneda;
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    txtTipoCambio.Text = fac.TipoCambio.ToString();
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    CodDocumento = fac.CodTipoDocumento;
                    txtDocRef.Text = (fac.DocumentoFactura).Substring(0,2);
                    txtNDocRef.Text = (fac.DocumentoFactura).Substring(3); 
                    txtCodProv.Text = fac.RUCProveedor;
                    txtCodProv.Visible = true;
                    txtCodProveedor.Text = fac.CodProveedor.ToString();
                    txtNombreProv.Text = fac.RazonSocialProveedor;
                    txtNombreProv.Visible = true;
                    txtOrdenCompra.Visible = false;
                    label8.Visible = false;
                    cmbFormaPago.SelectedValue = fac.FormaPago;
                    dtpFechaPago.Value = fac.FechaPago;
                    txtComentario.Text = fac.Comentario;
                    txtBruto.Text = String.Format("{0:#,##0.0000}", fac.MontoBruto);
                    txtDscto.Text = String.Format("{0:#,##0.0000}", fac.MontoDscto);
                    txtFlete.Text = String.Format("{0:#,##0.0000}", fac.Flete);
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", fac.Total - fac.Igv);
                    txtIGV.Text = String.Format("{0:#,##0.0000}", fac.Igv);
                    txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", fac.Total);
                    CargaDetalleFactura();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso Por Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmNota.CargaDetalle(Convert.ToInt32(nota.CodNotaIngreso));
            RecorreDetalle();
            nota.Detalle = detalle;
        }
        private void CargaDetalleFactura()
        {
            dgvDetalle.DataSource = AdmFact.CargaDetalle(Convert.ToInt32(fac.CodFactura));
            valoreal.Visible = false;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Proceso==1)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
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
        }

        private void limpiar()
        {
            txtOrdenCompra.Text = "";
            txtCodProveedor.Text = "";
            txtNombreProv.Text = "";
            txtCodProv.Text = "";
        }

        private void txtCodProv_KeyDown(object sender, KeyEventArgs e)
        {
            //limpiar();
            if (e.KeyCode == Keys.F1)
            {
                limpiar();
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    dgvDetalle.DataSource = null;
                    data.DataSource = null;
                    //dgvDetalle.Rows.Clear();
                    dgvDetalle.Refresh();
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = 1;
                    form.ShowDialog();
                    if (CodProveedor != 0) { CargaProveedor(); ProcessTabKey(true); } else { BorrarProveedor(); }
                }
            }
        }

        private void frmNotaIngreso_Shown(object sender, EventArgs e)
        {
            tran = AdmTran.MuestraTransaccion(14);
            txtTransaccion.Text = tran.Sigla;
            txtTransaccion.ReadOnly = true;
            KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
            txtTransaccion_KeyPress(txtTransaccion, ee);
            
            if (tran.CodTransaccion==14)
            {
                label17.Visible = true;
                cmbFormaPago.Visible = true;
                dtpFechaPago.Visible = true;
            }

            if (Proceso ==1)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date,2);
                if (tc != null)
                {
                    txtTipoCambio.Text = tc.Venta.ToString();
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                }
                else
                {
                    MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFecha.Value = DateTime.Now.Date;
                    cmbMoneda.Focus();
                    this.Close();
                }
                txtOrdenCompra.Focus();
            }
            if (Proceso == 3)
            {
                txtTipoCambio.Visible = true;
                label16.Visible = true;
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
                        if (CodDocumento != 0) { ProcessTabKey(true); } else { txtDocRef.Text = ""; }
                    }
                }
            
        }

        //private void CargaDocumento()
        //{
        //    doc = Admdoc.BuscaTipoDocumento(doc.CodTipoDocumento);
        //    txtDocRef.Text = doc.Sigla;            
        //}

        //private void BorrarDocumento()
        //{
        //    doc = Admdoc.BuscaTipoDocumento(doc.CodTipoDocumento);
        //    txtDocRef.Text = "";
        //}

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

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Proceso == 1)
            {
                calculatotales();
            }
        }

        private void calculatotales()
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
            AdmNota.deleteConsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
            try
            {
                if (superValidator1.Validate())
                {
                    if (verificarCamposVacios() == 1)
                    {
                        MessageBox.Show("Debe completar Detalle de Nota, Datos Vacios");
                    }
                    else
                    {

                        if (Proceso != 0)
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

                            fac.CodAlmacen = frmLogin.iCodAlmacen;
                            fac.CodTipoTransaccion = tran.CodTransaccion;
                            fac.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                            fac.CodTipoDocumento = doc.CodTipoDocumento;
                            fac.DocumentoFactura = doc.Sigla + "-" + txtNDocRef.Text;
                            fac.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            if (txtTipoCambio.Visible)
                            {
                                fac.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                            }
                            fac.FechaIngreso = dtpFecha.Value.Date;
                            fac.FormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                            fac.FechaPago = dtpFechaPago.Value.Date;
                            if (fpago.Tipo == true)
                            {
                                fac.FechaCancelado = dtpFecha.Value.Date;
                            }
                            fac.Cancelado = 0;// Para saber si la nota esta pendiente de pago o esta cancelada                    

                            fac.Comentario = txtComentario.Text;
                            fac.MontoBruto = Convert.ToDouble(txtBruto.Text);
                            fac.MontoDscto = Convert.ToDouble(txtDscto.Text);
                            if (txtFlete.Text != "")
                            {
                                fac.Flete = Convert.ToDouble(txtFlete.Text);
                            }
                            fac.Igv = Convert.ToDouble(txtIGV.Text);
                            fac.Total = Convert.ToDouble(txtPrecioVenta.Text);
                            fac.CodUser = frmLogin.iCodUser;
                            fac.CodOrdenCompra = codOrdenCompra_nota;
                            fac.Estado = 1;
                         // Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas
                            if (Proceso == 1)
                            {
                                RecorreGrilla();
                                if (estado == 1)
                                {
                                    if (AdmFact.insert(fac))
                                    {

                                        RecorreDetalle();
                                        if (detalle1.Count > 0)
                                        {
                                            foreach (clsDetalleFactura det in detalle1)
                                            {
                                                Int32 cont=0;
                                                AdmFact.insertdetalle(det);
                                                for(Int32 i=0; i< det.CodNotaIngreso.Length;i++)
                                                    if (det.CodNotaIngreso.Substring(0,i).Contains(",")) cont += 1;
                                                
                                                if(cont>1)AdmNota.ActualizaCodNotaIngreso(det.Cantidad, det.CodProducto,
                                                    det.CodDetalleFactura, 2);
                                                else AdmNota.ActualizaCodNotaIngreso(det.Cantidad, det.CodProducto,
                                                    det.CodDetalleFactura, 1);
                                            }
                                            if (VerificarDetracciones())//MOD7
                                            {
                                                if (cbDetraccion.Checked)
                                                {
                                                    DialogResult dlgResult = MessageBox.Show("La operación está afecta a detracción, Desea generar pago de detracción?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (dlgResult == DialogResult.No)
                                                    {
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        GenerarPagoDetraccion();
                                                    }
                                                }
                                            }
                                        }
                                        MessageBox.Show("Los datos se guardaron correctamente", "Facturacion",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (fpago.Tipo == true)//MOD7
                                        //se comprueba que el pago sea al contado y que la trnasaccion sea ingreso por compra
                                        {
                                            ingresarpago();
                                        }
                                        txtNumDoc.Text = fac.CodFacturaNueva.ToString().PadLeft(11, '0');
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarPagoDetraccion()//MOD7
        {
            Decimal porcentdet = 0.015m;

            try
            {
                Pag.CodNota = fac.CodFacturaNueva.ToString();
                Pag.CodMoneda = 1;//soles
                Pag.Tipo = false;//parcial
                Pag.IngresoEgreso = false;//egreso
                if (txtTipoCambio.Text == "") { Pag.TipoCambio = 0; } else { Pag.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text); };
                Pag.MontoPagado = sumadet * porcentdet;
                Pag.MontoCobrado = sumadet * porcentdet;
                Pag.Vuelto = 0;
                Pag.NOperacion = "";
                Pag.NCheque = "";
                Pag.FechaPago = dtpFecha.Value;
                Pag.Observacion = "";
                Pag.CodUser = frmLogin.iCodUser;
                Pag.CodAlmacen = frmLogin.iCodAlmacen;
                Pag.Provision = true;
                Pag.Pendiente = true;
                if (Admpag.insertpagodetraccion(Pag))
                {
                    MessageBox.Show("El pago de detraccion se envio a Tesoreria", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El pago de detraccion no pudo generarse", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private Int32 verificarCamposVacios()
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

                cant = Convert.ToString(Convert.ToInt32(row.Cells[cantidad.Name].Value));
                impor = Convert.ToString(row.Cells[importe.Name]);
                IG = Convert.ToString(row.Cells[igv.Name]);
                MontDes = Convert.ToString(row.Cells[montodscto.Name]);
                precio = Convert.ToString(row.Cells[preciounit.Name].Value);
                d1 = Convert.ToString(row.Cells[dscto1.Name].Value);
                d2 = Convert.ToString(row.Cells[dscto2.Name].Value);
                d3 = Convert.ToString(row.Cells[dscto3.Name].Value);

                if (d1 != "" || d2 != "" || d3 != "") { calculatotales(); }

                if (cant == "" || precio == "" || impor == "" || IG == "")
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

        private void ingresarpago()
        {
            frmCancelarPago form = new frmCancelarPago();
            form.CodNota = fac.CodFacturaNueva.ToString();
            form.mon = nota.Moneda;
            form.tipo = 1; // (1)pago de nota de salida (2) pago de letra
            form.ShowDialog();  
        }

        private Int32 estado, contP, contN;
        
        private void RecorreGrilla()
        {
            try
            {
                detalle.Clear();
                contP = 0;
                contN = 0;
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[bonificacion.Name].Value) == 1 &&
                            Convert.ToDouble(row.Cells[preciounit.Name].Value).Equals(0.00))
                        {
                            preciounit.ReadOnly = true;
                            cantidad.ReadOnly = true;
                            dscto1.ReadOnly = true;
                            contP = contP + 1;
                        }
                        else if (Convert.ToInt32(row.Cells[bonificacion.Name].Value) == 0 &&
                                 Convert.ToDouble(row.Cells[preciounit.Name].Value).Equals(0.00))
                        {
                            MessageBox.Show("Modifique PrecioUnitario" + Environment.NewLine + " del Producto [" + row.Cells[referencia.Name].Value + "]" + Environment.NewLine + "No es una Bonificacion!!", "FacturaCompra", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            contN = contN + 1;
                            break;
                        }
                        else
                        {
                            contP = contP + 1;
                        }
                    }
                }
                if (contP == dgvDetalle.Rows.Count) estado = 1;
                else estado = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void RecorreDetalle()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void añadedetalle(DataGridViewRow fila)
        {
            try
            {
                clsDetalleFactura deta = new clsDetalleFactura();
                deta.CodFactura = fac.CodFacturaNueva;
                deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
                deta.CodNotaIngreso = txtCodNota.Text;
                deta.CodAlmacen = frmLogin.iCodAlmacen;
                deta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
                deta.SerieLote = "0"; // sta pendiente
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
                deta.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                detalle1.Add(deta);
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        private void CargaFilaDetalle(DataGridViewRow fila)
        {
            //detaSelec1.CodDetalleFactura = Convert.ToInt32(fila.Cells[coddetalle.Name].Value);
            detaSelec1.CodFactura = fac.CodFacturaNueva;
            detaSelec1.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            detaSelec1.CodNotaIngreso = txtCodNota.Text;
            detaSelec1.CodAlmacen = frmLogin.iCodAlmacen;
            detaSelec1.Moneda = cmbMoneda.SelectedIndex;
            detaSelec1.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            detaSelec1.SerieLote = "0";
            detaSelec1.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            detaSelec1.PrecioUnitario = Convert.ToDouble(fila.Cells[preciounit.Name].Value);
            detaSelec1.Subtotal = Convert.ToDouble(fila.Cells[importe.Name].Value);
            detaSelec1.Descuento1 = Convert.ToDouble(fila.Cells[dscto1.Name].Value);
            detaSelec1.Descuento2 = Convert.ToDouble(fila.Cells[dscto2.Name].Value);
            detaSelec1.Descuento3 = Convert.ToDouble(fila.Cells[dscto3.Name].Value);
            detaSelec1.MontoDescuento = Convert.ToDouble(fila.Cells[montodscto.Name].Value);
            detaSelec1.Igv = Convert.ToDouble(fila.Cells[igv.Name].Value);
            detaSelec1.Flete = Convert.ToDouble(fila.Cells[flete.Name].Value);
            detaSelec1.Importe = Convert.ToDouble(fila.Cells[precioventa.Name].Value);
            detaSelec1.PrecioReal = Convert.ToDouble(fila.Cells[precioreal.Name].Value);
            detaSelec1.ValoReal = Convert.ToDouble(fila.Cells[valoreal.Name].Value);
            detaSelec1.FechaIngreso = dtpFecha.Value;
            detaSelec1.CodUser = frmLogin.iCodUser;           
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
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (!this.Visible)
            //    return;
            //if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected && dgvDetalle.CurrentRow.Index == e.Row.Index)
            //{
            //    CargaFilaDetalle(e.Row);                
            //}            
        }

        public void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            dtpFechaPago.Value = dtpFecha.Value.AddDays(fpago.Dias); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
        }

        private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
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
                txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
                txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
                txtIGV.Text = String.Format("{0:#,##0.0000}", bruto - descuen - valor);
                txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", bruto - descuen);
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
            //dgvDetalle_CellEndEdit(sender, e);
            if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
            {
                if (Proceso == 1 || Proceso ==2)
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
                    calculatotales();
                }
            }
        }


        private void prorrateodeflete()
        {
            if (txtFlete.Text != "" && dgvDetalle.Rows.Count >= 1)
            {
                Decimal precior = 0;
                Decimal percentr = 0;
                Decimal fleter = 0;
                Decimal totalr = 0;
                Decimal dflete = Convert.ToDecimal(txtFlete.Text);

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    totalr = totalr + Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                }
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    precior = Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                    percentr = precior / totalr;
                    fleter = dflete * percentr;
                    row.Cells[flete.Name].Value = String.Format("{0:#,##0.0000}", fleter);
                }
            }
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
            //dgvDetalle_CellEndEdit(sender, e);
            if (!this.Visible)
                return;
            if (dgvDetalle.Rows.Count >= 1 && dgvDetalle.CurrentRow.Index == e.RowIndex && e.RowIndex != -1)
            {
                CargaFilaDetalle(dgvDetalle.CurrentRow);
                if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[bonificacion.Name].Value) == 1)
                {
                    MessageBox.Show("Es Bonificación No Necesita Ingresar Montos");
                    dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                    dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true;
                    dgvDetalle.CurrentRow.Cells[dscto1.Name].ReadOnly = true;
                }
                if (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value) != 0)
                {
                    //dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                }
               
            }            
        }

       

        private void txtOrdenCompra_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                AdmNota.deleteConsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
                txtCodNota.Text = "";
                if (e.KeyCode == Keys.F1)
                {
                    if (Application.OpenForms["frmNotaOrdenAlmacen"] != null)
                    {
                        Application.OpenForms["frmNotaOrdenAlmacen"].Activate();
                    }
                    else
                    {
                        frmNotaOrdenAlmacen form = new frmNotaOrdenAlmacen();
                        form.proceso = 7;
                        form.procede = 1;
                        form.coddetallenota = documento;
                        form.Cargaconsolidado();
                        form.unir = "";
                        form.ShowDialog();
                        txtDocRef.Focus();
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
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

        private void customValidator10_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (dgvDetalle.Rows.Count > 0)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
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

        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            calculatotales();
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == cantidad.Index)//Cantidad
            {
                val.SOLONumeros(sender,e);
            }
            if (dgvDetalle.CurrentCell.ColumnIndex == preciounit.Index)//preciounit
            {
                val.SOLONumeros(sender,e);
            }
            if (dgvDetalle.CurrentCell.ColumnIndex == dscto1.Index)//dscto1
            {
                val.SOLONumeros(sender, e);
            }

            if (dgvDetalle.CurrentCell.ColumnIndex == dscto2.Index)//dscto2
            {
                val.SOLONumeros(sender, e);
            }
            if (dgvDetalle.CurrentCell.ColumnIndex == dscto3.Index)//dscto3
            {
                val.SOLONumeros(sender, e);
            }
        }

        private void dgvDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtedit.Text) >
                        Convert.ToDouble(dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value) && dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantidad")
                {
                    MessageBox.Show("Cantidad Debe Ser Menor o Igual que: " + dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value);
                    dgvDetalle.CurrentRow.Cells[cantidad.Name].Value =
                        dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value;
                }
                else
                {
                    if (dgvDetalle.CurrentRow.Cells[cantidad.Name].Value.ToString() != "" &&
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].Value.ToString() != "")
                    {
                        dgvDetalle.CurrentRow.Cells[importe.Name].Value =
                            Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value) *
                            Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);
                        importes();
                        calculatotales();
                    }
                }
                if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "importe" ||
                     dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "preciounit")
                {
                    if (dgvDetalle.CurrentRow.Cells[cantidad.Name].Value.ToString() != "" &&
                        dgvDetalle.CurrentRow.Cells[preciounit.Name].Value.ToString() != "")
                    {
                        dgvDetalle.CurrentRow.Cells[importe.Name].Value =
                            Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value) *
                            Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);
                        importes();
                        calculatotales();
                    }
                }

                if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "valorventa")
                {
                    importes();
                    calculatotales();
                }
                if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "montodscto" ||
                    dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto1" ||
                    dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto2" ||
                    dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto3")
                {
                    if (dgvDetalle.CurrentRow.Cells[dscto1.Name].Value.ToString() != "" ||
                        dgvDetalle.CurrentRow.Cells[dscto2.Name].Value.ToString() != "" ||
                        dgvDetalle.CurrentRow.Cells[dscto3.Name].Value.ToString() != "")
                    {
                        dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value) -
                            (Convert.ToDecimal((dgvDetalle.CurrentRow.Cells[importe.Name].Value)) *
                             (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto1.Name].Value) / 100)) *
                             (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto2.Name].Value) / 100)) *
                             (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto3.Name].Value) / 100)));
                    }
                    importes();
                    calculatotales();
                }
                if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "montodscto")
                {
                    if (dgvDetalle.CurrentRow.Cells[dscto1.Name].Value.ToString() == "" &&
                        dgvDetalle.CurrentRow.Cells[dscto2.Name].Value.ToString() == "" &&
                        dgvDetalle.CurrentRow.Cells[dscto3.Name].Value.ToString() == "")
                    {
                        dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = "";
                    }
                    importes();
                    calculatotales();
                }

                //switch (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[codControlStock.Name].Value))
                //{
                //    case 1: dgvDetalle.CurrentRow.Cells[serielote.Name].ReadOnly = true; dgvDetalle.CurrentRow.Cells[serielote.Name].Value = "0"; break;
                //    case 2: dgvDetalle.CurrentRow.Cells[serielote.Name].ReadOnly = true; dgvDetalle.CurrentRow.Cells[serielote.Name].Value = "0"; break;
                //    case 3: dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true; dgvDetalle.CurrentRow.Cells[cantidad.Name].Value = "01"; break;
                //    case 4: dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true; dgvDetalle.CurrentRow.Cells[cantidad.Name].Value = ""; dgvDetalle.CurrentRow.Cells[serielote.Name].ReadOnly = true; dgvDetalle.CurrentRow.Cells[serielote.Name].Value = "0"; break;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void importes()
        {
            
                dgvDetalle.CurrentRow.Cells[precioventa.Name].Value = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[importe.Name].Value) - Convert.ToDouble(dgvDetalle.CurrentRow.Cells[montodscto.Name].Value);
                dgvDetalle.CurrentRow.Cells[valorventa.Name].Value = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[precioventa.Name].Value) / Convert.ToDouble(frmLogin.Configuracion.IGV / 100 + 1);
                dgvDetalle.CurrentRow.Cells[igv.Name].Value = Convert.ToDouble(dgvDetalle.CurrentRow.Cells[precioventa.Name].Value) - Convert.ToDouble(dgvDetalle.CurrentRow.Cells[valorventa.Name].Value);
            
            recalculadetalle();
        }

        private void txtFlete_KeyUp(object sender, KeyEventArgs e)
        {
            if (verificarCamposVacios() == 1)
            {
                MessageBox.Show("Debe completar Datos Vacios");
            }
            else
            {
                if (txtFlete.Text == "" || txtFlete.Text == "0.0000")
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        row.Cells[flete.Name].Value = String.Format("{0:#,##0.0000}", 00);
                    }
                    recalculadetalle();
                    calculatotales();
                }
                else
                {
                    prorrateodeflete();
                    recalculadetalle();
                    calculatotales();
                }
            }
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                prorrateodeflete();
                recalculadetalle();
                calculatotales();
            }  
        }

        private void dgvDetalle_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "preciounit" && txtedit.Text != "")//Cantidad
                {

                    dgvDetalle.CurrentRow.Cells[importe.Name].Value =  Convert.ToDouble(dgvDetalle.CurrentRow.Cells[cantidad.Name].Value) * Convert.ToDouble(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);
                    importes();
                    calculatotales();

                    if (Convert.ToString(dgvDetalle.CurrentRow.Cells[dscto1.Name].Value) == "") { dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = ""; calculatotales(); }
                    if (Convert.ToString(dgvDetalle.CurrentRow.Cells[dscto2.Name].Value) == "") { dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = ""; calculatotales(); }
                    if (Convert.ToString(dgvDetalle.CurrentRow.Cells[dscto3.Name].Value) == "") { dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = ""; calculatotales(); }

                    importes();
                    calculatotales();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.Rows.Count >= 1 && dgvDetalle.CurrentRow.Index == e.RowIndex && e.RowIndex != -1)
            {
                if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[bonificacion.Name].Value) == 1)
                {
                    MessageBox.Show("Es Bonificación No Necesita Ingresar Montos");
                    dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
                    dgvDetalle.CurrentRow.Cells[cantidad.Name].ReadOnly = true;
                    dgvDetalle.CurrentRow.Cells[dscto1.Name].ReadOnly = true;

                }
            }
            if (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value) != 0)
            {
                //dgvDetalle.CurrentRow.Cells[preciounit.Name].ReadOnly = true;
            }
        }

        public Boolean VerificarDetracciones()//MOD7
        {
            sumadet = 0;
            if (CodDocumento == 2)
            {
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[igv.Name].Value) == 0)
                        {
                            sumadet = sumadet + Convert.ToDecimal(row.Cells[precioventa.Name].Value);
                        }
                    }
                }
                if (sumadet <= 700)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        
    }
}
