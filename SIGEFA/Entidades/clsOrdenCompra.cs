using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsOrdenCompra
    {
        public Int32 CodOrdenCompraNuevo
        { get; set; }
        public Int32 CodOrdenCompra
        {
            get;
            set;
        }
        public Int32 CodAlmacen
        {
            get;
            set;
        }
        public Int32 CodTipoTransaccion
        {
            get;
            set;
        }
        public String SiglaTransaccion
        {
            get;
            set;
        }
        public String DescripcionTransaccion
        {
            get;
            set;
        }
        public Int32 CodTipoDocumento
        {
            get;
            set;
        }
        public String SiglaDocumento
        {
            get;
            set;
        }
        public Int32 CodSerie
        {
            get;
            set;
        }
        public String Serie
        {
            get;
            set;
        }
        public String NumDoc
        {
            get;
            set;
        }
        public Int32 CodProveedor
        {
            get;
            set;
        }
        public String RUCProveedor
        {
            get;
            set;
        }
        public String RazonSocialProveedor
        {
            get;
            set;
        }
        public String ReferenciaProveedor
        {
            get;
            set;
        }
        public Int32 Moneda
        {
            get;
            set;
        }
        public Decimal TipoCambio
        {
            get;
            set;
        }
        public DateTime FechaIngreso
        {
            get;
            set;
        }
        public Int32 CodAutorizado
        {
            get;
            set;
        }
        public String NombreAutorizado
        {
            get;
            set;
        }
        public Int32 FormaPago
        {
            get;
            set;
        }
        public DateTime FechaPago
        {
            get;
            set;
        }
        public String Comentario
        {
            get;
            set;
        }
        public Decimal MontoBruto
        {
            get;
            set;
        }
        public Decimal PorcDscto
        {
            get;
            set;
        }
        public Decimal MontoDscto
        {
            get;
            set;
        }
        public Decimal Igv
        {
            get;
            set;
        }
        public Decimal Flete
        {
            get;
            set;
        }
        public Decimal Total
        {
            get;
            set;
        }
        public Boolean Pendiente
        {
            get;
            set;
        }
        public Decimal Abonado
        {
            get;
            set;
        }
        public Boolean Estado
        {
            get;
            set;
        }
        public Int32 Recibido
        {
            get;
            set;
        }
        public Int32 Cancelado
        {
            get;
            set;
        }
        public DateTime FechaCancelado
        {
            get;
            set;
        }
        public Int32 CodUser
        {
            get;
            set;
        }
        public DateTime FechaRegistro
        {
            get;
            set;
        }
        public Int32 CodReferencia
        {
            get;
            set;
        }
        public List<clsDetalleOrdenCompra> Detalle
        {
            get;
            set;
        }
    }
}
