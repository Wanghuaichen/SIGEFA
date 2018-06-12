using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.InterMySql;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface INotaCreditoCompra
    {

        Boolean insert(clsNotaSalida notaS);
    }
}
