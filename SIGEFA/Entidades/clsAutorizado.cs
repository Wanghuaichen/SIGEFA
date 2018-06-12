using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsAutorizado
    {
        #region propiedades

        private Int32 iCodAutorizado;
        private Int32 iCodAutorizadoNuevo;
        private String sNombre;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodAutorizadoNuevo
        {
            get { return iCodAutorizadoNuevo; }
            set { iCodAutorizadoNuevo = value; }
        }
        public Int32 CodAutorizado
        {
            get { return iCodAutorizado; }
            set { iCodAutorizado = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }

        #endregion propiedades

    }
}
