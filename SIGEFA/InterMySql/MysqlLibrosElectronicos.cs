using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;
using SIGEFA.Formularios;
namespace SIGEFA.InterMySql
{
    class MysqlLibrosElectronicos : ILibrosElectronicos
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ILibros Electronicos

        public Boolean Insert(clsLibrosElectronicos libro)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaLibroElectronico", con.conector); // falta completar todas las propiedades y crear su procedimiento
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("descripcion", libro.Descripcion);
                oParam = cmd.Parameters.AddWithValue("sig", libro.Codsunat);
                oParam = cmd.Parameters.AddWithValue("codusu", libro.Coduser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                libro.Codnuevolibro = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsLibrosElectronicos libro)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaLibroElestronico", con.conector); // falta completar todas las propiedades y crear su procedimiento
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codban", libro.Codlibro);
                cmd.Parameters.AddWithValue("descripcion", libro.Descripcion);
                cmd.Parameters.AddWithValue("sig", libro.Codsunat);
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

        public Boolean Delete(Int32 CodLibro)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarLibroElectronico", con.conector); // falta crear su procedimiento
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codlib", CodLibro);
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

        public clsLibrosElectronicos MuestraLE(Int32 Codigo)
        {
            clsLibrosElectronicos le = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraLibro", con.conector);
                cmd.Parameters.AddWithValue("codlibro_ex", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        le = new clsLibrosElectronicos();
                        le.Codlibro = dr.GetInt32(0);
                        le.Codsunat = dr.GetString(1);
                        le.Descripcion = dr.GetString(2);
                        le.Aplicaanio = dr.GetInt32(3); 
                        le.Aplicames = dr.GetInt32(4); 
                        le.Aplicadia = dr.GetInt32(5);
                        le.Aplicaoportunidad = dr.GetInt32(6);
                        le.Estado = dr.GetInt32(7);
                        le.Coduser = dr.GetInt32(8);
                        le.Fecharegistro = dr.GetDateTime(9);// capturo la fecha 
                    }

                }
                return le;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaLibrosElectronicos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaLibrosElectronicos", con.conector);
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

        public DataTable CargaRegistrosElectronicos(Int32 Codle)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaRegistrosElectronicos", con.conector);
                cmd.Parameters.AddWithValue("codlibros_ex", Codle);
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

        public clsRegistroElectronico MuestraRE(Int32 Codigo)
        {
            clsRegistroElectronico re = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraRegistro", con.conector);
                cmd.Parameters.AddWithValue("codlibroregistro_ex", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        re = new clsRegistroElectronico();
                        re.Codlibroregistro = dr.GetInt32(0);
                        re.Codlibros = dr.GetInt32(1);
                        re.Codsunat = dr.GetString(2);
                        re.Descripcion = dr.GetString(3);
                        re.Codigo = dr.GetString(4);
                        re.Estado = dr.GetInt32(5);
                        re.Coduser = dr.GetInt32(6);
                        re.Fecharegistro = dr.GetDateTime(7);// capturo la fecha 
                    }

                }
                return re;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaOperaciones()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaOperaciones", con.conector);
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

        public DataTable CargaContenido()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaContenido", con.conector);
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

        public DataTable CargaGeneradoPor()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaGeneradoPor", con.conector);
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

        public DataTable GetVentas_Mes_LEV(Int32 mes)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("GetVentas_Mes_LEV", con.conector);
                cmd.Parameters.AddWithValue("mes_ex", mes);
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

        public DataTable FacturasComprasLE(Int32 mes, Int32 codalma, String cadena) 
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand(cadena, con.conector);
                cmd.Parameters.AddWithValue("mes", mes);
                cmd.Parameters.AddWithValue("alma", codalma);
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

        public Int32 ValidaCampoTipoFacturacion(Int32 mes, Int32 Anio) 
        {
            Int32 valida = 0;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("ValidaCampoTipoFacturacion", con.conector);
                cmd.Parameters.AddWithValue("mes_ex", mes);
                cmd.Parameters.AddWithValue("anio_ex", Anio);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        valida = dr.GetInt32(0);
                    }
                }
                return valida;
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
