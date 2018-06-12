using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsConductor
    {
        #region propiedades

        private Int32 iCodConductor;
        private Int32 iCodConductorNuevo;
        private String sDni;
        private String sRuc;
        private String sNombre;
        private String sLicencia;
        private String sTelefono;
        private String sDireccion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodConductorNuevo
        {
            get { return iCodConductorNuevo; }
            set { iCodConductorNuevo = value; }
        }
        public Int32 CodConductor
        {
            get { return iCodConductor; }
            set { iCodConductor = value; }
        }
        public String Dni
        {
            get { return sDni; }
            set { sDni = value; }
        }
        public String Ruc
        {
            get { return sRuc; }
            set { sRuc = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public String Licencia
        {
            get { return sLicencia; }
            set { sLicencia = value; }
        }
        public String Telefono
        {
            get { return sTelefono; }
            set { sTelefono = value; }
        }
        public String Direccion
        {
            get { return sDireccion; }
            set { sDireccion = value; }
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
