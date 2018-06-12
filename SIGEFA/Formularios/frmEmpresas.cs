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
    public partial class frmEmpresas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        clsEmpresa emp = new clsEmpresa();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmEmpresas()
        {
            InitializeComponent();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmGestionEmpresa frm = new frmGestionEmpresa();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }
        private void CargaLista()
        {
            dgvEmpresas.DataSource = data;
            data.DataSource = AdmEmp.MuestraEmpresas();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvEmpresas.ClearSelection();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "RUC";
            label3.Text = "ruc";            
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {       
            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                frmGestionEmpresa frm = new frmGestionEmpresa();
                frm.Proceso = 2;
                frm.emp = emp;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void dgvEmpresas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvEmpresas.Rows.Count >= 1 && e.Row.Selected)
            {
                emp.CodEmpresa = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);                              
            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (dgvEmpresas.CurrentRow.Index != -1 && emp.CodEmpresa != 0 && dgvEmpresas.Rows.Count > 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente",
                    "Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmEmp.delete(Convert.ToInt32(emp.CodEmpresa)))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Empresas", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
            else MessageBox.Show("No se Puede Eliminar la empresa");
        }

        private void buttonItem5_Click(object sender, EventArgs e)
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

        private void frmEmpresas_Shown(object sender, EventArgs e)
        {
            //expandablePanel1.Expanded = false;           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
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

        private void dgvEmpresas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvEmpresas.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvEmpresas.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;     
            }
        }

        private void frmEmpresas_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }

        private void dgvEmpresas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                frmGestionEmpresa frm = new frmGestionEmpresa();
                frm.Proceso = 3;
                frm.emp = emp;
                frm.ShowDialog();                
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Empresas");
            // Columnas
            foreach (DataGridViewColumn column in dgvEmpresas.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvEmpresas.Rows.Count; i++)
            {
                DataGridViewRow row = dgvEmpresas.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvEmpresas.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmEmpresasRP frm = new frmEmpresasRP();
            frm.DTable = dt;
            frm.Show();
        }
        
    }
}
