using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsSucursal
    {
        #region propiedades

        private Int32 iCodSucursal;
        private Int32 iCodSucursalNueva;
        private Int32 iCodEmpresa;
        private String sNombre;
        private String sUbicacion;
        private String sTelefono;
        private String sDescripcion;       
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private List<Int32> lCodidosForm;


        public Int32 CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
        }
        public Int32 CodSucursalNueva
        {
            get { return iCodSucursalNueva; }
            set { iCodSucursalNueva = value; }
        }
        public Int32 CodEmpresa
        {
            get { return iCodEmpresa; }
            set { iCodEmpresa = value; }
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

        public List<Int32> CodigosForm
        {
            get { return lCodidosForm; }
            set { lCodidosForm = value; }
        }

        #endregion propiedades
    }
}
