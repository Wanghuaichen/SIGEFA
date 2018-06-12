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

namespace SIGEFA.Formularios
{
    public partial class frmAperturaCaja : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAperturaCierre AdmApe = new clsAdmAperturaCierre();
        clsCaja ape = new clsCaja();

        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void AperturaCaja_Load(object sender, EventArgs e)
        {
            CargarCaja();
            toolTip1.SetToolTip(btnaceptar, "Pulse Aqui Para Aperturar Caja del Día , con el Monto Ingresado");
            toolTip1.SetToolTip(txtmonto, "Ingrese Monto Para la Apertura de Caja Actual");
        }

        private void CargarCaja()
        {
            try
            {
                ape = AdmApe.CargaAperturaCaja(frmLogin.iCodAlmacen);
                if (ape != null)
                {
                    txtmonto.Text = Convert.ToString(ape.Montoapertura);
                    if (Convert.ToInt32(ape.Estado) == 1)
                    {
                        txtmonto.Enabled = false;
                        btnaceptar.Enabled = false;
                        btnaceptar.Visible = false;
                    }
                }
                else
                {
                    ape = new clsCaja();
                    txtmonto.Text = "00.00";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }  
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }  
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal montoApertura = ape.Montoapertura;
                ape.Montoapertura = Convert.ToDecimal(txtmonto.Text);
                ape.Fechaapertura = Convert.ToDateTime(System.DateTime.Now.ToString());
                ape.CodUser = frmLogin.iCodUser;
                ape.Codsucursal = frmLogin.iCodAlmacen;
                if (ape.Montoapertura != Convert.ToDecimal(montoApertura))
                {
                    if (AdmApe.Insert(ape))
                    {

                        MessageBox.Show("Los datos se guardaron correctamente", "APERTURA DE CAJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                { this.Close(); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }  
        }
    }
}
