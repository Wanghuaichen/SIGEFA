using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsDetalleConciliacion
    {
        private Int32 codconciliacion;
        private Int32 codconciliacionNuevo;
        private Int32 activo_conci;
        private Int32 bandera;
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
        private Int32 codctamovimiento;

        public Int32 Codctamovimiento
        {
            get { return codctamovimiento; }
            set { codctamovimiento = value; }
        }
        private Decimal monto;

        public Decimal Monto
        {
            get { return monto; }
            set { monto = value; }
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
        private Int32 fecharegistro;

        public Int32 Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }
        public Int32 Actico_conci
        {
            get { return activo_conci; }
            set { activo_conci = value; }
        }
        public Int32 Bandera
        {
            get { return bandera; }
            set { bandera = value; }
        }
    }
}
