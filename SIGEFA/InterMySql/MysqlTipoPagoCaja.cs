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
    class MysqlTipoPagoCaja : ITipoPagoCaja
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITipoPagoCaja

        public Boolean Insert(clsTipoPagoCaja TPcaja)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTipoPagoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("descrip", TPcaja.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", TPcaja.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                TPcaja.CodTipoPagoServicioNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTipoPagoCaja TPcaja)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTipoPagoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", TPcaja.CodTipoPagoServicio);
                cmd.Parameters.AddWithValue("descripcion", TPcaja.Descripcion);
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

        public Boolean Delete(Int32 Codigo)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTipoPagoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", Codigo);
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

        public clsTipoPagoCaja CargaTipoPagoCaja(Int32 Codigo)
        {
            clsTipoPagoCaja TPCaja = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaTipoPagoCaja", con.conector);
                cmd.Parameters.AddWithValue("codigo", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TPCaja = new clsTipoPagoCaja();
                        TPCaja.CodTipoPagoServicio = Convert.ToInt32(dr.GetDecimal(0));
                        TPCaja.Descripcion = dr.GetString(1);
                        TPCaja.Estado = dr.GetBoolean(2);
                        TPCaja.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        TPCaja.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }
                }
                return TPCaja;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaTipoPagoCaja()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTipoPagoCaja", con.conector);
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
