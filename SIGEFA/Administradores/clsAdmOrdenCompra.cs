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
    class clsAdmOrdenCompra
    {
        IOrdenCompra MOrden = new MysqlOrdenCompra();

        public Boolean insert(clsOrdenCompra Orden)
        {
            try
            {
                return MOrden.insert(Orden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleOrdenCompra detalle)
        {
            try
            {
                return MOrden.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsOrdenCompra Orden)
        {
            try
            {
                return MOrden.update(Orden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleOrdenCompra detalle)
        {
            try
            {
                return MOrden.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 CodigoOrden)
        {
            try
            {
                return MOrden.delete(CodigoOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular(Int32 CodigoOrden)
        {
            try
            {
                return MOrden.anular(CodigoOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean activar(Int32 CodigoOrden)
        {
            try
            {
                return MOrden.activar(CodigoOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 CodigoOrden)
        {
            try
            {
                return MOrden.deletedetalle(CodigoOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsOrdenCompra CargaOrdenCompra(Int32 CodOrden)
        {
            try
            {
                return MOrden.CargaOrdenCompra(CodOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 CodOrden)
        {
            try
            {
                return MOrden.CargaDetalle(CodOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaOrdenesCompra(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return MOrden.ListaOrdenesCompra(Criterio, CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraOrdenes(Int32 CodAlmacen)
        {
            try
            {
                return MOrden.ListaOrdenes(CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsOrdenCompra BuscaOrden(String CodOrden, Int32 CodAlmacen)
        {
            try
            {
                return MOrden.BuscaOrden(CodOrden, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaOrden()
        {
            try
            {
                return MOrden.ListaOrden();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable StockActualProducto(Int32 CodProducto)
        {
            try
            {
                return MOrden.StockActualProducto(CodProducto);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
