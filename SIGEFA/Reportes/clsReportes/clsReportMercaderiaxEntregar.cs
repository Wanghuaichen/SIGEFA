using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReportMercaderiaxEntregar
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet ReportMercaderiaEntregar(DateTime fecha1, DateTime fecha2, Int32 CodAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportMercaderiaPorEntregar", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fecini", fecha1);
                cmd.Parameters.AddWithValue("fecfin", fecha2);
                cmd.Parameters.AddWithValue("alma", CodAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_MercaderiaxEntregar");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\MercaderiaxEntregarRPT.xml", XmlWriteMode.WriteSchema);
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
