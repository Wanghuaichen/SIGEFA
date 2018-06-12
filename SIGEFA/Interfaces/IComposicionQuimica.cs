using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IComposicionQuimica
    {
        Boolean Insert(clsComposicionQuimica NuevoComQui);
        Boolean Delete(Int32 codCompQuim);
        DataTable ListaComposicion(Int32 codProducto);
    }
}
