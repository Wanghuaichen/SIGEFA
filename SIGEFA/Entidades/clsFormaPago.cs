using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsFormaPago
    {
        #region propiedades

        private Int32 iCodFormaPago;        
        private String sDescripcion;
        private Int32 iDias;
        private Boolean bTipo;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Boolean btipoaccion;//compra/venta
               
        public Int32 CodFormaPago
        {
            get { return iCodFormaPago; }
            set { iCodFormaPago = value; }
        }
        public Int32 Dias
        {
            get { return iDias; }
            set { iDias = value; }
        }
        public Boolean Tipo
        {
            get { return bTipo; }
            set { bTipo = value; }
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

        public Boolean Tipoaccion
        {
            get { return btipoaccion; }
            set { btipoaccion = value; }
        }

        #endregion propiedades
    }
}
