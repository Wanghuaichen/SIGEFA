using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsModeloTransporte
    {
        #region propiedades

        private Int32 iCodModeloTransporte;
        private Int32 iCodModeloTransporteNuevo;
        private Int32 iCodMarcaTransporte;
        private String sReferencia;
        private String sDescripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;


        public Int32 CodModeloTransporteNuevo
        {
            get { return iCodModeloTransporteNuevo; }
            set { iCodModeloTransporteNuevo = value; }
        }
        public Int32 CodModeloTransporte
        {
            get { return iCodModeloTransporte; }
            set { iCodModeloTransporte = value; }
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
