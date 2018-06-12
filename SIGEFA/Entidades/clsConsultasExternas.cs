using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;
using System.Data;

namespace SIGEFA.Entidades
{
    public class clsConsultasExternas
    {
        private String sRazonSocial;
        private String sDireccionLegal;

        private String cadhtml = "";
        private String año = "";
        private String mes = "";
        private bool consulta = false;
        private bool rpta = false;

        public String RazonSocial
        {
            get { return sRazonSocial; }
            set { sRazonSocial = value; }
        }
        public String DireccionLegal
        {
            get { return sDireccionLegal; }
            set { sDireccionLegal = value; }
        }

        public DataTable ConsultaTCSunat(DateTime Fecha)
        {
            try
            {
                año = Fecha.ToString("yyyy");
                mes = Fecha.ToString("MM");


                WebBrowser objWebBrowser = new WebBrowser();
                objWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserDocumentCompleted);
                objWebBrowser.Navigate("http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias");

                //Se queda en espera hasta que obtenga respuesta de la consulta
                while (rpta == false)
                {
                    Application.DoEvents();
                }

                //Obtenemos Informacion
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(cadhtml);

                HtmlAgilityPack.HtmlNodeCollection NodesTr = document.DocumentNode.SelectNodes("//table[@class='class=\"form-table\"']//tr");

                if (NodesTr != null)
                {
                    DataTable dt = new DataTable();
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
                    return dt;
                    //dgvTipo.DataSource = dt;
                    //dgvTipo.ReadOnly = true;
                    //dgvTipo.AllowUserToAddRows = false;
                    //dgvTipo.AllowUserToDeleteRows = false;
                    //dgvTipo.AllowUserToOrderColumns = false;
                    //dgvTipo.RowHeadersVisible = false;
                }

                consulta = false;
                rpta = false;
                mes = "";
                año = "";
                cadhtml = "";
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
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
                MessageBox.Show(ex.Message, "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Boolean rucsunat(String codigo)
        {
            try
            {
                if (codigo.Length == 11)
                {
                    String url = "http://www.sunat.gob.pe/w/wapS01Alias?ruc=" + codigo;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Close();
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                        String backstr = sr.ReadToEnd();
                        if (capturardatos(backstr, codigo))
                        {
                            sr.Close();
                            res.Close();
                            return true;
                        }
                        else
                        {
                            sr.Close();
                            res.Close();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No responde el servicio de la SUNAT", "Consulta Sunat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        res.Close();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("EL RUC ingresado no es válido", "Consulta Sunat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                return false;
            }
          

            //String url = "http://www.sunat.gob.pe/w/wapS01Alias?ruc=" + codigo;
            //WebRequest request = WebRequest.Create(url);
            //request.Method = "POST";            
            //Stream dataStream = request.GetRequestStream();            
            //dataStream.Close();
            //WebResponse response = request.GetResponse();          
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);           
            //dataStream = response.GetResponseStream();           
            //StreamReader reader = new StreamReader(dataStream);           
            //string responseFromServer = reader.ReadToEnd();
            //capturardatos(responseFromServer, codigo);
            //Console.WriteLine(responseFromServer);            
            //reader.Close();
            //dataStream.Close();
            //response.Close();           
        }

        private Boolean capturardatos(String resp, String cod)
        {
            resp = resp.Replace("     ", " ");
            resp = resp.Replace("    ", " ");
            resp = resp.Replace("   ", " ");
            resp = resp.Replace("  ", " ");
            resp = resp.Replace("( ", "(");
            resp = resp.Replace(" )", ")");

            String[] stringSeparators = new String[] { "<small>" };
            String[] words = resp.Split(stringSeparators, StringSplitOptions.None);

            String word1 = String.Empty;
            String word2 = String.Empty;
            String word3 = String.Empty;
            String word4 = String.Empty;

            if (words[0].Contains("Resultado"))
            {
                foreach (String word in words)
                {
                    if (word.Contains("<b>N&#xFA;mero Ruc. </b> " + cod + " - "))
                    {
                        word1 = word.Replace("<b>N&#xFA;mero Ruc. </b> " + cod + " - ", "");
                        word1 = word1.Replace(" <br/></small>", "");
                    }
                    if (word.Contains("Estado."))
                    {
                        word2 = word.Replace("<b>Estado.</b>", "");
                        word2 = word2.Replace("</small><br/>", "");

                    }
                    if (word.Contains("Direcci"))
                    {
                        word3 = word.Replace("<b>Direcci&#xF3;n.</b><br/>", "");
                        word3 = word3.Replace("</small><br/>", "");

                    }
                    if (word.Contains("Situaci"))
                    {
                        word4 = word.Replace("Situaci&#xF3;n.<b> ", "");
                        word4 = word4.Replace("</b></small><br/>", "");
                    }                    
                }
                String RazSoc = word1.ToString();
                String Est = word2.ToString();
                String Dir = word3.ToString();
                String Con = word4.ToString();

                RazSoc = RazSoc.Replace("&#209;", "Ñ");
                RazSoc = RazSoc.Replace("&#xD1;", "Ñ");
                RazSoc = RazSoc.Replace("&#193;", "Á");
                RazSoc = RazSoc.Replace("&#201;", "É");
                RazSoc = RazSoc.Replace("&#205;", "Í");
                RazSoc = RazSoc.Replace("&#211;", "Ó");
                RazSoc = RazSoc.Replace("&#218;", "Ú");
                RazSoc = RazSoc.Replace("&#xC1;", "Á");
                RazSoc = RazSoc.Replace("&#xC9;", "É");
                RazSoc = RazSoc.Replace("&#xCD;", "Í");
                RazSoc = RazSoc.Replace("&#xD3;", "Ó");
                RazSoc = RazSoc.Replace("&#xDA;", "Ú");

                RazSoc = RazSoc.Substring(0, RazSoc.Length - 3);

                Dir = Dir.Replace("&#209;", "Ñ");
                Dir = Dir.Replace("&#xD1;", "Ñ");
                Dir = Dir.Replace("&#193;", "Á");
                Dir = Dir.Replace("&#201;", "É");
                Dir = Dir.Replace("&#205;", "Í");
                Dir = Dir.Replace("&#211;", "Ó");
                Dir = Dir.Replace("&#218;", "Ú");
                Dir = Dir.Replace("&#xC1;", "Á");
                Dir = Dir.Replace("&#xC9;", "É");
                Dir = Dir.Replace("&#xCD;", "Í");
                Dir = Dir.Replace("&#xD3;", "Ó");
                Dir = Dir.Replace("&#xDA;", "Ú");

                Est = Est.Substring(0, Est.Length - 6);
                Con = Con.Substring(0, Con.Length - 3);
                Dir = Dir.Substring(0, Dir.Length - 3);

                RazonSocial = HttpUtility.HtmlDecode(RazSoc);
                DireccionLegal = Dir;
                return true;
            }
            else if (words[0].Contains("Mensaje"))
            {
                MessageBox.Show("El RUC ingresado no existe en la base de datos de la Sunat", "Consulta Sunat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return false;
            }
            
        }

        public void limpiar(Control.ControlCollection Coleccion)
        {            
            foreach (Control c in Coleccion)
            {               
                if (c.Enabled == true && c is TextBox)
                {
                    c.Text = "";                 
                }
                if (c.Enabled == true && c is ComboBox)
                {
                    ComboBox com = (ComboBox)c;
                    com.SelectedIndex = -1;
                }
                if (c.Enabled == true && c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;
                    ch.Checked = false;
                }
                if (c.HasChildren)
                {
                    limpiar(c.Controls);
                }
            }
        }

        public void sololectura(Control.ControlCollection Coleccion)
        {
            foreach (Control c in Coleccion)
            {
                if (c.Enabled == true && c is TextBox)
                {
                    TextBox tx = (TextBox)c;
                    tx.ReadOnly = true;
                }
                if (c.Enabled == true && c is ComboBox)
                {
                    ComboBox com = (ComboBox)c;
                    com.Enabled = false;
                }
                if (c.Enabled == true && c is CheckBox)
                {
                    CheckBox ch = (CheckBox)c;
                    ch.Enabled = false;
                }
                if (c.Enabled == true && c is Button)
                {
                    Button bt = (Button)c;
                    bt.Enabled = false;
                }
                if (c.HasChildren)
                {
                    sololectura(c.Controls);
                }
            }
        }

        public Int32 GetIDPaperSize(String PrinterName, String PaperSizeName)
        {
            System.Drawing.Printing.PrintDocument pdprint = new System.Drawing.Printing.PrintDocument();
            pdprint.PrinterSettings.PrinterName = PrinterName;
            Int32 PaperSizeID = 0;
            foreach (System.Drawing.Printing.PaperSize ps in pdprint.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName == PaperSizeName)
                {
                    PaperSizeID = ps.RawKind;
                    break;
                }
            }
            return PaperSizeID;
        }
    }
}
