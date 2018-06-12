using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Librerias;

namespace SIGEFA
{
    public partial class mdi_Menu : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private int childFormNumber = 0;
        public static Boolean Cambio = false;
        clsAdmAcceso AdmAcce = new clsAdmAcceso();
        Boolean FormEncontrado;
        clsCaja aper = new clsCaja();
        clsAdmAperturaCierre AdmAper = new clsAdmAperturaCierre();
        clsAdmAlmacen admalm = new clsAdmAlmacen();
        clsConexionMysql con = new clsConexionMysql();
        clsAdmTipoCambio tc=new clsAdmTipoCambio();
        clsTipoCambio clstc=new clsTipoCambio();
        clsAdmCotizacion admcot=new clsAdmCotizacion();
        private Boolean rpta;
        List<DevComponents.DotNetBar.ButtonItem> ListaControles = new List<DevComponents.DotNetBar.ButtonItem>();
        public Double tc_hoy = 0;
        public Int32 tcvalida;

        clsTipoCambioSunat clstipoc = new clsTipoCambioSunat();
        clsValidarSGE valida = new clsValidarSGE();
        DateTime dia = new DateTime().Date;
        DateTime fechactual = new DateTime().Date;
        Boolean EstadoTC_BD = false;
        DataTable tabla = new DataTable();
        public static clsParametros Configuracion = new clsParametros();
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        public Double ven;
        public Double com;
        public Double comp;
        public Double vent;
        public Boolean EstadoTC = false;

        clsCaja Caja = new clsCaja();
        clsAdmAperturaCierre AdmCaja = new clsAdmAperturaCierre();
        Int32 tipocaja = 0;
        public Boolean bandcaja = false;

        public void cargaconfiguracion()
        {
            Configuracion = AdmEmp.CargaConfiguracion();
        }

        private void GenerarLista()
        {
            #region Ventas

            ListaControles.Add(biVenta);
            ListaControles.Add(biMuestraVentas);
            ListaControles.Add(biVentasPendientesDespacho);
            //ListaControles.Add(biCotizacion);
            

            ListaControles.Add(biGuia);
            ListaControles.Add(biGuias);
            ListaControles.Add(biBuscarGuia);

            ListaControles.Add(biNotaCredito);
            ListaControles.Add(ciNotasdeCredito);

            ListaControles.Add(biNotaDebito);
            ListaControles.Add(ciNotasdeDebito);

            ListaControles.Add(biCobros);
            ListaControles.Add(biStockAlmacenes);

            //ListaControles.Add(biVentasporSeparacion);
            //ListaControles.Add(biListaVentasSeparacion);

            #endregion Ventas

            #region Compras

            ListaControles.Add(biPedidoCompra);
            ListaControles.Add(biListadoCompras);
            ListaControles.Add(biPagos);

            ListaControles.Add(biOrdenCompra);
            ListaControles.Add(biOrdenesCompras);

            ListaControles.Add(biCompraOrden);
            ListaControles.Add(biHistorialFacturaciones);
            //ListaControles.Add(biNotaCreditoCompra);
            //ListaControles.Add(biNotasCreditoCompras);

            //ListaControles.Add(btnNotaDebitoC);
            //ListaControles.Add(biListadoND);

            #endregion Compras

            #region Almacen

            ListaControles.Add(biNotadeIngreso);
            ListaControles.Add(biNotadeSalida);
            ListaControles.Add(biTransferencia);
            ListaControles.Add(biTransferenciasPendientes);

            ListaControles.Add(biConsulta);
            //ListaControles.Add(btArqueo);
            ListaControles.Add(biStockMinimos);

            #endregion Almacen

            #region Clinica

            ListaControles.Add(biPacientes);
            ListaControles.Add(biHistoriasClinicas);

            #endregion Clinica

            #region Entidades

            ListaControles.Add(biProductos);
            ListaControles.Add(biCatalogo);

            ListaControles.Add(biClientes);
            ListaControles.Add(biProveedores);

            #endregion Entidades

            #region Reportes

            ListaControles.Add(biInventario);
            ListaControles.Add(biKardex);
            ListaControles.Add(btnReporte);
            ListaControles.Add(biUtilidad);

            #endregion Reportes

            #region Administrador

            ListaControles.Add(biEmpresa);
            ListaControles.Add(biSucursal);
            ListaControles.Add(biAlmacen);
            ListaControles.Add(biUsuarios);

            ListaControles.Add(biTablas);
            ListaControles.Add(biUnidades);
            ListaControles.Add(biFamilias);
            ListaControles.Add(biMarcas);
            ListaControles.Add(biCaracteristica);
            ListaControles.Add(biDocumentos);
            ListaControles.Add(biTransacciones);
            ListaControles.Add(biTipoCambio);
            ListaControles.Add(biFormaPago);
            ListaControles.Add(biMetodoPago);
            ListaControles.Add(biListasPrecios);
            ListaControles.Add(biBancos);
            ListaControles.Add(biCuentasCorrientes);
            ListaControles.Add(biTarjetaPago);
            ListaControles.Add(biTipoEgresoCaja);

            ListaControles.Add(biParametros);
            ListaControles.Add(biVigenciaCotizaciones);

            ListaControles.Add(biBackup);
            ListaControles.Add(biImport);
            ListaControles.Add(biEnviodeDocumentos); 
            //importar excel
            //ListaControles.Add(biListaVentasSeparacion); //modulo contingencia
            //ListaControles.Add(buttonItem15); //Envio de F/B por Error Servidor Sunat
            #endregion Administrador

            #region Caja Bancos

            ListaControles.Add(BiAperturaCajaVentas);
            ListaControles.Add(biMovimientosCajaVentasEfectivo);

            ListaControles.Add(biAperturaCajachica);
            ListaControles.Add(biCajaChica);

            ListaControles.Add(biMovimientosBancarios);
            ListaControles.Add(BiRendiciones);

            #endregion Caja Bancos

            #region Libros Electronicos

            ListaControles.Add(biVentasPendientesDespacho);       // genera libros electronicos
            ListaControles.Add(biRegistroVentas);  // procesar compras
            ListaControles.Add(buttonItem1); //Plan contable

            #endregion Libros Electronicos
        }
                
        public mdi_Menu()
        {
            InitializeComponent();
            GenerarLista();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
               

        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            frmUsuarios form = new frmUsuarios();
            form.MdiParent = this;                       
            form.Show();
        }

        private void mdi_Menu_Load(object sender, EventArgs e)
        {
            tabStrip1.Hide();
            //frmLogin.iCodAlmacen = 2;
            //frmLogin.AlmacenLogin = admalm.CargaAlmacen(frmLogin.iCodAlmacen);
            //frmLogin.sAlmacen = frmLogin.AlmacenLogin.Nombre;
            rpta = admcot.CotizacionesVencidas();
            frmSeleccionarAlmacen frm = new frmSeleccionarAlmacen();
            frm.ShowDialog();
            Configuracion = frmLogin.Configuracion;
            frmLogin.AcesosUsuario = AdmAcce.MuestraAccesos(frmLogin.iCodUser, frmLogin.iCodAlmacen);                        
            sUsuario.Text = "Usuario : " + frmLogin.sNombreUser + " " + frmLogin.sApellidoUSer;
            sEmpresa.Text = "Empresa : " + frmLogin.sEmpresa;
            sAlmacen.Text = "Almacen : " + frmLogin.sAlmacen;
            sIP.Text = "IP : " + frmLogin.DirecIp;
            dia = DateTime.Now.Date;
            fechactual = DateTime.Now.Date;
            crearDirectorio();

            //Aletar Stock Minimo Almacen
            DataTable ds = admalm.RelacionProductosStockMin(1, frmLogin.iCodAlmacen);
            if (ds.Rows.Count > 0)
            {
                frmProductosStockMin frma = new frmProductosStockMin();
                frma.codalmacen = frmLogin.iCodAlmacen;
                frma.ShowDialog();
            }
            //Fin Aletar Stock Minimo Almacen
            //Alerta de Facturas y letras por vencer
            DataTable dtven = admalm.AlertaFacturasLetrasXVencer();
            if (dtven.Rows.Count > 0)
            {
                frmFacturasLetrasXVencer frmfv = new frmFacturasLetrasXVencer();
                frmfv.ShowDialog();
            }
            //Fin Alerta de Facturas y letras por vencer
            ValidaTipoCambio();
            VerificaSaldoCaja();
        }

