using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReporteOrdeCompra
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        //MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet OrdenCompra(Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("cod", cod);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_OrdenCompraRPT");

                set.WriteXml("C:\\XML\\ReporteOrdenCompraRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteCompras(DateTime f1, DateTime f2, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaReporteCompras", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fechaini", f1);
                cmd.Parameters.AddWithValue("fechafin", f2);
                cmd.Parameters.AddWithValue("alma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReporteCompras");

                set.WriteXml("C:\\XML\\dt_ReporteCompras.xml", XmlWriteMode.WriteSchema);
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
