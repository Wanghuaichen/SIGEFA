using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IRequerimiento
    {
        Boolean insert(clsRequerimiento Requerimiento);
        Boolean update(clsRequerimiento Requerimiento);
        Boolean delete(Int32 CodigoRequerimiento);
        Boolean envio(Int32 codAlmaDestino, Int32 codreq);
        Boolean Atender(Int32 codreq);
        Boolean rechazado(Int32 CodigoRequerimiento, String comentario);
        Boolean anular(Int32 CodigoRequerimiento);
        Boolean anularDetalle(Int32 CodigoDetalleRequerimiento);
        //Boolean activar(Int32 CodigoRequerimiento);

        Boolean insertdetalleRequerimiento(clsDetalleRequerimiento Detalle);

        Boolean updatedetalleRequerimiento(clsDetalleRequerimiento Detalle);

        Boolean deletedetalle(Int32 CodigoDetalle);

        clsRequerimiento CargaRequerimiento(Int32 CodOrden);

        DataTable CargaDetalle(Int32 codReq);

        DataTable Cargaconsolidado(Int32 codalma,Int32 codprov);

        DataTable cargaRequerimientosTotales(Int32 alma, Int32 almaori);

        DataTable ListaRequerimiento(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal);

        DataTable ListaRequerimientoHistorial(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal );

        DataTable ListaRequerimientoHistorial_x_almacen(Int32 CodAlmacen, Int32 almades, DateTime FechaInicial, DateTime FechaFinal, Int32 tipo);

        Boolean actualiza_det_requerimientos_vigentes(clsDetalleRequerimiento Detalle);

        Boolean actualiza_det_requerimientos_comentario(Int32 coddeta, String coment);

        Boolean actualiza_requerimientos_vigentes(clsRequerimiento Requerimiento);

        DataTable cargaRequerimientosTotales_x_requerimiento(Int32 codrequerimiento_ex);
    }
}
