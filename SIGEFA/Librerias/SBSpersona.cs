using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;
using HtmlAgilityPack;

namespace SIGEFA.Librerias
{
    public class SBSpersona
    {

        #region Propiedades
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _PrimerNombre;
        private string _SegundoNombre;
        private string _TipoTrabajador;
        private string _Sexo;
        private string _Nacionalidad;
        private string _LugarNacimiento;
        private string _LugarResidencia;
        private string _EstadoCivil;
        private string _FechaNacimiento;
        private string _FechaDefuncion;
        private string _FechaProcesoDefuncion;
        private string _OrigenAfiliacion;
        private string _EntidadAfiliacion;
        private string _TipoComisionAfiliacion;
        private string _CodigoAfiliacion;
        private string _FechaIngresoAfiliacion;
        private string _SituacionAfiliacion;

        public string ApellidoPaterno { get { return _ApellidoPaterno; } }
        public string ApellidoMaterno { get { return _ApellidoMaterno; } }
        public string PrimerNombre { get { return _PrimerNombre; } }
        public string SegundoNombre { get { return _SegundoNombre; } }
        public string TipoTrabajador { get { return _TipoTrabajador; } }
        public string Sexo { get { return _Sexo; } }
        public string Nacionalidad { get { return _Nacionalidad; } }
        public string LugarNacimiento { get { return _LugarNacimiento; } }
        public string LugarResidencia { get { return _LugarResidencia; } }
        public string EstadoCivil { get { return _EstadoCivil; } }
        public string FechaNacimiento { get { return _FechaNacimiento; } }
        public string FechaDefuncion { get { return _FechaDefuncion; } }
        public string FechaProcesoDefuncion { get { return _FechaProcesoDefuncion; } }
        public string OrigenAfiliacion { get { return _OrigenAfiliacion; } }
        public string EntidadAfiliacion { get { return _EntidadAfiliacion; } }
        public string TipoComisionAfiliacion { get { return _TipoComisionAfiliacion; } }
        public string CodigoAfiliacion { get { return _CodigoAfiliacion; } }
        public string FechaIngresoAfiliacion { get { return _FechaIngresoAfiliacion; } }
        public string SituacionAfiliacion { get { return _SituacionAfiliacion; } }
        private Resul state;
        private bool _ok;
        private string _error;        

        #endregion
        #region Variables Metodo ConsutaSBS
        string xApellidoPaterno="";
        string xApellidoMaterno = "";
        string xPrimerNombre = "";
        string xSegundoNombre = "";
        string xTipoTrabajador = "";
        string xSexo = "";
        string xNacionalidad = "";
        string xLugarNacimiento = "";
        string xLugarResidencia = "";
        string xEstadoCivil = "";
        string xFechaNacimiento;
        string xFechaDefuncion;
        string xFechaProcesoDefuncion;
        string xOrigenAfiliacion = "";
        string xEntidadAfiliacion = "";
        string xTipoComisionAfiliacion = "";
        string xCodigoAfiliacion = "";
        string xFechaIngresoAfiliacion;
        string xSituacionAfiliacion = "";
        #endregion
        #region Enumerador
        public enum Resul
        {
            Ok = 0,
            NoResul = 1,
            Error = 2,            
        }
        public enum Method { GET, POST }
        #endregion

        public void EnviarDatos(string numDni)
        {
            string UrlBase = "http://www.sbs.gob.pe/app/spp/Afiliados/afil_detalle.asp";

            Dictionary<string, string> Parametros = new Dictionary<string, string>();

            Parametros.Add("tp", "2");
            Parametros.Add("tip_doc", "00");
            Parametros.Add("num_doc",numDni);

            string respuestaServidor = GetResponse(UrlBase, Parametros, Method.POST);
        }
        public string GetResponse(string urlBase, Dictionary<string, string> parameters, Method method)
        {
            switch (method)
            {
                case Method.GET:
                    return GetResponse_GET(urlBase, parameters);
                case Method.POST:
                    return ConsultaSBS(urlBase, parameters);
                default:
                    throw new NotImplementedException();
            }
        }
        private string ConcatParams(Dictionary<string, string> parameters)
        {
            bool FirstParam = true;
            StringBuilder Parametros = null;

            if (parameters != null)
            {
                Parametros = new StringBuilder();
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    Parametros.Append(FirstParam ? "" : "&");
                    Parametros.Append(param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value));
                    FirstParam = false;
                }
            }

