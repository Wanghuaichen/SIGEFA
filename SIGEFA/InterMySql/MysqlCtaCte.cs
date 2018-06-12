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
    class MysqlCtaCte : ICtaCte
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IBancos

        public bool Insert(clsCtaCte cta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaCtaCte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codban", cta.CodBanco);
                oParam = cmd.Parameters.AddWithValue("ctacte", cta.CtaCte);
                oParam = cmd.Parameters.AddWithValue("tipo", cta.TipoCuenta);
                oParam = cmd.Parameters.AddWithValue("mone", cta.Moneda);
                oParam = cmd.Parameters.AddWithValue("codusu", cta.Coduser);
                oParam = cmd.Parameters.AddWithValue("codalma", cta.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                cta.CodCtaCteNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool Update(clsCtaCte cta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaCtaCte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codctacte", cta.CodCtaCte);
                cmd.Parameters.AddWithValue("ctacte", cta.CtaCte);
                cmd.Parameters.AddWithValue("tipo", cta.TipoCuenta);
                cmd.Parameters.AddWithValue("mone", cta.Moneda);
                cmd.Parameters.AddWithValue("codalma", cta.CodAlmacen);
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

        public bool Delete(int codCtaCte, int codAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ElimimaCtaCte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codctacte", codCtaCte);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaCtasBanco(int CodBanco, Int32 CodAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaCuentasCorrientes", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codban", CodBanco);
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

        public DataTable ListaCtaCte(Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaCtaCte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public clsCtaCte CargaTipoCuenta(int CodCuenta, Int32 CodAlmacen)
        {
            clsCtaCte tc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTipoCuenta", con.conector);
                cmd.Parameters.AddWithValue("codcuenta", CodCuenta);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tc = new clsCtaCte();
                        tc.TipoCuenta = dr.GetString(0);
                        tc.Moneda = dr.GetInt32(1);
                        tc.saldo = dr.GetDecimal(2);
                        tc.descripcion = dr.GetString(3);
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

        public DataTable CargarMovxCuenta(string Cuenta, Int32 codAlmacen)
        {
           try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListarMovxCuenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cuenta", Cuenta);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
                return tabla;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsCtaCte BuscaMovimiento(int codMov, int codAlmacen)
        {
            clsCtaCte tc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarMovimientoCta", con.conector);
                cmd.Parameters.AddWithValue("codmovi", codMov);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    { 
                        tc = new clsCtaCte();
                        tc.CodMovi = dr.GetInt32(0);
                        tc.CodBanco = dr.GetInt32(1);
                        tc.NombreBanco = dr.GetString(2);
                        tc.CodCtaCte = dr.GetInt32(3);
                        tc.CtaCte = dr.GetString(4);
                        tc.TipoCuenta = dr.GetString(5);
                        tc.NumTransaccion = dr.GetString(6);
                        tc.FechaMovimiento = dr.GetDateTime(7);
                        tc.DescTipo = dr.GetString(8);
                        tc.egreso = dr.GetDecimal(9);
                        tc.ingreso = dr.GetDecimal(10);
                        tc.saldo = dr.GetDecimal(11);
                        tc.descripcion = dr.GetString(12);
                        tc.tipocambio = dr.GetDecimal(13);
                        tc.TipoCVenta = dr.GetDecimal(14);
                        tc.Moneda = dr.GetInt32(15);
                        tc.CodTipoPagoServicio = dr.GetInt32(16);
                        tc.Nombre = dr.GetString(17);
                        tc.Direccion = dr.GetString(18);
                        tc.Dni = dr.GetString(19);
                        tc.Igresoegreso = dr.GetInt32(20);
                        tc.Correlativo = dr.GetInt32(21);
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

        public bool InsertMovi(clsCtaCte cta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardarCuentaMovimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codcuen", cta.CodCtaCte);
                oParam = cmd.Parameters.AddWithValue("codalma", cta.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codtrans", cta.NumTransaccion);
                oParam = cmd.Parameters.AddWithValue("descrip", cta.descripcion);
                oParam = cmd.Parameters.AddWithValue("mone", cta.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipo", cta.Tipo);
                oParam = cmd.Parameters.AddWithValue("tcve", cta.tipocambio);
                oParam = cmd.Parameters.AddWithValue("tccom", cta.TipoCVenta);
                oParam = cmd.Parameters.AddWithValue("ingresoegreso", cta.Dmonto);
                oParam = cmd.Parameters.AddWithValue("codu", cta.Coduser);
                oParam = cmd.Parameters.AddWithValue("fechamov", cta.FechaMovimiento);
                oParam = cmd.Parameters.AddWithValue("codtipo", cta.CodTipoPagoServicio);
                oParam = cmd.Parameters.AddWithValue("codban", cta.CodBanco);
                oParam = cmd.Parameters.AddWithValue("codsucur", cta.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("tip", cta.TipoProcedencia);
                oParam = cmd.Parameters.AddWithValue("fcierre", cta.FechaCierreCaja);
                oParam = cmd.Parameters.AddWithValue("nombre_ex", cta.Nombre);
                oParam = cmd.Parameters.AddWithValue("direccion_ex", cta.Direccion);
                oParam = cmd.Parameters.AddWithValue("dni_ex", cta.Dni);
                oParam = cmd.Parameters.AddWithValue("ingresoegreso_ex", cta.Igresoegreso);
                oParam = cmd.Parameters.AddWithValue("correlativo_ex", cta.Correlativo);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                cta.CodCtaCteNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool UpdateMovi(clsCtaCte cta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaMovimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codmovi", cta.CodMovi);
                oParam = cmd.Parameters.AddWithValue("codcuen", cta.CodCtaCte);
                oParam = cmd.Parameters.AddWithValue("descrip", cta.descripcion);
                oParam = cmd.Parameters.AddWithValue("mone", cta.Moneda);
                oParam = cmd.Parameters.AddWithValue("ingresoegreso", cta.Dmonto);
                oParam = cmd.Parameters.AddWithValue("codu", cta.Coduser);
                oParam = cmd.Parameters.AddWithValue("codalma", cta.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("fechamov", cta.FechaMovimiento);
                oParam = cmd.Parameters.AddWithValue("tipo", cta.Tipo);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                cta.CodCtaCteNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool DeleteMov(int CodMov, Int32 codAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminaMovimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmov", CodMov);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaMovimientos(Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListarMovimientos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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
        public DataTable ListarMovientoscta(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("BuscarMovimientoCta2", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("codbanco", codBanco);
                cmd.Parameters.AddWithValue("codcuenta", codCuenta);
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
        public DataTable ListaMovimientosDesactivos(Int32 codbanco, Int32 codcuenta, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaMovimientosDesactivos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codbanco_ex", codbanco);
                cmd.Parameters.AddWithValue("codcuenta_ex", codcuenta);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaEgresosCaja(Int32 CodSucursal, DateTime Fecha)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaEgresosCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codsucur", CodSucursal);
                cmd.Parameters.AddWithValue("fec", Fecha);
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

        public DataTable ListatipoCtas_x_Banco(int CodBanco, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("con_lista_tipocta_x_banco", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codbanco_ex", CodBanco);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListanumCta_x_tipocta(int CodBanco, string tipocuenta, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("con_lista_numcta_x_tipocta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codbanco_ex", CodBanco);
                cmd.Parameters.AddWithValue("tipocuenta_ex", tipocuenta);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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


        public DataTable ListaCaja(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("IngresosCaja", con.conector);
                cmd.Parameters.AddWithValue("codsucur", codSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
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

        public clsCtaCte VerificaEgresoCaja(Int32 CodSucursal, DateTime fecha)
        {
            clsCtaCte tc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VerificaEgresoCaja", con.conector);
                cmd.Parameters.AddWithValue("codsucur", CodSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tc = new clsCtaCte();
                        tc.CodMovi = dr.GetInt32(0);
                        tc.ingreso = dr.GetDecimal(1);
                        tc.FechaMovimiento = dr.GetDateTime(2);
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

        public DataTable ListaCtaCtexBancoxMoneda(Int32 codBanco, Int32 codMoneda)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CtaCtexBancoxMoneda", con.conector);
                cmd.Parameters.AddWithValue("codban", codBanco);
                cmd.Parameters.AddWithValue("codmoneda", codMoneda);
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

        public DataTable ListaBancoxMoneda(Int32 codMoneda)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaBancoxMoneda", con.conector);
                cmd.Parameters.AddWithValue("codmoneda", codMoneda);
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

        public Int32 Correlativo(Int32 codtipo)
        {
            try
            {
                Int32 correl = 0;
                con.conectarBD();
                cmd = new MySqlCommand("TraerCorrelativo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codTipoPagoCaja_ex", codtipo);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        correl = dr.GetInt32(0);
                    }
                }
                return correl;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean activar(Int32 codmov)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActivaMovimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmov", codmov);                
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

        public Boolean desactivar(Int32 codmov)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("DesactivaMovimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmov", codmov);
                int x = cmd.ExecuteNonQuery();

                if (x != 0) { return true; }
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

        public decimal TotalConciliacion(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta) {
            try
            {
                decimal total = 0;
                con.conectarBD();
                cmd = new MySqlCommand("SumaTotalConciliacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("codbanco", codBanco);
                cmd.Parameters.AddWithValue("codcuenta", codCuenta);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        total = dr.GetDecimal(0);
                    }
                }
                return total;
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
