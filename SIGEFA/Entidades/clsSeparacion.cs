using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsSeparacion
    {
        Int32 icodSeparacion;
        Int32 icodAlmacen;
        Int32 icodTipoDocumento;
        Int32 itipoCliente;
        Int32 icodCliente;
        Int32 imoneda;
        Decimal itipoCambio;
        DateTime ifechaPedido;
        DateTime ifechaEntrega;
        Decimal ibruto;
        Decimal imontoDescuento;
        Decimal iigv;
        Decimal itotal;
        Int32 iestado;
        Int32 ipendiente;
        Int32 iformaPago;
        DateTime ifechaPago;
        Int32 icodUsuario;
        DateTime ifechaRegistro;
        Int32 inumeracion;
        String inumDocumento;
        Int32 icodTipoTransaccion;
        String icomentario;
        Int32 icodVendedor;
        Decimal isaldopendiente;
        Decimal isaldocancelado;
        Int32 icodSerie;
        String iserie;
        String iSigla;
        String inomCliente;

        public String NomCliente
        {
            get { return inomCliente; }
            set { inomCliente = value; }
        }

        public String Sigla
        {
            get { return iSigla; }
            set { iSigla = value; }
        }

        public Int32 CodSerie
        {
            get { return icodSerie; }
            set { icodSerie = value; }
        }

        public String Serie
        {
            get { return iserie; }
            set { iserie = value; }
        }

        public Decimal SaldoPendiente
        {
            get { return isaldopendiente; }
            set { isaldopendiente = value; }
        }

        public Decimal SaldoCancelado
        {
            get { return isaldocancelado; }
            set { isaldocancelado = value; }
        }

        public Int32 CodVendedor
        {
            get { return icodVendedor; }
            set { icodVendedor = value; }
        }

        public String Comentario
        {
            get { return icomentario; }
            set { icomentario = value; }
        }

        public Int32 CodSeparacion
        {
            get { return icodSeparacion; }
            set { icodSeparacion = value; }
        }

        public Int32 CodAlmacen
        {
            get { return icodAlmacen; }
            set { icodAlmacen = value; }
        }

        public Int32 CodTipoDocumento
        {
            get { return icodTipoDocumento; }
            set { icodTipoDocumento = value; }
        }

        public Int32 TipoCliente
        {
            get { return itipoCliente; }
            set { itipoCliente = value; }
        }

        public Int32 CodCliente
        {
            get { return icodCliente; }
            set { icodCliente = value; }
        }

        public Int32 Moneda
        {
            get { return imoneda; }
            set { imoneda = value; }
        }

        public Decimal TipoCambio
        {
            get { return itipoCambio; }
            set { itipoCambio = value; }
        }

        public DateTime FechaPedido
        {
            get { return ifechaPedido; }
            set { ifechaPedido = value; }
        }

        public DateTime FechaEntrega
        {
            get { return ifechaEntrega; }
            set { ifechaEntrega = value; }
        }

        public Decimal Bruto
        {
            get { return ibruto; }
            set { ibruto = value; }
        }

        public Decimal MontoDescuento
        {
            get { return imontoDescuento; }
            set { imontoDescuento = value; }
        }

        public Decimal Igv
        {
            get { return iigv; }
            set { iigv = value; }
        }

        public Decimal Total
        {
            get { return itotal; }
            set { itotal = value; }
        }

        public Int32 Estado
        {
            get { return iestado; }
            set { iestado = value; }
        }

        public Int32 FormaPago
        {
            get { return iformaPago; }
            set { iformaPago = value; }
        }

        public Int32 Pendiente
        {
            get { return ipendiente; }
            set { ipendiente = value; }
        }

        public DateTime FechaPago
        {
            get { return ifechaPago; }
            set { ifechaPago = value; }
        }

        public Int32 CodUsuario
        {
            get { return icodUsuario; }
            set { icodUsuario = value; }
        }

        public DateTime FechaRegistro
        {
            get { return ifechaRegistro; }
            set { ifechaRegistro = value; }
        }

        public Int32 Numeracion
        {
            get { return inumeracion; }
            set { inumeracion = value; }
        }

        public String NumDocumento
        {
            get { return inumDocumento; }
            set { inumDocumento = value; }
        }

        public Int32 CodTipoTransaccion
        {
            get { return icodTipoTransaccion; }
            set { icodTipoTransaccion = value; }
        }

    }
}
