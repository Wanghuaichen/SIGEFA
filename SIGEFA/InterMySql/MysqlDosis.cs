using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Interfaces;
using SIGEFA.Conexion;
using SIGEFA.Entidades;

namespace SIGEFA.InterMySql
{
    class MysqlDosis:IDosis
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IDosis

        public Boolean Insert(clsDosis dosi)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDosis", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", dosi.CodProducto);
                oParam = cmd.Parameters.AddWithValue("cult", dosi.Cultivo);
                oParam = cmd.Parameters.AddWithValue("apli", dosi.Aplicacion);
                oParam = cmd.Parameters.AddWithValue("dosi", dosi.Dosis);
                oParam = cmd.Parameters.AddWithValue("lmr", dosi.Lmrppm);
                oParam = cmd.Parameters.AddWithValue("pc", dosi.Pc);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                dosi.CodDosisNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Delete(Int32 CodDosis)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarDosis", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("coddos", CodDosis);
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

        public DataTable ListaDosis(Int32 CodPro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaDosis", con.conector);
                cmd.Parameters.AddWithValue("codpro", CodPro);
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

        #endregion Implementacion IDosis
    }
}
