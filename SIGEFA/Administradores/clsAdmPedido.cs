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
    class clsAdmPedido
    {
        IPedido Mpedido = new MysqlPedido();

        public Boolean insert(clsPedido pedido)
        {
            try
            {
                return Mpedido.insert(pedido);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetallePedido detalle)
        {
            try
            {
                return Mpedido.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsPedido pedido)
        {
            try
            {
                return Mpedido.update(pedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetallePedido detalle)
        {
            try
            {
                return Mpedido.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codpedido)
        {
            try
            {
                return Mpedido.delete(Codpedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 Codpedido)
        {
            try
            {
                return Mpedido.deletedetalle(Codpedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsPedido CargaPedido(Int32 CodPedido)
        {
            try
            {
                return Mpedido.CargaPedido(CodPedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsPedido BuscaPedido(String CodPedido, Int32 CodAlmacen)
        {
            try
            {
                return Mpedido.BuscaPedido(CodPedido, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 CodPedido)
        {
            try
            {
                return Mpedido.CargaDetalle(CodPedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalleGuia(Int32 CodPedido)
        {
            try
            {
                return Mpedido.CargaDetalleGuia(CodPedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //public DataTable MuestraPedidos(Int32 CodAlmacen)
        //{
        //    try
        //    {
        //        return Mpedido.ListaPedidos(CodAlmacen);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}

        public clsPedido CargaEntrega(Int32 CodEntrega)
        {
            try
            {
                return Mpedido.CargaEntrega(CodEntrega);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalleEntrega(Int32 CodEntrega)
        {
            try
            {
                return Mpedido.CargaDetalleEntrega(CodEntrega);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean insertEntConsExt(clsPedido pedido)
        {
            try
            {
                return Mpedido.insertEntConsExt(pedido);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraEntregasConsultorExt(Int32 CodAlmacen, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                return Mpedido.MuestraEntregasConsultorExt(CodAlmacen, Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean insertdetalleconsultor(clsDetallePedido detalle)
        {
            try
            {
                return Mpedido.insertdetalleconsultor(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetallesalidaconsultext(clsDetallePedido detalle)
        {
            try
            {
                return Mpedido.updatedetallesalidaconsultext(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deleteEntConsExt(Int32 CodEntConExt)
        {
            try
            {
                return Mpedido.deleteEntConsExt(CodEntConExt);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean liquidar(Int32 Codpedido)
        {
            try
            {
                return Mpedido.liquidar(Codpedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean rollbackpedido(Int32 codpedido)
        {
            try
            {
                return Mpedido.rollbackpedido(codpedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraPedidos(Int32 user, Int32 CodAlmacen, DateTime desde, DateTime hasta)
        {
            try
            {
                return Mpedido.ListaPedidos(user, CodAlmacen, desde, hasta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

    }
}
