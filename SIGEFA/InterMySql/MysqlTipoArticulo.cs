using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;


namespace SIGEFA.InterMySql
{
    class MysqlTipoArticulo:ITipoArticulo
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITipoArticulo

        public Boolean Insert(clsTipoArticulo tip)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTipoArticulo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("referencia", tip.Referencia);
                oParam = cmd.Parameters.AddWithValue("descripcion", tip.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", tip.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                tip.CodTipoArticuloNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTipoArticulo tip)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTipoArticulo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtipo", tip.CodTipoArticulo);
                cmd.Parameters.AddWithValue("referencia", tip.Referencia);
                cmd.Parameters.AddWithValue("descripcion", tip.Descripcion);
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

        public Boolean Delete(Int32 CodTipoArticulo)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTipoArticulo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtipo", CodTipoArticulo);
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

        public clsTipoArticulo CargaTipoArticulo(Int32 Codigo)
        {
            clsTipoArticulo tip = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTipoArticulo", con.conector);
                cmd.Parameters.AddWithValue("codtipo", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tip = new clsTipoArticulo();
                        tip.CodTipoArticulo = Convert.ToInt32(dr.GetDecimal(0));
                        tip.Referencia = dr.GetString(1);
                        tip.Descripcion = dr.GetString(2);
                        tip.Estado = dr.GetBoolean(3); 
                        tip.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        tip.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return tip;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaTipoArticulos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaArticulos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
                return tabla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        #endregion
    }
}
