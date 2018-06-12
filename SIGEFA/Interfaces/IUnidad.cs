using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IUnidad
    {
        Boolean Insert(clsUnidadMedida NuevaUnidad);
        Boolean Update(clsUnidadMedida Unidad);
        Boolean Delete(Int32 Codigo);

        clsUnidadMedida CargaUnidad(Int32 Codigo);
        DataTable ListaUnidades();
        DataTable MuestraUnidadesEquivalentes();
        Boolean ActualizaPrecioEnDolares();
        Int32 CantidadProductosDolares();

        Int32 ValidaMoneda();
    }
}
