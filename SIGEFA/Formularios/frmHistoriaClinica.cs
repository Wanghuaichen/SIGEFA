using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmHistoriaClinica : Office2007Form
    {
        private clsPaciente Paciente;
        private clsAdmClinica AdmClin;
        private clsReporteHistoriaClinica Rpt;
        private clsHistoria HistoriaCab;


        public frmHistoriaClinica()
        {
            InitializeComponent();
            PostConstructor();
        }

        private void PostConstructor()
        {
            AdmClin = new clsAdmClinica();
            Rpt = new clsReporteHistoriaClinica();
            // HistoriaCab = new clsHistoria();
            // Paciente = null;
        }

        private void txtNombre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmPaciente Paciente = new frmPaciente(this);
            Paciente.ShowDialog(this);
        }

        private string CalcularDiferenciaEntreFechas(DateTime inicio, DateTime fin)
        {
            DateTime date1 = inicio;
            DateTime date2 = fin;


            int oldMonth = date2.Month;
            while (oldMonth == date2.Month)
            {
                date1 = date1.AddDays(-1);
                date2 = date2.AddDays(-1);
            }


            int years = 0, months = 0, days = 0;


            // Obtengo el número de años
            while (date2.CompareTo(date1) >= 0)
            {
                years++;
                date2 = date2.AddYears(-1);
            }
            date2 = date2.AddYears(1);
            years--;


            // Obtengo el número de meses y días
            oldMonth = date2.Month;
            while (date2.CompareTo(date1) >= 0)
            {
                days++;
                date2 = date2.AddDays(-1);
                if ((date2.CompareTo(date1) >= 0) && (oldMonth != date2.Month))
                {
                    months++;
                    days = 0;
                    oldMonth = date2.Month;
                }
            }
            date2 = date2.AddDays(1);
            days--;


            TimeSpan difference = date2.Subtract(date1);


            return
                 years.ToString() + " años" +
                 ", " + months.ToString() + " meses" +
                 ", " + days.ToString() + " días";
        }

        public void CargarOcurrencias()
        {
            try
            {
                if (HistoriaCab != null)
                {
                    PrepareData(AdmClin.ListaDetalleHistorial(HistoriaCab.ID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareData(DataTable DataBD)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("FECHA/HORA", typeof(string));
            table.Columns.Add("TEMPERATURA (C°)", typeof(string));
            table.Columns.Add("PESO (KG)", typeof(string));
            table.Columns.Add("NOTAS", typeof(string));
            table.Columns.Add("TRATAMIENTOS", typeof(string));
            table.Columns.Add("FALLECIDO", typeof(string));

            foreach (DataRow row in DataBD.Rows)
            {
                table.Rows.Add(
                    row[0].ToString(),
                    row[1].ToString(),
                    row[2].ToString(),
                    row[3].ToString(),
                    row[4].ToString(),
                    row[5].ToString(),
                    row[6].ToString().Equals("0") ? "NO" : "SI"
                );
            }

            dgvDetalle.DataSource = table;

            dgvDetalle.Columns[0].Visible = false;
        }

        public void ObtenerDesdeBuscador(Int32 CodPaciente)
        {
            Paciente = AdmClin.CargaPaciente(CodPaciente);
            txtEspecie.Text = Paciente.Especie;
            txtNombre.Text = Paciente.Nombre;
            txtRaza.Text = Paciente.Raza;
            txtPropietario.Text = Paciente.Propietario;
            txtDireccion.Text = Paciente.Direccion;
            txtEdad.Text = CalcularDiferenciaEntreFechas(Paciente.FechaNacimiento, DateTime.Now);
            txtSexo.Text = Paciente.Sexo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool res = false;
            if (dgvDetalle.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.Cells[6].Value.ToString().Equals("SI"))
                    {
                        res = true;
                    }
                }
            }
            if (HistoriaCab != null && !res)
            {
                frmNuevaHistoria frm = new frmNuevaHistoria(this, HistoriaCab);
                frm.ShowDialog(this);
            }
            else if (res)
            {
                MessageBox.Show("EL PACIENTE YA HA FALLECIDO :(. NO SE PUEDEN AGREGAR MAS OCURRENCIAS","SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelPaciente_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro())
            {
                try
                {
                    HistoriaCab = new clsHistoria();
                    HistoriaCab.Numero = txtNumero.Text;
                    HistoriaCab.PacienteID = Paciente.ID;
                    HistoriaCab.UsuarioID = frmLogin.iCodUser;
                    HistoriaCab.FechaRegistro = DateTime.Now;

                    if (AdmClin.InsertHistoriaCabecera(HistoriaCab))
                    {
                        MessageBox.Show("HISTORIA CLINICA REGISTRADA CORRECTAMENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PostConstructor();
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL REGISTRAR LA HISTORIA CLINICA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarRegistro()
        {
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("INGRESE EL NUMERO DE LA HISTORIA CLINICA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text) || Paciente == null)
            {
                MessageBox.Show("SELECCIONE EL PACIENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                HistoriaCab = AdmClin.CargaHistoriaCabecera(txtNumero.Text);
                if (HistoriaCab != null)
                {
                    Paciente = AdmClin.CargaPaciente(HistoriaCab.PacienteID);
                    txtEspecie.Text = Paciente.Especie;
                    txtNombre.Text = Paciente.Nombre;
                    txtRaza.Text = Paciente.Raza;
                    txtPropietario.Text = Paciente.Propietario;
                    txtDireccion.Text = Paciente.Direccion;
                    txtEdad.Text = CalcularDiferenciaEntreFechas(Paciente.FechaNacimiento, DateTime.Now);
                    txtSexo.Text = Paciente.Sexo;
                    CargarOcurrencias();
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRO NINGUNA HISTORIA CON EL NUMERO INGRESADO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (HistoriaCab != null)
            {
                try
                {
                    CRHistoriaClinica rpt = new CRHistoriaClinica();
                    frmRptHistoriaClinica frm = new frmRptHistoriaClinica();
                    rpt.SetDataSource(Rpt.HistoriaClinica(HistoriaCab.ID));
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
