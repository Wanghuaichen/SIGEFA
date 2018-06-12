using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsMarcaTransporte
    {
        #region propiedades

        private Int32 iCodMarcaTransporte;
        private Int32 iCodMarcaTransporteNuevo;        
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodMarcaTransporteNuevo
        {
            get { return iCodMarcaTransporteNuevo; }
            set { iCodMarcaTransporteNuevo = value; }
        }
        public Int32 CodMarcaTransporte
        {
            get { return iCodMarcaTransporte; }
            set { iCodMarcaTransporte = value; }
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

        #endregion propiedades
    }
}
