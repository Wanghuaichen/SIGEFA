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
    public partial class frmListaVendedores : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmVendedor admVen = new clsAdmVendedor();
        public clsVendedor ven = new clsVendedor();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmListaVendedores()
        {
            InitializeComponent();
        }

        public int GetCodigoVendedor()
        {
            return ven.CodVendedor = Convert.ToInt32(dgvVendedores.CurrentRow.Cells[0].Value); 
        }

        private void frmListaVendedores_Load(object sender, EventArgs e)
        {
            CargaLista();
            label9.Text = "Codigo";
            label8.Text = "codVendedor";
        }

        private void CargaLista()
        {
            dgvVendedores.DataSource = data;
            data.DataSource = admVen.MuestraVendedores();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVendedores.ClearSelection();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label8.Text.Trim(), txtFiltro.Text.Trim());
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

        private void dgvVendedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmConsultorExt form = (frmConsultorExt)Application.OpenForms["frmConsultorExt"];

            form.CodVendedor = Int32.Parse(dgvVendedores.CurrentRow.Cells["codigo"].Value.ToString());
            form.txtCodCliente.Text = dgvVendedores.CurrentRow.Cells["dni"].Value.ToString();
            form.txtNombreCliente.Text = dgvVendedores.CurrentRow.Cells["apellido"].Value.ToString();
            //GetCodigoVendedor();
            this.Close();
        }

        private void dgvVendedores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label9.Text = dgvVendedores.Columns[e.ColumnIndex].HeaderText;
            label8.Text = dgvVendedores.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void frmListaVendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void frmListaVendedores_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
