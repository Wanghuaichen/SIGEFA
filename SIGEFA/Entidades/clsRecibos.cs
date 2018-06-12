using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsRecibos
    {
        #region propiedades

        private String nombre;
        private String direccion;
        private String dni;
        private Int32 igresoegreso;
        private Int32 correlativo;
        private Int32 codtipopagocajahica;
        private Decimal saldocaja;

        public Decimal Saldocaja
        {
            get { return saldocaja; }
            set { saldocaja = value; }
        }

        public Int32 Codtipopagocajahica
        {
            get { return codtipopagocajahica; }
            set { codtipopagocajahica = value; }
        }

        public Int32 Correlativo
        {
            get { return correlativo; }
            set { correlativo = value; }
        }

        public Int32 Igresoegreso
        {
            get { return igresoegreso; }
            set { igresoegreso = value; }
        }

        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private Int32 iCodRecibos;

        public Int32 CodRecibos
        {
            get { return iCodRecibos; }
            set { iCodRecibos = value; }
        }
        private Int32 iCodRecibosNuevo;

        public Int32 CodRecibosNuevo
        {
            get { return iCodRecibosNuevo; }
            set { iCodRecibosNuevo = value; }
        }
        private String sConcepto;

        public String Concepto
        {
            get { return sConcepto; }
            set { sConcepto = value; }
        }
        private Decimal dMonto;

        public Decimal Monto
        {
            get { return dMonto; }
            set { dMonto = value; }
        }
        private DateTime dtFecha;

        public DateTime Fecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
        private Boolean bEstado;

        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        private Int32 iCodUser;

        public Int32 CodUser
        {
            get { return iCodUser; }
            set { iCodUser = value; }
        }
        private Int32 iCodSucursal;

        public Int32 CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
        }

        private Int32 icodTipoDocumento;

        public Int32 CodTipoDocumento
        {
            get { return icodTipoDocumento; }
            set { icodTipoDocumento = value; }
        }

        private Int32 iCodSerie;

        public Int32 CodSerie
        {
            get { return iCodSerie; }
            set { iCodSerie = value; }
        }
        private String sNumeracion;

        public String Numeracion
        {
            get { return sNumeracion; }
            set { sNumeracion = value; }
        }
        private Boolean bAnulado;

        public Boolean Anulado
        {
            get { return bAnulado; }
            set { bAnulado = value; }
        }
        //**********************************
        private Decimal dMontoPendiente;

        public Decimal MontoPendiente
        {
            get { return dMontoPendiente; }
            set { dMontoPendiente = value; }
        }
        private Decimal dMontoRendido;

        public Decimal MontoRendido
        {
            get { return dMontoRendido; }
            set { dMontoRendido = value; }
        }
        //**********************************
        private Boolean bSustentado;

        public Boolean Sustentado
        {
            get { return bSustentado; }
            set { bSustentado = value; }
        }

        private Int32 iTipoCaja;

        public Int32 TipoCaja
        {
            get { return iTipoCaja; }
            set { iTipoCaja = value; }
        }
        

        #endregion propiedades
    }
}
