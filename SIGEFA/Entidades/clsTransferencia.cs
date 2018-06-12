using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsTransferencia
    {
        #region propiedades

        private String sCodTransDir;
        private Int32 iCodAlmacenOrigen;
        private Int32 iCodTipoDocumento;
        private String sSiglaDocumento;
        private String sDescripcionDocumento;
        private Int32 iCodAlmacenDestino;
        private Int32 iMoneda;
        private decimal dTipoCambio;
        private DateTime dtFechaEnvio;
        private DateTime dtFechaEntrega;
        
        private String sDescripcionRechazo;
        private Int32 iFormaPago;
        private DateTime dtFechaPago;
        private Int32 iCodListaPrecio;
        private String sComentario;
        private decimal dMontoBruto;
        private decimal dPorcDscto;
        private decimal dMontoDscto;
        private decimal dIgv;
        private decimal dTotal;
        private Int32 iEstado;
        private Int32 idcodProv;
        private Int32 iPendiente;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private List<clsDetalleTransferencia> lDetalle;

        private Int32 codserie;
        private String serie;
        private String numerodocumento;

        public String Numerodocumento
        {
            get { return numerodocumento; }
            set { numerodocumento = value; }
        }

        public String Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public Int32 Codserie
        {
            get { return codserie; }
            set { codserie = value; }
        }


        public String CodTransDir
        {
            get { return sCodTransDir; }
            set { sCodTransDir = value; }
        }
        public Int32 CodAlmacenOrigen
        {
            get { return iCodAlmacenOrigen; }
            set { iCodAlmacenOrigen = value; }
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
        public Int32 CodAlmacenDestino
        {
            get { return iCodAlmacenDestino; }
            set { iCodAlmacenDestino = value; }
        }
        public Int32 IdcodProv
        {
            get { return idcodProv; }
            set { idcodProv = value; }
        }
        public Int32 Moneda
        {
            get { return iMoneda; }
            set { iMoneda = value; }
        }
        public decimal TipoCambio
        {
            get { return dTipoCambio; }
            set { dTipoCambio = value; }
        }
        public DateTime FechaEnvio
        {
            get { return dtFechaEnvio; }
            set { dtFechaEnvio = value; }
        }
        public DateTime FechaEntrega
        {
            get { return dtFechaEntrega; }
            set { dtFechaEntrega = value; }
        }

        public String DescripcionRechazo
        {
            get { return sDescripcionRechazo; }
            set { sDescripcionRechazo = value; }
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
        public decimal MontoBruto
        {
            get { return dMontoBruto; }
            set { dMontoBruto = value; }
        }
        public decimal PorcDscto
        {
            get { return dPorcDscto; }
            set { dPorcDscto = value; }
        }
        public decimal MontoDscto
        {
            get { return dMontoDscto; }
            set { dMontoDscto = value; }
        }
        public decimal Igv
        {
            get { return dIgv; }
            set { dIgv = value; }
        }
        public decimal Total
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
        public List<clsDetalleTransferencia> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }
        #endregion propiedades
    }
}
