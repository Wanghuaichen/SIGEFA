using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    internal interface ICotizacion
    {
        Boolean insert(clsCotizacion Cotizacion);
        Boolean update(clsCotizacion Cotizacion);
        Boolean updateAprobado(Int32 CodCotizacion);
        Boolean delete(Int32 CodigoCotizacion);

        Boolean insertdetalle(clsDetalleCotizacion Detalle);
        Boolean updatedetalle(clsDetalleCotizacion Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);

        clsCotizacion CargaCotizacion(Int32 CodCotizacion, Int32 CodAlmacen);
        clsCotizacion BuscaCotizacion(String CodCotizacion, Int32 CodAlmacen);
        clsDetalleCotizacion CargaDetalleCotizacion(Int32 CodCotizacion, Int32 CodAlmacen);
        DataTable CargaDetalle(Int32 CodCotizacion, Int32 CodAlmacen);
        DataTable ListaCotizaciones(Int32 CodAlmacen);
        DataTable ListaCotizacionesxVigente(Int32 CodAlmacen, Int32 estado, DateTime fecha1, DateTime fecha2);
        Boolean CotizacionesVencidas();
    }
}
