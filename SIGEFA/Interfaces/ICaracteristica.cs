using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;


namespace SIGEFA.Interfaces
{
    interface ICaracteristica
    {
        Boolean Insert(clsCaracteristica NuevaCaracteristica);
        Boolean Update(clsCaracteristica Caracteristica);
        Boolean Delete(Int32 Codigo);

        clsCaracteristica CargaCaracteristica(Int32 Codigo);
        DataTable ListaCaracteristicas();
    }
}
