using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGEFA.Entidades
{
    public class clsStatusCajaChica
    {
        #region propiedades

        private Decimal dAperturaCaja;
        private Decimal dSumaAperturasCaja;
        private Decimal dSumaCierresCaja;
        private Decimal dIngresos;
        private Decimal dEgresos;
        private Decimal dTotalVentas;
        private Decimal dPorCobrar;
        private Decimal dTotalPagos;
        private Decimal dPorPagar;
        private Int32 iCodAlmacen;
        private Int32 iCantidad;
        private Decimal dSumaVentasEfectivoDia;
        private Decimal dSumaVentasDepositoDia;
        private Decimal dSumaVentasChequeDia;
        private Decimal dSumaVentasTransferenciaDia;
        private Decimal dSumaVentasTarjetaDia;
        private Decimal dSumaVentasEfectivoMes;
        private Decimal dSumaVentasDepositoMes;
        private Decimal dSumaVentasChequeMes;
        private Decimal dSumaVentasTransferenciaMes;
        private Decimal dSumaVentasTarjetaMes;
        private Decimal dVentasCreditoDia;
        private Decimal dVentasContadoDia;
        private Decimal dVentasCreditoMes;
        private Decimal dVentasContadoMes;
        private Decimal dTotalVentasMes;
        private Decimal dPorCobrarMes;
        private Decimal dMontoDepositado;
        private Int32 iCodSucursal;

        private Decimal dSumaVentasEfectivoDiaDolar;
        private Decimal dSumaVentasDepositoDiaDolar;
        private Decimal dSumaVentasChequeDiaDolar;
        private Decimal dSumaVentasTransferenciaDiaDolar;
        private Decimal dSumaVentasTarjetaDiaDolar;
        private Decimal dSumaVentasEfectivoMesDolar;
        private Decimal dSumaVentasDepositoMesDolar;
        private Decimal dSumaVentasChequeMesDolar;
        private Decimal dSumaVentasTransferenciaMesDolar;
        private Decimal dSumaVentasTarjetaMesDolar;
        private Decimal dVentasCreditoDiaDolar;
        private Decimal dVentasContadoDiaDolar;
        private Decimal dVentasCreditoMesDolar;
        private Decimal dVentasContadoMesDolar;
        private Decimal dTotalVentasMesDolar;
        private Decimal dPorCobrarMesDolar;
        private Decimal dTotalVentasDolar;
        private Decimal dPorCobrarDolar;
        private Decimal dTotalPagosDolar;
        private Decimal dPorPagarDolar;
        private Decimal dIngresosDolar;
        private Decimal dEgresosDolar;
        private Decimal dCobranzaSolesTotal;
        private Decimal dCobranzaDolaresTotal;

        public Decimal CobranzaDolaresTotal
        {
            get { return dCobranzaDolaresTotal; }
            set { dCobranzaDolaresTotal = value; }
        }

        public Decimal CobranzaSolesTotal
        {
          get { return dCobranzaSolesTotal; }
          set { dCobranzaSolesTotal = value; }
        }

        public Decimal AperturaCaja
        {
            get { return dAperturaCaja; }
            set { dAperturaCaja = value; }
        }
        public Decimal SumaAperturasCaja
        {
            get { return dSumaAperturasCaja; }
            set { dSumaAperturasCaja = value; }
        }
        public Decimal SumaCierresCaja
        {
            get { return dSumaCierresCaja; }
            set { dSumaCierresCaja = value; }
        }
        public Decimal Ingresos
        {
            get { return dIngresos; }
            set { dIngresos = value; }
        }
        public Decimal Egresos
        {
            get { return dEgresos; }
            set { dEgresos = value; }
        }
        public Decimal TotalVentas
        {
            get { return dTotalVentas; }
            set { dTotalVentas = value; }
        }
        public Decimal PorCobrar
        {
            get { return dPorCobrar; }
            set { dPorCobrar = value; }
        }
        public Decimal TotalPagos
        {
            get { return dTotalPagos; }
            set { dTotalPagos = value; }
        }
        public Decimal PorPagar
        {
            get { return dPorPagar; }
            set { dPorPagar = value; }
        }

        public Int32 Cantidad
        {
            get { return iCantidad; }
            set { iCantidad = value; }
        }

        public int CodAlmacen
        {
            get { return iCodAlmacen; }
            set { iCodAlmacen = value; }
        }

        public decimal SumaVentasEfectivoDia
        {
            get { return dSumaVentasEfectivoDia; }
            set { dSumaVentasEfectivoDia = value; }
        }

        public decimal SumaVentasDepositoDia
        {
            get { return dSumaVentasDepositoDia; }
            set { dSumaVentasDepositoDia = value; }
        }

        public decimal SumaVentasChequeDia
        {
            get { return dSumaVentasChequeDia; }
            set { dSumaVentasChequeDia = value; }
        }

        public decimal SumaVentasTransferenciaDia
        {
            get { return dSumaVentasTransferenciaDia; }
            set { dSumaVentasTransferenciaDia = value; }
        }

        public decimal SumaVentasTarjetaDia
        {
            get { return dSumaVentasTarjetaDia; }
            set { dSumaVentasTarjetaDia = value; }
        }

        public decimal SumaVentasEfectivoMes
        {
            get { return dSumaVentasEfectivoMes; }
            set { dSumaVentasEfectivoMes = value; }
        }

        public decimal SumaVentasDepositoMes
        {
            get { return dSumaVentasDepositoMes; }
            set { dSumaVentasDepositoMes = value; }
        }

        public decimal SumaVentasChequeMes
        {
            get { return dSumaVentasChequeMes; }
            set { dSumaVentasChequeMes = value; }
        }

        public decimal SumaVentasTransferenciaMes
        {
            get { return dSumaVentasTransferenciaMes; }
            set { dSumaVentasTransferenciaMes = value; }
        }

        public decimal SumaVentasTarjetaMes
        {
            get { return dSumaVentasTarjetaMes; }
            set { dSumaVentasTarjetaMes = value; }
        }

        public decimal VentasCreditoDia
        {
            get { return dVentasCreditoDia; }
            set { dVentasCreditoDia = value; }
        }

        public decimal VentasContadoDia
        {
            get { return dVentasContadoDia; }
            set { dVentasContadoDia = value; }
        }

        public decimal VentasCreditoMes
        {
            get { return dVentasCreditoMes; }
            set { dVentasCreditoMes = value; }
        }

        public decimal VentasContadoMes
        {
            get { return dVentasContadoMes; }
            set { dVentasContadoMes = value; }
        }

        public decimal TotalVentasMes
        {
            get { return dTotalVentasMes; }
            set { dTotalVentasMes = value; }
        }

        public decimal PorCobrarMes
        {
            get { return dPorCobrarMes; }
            set { dPorCobrarMes = value; }
        }

        public decimal MontoDepositado
        {
            get { return dMontoDepositado; }
            set { dMontoDepositado = value; }
        }

        public int CodSucursal
        {
            get { return iCodSucursal; }
            set { iCodSucursal = value; }
        }

        public decimal SumaVentasEfectivoDiaDolar
        {
            get { return dSumaVentasEfectivoDiaDolar; }
            set { dSumaVentasEfectivoDiaDolar = value; }
        }

        public decimal SumaVentasDepositoDiaDolar
        {
            get { return dSumaVentasDepositoDiaDolar; }
            set { dSumaVentasDepositoDiaDolar = value; }
        }

        public decimal SumaVentasChequeDiaDolar
        {
            get { return dSumaVentasChequeDiaDolar; }
            set { dSumaVentasChequeDiaDolar = value; }
        }

        public decimal SumaVentasTransferenciaDiaDolar
        {
            get { return dSumaVentasTransferenciaDiaDolar; }
            set { dSumaVentasTransferenciaDiaDolar = value; }
        }

        public decimal SumaVentasTarjetaDiaDolar
        {
            get { return dSumaVentasTarjetaDiaDolar; }
            set { dSumaVentasTarjetaDiaDolar = value; }
        }

        public decimal SumaVentasEfectivoMesDolar
        {
            get { return dSumaVentasEfectivoMesDolar; }
            set { dSumaVentasEfectivoMesDolar = value; }
        }

        public decimal SumaVentasDepositoMesDolar
        {
            get { return dSumaVentasDepositoMesDolar; }
            set { dSumaVentasDepositoMesDolar = value; }
        }

        public decimal SumaVentasChequeMesDolar
        {
            get { return dSumaVentasChequeMesDolar; }
            set { dSumaVentasChequeMesDolar = value; }
        }

        public decimal SumaVentasTransferenciaMesDolar
        {
            get { return dSumaVentasTransferenciaMesDolar; }
            set { dSumaVentasTransferenciaMesDolar = value; }
        }

        public decimal SumaVentasTarjetaMesDolar
        {
            get { return dSumaVentasTarjetaMesDolar; }
            set { dSumaVentasTarjetaMesDolar = value; }
        }

        public decimal VentasCreditoDiaDolar
        {
            get { return dVentasCreditoDiaDolar; }
            set { dVentasCreditoDiaDolar = value; }
        }

        public decimal VentasContadoDiaDolar
        {
            get { return dVentasContadoDiaDolar; }
            set { dVentasContadoDiaDolar = value; }
        }

        public decimal VentasCreditoMesDolar
        {
            get { return dVentasCreditoMesDolar; }
            set { dVentasCreditoMesDolar = value; }
        }

        public decimal VentasContadoMesDolar
        {
            get { return dVentasContadoMesDolar; }
            set { dVentasContadoMesDolar = value; }
        }

        public decimal TotalVentasMesDolar
        {
            get { return dTotalVentasMesDolar; }
            set { dTotalVentasMesDolar = value; }
        }

        public decimal PorCobrarMesDolar
        {
            get { return dPorCobrarMesDolar; }
            set { dPorCobrarMesDolar = value; }
        }

        public decimal TotalVentasDolar
        {
            get { return dTotalVentasDolar; }
            set { dTotalVentasDolar = value; }
        }

        public decimal PorCobrarDolar
        {
            get { return dPorCobrarDolar; }
            set { dPorCobrarDolar = value; }
        }

        public decimal TotalPagosDolar
        {
            get { return dTotalPagosDolar; }
            set { dTotalPagosDolar = value; }
        }

        public decimal PorPagarDolar
        {
            get { return dPorPagarDolar; }
            set { dPorPagarDolar = value; }
        }

        public decimal IngresosDolar
        {
            get { return dIngresosDolar; }
            set { dIngresosDolar = value; }
        }

        public decimal EgresosDolar
        {
            get { return dEgresosDolar; }
            set { dEgresosDolar = value; }
        }

        #endregion propiedades
    }
}
