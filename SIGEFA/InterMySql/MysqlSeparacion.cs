﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Interfaces;
using SIGEFA.Conexion;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;

namespace SIGEFA.InterMySql
{
    class MysqlSeparacion:ISeparacion
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public Boolean insert(clsSeparacion sepa)
        {
            try
            {
                con.conectarBD();
                String msj = "";
                cmd = new MySqlCommand("GuardaSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codalma", sepa.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codtran", sepa.CodTipoTransaccion);
                oParam = cmd.Parameters.AddWithValue("codtipo", sepa.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("numdoc", sepa.NumDocumento);
                oParam = cmd.Parameters.AddWithValue("moneda", sepa.Moneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", sepa.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("comentario", sepa.Comentario);
                oParam = cmd.Parameters.AddWithValue("bruto", sepa.Bruto);
                oParam = cmd.Parameters.AddWithValue("montodscto", sepa.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", sepa.Igv);
                oParam = cmd.Parameters.AddWithValue("total", sepa.Total);
                oParam = cmd.Parameters.AddWithValue("codcli", sepa.CodCliente);
                oParam = cmd.Parameters.AddWithValue("formapago", sepa.FormaPago);
                oParam = cmd.Parameters.AddWithValue("codserie", sepa.CodSerie);
                oParam = cmd.Parameters.AddWithValue("serie", sepa.Serie);
                oParam = cmd.Parameters.AddWithValue("codusu", sepa.CodUsuario);
                oParam = cmd.Parameters.AddWithValue("codven", sepa.CodVendedor);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                sepa.CodSeparacion = Convert.ToInt32(cmd.Parameters["newid"].Value);
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

        public DataTable CargarVentas(int CodAlmacen, DateTime FechaInicio, DateTime FechaFin, Int32 estado)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraVentas_Xseparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("fechaini", FechaInicio);
                cmd.Parameters.AddWithValue("fechafin", FechaFin);
                cmd.Parameters.AddWithValue("estad", estado);
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

        public clsSeparacion BuscarSeparacion(Int32 CodSepracion, Int32 CodAlmacen)
        {
            clsSeparacion sepa = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraSeparacion", con.conector);
                cmd.Parameters.AddWithValue("codseparacion", CodSepracion);
                cmd.Parameters.AddWithValue("codalmacen", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sepa = new clsSeparacion();
                        sepa.CodSeparacion = Convert.ToInt32(dr.GetString(0));
                        sepa.CodAlmacen = Convert.ToInt32(dr.GetInt32(1));
                        sepa.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));                       
                        sepa.CodCliente = Convert.ToInt32(dr.GetString(3));
                        sepa.Moneda = Convert.ToInt32(dr.GetString(10));
                        sepa.TipoCambio = dr.GetDecimal(11);                        
                
                        sepa.NomCliente = dr.GetString(8);                  
                        sepa.Total = dr.GetDecimal(16);
                        sepa.Igv = dr.GetDecimal(15);                      
                        sepa.MontoDescuento = dr.GetDecimal(14);
                        sepa.Bruto = dr.GetDecimal(13);
                        sepa.FechaPedido = dr.GetDateTime(23);
                        //sepa.FormaPago = Convert.ToInt32(dr.GetString(23));                        
                        sepa.CodUsuario = Convert.ToInt32(dr.GetDecimal(18));
                        //sepa.FechaRegistro = dr.GetDateTime(26);
                    }
                }
                return sepa;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public bool insertdetalle(clsDetalleSeparacionVenta detalle_venta)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleSeparacionVenta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", detalle_venta.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codseparacion", detalle_venta.CodSeparacion);
                oParam = cmd.Parameters.AddWithValue("codalma", detalle_venta.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("unidad", detalle_venta.UnidadIngresada);               
                oParam = cmd.Parameters.AddWithValue("cantidad", detalle_venta.Cantidad);     
                
                oParam = cmd.Parameters.AddWithValue("precio", detalle_venta.PrecioUnitario);
                oParam = cmd.Parameters.AddWithValue("subtotal", detalle_venta.Subtotal);
                oParam = cmd.Parameters.AddWithValue("dscto1", detalle_venta.Descuento1);
                oParam = cmd.Parameters.AddWithValue("dscto2", detalle_venta.Descuento2);
                oParam = cmd.Parameters.AddWithValue("dscto3", detalle_venta.Descuento3);
                oParam = cmd.Parameters.AddWithValue("montodscto", detalle_venta.MontoDescuento);
                oParam = cmd.Parameters.AddWithValue("igv", detalle_venta.Igv);
                oParam = cmd.Parameters.AddWithValue("importe", detalle_venta.Importe);
                oParam = cmd.Parameters.AddWithValue("precioreal", detalle_venta.PrecioReal);
                oParam = cmd.Parameters.AddWithValue("valoreal", detalle_venta.ValoReal);
                
                oParam = cmd.Parameters.AddWithValue("codusu", detalle_venta.CodUser);
               
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detalle_venta.CodDetalleSeparacion = Convert.ToInt32(cmd.Parameters["newid"].Value);

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


        public clsSeparacion BuscarSeparacionXid(Int32 CodSepracion, Int32 codAlmacen)
        {
            clsSeparacion sepa = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarSeparacionXid", con.conector);
                cmd.Parameters.AddWithValue("codsepa", CodSepracion);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sepa = new clsSeparacion();
                        sepa.CodSeparacion = Convert.ToInt32(dr.GetString(0));
                        sepa.CodAlmacen = Convert.ToInt32(dr.GetInt32(1));
                        sepa.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(2));                       
                        sepa.CodCliente = Convert.ToInt32(dr.GetString(3));
                        sepa.Moneda = Convert.ToInt32(dr.GetString(10));
                        sepa.TipoCambio = dr.GetDecimal(11);
                        sepa.Comentario = dr.GetString(12);
                        sepa.NomCliente = dr.GetString(8);
                        sepa.Total = dr.GetDecimal(16);
                        sepa.Igv = dr.GetDecimal(15);                       
                        sepa.MontoDescuento = dr.GetDecimal(14);
                        sepa.Bruto = dr.GetDecimal(13);
                        //sepa.FormaPago = Convert.ToInt32(dr.GetString(23));

                        sepa.CodUsuario = Convert.ToInt32(dr.GetDecimal(18));
                        //sepa.FechaRegistro = dr.GetDateTime(26);
                    }
                }
                return sepa;

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
                cmd = new MySqlCommand("MuestraDetalleSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codsepa", CodPedido);
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

        public Boolean anular(Int32 codSeparacion)
        {
            try
            {
                con.conectarBD();                
                cmd = new MySqlCommand("anularSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codsep", codSeparacion);
               
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

        public Double CargaSeparacion(Int32 cod_almacen)
        {
            Double Total = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuetraTotalSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalm", cod_almacen);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        Total = dr.GetDouble(0);
                    }
                }
                return Total;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
