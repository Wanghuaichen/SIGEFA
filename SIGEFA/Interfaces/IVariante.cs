using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IVariante
    {
        Boolean Insert(clsVariante NuevoVariante);
        Boolean Update(clsVariante Variante);
        Boolean Delete(Int32 Codigo);

        clsVariante CargaVariante(Int32 Codigo);
        DataTable ListaVariantes(Int32 codCaracteristica);
    }
}
