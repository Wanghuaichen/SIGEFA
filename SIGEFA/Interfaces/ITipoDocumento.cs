using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITipoDocumento
    {
        Boolean Insert(clsTipoDocumento NuevoTipoDocumento);
        Boolean Update(clsTipoDocumento TipoDocumento);
        Boolean Delete(Int32 Codigo);

        clsTipoDocumento CargaTipoDocumento(Int32 Codigo);
        clsTipoDocumento BuscaTipoDocumento(String Sigla);
        DataTable ListaTipoDocumentos();
        DataTable ListaTipoDocumentosDeCaja();
        DataTable CargaTipoDocumentos();
        DataTable ListaDocumentoNota();
    }
}
