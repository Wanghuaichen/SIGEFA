using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using DevComponents.Editors;

namespace SIGEFA.Formularios
{
    public partial class frmPaciente : Office2007Form
    {
        private clsAdmClinica AdmClinica;
        private clsPaciente Paciente;

        private Form ParentForm;

        public frmPaciente()
        {
            InitializeComponent();
            PostConstructor();
        }

        public frmPaciente(Form _parentForm)
        {
            InitializeComponent();
            PostConstructor();
            this.ParentForm = _parentForm;
        }

        private void PostConstructor()
        {
            txtNombre.Enabled = false;
            txtNombre.Text = string.Empty;

            txtPropietario.Enabled = false;
            txtPropietario.Text = string.Empty;

            txtEdad.Text = string.Empty;

            txtRaza.Enabled = false;
            txtRaza.Text = string.Empty;

            txtDireccion.Enabled = false;
            txtDireccion.Text = string.Empty;

            cmbEspecie.Enabled = false;
            cmbEspecie.Items.Clear();
            cmbSexo.Enabled = false;
            cmbSexo.Items.Clear();
            dtiFechaNacimiento.Enabled = false;
            dtiFechaNacimiento.Value = DateTimePicker.MinimumDateTime;

            //Inicializacion Administradores
            AdmClinica = new clsAdmClinica();


            Paciente = null;

            dtiFechaNacimiento.MaxDate = DateTime.Now;

            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            CargarData();

            if (dgvDetalle.RowCount > 0) btnModificar.Enabled = true;

        }

