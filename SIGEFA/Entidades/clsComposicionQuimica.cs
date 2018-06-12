using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsComposicionQuimica
    {
        # region propiedades

        private Int32 iCodComposion;
        private Int32 iCompQuimicaNuevo;
        private Int32 iCodProducto;
        private String sComponente;
        private String sCantidad;

        public Int32 CompQuimicaNuevo 
        {
            get { return iCompQuimicaNuevo; }
            set { iCompQuimicaNuevo = value; }
        }

        public Int32 CodComposion
        {
            get { return iCodComposion; }
            set { iCodComposion = value; }
        }

        public Int32 CodProducto 
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }

        public String Componente
        {
            get { return sComponente; }
            set { sComponente = value; }
        }

        public String Cantidad
        {
            get { return sCantidad; }
            set { sCantidad = value; }
        }

        # endregion propiedades
    }
}
