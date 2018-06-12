using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ICuota
    {
        Boolean Insert(clsCuota NuevoCuota);
        //Boolean update(clsLetra Letra);
        //Boolean delete(Int32 CodigoLetra);
        clsCuota CargaCuota(Int32 CodCuota);

        DataTable MuestraListaCuotasPrestamo(Int32 CodNotaIngreso);
        //Boolean AnularLetra(Int32 CodigoLetra);
    }
}
