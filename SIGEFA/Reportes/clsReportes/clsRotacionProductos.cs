using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsRotacionProductos
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet ReportRotacionProductos(Boolean Alma, Boolean Cri, DateTime fecha1, DateTime fecha2, Int32 mes1, Int32 mes2, String Annio,
               Int32 codAlma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportRotacionProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("alma", Alma);
                cmd.Parameters.AddWithValue("cri", Cri);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("mes1", mes1);
                cmd.Parameters.AddWithValue("mes2", mes2);
                cmd.Parameters.AddWithValue("annio", Annio);
                cmd.Parameters.AddWithValue("codalma", codAlma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_RotacionProducto");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\RotacionProductoRPT.xml", XmlWriteMode.WriteSchema);
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
