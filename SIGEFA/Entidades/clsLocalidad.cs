using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;



namespace SIGEFA.Entidades
{
    class clsLocalidad
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        #region propiedades

        private String sCodLocalidad;
        private String sCodPadre;
        private String sNombre;
        private Int32 iNivel;

        public String CodLocalidad
        {
            get { return sCodLocalidad; }
            set { sCodLocalidad = value; }
        }
        public String CodPadre
        {
            get { return sCodPadre; }
            set { sCodPadre = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public Int32 Nivel
        {
            get { return iNivel; }
            set { iNivel = value; }
        }

        #endregion propiedades


        public DataTable CargaLocalidades(String CodPadre, Int32 Nivel)
        {
            try
            {
                tabla = new DataTable();
                con.conectarBD();
                cmd = new MySqlCommand("CargaLocalidades", con.conector);
                cmd.Parameters.AddWithValue("codpad", CodPadre);
                cmd.Parameters.AddWithValue("niv", Nivel);
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

    }
}
