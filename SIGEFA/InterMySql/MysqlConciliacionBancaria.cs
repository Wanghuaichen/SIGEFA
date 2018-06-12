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
    class MysqlConciliacionBancaria:IConciliacionBancaria
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public Boolean Insert(clsConciliacionBancaria acce)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaConciliacionBancaria", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codbanco_ex", acce.Codbanco);
                oParam = cmd.Parameters.AddWithValue("codcuenta_ex", acce.Codcuenta);
                oParam = cmd.Parameters.AddWithValue("saldoextracto_ex", acce.Saldoextracto);
                oParam = cmd.Parameters.AddWithValue("montonocobrado_ex", acce.Montonocobrado);
                oParam = cmd.Parameters.AddWithValue("saldolibro_ex", acce.Saldolibro);
                oParam = cmd.Parameters.AddWithValue("codmoneda_ex", acce.Codmoneda);
                oParam = cmd.Parameters.AddWithValue("coduser_ex", acce.Coduser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                acce.CodconciliacionNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean insertdetalle(clsDetalleConciliacion det)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleConciliacionBancaria", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codconciliacion_ex", det.Codconciliacion);
                oParam = cmd.Parameters.AddWithValue("codctamovimiento_ex", det.Codctamovimiento);
                oParam = cmd.Parameters.AddWithValue("monto_ex", det.Monto);
                oParam = cmd.Parameters.AddWithValue("estado_ex", det.Actico_conci);
                oParam = cmd.Parameters.AddWithValue("coduser_ex", det.Coduser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                det.CodconciliacionNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaMovimientosConci", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("codbanco", codbanco);
                cmd.Parameters.AddWithValue("codcuenta", codcuenta);
                cmd.Parameters.AddWithValue("codigo", CodConciliacion);
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


        public Boolean UpdateBandera(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaBanderaConciliacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalma", codalma);
                cmd.Parameters.AddWithValue("codbanco", codbanco);
                cmd.Parameters.AddWithValue("codcuenta", codcuenta);
                cmd.Parameters.AddWithValue("codigo", CodConciliacion);
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
