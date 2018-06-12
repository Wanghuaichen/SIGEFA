using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ILibrosElectronicos
    {
        Boolean Insert(clsLibrosElectronicos libroElect);
        Boolean Update(clsLibrosElectronicos libroElect);
        Boolean Delete(Int32 Codle);

        clsLibrosElectronicos MuestraLE(Int32 Codigo);
        DataTable CargaLibrosElectronicos();

        DataTable CargaRegistrosElectronicos(Int32 Codle);
        clsRegistroElectronico MuestraRE(Int32 Codigo);

        DataTable CargaOperaciones();
        DataTable CargaContenido();
        DataTable CargaGeneradoPor();

        DataTable GetVentas_Mes_LEV(Int32 mes);
        DataTable FacturasComprasLE(Int32 mes, Int32 codalma, String cadena);
        Int32 ValidaCampoTipoFacturacion(Int32 mes, Int32 Anio);
    }
}
