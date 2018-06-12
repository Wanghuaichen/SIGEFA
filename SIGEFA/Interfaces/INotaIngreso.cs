using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface INotaIngreso
    {   
        Boolean insert(clsNotaIngreso Nota);
        Boolean update(clsNotaIngreso Nota);
        Boolean ActualizaCantidadPendiente(Double cantidad, Int32 produc, Int32 CodOrden,Int32 coddeta);
        Boolean ActualizaCantidadPendiente2(Double cantidad, Int32 produc, Int32 alma, Int32 coduser);
        Boolean ActualizaCodNotaIngreso(Double cantidad, Int32 produc, Int32 CodDetalle , Int32 tipo);
        Boolean delete(Int32 CodigoNota);
        Boolean anular(Int32 CodSerie, String NumDoc,String text);
        Boolean anular1(Int32 codigo);
        Boolean activar(Int32 CodigoNota);
        Boolean atender( Int32 codigo, Int32 CodSerie,  String NumDoc ,Int32 User);


        Boolean insertdetalle(clsDetalleNotaIngreso Detalle);
        Boolean insertdetalleConsolidado(Int32 orden,Int32 nota, Int32 codAlma, Int32 codUsu);
        Boolean updatedetalle(clsDetalleNotaIngreso Detalle);        
        Boolean deletedetalle(Int32 CodigoDetalle);
        Boolean deleteConsolidado(Int32 codalma, Int32 codusu);
        clsNotaIngreso CargaNotaIngreso(Int32 CodNota);
        //clsDetalleNotaIngreso ListaOrdenAlmacen(Int32 codAlmacen, Int32 codNota);
        //List<clsDetalleNotaIngreso> GuardaDetalleOrdenAlmacen(Int32 codAlmacen, Int32 codNota);
        DataTable CargaDetalle(Int32 CodNota);
        DataTable ListaNotasIngreso(Int32 Criterio, Int32 CodAlmacen,DateTime FechaInicial, DateTime FechaFinal);
        DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);
        DataTable MuestraPagos(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2);
        DataTable MuestraOrdenAlmacen(Int32 codAlmacen, Int32 codUsu);
        DataTable MuestraNotaIngresoOrden(Int32 codAlmacen, DateTime FechaInicial, DateTime FechaFinal);
        DataTable MuestraTransferenciasVigentes(Int32 CodAlmacen);
        DataTable CargaDetalleTransferencia(Int32 codigotransferencia);
        Boolean UpdateComentario(clsNotaIngreso Nota);
        DataTable MuestraGuia(Int32 codAlmacen, Int32 codUsu);

        DataTable CargaNotaCreditoSinAplicar(Int32 Codcli, Int32 VentComp);
        Boolean ActualizaNCreditoVentaSinAplicar(clsNotaIngreso nota);
        Boolean VerificarNCVentaAplicada(clsNotaIngreso nota);
        DataTable CargaNotaIngresoSD(Int32 Codprov, Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);

        DataTable ListarCodigoNotasSalida();

        Boolean ActualizaStockPA(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI, Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie);
        Boolean ActualizaStockAR(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI, Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie);

        clsNotaIngreso CargaNI(Int32 codTransDirecta);
    }
}
 