using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsVariante
    {
        #region propiedades

        private Int32 iCodVariante;
        private Int32 iCodVarianteNuevo;
        private Int32 iCodCaracteristica;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodVarianteNuevo
        {
            get { return iCodVarianteNuevo; }
            set { iCodVarianteNuevo = value; }
        }
        public Int32 CodVariante
        {
            get { return iCodVariante; }
            set { iCodVariante = value; }
        }
        public Int32 CodCaracteristica
        {
            get { return iCodCaracteristica; }
            set { iCodCaracteristica = value; }
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
