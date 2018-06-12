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
    public partial class frmRendicionesVigentes : DevComponents.DotNetBar.Office2007Form
    {
       
        public Int32 tipocaja=0;
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;



        public frmRendicionesVigentes()
        {
            InitializeComponent();
        }

        private void Listaliquidaciones()
        {
            //dgvLiquidaciones.DataSource = data;
            //data.DataSource = AdmCaja.ListaLiquidacionesVigentes(frmLogin.iCodSucursal, tipocaja);
            //data.Filter = String.Empty;
            //filtro = String.Empty;
        }

        private void frmRendicionesVigentes_Load(object sender, EventArgs e)
        {
            Listaliquidaciones();
        }

        private void s_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLiquidaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvLiquidaciones.RowCount > 0)
            {
                biIngresarCaja.Enabled = true;
            }
            else
            { biIngresarCaja.Enabled = true; }
        }

        private void biIngresarCaja_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaChicaRegistro"] != null)
            {
                Application.OpenForms["frmCajaChicaRegistro"].Activate();
            }
            else
            {
                frmCajaChicaRegistro form = new frmCajaChicaRegistro();
                form.tipoCaja = tipocaja;
                form.Tipo = 1;
                form.tip = 2;
                form.Proceso = 1;
                form.AperturaCaja = 2;
                form.txtDocumento.Text = dgvLiquidaciones.SelectedRows[0].Cells[numDocumento.Name].Value.ToString();
                form.txtMonto.Text = dgvLiquidaciones.SelectedRows[0].Cells[montoLiquidado.Name].Value.ToString();
                form.txtMontoPendiente.Visible = false;
                form.label9.Visible = false;
                form.label6.Visible = false;
                form.txtRecibo.Visible = false;
                form.ShowDialog();
                Listaliquidaciones();
                this.Close();
            }
        }
    }
}
