using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsGuiaRemision
    {
        #region propiedades

        private String sCodGuiaRemision;
        private Int32 iCodAlmacen;
        private String sCodigosPedidos;
        private String sCodigosFacturas;
        private Int32 iCodMotivo;
        private Int32 iCodTipoDocumento;
        private String sSiglaDocumento;
        private Int32 iCodSerie;
        private String sSerie;
        private String sNumDoc;
        private Int32 iTipoCliente;
        private Int32 iCodCliente;
        private String sCodigoPersonalizado;
        private String sRUCCliente;        
        private String sDNI;
        private String sRazonSocialCliente;
        private String sNombre;
        private String sDireccion;
        private Int32 iCodVehiculoTransporte;
        private Int32 iCodMarca;
        private Int32 iCodModelo;
        private String sPlaca;
        private String sMarca;
        private String sModelo;
        private String sConstanciaInscripcion;
        private Int32 iCodConductor;
        private String sNombreConductor;
        private String sLicencia;
        private Int32 iCodEmpresaTransporte;
        private String sRUCEmpresaTransporte;
        private String sRazonSocialTransporte;
        private String sDireccionTransporte;
        private DateTime dtFechaEmision;
        private DateTime dtFechaTraslado;
        private String sComentario;
        private Int32 iEstado;
        private Int32 iFacturado;
        private Int32 iCodPedido;
        private Int32 iCodFactura;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Int32 sCodAlmacenDestino;
        private String sNomAlmacenDestino;
        private String sUbicacionAlmacenDest;
        private List<clsDetalleGuiaRemision> lDetalle;
        private Int32 iCodReq;
        private Int32 iCodProveedor;
        private Int32 iCodTransferencia;

        public Int32 CodTransferencia
        {
            get { return iCodTransferencia; }
            set { iCodTransferencia = value; }
        }

        public Int32 CodProveedor
        {
            get { return iCodProveedor; }
            set { iCodProveedor = value; }
        }

        public Int32 CodReq
        {
            get { return iCodReq; }
            set { iCodReq = value; }
        }

        public String CodGuiaRemision
        {
            get { return sCodGuiaRemision; }
            set { sCodGuiaRemision = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }        
        public String CodigosPedidos
        {
            get { return sCodigosPedidos; }
            set { sCodigosPedidos = value; }
        }
        public String CodigosFacturas
        {
            get { return sCodigosFacturas; }
            set { sCodigosFacturas = value; }
        }
        public Int32 CodMotivo
        {
            get { return iCodMotivo; }
            set { iCodMotivo = value; }
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
        public String CodigoPersonalizado
        {
            get { return sCodigoPersonalizado; }
            set { sCodigoPersonalizado = value; } 
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
        public Int32 CodVehiculoTransporte
        {
            get { return iCodVehiculoTransporte; }
            set { iCodVehiculoTransporte = value; } 
        }
        public Int32 CodMarca
        {
            get { return iCodMarca; }
            set { iCodMarca = value; } 
        }
        public Int32 CodModelo
        {
            get { return iCodModelo; }
            set { iCodModelo = value; }
        }
        public String Placa
        {
            get { return sPlaca; }
            set { sPlaca = value; }
        }
        public String Marca
        {
            get { return sMarca; }
            set { sMarca = value; }
        }
        public String Modelo
        {
            get { return sModelo; }
            set { sModelo = value; }
        }
        public String ConstanciaInscripcion
        {
            get { return sConstanciaInscripcion; }
            set { sConstanciaInscripcion = value; }
        }
        public Int32 CodConductor
        {
            get { return iCodConductor; }
            set { iCodConductor = value; }
        }
        public String NombreConductor
        {
            get { return sNombreConductor; }
            set { sNombreConductor = value; }
        }
        public String Licencia
        {
            get { return sLicencia; }
            set { sLicencia = value; }
        }
        public Int32 CodEmpresaTransporte
        {
            get { return iCodEmpresaTransporte; }
            set { iCodEmpresaTransporte = value; }
        }
        public String RUCEmpresaTransporte
        {
            get { return sRUCEmpresaTransporte; }
            set { sRUCEmpresaTransporte = value; }
        }
        public String RazonSocialTransporte
        {
            get { return sRazonSocialTransporte; }
            set { sRazonSocialTransporte = value; }
        }
        public String DireccionTransporte
        {
            get { return sDireccionTransporte; }
            set { sDireccionTransporte = value; }
        }
        public DateTime FechaEmision
        {
            get { return dtFechaEmision; }
            set { dtFechaEmision = value; }
        }
        public DateTime FechaTraslado
        {
            get { return dtFechaTraslado; }
            set { dtFechaTraslado = value; }
        }
        public String Comentario
        {
            get { return sComentario; }
            set { sComentario = value; }
        }        
        public Int32 Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public Int32 Facturado
        {
            get { return iFacturado; }
            set { iFacturado = value; }
        }
        public Int32 CodPedido
        {
            get { return iCodPedido; }
            set { iCodPedido = value; }
        }
        public Int32 CodFactura
        {
            get { return iCodFactura; }
            set { iCodFactura = value; }
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
        public List<clsDetalleGuiaRemision> Detalle
        {
            get { return lDetalle; }
            set { lDetalle = value; }
        }

        public Int32 CodAlmacenDestino
        {
            get { return sCodAlmacenDestino; }
            set { sCodAlmacenDestino = value; }
        }

        public String NomAlmacenDestino
        {
            get { return sNomAlmacenDestino; }
            set { sNomAlmacenDestino = value; }
        }

        public String UbicacionAlmacenDest
        {
            get { return sUbicacionAlmacenDest; }
            set { sUbicacionAlmacenDest = value; }
        }

         #endregion propiedades
    }
    
}
