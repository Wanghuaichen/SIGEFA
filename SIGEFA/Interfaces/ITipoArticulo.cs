using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITipoArticulo
    {
        Boolean Insert(clsTipoArticulo NuevaTipoArticulo);
        Boolean Update(clsTipoArticulo TipoArticulo);
        Boolean Delete(Int32 Codigo);

        clsTipoArticulo CargaTipoArticulo(Int32 Codigo);
        DataTable ListaTipoArticulos();
    }
}
