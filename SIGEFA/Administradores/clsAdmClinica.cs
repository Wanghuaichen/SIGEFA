using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGEFA.Interfaces;
using SIGEFA.InterMySql;
using SIGEFA.Entidades;
using System.Windows.Forms;
using System.Data;

namespace SIGEFA.Administradores
{
    public class clsAdmClinica
    {
        IClinica MClin = new MysqlClinica();

        public bool InsertPaciente(clsPaciente Paciente)
        {
            try
            {
                return MClin.InsertPaciente(Paciente);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public DataTable ListaPacientes()
        {
            try
            {
                return MClin.ListaPacientes();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public clsPaciente CargaPaciente(int Codigo)
        {
            try
            {
                return MClin.CargaPaciente(Codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public bool UpdatePaciente(clsPaciente Paciente)
        {
            try
            {
                return MClin.UpdatePaciente(Paciente);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public bool DeletePaciente(int Codigo)
        {
            try
            {
                return MClin.DeletePaciente(Codigo);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool InsertHistoriaCabecera(clsHistoria Historia)
        {
            try
            {
                return MClin.InsertHistoriaCabecera(Historia);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry")) DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: N°- de Documento Repetido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public clsHistoria CargaHistoriaCabecera(string Numero)
        {
            try
            {
                return MClin.CargaHistoriaCabecera(Numero);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public bool InsertHistoriaDetalle(clsDetalleHistoria Detalle)
        {
            try
            {
                return MClin.InsertHistoriaDetalle(Detalle);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public DataTable ListaDetalleHistorial(Int32 CodigoCab)
        {
            try
            {
                return MClin.ListaDetalleHistorial(CodigoCab);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

    }
}
