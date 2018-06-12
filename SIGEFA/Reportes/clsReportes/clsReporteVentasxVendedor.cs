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
    class clsReporteVentasxVendedor
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet Reporte(Int32 emp, DateTime fecha1, DateTime fecha2, Int32 forma, Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportVentxVendedor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", emp);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("cod", cod);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentaxVendedorDiaRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet ReporteUtilidad(Int32 emp, DateTime fecha1, DateTime fecha2, Int32 forma, Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportVentasUtilidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", emp);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);              
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\UtilidadVentas.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Utilidad3(DateTime fecha1, DateTime fecha2, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                cmd = new MySqlCommand("UtilidadProductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_utilidadnetaProductos");

                set.WriteXml("C:\\XML\\UtilidadnetaProductos.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        //*************AGREGADO PARA LOS REPORTES DE TODOS LOS MOVIMIENTOS*****************

        public DataSet ReporteCompras(DateTime fecha1, DateTime fecha2, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                cmd = new MySqlCommand("ReporteCompras", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReporteCompras");

                set.WriteXml("C:\\XML\\ReporteCompras.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet ReporteNotasIngreso(DateTime fecha1, DateTime fecha2, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                cmd = new MySqlCommand("ReporteNIngresos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReporteNIngresos");

                set.WriteXml("C:\\XML\\ReporteNIngresos.xml", XmlWriteMode.WriteSchema);
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
