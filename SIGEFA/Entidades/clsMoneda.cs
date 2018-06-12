using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsMoneda
    {
        #region propiedades

        private Int32 icodMoneda;

        public Int32 IcodMoneda
        {
            get { return icodMoneda; }
            set { icodMoneda = value; }
        }
        private Int32 icodPais;

        public Int32 IcodPais
        {
            get { return icodPais; }
            set { icodPais = value; }
        }
        private String sNombrePais;

        public String SNombrePais
        {
            get { return sNombrePais; }
            set { sNombrePais = value; }
        }
        private String sDescripcion;

        public String SDescripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        private DateTime dtFechaRegistro;

        public DateTime DtFechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }
        private Int32 iCodUser;

        public Int32 ICodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        private String sUsuario;

        public String SUsuario
        {
            get { return sUsuario; }
            set { sUsuario = value; }
        }


        private Boolean iEstado;

        public Boolean IEstado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }

        #endregion propiedades
    }
}
