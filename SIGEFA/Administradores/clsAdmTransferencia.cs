using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;

namespace SIGEFA.Administradores
{
    class clsAdmTransferencia
    {
        ITransferencia MTrans = new MysqlTransferencia();

        public Boolean insert(clsTransferencia transf)
        {
            try
            {
                return MTrans.insert(transf);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean update(clsTransferencia transf)
        {
            try
            {
                return MTrans.update(transf);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean delete(Int32 Codtrans)
        {
            try
            {
                return MTrans.delete(Codtrans);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public clsTransferencia CargaTransferencia(Int32 Codtrans)
        {
            try
            {
                return MTrans.CargaTransferencia(Codtrans);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsTransferencia BuscaTransferencia(String Codtrans, Int32 CodAlmacenOrigen)
        {
            try
            {
                return MTrans.BuscaTransferencia(Codtrans, CodAlmacenOrigen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraTranferencias(Int32 caso, Int32 user, Int32 CodAlmacen, DateTime desde, DateTime hasta)
        {
            try
            {
                return MTrans.ListaTranferencias(caso, user, CodAlmacen, desde, hasta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //detlle transferencia metodos

        public Boolean insertdetalle(clsDetalleTransferencia detalle)
        {
            try
            {
                return MTrans.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleTransferencia detalle)
        {
            try
            {
                return MTrans.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 Coddeta)
        {
            try
            {
                return MTrans.deletedetalle(Coddeta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaDetalle(Int32 codTransDir)
        {
            try
            {
                return MTrans.CargaDetalle(codTransDir);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        public Boolean rechazado(Int32 codTransDirecta, String desc)
        {
            try
            {
                return MTrans.rechazado(codTransDirecta, desc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean devuelveproductos(clsDetalleTransferencia det)
        {
            try
            {
                return MTrans.devuelveproductos(det);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean Aprobar(Int32 codTransDirecta)
        {
            try
            {
                return MTrans.Aprobar(codTransDirecta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaDetalleGuiaT(String CodigoTransferencia)
        {
            try
            {
                return MTrans.CargaDetalleGuiaT(CodigoTransferencia);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
