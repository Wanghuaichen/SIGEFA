using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsConciliacionBancaria
    {
        private Int32 codconciliacion;
        private Int32 codconciliacionNuevo;

        public Int32 CodconciliacionNuevo
        {
            get { return codconciliacionNuevo; }
            set { codconciliacionNuevo = value; }
        }

        public Int32 Codconciliacion
        {
            get { return codconciliacion; }
            set { codconciliacion = value; }
        }

        private Int32 codbanco;

        public Int32 Codbanco
        {
            get { return codbanco; }
            set { codbanco = value; }
        }

        private Int32 codcuenta;

        public Int32 Codcuenta
        {
            get { return codcuenta; }
            set { codcuenta = value; }
        }
        private Decimal saldoextracto;

        public Decimal Saldoextracto
        {
            get { return saldoextracto; }
            set { saldoextracto = value; }
        }
        private Decimal montonocobrado;

        public Decimal Montonocobrado
        {
            get { return montonocobrado; }
            set { montonocobrado = value; }
        }
        private Decimal saldolibro;

        public Decimal Saldolibro
        {
            get { return saldolibro; }
            set { saldolibro = value; }
        }
        private Int32 codmoneda;

        public Int32 Codmoneda
        {
            get { return codmoneda; }
            set { codmoneda = value; }
        }
        private Int32 estado;

        public Int32 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private Int32 coduser;

        public Int32 Coduser
        {
            get { return coduser; }
            set { coduser = value; }
        }
        private DateTime fecharegistro;

        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }

    }
}
