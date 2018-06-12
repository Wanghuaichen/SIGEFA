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
    class MysqlMarca:IMarca
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IFamilias

        public Boolean Insert(clsMarca mar)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaMarca", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("descripcion", mar.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", mar.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                mar.CodMarcaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsMarca mar)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaMarca", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmar", mar.CodMarca);
                cmd.Parameters.AddWithValue("descripcion", mar.Descripcion);
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

        public Boolean Delete(Int32 CodMarca)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarMarca", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmar", CodMarca);
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

        public clsMarca CargaMarca(Int32 Codigo)
        {
            clsMarca mar = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraMarca", con.conector);
                cmd.Parameters.AddWithValue("codmar", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mar = new clsMarca();
                        mar.CodMarca = Convert.ToInt32(dr.GetDecimal(0));
                        mar.Descripcion = dr.GetString(1);
                        mar.Estado = dr.GetBoolean(2); 
                        mar.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        mar.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }

                }
                return mar;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaMarcas()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaMarcas", con.conector);
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
