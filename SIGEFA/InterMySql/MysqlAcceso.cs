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
    class MysqlAcceso : IAcceso
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IAcceso

        public Boolean Insert(clsAccesos acce)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaAcceso", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codusua", acce.CodUsuario );
                oParam = cmd.Parameters.AddWithValue("codalm", acce.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("codfor", acce.CodFormulario);                
                oParam = cmd.Parameters.AddWithValue("codusu", acce.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                acce.CodNuevoAcceso = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodAlmacen)
        {
            
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("LimpiaAccesos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codusua", CodUsuario);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
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

        public List<Int32> MuestraAccesos(Int32 CodUsuario, Int32 CodAlmacen)
        {
            List<Int32> lista = new List<Int32>();
            
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaAccesos", con.conector);
                cmd.Parameters.AddWithValue("codusua", CodUsuario);
                cmd.Parameters.AddWithValue("codalma", CodAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lista.Add(Convert.ToInt32(dr["codFormulario"]));
                    }
                }
                return lista;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean InsertAccesoEmp(Int32 CodUsuario, Int32 CodEmpresa, Int32 codUser)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaAccesoEmpresa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codusu", CodUsuario);
                oParam = cmd.Parameters.AddWithValue("codemp", CodEmpresa);
                oParam = cmd.Parameters.AddWithValue("coduser", codUser);
                //oParam.Direction = ParameterDirection.Output;
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


        #endregion
    }
}
