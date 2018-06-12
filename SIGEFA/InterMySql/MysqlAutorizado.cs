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
    class MysqlAutorizado: IAutorizado
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IAutorizado

        public Boolean Insert(clsAutorizado aut)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaAutorizado", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("nombre", aut.Nombre);
                oParam = cmd.Parameters.AddWithValue("codusu", aut.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                aut.CodAutorizadoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsAutorizado aut)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaAutorizado", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codaut", aut.CodAutorizado);
                cmd.Parameters.AddWithValue("nombre", aut.Nombre);
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

        public Boolean Delete(Int32 CodAutorizado)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarAutorizado", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codaut", CodAutorizado);
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

        public clsAutorizado CargaAutorizado(Int32 Codigo)
        {
            clsAutorizado aut = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraAutorizado", con.conector);
                cmd.Parameters.AddWithValue("codaut", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        aut = new clsAutorizado();
                        aut.CodAutorizado = Convert.ToInt32(dr.GetDecimal(0));
                        aut.Nombre = dr.GetString(1);
                        aut.Estado = dr.GetBoolean(2); 
                        aut.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        aut.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }

                }
                return aut;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaAutorizados()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaAutorizados", con.conector);
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
