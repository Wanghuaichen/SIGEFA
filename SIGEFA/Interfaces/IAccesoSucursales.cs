using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SIGEFA.Entidades;


namespace SIGEFA.Interfaces
{
    interface IAccesoSucursales
    {
        Boolean Insert(clsAccesosSucursales NuevoAcceso);
        Boolean LimpiarAccesos(Int32 CodUsuario, Int32 CodEmpresa);
        List<Int32> MuestraAccesosSucursales(Int32 CodUsuario, Int32 codEmpresa);
        Boolean InsertAccesoEmp(Int32 CodUsuario,Int32 CodEmpresa);
    }
}
