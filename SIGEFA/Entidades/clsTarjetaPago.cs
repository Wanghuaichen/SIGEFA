using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsTarjetaPago
    {
        #region propiedades

        private Int32 iCodTarjeta;
        private Int32 iCodTarjetaNuevo;
        private String sTipo;
        private String sDescripcion;
        private Boolean bEstado;
        private Int32 iCoduser;
        private DateTime dFecharegistro;
        private Int32 iCodAlmacen;
        private Double dPorcComision;
        private Double dAlquilerEquipo;

        public Int32 CodTarjeta
        {
            get { return iCodTarjeta; }
            set { iCodTarjeta = value; }
        }
        public Int32 CodTarjetaNuevo
        {
            get { return iCodTarjetaNuevo; }
            set { iCodTarjetaNuevo = value; }
        }
        public String Tipo
        {
            get { return sTipo; }
            set { sTipo = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        public Int32 Coduser
        {
            get { return iCoduser; }
            set { iCoduser = value; }
        }
        public DateTime Fecharegistro
        {
            get { return dFecharegistro; }
            set { dFecharegistro = value; }
        }

        public int CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }

        public double PorcComision
        {
            get { return dPorcComision; }
            set { dPorcComision = value; }
        }

        public double AlquilerEquipo
        {
            get { return dAlquilerEquipo; }
            set { dAlquilerEquipo = value; }
        }

        #endregion propiedades
    }
}
