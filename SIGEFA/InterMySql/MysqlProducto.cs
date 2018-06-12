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
    class MysqlProducto:IProducto
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IProducto

        public Boolean Insert(clsProducto prod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codUsuario_ex", prod.CodUsuario);
                if (prod.CodGrupo != 0) { oParam = cmd.Parameters.AddWithValue("codGrupo_ex", prod.CodGrupo); } else { oParam = cmd.Parameters.AddWithValue("codGrupo_ex", null); }
                if (prod.CodLinea != 0) { oParam = cmd.Parameters.AddWithValue("codLinea_ex", prod.CodLinea); } else { oParam = cmd.Parameters.AddWithValue("codLinea_ex", null); }
                oParam = cmd.Parameters.AddWithValue("codFamilia_ex", prod.CodFamilia);
                oParam = cmd.Parameters.AddWithValue("codUnidadMedida_ex", prod.CodUnidadMedida);
                oParam = cmd.Parameters.AddWithValue("codTipoArticulo_ex", prod.CodTipoArticulo);
                if (prod.CodMarca != 0) { oParam = cmd.Parameters.AddWithValue("codMarca_ex", prod.CodMarca); } else { oParam = cmd.Parameters.AddWithValue("codMarca_ex", null); }
                oParam = cmd.Parameters.AddWithValue("codControlStock_ex", prod.CodControlStock);
                oParam = cmd.Parameters.AddWithValue("referencia_ex", prod.Referencia);
                oParam = cmd.Parameters.AddWithValue("descripcion_ex", prod.Descripcion);
                oParam = cmd.Parameters.AddWithValue("tipoimpuesto_ex", prod.TipoImpuesto);
                oParam = cmd.Parameters.AddWithValue("codsunat_ex", prod.CodSunat);
                oParam = cmd.Parameters.AddWithValue("detraccion_ex", prod.Detraccion);
                oParam = cmd.Parameters.AddWithValue("estado_ex", prod.Estado);
                oParam = cmd.Parameters.AddWithValue("comision_ex", prod.Comision);
                oParam = cmd.Parameters.AddWithValue("preciocatalogo_ex", prod.PrecioCatalogo);
                oParam = cmd.Parameters.AddWithValue("preciocompracatalago_ex", prod.PrecioCompra);
                oParam = cmd.Parameters.AddWithValue("maxPorcDescto_ex", prod.MaxPorcDesc);
                oParam = cmd.Parameters.AddWithValue("propeso", prod.Peso); 
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                prod.CodProducto = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertProductoAlmacen(clsProducto prod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaProductoAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codusu", prod.CodUsuario);                
                oParam = cmd.Parameters.AddWithValue("valorpromedio", prod.ValorProm);
                oParam = cmd.Parameters.AddWithValue("preciopromedio", prod.PrecioProm);
                oParam = cmd.Parameters.AddWithValue("recargo", prod.Recargo);
                oParam = cmd.Parameters.AddWithValue("precioventa", prod.PrecioVenta);
                oParam = cmd.Parameters.AddWithValue("oferta", prod.Oferta);
                oParam = cmd.Parameters.AddWithValue("descuento", prod.PDescuento);
                oParam = cmd.Parameters.AddWithValue("montodescuento", prod.MontoDscto);
                oParam = cmd.Parameters.AddWithValue("preciooferta", prod.PrecioOferta);
                oParam = cmd.Parameters.AddWithValue("preciovariable", prod.PrecioVariable);
                oParam = cmd.Parameters.AddWithValue("maximodscto", prod.MaximoDscto);
                oParam = cmd.Parameters.AddWithValue("stockminimo", prod.StockMinimo);
                oParam = cmd.Parameters.AddWithValue("stockmaximo", prod.StockMaximo);
                oParam = cmd.Parameters.AddWithValue("stockreposicion", prod.StockReposicion);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                prod.CodProductoAlmacen = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertCaracteristica(clsCaracteristicaProducto carpro)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaCaracteristicaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", carpro.CodProducto);
                oParam = cmd.Parameters.AddWithValue("codcar", carpro.CodCaracteristica);
                oParam = cmd.Parameters.AddWithValue("valor", carpro.Valor);
                oParam = cmd.Parameters.AddWithValue("codusu", carpro.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                carpro.CodCaracteristicaProductoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertNota(clsNotaProducto notpro)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaNotaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", notpro.CodProducto);                
                oParam = cmd.Parameters.AddWithValue("nota", notpro.Nota);
                oParam = cmd.Parameters.AddWithValue("codusu", notpro.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                notpro.CodNotaProducto = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsProducto prod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("codpro", prod.CodProducto);
                if (prod.CodGrupo != 0) { cmd.Parameters.AddWithValue("codgru", prod.CodGrupo); } else { cmd.Parameters.AddWithValue("codgru", null); }
                if (prod.CodLinea != 0) { cmd.Parameters.AddWithValue("codlin", prod.CodLinea); } else { cmd.Parameters.AddWithValue("codlin", null); }
                cmd.Parameters.AddWithValue("codfam", prod.CodFamilia);
                if (prod.CodMarca != 0) { cmd.Parameters.AddWithValue("codmar", prod.CodMarca); } else { cmd.Parameters.AddWithValue("codmar", null); }
                cmd.Parameters.AddWithValue("coduni", prod.CodUnidadMedida);
                cmd.Parameters.AddWithValue("codtip", prod.CodTipoArticulo);
                cmd.Parameters.AddWithValue("control", prod.CodControlStock);
                cmd.Parameters.AddWithValue("referencia", prod.Referencia);
                cmd.Parameters.AddWithValue("descripcion", prod.Descripcion);
                cmd.Parameters.AddWithValue("tipoimpuesto_ex", prod.TipoImpuesto);
                cmd.Parameters.AddWithValue("codsunat_ex", prod.CodSunat);
                cmd.Parameters.AddWithValue("detraccion", prod.Detraccion);
                cmd.Parameters.AddWithValue("estado", prod.Estado);
                cmd.Parameters.AddWithValue("comision", prod.Comision);
                cmd.Parameters.AddWithValue("precioca", prod.PrecioCatalogo);
                cmd.Parameters.AddWithValue("maxPorcDesc", prod.MaxPorcDesc);
                cmd.Parameters.AddWithValue("propeso", prod.Peso);
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

        public Boolean UpdateProductoAlmacen(clsProducto prod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaProductoAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", prod.CodProducto);
                cmd.Parameters.AddWithValue("codalma", prod.CodAlmacen);  
                cmd.Parameters.AddWithValue("valorprom", prod.ValorProm);
                cmd.Parameters.AddWithValue("precioprom", prod.PrecioProm);
                cmd.Parameters.AddWithValue("recargo", prod.Recargo);
                cmd.Parameters.AddWithValue("valorventa", prod.ValorVenta);
                cmd.Parameters.AddWithValue("precioventa", prod.PrecioVenta);
                cmd.Parameters.AddWithValue("oferta", prod.Oferta);
                cmd.Parameters.AddWithValue("descuento", prod.PDescuento);
                cmd.Parameters.AddWithValue("montodescuento", prod.MontoDscto);
                cmd.Parameters.AddWithValue("preciooferta", prod.PrecioOferta);
                cmd.Parameters.AddWithValue("preciovariable", prod.PrecioVariable);
                cmd.Parameters.AddWithValue("maximodscto", prod.MaximoDscto);
                cmd.Parameters.AddWithValue("stockminimo", prod.StockMinimo);
                cmd.Parameters.AddWithValue("stockmaximo", prod.StockMaximo);
                cmd.Parameters.AddWithValue("stockreposicion", prod.StockReposicion);
                cmd.Parameters.AddWithValue("tipoimpuesto_ex", prod.TipoImpuesto);
                cmd.Parameters.AddWithValue("codsunat_ex", prod.CodSunat);
                cmd.Parameters.AddWithValue("detraccion", prod.Detraccion);
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



        public Boolean Delete(Int32 CodProducto)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", CodProducto);
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

        public Boolean DeleteProductoAlmacen(Int32 CodProductoAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarProductoAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codprod", CodProductoAlmacen);
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

        public Boolean DeleteCaracteristica(Int32 CodCarPro)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarCaracteristicaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcarpro", CodCarPro);
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

        public Boolean DeleteNota(Int32 CodNotaProducto)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarNotaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnota", CodNotaProducto);
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

        public clsProducto CargaProducto(Int32 CodPro, Int32 CodAlm)
         {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProducto", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
                cmd.Parameters.AddWithValue("codalm", CodAlm);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pro = new clsProducto();
                        pro.CodProducto = dr.GetInt32(0);
                        pro.Referencia = dr.GetString(1);
                        pro.Descripcion = dr.GetString(2);
                        pro.TipoImpuesto = dr.GetInt32(3);
                        pro.Detraccion = dr.GetBoolean(4);
                        pro.CodTipoArticulo = dr.GetInt32(5);
                        pro.CodFamilia = dr.GetInt32(6);
                        pro.CodLinea = dr.GetInt32(7);
                        pro.CodGrupo = dr.GetInt32(8);
                        pro.CodMarca = dr.GetInt32(9);
                        pro.CodControlStock = dr.GetInt32(10);
                        pro.CodUnidadMedida = dr.GetInt32(11);

                        pro.CodUsuario = dr.GetInt32(13);
                        pro.UltimaModificacion = dr.GetDateTime(14);// capturo la fecha 
                        pro.FechaRegistro = dr.GetDateTime(15);// capturo la fecha 
                        pro.CodProductoAlmacen = dr.GetInt32(16);
                        pro.CodAlmacen = dr.GetInt32(17);
                        pro.PrecioProm = dr.GetDecimal(18);
                        pro.ValorProm = Convert.ToDouble(dr.GetString(19));
                        pro.Recargo = Convert.ToDouble(dr.GetString(20));
                        pro.ValorVenta = Convert.ToDouble(dr.GetString(21));
                        pro.PrecioVenta = Convert.ToDouble(dr.GetString(22));

                        pro.PDescuento = dr.GetDouble(24);
                        pro.MontoDscto = dr.GetDouble(25);
                        pro.PrecioOferta = dr.GetDouble(26);
                        pro.MaximoDscto = dr.GetDouble(27);

                        pro.StockActual = dr.GetDouble(30);
                        pro.StockDisponible = dr.GetDecimal(31);
                        pro.StockMaximo = dr.GetDouble(32);
                        pro.StockMinimo = dr.GetDouble(33);
                        pro.StockReposicion = dr.GetDouble(34);
                        pro.Comision = Convert.ToDecimal(dr.GetString(35));
                        pro.PrecioCatalogo = Convert.ToDecimal(dr.GetString(36));
                        pro.Estado = dr.GetBoolean(12);
                        //pro.Oferta = Convert.ToBoolean(dr.GetString(23));

                        pro.Oferta = dr.GetBoolean(23);
                        pro.CodSunat = dr.GetString(28);
                        //pro.PrecioVariable = Convert.ToBoolean(dr.GetString(29));
                        pro.PrecioVariable = dr.GetBoolean(29);
                        pro.StockFuturo = dr.GetDecimal(38);
                        pro.StockPorRecibir = dr.GetDecimal(37);
                        pro.MaxPorcDesc = dr.GetDecimal(39);
                        pro.Peso = dr.GetDecimal(40);
                        
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsProducto CargaProductoDetalle(Int32 CodPro, Int32 CodAlm, Int32 Caso, Int32 CodLista)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoDetalle", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
                cmd.Parameters.AddWithValue("codalm", CodAlm);
                cmd.Parameters.AddWithValue("caso", Caso);
                cmd.Parameters.AddWithValue("lista", CodLista);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Caso == 1)
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.CodSunat = dr.GetString(7);
                            pro.TipoImpuesto = dr.GetInt32(8);
                            pro.MaxPorcDesc = dr.GetDecimal(9);
                        }
                        else
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.PrecioVenta = Convert.ToDouble(dr.GetDecimal(7));
                            pro.PrecioVentaSoles = Convert.ToDouble(dr.GetDecimal(8));
                            pro.PrecioVariable = dr.GetBoolean(9);
                            pro.Oferta = dr.GetBoolean(10);
                            pro.PDescuento = Convert.ToDouble(dr.GetDecimal(11));
                            pro.PrecioOferta = Convert.ToDouble(dr.GetDecimal(12));
                            pro.CodSunat = dr.GetString(13);
                            pro.TipoImpuesto = dr.GetInt32(14);
                            pro.MaxPorcDesc = dr.GetDecimal(18);
                            
                        }
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsProducto CargaProductoDetalle1(Int32 CodPro, Int32 CodAlm, Int32 Caso, Int32 CodLista)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoDetalle1", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
                cmd.Parameters.AddWithValue("codalm", CodAlm);
                cmd.Parameters.AddWithValue("caso", Caso);
                cmd.Parameters.AddWithValue("lista", CodLista);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Caso == 1)
                        {
                            pro = new clsProducto();
                            pro.CodProducto = dr.GetInt32(0);
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = Convert.ToDecimal(dr.GetDecimal(3));
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.ConIgv = dr.GetBoolean(7);
                            pro.TipoImpuesto = dr.GetInt32(8);                            
                            pro.ValorProm = dr.GetDouble(11);
                            pro.PrecioCompra = dr.GetDecimal(12);
                        }
                        else
                        {
                            pro = new clsProducto();
                            pro.CodProducto = dr.GetInt32(0);
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = dr.GetInt32(4);
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = dr.GetInt32(6);
                            pro.PrecioVenta = dr.GetDouble(7);
                            pro.PrecioVariable = dr.GetBoolean(8);                            
                            pro.ConIgv = dr.GetBoolean(9);
                            pro.TipoImpuesto = dr.GetInt32(10);
                            pro.ValorProm = dr.GetDouble(11);
                            pro.PrecioProm = dr.GetDecimal(12);
                        }
                    }
                }
                return pro;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsProducto CargaDatosProductoOrden(Int32 CodPro, Int32 CodAlm, Int32 codusu, Decimal cant)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaDatosProductoOrden", con.conector);
                cmd.Parameters.AddWithValue("alma", CodAlm);
                cmd.Parameters.AddWithValue("usu", codusu);
                cmd.Parameters.AddWithValue("codpro",CodPro);
                cmd.Parameters.AddWithValue("cant", cant);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                        
                            pro = new clsProducto();
                            pro.Porllegar = Convert.ToInt32(dr.GetDecimal(0));
                            pro.PorAtender = Convert.ToInt32(dr.GetDecimal(1));
                            pro.PorCompletar = Convert.ToInt32(dr.GetDecimal(2));
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsProducto CargaProductoDetalleR(String Referencia, Int32 CodAlm, Int32 Caso, Int32 Lista)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoDetalleR", con.conector);
                cmd.Parameters.AddWithValue("refe", Referencia);
                cmd.Parameters.AddWithValue("codalm", CodAlm);
                cmd.Parameters.AddWithValue("caso", Caso);
                cmd.Parameters.AddWithValue("lista", Lista);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Caso == 1)
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.CodSunat = dr.GetString(7);
                            pro.TipoImpuesto = dr.GetInt32(8);
                            pro.MaxPorcDesc = dr.GetDecimal(9);
                        }
                        else
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.PrecioVenta = Convert.ToDouble(dr.GetDecimal(7));
                            pro.PrecioVentaSoles = Convert.ToDouble(dr.GetDecimal(8));
                            pro.PrecioVariable = dr.GetBoolean(9);
                            pro.Oferta = dr.GetBoolean(10);
                            pro.PDescuento = Convert.ToDouble(dr.GetDecimal(11));
                            pro.PrecioOferta = Convert.ToDouble(dr.GetDecimal(12));
                            pro.CodSunat = dr.GetString(13);
                            pro.TipoImpuesto = dr.GetInt32(14);
                            pro.MaxPorcDesc = dr.GetDecimal(18);
                        }
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaProductos(Int32 nivel, Int32 codigo, Int32 codalmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaProductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nivel", nivel);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("codalm", codalmacen);
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

        public DataTable CatalogoProductos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CatalogoProductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", 1);                
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

        public DataTable StockProductoAlmacenes(Int32 codempre, Int32 codpro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("StockProductoxAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", codpro);
                cmd.Parameters.AddWithValue("codempre", codempre);                
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

        public DataTable ListaProductosReporte(Int32 codalmacen, Int32 Tipo, Int32 Inicio)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaProductosReporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.AddWithValue("codalma", codalmacen);
                cmd.Parameters.AddWithValue("tipo", Tipo);
                cmd.Parameters.AddWithValue("inicio", Inicio);
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

        public DataTable RelacionProductosIngreso(Int32 Tipo, Int32 codalma)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosIngreso", con.conector);
                cmd.Parameters.AddWithValue("tipo", Tipo);
                cmd.Parameters.AddWithValue("codalma", codalma);
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

        public DataTable RelacionIngresoPorProveedor(Int32 Tipo, Int32 codalma, Int32 codproveedor)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosIngresoPorProveedor", con.conector);
                cmd.Parameters.AddWithValue("tipo", Tipo);
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("codprov", codproveedor);
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

        public DataTable RelacionProductosSalida(Int32 Tipo,Int32 codalmacen, Int32 codlista)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosSalida", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", Tipo);
                cmd.Parameters.AddWithValue("codalma", codalmacen);
                cmd.Parameters.AddWithValue("codlista", codlista);
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

        public DataTable ListaCaracteristicas(Int32 codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaCaracteristicaProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("codpro", codigo);
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

        public DataTable ListaNotas(Int32 codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaNotasProducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", codigo);
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

        public DataTable BuscaProductos(Int32 Criterio, String Filtro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("FiltraProductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criterio", Criterio);
                cmd.Parameters.AddWithValue("@filtro", Filtro);
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

        public DataTable ArbolProductos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaArbolProductos", con.conector);
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

        public DataTable MuestraProductosProveedor(Int32 codProducto, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductosProveedor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", codProducto);
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

      
        public clsProducto MuestraProductosTransferencia(Int32 codProducto, Int32 codAlmacen)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", codProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                            pro = new clsProducto();
                            pro.ValorProm = Convert.ToDouble(dr.GetDecimal(0));
                            pro.ValorPromsoles = Convert.ToDecimal(dr.GetDecimal(1));
                            pro.PrecioProm = dr.GetDecimal(2);
                            pro.StockActual = Convert.ToDouble(dr.GetDecimal(3));
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsProducto MuestraProductosTransferencia_nuevo(Int32 codProducto, Int32 codAlmacen)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoTransferencia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpro", codProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pro = new clsProducto();
                        pro.ValorProm = Convert.ToDouble(dr.GetDecimal(0));
                        pro.ValorPromsoles = Convert.ToDecimal(dr.GetDecimal(1));
                        pro.PrecioProm = dr.GetDecimal(2);
                        pro.StockActual = Convert.ToDouble(dr.GetDecimal(3));
                        pro.Cantidad = Convert.ToInt32(dr.GetInt32(4));
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable RelacionProductosCotizacion(int Tipo, int codAlmacen, int codlista)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosCotizacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", Tipo);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.Parameters.AddWithValue("codlista", codlista);
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

        public Decimal CargaPrecioProducto(Int32 CodPro, Int32 CodAlm, Int32 codmon)
        {
            Decimal Precio = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaPrecioProducto", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
                cmd.Parameters.AddWithValue("codalma", CodAlm);
                cmd.Parameters.AddWithValue("mon", codmon);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Precio= Convert.ToDecimal(dr.GetDecimal(0));
                    }
                }
                return Precio;


            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable MuestraStockAlmacenes()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("consultadinamicastock", con.conector);
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

        #region Implementacion IUnidadEquivalente

        public Boolean InsertUnidad(clsUnidadEquivalente uni)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaUnidadEquivalente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", uni.CodProducto);
                oParam = cmd.Parameters.AddWithValue("coduni", uni.CodUnidad);
                oParam = cmd.Parameters.AddWithValue("factor", uni.Factor);
                oParam = cmd.Parameters.AddWithValue("codUndEqui", uni.CodEquivalente);
                oParam = cmd.Parameters.AddWithValue("codTipo", uni.Tipo);
                oParam = cmd.Parameters.AddWithValue("precio", uni.Precio);
                oParam = cmd.Parameters.AddWithValue("codAlmacen", uni.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codusu", uni.CodUser);
                oParam = cmd.Parameters.AddWithValue("compra_venta", uni.CompraVenta);
                oParam = cmd.Parameters.AddWithValue("codMoneda_ex", uni.ICodMoneda);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                uni.CodUnidadEquivalente = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean UpdateUnidad(clsUnidadEquivalente uni)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaUnidadEquivalente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("factor", uni.Factor);
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

        public Boolean DeleteUnidad(Int32 CodUnidad)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarUnidadEquivalente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coduni", CodUnidad);
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

        public clsUnidadEquivalente CargaUnidadEquivalente(Int32 Coduni, Int32 Codpro)
        {
            clsUnidadEquivalente uni = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUnidadEquivalente", con.conector);
                cmd.Parameters.AddWithValue("coduni", Coduni);
                cmd.Parameters.AddWithValue("codpro", Codpro);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = new clsUnidadEquivalente();
                        uni.CodUnidadEquivalente = Convert.ToInt32(dr.GetDecimal(0));
                        uni.CodProducto = Convert.ToInt32(dr.GetDecimal(1));
                        uni.CodUnidad = Convert.ToInt32(dr.GetDecimal(2));
                        uni.Factor = dr.GetDecimal(3);
                        uni.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        uni.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaUnidadesEquivalentes(Int32 CodigoProducto)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidadesEquivalentes", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
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

        public DataTable CargaUnidadesEquivalentes(Int32 CodigoProducto)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaUnidadesEquivalentes", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
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

        public DataTable BuscarProducto(Int32 codProducto)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("BuscarProducto", con.conector);
                cmd.Parameters.AddWithValue("codprod", codProducto);
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

        public DataTable RelacionProductos(Int32 codalma)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductos", con.conector);
                cmd.Parameters.AddWithValue("codalma", codalma);
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

        public List<clsProducto> ListaProdConsultor(Int32 CodVendedor)
        {
            clsProducto pro = null;
            List<clsProducto> list1 = new List<clsProducto>();
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProdConsultor", con.conector);
                cmd.Parameters.AddWithValue("codvendedor", CodVendedor);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pro = new clsProducto();
                        pro.CodProducto = dr.GetInt32(0);
                        pro.Descripcion = dr.GetString(1);
                        pro.StockActual = dr.GetInt32(2);
                        list1.Add(pro);

                    }
                }
                return list1;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable RelacionVendedor(Int32 CodTipArt, Int32 CodAlmacen, Int32 CodLista, Int32 CodVendedor)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosVendedor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", CodTipArt);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.Parameters.AddWithValue("codlista", CodLista);
                cmd.Parameters.AddWithValue("codvendedor", CodVendedor);
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

        public List<clsProducto> VentasProductosCount(Int32 CodFac)
        {
            clsProducto pro = null;
            List<clsProducto> list1 = new List<clsProducto>();
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VentasProductosCount", con.conector);
                cmd.Parameters.AddWithValue("codfac", CodFac);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pro = new clsProducto();
                        pro.CodProducto = dr.GetInt32(0);
                        pro.Descripcion = dr.GetString(1);
                        pro.StockActual = dr.GetInt32(2);
                        list1.Add(pro);

                    }
                }
                return list1;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean UpdateUnidadEquivalente(Int32 cod, Decimal precio)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaUnidadEquivalenteCodigo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod", cod);
                cmd.Parameters.AddWithValue("p", precio);
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

        public clsPrecioEquivalente PrecioStock(Int32 cmunidad, int CodProducto, int undBase)
        {
            clsPrecioEquivalente p = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUnidad", con.conector);
                cmd.Parameters.AddWithValue("unid", cmunidad);
                cmd.Parameters.AddWithValue("codpro", CodProducto);
                cmd.Parameters.AddWithValue("undbase", undBase);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        p = new clsPrecioEquivalente();
                        p.Stock = Convert.ToDecimal(dr.GetDecimal(0));
                        p.Precio = Convert.ToInt32(dr.GetInt32(1));
                        p.Und = dr.GetInt32(2);
                        p.p_compra = dr.GetDecimal(3);
                    }
                }

                return p;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaUnidadesEquivalentesCompra(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidadesEquivalentesCompra", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaUnidadesEquivalentesVenta(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidadesEquivalentesVenta", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaUnidadesEquivalentesVenta1(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidadesEquivalentesVenta1", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public DataTable ListaUnidadesEquivalentes(Int32 CodigoProducto, Int32 codAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidadesEquivalentes", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodigoProducto);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
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

        public Int32 getUnidadCompra(Int32 codProd)
        {
            try
            {
                int unidcompra = 0;
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUC", con.conector);
                cmd.Parameters.AddWithValue("codpro", codProd);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        unidcompra = Convert.ToInt32(dr.GetDecimal(0));
                    }

                }
                return unidcompra;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsUnidadEquivalente Factor(Int32 codProducto, Int32 codUnidadMedida, Int32 codUnidaEqui)
        {
            clsUnidadEquivalente uni = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraFactor", con.conector);
                cmd.Parameters.AddWithValue("codpro", codProducto);
                cmd.Parameters.AddWithValue("coduni", codUnidadMedida);
                cmd.Parameters.AddWithValue("coduniEqui", codUnidaEqui);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = new clsUnidadEquivalente();
                        uni.Factor = Convert.ToInt32(dr.GetDecimal(0));
                    }

                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsProducto PrecioPromedio(Int32 codProducto, Int32 codalm)
        {
            clsProducto prod = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPrecioPromedio", con.conector);
                cmd.Parameters.AddWithValue("codpro", codProducto);
                cmd.Parameters.AddWithValue("codalma", codalm);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        prod = new clsProducto();
                        prod.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                        prod.PrecioProm = Convert.ToDecimal(dr.GetDecimal(1));
                        prod.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(2));

                    }

                }
                return prod;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsUnidadEquivalente PrecioVenta(Int32 coduni, Int32 codalmacen)
        {
            clsUnidadEquivalente uni = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraPrecioVenta", con.conector);
                cmd.Parameters.AddWithValue("undequi", coduni);
                cmd.Parameters.AddWithValue("codalma", codalmacen);
               
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = new clsUnidadEquivalente();
                        uni.Stock = dr.GetDecimal(0);
                        uni.CodUnidad = dr.GetInt32(1);
                        uni.Precio = dr.GetDecimal(2);
                        uni.Tipo = dr.GetInt32(3);
                    }
                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 UnidadBase(Int32 codProd, Int32 codalma)
        {
            Int32 uni = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("UnidadBase", con.conector);
                cmd.Parameters.AddWithValue("codProd", codProd);
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = dr.GetInt32(0);
                    }
                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Decimal FactorProducto(Int32 codPro, Int32 undBase, Int32 undEqui, Int32 tipo)
        {
            Decimal uniEqui = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("FactorProducto", con.conector);
                cmd.Parameters.AddWithValue("codProd", codPro);
                cmd.Parameters.AddWithValue("undBase", undBase);
                cmd.Parameters.AddWithValue("undEqui", undEqui);
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uniEqui = dr.GetDecimal(0);
                    }
                }
                return uniEqui;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public String SiglaUnidadBase(Int32 codUnd)
        {
            String uni = "";
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("SiglaUnidadBase", con.conector);
                cmd.Parameters.AddWithValue("codUnd", codUnd);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = dr.GetString(0);
                    }
                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 GetCodProducto_xDescripcion(String descripcion)
        {
            Int32 codProd = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodProducto_xDescripcion", con.conector);
                cmd.Parameters.AddWithValue("nombrePro", descripcion);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        codProd = dr.GetInt32(0);
                    }
                }
                return codProd;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaCodigoUE(Int32 codigo)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCodigoUE", con.conector);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaCodigoUE(String unidad)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCodigoUE", con.conector);
                cmd.Parameters.AddWithValue("unidad", unidad);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaCodigoProducto(Int32 codigo)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCodigoProducto", con.conector);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaCodigoMoneda(Int32 codigo)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCodigoMoneda", con.conector);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaCodigoMoneda(String moneda)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCodigoMoneda", con.conector);
                cmd.Parameters.AddWithValue("moneda", moneda);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaTipoPrecio(Int32 codigo)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaTipoPrecio", con.conector);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaTipoPrecio(String tipoPrecio)
        {
            Int32 resultado = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaTipoPrecio", con.conector);
                cmd.Parameters.AddWithValue("tipoPrecio", tipoPrecio);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = dr.GetInt32(0);
                    }
                }
                return resultado;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 GetCodUnidad(String descripcion)
        {
            Int32 codUnidad = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodUnidad_xDescripcion", con.conector);
                cmd.Parameters.AddWithValue("nombreUnd", descripcion);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        codUnidad = dr.GetInt32(0);
                    }
                }
                return codUnidad;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 GetCodTipoPrecio(String descripcion)
        {
            Int32 CodTipoPrecio = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodTipoPrecio_xDescripcion", con.conector);
                cmd.Parameters.AddWithValue("nombreTipoP", descripcion);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CodTipoPrecio = dr.GetInt32(0);
                    }
                }
                return CodTipoPrecio;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 GetCodMoneda(String descripcion)
        {
            Int32 GetCodMoneda = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodMoneda_xDescripcion", con.conector);
                cmd.Parameters.AddWithValue("nombreMoneda", descripcion);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GetCodMoneda = dr.GetInt32(0);
                    }
                }
                return GetCodMoneda;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaUnidadEquivalente(Int32 codigo)
        {
            Int32 Cantidad = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaUnidadEquivalente", con.conector);
                cmd.Parameters.AddWithValue("codigo", codigo);

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cantidad = dr.GetInt32(0);
                    }
                }
                return Cantidad;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsProducto CargaProductoDetalleCodBarras(String CodPro, Int32 CodAlm, Int32 Caso, Int32 CodLista)
        {
            clsProducto pro = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraProductoDetalleCodBarras", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
                cmd.Parameters.AddWithValue("codalm", CodAlm);
                cmd.Parameters.AddWithValue("caso", Caso);
                cmd.Parameters.AddWithValue("lista", CodLista);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Caso == 1)
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.ConIgv = dr.GetBoolean(7);
                            pro.TipoImpuesto = dr.GetInt32(8);
                            pro.MaxPorcDesc = dr.GetDecimal(9);
                        }
                        else
                        {
                            pro = new clsProducto();
                            pro.CodProducto = Convert.ToInt32(dr.GetDecimal(0));
                            pro.Referencia = dr.GetString(1);
                            pro.Descripcion = dr.GetString(2);
                            pro.StockDisponible = dr.GetDecimal(3);
                            pro.CodUnidadMedida = Convert.ToInt32(dr.GetDecimal(4));
                            pro.UnidadDescrip = dr.GetString(5);
                            pro.CodControlStock = Convert.ToInt32(dr.GetDecimal(6));
                            pro.PrecioVenta = Convert.ToDouble(dr.GetDecimal(7));
                            pro.PrecioVentaSoles = Convert.ToDouble(dr.GetDecimal(8));
                            pro.PrecioVariable = dr.GetBoolean(9);
                            pro.Oferta = dr.GetBoolean(10);
                            pro.PDescuento = Convert.ToDouble(dr.GetDecimal(11));
                            pro.PrecioOferta = Convert.ToDouble(dr.GetDecimal(12));
                            pro.ConIgv = dr.GetBoolean(13);
                            pro.TipoImpuesto = dr.GetInt32(14);
                            pro.MaxPorcDesc = dr.GetDecimal(18);

                        }
                    }
                }
                return pro;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable MuestratipoNC()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestratipoNC", con.conector);
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
    }
}
