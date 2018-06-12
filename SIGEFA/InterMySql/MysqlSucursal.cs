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
    class MysqlSucursal : ISucursal
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ISucursal

        public Boolean Insert(clsSucursal suc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codemp", suc.CodEmpresa);
                oParam = cmd.Parameters.AddWithValue("nombre", suc.Nombre);
                oParam = cmd.Parameters.AddWithValue("ubicacion", suc.Ubicacion);
                oParam = cmd.Parameters.AddWithValue("telefono", suc.Telefono);
                oParam = cmd.Parameters.AddWithValue("descripcion", suc.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", suc.CodUser);
                oParam = cmd.Parameters.AddWithValue("estado", suc.Estado);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                suc.CodSucursalNueva = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsSucursal suc)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codemp", suc.CodEmpresa);
                cmd.Parameters.AddWithValue("nombre", suc.Nombre);
                cmd.Parameters.AddWithValue("ubicacion", suc.Ubicacion);
                cmd.Parameters.AddWithValue("telefono", suc.Telefono);
                cmd.Parameters.AddWithValue("descripcion", suc.Descripcion);
                cmd.Parameters.AddWithValue("codusu", suc.CodUser);
                cmd.Parameters.AddWithValue("estado", suc.Estado);
                cmd.Parameters.AddWithValue("codsu", suc.CodSucursal);
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

        public Boolean Delete(Int32 Codigo)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codSuc", Codigo);
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


        public clsSucursal CargaSucursal(Int32 Codigo)
        {
            clsSucursal suc = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraSucursal", con.conector);
                cmd.Parameters.AddWithValue("CodSucu", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        suc = new clsSucursal();
                        suc.CodSucursal = Convert.ToInt32(dr.GetInt32(0));
                        suc.CodEmpresa = Convert.ToInt32(dr.GetInt32(1));
                        suc.Nombre = dr.GetString(2);
                        suc.Ubicacion = dr.GetString(3);
                        suc.Telefono = dr.GetString(4);
                        suc.Descripcion = dr.GetString(5);
                        suc.Estado = dr.GetBoolean(6);                       
                        suc.FechaRegistro = dr.GetDateTime(7);// capturo la fecha 
                    }

                }
                return suc;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean VerificaRUC(String RUC)
        {            
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("VerificaRUC", con.conector);
                cmd.Parameters.AddWithValue("rucingresado", RUC);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
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

        public DataTable ListaSucursales()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaSucursales", con.conector);
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

        public DataTable CargaSucursalesXempresa(Int32 Codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaSucursalesXempresa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CodEmpre", Codigo);
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

        public DataTable CargaSucursales(Int32 Codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaSucursales", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CodEmpre", Codigo);
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

        public DataTable CargaSucursalesXusuario(Int32 Codigo, Int32 CodUsuario)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaSucursalesXUsuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CodEmpre", Codigo);
                cmd.Parameters.AddWithValue("CodUsu", CodUsuario);
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

        public DataTable CargaSucursalesSeleccion(Int32 Codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaSucursalesSeleccion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CodEmpre", Codigo);
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

        public DataTable BuscaSucursales(Int32 Criterio, String Filtro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("FiltraSucursales", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criterio", Criterio);
                cmd.Parameters.AddWithValue("@filtro", Filtro);
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

        public DataTable CargaSucursales()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaSucursales", con.conector);
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

        public Boolean UpdateConfiguracion(clsParametros Config)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaConfiguracion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("config", Config.CodConfiguracion); 
                cmd.Parameters.AddWithValue("igv", Config.IGV);               
                cmd.Parameters.AddWithValue("codusu", Config.CodUser);                
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

        public clsParametros CargaConfiguracion()
        {
            clsParametros config = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaConfiguracion", con.conector);                
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        config = new clsParametros();
                        config.CodConfiguracion = Convert.ToInt32(dr.GetDecimal(0));
                        config.IGV = Convert.ToDouble(dr.GetDecimal(1));
                        config.Estado = dr.GetBoolean(2);
                        config.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        config.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }
                }
                return config;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaSucursales_Empresa(Int32 Codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaSucursales_Empresa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CodEmpre", Codigo);
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
