using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleOrdenCompra
    {
        #region Propiedades
        public Int32 CodDetalleOrdenCompra
        {
            get;
            set;
        }
        public Int32 CodProducto
        {
            get;
            set;
        }
        public Int32 CodOrdenCompra
        {
            get;
            set;
        }
        public Int32 CodAlmacen
        {
            get;
            set;
        }
        public Int32 Moneda
        {
            get;
            set;
        }
        public Int32 UnidadIngresada
        {
            get;
            set;
        }
        public String SerieLote
        {
            get;
            set;
        }
        public Double Cantidad
        {
            get;
            set;
        }
        public Int32 CodUnidad
        {
            get;
            set;
        }
        public Double PrecioUnitario
        {
            get;
            set;
        }
        public Double Subtotal
        {
            get;
            set;
        }
        public Double Descuento1
        {
            get;
            set;
        }
        public Double Descuento2
        {
            get;
            set;
        }
        public Double Descuento3
        {
            get;
            set;
        }
        public Double MontoDescuento
        {
            get;
            set;
        }
        public Double Igv
        {
            get;
            set;
        }
        public Double Flete
        {
            get;
            set;
        }
        public Double Importe
        {
            get;
            set;
        }
        public Double PrecioReal
        {
            get;
            set;
        }
        public Double ValoReal
        {
            get;
            set;
        }
        public Boolean Estado
        {
            get;
            set;
        }
        public DateTime FechaIngreso
        {
            get;
            set;
        }
        public DateTime FechaRegistro
        {
            get;
            set;
        }
        public Int32 CodUser
        {
            get;
            set;
        }
        public Int32 CodProveedor
        { get; set; }

        #endregion Propiedades


        #region IEquatable<clsDetalleOrdenCompra> Members

        public bool Equals(clsDetalleOrdenCompra other)
        {
            if (this.CodDetalleOrdenCompra == other.CodDetalleOrdenCompra && this.CodAlmacen == other.CodAlmacen)
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
