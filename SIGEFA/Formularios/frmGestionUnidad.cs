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
    public partial class frmGestionUnidad : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nueva Unidad (2)Editar Unidad
        clsAdmUnidad admUni = new clsAdmUnidad();
        public clsUnidadMedida uni = new clsUnidadMedida();  


        public frmGestionUnidad()
        {
            InitializeComponent();
        }

        private void frmGestionUnidad_Load(object sender, EventArgs e)
        {
            if (Proceso == 2)
            {
                txtSigla.Text = uni.Sigla;
                txtDescripcion.Text = uni.Descripcion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0 && txtSigla.Text != "" && txtDescripcion.Text != "")
            {
                uni.Sigla = txtSigla.Text;
                uni.Descripcion = txtDescripcion.Text;               
                
                if (Proceso == 1)
                {
                    if (admUni.insert(uni))
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else if (Proceso == 2)
                {
                    if (admUni.update(uni))
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
