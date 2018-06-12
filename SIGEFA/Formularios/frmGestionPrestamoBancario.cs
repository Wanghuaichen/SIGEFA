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
    public partial class frmGestionPrestamoBancario : Form
    {
        clsAdmMoneda AdmMoned = new clsAdmMoneda();
        clsAdmBanco AdmBan = new clsAdmBanco();
        clsValidar val = new clsValidar();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        public clsPrestamoBancario presBanc = new clsPrestamoBancario();
        clsAdmPrestamoBancario admPreBan = new clsAdmPrestamoBancario();
        public Int32 Proceso = 0;

        public frmGestionPrestamoBancario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbMoneda.SelectedIndex > -1 && cbBanco.SelectedIndex > -1 && Convert.ToDecimal(txtPrestamo.Text) > 0)
            {
                presBanc.CodBanco = Convert.ToInt32(cbBanco.SelectedValue);
                presBanc.CodMoneda = Convert.ToInt32(cbMoneda.SelectedValue);
                presBanc.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                presBanc.Montoprestamo = Convert.ToDecimal(txtPrestamo.Text);
                presBanc.Montointeres = Convert.ToDecimal(textInteres.Text);
                presBanc.Montodevolver = Convert.ToDecimal(txtDevolver.Text);
                presBanc.Fechaaprobacion = dtFecAprobacion.Value;
                presBanc.Fechavencimiento = dtFecVencimiento.Value;
                presBanc.Descripcion = txtDescripcion.Text;
                if (Proceso == 1 || Proceso == 3 || Proceso == 4)
                {
                    if (admPreBan.insert(presBanc))
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (Proceso == 1) { muestralista(); }
                        this.Close();
                    }
                }
                //else if (Proceso == 2)
                //{
                //    if (admCli.update(cli))
                //    {
                //        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        muestralista();
                //        this.Close();
                //    }
                //}
            }
            else
            {
                MessageBox.Show("Datos Incompletos", "Prestamo Bancario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaMoneda()
        {
            cbMoneda.DataSource = AdmMoned.ListaMonedas();
            cbMoneda.DisplayMember = "descripcion";
            cbMoneda.ValueMember = "codMoneda";
        }

        private void CargarBancos()
        {
            try
            {
                cbBanco.DataSource = AdmBan.MuestraBancos();
                cbBanco.DisplayMember = "descripcion";
                cbBanco.ValueMember = "codbanco";
                cbBanco.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void calculaDevolver()
        {
            Decimal total=Convert.ToDecimal(txtPrestamo.Text) + Convert.ToDecimal(textInteres.Text);
            txtDevolver.Text = String.Format("{0:#,##0.00}", total);
        }

        private void frmGestionPrestamoBancario_Load(object sender, EventArgs e)
        {
            cargaMoneda();
            CargarBancos();
            txtPrestamo.Text = "0.00";
            textInteres.Text = "0.00";
            tc = AdmTc.CargaTipoCambio(DateTime.Today.Date, 2);
            txtTipoCambio.Text = tc.Compra.ToString();
        }

        private void txtPrestamo_TextChanged(object sender, EventArgs e)
        {
            if (txtPrestamo.Text == "")
            {
                txtPrestamo.Text = "0.00";
            }
        }

        private void txtPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void textInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void textInteres_TextChanged(object sender, EventArgs e)
        {
            if (textInteres.Text == "")
            {
                textInteres.Text = "0.00";
            }
        }

        private void txtPrestamo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmGestionPrestamoBancario_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrestamo_Leave(object sender, EventArgs e)
        {
            calculaDevolver();
        }

        private void textInteres_Leave(object sender, EventArgs e)
        {
            calculaDevolver();
        }
    }
}
