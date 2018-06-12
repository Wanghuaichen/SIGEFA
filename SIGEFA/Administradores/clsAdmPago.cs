using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;
using SIGEFA.Formularios;

namespace SIGEFA.Administradores
{
    class clsAdmPago
    {
        IPago Mpag = new MysqlPago();

        public Boolean insert(clsPago pag)
        {
            try
            {
                return Mpag.Insert(pag);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertpagodetraccion(clsPago pag)//MOD7
        {
            try
            {
                return Mpag.InsertPagoDetraccion(pag);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraListaPagosPorNota(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo, Int32 codAlmacen)
        {
            try
            {
                return Mpag.MuestraListaPagosNota(CodNotaIngreso, InOut, Tipo, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean AnularPago(Int32 Codpago)
        {
            try
            {
                return Mpag.AnularPago(Codpago);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsPago MuestraPagoVenta(Int32 codAlmacen, Int32 venta)
        {
            try
            {
                return Mpag.MuestraPagoVenta(codAlmacen, venta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraPagosDetraccion(Int32 Estado, DateTime Fecha1, DateTime Fecha2)//MOD7
        {
            try
            {
                return Mpag.MuestraPagosDetraccion(Estado, Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }   

        public DataTable MuestraPagosPorAprobar(Int32 Estado,DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                return Mpag.MuestraPagosPorAprobar(Estado,   Fecha1,  Fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraPagoVentaAnula(Int32 codAlmacen, Int32 nota)
        {
            try
            {
                return Mpag.MuestraPagoVentaAnula(codAlmacen, nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public Boolean AprobarPago(Int32 codigo, Int32 valor)
        {
            try
            {
                return Mpag.AprobarPago(codigo, valor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraListaPagosPorNota2(Int32 CodNotaIngreso, Boolean InOut, Int32 Tipo)
        {
            try
            {
                return Mpag.MuestraListaPagosNota2(CodNotaIngreso, InOut, Tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean ActualizaPagoAprobado(String ser, String numdoc, Int32 codpag)
        {
            try
            {
                return Mpag.ActualizaPagoAprobado(ser, numdoc, codpag);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable GetPagosVenta(Int32 codigoalmacen, Int32 codigoventa)
        {
            try
            {
                return Mpag.GetPagosVenta(codigoalmacen, codigoventa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
