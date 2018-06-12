using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleConsolidado
    {
        #region Propiedades

        private Int32 icodDetalle;
        private Int32 iCodProducto;
        private Double dCantidad;
        private Int32 iCodAlmacen;
        private Int32 iCodUsuario;

        #endregion Propiedades

        public int CodDetalle
        {
            get { return icodDetalle; }
            set { icodDetalle = value; }
        }

        public int CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }

        public double Cantidad
        {
            get { return dCantidad; }
            set { dCantidad = value; }
        }

        public int CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }

        public int CodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
    }
}
