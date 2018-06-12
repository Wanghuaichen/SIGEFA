using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsLinea
    {
        #region propiedades

        private Int32 iCodLinea;
        private Int32 iCodLineaNuevo;
        private Int32 iCodFamilia;
        private String sReferencia;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodLineaNuevo
        {
            get { return iCodLineaNuevo; }
            set { iCodLineaNuevo = value; }
        }
        public Int32 CodLinea
        {
            get { return iCodLinea; }
            set { iCodLinea = value; }
        }
        public Int32 CodFamilia
        {
            get { return iCodFamilia; }
            set { iCodFamilia = value; }
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
