using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SIGEFA.Entidades
{
    class clsValidar
    {
        public void KeyTab(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

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
        public void SOLONumeros(object sender, KeyPressEventArgs e)
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
        public void SOLONumerosDoc(object sender, KeyPressEventArgs e)
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
        //f(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))

        public void letras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else e.Handled = false;
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

        public String Encode(String chaine)
        {

            int ind = 1;
            int checksum = 0;
            int mini;
            int dummy;
            bool tableB;
            String code128;
            int longueur;

            code128 = "";
            longueur = chaine.Length;

            if (longueur == 0)
            {
                Console.WriteLine("\n chaine vide");
            }
            else
            {
                for (ind = 0; ind < longueur; ind++)
                {
                    if ((chaine[ind] < 32) || (chaine[ind] > 126))
                    {
                        Console.WriteLine("\n chaine invalide");
                    }
                }
            }

            tableB = true;
            ind = 0;

            while (ind < longueur)
            {
                if (tableB == true)
                {
                    if ((ind == 0) || (ind + 3 == longueur - 1))
                    {
                        mini = 4;
                    }
                    else
                    {
                        mini = 6;
                    }

                    mini = mini - 1;

                    if ((ind + mini) <= longueur - 1)
                    {
                        while (mini >= 0)
                        {
                            if ((chaine[ind + mini] < 48) || (chaine[ind + mini] > 57))
                            {
                                Console.WriteLine("\n exit");
                                break;
                            }
                            mini = mini - 1;
                        }
                    }

                    if (mini < 0)
                    {
                        if (ind == 0)
                        {
                            code128 = Char.ToString((char)205);

                        }
                        else
                        {
                            code128 = code128 + Char.ToString((char)199);
                        }
                        tableB = false;
                    }
                    else
                    {

                        if (ind == 0)
                        {
                            code128 = Char.ToString((char)204);
                        }
                    }
                }

                if (tableB == false)
                {
                    mini = 2;
                    mini = mini - 1;
                    if (ind + mini < longueur)
                    {
                        while (mini >= 0)
                        {

                            if (((chaine[ind + mini]) < 48) || ((chaine[ind]) > 57))
                            {
                                break;
                            }
                            mini = mini - 1;
                        }
                    }
                    if (mini < 0)
                    {
                        dummy = Int32.Parse(chaine.Substring(ind, 2));

                        Console.WriteLine("\n  dummy ici : " + dummy);

                        if (dummy < 95)
                        {
                            dummy = dummy + 32;
                        }
                        else
                        {
                            dummy = dummy + 100;
                        }
                        code128 = code128 + (char)(dummy);

                        ind = ind + 2;
                    }
                    else
                    {
                        code128 = code128 + Char.ToString((char)200);
                        tableB = true;
                    }
                }
                if (tableB == true)
                {

                    code128 = code128 + chaine[ind];
                    ind = ind + 1;
                }
            }

            for (ind = 0; ind <= code128.Length - 1; ind++)
            {
                dummy = code128[ind];
                Console.WriteLine("\n  et voila dummy : " + dummy);
                if (dummy < 127)
                {
                    dummy = dummy - 32;
                }
                else
                {
                    dummy = dummy - 100;
                }
                if (ind == 0)
                {
                    checksum = dummy;
                }
                checksum = (checksum + (ind) * dummy) % 103;
            }

            if (checksum < 95)
            {
                checksum = checksum + 32;
            }
            else
            {
                checksum = checksum + 100;
            }
            code128 = code128 + Char.ToString((char)checksum)
                    + Char.ToString((char)206);

            return code128;



        }
    }
}
