using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


namespace SIGEFA.Conexion
{
    class clsConexionMysql
    {
        public MySqlConnection conector = null;
        public static String sConex = ConfigurationManager.ConnectionStrings["ConnNegocio"].ConnectionString;
        //public static String sConex = ConfigurationManager.ConnectionStrings["fiovizabdremoto"].ConnectionString;

        //public static String sConex = ConfigurationManager.ConnectionStrings["connLaptopcarlos"].ConnectionString;
        //public static String sConex = ConfigurationManager.ConnectionStrings["fioviza"].ConnectionString;
        //public static String sConex = ConfigurationManager.ConnectionStrings["fioviza1"].ConnectionString;
        //public static String sConex = ConfigurationManager.ConnectionStrings["connLaptopcarlosfioviza"].ConnectionString;

        //String constring = "server=localhost;user=root;pwd='13101983';database=bdsigefa;Port=3308";        

        public void GeneraraBackup(String file)
        {            
            try
            {
                //MySqlConnection conn = new MySqlConnection(sConex);
                //MySqlCommand cmd = new MySqlCommand();
                //MySqlBackup mb = new MySqlBackup(cmd);
                //cmd.Connection = conn;
                //conn.Open();
                //mb.ExportToFile(file);
                //conn.Close();
                using (MySqlConnection conn = new MySqlConnection(sConex))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ImportarBackup(String file)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(sConex))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("La importación de datos se realizó con ÉXITO!!!");            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public MySqlConnection conectarBD()
        {
            try
            {
                conector = new MySqlConnection(sConex);
                conector.Open();
                return conector;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MySqlConnection desconectarBD()
        {
            conector.Close(); return conector;
        }

        public String LocalIPAddress()
        {
            IPHostEntry host;
            String localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    
    }
}
