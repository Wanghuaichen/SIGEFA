using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface IAperturaCierre
    {
        Boolean Insert(clsCaja AperturaNuevo);
        Boolean UpdateApertura(clsCaja Apertura);
        Boolean UpdateCierre(clsCaja Cierre);

        Boolean AnularCierre(Int32 codAlmacen);

        clsCaja CargaAperturaCaja(Int32 codAlmacen);
        clsCaja CargaCierreCaja(Int32 codAlmacen);
        clsCaja GetUltimaCajaVentas(Int32 codAlmacen, Int32 tipocaja, Int32 codalma);

        //Implementado
        clsCaja ValidarAperturaDia(Int32 codSucursal, DateTime fecha1, Int32 tipocaja, Int32 codalma, Int32 CodUser);
        Boolean InsertAperturaCaja(clsCaja AperturaNuevo);
        clsCaja CargaCierreAnterior(Int32 iCodSucursal, Int32 tipocaja);
        DataTable ListaCierresDiarios(Int32 codSucursal, DateTime desde, DateTime hasta);
        //Fin Implementado

        Decimal SumaVentaEfectivoCaja(Int32 codSuc, DateTime fech1, Int32 codigocaja);
        DataTable ListaCajaDiaria(Int32 codSucursal, DateTime fecha1, Int32 codigocaja, Int32 codalma);

        Boolean CerrarCajaVentas(Int32 codSucursal, DateTime fecha1, Int32 codcaja, Int32 codalma);
        //clsCaja VerificaSaldoCajaChica(Int32 codSucursal, Int32 tipo);
        //clsCaja CargaSaldoCajaChica(Int32 CodAlmacen);

        Boolean InsertMovCajaChica(clsCajaChicaMov movchi);

        DataTable ListaCajaChica(Int32 codSucursal, DateTime fecha1, Int32 codigocaja, Int32 codalma);
        DataTable ConsultaCajas(Int32 almacen, DateTime fecha1, DateTime fecha2);
        Decimal traersaldo();

        
    }
}
