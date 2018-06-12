using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface INotaDebito
    {
        Boolean insert(clsNotaDebito nota);
        Boolean actualizarCodNotaDebitoFV(Int32 codFactura_venta, Int32 codNota);
        Boolean insertdetalle(clsDetalleNotaDebito Detalle);
    }
}
