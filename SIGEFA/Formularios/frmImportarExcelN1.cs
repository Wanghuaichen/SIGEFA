using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using System.Threading;

namespace SIGEFA.Formularios
{
    public partial class frmImportarExcelN1 : Form
    {
        public frmImportarExcelN1()
        {
            InitializeComponent();
        }

        //datos de unidadesequivalentes...
        Int32 contador = 0, resume = 0, codproducto = 0;
        Int32 i = 0, Proceso = 0;
        OpenFileDialog dialog = new OpenFileDialog();
        List<DataRow> lista = new List<DataRow>();
        DataTable tabla = new DataTable();
        clsAdmProducto admprod = new clsAdmProducto();
        clsAdmUnidad admunidad = new clsAdmUnidad();
        clsUnidadEquivalente equi = new clsUnidadEquivalente();
        DataTable dt_uniequi = new DataTable();
        String compra_venta_Descripcion = "";
        Int32 compra_venta_Cod;
        //Int32 unidad = 0, moneda = 0, tipoPre = 0;

        //datos de inventario inicial...
        DataGridViewTextBoxColumn colum;
        List<String> ltanombrecolumnas = new List<String>();
        clsNotaIngreso notaingreso = new clsNotaIngreso();
        clsDetalleNotaIngreso dtnotaingreso = new clsDetalleNotaIngreso();
        clsAdmTipoCambio admtipocambio = new clsAdmTipoCambio();
        clsAdmNotaIngreso admnotaingreso = new clsAdmNotaIngreso();
        DataTable dt_notaingreso = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String hoja = "";
                //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx;*.lis"; //le indicamos el tipo de filtro en este caso que busque
                //solo los archivos excel
                dialog.Title = "Seleccione el Archivo";//le damos un titulo a la ventana
                dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
                //si al seleccionar el archivo damos Ok
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //el nombre del archivo sera asignado al textbox
                    textBox1.Text = dialog.FileName;
                    Char delimiter = '.';
                    String[] substrings = dialog.SafeFileName.Split(delimiter);
                    hoja = substrings[0];
                    // hoja = txtHoja.Text; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                    LLenarGrid(textBox1.Text, hoja); //se manda a llamar al metodo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";
            //esta cadena es para archivos excel 2007 y 2010
            //string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
            String cadenaConexionArchivoExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo.Trim() + "';Extended Properties=Excel 8.0;";
            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";
            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    dataGridView1.Columns.Clear();
                    //dataGridView1.Rows.Clear();
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    lista.Clear();
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja.Trim());//llenamos el dataset
                    tabla = dataSet.Tables[0];
                    dataGridView1.DataSource = tabla;
                    if (dataGridView1.Columns.Count == 5)
                    {
                        this.crearColumnas();
                        this.movercolumnas();
                        this.ocultarCeldasExcel2();
                    }
                    if (dataGridView1.Columns.Count == 8)
                    {
                        this.crearColumnas();
                        this.moverColumnasUnidadesEquivalentes();
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        String producto = row.Cells[0].Value.ToString();
                        codproducto = admprod.GetCodProducto_xDescripcion(producto);
                        if (dataGridView1.Columns.Count == 13)
                        {
                            Proceso = 1;
                            this.MostrarExcel(row);
                            dataGridView1.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        }
                        else
                        {
                            Proceso = 2;
                            this.completarCeldasExcel2(row);
                            dataGridView1.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            dataGridView1.Columns["Precio_Unitario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            dataGridView1.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        }
                    }
                    label12.Text = dataGridView1.Rows.Count + " Registros.";
                    conexion.Close();//cerramos la conexion
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error : " + ex.Message.ToString(), "Advertencia");
                }
            }
        }

        public void llenarLista()
        {
            ltanombrecolumnas.Add("codProducto"); ltanombrecolumnas.Add("codNotaIngreso"); ltanombrecolumnas.Add("codAlmacen"); ltanombrecolumnas.Add("serielote");
            ltanombrecolumnas.Add("subtotal"); ltanombrecolumnas.Add("descuento1"); ltanombrecolumnas.Add("descuento2"); ltanombrecolumnas.Add("descuento3");
            ltanombrecolumnas.Add("montodscto"); ltanombrecolumnas.Add("igv"); ltanombrecolumnas.Add("flete"); ltanombrecolumnas.Add("importe");
            ltanombrecolumnas.Add("precioreal"); ltanombrecolumnas.Add("valoreal"); ltanombrecolumnas.Add("fechaingreso"); ltanombrecolumnas.Add("estado");
            ltanombrecolumnas.Add("codUser"); ltanombrecolumnas.Add("fecharegistro"); ltanombrecolumnas.Add("anulado"); ltanombrecolumnas.Add("valorrealsoles");
            ltanombrecolumnas.Add("coddetallerequerimiento"); ltanombrecolumnas.Add("cantidadpendiente"); ltanombrecolumnas.Add("bonificacion");
        }

        private void llenarListaUnidadesEquivalentes()
        {
            //ltanombrecolumnas.Clear();
            ltanombrecolumnas.Add("codProducto"); ltanombrecolumnas.Add("codUser"); ltanombrecolumnas.Add("fecharegistro"); ltanombrecolumnas.Add("codAlmacen");
            ltanombrecolumnas.Add("PrecioFinal");
        }

        public void crearColumnas()
        {
            try
            {
                //creando las columnas necesarias para datos de excel de unidades equivalentes e inventario inicial
                Int32 index = 5;
                ltanombrecolumnas.Clear();
                if (dataGridView1.Columns.Count == 5)
                {
                    this.llenarLista();
                }
                if (dataGridView1.Columns.Count == 8)
                {
                    this.llenarListaUnidadesEquivalentes();
                }
                foreach (String dato in ltanombrecolumnas)
                {
                    colum = new DataGridViewTextBoxColumn();
                    colum.Name = dato;
                    colum.DataPropertyName = dato;
                    colum.HeaderText = dato.ToUpper();
                    colum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colum.DisplayIndex = index;
                    colum.CellTemplate = new DataGridViewTextBoxCell();
                    dataGridView1.Columns.Add(colum);
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        public void movercolumnas()
        {
            //Acomodando las columas del excel de inventario inicial
            dataGridView1.Columns["codProducto"].DisplayIndex = 1;//cambio el lugar la columna
            dataGridView1.Columns["codNotaIngreso"].DisplayIndex = 2;//cambio el lugar la columna
            dataGridView1.Columns["codAlmacen"].DisplayIndex = 3;//cambio el lugar la columna
            dataGridView1.Columns["Codigo_Moneda"].DisplayIndex = 4;//cambio el lugar la columna
            dataGridView1.Columns["serielote"].DisplayIndex = 6;//cambio el lugar la columna
        }

        private void moverColumnasUnidadesEquivalentes()
        {
            //Acomodando las columas del excel de unidades equivalentes
            dataGridView1.Columns["codProducto"].DisplayIndex = 1;//cambio el lugar la columna
            dataGridView1.Columns["codUser"].DisplayIndex = 7;//cambio el lugar la columna
            dataGridView1.Columns["fecharegistro"].DisplayIndex = 8;//cambio el lugar la columna
            dataGridView1.Columns["codAlmacen"].DisplayIndex = 9;//cambio el lugar la columna
            dataGridView1.Columns["PrecioFinal"].DisplayIndex = 12;//cambio el lugar la columna
        }

        private void MostrarExcel(DataGridViewRow row)
        {
            row.Cells["codProducto"].Value = codproducto;
            row.Cells["codUser"].Value = frmLogin.iCodUser;
            row.Cells["fecharegistro"].Value = DateTime.Now;
            row.Cells["codAlmacen"].Value = frmLogin.iCodAlmacen;
            dataGridView1.Columns["codProducto"].Visible = false;//oculto el codigo del producto
            dataGridView1.Columns["fecharegistro"].Visible = false;//oculto la fecha de registro
            dataGridView1.Columns["codUser"].Visible = false;//oculto el codigo del producto
            dataGridView1.Columns["codAlmacen"].Visible = false;//oculto la fecha de registro
            dataGridView1.Columns["PrecioFinal"].Visible = false;//oculto el precio final
        }

        public void completarCeldasExcel2(DataGridViewRow row)
        {
            //colum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            row.Cells["codProducto"].Value = codproducto;
            row.Cells["codNotaIngreso"].Value = 0;
            row.Cells["codAlmacen"].Value = frmLogin.iCodAlmacen;
            row.Cells["serielote"].Value = 0;
            row.Cells["subtotal"].Value = Convert.ToInt32(row.Cells["Cantidad"].Value) * Convert.ToDecimal(row.Cells["Precio_Unitario"].Value);
            row.Cells["descuento1"].Value = 0; row.Cells["descuento2"].Value = 0; row.Cells["descuento3"].Value = 0; row.Cells["montodscto"].Value = 0;
            Decimal preciosinigv = Convert.ToDecimal(row.Cells["Precio_Unitario"].Value) / Convert.ToDecimal(1.18);
            row.Cells["igv"].Value = Math.Round((Convert.ToDecimal(row.Cells["subtotal"].Value)) - (preciosinigv * Convert.ToInt32(row.Cells["Cantidad"].Value)), 3);
            row.Cells["flete"].Value = 0; row.Cells["importe"].Value = row.Cells["subtotal"].Value; row.Cells["precioreal"].Value = row.Cells["Precio_Unitario"].Value;
            row.Cells["valoreal"].Value = Math.Round(Convert.ToDecimal(row.Cells["precioreal"].Value) / Convert.ToDecimal(1.18), 3);
            row.Cells["fechaingreso"].Value = DateTime.Now; row.Cells["estado"].Value = 1; row.Cells["codUser"].Value = frmLogin.iCodUser;
            row.Cells["fecharegistro"].Value = DateTime.Now; row.Cells["anulado"].Value = 0; row.Cells["valorrealsoles"].Value = 0; row.Cells["coddetallerequerimiento"].Value = 0;
            row.Cells["cantidadpendiente"].Value = row.Cells["Cantidad"].Value; row.Cells["bonificacion"].Value = 0;
        }

        public void ocultarCeldasExcel2()
        {
            dataGridView1.Columns["codNotaIngreso"].Visible = false; dataGridView1.Columns["codProducto"].Visible = false; dataGridView1.Columns["codAlmacen"].Visible = false;
            dataGridView1.Columns["Codigo_Moneda"].Visible = false; dataGridView1.Columns["Unidad_Compra"].Visible = false; dataGridView1.Columns["serielote"].Visible = false;
            dataGridView1.Columns["descuento1"].Visible = false; dataGridView1.Columns["descuento2"].Visible = false; dataGridView1.Columns["descuento3"].Visible = false;
            dataGridView1.Columns["montodscto"].Visible = false; dataGridView1.Columns["fecharegistro"].Visible = false; dataGridView1.Columns["fechaingreso"].Visible = false;
            dataGridView1.Columns["codUser"].Visible = false; dataGridView1.Columns["estado"].Visible = false; dataGridView1.Columns["anulado"].Visible = false;
            dataGridView1.Columns["valorrealsoles"].Visible = false; dataGridView1.Columns["coddetallerequerimiento"].Visible = false; dataGridView1.Columns["bonificacion"].Visible = false;
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            if (BtnProcesar.Text == "Procesar")
            {
                if (Proceso == 1)
                {
                    this.GuardarUnidades();
                }
                if (Proceso == 2)
                {
                    this.GuardarInventarioInicial();
                }
            }
            else
            {
                resume = 0;
                backgroundWorker1.RunWorkerAsync();
                progressBar1.Maximum = resume;
                contador = resume;
            }
        }

        private void GuardarUnidades()
        {
            Int32 contadorErrores = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Boolean bandera = false;
                if (admprod.ValidaCodigoProducto(Convert.ToInt32(row.Cells["codProducto"].Value)) != 0 && admprod.ValidaCodigoUE(row.Cells["codUnidadMedida"].Value.ToString()) != 0 &&
                    admprod.ValidaCodigoMoneda(row.Cells["codMoneda"].Value.ToString()) != 0 && admprod.ValidaTipoPrecio(row.Cells["codTipo"].Value.ToString()) != 0)
                {
                    //unidad = admprod.GetCodUnidad(row.Cells[2].Value.ToString());
                    compra_venta_Descripcion = row.Cells["compra_venta"].Value.ToString();
                    if (compra_venta_Descripcion == "COMPRA") { compra_venta_Cod = 0; }
                    else if (compra_venta_Descripcion == "VENTA") { compra_venta_Cod = 1; }
                    else { compra_venta_Cod = 2; }
                    equi.CodProducto = Convert.ToInt32(row.Cells["codProducto"].Value);
                    equi.CodUnidad = admprod.GetCodUnidad(row.Cells["codUnidadMedida"].Value.ToString());
                    if (compra_venta_Cod != 2)
                    {
                        equi.Factor = 0;
                        equi.CodEquivalente = 0;
                    }
                    else
                    {
                        equi.Factor = Convert.ToInt32(row.Cells["factor"].Value);
                        equi.CodEquivalente = admprod.GetCodUnidad(row.Cells["codUndEqui"].Value.ToString());
                    }
                    equi.Tipo = admprod.GetCodTipoPrecio(row.Cells["codTipo"].Value.ToString());
                    equi.Precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                    equi.CodUser = Convert.ToInt32(row.Cells["codUser"].Value);
                    equi.FechaRegistro = Convert.ToDateTime(row.Cells["fecharegistro"].Value);
                    equi.CodAlmacen = Convert.ToInt32(row.Cells["codAlmacen"].Value);
                    equi.CompraVenta = compra_venta_Cod;
                    equi.ICodMoneda = admprod.GetCodMoneda(row.Cells["codMoneda"].Value.ToString());
                    dt_uniequi = admunidad.MuestraUnidadesEquivalentes();
                    foreach (DataRow rows in dt_uniequi.Rows)
                    {
                        Int32 codigoundequi = Convert.ToInt32(rows.ItemArray[0]);
                        if (equi.CodProducto == Convert.ToInt32(rows.ItemArray[1]) && equi.CodUnidad == Convert.ToInt32(rows.ItemArray[2]) && equi.Factor == Convert.ToInt32(rows.ItemArray[3])
                           && equi.CodEquivalente == Convert.ToInt32(rows.ItemArray[4]) && equi.Tipo == Convert.ToInt32(rows.ItemArray[5]) && equi.CodUser == Convert.ToInt32(rows.ItemArray[7])
                           && equi.CodAlmacen == Convert.ToInt32(rows.ItemArray[9]) && equi.CompraVenta == Convert.ToInt32(rows.ItemArray[10]))
                        {
                            if (Convert.ToInt32(rows.ItemArray[10]) != 2 && Convert.ToDecimal(rows.ItemArray[6]) != equi.Precio)
                            {
                                admprod.deleteunidadequivalente(codigoundequi);
                            }
                            else
                            {
                                bandera = true;
                            }
                            row.DefaultCellStyle.BackColor = Color.LightSkyBlue;//celdas que reemplazan los datos iguales
                            break;
                        }
                    }
                    if (bandera == false)
                    {
                        if (admprod.insertunidadequivalente(equi))
                        {
                            contador++;
                            Boolean resultado = admunidad.ActualizaPrecioEnDolares();
                            Int32 resultado2 = admunidad.CantidadProductosDolares();
                            if (resultado == false && resultado2 > 0)
                            {
                                MessageBox.Show("Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar datos", "Gestion de Importacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    contadorErrores++;
                }
            }
            if (contadorErrores > 0)
            {
                MessageBox.Show("Datos erroneos", "Gestion de Importacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Maximum = contador/* + 1*/;
            backgroundWorker1.RunWorkerAsync();
        }

        private void GuardarInventarioInicial()
        {
            Int32 correlativo = 1;//empezamos asi aqui por lo que en la bd ya existe un correlativo del 1 al 3; CAMBIARLO PARA EL ORIGINAL
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                String producto = row.Cells["Producto"].Value.ToString();
                codproducto = admprod.GetCodProducto_xDescripcion(producto);
                if (admprod.ValidaUnidadEquivalente(codproducto) > 0)
                {
                    notaingreso.CodAlmacen = frmLogin.iCodAlmacen;
                    notaingreso.CodTipoTransaccion = 4;
                    notaingreso.CodTipoDocumento = 10;
                    notaingreso.NumDoc = String.Format("{0:00000}", correlativo);
                    notaingreso.CodProveedor = 0;
                    notaingreso.Moneda = admprod.GetCodMoneda(row.Cells["Codigo_Moneda"].Value.ToString());
                    clsTipoCambio tipocambio = new clsTipoCambio();
                    tipocambio = admtipocambio.CargaTipoCambio(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), 2);
                    notaingreso.TipoCambio = tipocambio.Venta;
                    notaingreso.FechaIngreso = DateTime.Now;
                    notaingreso.Comentario = "INVENTARIO INICIAL";
                    notaingreso.MontoBruto = Convert.ToDouble(row.Cells["subtotal"].Value);
                    notaingreso.MontoDscto = Convert.ToDouble(row.Cells["montodscto"].Value);
                    notaingreso.Igv = Convert.ToDouble(row.Cells["igv"].Value);
                    notaingreso.Flete = Convert.ToDouble(row.Cells["flete"].Value);
                    notaingreso.Total = Convert.ToDouble(row.Cells["subtotal"].Value);
                    notaingreso.Abonado = 0;
                    notaingreso.Pendiente = Convert.ToDouble(row.Cells["subtotal"].Value);
                    notaingreso.Estado = 1; notaingreso.Recibido = 0; notaingreso.FormaPago = 0;
                    notaingreso.FechaPago = DateTime.Now; notaingreso.Cancelado = 0; notaingreso.CodUser = frmLogin.iCodUser;
                    notaingreso.FechaRegistro = DateTime.Now; notaingreso.CodSerie = 0;
                    notaingreso.Serie = ""; notaingreso.CodReferencia = 0; notaingreso.CodOrdenCompra = 0; notaingreso.Aceptado = 0;
                    notaingreso.codalmacenemisor = 0; notaingreso.Aplicada = 0; notaingreso.CodAplicada = 0; notaingreso.Motivo = "";
                    correlativo++;
                    Boolean bandera2 = false;
                    dt_notaingreso = admnotaingreso.ListarCodigoNotasSalida();
                    foreach (DataRow x in dt_notaingreso.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["codNotaIngreso"].Value) == Convert.ToInt32(x["codNotaIngreso"]))
                        {
                            MessageBox.Show("Esta nota de salida ya existe!", "Gestion de Importacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bandera2 = true;
                            Proceso = 3;
                        }
                    }
                    if (bandera2 == false)
                    {
                        if (admnotaingreso.insert(notaingreso))
                        {
                            dtnotaingreso.CodProducto = codproducto;
                            dtnotaingreso.CodNotaIngreso = Convert.ToInt32(notaingreso.CodNotaIngreso);
                            dtnotaingreso.CodAlmacen = frmLogin.iCodAlmacen;
                            /*dtnotaingreso.Moneda = admprod.GetCodMoneda(row.Cells["Codigo_Moneda"].Value.ToString());*/
                            dtnotaingreso.UnidadIngresada = admprod.GetCodUnidad(row.Cells["Unidad_Compra"].Value.ToString());
                            dtnotaingreso.SerieLote = row.Cells["serielote"].Value.ToString();
                            dtnotaingreso.Cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);
                            dtnotaingreso.PrecioUnitario = Convert.ToDouble(row.Cells["Precio_Unitario"].Value);
                            dtnotaingreso.Subtotal = Convert.ToDouble(row.Cells["subtotal"].Value);
                            dtnotaingreso.Descuento1 = Convert.ToDouble(row.Cells["descuento1"].Value);
                            dtnotaingreso.Descuento2 = Convert.ToDouble(row.Cells["descuento2"].Value);
                            dtnotaingreso.Descuento3 = Convert.ToDouble(row.Cells["descuento3"].Value);
                            dtnotaingreso.MontoDescuento = Convert.ToDouble(row.Cells["montodscto"].Value);
                            dtnotaingreso.Igv = Convert.ToDouble(row.Cells["igv"].Value);
                            dtnotaingreso.Flete = Convert.ToDouble(row.Cells["flete"].Value);
                            dtnotaingreso.Importe = Convert.ToDouble(row.Cells["importe"].Value);
                            dtnotaingreso.PrecioReal = Convert.ToDouble(row.Cells["precioreal"].Value);
                            dtnotaingreso.ValoReal = Convert.ToDouble(row.Cells["valoreal"].Value);
                            dtnotaingreso.FechaIngreso = Convert.ToDateTime(row.Cells["fechaingreso"].Value);
                            //if (Convert.ToInt32(row.Cells["estado"].Value) == 1) { dtnotaingreso.Estado = true; } else { dtnotaingreso.Estado = false; }
                            dtnotaingreso.CodUser = Convert.ToInt32(row.Cells["codUser"].Value);
                            //dtnotaingreso.FechaRegistro = Convert.ToDateTime(row.Cells["fecharegistro"].Value);
                            dtnotaingreso.ValorrealSoles = Convert.ToDouble(row.Cells["valorrealsoles"].Value);
                            dtnotaingreso.CodDetalleRequerimiento = Convert.ToInt32(row.Cells["coddetallerequerimiento"].Value);
                            if (Convert.ToInt32(row.Cells["bonificacion"].Value) == 0) { dtnotaingreso.Bonificacion = true; } else { dtnotaingreso.Bonificacion = false; }
                            //if (Proceso == 3)
                            //{
                            if (!admnotaingreso.insertdetalle(dtnotaingreso))
                            {
                                MessageBox.Show("Error al agregar el detalle de la nota de salida", "Gestion de Importacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                contador++;
                            }
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar la nota de salida", "Gestion de Importacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //else 
                //{
                //    MessageBox.Show("El Producto: "+producto+" no tiene unidades equivalentes configuradas...!", "Gestion de Importacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            progressBar1.Maximum = contador;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelado : " + i + "", "Importacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Comparados : " + i + " Registros.", "Importacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label2.Text = e.ProgressPercentage.ToString() + " Registros.";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (contador != 0)
            {
                for (int cont = 0; cont < contador; cont++)
                {
                    if (BtnProcesar.Text == "Procesar")
                    {
                        i++;
                    }
                    else
                    {
                        i = resume;
                        i++;
                    }

                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        Thread.Sleep(100);
                        backgroundWorker1.ReportProgress(i);
                    }
                }
            }
            else
            {
                MessageBox.Show("Datos repetidos...! Revisar formulario", "Gestion de Importacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            if (contador > 0)
            {
                BtnProcesar.Text = "Continuar";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
