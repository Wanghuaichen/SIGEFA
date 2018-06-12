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
    class clsAdmComposicionQuimica
    {
        IComposicionQuimica MCompQui = new MysqlComposicionQuimica();

        public Boolean insert(clsComposicionQuimica compQuim)
        {
            try
            {
                return MCompQui.Insert(compQuim);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 CodComQui)
        {
            try
            {
                return MCompQui.Delete(CodComQui);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaComposicion(Int32 codPro)
        {
            try
            {
                return MCompQui.ListaComposicion(codPro);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
