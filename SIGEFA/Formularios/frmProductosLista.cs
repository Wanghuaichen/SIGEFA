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
    public partial class frmProductosLista : DevComponents.DotNetBar.Office2007Form
    {
        public List<clsProducto> prodvendidos;
        clsAdmProducto AdmProd = new clsAdmProducto();
        public Boolean consultorext;
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmTipoArticulo AdmTip = new clsAdmTipoArticulo();
        public clsProducto pro = new clsProducto();
        public Int32 CodLista = 0, codproveedor=0;
        public Boolean bvalorventa = false;
        public Int32 Proceso = 0; //(1) Ingreso (2)Salida (3)Relacion (4)Guia
        public Int32 Procede = 0; //(1)Nota de Salida (2)Venta       
        public Int32 Moneda = 0;
        public Double tc = 0;
        public Int32 codtrans = 0;
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public List<Int32> seleccion = new List<Int32>();
        public List<clsDetalleNotaIngreso> productoscargados = new List<clsDetalleNotaIngreso>();// relacion de los productos que ya han sido cargado en la nota de ingreso
        public List<clsDetalleFacturaVenta> productosfactura = new List<clsDetalleFacturaVenta>();// relacion de los productos seleccionados para la venta
        public List<clsDetalleCotizacion> productoscotizacion = new List<clsDetalleCotizacion>();// relacion de los productos seleccionados para la cotizacion
        public List<clsDetalleNotaSalida> productosNotaSalida = new List<clsDetalleNotaSalida>(); 
        public Int32 codalmacen = 0;

        public Int32 codigoPro, alma=0;
        public String referenciaPro, descripcionPro;
        public Int32 Tipo = 0;
        public Int32 CodVendedor;

        public frmProductosLista()
        {
            InitializeComponent();
        }

        public int GetCodigoProducto()
        {
            try
            {
                return Convert.ToInt32(dgvProductos.CurrentRow.Cells[codigo.Name].Value); 
            }
            catch (Exception ex) { return 0; this.Close(); }
        }

        private void frmProductosLista_Load(object sender, EventArgs e)
        {
            CargaTipoArticulos();
            //cbTipoArticulo.SelectedIndex = 0;
            CargaLista(Procede);
            label2.Text = "Descripcion";
            label3.Text = "descripcion";
        }

        private void dgvProductos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //try
            //{
            //    if (dgvProductos.Rows.Count >= 1 && e.Row.Selected && e.Row != null)
            //    {
            //        pro.CodProducto = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            //        pro.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
            //        pro.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void CargaLista(Int32 proce)
        {
            if (proce == 6 || proce == 8 || proce == 10)//6) nota de ingreso por compra rapida, 8)orden compra 10)Nota de ingreso por orden compra
            {
                dgvProductos.DataSource = data;
                data.DataSource = AdmPro.RelacionIngresoPorProveedor(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen,codproveedor);
                DepurarLista();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                stockdisponible.Visible = false;
                preciooferta.Visible = false;
                precioventa.Visible = false;
                preciodolares.Visible = false;
                preciosoles.Visible = false;
                Procede = 3;
            }
            else if (proce == 7)// 7)nota de credito
            {
                dgvProductos.DataSource = data;
                data.DataSource = AdmPro.RelacionIngreso(Convert.ToInt32(cbTipoArticulo.SelectedValue),frmLogin.iCodAlmacen);
                DepurarLista();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                stockdisponible.Visible = false;
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (proce == 4 )//Cotizacion
            {
                //cbTipoArticulo.SelectedValue = 1;//selecciona MERCADERIAS
                dgvProductos.DataSource = data;
                data.DataSource = AdmPro.RelacionCotizacion(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen,CodLista);
                DepurarLista3();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                //stockdisponible.Visible = false;
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (proce == 3 /*|| proce == 4*/ || proce == 5 || proce == 9 || proce == 41) //  3)Pedido Venta, 4)Cotizacion,5)Guia
            {
                //cbTipoArticulo.SelectedValue = 1;//selecciona MERCADERIAS
                dgvProductos.DataSource = data;
                if (codalmacen != 0)
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), codalmacen, CodLista);
                }
                //data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen, CodLista);
                else
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen, CodLista);
                }
                DepurarLista2();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (proce == 1)// 1)Nota de salida
            {
                //cbTipoArticulo.SelectedValue = 1;//selecciona MERCADERIAS
                dgvProductos.DataSource = data;
                if (codalmacen != 0)
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), codalmacen, CodLista);
                }
                //data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen, CodLista);
                else
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen, CodLista);
                }
                DepurarLista4();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (proce == 42)// Productos Vendedores
            {
                cbTipoArticulo.SelectedValue = 1;//selecciona MERCADERIAS
                dgvProductos.DataSource = data;
                if (codalmacen != 0)
                {
                    data.DataSource = AdmPro.RelacionVendedor(Convert.ToInt32(cbTipoArticulo.SelectedValue), codalmacen, 0, CodVendedor);
                }
                else
                {
                    data.DataSource = AdmPro.RelacionVendedor(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen, 0, CodVendedor);
                }
                if (data.Count == 0)
                {
                    MessageBox.Show("El vendedor no tiene asignada una entrega");
                    this.Close();
                }
                prodvendidos = AdmProd.ListaProdConsultor(CodVendedor);
                if (prodvendidos.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        foreach (clsProducto prod in prodvendidos)
                        {
                            if (prod.CodProducto == Convert.ToInt32(row.Cells[codigo.Name].Value))
                            {
                                row.Cells[stockdisponible.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[stockdisponible.Name].Value) - Convert.ToDouble(prod.StockActual));
                                break;
                            }
                        }
                    }
                }
                DepurarLista2();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (proce == 2)//2) Venta
            {
                //cbTipoArticulo.SelectedValue = 1;//selecciona MERCADERIAS
                dgvProductos.DataSource = data;
                if (codalmacen != 0)
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), codalmacen, CodLista);
                }
                else
                {
                    data.DataSource = AdmPro.RelacionSalida(Convert.ToInt32(cbTipoArticulo.SelectedValue), alma, CodLista);
                }

                if (consultorext == true)
                {
                    if (data.Count == 0)
                    {
                        MessageBox.Show("El vendedor no tiene asignada una entrega");
                        this.Close();
                    }
                    prodvendidos = AdmProd.ListaProdConsultor(CodVendedor);
                    if (prodvendidos.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvProductos.Rows)
                        {
                            foreach (clsProducto prod in prodvendidos)
                            {
                                if (prod.CodProducto == Convert.ToInt32(row.Cells[codigo.Name].Value))
                                {
                                    row.Cells[stockdisponible.Name].Value = String.Format("{0:#,##0.00}", Convert.ToDouble(row.Cells[stockdisponible.Name].Value) - Convert.ToDouble(prod.StockActual));
                                    break;
                                }
                            }
                        }
                    }
                }
                DepurarLista2();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                preciooferta.Visible = false;
                precioventa.Visible = false;
            }
            else if (Procede == 11 || Procede == 12 || Procede == 13 || Procede == 14 || Procede == 20)// 11)Requerimiento 12) OrdenCompra
            {
                dgvProductos.DataSource = data;
                data.DataSource = AdmPro.RelacionIngreso(Convert.ToInt32(cbTipoArticulo.SelectedValue), frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                precioventa.Visible = false;
                preciooferta.Visible = false;
                stockdisponible.Visible = false;
                preciodolares.Visible = false;
                preciosoles.Visible = false;
            }
            else if (Procede == 15)// 15)frmParamVentxArticulo
            {
                dgvProductos.DataSource = data;
                data.DataSource = AdmPro.RelacionProductos(frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                precioventa.Visible = false;
                preciooferta.Visible = false;
                stockdisponible.Visible = false;
                preciodolares.Visible = false;
                preciosoles.Visible = false;
            }
        }

        private void DepurarLista()
        {       
            foreach (clsDetalleNotaIngreso deta in productoscargados)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[codigo.Name].Value) == deta.CodProducto)
                    {
                        dgvProductos.Rows.Remove(row);
                    }
                }
            }
        }

        private void DepurarLista2()
        {
            foreach (clsDetalleFacturaVenta deta in productosfactura)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[codigo.Name].Value) == deta.CodProducto)
                    {
                        dgvProductos.Rows.Remove(row);
                    }
                }
            }
        }

        private void DepurarLista3()
        {
            foreach (clsDetalleCotizacion deta in productoscotizacion)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[codigo.Name].Value) == deta.CodProducto)
                    {
                        dgvProductos.Rows.Remove(row);
                    }
                }
            }
        }

        private void DepurarLista4()
        {
            foreach (clsDetalleNotaSalida deta in productosNotaSalida)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (Convert.ToInt32(row.Cells[codigo.Name].Value) == deta.CodProducto)
                    {
                        dgvProductos.Rows.Remove(row);
                    }
                }
            }
        }

        private void CargaTipoArticulos()
        {
            cbTipoArticulo.DataSource = AdmTip.MuestraTipoArticulos();
            cbTipoArticulo.DisplayMember = "descripcion";
            cbTipoArticulo.ValueMember = "codTipoArticulo";
            cbTipoArticulo.SelectedValue = 1;
        }

        private void frmProductosLista_Shown(object sender, EventArgs e)
        {
            //CargaLista(Procede);
            dgvProductos.ClearSelection();
            txtFiltro.Focus();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                if(ee.KeyChar != (char)Keys.Down)
                {
                    dgvProductos.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvProductos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvProductos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            recorrelista();
            //this.Close();
            if (Procede == 6 || Procede == 7 || Procede == 10)
            {
                //foreach (int cod in seleccion)
                //{
                //    if (Application.OpenForms["frmDetalleIngreso"] != null)
                //    {
                //        Application.OpenForms["frmDetalleIngreso"].Close();
                //    }
                //    frmDetalleIngreso form = new frmDetalleIngreso();
                //    form.Procede = Procede;
                //    form.Seleccion = 2;
                //    form.Proceso = Proceso;
                    
                //    form.bvalorventa = bvalorventa;
                //    form.txtCodigo.Text = cod.ToString();
                //    if (form.repetido == 1) { form.Close(); this.Close(); }
                //    else
                //    {
                //        form.txtCantidad.Focus();
                //        form.ShowDialog();
                //    }
                //}
                DialogResult = DialogResult.OK;
            }
            else if (Procede == 1 || Procede == 2 || Procede == 3 || Procede == 4 || Procede == 41 || Procede == 42)
            {
                //foreach (int cod in seleccion)
                //{
                //    if (Application.OpenForms["frmDetalleSalida"] != null)
                //    {
                //        Application.OpenForms["frmDetalleSalida"].Close();
                //    }
                //    frmDetalleSalida form = new frmDetalleSalida();
                //    form.Seleccion = 2;
                //    form.Codlista = CodLista;
                //    form.Procede = Procede;
                //    form.Moneda = Moneda;
                //    form.tc = tc;
                //    form.Proceso = Proceso;
                //    if (Procede == 42)
                //        form.stock42 = Double.Parse(dgvProductos.CurrentRow.Cells[stockdisponible.Name].Value.ToString());
                //    form.alma = alma;
                //    form.txtCodigo.Text = cod.ToString();
                //    form.codTran = codtrans;
                //    form.ShowDialog();
                //}
                DialogResult = DialogResult.OK;
            }
            else if (Procede == 5 || Procede == 11 || Procede == 12 || Procede == 9 /*|| Procede==10*/)
            {
                //foreach (int cod in seleccion)
                //{
                //    if (Application.OpenForms["frmDetalleGuia"] != null)
                //    {
                //        Application.OpenForms["frmDetalleGuia"].Close();
                //    }
                //    frmDetalleGuia form = new frmDetalleGuia();
                //    form.Proceso = Proceso;
                //    form.Seleccion = 2;
                //    form.Procede = Procede;

                    /*if (Procede == 10) form.chBonificacion.Visible = true;
                    form.txtCodigo.Text = cod.ToString();*/

                //    if (form.repetido == 1) { form.Close(); this.Close(); }
                //    else
                //    {
                //        form.txtCantidad.Focus();
                //        form.ShowDialog();
                //    }
                    
                //}

                DialogResult = DialogResult.OK;
            }
            else if (Procede == 13)
            {
                codigoPro = pro.CodProducto;
                referenciaPro = pro.Referencia;
                descripcionPro = pro.Descripcion;

            }
            else if (Procede == 14)
            {
                codigoPro = pro.CodProducto;
                referenciaPro = pro.Referencia;
                descripcionPro = pro.Descripcion;
            }

            //else if (Procede == 8)
            //{
            //    GetCodigoProducto();
            //}
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {             
            recorrelista();
            if (Procede == 6 || Procede == 7 || Procede == 8)
            {
                foreach (int cod in seleccion)
                {
                    if (Application.OpenForms["frmDetalleIngreso"] != null)
                    {
                        Application.OpenForms["frmDetalleIngreso"].Close();
                    }
                    frmDetalleIngreso form = new frmDetalleIngreso();
                    form.Proceso = Proceso;
                    form.Seleccion = 2;
                    form.Procede = Procede;
                    form.bvalorventa = bvalorventa;
                    form.txtCodigo.Text = cod.ToString();
                    if (form.repetido == 1) { form.Close(); this.Close(); }
                    else
                    {
                        form.txtCantidad.Focus();
                        form.ShowDialog();
                    }                    
                }
            }
            
            else if (Procede == 1 || Procede == 2 || Procede == 3 || Procede == 4)
            {
                foreach (int cod in seleccion)
                {
                    if (Application.OpenForms["frmDetalleSalida"] != null)
                    {
                        Application.OpenForms["frmDetalleSalida"].Close();
                    }
                    frmDetalleSalida form = new frmDetalleSalida();
                    form.Seleccion = 2;
                    form.Proceso = Proceso;
                    form.Codlista = CodLista;
                    form.Procede = Procede;
                    form.Moneda = Moneda;
                    form.tc = tc;
                    form.alma = alma;
                    form.txtCodigo.Text = cod.ToString();
                    form.txtPrecio.ReadOnly = true;
                    form.codTran = codtrans;
                    form.ShowDialog();
                }
            }
            else if (Procede == 5 || Procede == 11 || Procede == 12 || Procede == 9 || Procede == 10)
            {
                foreach (int cod in seleccion)
                {
                    if (Application.OpenForms["frmDetalleGuia"] != null)
                    {
                        Application.OpenForms["frmDetalleGuia"].Close();
                    }
                    frmDetalleGuia form = new frmDetalleGuia();
                    form.txtCantidad.Focus();
                    form.Seleccion = 2;
                    form.Proceso = Proceso;
                    form.Procede = Procede;
                    if (Procede == 10) form.chBonificacion.Visible = true;
                    form.txtCodigo.Text = cod.ToString();
                    if (form.repetido == 1) { form.Close(); this.Close(); }
                    else
                    {
                        form.txtCantidad.Focus();
                        form.ShowDialog();
                    }
                    
                }
            }
            else if (Procede == 13)
            {
                codigoPro = pro.CodProducto;
                referenciaPro = pro.Referencia;
                descripcionPro = pro.Descripcion;

            }
            else if (Procede == 14)
            {
                codigoPro = pro.CodProducto;
                referenciaPro = pro.Referencia;
                descripcionPro = pro.Descripcion;
            }
            this.Close();
            
        }

        private void recorrelista()
        {
            seleccion.Clear();
            if (dgvProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                {
                    seleccion.Add(Convert.ToInt32(row.Cells[codigo.Name].Value));
                }
            }
        }

        private void cbTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLista(Procede);
        }

        private void frmProductosLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count >= 1 && e.RowIndex != -1 && dgvProductos.CurrentRow.Index == e.RowIndex)
                {
                    DataGridViewRow Row = dgvProductos.Rows[e.RowIndex];
                    pro.CodProducto = Convert.ToInt32(Row.Cells[codigo.Name].Value);
                    pro.Referencia = Row.Cells[referencia.Name].Value.ToString();
                    pro.Descripcion = Row.Cells[descripcion.Name].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvProductos.Focus();
            } 
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                recorrelista();
                if (Procede == 6 || Procede == 7 || Procede == 8)
                {
                    foreach (int cod in seleccion)
                    {
                        if (Application.OpenForms["frmDetalleIngreso"] != null)
                        {
                            Application.OpenForms["frmDetalleIngreso"].Close();
                        }
                        frmDetalleIngreso form = new frmDetalleIngreso();
                        form.Proceso = Proceso;
                        form.Seleccion = 2;
                        form.Procede = Procede;
                        form.bvalorventa = bvalorventa;
                        form.txtCodigo.Text = cod.ToString();
                        if (form.repetido == 1) { form.Close(); this.Close(); }
                        else
                        {
                            form.txtCantidad.Focus();
                            form.ShowDialog();
                        }
                    }
                }

                else if (Procede == 1 || Procede == 2 || Procede == 3 || Procede == 4)
                {
                    foreach (int cod in seleccion)
                    {
                        if (Application.OpenForms["frmDetalleSalida"] != null)
                        {
                            Application.OpenForms["frmDetalleSalida"].Close();
                        }
                        frmDetalleSalida form = new frmDetalleSalida();
                        form.Seleccion = 2;
                        form.Proceso = Proceso;
                        form.Codlista = CodLista;
                        form.Procede = Procede;
                        form.Moneda = Moneda;
                        form.tc = tc;
                        form.alma = alma;
                        form.txtCodigo.Text = cod.ToString();
                        form.txtPrecio.ReadOnly = true;
                        form.codTran = codtrans;
                        form.ShowDialog();
                    }
                }
                else if (Procede == 5 || Procede == 11 || Procede == 12 || Procede == 9 || Procede == 10)
                {
                    foreach (int cod in seleccion)
                    {
                        if (Application.OpenForms["frmDetalleGuia"] != null)
                        {
                            Application.OpenForms["frmDetalleGuia"].Close();
                        }
                        frmDetalleGuia form = new frmDetalleGuia();
                        form.txtCantidad.Focus();
                        form.Seleccion = 2;
                        form.Proceso = Proceso;
                        form.Procede = Procede;
                        if (Procede == 10) form.chBonificacion.Visible = true;
                        form.txtCodigo.Text = cod.ToString();
                        if (form.repetido == 1) { form.Close(); this.Close(); }
                        else
                        {
                            form.txtCantidad.Focus();
                            form.ShowDialog();
                        }

                    }
                }
                else if (Procede == 13)
                {
                    codigoPro = pro.CodProducto;
                    referenciaPro = pro.Referencia;
                    descripcionPro = pro.Descripcion;

                }
                else if (Procede == 14)
                {
                    codigoPro = pro.CodProducto;
                    referenciaPro = pro.Referencia;
                    descripcionPro = pro.Descripcion;
                }
                else if (Procede == 15)
                {
                    int f = dgvProductos.CurrentRow.Index;
                    pro.CodProducto = Convert.ToInt32(dgvProductos.Rows[f].Cells[codigo.Name].Value);                        
                }
                this.Close();
            }
        }
    }
}
