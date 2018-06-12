using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmTesoreria : DevComponents.DotNetBar.Office2007Form
    {
        clsValidar val = new clsValidar();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        //clsAdmCajaChica AdmCaja = new clsAdmCajaChica();
        //clsCajaChica Caja = new clsCajaChica();

        private Int32 CodRendicion = 0;



        public frmTesoreria()
        {
            InitializeComponent();
        }

        private void frmTesoreria_Load(object sender, EventArgs e)
        {
            ListaRendiciones();
        }

        private void ListaRendiciones()
        {
            //dgvRendiciones.DataSource = data;
            //data.DataSource = AdmCaja.ListaRendicionesTesoreria();
            //data.Filter = String.Empty;
            //filtro = String.Empty;
        }

        private void dgvRendiciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvRendiciones.Rows.Count >= 1 && e.Row.Selected)
            {
                    CodRendicion = Convert.ToInt32(e.Row.Cells[codigo.Name].Value.ToString());
                    txtSucursal.Text = e.Row.Cells[sucursal.Name].Value.ToString();
                    txtMontoRendido.Text = e.Row.Cells[montoAprobado.Name].Value.ToString();
                    txtMontoLiquidar.Text = e.Row.Cells[montoAprobado.Name].Value.ToString();
                    txtMontoLiquidar.Enabled = false;
                    btnGuardar.Enabled = true;
            }
            else { btnGuardar.Enabled = false; }
        }

        private void Limpiar()
        {
            txtSucursal.Text = "";
            txtMontoRendido.Text = "";
            txtMontoLiquidar.Text = "";
            txtNumCheque.Text = "";
            txtResponsable.Text = "";
            dtpFechaLiquidacion.Value = Convert.ToDateTime(System.DateTime.Now);
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Caja.CodRendicion = CodRendicion;
            //Caja.NumCheque = txtNumCheque.Text.Trim();
            //Caja.Responsable = txtResponsable.Text.Trim();
            //Caja.MontoLiquidado = Convert.ToDecimal(txtMontoLiquidar.Text.Trim());
            //Caja.FechaLiquidacion = dtpFechaLiquidacion.Value;

            //if (AdmCaja.GeneraLiquidacion(Caja))
            //{
            //    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Tesoreria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Limpiar();
            //    ListaRendiciones();
            //}
        }

        private void biSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMontoLiquidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }
    }
}
