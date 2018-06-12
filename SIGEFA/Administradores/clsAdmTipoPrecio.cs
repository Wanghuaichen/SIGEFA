using System;
using System.Collections.Generic;
using System.Linq;
using SIGEFA.Interfaces;
using SIGEFA.Entidades;
using SIGEFA.InterMySql;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SIGEFA.Administradores
{
    class clsAdmTipoPrecio
    {
        ITipoPrecio it = new mysqlTipoPrecios();

        public Boolean insert(clsTipoPrecios tp) {
            try {

              return  it.insert(tp);
            }catch(Exception ex){
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsTipoPrecios tp){
            try {

              return  it.Update(tp);
            }catch(Exception ex){

                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean eliminar(Int32 tp)
        {
            try
            {

              return  it.eliminar(tp);
            }
            catch (Exception ex)
            {

                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public DataTable listaPrecios()
        {
            try
            {

           return     it.ListaPrecios();
            }
            catch (Exception ex)
            {

                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        
    }
}
