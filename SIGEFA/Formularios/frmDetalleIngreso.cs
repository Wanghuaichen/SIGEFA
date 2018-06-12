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
    public partial class frmDetalleIngreso : DevComponents.DotNetBar.Office2007Form
    {
        public static List<Int32> seleccion = new List<Int32>();
        public Int32 Proceso = 0,repetido=0, proce=0;
        public Int32 Procede = 0;
        public Int32 Seleccion = 0;
        public Int32 CodProducto = 0, codproveedor=0;
        public Boolean bvalorventa = false;
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto pro = new clsProducto();
        clsProducto pro1 = new clsProducto();
        public Int32 CodLista = 0;
        clsValidar ok = new clsValidar();
        public List<clsDetalleNotaIngreso> productoscargados = new List<clsDetalleNotaIngreso>(); // relacion de los productos que ya han sido cargado en la nota de ingreso       
        public DataTable data = new DataTable();
        public frmDetalleIngreso()
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (/*Seleccion == 2 && */txtCodigo.Text != "")
            {
                pro = AdmPro.CargaProductoDetalle(Convert.ToInt32(txtCodigo.Text), frmLogin.iCodAlmacen, 1,CodLista);
                //pro1 = AdmPro.CargaDatosProductoOrden(pro.CodProducto, frmLogin.iCodAlmacen, frmLogin.iCodUser);
                if (Procede == 10)
                {
                    frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];
                    //if (form.codpro.Contains(pro.CodProducto))
                    //{
                    //    MessageBox.Show("El Producto ya existe");
                    //    repetido = 1;
                    //}
                    //else
                    //{
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;

                        CargaUnidades(cmbUnidad);                        
                        cmbUnidad.SelectedValue = pro.CodUnidadMedida;                        
                        txtPrecio.Text = pro.PrecioCompra.ToString();

                        txtStock.Text = pro.StockDisponible.ToString();
                        switch (pro.CodControlStock)
                        {
                            case 1: txtControlStock.Enabled = false; txtCantidad.Enabled = true; break;
                            case 2: txtControlStock.Enabled = true; txtCantidad.Enabled = true; break;
                            case 3: txtControlStock.Enabled = true; txtCantidad.Enabled = false; txtCantidad.Text = "01"; break;
                            case 4: txtControlStock.Enabled = false; txtCantidad.Enabled = false; txtCantidad.Text = ""; break;
                        }
                    //}
                }
                else if(Procede==6)
                {
                    frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                    //if (form.codProd.Contains(pro.CodProducto))
                    //{
                    //    MessageBox.Show("El Producto ya existe");
                    //    repetido = 1;
                    //}
                    //else
                    //{
                        CodProducto = pro.CodProducto;
                        txtReferencia.Text = pro.Referencia;
                        txtDescripcion.Text = pro.Descripcion;
                        txtUnidad.Text = pro.UnidadDescrip;

                        CargaUnidades(cmbUnidad);
                        cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                        txtStock.Text = pro.StockDisponible.ToString();
                        switch (pro.CodControlStock)
                        {
                            case 1: txtControlStock.Enabled = false; txtCantidad.Enabled = true; break;
                            case 2: txtControlStock.Enabled = true; txtCantidad.Enabled = true; break;
                            case 3: txtControlStock.Enabled = true; txtCantidad.Enabled = false; txtCantidad.Text = "01"; break;
                            case 4: txtControlStock.Enabled = false; txtCantidad.Enabled = false; txtCantidad.Text = ""; break;
                        }
                    //}
                }
            }
        }       

        private void txtDscto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDscto1.Text == "")
                    {
                        txtDscto1.Text = "0.000";
                    }
                    txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)));
                }
                ProcessTabKey(true);
            }
        }

        private void txtDscto_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                if (txtDscto1.Text == "")
                {
                    txtDscto1.Text = "0.000";
                }
                txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)));
            }             
        }

        private void txtPrecioNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            //if( txtPrecioNeto.Text != "")
            //{
            //    if (txtDscto1.Text == "") { txtDscto1.Text = "0.00"; }
            //    if (txtDscto2.Text == "") { txtDscto2.Text = "0.00"; }
            //    if (txtDscto3.Text == "") { txtDscto3.Text = "0.00"; }
            //    if (txtCantidad.Text != "")
            //    {
            //        txtPrecio.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioNeto.Text) / (1 - (Convert.ToDouble(txtDscto3.Text) / 100)) / (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) / (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) / Convert.ToDouble(txtCantidad.Text));
            //    }               
            //}
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                    if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                    if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                    if (txtCantidad.Text != "")
                    {
                        txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
                    }
                }
                ProcessTabKey(true);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                    if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                    if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                    if (txtCantidad.Text != "" || Convert.ToDecimal(txtCantidad.Text) != 0)
                    {
                        txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
                    }
                    else { txtCantidad.Focus(); }
                }
                if (txtCantidad.Text != "")
                    if (Convert.ToDecimal(txtCantidad.Text) != 0)
                        txtPrecio.Focus();
                    else txtCantidad.Focus();
                else txtCantidad.Focus();

                //ProcessTabKey(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbUnidad.Text != "")
            {
                if (txtCantidad.Text != "")
                {
                    if (Convert.ToDecimal(txtCantidad.Text) != 0)
                    {
                        Double bruto, montodescuento, valorventa, igv, precioventa, precioreal, valorreal, factorigv, dsc1, dsc2, dsc3, preunitario;
                        if (Procede == 6)//Cuando abre desde nota de ingreso
                        {
                            frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                            if (bvalorventa == false)
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (pro.TipoImpuesto == 1)
                                {

                                    precioventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                    valorventa = precioventa / factorigv;
                                    this.Close();
                                }
                                else
                                {
                                    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    precioventa = valorventa;
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (Proceso == 1)
                                {
                                    form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, form.cmbMoneda.SelectedValue,
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, "0.00", igv, precioventa, precioventa, precioreal, valorreal, "", "", "");

                                    limpiarformulario();

                                    if (Seleccion == 2)
                                    {
                                        this.Close();
                                    }
                                }
                                else if (Proceso == 2)
                                {
                                    form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();
                                    this.Close();
                                }
                            }
                            else
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (bvalorventa == true)
                                {
                                    //DEBE TOMAR EL DATO DE IGV DE LA CONFIGURACION DEL SISTEMA   
                                    if (pro.ConIgv)
                                    {
                                        
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                        precioventa = valorventa * factorigv;
                                    }
                                    else
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        precioventa = valorventa;
                                    }
                                }
                                else
                                {
                                    if (pro.ConIgv)
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                        precioventa = valorventa * factorigv;
                                    }
                                    else
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        precioventa = valorventa;
                                    }
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (Proceso == 1)
                                {
                                    form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, form.cmbMoneda.SelectedValue,
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, "0.00", igv, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();

                                    if (Seleccion == 2)
                                    {
                                        this.Close();
                                    }
                                }
                                else if (Proceso == 2)
                                {
                                    form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();
                                    this.Close();
                                }
                            }
                        }
                        else if (Procede == 7)//Cuando de abre desde Nota de credito
                        {

                            frmNotadeCredito form = (frmNotadeCredito)Application.OpenForms["frmNotadeCredito"];

                            if (bvalorventa)
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (pro.ConIgv)
                                {
                                    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                    precioventa = valorventa * factorigv;
                                }
                                else
                                {
                                    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    precioventa = valorventa;
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (form.dgvDetalle.Rows.Count < 10) // se carga el numero de items que soporta el tamaño del formato
                                {

                                    if (Proceso == 1)
                                    {
                                        form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                            cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                            dsc1, dsc2, dsc3, montodescuento, valorventa,
                                            valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                        limpiarformulario();

                                        if (Seleccion == 2)
                                        {
                                            this.Close();
                                        }
                                    }
                                    else if (Proceso == 2)
                                    {
                                        form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                            cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                            dsc1, dsc2, dsc3, montodescuento, valorventa,
                                            valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                        limpiarformulario();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Se alcanzo el limite de items permitidos en el formato", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (pro.ConIgv)
                                {
                                    //DEBE TOMAR EL DATO DE IGV DE LA CONFIGURACION DEL SISTEMA   
                                    //if (pro.Igv)// venta activa con igv
                                    //{
                                    precioventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                    valorventa = precioventa / factorigv;
                                    //}
                                    //else
                                    //{
                                    //    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    //    precioventa = valorventa;
                                    //}
                                }
                                else
                                {
                                    //if (pro.Igv)
                                    //{
                                    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                    precioventa = valorventa * factorigv;
                                    //}
                                    //else
                                    //{
                                    //    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    //    precioventa = valorventa;
                                    //}
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (form.dgvDetalle.Rows.Count < 10) // se carga el numero de items que soporta el tamaño del formato
                                {
                                    if (Proceso == 1)
                                    {
                                        form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                            cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                            dsc1, dsc2, dsc3, montodescuento, valorventa,
                                            valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                        limpiarformulario();

                                        if (Seleccion == 2)
                                        {
                                            this.Close();
                                        }
                                    }
                                    else if (Proceso == 2)
                                    {
                                        form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                            cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                            dsc1, dsc2, dsc3, montodescuento, valorventa,
                                            valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
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
                        if (Procede == 10)//Cuando abre desde orden Compra
                        {

                            frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];

                            if (bvalorventa)
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (pro.ConIgv)
                                {
                                    valorventa = Convert.ToDouble(bruto) - montodescuento;
                                    factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                    precioventa = valorventa * factorigv;
                                }
                                else
                                {
                                    valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                    precioventa = valorventa;
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (Proceso == 1)
                                {
                                    form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();

                                    if (Seleccion == 2)
                                    {
                                        this.Close();
                                    }
                                }
                                else if (Proceso == 2)
                                {
                                    form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();
                                    this.Close();
                                }
                            }
                            else
                            {
                                bruto = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
                                montodescuento = bruto - Convert.ToDouble(txtPrecioNeto.Text);
                                if (pro.ConIgv)
                                {
                                    //DEBE TOMAR EL DATO DE IGV DE LA CONFIGURACION DEL SISTEMA   
                                    if (pro.ConIgv)
                                    {
                                        precioventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                        valorventa = precioventa / factorigv;
                                    }
                                    else
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        precioventa = valorventa;
                                    }
                                }
                                else
                                {
                                    if (pro.ConIgv)
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        factorigv = frmLogin.Configuracion.IGV / 100 + 1;
                                        precioventa = valorventa * factorigv;
                                    }
                                    else
                                    {
                                        valorventa = Convert.ToDouble(txtPrecioNeto.Text);
                                        precioventa = valorventa;
                                    }
                                }
                                precioreal = precioventa / Convert.ToDouble(txtCantidad.Text);
                                valorreal = valorventa / Convert.ToDouble(txtCantidad.Text);
                                igv = precioventa - valorventa;
                                if (txtDscto1.Text != "") { dsc1 = Convert.ToDouble(txtDscto1.Text); } else { dsc1 = 0.00; }
                                if (txtDscto2.Text != "") { dsc2 = Convert.ToDouble(txtDscto2.Text); } else { dsc2 = 0.00; }
                                if (txtDscto3.Text != "") { dsc3 = Convert.ToDouble(txtDscto3.Text); } else { dsc3 = 0.00; }

                                if (Proceso == 1)
                                {
                                    form.dgvDetalle.Rows.Add("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();

                                    if (Seleccion == 2)
                                    {
                                        this.Close();
                                    }
                                }
                                else if (Proceso == 2)
                                {
                                    form.dgvDetalle.CurrentRow.SetValues("", pro.CodProducto, pro.Referencia, pro.Descripcion, cmbUnidad.SelectedValue, "",
                                        cmbUnidad.Text, "0", Convert.ToDouble(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text), bruto,
                                        dsc1, dsc2, dsc3, montodescuento, valorventa,
                                        valorventa, igv, 0.00, precioventa, precioventa, precioreal, valorreal, "", "", "");
                                    limpiarformulario();
                                    this.Close();
                                }
                            }
                        }

                    }
                    else { txtCantidad.Focus(); }
                }
                else { txtCantidad.Focus(); }
            }
            else
            {
                MessageBox.Show("Falta Ingresar todas la unidades equivalentes", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDscto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                    if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                    if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                    txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
                }
                ProcessTabKey(true);
            }
        }

        private void txtDscto2_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
            }
        }

        private void txtDscto3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecio.Text != "")
                {
                    if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                    if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                    if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                    txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
                }
                ProcessTabKey(true);
            }
        }

        private void txtDscto3_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) * (1 - (Convert.ToDouble(txtDscto3.Text) / 100)));
            }           
        }

        private void txtControlStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void frmDetalleIngreso_Shown(object sender, EventArgs e)
        {
            if (Seleccion == 2)
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
            txtReferencia.Focus();
     
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                if (txtDscto1.Text == "")
                {
                    txtDscto1.Text = "0.000";
                }
                if (txtCantidad.Text != "")
                {
                    txtPrecioNeto.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text) * (1 - (Convert.ToDouble(txtDscto1.Text) / 100)));
                }
            }
            if (pro != null && txtCantidad.Text != "" && txtPrecio.Text != "")
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosLista frm = new frmProductosLista();
                frm.Proceso = Proceso;
                frm.Procede = Procede;
                frm.codproveedor = codproveedor;
                frm.bvalorventa = bvalorventa;
                frm.productoscargados = productoscargados;
                if (frm.ShowDialog() == DialogResult.OK) 
                {
                    txtCodigo.Text = frm.GetCodigoProducto().ToString();
                    Seleccion = 2;
                    if (repetido == 1) { Close(); this.Close(); }
                    else
                    {
                       cmbUnidad.Focus();
                       //ShowDialog();
                    }
                }                
            }
            else if(e.KeyCode == Keys.F2)
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
                        ProcessTabKey(true);
                    }
                    //else
                    //{
                    //    MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    //}
                }
            }
        }

        private Boolean verificaproductoscargados()
        {
            foreach (clsDetalleNotaIngreso det in productoscargados)
            {
                if(det.CodProEquals(pro.CodProducto))
                {
                    return false;
                    break;
                }
            }
            return true;
        }

        private Boolean BuscaProducto()
        {
            pro = AdmPro.CargaProductoDetalleR(txtReferencia.Text, frmLogin.iCodAlmacen,1, CodLista);
            if (pro != null)
            {
                if (verificaproductoscargados())
                {
                    if (Procede == 10)
                    {
                        frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];
                        //if (form.codProd.Contains(pro.CodProducto))
                        //{
                        //    MessageBox.Show("El Producto ya existe");
                        //    repetido = 1;
                        //    return false;
                        //}
                        //else
                        //{
                            CodProducto = pro.CodProducto;
                            txtReferencia.Text = pro.Referencia;
                            txtDescripcion.Text = pro.Descripcion;
                            txtUnidad.Text = pro.UnidadDescrip;
                            CargaUnidades(cmbUnidad);
                            cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                            txtStock.Text = pro.StockDisponible.ToString();
                            txtControlStock.Text = "";
                            txtCantidad.Text = "";
                            txtPrecio.Text = "";
                            txtDscto1.Text = "";
                            txtDscto2.Text = "";
                            txtDscto3.Text = "";
                            txtPrecioNeto.Text = "";
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
                                    break;
                                case 4:
                                    txtControlStock.Enabled = false;
                                    txtCantidad.Enabled = false;
                                    break;
                            }
                            return true;
                        //}
                    }else if (Procede == 6)
                    {
                        frmNotaIngreso form = (frmNotaIngreso) Application.OpenForms["frmNotaIngreso"];
                        //if (form.codProd.Contains(pro.CodProducto))
                        //{
                        //    MessageBox.Show("El Producto ya existe");
                        //    repetido = 1;
                        //    return false;
                        //}
                        //else
                        //{
                            CodProducto = pro.CodProducto;
                            txtReferencia.Text = pro.Referencia;
                            txtDescripcion.Text = pro.Descripcion;
                            txtUnidad.Text = pro.UnidadDescrip;
                            CargaUnidades(cmbUnidad);
                            cmbUnidad.SelectedValue = pro.CodUnidadMedida;
                            txtStock.Text = pro.StockDisponible.ToString();
                            txtControlStock.Text = "";
                            txtCantidad.Text = "";
                            txtPrecio.Text = "";
                            txtDscto1.Text = "";
                            txtDscto2.Text = "";
                            txtDscto3.Text = "";
                            txtPrecioNeto.Text = "";
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
                                    break;
                                case 4:
                                    txtControlStock.Enabled = false;
                                    txtCantidad.Enabled = false;
                                    break;
                            }
                            return true;
                        //}
                    }
                    else
                    {
                        return false;}
                    
                }
                else 
                {
                    MessageBox.Show("El producto ya ha sido seleccionado", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CodProducto = 0;
                    txtDescripcion.Text = "";
                    txtUnidad.Text = "";
                    cmbUnidad.SelectedIndex = -1;
                    txtStock.Text = "";
                    txtControlStock.Text = "";
                    txtCantidad.Text = "";
                    txtPrecio.Text = "";
                    txtDscto1.Text = "";
                    txtDscto2.Text = "";
                    txtDscto3.Text = "";
                    txtPrecioNeto.Text = "";
                    return false;
                }                
            }
            else
            {
                MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);                       

                CodProducto = 0;                
                txtDescripcion.Text = "";
                txtUnidad.Text = "";
                cmbUnidad.SelectedIndex = -1;
                txtStock.Text = "";
                txtControlStock.Text = ""; 
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                txtDscto1.Text = "";
                txtDscto2.Text = "";
                txtDscto3.Text = "";
                txtPrecioNeto.Text = "";
                return false;
            }
        }

        private void frmDetalleIngreso_Load(object sender, EventArgs e)
        {
            txtReferencia.Focus();
        }

        private void CargaUnidades(ComboBox combo)
        {
            combo.DataSource = AdmPro.MuestraUnidadesEquivalentesCompra(pro.CodProducto, frmLogin.iCodAlmacen);
            combo.DisplayMember = "descripcion";
            combo.ValueMember = "codUnidadMedida";
            //combo.SelectedValue = pro.CodUnidadMedida;
        }

        private void txtReferencia_Leave(object sender, EventArgs e)
        {
            if (txtReferencia.Text != "" && txtReferencia.ReadOnly == false)
            {
                if (BuscaProducto())
                {
                    txtCantidad.Focus();
                }
                else
                {
                    txtReferencia.Focus();
                }
            }
        }

        private void txtPrecioNeto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPrecioNeto.Text != "")
            {
                if (txtDscto1.Text == "") { txtDscto1.Text = "0.000"; }
                if (txtDscto2.Text == "") { txtDscto2.Text = "0.000"; }
                if (txtDscto3.Text == "") { txtDscto3.Text = "0.000"; }
                if (txtCantidad.Text != "")
                {
                    if (Convert.ToDecimal(txtDscto1.Text) == 100) { /*txtPrecio.Text = String.Format("{0:#,##0.0000}", 0); */}
                    else { txtPrecio.Text = String.Format("{0:#,##0.0000}", Convert.ToDouble(txtPrecioNeto.Text) / (1 - (Convert.ToDouble(txtDscto3.Text) / 100)) / (1 - (Convert.ToDouble(txtDscto2.Text) / 100)) / (1 - (Convert.ToDouble(txtDscto1.Text) / 100)) / Convert.ToDouble(txtCantidad.Text)); }
                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && Procede == 8)
                pro1 = AdmPro.CargaDatosProductoOrden(pro.CodProducto, frmLogin.iCodAlmacen, frmLogin.iCodUser, Convert.ToDecimal(txtCantidad.Text));

       }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
                if (Convert.ToDecimal(txtCantidad.Text) != 0)
                    txtPrecio.Focus();
                else txtCantidad.Focus();
            else txtCantidad.Focus(); 
        }

        
    }
}
