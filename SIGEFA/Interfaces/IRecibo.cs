using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IRecibo
    {
        Boolean Insert(clsRecibos NuevaCajaChica);
        Boolean Update(clsRecibos CajaChica);
        DataTable ListaRecibos(Int32 codSucursal, DateTime fecha1, DateTime fecha2, Int32 tipo);
        DataTable ListaRecibosEgreso(Int32 codSucursal, Int32 tipo);

        Int32 Correlativo(Int32 codtipo);
    }
}
