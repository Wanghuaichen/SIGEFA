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
    class clsReporteVentaMesArticulo
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet Reporte(Int32 mes1, Int32 mes2, Int32 forma, Int32 cri,String refe,Boolean todo, Int32 moned, Int32 codAlmacen, Int32 annio)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteVentaMesArticulo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("mes1", mes1);
                cmd.Parameters.AddWithValue("mes2", mes2);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("cri", cri);
                cmd.Parameters.AddWithValue("refe", refe);
                cmd.Parameters.AddWithValue("todo", todo);
                cmd.Parameters.AddWithValue("moned", moned);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("annio", annio);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentaMesArticuloRPT.xml", XmlWriteMode.WriteSchema);
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
