using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsAlmacen
    {
        #region propiedades

        private Int32 iCodAlmacen;
        private Int32 iCodAlmacenNuevo;
        private Int32 iCodEmpresa;
        private Int32 iCodUser;
        private Int32 iCodSuc;
        private String sNombre;        
        private String sUbicacion;
        private String sTelefono;
        private String sDescripcion;
        private Boolean iEstado;
        private DateTime dtFechaRegistro;
        private Boolean iEstadoPrincipal;

        public Boolean EstadoPrincipal
        {
            get { return iEstadoPrincipal; }
            set { iEstadoPrincipal = value; }
        }

        public Int32 CodAlmacenNuevo
        {
            get { return iCodAlmacenNuevo; }
            set { iCodAlmacenNuevo = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 CodEmpresa
        {
            get { return iCodEmpresa; }
            set { iCodEmpresa = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        public Int32 CodSuc
        {
            get { return iCodSuc; }
            set { iCodSuc = value; }
        }
        public String Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }
        public String Ubicacion
        {
            get { return sUbicacion; }
            set { sUbicacion = value; }
        }
        public String Telefono
        {
            get { return sTelefono; }
            set { sTelefono = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }  
        public Boolean Estado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }

        #endregion propiedades
    }
}
