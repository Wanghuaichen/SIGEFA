using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsTransaccion
    {
        #region propiedades

        private Int32 iCodTransaccion;
        private Int32 iCodTransaccionNuevo;
        private String sSigla;
        private String sDescripcion;
        private Int32 iTipo;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private List<Int32> lConfiguracion;
        private String codsunat;

        public String Codsunat
        {
            get { return codsunat; }
            set { codsunat = value; }
        }
           


        public Int32 CodTransaccionNuevo
        {
            get { return iCodTransaccionNuevo; }
            set { iCodTransaccionNuevo = value; }
        }
        public Int32 CodTransaccion
        {
            get { return iCodTransaccion; }
            set { iCodTransaccion = value; }
        }
        public String Sigla
        {
            get { return sSigla; }
            set { sSigla = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public Int32 Tipo
        {
            get { return iTipo; }
            set { iTipo = value; }
        }
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }
        public List<Int32> Configuracion
        {
            get { return lConfiguracion; }
            set { lConfiguracion = value; }
        }


        #endregion propiedades
    }
}
