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
    class clsAdmRequerimiento
    {
        IRequerimiento MOrden = new MysqlRequerimiento();

        public Boolean insert(clsRequerimiento Requerimiento)
        {
            try
            {
                return MOrden.insert(Requerimiento);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleRequerimiento detalle)
        {
            try
            {
                return MOrden.insertdetalleRequerimiento(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsRequerimiento Requerimiento)
        {
            try
            {
                return MOrden.update(Requerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleRequerimiento detalle)
        {
            try
            {
                return MOrden.updatedetalleRequerimiento(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 CodigoRequerimiento)
        {
            try
            {
                return MOrden.delete(CodigoRequerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean Envio(Int32 codAlmaDestino, Int32 codreq)
        {
            try
            {
                return MOrden.envio(codAlmaDestino, codreq);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean Atender(Int32 codreq)
        {
            try
            {
                return MOrden.Atender(codreq);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean rechazado(Int32 CodigoRequerimiento, String comentario)
        {
            try
            {
                return MOrden.rechazado(CodigoRequerimiento,comentario);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean anular(Int32 CodigoRequerimiento)
        {
            try
            {
                return MOrden.anular(CodigoRequerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean anularDetalle(Int32 CodigoDetalleRequerimiento)
        {
            try
            {
                return MOrden.anularDetalle(CodigoDetalleRequerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 CodigoRequerimiento)
        {
            try
            {
                return MOrden.deletedetalle(CodigoRequerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
          

        //public Boolean activar(Int32 CodigoRequerimiento)
        //{
        //    try
        //    {
        //        return MOrden.activar(CodigoRequerimiento);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //}
       
        //public Boolean deletedetalle(Int32 CodigoDetalle)
        //{
        //    try
        //    {
        //        return MOrden.deletedetalle(CodigoDetalle);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //}

        public clsRequerimiento CargaRequerimiento(Int32 CodOrden)
        {
            try
            {
                return MOrden.CargaRequerimiento(CodOrden);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable Cargaconsolidado(Int32 codalma, Int32 codprov)
        {
            try
            {
                return MOrden.Cargaconsolidado(codalma, codprov);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable cargaRequerimientosTotales(Int32 alma, Int32 almaori)
        {
            try
            {
                return MOrden.cargaRequerimientosTotales(alma, almaori);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
      
        public DataTable CargaDetalle(Int32 codReq)
        {
            try
            {
                return MOrden.CargaDetalle(codReq);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraRequerimiento(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return MOrden.ListaRequerimiento(CodAlmacen,FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraRequerimientoHistorial(Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return MOrden.ListaRequerimientoHistorial(CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean actualiza_requerimientos_vigentes(clsRequerimiento requerimiento)
        {
            try
            {
                return MOrden.actualiza_requerimientos_vigentes(requerimiento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualiza_det_requerimientos_vigentes(clsDetalleRequerimiento detalle)
        {
            try
            {
                return MOrden.actualiza_det_requerimientos_vigentes(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean actualiza_det_requerimientos_comentario(Int32 coddeta, String coment)
        {
            try
            {
                return MOrden.actualiza_det_requerimientos_comentario(coddeta,coment);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable cargaRequerimientosTotales_x_requerimiento(Int32 codrequerimiento_ex)
        {
            try
            {
                return MOrden.cargaRequerimientosTotales_x_requerimiento(codrequerimiento_ex);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        public DataTable ListaRequerimientoHistorial_x_almacen(Int32 CodAlmacen, Int32 almades, DateTime FechaInicial, DateTime FechaFinal, Int32 tipo)
        {
            try
            {
                return MOrden.ListaRequerimientoHistorial_x_almacen(CodAlmacen,almades, FechaInicial, FechaFinal, tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


    }
}
