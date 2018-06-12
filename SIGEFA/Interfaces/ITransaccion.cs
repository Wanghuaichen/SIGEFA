using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITransaccion
    {
        Boolean Insert(clsTransaccion NuevaTransaccion);
        Boolean Update(clsTransaccion Transaccion);
        Boolean Delete(Int32 Codigo);

        clsTransaccion CargaTransaccion(Int32 Codigo);
        clsTransaccion CargaTransaccionS(String Sigla, Int32 Tipo);
        DataTable ListaTransacciones(Int32 Caso);

        Boolean InsertConfiguracion(Int32 CodTransaccion, Int32 CodDetalle, Int32 CodUser);
        Boolean LimpiarConfiguracion(Int32 CodTransaccion);
        List<Int32> MuestraConfiguracion(Int32 CodTransaccion);

    }
}
