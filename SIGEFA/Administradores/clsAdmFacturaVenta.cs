using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIGEFA.Administradores
{
    internal class clsAdmFacturaVenta
    {
        private IFacturaVenta Mventa = new MysqlFacturaVenta();

        public Boolean insert(clsFacturaVenta venta)
        {
            try
            {
                return Mventa.insert(venta);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean rollback(Int32 codventa, Int32 tipo)
        {
            try
            {
                return Mventa.rollbackfactura(codventa, tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleFacturaVenta detalle)
        {
            try
            {
                return Mventa.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsFacturaVenta venta)
        {
            try
            {
                return Mventa.update(venta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updateCobroVenta(clsFacturaVenta venta)
        {
            try
            {
                return Mventa.updateCobroVenta(venta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleFacturaVenta detalle)
        {
            try
            {
                return Mventa.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 codventa)
        {
            try
            {
                return Mventa.delete(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular(Int32 codventa)
        {
            try
            {
                return Mventa.anular(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean activar(Int32 codventa)
        {
            try
            {
                return Mventa.activar(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 codventa)
        {
            try
            {
                return Mventa.deletedetalle(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaEstadoImpreso(Int32 codventa)
        {
            try
            {
                return Mventa.actualizaEstadoImpreso(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsFacturaVenta FechaCorrelativoAnterior(Int32 codserie)
        {
            try
            {
                return Mventa.fechaCorrelativoAnterior(codserie);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        

        public clsFacturaVenta CargaFacturaVenta(Int32 codventa)
        {
            try
            {
                return Mventa.CargaFacturaVenta(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable CargaDetalleNotaSalida(Int32 codventa, Int32 codAlmacen)
        {
            try
            {
                return Mventa.CargaDetalleNotaSalida(codventa, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public Boolean UpdateKardex(Int32 codNota, Int32 codProd, Int32 Codalma, Decimal Cant,Decimal valProm)
        {
            try
            {
                return Mventa.UpdateKardex(codNota, codProd, Codalma, Cant,valProm);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public clsNotaIngreso BuscaNotaSalida(Int32 codVenta, Int32 codAlmacen)
        {
            try
            {
                return Mventa.BuscaNotaSalida(codVenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsFacturaVenta BuscaFacturaVenta(Int32 codVenta, Int32 codAlmacen)
        {
            try
            {
                return Mventa.BuscaFacturaVenta(codVenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaFacturaVenta(Int32 codalmacen)
        {
            try
            {
                return Mventa.ListaFacturaVenta(codalmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 codventa, Int32 codAlmacen)
        {
            try
            {
                return Mventa.CargaDetalleVenta(codventa, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCobrosVenta(Int32 Estado, Int32 codAlmacen, DateTime Fecha1, DateTime Fecha2,
            Int32 codTipo)
        {
            try
            {
                return Mventa.MuestraCobros(Estado, codAlmacen, Fecha1, Fecha2, codTipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable DocumentosPorCliente(Int32 CodCliente)
        {
            try
            {
                return Mventa.DocumentosPorCliente(CodCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable Ventas(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mventa.Ventas(CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean insertdetalleventasalida(Int32 codVen, Int32 codSalida)
        {
            try
            {
                return Mventa.insertdetalleventasalida(codVen, codSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraGuiaVenta(int CodAlmacen, int CodCliente)
        {
            try
            {
                return Mventa.MuestraGuiaVenta(CodAlmacen, CodCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraDetalleGuiaVenta(int CodAlmacen, Int32 codNota)
        {
            try
            {
                return Mventa.MuestraDetalleGuiaVenta(CodAlmacen,codNota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraDetalleGuiaVenta2(int CodAlmacen)
        {
            try
            {
                return Mventa.MuestraDetalleGuiaVenta2(CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean deletedetalleventasalida()
        {
            try
            {
                return Mventa.deletedetalleventasalida();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraDetalleGuia(int CodAlmacen, int codnota)
        {
            try
            {
                return Mventa.MuestraDetalleGuia(CodAlmacen,codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraDetalleVentaGuia(int codventa, int codalmacen)
        {
            try
            {
                return Mventa.MuestraDetalleVentaGuia(codventa, codalmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean VistaSucursal(Int32 codventa, Int32 valor)
        {
            try
            {
                return Mventa.VistaSucursal(codventa, valor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaDetalleVentaCredito(int codventa, int codAlmacen)
        {
            try
            {
                return Mventa.CargaDetalleVentaCredito(codventa, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean ActualizaPendienteCredito(Decimal monto, Int32 codnota, Int32 codalm, Int32 tipo)
        {
            try
            {
                return Mventa.ActualizaPendienteCredito(monto, codnota, codalm, tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaNotasDebito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return Mventa.ListaNotasDebito(CodAlmacen, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public int chekeaImpresion(Int32 codVenta)
        {
            try
            {
                return Mventa.chekeaImpresion(codVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        public Boolean actualizaFactura_venta(int CodSerie, string txtSeries, string txtNumeros, string CodVenta)
        {
            try
            {
                return Mventa.actualizaFactura_venta(CodSerie, txtSeries, txtNumeros, CodVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaFacturas_ventaCliente(int codcli)
        {
            try
            {
                return Mventa.ListaFacturas_ventaCliente(codcli);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean updatensconsultext(clsFacturaVenta venta)
        {
            try
            {
                return Mventa.updatensconsultext(venta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable VentasDiarias(Int32 CodAlmacen, DateTime FechaInicial, Int32 CodVendedor)
        {
            try
            {
                return Mventa.VentasDiarias(CodVendedor, CodAlmacen, FechaInicial);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable VentasPendientesdedespacho(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mventa.VentasPendientesdedespacho(CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetallexEntregar(Int32 codventa, Int32 codAlmacen)
        {
            try
            {
                return Mventa.CargaDetallexEntregar(codventa, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 GetCantidadPendiente(Int32 lista)
        {
            try
            {
                return Mventa.GetCantidadPendiente(lista);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Boolean CambiaEstadoDetalle(Int32 codigo)
        {
            try
            {
                return Mventa.CambiaEstadoDetalle(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean CambiaEstadoFactura(Int32 CodVenta)
        {
            try
            {
                return Mventa.CambiaEstadoFactura(CodVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable despachosxventa(Int32 Codfactura)
        {
            try
            {
                return Mventa.despachosxventa(Codfactura);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean insertventaentregar(clsFacturaVenta venta)
        {
            try
            {
                return Mventa.insertventaentregar(venta);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalleventaentregar(clsDetalleFacturaVenta detalle)
        {
            try
            {
                return Mventa.insertdetalleventaentregar(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }



        public Boolean VentaPendiente(Int32 CodVenta)
        {
            try
            {
                return Mventa.VentaPendiente(CodVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualizaEstadoEnvio(Int32 codigo, Int32 codVenta)
        {
            try
            {
                return Mventa.actualizaEstadoEnvio(codigo, codVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualizaEstadoEnvioConError(Int32 codigo, Int32 codVenta)
        {
            try
            {
                return Mventa.actualizaEstadoEnvioConError(codigo, codVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean ActualizaBoletaSunat(Int32 codventa)
        {
            try
            {
                return Mventa.ActualizaBoletaSunat(codventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ValidaAnulacionVenta(Int32 codigoventa)
        {
            try
            {
                return Mventa.ValidaAnulacionVenta(codigoventa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
