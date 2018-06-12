using System;
using MySql.Data.MySqlClient;
using System.Data;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;
using SIGEFA.Entidades;

namespace SIGEFA.InterMySql
{
    class mysqlTipoPrecios :ITipoPrecio
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataAdapter adap = null;
       // MySqlDataReader rd = null;
        DataTable listaP = null;

        public  Boolean insert(clsTipoPrecios tp) {

            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("guardaTipoPrecio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oparm;
                oparm = cmd.Parameters.AddWithValue("sigla", tp.Sigla);
                oparm = cmd.Parameters.AddWithValue("descripcion", tp.Descripcion);
                oparm = cmd.Parameters.AddWithValue("codalmacen", tp.CodAlmacen);
                oparm = cmd.Parameters.AddWithValue("codusu", tp.User1);
                oparm = cmd.Parameters.AddWithValue("newid", 0);
                oparm.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                tp.CodTipoPrecioNuevo = Convert.ToInt32 (cmd.Parameters["newid"].Value);

                if (x != 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean Update(clsTipoPrecios tp) {

            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("updateTipoPrecio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod", tp.CodTipoPrecio);
                cmd.Parameters.AddWithValue("siglaTP", tp.Sigla);
                cmd.Parameters.AddWithValue("descrip", tp.Descripcion);
                cmd.Parameters.AddWithValue("almacen", tp.CodAlmacen);
                cmd.Parameters.AddWithValue("codusu", tp.User1);
                int x = cmd.ExecuteNonQuery();
                if (x != 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean eliminar(Int32 codTipoPrecio) {

            try {
                con.conectarBD();
                cmd = new MySqlCommand("eliminarTipoPrecio",con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod",codTipoPrecio);
                int x = cmd.ExecuteNonQuery();
                if (x != 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaPrecios() {

            try { 
                
                con.conectarBD();
                listaP = new DataTable();
                cmd = new MySqlCommand("lisprecios",con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(listaP);
                return listaP;
            

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        
    }
}
