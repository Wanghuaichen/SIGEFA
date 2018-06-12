using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsUnidadMedida
    {
        #region propiedades

        private Int32 iCodUnidad;
        private Int32 iCodUnidadNuevo;        
        private String sSigla;       
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodUnidadNuevo
        {
            get { return iCodUnidadNuevo; }
            set { iCodUnidadNuevo = value; }
        }
        public Int32 CodUnidad
        {
            get { return iCodUnidad; }
            set { iCodUnidad = value; }
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
