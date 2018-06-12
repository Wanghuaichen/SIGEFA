using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IFormaPago
    {
        Boolean Insert(clsFormaPago NuevoFormaPago);
        Boolean Update(clsFormaPago FormaPago);
        Boolean Delete(Int32 Codigo);

        clsFormaPago CargaFormaPago(Int32 Codigo);
        clsFormaPago BuscaFormaPago(String Codigo);
        DataTable ListaFormaPagos();
        DataTable CargaFormaPagos(Int32 tip);
        DataTable CargaFormaPagosReportes();
        clsFormaPago BuscaFormaPagoVenta(Int32 Codigo);

        DataTable CargaFormaPagosCuotas();
    }
}
