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

namespace SIGEFA.Formularios
{
    public partial class frmClientesCorporativos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 Tipo;


        public frmClientesCorporativos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionCliente frm = new frmGestionCliente();
            frm.Proceso = 1;           
            frm.ShowDialog();
            CargaLista();
        }

        private void CargaLista()
        {
            //dgvProveedores.DataSource = AdmProv.MuestraProveedores();            
            //dgvProveedores.ClearSelection();
            dgvClientes.DataSource = data;
            data.DataSource = AdmCli.MuestraClientes();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvClientes.ClearSelection();
            setRowNumber(dgvClientes);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmGestionCliente frm = new frmGestionCliente();
            frm.Proceso = 2;            
            frm.cli = cli;
            frm.ShowDialog();
            CargaLista(); 
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvClientes.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvClientes.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void dgvClientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvClientes.Rows.Count >= 1 && e.Row.Selected)
            {
                cli.CodCliente = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            }
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                frmGestionCliente frm = new frmGestionCliente();
                frm.Proceso = 3;
                frm.cli = cli;
                frm.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!expandablePanel1.Expanded)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
            else
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void frmClientesCorporativos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index != -1 && cli.CodCliente != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCli.delete(cli.CodCliente))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                frmGestionCliente frm = new frmGestionCliente();
                frm.Proceso = 3;
                frm.cli = cli;
                frm.ShowDialog();
            }
        }
    }
}
