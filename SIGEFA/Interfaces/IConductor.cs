using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IConductor
    {
        Boolean Insert(clsConductor NuevoConductor);
        Boolean Update(clsConductor Conductor);
        Boolean Delete(Int32 Codigo);

        clsConductor CargaConductor(Int32 Codigo);
        DataTable ListaConductores();
        DataTable CargaConductores();
    }
}
