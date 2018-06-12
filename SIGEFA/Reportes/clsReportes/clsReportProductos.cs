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
    class clsReportProductos
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;
        DataSet set = null;

        public DataSet Inventario(Int32 codalma,Boolean costo,Boolean art,Boolean fam,Boolean lin,Boolean gru,Boolean tip,Boolean todo,Int32 art1,Int32 art2,Boolean cero,Int32 orden,Boolean activos)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteStock2", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("costo", costo);
                cmd.Parameters.AddWithValue("art", art);
                cmd.Parameters.AddWithValue("fam", fam);
                cmd.Parameters.AddWithValue("lin", lin);
                cmd.Parameters.AddWithValue("gru", gru);
                cmd.Parameters.AddWithValue("tip", tip);
                cmd.Parameters.AddWithValue("todo", todo);
                cmd.Parameters.AddWithValue("art1", art1);
                cmd.Parameters.AddWithValue("art2", art2);
                cmd.Parameters.AddWithValue("cero", cero);
                cmd.Parameters.AddWithValue("v_orden", orden);
                cmd.Parameters.AddWithValue("activos", activos);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\inventarioSP2.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet CatalogoConPrecio()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("CatalogoconPrecios", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;                
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\catalogoprecios.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet ReporteValorizacion(Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ValorizacionAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codalma", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ValorizacionAlmacen.xml", XmlWriteMode.WriteSchema);
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
