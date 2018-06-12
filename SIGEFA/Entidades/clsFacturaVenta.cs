using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsFacturaVenta
    {
        #region propiedades

        private String sCodFacturaVenta;
        private Int32 sCodSucursal;
        private Int32 iCodAlmacen;
        private Int32 iCodTipoTransaccion;
        private String sSiglaTransaccion;
        private String sDescripcionTransaccion;
        private Int32 iCodPedido;
        private Int32 iCodTipoDocumento;
        private Int32 iCodListaPrecio;
        private String sSiglaDocumento;
        private Int32 iCodSerie;
        private String sSerie;
        private String sNumDoc;
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
        private DateTime dtFechaSalida;
        private Int32 iCodAutorizado;
        private String sNombreAutorizado;
        private Int32 iFormaPago;
        private DateTime dtFechaPago;
        private String sComentario;
        private Double dMontoBruto;
        private Double dPorcDscto;
        private Double dMontoDscto;
        private Double dIgv;
        private Double dTotal;
        private Double dAbonado;
        private Double dPendiente;
        private Int32 iEstado;
        private Int32 iEntregado;
        private Int32 iCancelado;
        private Int32 iAnulado;
        private DateTime dtFechaCancelado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Int32 iCodNotacredito;
        private String sDocumentoReferencia;
        private Int32 iCodVendedor;
        private Int32 iCodCotizacion;
        private Boolean bImpreso;
        private Double dLineaCreditoCliente;
        private List<clsDetalleFacturaVenta> lDetalle;
        private Int32 codsalidaconsulext;
        private Boolean consultorext;
        private String sMotivo;
        private String detallecomentario;
        private Int32 codventaentregar;
        private Int32 iCodSeparacion;

        public Int32 CodSeparacion
        {
            get { return iCodSeparacion; }
            set { iCodSeparacion = value; }
        }

        public Int32 Codventaentregar
        {
            get { return codventaentregar; }
            set { codventaentregar = value; }
        }
        
        public String Detallecomentario
        {
            get { return detallecomentario; }
            set { detallecomentario = value; }
        }

        public String Motivo
        {
            get { return sMotivo; }
            set { sMotivo = value; }
        }

        public Boolean Consultorext
        {
            get { return consultorext; }
            set { consultorext = value; }
        }

        public Int32 Codsalidaconsulext
        {
            get { return codsalidaconsulext; }
            set { codsalidaconsulext = value; }
        }

        public String CodFacturaVenta
        {
            get { return sCodFacturaVenta; }
            set { sCodFacturaVenta = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 CodTipoTransaccion
        {
            get { return iCodTipoTransaccion; }
            set { iCodTipoTransaccion = value; }
        }
        public String SiglaTransaccion
        {
            get { return sSiglaTransaccion; }
            set { sSiglaTransaccion = value; }
        }
        public String DescripcionTransaccion
        {
            get { return sDescripcionTransaccion; }
            set { sDescripcionTransaccion = value; }
        }
        public Int32 CodPedido
        {
            get { return iCodPedido; }
            set { iCodPedido = value; }
        }
        public Int32 CodTipoDocumento
        {
            get { return iCodTipoDocumento; }
            set { iCodTipoDocumento = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public String SiglaDocumento
        {
            get { return sSiglaDocumento; }
            set { sSiglaDocumento = value; }
        }
        public Int32 CodSerie
        {
            get { return iCodSerie; }
            set { iCodSerie = value; }
        }
        public String Serie
        {
            get { return sSerie; }
            set { sSerie = value; }
        }
        public String NumDoc
        {
            get { return sNumDoc; }
            set { sNumDoc = value; }
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
        public DateTime FechaSalida
        {
            get { return dtFechaSalida; }
            set { dtFechaSalida = value; }
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
        public Double Pendiente
        {
            get { return dPendiente; }
            set { dPendiente = value; }
        }
        public Double Abonado
        {
            get { return dAbonado; }
            set { dAbonado = value; }
        }
        public Int32 Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }

        public Int32 Entregado
        {
            get { return iEntregado; }
            set { iEntregado = value; }
        }

        public Int32 Cancelado
        {
            get { return iCancelado; }
            set { iCancelado = value; }
        }
        public Int32 Anulado
        {
            get { return iAnulado; }
            set { iAnulado = value; }
        }
        public DateTime FechaCancelado
        {
            get { return dtFechaCancelado; }
            set { dtFechaCancelado = value; }
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
        public Int32 CodNotaCredito
        {
            get { return iCodNotacredito; }
            set { iCodNotacredito = value; }
        }
        public String DocumentoReferencia
        {
            get { return sDocumentoReferencia; }
            set { sDocumentoReferencia = value; }
        }
        public Int32 CodVendedor
        {
            get { return iCodVendedor; }
            set { iCodVendedor = value; }
        }
        
        public List<clsDetalleFacturaVenta> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public int CodSucursal
        {
            get { return sCodSucursal; }
            set { sCodSucursal = value; }
        }

        public int CodCotizacion
        {
            get { return iCodCotizacion; }
            set { iCodCotizacion = value; }
        }
        
        public double LineaCreditoCliente
        {
            get { return dLineaCreditoCliente; }
            set { dLineaCreditoCliente = value; }
        }

        public Boolean Impreso
        {
            get { return bImpreso; }
            set { bImpreso = value; }
        }

        #endregion propiedades

        public String CodigoBarras { get; set; }

        public String TipoDocumentoAnticipo { get; set; }

        public String DocumentoReferenciaAnticipo { get; set; }

        public Decimal MontoAnticipo { get; set; }

        public Int32 Tipoventa { get; set; }

        public Int32 CodEmpresa { get; set; }

        public Decimal Gratuitas { get; set; }

        public Decimal Gravadas { get; set; }

        public Decimal Exoneradas { get; set; }

        public Decimal Inafectas { get; set; }

        public Int32 Boletafactura { get; set; }

        public string CodigoBarrasCifrado { get; set; }
    }
}
