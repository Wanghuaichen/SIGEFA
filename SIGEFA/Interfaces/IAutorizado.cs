using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IAutorizado
    {
        Boolean Insert(clsAutorizado NuevoAutorizado);
        Boolean Update(clsAutorizado Autorizado);
        Boolean Delete(Int32 Codigo);

        clsAutorizado CargaAutorizado(Int32 Codigo);
        DataTable ListaAutorizados();
    }
}
