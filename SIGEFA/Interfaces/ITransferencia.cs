using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITransferencia
    {
        // cabecera transferencia directa
        Boolean insert(clsTransferencia transf);
        Boolean update(clsTransferencia transf);
        Boolean delete(Int32 codtrans);
        clsTransferencia CargaTransferencia(Int32 codtrans);
        clsTransferencia BuscaTransferencia(String codtrans, Int32 codAlmacenOrigen);
        DataTable ListaTranferencias(Int32 caso, Int32 user, Int32 codAlmacen, DateTime desde, DateTime hasta);

        // detalle transferencia derecta
        Boolean insertdetalle(clsDetalleTransferencia detalle);
        Boolean updatedetalle(clsDetalleTransferencia detalle);
        Boolean deletedetalle(Int32 coddeta);
        DataTable CargaDetalle(Int32 codTransDir);

        Boolean rechazado(Int32 codTransDirecta, String desc);
        Boolean devuelveproductos(clsDetalleTransferencia det);
        Boolean Aprobar(Int32 codTransDirecta);

        DataTable CargaDetalleGuiaT(String CodigoTransferencia);
    }
}
