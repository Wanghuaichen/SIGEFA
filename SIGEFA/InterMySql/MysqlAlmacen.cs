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
    class MysqlAlmacen:IAlmacen
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IAlmacen

        public Boolean Insert(clsAlmacen alm)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GuardaAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codemp", alm.CodEmpresa);
                oParam = cmd.Parameters.AddWithValue("nombre", alm.Nombre);
                oParam = cmd.Parameters.AddWithValue("ubicacion", alm.Ubicacion);
                oParam = cmd.Parameters.AddWithValue("telefono", alm.Telefono);
                oParam = cmd.Parameters.AddWithValue("descripcion", alm.Descripcion);
                oParam = cmd.Parameters.AddWithValue("estado", alm.Estado);
                oParam = cmd.Parameters.AddWithValue("codusu", alm.CodUser);
                oParam = cmd.Parameters.AddWithValue("codSuc", alm.CodSuc);
                oParam = cmd.Parameters.AddWithValue("estado_principal_ex", alm.EstadoPrincipal);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                alm.CodAlmacenNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsAlmacen alm)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalm", alm.CodAlmacen);
                //cmd.Parameters.AddWithValue("codSu", alm.CodSuc);
                cmd.Parameters.AddWithValue("codSu", alm.CodSuc);
                cmd.Parameters.AddWithValue("nombre", alm.Nombre);
                cmd.Parameters.AddWithValue("ubicacion", alm.Ubicacion);
                cmd.Parameters.AddWithValue("telefono", alm.Telefono);
                cmd.Parameters.AddWithValue("descripcion", alm.Descripcion);
                cmd.Parameters.AddWithValue("estado", alm.Estado);
                cmd.Parameters.AddWithValue("estado_principal_ex", alm.EstadoPrincipal);
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

        public Boolean Delete(Int32 CodAlmacen)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codalm", CodAlmacen);
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


        public clsAlmacen CargaAlmacen(Int32 Codigo)
        {
            clsAlmacen alm = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraAlmacen", con.conector);
                cmd.Parameters.AddWithValue("@codalm", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        alm = new clsAlmacen();
                        alm.CodAlmacen = dr.GetInt32(0);
                        alm.CodEmpresa = dr.GetInt32(1);
                        alm.CodSuc = dr.GetInt32(2);
                        alm.Nombre = dr.GetString(3);
                        alm.Ubicacion = dr.GetString(4);
                        alm.Telefono = dr.GetString(5);
                        alm.Descripcion = dr.GetString(6);
                        alm.Estado = dr.GetBoolean(7);
                        alm.CodUser = dr.GetInt32(8);
                        alm.FechaRegistro = dr.GetDateTime(9);// capturo la fecha                        
                        alm.EstadoPrincipal = dr.GetBoolean(10);
                    }
                }
                return alm;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaAlmacenes(Int32 codEmpresa)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaAlmacenes", con.conector);
                cmd.Parameters.AddWithValue("codempre", codEmpresa);
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

        public DataTable AlmacenesDisponible(Int32 iCodSucursal)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("SeleccionAlmacenSucursal", con.conector);
                //cmd.Parameters.AddWithValue("nivel", iNivel);
                cmd.Parameters.AddWithValue("sucur", iCodSucursal);
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

        public DataTable CargaAlmacenes(Int32 iNivel, Int32 iEmpresa, Int32 iUsuario)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaAlmacenes", con.conector);
                cmd.Parameters.AddWithValue("nivel", iNivel);
                cmd.Parameters.AddWithValue("empre", iEmpresa);
                cmd.Parameters.AddWithValue("usu", iUsuario);
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

        public DataTable BuscaAlmacenes(Int32 Criterio, String Filtro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("FiltraAlmacen", con.conector);
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

        public DataTable ListaAlmacenes2()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaAlmacenes2", con.conector);
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


        public DataTable CargaAlmacen2(Int32 codempre)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaAlmacen", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codempre", codempre);
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

        public DataTable RelacionProductosStockMin(Int32 codTipo, Int32 codAlm)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("RelacionProductosStockMin", con.conector);
                cmd.Parameters.AddWithValue("tipo", codTipo);
                cmd.Parameters.AddWithValue("codalma", codAlm);
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


        public DataTable AlertaFacturasLetrasXVencer()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("AlertaFacturasLetrasVencidas", con.conector);               
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
