using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;
using SIGEFA.Entidades;
using System.Windows.Forms;

namespace SIGEFA.InterMySql
{
    class MysqlComposicionQuimica:IComposicionQuimica
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region Implementacion IComposicionQuimica

        public Boolean Insert(clsComposicionQuimica comQui)
        {
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("GuardaComposicionQuimica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("codpro", comQui.CodProducto);
                oParam = cmd.Parameters.AddWithValue("descr", comQui.Componente);
                oParam = cmd.Parameters.AddWithValue("conte", comQui.Cantidad);
                oParam = cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                int x = cmd.ExecuteNonQuery();

                comQui.CompQuimicaNuevo = Convert.ToInt32(cmd.Parameters["newid"].Value);

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

        public Boolean Delete(Int32 codCompQuim)
        {
            try
            {
                //MessageBox.Show(codCompQuim+"");
                con.conectarBD();
                cmd = new MySqlCommand("EliminarComposicionQuimica", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codcomqui", codCompQuim);
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


        public DataTable ListaComposicion(Int32 CodPro)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("ListaComposicionQuimica", con.conector);
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

        #endregion Implementacion IComposicionQuimica
    }
}
