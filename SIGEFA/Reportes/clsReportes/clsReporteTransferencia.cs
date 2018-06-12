using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Conexion;
using System.Data;
using MySql.Data.MySqlClient;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReporteTransferencia
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet RptTransferencia(DateTime fecha1, DateTime fecha2, Int32 codalmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteDeTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1500;
                cmd.Parameters.AddWithValue("codalma", codalmacen);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_transferenciaProductos");
                set.WriteXml("C:\\XML\\ReporteDeTransferencia.xml", XmlWriteMode.WriteSchema);
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
