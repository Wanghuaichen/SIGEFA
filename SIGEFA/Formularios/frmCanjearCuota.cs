using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
using MySql.Data.MySqlClient;

namespace SIGEFA
{
    public partial class frmCanjearCuota : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsAdmNotaIngreso AdmNotaI = new clsAdmNotaIngreso();
        public clsNotaIngreso notaI = new clsNotaIngreso();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsAdmPrestamoBancario AdmPreBan = new clsAdmPrestamoBancario();
        public clsPrestamoBancario preBan = new clsPrestamoBancario();
        clsAdmCuota AdmCuota = new clsAdmCuota();
        clsCuota cuota = new clsCuota();
        Boolean bok = false;
        public Int32 Procede = 0;
        DateTimePicker selfecha = new DateTimePicker();

        public frmCanjearCuota()
        {
            InitializeComponent();
        }

        private void frmCanjearCuota_Load(object sender, EventArgs e)
        {
            CargaCuentaxPagar();
            selfecha.Format = DateTimePickerFormat.Short;
            selfecha.Visible = false;
            selfecha.Width = 100;
            dgvCuotas.Controls.Add(selfecha);
            selfecha.ValueChanged += new System.EventHandler(this.selfecha_ValueChanged);
            txtDiasEntreCuo.Text = "0";
            txtNDEC.Visible = false;
            if (Procede == 2) {
                txtDiasEntreCuo.Visible = false;
                label5.Visible = false;
                nudCuotas.Visible = false;
                txtNDEC.Visible = true;
                btnGuardar.Enabled = false;
                dgvCuotas.ReadOnly = true;
                cargaCuotas();
            }
            /*for (int i = 1; i <= 4; i++)
            {
                nudCuotas.Value = i;
            }*/

        }

        private void CargaCuentaxPagar()
        {
            preBan = AdmPreBan.CargaPrestamoBancario(Convert.ToInt32(preBan.CodPrestamoBancario));
            txtCodPreBan.Text = preBan.CodPrestamoBancario.ToString();
            txtBanco.Text = preBan.DescBanco;
            txtPrestamo.Text = String.Format("{0:#,##0.00}", preBan.Montoprestamo);
            txtInteres.Text = String.Format("{0:#,##0.00}", preBan.Montointeres); 
            txtTotal.Text = String.Format("{0:#,##0.00}", preBan.Montodevolver); 
            txtMoneda.Text = preBan.DescMoneda;
            txtTipoCambio.Text = String.Format("{0:#,##0.000}", preBan.TipoCambio);
            dtpFecha.Value = Convert.ToDateTime(preBan.Fechaaprobacion);
            //MessageBox.Show(preBan.CantCuotas + "" + Procede);
            if (Procede == 2)
            {
                txtNDEC.Text = preBan.CantCuotas.ToString();
            }
        }

        private void cargaCuotas()
        {
            dgvCuotas.DataSource = data;
            data.DataSource =AdmCuota.MuestraListaCuotasPrestamo(preBan.CodPrestamoBancario);
            dgvCuotas.ClearSelection();
        }

        private void nudCuotas_ValueChanged(object sender, EventArgs e)
        {
            if (nudCuotas.Value >= 0)
            {
                if (Convert.ToInt32(txtDiasEntreCuo.Text) > 0)
                {
                    LlenarProgramaLetras();
                }
                else
                {
                    MessageBox.Show("Ingrese Nro de días entre Cuotas", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (nudCuotas.Value > 0)
            {
                LlenarProgramaLetras();
            }
        }

        private void LlenarProgramaLetras()
        {
            dgvCuotas.Rows.Clear();
            if (nudCuotas.Value != -1 && txtDiasEntreCuo.Text != "")
            {
                Decimal cuota = 0;
                cuota = preBan.Montodevolver / Convert.ToDecimal(nudCuotas.Value);
                for (int i = 1; i <= nudCuotas.Value; i++)
                {
                    dgvCuotas.Rows.Add("", preBan.CodPrestamoBancario, preBan.CodMoneda, dtpFecha.Value.Date.ToShortDateString(), 
                        CalcularFechaCuota().ToShortDateString(), "", preBan.DescMoneda, "", cuota, cuota, "", "", "");
                }
                btnGuardar.Enabled = true;
            }
        }

        private DateTime CalcularFechaCuota()
        {
            DateTime fechaanterior = new DateTime();
            DateTime fechaactual = new DateTime();
            if (dgvCuotas.Rows.Count == 0)
            {
                fechaanterior = dtpFecha.Value.Date;
            }
            else
            {
                fechaanterior = Convert.ToDateTime(dgvCuotas.Rows[(dgvCuotas.Rows.Count - 1)].Cells[fechavence.Name].Value);
            }
            fechaactual = fechaanterior.AddDays(Convert.ToInt32(txtDiasEntreCuo.Text));
            return fechaactual;
        }

        private void selfecha_ValueChanged(object sender, EventArgs e)
        {
            dgvCuotas.CurrentCell.Value = selfecha.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Int32 cuoNro = 0;
            foreach (DataGridViewRow row in dgvCuotas.Rows)
            {
                cuoNro = cuoNro + 1;
                cuota.CodPrestamoBancario = Convert.ToInt32(preBan.CodPrestamoBancario);
                cuota.NroCuota = cuoNro;
                cuota.CodMoneda = preBan.CodMoneda;
                cuota.FechaEmision = Convert.ToDateTime(row.Cells[fechaemision.Name].Value);
                cuota.FechaVencimiento = Convert.ToDateTime(row.Cells[fechavence.Name].Value);
                cuota.Monto = Convert.ToDecimal(row.Cells[monto.Name].Value);
                cuota.MontoPendiente = Convert.ToDecimal(row.Cells[pendiente.Name].Value);
                if (AdmCuota.insert(cuota))
                {
                    bok = true;
                }
                else
                {
                    bok = false;
                }
            }
            if (bok)
            {
                MessageBox.Show("Se generaron las cuotas correctamente", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dgvCuotas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvCuotas.Focused && e.ColumnIndex == dgvCuotas.Columns[fechavence.Name].Index)
                {
                    selfecha.Location = dgvCuotas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    selfecha.Visible = true;
                    if (dgvCuotas.CurrentCell.Value != DBNull.Value)
                    {
                        selfecha.Value = Convert.ToDateTime(dgvCuotas.CurrentCell.Value);
                    }
                    else
                    {
                        selfecha.Value = DateTime.Today;
                    }
                }
                else
                {
                    selfecha.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCuotas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCuotas.Focused && e.ColumnIndex == dgvCuotas.Columns[fechavence.Name].Index)
                {
                    dgvCuotas.CurrentCell.Value = selfecha.Value.Date;
                }
                if (dgvCuotas.Focused && e.ColumnIndex == dgvCuotas.Columns[monto.Name].Index)
                {
                    dgvCuotas.CurrentRow.Cells[pendiente.Name].Value = dgvCuotas.CurrentCell.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiasEntreCuo_TextChanged(object sender, EventArgs e)
        {
            if (txtDiasEntreCuo.Text == "")
            {
                txtDiasEntreCuo.Text = "0.00";
            }
        }

    }
}
