using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsRepositorio
    {
        private int repoid;

        public int Repoid
        {
            get { return repoid; }
            set { repoid = value; }
        }
        private int tipodoc;

        public int Tipodoc
        {
            get { return tipodoc; }
            set { tipodoc = value; }
        }
        private DateTime fechaemision;

        public DateTime Fechaemision
        {
            get { return fechaemision; }
            set { fechaemision = value; }
        }
        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        private string correlativo;

        public string Correlativo
        {
            get { return correlativo; }
            set { correlativo = value; }
        }
        private decimal monto;

        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private string estadosunat="-1";

        public string Estadosunat
        {
            get { return estadosunat; }
            set { estadosunat = value; }
        }
        private string mensajesunat;

        public string Mensajesunat
        {
            get { return mensajesunat; }
            set { mensajesunat = value; }
        }
        private byte[] pdf;

        public byte[] Pdf
        {
            get { return pdf; }
            set { pdf = value; }
        }
        private byte[] xml;

        public byte[] Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        private int usuario;

        public int Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string nombredoc;

        public string Nombredoc
        {
            get { return nombredoc; }
            set { nombredoc = value; }
        }

        private byte[] cdr;

        public byte[] CDR
        {
            get { return cdr; }
            set { cdr = value; }
        }

        private int codEmpresa;
        public int CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }

        private int codSucursal;
        public int CodSucursal
        {
            get { return codSucursal; }
            set { codSucursal = value; }
        }

        private int codAlmacen;
        public int CodAlmacen
        {
            get { return codAlmacen; }
            set { codAlmacen = value; }
        }

        private int codFacturaVenta;
        public int CodFacturaVenta
        {
            get { return codFacturaVenta; }
            set { codFacturaVenta = value; }
        }
    }
}
