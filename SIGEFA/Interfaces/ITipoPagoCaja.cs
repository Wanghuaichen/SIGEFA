using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ITipoPagoCaja
    {
        Boolean Insert(clsTipoPagoCaja NuevoTPcaja);
        Boolean Update(clsTipoPagoCaja TPcaja);
        Boolean Delete(Int32 Codigo);
                
        DataTable ListaTipoPagoCaja();
    }
}