        private void CargarData()
        {
            try
            {
                PrepareData(AdmClinica.ListaPacientes());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareData(DataTable DataBD)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("NOMBRE", typeof(string));
            table.Columns.Add("FECHA NACIMIENTO", typeof(string));
            table.Columns.Add("PROPIETARIO", typeof(string));
            table.Columns.Add("ESPECIE", typeof(string));
            table.Columns.Add("RAZA", typeof(string));
            table.Columns.Add("SEXO", typeof(string));
            table.Columns.Add("DIRECCION", typeof(string));
            table.Columns.Add("USUARIO", typeof(string));
            table.Columns.Add("FECHA REGISTRO", typeof(string));
            table.Columns.Add("ESTADO", typeof(string));

            foreach (DataRow row in DataBD.Rows)
            {
                table.Rows.Add(
                    row[0].ToString(),
                    row[1].ToString(),
                    Convert.ToDateTime(row[2].ToString()).ToShortDateString(),
                    row[3].ToString(),
                    row[4].ToString(),
                    row[5].ToString(),
                    row[6].ToString(),
                    row[7].ToString(),
                    row[8].ToString(),
                    row[9].ToString(),
                    row[10].ToString().Equals("1") ? "ACTIVO" : row[10].ToString().Equals("0") ? "INACTIVO" : "FALLECIDO"
                );
            }

            dgvDetalle.DataSource = table;

            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[8].Visible = false;
            dgvDetalle.Columns[9].Visible = false;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtNombre.Text = string.Empty;

            txtPropietario.Enabled = true;
            txtPropietario.Text = string.Empty;

            txtEdad.Text = string.Empty;

            txtRaza.Enabled = true;
            txtRaza.Text = string.Empty;

            txtDireccion.Enabled = true;
            txtDireccion.Text = string.Empty;

            cmbEspecie.Enabled = true;
            cmbSexo.Enabled = true;
            dtiFechaNacimiento.Enabled = true;

            CargarEspecies();
            CargarSexo();

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void CargarEspecies()
        {
            cmbEspecie.Items.Add("CANINO");
            cmbEspecie.Items.Add("FELINO");
            cmbEspecie.Items.Add("AVE");
            cmbEspecie.Items.Add("REPTIL");
        }

        private void CargarSexo()
        {
            cmbSexo.Items.Add("MACHO");
            cmbSexo.Items.Add("HEMBRA");
            cmbSexo.Items.Add("NO DEIFINIDO");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PostConstructor();
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

        private void dtiFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            txtEdad.Text = CalcularDiferenciaEntreFechas(dtiFechaNacimiento.Value, DateTime.Now);
            if (dtiFechaNacimiento.Value == DateTimePicker.MinimumDateTime)
            {
                dtiFechaNacimiento.Value = DateTime.Now;
                dtiFechaNacimiento.Format = eDateTimePickerFormat.Custom;
                dtiFechaNacimiento.CustomFormat = " ";
            }
            else
            {
                dtiFechaNacimiento.Format = eDateTimePickerFormat.Short;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarRegistro())
            {
                if (Paciente == null)
                {
                    try
                    {
                        Paciente = new clsPaciente();
                        Paciente.Nombre = txtNombre.Text;
                        Paciente.FechaNacimiento = dtiFechaNacimiento.Value;
                        Paciente.Raza = txtRaza.Text;
                        Paciente.Especie = cmbEspecie.SelectedItem.ToString();
                        Paciente.Propietario = txtPropietario.Text;
                        Paciente.Direccion = txtDireccion.Text;
                        Paciente.Sexo = cmbSexo.SelectedItem.ToString();
                        Paciente.Estado = 1;
                        Paciente.FechaRegistro = DateTime.Now;
                        Paciente.UsuarioID = frmLogin.iCodUser;

                        if (AdmClinica.InsertPaciente(Paciente))
                        {
                            MessageBox.Show("PACIENTE REGISTRADO CORRECTAMENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PostConstructor();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL REGISTRAR EL PACIENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    try
                    {
                        Paciente.Nombre = txtNombre.Text;
                        Paciente.FechaNacimiento = dtiFechaNacimiento.Value;
                        Paciente.Raza = txtRaza.Text;
                        Paciente.Especie = cmbEspecie.SelectedItem.ToString();
                        Paciente.Propietario = txtPropietario.Text;
                        Paciente.Direccion = txtDireccion.Text;
                        Paciente.Sexo = cmbSexo.SelectedItem.ToString();
                        Paciente.Estado = 1;
                        Paciente.FechaRegistro = DateTime.Now;
                        Paciente.UsuarioID = frmLogin.iCodUser;

                        if (AdmClinica.UpdatePaciente(Paciente))
                        {
                            MessageBox.Show("PACIENTE ACTUALIZADO CORRECTAMENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PostConstructor();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL ACTUALIZAR EL PACIENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidarRegistro()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("INGRESE EL NOMBRE DEL PACIENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPropietario.Text))
            {
                MessageBox.Show("INGRESE EL NOMBRE DEL PROPIETARIO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPropietario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("INGRESE LA DIRECCION", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtRaza.Text))
            {
                MessageBox.Show("INGRESE LA RAZA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRaza.Focus();
                return false;
            }

            if (cmbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONE EL SEXO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSexo.Focus();
                return false;
            }

            if (cmbEspecie.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONE LA ESPECIE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecie.Focus();
                return false;
            }

            if (dtiFechaNacimiento.Value == null)
            {
                MessageBox.Show("INGRESE LA FECHA DE NACIMIENTO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtiFechaNacimiento.Focus();
                return false;
            }

            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    Int32 IDPaciente = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[0].Value.ToString());
                    Paciente = AdmClinica.CargaPaciente(IDPaciente);
                    if (Paciente.Estado != -1)
                    {
                        CargarEspecies();
                        CargarSexo();

                        txtNombre.Text = Paciente.Nombre;
                        txtPropietario.Text = Paciente.Propietario;
                        txtRaza.Text = Paciente.Raza;
                        dtiFechaNacimiento.Value = Paciente.FechaNacimiento;
                        txtDireccion.Text = Paciente.Direccion;
                        cmbEspecie.SelectedItem = Paciente.Especie;
                        cmbSexo.SelectedItem = Paciente.Sexo;

                        txtNombre.Enabled = true;

                        txtPropietario.Enabled = true;


                        txtRaza.Enabled = true;

                        txtDireccion.Enabled = true;

                        cmbEspecie.Enabled = true;
                        cmbSexo.Enabled = true;
                        dtiFechaNacimiento.Enabled = true;

                        btnNuevo.Enabled = false;
                        btnGuardar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    Int32 IDPaciente = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[0].Value.ToString());
                    string NombreMascota = dgvDetalle.CurrentRow.Cells[1].Value.ToString();
                    var dResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR A " + NombreMascota + "?", "SGE SYSTEM'S", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        if (AdmClinica.DeletePaciente(IDPaciente))
                        {
                            MessageBox.Show("PACIENTE ELIMINADO CORRECTAMENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PostConstructor();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL ELIMINAR EL PACIENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.RowCount > 0)
            {
                if (ParentForm != null)
                {
                    if (dgvDetalle.CurrentRow != null)
                    {
                        if (dgvDetalle.CurrentRow.Cells[10].Value.ToString().Equals("ACTIVO"))
                        {
                            if (ParentForm.Name.Equals("frmHistoriaClinica"))
                            {
                                frmHistoriaClinica frm = (frmHistoriaClinica)this.ParentForm;
                                frm.ObtenerDesdeBuscador(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[0].Value.ToString()));
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO PUEDES SELECCIONAR UN PACIENTE QUE SE ENCUENTRA INACTIVO / FALLECIDO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
