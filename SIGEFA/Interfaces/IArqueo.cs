using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IArqueo
    {
        DataTable ListaArqueos(Int32 opcion1, Int32 opcion2, Int32 mes1, Int32 anio1, Int32 codAlman);
        DataTable ListaDetalleArqueos(Int32 codArq);
        Boolean Insert(clsArqueo NuevoArqueo);
        Boolean InsertDetalle(clsDetalleArqueo NuevoDetalleArqueo);
        Boolean InsertChekeoDetalle(clsDetalleArqueo UpDetalleArqueo, Int32 codArq);
        Boolean Update(clsArqueo UpArqueo);
    }
}
