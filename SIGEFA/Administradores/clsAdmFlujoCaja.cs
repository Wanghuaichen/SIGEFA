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
    class clsAdmFlujoCaja
    {
        IFlujoCaja Mflu = new MysqlFlujoCaja();

        public Boolean Insert(clsFlujoCaja flujo)
        {
            try
            {
                return Mflu.Insert(flujo);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean Update(clsFlujoCaja flujo)
        {
            try
            {
                return Mflu.Update(flujo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean Delete(Int32 CodFlujoCaja, Int32 CodSucursal)
        {
            try
            {
                return Mflu.Delete(CodFlujoCaja, CodSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public DataTable MuestraFlujoCaja(Int32 CodSucursal)
        {
            try
            {
                return Mflu.ListaFlujosCaja(CodSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsFlujoCaja CargaFlujosCaja(DateTime fecha, Int32 CodSucursal)
        {
            try
            {
                return Mflu.CargaFlujosCaja(fecha, CodSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        // flujo caja SERVICIO //
        public DataTable ListaPagoCobro(Int32 tipo)
        {
            try
            {
                return Mflu.ListaPagoCobro(tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsFlujoCaja VerificaSaldoCaja(Int32 codSucursal)
        {
            try
            {
                return Mflu.VerificaSaldoCaja(codSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 VerificaAperturaCaja(Int32 codSucursal)
        {
            try
            {
                return Mflu.VerificaAperturaCaja(codSucursal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public clsFlujoCaja VerificaDepositoCaja(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                return Mflu.VerificaDepositoCaja(codSucursal,fecha);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
