using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsUnidadEquivalente
    {
        #region propiedades

        private Int32 iCodUnidadEquivalente;
        private Int32 iCodProducto;
        private Int32 iCodUnidad;
        private Decimal dFactor;
        private Int32 iCodUser;
        private DateTime dtFechaRegistro;
        private Decimal precio;
        private Int32 iCodMoneda;

        public Int32 Tipo
        { get; set; }

        public Int32 CodAlmacen
        { get; set; }

        public Decimal Stock
        { get; set; }

        public Int32 CodEquivalente
        { get; set; }

        public Decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Int32 CompraVenta
        { get; set; }

        public Int32 CodUnidadEquivalente
        {
            get { return iCodUnidadEquivalente; }
            set { iCodUnidadEquivalente = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
        public Int32 CodUnidad
        {
            get { return iCodUnidad; }
            set { iCodUnidad = value; }
        }
        public Decimal Factor
        {
            get { return dFactor; }
            set { dFactor = value; }
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

        public Int32 ICodMoneda
        {
            get { return iCodMoneda; }
            set { iCodMoneda = value; }
        }

        #endregion propiedades
    }
}
