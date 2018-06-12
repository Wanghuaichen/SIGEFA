using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;

namespace SIGEFA.InterMySql
{
    class MysqlPago : IPago
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IPago
         


        public Boolean Insert(clsPago pag)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codnot", Convert.ToInt32(pag.CodNota));
                oParam = cmd.Parameters.AddWithValue("codlet", Convert.ToInt32(pag.CodLetra));
                oParam = cmd.Parameters.AddWithValue("codcuopreban", Convert.ToInt32(pag.CodCuotaPreBan));
                oParam = cmd.Parameters.AddWithValue("codtipopago", pag.CodTipoPago);
                oParam = cmd.Parameters.AddWithValue("codmon", pag.CodMoneda);
                oParam = cmd.Parameters.AddWithValue("codtar", pag.CodTarjeta);
                oParam = cmd.Parameters.AddWithValue("tipo", pag.Tipo);
                oParam = cmd.Parameters.AddWithValue("ingegre", pag.IngresoEgreso);
                oParam = cmd.Parameters.AddWithValue("tipocambio", pag.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("montopa", pag.MontoPagado);
                oParam = cmd.Parameters.AddWithValue("montoco", pag.MontoCobrado);
                oParam = cmd.Parameters.AddWithValue("vuelto", pag.Vuelto);
                oParam = cmd.Parameters.AddWithValue("mora", pag.Mora);
                oParam = cmd.Parameters.AddWithValue("codalma", pag.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codcta", pag.codCtaCte);
                oParam = cmd.Parameters.AddWithValue("numcta", pag.CtaCte);
                oParam = cmd.Parameters.AddWithValue("noperacion", pag.NOperacion);
                oParam = cmd.Parameters.AddWithValue("ncheque", pag.NCheque);
                oParam = cmd.Parameters.AddWithValue("fecha", pag.FechaPago);
                oParam = cmd.Parameters.AddWithValue("observa", pag.Observacion);
                oParam = cmd.Parameters.AddWithValue("codusu", pag.CodUser);
                oParam = cmd.Parameters.AddWithValue("codban", pag.CodBanco);
                oParam = cmd.Parameters.AddWithValue("provi", pag.Provision);//MOD7
                if (pag.CodNotaCredito != 0) oParam = cmd.Parameters.AddWithValue("codnotac", pag.CodNotaCredito);
                else oParam = cmd.Parameters.AddWithValue("codnotac", null);
                if (pag.NotaCredito != 0) oParam = cmd.Parameters.AddWithValue("notacre", pag.NotaCredito);
                else oParam = cmd.Parameters.AddWithValue("notacre", 0);
                if(pag.CodSerie != 0) oParam = cmd.Parameters.AddWithValue("codserie", pag.CodSerie);
                else oParam = cmd.Parameters.AddWithValue("codserie", null); 
                if(pag.Serie != "") oParam = cmd.Parameters.AddWithValue("serie", pag.Serie);
                else oParam = cmd.Parameters.AddWithValue("serie", null);
                if(pag.NumDoc != "") oParam = cmd.Parameters.AddWithValue("numdoc", pag.NumDoc);
                else oParam = cmd.Parameters.AddWithValue("numdoc", null);
                oParam = cmd.Parameters.AddWithValue("aprob", pag.Aprobado);
                if (pag.Referencia != "") oParam = cmd.Parameters.AddWithValue("ref", pag.Referencia);
                else oParam = cmd.Parameters.AddWithValue("ref", null);
                if (pag.CodDoc != 0) oParam = cmd.Parameters.AddWithValue("coddoc", pag.CodDoc);
                else oParam = cmd.Parameters.AddWithValue("coddoc", null);
                oParam = cmd.Parameters.AddWithValue("codsucur", pag.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("codCaja_ex", pag.Codcaja);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pag.CodPago = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertPagoDetraccion(clsPago pag)//MOD7
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaPagoDetraccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codnot", Convert.ToInt32(pag.CodNota));
                oParam = cmd.Parameters.AddWithValue("codlet", Convert.ToInt32(pag.CodLetra));
                if (pag.CodTipoPago != 0) oParam = cmd.Parameters.AddWithValue("codtipopago", pag.CodTipoPago);
                else oParam = cmd.Parameters.AddWithValue("codtipopago", null);
                oParam = cmd.Parameters.AddWithValue("codmon", pag.CodMoneda);
                oParam = cmd.Parameters.AddWithValue("codtar", pag.CodTarjeta);
                oParam = cmd.Parameters.AddWithValue("tipo", pag.Tipo);
                oParam = cmd.Parameters.AddWithValue("ingegre", pag.IngresoEgreso);
                oParam = cmd.Parameters.AddWithValue("tipocambio", pag.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("montopa", pag.MontoPagado);
                oParam = cmd.Parameters.AddWithValue("montoco", pag.MontoCobrado);
                oParam = cmd.Parameters.AddWithValue("vuelto", pag.Vuelto);
                oParam = cmd.Parameters.AddWithValue("codalma", pag.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codcta", pag.codCtaCte);
                oParam = cmd.Parameters.AddWithValue("numcta", pag.CtaCte);
                oParam = cmd.Parameters.AddWithValue("noperacion", pag.NOperacion);
                oParam = cmd.Parameters.AddWithValue("ncheque", pag.NCheque);
                oParam = cmd.Parameters.AddWithValue("fecha", pag.FechaPago);
                oParam = cmd.Parameters.AddWithValue("observa", pag.Observacion);
                oParam = cmd.Parameters.AddWithValue("codusu", pag.CodUser);
                oParam = cmd.Parameters.AddWithValue("codban", pag.CodBanco);
                oParam = cmd.Parameters.AddWithValue("provi", pag.Provision);
                oParam = cmd.Parameters.AddWithValue("pend", pag.Pendiente);
                if (pag.CodSerie != 0) oParam = cmd.Parameters.AddWithValue("codserie", pag.CodSerie);
                else oParam = cmd.Parameters.AddWithValue("codserie", null);
                if (pag.Serie != "") oParam = cmd.Parameters.AddWithValue("serie", pag.Serie);
                else oParam = cmd.Parameters.AddWithValue("serie", null);
                if (pag.NumDoc != "") oParam = cmd.Parameters.AddWithValue("numdoc", pag.NumDoc);
                else oParam = cmd.Parameters.AddWithValue("numdoc", null);
                oParam = cmd.Parameters.AddWithValue("aprob", pag.Aprobado);
                if (pag.Referencia != "") oParam = cmd.Parameters.AddWithValue("ref", pag.Referencia);
                else oParam = cmd.Parameters.AddWithValue("ref", null);
                if (pag.CodDoc != 0) oParam = cmd.Parameters.AddWithValue("coddoc", pag.CodDoc);
                else oParam = cmd.Parameters.AddWithValue("coddoc", null);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pag.CodPago = Convert.ToInt32(cmd.Parameters["newid"].Value);

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


        public DataTable MuestraListaPagosNota(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraListaPagosPorNota", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnot", CodNotaIngreso);
                cmd.Parameters.AddWithValue("ingegre", InOut);
                cmd.Parameters.AddWithValue("tipo", Tipo);
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

        public Boolean AnularPago(Int32 CodigoPago)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpag", CodigoPago);
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

        public clsPago MuestraPagoVenta(int codAlmacen, Int32 venta)
        {
            clsPago pag = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPagoVenta", con.conector);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("codnota", venta);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pag = new clsPago();
                        pag.CodPago = Convert.ToInt32(dr.GetDecimal(0));
                        pag.CodNota = dr.GetString(1);
                        pag.MontoCobrado = dr.GetDecimal(2);
                        pag.MontoPagado = dr.GetDecimal(3);
                        pag.FechaPago = dr.GetDateTime(4);
                        pag.CodTipoPago = Convert.ToInt32(dr.GetDecimal(5));
                        pag.TipoCambio = dr.GetDecimal(6);
                        pag.CodCobrador = Convert.ToInt32(dr.GetDecimal(7));
                        pag.codCtaCte = Convert.ToInt32(dr.GetDecimal(8));
                        pag.CodTarjeta = Convert.ToInt32(dr.GetDecimal(9));
                        pag.CodBanco = Convert.ToInt32(dr.GetDecimal(10));
                        pag.NOperacion = dr.GetString(11);
                        pag.CtaCte = dr.GetString(12);
                        pag.NCheque = dr.GetString(13);
                        pag.Observacion = dr.GetString(14);
                    }
                }
                return pag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable MuestraPagoVentaAnula(int codAlmacen, Int32 nota)
        {
            clsPago pag = null;
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPagoVentaAnula", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("nota", nota);
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
        public DataTable MuestraPagosPorAprobar(Int32 Estado, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("pagoPorAprobarTesoreria", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("estado", Estado);
                cmd.Parameters.AddWithValue("fecha1", Fecha1);
                cmd.Parameters.AddWithValue("fecha2", Fecha2);
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
        public DataTable MuestraPagosDetraccion(Int32 Estado, DateTime Fecha1, DateTime Fecha2)//MOD7
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("pagoDetraccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("estado", Estado);
                cmd.Parameters.AddWithValue("fecha1", Fecha1);
                cmd.Parameters.AddWithValue("fecha2", Fecha2);
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
        public Boolean AprobarPago(int codigo, Int32 valor)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AprobarPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod", codigo);
                cmd.Parameters.AddWithValue("valor", valor);
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
        public Boolean VerificaDetraccionPendiente(int codigo)//MOD7
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VerificaDetraccionPendiente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codFactura", codigo);
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

        public DataTable MuestraListaPagosNota2(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraListaPagosPorNota2", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnot", CodNotaIngreso);
                cmd.Parameters.AddWithValue("ingegre", InOut);
                cmd.Parameters.AddWithValue("tipo", Tipo);
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

        public Boolean ActualizaPagoAprobado(String ser, String numdoc, Int32 codpag)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActualizaPagoAprobado", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ser", ser);
                cmd.Parameters.AddWithValue("numdoc", numdoc);
                cmd.Parameters.AddWithValue("codpag", codpag);
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

        public DataTable GetPagosVenta(Int32 codigoalmacen, Int32 codigoventa)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("GetPagosVenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codNota_ex", codigoventa);
                cmd.Parameters.AddWithValue("codAlmacen_ex", codigoalmacen);
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
