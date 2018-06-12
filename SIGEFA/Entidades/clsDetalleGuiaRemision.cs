using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleGuiaRemision
    {
        #region propiedades


        private Int32 iCodDetalleGuiaRemision;
        private Int32 iCodProducto;
        private String sReferencia;
        private String sDescripcion;
        private Int32 iCodGuiaRemision;
        private Int32 iCodAlmacen;
        private Int32 iUnidadIngresada;
        private String sSerieLote;
        private Double dCantidad;
        private Double dCantidadPendiente;
        private Int32 iCodUnidad;
        private String sUnidad;
        private Double dPeso;
        private Boolean bPendiente;
        private Boolean bEstado;
        private DateTime dFechaRegistro;
        private Int32 iCodUser;
        private Int32 iCodVenta;


        public Int32 CodDetalleGuiaRemision
        {
            get { return iCodDetalleGuiaRemision; }
            set { iCodDetalleGuiaRemision = value; }
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
        public Int32 CodGuiaRemision
        {
            get { return iCodGuiaRemision; }
            set { iCodGuiaRemision = value; }
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
        public Double Peso
        {
            get { return dPeso; }
            set { dPeso = value; }
        }
        public Boolean Pendiente
        {
            get { return bPendiente; }
            set { bPendiente = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
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

        public int CodVenta
        {
            get { return iCodVenta; }
            set { iCodVenta = value; }
        }

        #endregion propiedades
    }
}
