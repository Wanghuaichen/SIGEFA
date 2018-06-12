using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ILinea
    {
        Boolean Insert(clsLinea NuevaLinea);
        Boolean Update(clsLinea Linea);
        Boolean Delete(Int32 Codigo);

        clsLinea CargaLinea(Int32 Codigo);
        DataTable ListaLineas(Int32 codFamilia);
    }
}
