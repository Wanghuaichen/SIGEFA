using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;

namespace SIGEFA.Administradores
{
    class clsAdmConciliacionBancaria
    {
        IConciliacionBancaria Macce = new MysqlConciliacionBancaria();
        public Boolean insert(clsConciliacionBancaria acce)
        {
            try
            {
                return Macce.Insert(acce);
            }
            catch (Exception ex)
            {
                //if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleConciliacion dt)
        {
            try
            {
                return Macce.insertdetalle(dt);
            }
            catch (Exception ex)
            {
                //if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion)
        {
            try
            {
                return Macce.Update(codalma, codbanco, codcuenta, CodConciliacion);
            }
            catch (Exception ex)
            {
               // DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public Boolean UpdateBandera(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion)
        {
            try
            {
                return Macce.UpdateBandera(codalma, codbanco, codcuenta, CodConciliacion);
            }
            catch (Exception ex)
            {
                // DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
