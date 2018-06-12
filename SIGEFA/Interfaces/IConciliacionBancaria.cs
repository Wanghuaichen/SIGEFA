using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IConciliacionBancaria
    {
        Boolean Insert(clsConciliacionBancaria conciliacion);
        Boolean insertdetalle(clsDetalleConciliacion detalle);
        Boolean Update(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion);       
        Boolean UpdateBandera(Int32 codalma, Int32 codbanco, Int32 codcuenta, Int32 CodConciliacion);
    }
}
