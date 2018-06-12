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
    class clsReporteKardex
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet kardex(DateTime fecha1, DateTime fecha2,int codPro, int codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteKardex", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codPro", codPro);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_kardex");
                set.WriteXml("C:\\XML\\kardexRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet StockPorAgotar(Int32 tipo, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosStockMin", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_kardex");
                set.WriteXml("C:\\XML\\StockPorAgotarRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet kardex4(DateTime fecha1, DateTime fecha2, Boolean tod, String refe, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteKardex4", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Int32.MaxValue;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("todo", tod);
                cmd.Parameters.AddWithValue("ref", refe);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_kardex4");
                set.WriteXml("C:\\XML\\kardexRPT4.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Utilidad(DateTime fecha1, DateTime fecha2, Int32 codalma, Int32 codSucur)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                /* cmd = new MySqlCommand("ReporteUtilidad", con.conector);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.CommandTimeout = 250;
                 cmd.Parameters.AddWithValue("fecha1", fecha1);
                 cmd.Parameters.AddWithValue("fecha2", fecha2);
                 cmd.Parameters.AddWithValue("codalma", codalma);
                 adap = new MySqlDataAdapter(cmd);
                 adap.Fill(set, "dt_utilidadneta");*/


                cmd = new MySqlCommand("GastosUtilidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 20;
                cmd.Parameters.AddWithValue("codSucur", codSucur);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma_ex", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_gastosutilidadneta");




                //Utilidad2(fecha1,fecha2,codalma,codSucur);

                set.WriteXml("C:\\XML\\Utilidad.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet Utilidad2(DateTime fecha1, DateTime fecha2, Int32 codalma, Int32 codSucur)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                cmd = new MySqlCommand("ReporteUtilidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_utilidadneta");

                set.WriteXml("C:\\XML\\Utilidad2.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet UtilidadProducto(DateTime fecha1, DateTime fecha2, Int32 codalma, Int32 codSucur, Int32 codProd)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                cmd = new MySqlCommand("ReporteUtilidadProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("codProd", codProd);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_utilidadProducto");

                set.WriteXml("C:\\XML\\UtilidadProducto.xml", XmlWriteMode.WriteSchema);
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
