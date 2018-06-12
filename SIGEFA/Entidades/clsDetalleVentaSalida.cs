using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsDetalleVentaSalida
    {
        #region Propiedades
        public Int32 CodDetalle
        {
            get;
            set;
        }
        public Int32 CodProducto
        {
            get;
            set;
        }

        public Double Cantidad
        {
            get;
            set;
        }


        #endregion Propiedades
    }
}
