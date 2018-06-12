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
    class MysqlBanco:IBanco
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IBanco

        public Boolean Insert(clsBanco ban)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaBanco", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("descripcion", ban.Descripcion);
                oParam = cmd.Parameters.AddWithValue("sig", ban.SiglaBanco);
                oParam = cmd.Parameters.AddWithValue("codusu", ban.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                ban.CodBancoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsBanco ban)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaBanco", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codban", ban.CodBanco);
                cmd.Parameters.AddWithValue("descripcion", ban.Descripcion);
                cmd.Parameters.AddWithValue("sig", ban.SiglaBanco);
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

        public Boolean Delete(Int32 CodBanco)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarBanco", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codban", CodBanco);
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

        public clsBanco CargaBanco(Int32 Codigo)
        {
            clsBanco ban = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraBanco", con.conector);
                cmd.Parameters.AddWithValue("codban", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ban = new clsBanco();
                        ban.CodBanco = Convert.ToInt32(dr.GetDecimal(0));
                        ban.Descripcion = dr.GetString(1);
                        ban.Estado = dr.GetBoolean(2); 
                        ban.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        ban.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }

                }
                return ban;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaBancos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaBancos", con.conector);
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

        public DataTable CargaBancos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaBancos", con.conector);
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
