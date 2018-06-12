using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IPago
    {
        Boolean Insert(clsPago NuevoPago);
        Boolean InsertPagoDetraccion(clsPago pag);//MOD7
        DataTable MuestraListaPagosNota(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo, Int32 codAlmacen);
        DataTable MuestraPagoVentaAnula(Int32 codAlmacen, Int32 nota);
        Boolean AnularPago(Int32 CodigoPago);
        clsPago MuestraPagoVenta(Int32 codAlmacen,Int32 venta);
        DataTable MuestraPagosPorAprobar(Int32 Estado, DateTime Fecha1, DateTime Fecha2);
        DataTable MuestraPagosDetraccion(Int32 Estado, DateTime Fecha1, DateTime Fecha2);//MOD7
        Boolean AprobarPago(Int32 codigo, Int32 valor);
        DataTable MuestraListaPagosNota2(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo);
        Boolean ActualizaPagoAprobado(String ser, String numdoc, Int32 codpag);

        DataTable GetPagosVenta(Int32 codigoalmacen, Int32 codigoventa);
    }
}
