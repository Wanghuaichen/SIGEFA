using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsPedido
    {
        #region propiedades

        private String sCodPedido;
        private Int32 iCodAlmacen;        
        private Int32 iCodTipoDocumento;
        private String sSiglaDocumento;
        private String sDescripcionDocumento;
        private Int32 iCodCotizacion;
        private Int32 iTipoCliente;
        private Int32 iCodCliente;
        private String sRUCCliente;
        private String sDNI;
        private String sCodigoPersonalizado;
        private String sRazonSocialCliente;
        private String sNombre;
        private String sDireccion;
        private Int32 iMoneda;
        private Double dTipoCambio;
        private DateTime dtFechaPedido;
        private DateTime dtFechaEntrega;
        private Int32 iCodAutorizado;
        private String sNombreAutorizado;
        private Int32 iFormaPago;
        private DateTime dtFechaPago;
        private Int32 iCodListaPrecio;
        private String sComentario;
        private Double dMontoBruto;
        private Double dPorcDscto;
        private Double dMontoDscto;
        private Double dIgv;
        private Double dTotal;
        private Int32 iEstado;
        private Int32 iPendiente;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private List<clsDetallePedido> lDetalle;
        private String sEntregado;
        private Int32 iEntregado;
        private Int32 numeracion;
        private String nombrecliente;

        public String Nombrecliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
        }

        public Int32 IEntregado
        {
            get { return iEntregado; }
            set { iEntregado = value; }
        }

        public String SEntregado
        {
            get { return sEntregado; }
            set { sEntregado = value; }
        }

        public String CodPedido
        {
            get { return sCodPedido; }
            set { sCodPedido = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }       
        public Int32 CodTipoDocumento
        {
            get { return iCodTipoDocumento; }
            set { iCodTipoDocumento = value; }
        }
        public String SiglaDocumento
        {
            get { return sSiglaDocumento; }
            set { sSiglaDocumento = value; }
        }
        public String DescripcionDocumento
        {
            get { return sDescripcionDocumento; }
            set { sDescripcionDocumento = value; }
        }
        public Int32 CodCotizacion
        {
            get { return iCodCotizacion; }
            set { iCodCotizacion = value; }
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
        public Double TipoCambio
        {
            get { return dTipoCambio; }
            set { dTipoCambio = value; }
        }
        public DateTime FechaPedido
        {
            get { return dtFechaPedido; }
            set { dtFechaPedido = value; }
        }
        public DateTime FechaEntrega
        {
            get { return dtFechaEntrega; }
            set { dtFechaEntrega = value; }
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
        public Int32 FormaPago
        {
            get { return iFormaPago; }
            set { iFormaPago = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public DateTime FechaPago
        {
            get { return dtFechaPago; }
            set { dtFechaPago = value; }
        }
        public String Comentario
        {
            get { return sComentario; }
            set { sComentario = value; }
        }
        public Double MontoBruto
        {
            get { return dMontoBruto; }
            set { dMontoBruto = value; }
        }
        public Double PorcDscto
        {
            get { return dPorcDscto; }
            set { dPorcDscto = value; }
        }
        public Double MontoDscto
        {
            get { return dMontoDscto; }
            set { dMontoDscto = value; }
        }
        public Double Igv
        {
            get { return dIgv; }
            set { dIgv = value; }
        }
        public Double Total
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
        public List<clsDetallePedido> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public int Numeracion
        {
            get { return numeracion; }
            set { numeracion = value; }
        }
         #endregion propiedades

        public String CodigoBarras { get; set; }
        public String CodigoBarrasCifrado { get; set; }
    }
    
}
