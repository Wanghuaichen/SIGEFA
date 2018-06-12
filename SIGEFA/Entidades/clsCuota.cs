using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsCuota
    {
        #region propiedades
        private Int32 iCodCuotaPrestamo;
        private Int32 iCodPrestamoBancario;
        private Int32 iNroCuota;
        private DateTime dtFechaEmision;
        private DateTime dtFechaVencimiento;
        private DateTime dtFechaCancelado;
        private Int32 iCodMoneda;
        private String sDescMoneda;
        private Decimal dTipoCambio;
        private Decimal dMonto;
        private Decimal dMontoPendiente;
        private Decimal dMontoadicional;
        private Boolean bCancelado;
        private Boolean bEstado;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;

        public Int32 CodCuotaPrestamo
        {
            get { return iCodCuotaPrestamo; }
            set { iCodCuotaPrestamo = value; }
        }

        public Int32 CodPrestamoBancario
        {
            get { return iCodPrestamoBancario; }
            set { iCodPrestamoBancario = value; }
        }

        public Int32 NroCuota
        {
            get { return iNroCuota; }
            set { iNroCuota = value; }
        }

        public DateTime FechaEmision
        {
            get { return dtFechaEmision; }
            set { dtFechaEmision = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return dtFechaVencimiento; }
            set { dtFechaVencimiento = value; }
        }
        
        public DateTime FechaCancelado
        {
            get { return dtFechaCancelado; }
            set { dtFechaCancelado = value; }
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

        public Decimal Monto
        {
            get { return dMonto; }
            set { dMonto = value; }
        }
        public Decimal MontoPendiente
        {
            get { return dMontoPendiente; }
            set { dMontoPendiente = value; }
        }

        public Decimal Montoadicional
        {
            get { return dMontoadicional; }
            set { dMontoadicional = value; }
        }

        public Boolean Cancelado
        {
            get { return bCancelado; }
            set { bCancelado = value; }
        }

        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
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
