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
    class clsReporteArqueo
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet Arqueo(Int32 codArque)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteListaArqueo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codArque", codArque);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ListaArqueoRPT.xml", XmlWriteMode.WriteSchema);
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
