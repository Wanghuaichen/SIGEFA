using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Entidades;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;

namespace SIGEFA.Administradores
{
    class clsAdmCtaCte
    {
        ICtaCte Mcta = new MysqlCtaCte();


        public Boolean Insert(clsCtaCte cta)
        {
            try
            {
                return Mcta.Insert(cta);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean Update(clsCtaCte cta)
        {
            try
            {
                return Mcta.Update(cta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean Delete(Int32 CodCtaCte, Int32 codAlmacen)
        {
            try
            {
                return Mcta.Delete(CodCtaCte, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaCtasBanco(Int32 CodBanco, Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListaCtasBanco(CodBanco, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaCtaCte(Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListaCtaCte(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        //
        public Boolean InsertMovi(clsCtaCte cta)
        {
            try
            {
                return Mcta.InsertMovi(cta);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaMovimientos(Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListaMovimientos(codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListarMovientoscta(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta)
        {
            try
            {
                
                return Mcta.ListarMovientoscta(codAlmacen,codBanco,codCuenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaMovimientosDesactivos(Int32 codbanco, Int32 codcuenta, Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListaMovimientosDesactivos(codbanco, codcuenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaEgresosCaja(Int32 CodSucursal, DateTime fecha)
        {
            try
            {
                return Mcta.ListaEgresosCaja(CodSucursal,fecha);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public decimal TotalConciliacion(Int32 codAlmacen, Int32 codBanco, Int32 codCuenta) 
        {
            try
            {

                return Mcta.TotalConciliacion(codAlmacen, codBanco, codCuenta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        public clsCtaCte CargaTipoCuenta(Int32 CodCuenta, Int32 codAlmacen)
        {
            try
            {
                return Mcta.CargaTipoCuenta(CodCuenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCtaCte BuscaMovimiento(Int32 CodCuenta, Int32 codAlmacen)
        {
            try
            {
                return Mcta.BuscaMovimiento(CodCuenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean UpdateMovi(clsCtaCte cta)
        {
            try
            {
                return Mcta.UpdateMovi(cta);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        public Boolean DeleteMov(Int32 CodMov, Int32 codAlmacen)
        {
            try
            {
                return Mcta.DeleteMov(CodMov, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable CargarMovxCuenta(String Cuenta, Int32 codAlmacen)
        {
            try
            {
                return Mcta.CargarMovxCuenta(Cuenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        public DataTable ListatipoCtas_x_Banco(Int32 CodBanco, Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListatipoCtas_x_Banco(CodBanco, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable ListanumCta_x_tipocta(Int32 CodBanco, String tipocuenta, Int32 codAlmacen)
        {
            try
            {
                return Mcta.ListanumCta_x_tipocta(CodBanco, tipocuenta, codAlmacen);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaCaja(Int32 codSucursal, DateTime fecha)
        {
            try
            {
                return Mcta.ListaCaja(codSucursal, fecha);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCtaCte VerificaEgresoCaja(Int32 CodSucursal, DateTime fecha)
        {
            try
            {
                return Mcta.VerificaEgresoCaja(CodSucursal, fecha);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaCtaCtexBancoxMoneda(Int32 codBanco, Int32 codMoneda)
        {
            try
            {
                return Mcta.ListaCtaCtexBancoxMoneda(codBanco, codMoneda);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaBancoxMoneda(Int32 codMoneda)
        {
            try
            {
                return Mcta.ListaBancoxMoneda(codMoneda);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Int32 Correlativo(Int32 codtipo)
        {
            try
            {
                return Mcta.Correlativo(codtipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
                
        public Boolean activar(Int32 codtipo)
        {
            try
            {
                return Mcta.activar(codtipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Boolean desactivar(Int32 codigo)
        {
            try
            {
                return Mcta.desactivar(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
