using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsCuotasSeparacion
    {
        Int32 icodCuota;
        DateTime ifechaRegistro;
        Decimal imonto;
        Int32 icodSeparacion;
        Int32 icodUsuario;
        Decimal itotal;
        //otros
        Int32 icodMoneda;
        Decimal itipoCambio;
        Int32 icodAlmacen;
        Int32 icodSerie;
        String iserie;
        String inumDocumento;
        Int32 icodTipoDocumento;
        String idesdocumento;
        

        public String Desdocumento
        {
            get { return idesdocumento; }
            set { idesdocumento = value; }
        }

        public Int32 CodTipoDocumento
        {
            get { return icodTipoDocumento; }
            set { icodTipoDocumento = value; }
        }

        public String NumDocumento
        {
            get { return inumDocumento; }
            set { inumDocumento = value; }
        }

        public String Serie
        {
            get { return iserie; }
            set { iserie = value; }
        }

        public Int32 CodSerie
        {
            get { return icodSerie; }
            set { icodSerie = value; }
        }

        public Int32 CodAlmacen
        {
            get { return icodAlmacen; }
            set { icodAlmacen = value; }
        }

        public Decimal TipoCambio
        {
            get { return itipoCambio; }
            set { itipoCambio = value; }
        }

        public Int32 CodMoneda
        {
            get { return icodMoneda; }
            set { icodMoneda = value; }
        }

        public Decimal Total
        {
            get { return itotal; }
            set { itotal = value; }
        }

        public Int32 CodUsuario
        {
            get { return icodUsuario; }
            set { icodUsuario = value; }
        }

        public DateTime FechaRegistro
        {
            get { return ifechaRegistro; }
            set { ifechaRegistro = value; }
        }

        public Int32 CodCuota
        {
            get { return icodCuota; }
            set { icodCuota = value; }
        }

        public Decimal Monto
        {
            get { return imonto; }
            set { imonto = value; }
        }

        public Int32 CodSeparacion
        {
            get { return icodSeparacion; }
            set { icodSeparacion = value; }
        }
    }
}
