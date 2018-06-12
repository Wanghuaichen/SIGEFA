using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsArqueoFondoFijo
    {
        private Int32 codarqueofondodijo;

        public Int32 Codarqueofondodijo
        {
            get { return codarqueofondodijo; }
            set { codarqueofondodijo = value; }
        }

        private Int32 codarqueofondodijoNuevo;

        public Int32 CodarqueofondodijoNuevo
        {
            get { return codarqueofondodijoNuevo; }
            set { codarqueofondodijoNuevo = value; }
        }

        private String encargado;

        public String Encargado
        {
            get { return encargado; }
            set { encargado = value; }
        }

        private String horainicio;

        public String Horainicio
        {
            get { return horainicio; }
            set { horainicio = value; }
        }

        private String horafin;

        public String Horafin
        {
            get { return horafin; }
            set { horafin = value; }
        }

        private Decimal total;

        public Decimal Total
        {
            get { return total; }
            set { total = value; }
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

        private Int32 codsucursa;

        public Int32 Codsucursa
        {
            get { return codsucursa; }
            set { codsucursa = value; }
        }
    }
}
