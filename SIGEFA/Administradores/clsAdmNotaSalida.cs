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
    internal class clsAdmNotaSalida
    {
        private INotaSalida Mnota = new MysqlNotaSalida();

        public Boolean insert(clsNotaSalida nota)
        {
            try
            {
                return Mnota.insert(nota);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleNotaSalida detalle)
        {
            try
            {
                return Mnota.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle2(clsDetalleNotaSalida detalle)
        {
            try
            {
                return Mnota.insertdetalle2(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsNotaSalida nota)
        {
            try
            {
                return Mnota.update(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleNotaSalida detalle)
        {
            try
            {
                return Mnota.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codnota)
        {
            try
            {
                return Mnota.delete(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaCantidadPendienteCotizacion(Double cantidad, Int32 produc, Int32 CodCoti){
            try
            {
                return Mnota.ActualizaCantidadPendienteCotizacion(cantidad, produc, CodCoti);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaCantidadPendienteVenta(Double cantidad, Int32 produc, Int32 CodVen)
        {
            try
            {
                return Mnota.ActualizaCantidadPendienteVenta(cantidad, produc, CodVen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool ActualizaCotizacionAprobada(int codCotizacion)
        {
            try
            {
                return Mnota.ActualizaCotizacionAprobada(codCotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool ActualizaCotizacionVigente(int codCotizacion, int codDetalleCotizacion)
        {
            try
            {
                return Mnota.ActualizaCotizacionVigente(codCotizacion, codDetalleCotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular(Int32 Codnota)
        {
            try
            {
                return Mnota.anular(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean activar(Int32 Codnota)
        {
            try
            {
                return Mnota.activar(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 Codnota)
        {
            try
            {
                return Mnota.deletedetalle(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertadetalleventaSalida(Int32 codVenta, Int32 codCoti, Int32 codSalida)
        {
            try
            {
                return Mnota.insertadetalleventaSalida(codVenta,codCoti,codSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean deletedetalleventaSalida()
        {
            try
            {
                return Mnota.deletedetalleventaSalida();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsNotaSalida CargaNotaSalida(Int32 CodNotaSalida)
        {
            try
            {
                return Mnota.CargaNotaSalida(CodNotaSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 CodNotaSalida)
        {
            try
            {
                return Mnota.CargaDetalle(CodNotaSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalleNotaCredito(Int32 CodNotaSalida)
        {
            try
            {
                return Mnota.CargaDetalleNotaCredito(CodNotaSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraNotasSalida(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mnota.ListaNotasSalida(Criterio, CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCobros(Int32 Estado, Int32 codAlmacen, DateTime Fecha1, DateTime Fecha2, Int32 codTipo)
        {
            try
            {
                return Mnota.MuestraCobros(Estado, codAlmacen, Fecha1, Fecha2, codTipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable DocumentosSinGuia(Int32 CodAlmacen, Int32 CodCliente, Int32 Tipo)
        {
            try
            {
                return Mnota.DocumentosSinGuia(CodAlmacen, CodCliente, Tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //public DataTable DocumentosPorCliente(Int32 CodCliente)
        //{
        //    try
        //    {
        //        return Mnota.DocumentosPorCliente(CodCliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
        //            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}
        public DataTable DocumentosPorCliente(Int32 CodCliente, Int32 tipo)
        {
            try
            {
                return Mnota.DocumentosPorCliente(CodCliente, tipo);
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
                return Mnota.Ventas(CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraFacturasVentaCliente(int CodAlmacen, int CodSucursal, int CodEmpresa)
        {
            try
            {
                return Mnota.MuestraFacturasVentaCliente(CodAlmacen, CodSucursal, CodEmpresa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraVentaSalida(int CodAlmacen, int codVenta)
        {
            try
            {
                return Mnota.MuestraVentaSalida(CodAlmacen, codVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCotizacionSalida(Int32 CodAlmacen, Int32 codCotizacion)
        {
            try
            {
                return Mnota.MuestraCotizacionSalida(CodAlmacen, codCotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraTipoDocumentoNota(int CodAlmacen, int codCliente)
        {
            try
            {
                return Mnota.MuestraTipoDocumentoNota(CodAlmacen, codCliente);
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
                return Mnota.deletedetalleventaSalida();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsNotaSalida CargaNotaSalidaCredito(Int32 CodNota)
        {
            try
            {
                return Mnota.CargaNotaSalidaCredito(CodNota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaNotasCreditoCompra(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return Mnota.ListaNotasCreditoCompra(CodAlmacen, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraNotaAlmacen(Int32 codAlmacen, Int32 tipo)
        {
            try
            {
                return Mnota.MuestraNotaAlmacen(codAlmacen, tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalleNotaSalida(Int32 CodNotaSalida, Int32 proceso)
        {
            try
            {
                return Mnota.CargaDetalleNotaSalida(CodNotaSalida, proceso);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsNotaSalida CargaNotaSalidaCreditoVentas(Int32 CodNota)
        {
            try
            {
                return Mnota.CargaNotaSalidaCreditoVentas(CodNota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsNotaSalida CargaNotaSalidaDebitoVentas(Int32 CodNotaSalida)
        {
            try
            {
                return Mnota.CargaNotaSalidaDebitoVentas(CodNotaSalida);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean VerificarNCCompraAplicada(clsNotaSalida nota)
        {
            try
            {
                return Mnota.VerificarNCCompraAplicada(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListarNotaSalidaParaNDCompra(Int32 codAlm, Int32 codProv)
        {
            try
            {
                return Mnota.ListarNotaSalidaParaNDCompra(codAlm, codProv);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalleNotaSalidaNDC(Int32 codNota, Int32 codAlm)
        {
            try
            {
                return Mnota.CargaDetalleNotaSalidaNDC(codNota, codAlm);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean ActualizaNCreditoCompraSinAplicar(clsNotaSalida nota)
        {
            try
            {
                return Mnota.ActualizaNCreditoCompraSinAplicar(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaSalidaDevolucion(Int32 codnota, Int32 codfact)
        {
            try
            {
                return Mnota.ActualizaSalidaDevolucion(codnota, codfact);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Decimal VerificarStock(Int32 codpro, Int32 codalma, Int32 opc)
        {
            try
            {
                return Mnota.VerificarStock(codpro, codalma, opc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        
        public clsNotaSalida CargaNS(Int32 codTransDirecta)
        {
            try
            {
                return Mnota.CargaNS(codTransDirecta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}