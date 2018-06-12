using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIGEFA.Administradores
{
    class clsAdmNotaCredito
    {
        INotaCredito MNotaC = new MysqlNotaCredito();

        public Boolean insert(clsNotaCredito factura)
        {
            try
            {
                return MNotaC.insert(factura);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        
        public Boolean insertdetalle(clsDetalleNotaCredito detalle)
        {
            try
            {
                return MNotaC.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return MNotaC.ListaNotasCredito(CodAlmacen, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsNotaCredito CargaNotaCredito(Int32 CodNotaCredito)
        {
            try
            {
                return MNotaC.CargaNotaCredito(CodNotaCredito);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 CodNotaCredito)
        {
            try
            {
                return MNotaC.CargaDetalle(CodNotaCredito);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public List<clsNotaCredito> BuscarNotasXCliente(Int32 codCliente)
        {
            try
            {
                return MNotaC.BuscarNotasXCliente(codCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean anular(Int32 codNotaCredito)
        {
            try
            {
                return MNotaC.anular(codNotaCredito);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean anularFactura_venta(Int32 codFacturaVenta)
        {
            try
            {
                return MNotaC.anularFactura_venta(codFacturaVenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualizarCodNotaCreditoFV(Int32 codFactura_venta, Int32 codNota)
        {
            try
            {
                return MNotaC.actualizarCodNotaCreditoFV(codFactura_venta,codNota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualizarStockNotaCredito(Int32 codpro, double valor)
        {
            try
            {
                return MNotaC.actualizarStockNotaCredito(codpro, valor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
