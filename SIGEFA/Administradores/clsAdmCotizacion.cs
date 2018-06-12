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
    class clsAdmCotizacion
    {
        ICotizacion Mcotizacion = new MysqlCotizacion();

        public Boolean insert(clsCotizacion cotizacion)
        {
            try
            {
                return Mcotizacion.insert(cotizacion);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleCotizacion detalle)
        {
            try
            {
                return Mcotizacion.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsCotizacion cotizacion)
        {
            try
            {
                return Mcotizacion.update(cotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleCotizacion detalle)
        {
            try
            {
                return Mcotizacion.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updateAprobado(Int32 CodCotizacion)
        {
            try
            {
                return Mcotizacion.updateAprobado(CodCotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codcotizacion)
        {
            try
            {
                return Mcotizacion.delete(Codcotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 Codcotizacion)
        {
            try
            {
                return Mcotizacion.deletedetalle(Codcotizacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsCotizacion CargaCotizacion(Int32 CodCotizacion, Int32 CodAlmacen)
        {
            try
            {
                return Mcotizacion.CargaCotizacion(CodCotizacion,CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCotizacion BuscaCotizacion(String CodCotizacion, Int32 CodAlmacen)
        {
            try
            {
                return Mcotizacion.BuscaCotizacion(CodCotizacion, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsDetalleCotizacion CargaDetalleCotizacion(Int32 CodCotizacion, Int32 CodAlmacen)
        {
            try
            {
                return Mcotizacion.CargaDetalleCotizacion(CodCotizacion, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDetalle(Int32 CodCotizacion, Int32 CodAlmacen)
        {
            try
            {
                return Mcotizacion.CargaDetalle(CodCotizacion, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCotizaciones(Int32 CodAlmacen)
        {
            try
            {
                return Mcotizacion.ListaCotizaciones(CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraCotizacionesxVigente(Int32 CodAlmacen, Int32 estado, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return Mcotizacion.ListaCotizacionesxVigente(CodAlmacen, estado, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean CotizacionesVencidas()
        {
            try
            {
                return Mcotizacion.CotizacionesVencidas();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
