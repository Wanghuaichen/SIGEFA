using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    class clsCajaChicaMov
    {
        #region propiedades

        private Int32 codMovCaja;        
        private Int32 codSucursal;
        private Int32 codUser;
        private DateTime fecharegistro;       
        private Int32 codcaja;        
        private Int32 codPago;        
        private String concepto;        
        private Decimal monto;
        private Int32 codTipoPagoCaja;
        private Int32 estado;
        private String nombre;
        private String NumDocumento;
        private Decimal toneladas;        
        private Int32 tipo;        
        private Int32 tipomovimiento;
        private DateTime fecha;
        private Int32 codSerie;
        private Int32 tipodocumento;
        private String serie;
        private String dni;
        private Int32 codalmacen;
        private Int32 codmoneda;
        private Decimal tcventa;

        public Decimal Tcventa
        {
            get { return tcventa; }
            set { tcventa = value; }
        }

        public Int32 Codmoneda
        {
            get { return codmoneda; }
            set { codmoneda = value; }
        }

        public Int32 Codalmacen
        {
            get { return codalmacen; }
            set { codalmacen = value; }
        }

        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public Int32 Tipomovimiento
        {
            get { return tipomovimiento; }
            set { tipomovimiento = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Int32 Tipodocumento
        {
            get { return tipodocumento; }
            set { tipodocumento = value; }
        }
        public Int32 CodSerie
        {
            get { return codSerie; }
            set { codSerie = value; }
        }
        public String Serie
        {
            get { return serie; }
            set { serie = value; }
        }        
        public String NumDocumento1
        {
            get { return NumDocumento; }
            set { NumDocumento = value; }
        }
        public Decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Decimal Toneladas
        {
            get { return toneladas; }
            set { toneladas = value; }
        }        
        public Int32 CodTipoPagoCaja
        {
            get { return codTipoPagoCaja; }
            set { codTipoPagoCaja = value; }
        }
        public Int32 Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Int32 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime Fecharegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }
        public Int32 CodMovCaja
        {
            get { return codMovCaja; }
            set { codMovCaja = value; }
        }
        public Int32 CodUser
        {
            get { return codUser; }
            set { codUser = value; }
        }
        public Int32 CodSucursal
        {
            get { return codSucursal; }
            set { codSucursal = value; }
        }
        public Int32 Codcaja
        {
            get { return codcaja; }
            set { codcaja = value; }
        }
        public Int32 CodPago
        {
            get { return codPago; }
            set { codPago = value; }
        }
        public String Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        #endregion propiedades
    }
}
