using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;

namespace SIGEFA.Administradores
{
    class clsAdmNotaCreditoCompra
    {

        INotaCreditoCompra nota = new MysqlNotaCreditoCompra();

        public Boolean insert(clsNotaSalida notaS)
        {
            try
            {
                return nota.insert(notaS);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("no se pudo guardar");
                return false;
            }
        }
    }
}
