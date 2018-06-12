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
using System;

namespace SIGEFA.Administradores
{
    class clsAdmPrestamoBancario
    {
        IPrestamoBancario Mpreban = new MysqlPrestamoBancario();

        public Boolean insert(clsPrestamoBancario preBan)
        {
            try
            {
                return Mpreban.Insert(preBan);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 CodPreBan)
        {
            try
            {
                return Mpreban.Delete(CodPreBan);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraPrestamos()
        {
            try
            {
                return Mpreban.ListaPrestamos();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraPagosPrestamo(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                return Mpreban.MuestraPagosPrestamo(Estado, codEmpresa, Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsPrestamoBancario CargaPrestamoBancario(Int32 CodPreBan)
        {
            try
            {
                return Mpreban.CargaPrestamoBancario(CodPreBan);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

    }
}
