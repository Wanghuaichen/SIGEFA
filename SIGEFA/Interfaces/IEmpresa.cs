using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IEmpresa
    {
        Boolean Insert(clsEmpresa EmpresaNueva);
        Boolean Update(clsEmpresa Empresa);
        Boolean Delete(Int32 CodigoEmp);


        clsEmpresa CargaEmpresa(Int32 CodigoEmp);
        Boolean VerificaRUC(String RUC);
        DataTable CargaEmpresas();//para cargar los combos
        DataTable ListaEmpresas();
        DataTable BuscaEmpresas(Int32 Criterio, String Filtro);

        Boolean UpdateConfiguracion(clsParametros Configuracion);
        clsParametros CargaConfiguracion();

        clsEmpresa CargaEmpresa3(Int32 CodEmpresa);
    }
}
