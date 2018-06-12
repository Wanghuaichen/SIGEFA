using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsCaracteristicaProducto
    {
        #region propiedades

        private Int32 iCodCaracteristicaProducto;
        private Int32 iCodCaracteristicaProductoNuevo;
        private Int32 iCodProducto;
        private Int32 iCodCaracteristica;
        private String sValor;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodCaracteristicaProducto
        {
            get { return iCodCaracteristicaProducto; }
            set { iCodCaracteristicaProducto = value; }
        }
        public Int32 CodCaracteristicaProductoNuevo
        {
            get { return iCodCaracteristicaProductoNuevo; }
            set { iCodCaracteristicaProductoNuevo = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
        public Int32 CodCaracteristica
        {
            get { return iCodCaracteristica; }
            set { iCodCaracteristica = value; }
        }
        public String Valor
        {
            get { return sValor; }
            set { sValor = value; }
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
