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
    class MysqlPedido: IPedido
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IPedido

        public Boolean insert(clsPedido pedido)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaPedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codalma", pedido.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codtipo", pedido.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codcoti", pedido.CodCotizacion);
                oParam = cmd.Parameters.AddWithValue("tipocliente", pedido.TipoCliente);
                if (pedido.CodCliente != 0) { oParam = cmd.Parameters.AddWithValue("codcli", pedido.CodCliente); } else { oParam = cmd.Parameters.AddWithValue("codcli", null); }
                oParam = cmd.Parameters.AddWithValue("moneda", pedido.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", pedido.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechapedido", pedido.FechaPedido);
                oParam = cmd.Parameters.AddWithValue("fechaentrega", pedido.FechaEntrega);
                oParam = cmd.Parameters.AddWithValue("codlista", pedido.CodListaPrecio);
                oParam = cmd.Parameters.AddWithValue("auto", pedido.CodAutorizado);
                oParam = cmd.Parameters.AddWithValue("comentario", pedido.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", pedido.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", pedido.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", pedido.Igv);
                oParam = cmd.Parameters.AddWithValue("total", pedido.Total);
                oParam = cmd.Parameters.AddWithValue("estado", pedido.Estado);
                oParam = cmd.Parameters.AddWithValue("formapago", pedido.FormaPago);
                oParam = cmd.Parameters.AddWithValue("fechapago", pedido.FechaPago);
                oParam = cmd.Parameters.AddWithValue("codusu", pedido.CodUser);
                oParam = cmd.Parameters.AddWithValue("nombrecliente", pedido.Nombrecliente);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pedido.CodPedido = Convert.ToString(cmd.Parameters["newid"].Value);

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

        public Boolean update(clsPedido pedido)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaPedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpedid", Convert.ToInt32(pedido.CodPedido));
                cmd.Parameters.AddWithValue("codalma", pedido.CodAlmacen);               
                cmd.Parameters.AddWithValue("codtipo", pedido.CodTipoDocumento);
                cmd.Parameters.AddWithValue("codcoti", pedido.CodCotizacion);
                cmd.Parameters.AddWithValue("tipoclient", pedido.TipoCliente);
                if (pedido.CodCliente != 0) { cmd.Parameters.AddWithValue("codcli", pedido.CodCliente); } else { cmd.Parameters.AddWithValue("codcli", null); }
                cmd.Parameters.AddWithValue("moned", pedido.Moneda);
                cmd.Parameters.AddWithValue("tipocambi", pedido.TipoCambio);
                cmd.Parameters.AddWithValue("fechapedid", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("fechaentreg", pedido.FechaEntrega);
                cmd.Parameters.AddWithValue("codlist", pedido.CodListaPrecio);
                cmd.Parameters.AddWithValue("auto", pedido.CodAutorizado);
                cmd.Parameters.AddWithValue("comentari", pedido.Comentario);
                cmd.Parameters.AddWithValue("brut", pedido.MontoBruto);
                cmd.Parameters.AddWithValue("montodsct", pedido.MontoDscto);
                cmd.Parameters.AddWithValue("ig", pedido.Igv);
                cmd.Parameters.AddWithValue("tota", pedido.Total);
                cmd.Parameters.AddWithValue("estad", pedido.Estado);
                cmd.Parameters.AddWithValue("formapag", pedido.FormaPago);
                cmd.Parameters.AddWithValue("fechapag", pedido.FechaPago);
                cmd.Parameters.AddWithValue("nomcliente", pedido.Nombrecliente);
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

        public Boolean delete(Int32 CodigoPedido)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarPedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codped", CodigoPedido);
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


        public Boolean insertdetalle(clsDetallePedido detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetallePedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codpedido", detalle.CodPedido);
                oParam = cmd.Parameters.AddWithValue("codalma", detalle.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("unidad", detalle.UnidadIngresada);
                oParam = cmd.Parameters.AddWithValue("serielote", detalle.SerieLote);
                oParam = cmd.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                oParam = cmd.Parameters.AddWithValue("precio", detalle.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", detalle.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", detalle.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", detalle.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", detalle.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", detalle.Igv);
                oParam = cmd.Parameters.AddWithValue("importe", detalle.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("codprov", detalle.CodProv);
                oParam = cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("precioigv", detalle.Precioigv);
                oParam = cmd.Parameters.AddWithValue("codusu", detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("promedio", detalle.Valorpromedio);
                oParam = cmd.Parameters.AddWithValue("pmargen", detalle.PrecioMargen);
                oParam = cmd.Parameters.AddWithValue("codtidoc", detalle.Codtipodoc);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detalle.CodDetallePedido = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean updatedetalle(clsDetallePedido detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaDetallePedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", detalle.CodDetallePedido);
                cmd.Parameters.AddWithValue("unidad", detalle.UnidadIngresada);
                cmd.Parameters.AddWithValue("serielote", detalle.SerieLote);
                cmd.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("precio", detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);
                cmd.Parameters.AddWithValue("descuento1", detalle.Descuento1);
                cmd.Parameters.AddWithValue("descuento2", detalle.Descuento2);
                cmd.Parameters.AddWithValue("descuento3", detalle.Descuento3);
                cmd.Parameters.AddWithValue("montodscto", detalle.MontoDescuento);
                cmd.Parameters.AddWithValue("igv", detalle.Igv);
                cmd.Parameters.AddWithValue("importe", detalle.Importe);
                cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
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

        public Boolean deletedetalle(Int32 CodigoDetalle)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarDetallePedido", con.conector);
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

        public clsPedido CargaPedido(Int32 CodPedido)
        {
            clsPedido pedido = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPedido", con.conector);
                cmd.Parameters.AddWithValue("codpedido", CodPedido);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pedido = new clsPedido();
                        pedido.CodPedido = dr.GetString(0);
                        pedido.CodAlmacen = Convert.ToInt32(dr.GetDecimal(1));
                        pedido.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));
                        pedido.SiglaDocumento = dr.GetString(3);
                        pedido.DescripcionDocumento = dr.GetString(4);
                        pedido.TipoCliente = Convert.ToInt32(dr.GetString(5));
                        pedido.CodCliente = Convert.ToInt32(dr.GetString(6));
                        pedido.DNI = dr.GetString(7);
                        pedido.RUCCliente = dr.GetString(8);
                        pedido.CodigoPersonalizado = dr.GetString(9);
                        pedido.RazonSocialCliente = dr.GetString(10);
                        pedido.Nombre = dr.GetString(11);
                        pedido.Direccion = dr.GetString(12);
                        pedido.Moneda = Convert.ToInt32(dr.GetString(13));
                        pedido.TipoCambio = dr.GetDouble(14);
                        pedido.FechaPedido = dr.GetDateTime(15);
                        pedido.FechaEntrega = dr.GetDateTime(16);
                        pedido.Comentario = dr.GetString(17);
                        pedido.MontoBruto = dr.GetDouble(18);
                        pedido.MontoDscto = dr.GetDouble(19);
                        pedido.Igv = dr.GetDouble(20);
                        pedido.Total = dr.GetDouble(21);
                        pedido.Estado = Convert.ToInt32(dr.GetDecimal(22));
                        pedido.FormaPago = Convert.ToInt32(dr.GetString(23));
                        pedido.FechaPago = dr.GetDateTime(24);
                        pedido.CodUser = Convert.ToInt32(dr.GetDecimal(25));
                        pedido.FechaRegistro = dr.GetDateTime(26);
                        pedido.CodAutorizado = Convert.ToInt32(dr.GetDecimal(27));
                        pedido.NombreAutorizado = dr.GetString(28);
                        pedido.CodListaPrecio = Convert.ToInt32(dr.GetDecimal(29));
                        pedido.CodCotizacion = Convert.ToInt32(dr.GetDecimal(30));
                        pedido.Nombrecliente = dr.GetString(31);
                        pedido.Numeracion = dr.GetInt32(32);

                    }
                }
                return pedido;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsPedido BuscaPedido(String CodPedido, Int32 CodAlmacen)
        {
            clsPedido pedido = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaPedido", con.conector);
                cmd.Parameters.AddWithValue("codpe", Convert.ToInt32(CodPedido));
                cmd.Parameters.AddWithValue("codalm", CodAlmacen);
                cmd.Parameters.AddWithValue("tipo", 1);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pedido = new clsPedido();
                        pedido.CodPedido = dr.GetString(0);
                        pedido.CodTipoDocumento = dr.GetInt32(1);
                        pedido.SiglaDocumento = dr.GetString(2);
                        pedido.TipoCliente = dr.GetInt32(3);
                        pedido.CodCliente = dr.GetInt32(4);
                        pedido.DNI = dr.GetString(5);
                        pedido.RUCCliente = dr.GetString(6);
                        pedido.CodigoPersonalizado = dr.GetString(7);
                        pedido.RazonSocialCliente = dr.GetString(8);
                        pedido.Nombre = dr.GetString(9);
                        pedido.Direccion = dr.GetString(10);
                        pedido.Moneda = dr.GetInt32(11);
                        pedido.TipoCambio = dr.GetDouble(12);
                        pedido.FechaPedido = dr.GetDateTime(13);
                        pedido.FechaEntrega = dr.GetDateTime(14);
                        pedido.Comentario = dr.GetString(15);
                        pedido.MontoBruto = dr.GetDouble(16);
                        pedido.MontoDscto = dr.GetDouble(17);
                        pedido.Igv = dr.GetDouble(18);
                        pedido.Total = dr.GetDouble(19);
                        pedido.Estado = dr.GetInt32(20);
                        pedido.Pendiente = dr.GetInt32(21);
                        pedido.FormaPago = dr.GetInt32(22);
                        pedido.FechaPago = dr.GetDateTime(23);
                        pedido.CodUser = dr.GetInt32(24);
                        pedido.FechaRegistro = dr.GetDateTime(25);
                        pedido.CodListaPrecio = dr.GetInt32(26);
                        pedido.CodCotizacion = dr.GetInt32(27);
                        pedido.Numeracion = dr.GetInt32(28);
                    }
                }
                return pedido;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataTable CargaDetalle(Int32 CodPedido)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetallePedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpedido", CodPedido);
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

        public DataTable CargaDetalleGuia(Int32 CodPedido)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetallePedidoGuia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpedido", CodPedido);
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


        public DataTable ListaPedidos(Int32 user, Int32 CodAlmacen, DateTime desde, DateTime hasta)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaPedidos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("usu", user);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("fechaini", desde);
                cmd.Parameters.AddWithValue("fechafin", hasta);
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

        public clsPedido CargaEntrega(Int32 CodEntrega)
        {
            clsPedido pedido = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraEntrega", con.conector);
                cmd.Parameters.AddWithValue("codentrega", CodEntrega);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pedido = new clsPedido();
                        pedido.CodPedido = dr.GetString(0);
                        pedido.CodAlmacen = Convert.ToInt32(dr.GetDecimal(1));
                        pedido.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));
                        pedido.SiglaDocumento = dr.GetString(3);
                        pedido.DescripcionDocumento = dr.GetString(4);
                        pedido.TipoCliente = Convert.ToInt32(dr.GetString(5));
                        pedido.CodCliente = Convert.ToInt32(dr.GetString(6));
                        pedido.DNI = dr.GetString(7);
                        pedido.RUCCliente = dr.GetString(8);
                        pedido.CodigoPersonalizado = dr.GetString(9);
                        pedido.RazonSocialCliente = dr.GetString(10);
                        pedido.Nombre = dr.GetString(11);
                        pedido.Direccion = dr.GetString(12);
                        pedido.Moneda = Convert.ToInt32(dr.GetString(13));
                        pedido.TipoCambio = dr.GetDouble(14);
                        pedido.FechaPedido = dr.GetDateTime(15);
                        pedido.FechaEntrega = dr.GetDateTime(16);
                        pedido.Comentario = dr.GetString(17);
                        pedido.MontoBruto = dr.GetDouble(18);
                        pedido.MontoDscto = dr.GetDouble(19);
                        pedido.Igv = dr.GetDouble(20);
                        pedido.Total = dr.GetDouble(21);
                        pedido.Estado = Convert.ToInt32(dr.GetDecimal(22));
                        pedido.FormaPago = Convert.ToInt32(dr.GetString(23));
                        pedido.FechaPago = dr.GetDateTime(24);
                        pedido.CodUser = Convert.ToInt32(dr.GetDecimal(25));
                        pedido.FechaRegistro = dr.GetDateTime(26);
                        pedido.CodAutorizado = Convert.ToInt32(dr.GetDecimal(27));
                        pedido.NombreAutorizado = dr.GetString(28);
                        pedido.CodListaPrecio = Convert.ToInt32(dr.GetDecimal(29));
                        pedido.CodCotizacion = Convert.ToInt32(dr.GetDecimal(30));
                    }
                }
                return pedido;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaDetalleEntrega(Int32 CodEntrega)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleEntrega", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codentrega", CodEntrega);
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

        public Boolean insertEntConsExt(clsPedido pedido)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaEntregaConsultorExt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codalma", pedido.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codtipo", pedido.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codcoti", pedido.CodCotizacion);
                oParam = cmd.Parameters.AddWithValue("tipocliente", pedido.TipoCliente);
                if (pedido.CodCliente != 0) { oParam = cmd.Parameters.AddWithValue("codcli", pedido.CodCliente); } else { oParam = cmd.Parameters.AddWithValue("codcli", null); }
                oParam = cmd.Parameters.AddWithValue("moneda", pedido.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", pedido.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechapedido", pedido.FechaPedido);
                oParam = cmd.Parameters.AddWithValue("fechaentrega", pedido.FechaEntrega);
                oParam = cmd.Parameters.AddWithValue("codlista", pedido.CodListaPrecio);
                oParam = cmd.Parameters.AddWithValue("auto", pedido.CodAutorizado);
                oParam = cmd.Parameters.AddWithValue("comentario", pedido.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", pedido.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", pedido.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", pedido.Igv);
                oParam = cmd.Parameters.AddWithValue("total", pedido.Total);
                oParam = cmd.Parameters.AddWithValue("estado", pedido.Estado);
                oParam = cmd.Parameters.AddWithValue("formapago", pedido.FormaPago);
                oParam = cmd.Parameters.AddWithValue("fechapago", pedido.FechaPago);
                oParam = cmd.Parameters.AddWithValue("codusu", pedido.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pedido.CodPedido = Convert.ToString(cmd.Parameters["newid"].Value);

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

        public Boolean updatedetallesalidaconsultext(clsDetallePedido detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaDetalleconsultext", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", detalle.CodDetallePedido);
                cmd.Parameters.AddWithValue("codpro", detalle.CodProducto);
                cmd.Parameters.AddWithValue("unidad", detalle.UnidadIngresada);
                cmd.Parameters.AddWithValue("serielote", detalle.SerieLote);
                cmd.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("precio", detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);
                cmd.Parameters.AddWithValue("dscto1", detalle.Descuento1);
                cmd.Parameters.AddWithValue("dscto2", detalle.Descuento2);
                cmd.Parameters.AddWithValue("dscto3", detalle.Descuento3);
                cmd.Parameters.AddWithValue("montodscto", detalle.MontoDescuento);
                cmd.Parameters.AddWithValue("igv", detalle.Igv);
                cmd.Parameters.AddWithValue("importe", detalle.Importe);
                cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);

                cmd.Parameters.AddWithValue("cantidaddevuelta", detalle.DCantidadDevuelta);
                cmd.Parameters.AddWithValue("cantidadvendida", detalle.DCantidadVendida);
                cmd.Parameters.AddWithValue("importedev", detalle.IImpDevuelto);
                cmd.Parameters.AddWithValue("importevend", detalle.IImpVend);
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

        public Boolean deleteEntConsExt(Int32 CodEntConExt)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarEntregaConsultorExt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codentconext", CodEntConExt);
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

        public DataTable MuestraEntregasConsultorExt(Int32 CodAlmacen, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaEntregasConsultorExt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
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

        public Boolean insertdetalleconsultor(clsDetallePedido detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleConsultor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codpedido", detalle.CodPedido);
                oParam = cmd.Parameters.AddWithValue("codalma", detalle.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("unidad", detalle.UnidadIngresada);
                oParam = cmd.Parameters.AddWithValue("serielote", detalle.SerieLote);
                oParam = cmd.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                oParam = cmd.Parameters.AddWithValue("precio", detalle.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", detalle.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", detalle.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", detalle.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", detalle.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", detalle.Igv);
                oParam = cmd.Parameters.AddWithValue("importe", detalle.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("codusu", detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detalle.CodDetallePedido = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean liquidar(Int32 CodigoPedido)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("LiquidarPedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codped", CodigoPedido);
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

        public Boolean rollbackpedido(Int32 codpedido)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("rollbackpedido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codped", codpedido);

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


        #endregion
    }
}
