using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IFlujoCaja
    {
        Boolean Insert(clsFlujoCaja flu);
        Boolean Update(clsFlujoCaja flu);
        Boolean Delete(Int32 CodFlujoCaja, Int32 CodSucursal);

        clsFlujoCaja CargaFlujosCaja(DateTime fecha, Int32 CodSucursal);
        DataTable ListaFlujosCaja(Int32 codSucursal);
        DataTable ListaPagoCobro(Int32 tipo);

        /********************************* CAJA ***************************/
        clsFlujoCaja VerificaSaldoCaja(Int32 CodSucursal);
        Int32 VerificaAperturaCaja(Int32 codSucursal);
        clsFlujoCaja VerificaDepositoCaja(Int32 CodSucursal, DateTime fecha);

    }
}
