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
    class MysqlMetodoPago: IMetodoPago
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IMetodoPago

        public Boolean Insert(clsMetodoPago pago)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaMetodoPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;                
                oParam = cmd.Parameters.AddWithValue("descripcion", pago.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", pago.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                pago.CodMetodoPago= Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsMetodoPago pago)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaMetodoPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpago", pago.CodMetodoPago);                
                cmd.Parameters.AddWithValue("descripcion", pago.Descripcion);
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

        public Boolean Delete(Int32 CodMetodoPago)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarMetodoPago", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codpago", CodMetodoPago);
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
        public clsMetodoPago CargaMetodoPago(Int32 Codigo)
        {
            clsMetodoPago pago = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraMetodoPago", con.conector);
                cmd.Parameters.AddWithValue("codpago", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pago = new clsMetodoPago();
                        pago.CodMetodoPago = Convert.ToInt32(dr.GetDecimal(0));                        
                        pago.Descripcion = dr.GetString(1);
                        pago.Estado = dr.GetBoolean(2);
                        pago.CodUser = Convert.ToInt32(dr.GetDecimal(3));
                        pago.FechaRegistro = dr.GetDateTime(4);// capturo la fecha 
                    }
                }
                return pago;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsMetodoPago BuscaMetodoPago(String Codigo)
        {
            clsMetodoPago pago = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaMetodoPago", con.conector);
                cmd.Parameters.AddWithValue("cod", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pago = new clsMetodoPago();
                        pago.CodMetodoPago = Convert.ToInt32(dr.GetDecimal(0));                        
                        pago.Descripcion = dr.GetString(1);
                    }
                }
                return pago;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaMetodoPagos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaMetodoPagos", con.conector);
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

        public DataTable CargaMetodoPagos()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaMetodoPagos", con.conector);
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
