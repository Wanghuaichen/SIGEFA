using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IVehiculoTransporte
    {
        Boolean Insert(clsVehiculoTransporte NuevoVehiculoTransporte);
        Boolean Update(clsVehiculoTransporte VehiculoTransporte);
        Boolean Delete(Int32 Codigo);

        clsVehiculoTransporte CargaVehiculoTransporte(Int32 Codigo);
        DataTable ListaVehiculoTransportes();
        DataTable CargaVehiculoTransportes();

    }
}
