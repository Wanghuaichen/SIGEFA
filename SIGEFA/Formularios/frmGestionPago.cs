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
    public partial class frmGestionPago : DevComponents.DotNetBar.Office2007Form
    {
        private Boolean textblanco;
        public Double Monto;
        public Double Cambio;
        public Double Pagado;
        public clsNotaSalida Nota = new clsNotaSalida();
        public clsFactura Compra = new clsFactura();
        public clsFacturaVenta Venta = new clsFacturaVenta();
        public clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        clsConsultasExternas ext = new clsConsultasExternas();
        clsValidar val = new clsValidar();

        public frmGestionPago()
        {
            InitializeComponent();
        }        

        private void btUno_Click(object sender, EventArgs e)
        {
            PressButton(btUno);
        }

        private void PressButton(Button Boton)
        {
            if (textblanco)
            {
                txtPagado.Text = "";
                txtPagado.Text = Boton.Text;
                textblanco = false;
            }
            else
            {
                txtPagado.Text = txtPagado.Text + Boton.Text;
            }
        }

        private void btDos_Click(object sender, EventArgs e)
        {
            PressButton(btDos);
        }

        private void btTres_Click(object sender, EventArgs e)
        {
            PressButton(btTres);
        }

        private void btCuatro_Click(object sender, EventArgs e)
        {
            PressButton(btCuatro);
        }

        private void btCinco_Click(object sender, EventArgs e)
        {
            PressButton(btCinco);
        }

        private void btSeis_Click(object sender, EventArgs e)
        {
            PressButton(btSeis);
        }

        private void btSiete_Click(object sender, EventArgs e)
        {
            PressButton(btSiete);
        }

        private void btOcho_Click(object sender, EventArgs e)
        {
            PressButton(btOcho);
        }

        private void btNueve_Click(object sender, EventArgs e)
        {
            PressButton(btNueve);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPagado.Text = "0";
            textblanco = true;
        }

        private void btCero_Click(object sender, EventArgs e)
        {
            PressButton(btCero);
        }

        private void btPunto_Click(object sender, EventArgs e)
        {
            if (textblanco)
            {
                {
                    if(txtPagado.Text.Contains(","))
                    return;

                    textblanco = false;
                }
            }
            else
            {
                {
                    if (txtPagado.Text.Contains(","))
                        return;

                    txtPagado.Text = txtPagado.Text + ",";
                }

            }

        }

        private void frmGestionPago_Load(object sender, EventArgs e)
        {
            txtTotal.Text = Monto.ToString();
           
        }

        private void frmGestionPago_Shown(object sender, EventArgs e)
        {
            txtPagado.Text = "0.00";
            txtPagado.Focus();
        }

        private void txtPagado_TextChanged(object sender, EventArgs e)
        {
            actualizacambio();
        }

        private void actualizacambio()
        {
            if (txtPagado.Text.Length > 0)
            {
                Cambio = Monto - Convert.ToDouble(txtPagado.Text);
                if (Cambio > 0)
                {
                    label3.Text = "A pagar";
                    txtVuelto.Text = Cambio.ToString();
                }
                else
                {
                    label3.Text = "Cambio";
                    txtVuelto.Text = (Cambio * -1).ToString();
                }

            }
        }

        private void txtPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            Pag.CodNota = Nota.CodNotaSalida;
            Pag.MontoCobrado = Convert.ToDecimal(Nota.Total);
            Pag.MontoPagado = Convert.ToDecimal(txtPagado.Text);
            Pag.Vuelto = Convert.ToDecimal(txtVuelto.Text);
            Pag.CodUser = frmLogin.iCodUser;
            if (Admpag.insert(Pag))
            {   
                MessageBox.Show("Los datos se guardaron correctamente", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                imprimecomprobante();
                this.Close();
            }
        }

        private void imprimecomprobante()
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }


    }
}
