using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleSeparacionVenta
    {
        private Int32 iCodDetalleSeparacion;
        private Int32 icodSeparacion;
        private Int32 iCodProducto;
        private Int32 iCodAlmacen;
        private Int32 iUnidadIngresada;       
        private Double dCantidad;
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
        private Int32 iCodVenta;
        private Double dValorPromedio;
        private Double dValorPromedioSoles;

        public Int32 CodDetalleSeparacion
        {
            get { return iCodDetalleSeparacion; }
            set { iCodDetalleSeparacion = value; }
        }

        public Int32 CodSeparacion
        {
            get { return icodSeparacion; }
            set { icodSeparacion = value; }
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
        public Int32 UnidadIngresada
        {
            get { return iUnidadIngresada; }
            set { iUnidadIngresada = value; }
        }
       
        
        public Double Cantidad
        {
            get { return dCantidad; }
            set { dCantidad = value; }
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

       

        public double ValorPromedio
        {
            get { return dValorPromedio; }
            set { dValorPromedio = value; }
        }

        public double ValorPromedioSoles
        {
            get { return dValorPromedioSoles; }
            set { dValorPromedioSoles = value; }
        }

        
    }
}
