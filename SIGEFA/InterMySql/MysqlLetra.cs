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
    class MysqlLetra : ILetra
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ILetra
         


        public Boolean Insert(clsLetra letra)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaLetra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;                
                oParam = cmd.Parameters.AddWithValue("codalma", Convert.ToInt32(letra.CodAlmacen));
                oParam = cmd.Parameters.AddWithValue("coddoc", letra.CodDocumento);
                oParam = cmd.Parameters.AddWithValue("codser", letra.CodSerie);
                oParam = cmd.Parameters.AddWithValue("numdoc", letra.NumDocumento);
                oParam = cmd.Parameters.AddWithValue("codnota", letra.CodNota);
                oParam = cmd.Parameters.AddWithValue("docref", letra.DocumentoReferencia);
                oParam = cmd.Parameters.AddWithValue("codliberador", letra.CodProveedor);
                oParam = cmd.Parameters.AddWithValue("codliberado", letra.CodLiberado);
                oParam = cmd.Parameters.AddWithValue("fechaemision", letra.FechaEmision);
                oParam = cmd.Parameters.AddWithValue("fechavencimiento", letra.FechaVencimiento);
                oParam = cmd.Parameters.AddWithValue("fechacancelado", letra.FechaCancelado);
                oParam = cmd.Parameters.AddWithValue("ingegre", letra.IngresoEgreso);
                oParam = cmd.Parameters.AddWithValue("codmon", letra.CodMoneda);
                oParam = cmd.Parameters.AddWithValue("tipocambio", letra.TipoCambio);
                oParam = cmd.Parameters.AddWithValue("monto", letra.Monto);
                oParam = cmd.Parameters.AddWithValue("montopendiente", letra.MontoPendiente);
                oParam = cmd.Parameters.AddWithValue("codban", letra.CodBanco);                
                oParam = cmd.Parameters.AddWithValue("numerounico", letra.NumeroUnico);
                oParam = cmd.Parameters.AddWithValue("cancelado", letra.Cancelado);
                oParam = cmd.Parameters.AddWithValue("codusu", letra.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                letra.CodLetra = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean update(clsLetra letra)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaLetra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codlet", Convert.ToInt32(letra.CodLetra));                
                cmd.Parameters.AddWithValue("coddoc", letra.CodDocumento);
                cmd.Parameters.AddWithValue("codser", letra.CodSerie);                
                cmd.Parameters.AddWithValue("numdoc", letra.NumDocumento);                
                cmd.Parameters.AddWithValue("fechaemision", letra.FechaEmision);
                cmd.Parameters.AddWithValue("fechavencimiento", letra.FechaVencimiento);                           
                cmd.Parameters.AddWithValue("moneda", letra.CodMoneda);
                cmd.Parameters.AddWithValue("tipocambio", letra.TipoCambio);
                cmd.Parameters.AddWithValue("monto", letra.Monto);
                cmd.Parameters.AddWithValue("montopendiente", letra.MontoPendiente);
                cmd.Parameters.AddWithValue("codban", letra.CodBanco);
                cmd.Parameters.AddWithValue("numerounico", letra.NumeroUnico);               
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

        public Boolean delete(Int32 CodigoLetra)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarLetra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codletra", CodigoLetra);
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

        public clsLetra CargaLetra(Int32 Codletra)
        {
            clsLetra letra = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraLetra", con.conector);
                cmd.Parameters.AddWithValue("codle", Codletra);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        letra = new clsLetra();
                        letra.CodLetra = Convert.ToInt32(dr.GetDecimal(0));
                        letra.CodAlmacen = Convert.ToInt32(dr.GetDecimal(1));
                        letra.CodDocumento = Convert.ToInt32(dr.GetDecimal(2));
                        letra.SiglaDocumento = dr.GetString(3);
                        letra.CodSerie = Convert.ToInt32(dr.GetDecimal(4));
                        letra.Serie = dr.GetString(5);
                        letra.NumDocumento = dr.GetString(6);
                        letra.CodNota = Convert.ToInt32(dr.GetString(7));
                        letra.CodProveedor = Convert.ToInt32(dr.GetString(8));
                        letra.RucProveedor = dr.GetString(9);
                        letra.RazonSocialProveedor = dr.GetString(10);
                        letra.DireccionProveedor = dr.GetString(11);
                        letra.CodLiberado = Convert.ToInt32(dr.GetDecimal(12));
                        letra.FechaEmision = dr.GetDateTime(13);
                        letra.FechaVencimiento = dr.GetDateTime(14);
                        letra.FechaCancelado2 = dr.GetString(15);
                        letra.IngresoEgreso = dr.GetBoolean(16);
                        letra.CodMoneda = Convert.ToInt32(dr.GetString(17));
                        letra.TipoCambio = dr.GetDouble(18);
                        letra.Monto = dr.GetDouble(19);
                        letra.MontoPendiente = dr.GetDouble(20);
                        letra.CodBanco = Convert.ToInt32(dr.GetString(21));
                        letra.NumeroUnico = dr.GetString(22);
                        letra.Estado = dr.GetBoolean(23);
                        letra.Cancelado = dr.GetBoolean(24);
                        letra.CodUser = Convert.ToInt32(dr.GetDecimal(25));
                        letra.FechaRegistro = dr.GetDateTime(26);
                        letra.DocumentoReferencia = dr.GetString(27);
                    }
                }
                return letra;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }



        public DataTable MuestraListaLetrasNota(Int32 CodNotaIngreso)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraListaLetrasPorNota", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codnot", CodNotaIngreso);                
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

        public Boolean AnularLetra(Int32 CodigoLetra)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("AnularLetra", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codletra", CodigoLetra);
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

        public Int32 GetCodigoFactura(Int32 codigonota)
        {
            Int32 CodigoFactura = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodigoFactura", con.conector);
                cmd.Parameters.AddWithValue("codNotaI_ex", codigonota);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                       
                        CodigoFactura = dr.GetInt32(0);                       
                    }
                }
                return CodigoFactura;

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
