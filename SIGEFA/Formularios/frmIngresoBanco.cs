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
    public partial class frmIngresoBanco : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmBanco AdmBanco = new clsAdmBanco();
        clsBanco banco = new clsBanco();
        clsAdmLetra AdmLetra = new clsAdmLetra();
        clsLetra letra = new clsLetra();
        clsValidar valido = new clsValidar();
        public Int32 CodLetra = 0;
        public Int32 Proceso = 0;

        public frmIngresoBanco()
        {
            InitializeComponent();
        }

        private void frmIngresoBanco_Load(object sender, EventArgs e)
        {
            CargaBancos();
            CargaLetra();
        }

        private void CargaBancos()
        {
            cmbBancos.DataSource = AdmBanco.CargaBancos();
            cmbBancos.DisplayMember = "descripcion";
            cmbBancos.ValueMember = "codBanco";            
        }

        private void CargaLetra()
        {
            letra = AdmLetra.CargaLetra(CodLetra);
            if (letra != null)
            {
                cmbBancos.SelectedValue = letra.CodBanco;
                txtnumero.Text = letra.NumeroUnico;
            }
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
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                letra.CodBanco = Convert.ToInt32(cmbBancos.SelectedValue);
                letra.NumeroUnico = txtnumero.Text;
                if (Proceso == 1)
                {
                    if (AdmLetra.update(letra))
                    {
                        MessageBox.Show("Se realizó en registro correctamente", "Letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                        this.Close();
                    }
                }                
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            valido.SOLONumeros(sender, e);
        }
    }
}
