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
    class MysqlModeloTransporte:IModeloTransporte
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IModeloTransporte

        public Boolean Insert(clsModeloTransporte mod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaModeloTransporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codmar", mod.CodMarcaTransporte);                
                oParam = cmd.Parameters.AddWithValue("descripcion", mod.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", mod.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                mod.CodModeloTransporteNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsModeloTransporte mod)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaModeloTransporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmod", mod.CodModeloTransporte);                
                cmd.Parameters.AddWithValue("descripcion", mod.Descripcion);
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

        public Boolean Delete(Int32 CodModeloTransporte)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarModeloTransporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codmod", CodModeloTransporte);
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

        public clsModeloTransporte CargaModeloTransporte(Int32 Codigo)
        {
            clsModeloTransporte mod = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraModeloTransporte", con.conector);
                cmd.Parameters.AddWithValue("codmod", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mod = new clsModeloTransporte();
                        mod.CodModeloTransporte = Convert.ToInt32(dr.GetDecimal(0));
                        mod.CodMarcaTransporte = Convert.ToInt32(dr.GetDecimal(1));
                        mod.Descripcion = dr.GetString(2);
                        mod.Estado = dr.GetBoolean(3);
                        mod.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        mod.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return mod;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable ListaModeloTransportes(Int32 CodMar)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaModeloTransportes", con.conector);
                cmd.Parameters.AddWithValue("codmar", CodMar);
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