        public void ValidaTipoCambio()
        {
            try
            {
                EstadoTC_BD = tc.VerificaTCFecha(dia);
                if (EstadoTC_BD)
                {
                    tcvalida = 1;
                    clstc = tc.CargaTipoCambio(dia, 2);
                    tc_hoy = clstc.Venta;
                    liTipodeCambio.Text = "Fecha TC:  " + clstc.Fecha.ToShortDateString() + "  Compra: " + clstc.Compra.ToString() + " - Venta: " + clstc.Venta.ToString();
                }
                else
                {
                    if (valida.AccesoInternet())
                    {
                        MetodoTipoCambio();
                        if (liTipodeCambio.Text != "Tipo de Cambio" && Configuracion.Autoguardado == true)
                        {
                            tcvalida = 1;
                            clstc = tc.CargaTipoCambio(dia, 2);
                            tc_hoy = clstc.Venta;
                        }
                        else
                        {
                            MessageBox.Show("Ingresa Tipo de Cambio de Hoy");
                            if (Application.OpenForms["frmTipoCambio"] != null)
                            {
                                Application.OpenForms["frmTipoCambio"].Activate();
                            }
                            else
                            {
                                frmTipoCambio form = new frmTipoCambio();
                                form.btnNuevo_Click(null, null);
                                form.ShowDialog();
                                ValidaTipoCambio();
                            }
                        }
                    }
                    else
                    {
                        //dia = dia.AddDays(-1);

                        MessageBox.Show("Ingresa Tipo de Cambio de Hoy");
                        if (Application.OpenForms["frmTipoCambio"] != null)
                        {
                            Application.OpenForms["frmTipoCambio"].Activate();
                        }
                        else
                        {
                            frmTipoCambio form = new frmTipoCambio();
                            //form.MdiParent = this;
                            form.btnNuevo_Click(new object(), new EventArgs());
                            form.ShowDialog();
                        }

                        ValidaTipoCambio();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MetodoTipoCambio()
        {
            try
            {
                Boolean auto = Configuracion.Autoguardado;
                tabla = clstipoc.ConsultaTCSunat(dia);
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    //var sdiabuscado = TipoCam.Select("Día = '" + Fechabuscada.Date.Day.ToString() + "'");
                    String cadenabusqueda = "[Día] like '*" + dia.Date.Day.ToString() + "*'";
                    DataRow[] foundRows = tabla.Select(cadenabusqueda);
                    //if (sdiabuscado.Length != 0)
                    if (foundRows.Length != 0)
                    {
                        foreach (DataRow r in tabla.Rows)
                        {
                            if (Convert.ToInt32(r[0]) == dia.Date.Day)
                            {
                                liTipodeCambio.Text = "Fecha TC:  " + dia.ToShortDateString() + " Compra: " + r[1].ToString() + " Venta: " + r[2].ToString();
                                //Thread.Sleep(1000);
                                comp = Convert.ToDouble(r[1].ToString().Replace(",", "."));
                                vent = Convert.ToDouble(r[2].ToString().Replace(",", "."));
                            }
                        }
                        if (auto)
                        {
                            if (liTipodeCambio.Text != "Tipo de Cambio")
                            {
                                clstc.ICodMoneda = 2;
                                clstc.Compra = comp;
                                clstc.Venta = vent;
                                clstc.Fecha = DateTime.Now;
                                clstc.CodUser = frmLogin.iCodUser;
                                if (tc.insert(clstc))
                                {
                                    //MetodoTipoCambio();
                                    EstadoTC = true;
                                    dia = DateTime.Now;
                                    ValidaTipoCambio();
                                }
                            }
                        }
                    }
                    else
                    {
                        dia = dia.AddDays(-1);
                        MetodoTipoCambio();
                    }
                }
                else
                {
                    dia = dia.AddDays(-1);
                    MetodoTipoCambio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexión : " + ex.Message, "Error en Hilo Tipo Cambio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void crearDirectorio()
        {
            //crear las rutas

            string XML = @"C:\XML";
            string CAPTCHA = @"C:\CAPTCHA";
            string DOCUMENTOS_ELECTRONICAS = @"C:\DOCUMENTOS-" + frmLogin.RUC;
            string FIRMA = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\CERTIFIK";
            string QR = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\CERTIFIK\\QR";
            string DOCUMENTOS_ENVIA = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR";
            string NOTASDEBITO = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\NOTAS DEBITO";
            string NOTASCREDITO = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\NOTAS CREDITO";
            string FACTURAS = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\FACTURAS";
            string BOLETAS = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOS ENVIAR\\BOLETAS";
            string CDR = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\CDR";
            string DOCUMENTOSBAJA = @"C:\DOCUMENTOS-" + frmLogin.RUC + "\\DOCUMENTOSBAJA";
            try
            {//si no existe la carpeta temporal la creamos                
                if (!(System.IO.Directory.Exists(XML)))
                {
                    System.IO.Directory.CreateDirectory(XML);
                }
                if (!(System.IO.Directory.Exists(CAPTCHA)))
                {
                    System.IO.Directory.CreateDirectory(CAPTCHA);
                }
                if (!(System.IO.Directory.Exists(DOCUMENTOS_ELECTRONICAS)))
                {
                    System.IO.Directory.CreateDirectory(DOCUMENTOS_ELECTRONICAS);
                    if (!(System.IO.Directory.Exists(FIRMA)))
                    {
                        System.IO.Directory.CreateDirectory(FIRMA);
                        if (!(System.IO.Directory.Exists(QR)))
                        {
                            System.IO.Directory.CreateDirectory(QR);
                        }
                    }
                    if (!(System.IO.Directory.Exists(CDR)))
                    {
                        System.IO.Directory.CreateDirectory(CDR);
                    }
                    if (!(System.IO.Directory.Exists(DOCUMENTOSBAJA)))
                    {
                        System.IO.Directory.CreateDirectory(DOCUMENTOSBAJA);
                    }
                    if (!(System.IO.Directory.Exists(DOCUMENTOS_ENVIA)))
                    {
                        System.IO.Directory.CreateDirectory(DOCUMENTOS_ENVIA);

                        if (!(System.IO.Directory.Exists(NOTASDEBITO))) { System.IO.Directory.CreateDirectory(NOTASDEBITO); }
                        if (!(System.IO.Directory.Exists(NOTASCREDITO))) { System.IO.Directory.CreateDirectory(NOTASCREDITO); }
                        if (!(System.IO.Directory.Exists(FACTURAS))) { System.IO.Directory.CreateDirectory(FACTURAS); }
                        if (!(System.IO.Directory.Exists(BOLETAS))) { System.IO.Directory.CreateDirectory(BOLETAS); }
                    }

                }

            }
            catch (Exception errorC)
            {
                MessageBox.Show(errorC.Message, "Error al crear fichero temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void buttonItem22_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmEmpresas"] != null)
            {
                Application.OpenForms["frmEmpresas"].Activate();
            }
            else
            {
                frmEmpresas form = new frmEmpresas();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
           
        }

        //private void buttonItem24_Click(object sender, EventArgs e)
        //{
        //    if (Application.OpenForms["frmUsuarios"] != null)
        //    {
        //        Application.OpenForms["frmUsuarios"].Activate();
        //    }
        //    else
        //    {
        //        frmUsuarios form = new frmUsuarios();
        //        form.MdiParent = this;
        //        form.Show();
        //    }
        //}

        private void buttonItem1_Click(object sender, EventArgs e)
        {
             if (tcvalida==1){
                if (Application.OpenForms["frmProductos"] != null)
                {
                    Application.OpenForms["frmProductos"].Activate();
                }
                else
                {
                    frmProductos form = new frmProductos();
                    form.MdiParent = this;
                    form.tc_hoy = tc_hoy;
                    form.Dock = DockStyle.Fill;
                    form.Show();
                }
             }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmUnidades"] != null)
            {
                Application.OpenForms["frmUnidades"].Activate();
            }
            else
            {
                frmUnidades form = new frmUnidades();
                //form.MdiParent = this;
                form.ShowDialog();
            }
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmFamilias"] != null)
            {
                Application.OpenForms["frmFamilias"].Activate();
            }
            else
            {
                frmFamilias form = new frmFamilias();
                form.MdiParent = this;
                //form.ShowDialog();
                form.Show();
            }
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
        
            if (Application.OpenForms["frmMarcas"] != null)
            {
                Application.OpenForms["frmMarcas"].Activate();
            }
            else
            {
                frmMarcas form = new frmMarcas();
                //form.MdiParent = this;
                form.ShowDialog();
            }
            
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmTipoArticulos"] != null)
            {
                Application.OpenForms["frmTipoArticulos"].Activate();
            }
            else
            {
                frmTipoArticulos form = new frmTipoArticulos();
                //form.MdiParent = this;
                form.ShowDialog();
            }
            
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            
            if (Application.OpenForms["frmCaracteristicas"] != null)
            {
                Application.OpenForms["frmCaracteristicas"].Activate();
            }
            else
            {
                frmCaracteristicas form = new frmCaracteristicas();
                //form.MdiParent = this;
                form.ShowDialog();
            }
            
        }

        private void mdi_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mdi_Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                frmSeleccionarAlmacen frm = new frmSeleccionarAlmacen();
                frm.ShowDialog();                
                if (Cambio)
                {
                    foreach (Form childForm in MdiChildren)
                    {
                        childForm.Close();
                    }
                    frmLogin.AcesosUsuario = AdmAcce.MuestraAccesos(frmLogin.iCodUser, frmLogin.iCodAlmacen);
                    OtorgarAccesos(ListaControles);
                    sAlmacen.Text = "Almacen : " + frmLogin.sAlmacen;                    
                }
                Cambio = false;
            }
        }

        private void mdi_Menu_Shown(object sender, EventArgs e)
        {
            OtorgarAccesos(ListaControles);
            tabStrip1.Hide();
            if (tc.VerificaTCFecha(DateTime.Now) == true)
            {
                tcvalida = 1;
                clstc = tc.CargaTipoCambio(DateTime.Now, 2);
                tc_hoy = clstc.Venta;

            }
            else
            {
                MessageBox.Show("Ingresa Tipo de Cambio de Hoy");
                if (Application.OpenForms["frmTipoCambio"] != null)
                {
                    Application.OpenForms["frmTipoCambio"].Activate();
                }
                else
                {
                    frmTipoCambio form = new frmTipoCambio();
                    //form.MdiParent = this;
                    form.btnNuevo_Click(sender, e);
                    form.ShowDialog();
                }
            }
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAlmacenes"] != null)
            {
                Application.OpenForms["frmAlmacenes"].Activate();
            }
            else
            {
                frmAlmacenes form = new frmAlmacenes();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
           
        }


        private void OtorgarAccesos(List<DevComponents.DotNetBar.ButtonItem> Lista)
        {
            if (frmLogin.iNivelUser != 1)
            {
                foreach (DevComponents.DotNetBar.ButtonItem item in Lista)
                {
                    if (frmLogin.AcesosUsuario.Contains(Convert.ToInt32(item.Tag)))
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }

                }
            }
        }

        //private void OtorgarAccesos(Control.ControlCollection Coleccion)
        //{   
        //    Int32 cod;
        //    if (frmLogin.iNivelUser == 0)
        //    {
        //        foreach (Control c in Coleccion)
        //        {
        //            cod = Convert.ToInt32(c.Tag);
        //            if (frmLogin.AcesosUsuario.Contains(Convert.ToInt32(c.Tag)))
        //            {
        //                c.Enabled = true;
        //            }
        //            else
        //            {
        //                c.Enabled = false;
        //            }   
        //            if (c.Controls.Count > 0)
        //            {
        //                OtorgarAccesos(c.Controls);
        //            }
                    
        //        }
        //    }
        //}

        private void biNotadeIngreso_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {

                if (Application.OpenForms["frmNotaIngreso"] != null)
                {
                    Application.OpenForms["frmNotaIngreso"].Activate();
                }
                else
                {
                    frmNotaIngreso form = new frmNotaIngreso();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.Show();
                }
            }
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
             if (Application.OpenForms["frmUsuarios"] != null)
            {
                Application.OpenForms["frmUsuarios"].Activate();
            }
            else
            {
                frmUsuarios form = new frmUsuarios();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void biProveedores_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmProveedores"] != null)
            {
                Application.OpenForms["frmProveedores"].Activate();
            }
            else
            {
                frmProveedores form = new frmProveedores();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }

        private void biClienteSimple_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmClientesSimples"] != null)
            {
                Application.OpenForms["frmClientesSimples"].Activate();
            }
            else
            {
                frmClientesSimples form = new frmClientesSimples();
                form.MdiParent = this;
                form.Tipo = 0;
                form.Show();
            }
        }

        private void biClienteCompleto_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmClientesCompletos"] != null)
            {
                Application.OpenForms["frmClientesCompletos"].Activate();
            }
            else
            {
                frmClientesCompletos form = new frmClientesCompletos();
                form.MdiParent = this;
                form.Tipo = 1;
                form.Show();
            }
        }

        private void biClienteEmpresa_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmClientesCorporativos"] != null)
            {
                Application.OpenForms["frmClientesCorporativos"].Activate();
            }
            else
            {
                frmClientesCorporativos form = new frmClientesCorporativos();
                form.MdiParent = this;
                form.Tipo = 2;
                form.Show();
            }
        }

        private void biDocumentos_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmDocumentos"] != null)
            {
                Application.OpenForms["frmDocumentos"].Activate();
            }
            else
            {
                frmDocumentos form = new frmDocumentos();
                //form.MdiParent = this;
                form.ShowDialog();
            }
          
        }

        private void biTransacciones_Click(object sender, EventArgs e)
        {
        
            if (Application.OpenForms["frmTransacciones"] != null)
            {
                Application.OpenForms["frmTransacciones"].Activate();
            }
            else
            {
                frmTransacciones form = new frmTransacciones();
                //form.MdiParent = this;
                form.ShowDialog();
            }
            
        }

        private void biVenta_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                try
                {
                    VerificaSaldoCaja();
                    aper = AdmAper.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, 1, frmLogin.iCodAlmacen, frmLogin.iCodUser);//1 caja ventas
                    if (aper != null)
                    {
                        if (aper.Estado == true)
                        {
                            if (Application.OpenForms["frmVenta"] != null)
                            {
                                Application.OpenForms["frmVenta"].Activate();
                            }
                            else
                            {
                                frmVenta form1 = new frmVenta();
                                form1.MdiParent = this;
                                form1.Proceso = 1;
                                form1.CodigoCaja = aper.Codcaja;
                                form1.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya ha realizado el cierre para el día de hoy", "Apertura Caja", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe Aperturar Caja", "Apertura Caja", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                }
            }
        }

        private void biTipoCambio_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTipoCambio"] != null)
            {
                Application.OpenForms["frmTipoCambio"].Activate();
            }
            else
            {
                frmTipoCambio form = new frmTipoCambio();
                //form.MdiParent = this;
                form.ShowDialog();
            }
        }

        private void biAutorizado_Click(object sender, EventArgs e)
        {
           
            if (Application.OpenForms["frmAutorizado"] != null)
            {
                Application.OpenForms["frmAutorizado"].Activate();
            }
            else
            {
                frmAutorizado form = new frmAutorizado();
                //form.MdiParent = this;
                form.ShowDialog();
            }
           
        }

        private void BuscaFormulario(Int32 Proceso)
        {
            foreach (Form formu in Application.OpenForms)
            {
                String typeform = formu.GetType().Name;
                if (typeform == "frmNotas")
                {
                    frmNotas fo = (frmNotas)formu;
                    if (fo.Proceso == Proceso)
                    {
                        fo.Activate();
                        fo.WindowState = FormWindowState.Maximized;
                        FormEncontrado = true;
                        return;
                    }
                    else
                    {
                        FormEncontrado = false;
                    }
                }
            }
        }

        private void biConsulta_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotas"] != null)
                {
                    BuscaFormulario(3);
                    if (!FormEncontrado)
                    {
                        frmNotas form1 = new frmNotas();
                        form1.MdiParent = this;
                        form1.Proceso = 3;
                        form1.Text += " - CONSULTA";
                        //form.ShowDialog();                
                        form1.Show();
                    }
                }
                else
                {
                    frmNotas form1 = new frmNotas();
                    form1.MdiParent = this;
                    form1.Proceso = 3;
                    form1.Text += " - CONSULTA";
                    //form.ShowDialog();                
                    form1.Show();
                }
           }
        }

        private void biModificar_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotas"] != null)
                {
                    BuscaFormulario(2);
                    if (!FormEncontrado)
                    {
                        frmNotas form = new frmNotas();
                        form.MdiParent = this;
                        form.Proceso = 2;
                        form.Text += " - MODIFICAR";
                        //form.ShowDialog();                
                        form.Show();
                    }
                }
                else
                {
                    frmNotas form2 = new frmNotas();
                    form2.MdiParent = this;
                    form2.Proceso = 2;
                    form2.Text += " - MODIFICAR";
                    //form.ShowDialog();                
                    form2.Show();
                }
           }
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotas"] != null)
                {
                    BuscaFormulario(4);
                    if (!FormEncontrado)
                    {
                        frmNotas form3 = new frmNotas();
                        form3.MdiParent = this;
                        form3.Proceso = 4;
                        form3.Text += " - ELIMINAR";
                        //form.ShowDialog();                
                        form3.Show();
                    }
                }
                else
                {
                    frmNotas form3 = new frmNotas();
                    form3.MdiParent = this;
                    form3.Proceso = 4;
                    form3.Text += " - ELIMINAR";
                    //form.ShowDialog();                
                    form3.Show();
                }
             }
        }

        private void biNotadeSalida_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotaSalida"] != null)
                {
                    Application.OpenForms["frmNotaSalida"].Activate();
                }
                else
                {
                    frmNotaSalida form = new frmNotaSalida();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.Show();
                }
             }
        }

        private void biParametros_Click(object sender, EventArgs e)
        {
             if (tcvalida==1){
                if (Application.OpenForms["frmParametros"] != null)
                {
                    Application.OpenForms["frmParametros"].Activate();
                }
                else
                {
                    frmParametros form = new frmParametros();
                    form.MdiParent = this;                
                    form.Show();
                }
             }
        }

        private void biUsuarios_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmUsuarios"] != null)
            {
                Application.OpenForms["frmUsuarios"].Activate();
            }
            else
            {
                frmUsuarios form = new frmUsuarios();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }

        private void biPedidoCompra_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotaIngreso"] != null)
                {
                    Application.OpenForms["frmNotaIngreso"].Activate();
                }
                else
                {
                    frmNotaIngreso form = new frmNotaIngreso();
                    form.MdiParent = this;
                    form.Text = "Compra Directa";
                    form.Proceso = 1;
                    form.txtTransaccion.Text = "FT";
                    form.txtTransaccion.ReadOnly = true;
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    form.txtTransaccion_KeyPress(form.txtTransaccion, ee);
                    form.txtCodProv.Focus();
                    form.Show();
                    //form.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void biFormaPago_Click(object sender, EventArgs e)
        {
            
            if (Application.OpenForms["frmFormaPago"] != null)
            {
                Application.OpenForms["frmFormaPago"].Activate();
            }
            else
            {
                frmFormaPago form = new frmFormaPago();
                //form.MdiParent = this;
                form.ShowDialog();
            }
           
        }
        
        private void biPedidosPendientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPedidosPendientes"] != null)
            {
                Application.OpenForms["frmPedidosPendientes"].Activate();
            }
            else
            {
                frmPedidosPendientes form = new frmPedidosPendientes();
                form.MdiParent = this;
                //form.Proceso = 1;
                //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                //form.txtDocRef.Focus();
                form.Show();
            }
        }

        private void biPedidoVenta_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){

                if (Application.OpenForms["frmPedido"] != null)
                {
                    Application.OpenForms["frmPedido"].Activate();
                }
                else
                {
                    frmPedido form = new frmPedido();
                    form.MdiParent = this;
                    form.Proceso = 1;                
                    form.txtDocRef.Focus();
                    form.Show();
                }
            }
        }

        private void biInventario_Click(object sender, EventArgs e)
        {
             if (tcvalida==1){
                if (Application.OpenForms["ReporteInventario"] != null)
                {
                    Application.OpenForms["ReporteInventario"].Activate();
                }
                else
                {
                    frmReporteInventario form = new frmReporteInventario();
                    form.MdiParent = this;
                    form.Show();
                }
             }
        }

        private void biBackup_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                saveFileDialog1.ShowDialog();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (tcvalida==1){
            con.GeneraraBackup(saveFileDialog1.FileName);
            }
        }

        private void biImport_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
            openFileDialog1.ShowDialog();
            }      
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            con.ImportarBackup(openFileDialog1.FileName);
        }

        private void biTransferencia_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["F2TransferenciaEntreAlmacenes"] != null)
                {
                    Application.OpenForms["F2TransferenciaEntreAlmacenes"].Activate();
                }
                else
                {
                    F2TransferenciaEntreAlmacenes form = new F2TransferenciaEntreAlmacenes();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.txtDocRef.Focus();
                    form.Show();
                }
           }
        }

        private void biCobros_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){

                if (Application.OpenForms["frmCobros"] != null)
                {
                    Application.OpenForms["frmCobros"].Activate();
                }
                else
                {
                    frmCobros form = new frmCobros();
                    form.MdiParent = this;
                    //form.Proceso = 1;
                    //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.txtDocRef.Focus();
                    form.Dock = DockStyle.Fill;
                    form.Show();
                }
            }
        }

        private void biPagos_Click(object sender, EventArgs e)
        {
            frmPagos form1 = new frmPagos();
            form1.Close();
             if (tcvalida==1){
                if (Application.OpenForms["frmPagos"] != null)
                {
                    Application.OpenForms["frmPagos"].Activate();
                }
                else
                {
                    frmPagos form = new frmPagos();
                    form.MdiParent = this;
                    form.Dock = DockStyle.Fill;
                    //form.Proceso = 1;
                    //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.txtDocRef.Focus();
                    form.Show();
                }
             }
        }

        private void biMetodoPago_Click(object sender, EventArgs e)
        {
        
            if (Application.OpenForms["frmMetodoPago"] != null)
            {
                Application.OpenForms["frmMetodoPago"].Activate();
            }
            else
            {
                frmMetodoPago form = new frmMetodoPago();
                //form.MdiParent = this;
                form.ShowDialog();
            }
           
        }

        private void biCotizacion_Click(object sender, EventArgs e)
        {
            
            
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmGestionCotizacion"] != null)
                {
                    Application.OpenForms["frmGestionCotizacion"].Activate();
                }
                else
                {
                    frmGestionCotizacion form = new frmGestionCotizacion();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.txtDocRef.Text = "CT";
                    form.txtDocRef.ReadOnly = true;
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    form.txtDocRef_KeyPress(form.txtDocRef, ee);
                    form.txtCodCliente.Focus();
                    form.Show();
                }
            }
        }        

        private void biCotizacionesVigentes_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmCotizacionesVigentes"] != null)
                {
                    Application.OpenForms["frmCotizacionesVigentes"].Activate();
                }
                else
                {
                    frmCotizacionesVigentes form = new frmCotizacionesVigentes();
                    form.MdiParent = this;
                    //form.Proceso = 1;
                    //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.txtDocRef.Focus();
                    form.Show();
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmMenuReportes"] != null)
                {
                    Application.OpenForms["frmMenuReportes"].Activate();
                }
                else
                {
                    frmMenuReportes form = new frmMenuReportes();
                    //form.MdiParent = this;
                    //form.Proceso = 1;
                    //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.txtDocRef.Focus();
                    form.ShowDialog();
                }
            }
        }

        private void biClientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmClientesCompletos"] != null)
            {
                Application.OpenForms["frmClientesCompletos"].Activate();
            }
            else
            {
                frmClientesCompletos form = new frmClientesCompletos();
                form.MdiParent = this;
                form.Tipo = 1;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
             
        }

        private void biListasPrecios_Click(object sender, EventArgs e)
        {
             if (tcvalida == 1)
             {
                    //if (Application.OpenForms["frmGestionListaPrecios"] != null)
                    //{
                    //    Application.OpenForms["frmGestionListaPrecios"].Activate();
                    //}
                    //else
                    //{
                    //    frmGestionListaPrecios form = new frmGestionListaPrecios();                    
                    //    form.ShowDialog();
                    //}

                 if (Application.OpenForms["frmTipoPrecios"] != null)
                 {
                     Application.OpenForms["frmTipoPrecios"].Activate();
                 }
                 else
                 {
                     frmTipoPrecios form = new frmTipoPrecios();
                     form.ShowDialog();
                 }
             }
        }

        private void biVehiculosTransporte_Click(object sender, EventArgs e)
        {
       
            if (Application.OpenForms["frmVehiculosTransporte"] != null)
            {
                Application.OpenForms["frmVehiculosTransporte"].Activate();
            }
            else
            {
                frmVehiculoTransporte form = new frmVehiculoTransporte();
                //form.MdiParent = this;
                form.ShowDialog();
            }
           
        }

        private void biConductores_Click(object sender, EventArgs e)
        {
             
                if (Application.OpenForms["frmConductores"] != null)
                {
                    Application.OpenForms["frmConductores"].Activate();
                }
                else
                {
                    frmConductores form = new frmConductores();
                    //form.MdiParent = this;
                    form.ShowDialog();
                }
            
        }

        private void biEmpresasTransporte_Click(object sender, EventArgs e)
        {
           
                if (Application.OpenForms["frmEmpresaTransporte"] != null)
                {
                    Application.OpenForms["frmEmpresaTransporte"].Activate();
                }
                else
                {
                    frmEmpresaTransporte form = new frmEmpresaTransporte();
                    form.MdiParent = this;
                    form.Show();
                }
           
        }

        private void biGuia_Click(object sender, EventArgs e)
        {
           if (tcvalida==1){
                if (Application.OpenForms["frmGuiaRemision"] != null)
                {
                    Application.OpenForms["frmGuiaRemision"].Activate();
                }
                else
                {
                    frmGuiaRemision form1 = new frmGuiaRemision();
                    form1.MdiParent = this;
                    form1.Proceso = 1;
                    form1.Show();
                }
           }        
        }
            

        private void biZonas_Click(object sender, EventArgs e)
        {
            
                if (Application.OpenForms["frmZonas"] != null)
                {
                    Application.OpenForms["frmZonas"].Activate();
                }
                else
                {
                    frmZonas form = new frmZonas();
                    //form.MdiParent = this;
                    form.ShowDialog();
                }
           
        }

        private void biVendedores_Click(object sender, EventArgs e)
        {
           
                if (Application.OpenForms["frmVendedores"] != null)
                {
                    Application.OpenForms["frmVendedores"].Activate();
                }
                else
                {
                    frmVendedores form = new frmVendedores();
                    //form.MdiParent = this;
                    form.ShowDialog();
                }
            
        }

        private void biDestaques_Click(object sender, EventArgs e)
        {
             
                if (Application.OpenForms["frmDestaques"] != null)
                {
                    Application.OpenForms["frmDestaques"].Activate();
                }
                else
                {
                    frmDestaques form = new frmDestaques();
                    //form.MdiParent = this;
                    form.ShowDialog();
                }
            
        }

        private void btArqueo_Click(object sender, EventArgs e)
        {
             if (tcvalida==1){
                if (Application.OpenForms["frmArqueos"] != null)
                {
                    Application.OpenForms["frmArqueos"].Activate();
                }
                else
                {
                    frmArqueos form = new frmArqueos();
                    form.MdiParent = this;
                    //form.Proceso = 1;
                    form.Show();
                }
          }
        }

        

        private void biComisionVentas_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmCacularComision"] != null)
                {
                    Application.OpenForms["frmCacularComision"].Activate();
                }
                else
                {
                    frmCacularComision form = new frmCacularComision();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }       

        private void biComisionVentas_Click_1(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmComsionPorDocumento"] != null)
                {
                    Application.OpenForms["frmComsionPorDocumento"].Activate();
                }
                else
                {
                    frmComsionPorDocumento form = new frmComsionPorDocumento();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biGuias_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmGuiasRemision"] != null)
                {
                    Application.OpenForms["frmGuiasRemision"].Activate();
                }
                else
                {
                    frmGuiasRemision form = new frmGuiasRemision();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biAnular_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotas"] != null)
                {
                    BuscaFormulario(5);
                    if (!FormEncontrado)
                    {
                        frmNotas form3 = new frmNotas();
                        form3.MdiParent = this;
                        form3.Proceso = 5;
                        form3.Text += " - ANULAR";
                        //form.ShowDialog();                
                        form3.Show();
                    }
                }
                else
                {
                    frmNotas form3 = new frmNotas();
                    form3.MdiParent = this;
                    form3.Proceso = 5;
                    form3.Text += " - ANULAR";
                    //form.ShowDialog();                
                    form3.Show();
                }
            }
        }

        private void biNotaCredito_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotadeCredito"] != null)
                {
                    Application.OpenForms["frmNotadeCredito"].Activate();
                }
                else
                {
                    frmNotadeCredito form = new frmNotadeCredito();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.Show();
                }
            }        
         }

        private void ciNotasdeCredito_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotasCredito"] != null)
                {
                    Application.OpenForms["frmNotasCredito"].Activate();
                }
                else
                {
                    frmNotasCredito form1 = new frmNotasCredito();
                    form1.MdiParent = this;
                    form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

        private void biMuestraVentas_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmVentas"] != null)
                {
                    Application.OpenForms["frmVentas"].Activate();
                }
                else
                {
                    frmVentas form = new frmVentas();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biCatalogo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCatalogo"] != null)
            {
                Application.OpenForms["frmCatalogo"].Activate();
            }
            else
            {
                frmCatalogo form = new frmCatalogo();
                form.tc_hoy = tc_hoy;
                form.MdiParent = this;
                form.Show();
            }
        }

        private void biKardex_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
            frmParamKardexArticulo form = new frmParamKardexArticulo();
           // form.criterio = 0; // (0) ARTICULO
            form.ShowDialog();
            }
        }

        private void biBancos_Click(object sender, EventArgs e)
        {
             
                if (Application.OpenForms["frmBancos"] != null)
                {
                    Application.OpenForms["frmBancos"].Activate();
                }
                else
                {
                    frmBancos form = new frmBancos();
                    //form.MdiParent = this;
                    form.ShowDialog();
                }
            
        }

        
        private void tabStrip1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            if(tabStrip1.SelectedTab != null)
            {
            Form ventana = (Form)tabStrip1.SelectedTab.AttachedControl;
            if (ventana.WindowState == FormWindowState.Maximized)
            {
                ventana.WindowState = FormWindowState.Maximized;
            }
            }
        }

        private void mdi_Menu_MdiChildActivate(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild != null)
            //{
            //    this.ActiveMdiChild.WindowState =
            //    FormWindowState.Maximized;
            //}
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            //if (tcvalida==1){
            //    if (Application.OpenForms["frmTermometroVentas"] != null)
            //    {
            //        Application.OpenForms["frmTermometroVentas"].Activate();
            //    }
            //    else
            //    {
            //        frmTermometroVentas form = new frmTermometroVentas();
            //        form.MdiParent = this;
            //        form.Show();
            //    }
            //}
        }

        private void biBuscarGuia_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmBuscarGuias"] != null)
                {
                    Application.OpenForms["frmBuscarGuias"].Activate();
                }
                else
                {
                    frmBuscarGuias form = new frmBuscarGuias();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void btnRequerimiento_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmRequerimiento"] != null)
                {
                    Application.OpenForms["frmRequerimiento"].Activate();
                }
                else
                {
                    frmRequerimiento form = new frmRequerimiento();
                    form.MdiParent = this;
                    form.txtSerie.Focus();
                    form.Procede = 10;
                    form.Proceso = 1;
                    form.Show();
                }
             }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmRequerimientosVigentes"] != null)
                {
                    Application.OpenForms["frmRequerimientosVigentes"].Activate();
                }
                else
                {
                    frmRequerimientosVigentes form = new frmRequerimientosVigentes();
                    form.MdiParent = this;
                    form.tipo = 1;
                    form.Show();
                }
            }
        }

        private void biOrdenCompra_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmOrdenCompra"] != null)
            {
                Application.OpenForms["frmOrdenCompra"].Activate();
            }
            else
            {
                frmOrdenCompra form = new frmOrdenCompra();
                form.MdiParent = this;
                form.Procede = 10;
                form.Proceso = 1;
                form.Show();
            }
        }

        private void biOrdenesCompras_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmOrdenesVigentes"] != null)
            {
                Application.OpenForms["frmOrdenesVigentes"].Activate();
            }
            else
            {
                frmOrdenesVigentes form = new frmOrdenesVigentes();
                form.MdiParent = this;
                //form.Proceso = 1;
                //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                //form.txtDocRef.Focus();
                form.Show();
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            //if (tcvalida==1){
            //    if (Application.OpenForms["frmNotaIngresoPorOrden"] != null)
            //    {
            //        Application.OpenForms["frmNotaIngresoPorOrden"].Activate();
            //    }
            //    else
            //    {
            //        frmNotaIngresoPorOrden form = new frmNotaIngresoPorOrden();
            //        form.MdiParent = this;
            //        form.txtOrdenCompra.Focus();
            //        form.label19.Visible = false;
            //        form.txtFlete.Visible = false;
            //        form.Proceso = 1;
            //        form.Show();
            //        //form.WindowState = FormWindowState.Normal;
            //    }
            //}
        }

        private void BiMoneda_Click(object sender, EventArgs e)
        {
             if (tcvalida == 1){
                if (Application.OpenForms["frmMoneda"] != null)
                {
                    Application.OpenForms["frmMoneda"].Activate();
                }
                else
                {
                    frmMoneda form = new frmMoneda();
                    form.MdiParent = this;
                    form.Show();
                }
             }
        }

        private void biNotasOrden_Click(object sender, EventArgs e)
        {
            if (tcvalida==1){
                if (Application.OpenForms["frmNotasOrden"] != null)
                {
                    BuscaFormulario(3);
                    if (!FormEncontrado)
                    {
                        frmNotasOrden form1 = new frmNotasOrden();
                        form1.MdiParent = this;
                        form1.Proceso = 3;
                        form1.Text += " - CONSULTA";
                        //form.ShowDialog();                
                        form1.Show();
                    }
                }
                else
                {
                    frmNotasOrden form1 = new frmNotasOrden();
                    form1.MdiParent = this;
                    form1.Proceso = 3;
                    form1.Text += " - CONSULTA";
                    //form.ShowDialog();                
                    form1.Show();
                }
           }
        }

        private void biSucursal_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSucursales"] != null)
            {
                Application.OpenForms["frmSucursales"].Activate();
            }
            else
            {
                frmSucursales form = new frmSucursales();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }

        private void biTransferenciasPendientes_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["F2TransferenciasPendientes"] != null)
                {
                    Application.OpenForms["F2TransferenciasPendientes"].Activate();
                }
                else
                {
                    F2TransferenciasPendientes form = new F2TransferenciasPendientes();
                    form.MdiParent = this;
                    //form.tipo = 1;
                    form.Show();
                }
            }
        }

        private void biHistorialRequerimiento_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmOrdenesVigentes"] != null)
                {
                    Application.OpenForms["frmOrdenesVigentes"].Activate();
                }
                else
                {
                    frmRequerimientosVigentes form = new frmRequerimientosVigentes();
                    form.MdiParent = this;
                    form.tipo = 2;
                    form.Show();
                }
            }
        }

        private void biIngresos_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmTesoreria"] != null)
                {
                    Application.OpenForms["frmTesoreria"].Activate();
                }
                else
                {
                    frmTesoreria form = new frmTesoreria();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biCajaChica_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                try
                {
                    tipocaja = 2;
                    aper = AdmAper.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, tipocaja, frmLogin.iCodAlmacen, frmLogin.iCodUser);
                    if (aper != null)
                    {
                        if (aper.Estado == true)
                        {
                            if (Application.OpenForms["frmCajaChica"] != null)
                            {
                                Application.OpenForms["frmCajaChica"].Activate();
                            }
                            else
                            {
                                frmCajaChica form = new frmCajaChica();
                                form.tipo = 2;
                                form.MdiParent = this;
                                form.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya ha realizado el cierre para el día de hoy", "Apertura Caja", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe Aperturar Caja", "Apertura Caja", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                }
                
            }
        }       
        
        private void biHistorialFacturaciones_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmFacturacionesVigentes"] != null)
                {
                    Application.OpenForms["frmFacturacionesVigentes"].Activate();
                }
                else
                {
                    frmFacturacionesVigentes form = new frmFacturacionesVigentes();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biCotizacionesAprobadas_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmCotizacionesAprobadas"] != null)
                {
                    Application.OpenForms["frmCotizacionesAprobadas"].Activate();
                }
                else
                {
                    frmCotizacionesAprobadas form = new frmCotizacionesAprobadas();
                    form.MdiParent = this;
                    //form.Proceso = 1;
                    //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.txtDocRef.Focus();
                    form.Show();
                }
            }
        }

        private void biConsolidado_Click(object sender, EventArgs e)
        {
            //if (tcvalida == 1)
            //{
            //    if (Application.OpenForms["frmConsolidado"] != null)
            //    {
            //        Application.OpenForms["frmConsolidado"].Activate();
            //    }
            //    else
            //    {
            //        frmConsolidado form = new frmConsolidado();
            //        form.MdiParent = this;
            //        form.proceso = 3;
            //        form.Show();
            //    }
            //}
        }

        private void biCuentasCorrientes_Click(object sender, EventArgs e)
        {
            
                if (Application.OpenForms["frmCuentasCte"] != null)
                {
                    Application.OpenForms["frmCuentasCte"].Activate();
                }
                else
                {
                    frmCuentasCte form = new frmCuentasCte();
                    form.MdiParent = this;
                    form.Show();
                }
            
        }

        private void biTarjetaPago_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmTarjetasPago"] != null)
                {
                    Application.OpenForms["frmTarjetasPago"].Activate();
                }
                else
                {
                    frmTarjetasPago form = new frmTarjetasPago();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biVigenciaCotizaciones_Click(object sender, EventArgs e)
        {
          
            if (Application.OpenForms["frmVigenciaCotizacion"] != null)
            {
                Application.OpenForms["frmVigenciaCotizacion"].Activate();
            }
            else
            {
                frmVigenciaCotizacion form = new frmVigenciaCotizacion();
                form.MdiParent = this;
                form.Show();
            }
          
        }

        private void biGuiasSinFacturar_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotaOrdenAlmacen"] != null)
                {
                    Application.OpenForms["frmNotaOrdenAlmacen"].Activate();
                }
                else
                {
                    frmNotaOrdenAlmacen form = new frmNotaOrdenAlmacen();
                    form.proceso = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
             
        }
       
        private void biStockAlmacenes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmStockAlmacenes"] != null)
            {
                Application.OpenForms["frmStockAlmacenes"].Activate();
            }
            else
            {
                frmStockAlmacenes form = new frmStockAlmacenes();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }

        private void biParametros_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmParametros"] != null)
            {
                Application.OpenForms["frmParametros"].Activate();
            }
            else
            {
                frmParametros form = new frmParametros();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnNotaDebitoC_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotadeDebitoCompra"] != null)
                {
                    Application.OpenForms["frmNotadeDebitoCompra"].Activate();
                }
                else
                {
                    frmNotadeDebitoCompra form = new frmNotadeDebitoCompra();
                    form.Proceso = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

       

        private void biNotaCreditoCompra_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotadeCreditoCompra"] != null)
                {
                    Application.OpenForms["frmNotadeCreditoCompra"].Activate();
                }
                else
                {
                    frmNotadeCreditoCompra form = new frmNotadeCreditoCompra();
                    form.Proceso = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biNotasCreditoCompras_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotasCreditoCompras"] != null)
                {
                    Application.OpenForms["frmNotasCreditoCompras"].Activate();
                }
                else
                {
                    frmNotasCreditoCompras form = new frmNotasCreditoCompras();
                    form.Proceso = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

       

        private void biTipoEgresoCaja_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmGestionTipoEgreso"] != null)
                {
                    Application.OpenForms["frmGestionTipoEgreso"].Activate();
                }
                else
                {
                    frmGestionTipoEgreso form = new frmGestionTipoEgreso();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        

        private void biNotaDebito_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotadeDebito"] != null)
                {
                    Application.OpenForms["frmNotadeDebito"].Activate();
                }
                else
                {
                    frmNotadeDebito form1 = new frmNotadeDebito();
                    form1.MdiParent = this;
                    form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

        private void ciNotasdeDebito_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotasDebitoVentas"] != null)
                {
                    Application.OpenForms["frmNotasDebitoVentas"].Activate();
                }
                else
                {
                    frmNotasDebitoVentas form1 = new frmNotasDebitoVentas();
                    form1.MdiParent = this;
                    form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

        
        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmNotasDebitoCompras"] != null)
                {
                    Application.OpenForms["frmNotasDebitoCompras"].Activate();
                }
                else
                {
                    frmNotasDebitoCompras form1 = new frmNotasDebitoCompras();
                    form1.MdiParent = this;
                    form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

        private void btnMasivo_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmCancelarPagoMasivo"] != null)
                {
                    Application.OpenForms["frmCancelarPagoMasivo"].Activate();
                }
                else
                {
                    frmCancelarPagoMasivo form1 = new frmCancelarPagoMasivo();
                    form1.MdiParent = this;
                    form1.WindowState = FormWindowState.Normal;
                    form1.tipo = 3;
                    //form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

       

        private void biRotacionProducto_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmRotacionProductos"] != null)
                {
                    Application.OpenForms["frmRotacionProductos"].Activate();
                }
                else
                {
                    frmRotacionProductos form1 = new frmRotacionProductos();
                    form1.MdiParent = this;
                    form1.Show();
                }
            }
        }


        private void buttonItem3_Click_3(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmTesoreria"] != null)
                {
                    Application.OpenForms["frmTesoreria"].Activate();
                }
                else
                {
                    frmTesoreria form = new frmTesoreria();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmRegistroChequeCaja"] != null)
                {
                    Application.OpenForms["frmRegistroChequeCaja"].Activate();
                }
                else
                {
                    frmRegistroChequeCaja form = new frmRegistroChequeCaja();
                    //form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmTesoreriaAnuPag"] != null)
                {
                    Application.OpenForms["frmTesoreriaAnuPag"].Activate();
                }
                else
                {
                    frmTesoreriaAnuPag form = new frmTesoreriaAnuPag();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmPagosDetraccion"] != null)
                {
                    Application.OpenForms["frmPagosDetraccion"].Activate();
                }
                else
                {
                    frmPagosDetraccion form = new frmPagosDetraccion();
                    // form.Proceso = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem1_Click_3(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmAprobacionPagos"] != null)
                {
                    Application.OpenForms["frmAprobacionPagos"].Activate();
                }
                else
                {
                    frmAprobacionPagos form = new frmAprobacionPagos();
                    // form.Proceso = 1;
                    form.Dock = DockStyle.Fill;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

       
        private void biConsultorExterno_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {

                if (Application.OpenForms["frmConsultorExt"] != null)
                {
                    Application.OpenForms["frmConsultorExt"].Activate();
                }
                else
                {
                    frmConsultorExt form = new frmConsultorExt();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.txtDocRef.Focus();
                    form.Show();
                }
            }
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEntregasConsultExt"] != null)
            {
                Application.OpenForms["frmEntregasConsultExt"].Activate();
            }
            else
            {
                frmEntregasConsultExt form = new frmEntregasConsultExt();
                form.MdiParent = this;
                //form.Proceso = 1;
                //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                //form.txtDocRef.Focus();
                form.Show();
            }
        }

        private void buttonItem5_Click_1(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmVenta"] != null)
                {
                    Application.OpenForms["frmVenta"].Activate();
                }
                else
                {
                    frmVenta form1 = new frmVenta();
                    form1.MdiParent = this;
                    form1.consultorext = true;
                    form1.Proceso = 1;
                    form1.Show();
                }
            }
        }

        private void biStockMinimos_Click(object sender, EventArgs e)
        {
            frmProductosStockMin frma = new frmProductosStockMin();
            frma.codalmacen = frmLogin.iCodAlmacen;
            frma.ShowDialog();
        }

        private void BiRendiciones_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmConciliacionesBancarias"] != null)
            {
                Application.OpenForms["frmConciliacionesBancarias"].Activate();
            }
            else
            {
                frmConciliacionesBancarias form = new frmConciliacionesBancarias();
                form.Proceso = 1;
                //form.MdiParent = this.MdiParent;
                form.MdiParent = this;
                form.Show();
            }
        }
        

        

        private void buttonItem1_Click_4(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmPrestamosBancarios"] != null)
                {
                    Application.OpenForms["frmPrestamosBancarios"].Activate();
                }
                else
                {
                    frmPrestamosBancarios form = new frmPrestamosBancarios();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem3_Click_4(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmPagosPresBancarios"] != null)
                {
                    Application.OpenForms["frmPagosPresBancarios"].Activate();
                }
                else
                {
                    frmPagosPresBancarios form = new frmPagosPresBancarios();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }      

        private void biRegistroCompras_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRegistroComprasLE"] != null)
            {
                Application.OpenForms["frmRegistroComprasLE"].Activate();
            }
            else
            {
                frmRegistroComprasLE form = new frmRegistroComprasLE();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void biLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            tipocaja = 1;
            frm.Show();  
        }

        private void buttonItem1_Click_5(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRegistroComprasLE"] != null)
            {
                Application.OpenForms["frmRegistroComprasLE"].Activate();
            }
            else
            {
                frmPlanContable form = new frmPlanContable();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void BiAperturaCajaVentas_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                tipocaja = 1;
                bandcaja = true;
                VerificaSaldoCaja();
            }
        }

        private void BiCajaVentasenEfectivo_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmListaCaja"] != null)
                {
                    Application.OpenForms["frmListaCaja"].Activate();
                }
                else
                {
                    frmListaCaja form = new frmListaCaja();
                    form.Proceso = 1;
                    form.ShowDialog();
                }
            }

        }

        private void biMovimientosCajaVentasEfectivo_Click(object sender, EventArgs e)
        {           
            if (tcvalida == 1)
            {
                try
                {
                    aper = AdmAper.ValidarAperturaDia(frmLogin.iCodSucursal, DateTime.Now.Date, tipocaja, frmLogin.iCodAlmacen, frmLogin.iCodUser);
                    if (aper != null)
                    {
                        if (aper.Estado == true)
                        {
                            if (Application.OpenForms["frmCajaVentasMovimientos"] != null)
                            {
                                Application.OpenForms["frmCajaVentasMovimientos"].Activate();
                            }
                            else
                            {
                                frmCajaVentasMovimientos form = new frmCajaVentasMovimientos();
                                form.MdiParent = this;
                                form.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya ha realizado el cierre para el día de hoy", "Apertura Caja", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe Aperturar Caja", "Apertura Caja", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                }
            }
        }

        private void btnOtrosCajaChica_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmCajaChica"] != null)
                {
                    Application.OpenForms["frmCajaChica"].Activate();
                }
                else
                {
                    frmCajaChica form = new frmCajaChica();
                    form.tipo = 2;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void biMovimientosBancarios_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmMovimientos"] != null)
                {
                    Application.OpenForms["frmMovimientos"].Activate();
                }
                else
                {
                    frmMovimientos form = new frmMovimientos();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }
        
        private void biAperturaCajachica_Click(object sender, EventArgs e)
        {
            tipocaja = 2; //tipo 2 verifica apertura de la caja chica
            VerificaSaldoCajaChica();
        }

        private void VerificaSaldoCaja()
        {
            tipocaja = 1;//tipo 1 caja de ventas en efectivo
            Caja = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, fechactual, tipocaja, frmLogin.iCodAlmacen, frmLogin.iCodUser);

            if (Caja == null)
            {
                Caja = AdmCaja.GetUltimaCajaVentas(frmLogin.iCodSucursal, tipocaja, frmLogin.iCodAlmacen);
                if (Caja != null)
                {
                    if (Caja.Estado == false)
                    {
                        DialogResult result = MessageBox.Show("Existe una Apertura Caja" + Environment.NewLine + "Desea darle Cierre", "Apertura Caja",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            if (Application.OpenForms["frmCajaVentasMovimientos"] != null)
                            {
                                Application.OpenForms["frmCajaVentasMovimientos"].Activate();
                            }
                            else
                            {
                                frmCajaVentasMovimientos form = new frmCajaVentasMovimientos();
                                form.MdiParent = this;
                                //form.Proceso = 1;
                                form.dtpfecha1.Value = Caja.Fechaapertura;
                                form.Show();
                            }
                        }
                    }
                    else if (Caja.Estado)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    Caja = AdmCaja.CargaCierreAnterior(frmLogin.iCodSucursal, tipocaja);
                    if (Caja == null)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.tipocaja = tipocaja;
                            form.txtmonto.Text = "0.00";
                            form.ShowDialog();
                        }
                    }
                    else if (Caja != null)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.tipocaja = tipocaja;
                            form.txtmonto.Text = String.Format("{0:#,##0.00}",Caja.Montocierre);
                            form.ShowDialog();
                        }
                    }
                }
            }
            else 
            {
                if (bandcaja)
                {
                    DialogResult result = MessageBox.Show("Ya Existe una Apertura de Caja Ventas", "Apertura Caja Ventas",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
              
        }

        private void VerificaSaldoCajaChica()
        {
            tipocaja = 2;//tipo 2 caja chica
            Caja = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, fechactual, tipocaja, frmLogin.iCodAlmacen, frmLogin.iCodUser);

            if (Caja == null)
            {
                Caja = AdmCaja.GetUltimaCajaVentas(frmLogin.iCodSucursal, tipocaja, frmLogin.iCodAlmacen);
                if (Caja != null)
                {
                    if (Caja.Estado == false)
                    {
                        DialogResult result = MessageBox.Show("Existe una Apertura de Caja Chica" + Environment.NewLine + "Desea darle Cierre", "Apertura Caja Chica",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            if (Application.OpenForms["frmCajaChica"] != null)
                            {
                                Application.OpenForms["frmCajaChica"].Activate();
                            }
                            else
                            {
                                frmCajaChica form = new frmCajaChica();
                                form.tipo = 2;
                                form.dtpfecha1.Value = Caja.Fechaapertura;
                                form.MdiParent = this;
                                form.Show();
                            }
                        }
                    }
                    else if (Caja.Estado)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.ShowDialog();
                        }
                    }
                }
                else
                {                    
                    Caja = AdmCaja.CargaCierreAnterior(frmLogin.iCodSucursal, tipocaja);
                    if (Caja == null)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.tipocaja = tipocaja;
                            form.txtmonto.Text = "0.00";
                            form.ShowDialog();
                        }
                    }
                    else if (Caja != null)
                    {
                        if (Application.OpenForms["frmAperturaCajaDiaria"] != null)
                        {
                            Application.OpenForms["frmAperturaCajaDiaria"].Activate();
                        }
                        else
                        {
                            frmAperturaCajaDiaria form = new frmAperturaCajaDiaria();
                            form.Proceso = 1;
                            form.tipocaja = tipocaja;
                            form.txtmonto.Text = String.Format("{0:#,##0.00}", Caja.Montocierre);
                            form.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Ya Existe una Apertura de Caja Chica", "Apertura Caja Chica",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);             
            }

        }

        private void buttonItem6_Click_1(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmImportarExcelN1"] != null)
                {
                    Application.OpenForms["frmImportarExcelN1"].Activate();
                }
                else
                {
                    frmImportarExcelN1 form = new frmImportarExcelN1();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void rtCompras_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmVentasPendientesdeDespacho"] != null)
                {
                    Application.OpenForms["frmVentasPendientesdeDespacho"].Activate();
                }
                else
                {
                    frmVentasPendientesdeDespacho form = new frmVentasPendientesdeDespacho();
                    //form.Proce = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmVerCompras"] != null)
                {
                    Application.OpenForms["frmVerCompras"].Activate();
                }
                else
                {
                    frmVerCompras form = new frmVerCompras();
                    form.MdiParent = this;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmVentaSeparacionAr"] != null)
                {
                    Application.OpenForms["frmVentaSeparacionAr"].Activate();
                }
                else
                {
                    frmVentaSeparacionAr form = new frmVentaSeparacionAr();
                    form.MdiParent = this;
                    form.Proceso = 1;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmVentasSeparacioVer"] != null)
                {
                    Application.OpenForms["frmVentasSeparacioVer"].Activate();
                }
                else
                {
                    frmVentasSeparacioVer form = new frmVentasSeparacioVer();
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }

        private void rbCaja_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmListadoDeCajas"] != null)
            {
                Application.OpenForms["frmListadoDeCajas"].Activate();
            }
            else
            {
                frmListadoDeCajas form = new frmListadoDeCajas();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void buttonItem12_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmUtilidad"] != null)
            {
                Application.OpenForms["frmUtilidad"].Activate();
            }
            else
            {
                frmUtilidad form = new frmUtilidad();
                //form.tc_hoy = tc_hoy;
                form.MdiParent = this;
                form.Show();
            }
        }

        public static int MontoTopeBoleta { get; set; }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPaciente"] != null)
            {
                Application.OpenForms["frmPaciente"].Activate();
            }
            else
            {
                frmPaciente form = new frmPaciente();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmHistoriaClinica"] != null)
            {
                Application.OpenForms["frmHistoriaClinica"].Activate();
            }
            else
            {
                frmHistoriaClinica form = new frmHistoriaClinica();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            if (tcvalida == 1)
            {
                if (Application.OpenForms["frmEnvioSunat"] != null)
                {
                    Application.OpenForms["frmEnvioSunat"].Activate();
                }
                else
                {
                    frmEnvioSunat form = new frmEnvioSunat();
                    //form.Proce = 1;
                    form.MdiParent = this;
                    form.Show();
                }
            }
        }
    }
}
