using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsNotasCreditoDebitoVenta
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet ReportNotaDebitoVenta(Int32 cod, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportNotaDebitoVenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codventa", cod);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_NotaDebitoVenta");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\NotaDebitoVentaRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReportNotaCreditoVenta(Int32 cod, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportNotaCreditoVenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codnota", cod);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_NotaCreditoVenta");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\NotaCreditoVentaRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
