using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using System.Data;

namespace SIGEFA.Interfaces
{
    interface ISeparacion
    {

        Boolean insert(clsSeparacion sepa);
        DataTable CargarVentas(Int32 codAlmacen, DateTime desde, DateTime hasta, Int32 estado);
        clsSeparacion BuscarSeparacion(Int32 id, Int32 CodAlmacen);

        Boolean insertdetalle(clsDetalleSeparacionVenta detalle);

        clsSeparacion BuscarSeparacionXid(Int32 codSeparacion, Int32 CodAlmacen);

        DataTable CargaDetalle(Int32 codSeparacion);



        Boolean anular(Int32 codSeparacion);

        Double CargaSeparacion(Int32 cod_alamcen);
    }
}
