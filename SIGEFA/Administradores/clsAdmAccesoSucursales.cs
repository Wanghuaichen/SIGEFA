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
    class clsAdmAccesoSucursales
    {
        IAccesoSucursales Macce = new MysqlAccesoSucursales();

        public Boolean insert(clsAccesosSucursales acce)
        {
            try
            {
                return Macce.Insert(acce);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodEmpresa)
        {
            try
            {
                return Macce.LimpiarAccesos(CodUsuario, CodEmpresa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public List<Int32> MuestraAccesosSucursales(Int32 CodUsuario, Int32 codEmpresa)
        {
            try
            {
                return Macce.MuestraAccesosSucursales(CodUsuario, codEmpresa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean InsertAccesoEmp(Int32 CodUsuario, Int32 CodEmpresa)
        {
            try
            {
                return Macce.InsertAccesoEmp(CodUsuario,CodEmpresa);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
