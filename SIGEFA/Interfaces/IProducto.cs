using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IProducto
    {
        Boolean Insert(clsProducto ProductoNuevo);
        Boolean Update(clsProducto Producto);
        Boolean Delete(Int32 Codigo);

        Boolean InsertProductoAlmacen(clsProducto ProductoAlmacenNuevo);
        Boolean UpdateProductoAlmacen(clsProducto ProductoAlmacen);
        Boolean DeleteProductoAlmacen(Int32 CodProductoAlmacen);

        Boolean InsertCaracteristica(clsCaracteristicaProducto CaracNuevo);
        Boolean DeleteCaracteristica(Int32 Codigo);
        DataTable ListaCaracteristicas(Int32 CodProducto);

        Boolean InsertNota(clsNotaProducto NotaProducto);
        Boolean DeleteNota(Int32 Codigo);
        DataTable ListaNotas(Int32 CodProducto);

        Boolean InsertUnidad(clsUnidadEquivalente NuevaUnidad);
        Boolean UpdateUnidad(clsUnidadEquivalente Unidad);
        Boolean DeleteUnidad(Int32 Codigo);


        clsUnidadEquivalente CargaUnidadEquivalente(Int32 Coduni, Int32 Codpro);
        DataTable ListaUnidadesEquivalentesCompra(Int32 CodigoProducto, Int32 codAlmacen);
        DataTable ListaUnidadesEquivalentesVenta(Int32 CodigoProducto, Int32 codAlmacen);
        DataTable ListaUnidadesEquivalentesVenta1(Int32 CodigoProducto, Int32 codAlmacen);
        DataTable ListaUnidadesEquivalentes(Int32 CodigoProducto, Int32 codAlmacen);
        DataTable CargaUnidadesEquivalentes(Int32 CodigoProducto);
        clsPrecioEquivalente PrecioStock(Int32 cmunidad, int CodProducto, int undBase);
        Boolean UpdateUnidadEquivalente(Int32 cod, Decimal precio);

        Int32 getUnidadCompra(Int32 codProd);


        clsProducto CargaProducto(Int32 CodProducto, Int32 CodAlmacen);
        clsProducto CargaProductoDetalle(Int32 CodPro, Int32 CodAlm, Int32 Caso, Int32 Lista);
        clsProducto CargaProductoDetalleCodBarras(String CodProducto, Int32 CodAlmacen, Int32 Caso, Int32 CodLista);
        clsProducto CargaProductoDetalle1(Int32 CodPro, Int32 CodAlm, Int32 Caso, Int32 Lista);
        clsProducto CargaDatosProductoOrden(Int32 CodPro, Int32 CodAlm, Int32 codusu, Decimal cant);
        clsProducto CargaProductoDetalleR(String Referencia, Int32 CodAlm, Int32 Caso, Int32 Lista);
        DataTable ListaProductos(Int32 nivel, Int32 codigo, Int32 CodAlmacen);
        DataTable CatalogoProductos();
        DataTable ListaProductosReporte(Int32 CodAlmacen, Int32 Tipo, Int32 Inicio);
        DataTable RelacionProductosIngreso(Int32 Tipo, Int32 codalma);
        DataTable RelacionIngresoPorProveedor(Int32 Tipo, Int32 codalma, Int32 codproveedor);
        DataTable RelacionProductosSalida(Int32 Tipo, Int32 codalmacen, Int32 codlista);
        DataTable BuscaProductos(Int32 Criterio, String Filtro);
        DataTable ArbolProductos();
        DataTable StockProductoAlmacenes(Int32 codEmpre, Int32 codPro);
        DataTable MuestraProductosProveedor(Int32 codProducto, Int32 codAlmacen);
        clsProducto MuestraProductosTransferencia(Int32 codProducto, Int32 codAlmacen);
        clsProducto MuestraProductosTransferencia_nuevo(Int32 codProducto, Int32 codAlmacen);
        DataTable RelacionProductosCotizacion(Int32 Tipo, Int32 codAlmacen, Int32 codlista);
        Decimal CargaPrecioProducto(Int32 CodProducto, Int32 CodAlmacen,Int32 codmon);
        DataTable MuestraStockAlmacenes();

        DataTable BuscarProducto(Int32 codProducto);
        DataTable RelacionProductos(Int32 codalma);

        List<clsProducto> VentasProductosCount(Int32 CodFac);
        DataTable RelacionVendedor(Int32 CodTipArt, Int32 CodAlmacen, Int32 CodLista, Int32 CodVendedor);
        List<clsProducto> ListaProdConsultor(Int32 CodVendedor);

        Int32 UnidadBase(Int32 codPro, Int32 codalma);
        Decimal FactorProducto(Int32 codPro, Int32 undBase, Int32 undEqui, Int32 tipo);
        String SiglaUnidadBase(Int32 codUnd);
        clsUnidadEquivalente PrecioVenta( Int32 coduni, Int32 codalmacen);
        clsUnidadEquivalente Factor(Int32 codProducto, Int32 codUnidadMedida, Int32 codUnidaEqui);
        clsProducto PrecioPromedio(Int32 codProducto, Int32 codalm);

        Int32 GetCodProducto_xDescripcion(String descripcion);
        Int32 ValidaCodigoUE(Int32 codigo);
        Int32 ValidaCodigoUE(String unidad);
        Int32 ValidaCodigoProducto(Int32 codigo);
        Int32 ValidaCodigoMoneda(Int32 codigo);
        Int32 ValidaCodigoMoneda(String moneda);
        Int32 ValidaTipoPrecio(Int32 codigo);
        Int32 GetCodUnidad(String descripcion);
        Int32 GetCodTipoPrecio(String descripcion);
        Int32 GetCodMoneda(String descripcion);
        Int32 ValidaTipoPrecio(String tipoPrecio);
        Int32 ValidaUnidadEquivalente(Int32 codigo);

        DataTable MuestratipoNC();
    }
}
