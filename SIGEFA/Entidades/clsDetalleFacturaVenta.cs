using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleFacturaVenta
    {
        #region propiedades


        private Int32 iCodDetalleVenta;
        private Int32 iCodProducto;
        private String sReferencia;
        private String sDescripcion;
        private Int32 iCodVenta;
        private Int32 iCodAlmacen;
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
        private Int32 iCodUser;
        private Int32 iCodNotaSalida;
        private Int32 iMoneda;
        private Int32 iCodDetalleCotizacion;
        private Int32 iCodDetallePedido;
        private Int32 codventaentregar;
        private Boolean entregado;
        private Int32 iCodDetalleSeparacion;

        public Int32 CodDetalleSeparacion
        {
            get { return iCodDetalleSeparacion; }
            set { iCodDetalleSeparacion = value; }
        }

        public Boolean Entregado
        {
            get { return entregado; }
            set { entregado = value; }
        }

        public Int32 Codventaentregar
        {
            get { return codventaentregar; }
            set { codventaentregar = value; }
        }

        public Int32 CodDetallePedido
        {
            get { return iCodDetallePedido; }
            set { iCodDetallePedido = value; }
        }


        public Int32 CodDetalleVenta
        {
            get { return iCodDetalleVenta; }
            set { iCodDetalleVenta = value; }
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
        public Int32 CodVenta
        {
            get { return iCodVenta; }
            set { iCodVenta = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
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

        public double CantidadPendiente
        {
            get { return dCantidadPendiente; }
            set { dCantidadPendiente = value; }
        }

        public Int32 CodNotaSalida
        {
            get { return iCodNotaSalida; }
            set { iCodNotaSalida = value; }
        }

        public Int32 Moneda
        {
            get { return iMoneda; }
            set { iMoneda = value; }
        }

        public Int32 CodDetalleCotizacion
        {
            get { return iCodDetalleCotizacion; }
            set { iCodDetalleCotizacion = value; }
        }

        #endregion propiedades

        public int CodTipoArticulo { get; set; }

        public string Tipoimpuesto { get; set; }

        public int TipoUnidad { get; set; }
    }
}
