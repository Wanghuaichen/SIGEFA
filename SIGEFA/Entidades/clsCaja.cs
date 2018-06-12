using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsCaja
    {
        #region propiedades

        private Int32 codcaja;
        private Int32 codcajaNuevo;
        private Int32 codsucursal;
        private Int32 tipo;
        private Decimal montoapertura;
        private Decimal montocierre;
        private DateTime fechaapertura;
        private DateTime fechacierre;
        private Decimal totalIngreso;
        private Decimal totalEgreso;
        private Decimal totalVentaEfectivo;
        private Decimal totalDisponible;
        private Int32 codUser;
        private Boolean estado;
        private Decimal totalventacredito;
        private Decimal totalcheque;
        private Decimal totaltarnsferencia;
        private Decimal totalcobranza;
        private Decimal totaldeposito;
        private Int32 codalmacen;

        public Int32 Codalmacen
        {
            get { return codalmacen; }
            set { codalmacen = value; }
        }

        public Decimal Totaldeposito
        {
            get { return totaldeposito; }
            set { totaldeposito = value; }
        }

        public Decimal Totalcobranza
        {
            get { return totalcobranza; }
            set { totalcobranza = value; }
        }

        public Decimal Totaltarnsferencia
        {
            get { return totaltarnsferencia; }
            set { totaltarnsferencia = value; }
        }

        public Decimal Totalcheque
        {
            get { return totalcheque; }
            set { totalcheque = value; }
        }

        public Decimal Totalventacredito
        {
            get { return totalventacredito; }
            set { totalventacredito = value; }
        }

        public Int32 Codcaja
        {
            get { return codcaja; }
            set { codcaja = value; }
        }

        public Int32 CodcajaNuevo
        {
            get { return codcajaNuevo; }
            set { codcajaNuevo = value; }
        }

        public Int32 Codsucursal
        {
            get { return codsucursal; }
            set { codsucursal = value; }
        }

        public Int32 Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Decimal Montoapertura
        {
            get { return montoapertura; }
            set { montoapertura = value; }
        }

        public Decimal Montocierre
        {
            get { return montocierre; }
            set { montocierre = value; }
        }

        public DateTime Fechaapertura
        {
            get { return fechaapertura; }
            set { fechaapertura = value; }
        }

        public DateTime Fechacierre
        {
            get { return fechacierre; }
            set { fechacierre = value; }
        }

        public Decimal TotalIngreso
        {
            get { return totalIngreso; }
            set { totalIngreso = value; }
        }

        public Decimal TotalEgreso
        {
            get { return totalEgreso; }
            set { totalEgreso = value; }
        }

        public Decimal TotalVentaEfectivo
        {
            get { return totalVentaEfectivo; }
            set { totalVentaEfectivo = value; }
        }

        public Decimal TotalDisponible
        {
            get { return totalDisponible; }
            set { totalDisponible = value; }
        }

        public Int32 CodUser
        {
            get { return codUser; }
            set { codUser = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion propiedades
    }
}
