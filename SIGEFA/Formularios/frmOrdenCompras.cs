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
    public partial class frmOrdenCompras : DevComponents.DotNetBar.Office2007Form
    {
        clsValidar val = new clsValidar();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsMoneda Mon = new clsMoneda();
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Ord = new clsOrdenCompra();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsValidar ok = new clsValidar();
        clsDetalleOrdenCompra detaSelec = new clsDetalleOrdenCompra();
        clsAdmProducto Admpro = new clsAdmProducto();
        clsProducto prod = new clsProducto();
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleOrdenCompra> detalle = new List<clsDetalleOrdenCompra>();
        TextBox txtedit = new TextBox();
        public DataTable TablaDetalleOrdenes = new DataTable();
        public DataTable TablaDetalleOrdenesnuevo = new DataTable();
        public List<Int32> codProd = new List<int>();
        public Int32 CodProveedor;
        public Int32 CodOrdenCompra;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Procede = 0, Proce=0; //(10) Orden de Compra 
        public Int32 pro = 0;
        public Int32 Tipo=1;
        public Int32 CodDocumento;
        public Int32 CodSerie,num;
        public Int32 codorden = 0,estadcheck, proce;

        public Int32 Contador = 0;
        public List<Int32> documento = new List<Int32>();
        public List<Int32> codprod = new List<Int32>();
        private Int32 CodProd = 0;
        public DataTable tabdata = new DataTable();
        DataTable tabdata2 = new DataTable();
        String filtro = String.Empty;   

        public frmOrdenCompras()
        {
            InitializeComponent();
        }
      
        private Boolean BuscaSerie()
        {
            ser = Admser.BuscaSerie(txtSerie.Text, CodDocumento, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                num = ser.Numeracion;
                return true;
            }
            else
            {
                CodSerie = 0;
                num = 0;
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
                    if (CodSerie != 0)
                    {
                        txtcodserie.Text = ser.CodSerie.ToString();
                        txtSerie.Text = ser.Serie;
                    }
                    if (CodSerie != 0) { ProcessTabKey(true); }
                }
            }
           
        }
    
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
            
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
                txtNumero.Focus();
            }
            else
            {
                VerificarCabecera();
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

        private void VerificarCabecera()
        {
            Validacion = true;
            if (txtCodProv.Visible && CodProveedor == 0)
            {
                Validacion = false;
            }
        }
       
        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            CargaFormaPagos(0);
            cargaMoneda();
            txtSerie.Focus();
            CodDocumento = 13;
            doc=Admdoc.CargaTipoDocumento(CodDocumento);
            txtCodDoc.Text = doc.CodTipoDocumento.ToString();
            txtDocRef.Text = doc.Sigla;
            lbDocumento.Text =doc.Descripcion;
            tc = AdmTc.CargaTipoCambio(dtpFechaOrden.Value.Date, 2);
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
            }
            if (Proceso == 1)
            {
            }
            else if (Proceso == 3)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
        }

        private void CargaFormaPagos(Int32 tip)
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(tip);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = -1;
        }

        private void cargaDetalleOrden()
        {
            try
            {
                dgvDetalle.DataSource = AdmOrden.CargaDetalleOrdenCompra(Ord.CodOrdenCompra);
                tabdata = (DataTable)dgvDetalle.DataSource;
                dgvDetalle.ClearSelection();
                if (Proce == 2)
                {
                    CantPorAtender.Visible = false;
                    CantPorCompletar.Visible = false;
                    CantidadPorLlegar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void CargaDetalle()
        {
            try
            {
                if (Proceso == 1)
                {
                    //dgvDetalle.DataSource = AdmOrden.Cargadetalleconsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
                    tabdata = (DataTable) dgvDetalle.DataSource;
                }
                else if(Proceso==3)
                {
                    tabdata = (DataTable)dgvDetalle.DataSource;
                    tabdata2.Clear();
                    //tabdata2= AdmOrden.Cargadetalleconsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
                    if (tabdata2.Rows.Count>0)
                    {
                        tabdata.Merge(tabdata2);
                    }
                    dgvDetalle.DataSource = tabdata;
                    if (Proce == 2)
                    {
                        CantPorAtender.Visible = false;
                        CantPorCompletar.Visible = false;
                        CantidadPorLlegar.Visible = false;
                    }
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

       
        
        private void sololectura(Boolean estado)
        {
            txtDocRef.ReadOnly = !estado;
            txtSerie.Enabled = !estado;
            txtCodProv.ReadOnly = !estado;
            txtCodProv.Enabled = !estado;
            cmbMoneda.Enabled = !estado;
            btnImprimir.Visible = estado; //MOD3
            if (Proce == 2)
            {
                txtComentario.ReadOnly = estado;
                btnGuardar.Enabled = !estado;
                btnDetalle.Enabled= !estado;
                btnNuevo.Enabled = !estado;
                btnEliminar.Enabled = !estado;
                txtFlete.ReadOnly= estado;
                dgvDetalle.Enabled = !estado;
                cmbFormaPago.Enabled = !estado;
                cmbMoneda.Enabled = !estado;
                btnNuevo.Visible = !estado;
                //btnImprimir.Visible = estado;//MOD3
            }
            else if (Proce == 0)
            {
                cmbFormaPago.Enabled = estado;
                txtComentario.ReadOnly = !estado;
                btnGuardar.Enabled = estado;
                btnDetalle.Enabled = estado;
                btnNuevo.Enabled = estado;
                btnEliminar.Enabled = estado;
                txtFlete.ReadOnly = !estado;
                dgvDetalle.Enabled = estado;
                cmbMoneda.Enabled = estado;
                btnNuevo.Visible = estado;
                btnNuevo.Enabled = estado;
                //btnImprimir.Visible = estado;//MOD3
            }
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
                        txtCodProveedor.Text = Ord.CodProveedor.ToString();
                        txtCodProv.Text = Ord.RUCProveedor;
                        txtNombreProv.Text = Ord.RazonSocialProveedor;
                        BuscaProveedor();
                    }
                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = Ord.CodTipoDocumento;
                        txtDocRef.Text = Ord.SiglaDocumento;
                        //lbDocumento.Text = Ord.DescripcionDocumento;
                    }
                    txtcodserie.Text = Ord.CodSerie.ToString();
                    txtSerie.Text = Ord.Serie;
                    txtNumero.Text = Ord.NumDoc.ToString();
                    txtFlete.Text = Ord.Flete.ToString();
                    //dtpFechaOrden.Value = Ord.FechaOrden;
                    txtComentario.Text = Ord.Comentario;
                    cmbMoneda.SelectedValue = Ord.Moneda;
                    txtTipoCambio.Visible = true;
                    label16.Visible = true;
                    //txtTipoCambio.Text = Ord.Tipocambio.ToString();
                    //txtBruto.Text = String.Format("{0:#,##0.0000}",Ord.Bruto);
                    //txtDscto.Text = String.Format("{0:#,##0.0000}",Ord.Montodesc);
                    txtIGV.Text = String.Format("{0:#,##0.0000}",Ord.Igv);
                    txtValorVenta.Text = String.Format("{0:#,##0.0000}", (Ord.Total - Ord.Igv));
                    txtPrecioVenta.Text = String.Format("{0:#,##0.0000}",(Ord.Total));
                    //cmbFormaPago.SelectedValue = Ord.Formapago;
                    //dtpFechaPago.Value=Ord.Fechapago;
                    cargaDetalleOrden();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
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
                    form.Procede = 3;
                    form.ShowDialog();
                    if (CodProveedor != 0) { CargaProveedor(); ProcessTabKey(true); } else { BorrarProveedor(); }
                }
            }
            //if (txtNumero.Text == "")
            //{
            //    txtSerie.Focus();
            //}
            if (txtCodProveedor.Text != "")
            {
                btnDetalle.Visible = true;
                btnNuevo.Visible = true;
            }
            else
            {
                btnDetalle.Visible = false;
                btnNuevo.Visible = true;
            }
           
        }
     
       private void btnGuardar_Click(object sender, EventArgs e)
       {
            if (superValidator2.Validate())
            {
                if (verificarCamposVacios() == 1)
                {
                    //MessageBox.Show("Debe completar Detalle de Orden, Datos Vacios");
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
                    }
                }

                if (Proceso != 0 && txtPrecioVenta.Text != "0.0000" && verificarCamposVacios() != 1)
                {
                   Ord.CodAlmacen = frmLogin.iCodAlmacen;
                   Ord.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                   txtComentario.Text = txtComentario.Text.Replace(" - ", "");
                   txtComentario.Text = txtComentario.Text.Replace("\r\n", "\r\n - ");
                   if (txtComentario.Text != "") txtComentario.Text = " - " + txtComentario.Text;
                   Ord.Comentario = txtComentario.Text;
                   Ord.CodTipoDocumento = Convert.ToInt32(txtCodDoc.Text);
                   ser = Admser.BuscaSerie(txtSerie.Text, CodDocumento, frmLogin.iCodAlmacen);
                   Ord.CodSerie = Convert.ToInt32(txtcodserie.Text);
                   Ord.NumDoc = ser.Numeracion;
                   txtNumero.Text = Ord.NumDoc.ToString();
                   Ord.FechaOrden = dtpFechaOrden.Value.Date;
                   Ord.CodUser = frmLogin.iCodUser;
                   Ord.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                   Ord.Tipocambio = Convert.ToDecimal(txtTipoCambio.Text);
                   Ord.Bruto = Convert.ToDecimal(txtValorVenta.Text);
                   Ord.Montodesc = Convert.ToDecimal(txtDscto.Text);
                   Ord.Igv = Convert.ToDecimal(txtIGV.Text);
                   Ord.Total = Convert.ToDecimal(txtPrecioVenta.Text);
                   Ord.Formapago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                   Ord.Fechapago = dtpFechaPago.Value.Date;
                   if (txtFlete.Text != "")
                   {
                       Ord.Flete= Convert.ToDecimal(txtFlete.Text);
                   }
                   if (Proceso == 1)
                   {
                       if (AdmOrden.insert(Ord))
                       {

                           RecorreDetalle();
                           if (detalle.Count > 0)
                           {
                               foreach (clsDetalleOrdenCompra det in detalle)
                               {
                                   AdmOrden.insertdetalle(det);
                               }
                           }
                           MessageBox.Show("Los datos se guardaron correctamente", "Orden compra", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                           txtOrdenCompra.Text = Ord.CodOrdenCompraNuevo.ToString().PadLeft(11, '0');
                          
                           foreach (Int32 a in documento)
                           {
                               AdmOrden.AtenderRequerimiento(a, Ord.CodOrdenCompraNuevo);
                           }

                           AdmOrden.deleteConsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
                           proce = 2;
                           sololectura(true);
                           btnImprimir.Visible = true;
                           btnGuardar.Enabled = false;
                       }

                       
                   }

                   else if (Proceso == 3)
                   {
                       if (AdmOrden.update(Ord))
                       {
                           RecorreDetalle();
                           AdmOrden.suprimirdetalle(Ord.CodOrdenCompra);
                           if (detalle.Count > 0)
                           {
                               //documento.Clear();
                               foreach (clsDetalleOrdenCompra det in detalle)
                               {
                                   //if (det.CodDetalleOrdenCompra == 0 || det.CodUser == 0)
                                   //{
                                       AdmOrden.insertdetalle(det);
                                       //documento.Add(det.codDetalleRequerimiento);
                                   //}
                                   //else
                                   //{
                                   //    AdmOrden.updatedetalle(det);
                                   //}
                               }
                               
                           }
                          
                           foreach (Int32 a in documento)
                           {
                               AdmOrden.AtenderRequerimiento(a, Ord.CodOrdenCompra);
                           }

                           AdmOrden.deleteConsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);

                           MessageBox.Show("Los datos se guardaron correctamente", "Orden compra", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                           sololectura(true);
                           btnGuardar.Enabled = false;
                           btnImprimir.Visible = true;
                       }
                   }
               }
                else
                {
                    MessageBox.Show("Debe Ingresar Montos", "Orden Compra", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
           clsDetalleOrdenCompra deta = new clsDetalleOrdenCompra();
           deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
           if (Proceso == 3)
           {
               deta.CodDetalleOrdenCompra = Convert.ToInt32(fila.Cells[coddetalle.Name].Value.ToString());
               deta.CodOrdenCompra = Convert.ToInt32(Ord.CodOrdenCompra);
           }
           else
           {
               deta.CodOrdenCompra = Convert.ToInt32(Ord.CodOrdenCompraNuevo);
           }
           deta.CodAlmacen = frmLogin.iCodAlmacen;
           deta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
           deta.Unidad = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
           deta.Cantidad = Convert.ToDouble(fila.Cells[cantidadpendiente.Name].Value);
           deta.Preciounitario = Convert.ToDecimal(fila.Cells[preciounit.Name].Value);
           deta.Subtotal = Convert.ToDecimal(fila.Cells[importe.Name].Value);
           deta.Dscto1 = Convert.ToDecimal(fila.Cells[dscto1.Name].Value);
           deta.Dscto2 = Convert.ToDecimal(fila.Cells[dscto2.Name].Value);
           deta.Dscto3 = Convert.ToDecimal(fila.Cells[dscto3.Name].Value);
           deta.Montodscto = Convert.ToDecimal(fila.Cells[montodscto.Name].Value);
           deta.Igv = Convert.ToDecimal(fila.Cells[igv.Name].Value);
           deta.Importe = Convert.ToDecimal(fila.Cells[precioventa.Name].Value);
           deta.Precioreal = Convert.ToDecimal(fila.Cells[precioreal.Name].Value);
           deta.Valorreal = Convert.ToDecimal(fila.Cells[valoreal.Name].Value);
           deta.CantidadPendiente =0;
           deta.FechaRegistro = dtpFechaOrden.Value;
           deta.CodUser = frmLogin.iCodUser;
           deta.Flete = Convert.ToDecimal(fila.Cells[flete.Name].Value);
           detalle.Add(deta);

       }
     

       private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
       {
         
           if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
           {
               btnGuardar.Enabled = true;
               detaSelec.CodDetalleOrdenCompra= Convert.ToInt32(e.Row.Cells[coddetalle.Name].Value);
               detaSelec.CodProducto = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value);
               detaSelec.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
           }
       }

       private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
       {
           ok.enteros(e);
           if (e.KeyChar == (char)Keys.Return)
           {
               if (txtSerie.Text != "")
               {
                   if (BuscaSerie())
                   {
                       txtNumero.Text = ser.Numeracion.ToString();
                       ProcessTabKey(true);
                   }
                   else
                   {
                       MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

      
       private void btnDetalle_Click(object sender, EventArgs e)
       {           
           if (Application.OpenForms["frmConsolidado"] != null)
           {
               Application.OpenForms["frmConsolidado"].Close();
           }
           else
           {
                   frmConsolidado form = new frmConsolidado();
                   form.proceso = 2;
                   form.CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                   form.coddetallerequerimientos = documento;
                   //if (Proceso == 3)
                   //{
                   //    if (dgvDetalle.Rows.Count > 0)
                   //    {
                   //        foreach (DataGridViewRow row in dgvDetalle.Rows)
                   //        {
                   //            codProd.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
                   //        }
                   //    }
                   //    else
                   //    {
                   //        codProd.Add(0);
                   //    }
                   //}
                   //form.codProd = codProd;
                   form.MdiParent = MdiParent;
                   form.Show();
           }
           
       }

       private void btnEliminar_Click(object sender, EventArgs e)
       {
           if (dgvDetalle.SelectedRows.Count > 0) 
           {
               if (Proceso == 1)
               {
                   if (detaSelec.CodDetalleOrdenCompra != 0)// viene de requerimiento
                   {
                       documento.Remove(detaSelec.CodDetalleOrdenCompra);
                   }

                   codprod.Remove(detaSelec.CodProducto);
                   dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
               }
               else if (Proceso == 3 && dgvDetalle.Rows.Count >= 2)
               {
                   DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Orden Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (dlgResult == DialogResult.No)
                   {
                       return;
                   }
                   else
                   {
                       if (detaSelec.CodDetalleOrdenCompra != 0 && AdmOrden.deletedetalle(detaSelec.CodDetalleOrdenCompra, detaSelec.CodProducto))
                       {
                           MessageBox.Show("Los datos han sido eliminado correctamente", "Orden Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                       else if (detaSelec.CodDetalleOrdenCompra != 0 && !AdmOrden.deletedetalle(detaSelec.CodDetalleOrdenCompra, detaSelec.CodProducto))
                       {
                           documento.Remove(detaSelec.CodDetalleOrdenCompra);
                       }
                       codprod.Remove(detaSelec.CodProducto);
                       dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                   }
               }
               else
               {
                   MessageBox.Show("Verifique, El Detalle no puede ser vacio");
               }

           }
           else {
               MessageBox.Show("Verifique, El Detalle no puede ser vacio");
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


       private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
       {
           if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioventa")
           {
               if (Proceso == 1 || Proceso == 3)
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
                   calculatotales();
               }
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

       private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
       {
               calculatotales();
       }

       private void dgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
       {
               Decimal bruto = 0;
               Decimal descuen = 0;
               Decimal valor = 0;
               foreach (DataGridViewRow row in dgvDetalle.Rows)
               {
                   bruto = bruto + Convert.ToDecimal(row.Cells[importe.Name].Value);
                   descuen = descuen + Convert.ToDecimal(row.Cells[montodscto.Name].Value);
                   valor = valor + Convert.ToDecimal(row.Cells[valorventa.Name].Value);
               }
               txtBruto.Text = String.Format("{0:#,##0.0000}", bruto);
               txtDscto.Text = String.Format("{0:#,##0.0000}", descuen);
               txtValorVenta.Text = String.Format("{0:#,##0.0000}", valor);
               txtIGV.Text = String.Format("{0:#,##0.0000}", (bruto - descuen - valor));
               txtPrecioVenta.Text = String.Format("{0:#,##0.0000}", (bruto - descuen));
               calculatotales();
       }

       private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
       {
           fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
           dtpFechaPago.Value = dtpFechaOrden.Value.AddDays(fpago.Dias); 
       }

       private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       {
           txtedit = e.Control as TextBox;
           if (txtedit != null)
           {
               txtedit.KeyPress -= new KeyPressEventHandler(dgvDetalle_KeyPress);
               txtedit.KeyPress += new KeyPressEventHandler(dgvDetalle_KeyPress);
               txtedit.Leave += new EventHandler(dgvDetalle_Leave);
               txtedit.Leave += new EventHandler(dgvDetalle_Leave);
           }
       }

       private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
       {
           calculatotales();
       }

       private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
       {
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantidad" && txtedit.Text != "")
               {
                   val.SOLONumeros(sender,e);
               }
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "preciounit" && txtedit.Text != "")
               {
                   val.SOLONumeros(sender, e);
               }
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto1" && txtedit.Text != "")
               {
                   val.SOLONumeros(sender, e);
               }
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto2" && txtedit.Text != "")
               {
                   val.SOLONumeros(sender, e);
               }
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "dscto3" && txtedit.Text != "")
               {
                   val.SOLONumeros(sender, e);
               }
       }

       private void importes()
       {
           Decimal precio=0;
           Decimal valor=0;
           Decimal factorigv = 0;
           prod = Admpro.CargaProductoDetalle(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[codproducto.Name].Value), frmLogin.iCodAlmacen, 1, 0);
           if (cbValorVenta.Checked)
           {
               if (prod.ConIgv)
               {
                   valor = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value) - Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[montodscto.Name].Value);
                   factorigv = Convert.ToDecimal((frmLogin.Configuracion.IGV / 100 + 1));
                   precio = valor * factorigv;

                  /*precio = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value);
                  valor = precio / Convert.ToDecimal(frmLogin.Configuracion.IGV / 100 + 1);
                  Igv = precio - valor;*/
               }
               else
               {
                   valor = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value);
                   precio = valor;
                   /*
                   precio =Convert.ToDecimal( dgvDetalle.CurrentRow.Cells[importe.Name].Value);
                   valor =precio;
                   Igv = precio - valor;
                     */
               }
               dgvDetalle.CurrentRow.Cells[precioventa.Name].Value =  precio;
               dgvDetalle.CurrentRow.Cells[valorventa.Name].Value =  valor;
               dgvDetalle.CurrentRow.Cells[igv.Name].Value = precio - valor;
           }
           recalculadetalle();
       }

       private void recalculadetalle()
       {
           foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
           {
               row.Cells[valorventaconflete.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) + Convert.ToDecimal(row.Cells[flete.Name].Value);
               row.Cells[pvconflete.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) + Convert.ToDecimal(row.Cells[flete.Name].Value);
               if (Convert.ToDecimal(row.Cells[flete.Name].Value) > 0 && row.Cells[flete.Name].Value.ToString() != "")
               {
                   row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventaconflete.Name].Value) / Convert.ToDecimal(row.Cells[cantidadpendiente.Name].Value);
                   row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[pvconflete.Name].Value) / Convert.ToDecimal(row.Cells[cantidadpendiente.Name].Value);
               }
               else
               {
                   row.Cells[valoreal.Name].Value = Convert.ToDecimal(row.Cells[valorventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidadpendiente.Name].Value);
                   row.Cells[precioreal.Name].Value = Convert.ToDecimal(row.Cells[precioventa.Name].Value) / Convert.ToDecimal(row.Cells[cantidadpendiente.Name].Value);
               }
           }

       }

       private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
       {
           try
           {
                   if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "importe" ||
                       dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantidadpendiente" ||
                        dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "preciounit")
                   {
                       if (dgvDetalle.CurrentRow.Cells[cantidadpendiente.Name].Value.ToString() != "" &&
                           dgvDetalle.CurrentRow.Cells[preciounit.Name].Value.ToString() != "")
                       {
                           dgvDetalle.CurrentRow.Cells[importe.Name].Value =
                               Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidadpendiente.Name].Value) *
                               Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);
                           dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value) -
                           (Convert.ToDecimal((dgvDetalle.CurrentRow.Cells[importe.Name].Value)) *
                            (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto1.Name].Value) / 100)) *
                            (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto2.Name].Value) / 100)) *
                            (1 - (Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[dscto3.Name].Value) / 100)));
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
                           dgvDetalle.CurrentRow.Cells[montodscto.Name].Value = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[importe.Name].Value)-
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

       private void customValidator8_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
       {
           if (Proceso != 0)
               if (dgvDetalle.Rows.Count > 0)
                   e.IsValid = true;
               else
                   e.IsValid = false;
           else
               e.IsValid = true;
       }

       private void frmOrdenCompras_Shown(object sender, EventArgs e)
       {
           if (Proceso == 3)
           {
               sololectura(true);
           }
           
       }

       private void dgvDetalle_Leave(object sender, EventArgs e)
       {
           try
           {
               if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "preciounit" && txtedit.Text != "")//Cantidad
               {
                   dgvDetalle.CurrentRow.Cells[importe.Name].Value = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidadpendiente.Name].Value) *
                    Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[preciounit.Name].Value);

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

       private void dgvDetalle_Click(object sender, EventArgs e)
       {

       }

       private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
       {
           ok.SOLONumeros(sender, e);
           if (txtFlete.Text != "")
           {
               if (e.KeyChar == (char)Keys.Return)
               {
                   prorrateodeflete();
                   recalculadetalle();
                   calculatotales();
               }
           }
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
                       row.Cells[flete.Name].Value = 00;
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
           if (txtFlete.Text == "")
           {
               txtFlete.Text = "0.0000";
           }
       }

       private int verificarCamposVacios()
       {
           Int32 valor = 0;
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

               cant = Convert.ToString(Convert.ToInt32(row.Cells[cantidadpendiente.Name].Value));
               impor = Convert.ToString(row.Cells[importe.Name].Value);
               //IG = Convert.ToString(row.Cells[igv.Name].Value);
               MontDes = Convert.ToString(row.Cells[montodscto.Name].Value);
               precio = Convert.ToString(row.Cells[preciounit.Name].Value);
               d1 = Convert.ToString(row.Cells[dscto1.Name].Value);
               d2 = Convert.ToString(row.Cells[dscto2.Name].Value);
               d3 = Convert.ToString(row.Cells[dscto3.Name].Value);

               if (d1 != "" || d2 != "" || d3 != "") { calculatotales(); }

               if (cant == "" || precio == "" || impor == "" || /*IG == "" ||*/ cant == "0" || precio == "0" || precio == "0.00" || impor == "0.00" || impor == "0" )
               {
                   valor = 1;
               }
               

           }
           return valor;
       }

       private void prorrateodeflete()
       {
           if (txtFlete.Text != "" && dgvDetalle.Rows.Count >= 1 && Convert.ToDouble(txtPrecioVenta.Text) > 0)
           {
               Double precior = 0;
               Double percentr = 0;
               Double fleter = 0;
               Double totalr = 0;
               Double dflete = Convert.ToDouble(txtFlete.Text);

               foreach (DataGridViewRow row in dgvDetalle.Rows)
               {
                   totalr = totalr + Convert.ToDouble(row.Cells[precioventa.Name].Value);
               }
               foreach (DataGridViewRow row in dgvDetalle.Rows)
               {
                   precior = Convert.ToDouble(row.Cells[precioventa.Name].Value);
                   percentr = precior / totalr;
                   fleter = dflete * percentr;
                   row.Cells[flete.Name].Value = String.Format("{0:#,##0.00}", fleter); ;
               }
           }
       }

       private void txtCodProveedor_TextChanged(object sender, EventArgs e)
       {
           if (txtCodProveedor.Text.Length > 0)
           {
               btnDetalle.Visible = true;   
           }
       }


       private void btnNuevo_Click(object sender, EventArgs e)
       {
           RecorreDetalle();
           if (Application.OpenForms["frmDetalleIngreso"] != null)
           {
               Application.OpenForms["frmDetalleIngreso"].Activate();
           }
           else
           {
               frmDetalleIngreso form = new frmDetalleIngreso();
               form.Procede = 8;
               form.codproveedor = Convert.ToInt32(txtCodProveedor.Text);
               form.Proceso = Proceso;
               form.bvalorventa = cbValorVenta.Checked;
               form.Text = "Detalle de Productos";
               codProd.Clear();
               if (dgvDetalle.Rows.Count > 0)
               {
                   //foreach (DataGridViewRow row in dgvDetalle.Rows)
                   //{
                   //    codProd.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
                   //}
                   Proce = 1;
               }
               else
               {
                   //codProd.Add(0);
                   Proce = 2;
               }
               form.ShowDialog();
           }
           //if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
           //{
           //    DataGridViewRow row = dgvDetalle.SelectedRows[0];
           //    if (Application.OpenForms["frmDetalleIngreso"] != null)
           //    {
           //        Application.OpenForms["frmDetalleIngreso"].Activate();
           //    }
           //    else
           //    {
           //        frmDetalleIngreso form = new frmDetalleIngreso();
           //        form.Procede = 8;
           //        form.Proceso = 2;
           //        form.codproveedor = Convert.ToInt32(txtCodProveedor.Text);
           //        form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
           //        form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
           //        form.txtUnidad.Text = row.Cells[unidad.Name].Value.ToString();
           //        form.txtReferencia.ReadOnly = true;
           //        form.cmbUnidad.SelectedValue = row.Cells[codunidad.Name].Value.ToString();
           //        form.txtUnidad.Text = row.Cells[codunidad.Name].Value.ToString();
           //        form.txtDescripcion.Text = row.Cells[descripcion.Name].Value.ToString();
           //        form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
           //        form.txtCantidad.Focus();
           //        form.btnGuardar.Enabled = true;
           //        //form.ShowDialog();
           //    }
           //}
          // btnDetalle.Visible = false;
       }

       private void btnImprimir_Click(object sender, EventArgs e)
       {
           frmrptCotizacion frm = new frmrptCotizacion();
           frm.CodCotizacion = Convert.ToInt32(txtOrdenCompra.Text);//codigo del requerimiento
           if (Ord.Vigente == 0) //MOD3
           {
               frm.tipo = 18;
           }
           else
           {
               frm.tipo = 3;
           }
           frm.ShowDialog();
       }

       private void dtpFechaOrden_ValueChanged(object sender, EventArgs e)
       {
           if (Proceso == 1)
           {
               tc = AdmTc.CargaTipoCambio(dtpFechaOrden.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
               if (tc != null)
               {
                   txtTipoCambio.Text = tc.Venta.ToString();
                   dtpFechaPago.Value = dtpFechaOrden.Value.AddDays(fpago.Dias);
               }
               else
               {
                   MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   dtpFechaOrden.Value = DateTime.Now.Date;
                   dtpFechaOrden.Focus();
               }
           }
           
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

       private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           if (dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "stockactual")
           {
               CodProd = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[codproducto.Name].Value);
               frmDetalleStock frm = new frmDetalleStock();
               frm.CodProducto = CodProd;
               frm.ShowDialog();
           }
       }
    }
}
