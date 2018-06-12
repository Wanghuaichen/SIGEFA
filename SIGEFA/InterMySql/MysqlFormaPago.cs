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
    class MysqlFormaPago: IFormaPago
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IFormaPago

        public Boolean Insert(clsFormaPago pago)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaFormaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("dias", pago.Dias);
                oParam = cmd.Parameters.AddWithValue("descripcion", pago.Descripcion);
                oParam = cmd.Parameters.AddWithValue("tipo", pago.Tipo);
                oParam = cmd.Parameters.AddWithValue("codusu", pago.CodUser);
                oParam = cmd.Parameters.AddWithValue("tipoa", pago.Tipoaccion);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pago.CodFormaPago= Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsFormaPago pago)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaFormaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpago", pago.CodFormaPago);
                cmd.Parameters.AddWithValue("dias", pago.Dias);
                cmd.Parameters.AddWithValue("descripcion", pago.Descripcion);
                cmd.Parameters.AddWithValue("tipo", pago.Tipo);
                cmd.Parameters.AddWithValue("tipoa", pago.Tipoaccion);
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

        public Boolean Delete(Int32 CodFormaPago)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarFormaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpago", CodFormaPago);
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
        public clsFormaPago CargaFormaPago(Int32 Codigo)
        {
            clsFormaPago pago = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraFormaPago", con.conector);
                cmd.Parameters.AddWithValue("codpago", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pago = new clsFormaPago();
                        pago.CodFormaPago = Convert.ToInt32(dr.GetDecimal(0));
                        pago.Dias = Convert.ToInt32(dr.GetDecimal(1));
                        pago.Descripcion = dr.GetString(2);                        
                        pago.Estado = dr.GetBoolean(3);
                        pago.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        pago.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                        pago.Tipo = dr.GetBoolean(6);
                    }
                }
                return pago;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsFormaPago BuscaFormaPago(String Codigo)
        {
            clsFormaPago pago = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaFormaPago", con.conector);
                cmd.Parameters.AddWithValue("cod", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pago = new clsFormaPago();
                        pago.CodFormaPago = Convert.ToInt32(dr.GetDecimal(0));
                        pago.Dias = Convert.ToInt32(dr.GetDecimal(1));
                        pago.Descripcion = dr.GetString(2);
                        pago.Tipo = dr.GetBoolean(3);
                    }
                }
                return pago;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaFormaPagos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaFormaPagos", con.conector);
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

        public DataTable CargaFormaPagos(Int32 tip)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaFormaPagos", con.conector);
                cmd.Parameters.AddWithValue("tip", tip);
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

        public DataTable CargaFormaPagosReportes()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaFormaPagosReportes", con.conector);
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

        public clsFormaPago BuscaFormaPagoVenta(Int32 Codigo)
        {
            clsFormaPago pago = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaFormaPagoVenta", con.conector);
                cmd.Parameters.AddWithValue("codforma", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pago = new clsFormaPago();
                        pago.CodFormaPago = Convert.ToInt32(dr.GetDecimal(0));
                        pago.Dias = Convert.ToInt32(dr.GetDecimal(1));
                        pago.Descripcion = dr.GetString(2);
                        pago.Estado = dr.GetBoolean(3);
                        pago.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        pago.FechaRegistro = dr.GetDateTime(5);
                        pago.Tipo = dr.GetBoolean(6);
                        pago.Tipoaccion = dr.GetBoolean(7);
                    }
                }
                return pago;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaFormaPagosCuotas()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaFormaPagosCuotas", con.conector);
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
