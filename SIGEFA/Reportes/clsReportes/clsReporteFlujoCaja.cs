using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;
using SIGEFA.Formularios;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReporteFlujoCaja
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        #region Formulario flujocaja

        public DataSet ReporteFlujoCaja(DateTime fecha1, DateTime fecha2, Int32 codAlmacen)
        {

            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("Rprte_FlujoCaja", con.conector);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "FlujoCaja.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReportePagosFacturaVenta(Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportPagosFacturaVenta", con.conector);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "PagosFacturaVenta.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        #endregion

        #region Formulario MovimientosBancarios

        public DataSet ReporteMovimientosBancarios(DateTime fecha1, DateTime fecha2, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportMovimientosBancarios", con.conector);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "MovimientosBancarios.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        #endregion

        #region Formulario MovimientosBancarios

        public DataSet ReporteLiquidacionCaja(DateTime fecha1, DateTime fecha2, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportLiquidacionCajaDia", con.conector);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("fecha2", fecha2);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "LiquidacionCajaDia.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        #endregion

        #region Formulario Pagos

        public DataSet ReporteImpresionPago(Int32 codPago, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ImprimirPago", con.conector);
                cmd.Parameters.AddWithValue("codpag", codPago);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "ImpresionPago.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }





        //PAGO DE COMPRAS
        public DataSet ReporteImpresionCobro(Int32 codPago, Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ImprimirCobro", con.conector);
                cmd.Parameters.AddWithValue("codpag", codPago);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "ImprimirCobro.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        #endregion

        #region Formulario Caja

        public DataSet ReporteLiquidacionCaja(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportLiquidacion", con.conector);
                cmd.Parameters.AddWithValue("sucur", codSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "LiquidacionCajaRP.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteLiquidacionCaja2(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportLiquidacion2", con.conector);
                cmd.Parameters.AddWithValue("sucur", codSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "LiquidacionCajaRP2.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteLiquidacionCaja3(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportLiquidacion3", con.conector);
                cmd.Parameters.AddWithValue("sucur", codSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "LiquidacionCajaRP3.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReportLiquidacion(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportLiquidacionCaja", con.conector);
                cmd.Parameters.AddWithValue("sucur", codSucursal);
                cmd.Parameters.AddWithValue("fec", fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                String archivo = "RptLiquidacionCaja.xml";
                String carpeta = Path.GetDirectoryName("C:\\XML\\");

                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    if (File.Exists(carpeta + "\\" + archivo))
                    {
                        File.Delete(carpeta + "\\" + archivo);
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                    else
                    {
                        set.WriteXml("C:\\XML\\" + archivo, XmlWriteMode.WriteSchema);
                    }
                }

                return set;
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
