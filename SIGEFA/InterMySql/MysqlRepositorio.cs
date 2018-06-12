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
    class MysqlRepositorio:IRepositorio
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction mysqltransaccion;
        private List<clsRepositorio> lista = null;
        private clsRepositorio clsrepo = null;
        private string consulta = "";

        public bool registra_repositorio(Entidades.clsRepositorio repo)
        {
            try
            {
                con.conectarBD();

                mysqltransaccion = con.conector.BeginTransaction();
                consulta = "registrar_repositorio";
                cmd = new MySqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("_tipdoc", repo.Tipodoc);
                oParam = cmd.Parameters.AddWithValue("_fechaemision", repo.Fechaemision.ToString("yyyy/MM/dd"));
                oParam = cmd.Parameters.AddWithValue("_serie", repo.Serie);
                oParam = cmd.Parameters.AddWithValue("_correlativo", repo.Correlativo);
                oParam = cmd.Parameters.AddWithValue("_monto", repo.Monto);
                oParam = cmd.Parameters.AddWithValue("_estadosunat", repo.Estadosunat);
                oParam = cmd.Parameters.AddWithValue("_mensajesunat", repo.Mensajesunat);
                oParam = cmd.Parameters.AddWithValue("_docpdf", repo.Pdf);
                oParam = cmd.Parameters.AddWithValue("_docxml", repo.Xml);
                oParam = cmd.Parameters.AddWithValue("_nombredoc", repo.Nombredoc);
                oParam = cmd.Parameters.AddWithValue("_usuario", repo.Usuario);
                oParam = cmd.Parameters.AddWithValue("_codEmpresa", repo.CodEmpresa);
                oParam = cmd.Parameters.AddWithValue("_codSucursal", repo.CodSucursal);
                oParam = cmd.Parameters.AddWithValue("_codAlmacen", repo.CodAlmacen);
                oParam = cmd.Parameters.AddWithValue("_codFacturaVenta", repo.CodFacturaVenta);
                oParam = cmd.Parameters.AddWithValue("_resultado", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                x = Convert.ToInt32(cmd.Parameters["_resultado"].Value);
                mysqltransaccion.Commit();

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
                if (mysqltransaccion != null)
                {
                    mysqltransaccion.Rollback();
                }
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public List<Entidades.clsRepositorio> buscar_repositorio(Entidades.clsRepositorio repo)
        {
            try
            {
                con.conectarBD();
                consulta = "buscar_repositorio";
                cmd = new MySqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("_tipdoc", repo.Tipodoc);
                oParam = cmd.Parameters.AddWithValue("_serie", repo.Serie);
                oParam = cmd.Parameters.AddWithValue("_correlativo", repo.Correlativo);
                oParam = cmd.Parameters.AddWithValue("_fechaemision", repo.Fechaemision.ToString("yyyy/MM/dd"));
                oParam = cmd.Parameters.AddWithValue("_monto", repo.Monto);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    lista = new List<clsRepositorio>();

                    while (dr.Read())
                    {
                        clsrepo = new clsRepositorio();
                        clsrepo.Repoid = (int)dr["repositorioid"];
                        clsrepo.Tipodoc = (int)dr["tipdoc"];
                        clsrepo.Fechaemision = DateTime.Parse(dr["fechaemision"].ToString()).Date;
                        clsrepo.Serie = (string)dr["serie"];
                        clsrepo.Correlativo = (string)dr["correlativo"];
                        clsrepo.Monto = (decimal)dr["monto"];
                        clsrepo.Estadosunat = (string)dr["estadosunat"];
                        clsrepo.Mensajesunat = (string)dr["mensajesunat"];
                        clsrepo.Pdf = (byte[])dr["docpdf"];
                        clsrepo.Xml = (byte[])dr["docxml"];
                        clsrepo.Nombredoc = (string)dr["nombredoc"];
                        clsrepo.Usuario = (int)dr["usuario"];
                        clsrepo.Fechaemision = DateTime.Parse(dr["fecharegistro"].ToString());
                        lista.Add(clsrepo);
                    }

                }

                return lista;
                

            }
            catch (MySqlException ex)
            {
                return lista;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public List<clsRepositorio> listar_repositorio(String estado, Int32 codsucu, Int32 codalma)
        {
            try
            {
                lista = null;
                con.conectarBD();
                consulta = "listar_repositorio";
                cmd = new MySqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("_estadosunat", estado);
                oParam = cmd.Parameters.AddWithValue("_codSucursal", codsucu);
                oParam = cmd.Parameters.AddWithValue("_codAlmacen", codalma); 
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    lista = new List<clsRepositorio>();

                    while (dr.Read())
                    {
                        clsrepo = new clsRepositorio();
                        clsrepo.Repoid = (int)dr["repositorioid"];
                        clsrepo.Tipodoc = (int)dr["tipdoc"];
                        clsrepo.Fechaemision = DateTime.Parse(dr["fechaemision"].ToString());
                        clsrepo.Serie = (string)dr["serie"];
                        clsrepo.Correlativo = (string)dr["correlativo"];
                        clsrepo.Monto = (decimal)dr["monto"];
                        clsrepo.Estadosunat = (string)dr["estadosunat"];
                        clsrepo.Mensajesunat = (string)dr["mensajesunat"];
                        clsrepo.Pdf = (byte[])dr["docpdf"];
                        clsrepo.Xml = (byte[])dr["docxml"];
                        clsrepo.Nombredoc = (string)dr["nombredoc"];
                        clsrepo.Usuario = (int)dr["usuario"];
                        clsrepo.Fechaemision = DateTime.Parse(dr["fecharegistro"].ToString());
                        lista.Add(clsrepo);
                    }

                }
                return lista;
            }
            catch (MySqlException ex)
            {
                return lista;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }


        public bool actualiza_repositorio(clsRepositorio repo)
        {
            try
            {
                con.conectarBD();

                mysqltransaccion = con.conector.BeginTransaction();
                consulta = "actualiza_estadosunat_repositorio";
                cmd = new MySqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("_repositorioid", repo.Repoid);
                oParam = cmd.Parameters.AddWithValue("_estadosunat", repo.Estadosunat);
                oParam = cmd.Parameters.AddWithValue("_mensajesunat", repo.Mensajesunat);
                oParam = cmd.Parameters.AddWithValue("_cdrzip", repo.CDR);
                oParam = cmd.Parameters.AddWithValue("_resultado", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();
                x = Convert.ToInt32(cmd.Parameters["_resultado"].Value);
                mysqltransaccion.Commit();

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
                if (mysqltransaccion != null)
                {
                    mysqltransaccion.Rollback();
                }
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Boolean ActualizaCorrelativoDocResp(Int32 codtipodoc, Int32 codalma)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaCorrelativoDocResp", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codDocumento_ex", codtipodoc);
                oParam = cmd.Parameters.AddWithValue("codAlmacen_ex", codalma); 
                int x = cmd.ExecuteNonQuery();
                if (x != 0) { return true; }
                else { return false; }
            }
            catch (MySqlException ex)
            {
                if (mysqltransaccion != null)
                {
                    mysqltransaccion.Rollback();
                }
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
