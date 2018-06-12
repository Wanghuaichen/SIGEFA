using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IPrestamoBancario
    {
        Boolean Insert(clsPrestamoBancario NuevoPreBan);
        Boolean Delete(Int32 CodPreBan);
        DataTable ListaPrestamos();
        DataTable MuestraPagosPrestamo(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2);
        clsPrestamoBancario CargaPrestamoBancario(Int32 CodPreBan);
    }
}
