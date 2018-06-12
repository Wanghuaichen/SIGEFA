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
    class MysqlFlujoCaja : IFlujoCaja
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IFlujoCaja

        public Boolean Insert(clsFlujoCaja flu)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaFlujoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("sucur", flu.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("fec", flu.FechaApertura);
                oParam = cmd.Parameters.AddWithValue("montoape", flu.MontoApertura);
                oParam = cmd.Parameters.AddWithValue("codusu", flu.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                flu.CodFlujoCajaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

                if (x != 0)
                {
                    if (flu.CodFlujoCajaNuevo > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (flu.CodFlujoCajaNuevo > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean Update(clsFlujoCaja flu)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaFlujoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codflu", flu.CodFlujoCaja);
                cmd.Parameters.AddWithValue("sucur", flu.CodSucursal);
                cmd.Parameters.AddWithValue("montodis", flu.MontoDisponible);
                cmd.Parameters.AddWithValue("montoing", flu.MontoIngresado);
                cmd.Parameters.AddWithValue("montocie", flu.MontoCierre);
                cmd.Parameters.AddWithValue("fec", flu.FechaCierre);
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

        public Boolean Delete(Int32 CodFlujoCaja, Int32 CodSucursal)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarFlujoCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codflu", CodFlujoCaja);
                cmd.Parameters.AddWithValue("sucur", CodSucursal);
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

        public clsFlujoCaja CargaFlujosCaja(DateTime fecha, Int32 CodSucursal)
        {
            clsFlujoCaja flu = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraFlujoCaja", con.conector);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.Parameters.AddWithValue("sucur", CodSucursal);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        flu = new clsFlujoCaja();
                        flu.CodFlujoCaja = Convert.ToInt32(dr.GetDecimal(0));
                        flu.CodSucursal = Convert.ToInt32(dr.GetDecimal(1));
                        flu.FechaApertura = dr.GetDateTime(2);
                        flu.MontoApertura = dr.GetDecimal(3);
                        flu.FechaCierre = dr.GetDateTime(4);
                        flu.MontoCierre = dr.GetDecimal(5);
                        flu.MontoIngresado = dr.GetDecimal(6);
                        flu.MontoDepositado = dr.GetDecimal(7);
                        flu.MontoDisponible = dr.GetDecimal(8);
                        flu.FechaDeposito = dr.GetDateTime(9);
                        flu.Estado = dr.GetBoolean(10);
                        flu.Deposito = dr.GetBoolean(11);
                        flu.FechaRegistro = dr.GetDateTime(12);
                        flu.CodUser = Convert.ToInt32(dr.GetDecimal(13));
                    }
                }
                return flu;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaFlujosCaja(Int32 codSucursal)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaFlujoCaja", con.conector);
                cmd.Parameters.AddWithValue("sucur", codSucursal);
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

        public DataTable ListaPagoCobro(Int32 tipo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListarTipoPagoServ", con.conector);
                cmd.Parameters.AddWithValue("tipo_ex", tipo);
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

        public clsFlujoCaja VerificaSaldoCaja(Int32 CodSucursal)
        {
            clsFlujoCaja caja = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VerificaSaldoCaja", con.conector);
                cmd.Parameters.AddWithValue("codSucur", CodSucursal);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        caja = new clsFlujoCaja();
                        caja.MontoApertura = Convert.ToDecimal(dr.GetDecimal(0));
                        caja.MontoIngresado = Convert.ToDecimal(dr.GetDecimal(1));
                        caja.MontoDepositado = Convert.ToDecimal(dr.GetDecimal(2));
                        caja.MontoDisponible = Convert.ToDecimal(dr.GetDecimal(3));
                    }
                }
                return caja;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 VerificaAperturaCaja(Int32 codSucursal)
        {
            Int32 result;
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("VerificaAperturaCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sucur", codSucursal);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsFlujoCaja VerificaDepositoCaja(int CodSucursal, DateTime fecha)
        {
            clsFlujoCaja caja = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VerificaDepositoCaja", con.conector);
                cmd.Parameters.AddWithValue("sucur", CodSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        caja = new clsFlujoCaja();
                        caja.FechaCierre = dr.GetDateTime(0);
                        caja.MontoIngresado = Convert.ToDecimal(dr.GetDecimal(1));
                    }
                }
                return caja;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        #endregion
    }
}
