using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;

namespace SIGEFA.Formularios
{
    public partial class frmStockAlmacenes : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProducto admPro = new clsAdmProducto();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmStockAlmacenes()
        {
            InitializeComponent();
        }

        private void CargaStock()
        {
            try
            {
                dgvDetalle.DataSource = data;
                data.DataSource = admPro.MuestraStockAlmacenes();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvDetalle.ClearSelection();
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void frmStockAlmacenes_Load(object sender, EventArgs e)
        {
            try
            {
                CargaStock();
                label2.Text = "Producto";
                label3.Text = "Producto";
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void dgvDetalle_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                label2.Text = dgvDetalle.Columns[e.ColumnIndex].HeaderText;
                label3.Text = dgvDetalle.Columns[e.ColumnIndex].DataPropertyName;
                txtFiltro.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 17;
            frm.ShowDialog();
        }

        private void frmStockAlmacenes_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
