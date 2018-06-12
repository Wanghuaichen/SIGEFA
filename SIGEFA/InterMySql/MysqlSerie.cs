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
    class MysqlSerie : ISerie
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ISerie

        public Boolean Insert(clsSerie ser)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaSerie", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("coddoc", ser.CodDocumento);
                oParam = cmd.Parameters.AddWithValue("codalm", ser.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("serie", ser.Serie);
                oParam = cmd.Parameters.AddWithValue("inicio", ser.Inicio);
                oParam = cmd.Parameters.AddWithValue("fin", ser.Fin);
                oParam = cmd.Parameters.AddWithValue("numeracion", ser.Numeracion);
                oParam = cmd.Parameters.AddWithValue("codusu", ser.CodUser);
                oParam = cmd.Parameters.AddWithValue("nomimpre", ser.NombreImpresora);
                oParam = cmd.Parameters.AddWithValue("paper", ser.PaperSize);
                oParam = cmd.Parameters.AddWithValue("serimpre", ser.SerieImpresora);
                oParam = cmd.Parameters.AddWithValue("preimpreso", ser.PreImpreso);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                ser.CodSerie = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsSerie ser)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaSerie", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codse", ser.CodSerie);
                cmd.Parameters.AddWithValue("serie", ser.Serie);
                cmd.Parameters.AddWithValue("inicio", ser.Inicio);
                cmd.Parameters.AddWithValue("fin", ser.Fin);
                cmd.Parameters.AddWithValue("numeracion", ser.Numeracion);
                cmd.Parameters.AddWithValue("nomimpre", ser.NombreImpresora);
                cmd.Parameters.AddWithValue("paper", ser.PaperSize);
                cmd.Parameters.AddWithValue("serie_impresora", ser.SerieImpresora);
                cmd.Parameters.AddWithValue("preimpreso", ser.PreImpreso);
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

        public Int32 ExistenSeries(Int32 CodDocumento, Int32 CodAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ExisteSeries", con.conector);
                cmd.Parameters.AddWithValue("coddoc", CodDocumento);
                cmd.Parameters.AddWithValue("codalm", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 GetCodigoSerie(Int32 CodDocumento, Int32 CodAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GetCodigoSerie", con.conector);
                cmd.Parameters.AddWithValue("coddoc", CodDocumento);
                cmd.Parameters.AddWithValue("codalm", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsSerie BuscaSeriexDocumento(int codDocumento, int CodAlmacen)
        {
            clsSerie ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaSeriexDocumento", con.conector);
                cmd.Parameters.AddWithValue("doc", codDocumento);
                cmd.Parameters.AddWithValue("alm", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsSerie();
                        ser.CodSerie = Convert.ToInt32(dr.GetDecimal(0));
                        ser.Serie = dr.GetString(1);
                        ser.Numeracion = Convert.ToInt32(dr.GetDecimal(2));
                        ser.NombreImpresora = dr.GetString(3);
                        ser.PaperSize = dr.GetString(4);
                        ser.PreImpreso = dr.GetBoolean(5);
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean Delete(Int32 CodSerie)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarSerie", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codser", CodSerie);
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

        public clsSerie CargaSerie(Int32 Codigo, Int32 CodAlmacen)
        {
            clsSerie ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraSerie", con.conector);
                cmd.Parameters.AddWithValue("codser", Codigo);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsSerie();
                        ser.CodSerie = Convert.ToInt32(dr.GetDecimal(0));
                        ser.CodDocumento = Convert.ToInt32(dr.GetDecimal(1));
                        ser.CodEmpresa = Convert.ToInt32(dr.GetDecimal(2));
                        ser.CodAlmacen = Convert.ToInt32(dr.GetDecimal(3));
                        ser.Serie = dr.GetString(4);
                        ser.Inicio = Convert.ToInt32(dr.GetDecimal(5));
                        ser.Fin = Convert.ToInt32(dr.GetDecimal(6));
                        ser.Numeracion = Convert.ToInt32(dr.GetDecimal(7));
                        ser.Estado = dr.GetBoolean(8);
                        ser.CodUser = Convert.ToInt32(dr.GetDecimal(9));
                        ser.FechaRegistro = dr.GetDateTime(10);// capturo la fecha 
                        ser.NombreImpresora = dr.GetString(11);
                        ser.PaperSize = dr.GetString(12);
                        ser.SerieImpresora = dr.GetString(13);
                        ser.PreImpreso = dr.GetBoolean(14);
                    }

                }
                return ser;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaSeries(Int32 CodDoc, Int32 CodAlmacen)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaSeries", con.conector);
                cmd.Parameters.AddWithValue("coddoc", CodDoc);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
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

        public clsSerie BuscaSerie(String Serie, Int32 Documento, Int32 Almacen)
        {
            clsSerie ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaSerie", con.conector);
                cmd.Parameters.AddWithValue("ser", Serie);
                cmd.Parameters.AddWithValue("doc", Documento);
                cmd.Parameters.AddWithValue("alm", Almacen);                
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsSerie();
                        ser.CodSerie = Convert.ToInt32(dr.GetDecimal(0));
                        ser.Serie = dr.GetString(1);
                        ser.Numeracion = Convert.ToInt32(dr.GetDecimal(2));
                        ser.NombreImpresora = dr.GetString(3);
                        ser.PaperSize = dr.GetString(4);
                        ser.PreImpreso = dr.GetBoolean(5);
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        //MODIFICACION ALEX TRAE SERIE
        public Int32 traeNumeracion(Int32 codal, Int32 coddoc)
        {
            Int32 numero = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("traeNumeracion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codal", codal);
                cmd.Parameters.AddWithValue("coddoc", coddoc);
                numero = (int)cmd.ExecuteScalar();

                return numero;

            }
            catch (MySqlException ex)
            {
                return numero;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        //MODIFICACION ALEX TRAE SERIE
        public Int32 traeCodSerie(Int32 codal, Int32 coddoc)
        {
            Int32 numero = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("traeCodSerie", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codal", codal);
                cmd.Parameters.AddWithValue("coddoc", coddoc);
                numero = (int)cmd.ExecuteScalar();

                return numero;

            }
            catch (MySqlException ex)
            {
                return numero;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsSerie CargaSerieEmpresa(Int32 CodigoAlmacen, Int32 codigoDoc)
        {
            clsSerie ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraSerieEmpresa", con.conector);
                cmd.Parameters.AddWithValue("codAlmacen_ex", CodigoAlmacen);
                cmd.Parameters.AddWithValue("codDocumento_ex", codigoDoc);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsSerie();
                        ser.CodSerie = Convert.ToInt32(dr.GetDecimal(0));
                        ser.CodDocumento = Convert.ToInt32(dr.GetDecimal(1));
                        ser.CodEmpresa = Convert.ToInt32(dr.GetDecimal(2));
                        ser.CodAlmacen = Convert.ToInt32(dr.GetDecimal(3));
                        ser.Serie = dr.GetString(4);
                        ser.Inicio = Convert.ToInt32(dr.GetDecimal(5));
                        ser.Fin = Convert.ToInt32(dr.GetDecimal(6));
                        ser.Numeracion = Convert.ToInt32(dr.GetDecimal(7));
                        ser.Estado = dr.GetBoolean(8);
                        ser.CodUser = Convert.ToInt32(dr.GetDecimal(9));
                        ser.FechaRegistro = dr.GetDateTime(10);// capturo la fecha 
                        ser.NombreImpresora = dr.GetString(11);
                        ser.PaperSize = dr.GetString(12);
                        ser.SerieImpresora = dr.GetString(13);
                        ser.PreImpreso = dr.GetBoolean(14);
                        //ser.Descripcion = dr.GetString(15);
                    }

                }
                return ser;

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
