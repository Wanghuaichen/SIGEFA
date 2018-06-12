using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsTipoPagoCaja 
    {
        #region propiedades

        private Int32 iCodTipoPagoServicio;
        private Int32 iCodTipoPagoServicioNuevo;
        private String sDescripcion;
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dFechaRegistro;


        public Int32 CodTipoPagoServicio
        {
            get { return iCodTipoPagoServicio; }
            set { iCodTipoPagoServicio = value; }
        }
        public Int32 CodTipoPagoServicioNuevo
        {
            get { return iCodTipoPagoServicioNuevo; }
            set { iCodTipoPagoServicioNuevo = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }

        #endregion

    }
}
