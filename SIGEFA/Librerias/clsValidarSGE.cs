using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace SIGEFA.Librerias
{
    public class clsValidarSGE
    {
        public Boolean Valida = true;
        public static Boolean internet = true;
        Ping pinguin = new Ping();
        Int32 timeout = 3;
        String ips = "8.8.8.8";

        public bool AccesoInternet()
        {
            try
            {
                if (pinguin.Send(ips, timeout).Status == IPStatus.Success)
                {
                    internet = true;
                    return true;
                }
                else
                {
                    internet = false;
                    return false;
                }

                // System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");

            }
            catch (Exception)
            {
                internet = false;
                return false;
            }
        }
        public void KeyTab(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }
        public bool esHoraValida(string hora)
        {
            Regex r = new Regex(@"([0-1][0-9]|2[0-3]):[0-5][0-9]");
            Match m = r.Match(hora);
            return m.Success;
        }
        public int ObtieneNumeroSemana(DateTime fecha)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int numsemana = ciCurr.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return numsemana;
        }
        public void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            //***********************************************
        }
        public void ActivaCajas(Control.ControlCollection Coleccion)
        {
            foreach (Control a in Coleccion)
            {
                if (a.Enabled == false && a is TextBox)
                {
                    TextBox tx = (TextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = true;
                    tx.Focus();
                }
                if (a.Enabled == false && a is RichTextBox)
                {
                    RichTextBox tx = (RichTextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = true;
                    tx.Focus();
                }
                if (a.Enabled == false && a is MaskedTextBox)
                {
                    MaskedTextBox tx = (MaskedTextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = true;
                    tx.Focus();
                }
                if (a.Enabled == false && a is ComboBox)
                {
                    ComboBox cb = (ComboBox)a;
                    cb.SelectedIndex = -1;
                    cb.Enabled = true;
                }
                if (a.Enabled == false && a is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)a;
                    dt.Enabled = true;
                }
                if (a.Enabled == false && a is CheckedListBox)
                {
                    CheckedListBox chk = (CheckedListBox)a;
                    while (chk.CheckedIndices.Count > 0)
                    {
                        chk.SetItemChecked(chk.CheckedIndices[0], false);
                    }
                    chk.Enabled = true;
                }
                if (a.HasChildren)
                {
                    ActivaCajas(a.Controls);
                }
            }
        }
        public void Limpiar(Control.ControlCollection Coleccion)
        {
            foreach (Control a in Coleccion)
            {
                if (a.Enabled == true && a is TextBox)
                {
                    TextBox tx = (TextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = false;
                    tx.Focus();
                }
                if (a.Enabled == true && a is RichTextBox)
                {
                    RichTextBox tx = (RichTextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = false;
                    tx.Focus();
                }
                if (a.Enabled == true && a is MaskedTextBox)
                {
                    MaskedTextBox tx = (MaskedTextBox)a;
                    tx.BackColor = Color.White;
                    tx.Text = "";
                    tx.Enabled = false;
                    tx.Focus();
                }
                if (a.Enabled == true && a is ComboBox)
                {
                    ComboBox cb = (ComboBox)a;
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                    cb.Enabled = false;
                }
                if (a.Enabled == true && a is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)a;
                    dt.Format = DateTimePickerFormat.Long;
                    dt.CustomFormat = "";
                    dt.Enabled = false;
                }
                if (a.Enabled == true && a is CheckedListBox)
                {
                    CheckedListBox chk = (CheckedListBox)a;
                    while (chk.CheckedIndices.Count > 0)
                    {
                        chk.SetItemChecked(chk.CheckedIndices[0], false);
                    }
                    chk.Enabled = false;
                }
                if (a.HasChildren)
                {
                    Limpiar(a.Controls);
                }
            }
        }
        public void LimpiarDataGrid(DataGridView grilla)
        {
            DataTable dt = (DataTable)grilla.DataSource;
            dt.Clear();
        }
        public void ValidarDatos(Control.ControlCollection Coleccion)
        {
            Valida = true;
            foreach (Control c in Coleccion)
            {
                if (c.Enabled == true && c.Text == "" && c is TextBox)
                {
                    TextBox tx = (TextBox)c;
                    tx.BackColor = Color.LightPink;
                    Valida = false;
                    tx.Focus();
                    //c.BackColor = Color.LightPink;
                    //Valida = false;
                    //c.Focus();                        
                }
                if (c.Enabled == true && c.Text == "" && c is RichTextBox)
                {
                    RichTextBox tx = (RichTextBox)c;
                    tx.BackColor = Color.LightPink;
                    Valida = false;
                    tx.Focus();
                }
                if (c.Enabled == true && c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    if (cb.SelectedIndex == -1)
                    {
                        //cb.BackColor = Color.LightBlue;
                        Valida = false;
                        cb.Focus();
                    }
                }

                if (c.HasChildren)
                {
                    if (Valida) { ValidarDatos(c.Controls); }
                }
            }
        }
        public void Numeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        public void MontoTope(object sender, KeyPressEventArgs e, Double Monto)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (Convert.ToDouble((sender as TextBox).Text) <= Monto)
            {
                e.Handled = true;
            }
        }
        public void telefono(KeyPressEventArgs e)
        {
            String Aceptados = "0123456789-" + Convert.ToChar(8);

            if (Aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }
        public void enteros(KeyPressEventArgs e)
        {
            String Aceptados = "0123456789" + Convert.ToChar(8);

            if (Aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }       
        public void letras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else e.Handled = false;
        }
        public void SoloLectura(Control.ControlCollection Coleccion)
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
                if (c.Enabled == true && c is NumericUpDown)
                {
                    NumericUpDown nud = (NumericUpDown)c;
                    nud.Enabled = false;
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
                    SoloLectura(c.Controls);
                }
            }
        }
        public Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void NumerosEnteros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void NumerosDecimales(KeyPressEventArgs e, TextBox t)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < t.Text.Length; i++)
            {
                if (t.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 3)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        public void SoloNumerosDoc(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }
        public void decimalesNegativos(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > 0)
            {
                e.Handled = true;
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
