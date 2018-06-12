using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ISucursal
    {
        Boolean Insert(clsSucursal SucursalNueva);
        Boolean Update(clsSucursal Sucursal);
        Boolean Delete(Int32 CodigoSuc);


        clsSucursal CargaSucursal(Int32 CodigoSuc);
        Boolean VerificaRUC(String RUC);
        DataTable CargaSucursales(Int32 Codigo);//para cargar los combos
        DataTable CargaSucursalesXusuario(Int32 Codigo, Int32 CodUsuario);
        DataTable CargaSucursalesSeleccion(Int32 Codigo);
        DataTable ListaSucursales();
        DataTable BuscaSucursales(Int32 Criterio, String Filtro);

        Boolean UpdateConfiguracion(clsParametros Configuracion);
        clsParametros CargaConfiguracion();

        DataTable ListaSucursales_Empresa(Int32 Codigo);
    }
}
