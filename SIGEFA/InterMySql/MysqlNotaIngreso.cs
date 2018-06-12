using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;
using System.Windows.Forms;

namespace SIGEFA.InterMySql
{
    class MysqlNotaIngreso:INotaIngreso
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion INotaIngreso

        public Boolean insert(clsNotaIngreso nota)
        {
            try
            {
                con.conectarBD();
                String msj = "";
                cmd = new MySqlCommand("GuardaNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codalma", nota.CodAlmacen);                
                oParam = cmd.Parameters.AddWithValue("codtran", nota.CodTipoTransaccion);
                oParam = cmd.Parameters.AddWithValue("codtipo", nota.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("numdoc", nota.NumDoc);
                if (nota.CodProveedor != 0) { oParam = cmd.Parameters.AddWithValue("codprov", nota.CodProveedor); } else { oParam = cmd.Parameters.AddWithValue("codprov", null); }
                oParam = cmd.Parameters.AddWithValue("moneda", nota.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", nota.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("fechaingreso", nota.FechaIngreso);
                oParam = cmd.Parameters.AddWithValue("comentario", nota.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", nota.MontoBruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", nota.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("igv", nota.Igv);
                oParam = cmd.Parameters.AddWithValue("flete", nota.Flete);
                oParam = cmd.Parameters.AddWithValue("total", nota.Total);
                oParam = cmd.Parameters.AddWithValue("pend", nota.Total);  
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
                oParam = cmd.Parameters.AddWithValue("CodOrd", nota.CodOrdenCompra);
                oParam = cmd.Parameters.AddWithValue("codalmacenemisor_ex", nota.codalmacenemisor);
                oParam = cmd.Parameters.AddWithValue("aplicad", nota.Aplicada);
                if (nota.Aplicada != 0) { oParam = cmd.Parameters.AddWithValue("codaplicad", nota.CodAplicada); } else { oParam = cmd.Parameters.AddWithValue("codaplicad", null); }
                if (nota.Motivo != "") { cmd.Parameters.AddWithValue("motiv", nota.Motivo); } else { cmd.Parameters.AddWithValue("motiv", null); }
                oParam = cmd.Parameters.AddWithValue("codTransferencia_ex", nota.Codtransferencia);
                
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                nota.CodNotaIngreso = Convert.ToString(cmd.Parameters["newid"].Value);
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

        public Boolean ActualizaCantidadPendiente(Double cantidad, Int32 produc, Int32 CodOrden,Int32 coddeta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaOrdenCompraCantidadPendiente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cant", cantidad);
                cmd.Parameters.AddWithValue("codpro", produc);
                cmd.Parameters.AddWithValue("codord", CodOrden);
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

        public Boolean ActualizaCantidadPendiente2(Double cantidad, Int32 produc, Int32 alma, Int32 coduser)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaCantidadPendienteProductoAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cant", cantidad);
                cmd.Parameters.AddWithValue("codpro", produc);
                cmd.Parameters.AddWithValue("alma", alma);
                cmd.Parameters.AddWithValue("coduser", coduser);
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

        public Boolean ActualizaCodNotaIngreso(Double cantidad, Int32 produc, Int32 CodDetalle, Int32 tipo)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaCodNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cant", cantidad);
                cmd.Parameters.AddWithValue("codpro", produc);
                cmd.Parameters.AddWithValue("CodDetalle", CodDetalle);
                cmd.Parameters.AddWithValue("tipo", tipo);
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

        public Boolean update(clsNotaIngreso nota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", Convert.ToInt32(nota.CodNotaIngreso));
                cmd.Parameters.AddWithValue("codalma", nota.CodAlmacen);
                cmd.Parameters.AddWithValue("codtran", nota.CodTipoTransaccion);
                cmd.Parameters.AddWithValue("codtipo", nota.CodTipoDocumento);
                cmd.Parameters.AddWithValue("numdoc", nota.NumDoc);
                if (nota.CodProveedor != 0) { cmd.Parameters.AddWithValue("codprov", nota.CodProveedor); } else { cmd.Parameters.AddWithValue("codprov", null); }
                cmd.Parameters.AddWithValue("moneda", nota.Moneda);
                cmd.Parameters.AddWithValue("tipocambio", nota.TipoCambio);
                cmd.Parameters.AddWithValue("fechaingreso", nota.FechaIngreso);
                cmd.Parameters.AddWithValue("comentario", nota.Comentario);
                cmd.Parameters.AddWithValue("bruto", nota.MontoBruto);
                cmd.Parameters.AddWithValue("montodscto", nota.MontoDscto);
                cmd.Parameters.AddWithValue("igv", nota.Igv);
                cmd.Parameters.AddWithValue("flete", nota.Flete);
                cmd.Parameters.AddWithValue("total", nota.Total);
                cmd.Parameters.AddWithValue("estado", nota.Estado);
                cmd.Parameters.AddWithValue("recibido", nota.Recibido);
                cmd.Parameters.AddWithValue("formapago", nota.FormaPago);
                cmd.Parameters.AddWithValue("fechapago", nota.FechaPago);
                cmd.Parameters.AddWithValue("fechacancelado", nota.FechaCancelado);
                cmd.Parameters.AddWithValue("cancelado", nota.Cancelado);
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

        public Boolean delete(Int32 CodigoNota)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", CodigoNota);
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

        public Boolean anular(Int32 CodSerie, String NumDoc, String text)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod", CodSerie);
                cmd.Parameters.AddWithValue("numero", NumDoc);
                cmd.Parameters.AddWithValue("comentario", text);
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

        public Boolean anular1(Int32 codigo)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularNotaIngreso1", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", codigo);
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

        public Boolean activar(Int32 CodigoNota)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActivarNotaIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", CodigoNota);
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

        public bool atender(int codigo, int CodSerie, String NumDoc, Int32 User)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AtenderTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("cod", CodSerie);
                cmd.Parameters.AddWithValue("numero", NumDoc);
                cmd.Parameters.AddWithValue("Usu", User);
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

        public Boolean insertdetalle(clsDetalleNotaIngreso detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", detalle.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codnota", detalle.CodNotaIngreso);
                oParam = cmd.Parameters.AddWithValue("codalma", detalle.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("moneda", detalle.Moneda);
                oParam = cmd.Parameters.AddWithValue("unidad", detalle.UnidadIngresada);
                oParam = cmd.Parameters.AddWithValue("serielote", detalle.SerieLote);
                oParam = cmd.Parameters.AddWithValue("canti", detalle.Cantidad);
                oParam = cmd.Parameters.AddWithValue("precio", detalle.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", detalle.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", detalle.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", detalle.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", detalle.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", detalle.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", detalle.Igv);
                oParam = cmd.Parameters.AddWithValue("flete", detalle.Flete);
                oParam = cmd.Parameters.AddWithValue("importe", detalle.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
                oParam = cmd.Parameters.AddWithValue("fecha", detalle.FechaIngreso); 
                oParam = cmd.Parameters.AddWithValue("codusu", detalle.CodUser);
                oParam = cmd.Parameters.AddWithValue("valorrealS", detalle.ValorrealSoles);
                oParam = cmd.Parameters.AddWithValue("codrequer", detalle.CodDetalleRequerimiento);
                oParam = cmd.Parameters.AddWithValue("bonific", detalle.Bonificacion);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detalle.CodDetalleIngreso = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public bool insertdetalleConsolidado(Int32 orden,Int32 nota, Int32 codAlma, Int32 codUsu )
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleConsolidadoNota", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codord", orden);
                oParam = cmd.Parameters.AddWithValue("codnota", nota);
                oParam = cmd.Parameters.AddWithValue("alma", codAlma);
                oParam = cmd.Parameters.AddWithValue("usu", codUsu);
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

        public Boolean updatedetalle(clsDetalleNotaIngreso detalle)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaDetalleIngreso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddeta", detalle.CodDetalleIngreso);
                cmd.Parameters.AddWithValue("moneda", detalle.Moneda);
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
                cmd.Parameters.AddWithValue("flete", detalle.Flete);
                cmd.Parameters.AddWithValue("importe", detalle.Importe);
                cmd.Parameters.AddWithValue("precioreal", detalle.PrecioReal);
                cmd.Parameters.AddWithValue("valoreal", detalle.ValoReal);
                cmd.Parameters.AddWithValue("fecha", detalle.FechaIngreso); 
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

        public bool deleteConsolidado(Int32 codalma, Int32 codusu)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarConsolidadoNota", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("codusu", codusu);
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
                cmd = new MySqlCommand("EliminarDetalleIngreso", con.conector);
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

        public clsNotaIngreso CargaNotaIngreso(Int32 CodNota)
        {
            clsNotaIngreso nota = null;
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
                        nota = new clsNotaIngreso();
                        nota.CodNotaIngreso = dr.GetString(0);
                        nota.CodAlmacen = Convert.ToInt32(dr.GetDecimal(1));
                        nota.CodTipoTransaccion = Convert.ToInt32(dr.GetDecimal(2));
                        nota.SiglaTransaccion = dr.GetString(3);
                        nota.DescripcionTransaccion = dr.GetString(4);
                        nota.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(5));
                        nota.SiglaDocumento = dr.GetString(6);
                        nota.NumDoc = dr.GetString(7);
                        nota.CodProveedor = Convert.ToInt32(dr.GetString(8));
                        nota.RUCProveedor = dr.GetString(9);
                        nota.RazonSocialProveedor = dr.GetString(10);
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
                        nota.codalmacenemisor = dr.GetInt32(33);
                        nota.Codconductor = dr.GetInt32(34);
                        nota.Codvehiculotransporte = dr.GetInt32(35);
                        nota.Estado = Convert.ToInt32(dr.GetDecimal(21));
                        nota.Recibido = Convert.ToInt32(dr.GetDecimal(22));
                        nota.Aplicada = Convert.ToInt32(dr.GetString(36));
                        nota.CodAplicada = dr.GetInt32(37);
                        nota.Motivo = dr.GetString(38);
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

       //// public clsDetalleNotaIngreso ListaOrdenAlmacen(int codAlmacen, int codNota)
       // {
       //     clsDetalleNotaIngreso ingreso = null;
       //     try
       //     {

       //         con.conectarBD();
       //         cmd = new MySqlCommand("MuestraOrdenAlmacen", con.conector);
       //         cmd.Parameters.AddWithValue("codalma", codAlmacen);
       //         cmd.Parameters.AddWithValue("codnota", codNota);
       //         cmd.CommandType = CommandType.StoredProcedure;
       //         dr = cmd.ExecuteReader();
       //         if (dr.HasRows)
       //         {
       //             while (dr.Read())
       //             {
       //                 ingreso = new clsDetalleNotaIngreso();
       //                 ingreso.CodNotaIngreso = dr.GetInt32(1);
       //                 ingreso.CodDetalleIngreso = dr.GetInt32(2);
       //                 ingreso.CodProducto = dr.GetInt32(3);
       //                 ingreso.Referencia = dr.GetString(4);
       //                 ingreso.DescripcionProd = dr.GetString(5);
       //                 ingreso.Moneda = dr.GetInt32(6);
       //                 ingreso.CodUnidad = dr.GetInt32(7);
       //                 ingreso.DescripcionUnid = dr.GetString(8);
       //                 ingreso.SerieLote = dr.GetString(9);
       //                 ingreso.Cantidad = dr.GetDouble(10);
       //                 ingreso.PrecioUnitario = dr.GetDouble(11);
       //                 ingreso.Subtotal = dr.GetDouble(12);
       //                 ingreso.Descuento1 = dr.GetDouble(13);
       //                 ingreso.Descuento2 = dr.GetDouble(14);
       //                 ingreso.Descuento3 = dr.GetDouble(15);
       //                 ingreso.MontoDescuento = dr.GetDouble(16);
       //                 ingreso.ValorVenta = dr.GetDouble(17);
       //                 ingreso.Igv = dr.GetDouble(18);
       //                 ingreso.Flete = dr.GetDouble(19);
       //                 ingreso.Importe = dr.GetDouble(20);
       //                 ingreso.ValoReal = dr.GetDouble(21);
       //                 ingreso.PrecioReal = dr.GetDouble(22);
       //                 ingreso.FechaIngreso = dr.GetDateTime(23);
       //                 ingreso.CodUser = dr.GetInt32(24);
       //                 ingreso.FechaRegistro = dr.GetDateTime(25);
       //                 ingreso.CodProveedor = dr.GetInt32(26);
       //                 ingreso.Ruc = dr.GetString(27);
       //                 ingreso.RazonSocial = dr.GetString(28);
       //             }
       //         }
       //         return ingreso;
       //     }
       //     catch (Exception ex)
       //     {
       //         throw ex;
       //     }
       // }

        //public List<clsDetalleNotaIngreso> GuardaDetalleOrdenAlmacen(int codAlmacen, int codNota)
        //{

        //    List<clsDetalleNotaIngreso> lta = null;
        //    try
        //    {

        //        con.conectarBD();
        //        cmd = new MySqlCommand("MuestraOrdenAlmacen", con.conector);
        //        cmd.Parameters.AddWithValue("codalma", codAlmacen);
        //        cmd.Parameters.AddWithValue("codnota", codNota);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                clsDetalleNotaIngreso ingreso = new clsDetalleNotaIngreso ();
        //                ingreso.CodNotaIngreso = dr.GetInt32(1);
        //                ingreso.CodDetalleIngreso = dr.GetInt32(2);
        //                ingreso.CodProducto = dr.GetInt32(3);
        //                ingreso.Referencia = dr.GetString(4);
        //                ingreso.DescripcionProd = dr.GetString(5);
        //                ingreso.Moneda = dr.GetInt32(6);
        //                ingreso.CodUnidad = dr.GetInt32(7);
        //                ingreso.DescripcionUnid = dr.GetString(8);
        //                ingreso.SerieLote = dr.GetString(9);
        //                ingreso.Cantidad = dr.GetDouble(10);
        //                ingreso.PrecioUnitario = dr.GetDouble(11);
        //                ingreso.Subtotal = dr.GetDouble(12);
        //                ingreso.Descuento1 = dr.GetDouble(13);
        //                ingreso.Descuento2 = dr.GetDouble(14);
        //                ingreso.Descuento3 = dr.GetDouble(15);
        //                ingreso.MontoDescuento = dr.GetDouble(16);
        //                ingreso.ValorVenta = dr.GetDouble(17);
        //                ingreso.Igv = dr.GetDouble(18);
        //                ingreso.Flete = dr.GetDouble(19);
        //                ingreso.Importe = dr.GetDouble(20);
        //                ingreso.ValoReal = dr.GetDouble(21);
        //                ingreso.PrecioReal = dr.GetDouble(22);
        //                ingreso.FechaIngreso = dr.GetDateTime(23);
        //                ingreso.CodUser = dr.GetInt32(24);
        //                ingreso.FechaRegistro = dr.GetDateTime(25);
        //                ingreso.CodProveedor = dr.GetInt32(26);
        //                ingreso.Ruc = dr.GetString(27);
        //                ingreso.RazonSocial = dr.GetString(28);
        //                lta.Add(ingreso);
        //            }
        //        }
        //        return lta;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<clsDetalleNotaIngreso> GuardaDetalleOrdenAlmacen()
        //{
        //    throw new NotImplementedException();
        //}

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

        public DataTable CargaDetalleTransferencia(int codigotransferencia)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("BuscaDetalleTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod", codigotransferencia);
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

        public Boolean UpdateComentario(clsNotaIngreso nota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaNotaIngresoComentario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", Convert.ToInt32(nota.CodNotaIngreso));
                cmd.Parameters.AddWithValue("comentario", nota.Comentario);
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

        public DataTable ListaNotasIngreso(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaNotas", con.conector);
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

        public DataTable MuestraPagos(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPagos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("esta", Estado);
                cmd.Parameters.AddWithValue("empre", codEmpresa);
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

        public DataTable MuestraOrdenAlmacen(int codAlmacen, int codUsu)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraOrdenAlmacen", con.conector);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("usu",codUsu);
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

        public DataTable MuestraNotaIngresoOrden(int codAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNotaIngresoOrden", con.conector);
                cmd.Parameters.AddWithValue("finicial", FechaInicial);
                cmd.Parameters.AddWithValue("ffinal", FechaFinal);
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

        public DataTable MuestraTransferenciasVigentes(Int32 CodAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTransferenciasVigentes", con.conector);
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

        public DataTable MuestraGuia(Int32 codAlmacen, Int32 codUsu)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("VerificaProductoBonificadoCompra_1", con.conector);
                cmd.Parameters.AddWithValue("codalmacen_ex", codAlmacen);
                cmd.Parameters.AddWithValue("usu", codUsu);
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

        public DataTable CargaNotaCreditoSinAplicar(Int32 Codcli, Int32 VentComp)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNotaCreditoSinAplicar", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcli", Codcli);
                cmd.Parameters.AddWithValue("tipo", VentComp);
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

        public Boolean ActualizaNCreditoVentaSinAplicar(clsNotaIngreso nota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaNCreditoVentaSinAplicar", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codNotaI", nota.CodNotaIngreso);
                cmd.Parameters.AddWithValue("codRef", nota.CodReferencia);
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

        public Boolean VerificarNCVentaAplicada(clsNotaIngreso nota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("VerificarNCVentaAplicada", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("aplicad", nota.Aplicada);
                oParam = cmd.Parameters.AddWithValue("codalma", nota.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codref", nota.CodReferencia);
                oParam = cmd.Parameters.AddWithValue("total", nota.Total);
                oParam = cmd.Parameters.AddWithValue("msj", "0");
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                nota.Comentario = Convert.ToString(cmd.Parameters["msj"].Value);
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

        public DataTable CargaNotaIngresoSD(Int32 Codprov, Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNotaIngresoSD", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprov", Codprov);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("finicial", fecha1);
                cmd.Parameters.AddWithValue("ffinal", fecha2);
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

        public DataTable ListarCodigoNotasSalida()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListarCodigoNotasSalida", con.conector);
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

        public Boolean ActualizaStockPA(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI, Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaStockPA", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codAlmacenORG_ex", codalmacenorig);
                oParam = cmd.Parameters.AddWithValue("codAlmacenREC_ex", codalmacenrecep);
                oParam = cmd.Parameters.AddWithValue("codProducto_ex", codigoProd);
                oParam = cmd.Parameters.AddWithValue("codigoNI_ex", codigoNI);
                oParam = cmd.Parameters.AddWithValue("cantidadenviada_ex", cantidadenviada);
                oParam = cmd.Parameters.AddWithValue("preciounitario_ex", preciounit);
                oParam = cmd.Parameters.AddWithValue("valorreal_ex", valorreal);
                oParam = cmd.Parameters.AddWithValue("valorrealsoles_ex", valorrealsoles);
                oParam = cmd.Parameters.AddWithValue("codigouser_ex", codigouser);
                oParam = cmd.Parameters.AddWithValue("serie_ex", serie);
                oParam = cmd.Parameters.AddWithValue("numerodoc_ex", numerodoc);
                oParam = cmd.Parameters.AddWithValue("codserie_ex", codserie);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                //nota.Comentario = Convert.ToString(cmd.Parameters["msj"].Value);
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

        public Boolean ActualizaStockAR(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI, Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaStockAR", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codAlmacenORG_ex", codalmacenorig);
                oParam = cmd.Parameters.AddWithValue("codAlmacenREC_ex", codalmacenrecep);
                oParam = cmd.Parameters.AddWithValue("codProducto_ex", codigoProd);
                oParam = cmd.Parameters.AddWithValue("codigoNI_ex", codigoNI);
                oParam = cmd.Parameters.AddWithValue("cantidadenviada_ex", cantidadenviada);
                oParam = cmd.Parameters.AddWithValue("preciounitario_ex", preciounit);
                oParam = cmd.Parameters.AddWithValue("valorreal_ex", valorreal);
                oParam = cmd.Parameters.AddWithValue("valorrealsoles_ex", valorrealsoles);
                oParam = cmd.Parameters.AddWithValue("codigouser_ex", codigouser);
                oParam = cmd.Parameters.AddWithValue("serie_ex", serie);
                oParam = cmd.Parameters.AddWithValue("numerodoc_ex", numerodoc);
                oParam = cmd.Parameters.AddWithValue("codserie_ex", codserie);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                //nota.Comentario = Convert.ToString(cmd.Parameters["msj"].Value);
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

        public clsNotaIngreso CargaNI(Int32 codTransDirecta)
        {
            clsNotaIngreso nota = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraNIngreso", con.conector);
                cmd.Parameters.AddWithValue("cod", codTransDirecta);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nota = new clsNotaIngreso();
                        nota.CodNotaIngreso = dr.GetString(0);
                        nota.CodReferencia = dr.GetInt32(1);

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

        #endregion
    }
}
