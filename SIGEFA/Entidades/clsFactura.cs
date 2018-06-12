using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsFactura
    {
        #region propiedades

        private Int32 iCodFactura;
        private Int32 iCodFacturaNueva;
        private String sDocumentoFactura;
        private Int32 iCodAlmacen;
        private Int32 iCodNotaIngreso;
        private Int32 iCodTipoTransaccion;
        private String sSiglaTransaccion;
        private String sDescripcionTransaccion;
        private Int32 iCodOrdenCompra;
        private Int32 iCodTipoDocumento;
        private String sSiglaDocumento;
        private Int32 iCodSerie;
        private String sSerie;
        private String sNumFac;
        private Int32 iCodReferencia;
        private Int32 iCodProveedor;
        private String sRUCProveedor;
        private String sRazonSocialProveedor;
        private Int32 iMoneda;
        private Double dTipoCambio;        
        private DateTime dtFechaIngreso;
        private Int32 iCodAutorizado;
        private String sNombreAutorizado;
        private Int32 iFormaPago;
        private DateTime dtFechaPago;
        private String sComentario;
        private Double dMontoBruto;
        private Double dPorcDscto;
        private Double dMontoDscto;
        private Double dIgv;
        private Double dFlete;
        private Double dTotal;
        private Double dAbonado;
        private Double dPendiente;        
        private Int32 iEstado;
        private Int32 iRecibido;
        private Int32 iCancelado;
        private DateTime dtFechaCancelado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sDocumentoOrden;
        private String sMotivo;
        private List<clsDetalleFactura> lDetalle;

        public String Motivo
        {
            get { return sMotivo; }
            set { sMotivo = value; }
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
        public Int32 CodOrdenCompra
        {
            get { return iCodOrdenCompra; }
            set { iCodOrdenCompra = value; }
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
        public String NumFac
        {
            get { return sNumFac; }
            set { sNumFac = value; }
        } 
        public Int32 CodProveedor
        {
            get { return iCodProveedor; }
            set { iCodProveedor = value; }
        }
        public String RUCProveedor
        {
            get { return sRUCProveedor; }
            set { sRUCProveedor = value; }
        }
        public String RazonSocialProveedor
        {
            get { return sRazonSocialProveedor; }
            set { sRazonSocialProveedor = value; }
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
        public DateTime FechaIngreso
        {
            get { return dtFechaIngreso; }
            set { dtFechaIngreso = value; }
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
        public Double Flete
        {
            get { return dFlete; }
            set { dFlete = value; }
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
        public Int32 Recibido
        {
            get { return iRecibido; }
            set { iRecibido = value; }
        }
        public Int32 Cancelado
        {
            get { return iCancelado; }
            set { iCancelado = value; }
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
        public Int32 CodReferencia
        {
            get { return iCodReferencia; }
            set { iCodReferencia = value; }
        }
        public List<clsDetalleFactura> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public String SDocumentoOrden
        {
            get { return sDocumentoOrden; }
            set { sDocumentoOrden = value; }
        }

        public int CodNotaIngreso
        {
            get { return iCodNotaIngreso; }
            set { iCodNotaIngreso = value; }
        }

        public int CodFactura
        {
            get { return iCodFactura; }
            set { iCodFactura = value; }
        }

        public string DocumentoFactura
        {
            get { return sDocumentoFactura; }
            set { sDocumentoFactura = value; }
        }

        public int CodFacturaNueva
        {
            get { return iCodFacturaNueva; }
            set { iCodFacturaNueva = value; }
        }

        #endregion propiedades
                
    }
}

