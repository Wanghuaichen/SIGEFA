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
    class MysqlUsuario:IUsuario
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IUsuario

        public Boolean Insert(clsUsuario usu)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaUsuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                if (usu.Dni=="") oParam = cmd.Parameters.AddWithValue("dni", null);
                else oParam = cmd.Parameters.AddWithValue("dni", usu.Dni);
                oParam = cmd.Parameters.AddWithValue("nombre", usu.Nombre);
                oParam = cmd.Parameters.AddWithValue("apellido", usu.Apellido);
                oParam = cmd.Parameters.AddWithValue("fechanac", usu.FechaNac);
                oParam = cmd.Parameters.AddWithValue("direccion", usu.Direccion);
                oParam = cmd.Parameters.AddWithValue("telefono", usu.Telefono);
                oParam = cmd.Parameters.AddWithValue("celular", usu.Celular);
                oParam = cmd.Parameters.AddWithValue("email", usu.Email);
                oParam = cmd.Parameters.AddWithValue("usuario", usu.Usuario);
                oParam = cmd.Parameters.AddWithValue("contraseña", usu.Contraseña);
                oParam = cmd.Parameters.AddWithValue("contraemail", usu.ContraEmail);
                oParam = cmd.Parameters.AddWithValue("hostmail", usu.Host);
                oParam = cmd.Parameters.AddWithValue("host", usu.Host);
                oParam = cmd.Parameters.AddWithValue("nivel", usu.Nivel);
                oParam = cmd.Parameters.AddWithValue("estado", usu.Estado);
                oParam = cmd.Parameters.AddWithValue("codusu", usu.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                usu.CodUsuarioNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsUsuario usu)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaUsuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codusu", usu.CodUsuario);
                cmd.Parameters.AddWithValue("dni", usu.Dni);
                cmd.Parameters.AddWithValue("nombre", usu.Nombre);
                cmd.Parameters.AddWithValue("apellido", usu.Apellido);
                cmd.Parameters.AddWithValue("fechanac", usu.FechaNac);
                cmd.Parameters.AddWithValue("direccion", usu.Direccion);
                cmd.Parameters.AddWithValue("telefono", usu.Telefono);
                cmd.Parameters.AddWithValue("celular", usu.Celular);
                cmd.Parameters.AddWithValue("email", usu.Email);
                cmd.Parameters.AddWithValue("usuario", usu.Usuario);
                cmd.Parameters.AddWithValue("contraseña", usu.Contraseña);
                cmd.Parameters.AddWithValue("contraemail", usu.ContraEmail);
                cmd.Parameters.AddWithValue("hostmail", usu.Host);
                cmd.Parameters.AddWithValue("host", usu.Host);
                cmd.Parameters.AddWithValue("nivel", usu.Nivel);
                cmd.Parameters.AddWithValue("estado", usu.Estado);                
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

        public Boolean Delete(Int32 CodUsuario)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarUsuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codusu", CodUsuario);               
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

        public Boolean Login(clsUsuario Usu)
        {
            try
            {
                con.conectarBD();

            cmd = new MySqlCommand("Login", con.conector);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 10;
            cmd.Parameters.AddWithValue("usua", Usu.Usuario);
            cmd.Parameters.AddWithValue("contra", Usu.Contraseña);
            cmd.Parameters.AddWithValue("empre", Usu.CodEmpresaLogin );
            cmd.Parameters.AddWithValue("niv", Usu.Nivel);
            //cmd.Parameters.AddWithValue("sucur", Usu.CodSucursalLogin);

            dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                Usu.CodUsuario = Convert.ToInt32(dr[0].ToString().Trim());
                Usu.Nombre = dr[1].ToString().Trim();
                Usu.Apellido = dr[2].ToString().Trim();
                Usu.Nivel = Convert.ToInt32(dr[3].ToString().Trim());
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
        
        public clsUsuario CargaUsuario(Int32 Codigo)
        {
            clsUsuario usu = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUsuario", con.conector);
                cmd.Parameters.AddWithValue("codusu", Codigo);               
                cmd.CommandType = CommandType.StoredProcedure;               
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        usu = new clsUsuario();
                        usu.CodUsuario = Convert.ToInt32(dr.GetDecimal(0));
                        usu.Dni = dr.GetString(1);
                        usu.Nombre = dr.GetString(2);
                        usu.Apellido = dr.GetString(3);
                        usu.FechaNac = dr.GetDateTime(4);// capturo la fecha
                        usu.Direccion = dr.GetString(5);
                        usu.Telefono = dr.GetString(6);
                        usu.Celular = dr.GetString(7);
                        usu.Email = dr.GetString(8);
                        usu.Usuario = dr.GetString(9);
                        usu.Contraseña = dr.GetString(10);
                        usu.Nivel = Convert.ToInt32(dr.GetString(11));
                        usu.Estado = dr.GetBoolean(12);
                        usu.CodUser = Convert.ToInt32(dr.GetString(13));
                        usu.FechaRegistro = dr.GetDateTime(14);// capturo la fecha 
                        usu.ContraEmail = dr.GetString(15);
                        usu.Host = dr.GetString(16);
                    }

                }
                return usu;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsUsuario CargaUsuarioNivel()
        {
            clsUsuario usu = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraUsuarioNivel", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        usu = new clsUsuario();
                        usu.Email = dr.GetString(0);
                    }

                }
                return usu;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaUsuarios()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUsuarios", con.conector);
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
        public DataTable BuscaUsuarios(Int32 Criterio, String Filtro) 
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("FiltraUsuarios", con.conector);
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

        public DataTable ListaCorreosUsuarios()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaCorreosUsuarios", con.conector);
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

        public DataTable correoTesoreria()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("correoTesoreria", con.conector);
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
        public DataTable ListaNiveles()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaNiveles", con.conector);
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

        public DataTable ListaUsuarios_Empresa(Int32 Codigo)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaUsuarios_Empresa", con.conector);
                cmd.Parameters.AddWithValue("codEmpresa", Codigo);
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
