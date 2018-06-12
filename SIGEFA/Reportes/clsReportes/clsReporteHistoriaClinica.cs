using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Conexion;
using MySql.Data.MySqlClient;
using System.Data;

namespace SIGEFA.Reportes.clsReportes
{
    public class clsReporteHistoriaClinica
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet HistoriaClinica(Int32 CodHistoria)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteHistoriaClinica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1500;
                cmd.Parameters.AddWithValue("_historiaid", CodHistoria);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_historia");
                set.WriteXml("C:\\XML\\HistoriaClinica.xml", XmlWriteMode.WriteSchema);
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
