using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsMarca
    {
        #region propiedades

        private Int32 iCodMarca;
        private Int32 iCodMarcaNuevo;
        private String sDescripcion;
        private Boolean iEstado;        
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodMarcaNuevo
        {
            get { return iCodMarcaNuevo; }
            set { iCodMarcaNuevo = value; }
        }
        public Int32 CodMarca
        {
            get { return iCodMarca; }
            set { iCodMarca = value; }
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
