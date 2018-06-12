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
    public partial class frmRegistroChequeCaja : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmSucursal admSucur = new clsAdmSucursal();        
        clsValidar val = new clsValidar();

        public frmRegistroChequeCaja()
        {
            InitializeComponent();
        }

        private void CargaSucursales()
        {
            cmbSucursal.DataSource = admSucur.ListaSucursales();
            cmbSucursal.DisplayMember = "nombre";
            cmbSucursal.ValueMember = "codSucursal";
            cmbSucursal.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (superValidator1.Validate())
            //{
            //    Caja.NumCheque = txtNumCheque.Text.Trim();
            //    Caja.Responsable = txtResponsable.Text.Trim();
            //    Caja.MontoLiquidado = Convert.ToDecimal(txtMontoLiquidar.Text.Trim());
            //    Caja.FechaLiquidacion = dtpFechaLiquidacion.Value;
            //    Caja.CodUser = frmLogin.iCodAlmacen;
            //    //Caja.CodSucursal = frmLogin.iCodSucursal;
            //    Caja.CodSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
            //    if (cbotraCaja.Checked) Caja.Tipocaja = 2;
            //    else Caja.Tipocaja = 1;
            //    if (AdmCaja.InsertLiquidacion(Caja))
            //    {
            //        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Tesoreria", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //        Limpiar();
            //        this.Close();
            //        //ListaRendiciones();
            //    }
            //}
        }

        private void Limpiar()
        {
            cmbSucursal.SelectedIndex = -1;
            txtMontoLiquidar.Text = "";
            txtNumCheque.Text = "";
            txtResponsable.Text = "";
            //dtpFechaLiquidacion.Value = Convert.ToDateTime(System.DateTime.Now);
            btnGuardar.Enabled = false;
        }

        private void frmRegitroChequeCaja_Load(object sender, EventArgs e)
        {
            CargaSucursales();
            dtpFechaLiquidacion.Value= DateTime.Now.Date;
            cmbSucursal.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtResponsable_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (c.SelectedIndex != -1)
                      e.IsValid = true;
                else
                      e.IsValid = false;
            else e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "") e.IsValid = true;
            else e.IsValid = false;
        }

        private void txtMontoLiquidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender,e);
        }

        private void txtNumCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumerosDoc(sender,e);
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "") e.IsValid = true;
            else e.IsValid = false;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "") e.IsValid = true;
            else e.IsValid = false;
        }

        private void cmbSucursal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            txtMontoLiquidar.Focus();
        }

        private void txtMontoLiquidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumCheque.Focus();
            }
        }

        private void txtNumCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaLiquidacion.Focus();
            }
        }

        private void dtpFechaLiquidacion_ValueChanged(object sender, EventArgs e)
        {
            txtResponsable.Focus();
        }

        private void txtResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }        
    }
}
