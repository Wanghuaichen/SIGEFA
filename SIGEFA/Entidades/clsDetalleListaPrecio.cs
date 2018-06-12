using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleListaPrecio
    {
        #region propiedades

        private Int32 iCodDetalleLista;
        private Int32 iCodListaPrecio;
        private Int32 iCodProducto;
        private Double dValor;
        private Double dMargen;
        private Double dDescuento1;
        private Double dDescuento2;
        private Double dDescuento3;
        private Double dPrecioNeto;
        private Double dPrecio;        
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodDetalleLista
        {
            get { return iCodDetalleLista; }
            set { iCodDetalleLista = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
        public Double Valor
        {
            get { return dValor; }
            set { dValor = value; }
        }
        public Double Margen
        {
            get { return dMargen; }
            set { dMargen = value; }
        }
        public Double Descuento1
        {
            get { return dDescuento1; }
            set { dDescuento1 = value; }
        }
        public Double Descuento2
        {
            get { return dDescuento2; }
            set { dDescuento2 = value; }
        }
        public Double Descuento3
        {
            get { return dDescuento3; }
            set { dDescuento3 = value; }
        }
        public Double PrecioNeto
        {
            get { return dPrecioNeto; }
            set { dPrecioNeto = value; }
        }
        public Double Precio
        {
            get { return dPrecio; }
            set { dPrecio = value; }
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
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }        


        #endregion propiedades
    }
}
