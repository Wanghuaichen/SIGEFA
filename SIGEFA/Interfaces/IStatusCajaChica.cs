using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IStatusCajaChica
    {
        clsStatusCajaChica CargaStatusFlujosCajaChica(DateTime FechaInicio, DateTime FechaFin);
        clsStatusCajaChica CargaStatusFlujosCajaChica_SP(DateTime Fecha);

        clsStatusCajaChica VerificaStadoCajaChica();

        /************************** CAJA ******************************************************/

        clsStatusCajaChica CargaStatusFlujosCaja(DateTime FechaInicio, DateTime FechaFin, Int32 CodSucursal);
        clsStatusCajaChica CargaStatusFlujosCaja_SP(DateTime Fecha, Int32 CodSucursal);
        clsStatusCajaChica VerificaStadoCaja();
    }
}
