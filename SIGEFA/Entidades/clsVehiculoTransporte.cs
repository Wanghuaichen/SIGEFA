using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsVehiculoTransporte
    {
        #region propiedades

        private Int32 iCodVehiculoTransporte;
        private Int32 iCodVehiculoTransporteNuevo;
        private String sPlaca;
        private Int32 iCodMarca;
        private String sMarca;
        private Int32 iCodModelo;
        private String sModelo;
        private Int32 iAño;
        private String sConstanciaInscripcion;
        private Boolean iEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private String sSoat;
        private String sConfVehicular;
        private String sMTC;

        public String MTC
        {
            get { return sMTC; }
            set { sMTC = value; }
        }

        public String ConfVehicular
        {
            get { return sConfVehicular; }
            set { sConfVehicular = value; }
        }

        public String Soat
        {
            get { return sSoat; }
            set { sSoat = value; }
        }
        

        public Int32 CodVehiculoTransporteNuevo
        {
            get { return iCodVehiculoTransporteNuevo; }
            set { iCodVehiculoTransporteNuevo = value; }
        }
        public Int32 CodVehiculoTransporte
        {
            get { return iCodVehiculoTransporte; }
            set { iCodVehiculoTransporte = value; }
        }
        public String Placa
        {
            get { return sPlaca; }
            set { sPlaca = value; }
        }
        public Int32 CodMarca
        {
            get { return iCodMarca; }
            set { iCodMarca = value; }
        }
        public String Marca
        {
            get { return sMarca; }
            set { sMarca = value; }
        }
        public Int32 CodModelo
        {
            get { return iCodModelo; }
            set { iCodModelo = value; }
        }
        public String Modelo
        {
            get { return sModelo; }
            set { sModelo = value; }
        }
        public Int32 Año
        {
            get { return iAño; }
            set { iAño = value; }
        }
        public String ConstanciaInscripcion
        {
            get { return sConstanciaInscripcion; }
            set { sConstanciaInscripcion = value; }
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
