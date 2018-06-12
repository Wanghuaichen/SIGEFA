using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;


namespace SIGEFA.Interfaces
{
    interface IVendedor
    {
        Boolean Insert(clsVendedor VendedorNuevo);
        Boolean Update(clsVendedor Vendedor);
        Boolean Delete(Int32 Codigo);
              
                
        clsVendedor CargaVendedor(Int32 Codigo);
        DataTable ListaVendedores();
        DataTable ListaVendedoresDestaque();
        DataTable BuscaVendedores(Int32 Criterio, String Filtro);
        DataTable ListaComisiones(DateTime FechaInicial, DateTime FechaFinal);
        DataTable MuestraComisonesFiltros(Int32 Codigo, DateTime FechaInicial, DateTime FechaFinal);
        DataTable CargaVendedores();
        DataTable ListarComisionesPorDocumentoFecha();
        DataTable MuestraComisionPorDocumentoFecha(Int32 Mes, Int32 Año);
        DataTable MuestraComisionPorDocumentoPorVendedor(Int32 Mes, Int32 Año, Int32 CodVendedor);
        DataTable MuestraComisionPorDocumentoPorVendedorZona(Int32 Mes, Int32 Año, Int32 CodVendedor, Int32 CodZona);
        DataTable CargaVendedoresReportes();
        DataTable ListaVendedoresDestaque2();

    }
}
