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
    class MysqlVariante : IVariante
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IVariante

        public Boolean Insert(clsVariante var)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaVariante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codcar", var.CodCaracteristica);
                oParam = cmd.Parameters.AddWithValue("descripcion", var.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", var.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                var.CodVarianteNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsVariante var)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaVariante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codvar", var.CodVariante);
                cmd.Parameters.AddWithValue("descripcion", var.Descripcion);
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

        public Boolean Delete(Int32 CodVariante)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarVariante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codvar", CodVariante);
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

        public clsVariante CargaVariante(Int32 Codigo)
        {
            clsVariante var = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraVariante", con.conector);
                cmd.Parameters.AddWithValue("codvar", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var = new clsVariante();
                        var.CodVariante = Convert.ToInt32(dr.GetDecimal(0));
                        var.CodCaracteristica = Convert.ToInt32(dr.GetDecimal(1));
                        var.Descripcion = dr.GetString(2);
                        var.Estado = dr.GetBoolean(3); 
                        var.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        var.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return var;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaVariantes(Int32 CodCar)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaVariantes", con.conector);
                cmd.Parameters.AddWithValue("codcar", CodCar);
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
