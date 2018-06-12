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
    class clsAdmCliente
    {
        ICliente Mcli = new MysqlCliente();

        public Boolean insert(clsCliente cli)
        {
            try
            {
                return Mcli.Insert(cli);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean update(clsCliente cli)
        {
            try
            {
                return Mcli.Update(cli);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean delete(Int32 Codcli)
        {
            try
            {
                return Mcli.Delete(Codcli);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean CambioHabilitado(Int32 CodCliente, Boolean Estado)
        {
            try
            {
                return Mcli.CambioHabilitado(CodCliente,Estado);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable MuestraClientes()
        {
            try
            {
                return Mcli.ListaClientes();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCliente MuestraCliente(Int32 CodCliente)
        {
            try
            {
                return Mcli.CargaCliente(CodCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsCliente BuscaCliente(String Codigo, Int32 Tipo)
        {
            try
            {
                return Mcli.BuscaCliente(Codigo, Tipo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable RelacionClientes()
        {
            try
            {
                return Mcli.RelacionClientes();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public String CodigoPersonalizado()
        {
            try
            {
                return Mcli.CodigoPersonalizado();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsCliente CargaDeuda(clsCliente Cliente)
        {
            try
            {
                return Mcli.CargaDeuda(Cliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCliente CargaFacturasVencidas(clsCliente cliente)
        {
            try
            {
                return Mcli.CargaFacturasVencidas(cliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            } 
        }

        public clsCliente MuestraClienteNota(Int32 CodCliente)
        {
            try
            {
                return Mcli.MuestraClienteNota(CodCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable ListaClientesConsultor(Int32 CodEntConsExt)
        {
            try
            {
                return Mcli.ListaClientesConsultor(CodEntConsExt);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCliente ConsultaCliente(String DNIRUC)
        {
            try
            {
                return Mcli.ConsultaCliente(DNIRUC);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Boolean insertConCli(Int32 codEntConsExt, Int32 CodCliente)
        {
            try
            {
                return Mcli.InsertConCli(codEntConsExt, CodCliente);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: Documento Duplicado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean deleteConCli(Int32 codEntConsExt, Int32 CodCliente)
        {
            try
            {
                return Mcli.DeleteConCli(codEntConsExt, CodCliente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

       
    }
}
