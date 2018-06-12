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
    class clsReporteVentxCliente
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet Reporte(Int32 emp, DateTime fecha1, DateTime fecha2, Int32 forma, Boolean todoCli, Boolean todoArt, String refe, String cod, Int32 moned)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportVentxClient", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", emp);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("todoCli", todoCli);
                cmd.Parameters.AddWithValue("todoArt", todoArt);
                cmd.Parameters.AddWithValue("refe", refe);
                cmd.Parameters.AddWithValue("cod", cod);
                cmd.Parameters.AddWithValue("moned", moned);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentaxClienteDiaRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        
        public DataSet Reporte22(Int32 codSu, DateTime fecha1, DateTime fecha2, Int32 codVen, String codArticulo1, String codArticulo2, Boolean todoArt, Boolean unArt)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportVentxVendedorxArti", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", codSu);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("cod", codVen);
                cmd.Parameters.AddWithValue("rango1", codArticulo1);
                cmd.Parameters.AddWithValue("rango2", codArticulo2);
                cmd.Parameters.AddWithValue("todoArt", todoArt);
                cmd.Parameters.AddWithValue("unArt", unArt);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentaxArticuloxVendedor.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        //public DataSet Reporte23(Int32 codSu, DateTime fecha1, DateTime fecha2, Int32 codVen)
        //{
        //    try
        //    {
        //        set = new DataSet();
        //        con.conectarBD();
        //        cmd = new MySqlCommand("ReportVentxVendedorxArticulo2", con.conector);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 15;
        //        cmd.Parameters.AddWithValue("empre", codSu);
        //        cmd.Parameters.AddWithValue("fecha1", fecha1);
        //        cmd.Parameters.AddWithValue("fecha2", fecha2);
        //        cmd.Parameters.AddWithValue("cod", codVen);
        //        adap = new MySqlDataAdapter(cmd);
        //        adap.Fill(set);
        //        set.WriteXml("C:\\XML\\VentaxArticuloxVendedor1.xml", XmlWriteMode.WriteSchema);
        //        return set;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        //}

        public DataSet ReporteVentasCliente(Int32 codSu, DateTime fecha1, DateTime fecha2, Int32 forma, Boolean todoCli, String refe, Int32 moned)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteVentasxCliente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("empre", codSu);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("todoCli", todoCli);
                cmd.Parameters.AddWithValue("refe", refe);
                cmd.Parameters.AddWithValue("moned", moned);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VentasxCliente.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
