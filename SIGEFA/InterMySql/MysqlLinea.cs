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
    class MysqlLinea:ILinea
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ILinea

        public Boolean Insert(clsLinea lin)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaLinea", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codfam", lin.CodFamilia);
                oParam = cmd.Parameters.AddWithValue("referencia", lin.Referencia);
                oParam = cmd.Parameters.AddWithValue("descripcion", lin.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", lin.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                lin.CodLineaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsLinea lin)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaLinea", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codlin", lin.CodLinea);
                cmd.Parameters.AddWithValue("referencia", lin.Referencia);
                cmd.Parameters.AddWithValue("descripcion", lin.Descripcion);
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

        public Boolean Delete(Int32 CodLinea)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarLinea", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codlin", CodLinea);
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

        public clsLinea CargaLinea(Int32 Codigo)
        {
            clsLinea lin = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraLinea", con.conector);
                cmd.Parameters.AddWithValue("codlin", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lin = new clsLinea();
                        lin.CodLinea = Convert.ToInt32(dr.GetDecimal(0));
                        lin.CodFamilia = Convert.ToInt32(dr.GetDecimal(1));
                        lin.Referencia = dr.GetString(2);
                        lin.Descripcion = dr.GetString(3);
                        lin.Estado = dr.GetBoolean(4); 
                        lin.CodUser = Convert.ToInt32(dr.GetDecimal(5));
                        lin.FechaRegistro = dr.GetDateTime(6);// capturo la fecha 
                    }

                }
                return lin;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaLineas(Int32 CodFam)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaLineas", con.conector);
                cmd.Parameters.AddWithValue("codfam", CodFam);
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
