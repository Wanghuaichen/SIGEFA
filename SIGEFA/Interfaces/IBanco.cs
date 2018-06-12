using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IBanco
    {
        Boolean Insert(clsBanco NuevaBanco);
        Boolean Update(clsBanco Banco);
        Boolean Delete(Int32 Codigo);

        clsBanco CargaBanco(Int32 Codigo);
        DataTable ListaBancos();
        DataTable CargaBancos();
    }
}
