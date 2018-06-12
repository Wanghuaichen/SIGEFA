using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IListaPrecio
    {
        Boolean Insert(clsListaPrecio NuevaListaPrecio);
        Boolean Update(clsListaPrecio ListaPrecio);
        Boolean Delete(Int32 Codigo);
        Boolean Anular(Int32 codSucursal, Int32 Codigo);
        Boolean Activar(Int32 codSucursal, Int32 Codigo);
        Boolean Updatedetalle(clsDetalleListaPrecio detalle);
        Boolean updatedetallePorFiltro(clsDetalleListaPrecio detalle);

        clsListaPrecio CargaListaPrecio(Int32 Codigo);
        DataTable MuestraListas(Int32 codSucursal);
        DataTable MuestraPreciosProducto(Int32 CodProducto, Int32 codSucursal, Int32 codalma);
        Boolean GeneraPreciosLista(Int32 CodLista, Int32 codalma, Int32 Decimales);
        Boolean GeneraPreciosListaProveedor(Int32 CodLista, Int32 codSucursal, Int32 Decimales, Int32 CodProveedor);
        List<Int32> ListaProductosAlmacen(Int32 codSucursal);
        DataTable CargaListaPrecios(Int32 CodLista);
        List<Int32> MuestraListasProveedor(Int32 codSucursal);
        DataTable MuestraListasPorFiltro(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorProveedor(Int32 codSucursal, Int32 codProv, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorFamilia(Int32 codSucursal, Int32 codFam, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorLinea(Int32 codSucursal, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorRangoProv(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorRangoFam(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codFam, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorProveedorFam(Int32 codSucursal, Int32 codProv, Int32 codFam, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorTodos(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorRangoFamLin(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPorProveedorFamLin(Int32 codSucursal, Int32 codProv, Int32 codFam, Int32 codLin, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaParcial(Int32 codSucursal, Int32 rango1, Int32 rango2, Int32 codProv, Int32 codFam, Int32 listaorigen, Int32 decimales);
        DataTable MuestraListaPrecioxFormaPago(Int32 codSucursal, Int32 codForma);
    }
}
