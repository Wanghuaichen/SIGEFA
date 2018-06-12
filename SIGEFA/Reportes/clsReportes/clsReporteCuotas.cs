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
    class clsReporteCuotas
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet CuotasPrestamo(Int32 codPrestamo)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("CuotasPrestamo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1500;
                cmd.Parameters.AddWithValue("codpre", codPrestamo);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_cuotas");
                set.WriteXml("C:\\XML\\CuotasPrestamo.xml", XmlWriteMode.WriteSchema);
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
