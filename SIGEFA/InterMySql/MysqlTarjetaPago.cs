using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;

namespace SIGEFA.InterMySql
{
    class MysqlTarjetaPago : ITarjetaPago
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITarjetaPago

        public Boolean Insert(clsTarjetaPago tar)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTarjetaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("tipo", tar.Tipo);
                oParam = cmd.Parameters.AddWithValue("descripcion", tar.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codUsu", tar.Coduser);
                oParam = cmd.Parameters.AddWithValue("codalma", tar.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                tar.CodTarjetaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTarjetaPago tar)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTarjetaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtar", tar.CodTarjeta);
                cmd.Parameters.AddWithValue("tip", tar.Tipo);
                cmd.Parameters.AddWithValue("descrip", tar.Descripcion);
                cmd.Parameters.AddWithValue("codalma", tar.CodAlmacen);
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

        public Boolean Delete(Int32 CodTarjeta, Int32 CodAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTarjetaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtar", CodTarjeta);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
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

        public clsTarjetaPago CargaTarjeta(Int32 CodTarjeta, Int32 codAlmacen)
        {
            clsTarjetaPago tar = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTarjetaPago", con.conector);
                cmd.Parameters.AddWithValue("codtar", CodTarjeta);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tar = new clsTarjetaPago();
                        tar.CodTarjeta = Convert.ToInt32(dr.GetDecimal(0));
                        tar.Tipo = dr.GetString(1);
                        tar.Descripcion = dr.GetString(2);
                        tar.Estado = dr.GetBoolean(3);
                        tar.Coduser = Convert.ToInt32(dr.GetDecimal(4));
                        tar.Fecharegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return tar;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaTarjetas(Int32 CodAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTarjetasPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
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
