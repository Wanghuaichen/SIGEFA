using MySql.Data.MySqlClient;
using SIGEFA.Conexion;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIGEFA.InterMySql
{
    class MysqlNotaCredito : INotaCredito
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public Boolean insert(clsNotaCredito nota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaNotaCredito", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("docnota", nota.DocumentoNotaCredito);
                oParam = cmd.Parameters.AddWithValue("codtran", nota.CodTipoTransaccion);
                oParam = cmd.Parameters.AddWithValue("codtipo", nota.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("numdoc", nota.NumFac);
                oParam = cmd.Parameters.AddWithValue("moneda", nota.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", nota.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechaingreso", nota.FechaIngreso);
                oParam = cmd.Parameters.AddWithValue("comentario", nota.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", nota.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", nota.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", nota.Igv);
                oParam = cmd.Parameters.AddWithValue("flete", nota.Flete);
                oParam = cmd.Parameters.AddWithValue("total", nota.Total);
                oParam = cmd.Parameters.AddWithValue("pendiente", nota.Total);
                oParam = cmd.Parameters.AddWithValue("estado", nota.Estado);
                oParam = cmd.Parameters.AddWithValue("recibido", nota.Recibido);
                if (nota.FormaPago != 0) { oParam = cmd.Parameters.AddWithValue("formapago", nota.FormaPago); } else { oParam = cmd.Parameters.AddWithValue("formapago", null); }
                oParam = cmd.Parameters.AddWithValue("fechapago", nota.FechaPago);
                oParam = cmd.Parameters.AddWithValue("fechacancelado", nota.FechaCancelado);
                oParam = cmd.Parameters.AddWithValue("cancelado", nota.Cancelado);
                oParam = cmd.Parameters.AddWithValue("codusu", nota.CodUser);
                oParam = cmd.Parameters.AddWithValue("codref", nota.CodReferencia);
                oParam = cmd.Parameters.AddWithValue("codser", nota.CodSerie);
                oParam = cmd.Parameters.AddWithValue("serie", nota.Serie);
                oParam = cmd.Parameters.AddWithValue("codcli", nota.CodCliente);
                oParam = cmd.Parameters.AddWithValue("codalma", nota.CodAlmacen);
                if (nota.Motivo != "") { cmd.Parameters.AddWithValue("motiv", nota.Motivo); } else { cmd.Parameters.AddWithValue("motiv", null); }
                oParam = cmd.Parameters.AddWithValue("codNotaI_ex", nota.CodNotaIngreso);
                oParam = cmd.Parameters.AddWithValue("codMovi", nota.MovimientoNC);
                oParam = cmd.Parameters.AddWithValue("gravadas_ex", nota.Gravadas);
                oParam = cmd.Parameters.AddWithValue("exoneradas_ex", nota.Exoneradas);
                oParam = cmd.Parameters.AddWithValue("inafectas_ex", nota.Inafectas);
                oParam = cmd.Parameters.AddWithValue("gratuitas_ex", nota.Gratuitas);
                oParam = cmd.Parameters.AddWithValue("tipofacturacion_ex", nota.Tipofacturacion);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                nota.CodNotaCreditoNueva = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool insertdetalle(clsDetalleNotaCredito Detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleNotaCredito", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", Detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codnotacredito", Detalle.CodNotaCredito);
                oParam = cmd.Parameters.AddWithValue("codnota", Detalle.CodNotaIngreso);
                oParam = cmd.Parameters.AddWithValue("moneda", Detalle.Moneda);
                oParam = cmd.Parameters.AddWithValue("unidad", Detalle.UnidadIngresada);
                oParam = cmd.Parameters.AddWithValue("serielote", Detalle.SerieLote);
                oParam = cmd.Parameters.AddWithValue("precio", Detalle.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", Detalle.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", Detalle.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", Detalle.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", Detalle.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", Detalle.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", Detalle.Igv);
                oParam = cmd.Parameters.AddWithValue("flete", Detalle.Flete);
                oParam = cmd.Parameters.AddWithValue("importe", Detalle.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", Detalle.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("valoreal", Detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("fecha", Detalle.FechaIngreso);
                oParam = cmd.Parameters.AddWithValue("codusu", Detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("codalma", Detalle.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("cant", Detalle.Cantidad);
                oParam = cmd.Parameters.AddWithValue("descrip", Detalle.Descripcion);
                oParam = cmd.Parameters.AddWithValue("Tipoimpuesto_ex", Detalle.TipoImpuesto);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                Detalle.CodDetalleNotaCredito = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaNotasCredito", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
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


        public clsNotaCredito CargaNotaCredito(Int32 CodNota)
        {
            clsNotaCredito nota = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNotaIngreso", con.conector);
                cmd.Parameters.AddWithValue("codnota", CodNota);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nota = new clsNotaCredito();
                        nota.CodNotaCredito = dr.GetString(0);
                        nota.CodAlmacen = Convert.ToInt32(dr.GetDecimal(1));
                        nota.CodTipoTransaccion = Convert.ToInt32(dr.GetDecimal(2));
                        nota.SiglaTransaccion = dr.GetString(3);
                        nota.DescripcionTransaccion = dr.GetString(4);
                        nota.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(5));
                        nota.SiglaDocumento = dr.GetString(6);
                        nota.DocumentoNotaCredito = dr.GetString(7);
                        nota.CodCliente = Convert.ToInt32(dr.GetString(8));
                        nota.RUCCliente = dr.GetString(9);
                        nota.RazonSocialCliente = dr.GetString(10);
                        nota.Moneda = Convert.ToInt32(dr.GetString(11));
                        nota.TipoCambio = dr.GetDouble(12);
                        nota.FechaIngreso = dr.GetDateTime(13);
                        nota.Comentario = dr.GetString(14);
                        nota.MontoBruto = dr.GetDouble(15);
                        nota.MontoDscto = dr.GetDouble(16);
                        nota.Igv = dr.GetDouble(17);
                        nota.Total = dr.GetDouble(18);
                        nota.Abonado = dr.GetDouble(19);
                        nota.Pendiente = dr.GetDouble(20);

                        nota.FormaPago = Convert.ToInt32(dr.GetString(23));
                        nota.FechaPago = dr.GetDateTime(24);
                        nota.Cancelado = Convert.ToInt32(dr.GetDecimal(25));
                        nota.CodUser = Convert.ToInt32(dr.GetDecimal(26));
                        nota.FechaRegistro = dr.GetDateTime(27);
                        nota.CodSerie = Convert.ToInt32(dr.GetDecimal(28));
                        nota.Serie = dr.GetString(29);
                        nota.CodReferencia = Convert.ToInt32(dr.GetDecimal(30));
                        nota.Flete = dr.GetDouble(31);
                        nota.SDocumentoOrden = dr.GetString(32);
                        nota.Motivo = dr.GetString(34);
                        
                        nota.Estado = Convert.ToInt32(dr.GetDecimal(21));
                        nota.Recibido = Convert.ToInt32(dr.GetDecimal(22));
                        nota.MovimientoNC = Convert.ToInt32(dr.GetDecimal(35));

                    }
                }
                return nota;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaDetalle(Int32 CodNota)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", CodNota);
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

        public List<clsNotaCredito> BuscarNotasXCliente(Int32 codCliente)
        {
            List<clsNotaCredito> lista = new List<clsNotaCredito>();
           clsNotaCredito nota = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNotaCxCliente", con.conector);
                cmd.Parameters.AddWithValue("codcli", codCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nota = new clsNotaCredito();
                        nota.CodNotaCredito = dr.GetString(0);
                        nota.Pendiente = dr.GetDouble(1);
                        nota.DocumentoNotaCredito = dr.GetString(2);
                        lista.Add(nota);

                    }
                }
                return lista;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public bool anular(Int32 codigonota)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularNotaCredito", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codventa", codigonota);
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

        public Boolean actualizarCodNotaCreditoFV(Int32 codFactura_venta,  Int32 codNota)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActualizarCodNocreditoFV", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codfac", codFactura_venta);
                oParam = cmd.Parameters.AddWithValue("codnota", codNota);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
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


        public Boolean anularFactura_venta(Int32 codFactura_venta)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularFacturaVenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codventa", codFactura_venta);
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


        public Boolean actualizarStockNotaCredito(Int32 codpro, double valor)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("actualizarSctockNotaCredito", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", codpro);
                oParam = cmd.Parameters.AddWithValue("valor", valor);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
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
    }
}
