using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIGEFA.Administradores
{
    class clsAdmNotaIngreso
    {
        INotaIngreso Mnota = new MysqlNotaIngreso();

        public Boolean insert(clsNotaIngreso nota)
        {
            try
            {
                return Mnota.insert(nota);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry"))DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalleConsolidado(Int32 orden, Int32 Nota, Int32 codAlma, Int32 codUsu)
        {
            try
            {
                return Mnota.insertdetalleConsolidado(orden,Nota, codAlma, codUsu);
            }
            catch (Exception ex)
            {
                 DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deleteConsolidado(Int32 codalma, Int32 codusu)
        {
            try
            {
                return Mnota.deleteConsolidado(codalma, codusu);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean insertdetalle(clsDetalleNotaIngreso detalle)
        {
            try
            {
                return Mnota.insertdetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaCantidadPendiente(Double cantidad, Int32 produc, Int32 CodOrden,Int32 coddeta)
            {
                try
                {
                    return Mnota.ActualizaCantidadPendiente(cantidad, produc, CodOrden, coddeta);
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

        public Boolean ActualizaCantidadPendiente2(Double cantidad, Int32 produc, Int32 alma, Int32 coduser)//Para actualizar la cantidad pendiente, porque la orden esta siendo visualizada por otros almacenes
        {
            try
            {
                return Mnota.ActualizaCantidadPendiente2(cantidad, produc, alma, coduser);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaCodNotaIngreso(Double cantidad, Int32 produc, Int32 CodDetalle, Int32 tipo)
         {
             try
             {
                 return Mnota.ActualizaCodNotaIngreso(cantidad, produc, CodDetalle, tipo);
             }
             catch (Exception ex)
             {
                 DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return false;
             }
         }

        public Boolean update(clsNotaIngreso nota)
        {
            try
            {
                return Mnota.update(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean updatedetalle(clsDetalleNotaIngreso detalle)
        {
            try
            {
                return Mnota.updatedetalle(detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codnota)
        {
            try
            {
                return Mnota.delete(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular( Int32 CodSerie, String NumDoc, String text)
        {
            try
            {
                return Mnota.anular(CodSerie, NumDoc, text);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean anular1(Int32 codigo)
        {
            try
            {
                return Mnota.anular1(codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean activar(Int32 Codnota)
        {
            try
            {
                return Mnota.activar(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deletedetalle(Int32 Codnota)
        {
            try
            {
                return Mnota.deletedetalle(Codnota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsNotaIngreso CargaNotaIngreso(Int32 CodNotaIngreso)
        {
            try
            {
                return Mnota.CargaNotaIngreso(CodNotaIngreso);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //public clsDetalleNotaIngreso ListaOrdenAlmacen(int codAlmacen, int codNota)
        //{
        //    try
        //    {
        //        return Mnota.ListaOrdenAlmacen(codAlmacen, codNota);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}

        //public List<clsDetalleNotaIngreso> GuardaDetalleOrdenAlmacen(int codAlmacen, int codNota)
        //{
        //    try
        //    {
        //        return Mnota.GuardaDetalleOrdenAlmacen(codAlmacen, codNota);
        //    }
        //    catch (Exception ex)
        //    {
        //        DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return null;
        //    }
        //}

        public DataTable CargaDetalle(Int32 CodNotaIngreso)
        {
            try
            {
                return Mnota.CargaDetalle(CodNotaIngreso);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraOrdenAlmacen(int codAlmacen, int codUsu)
        {
            try
            {
                return Mnota.MuestraOrdenAlmacen(codAlmacen, codUsu);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraNotaIngresoOrden(int codAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mnota.MuestraNotaIngresoOrden(codAlmacen,FechaInicial,FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraNotasIngreso(Int32 Criterio, Int32 CodAlmacen, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mnota.ListaNotasIngreso(Criterio, CodAlmacen, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraPagos(Int32 Estado, Int32 codEmpresa, DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                return Mnota.MuestraPagos(Estado, codEmpresa, Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaNotasCredito(Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return Mnota.ListaNotasCredito(CodAlmacen, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraTransferenciasVigentes(Int32 CodAlmacen)
        {
            try
            {
                return Mnota.MuestraTransferenciasVigentes(CodAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean atender(Int32 codigo, Int32 CodSerie, String NumDoc, int User)
        {
            try
            {
                return Mnota.atender(codigo,  CodSerie, NumDoc, User);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaDetalleTransferencia(Int32 codigotransferencia)
        {
            try
            {
                return Mnota.CargaDetalleTransferencia(codigotransferencia);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean UpdateComentario(clsNotaIngreso nota)
        {
            try
            {
                return Mnota.UpdateComentario(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraGuia(int codAlmacen, int codUsu)
        {
            try
            {
                return Mnota.MuestraGuia(codAlmacen, codUsu);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaNotaCreditoSinAplicar(Int32 Codcli, Int32 VentComp)
        {
            try
            {
                return Mnota.CargaNotaCreditoSinAplicar(Codcli, VentComp);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean ActualizaNCreditoVentaSinAplicar(clsNotaIngreso nota)
        {
            try
            {
                return Mnota.ActualizaNCreditoVentaSinAplicar(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean VerificarNCVentaAplicada(clsNotaIngreso nota)
        {
            try
            {
                return Mnota.VerificarNCVentaAplicada(nota);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargaNotaIngresoSD(Int32 Codprov, Int32 CodAlmacen, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                return Mnota.CargaNotaIngresoSD(Codprov, CodAlmacen, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListarCodigoNotasSalida()
        {
            try
            {
                return Mnota.ListarCodigoNotasSalida();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean ActualizaStockPA(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI,
            Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie)
        {
            try
            {
                return Mnota.ActualizaStockPA(codalmacenorig, codalmacenrecep, codigoProd, codigoNI, cantidadenviada, preciounit, valorreal, valorrealsoles, codigouser, serie, numerodoc, codserie);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean ActualizaStockAR(Int32 codalmacenorig, Int32 codalmacenrecep, Int32 codigoProd, Int32 codigoNI,
            Decimal cantidadenviada, Decimal preciounit, Decimal valorreal, Decimal valorrealsoles, Int32 codigouser, String serie, String numerodoc, Int32 codserie)
        {
            try
            {
                return Mnota.ActualizaStockAR(codalmacenorig, codalmacenrecep, codigoProd, codigoNI, cantidadenviada, preciounit, valorreal, valorrealsoles, codigouser, serie, numerodoc, codserie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsNotaIngreso CargaNI(Int32 codTransDirecta)
        {
            try
            {
                return Mnota.CargaNI(codTransDirecta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
