using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsEmpresa
    {
        #region propiedades

        private Int32 iCodEmpresa;
        private Int32 iCodEmpresaNueva;
        private String sRazonSocial;
        private String sRuc;        
        private String sDireccion;
        private String sTelefono;
        private String sFax;        
        private String sRepresentante;        
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodEmpresaNuevo
        {
            get { return iCodEmpresaNueva; }
            set { iCodEmpresaNueva = value; }
        }
        public Int32 CodEmpresa
        {
            get { return iCodEmpresa; }
            set { iCodEmpresa = value; }
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

        public string Certificado { get; set; }

        public string Contrasena { get; set; }

        public string UsuarioSunat { get; set; }

        public string ClaveSunat { get; set; }

        public String url { get; set; }
    }
}
