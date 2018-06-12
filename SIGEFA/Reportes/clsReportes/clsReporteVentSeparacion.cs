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
    class clsReporteVentSeparacion
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet Reporte(Int32 emp, DateTime fecha1, DateTime fecha2, Int32 forma, Int32 suc, Int32 almacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportVentSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", emp);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("su", suc);
                cmd.Parameters.AddWithValue("alma", almacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentaSeparacionRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteSeparacion(Int32 alma, DateTime fecha1, DateTime fecha2, Int32 estado)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraVentas_Xseparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codalma", alma);
                cmd.Parameters.AddWithValue("fechaini", fecha1);
                cmd.Parameters.AddWithValue("fechafin", fecha2);                
                cmd.Parameters.AddWithValue("estad", estado);
           
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ListaVentaSeparacionRPT.xml", XmlWriteMode.WriteSchema);
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
