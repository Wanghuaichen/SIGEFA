using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IOrdenCompra
    {
        Boolean insert(clsOrdenCompra Orden);
        Boolean update(clsOrdenCompra Orden);
        Boolean delete(Int32 CodigoOrden);
        Boolean anular(Int32 CodigoOrden);
        Boolean activar(Int32 CodigoOrden);

        Boolean insertdetalle(clsDetalleOrdenCompra Detalle);
        Boolean updatedetalle(clsDetalleOrdenCompra Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);

        clsOrdenCompra CargaOrdenCompra(Int32 CodOrden);
        DataTable CargaDetalle(Int32 CodOrden);
        DataTable ListaOrdenesCompra(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal);
        DataTable ListaOrdenes(Int32 CodAlmacen);
        DataTable ListaOrden();
        clsOrdenCompra BuscaOrden(String CodOrden, Int32 CodAlmacen);
        DataTable StockActualProducto(Int32 CodProducto);
    }
}
