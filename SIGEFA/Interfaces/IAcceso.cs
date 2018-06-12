using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;


namespace SIGEFA.Interfaces
{
    interface IAcceso
    {
        Boolean Insert(clsAccesos NuevoAcceso);
        Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodAlmacen);
        List<Int32> MuestraAccesos(Int32 CodUsuario, Int32 CodAlmacen);
        Boolean InsertAccesoEmp(Int32 CodUsuario,Int32 CodEmpresa, Int32 codUser);
    }
}
