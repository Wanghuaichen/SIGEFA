using SIGEFA.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIGEFA.Interfaces
{
    interface INotaCredito
    {
        Boolean insert(clsNotaCredito Factura);
        Boolean insertdetalle(clsDetalleNotaCredito Detalle);
        DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);
        clsNotaCredito CargaNotaCredito(Int32 CodNotaCredito);
        DataTable CargaDetalle(Int32 CodNotaCredito);
        List<clsNotaCredito> BuscarNotasXCliente(Int32 codCliente);

        Boolean anular(Int32 codNotaCredito);
        Boolean anularFactura_venta(Int32 codFactura_venta);
        Boolean actualizarCodNotaCreditoFV(Int32 codFactura_venta, Int32 codNota);
        Boolean actualizarStockNotaCredito(Int32 codpro, Double valor);
        
    }
}
