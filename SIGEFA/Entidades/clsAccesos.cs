using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsAccesos : IEquatable<clsAccesos>
    {
        #region propiedades

        private Int32 iCodAcceso;
        private Int32 iCodNuevoAcceso;
        private Int32 iCodUsuario;
        private Int32 iCodAlmacen;
        private Int32 iCodFormulario;
        private DateTime dFechaRegistro;
        private Int32 iCodUser; 
       

        public Int32 CodAcceso
        {
            get { return iCodAcceso; }
            set { iCodAcceso = value; }
        }
        public Int32 CodNuevoAcceso
        {
            get { return iCodNuevoAcceso; }
            set { iCodNuevoAcceso = value; }
        }
        public Int32 CodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 CodFormulario
        {
            get { return iCodFormulario; }
            set { iCodFormulario = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }
        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }

        #endregion propiedades

        #region IEquatable<clsAccesos> Members

        public bool Equals(clsAccesos other)
        {
            if (this.CodFormulario == other.CodFormulario && this.CodAlmacen == other.CodAlmacen)
                return true;
            return false;
        }

        #endregion

    }
}
