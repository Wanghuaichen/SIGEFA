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
    class MysqlDocumentoRescom : IDocumentoRescom
    {

        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public Boolean InsertRescom(clsDocumentorescom rescom)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDocumentoRescom", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;                
                oParam = cmd.Parameters.AddWithValue("codSerie_ex", rescom.CodSerie);
                oParam = cmd.Parameters.AddWithValue("numeracion_ex", rescom.Numeracion);
                oParam = cmd.Parameters.AddWithValue("tipodocumento_ex", rescom.Tipodocumento);
                oParam = cmd.Parameters.AddWithValue("codUser_ex", rescom.CodUser);
                oParam = cmd.Parameters.AddWithValue("fecharegistro_ex", rescom.Fecharegistro);
                oParam = cmd.Parameters.AddWithValue("codTipodocumento_ex", rescom.Codtipodocumento);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                rescom.Codigonuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertDetRescom(clsDetalleDocumentoRescom detrescom)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleDocumentoRescom", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("coddocumentorescom_ex", detrescom.Coddocumentorescom);
                oParam = cmd.Parameters.AddWithValue("codFacturaV_ex", detrescom.CodFacturaV);
                oParam = cmd.Parameters.AddWithValue("codTipoDocumento_ex", detrescom.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("numDocumento_ex", detrescom.NumDocumento);
                oParam = cmd.Parameters.AddWithValue("codAlmacen_ex", detrescom.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codCliente_ex", detrescom.CodCliente);
                oParam = cmd.Parameters.AddWithValue("codSerie_ex", detrescom.CodSerie);
                oParam = cmd.Parameters.AddWithValue("serie_ex", detrescom.Serie);
                oParam = cmd.Parameters.AddWithValue("bruto_ex", detrescom.Bruto);
                oParam = cmd.Parameters.AddWithValue("montodscto_ex", detrescom.Montodscto);
                oParam = cmd.Parameters.AddWithValue("valorventa_ex", detrescom.Valorventa);
                oParam = cmd.Parameters.AddWithValue("igv_ex", detrescom.Igv);
                oParam = cmd.Parameters.AddWithValue("total_ex", detrescom.Total);
                oParam = cmd.Parameters.AddWithValue("codUsuario_ex", detrescom.CodUsuario);
                oParam = cmd.Parameters.AddWithValue("fecharegistro_ex", detrescom.Fecharegistro);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                detrescom.CoddetallerescomNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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
