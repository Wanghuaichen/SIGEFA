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
    class MysqlCaracteristica:ICaracteristica
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion ICaracteristica

        public Boolean Insert(clsCaracteristica car)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaCaracteristica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("descripcion", car.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", car.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                car.CodCaracteristicaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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
        
        public Boolean Update(clsCaracteristica car)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaCaracteristica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcar", car.CodCaracteristica);
                cmd.Parameters.AddWithValue("descripcion", car.Descripcion);
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

        public Boolean Delete(Int32 CodCaracteristica)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarCaracteristica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcar", CodCaracteristica);
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

        public clsCaracteristica CargaCaracteristica(Int32 Codigo)
        {
            clsCaracteristica car = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraCaracteristica", con.conector);
                cmd.Parameters.AddWithValue("codcar", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        car = new clsCaracteristica();
                        car.CodCaracteristica = Convert.ToInt32(dr.GetDecimal(0));
                        car.Descripcion = dr.GetString(1);
                        car.Estado = dr.GetBoolean(2); 
                        car.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        car.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }

                }
                return car;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaCaracteristicas()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaCaracteristicas", con.conector);
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
