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
    class MysqlUnidades:IUnidad
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IUnidad

        public Boolean Insert(clsUnidadMedida uni)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaUnidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("sigla", uni.Sigla);
                oParam = cmd.Parameters.AddWithValue("descripcion", uni.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", uni.CodUser);                
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                uni.CodUnidadNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsUnidadMedida uni)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaUnidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coduni", uni.CodUnidad);                
                cmd.Parameters.AddWithValue("sigla", uni.Sigla);               
                cmd.Parameters.AddWithValue("descripcion", uni.Descripcion);                
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

        public Boolean Delete(Int32 CodUnidad)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarUnidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coduni", CodUnidad);
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

        public clsUnidadMedida CargaUnidad(Int32 Codigo)
        {
            clsUnidadMedida uni = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUnidadMedida", con.conector);
                cmd.Parameters.AddWithValue("coduni", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        uni = new clsUnidadMedida();
                        uni.CodUnidad = Convert.ToInt32(dr.GetDecimal(0));
                        uni.Sigla = dr.GetString(1);
                        uni.Descripcion = dr.GetString(2);
                        uni.Estado = dr.GetBoolean(3); 
                        uni.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        uni.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return uni;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaUnidades()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUnidades", con.conector);
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

        public DataTable MuestraUnidadesEquivalentes()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUnidadesEquivalentes", con.conector);
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

        public Boolean ActualizaPrecioEnDolares()
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ActualizaPrecioEnDolares", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public Int32 CantidadProductosDolares()
        {
            try
            {
                Int32 resultado = 0;
                con.conectarBD();
                cmd = new MySqlCommand("CantidadProductosDolares", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr.GetInt32(0));
                    }
                }
                return resultado;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Int32 ValidaMoneda(){
            try
            {
                Int32 resultado = 0;
                con.conectarBD();
                cmd = new MySqlCommand("ValidaMoneda", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr.GetInt32(0));
                    }
                }
                return resultado;
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
