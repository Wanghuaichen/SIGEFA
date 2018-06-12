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
    class MysqlCuota:ICuota
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ICuota



        public Boolean Insert(clsCuota cuota)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaCuota", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpreban", cuota.CodPrestamoBancario);
                oParam = cmd.Parameters.AddWithValue("nrocuo", cuota.NroCuota);
                oParam = cmd.Parameters.AddWithValue("codmon", cuota.CodMoneda);
                oParam = cmd.Parameters.AddWithValue("fechaemision", cuota.FechaEmision);
                oParam = cmd.Parameters.AddWithValue("fechavencimiento", cuota.FechaVencimiento);
                oParam = cmd.Parameters.AddWithValue("monto", cuota.Monto);
                oParam = cmd.Parameters.AddWithValue("montopendiente", cuota.MontoPendiente);
                oParam = cmd.Parameters.AddWithValue("codusu", cuota.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                cuota.CodCuotaPrestamo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        //public Boolean update(clsLetra letra)
        //{
        //    try
        //    {
        //        con.conectarBD();

        //        cmd = new MySqlCommand("ActualizaLetra", con.conector);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("codlet", Convert.ToInt32(letra.CodLetra));
        //        cmd.Parameters.AddWithValue("coddoc", letra.CodDocumento);
        //        cmd.Parameters.AddWithValue("codser", letra.CodSerie);
        //        cmd.Parameters.AddWithValue("numdoc", letra.NumDocumento);
        //        cmd.Parameters.AddWithValue("fechaemision", letra.FechaEmision);
        //        cmd.Parameters.AddWithValue("fechavencimiento", letra.FechaVencimiento);
        //        cmd.Parameters.AddWithValue("moneda", letra.CodMoneda);
        //        cmd.Parameters.AddWithValue("tipocambio", letra.TipoCambio);
        //        cmd.Parameters.AddWithValue("monto", letra.Monto);
        //        cmd.Parameters.AddWithValue("montopendiente", letra.MontoPendiente);
        //        cmd.Parameters.AddWithValue("codban", letra.CodBanco);
        //        cmd.Parameters.AddWithValue("numerounico", letra.NumeroUnico);
        //        int x = cmd.ExecuteNonQuery();
        //        if (x != 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        //}

        //public Boolean delete(Int32 CodigoLetra)
        //{
        //    try
        //    {
        //        con.conectarBD();
        //        cmd = new MySqlCommand("EliminarLetra", con.conector);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("codletra", CodigoLetra);
        //        int x = cmd.ExecuteNonQuery();
        //        if (x != 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw ex;

        //    }
        //    finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        //}

        public clsCuota CargaCuota(Int32 Codcuota)
        {
            clsCuota cuota = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraCuota", con.conector);
                cmd.Parameters.AddWithValue("codcu", Codcuota);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cuota = new clsCuota();
                        cuota.CodCuotaPrestamo = Convert.ToInt32(dr.GetDecimal(0));
                        cuota.CodPrestamoBancario = Convert.ToInt32(dr.GetString(1));
                        cuota.CodMoneda = Convert.ToInt32(dr.GetString(2));
                        cuota.DescMoneda = dr.GetString(3);
                        cuota.TipoCambio = dr.GetDecimal(4);
                        cuota.FechaEmision = dr.GetDateTime(5);
                        cuota.FechaVencimiento = dr.GetDateTime(6);
                        cuota.FechaCancelado = dr.GetDateTime(7);
                        cuota.Monto = Convert.ToDecimal(dr.GetDecimal(8));
                        cuota.MontoPendiente = Convert.ToDecimal(dr.GetDecimal(9));
                        cuota.Montoadicional = Convert.ToDecimal(dr.GetDecimal(10));
                        cuota.Cancelado = dr.GetBoolean(11);
                        cuota.Estado = dr.GetBoolean(12);
                        cuota.CodUser = Convert.ToInt32(dr.GetDecimal(13));
                        cuota.FechaRegistro = dr.GetDateTime(14);
                    }
                }
                return cuota;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }



        public DataTable MuestraListaCuotasPrestamo(Int32 CodPreBan)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraListaCuotasPrestamo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpreban", CodPreBan);
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

        //public Boolean AnularLetra(Int32 CodigoLetra)
        //{
        //    try
        //    {
        //        con.conectarBD();
        //        cmd = new MySqlCommand("AnularLetra", con.conector);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("codletra", CodigoLetra);
        //        int x = cmd.ExecuteNonQuery();
        //        if (x != 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw ex;

        //    }
        //    finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        //}


        #endregion

    }
}
