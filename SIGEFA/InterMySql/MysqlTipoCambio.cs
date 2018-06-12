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
    class MysqlTipoCambio : ITipoCambio
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITipoCambio

        public Boolean Insert(clsTipoCambio tc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTipoCambio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("compra", tc.Compra);
                oParam = cmd.Parameters.AddWithValue("venta", tc.Venta);
                oParam = cmd.Parameters.AddWithValue("fecha", tc.Fecha);
                oParam = cmd.Parameters.AddWithValue("codusu", tc.CodUser);
                oParam = cmd.Parameters.AddWithValue("codmon", tc.ICodMoneda);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                tc.CodTipoCambio = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTipoCambio tc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTipoCambio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtc", tc.CodTipoCambio);
                cmd.Parameters.AddWithValue("compra", tc.Compra);
                cmd.Parameters.AddWithValue("venta", tc.Venta);
                cmd.Parameters.AddWithValue("codMon", tc.ICodMoneda);
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

        public Boolean Delete(Int32 CodTipoCambio)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTipoCambio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtc", CodTipoCambio);
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

        public clsTipoCambio CargaTipoCambio(DateTime Fecha,Int32 codMoneda)
        {
            clsTipoCambio tc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTipoCambio", con.conector);
                cmd.Parameters.AddWithValue("fechab", Fecha);
                cmd.Parameters.AddWithValue("codM", codMoneda);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tc = new clsTipoCambio();
                        tc.CodTipoCambio = Convert.ToInt32(dr.GetDecimal(0));
                        tc.Compra = dr.GetDouble(1);
                        tc.Venta = dr.GetDouble(2);
                        tc.Fecha = dr.GetDateTime(3);
                        tc.Estado = dr.GetBoolean(4); 
                        tc.CodUser = Convert.ToInt32(dr.GetDecimal(5));
                        tc.FechaRegistro = dr.GetDateTime(6);// capturo la fecha 
                    }
                }                
                return tc;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean VerificaTCfecha(DateTime Fecha)
        {
            try
            {                
                con.conectarBD();
                cmd = new MySqlCommand("BuscaTipoCambio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("fechab", Fecha);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
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

        public DataTable ListaTipoCambios(Int32 Mes, Int32 Año)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTipoCambios", con.conector);
                cmd.Parameters.AddWithValue("mes", Mes);
                cmd.Parameters.AddWithValue("año", Año);
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
