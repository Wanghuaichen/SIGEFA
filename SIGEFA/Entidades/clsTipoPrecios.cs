using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsTipoPrecios
    {
        private Int32 codTipoPrecio;

        public Int32 CodTipoPrecio
        {
            get { return codTipoPrecio; }
            set { codTipoPrecio = value; }
        }
        private Int32 codTipoPrecioNuevo;

        public Int32 CodTipoPrecioNuevo
        {
            get { return codTipoPrecioNuevo; }
            set { codTipoPrecioNuevo = value; }
        }

        private String sigla;

        public String Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }
        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private Int32 User;


        public Int32 User1
        {
            get { return User; }
            set { User = value; }
        }
        private Int32 codAlmacen;

        public Int32 CodAlmacen
        {
            get { return codAlmacen; }
            set { codAlmacen = value; }
        }
    }
}
