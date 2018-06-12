using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using System.Data;

namespace SIGEFA.Interfaces
{
    interface ICuotaSeparacion
    {
        Boolean Insert(clsCuotasSeparacion cuotasepa);
        DataTable CargaCuotas(Int32 codSeparacion);

        Boolean delete(Int32 idValor);

        clsCuotasSeparacion BuscarCuotasSeparacion(Int32 codSeparacion, Int32 codAlmacen);
    }
}
