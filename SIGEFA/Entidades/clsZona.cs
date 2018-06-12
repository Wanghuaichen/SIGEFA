using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsZona
    {
        #region propiedades

        private Int32 iCodZona;
        private Int32 iCodZonaNuevo;
        private String sDescripcion;
        private Boolean iEstado;        
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodZonaNuevo
        {
            get { return iCodZonaNuevo; }
            set { iCodZonaNuevo = value; }
        }
        public Int32 CodZona
        {
            get { return iCodZona; }
            set { iCodZona = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
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

        #endregion propiedades
    }
}
