using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using SIGEFA.Entidades;

namespace SIGEFA.Administradores
{
    class clsAdmDosis
    {
        IDosis MDos = new MysqlDosis();

        public Boolean insert(clsDosis dosi)
        {
            try
            {
                return MDos.Insert(dosi);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 CodDos)
        {
            try
            {
                
                return MDos.Delete(CodDos);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaDosis(Int32 codPro)
        {
            try
            {
                return MDos.ListaDosis(codPro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
