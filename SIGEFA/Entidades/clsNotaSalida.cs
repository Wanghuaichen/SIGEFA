using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsNotaSalida
    {
        #region propiedades

        private String sCodNotaSalida;
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
        private Int32 sDocumentoReferencia;
        private Int32 iCodVendedor;
        private Int32 iCodStand;
        private Int32 iAceptado;
        private Int32 iCodSucursal;
        private List<clsDetalleNotaSalida> lDetalle;
        private Int32 icodVehiculoTransporte;
        private Int32 icodConductor;
        private Int32 icodalmacenreceptor;
        private String docref;
        private Int32 iAplicada;
        private Int32 iCodAplicada;
        private String sMotivo;
        private Int32 iCodProveedor;
        private String sDocumentoNotaSalida;
        private String sDocumentoFacturaAplicada;
        private Int32 codtransferencia;

        public Int32 Codtransferencia
        {
            get { return codtransferencia; }
            set { codtransferencia = value; }
        }

        public String DocumentoFacturaAplicada
        {
            get { return sDocumentoFacturaAplicada; }
            set { sDocumentoFacturaAplicada = value; }
        }

        public String DocumentoNotaSalida
        {
            get { return sDocumentoNotaSalida; }
            set { sDocumentoNotaSalida = value; }
        }

        public Int32 CodProveedor
        {
            get { return iCodProveedor; }
            set { iCodProveedor = value; }
        }
        public String Motivo
        {
            get { return sMotivo; }
            set { sMotivo = value; }
        }

        public Int32 CodAplicada
        {
            get { return iCodAplicada; }
            set { iCodAplicada = value; }
        }

        public Int32 Aplicada
        {
            get { return iAplicada; }
            set { iAplicada = value; }
        }


        public Int32 codalmacenreceptor
        {
            get { return icodalmacenreceptor; }
            set { icodalmacenreceptor = value; }
        }

        public Int32 codVehiculoTransporte
        {
            get { return icodVehiculoTransporte; }
            set { icodVehiculoTransporte = value; }
        }

        public Int32 codConductor
        {
            get { return icodConductor; }
            set { icodConductor = value; }
        }

        public String CodNotaSalida
        {
            get { return sCodNotaSalida; }
            set { sCodNotaSalida = value; }
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
        public Int32 DocumentoReferencia
        {
            get { return sDocumentoReferencia; }
            set { sDocumentoReferencia = value; }
        }
        public Int32 CodVendedor
        {
            get { return iCodVendedor; }
            set { iCodVendedor = value; }
        }
        public Int32 CodStand
        {
            get { return iCodStand; }
            set { iCodStand = value; }
        }
        public List<clsDetalleNotaSalida> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public int Aceptado
        {
            get { return iAceptado; }
            set { iAceptado = value; }
        }

        public int CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
        }

        public string Docref
        {
            get { return docref; }
            set { docref = value; }
        }

        #endregion propiedades
    }
    
}
