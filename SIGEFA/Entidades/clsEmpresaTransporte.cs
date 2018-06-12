using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsEmpresaTransporte
    {
        #region propiedades

        private Int32 iCodEmpresaTranporte;
        private Int32 iCodEmpresaTranporteNuevo;        
        private String sRuc;
        private String sRazonSocial;        
        private String sTelefono;
        private String sDireccion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodEmpresaTranporteNuevo
        {
            get { return iCodEmpresaTranporteNuevo; }
            set { iCodEmpresaTranporteNuevo = value; }
        }
        public Int32 CodEmpresaTranporte
        {
            get { return iCodEmpresaTranporte; }
            set { iCodEmpresaTranporte = value; }
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
