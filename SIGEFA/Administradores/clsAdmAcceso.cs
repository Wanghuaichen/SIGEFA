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
    class clsAdmAcceso
    {
        IAcceso Macce = new MysqlAcceso();

        public Boolean insert(clsAccesos acce)
        {
            try
            {
                return Macce.Insert(acce);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodAlmacen)
        {
            try
            {
                return Macce.LimpiarAccesos(CodUsuario, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public List<Int32> MuestraAccesos(Int32 CodUsuario, Int32 CodAlmacen)
        {
            try
            {
                return Macce.MuestraAccesos(CodUsuario, CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean InsertAccesoEmp(Int32 CodUsuario, Int32 CodEmpresa,Int32 codUser)
        {
            try
            {
                return Macce.InsertAccesoEmp(CodUsuario,CodEmpresa, codUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
