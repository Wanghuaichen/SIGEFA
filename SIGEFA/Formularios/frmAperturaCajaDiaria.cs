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
    public partial class frmAperturaCajaDiaria : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAperturaCierre AdmApe = new clsAdmAperturaCierre();
        clsCaja caja = new clsCaja();
        public Int32 tipocaja = 0;

        public Int32 Proceso = 0;
        

        public frmAperturaCajaDiaria()
        {
            InitializeComponent();
        }

        private void AperturaCaja_Load(object sender, EventArgs e)
        {
            if (Proceso == 0)
            {
                CargarCaja();
            }
            
            toolTip1.SetToolTip(btnaceptar, "Pulse Aqui Para Aperturar Caja del Día , con el Monto Ingresado");
            toolTip1.SetToolTip(txtmonto, "Ingrese Monto Para la Apertura de Caja Actual");
        }

        private void CargarCaja()
        {
            try
            {
                caja = AdmApe.CargaCierreAnterior(frmLogin.iCodSucursal, tipocaja);
                if (caja != null)
                {
                    txtmonto.Text = caja.Montocierre.ToString("###.####");
                }
                else
                {
                    caja = new clsCaja();
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
                caja.Codsucursal = frmLogin.iCodSucursal;
                caja.Tipo = tipocaja; // 1 caja ventas en efectivo
                caja.Montoapertura = Convert.ToDecimal(txtmonto.Text);
                caja.Montocierre = 0m;
                caja.Fechaapertura = Convert.ToDateTime(System.DateTime.Now.ToString());
                caja.TotalIngreso = 0m;
                caja.TotalEgreso = 0m;
                caja.TotalVentaEfectivo = 0m;
                caja.TotalDisponible = Convert.ToDecimal(txtmonto.Text);
                caja.CodUser = frmLogin.iCodUser;
                caja.Codalmacen = frmLogin.iCodAlmacen;

                if (AdmApe.InsertAperturaCaja(caja))
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "APERTURA DE CAJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                { this.Close(); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }  
        }
    }
}
