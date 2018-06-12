using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsDetalleArqueo
    {
        private Int32 iCodDetalle;

        public Int32 ICodDetalle
        {
            get { return iCodDetalle; }
            set { iCodDetalle = value; }
        }
        private Int32 iCodUsuario;

        public Int32 ICodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
        private Int32 iCodArqueo;

        public Int32 ICodArqueo
        {
            get { return iCodArqueo; }
            set { iCodArqueo = value; }
        }
        private Int32 iCodProducto;

        public Int32 ICodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
        private Decimal dStockS;

        public Decimal DStockS
        {
            get { return dStockS; }
            set { dStockS = value; }
        }
        private Decimal dStockF;

        public Decimal DStockF
        {
            get { return dStockF; }
            set { dStockF = value; }
        }
        private Decimal dDiferencia;

        public Decimal DDiferencia
        {
            get { return dDiferencia; }
            set { dDiferencia = value; }
        }
        private Int32 iEstado;

        public Int32 IEstado
        {
            get { return iEstado; }
            set { iEstado = value; }
        }
        private String sObservacion;

        public String SObservacion
        {
            get { return sObservacion; }
            set { sObservacion = value; }
        }
        private DateTime dFechaRegistro;

        public DateTime DFechaRegistro
        {
            get { return dFechaRegistro; }
            set { dFechaRegistro = value; }
        }

        private DateTime dFechaChekeo;

        public DateTime DFechaChekeo
        {
            get { return dFechaChekeo; }
            set { dFechaChekeo = value; }
        }

      
        private Int32 iCodAlma;

        public Int32 ICodAlma
        {
            get { return iCodAlma; }
            set { iCodAlma = value; }
        }
    }
}
