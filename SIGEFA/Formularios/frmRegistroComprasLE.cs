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
    public partial class frmRegistroComprasLE : DevComponents.DotNetBar.Office2007Form
    {
        clsValidar val = new clsValidar();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsAdmFactura admCompras = new clsAdmFactura();
        List<String> listalibros = new List<String>();
        //List<String> ltaColumnasLVS = new List<String>();
        clsAdmLibrosElectronicos admLE = new clsAdmLibrosElectronicos();
        DataGridViewTextBoxColumn colum;
        DataTable dt_ventas = new DataTable();
        DataTable dt_compras = new DataTable();
        public Int32 tipoLibroRecibido = 0;
        public Int32 tipoRegistroRecibido = 0;
        public String Periodo = "";
        public Int32 MesPeriodo = 0;
        String AnalizarRuc = ""; Int32 codTipoDoc = 0;
        Decimal BI = 0, DBI = 0;
        public Int32 contenidoLibro;

        public frmRegistroComprasLE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtnombrelibro.Text != "" && txtnombrelibro.Text != ".")
            {
                //se crea un objeto de tipo savefiledialog que nos servira para guardar el archivo
                SaveFileDialog Save = new SaveFileDialog();
                System.IO.StreamWriter myStreamWriter = null;
                //al igual que para abrir el tipo de documentos aqui se especifica en que extenciones se puede guardar el archivo
                Save.FileName = txtnombrelibro.Text;
                Save.Filter = "Text (*.txt)|*.txt|HTML(*.html*)|*.html|All files(*.*)|*.*";
                Save.CheckPathExists = true;
                Save.Title = "Guardar como";
                Save.ShowDialog(this);
                try
                {
                    //este codigo se utiliza para guardar el archivo de nuestro editor
                    myStreamWriter = System.IO.File.AppendText(Save.FileName);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable("ListaGuias");
                    // Columnas
                    foreach (DataGridViewColumn column in dgvVentas.Columns)
                    {
                        DataColumn dc = new DataColumn(column.Name.ToString());
                        dt.Columns.Add(dc);
                    }
                    // Datos
                    for (int i = 0; i < dgvVentas.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvVentas.Rows[i];
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < dgvVentas.Columns.Count; j++)
                        {
                            dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString().Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                    String cad = "";
                    Type t = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            //t = ds.Tables[0].Rows[i][j].GetType();
                            if (ds.Tables[0].Columns[j].ColumnName == "Fecha Comp." || ds.Tables[0].Columns[j].ColumnName == "Fecha Venc/Pago")
                            {
                                if (ds.Tables[0].Rows[i][j].ToString() != "")
                                {
                                    ds.Tables[0].Rows[i][j] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[i][j]));
                                }
                            }
                            if (j == (ds.Tables[0].Columns.Count - 1))
                            {
                                cad = cad + ((ds.Tables[0].Rows[i][j]).ToString() + "\t");
                                myStreamWriter.WriteLine(cad);
                                cad = "";
                            }
                            else
                            { 
                                cad = cad + ((ds.Tables[0].Rows[i][j]).ToString() + "|");
                            }
                        }
                    }
                    myStreamWriter.Flush();
                }
                catch (Exception) { }
            }
        }

        private void txtMontoLiquidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void frmRegistroComprasLE_Load(object sender, EventArgs e)
        {
            if (tipoLibroRecibido == 13)//LIBRO DE VENTAS E INGRESOS
            {
                if (tipoRegistroRecibido == 47)  //LIBRO -> REGISTRO DE VENTAS E INGRESOS
                {
                    this.LLenarLista_ColumnasLVentas();
                    this.crearColumnas(listalibros);
                    if (contenidoLibro != 0)
                    {
                        this.CargarGrillaVentas();
                    }
                }
                if (tipoRegistroRecibido == 48) //LIBRO -> REGISTRO DE VENTAS E INGRESOS SIMPLIFICADO
                {
                    this.LLenarLista_ColumnasVentasSimplificado();
                    this.crearColumnas(listalibros);
                    if (contenidoLibro != 0)
                    {
                        this.CargarGrillaVentasSimplificado();
                    }
                }
            }
            else if (tipoLibroRecibido == 8)//LIBRO DE COMPRAS
            {
                if (tipoRegistroRecibido == 36)  //LIBRO -> REGISTRO DE COMPRAS
                {
                    this.LLenarLista_ColumnasLCompras();
                    this.crearColumnas(listalibros);
                    if (contenidoLibro != 0)
                    {
                        this.cargarGrillaCompras("FacturasComprasLE");
                    }
                }
                else if (tipoRegistroRecibido == 37) //LIBRO -> REGISTRO DE COMPRAS - INFORMACIÓN DE OPERACIONES CON SUJETOS NO DOMICILIADOS
                {
                    this.LLenarLista_ColumnasCompras_NoDomiciliados();
                    this.crearColumnas(listalibros);
                    if (contenidoLibro != 0)
                    {
                        this.cargarGrillaComprasNoDomiciliadas("FacturasComprasOPnoDomicLE");
                    }
                }
                else if (tipoRegistroRecibido == 38) //LIBRO -> REGISTRO DE COMPRAS SIMPLIFICADO
                {
                    this.LLenarLista_ColumnasComprasSimplificado();
                    this.crearColumnas(listalibros);
                    if (contenidoLibro != 0)
                    {
                        this.cargarGrillaComprasSimplificadas("FacturasComprasSimplificadoLE");
                    }
                }
            }
        }

        #region LIBROS DE VENTAS

        public void LLenarLista_ColumnasLVentas() // REGISTRO DE VENTAS E INGRESOS
        {
            listalibros.Clear();
            listalibros.Add("Periodo"); 
            listalibros.Add("CUO"); 
            listalibros.Add("Estado CUO"); 
            listalibros.Add("Fecha Comp."); 
            listalibros.Add("Fecha Venc/Pago");
            listalibros.Add("Tipo Doc. Pago"); 
            listalibros.Add("Nro. Serie"); 
            listalibros.Add("Nro. Comprob."); 
            listalibros.Add("Consolidacion");
            listalibros.Add("Tipo Doc. Iden."); 
            listalibros.Add("Documento Iden."); 
            listalibros.Add("Razon Social"); 
            listalibros.Add("Valor Export.");
            listalibros.Add("Base Imponible"); 
            listalibros.Add("Dscto Base Impo."); 
            listalibros.Add("IGV"); 
            listalibros.Add("Dscto IGV"); 
            listalibros.Add("OP. Exhon.");
            listalibros.Add("OP. Inafecta"); 
            listalibros.Add("ISC"); 
            listalibros.Add("IGV Arroz Pilado"); 
            listalibros.Add("Imp. Ventas Arroz Pilado");
            listalibros.Add("Otros Tributos"); 
            listalibros.Add("Importe Total Ope."); 
            listalibros.Add("Moneda"); 
            listalibros.Add("Tipo Cambio");
            listalibros.Add("Fecha Emision Comprob."); 
            listalibros.Add("Tipo Comprob.");
            listalibros.Add("Nro Serie Comprob."); 
            listalibros.Add("Nro Comprob. Pago");
            listalibros.Add("Proyecto");
            listalibros.Add("Error Tipo 1"); 
            listalibros.Add("Medios de Pago"); 
            listalibros.Add("Estado");
            listalibros.Add("CampoLibre");//35
        }

        public void LLenarLista_ColumnasVentasSimplificado() // REGISTRO DE VENTAS E INGRESOS SIMPLIFICADO
        {
            listalibros.Clear();
            listalibros.Add("Periodo");
            listalibros.Add("CUO");
            listalibros.Add("Estado CUO");
            listalibros.Add("Fecha Comp.");
            listalibros.Add("Fecha Venc/Pago");
            listalibros.Add("Tipo Doc. Pago");
            listalibros.Add("Nro. Serie");
            listalibros.Add("Nro. Comprob.");
            listalibros.Add("Consolidacion");
            listalibros.Add("Tipo Doc. Iden.");
            listalibros.Add("Documento Iden.");
            listalibros.Add("Razon Social");
            listalibros.Add("Base Imponible");
            listalibros.Add("IGV");
            listalibros.Add("Otros Tributos");
            listalibros.Add("Importe Total Ope.");
            listalibros.Add("Moneda");
            listalibros.Add("Tipo Cambio");
            listalibros.Add("Fecha Emision Comprob.");
            listalibros.Add("Tipo Comprob.");
            listalibros.Add("Nro Serie Comprob.");
            listalibros.Add("Nro Comprob. Pago");
            listalibros.Add("Error Tipo 1");
            listalibros.Add("Medios de Pago");
            listalibros.Add("Estado");
            listalibros.Add("CampoLibre");//26
        }

        #endregion

        #region LIBROS DE COMPRAS

        public void LLenarLista_ColumnasLCompras() // REGISTRO DE COMPRAS
        {
            listalibros.Clear();
            listalibros.Add("Periodo");
            listalibros.Add("CUO");
            listalibros.Add("Estado CUO");
            listalibros.Add("Fecha Comp.");
            listalibros.Add("Fecha Venc/Pago");
            listalibros.Add("Tipo Doc. Pago");
            listalibros.Add("Nro. Serie");
            listalibros.Add("Año Emision");
            listalibros.Add("Nro. Comprob.");
            listalibros.Add("Consolidacion");
            listalibros.Add("Tipo Doc. Proveedor");
            listalibros.Add("Documento Iden.");
            listalibros.Add("Razon Social");
            listalibros.Add("Base Imponible 1");
            listalibros.Add("IGV 1");
            listalibros.Add("Base Imponible 2");
            listalibros.Add("IGV 2");
            listalibros.Add("Base Imponible 3");
            listalibros.Add("IGV 3");
            listalibros.Add("Valor Adquisicion");//19
            listalibros.Add("Monto Impuesto Selectivo");
            listalibros.Add("Otros Conceptos");
            listalibros.Add("Importe Total Ope.");
            listalibros.Add("Moneda");
            listalibros.Add("Tipo Cambio");
            listalibros.Add("Fecha Emision Comprob.");
            listalibros.Add("Tipo Comprob. Modifi.");
            listalibros.Add("Nro Serie Comprob. Modifi.");
            listalibros.Add("Codigo Aduana"); 
            listalibros.Add("Nro Comprob. Pago Modifi.");
            listalibros.Add("Fecha Constan. Detrac.");
            listalibros.Add("Numero Constan. Detrac.");
            listalibros.Add("Marca Comprob. Pago");
            listalibros.Add("Clasificacion Serv.");
            listalibros.Add("Proyecto");
            listalibros.Add("Error Tipo 1");
            listalibros.Add("Error Tipo 2");
            listalibros.Add("Error Tipo 3");
            listalibros.Add("Error Tipo 4");
            listalibros.Add("Indicador Compr. Pago");
            listalibros.Add("Estado");//40
            listalibros.Add("CampoLibre");//41
        }

        public void LLenarLista_ColumnasCompras_NoDomiciliados() // REGISTRO DE COMPRAS - INFORMACIÓN DE OPERACIONES CON SUJETOS NO DOMICILIADOS
        {
            listalibros.Clear();
            listalibros.Add("Periodo");
            listalibros.Add("CUO");
            listalibros.Add("Estado CUO");
            listalibros.Add("Fecha Comp.");
            listalibros.Add("Tipo Doc. Pago");
            listalibros.Add("Nro. Serie");
            listalibros.Add("Nro. Comprob.");
            listalibros.Add("Valor Adquisicion");
            listalibros.Add("Otros Conceptos");
            listalibros.Add("Importe Total Ope.");
            listalibros.Add("Tipo Comprob. Modifi.");
            listalibros.Add("Nro Serie Comprob. Modifi.");
            listalibros.Add("Año Emision del Comprob.");
            listalibros.Add("Nro Comprob. Pago Modifi.");
            listalibros.Add("Monto Retencion");
            listalibros.Add("Moneda");
            listalibros.Add("Tipo Cambio");
            listalibros.Add("Pais Residencia");
            listalibros.Add("Razon Social");
            listalibros.Add("Domicilio_Extranjero");
            listalibros.Add("Identificacion");//20
            listalibros.Add("Identificacion_Bancaria");
            listalibros.Add("Beneficiario");
            listalibros.Add("Pais_Beneficiario");
            listalibros.Add("Vinculo_contrib_Benef");
            listalibros.Add("Renta_Bruta");
            listalibros.Add("Deduccion");
            listalibros.Add("Renta_neta");
            listalibros.Add("Tasa_Reten");
            listalibros.Add("Impuesto_Reten");
            listalibros.Add("Convenios");
            listalibros.Add("Exoneracion");
            listalibros.Add("Tipo_Renta");
            listalibros.Add("Modalidad_Serv");
            listalibros.Add("AplicaImpRenta");
            listalibros.Add("Estado");//35
            listalibros.Add("CampoLibre");//36
        }

        public void LLenarLista_ColumnasComprasSimplificado() // REGISTRO DE COMPRAS SIMPLIFICADO
        {
            listalibros.Add("Periodo");
            listalibros.Add("CUO");
            listalibros.Add("Estado CUO");
            listalibros.Add("Fecha Comp.");
            listalibros.Add("Fecha Venc/Pago");
            listalibros.Add("Tipo Doc. Pago");
            listalibros.Add("Nro. Serie");
            listalibros.Add("Nro. Comprob.");
            listalibros.Add("Operaciones_Diarias");
            listalibros.Add("Tipo Doc. Proveedor");
            listalibros.Add("Documento Iden.");
            listalibros.Add("Razon Social");
            listalibros.Add("Base Imponible 1");
            listalibros.Add("IGV 1");
            listalibros.Add("Otros Conceptos");
            listalibros.Add("Importe Total Ope.");
            listalibros.Add("Moneda");
            listalibros.Add("Tipo Cambio");
            listalibros.Add("Fecha Emision Comprob.");
            listalibros.Add("Tipo Comprob. Modifi.");
            listalibros.Add("Nro Serie Comprob. Modifi.");
            listalibros.Add("Nro Comprob. Pago Modifi.");
            listalibros.Add("Fecha Constan. Detrac.");
            listalibros.Add("Numero Constan. Detrac.");
            listalibros.Add("Marca Comprob. Pago");
            listalibros.Add("Clasificacion Serv.");
            listalibros.Add("Error Tipo 1");
            listalibros.Add("Error Tipo 2");
            listalibros.Add("Error Tipo 3");
            listalibros.Add("Indicador Compr. Pago");
            listalibros.Add("Estado");//31
            listalibros.Add("CampoLibre");//32
        }

        #endregion

        private void crearColumnas(List<String> ltaV)
        {
            List<String> ltaTrabajada = new List<String>();
            ltaTrabajada = ltaV;
            Int32 index = 0;
            dgvVentas.Columns.Clear();
            foreach (String dato in ltaTrabajada)
            {
                colum = new DataGridViewTextBoxColumn();
                colum.Name = dato;
                colum.DataPropertyName = dato;
                colum.HeaderText = dato.ToUpper();
                colum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                colum.DisplayIndex = index;
                colum.CellTemplate = new DataGridViewTextBoxCell();
                dgvVentas.Columns.Add(colum);
                if (colum.Name == "Fecha Comp." || colum.Name == "Fecha Venc/Pago")
                {
                    colum.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                index++;
            }
        }

        #region GRILLA DE VENTAS

        private void CargarGrillaVentas()
        {
            dt_ventas.Clear();
            dt_ventas = admLE.GetVentas_Mes_LEV(MesPeriodo);
            dgvVentas.Rows.Clear();
            foreach (DataRow row in dt_ventas.Rows)
            {
                AnalizarRuc = row[6].ToString();
                BI = Convert.ToDecimal(row[8]);
                DBI = Convert.ToDecimal(row[9]);
                dgvVentas.Rows.Add(Periodo, row[0], "M - " + row[0], Convert.ToDateTime(row[1]).Date, Convert.ToDateTime(row[2]).Date, row[3], row[4], row[5],
                                   "", this.AnalizarTipoDocumento(AnalizarRuc), row[6], row[7], "", row[8], row[9], row[10], this.AnalizarDCTO_IGV(BI, DBI), "0",
                                   "0", "0", "0", "0", "0", row[11], row[12], row[13], "", "", "", "", "", "", "", "1",row[14]);
            }
        }

        private void CargarGrillaVentasSimplificado() 
        {
            dt_ventas.Clear();
            dt_ventas = admLE.GetVentas_Mes_LEV(MesPeriodo);
            dgvVentas.Rows.Clear();
            foreach (DataRow row in dt_ventas.Rows)
            {
                AnalizarRuc = row[6].ToString();
                BI = Convert.ToDecimal(row[8]);
                DBI = Convert.ToDecimal(row[9]);
                dgvVentas.Rows.Add(Periodo, row[0], "M - " + row[0], Convert.ToDateTime(row[1]).Date, Convert.ToDateTime(row[2]).Date, row[3], row[4], row[5],
                                   "", this.AnalizarTipoDocumento(AnalizarRuc), row[6], row[7], row[8], row[10], "0", row[11], row[12], row[13], "", "", "", "",
                                   "", "", "1", row[14]);
            }
        }

        #endregion;

        #region GRILLA DE COMPRAS

        private void cargarGrillaCompras(String cadena) 
        {
            dt_compras.Clear();
            dt_compras = admLE.FacturasComprasLE(MesPeriodo, frmLogin.iCodAlmacen, cadena);
            dgvVentas.Rows.Clear();
            foreach (DataRow row in dt_compras.Rows)
            {
                dgvVentas.Rows.Add(Periodo, row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14],
                                   row[15],row[16], row[17], row[18], row[19], row[20], row[21], row[22], row[23], row[24], row[25], row[26], row[27],
                                   row[28], row[29], row[30], row[31], row[32], row[33], row[34], row[35], row[36], row[37], row[38], row[39], row[40], row[41]);
            }
            dgvVentas.Columns["CampoLibre"].Visible = false; 
        }

        private void cargarGrillaComprasNoDomiciliadas(String cadena)
        {
            dt_compras.Clear();
            dt_compras = admLE.FacturasComprasLE(MesPeriodo, frmLogin.iCodAlmacen, cadena);
            dgvVentas.Rows.Clear();
            foreach (DataRow row in dt_compras.Rows)
            {
                dgvVentas.Rows.Add(Periodo, row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14],
                                   row[15], row[16], row[17], row[18], row[19], row[20], row[21], row[22], row[23], row[24], row[25], row[26], row[27],
                                   row[28], row[29], row[30], row[31], row[32], row[33], row[34], row[35], row[36]);
            }
            dgvVentas.Columns["CampoLibre"].Visible = false; 
        }

        private void cargarGrillaComprasSimplificadas(String cadena)
        {
            dt_compras.Clear();
            dt_compras = admLE.FacturasComprasLE(MesPeriodo, frmLogin.iCodAlmacen, cadena);
            dgvVentas.Rows.Clear();
            foreach (DataRow row in dt_compras.Rows)
            {
                dgvVentas.Rows.Add(Periodo, row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14],
                                   row[15], row[16], row[17], row[18], row[19], row[20], row[21], row[22], row[23], row[24], row[25], row[26], row[27],
                                   row[28], row[29], row[30], row[31], row[32]);
            }
            dgvVentas.Columns["CampoLibre"].Visible = false; 
        }

        #endregion;

        private Int32 AnalizarTipoDocumento(String nrodocu)
        {
            if (nrodocu.Trim().Length == 8)
            {
                codTipoDoc = 1;
            }
            else if (nrodocu.Trim().Length == 11)
            {
                codTipoDoc = 6;
            }
            return codTipoDoc;
        }

        private Decimal AnalizarDCTO_IGV(Decimal BaseImponible, Decimal DesctoBI)
        {
            Decimal DctoIGV = 0, MontoDscto = 0;
            MontoDscto = BaseImponible - DesctoBI;
            if (DesctoBI != 0)
            {
                DctoIGV = (MontoDscto * 18) / 100;
                return DctoIGV;
            }
            else
            {
                return DctoIGV;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
