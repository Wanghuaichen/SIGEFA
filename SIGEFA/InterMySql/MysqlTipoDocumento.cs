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
    class MysqlTipoDocumento : ITipoDocumento
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ITipoDocumento

        public Boolean Insert(clsTipoDocumento doc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTipoDocumento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("sigla", doc.Sigla);
                oParam = cmd.Parameters.AddWithValue("descripcion", doc.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", doc.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                doc.CodTipoDocumentoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTipoDocumento doc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTipoDocumento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddoc", doc.CodTipoDocumento);
                cmd.Parameters.AddWithValue("sigla", doc.Sigla);
                cmd.Parameters.AddWithValue("descripcion", doc.Descripcion);
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

        public Boolean Delete(Int32 CodTipoDocumento)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTipoDocumento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddoc", CodTipoDocumento);
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
        public clsTipoDocumento CargaTipoDocumento(Int32 Codigo)
        {
            clsTipoDocumento doc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTipoDocumento", con.conector);
                cmd.Parameters.AddWithValue("coddoc", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        doc = new clsTipoDocumento();
                        doc.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        doc.Sigla = dr.GetString(1);
                        doc.Descripcion = dr.GetString(2);
                        doc.Estado = dr.GetBoolean(3); 
                        doc.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        doc.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                        doc.Tipodoccodsunat = dr.GetString(6);
                    }
                }
                return doc;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsTipoDocumento BuscaTipoDocumento(String Sigla)
        {
            clsTipoDocumento doc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaTipoDocumento", con.conector);
                cmd.Parameters.AddWithValue("sig", Sigla);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        doc = new clsTipoDocumento();
                        doc.CodTipoDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        doc.Sigla = dr.GetString(1);
                        doc.Descripcion = dr.GetString(2);                       
                    }
                }
                return doc;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaTipoDocumentos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTipoDocumentos", con.conector);
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

        public DataTable ListaTipoDocumentosDeCaja()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTipoDocumentosDeCaja", con.conector);
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

        public DataTable CargaTipoDocumentos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaTipoDocumentos", con.conector);
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

        public DataTable ListaDocumentoNota()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaDocumentoNota", con.conector);
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
    }
}
