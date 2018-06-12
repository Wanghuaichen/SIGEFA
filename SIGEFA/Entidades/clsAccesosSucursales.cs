using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsAccesosSucursales : IEquatable<clsAccesosSucursales>
    {
        #region propiedades

        private Int32 iCodAccesoSucursal;
        private Int32 iCodAccesoSucursalNuevo;
        private Int32 iCodUsuario;
        private Int32 iCodEmpresa;
        private Int32 iCodSucursal;
        private DateTime dFechaRegistro;
        private Int32 iCodUser;


        public Int32 CodAccesoSucursal
        {
            get { return iCodAccesoSucursal; }
            set { iCodAccesoSucursal = value; }
        }
        public Int32 CodAccesoSucursalNuevo
        {
            get { return iCodAccesoSucursalNuevo; }
            set { iCodAccesoSucursalNuevo = value; }
        }
        public Int32 CodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
        public Int32 CodEmpresa
        {
            get { return iCodEmpresa; }
            set { iCodEmpresa = value; }
        }
        public Int32 CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
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

        #region IEquatable<clsAccesosSucursales> Members

        public bool Equals(clsAccesosSucursales other)
        {
            if (this.CodEmpresa == other.CodEmpresa && this.CodSucursal == other.CodSucursal)
                return true;
            return false;
        }

        #endregion

    }
}
