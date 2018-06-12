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
    public partial class frmTablas : DevComponents.DotNetBar.Office2007Form
    {
        public frmTablas()
        {
            InitializeComponent();
        }

        private void frmTablas_Load(object sender, EventArgs e)
        {
            groupBox1.Text = this.Text;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.Text == "Unidades")
            {

            }
        }

       
    }
}
