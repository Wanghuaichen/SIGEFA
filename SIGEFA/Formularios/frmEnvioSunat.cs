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
using SIGEFA.SunatFacElec;
using SunatFE;
using System.IO;
using DevComponents.DotNetBar;
using System.Threading;


namespace SIGEFA.Formularios
{
    public partial class frmEnvioSunat : Office2007Form
    {

        //#region datos

        //public static Int32 iCodUser;
        //public static Int32 iCodEmpresa;
        //public static Int32 iCodSucursal;
        //public static String sEmpresa;
        //public static Int32 iCodAlmacen;
        //public static String sAlmacen;
        //public static String sUsuario = "";
        //public static String sNombreUser = "";
        //public static String sApellidoUSer = "";
        //public static Int32 iNivelUser;
        //public static String DirecIp = "";
        //public static String RUC = "";
        //public static Int32 estadoIngreso;

        //#endregion datos

        private string estado = "-1";
        private clsAdmRepositorio clsadmrepo = new clsAdmRepositorio();
        private List<clsRepositorio> lista_repositorio = null;
        private clsEmpresa empresa = null;
        private clsAdmEmpresa admemp = new clsAdmEmpresa();

        SIGEFA.SunatFacElec.Conexion con = new SIGEFA.SunatFacElec.Conexion();

        public frmEnvioSunat()
        {
            InitializeComponent();
        }        

        public void listar_repositorio() 
        {
            try
            {
                Herramientas her = new Herramientas();

                Image imagen_pdf = Image.FromFile(@"" + her.GetResourcesPath4() + "\\pdf.png");
                Image imagen_xml = Image.FromFile(@"" + her.GetResourcesPath4() + "\\xml.png");

                lista_repositorio = new List<clsRepositorio>(); 
                lista_repositorio = clsadmrepo.listar_repositorio(estado, frmLogin.iCodSucursal, frmLogin.iCodAlmacen);

                if (lista_repositorio != null)
                {
                    if (lista_repositorio.Count > 0)
                    {
                        dg_documentos.Rows.Clear();
                        foreach (clsRepositorio rep in lista_repositorio) 
                        {                            
                            dg_documentos.Rows.Add(rep.Repoid, rep.Tipodoc, rep.Fechaemision, rep.Serie, 
                                                   rep.Correlativo, rep.Monto, rep.Estadosunat, rep.Mensajesunat,
                                                   imagen_pdf, imagen_xml, rep.Nombredoc, rep.Usuario, rep.Fechaemision);
                        }                        
                    }
                    totaldocs.Text = lista_repositorio.Count.ToString();
                }
                else{ dg_documentos.Rows.Clear(); }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }       

        public void Envio() 
        {
            try
            {
                //string firmaxml = "";
                string rutacertificado = "";
                string tipodocumento = "";
                string _iddocumento = "";
                string[] iddocumento = null;
                bool todocorrecto = false;

                if (lista_repositorio != null)
                {
                    if (lista_repositorio.Count > 0)
                    {
                        empresa = admemp.CargaEmpresa3(1);
                        rutacertificado = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CERTIFIK\\" + empresa.Certificado;

                        foreach (clsRepositorio r in lista_repositorio)
                        {
                            var tramaXmlSinFirma = Convert.ToBase64String(r.Xml);

                            var firmadoRequest = new FirmadoRequest
                            {
                                TramaXmlSinFirma = tramaXmlSinFirma,
                                CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(rutacertificado)),
                                PasswordCertificado = empresa.Contrasena,
                                UnSoloNodoExtension = true
                            };

                            switch (r.Tipodoc)
                            {

                                case 1: tipodocumento = "03"; iddocumento = r.Nombredoc.Split('-'); _iddocumento = iddocumento[2] + "-" + r.Correlativo; break;//boleta
                                case 2: tipodocumento = "01"; iddocumento = r.Nombredoc.Split('-'); _iddocumento = iddocumento[2] + "-" + r.Correlativo; break;//factura
                                case 4: tipodocumento = "07"; iddocumento = r.Nombredoc.Split('-'); _iddocumento = iddocumento[2] + "-" + r.Correlativo; break;//nota credito
                                case 6: tipodocumento = "08"; iddocumento = r.Nombredoc.Split('-'); _iddocumento = iddocumento[2] + "-" + r.Correlativo; break;//nota debito                            
                            }
                            FirmarController enviar = new FirmarController();
                            var respuestaFirmado = enviar.FirmadoResponse(firmadoRequest, Convert.ToInt32(tipodocumento));
                            if (!respuestaFirmado.Exito)
                                throw new ApplicationException(respuestaFirmado.MensajeError);

                            var enviarDocumentoRequest = new EnviarDocumentoRequest
                            {
                                Ruc = empresa.Ruc,
                                UsuarioSol = empresa.UsuarioSunat,
                                ClaveSol = empresa.ClaveSunat,
                                //EndPointUrl = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService",      
                                EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService",
                                IdDocumento = _iddocumento,
                                TipoDocumento = tipodocumento,
                                TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                            };

                            var respuestaEnvio = new EnviarDocumentoResponse();
                            EnviarDocumentoController enviarDoc = new EnviarDocumentoController();
                            respuestaEnvio = enviarDoc.EnviarDocumentoResponse(enviarDocumentoRequest);
                            var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                            if (rpta != null)
                            {

                                if (rpta.CodigoRespuesta == "0")
                                {
                                    r.Estadosunat = "0";
                                    r.Mensajesunat = rpta.MensajeRespuesta;
                                    String ruta = @"C:\DOCUMENTOS-" + empresa.Ruc + "\\CDR\\" + "R-" + r.Nombredoc + ".zip";
                                    File.WriteAllBytes(ruta, Convert.FromBase64String(rpta.TramaZipCdr));
                                    r.CDR = File.ReadAllBytes(ruta);
                                    todocorrecto = clsadmrepo.actualiza_repositorio(r);
                                }
                                else
                                {

                                    r.Estadosunat = "-1";
                                    r.Mensajesunat = rpta.MensajeRespuesta;
                                    clsadmrepo.actualiza_repositorio(r);
                                }
                            }
                        }

                        if (todocorrecto)
                        {

                            MessageBox.Show("Los documentos fueron enviados de forma correcta");
                            
                            listar_repositorio();
                            //Thread.Sleep(5000);
                            //this.Close();
                        }
                        else
                        {

                            MessageBox.Show("No todos los documentos fueron enviados de forma correcta");
                            listar_repositorio();
                        }
                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void btn_envio_Click(object sender, EventArgs e)
        {
            this.Envio();
        }
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEnvioSunat_Load(object sender, EventArgs e)
        {
            cb_estado.SelectedIndex = 0; 
            listar_repositorio();            
        }

        private void cb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_estado.SelectedIndex == 0)
            {
                btn_envio.Enabled = true;
                estado = "-1";
            }
            else
            {

                btn_envio.Enabled = false;
                estado = "0";
            }           
            listar_repositorio();
        }

        private void frmEnvioSunat_Shown(object sender, EventArgs e)
        {
            if (lista_repositorio != null)
            {
                if (lista_repositorio.Count > 0)
                {
                    //Thread.Sleep(5000);
                    //this.Envio();
                }
            }
            else { 
                //this.Close(); 
            }
        }

    }
}
