using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleFactura
    {
        #region propiedades

        private Int32 iCodDetalleFactura;
        private Int32 iCodProducto;
        private Int32 iCodFactura;
        private String iCodNotaIngreso;
        private Int32 iCodAlmacen;
        private Int32 iUnidadIngresada;
        private Int32 iMoneda;
        private String sSerieLote;
        private Double dCantidad;
        private Int32 iCodUnidad;
        private Double dPrecioUnitario;
        private Double dSubtotal;
        private Double dDescuento1;
        private Double dDescuento2;
        private Double dDescuento3;
        private Double dMontoDescuento;
        private Double dIgv;
        private Double dFlete;
        private Double dImporte;
        private Double dPrecioReal;
        private Double dValoReal;
        private Boolean bEstado;
        private DateTime dFechaIngreso;
        private DateTime dFechaRegistro;
        private Int32 iCodUser;
        private Int32 coddetalleOrden;


        public Int32 CoddetalleOrden
        {
            get { return coddetalleOrden; }
            set { coddetalleOrden = value; }
        }

        public Int32 CodDetalleFactura
        {
            get { return iCodDetalleFactura; }
            set { iCodDetalleFactura = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
       
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 Moneda
        {
            get { return iMoneda; }
            set { iMoneda = value; }
        }
        public Int32 UnidadIngresada
        {
            get { return iUnidadIngresada; }
            set { iUnidadIngresada = value; }
        }
        public String SerieLote
        {
            get { return sSerieLote; }
            set { sSerieLote = value; }
        }
        public Double Cantidad
        {
            get { return dCantidad; }
            set { dCantidad = value; }
        }
        public Int32 CodUnidad
        {
            get { return iCodUnidad; }
            set { iCodUnidad = value; }
        }
        public Double PrecioUnitario
        {
            get { return dPrecioUnitario; }
            set { dPrecioUnitario = value; }
        }
        public Double Subtotal
        {
            get { return dSubtotal; }
            set { dSubtotal = value; }
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
        public Double MontoDescuento
        {
            get { return dMontoDescuento; }
            set { dMontoDescuento = value; }
        }
        public Double Igv
        {
            get { return dIgv; }
            set { dIgv = value; }
        }
        public Double Flete
        {
            get { return dFlete; }
            set { dFlete = value; }
        }
        public Double Importe
        {
            get { return dImporte; }
            set { dImporte = value; }
        }
        public Double PrecioReal
        {
            get { return dPrecioReal; }
            set { dPrecioReal = value; }
        }
        public Double ValoReal
        {
            get { return dValoReal; }
            set { dValoReal = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        public DateTime FechaIngreso
        {
            get { return dFechaIngreso; }
            set { dFechaIngreso = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public Int32 CodProveedor
        { get; set; }

        public String CodNotaIngreso
        {
            get { return iCodNotaIngreso; }
            set { iCodNotaIngreso = value; }
        }

        public int CodFactura
        {
            get { return iCodFactura; }
            set { iCodFactura = value; }
        }

        #endregion propiedades

        #region IEquatable<clsDetalleFactura> Members

        public bool Equals(clsDetalleFactura other)
        {
            if (this.CodDetalleFactura == other.CodDetalleFactura && this.CodAlmacen == other.CodAlmacen)
                return true;
            return false;
        }

        public bool CodProEquals(Int32 codigo)
        {
            if (this.CodProducto == codigo)
                return true;
            return false;
        }

        #endregion
    }
}
