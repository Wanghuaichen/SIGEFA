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
    class MysqlOrdenCompra:IOrdenCompra
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region IOrdenCompra Members

        public bool insert(clsOrdenCompra Orden)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codAlmacen_ex", Orden.CodAlmacen);
                if (Orden.CodProveedor != 0) { oParam = cmd.Parameters.AddWithValue("codProveedor_ex", Orden.CodProveedor); } else { oParam = cmd.Parameters.AddWithValue("codProveedor_ex", null); }
                oParam = cmd.Parameters.AddWithValue("comentario_ex", Orden.Comentario);
                oParam = cmd.Parameters.AddWithValue("codTipoDocumento_ex", Orden.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codserie_ex", Orden.CodSerie);
                oParam = cmd.Parameters.AddWithValue("numeracion_ex", Orden.NumDoc);
                oParam = cmd.Parameters.AddWithValue("fechaorden_ex", Orden.FechaIngreso);
                oParam = cmd.Parameters.AddWithValue("codUsuario_ex", Orden.CodUser);
                oParam = cmd.Parameters.AddWithValue("moneda_ex", Orden.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio_ex", Orden.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("bruto_ex", Orden.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto_ex", Orden.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv_ex", Orden.Igv);
                oParam = cmd.Parameters.AddWithValue("total_ex", Orden.Total);
                oParam = cmd.Parameters.AddWithValue("formapago_ex", Orden.FormaPago);
                oParam = cmd.Parameters.AddWithValue("fechapago_ex", Orden.FechaPago);
                oParam = cmd.Parameters.AddWithValue("flete_ex", Orden.Flete);                
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                Orden.CodOrdenCompraNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool update(clsOrdenCompra Orden)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codOrd", Convert.ToInt32(Orden.CodOrdenCompra));
                cmd.Parameters.AddWithValue("codalma", Orden.CodAlmacen);
                if (Orden.CodProveedor != 0) { cmd.Parameters.AddWithValue("codprov", Orden.CodProveedor); } else { cmd.Parameters.AddWithValue("codprov", null); }
                cmd.Parameters.AddWithValue("moneda", Orden.Moneda);
                cmd.Parameters.AddWithValue("tipocambio", Orden.TipoCambio);
                cmd.Parameters.AddWithValue("fechaingreso", Orden.FechaIngreso);
                cmd.Parameters.AddWithValue("comentario", Orden.Comentario);
                cmd.Parameters.AddWithValue("bruto", Orden.MontoBruto);
                cmd.Parameters.AddWithValue("montodscto", Orden.MontoDscto);
                cmd.Parameters.AddWithValue("igv", Orden.Igv);
                cmd.Parameters.AddWithValue("total", Orden.Total);
                cmd.Parameters.AddWithValue("estado", Orden.Estado);
                cmd.Parameters.AddWithValue("formapago", Orden.FormaPago);
                cmd.Parameters.AddWithValue("fechapago", Orden.FechaPago);
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

        public bool delete(int CodigoOrden)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codOrd", CodigoOrden);
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

        public bool anular(int CodigoOrden)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codOrd", CodigoOrden);
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

        public bool activar(int CodigoOrden)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActivarOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codOrd", CodigoOrden);
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

        public bool insertdetalle(clsDetalleOrdenCompra Detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleOrden", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", Detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codOrd", Detalle.CodOrdenCompra);
                oParam = cmd.Parameters.AddWithValue("codalma", Detalle.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("moneda", Detalle.Moneda);
                oParam = cmd.Parameters.AddWithValue("unidad", Detalle.UnidadIngresada);
                oParam = cmd.Parameters.AddWithValue("serielote", Detalle.SerieLote);
                oParam = cmd.Parameters.AddWithValue("cantidad", Detalle.Cantidad);
                oParam = cmd.Parameters.AddWithValue("precio", Detalle.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", Detalle.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", Detalle.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", Detalle.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", Detalle.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", Detalle.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", Detalle.Igv);
                oParam = cmd.Parameters.AddWithValue("importe", Detalle.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", Detalle.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("valoreal", Detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("fecha", Detalle.FechaIngreso);
                oParam = cmd.Parameters.AddWithValue("codusu", Detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("codProve", Detalle.CodProveedor);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                Detalle.CodDetalleOrdenCompra = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool updatedetalle(clsDetalleOrdenCompra Detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaDetalleOrden", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", Detalle.CodDetalleOrdenCompra);
                cmd.Parameters.AddWithValue("moneda", Detalle.Moneda);
                cmd.Parameters.AddWithValue("unidad", Detalle.UnidadIngresada);
                cmd.Parameters.AddWithValue("serielote", Detalle.SerieLote);
                cmd.Parameters.AddWithValue("cantidad", Detalle.Cantidad);
                cmd.Parameters.AddWithValue("precio", Detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("subtotal", Detalle.Subtotal);
                cmd.Parameters.AddWithValue("dscto1", Detalle.Descuento1);
                cmd.Parameters.AddWithValue("dscto2", Detalle.Descuento2);
                cmd.Parameters.AddWithValue("dscto3", Detalle.Descuento3);
                cmd.Parameters.AddWithValue("montodscto", Detalle.MontoDescuento);
                cmd.Parameters.AddWithValue("igv", Detalle.Igv);
                cmd.Parameters.AddWithValue("importe", Detalle.Importe);
                cmd.Parameters.AddWithValue("precioreal", Detalle.PrecioReal);
                cmd.Parameters.AddWithValue("valoreal", Detalle.ValoReal);
                cmd.Parameters.AddWithValue("fecha", Detalle.FechaIngreso);
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

        public bool deletedetalle(int CodigoDetalle)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarDetalleOrden", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", CodigoDetalle);
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

        public clsOrdenCompra CargaOrdenCompra(int CodOrden)
        {
            clsOrdenCompra orden = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraOrdenCompra", con.conector);
                cmd.Parameters.AddWithValue("codOrd", CodOrden);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        orden = new clsOrdenCompra();
                        orden.CodOrdenCompra = dr.GetInt32(0);
                        orden.CodAlmacen = dr.GetInt32(1);
                        orden.CodProveedor = Convert.ToInt32(dr.GetString(2));
                        orden.RUCProveedor = dr.GetString(3);
                        orden.RazonSocialProveedor = dr.GetString(4);
                        orden.Moneda = Convert.ToInt32(dr.GetString(5));
                        orden.TipoCambio = dr.GetDecimal(6);
                        orden.FechaIngreso = dr.GetDateTime(7);
                        orden.Comentario = dr.GetString(8);
                        orden.MontoBruto = dr.GetDecimal(9);
                        orden.MontoDscto = dr.GetDecimal(10);
                        orden.Igv = dr.GetDecimal(11);
                        orden.Total = dr.GetDecimal(12);
                        orden.Estado = dr.GetBoolean(13);
                        orden.FormaPago = Convert.ToInt32(dr.GetString(14));
                        orden.FechaPago = dr.GetDateTime(15);
                        orden.CodUser = Convert.ToInt32(dr.GetDecimal(16));
                        orden.FechaRegistro = dr.GetDateTime(17);
                    }
                }
                return orden;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaDetalle(int CodOrden)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleOrdenCompra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codOrd", CodOrden);
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

        public DataTable ListaOrdenesCompra(int Criterio, int CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaOrdenes", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("criterio", Criterio);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("fechaini", FechaInicial);
                cmd.Parameters.AddWithValue("fechafin", FechaFinal);
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

        public DataTable ListaOrdenes(Int32 CodAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaOrdenesCompra", con.conector);
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

        public clsOrdenCompra BuscaOrden(String CodOrden, Int32 CodAlmacen)
        {
            clsOrdenCompra orden = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaOrden", con.conector);
                cmd.Parameters.AddWithValue("cod", Convert.ToInt32(CodOrden));
                cmd.Parameters.AddWithValue("codalm", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        orden = new clsOrdenCompra();
                        orden.CodOrdenCompra = dr.GetInt32(0);
                        orden.CodProveedor = dr.GetInt32(1);
                        orden.RUCProveedor = dr.GetString(2);
                        orden.ReferenciaProveedor = dr.GetString(3);
                        orden.RazonSocialProveedor = dr.GetString(4);
                        orden.Moneda = dr.GetInt32(5);
                        orden.TipoCambio = dr.GetDecimal(6);
                        orden.FechaIngreso = dr.GetDateTime(7);
                        orden.Comentario = dr.GetString(8);
                        orden.MontoBruto = dr.GetDecimal(9);
                        orden.MontoDscto = dr.GetDecimal(10);
                        orden.Igv = dr.GetDecimal(11);
                        orden.Total = dr.GetDecimal(12);
                        orden.Estado = dr.GetBoolean(13);
                        orden.FormaPago = dr.GetInt32(14);
                        orden.FechaPago = dr.GetDateTime(15);
                        orden.CodUser = dr.GetInt32(16);
                        orden.FechaRegistro = dr.GetDateTime(17);
                        orden.Pendiente = dr.GetBoolean(18);
                    }
                }
                return orden;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaOrden()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaOrdenCompra", con.conector);
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

        public DataTable StockActualProducto(Int32 CodProducto)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("StockActualProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", CodProducto);
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
