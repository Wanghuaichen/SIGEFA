using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IZona
    {
        Boolean Insert(clsZona NuevaZona);
        Boolean Update(clsZona Zona);
        Boolean Delete(Int32 Codigo);

        clsZona CargaZona(Int32 Codigo);
        DataTable ListaZonas();

        Boolean InsertDestaque(clsDestaque NuevaDestauque);
        Boolean DeleteDestaque(Int32 Codigo);
        DataTable ListaDestaques();
        DataTable ListaZonaDestaque();
        DataTable CargaZonasReporte();
    }
}
