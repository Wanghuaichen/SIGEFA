using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IModeloTransporte
    {
        Boolean Insert(clsModeloTransporte NuevaModeloTransporte);
        Boolean Update(clsModeloTransporte ModeloTransporte);
        Boolean Delete(Int32 Codigo);

        clsModeloTransporte CargaModeloTransporte(Int32 Codigo);
        DataTable ListaModeloTransportes(Int32 codMarcaTransporte);
    }
}
