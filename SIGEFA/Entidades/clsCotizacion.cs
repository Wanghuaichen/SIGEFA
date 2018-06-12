using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsCotizacion
    {
        #region propiedades

        private String sCodCotizacion;
        private Int32 sCodSucursal;
        private Int32 iCodAlmacen;
        private Int32 iTipoCliente;
        private Int32 iCodCliente;
        private String sRUCCliente;
        private String sDNI;
        private String sCodigoPersonalizado;
        private String sRazonSocialCliente;
        private String sNombre;
        private String sDireccion;
        private Decimal dLineaCredito;
        private Int32 iDocRef;
        private String sSiglaDocRef;
        private Int32 iMoneda;
        private Decimal dTipoCambio;
        private DateTime dtFechaCotizacion;
        private Int32 iCodAutorizado;
        private String sNombreAutorizado;
        private Int32 iFormaPago;
        private Int32 iCodListaPrecio;
        private DateTime dtFechaPago;
        private Int32 iVigencia;
        private DateTime dtFechaVigencia;
        private String sComentario;
        private Decimal dMontoBruto;
        private Decimal dPorcDscto;
        private Decimal dMontoDscto;
        private Decimal dIgv;
        private Decimal dTotal;
        private Int32 iEstado;
        private Int32 iPendiente;
        private Int32 iAnulado;
        private Int32 iVigente;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Decimal dLineaCreditoUso;
        private Decimal dLineaCreditoDisponible;
        private List<clsDetalleCotizacion> lDetalle;

        public String CodCotizacion
        {
            get { return sCodCotizacion; }
            set { sCodCotizacion = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }     
        
        public Int32 TipoCliente
        {
            get { return iTipoCliente; }
            set { iTipoCliente = value; }
        }
        public Int32 CodCliente
        {
            get { return iCodCliente; }
            set { iCodCliente = value; }
        }
        public String RUCCliente
        {
            get { return sRUCCliente; }
            set { sRUCCliente = value; }
        }
        public String DNI
        {
            get { return sDNI; }
            set { sDNI = value; }
        }
        public String CodigoPersonalizado
        {
            get { return sCodigoPersonalizado; }
            set { sCodigoPersonalizado = value; }
        }
        public String RazonSocialCliente
        {
            get { return sRazonSocialCliente; }
            set { sRazonSocialCliente = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public String Direccion
        {
            get { return sDireccion; }
            set { sDireccion = value; }
        }
        public Int32 Moneda
        {
            get { return iMoneda; }
            set { iMoneda = value; }
        }
        public Decimal TipoCambio
        {
            get { return dTipoCambio; }
            set { dTipoCambio = value; }
        }
        public DateTime FechaCotizacion
        {
            get { return dtFechaCotizacion; }
            set { dtFechaCotizacion = value; }
        }
        public Int32 CodAutorizado
        {
            get { return iCodAutorizado; }
            set { iCodAutorizado = value; }
        }
        public String NombreAutorizado
        {
            get { return sNombreAutorizado; }
            set { sNombreAutorizado = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public Int32 FormaPago
        {
            get { return iFormaPago; }
            set { iFormaPago = value; }
        }
        public DateTime FechaPago
        {
            get { return dtFechaPago; }
            set { dtFechaPago = value; }
        }
        public Int32 Vigencia
        {
            get { return iVigencia; }
            set { iVigencia = value; }
        }
        public DateTime FechaVigencia
        {
            get { return dtFechaVigencia; }
            set { dtFechaVigencia = value; }
        }
        public String Comentario
        {
            get { return sComentario; }
            set { sComentario = value; }
        }
        public Decimal MontoBruto
        {
            get { return dMontoBruto; }
            set { dMontoBruto = value; }
        }
        public Decimal PorcDscto
        {
            get { return dPorcDscto; }
            set { dPorcDscto = value; }
        }
        public Decimal MontoDscto
        {
            get { return dMontoDscto; }
            set { dMontoDscto = value; }
        }
        public Decimal Igv
        {
            get { return dIgv; }
            set { dIgv = value; }
        }
        public Decimal Total
        {
            get { return dTotal; }
            set { dTotal = value; }
        }
        public Int32 Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public Int32 Pendiente
        {
            get { return iPendiente; }
            set { iPendiente = value; }
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
        public List<clsDetalleCotizacion> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public Int32 DocRef
        {
            get { return iDocRef; }
            set { iDocRef = value; }
        }

        public int Anulado
        {
            get { return iAnulado; }
            set { iAnulado = value; }
        }

        public int CodSucursal
        {
            get { return sCodSucursal; }
            set { sCodSucursal = value; }
        }

        public string SiglaDocRef
        {
            get { return sSiglaDocRef; }
            set { sSiglaDocRef = value; }
        }

        public int Vigente
        {
            get { return iVigente; }
            set { iVigente = value; }
        }

        public Decimal LineaCredito
        {
            get { return dLineaCredito; }
            set { dLineaCredito = value; }
        }

        public decimal LineaCreditoUso
        {
            get { return dLineaCreditoUso; }
            set { dLineaCreditoUso = value; }
        }

        public decimal LineaCreditoDisponible
        {
            get { return dLineaCreditoDisponible; }
            set { dLineaCreditoDisponible = value; }
        }

        #endregion propiedades
    }
    
}
