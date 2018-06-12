using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HtmlAgilityPack;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Data;
using System.Windows.Forms;


namespace SIGEFA.Librerias
{
    public class clsTipoCambioSunat
    {
        private string url = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias";
        private string cadhtml = "";
        private string año = "";
        private string mes = "";

        private bool consulta = false;
        private bool rpta = false;

        //private CookieContainer myCookie;

        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                WebBrowser webBrowser = ((WebBrowser)sender);
                System.Windows.Forms.HtmlDocument html = webBrowser.Document;
                string sTitle = html.Title;

                foreach (HtmlElement select in html.GetElementsByTagName("select"))
                {
                    if (select.Name.Equals("anho"))
                    {
                        select.Focus();
                        select.SetAttribute("value", año);
                        select.InvokeMember("onchange");
                        select.RemoveFocus();
                    }

                    if (select.Name.Equals("mes"))
                    {
                        select.Focus();
                        select.SetAttribute("value", mes);
                        select.InvokeMember("onchange");
                        select.RemoveFocus();
                    }
                }

                foreach (HtmlElement button in html.GetElementsByTagName("input"))
                {
                    if (button.Name.Equals("B1"))
                    {
                        cadhtml = webBrowser.DocumentText;
                        if (consulta == true)
                        {
                            rpta = true;
                            return;
                        }
                        button.RaiseEvent("onclick");
                        consulta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AccesoInternet() 
        {
            try {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public DataTable ConsultaTCSunat(DateTime fecha)
        {  
            año = fecha.ToString("yyyy");
            mes = fecha.ToString("MM");
            DataTable dt = new DataTable();
            WebBrowser objWebBrowser = new WebBrowser();            
            //WebBrowserDocumentCompletedEventArgs webero = new WebBrowserDocumentCompletedEventArgs(url);
            objWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserDocumentCompleted);
            objWebBrowser.Navigate(url);
            
               //Se queda en espera hasta que obtenga respuesta de la consulta
            while (rpta == false && AccesoInternet())
            {
                Application.DoEvents();
            }
            //if (rpta == false) Application.DoEvents();

                //Obtenemos Informacion
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(cadhtml);

            HtmlAgilityPack.HtmlNodeCollection NodesTr = document.DocumentNode.SelectNodes("//table[@class='class=\"form-table\"']//tr");
            if (NodesTr != null)
            {                    
               dt.Columns.Add("Día", typeof(String));
               dt.Columns.Add("Compra", typeof(String));
               dt.Columns.Add("Venta", typeof(String));

               int iNumFila = 0;
               foreach (HtmlNode Node in NodesTr)
               {
                    if (iNumFila > 0)
                    {
                       int iNumColumna = 0;
                       DataRow dr = dt.NewRow();
                       foreach (HtmlNode subNode in Node.Elements("td"))
                            {
                           if (iNumColumna == 0) dr = dt.NewRow();
                                                                                
                           string sValue = subNode.InnerHtml.ToString().Trim();
                           sValue = System.Text.RegularExpressions.Regex.Replace(sValue, "<.*?>", " ");
                           dr[iNumColumna] = sValue;
                           
                           iNumColumna++;

                           if (iNumColumna == 3)
                           {
                             dt.Rows.Add(dr);
                             iNumColumna = 0;
                           }
                        }
                     }
                     iNumFila++;
                }                
                dt.AcceptChanges();                    
            }
            consulta = false;
            rpta = false;
            mes = "";
            año = "";
            cadhtml = ""; 
            return dt;              
        }
    }
}
