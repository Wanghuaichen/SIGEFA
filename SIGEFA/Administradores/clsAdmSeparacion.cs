using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System.Windows.Forms;
using System.Data;

namespace SIGEFA.Administradores
{
    class clsAdmSeparacion
    {
        ISeparacion Msepa = new MysqlSeparacion();

        public Boolean insert(clsSeparacion sepa)
        {
            try
            {
                return Msepa.insert(sepa);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargarVentas(Int32 codAlmacen, DateTime desde, DateTime hasta, Int32 estado)
        {
            try
            {
                return Msepa.CargarVentas(codAlmacen, desde, hasta, estado);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsSeparacion BuscarSeparacion(Int32 id, Int32 CodAlmacen)
        {
            try
            {
                return Msepa.BuscarSeparacion(id, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }



        public Boolean InsertarDetalleSepa(clsDetalleSeparacionVenta detalle)
        {
            try
            {
                return Msepa.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsSeparacion BuscarSeparacionXid(Int32 codSeparacion, Int32 CodAlmacen)
        {
            try
            {
                return Msepa.BuscarSeparacionXid(codSeparacion, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 codSeparacion)
        {
            try
            {
                return Msepa.CargaDetalle(codSeparacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }



        public Boolean anular(Int32 codSeparacion )
        {
            try
            {
                return Msepa.anular(codSeparacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Double CargarTotalSeparacion(Int32 cod_almacen)
        {
            try
            {
                return Msepa.CargaSeparacion(cod_almacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
    }
}
