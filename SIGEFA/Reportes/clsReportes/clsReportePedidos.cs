using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Reportes.clsReportes
{
    class clsReportePedidos
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataSet set = null;

        public DataSet RptPedidosPen(Int32 codAlmacen)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ListaPedidos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\PedidosRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet RptDetallePedido(Int32 codPedido)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();
                cmd = new MySqlCommand("ReportePedidoDetalle", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.AddWithValue("codpedido", codPedido);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set);
                set.WriteXml("C:\\XML\\PedidoDetalleRPT.xml", XmlWriteMode.WriteSchema);
                return set;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataSet RptMuestraEntregaConsultorExt(Int32 CodConsExt)
        {
            try
            {
                set = new DataSet();
                con.conectarBD();

                ////---------------------------------------------------------

                cmd = new MySqlCommand("valoresEntregaConsultor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codconext", CodConsExt);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_cabeceraConsultor");

                ////--------------------------------------------------------
                cmd = new MySqlCommand("MuestraConsultorProductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 250;
                cmd.Parameters.AddWithValue("codconext", CodConsExt);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(set, "dt_consultorProductos");

                set.WriteXml("C:\\XML\\ConsultorEnt.xml", XmlWriteMode.WriteSchema);
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
