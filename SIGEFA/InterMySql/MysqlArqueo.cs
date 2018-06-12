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
    class MysqlArqueo:IArqueo
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public DataTable ListaArqueos(Int32 opcion1, Int32 opcion2, Int32 mes1, Int32 anio1, Int32 codAlman)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaArqueos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("opcion1", opcion1);
                cmd.Parameters.AddWithValue("opcion2", opcion2);
                cmd.Parameters.AddWithValue("mes1", mes1);
                cmd.Parameters.AddWithValue("anio1", anio1);
                cmd.Parameters.AddWithValue("codAlman", codAlman);
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

        public DataTable ListaDetalleArqueos(Int32 codArq)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("MuestraDetalleArqueo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codArq", codArq);
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

        public Boolean Insert(clsArqueo arqe)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaArqueo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codUser", arqe.ICodUsuario);
                oParam = cmd.Parameters.AddWithValue("fech", arqe.DFecha);
                //oParam = cmd.Parameters.AddWithValue("observ", arqe.SObservacion);
                oParam = cmd.Parameters.AddWithValue("codAlman", arqe.ICodAlma);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                arqe.ICodArqueoNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean InsertDetalle(clsDetalleArqueo detarqe)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("GuardaDetalleArqueo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codArq", detarqe.ICodArqueo);
                oParam = cmd.Parameters.AddWithValue("codUser", detarqe.ICodUsuario);
                oParam = cmd.Parameters.AddWithValue("observ", detarqe.SObservacion);
                oParam = cmd.Parameters.AddWithValue("codAlma", detarqe.ICodAlma);
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

        public Boolean InsertChekeoDetalle(clsDetalleArqueo detarqe, int codArq)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ChekeaDetalleArqueo", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("fisico", detarqe.DStockF);
                oParam = cmd.Parameters.AddWithValue("dif", detarqe.DDiferencia);
                oParam = cmd.Parameters.AddWithValue("observa", detarqe.SObservacion);
                oParam = cmd.Parameters.AddWithValue("codDeta", detarqe.ICodDetalle);
                oParam = cmd.Parameters.AddWithValue("codArq", codArq);
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

        public Boolean Update(clsArqueo arqe)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaArqueoEstado", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("observa", arqe.SObservacion);
                cmd.Parameters.AddWithValue("codUsAp", arqe.ICodUsuarioApro);
                cmd.Parameters.AddWithValue("codArq", arqe.ICodArqueo);
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

    }
}
