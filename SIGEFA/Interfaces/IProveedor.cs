using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IProveedor
    {
        Boolean Insert(clsProveedor ProveedorNuevo);
        Boolean Update(clsProveedor Proveedor);
        Boolean Delete(Int32 CodigoProv);


        clsProveedor CargaProveedor(Int32 CodigoProv);
        clsProveedor BuscaProveedor(String RUC);
        DataTable CargaProveedores();//para cargar los combos
        DataTable ListaProveedores();
        DataTable RelacionProveedores();
        DataTable BuscaProveedores(Int32 Criterio, String Filtro);
        DataTable ListaCorreosProveedores(Int32 codpro);
        Boolean CambiaProveedor(Int32 codProd, Int32 codProv1, Int32 codProv2);
    }
}
