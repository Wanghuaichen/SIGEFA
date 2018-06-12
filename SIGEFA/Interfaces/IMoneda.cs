using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using System.Data;

namespace SIGEFA.Interfaces
{
    interface IMoneda
    {
        Boolean Insert(clsMoneda NuevaMoneda);
        Boolean Update(clsMoneda Moneda);
        Boolean Delete(Int32 Codigo);

        clsMoneda CargaMoneda(Int32 Codigo);
        DataTable CargaMonedasHabiles();
        DataTable ListaMonedas();
        DataTable CargaPais();
        clsMoneda Buscamoneda(String Moneda);
        Int32 BuscamonedaXdescripcion(String descrip);
    }
}
