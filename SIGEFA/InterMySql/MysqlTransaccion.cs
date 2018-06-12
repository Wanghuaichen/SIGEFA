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
    class MysqlTransaccion: ITransaccion
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IFamilias

        public Boolean Insert(clsTransaccion tran)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaTransaccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("sigla", tran.Sigla);
                oParam = cmd.Parameters.AddWithValue("descripcion", tran.Descripcion);
                oParam = cmd.Parameters.AddWithValue("tipo", tran.Tipo);
                oParam = cmd.Parameters.AddWithValue("codusu", tran.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                tran.CodTransaccion = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsTransaccion tran)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaTransaccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("codtran", tran.CodTransaccion);
                cmd.Parameters.AddWithValue("sigla", tran.Sigla);
                cmd.Parameters.AddWithValue("descripcion", tran.Descripcion);
                cmd.Parameters.AddWithValue("tipo", tran.Tipo);
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

        public Boolean Delete(Int32 CodTransaccion)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarTransaccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtran", CodTransaccion);
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

        public clsTransaccion CargaTransaccion(Int32 Codigo)
        {
            clsTransaccion tran = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTransaccion", con.conector);
                cmd.Parameters.AddWithValue("codtran", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tran = new clsTransaccion();
                        tran.CodTransaccion = Convert.ToInt32(dr.GetDecimal(0));
                        tran.Descripcion = dr.GetString(1);
                        tran.Sigla = dr.GetString(2);
                        tran.Codsunat = dr.GetString(3);
                        tran.Tipo = Convert.ToInt32(dr.GetDecimal(4));
                        tran.Estado = dr.GetBoolean(5); 
                        tran.CodUser = Convert.ToInt32(dr.GetDecimal(6));
                        tran.FechaRegistro = dr.GetDateTime(7);// capturo la fecha 
                    }
                }
                return tran;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsTransaccion CargaTransaccionS(String Sigla, Int32 Tipo)
        {
            clsTransaccion tran = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraTransaccionS", con.conector);
                cmd.Parameters.AddWithValue("sig", Sigla);
                cmd.Parameters.AddWithValue("tip", Tipo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tran = new clsTransaccion();
                        tran.CodTransaccion = Convert.ToInt32(dr.GetDecimal(0));                       
                        tran.Descripcion = dr.GetString(1);
                        tran.Sigla = dr.GetString(2);
                        tran.Codsunat = dr.GetString(3);
                        tran.Tipo = Convert.ToInt32(dr.GetDecimal(4));
                        tran.Estado = dr.GetBoolean(5); 
                        tran.CodUser = Convert.ToInt32(dr.GetDecimal(6));
                        tran.FechaRegistro = dr.GetDateTime(7);// capturo la fecha 
                    }
                }
                return tran;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaTransacciones(Int32 Caso)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaTransacciones", con.conector);
                cmd.Parameters.AddWithValue("caso", Caso);
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

        public Boolean InsertConfiguracion(Int32 CodTransaccion, Int32 CodDetalle, Int32 CodUser)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaConfTran", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codtran", CodTransaccion);
                oParam = cmd.Parameters.AddWithValue("coddeta", CodDetalle);                
                oParam = cmd.Parameters.AddWithValue("codusu", CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
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

        public Boolean LimpiarConfiguracion(Int32 CodTransaccion)
        {

            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("LimpiaConfTran", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codtran", CodTransaccion);                
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

        public List<Int32> MuestraConfiguracion(Int32 CodTransaccion)
        {
            List<Int32> lista = new List<Int32>();

            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaConfTran", con.conector);
                cmd.Parameters.AddWithValue("codTran", CodTransaccion);                
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lista.Add(Convert.ToInt32(dr["codDetalleTransaccion"]));
                    }
                }
                return lista;
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
