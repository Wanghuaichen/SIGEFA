using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsVendedor
    {
        #region propiedades

        private Int32       iCodVendedor;
        private Int32       iCodVendedorNuevo;
        private String      sDni;
        private String      sNombre;
        private String      sApellido;
        private DateTime    dtFechaNac;
        private String      sDireccion;
        private String      sTelefono;
        private String      sCelular;
        private String      sEmail;       
        private Boolean     iEstado;
        private Int32       iCodUser;
        private DateTime    dtFechaRegistro;        



        public Int32 CodVendedorNuevo
        {
            get { return iCodVendedorNuevo; }
            set { iCodVendedorNuevo = value; }
        }
        public Int32 CodVendedor
        {
            get { return iCodVendedor; }
            set { iCodVendedor = value; }
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

        #endregion propiedades

    }
}
