using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Drawing;
using System.Net;
using System.IO;
using System.Web;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace SIGEFA.Librerias
{

    public class EsSalud
    {
        public enum Resul
        {
            /// <summary>
            /// Se encontro la persona
            /// </summary>
            Ok = 0,
            /// <summary>
            /// No se encontro la persona
            /// </summary>
            NoResul = 1,
            /// <summary>
            /// la imagen capcha no es valida
            /// </summary>
            ErrorCapcha = 2,
            /// <summary>
            /// Error no especificado
            /// </summary>
            Error = 3,
        }
        private Resul state;
        private string _Nombres;
        private string _ApePaterno;
        private string _ApeMaterno;
        private string _fechanac;
        private string _TipoAsegurado;
        private string _Autogenerado;
        private string _TipoSeguro;
        private string _CentroAsistencial;
        private string _DireccionCA;
        private string _AfiliadoA;
        private string _desde;
        private string _hasta;

        private bool _ok;
        private string _error;
        private string DNI;

        private CookieContainer myCookie;

        #region Propiedades
        public string FechaNac { get { return _fechanac; } }
        public string TipoAsegurado { get { return _TipoAsegurado; } }
        public string Autogenerado { get { return _Autogenerado; } }
        public string TipoSeguro { get { return _TipoSeguro; } }
        public string CentroAsistencial { get { return _CentroAsistencial; } }
        public string DireccionCA { get { return _DireccionCA; } }
        public string AfiliadoA { get { return _AfiliadoA; } }
        public string Desde { get { return _desde; } }
        public string Hasta { get { return _hasta; } }

        /// <summary>
        /// Devuelve la imagen para el reto capcha
        /// </summary>
        public Image GetCapcha { get { return ReadCapcha(); } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// de la persona caso contrario devuelve ""
        /// </summary>
        public string Nombres { get { return _Nombres; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
        /// de la persona caso contrario devuelve ""
        public string ApePaterno { get { return _ApePaterno; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Materno
        /// de la persona caso contrario devuelve ""
        public string ApeMaterno { get { return _ApeMaterno; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public Resul GetResul { get { return state; } }

        #endregion

        #region Constructor

        public EsSalud()
        {
            try
            {
                myCookie = null;
                myCookie = new CookieContainer();

                //Permitir SSL
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                ReadCapcha();
            }
            catch (Exception)
            {
                _ok = false;
                _error = "Error al procesar informacion de ESSALUD";
            }
        }

        #endregion
        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
        private Image ReadCapcha()
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://ww4.essalud.gob.pe:7777/acredita/captcha.jpg");

                myWebRequest.CookieContainer = myCookie;

                myWebRequest.Proxy = null;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myImgStream = myWebResponse.GetResponseStream();

                //myWebResponse.Close();

                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numDni"></param>
        /// <param name="ImgCapcha"></param>

        private bool ParseInfoEsSalud(List<string> _result)
        {
            try
            {
                for (int i = 0; i < _result.Count; i++)
                {
                    //Console.WriteLine(_result[i].ToString());
                    switch (_result[i])
                    {
                        case "Asegurados":
                            _ok = false;
                            _error = "No se encontraron registros para las siguientes condiciones: Número de DNI " + DNI;
                            break;
                        case "Nombres":
                            _ApePaterno = _result[i + 1];
                            _ApeMaterno = _result[i + 2];
                            _Nombres = _result[i + 3] + " " + _result[i + 4];
                            break;
                        case "Nacimiento":
                            _fechanac = _result[i + 1];
                            break;
                        case "Asegurado":
                            if (_TipoAsegurado != null)
                            {
                                break;
                            }
                            else
                            {
                                _TipoAsegurado = _result[i + 1];
                            };
                            break;
                        //case "input type='hidden' name='auto'  value='":
                        //    _Autogenerado = _result[i + 1];
                        //    break;
                        case "Seguro":
                            if (_TipoSeguro != null)
                            {
                                break;
                            }
                            else
                            {
                                _TipoSeguro = _result[i + 1];
                            }

                            break;
                        case "Asistencial":
                            if (_CentroAsistencial != null)
                            {
                                break;
                            }
                            else
                            {
                                _CentroAsistencial = _result[i + 1] + " " + _result[i + 2];
                            }
                            break;
                        case "Desde":
                            _desde = _result[i + 1];
                            break;
                        case "C.A.":
                            if (_DireccionCA != null)
                            {
                                break;
                            }
                            else
                            {
                                _DireccionCA = _result[i + 1] + " " + _result[i + 2] + " " + _result[i + 3] + " " + _result[i + 4];
                            }
                            break;
                        case "Hasta":
                            _hasta = _result[i + 1];
                            break;
                        case "Afiliado(a)":
                            _AfiliadoA = _result[i + 2];
                            break;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                _ok = false;
                _error = "Error al procesar informacion de sunat(Funcion ParseInfo)";
            }
            return false;
        }

        public void ConsultaEsSalud(string numDni, string ImgCapcha)
        {
            try
            {
                string myUrl = String.Format("http://ww4.essalud.gob.pe:7777/acredita/servlet/Ctrlwacre?pg=1&ll=Libreta+Electoral%2FDNI&td=1&nd={0}&submit=Consultar&captchafield_doc={1}", numDni, ImgCapcha);
                DNI = numDni;
                                       
                //string myUrl = "http://ww4.essalud.gob.pe:7777/acredita/servlet/Ctrlwacre?pg=1&ll=Libreta+Electoral%2FDNI&td=1&nd=" + numDni + "&submit=Consultar&captchafield_doc=" + ImgCapcha;
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                //myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;
            
                //myWebRequest.Method = "POST";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myStream);
                             
                string _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
                //System.Windows.Forms.MessageBox.Show(_WebSource);
                #region AutoGENERADO HIDDEN           
                HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();                
                doc.LoadHtml(_WebSource);
                var node = doc.DocumentNode.SelectSingleNode("//input[@name='auto']");                
                if (node != null)
                {
                    string text = node.OuterHtml;
                    _Autogenerado = text.Substring(40, 15);
                    //System.Windows.Forms.MessageBox.Show(_Autogenerado);
                }
                #endregion

                string strRegexScript = @"(?m)<body[^>]*>(\w|\W)*?</body[^>]*>";
                string strRegex = @"<[^>]*>";                
                string strMatchScript = string.Empty;
                string strWholeHtml = string.Empty;
                strWholeHtml = _WebSource;
                Match matchText = Regex.Match(strWholeHtml, strRegexScript, RegexOptions.IgnoreCase);
                strMatchScript = matchText.Groups[0].Value;
                string strPureText = Regex.Replace(strMatchScript, strRegex ,string.Empty, RegexOptions.ExplicitCapture);

                strPureText = strPureText.Replace(Environment.NewLine, " ");
                string[] _split = strPureText.Split(new char[] { });

                List<string> _resul = new List<string>();
                //System.Windows.Forms.MessageBox.Show(strPureText);
                //quitamos todos los caracteres nulos
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }
                ParseInfoEsSalud(_resul);
                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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
