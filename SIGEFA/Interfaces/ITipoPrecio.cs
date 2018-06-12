using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SIGEFA.Entidades;
using System.Text;

namespace SIGEFA.Interfaces
{
   interface ITipoPrecio
    {
      
       Boolean insert(clsTipoPrecios tp);
       Boolean Update(clsTipoPrecios tp);
       Boolean eliminar(Int32 codTipoPrecio);
     DataTable ListaPrecios();

    }
}
