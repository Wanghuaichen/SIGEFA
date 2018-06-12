using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsLetra
    {
        #region propiedades

        private Int32 iCodLetra;
        private Int32 iCodAlmacen;
        private Int32 iCodDocumento;
        private String sSiglaDocumento;
        private Int32 iCodSerie;
        private String sSerie;
        private String sNumDocumento;
        private Int32 iCodNota;
        private String sDocumentoReferencia;
        private Int32 iCodProveedor;
        private String sRazonSocialProveedor;
        private String sRucProveedor;
        private String sDireccionProveedor;
        private Int32 iCodLiberado;
        private DateTime dtFechaEmision;
        private DateTime dtFechaVencimiento;
        private DateTime dtFechaCancelado;
        private Boolean bIngresoEgreso;
        private Int32 iCodMoneda;        
        private Double dTipoCambio;
        private Double dMonto;
        private Double dMontoPendiente;
        private Int32 iCodBanco;
        private String sNumeroUnico;
        private Boolean bCancelado;
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sFechaCancelado2;
        private Int32 codfactura;
        private Int32 codfacturaventa;

        public Int32 Codfacturaventa
        {
            get { return codfacturaventa; }
            set { codfacturaventa = value; }
        }

        public Int32 Codfactura
        {
            get { return codfactura; }
            set { codfactura = value; }
        }


        public Int32 CodLetra
        {
            get { return iCodLetra; }
            set { iCodLetra = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 CodDocumento
        {
            get { return iCodDocumento; }
            set { iCodDocumento = value; }
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
        public String NumDocumento
        {
            get { return sNumDocumento; }
            set { sNumDocumento = value; }
        }
        public Int32 CodNota
        {
            get { return iCodNota; }
            set { iCodNota = value; }
        }
        public String DocumentoReferencia
        {
            get { return sDocumentoReferencia; }
            set { sDocumentoReferencia = value; }
        }
        public Int32 CodProveedor
        {
            get { return iCodProveedor; }
            set { iCodProveedor = value; }
        }
        public Int32 CodLiberado
        {
            get { return iCodLiberado; }
            set { iCodLiberado = value; }
        }
        public String RazonSocialProveedor
        {
            get { return sRazonSocialProveedor; }
            set { sRazonSocialProveedor = value; }
        }
        public String RucProveedor
        {
            get { return sRucProveedor; }
            set { sRucProveedor = value; }
        }
        public String DireccionProveedor
        {
            get { return sDireccionProveedor; }
            set { sDireccionProveedor = value; }
        }
        public DateTime FechaEmision
        {
            get { return dtFechaEmision; }
            set { dtFechaEmision = value; }
        }
        public DateTime FechaVencimiento
        {
            get { return dtFechaVencimiento; }
            set { dtFechaVencimiento = value; }
        }
        public DateTime FechaCancelado
        {
            get { return dtFechaCancelado; }
            set { dtFechaCancelado = value; }
        }
        public Boolean IngresoEgreso
        {
            get { return bIngresoEgreso; }
            set { bIngresoEgreso = value; }
        }
        public Int32 CodMoneda
        {
            get { return iCodMoneda; }
            set { iCodMoneda = value; }
        }        
        public Double TipoCambio
        {
            get { return dTipoCambio; }
            set { dTipoCambio = value; }
        }
        public Double Monto
        {
            get { return dMonto; }
            set { dMonto = value; }
        }
        public Double MontoPendiente
        {
            get { return dMontoPendiente; }
            set { dMontoPendiente = value; }
        }
        public Int32 CodBanco
        {
            get { return iCodBanco; }
            set { iCodBanco = value; }
        }
        public String NumeroUnico
        {
            get { return sNumeroUnico; }
            set { sNumeroUnico = value; }
        }
        public Boolean Cancelado
        {
            get { return bCancelado; }
            set { bCancelado = value; }
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

        public string FechaCancelado2
        {
            get { return sFechaCancelado2; }
            set { sFechaCancelado2 = value; }
        }

        #endregion propiedades
    }
}
