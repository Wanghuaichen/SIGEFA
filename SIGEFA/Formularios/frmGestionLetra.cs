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


namespace SIGEFA.Formularios
{
    public partial class frmGestionLetra : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmLetra AdmLetra = new clsAdmLetra();
        public clsLetra letra = new clsLetra();
        clsProveedor prov = new clsProveedor();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        public Int32 Proceso = 0;
        public Int32 CodProveedor = 0;
        clsValidar valido = new clsValidar();
        Int32 CodDocumento = 9; // aca debe ir el codigo del tipo documento letra el cual se debe indicar en los parametros de configuracion principal
        clsMoneda Mon = new clsMoneda();
        clsAdmMoneda AdmMoned = new clsAdmMoneda();


        public frmGestionLetra()
        {
            InitializeComponent();
        }

        private void frmGestionLetra_Load(object sender, EventArgs e)
        {
            cargaMoneda();

                
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
                txtTipoCambio.Visible = true;
            }
            else
            {
                txtTipoCambio.Text = "0";
            }

            
            if (Proceso == 2)
            {
                CargaLetra();
            }

        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMoned.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void CargaLetra()
        {
            letra = AdmLetra.CargaLetra(letra.CodLetra);
            if (letra != null)
            {
                txtNumLetra.Text = letra.NumDocumento;
                txtDocRef.Text = letra.DocumentoReferencia;
                txtProveedor.Text = letra.RazonSocialProveedor;
                dtpFecha.Value = letra.FechaEmision;
                dtpFechaVence.Value = letra.FechaVencimiento;
                cmbMoneda.SelectedValue = letra.CodMoneda;
                txtTipoCambio.Text = letra.TipoCambio.ToString();
                txtMonto.Text = letra.Monto.ToString();
            }
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = 2;
                    form.ShowDialog();
                    if (CodProveedor != 0) { CargaProveedor(); ProcessTabKey(true); } else { BorrarProveedor(); }
                }
            }
        }

        private void CargaProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtProveedor.Text = prov.RazonSocial;
        }

        private void BorrarProveedor()
        {
            prov = AdmProv.MuestraProveedor(CodProveedor);
            txtProveedor.Text = "";
        }

        private void cmbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbMoneda_Leave(object sender, EventArgs e)
        {
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
            if (tc != null)
            {
                txtTipoCambio.Text = tc.Venta.ToString();
                txtTipoCambio.Visible = true;
                label16.Visible = true;
            }
            else
            {
                txtTipoCambio.Text = "0";
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.Visible)
            {
                tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, Convert.ToInt32(cmbMoneda.SelectedValue));
                if (tc != null)
                {
                    txtTipoCambio.Text = tc.Venta.ToString();
                }
                else
                {
                    MessageBox.Show("No existe tipo de cambio registrado en esta fecha", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFecha.Value = DateTime.Now.Date;
                    dtpFecha.Focus();
                }
            }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void frmGestionLetra_Shown(object sender, EventArgs e)
        {
            if (Proceso == 1)
            {
                if (txtTipoCambio.Visible)
                {
                    if (tc == null)
                    {
                        MessageBox.Show("Debe registrar el tipo de cambio del día", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        txtTipoCambio.Text = tc.Venta.ToString();
                    }
                }
            }
            txtNumLetra.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                letra.CodAlmacen = frmLogin.iCodAlmacen;
                letra.CodDocumento = CodDocumento;
                letra.NumDocumento = txtNumLetra.Text;
                letra.DocumentoReferencia = txtDocRef.Text;
                letra.CodProveedor = CodProveedor;
                letra.FechaEmision = dtpFecha.Value;
                letra.FechaVencimiento = dtpFechaVence.Value;
                letra.IngresoEgreso = false;
                letra.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                letra.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                letra.Monto = Convert.ToDouble(txtMonto.Text);
                letra.MontoPendiente = Convert.ToDouble(txtMonto.Text);
                if (Proceso == 1)
                {
                    if (AdmLetra.insert(letra))
                    {
                        MessageBox.Show("Se generó la letra correctamente", "Letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                        //this.Close();
                    }
                }
                else if (Proceso == 2)
                {
                    if (AdmLetra.update(letra))
                    {
                        MessageBox.Show("La letra se actualizó correctamente", "Letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                        //this.Close();
                    }
                }
            }
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            valido.SOLONumeros(sender, e);
        }

        private void txtNumLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido.enteros(e);
        }
      

    }
}
