using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsDetalleTransferencia
    {

        #region propiedades


        private Int32 iCodDetalleTransfer;
        private Int32 iCodProducto;
        private Int32 codProv;
        private String sReferencia;
        private String sDescripcion;
        private Int32 iCodTransDir;
        private Int32 iCodAlmacenOrigen;
        private Int32 iCodAlmacenDestino;
        private Int32 iUnidadIngresada;
        private String sSerieLote;
        private Double dCantidad;
        private Double dCantidadPendiente;
        private Int32 iCodUnidad;
        private String sUnidad;
        private Double dPrecioUnitario;
        private Double dSubtotal;
        private Double dDescuento1;
        private Double dDescuento2;
        private Double dDescuento3;
        private Double dMontoDescuento;
        private Double dIgv;
        private Double dImporte;
        private Double dPrecioVenta;
        private Double dValorVenta;
        private Double dPrecioReal;
        private Double dValoReal;
        private DateTime dFechaRegistro;
        private Boolean precioigv;
        private Decimal valorpromedio;

        public Decimal Valorpromedio
        {
            get { return valorpromedio; }
            set { valorpromedio = value; }
        }

        public Boolean Precioigv
        {
            get { return precioigv; }
            set { precioigv = value; }
        }
        private Int32 iCodUser;


        public Int32 CodDetalleTransfer
        {
            get { return iCodDetalleTransfer; }
            set { iCodDetalleTransfer = value; }
        }
        public Int32 CodProv
        {
            get { return codProv; }
            set { codProv = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
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
        public Int32 CodTransDir
        {
            get { return iCodTransDir; }
            set { iCodTransDir = value; }
        }
        public Int32 CodAlmacenOrigen
        {
            get { return iCodAlmacenOrigen; }
            set { iCodAlmacenOrigen = value; }
        }

        public Int32 CodAlmacenDestino
        {
            get { return iCodAlmacenDestino; }
            set { iCodAlmacenDestino = value; }
        }
        public Int32 UnidadIngresada
        {
            get { return iUnidadIngresada; }
            set { iUnidadIngresada = value; }
        }
        public String Unidad
        {
            get { return sUnidad; }
            set { sUnidad = value; }
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
        public Double CantidadPendiente
        {
            get { return dCantidadPendiente; }
            set { dCantidadPendiente = value; }
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
        public Double Importe
        {
            get { return dImporte; }
            set { dImporte = value; }
        }
        public Double PrecioVenta
        {
            get { return dPrecioVenta; }
            set { dPrecioVenta = value; }
        }
        public Double ValorVenta
        {
            get { return dValorVenta; }
            set { dValorVenta = value; }
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

        #endregion propiedades
    }
}
