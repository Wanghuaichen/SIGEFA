using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using SIGEFA.Conexion;
using System.Windows.Forms;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReporteCaja
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet RptMuestraCierreCaja(Int32 codSucursal, DateTime fecha1, Int32 codcaja, Int32 codalmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                //codcaja = 38;
                //fecha1 = Convert.ToDateTime("26-09-2017");
                ////--------------------------------------------------------
                cmd = new MySqlCommand("listaDetallesCierre", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codSucur", codSucursal);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("codcaja_ex", codcaja);
                cmd.Parameters.AddWithValue("codalma_ex", codalmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ingresosCierre");

                ////--------------------------------------------------------

                ////MessageBox.Show(codSucursal + "" + fecha1 + "");
                cmd = new MySqlCommand("GeneraCierreCabeceraSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codSucur", codSucursal);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_sucursalCierre");

                //---------------------------------------------------------

                cmd = new MySqlCommand("valoresCierraCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codSucur", codSucursal);
                cmd.Parameters.AddWithValue("codcaja_ex", codcaja);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_totales");


                //---------------------------------------------------------

                cmd = new MySqlCommand("MuestraTotalSeparacionCaja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("fe", fecha1);
                cmd.Parameters.AddWithValue("codalma", codalmacen);
                cmd.Parameters.AddWithValue("codcaja", codcaja);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_totalseparacion");

                set.WriteXml("C:\\XML\\CierreCajaDiario.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteMovimientosCajaVentas(Int32 CodSucursal, DateTime fecha, Int32 CodCaja, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
               
                ////--------------------------------------------------------
                 
                cmd = new MySqlCommand("ReporteMovimientosCajaVentas", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codSucur", CodSucursal);
                cmd.Parameters.AddWithValue("fecha1", fecha);
                cmd.Parameters.AddWithValue("codcaja_ex", CodCaja);
                cmd.Parameters.AddWithValue("codalma_ex", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_RTMovimientosCajaVentas");

                set.WriteXml("C:\\XML\\ReporteMovimientosCajaVentasRPT.xml", XmlWriteMode.WriteSchema);
                ////--------------------------------------------------------
            
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet DatosSucursal(Int32 CodSucursal)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                ////--------------------------------------------------------

                cmd = new MySqlCommand("GeneraCierreCabeceraSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codSucur", CodSucursal);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_RTSucursal"); 

                set.WriteXml("C:\\XML\\SucursalRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReciboDietasyEstimulo(Int32 tipo, Int32 Codigo)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                ////--------------------------------------------------------
                cmd = new MySqlCommand("ReproteReciboEgresosRpt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codmovimiento_ex", Codigo);
                cmd.Parameters.AddWithValue("tipo_movimiento_ex", tipo);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReproteReciboEgresos");


                set.WriteXml("C:\\XML\\ReproteReciboEgresosRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReciboCajaChica(Int32 tipo, Int32 Codigo)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                ////--------------------------------------------------------
                cmd = new MySqlCommand("ReciboCajaChicaRpt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codRecibo_ex", Codigo);
                cmd.Parameters.AddWithValue("codtipopagocajachica_ex", tipo);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReciboCajaChica");


                set.WriteXml("C:\\XML\\ReciboCajaChicaRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet ReporteMovimientosCajaChica(Int32 CodSucursal, DateTime fecha, Int32 codigocaja, Int32 codalma)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                ////--------------------------------------------------------
                cmd = new MySqlCommand("ReporteMovimientosCajaChicaRpt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codSucur", CodSucursal);
                cmd.Parameters.AddWithValue("fecha1", fecha);
                cmd.Parameters.AddWithValue("codcaja_ex", codigocaja);
                cmd.Parameters.AddWithValue("codalma_ex", codalma);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReporteMovimientosCajaChica");


                set.WriteXml("C:\\XML\\ReporteMovimientosCajaChicaRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public DataSet ReporteArqueoFondoFijo(Int32 CodArqueo)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                ////--------------------------------------------------------
                cmd = new MySqlCommand("ReporteArqueoFondoFijoRpt", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codarqueofondodijo_ex", CodArqueo);
                //cmd.Parameters.AddWithValue("codtipopagocajachica_ex", tipo);

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_ReporteArqueoFondoFijo");


                set.WriteXml("C:\\XML\\ReporteArqueoFondoFijoRpt.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
