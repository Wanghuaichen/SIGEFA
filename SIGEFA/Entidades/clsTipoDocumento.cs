using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsTipoDocumento
    {
        #region propiedades

        private Int32 iCodTipoDocumento;
        private Int32 iCodTipoDocumentoNuevo;
        private String sSigla;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        public String Tipodoccodsunat { get; set; }

        public Int32 CodTipoDocumentoNuevo
        {
            get { return iCodTipoDocumentoNuevo; }
            set { iCodTipoDocumentoNuevo = value; }
        }
        public Int32 CodTipoDocumento
        {
            get { return iCodTipoDocumento; }
            set { iCodTipoDocumento = value; }
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
