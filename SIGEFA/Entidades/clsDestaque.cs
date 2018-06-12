using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDestaque
    {
        #region propiedades

        private Int32 iCodDestaque;
        private Int32 iCodDestaqueNuevo;
        private Int32 iCodVendedor;
        private Int32 iCodZona;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodDestaqueNuevo
        {
            get { return iCodDestaqueNuevo; }
            set { iCodDestaqueNuevo = value; }
        }
        public Int32 CodDestaque
        {
            get { return iCodDestaque; }
            set { iCodDestaque = value; }
        }
        public Int32 CodZona
        {
            get { return iCodZona; }
            set { iCodZona = value; }
        }
        public Int32 CodVendedor
        {
            get { return iCodVendedor; }
            set { iCodVendedor = value; }
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
