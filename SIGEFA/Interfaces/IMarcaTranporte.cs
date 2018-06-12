using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IMarcaTransporte
    {
        Boolean Insert(clsMarcaTransporte NuevaMarcaTransporte);
        Boolean Update(clsMarcaTransporte MarcaTransporte);
        Boolean Delete(Int32 Codigo);

        clsMarcaTransporte CargaMarcaTransporte(Int32 Codigo);
        DataTable ListaMarcaTransportes();
    }
}
