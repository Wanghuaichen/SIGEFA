using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsFlujoCaja
    {
        #region propiedades

        private Int32 iCodFlujoCaja;
        private Int32 iCodFlujoCajaNuevo;
        private DateTime dFechaRegistro;
        private Int32 iCodUser;
        
        /************** FLUJO CAJA **************/
        private Int32 iCodSucursal;
        private DateTime dFechaApertura;
        private Decimal dMontoApertura;
        private DateTime dFechaCierre;
        private Decimal dMontoCierre;
        private Decimal dMontoIngresado;
        private Decimal dMontoDepositado;
        private Decimal dMontoDisponible;
        private DateTime dFechaDeposito;
        private Boolean bEstado;
        private Boolean bDeposito;
        

        /************CAJA************/
        private String sConcepto;
        private Decimal dMonto;
        private DateTime dFecha;
        private Int32 iCodAlmacen;
        private Int32 iTipo;
        private Int32 iCodPagoServicio;

        public Int32 CodFlujoCaja
        {
            get { return iCodFlujoCaja; }
            set { iCodFlujoCaja = value; }
        }

        public Int32 CodFlujoCajaNuevo
        {
            get { return iCodFlujoCajaNuevo; }
            set { iCodFlujoCajaNuevo = value; }
        }

        public Int32 CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
        }

        public DateTime FechaApertura
        {
            get { return dFechaApertura; }
            set { dFechaApertura = value; }
        }

        public Decimal MontoApertura
        {
            get { return dMontoApertura; }
            set { dMontoApertura = value; }
        }

        public DateTime FechaCierre
        {
            get { return dFechaCierre; }
            set { dFechaCierre = value; }
        }

        public Decimal MontoCierre
        {
            get { return dMontoCierre; }
            set { dMontoCierre = value; }
        }

        public Decimal MontoIngresado
        {
            get { return dMontoIngresado; }
            set { dMontoIngresado = value; }
        }

        public Decimal MontoDepositado
        {
            get { return dMontoDepositado; }
            set { dMontoDepositado = value; }
        }

        public Decimal MontoDisponible
        {
            get { return dMontoDisponible; }
            set { dMontoDisponible = value; }
        }

        public DateTime FechaDeposito
        {
            get { return dFechaDeposito; }
            set { dFechaDeposito = value; }
        }

        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }

        public Boolean Deposito
        {
            get { return bDeposito; }
            set { bDeposito = value; }
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

        public string Concepto
        {
            get { return sConcepto; }
            set { sConcepto = value; }
        }

        public decimal Monto
        {
            get { return dMonto; }
            set { dMonto = value; }
        }

        public DateTime Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }

        public int CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }

        public int Tipo
        {
            get { return iTipo; }
            set { iTipo = value; }
        }

        public int CodPagoServicio
        {
            get { return iCodPagoServicio; }
            set { iCodPagoServicio = value; }
        }

        #endregion propiedades
    }
}
