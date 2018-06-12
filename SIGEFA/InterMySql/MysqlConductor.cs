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
    class MysqlConductor: IConductor
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IConductor

        public Boolean Insert(clsConductor cond)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaConductor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("dni", cond.Dni);
                oParam = cmd.Parameters.AddWithValue("ruc", cond.Ruc);
                oParam = cmd.Parameters.AddWithValue("nombre", cond.Nombre);
                oParam = cmd.Parameters.AddWithValue("licencia", cond.Licencia);
                oParam = cmd.Parameters.AddWithValue("telefono", cond.Telefono);
                oParam = cmd.Parameters.AddWithValue("direccion", cond.Direccion);                
                oParam = cmd.Parameters.AddWithValue("codusu", cond.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                cond.CodConductorNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsConductor cond)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaConductor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcon", cond.CodConductor);
                cmd.Parameters.AddWithValue("dni", cond.Dni);
                cmd.Parameters.AddWithValue("ruc", cond.Ruc);
                cmd.Parameters.AddWithValue("nombre", cond.Nombre);
                cmd.Parameters.AddWithValue("licencia", cond.Licencia);
                cmd.Parameters.AddWithValue("telefono", cond.Telefono);
                cmd.Parameters.AddWithValue("direccion", cond.Direccion);                

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

        public Boolean Delete(Int32 CodConductor)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminaConductor", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcon", CodConductor);
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

        public clsConductor CargaConductor(Int32 Codigo)
        {
            clsConductor cond = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraConductor", con.conector);
                cmd.Parameters.AddWithValue("codcon", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cond = new clsConductor();
                        cond.CodConductor = Convert.ToInt32(dr.GetDecimal(0));
                        cond.Dni = dr.GetString(1);
                        cond.Ruc = dr.GetString(2);
                        cond.Nombre = dr.GetString(3);
                        cond.Licencia = dr.GetString(4);
                        cond.Telefono = dr.GetString(5);
                        cond.Direccion = dr.GetString(6);                        
                        cond.Estado = dr.GetBoolean(7); 
                        cond.CodUser = Convert.ToInt32(dr.GetDecimal(8));
                        cond.FechaRegistro = dr.GetDateTime(9);// capturo la fecha 
                    }

                }
                return cond;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaConductores()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaConductores", con.conector);
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

        public DataTable CargaConductores()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaConductores", con.conector);
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
