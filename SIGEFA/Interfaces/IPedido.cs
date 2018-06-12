using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IPedido
    {
        Boolean insert(clsPedido Pedido);
        Boolean update(clsPedido Pedido);
        Boolean delete(Int32 CodigoPedido);
        Boolean liquidar(Int32 CodigoPedido);

        Boolean insertdetalle(clsDetallePedido Detalle);
        Boolean updatedetalle(clsDetallePedido Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);

        clsPedido CargaPedido(Int32 CodPedido);
        clsPedido BuscaPedido(String CodPedido, Int32 CodAlmacen);
        DataTable CargaDetalle(Int32 CodPedido);
        DataTable CargaDetalleGuia(Int32 CodPedido);
        DataTable ListaPedidos(Int32 user, Int32 CodAlmacen, DateTime desde, DateTime hasta);

        clsPedido CargaEntrega(Int32 CodEntrega);
        DataTable CargaDetalleEntrega(Int32 CodEntrega);
        Boolean insertEntConsExt(clsPedido Pedido);
        DataTable MuestraEntregasConsultorExt(Int32 CodAlmacen, DateTime Fecha1, DateTime Fecha2);
        Boolean insertdetalleconsultor(clsDetallePedido Detalle);
        Boolean updatedetallesalidaconsultext(clsDetallePedido Detalle);
        Boolean deleteEntConsExt(Int32 CodEntConExt);
        Boolean rollbackpedido(Int32 codpedido);
    }
}
