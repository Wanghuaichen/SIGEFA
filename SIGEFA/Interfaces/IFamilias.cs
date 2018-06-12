using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IFamilias
    {
        Boolean Insert(clsFamilia NuevaFamilia);
        Boolean Update(clsFamilia Familia);
        Boolean Delete(Int32 Codigo);

        clsFamilia CargaFamilia(Int32 Codigo);
        DataTable ListaFamilias();
    }
}
