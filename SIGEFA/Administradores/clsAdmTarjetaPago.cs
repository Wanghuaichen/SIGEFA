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
    class clsAdmTarjetaPago
    {
        
        ITarjetaPago Mtar = new MysqlTarjetaPago();

        public Boolean Insert(clsTarjetaPago tar)
        {
            try
            {
                return Mtar.Insert(tar);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean Update(clsTarjetaPago tar)
        {
            try
            {
                return Mtar.Update(tar);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean Delete(Int32 Codtar, Int32 CodAlmacen)
        {
            try
            {
                return Mtar.Delete(Codtar, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraTarjetas(Int32 codAlmacen)
        {
            try
            {
                return Mtar.ListaTarjetas(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsTarjetaPago CargaTarjeta(Int32 Codigo, Int32 CodAlmacen)
        {
            try
            {
                return Mtar.CargaTarjeta(Codigo, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
