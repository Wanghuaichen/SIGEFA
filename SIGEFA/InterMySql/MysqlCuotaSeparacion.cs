using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Interfaces;
using SIGEFA.Conexion;
using MySql.Data.MySqlClient;
using System.Data;
using SIGEFA.Entidades;

namespace SIGEFA.InterMySql
{
    class MysqlCuotaSeparacion : ICuotaSeparacion
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public DataTable CargaCuotas(Int32 codSeparacion)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraAbonos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codsepa", codSeparacion);
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

        public Boolean Insert(clsCuotasSeparacion sepa)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaCuotaSeparacion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                
                oParam = cmd.Parameters.AddWithValue("codUser", sepa.CodUsuario);
                oParam = cmd.Parameters.AddWithValue("fech", sepa.FechaRegistro);
                oParam = cmd.Parameters.AddWithValue("abono", sepa.Monto);
                oParam = cmd.Parameters.AddWithValue("codsepara", sepa.CodSeparacion);
                oParam = cmd.Parameters.AddWithValue("total", sepa.Total);
                oParam = cmd.Parameters.AddWithValue("moneda", sepa.CodMoneda);                
                oParam = cmd.Parameters.AddWithValue("codalm", sepa.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("seriedoc", sepa.Serie);
                oParam = cmd.Parameters.AddWithValue("numdoc", sepa.NumDocumento);
                oParam = cmd.Parameters.AddWithValue("sigdoc", sepa.Desdocumento);
                oParam = cmd.Parameters.AddWithValue("coddoc", sepa.CodTipoDocumento);
                oParam = cmd.Parameters.AddWithValue("codser", sepa.CodSerie);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                sepa.CodSeparacion = Convert.ToInt32(cmd.Parameters["newid"].Value);

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


        public Boolean delete(Int32 CodigoLetra)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("EliminarCuotaS", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcuo", CodigoLetra);                
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

        public clsCuotasSeparacion BuscarCuotasSeparacion(Int32 CodCuotaSepracion, Int32 codAlmacen)
        {
            clsCuotasSeparacion sepa = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarCuotasSeparacion", con.conector);
                cmd.Parameters.AddWithValue("codcuota", CodCuotaSepracion);
                cmd.Parameters.AddWithValue("codalma", codAlmacen);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sepa = new clsCuotasSeparacion();
                        sepa.CodCuota = Convert.ToInt32(dr.GetString(0));                                               
                        sepa.CodSeparacion = Convert.ToInt32(dr.GetString(2));                                               
                        sepa.Monto = dr.GetDecimal(1);    
                    }
                }
                return sepa;

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
