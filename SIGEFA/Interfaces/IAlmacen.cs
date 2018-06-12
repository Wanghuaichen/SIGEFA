using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IAlmacen
    {
        Boolean Insert(clsAlmacen AlmacenNuevo);
        Boolean Update(clsAlmacen Almacen);
        Boolean Delete(Int32 CodigoAlm);


        clsAlmacen CargaAlmacen(Int32 CodigoAlm);        
        DataTable ListaAlmacenes(Int32 CodEmpre);
        DataTable BuscaAlmacenes(Int32 Criterio, String Filtro);
        DataTable AlmacenesDisponible(Int32 CodSucursal);
        DataTable ListaAlmacenes2();
        DataTable CargaAlmacen2(Int32 codempre);
        DataTable CargaAlmacenes(Int32 iNivel, Int32 iEmpresa, Int32 iUsuario);

        DataTable RelacionProductosStockMin(Int32 codTipo, Int32 codAlm);

        DataTable AlertaFacturasLetrasXVencer();
    }
}