            return Parametros == null ? string.Empty : Parametros.ToString();
        }
        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public string GetResponse_GET(string url, Dictionary<string, string> parameters)
        {
            try
            {
                //Concatenamos los parametros, OJO: antes del primero debe estar el caracter "?"
                string parametrosConcatenados = ConcatParams(parameters);
                string urlConParametros = url + "?" + parametrosConcatenados;

                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(urlConParametros);
                wr.Method = "GET";

                wr.ContentType = "application/x-www-form-urlencoded";

                System.IO.Stream newStream;
                // Obtiene la respuesta
                System.Net.WebResponse response = wr.GetResponse();
                // Stream con el contenido recibido del servidor
                newStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(newStream);
                // Leemos el contenido
                string responseFromServer = reader.ReadToEnd();

                // Cerramos los streams
                reader.Close();
                newStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (System.Web.HttpException ex)
            {
                if (ex.ErrorCode == 404)
                    throw new Exception("Not found remote service " + url);
                else throw ex;
            }
        }
        public string ConsultaSBS(string url, Dictionary<string, string> parameters)
        {
            try
            {   //A este link le pasamos los datos , RUC y valor del captcha
                string parametrosConcatenados = ConcatParams(parameters);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);                
                WebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "application/x-www-form-urlencoded";
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(parametrosConcatenados);
                myWebRequest.ContentLength = byte1.Length;
                Stream myStream=myWebRequest.GetRequestStream();
                myStream.Write(byte1, 0, byte1.Length); 
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                myStream = myHttpWebResponse.GetResponseStream();                
                StreamReader myStreamReader = new StreamReader(myStream);              
                //Leemos los datos
                string xDat = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());                
                
                xDat = xDat.Replace("     ", " ");
                xDat = xDat.Replace("    ", " ");
                xDat = xDat.Replace("   ", " ");
                xDat = xDat.Replace("  ", " ");
                xDat=xDat.Replace("</td>\r\n ","");
                xDat=xDat.Replace("</tr>\r\n ","");
                xDat = xDat.Replace("<tr>\r\n ", "");
                xDat = xDat.Replace("width=\"95px\" ", "");
                xDat = xDat.Replace("width=\"20px\"> ", "");
                xDat = xDat.Replace("width=\"75px\" ", "");
                xDat = xDat.Replace("width=\"100px\" ", "");
                xDat = xDat.Replace("width=\"210px\" ", "");
                xDat = xDat.Replace("colspan=\"2\" ", "");
                xDat = xDat.Replace("colspan=\"3\">", "");
                xDat = xDat.Replace("align=\"left\" class=\"APLI_txt", "");
                xDat = xDat.Replace("      ", "");
                xDat = xDat.Replace("   ", "");
                
                string[] tabla;                
                //Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
                tabla = Regex.Split(xDat, "<td ");

                List<string> _resul = new List<string>();
                for (int i = 0; i < tabla.Length; i++)
                {
                    if (!string.IsNullOrEmpty(tabla[i].Trim()))
                        _resul.Add(tabla[i].Trim());
                }
                if (_resul.Count == 2) //no es valido o algo salio mal
                {
                    _ok = false;
                    _error = "Documento de Identidad no registrado en el SPP.";
                }
                else
                {
                    if (_resul[1].Contains("Consulta de Afiliados del SPP"))
                    {
                        _ok = true;
                    }
                }
                switch (_resul.Count)
                {
                    case 2:
                        state = Resul.NoResul;
                        break;
                    case 41:
                        state = Resul.Ok;
                        break;
                    default:
                        state = Resul.Error;
                        break;
                }

                if (state == Resul.Ok)
                {//hacemos el parseo 
                    tabla[6] = tabla[6].Replace("Actualizado\">", "");
                    tabla[8] = tabla[8].Replace("Actualizado\">", "");
                    tabla[11] = tabla[11].Replace("Actualizado\">", "");
                    tabla[13] = tabla[13].Replace("Actualizado\">", "");
                    tabla[35] = tabla[35].Replace("Actualizado\">", "");
                    tabla[42] = tabla[42].Replace("Actualizado\">", "");
                    tabla[31] = tabla[31].Replace("Actualizado\">", "");
                    tabla[18] = tabla[18].Replace("Campo\">Estado Civil :<span class=\"APLI_txtActualizado\">", "");
                    tabla[18] = tabla[18].Replace("</span>", "");
                    tabla[45] = tabla[45].Replace("Actualizado\">", "");                   
                    tabla[40] = tabla[40].Replace("Actualizado\">", "");
                    tabla[33] = tabla[33].Replace("Actualizado\">", "");
                    tabla[33] = tabla[33].Replace("</td> \r\n ", "");
                    tabla[37] = tabla[37].Replace("Actualizado\">", "");
                    tabla[16] = tabla[16].Replace("Actualizado\">", "");
                    tabla[17] = tabla[17].Replace("Campo\">Sexo :<span class=\"APLI_txtActualizado\">", "");
                    tabla[17] = tabla[17].Replace("</span>", "");
                    tabla[17] = tabla[17].Replace("</td></tr><!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 --><!-- <tr> --><!-- ", "");
                    tabla[47] = tabla[47].Replace("Actualizado\">", "");
                    tabla[29] = tabla[29].Replace("Actualizado\">", "");
                    tabla[29] = tabla[29].Replace("</TD>\r\n ", "");
                    tabla[23] = tabla[23].Replace("Actualizado\">", "");
                    tabla[21] = tabla[21].Replace("Actualizado\">", "");
                    tabla[26] = tabla[26].Replace("colspan=\"3\" Actualizado\">", "");
                   
                    xApellidoPaterno = (string)tabla[6].Trim();
                    xApellidoMaterno= (string)tabla[8].Trim();
                    xPrimerNombre = (string)tabla[11].Trim();
                    xSegundoNombre= (string)tabla[13].Trim();
                    xTipoTrabajador = (string)tabla[31].Trim();
                    xSexo= (string)tabla[17].Trim();
                    xNacionalidad= (string)tabla[23].Trim();
                    xLugarNacimiento = (string)tabla[21].Trim();
                    xLugarResidencia = (string)tabla[26].Trim();
                    xEstadoCivil= (string)tabla[18].Trim();
                    xFechaNacimiento =(string)tabla[16].Trim();
                    xFechaDefuncion = (string)tabla[45].Trim();
                    xFechaProcesoDefuncion = (string)tabla[47].Trim();
                    xOrigenAfiliacion = (string)tabla[29].Trim();
                    xEntidadAfiliacion= (string)tabla[35].Trim();
                    xTipoComisionAfiliacion = (string)tabla[42].Trim();
                    xCodigoAfiliacion = (string)tabla[33].Trim();
                    xFechaIngresoAfiliacion = (string)tabla[37].Trim();
                    xSituacionAfiliacion = (string)tabla[40].Trim();                   
                                       
                }
                if (state == Resul.Ok)
                {
                    _ApellidoPaterno=xApellidoPaterno;
                    _ApellidoMaterno=xApellidoMaterno;
                    _PrimerNombre=xPrimerNombre;    
                    _SegundoNombre=xSegundoNombre;
                    _TipoTrabajador=xTipoTrabajador;
                    _Sexo=xSexo;
                    _Nacionalidad=xNacionalidad;
                    _LugarNacimiento=xLugarNacimiento;
                    _LugarResidencia=xLugarResidencia;
                    _EstadoCivil=xEstadoCivil;
                    _FechaNacimiento=xFechaNacimiento;
                    _FechaDefuncion=xFechaDefuncion;
                    _FechaProcesoDefuncion=xFechaProcesoDefuncion;
                    _OrigenAfiliacion=xOrigenAfiliacion;
                    _EntidadAfiliacion=xEntidadAfiliacion;
                    _TipoComisionAfiliacion=xTipoComisionAfiliacion;
                    _CodigoAfiliacion=xCodigoAfiliacion;
                    _FechaIngresoAfiliacion=xFechaIngresoAfiliacion;
                    _SituacionAfiliacion=xSituacionAfiliacion;                    
                }
                return "Exito!!!";                      
            }
            catch (Exception ex)
            {
                _ok = false;
                _error = _error + ex.Message;
                return _error;
            }
             
        }        
        public string Error
        {
            get
            {
                if (_ok)
                    return string.Empty;
                else
                    return _error;
            }
        }       
    }
}
