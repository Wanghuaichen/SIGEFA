using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IMarca
    {
        Boolean Insert(clsMarca NuevaMarca);
        Boolean Update(clsMarca Marca);
        Boolean Delete(Int32 Codigo);

        clsMarca CargaMarca(Int32 Codigo);
        DataTable ListaMarcas();
    }
}
