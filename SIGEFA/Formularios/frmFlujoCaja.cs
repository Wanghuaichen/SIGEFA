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
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmFlujoCaja : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmFlujoCaja AdmFlu = new clsAdmFlujoCaja();
        clsFlujoCaja flu = new clsFlujoCaja();
        clsCaja aper = new clsCaja();
        clsAdmAperturaCierre AdmAper = new clsAdmAperturaCierre();
        

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        Int32 proceso = 0;

        public frmFlujoCaja()
        {
            InitializeComponent();
        }

        private void frmFlujoCaja_Load(object sender, EventArgs e)
        {
            CargarFlujoCaja();
        }

        private void CargarFlujoCaja()
        {
            dgvFlujoCaja.DataSource = data;
            data.DataSource = AdmFlu.MuestraFlujoCaja(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvFlujoCaja.ClearSelection();

            DarFormato();
        }

        public void SOLONumeros(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DarFormato()
        {
            if (dgvFlujoCaja.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFlujoCaja.Rows)
                {
                    if (Convert.ToString(row.Cells[tipo.Name].Value) == "EGRESO")
                    {
                        row.Cells[monto.Name].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[monto.Name].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void dgvFlujoCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmFlujoCajaRegistro frm = new frmFlujoCajaRegistro();
            frm.Proceso = 3;
            frm.CodFlujoCaja = Convert.ToInt32(dgvFlujoCaja.SelectedRows[0].Cells[codigo.Name].Value);
            frm.txtconcepto.Text = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[concepto.Name].Value);
            frm.txtmonto.Text = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[monto.Name].Value);
            frm.dtpfecha.Value = Convert.ToDateTime(dgvFlujoCaja.SelectedRows[0].Cells[fecha.Name].Value);
            String tipos;
            tipos = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[tipo.Name].Value);

            if (tipos == "INGRESO")
            { frm.cboTipo.SelectedItem = "INGRESO"; }
            else if (tipos == "EGRESO")
            { frm.cboTipo.SelectedItem = "EGRESO"; }

            frm.ShowDialog();            
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmFlujoCajaRegistro frm = new frmFlujoCajaRegistro();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargarFlujoCaja();
        }

        private void biEditar_Click(object sender, EventArgs e)
        {
            frmFlujoCajaRegistro frm = new frmFlujoCajaRegistro();
            frm.Proceso = 2;
            frm.CodFlujoCaja = Convert.ToInt32(dgvFlujoCaja.SelectedRows[0].Cells[codigo.Name].Value);
            frm.txtconcepto.Text = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[concepto.Name].Value);
            frm.txtmonto.Text = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[monto.Name].Value);
            frm.dtpfecha.Value = Convert.ToDateTime(dgvFlujoCaja.SelectedRows[0].Cells[fecha.Name].Value);
            String tipos;
            tipos = Convert.ToString(dgvFlujoCaja.SelectedRows[0].Cells[tipo.Name].Value);

            if (tipos == "INGRESO")
            { frm.cboTipo.SelectedItem = "INGRESO"; }
            else if (tipos == "EGRESO")
            { frm.cboTipo.SelectedItem = "EGRESO"; }

            frm.ShowDialog();
            CargarFlujoCaja();
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            flu.CodFlujoCaja = Convert.ToInt32(dgvFlujoCaja.SelectedRows[0].Cells[codigo.Name].Value);
            if (dgvFlujoCaja.CurrentRow.Index != -1 && flu.CodFlujoCaja != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "CONTROL DE FLUJO DE CAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmFlu.Delete(flu.CodFlujoCaja,frmLogin.iCodAlmacen))
                    {
                        CargarFlujoCaja();

                        biEliminar.Enabled = false;
                        biEditar.Enabled = false;
                    }
                }
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            CargarFlujoCaja();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFlujoCaja.RowCount > 0)
                {
                    frmParamLiquidacionCaja frm = new frmParamLiquidacionCaja();
                    frm.ShowDialog();
                }
                else
                { MessageBox.Show("No Tiene Datos para Mostrar en Reporte", "Alerta ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
