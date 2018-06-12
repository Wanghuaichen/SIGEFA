using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IMetodoPago
    {
        Boolean Insert(clsMetodoPago NuevoMetodoPago);
        Boolean Update(clsMetodoPago MetodoPago);
        Boolean Delete(Int32 Codigo);

        clsMetodoPago CargaMetodoPago(Int32 Codigo);
        clsMetodoPago BuscaMetodoPago(String Codigo);
        DataTable ListaMetodoPagos();
        DataTable CargaMetodoPagos();
    }
}
