using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsDetalleArqueFondoFijo
    {
        private Int32 coddetallearqueofondofijo;

        public Int32 Coddetallearqueofondofijo
        {
            get { return coddetallearqueofondofijo; }
            set { coddetallearqueofondofijo = value; }
        }

        private Int32 coddetallearqueofondofijoNuevo;

        public Int32 CoddetallearqueofondofijoNuevo
        {
            get { return coddetallearqueofondofijoNuevo; }
            set { coddetallearqueofondofijoNuevo = value; }
        }

        private Int32 codarqueofondofijo;

        public Int32 Codarqueofondofijo
        {
            get { return codarqueofondofijo; }
            set { codarqueofondofijo = value; }
        }

        private Int32 coddinero;

        public Int32 Coddinero
        {
            get { return coddinero; }
            set { coddinero = value; }
        }

        private Int32 cantidad;

        public Int32 Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private Decimal importe;

        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
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
