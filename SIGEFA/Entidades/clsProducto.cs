using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsProducto
    {

        #region propiedades

        private Int32 iCodProducto;        
        private Int32 iCodProductoAlmacen;
        private Int32 iCodAlmacen;
        private Int32 iCodUsuario;
        private Int32 iCodGrupo;
        private Int32 iCodLinea;
        private Int32 iCodFamilia;
        private Int32 iCodUnidadMedida;
        private Int32 iCodTipoArticulo;
        private Int32 iCodMarca;
        private Int32 iCodControlStock;
        private String sReferencia;
        private String sDescripcion;
        private Decimal dPrecioCatalogo;
        private Double dValorProm;
        private Decimal dPrecioProm;
        private Double dRecargo;
        private Double dValorVenta;
        private Double dPrecioVenta;
        private Double dPrecioVentaSoles;    
        private Double dPDescuento;
        private Double dMontoDscto;
        private Double dPrecioOferta;       
        private Double dMaximoDscto;
        private Double dStockActual;
        private Decimal dStockDisponible;
        private Double dStockMinimo;
        private Double dStockMaximo;
        private Double dStockReposicion;
        private Double dSoles;
        private Double dTotalIngresos;
        private Double dTotalSalidas;
        private Double dTotalSolesIngresos;
        private Double dTotalSolesSalidas;
        private Int32 tipoImpuesto;
        private Boolean bDetraccion;        
        private Boolean bEstado;
        private Boolean bOferta;
        private Boolean bConIGV;
        private Boolean bPrecioVariable;
        private DateTime dtUltimaModificacion;
        private DateTime dtFechaRegistro;
        private String sUnidaddescrip;
        private Decimal dComision;
        private Decimal dstockFuturo;
        private Decimal dstockPorRecibir;
        private Decimal dvalorPromsoles;
        private Decimal dMaxPorcDesc;
        private Int32 iPorllegar;
        private Int32 iPorAtender;
        private Int32 iPorCompletar;
        private Int32 icantidad;
        private Decimal dPeso;
        private Decimal preciocompra;
        private String codSunat;

        public String CodSunat
        {
            get { return codSunat; }
            set { codSunat = value; }
        }
        public Decimal PrecioCompra
        {
            get { return preciocompra; }
            set { preciocompra = value; }
        }
        public Int32 Cantidad
        {
            get { return icantidad; }
            set { icantidad = value; }
        }
        public Int32 Porllegar
        {
            get { return iPorllegar; }
            set { iPorllegar = value; }
        }
        public Int32 PorAtender
        {
            get { return iPorAtender; }
            set { iPorAtender = value; }
        }
        public Int32 PorCompletar
        {
            get { return iPorCompletar; }
            set { iPorCompletar = value; }
        }
        public Decimal MaxPorcDesc
        {
            get { return dMaxPorcDesc; }
            set { dMaxPorcDesc = value; }
        }
        public Decimal StockPorRecibir
        {
            get { return dstockPorRecibir; }
            set { dstockPorRecibir = value; }
        }
        public Decimal StockFuturo
        {
            get { return dstockFuturo; }
            set { dstockFuturo = value; }
        }
        public Int32 CodProductoAlmacen
        {
            get { return iCodProductoAlmacen; }
            set { iCodProductoAlmacen = value; }
        }
        public Int32 CodProducto
        {
            get { return iCodProducto; }
            set { iCodProducto = value; }
        }
        public Int32 CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }
        public Int32 CodUsuario
        {
            get { return iCodUsuario; }
            set { iCodUsuario = value; }
        }
        public Int32 CodGrupo
        {
            get { return iCodGrupo; }
            set { iCodGrupo = value; }
        }
        public Int32 CodLinea
        {
            get { return iCodLinea; }
            set { iCodLinea = value; }
        }
        public Int32 CodFamilia
        {
            get { return iCodFamilia; }
            set { iCodFamilia = value; }
        }
        public Int32 CodMarca
        {
            get { return iCodMarca; }
            set { iCodMarca = value; }
        }
        public Int32 CodUnidadMedida
        {
            get { return iCodUnidadMedida; }
            set { iCodUnidadMedida = value; }
        }
        public Int32 CodTipoArticulo
        {
            get { return iCodTipoArticulo; }
            set { iCodTipoArticulo = value; }
        }
        public Int32 CodControlStock
        {
            get { return iCodControlStock; }
            set { iCodControlStock = value; }
        }
        public String Referencia
        {
            get { return sReferencia; }
            set { sReferencia = value; }
        }
        public Decimal PrecioCatalogo
        {
            get { return dPrecioCatalogo; }
            set { dPrecioCatalogo = value; }
        }
        public String Descripcion
        {
            get { return sDescripcion; }
            set { sDescripcion = value; }
        }
        public Boolean ConIgv
        {
            get { return bConIGV; }
            set { bConIGV = value; }
        }
        public Double ValorProm
        {
            get { return dValorProm; }
            set { dValorProm = value; }
        }
        public Decimal PrecioProm
        {
            get { return dPrecioProm; }
            set { dPrecioProm = value; }
        }
        public Double Recargo
        {
            get { return dRecargo; }
            set { dRecargo = value; }
        }
        public Double ValorVenta
        {
            get { return dValorVenta; }
            set { dValorVenta = value; }
        }
        public Double PrecioVenta
        {
            get { return dPrecioVenta; }
            set { dPrecioVenta = value; }
        }
        public Double PrecioVentaSoles
        {
            get { return dPrecioVentaSoles; }
            set { dPrecioVentaSoles = value; }
        }
        public Boolean Oferta
        {
            get { return bOferta; }
            set { bOferta = value; }
        }       
        public Double PDescuento
        {
            get { return dPDescuento; }
            set { dPDescuento = value; }
        }
        public Double MontoDscto
        {
            get { return dMontoDscto; }
            set { dMontoDscto = value; }
        }
        public Double PrecioOferta
        {
            get { return dPrecioOferta; }
            set { dPrecioOferta = value; }
        }
        public Boolean PrecioVariable
        {
            get { return bPrecioVariable; }
            set { bPrecioVariable = value; }
        }
        public Double MaximoDscto
        {
            get { return dMaximoDscto; }
            set { dMaximoDscto = value; }
        }
        public Double StockActual
        {
            get { return dStockActual; }
            set { dStockActual = value; }
        }
        public Decimal StockDisponible
        {
            get { return dStockDisponible; }
            set { dStockDisponible = value; }
        }
        public Double StockMinimo
        {
            get { return dStockMinimo; }
            set { dStockMinimo = value; }
        }
        public Double StockMaximo
        {
            get { return dStockMaximo; }
            set { dStockMaximo = value; }
        }
        public Double StockReposicion
        {
            get { return dStockReposicion; }
            set { dStockReposicion = value; }
        }
        public Double Soles
        {
            get { return dSoles; }
            set { dSoles = value; }
        }
        public Double TotalIngresos
        {
            get { return dTotalIngresos; }
            set { dTotalIngresos = value; }
        }
        public Double TotalSalidas
        {
            get { return dTotalSalidas; }
            set { dTotalSalidas = value; }
        }
        public Double TotalSolesIngresos
        {
            get { return dTotalSolesIngresos; }
            set { dTotalSolesIngresos = value; }
        }
        public Double TotalSolesSalidas
        {
            get { return dTotalSolesSalidas; }
            set { dTotalSolesSalidas = value; }
        }
        public Int32 TipoImpuesto
        {
            get { return tipoImpuesto; }
            set { tipoImpuesto = value; }
        }
        public Boolean Detraccion
        {
            get { return bDetraccion; }
            set { bDetraccion = value; }
        }
        public Boolean Estado
        {
            get { return bEstado; }
            set { bEstado = value; }
        }
        public DateTime UltimaModificacion
        {
            get { return dtUltimaModificacion; }
            set { dtUltimaModificacion = value; }
        }
        public DateTime FechaRegistro
        {
            get { return dtFechaRegistro; }
            set { dtFechaRegistro = value; }
        }
        public String UnidadDescrip
        {
            get { return sUnidaddescrip; }
            set { sUnidaddescrip = value; }
        }
        public Decimal Comision
        {
            get { return dComision; }
            set { dComision = value; }
        }

        public decimal ValorPromsoles
        {
            get { return dvalorPromsoles; }
            set { dvalorPromsoles = value; }
        }

        public Decimal Peso
        {
            get { return dPeso; }
            set { dPeso = value; }
        }

        #endregion propiedades
    }
}
