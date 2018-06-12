using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsTipoArticulo
    {
        #region propiedades

        private Int32 iCodTipoArticulo;
        private Int32 iCodTipoArticuloNuevo;
        private String sReferencia;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodTipoArticuloNuevo
        {
            get { return iCodTipoArticuloNuevo; }
            set { iCodTipoArticuloNuevo = value; }
        }
        public Int32 CodTipoArticulo
        {
            get { return iCodTipoArticulo; }
            set { iCodTipoArticulo = value; }
        }
        public String Referencia
        {
            get { return sReferencia; }
            set { sReferencia = value; }
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
