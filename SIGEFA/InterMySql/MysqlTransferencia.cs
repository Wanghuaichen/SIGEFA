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
    class MysqlTransferencia : ITransferencia
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITransferencia

        // metodos para transferencia "cabecera"

        public Boolean insert(clsTransferencia transf)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codalmaorig", transf.CodAlmacenOrigen);
                oParam = cmd.Parameters.AddWithValue("codtipo", transf.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codalmadest", transf.CodAlmacenDestino);

                oParam = cmd.Parameters.AddWithValue("moneda", transf.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", transf.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechaenvio", transf.FechaEnvio);
                oParam = cmd.Parameters.AddWithValue("fechaentrega", transf.FechaEntrega);

                oParam = cmd.Parameters.AddWithValue("codlista", transf.CodListaPrecio);
                oParam = cmd.Parameters.AddWithValue("descripcion", transf.DescripcionRechazo);
                oParam = cmd.Parameters.AddWithValue("comentario", transf.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", transf.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", transf.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", transf.Igv);
                oParam = cmd.Parameters.AddWithValue("total", transf.Total);
                oParam = cmd.Parameters.AddWithValue("estado", transf.Estado);
                oParam = cmd.Parameters.AddWithValue("formapago", transf.FormaPago);
                oParam = cmd.Parameters.AddWithValue("fechapago", transf.FechaPago);
                oParam = cmd.Parameters.AddWithValue("codusu", transf.CodUser);
                oParam = cmd.Parameters.AddWithValue("codserie_ex", transf.Codserie);
                oParam = cmd.Parameters.AddWithValue("serie_ex", transf.Serie);
                oParam = cmd.Parameters.AddWithValue("numerodoc_ex", transf.Numerodocumento);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                transf.CodTransDir = Convert.ToString(cmd.Parameters["newid"].Value);

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

        public Boolean update(clsTransferencia transf)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTranferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtransf", Convert.ToInt32(transf.CodTransDir));
                cmd.Parameters.AddWithValue("codalmaorig", transf.CodAlmacenOrigen);
                cmd.Parameters.AddWithValue("codtipo", transf.CodTipoDocumento);
                cmd.Parameters.AddWithValue("codalmadest", transf.CodAlmacenDestino);
                cmd.Parameters.AddWithValue("moneda", transf.Moneda);
                cmd.Parameters.AddWithValue("tipocambio", transf.TipoCambio);
                cmd.Parameters.AddWithValue("fechaenvio", transf.FechaEnvio);
                cmd.Parameters.AddWithValue("fechaentrega", transf.FechaEntrega);

                cmd.Parameters.AddWithValue("comentario", transf.Comentario);
                cmd.Parameters.AddWithValue("bruto", transf.MontoBruto);
                cmd.Parameters.AddWithValue("montodscto", transf.MontoDscto);
                cmd.Parameters.AddWithValue("igv", transf.Igv);
                cmd.Parameters.AddWithValue("total", transf.Total);
                cmd.Parameters.AddWithValue("estado", transf.Estado);
                cmd.Parameters.AddWithValue("formapago", transf.FormaPago);
                cmd.Parameters.AddWithValue("fechapago", transf.FechaPago);
                cmd.Parameters.AddWithValue("codlista", transf.CodListaPrecio);
                

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

        public Boolean delete(Int32 codtrans)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtrans", codtrans);
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

        public clsTransferencia CargaTransferencia(Int32 codtrans)
        {
            clsTransferencia trans = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTransferencia", con.conector);
                cmd.Parameters.AddWithValue("codtransf", codtrans);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        trans = new clsTransferencia();
                        trans.CodTransDir = dr.GetString(0);
                        trans.CodAlmacenOrigen = Convert.ToInt32(dr.GetDecimal(1));
                        trans.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));
                        trans.SiglaDocumento = dr.GetString(3);
                        trans.DescripcionDocumento = dr.GetString(4);
                        trans.CodAlmacenDestino = Convert.ToInt32(dr.GetString(5));
                        trans.Moneda = Convert.ToInt32(dr.GetString(6));
                        trans.TipoCambio = dr.GetDecimal(7);
                        trans.FechaEnvio = dr.GetDateTime(8);
                        trans.FechaEntrega = dr.GetDateTime(9);
                        trans.Comentario = dr.GetString(10);
                        trans.MontoBruto = dr.GetDecimal(11);
                        trans.MontoDscto = dr.GetDecimal(12);
                        trans.Igv = dr.GetDecimal(13);
                        trans.Total = dr.GetDecimal(14);
                        trans.Estado = Convert.ToInt32(dr.GetDecimal(15));
                        trans.FormaPago = Convert.ToInt32(dr.GetString(16));
                        trans.FechaPago = dr.GetDateTime(17);
                        trans.CodUser = Convert.ToInt32(dr.GetDecimal(18));
                        trans.FechaRegistro = dr.GetDateTime(19);
                        trans.DescripcionRechazo = dr.GetString(20);
                        trans.CodListaPrecio = Convert.ToInt32(dr.GetDecimal(21));
                        trans.Codserie = dr.GetInt32(22);
                        trans.Serie = dr.GetString(23);
                        trans.Numerodocumento = dr.GetString(24);
                    }
                }
                return trans;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsTransferencia BuscaTransferencia(String codtrans, Int32 codAlmacenOrigen)
        {
            clsTransferencia trans = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaTransferencia", con.conector);
                cmd.Parameters.AddWithValue("codtrans", Convert.ToInt32(codtrans));
                cmd.Parameters.AddWithValue("codAlmacenOrigen", codAlmacenOrigen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        trans = new clsTransferencia();
                        trans.CodTransDir = dr.GetString(0);
                        trans.CodAlmacenOrigen = Convert.ToInt32(dr.GetDecimal(1));
                        trans.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));
                        trans.SiglaDocumento = dr.GetString(3);
                        trans.DescripcionDocumento = dr.GetString(4);
                        trans.CodAlmacenDestino = Convert.ToInt32(dr.GetString(5));
                        trans.Moneda = Convert.ToInt32(dr.GetString(6));
                        trans.TipoCambio = dr.GetDecimal(7);
                        trans.FechaEnvio = dr.GetDateTime(8);
                        trans.FechaEntrega = dr.GetDateTime(9);
                        trans.Comentario = dr.GetString(10);
                        trans.MontoBruto = dr.GetDecimal(11);
                        trans.MontoDscto = dr.GetDecimal(12);
                        trans.Igv = dr.GetDecimal(13);
                        trans.Total = dr.GetDecimal(14);
                        trans.Estado = Convert.ToInt32(dr.GetDecimal(15));
                        trans.FormaPago = Convert.ToInt32(dr.GetString(16));
                        trans.FechaPago = dr.GetDateTime(17);
                        trans.CodUser = Convert.ToInt32(dr.GetDecimal(18));
                        trans.FechaRegistro = dr.GetDateTime(19);
                        trans.DescripcionRechazo = dr.GetString(20);
                        
                    }
                }
                return trans;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaTranferencias(Int32 caso, Int32 user, Int32 codAlmacen, DateTime desde, DateTime hasta)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTransferencias", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("caso", caso);
                cmd.Parameters.AddWithValue("usu", user);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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



        // metodos para detalle transferencia

        public Boolean insertdetalle(clsDetalleTransferencia detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codtrans", detalle.CodTransDir);
                oParam = cmd.Parameters.AddWithValue("codalmaorig", detalle.CodAlmacenOrigen);
                oParam = cmd.Parameters.AddWithValue("codalmadest", detalle.CodAlmacenDestino);
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
                oParam = cmd.Parameters.AddWithValue("cantidadp", detalle.CantidadPendiente);
                oParam = cmd.Parameters.AddWithValue("codprov", detalle.CodProv);
                oParam = cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("precioigv", detalle.Precioigv);
                oParam = cmd.Parameters.AddWithValue("codusu", detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("promedio", detalle.Valorpromedio);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detalle.CodDetalleTransfer = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean updatedetalle(clsDetalleTransferencia detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaDetalleTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", detalle.CodDetalleTransfer);
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

        public Boolean deletedetalle(Int32 coddeta)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarDetalleTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", coddeta);
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

        public DataTable CargaDetalle(Int32 codTransDir)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codTransDir", codTransDir);
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

        public Boolean rechazado(Int32 codTransDirecta, String desc)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("RechazarTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtrans", codTransDirecta);
                cmd.Parameters.AddWithValue("descripcion", desc);
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

        public Int32 unidadPA(Int32 codprod, Int32 codalma)
        {
            Int32 unidad = 0;
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("CogeUnidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", codprod);
                cmd.Parameters.AddWithValue("almaorg", codalma);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                         unidad =  Convert.ToInt32(dr.GetDecimal(0));
                    }
                }
             return unidad;   
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
            
        }

        public Double Factor(Int32 codprod, Int32 unidad, Int32 unidadequi)
        {
            Double fac = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CogeFactor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", codprod);
                cmd.Parameters.AddWithValue("unidad", unidad);
                cmd.Parameters.AddWithValue("unidadEqui", unidadequi);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fac = dr.GetDouble(0);
                    }
                }
                return fac;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        } 

        public Boolean devuelveproductos(clsDetalleTransferencia detalle)
        {
            
            try
            {
                Int32 unidad = unidadPA(detalle.CodProducto, detalle.CodAlmacenOrigen);
                Double factor = Factor(detalle.CodProducto,detalle.UnidadIngresada,unidad);
                factor = (factor*detalle.Cantidad);

                con.conectarBD();
                cmd = new MySqlCommand("ActualizaPA", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", detalle.CodProducto);
                cmd.Parameters.AddWithValue("almaorg", detalle.CodAlmacenOrigen);
                cmd.Parameters.AddWithValue("stock", factor);
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

        public Boolean Aprobar(Int32 codTransDirecta)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AprobarTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtrans", codTransDirecta);
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

        public DataTable CargaDetalleGuiaT(String CodigoTransferencia)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleTranferenciaGuia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtranf", CodigoTransferencia);
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
