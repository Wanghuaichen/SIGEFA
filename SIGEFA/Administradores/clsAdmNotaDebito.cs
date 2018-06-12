using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.InterMySql;
using SIGEFA.Interfaces;
using System.Windows.Forms;

namespace SIGEFA.Administradores
{
    class clsAdmNotaDebito
    {
        INotaDebito Mnota = new MysqlNotaDebito();
        public Boolean insert(clsNotaDebito nota)
        {
            try
            {
                return Mnota.insert(nota);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleNotaDebito detalle)
        {
            try
            {
                return Mnota.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean actualizarCodNotaDebitoFV(Int32 codFactura_venta, Int32 codNota)
        {
            try
            {
                return Mnota.actualizarCodNotaDebitoFV(codFactura_venta, codNota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message,
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
