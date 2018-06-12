using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsCliente
    {
        #region propiedades

        private Int32 iCodCliente;
        private Int32 iCodClienteNuevo;
        private Int32 iCodListaPrecio;
        private String sCodigoPersonalizado;
        private Int32 iCodVendedor;
        private Int32 iTipo;
        private String sDni;
        private String sNombre;        
        private String sRuc;
        private String sRazonSocial;
        private String sDireccionLegal;
        private String sDireccionEntrega;
        private String sTelefono;
        private String sEmail;
        private String sWeb;
        private String iPais;
        private String iDepartamento;
        private String iProvincia;
        private String iDistrito;
        private Int32 iZona;
        private Decimal dDescuento;
        private Int32 iFormaPago;
        private Int32 iMoneda;
        private Decimal dLineaCredito;
        private Decimal dLineaCreditoDisponible;
        private String sComentario;
        private String sBanco;
        private String sCtaCte;
        private String sContacto;
        private String sTelefonoContacto;
        private Int32 iCalificacion;        
        private Boolean iEstado;
        private Boolean iHabilitado;
        private Int32 iCantidad;
        private Decimal dDeuda;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sRuc_Dni;
        private Decimal dLineaCreditoUsado;
        private Boolean bClienteFacturasVencidas;
        private Decimal dTasa;
        public Boolean CliEspecial { get; set; }

        public Decimal Tasa
        {
            get { return dTasa; }
            set { dTasa = value; }
        }

        public Int32 CodClienteNuevo
        {
            get { return iCodClienteNuevo; }
            set { iCodClienteNuevo = value; }
        }
        public Int32 CodCliente
        {
            get { return iCodCliente; }
            set { iCodCliente = value; }
        }
        public Int32 CodListaPrecio
        {
            get { return iCodListaPrecio; }
            set { iCodListaPrecio = value; }
        }
        public String CodigoPersonalizado
        {
            get { return sCodigoPersonalizado; }
            set { sCodigoPersonalizado = value; }
        }
        public Int32 CodVendedor
        {
            get { return iCodVendedor; }
            set { iCodVendedor = value; }
        }
        public Int32 Tipo
        {
            get { return iTipo; }
            set { iTipo = value; }
        }
        public String Dni
        {
            get { return sDni; }
            set { sDni = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public String Ruc
        {
            get { return sRuc; }
            set { sRuc = value; }
        }
        public String RazonSocial
        {
            get { return sRazonSocial; }
            set { sRazonSocial = value; }
        }        
        public String DireccionLegal
        {
            get { return sDireccionLegal; }
            set { sDireccionLegal = value; }
        }
        public String DireccionEntrega
        {
            get { return sDireccionEntrega; }
            set { sDireccionEntrega = value; }
        }
        public String Telefono
        {
            get { return sTelefono; }
            set { sTelefono = value; }
        }
        public String Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public String Web
        {
            get { return sWeb; }
            set { sWeb = value; }
        }
        public String Pais
        {
            get { return iPais; }
            set { iPais = value; }
        }
        public String Departamento
        {
            get { return iDepartamento; }
            set { iDepartamento = value; }
        }
        public String Provincia
        {
            get { return iProvincia; }
            set { iProvincia = value; }
        }
        public String Distrito
        {
            get { return iDistrito; }
            set { iDistrito = value; }
        }
        public Int32 Zona
        {
            get { return iZona; }
            set { iZona = value; }
        }
        public Decimal Descuento
        {
            get { return dDescuento; }
            set { dDescuento = value; }
        }
        public Int32 FormaPago
        {
            get { return iFormaPago; }
            set { iFormaPago = value; }
        }
        public Int32 Moneda
        {
            get { return iMoneda; }
            set { iMoneda = value; }
        }
        public Decimal LineaCredito
        {
            get { return dLineaCredito; }
            set { dLineaCredito = value; }
        }
        public String Comentario
        {
            get { return sComentario; }
            set { sComentario = value; }
        }
        public String Banco
        {
            get { return sBanco; }
            set { sBanco = value; }
        }
        public String CtaCte
        {
            get { return sCtaCte; }
            set { sCtaCte = value; }
        }
        public String Contacto
        {
            get { return sContacto; }
            set { sContacto = value; }
        }
        public String TelefonoContacto
        {
            get { return sTelefonoContacto; }
            set { sTelefonoContacto = value; }
        }
        public Int32 Calificacion
        {
            get { return iCalificacion; }
            set { iCalificacion = value; }
        }
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public Boolean Habilitado
        {
            get { return iHabilitado; }
            set { iHabilitado = value; }
        }
        public Int32 Cantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }
        public Decimal Deuda
        {
            get { return dDeuda; }
            set { dDeuda = value; }
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

        public Decimal LineaCreditoDisponible
        {
            get { return dLineaCreditoDisponible; }
            set { dLineaCreditoDisponible = value; }
        }

        public string RucDni
        {
            get { return sRuc_Dni; }
            set { sRuc_Dni = value; }
        }

        public Decimal LineaCreditoUsado
        {
            get { return dLineaCreditoUsado; }
            set { dLineaCreditoUsado = value; }
        }

        public Boolean ClienteFacturasVencidas
        {
            get { return bClienteFacturasVencidas; }
            set { bClienteFacturasVencidas = value; }
        }

        #endregion propiedades

    }
}
