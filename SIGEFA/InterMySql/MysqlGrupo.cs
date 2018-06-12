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
    class MysqlGrupo:IGrupo
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IGrupo

        public Boolean Insert(clsGrupo gru)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaGrupo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codlin", gru.CodLinea);
                oParam = cmd.Parameters.AddWithValue("referencia", gru.Referencia);
                oParam = cmd.Parameters.AddWithValue("descripcion", gru.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", gru.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                gru.CodGrupoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsGrupo gru)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaGrupo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codgru", gru.CodGrupo);
                cmd.Parameters.AddWithValue("referencia", gru.Referencia);
                cmd.Parameters.AddWithValue("descripcion", gru.Descripcion);
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

        public Boolean Delete(Int32 CodGrupo)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarGrupo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codgru", CodGrupo);
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

        public clsGrupo CargaGrupo(Int32 Codigo)
        {
            clsGrupo gru = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraGrupo", con.conector);
                cmd.Parameters.AddWithValue("codgru", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gru = new clsGrupo();
                        gru.CodGrupo = Convert.ToInt32(dr.GetDecimal(0));
                        gru.CodLinea = Convert.ToInt32(dr.GetDecimal(1));
                        gru.Referencia = dr.GetString(2);
                        gru.Descripcion = dr.GetString(3);
                        gru.Estado = dr.GetBoolean(4); 
                        gru.CodUser = Convert.ToInt32(dr.GetDecimal(5));
                        gru.FechaRegistro = dr.GetDateTime(6);// capturo la fecha 
                    }

                }
                return gru;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaGrupos(Int32 CodLin)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaGrupos", con.conector);
                cmd.Parameters.AddWithValue("codlin", CodLin);
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
