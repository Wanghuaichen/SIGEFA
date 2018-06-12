using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ISerie
    {
        Boolean Insert(clsSerie NuevoSerie);
        Boolean Update(clsSerie Serie);
        Boolean Delete(Int32 Codigo);

        clsSerie CargaSerie(Int32 Codigo, Int32 CodAlmacen);
        DataTable ListaSeries(Int32 codDocumento, Int32 codAlmacen);
        clsSerie BuscaSerie(String Serie, Int32 Documento, Int32 Almacen);
        Int32 ExistenSeries(Int32 CodDocumento, Int32 CodAlmacen);
        Int32 GetCodigoSerie(Int32 CodDocumento, Int32 CodAlmacen);
        clsSerie BuscaSeriexDocumento(Int32 codDocumento, Int32 CodAlmacen);

        //MODIFICACION ALEX TRAE SERIE
        Int32 traeNumeracion(Int32 codal, Int32 coddoc);
        //MODIFICACION ALEX TRAE SERIE
        Int32 traeCodSerie(Int32 codal, Int32 coddoc);

        clsSerie CargaSerieEmpresa(Int32 CodigoAlmacen, Int32 codigoDoc);
    }
}
