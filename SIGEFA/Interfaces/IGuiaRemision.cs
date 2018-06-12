using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IGuiaRemision
    {
        Boolean insert(clsGuiaRemision GuiaRemision);
        Boolean update(clsGuiaRemision GuiaRemision);
        Boolean delete(Int32 CodigoGuiaRemision);

        Boolean insertdetalle(clsDetalleGuiaRemision Detalle);
        Boolean updatedetalle(clsDetalleGuiaRemision Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);
        Boolean insertrelacionguia(Int32 codguia, Int32 codventa, Int32 codalmacen, Int32 codusuario, Int32 codTrans);

        clsGuiaRemision CargaGuiaRemision(Int32 CodGuiaRemision);
        clsGuiaRemision CargaGuiaTransferencia(Int32 cod);
        clsGuiaRemision CargaGuiaVenta(Int32 CodVenta);
        clsGuiaRemision BuscaGuiaRemision(String CodGuiaRemision, Int32 CodAlmacen);

        DataTable CargaDetalle(Int32 CodGuiaRemision);
        DataTable ListaGuiaRemisiones(Int32 CodAlmacen);
        DataTable MuestraGuias(DateTime fecha1, DateTime fecha2);
        DataTable CargaFacturasGuia(Int32 codGuia, Int32 codAlmacen);
    }
}
