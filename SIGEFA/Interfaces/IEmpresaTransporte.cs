using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IEmpresaTranporte
    {
        Boolean Insert(clsEmpresaTransporte NuevoEmpresaTranporte);
        Boolean Update(clsEmpresaTransporte EmpresaTranporte);
        Boolean Delete(Int32 Codigo);

        clsEmpresaTransporte CargaEmpresaTranporte(Int32 Codigo);
        clsEmpresaTransporte BuscaEmpresaTransporte(String RUC);
        DataTable CargaEmpresasTransporte();
        DataTable ListaEmpresaTranportes();
    }
}
