using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.InterMySql;
using SIGEFA.Interfaces;
using System.Windows.Forms;
using System.Data;

namespace SIGEFA.Administradores
{
    class clsAdmCuotaSeparacion
    {
        ICuotaSeparacion Mcuotas = new MysqlCuotaSeparacion();
        
        public Boolean insert(clsCuotasSeparacion cuotasepa)
        {
            try
            {
                return Mcuotas.Insert(cuotasepa);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaCuotas(Int32 codSeparacion)
        {
            try
            {
                return Mcuotas.CargaCuotas(codSeparacion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean delete(Int32 idValor)
        {
            try
            {
                return Mcuotas.delete(idValor);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsCuotasSeparacion BuscarCuotasSeparacion(Int32 codSeparacion, Int32 codAlmacen)
        {
            try
            {
                return Mcuotas.BuscarCuotasSeparacion(codSeparacion, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
