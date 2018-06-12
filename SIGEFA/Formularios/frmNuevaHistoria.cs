using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Entidades;
using SIGEFA.Administradores;

namespace SIGEFA.Formularios
{
    public partial class frmNuevaHistoria : Office2007Form
    {
        private Form parentForm;
        private clsHistoria Historia;
        private clsAdmClinica AdmClin;

        public frmNuevaHistoria(Form _parentForm, clsHistoria _Historia)
        {
            InitializeComponent();
            parentForm = _parentForm;
            Historia = _Historia;
            PostConstructor();
        }

        private void PostConstructor()
        {
            AdmClin = new clsAdmClinica();
            this.TitleText = "<b>Nueva Ocurrencia | Historia N° " + Historia.Numero + "</b>";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    clsDetalleHistoria Det = new clsDetalleHistoria();
                    Det.HistoriaID = Historia.ID;
                    Det.FechaHora = dtiFechaHora.Value;
                    Det.Temperatura = Convert.ToDecimal(diTemp.Value);
                    Det.Peso = Convert.ToDecimal(diPeso.Value);
                    Det.Notas = txtNotas.Text;
                    Det.Tratamientos = txtTratamiento.Text;
                    Det.Fallecimiento = chkFallecio.Checked;

                    if (AdmClin.InsertHistoriaDetalle(Det))
                    {
                        MessageBox.Show("OCURRENCIA REGISTRADA CORRECTAMENTE", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmHistoriaClinica frm = (frmHistoriaClinica)this.parentForm;
                        frm.CargarOcurrencias();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL REGISTRAR LA OCURRENCIA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool Validar()
        {
            if (dtiFechaHora.Value == null || dtiFechaHora.Text == "")
            {
                MessageBox.Show("INGRESE LA FECHA Y HORA DE LA OCURRENCIA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtiFechaHora.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTratamiento.Text))
            {
                MessageBox.Show("INGRESE EL TRATAMIENTO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTratamiento.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(diPeso.Text))
            {
                MessageBox.Show("INGRESE EL PESO", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                diPeso.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(diTemp.Text))
            {
                MessageBox.Show("INGRESE LA TEMPERATURA", "SGE SYSTEM'S", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                diTemp.Focus();
                return false;
            }

            return true;
        }
    }
}
