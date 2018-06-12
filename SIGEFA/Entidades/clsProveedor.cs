using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsProveedor
    {
        #region propiedades

        private Int32 iCodProveedor;
        private Int32 iCodProveedorNuevo;
        private String sRazonSocial;
        private String sRuc;
        private String sDireccion;
        private String sTelefono;
        private String sFax;
        private String sRepresentante;
        private String sContacto;
        private String sTelefonoContacto;
        private Int32 iFrecuenciaVisita;
        private Double dMargen;
        private String sBanco;
        private String sCtaCte;
        private String sComentario;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String iDepartamento;
        private String iProvincia;
        private String iDistrito;
        private String iMail;


        public String Mail
        {
            get { return iMail; }
            set { iMail = value; }
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
        public Int32 CodProveedorNuevo
        {
            get { return iCodProveedorNuevo; }
            set { iCodProveedorNuevo = value; }
        }
        public Int32 CodProveedor
        {
            get { return iCodProveedor; }
            set { iCodProveedor = value; }
        }
        public String RazonSocial
        {
            get { return sRazonSocial; }
            set { sRazonSocial = value; }
        }
        public String Ruc
        {
            get { return sRuc; }
            set { sRuc = value; }
        }
        public String Direccion
        {
            get { return sDireccion; }
            set { sDireccion = value; }
        }
        public String Telefono
        {
            get { return sTelefono; }
            set { sTelefono = value; }
        }
        public String Fax
        {
            get { return sFax; }
            set { sFax = value; }
        }
        public String Representante
        {
            get { return sRepresentante; }
            set { sRepresentante = value; }
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
        public Int32 FrecuenciaVisita
        {
            get { return iFrecuenciaVisita; }
            set { iFrecuenciaVisita = value; }
        }
        public Double Margen
        {
            get { return dMargen; }
            set { dMargen = value; }
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
        public String Comentario
        {
            get { return sComentario; }
            set { sComentario = value; }
        }
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
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

        #endregion propiedades
    }
}
