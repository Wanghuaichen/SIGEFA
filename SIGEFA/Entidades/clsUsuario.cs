using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsUsuario
    {
        #region propiedades

        private Int32       iCodUsuario;
        private Int32       iCodUsuarioNuevo;
        private String      sDni;
        private String      sNombre;
        private String      sApellido;
        private DateTime    dtFechaNac;
        private String      sDireccion;
        private String      sTelefono;
        private String      sCelular;
        private String      sEmail;
        private String      sUsuario;
        private String      sContraseña;
        private String      sContraemail;
        private String      sHost;
        private Int32       iNivel;
        private Boolean     iEstado;
        private Int32       iCodUser;
        private DateTime    dtFechaRegistro;
        private Int32       iCodEmpresaLogin;
        private List<Int32> lCodidosForm;

        private Int32 iCodSucursalLogin;
        public Int32 EstadoIngreso { get; set; }



        public Int32 CodUsuarioNuevo
        {
            get { return iCodUsuarioNuevo; }
            set { iCodUsuarioNuevo = value; }
        }
        public Int32 CodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
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
        public String Apellido
        {
            get { return sApellido; }
            set { sApellido = value; }
        }
        public DateTime FechaNac
        {
            get { return dtFechaNac; }
            set { dtFechaNac = value; }
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
        public String Celular
        {
            get { return sCelular; }
            set { sCelular = value; }
        }
        public String Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }        
        public String Usuario
        {
            get { return sUsuario; }
            set { sUsuario = value; }
        }
        public String Contraseña
        {
            get { return sContraseña; }
            set { sContraseña = value; }
        }
        public String Host
        {
            get { return sHost; }
            set { sHost = value; }
        }
        public String ContraEmail
        {
            get { return sContraemail; }
            set { sContraemail = value; }
        }
        public Int32 Nivel
        {
            get { return iNivel; }
            set { iNivel = value; }
        }
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value;}
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
        public Int32 CodEmpresaLogin
        {
            get { return iCodEmpresaLogin; }
            set { iCodEmpresaLogin = value; }
        }
        public List<Int32> CodigosForm
        {
            get { return lCodidosForm; }
            set { lCodidosForm = value; }
        }
        public Int32 CodSucursalLogin
        {
            get { return iCodSucursalLogin; }
            set { iCodSucursalLogin = value; }
        }

        #endregion propiedades


        
    }
}
