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
    class MysqlAccesoSucursales : IAccesoSucursales
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IAcceso

        public Boolean Insert(clsAccesosSucursales acce)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaAccesoSucursal", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codusua", acce.CodUsuario );
                oParam = cmd.Parameters.AddWithValue("codemp", acce.CodEmpresa);
                oParam = cmd.Parameters.AddWithValue("codsuc", acce.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("codusu", acce.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                acce.CodAccesoSucursalNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodEmpresa)
        {
            
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("LimpiaAccesosSucursales", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codusua", CodUsuario);
                cmd.Parameters.AddWithValue("codEmpre", CodEmpresa);
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

        public List<Int32> MuestraAccesosSucursales(Int32 CodUsuario, Int32 CodEmpresa)
        {
            List<Int32> lista = new List<Int32>();
            
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("CargaAccesosSucursales", con.conector);
                cmd.Parameters.AddWithValue("codusua", CodUsuario);
                cmd.Parameters.AddWithValue("codEmpre", CodEmpresa);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lista.Add(Convert.ToInt32(dr["codSucursal"]));
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

        public Boolean InsertAccesoEmp(Int32 CodUsuario, Int32 CodEmpresa)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaAccesoEmpresa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codusu", CodUsuario);
                oParam = cmd.Parameters.AddWithValue("codemp", CodEmpresa);               
                oParam.Direction = ParameterDirection.Output;
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
