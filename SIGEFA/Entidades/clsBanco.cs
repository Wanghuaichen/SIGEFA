using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsBanco
    {
        #region propiedades

        private Int32 iCodBanco;
        private Int32 iCodBancoNuevo;
        private String sDescripcion;
        private Boolean iEstado;        
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sSiglaBanco;


        public Int32 CodBancoNuevo
        {
            get { return iCodBancoNuevo; }
            set { iCodBancoNuevo = value; }
        }
        public Int32 CodBanco
        {
            get { return iCodBanco; }
            set { iCodBanco = value; }
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

        public string SiglaBanco
        {
            get { return sSiglaBanco; }
            set { sSiglaBanco = value; }
        }

        #endregion propiedades
    }
}
