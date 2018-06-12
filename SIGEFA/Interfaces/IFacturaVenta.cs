using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    internal interface IFacturaVenta
    {
        Boolean insert(clsFacturaVenta factura_venta);
        Boolean update(clsFacturaVenta factura_venta);
        Boolean updateCobroVenta(clsFacturaVenta factura_venta);
        Boolean delete(Int32 codigoventa);
        Boolean anular(Int32 codigoventa);
        Boolean activar(Int32 codigoventa);
        Boolean rollbackfactura(Int32 codigoventa, Int32 tipo);
        Boolean insertdetalle(clsDetalleFacturaVenta detalle_venta);
        Boolean updatedetalle(clsDetalleFacturaVenta detalle_venta);
        Boolean deletedetalle(Int32 codigodetalle_venta);
        
        Boolean insertdetalleventasalida(Int32 codVen, Int32 codSalida);
        Boolean deletedetalleventasalida();
        Boolean actualizaEstadoImpreso(Int32 codVen);

        clsFacturaVenta fechaCorrelativoAnterior(Int32 codse);
        clsFacturaVenta BuscaFacturaVenta(Int32 codVenta, Int32 codAlmacen);
        clsFacturaVenta CargaFacturaVenta(Int32 codventa);
        clsNotaIngreso BuscaNotaSalida(Int32 codVenta, Int32 codAlmacen);
        DataTable CargaDetalleNotaSalida(Int32 codventa, Int32 codAlmacen);
        Boolean UpdateKardex(Int32 codNota, Int32 codProd, Int32 Codalma, Decimal Cant,Decimal valProm);

        DataTable ListaFacturaVenta(Int32 codalmacen);
        DataTable CargaDetalleVenta(Int32 codventa, Int32 codAlmacen);
        DataTable MuestraCobros(Int32 Estado, Int32 codAlmacen, DateTime Fecha1, DateTime Fecha2, Int32 codTipo);
        DataTable DocumentosPorCliente(Int32 CodCliente);
        DataTable Ventas(Int32 CodAlmacen, DateTime FechaInicio, DateTime FechaFin);
        DataTable MuestraGuiaVenta(Int32 CodAlmacen, Int32 CodCliente);
        DataTable MuestraDetalleGuiaVenta(Int32 CodAlmacen,Int32 codNota);
        DataTable MuestraDetalleGuiaVenta2(Int32 CodAlmacen);
        DataTable MuestraDetalleGuia(Int32 CodAlmacen, Int32 codNota);
        DataTable MuestraDetalleVentaGuia(Int32 codventa, Int32 codalmacen);

        Boolean VistaSucursal(Int32 codventa, Int32 valor);
        DataTable CargaDetalleVentaCredito(int codventa, int codAlmacen);
        Boolean ActualizaPendienteCredito(Decimal monto, Int32 codnota, Int32 codalm, Int32 tipo);
        DataTable ListaNotasDebito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2);
        int chekeaImpresion(Int32 codVenta);
        Boolean actualizaFactura_venta(int CodSerie, string txtSeries, string txtNumeros, string CodVenta);
        DataTable ListaFacturas_ventaCliente(int codcli);

        Boolean updatensconsultext(clsFacturaVenta factura_venta);
        DataTable VentasDiarias(Int32 CodVendedor, Int32 CodAlmacen, DateTime FechaInicio);

        DataTable VentasPendientesdedespacho(Int32 CodAlmacen, DateTime FechaInicio, DateTime FechaFin);

        DataTable CargaDetallexEntregar(Int32 codventa, Int32 codAlmacen);

        Int32 GetCantidadPendiente(Int32 lista);

        Boolean CambiaEstadoDetalle(Int32 codigo);

        Boolean CambiaEstadoFactura(Int32 CodVenta);

        DataTable despachosxventa(Int32 Codfactura);

        Boolean insertventaentregar(clsFacturaVenta factura_venta);

        Boolean insertdetalleventaentregar(clsDetalleFacturaVenta detalle_venta);

        Boolean VentaPendiente(Int32 CodVenta);

        Boolean actualizaEstadoEnvio(Int32 codigo, Int32 codVenta);

        Boolean actualizaEstadoEnvioConError(Int32 codigo, Int32 codVenta);

        Boolean ActualizaBoletaSunat(Int32 codventa);

        Boolean ValidaAnulacionVenta(Int32 codigoventa);
    }
}
