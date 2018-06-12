using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    internal interface INotaSalida
    {
        Boolean insert(clsNotaSalida Nota);
        Boolean update(clsNotaSalida Nota);
        Boolean delete(Int32 CodigoNota);
        Boolean anular(Int32 CodigoNota);
        Boolean activar(Int32 CodigoNota);
        Boolean ActualizaCantidadPendienteCotizacion(Double cantidad, Int32 produc, Int32 CodCoti);
        Boolean ActualizaCantidadPendienteVenta(Double cantidad, Int32 produc, Int32 CodVen);
        Boolean ActualizaCotizacionAprobada(Int32 codCotizacion);
        Boolean ActualizaCotizacionVigente(Int32 codCotizacion, Int32 codDetalleCotizacion);
        Boolean insertdetalle(clsDetalleNotaSalida Detalle);
        Boolean updatedetalle(clsDetalleNotaSalida Detalle);
        Boolean deletedetalle(Int32 CodigoDetalle);
        Boolean insertdetalle2(clsDetalleNotaSalida Detalle);
        Boolean insertadetalleventaSalida(Int32 codVenta, Int32 codCoti, Int32 codSalida);
        Boolean deletedetalleventaSalida();

        clsNotaSalida CargaNotaSalida(Int32 CodNota);
        DataTable CargaDetalle(Int32 CodNota);
        DataTable CargaDetalleNotaCredito(Int32 CodNota);
        DataTable ListaNotasSalida(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal);
        DataTable MuestraCobros(Int32 Estado, Int32 codAlmacen, DateTime Fecha1, DateTime Fecha2, Int32 codTipo);
        DataTable DocumentosSinGuia(Int32 CodAlmacen, Int32 CodCliente, Int32 Tipo);
        //DataTable DocumentosPorCliente(Int32 CodCliente);
        DataTable DocumentosPorCliente(Int32 CodCliente, Int32 tipo);
        DataTable Ventas(Int32 CodAlmacen, DateTime FechaInicio, DateTime FechaFin);
        DataTable MuestraFacturasVentaCliente(Int32 CodAlmacen, Int32 CodSucursal, Int32 CodEmpresa);
        DataTable MuestraVentaSalida(Int32 CodAlmacen, Int32 codVenta);
        DataTable MuestraCotizacionSalida(Int32 CodAlmacen, Int32 codCotizacion);
        DataTable MuestraTipoDocumentoNota(Int32 CodAlmacen, Int32 codCliente);

        clsNotaSalida CargaNotaSalidaCredito(Int32 CodNota);
        DataTable ListaNotasCreditoCompra(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);

        DataTable MuestraNotaAlmacen(Int32 codAlmacen, Int32 tipo);
        DataTable CargaDetalleNotaSalida(Int32 codNota, Int32 proceso);

        clsNotaSalida CargaNotaSalidaCreditoVentas(Int32 CodNota);
        clsNotaSalida CargaNotaSalidaDebitoVentas(Int32 CodNota);
        Boolean VerificarNCCompraAplicada(clsNotaSalida nota);
        DataTable ListarNotaSalidaParaNDCompra(Int32 codAlm, Int32 codProv);
        DataTable CargaDetalleNotaSalidaNDC(Int32 codNota, Int32 codAlm);
        Boolean ActualizaNCreditoCompraSinAplicar(clsNotaSalida nota);
        Boolean ActualizaSalidaDevolucion(Int32 codnota, Int32 codfact);

        Decimal VerificarStock(Int32 codpro, Int32 codalma, Int32 opc);

        clsNotaSalida CargaNS(Int32 codTransDirecta);
    }
}
