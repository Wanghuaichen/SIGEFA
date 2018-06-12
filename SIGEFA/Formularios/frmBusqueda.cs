using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIGEFA.Formularios
{
    public partial class frmBusqueda : DevComponents.DotNetBar.Office2007Form
    {
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private void frmBusqueda_Shown(object sender, EventArgs e)
        {
            //this.Owner = Application.OpenForms["mdi_Menu"];
            //this.BringToFront();
            EffectIn();
        }

        private void frmBusqueda_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal; 
            this.Height = 0;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    frmUsuarios.data.Filter = String.Format("[{0}] like '*{1}*'", label2.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    frmUsuarios.data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void frmBusqueda_FormClosing(object sender, FormClosingEventArgs e)
        {
            EffectOut();
        }

        public void EffectOut()
        {
            for (int Effect = this.Height; Effect > 0; Effect--)
            {
                this.Height = Effect;
                this.Refresh();
            }
        }

        public void EffectIn()
        {
            int size = 93;            
            for (int Effect = 0; Effect < size; Effect++)
            {
                this.Height = Effect;
                this.Refresh();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
