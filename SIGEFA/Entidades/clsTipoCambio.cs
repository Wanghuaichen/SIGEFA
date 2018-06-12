using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsTipoCambio
    {
        #region propiedades

        private Int32 iCodTipoCambio;
        private Int32 iCodMoneda;
        private String sMoneda;
        private Double dCompra;
        private Double dVenta;
        private DateTime dtFecha;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
       
               
        public Int32 CodTipoCambio
        {
            get { return iCodTipoCambio; }
            set { iCodTipoCambio = value; }
        }
        public Int32 ICodMoneda
        {
            get { return iCodMoneda; }
            set { iCodMoneda = value; }
        }
        public String SMoneda
        {
            get { return sMoneda; }
            set { sMoneda = value; }
        }
        public Double Compra
        {
            get { return dCompra; }
            set { dCompra = value; }
        }
        public Double Venta
        {
            get { return dVenta; }
            set { dVenta = value; }
        }
        public DateTime Fecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
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
