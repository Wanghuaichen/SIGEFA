using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReporteInformeSucursal
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet ReportVentasContCredSucursal(DateTime fecha1, DateTime fecha2, Int32 CodSucursal)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportResumenVentas", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fechaini", fecha1);
                cmd.Parameters.AddWithValue("fechafin", fecha2);
                cmd.Parameters.AddWithValue("codsucur", CodSucursal);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ResumenVentas");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\ResumenVentasRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReportCobranzaSucursal(DateTime fecha1, DateTime fecha2, Int32 CodSucursal)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportResumenCobranzas", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fechaini", fecha1);
                cmd.Parameters.AddWithValue("fechafin", fecha2);
                cmd.Parameters.AddWithValue("codsucur", CodSucursal);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ResumenCobranza");

                //---------------------------------------------------------------

                //cmd = new MySqlCommand("ListaExtensiones", con.conector);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 15;
                //cmd.Parameters.AddWithValue("cod", ord);
                //adap = new MySqlDataAdapter(cmd);
                //adap.Fill(set, "dt_extensiones");


                set.WriteXml("C:\\XML\\ResumenCobranzaRPT.xml", XmlWriteMode.WriteSchema);
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
