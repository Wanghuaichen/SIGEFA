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
    public partial class frmDetalleGuia : DevComponents.DotNetBar.Office2007Form
    {
        public static List<Int32> seleccion = new List<Int32>();
        public Int32 Proceso = 0,repetido=0;
        public Int32 Seleccion = 0;
        public Int32 Procede = 0;//(1)nota de salida (2)venta (3)Pedidoventa
        public Int32 CodProducto = 0;
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto pro = new clsProducto();
        clsProducto prod = new clsProducto();
        public clsDetalleRequerimiento detalle;
        clsUnidadEquivalente uniequi = new clsUnidadEquivalente();
        clsUnidadMedida unidadMed = new clsUnidadMedida();
        clsAdmUnidad Unid = new clsAdmUnidad();
        Decimal factorconvert = 0;
        clsValidar ok = new clsValidar();
        public DataTable data = new DataTable();
        public Int32 Codlista = 0, codproveedor=0;
        public Int32 codalmacen = 0;
        clsAdmOrdenCompra AdmOrd = new clsAdmOrdenCompra();
        public Decimal stock = 0;

        public frmDetalleGuia()
        {
            InitializeComponent(); 
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosLista frm = new frmProductosLista();
                frm.ShowDialog();
            }
        }

        //private void ingresarseleccion()
        //{
        //    foreach (Int32 cod in seleccion)
        //    {
        //        txtCodigo.Text = cod.ToString();
        //    }
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargaProducto()
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    pro =  AdmPro.CargaProductoDetalle1(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 2, Codlista);
                    if (pro != null)
                    {
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;
                        CargaUnidades(cmbUnidad);
                        cmbUnidad.SelectedIndex = 0;
                        cmbUnidad_SelectionChangeCommitted(new object(), new EventArgs());
                        stock = pro.StockDisponible;
                        txtStock.Text = pro.StockDisponible.ToString();
                    }
                    else { 
                         MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (/*Seleccion == 2 &&*/ txtCodigo.Text != "")
            {
                pro = AdmPro.CargaProductoDetalle(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 2, Codlista);
               if (Procede == 11)
                {
                    frmRequerimiento form = (frmRequerimiento)Application.OpenForms["frmRequerimiento"];
                    if (form.codProd.Contains(pro.CodProducto) && Proceso == 1)
                    {
                        MessageBox.Show("El Producto ya existe");
                        repetido = 1;
                    }
                    else
                    {
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;
                        CargaUnidades(cmbUnidad);
                        cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                        txtStock.Text = pro.StockDisponible.ToString();
                        unidadMed = Unid.CargaUnidad(Convert.ToInt32(cmbUnidad.SelectedValue));
                        txtUnidad.Text = unidadMed.Descripcion;
                        txtControlStock.Text = "";
                        txtCantidad.Text = "";
                        btnGuardar.Enabled = true;
                        switch (pro.CodControlStock)
                        {
                            case 1:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = true;
                                break;
                            case 2:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = true;
                                break;
                            case 3:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "01";
                                break;
                            case 4:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "";
                                break;
                        }
                    }
                }
                   else if (Procede == 3)
               { CargaProducto(); }
               else if (Procede == 9)
               {

                   frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                   if (form.codProd.Contains(pro.CodProducto) && Proceso == 1)
                   {
                       MessageBox.Show("El Producto ya existe");
                       repetido = 1;
                   }
                   else
                   {
                       CodProducto = pro.CodProducto;
                       txtReferencia.Text = pro.Referencia;
                       txtDescripcion.Text = pro.Descripcion;
                       txtUnidad.Text = pro.UnidadDescrip;
                       CargaUnidades(cmbUnidad);
                       cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                       stock = pro.StockDisponible;
                       txtStock.Text = pro.StockDisponible.ToString();

                       txtControlStock.Text = "";
                       txtCantidad.Text = "";

                       //unidadMed = Unid.CargaUnidad(Convert.ToInt32(cmbUnidad.SelectedValue));
                       //txtUnidad.Text = unidadMed.Descripcion;

                       btnGuardar.Enabled = true;
                       switch (pro.CodControlStock)
                       {
                           case 1:
                               txtControlStock.Enabled = false;
                               txtCantidad.Enabled = true;
                               break;
                           case 2:
                               txtControlStock.Enabled = true;
                               txtCantidad.Enabled = true;
                               break;
                           case 3:
                               txtControlStock.Enabled = true;
                               txtCantidad.Enabled = false;
                               txtCantidad.Text = "01";
                               break;
                           case 4:
                               txtControlStock.Enabled = false;
                               txtCantidad.Enabled = false;
                               txtCantidad.Text = "";
                               break;
                       }
                   }
               }
                else
                {
                    if (Procede == 2) pro = AdmPro.CargaProductoDetalle(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 2, 0);
                    else pro = AdmPro.CargaProductoDetalle(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 2, Codlista);
                    //listaprecio = AdmLista.CargaListaPrecio(Codlista);
                    CodProducto = pro.CodProducto;
                    txtReferencia.Text = pro.Referencia;
                    txtDescripcion.Text = pro.Descripcion;
                    txtUnidad.Text = pro.UnidadDescrip;
                    CargaUnidades(cmbUnidad);
                    cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                    stock = pro.StockDisponible;
                    txtStock.Text = pro.StockDisponible.ToString();

                    //if (Procede == 42)
                    //    txtStock.Text = String.Format("{0:#,##0.00}", stock42);

                    txtControlStock.Text = "";
                    txtCantidad.Text = "";
                    //if (pro.PrecioVariable) { if (frmLogin.iCodUser == 10) { txtPrecio.ReadOnly = false; txtPrecioNeto.ReadOnly = false; } }
                    //else { /*txtPrecio.ReadOnly = true;*/ txtPrecioNeto.ReadOnly = true; }

                    //if (Moneda == 2) { txtPrecio.Text = pro.PrecioVenta.ToString(); puInicio = Convert.ToDecimal(pro.PrecioVenta); }
                    //else if (Moneda == 1) { txtPrecio.Text = pro.PrecioVentaSoles.ToString(); puInicio = Convert.ToDecimal(pro.PrecioVentaSoles);/*Math.Round((pro.PrecioVenta * tc),listaprecio.Decimales).ToString()*/ }

                    //if (pro.Oferta) { txtDscto1.Text = pro.PDescuento.ToString(); txtDscto1.ReadOnly = true; } else { txtDscto1.Text = ""; }
                    //txtDscto2.Text = "";
                    //txtDscto3.Text = "";
                    //if (pro.Oferta) { txtPrecioNeto.Text = pro.PrecioOferta.ToString(); } else { txtPrecioNeto.Text = pro.PrecioVenta.ToString(); }
                    //txtPrecioNeto.Text = "";
                    //txtDescMax.Text = String.Format("{0:#,##0.00}", pro.MaxPorcDesc);

                    //changeimporte = false;
                    

                    //CodProducto = pro.CodProducto;
                    //txtReferencia.Text = pro.Referencia;
                    //txtDescripcion.Text = pro.Descripcion;
                    //txtUnidad.Text = pro.UnidadDescrip;
                    //CargaUnidades(cmbUnidad);
                    //cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                    //txtStock.Text = pro.StockDisponible.ToString();
                    //unidadMed = Unid.CargaUnidad(Convert.ToInt32(cmbUnidad.SelectedValue));
                    //txtUnidad.Text = unidadMed.Descripcion;
                    //txtControlStock.Text = "";
                    //txtCantidad.Text = "";
                    //btnGuardar.Enabled = true;
                    switch (pro.CodControlStock)
                    {
                        case 1:
                            txtControlStock.Enabled = false;
                            txtCantidad.Enabled = true;
                            break;
                        case 2:
                            txtControlStock.Enabled = true;
                            txtCantidad.Enabled = true;
                            break;
                        case 3:
                            txtControlStock.Enabled = true;
                            txtCantidad.Enabled = false;
                            txtCantidad.Text = "01";
                            break;
                        case 4:
                            txtControlStock.Enabled = false;
                            txtCantidad.Enabled = false;
                            txtCantidad.Text = "";
                            break;
                    }
                }
                
            }
            if (txtCodigo.Text != "" && Procede==11)
            {
                if (Procede == 11) {
                    frmRequerimiento form = (frmRequerimiento)Application.OpenForms["frmRequerimiento"];
                    if (form.codProd.Contains(pro.CodProducto))
                    {

                    }
                }else if(Procede==9){
                    frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                    if (form.codProd.Contains(pro.CodProducto))
                    {

                    }
                }
                else
                {
                    pro = AdmPro.CargaProductoDetalle(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 2, Codlista);
                    txtStock.Text = pro.StockDisponible.ToString();
                }
            }
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCantidad.Text != "") 
                {
                    //if(Convert.ToDouble(txtCantidad.Text) <= pro.StockDisponible)
                    //{
                    //    if (txtPrecio.Text != "")
                    //    {
                    //        if (txtDscto1.Text == "") { txtDscto1.Text = "0.00"; }
                    //        if (txtDscto2.Text == "") { txtDscto2.Text = "0.00"; }
                    //        if (txtDscto3.Text == "") { txtDscto3.Text = "0.00"; }                       
                    //        txtPrecioNeto.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
                            if (pro != null)
                            {
                                btnGuardar.Enabled = true;
                            } 
                           ProcessTabKey(true);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Cantidad no disponible, verifique el stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    txtCantidad.Focus();
                    //}
                }
                if (Procede == 9)
                {
                    if (txtCantidad.Text != "")/*txtCantidad.Text="0";*/
                    {
                       /* if (Convert.ToDecimal(txtCantidad.Text) > pro.StockDisponible)
                        {
                            MessageBox.Show("Cantidad no disponible, verifique el stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCantidad.Focus();
                        }*/
                    }
                }
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Focus();
            }
            else if(cmbUnidad.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione unidad de medida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (pro != null && txtCantidad.Text != "")
            {
                btnGuardar.Enabled = true;
                btnGuardar.Focus();
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Double bruto, montodescuento, valorventa, igv, precioventa, precioreal, valorreal, factorigv;
            if (Procede == 5)//Cuando abre desde guia remision
            {
                frmGuiaRemision form = (frmGuiaRemision)Application.OpenForms["frmGuiaRemision"];

                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Verificar Cantidad", "DETALLE DE ARTICULO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
                else
                {
                    if (form.dgvDetalle.Rows.Count < 10) // se carga el numero de items que soporta el tamaño del formato
                    {
                        if (Proceso == 1)

                            

                            form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, txtCodUnidad.Text,
                                cmbUnidad.Text, txtControlStock.Text, Convert.ToDouble(txtCantidad.Text), "", "",
                                "", "", "", "", "", "", "", "", "");
                        limpiarformulario();
                        if (Seleccion == 2)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "DETALLE DE ARTICULO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            if (Procede == 11) //Cuando abre desde el requerimiento
            {
                
                frmRequerimiento form = (frmRequerimiento) Application.OpenForms["frmRequerimiento"];
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Verificar Cantidad", "DETALLE DE ARTICULO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
                else
                {
                    if (form.dgvDetalle.Rows.Count < 30)
                        // se carga el numero de items que soporta el tamaño del formato
                    {
                        if (form.proce == 1)
                        {
                            //if (form.codProd.Contains(pro.CodProducto))
                            //{
                            //    MessageBox.Show("El Producto ya existe");
                            //}
                            //else
                            //{
                                form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion,
                                    cmbUnidad.SelectedValue,
                                    txtUnidad.Text, Convert.ToDouble(txtCantidad.Text), "", "");
                                form.codProd.Add(pro.CodProducto);
                                limpiarformulario();
                                if (Seleccion == 2)
                                {
                                    this.Close();
                                }
                           // }
                        }
                        else if (form.proce == 2)
                        {

                            form.dgvDetalle.CurrentRow.SetValues(detalle.CodDetalleRequerimiento, pro.CodProducto,
                                pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue,
                                txtUnidad.Text, Convert.ToDouble(txtCantidad.Text), detalle.CodUser,
                                detalle.FechaRegistro);
                            form.codProd.Add(pro.CodProducto);
                            limpiarformulario();
                            this.Close();
                        }
                        else if (form.proce == 3)
                        {
                            data=(DataTable)form.dgvDetalle.DataSource;
                            data.Rows.Add(0, pro.CodProducto, pro.Referencia, pro.Descripcion,
                            cmbUnidad.SelectedValue,
                            txtUnidad.Text, Convert.ToDouble(txtCantidad.Text), 0, DateTime.Now);
                            form.dgvDetalle.DataSource = data;
                            limpiarformulario();
                            form.codProd.Add(pro.CodProducto);
                            if (Seleccion == 2)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "DETALLE DE ARTICULO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
           
        }
            if (Procede == 3) //Cuando abre desde transferencia
                {
                    //CargaProducto();
                    Decimal bruto, valorventa, igv, precioventa, precioreal, valorreal, factorigv;
                    F2TransferenciaEntreAlmacenes form = (F2TransferenciaEntreAlmacenes)Application.OpenForms["F2TransferenciaEntreAlmacenes"];
                    bruto = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(pro.ValorProm);
                    if (pro.ConIgv) 
                    { 
                        precioventa = bruto;
                        factorigv = ((Convert.ToDecimal(frmLogin.Configuracion.IGV) / 100) + 1);
                        valorventa = precioventa / factorigv;
                    }
                    else
                    {
                        valorventa = bruto;
                        precioventa = valorventa;
                    }
                    precioreal = precioventa / Convert.ToDecimal(txtCantidad.Text);
                    valorreal = valorventa / Convert.ToDecimal(txtCantidad.Text);
                    igv = precioventa - valorventa;
                    if (form.dgvDetalle.Rows.Count < 15) 
                    {
                        
                        form.dgvDetalle.Rows.Add("", pro.CodProducto, txtReferencia.Text, txtDescripcion.Text, pro.CodUnidadMedida,
                        pro.UnidadDescrip, txtControlStock.Text, Convert.ToDouble(txtCantidad.Text), pro.ValorProm, bruto,
                        0, 0, 0, 0,
                        valorventa, igv, precioventa, precioreal, /*valorreal*/precioreal, "", "", 0, pro.ValorProm, uniequi.Factor);
                       
                        

                        limpiarformulario();
                        if (Seleccion == 2)
                        {
                            this.Close();
                        }
                        btnGuardar.Enabled = false;
                        txtReferencia.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "Detalle Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
            if (Procede == 9)//Cuando abre desde el nota salida
            {
                frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                form.Procede = 9;
                if (txtCantidad.Text == "") { MessageBox.Show("Verificar Cantidad", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information); txtCantidad.Focus(); }
                else if (Convert.ToDecimal(txtCantidad.Text) > pro.StockDisponible)
                    {
                        MessageBox.Show("Cantidad no disponible, verifique el stock", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCantidad.Focus();
                    }
                else
                {
                    if (form.dgvDetalle.Rows.Count < 10) // se carga el numero de items que soporta el tamaño del formato
                    {
                        prod = AdmPro.MuestraProductosTransferencia(pro.CodProducto, frmLogin.iCodAlmacen);
                        if (Proceso == 1)
                        {
                            form.dgvDetalle.Rows.Add("0", pro.CodProducto, pro.Referencia, pro.Descripcion, txtCodUnidad.Text,
                            txtUnidad.Text, Convert.ToDouble(txtCantidad.Text), prod.ValorProm,prod.ValorPromsoles,prod.PrecioProm, prod.StockActual);
                            limpiarformulario();
                            if (Seleccion == 2)
                            {
                                this.Close();
                            }
                        }
                        else if (Proceso == 2)
                        {

                            form.dgvDetalle.CurrentRow.SetValues("0", Convert.ToInt32(txtCodigo.Text), txtReferencia.Text, txtDescripcion.Text, Convert.ToInt32(txtCodUnidad.Text),
                            txtUnidad.Text, Convert.ToDouble(txtCantidad.Text), prod.ValorProm, prod.ValorPromsoles, prod.PrecioProm, prod.StockActual);
                            limpiarformulario();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (Procede == 10) //Cuando abre desde la nota de ingreso por orden compra
            {

                frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                if (txtCantidad.Text == "" || Convert.ToInt32(txtCantidad.Text) == 0)
                {
                    MessageBox.Show("Verificar Cantidad", "DETALLE DE ARTICULO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
                else
                {
                    Decimal Bonificacion, Precio, bruto, montodescuento, valorventa, igv, precioventa, precioreal, valorreal, factorigv, dsc1, dsc2, dsc3, preunitario;


                    if (chBonificacion.Checked)
                    {
                        Precio = 0;
                        Bonificacion = 1;
                    }

                    else
                    {
                        Precio = AdmPro.CargaPrecioProducto(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, Convert.ToInt32(form.cmbMoneda.SelectedValue));
                        Bonificacion = 0;
                    }


                    //if (form.dgvDetalle2.Rows.Count < 10)
                    //// se carga el numero de items que soporta el tamaño del formato
                    //{

                    bruto = Convert.ToDecimal(txtCantidad.Text) * Precio;

                    if (pro.ConIgv)
                    {
                        precioventa = bruto;
                        factorigv = Convert.ToDecimal(frmLogin.Configuracion.IGV / 100 + 1);
                        valorventa = precioventa / factorigv;
                    }
                    else
                    {
                        valorventa = Precio;
                        precioventa = valorventa;
                    }
                    precioreal = precioventa / Convert.ToDecimal(txtCantidad.Text);
                    valorreal = valorventa / Convert.ToDecimal(txtCantidad.Text);
                    igv = precioventa - valorventa;

                    if (Proceso == 1)
                    {
                        data = (DataTable)form.dgvDetalle2.DataSource;
                        if (form.dgvDetalle2.Rows.Count <= 0)
                        {
                            form.dgvDetalle2.Rows.Add("0", pro.CodProducto, pro.Referencia, pro.Descripcion, txtUnidad.Text, cmbUnidad.SelectedValue, Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtStock.Text), Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(Precio), bruto,
                               0, 0, 0, 0, valorventa, igv, precioventa, precioreal, valorreal, 0, Convert.ToDouble(txtCantidad.Text), 0, Convert.ToDouble(txtCantidad.Text), 0, Bonificacion);
                            //form.dgvDetalle2.DataSource = data;
                        }
                        else
                        {
                            if (data == null)
                            {
                                form.dgvDetalle2.Rows.Add("0", pro.CodProducto, pro.Referencia, pro.Descripcion, txtUnidad.Text, cmbUnidad.SelectedValue, Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtStock.Text), Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(Precio), bruto,
                                  0, 0, 0, 0, valorventa, igv, precioventa, precioreal, valorreal, 0, Convert.ToDouble(txtCantidad.Text), 0, Convert.ToDouble(txtCantidad.Text), 0, Bonificacion);

                            }
                            else
                            {
                                data.Rows.Add("0", pro.CodProducto, pro.Referencia, pro.Descripcion, txtUnidad.Text, cmbUnidad.SelectedValue, Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtStock.Text), Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(Precio), bruto,
                               0, 0, 0, 0, valorventa, igv, precioventa, precioreal, valorreal, 0, Convert.ToDouble(txtCantidad.Text), 0, Convert.ToDouble(txtCantidad.Text), 0, Bonificacion);
                                form.dgvDetalle2.DataSource = data;
                            }

                        }

                        limpiarformulario();
                        if (Seleccion == 2)
                        {
                            this.Close();
                        }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "DETALLE DE ARTICULO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }        
        }

        private void CargaFilaDetalle()
        {
            //detalle.CodDetalleSalida = 0;
            //detalle.CodProducto = pro.CodProducto;
            //detalle.Referencia = pro.Referencia;
            //detalle.Descripcion = pro.Descripcion;
            //detalle.UnidadIngresada = Convert.ToInt32(cmbUnidad.SelectedValue);
            //detalle.Unidad = cmbUnidad.Text;
            //detalle.SerieLote = txtControlStock.Text;
            //detalle.Cantidad = Convert.ToDouble(txtCantidad.Text);
            //detalle.PrecioUnitario = Convert.ToDouble(txtPrecio.Text);
            //detalle.Importe = bruto;
            //detalle.Descuento1 = Convert.ToDouble(txtDscto1.Text);
            //detalle.Descuento2 = Convert.ToDouble(txtDscto2.Text);
            //detalle.Descuento3 = Convert.ToDouble(txtDscto3.Text);
            //detalle.MontoDescuento = montodescuento;
            //detalle.ValorVenta = valorventa;
            //detalle.Igv = igv;
            //detalle.PrecioVenta = precioventa;
            //detalle.PrecioReal = precioreal;
            //detalle.ValoReal = valorreal;
        }

       

        private void txtControlStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void frmDetalleSalida_Shown(object sender, EventArgs e)
        {
            if (txtReferencia.Text.Trim() == "")
            {
                txtReferencia.Focus();
            }
            if (Proceso == 2)
            {
                txtCantidad.Focus();
            }
            else if ((Proceso == 3 && txtDescripcion.Text.Trim() != "") || (Proceso == 1 && txtDescripcion.Text.Trim() != ""))
            {
                txtCantidad.Focus();
            }
        }
        private void limpiarformulario()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        
        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmProductosLista"] != null)
                {
                    Application.OpenForms["frmProductosLista"].Activate();
                }
                else
                {
                    frmProductosLista frm = new frmProductosLista();
                    frm.Procede = Procede;
                    frm.Proceso = Proceso;
                    frm.codproveedor = codproveedor;
                    frm.CodLista = Codlista;
                    
                    if (codalmacen != 0)
                    {
                        frm.codalmacen = codalmacen;
                    }
                    
                    
                    if (frm.ShowDialog() == DialogResult.OK) 
                    {
                        if (frm.GetCodigoProducto().ToString()!="")
                        {
                            txtCodigo.Text = frm.GetCodigoProducto().ToString();
                            txtCantidad.Focus();
                        }
                        //if (cmbUnidad.Items.Count > 0)
                        //{
                        //    cmbUnidad_SelectionChangeCommitted(sender, e);
                        //}
                    }
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                frmRegistroProducto frm = new frmRegistroProducto();
                frm.ShowDialog();
            }
            
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtReferencia.Text != "")
                {
                    if (BuscaProducto())
                    {
                        if (Procede == 3) CargaProducto();
                        ProcessTabKey(true);
                    }
                    else {
                        MessageBox.Show("Verifique datos del producto ","Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                   
                   
                
                }
                
            }
        }

        private Boolean BuscaProducto()
        {
            pro = AdmPro.CargaProductoDetalleR(txtReferencia.Text, frmLogin.iCodAlmacen, 2, Codlista);
            if (pro != null)
            {
                if (Procede == 11) {
                    frmRequerimiento form = (frmRequerimiento)Application.OpenForms["frmRequerimiento"];
                    if (form.codProd.Contains(pro.CodProducto) && Proceso == 1)
                    {
                        MessageBox.Show("El Producto ya existe");
                        repetido = 1;
                        return false;
                    }
                    else
                    {
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;
                        CargaUnidades(cmbUnidad);
                        cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                        txtStock.Text = pro.StockDisponible.ToString();
                        txtControlStock.Text = "";
                        txtCantidad.Text = "";
                        switch (pro.CodControlStock)
                        {
                            case 1:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = true;
                                break;
                            case 2:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = true;
                                break;
                            case 3:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "01";
                                break;
                            case 4:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "";
                                break;
                        }
                        return true;
                    }
                }
                else if (Procede == 9)
                {
                    frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                    if (form.codProd.Contains(pro.CodProducto) && Proceso == 1)
                    {
                        MessageBox.Show("El Producto ya existe");
                        repetido = 1;
                        return false;
                    }
                    else
                    {
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;
                        CargaUnidades(cmbUnidad);
                        cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                        txtStock.Text = pro.StockDisponible.ToString();
                        txtControlStock.Text = "";
                        txtCantidad.Text = "";
                        switch (pro.CodControlStock)
                        {
                            case 1:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = true;
                                break;
                            case 2:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = true;
                                break;
                            case 3:
                                txtControlStock.Enabled = true;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "01";
                                break;
                            case 4:
                                txtControlStock.Enabled = false;
                                txtCantidad.Enabled = false;
                                txtCantidad.Text = "";
                                break;
                        }
                        return true;
                    }
                }
                else {
                    CodProducto = pro.CodProducto;
                    txtCodigo.Text = pro.CodProducto.ToString();
                    txtReferencia.Text = pro.Referencia;
                    txtDescripcion.Text = pro.Descripcion;
                    txtUnidad.Text = pro.UnidadDescrip;
                    CargaUnidades(cmbUnidad);
                    cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                    if (pro.CodUnidadMedida > 0) { cmbUnidad.SelectedIndex = 0; }
                    txtStock.Text = pro.StockDisponible.ToString();
                    txtControlStock.Text = "";
                    txtCantidad.Text = "";
                    switch (pro.CodControlStock)
                    {
                        case 1:
                            txtControlStock.Enabled = false;
                            txtCantidad.Enabled = true;
                            break;
                        case 2:
                            txtControlStock.Enabled = true;
                            txtCantidad.Enabled = true;
                            break;
                        case 3:
                            txtControlStock.Enabled = true;
                            txtCantidad.Enabled = false;
                            txtCantidad.Text = "01";
                            break;
                        case 4:
                            txtControlStock.Enabled = false;
                            txtCantidad.Enabled = false;
                            txtCantidad.Text = "";
                            break;
                    }
                    return true;
                }
            }
            else
            {
                CodProducto = 0;
                txtDescripcion.Text = "";
                txtUnidad.Text = "";
                cmbUnidad.SelectedIndex = -1;
                txtStock.Text = "";
                txtControlStock.Text = "";
                txtCantidad.Text = "";                
                return false;
            }
        }

        private void CargaUnidades(ComboBox combo)
        {
            //combo.DataSource = AdmPro.CargaUnidadesEquivalentes(pro.CodProducto);
            //combo.DisplayMember = "descripcion";
            //combo.ValueMember = "codUnidadMedida";
            //combo.SelectedValue = pro.CodUnidadMedida;

            combo.Enabled = true;
            combo.Visible = true;
            if (Procede == 12 /*|| Procede == 3*/)
            {
                combo.DataSource = AdmPro.MuestraUnidadesEquivalentesCompra(CodProducto, frmLogin.iCodAlmacen);
                combo.DisplayMember = "descripcion";
                combo.ValueMember = "codUnidadMedida";
                //combo.SelectedValue = pro.CodUnidadMedida;
            }            
            else 
            {
                combo.DataSource = AdmPro.MuestraUnidadesEquivalentesVenta1(CodProducto, frmLogin.iCodAlmacen);//carga unidades sin precio
                combo.DisplayMember = "descripcion";
                combo.ValueMember = "codUnidadEquivalente";
                //combo.SelectedValue = pro.CodUnidadMedida;

            }
            if (combo.Items.Count > 0) { combo.SelectedIndex = 0; }
            txtStock.Visible = true;
            label4.Visible = true;
        }

        private void cmbUnidad_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbUnidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {   
                uniequi = AdmPro.PrecioVenta( Convert.ToInt32(cmbUnidad.SelectedValue), frmLogin.iCodAlmacen);
                    if (uniequi != null)
                    {
                       // if (uniequi.Stock > 0)
                       // {
                            txtStock.Text = string.Format("{0:###0.0000}", uniequi.Stock);
                            txtCodUnidad.Text = uniequi.CodUnidad.ToString();
                            
                            //txtCantidad.Text = "0.00";
                            
                            txtCantidad.Focus();
                           
                            btnGuardar.Enabled = true;
                            txtCantidad.Enabled = true;
                            
                            
                      //  }
                      //  else
                     /*   {
                            MessageBox.Show(
                                "No hay equivalencias ingresadas para la unidad de medida elegida.\nConfigure correctamente las unidades equivalentes.\nMientras tanto, no podrá realizar salidas de este producto.",
                                "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGuardar.Enabled = false;
                            txtCantidad.Enabled = false;
                            
                        }*/
                    }               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void frmDetalleGuia_Load(object sender, EventArgs e)
        {
            CargaUnidades(cmbUnidad);
        }

        

    }
}
