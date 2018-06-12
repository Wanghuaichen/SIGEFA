using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsPrestamoBancario
    {
        #region propiedades

        private Int32 iCodPrestamoBancario;
        private Int32 iCodBanco;
        private String sDescBanco;
        private Int32 iCodMoneda;
        private String sDescMoneda;
        private Decimal dTipoCambio;
        private Decimal dMontoprestamo;
        private Decimal dMontointeres;
        private Decimal dMontodevolver;
        private Decimal dPendiente;
        private DateTime dtFechaaprobacion;
        private DateTime dtFechavencimiento;
        private String sDescripcion;
        private Boolean bCronograma;
        private Int32 iCancelado;
        private DateTime dtFechacancelado;
        private Int32 iCantCuotas;

        public Int32 CodPrestamoBancario
        {
            get { return iCodPrestamoBancario; }
            set { iCodPrestamoBancario = value; }
        }

        public Int32 CodBanco
        {
            get { return iCodBanco; }
            set { iCodBanco = value; }
        }

        public String DescBanco
        {
            get { return sDescBanco; }
            set { sDescBanco = value; }
        }

        public Int32 CodMoneda
        {
            get { return iCodMoneda; }
            set { iCodMoneda = value; }
        }

        public String DescMoneda
        {
            get { return sDescMoneda; }
            set { sDescMoneda = value; }
        }

        public Decimal TipoCambio
        {
            get { return dTipoCambio; }
            set { dTipoCambio = value; }
        }

        public Decimal Montoprestamo
        {
            get { return dMontoprestamo; }
            set { dMontoprestamo = value; }
        }

        public Decimal Montointeres
        {
            get { return dMontointeres; }
            set { dMontointeres = value; }
        }

        public Decimal Montodevolver
        {
            get { return dMontodevolver; }
            set { dMontodevolver = value; }
        }

        public Decimal Pendiente
        {
            get { return dPendiente; }
            set { dPendiente = value; }
        }

        public DateTime Fechaaprobacion
        {
            get { return dtFechaaprobacion; }
            set { dtFechaaprobacion = value; }
        }

        public DateTime Fechavencimiento
        {
            get { return dtFechavencimiento; }
            set { dtFechavencimiento = value; }
        }

        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }

        public Boolean Cronograma
        {
            get { return bCronograma; }
            set { bCronograma = value; }
        }
        
        public Int32 Cancelado
        {
            get { return iCancelado; }
            set { iCancelado = value; }
        }

        public DateTime Fechacancelado
        {
            get { return dtFechacancelado; }
            set { dtFechacancelado = value; }
        }

        public Int32 CantCuotas
        {
            get { return iCantCuotas; }
            set { iCantCuotas = value; }
        }

        #endregion propiedades
    }
}
