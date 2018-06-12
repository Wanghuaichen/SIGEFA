using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IGrupo
    {
        Boolean Insert(clsGrupo NuevoGrupo);
        Boolean Update(clsGrupo Grupo);
        Boolean Delete(Int32 Codigo);

        clsGrupo CargaGrupo(Int32 Codigo);
        DataTable ListaGrupos(Int32 codLinea);
    }
}
