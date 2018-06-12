using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using SIGEFA.Conexion;
using SIGEFA.Formularios;

namespace SIGEFA.Reportes.clsReportes
{
    class clsDocumentosImpresos
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;
        DataSet set = null;

        public DataSet Cotizacion(Int32 codCotizacion)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("RptCotizacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codcoti", codCotizacion);                
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\cotizacion.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet FormaPago()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaFormaPagos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\FormaPagoRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Requerimiento(Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("RptRequerimiento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("cod", cod);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\Requerimiento.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet Orden(Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("RptOrden", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("cod", cod);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\Orden.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Sucursal()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaSucursales", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\SucursalRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Lineas(Int32 codCotizacion)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaLineas", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codfam", codCotizacion);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\LineasRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Grupos(Int32 codCotizacion)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaGrupos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codlin", codCotizacion);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\GruposRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataSet MetodoPago()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaMetodoPagos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\MetodoPagoRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ListaPrecios()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReporteListasPrecios", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codSu", frmLogin.iCodSucursal);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ListaPreciosRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet VehiculoTransporte()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaVehiculoTransportes", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VehiculoTransporteRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet Conductores()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaConductores", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ConductoresRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet EmpresaTransporte()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaEmpresasTransporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\EmpresasTransporteRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet Zonas()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaZonas", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ZonasRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet Vendedores()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaVendedores", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\VendedoresRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet Destaques()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaDestaques", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\DestaquesRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet TarjetaPago()
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTarjetasPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codalma", frmLogin.iCodAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\ListaTarjetasPagoRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet TransferenciaxDevolucion(Int32 cod)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("RptTransferenciaPorDevolucion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codnota", cod);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\TransferenciaxDevolucion.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet Rendiciones(Int32 tipo)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaRendicionesRP", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codSucur", frmLogin.iCodSucursal);
                cmd.Parameters.AddWithValue("tipo",tipo);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\RendicionesRP.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

    }
}
