using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ILetra
    {
        Boolean Insert(clsLetra NuevoLetra);
        Boolean update(clsLetra Letra);
        Boolean delete(Int32 CodigoLetra);
        clsLetra CargaLetra(Int32 CodLetra);

        DataTable MuestraListaLetrasNota(Int32 CodNotaIngreso);
        Boolean AnularLetra(Int32 CodigoLetra);

        Int32 GetCodigoFactura(Int32 codigonota);
    }
}
