using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IArqueoFondoFijo
    {
        Boolean Insert(clsArqueoFondoFijo NuevoArqueo);

        Boolean insertDetalle(clsDetalleArqueFondoFijo det);

        DataTable ListaDinero(Int32 tipo);

        Decimal TraeValor(Int32 codigo);
    }
}
