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
    public partial class frmProveedores : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionProveedor frm = new frmGestionProveedor();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void CargaLista()
        {
            //dgvProveedores.DataSource = AdmProv.MuestraProveedores();            
            //dgvProveedores.ClearSelection();
            dgvProveedores.DataSource = data;
            data.DataSource = AdmProv.MuestraProveedores();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvProveedores.ClearSelection();           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                frmGestionProveedor frm = new frmGestionProveedor();
                frm.Proceso = 2;
                frm.prov = prov;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Razon Social";
            label3.Text = "razonsocial"; 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvProveedores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (Application.OpenForms["frmBusqueda"] != null)
            //{
            //    frmBusqueda search = (frmBusqueda)Application.OpenForms["frmBusqueda"];
            //    search.label1.Text = dgvProveedores.Columns[e.ColumnIndex].HeaderText;
            //    search.label2.Text = dgvProveedores.Columns[e.ColumnIndex].DataPropertyName;
            //}
            label2.Text = dgvProveedores.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvProveedores.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
            if (Application.OpenForms["frmBusqueda"] != null)
            {
                frmBusqueda search = (frmBusqueda)Application.OpenForms["frmBusqueda"];
                search.label1.Text = dgvProveedores.Columns[e.ColumnIndex].HeaderText;
                search.label2.Text = dgvProveedores.Columns[e.ColumnIndex].DataPropertyName;
                search.txtFiltro.Focus();
            }
        }

        private void dgvProveedores_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvProveedores.Rows.Count >= 1 && e.Row.Selected)
            {
                prov.CodProveedor = Convert.ToInt32(e.Row.Cells[codproveedor.Name].Value);
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
            //frmBusqueda search = new frmBusqueda();
            //search.Owner = this;
            //search.label1.Text = dgvProveedores.Columns[dgvProveedores.CurrentCell.ColumnIndex].HeaderText;
            //search.label2.Text = dgvProveedores.Columns[dgvProveedores.CurrentCell.ColumnIndex].DataPropertyName;
            //search.Top = 50;
            //search.Left = Application.OpenForms["mdi_Menu"].Width - search.Width - 20;
            //search.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow.Index != -1 && prov.CodProveedor != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos del Proveedor definitivamente", "Proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmProv.delete(Convert.ToInt32(prov.CodProveedor)))
                    {
                        MessageBox.Show("El Proveedor ha sido eliminado", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void frmProveedores_Shown(object sender, EventArgs e)
        {

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

        private void frmProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
                //showbuscar();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Proveedores");
            // Columnas
            foreach (DataGridViewColumn column in dgvProveedores.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvProveedores.Rows.Count; i++)
            {
                DataGridViewRow row = dgvProveedores.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvProveedores.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmProveedoresRP frm = new frmProveedoresRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                frmGestionProveedor frm = new frmGestionProveedor();
                frm.Proceso = 3;
                frm.prov = prov;
                frm.ShowDialog();                
            }
        }

    }
}
