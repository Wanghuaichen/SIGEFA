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
    class MysqlFamilia:IFamilias
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IFamilias

        public Boolean Insert(clsFamilia fam)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaFamilia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("referencia", fam.Referencia);
                oParam = cmd.Parameters.AddWithValue("descripcion", fam.Descripcion);
                oParam = cmd.Parameters.AddWithValue("codusu", fam.CodUser);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                fam.CodFamiliaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Update(clsFamilia fam)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaFamilia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codfam", fam.CodFamilia);
                cmd.Parameters.AddWithValue("referencia", fam.Referencia);
                cmd.Parameters.AddWithValue("descripcion", fam.Descripcion);
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

        public Boolean Delete(Int32 CodFamilia)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarFamilia", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codfam", CodFamilia);
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

        public clsFamilia CargaFamilia(Int32 Codigo)
        {
            clsFamilia fam = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("MuestraFamilia", con.conector);
                cmd.Parameters.AddWithValue("codfam", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fam = new clsFamilia();
                        fam.CodFamilia = Convert.ToInt32(dr.GetDecimal(0));
                        fam.Referencia = dr.GetString(1);
                        fam.Descripcion = dr.GetString(2);
                        fam.Estado = dr.GetBoolean(3); 
                        fam.CodUser = Convert.ToInt32(dr.GetDecimal(4));
                        fam.FechaRegistro = dr.GetDateTime(5);// capturo la fecha 
                    }

                }
                return fam;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable ListaFamilias()
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaFamilias", con.conector);
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
