using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;

namespace SIGEFA.Interfaces
{
    interface ICtaCte
    {
        Boolean Insert(clsCtaCte cta);
        Boolean Update(clsCtaCte cta);
        Boolean Delete(Int32 codCtaCte, Int32 codAlmacen);

        DataTable ListaCtasBanco(Int32 CodBanco, Int32 codAlmacen);
        DataTable ListaCtaCte(Int32 codAlmacen);
        clsCtaCte CargaTipoCuenta(Int32 CodCuenta, Int32 codAlmacen);
        decimal TotalConciliacion(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta);
       


        DataTable CargarMovxCuenta(String Cuenta, Int32 codAlmacen);
        clsCtaCte BuscaMovimiento(Int32 codMov, Int32 codAlmacen);

        Boolean InsertMovi(clsCtaCte cta);

        Boolean UpdateMovi(clsCtaCte cta);
        Boolean DeleteMov(Int32 CodMov, Int32 codAlmacen);
        DataTable ListaMovimientos(Int32 codAlmacen);
        //DataTable ListaMovimientos(Int32 codAlmacen);
        DataTable ListarMovientoscta(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta);
        DataTable ListaEgresosCaja(Int32 CodSucursal, DateTime Fecha);
        DataTable ListatipoCtas_x_Banco(Int32 CodBanco, Int32 CodAlmacen);
        DataTable ListanumCta_x_tipocta(Int32 CodBanco, String tipocuenta, Int32 codAlmacen);
        DataTable ListaCaja(Int32 codSucursal, DateTime fecha);
        clsCtaCte VerificaEgresoCaja(Int32 CodSucursal, DateTime fecha);
        DataTable ListaCtaCtexBancoxMoneda(Int32 codBanco, Int32 codMoneda);
        DataTable ListaBancoxMoneda(Int32 codMoneda);
        Int32 Correlativo(Int32 codtipo);

        Boolean activar(Int32 codtipo);
        Boolean desactivar(Int32 codigo);
        DataTable ListaMovimientosDesactivos(Int32 codbanco, Int32 codcuenta, Int32 codAlmacen);
    }
}
