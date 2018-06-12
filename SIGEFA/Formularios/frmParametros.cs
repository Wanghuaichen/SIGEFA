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
    public partial class frmParametros : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();

        public frmParametros()
        {
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            CargaConfiguracion();
        }

        private void CargaConfiguracion()
        {
            if (frmLogin.Configuracion != null)
            {

                txtIGV.Text = frmLogin.Configuracion.IGV.ToString();
            }
            else
            {
                frmLogin.Configuracion = new clsParametros();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIGV.Text != "") { frmLogin.Configuracion.IGV = Convert.ToDouble(txtIGV.Text); }
            if (AdmEmp.UpdateConfiguracion(frmLogin.Configuracion))
            {
                frmLogin.Configuracion = AdmEmp.CargaConfiguracion();
                MessageBox.Show("Los datos se guardaron correctamente", "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
