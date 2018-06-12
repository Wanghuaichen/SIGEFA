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
    class clsAdmVendedor
    {
        IVendedor Mven = new MysqlVendedor();

        public Boolean insert(clsVendedor ven)
        {
            try
            {
                return Mven.Insert(ven);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else  DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsVendedor ven)
        {
            try
            {
                return Mven.Update(ven);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codven)
        {
            try
            {
                return Mven.Delete(Codven);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraVendedores()
        {
            try
            {
                return Mven.ListaVendedores();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraVendedoresDestaque()
        {
            try
            {
                return Mven.ListaVendedoresDestaque();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsVendedor MuestraVendedor(Int32 CodVendedor)
        {
            try
            {
                return Mven.CargaVendedor(CodVendedor);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraComisones(DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mven.ListaComisiones(FechaInicial,FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraComisonesFiltros(Int32 Codigo, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                return Mven.MuestraComisonesFiltros(Codigo, FechaInicial, FechaFinal);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraVendedoresCombo()
        {
            try
            {
                return Mven.CargaVendedores();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraComisionesPorDocumentoFecha()
        {
            try
            {
                return Mven.ListarComisionesPorDocumentoFecha();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraComisionPorDocumentoFecha(Int32 Mes, Int32 Año)
        {
            try
            {
                return Mven.MuestraComisionPorDocumentoFecha(Mes, Año);

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraComisionPorDocumentoPorVendedor(Int32 Mes, Int32 Año,Int32 CodVendedor)
        {
            try
            {
                return Mven.MuestraComisionPorDocumentoPorVendedor(Mes, Año, CodVendedor);

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable MuestraComisionPorDocumentoPorVendedorZona(Int32 Mes, Int32 Año, Int32 CodVendedor, Int32 CodZona)
        {
            try
            {
                return Mven.MuestraComisionPorDocumentoPorVendedorZona(Mes, Año, CodVendedor, CodZona);

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaVendedoresReporte()
        {
            try
            {
                return Mven.CargaVendedoresReportes();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable MuestraVendedoresDestaque2()
        {
            try
            {
                return Mven.ListaVendedoresDestaque2();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

    }
}
