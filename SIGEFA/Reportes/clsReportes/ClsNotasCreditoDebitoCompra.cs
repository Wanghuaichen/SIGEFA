using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class ClsNotasCreditoDebitoCompra
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet ReportNotaDebitoCompra(Int32 cod, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportNotaDebitoCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codnota", cod);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_NotaDebitoCompra");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\NotaDebitoCompraRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReportNotaCreditoCompra(Int32 cod, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportNotaCreditoCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codnota", cod);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_NotaCreditoCompra");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\NotaCreditoCompraRPT.xml", XmlWriteMode.WriteSchema);
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
