using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IDosis
    {
        Boolean Insert(clsDosis NuevaDosis);
        Boolean Delete(Int32 Codigo);
        DataTable ListaDosis(Int32 codPro);
    }
}
