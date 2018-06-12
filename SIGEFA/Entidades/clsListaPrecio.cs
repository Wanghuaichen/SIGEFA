using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsListaPrecio
    {
        #region propiedades

        private Int32 iCodListaPrecio;
        private Int32 icodSucursal;
        private String sNombre;
        private Boolean bMargenProv;
        private Double dMargen;
        private Double dDescuento1;
        private Double dDescuento2;
        private Double dDescuento3;
        private Boolean bPrecioProm;
        private Int32 iListaOrigen;
        private Double dVariacion;
        private Boolean bUpdate;
        private Int32 iDecimales;
        private Boolean bRedondear;
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Int32 icodFormaPago;


        public Int32 CodFormaPago
        {
            get { return icodFormaPago; }
            set { icodFormaPago = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public Int32 CodSucursal
        {
            get { return icodSucursal; }
            set { icodSucursal = value; }
        }

        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public Boolean MargenProv
        {
            get { return bMargenProv; }
            set { bMargenProv = value; }
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
        public Boolean PrecioProm
        {
            get { return bPrecioProm; }
            set { bPrecioProm = value; }
        }
        public Int32 ListaOrigen
        {
            get { return iListaOrigen; }
            set { iListaOrigen = value; }
        }
        public Double Variacion
        {
            get { return dVariacion; }
            set { dVariacion = value; }
        }
        public Boolean Update
        {
            get { return bUpdate; }
            set { bUpdate = value; }
        }
        public Int32 Decimales
        {
            get { return iDecimales; }
            set { iDecimales = value; }
        }
        public Boolean Redondear
        {
            get { return bRedondear; }
            set { bRedondear = value; }
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
