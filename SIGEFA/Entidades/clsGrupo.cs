using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsGrupo
    {
        #region propiedades

        private Int32 iCodGrupo;
        private Int32 iCodGrupoNuevo;
        private Int32 iCodLinea;
        private String sReferencia;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodGrupoNuevo
        {
            get { return iCodGrupoNuevo; }
            set { iCodGrupoNuevo = value; }
        }
        public Int32 CodGrupo
        {
            get { return iCodGrupo; }
            set { iCodGrupo = value; }
        }
        public Int32 CodLinea
        {
            get { return iCodLinea; }
            set { iCodLinea = value; }
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
