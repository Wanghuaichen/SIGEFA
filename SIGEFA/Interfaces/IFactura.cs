using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IFactura
    {
        Boolean insert(clsFactura Factura);
        Boolean update(clsFactura Factura);
        Boolean delete(String CodigoFactura);
        Boolean anular(Int32 CodigoFactura);
        Boolean activar(String CodigoFactura);

        Boolean insertdetalle(clsDetalleFactura Detalle);
        Boolean updatedetalle(clsDetalleFactura Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);

        clsFactura CargaFactura(Int32 CodFactura);
        DataTable CargaDetalle(Int32 CodFactura);
        DataTable ListaFactura(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal);
        DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);
        DataTable MuestraPagos(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2);
        DataTable ListaFactura(DateTime FechaInicial, DateTime FechaFinal, Int32 alma);
        DataTable MuestraFacturasProveedor(int alma, int codprom, Int32 tipo);

        Boolean ActualizaPendienteCreditoCompra(Double monto, Int32 codcompra, Int32 codalm);
        DataTable ListaNotasDebitoCompra(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);
    }
}
