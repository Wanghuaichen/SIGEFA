using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITarjetaPago
    {
        Boolean Insert(clsTarjetaPago NuevaTarjeta);
        Boolean Update(clsTarjetaPago Tarjeta);
        Boolean Delete(Int32 CodTarjeta, Int32 codAlmacen);

        clsTarjetaPago CargaTarjeta(Int32 CodTarjeta, Int32 codAlmacen);
        DataTable ListaTarjetas(Int32 codAlmacen);
    }
}
