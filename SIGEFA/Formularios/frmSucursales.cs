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
    public partial class frmSucursales : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmSucursal AdmSuc = new clsAdmSucursal();
        clsSucursal suc = new clsSucursal();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmSucursales()
        {
            InitializeComponent();
        }

        

        private void CargaLista()
        {
            dgvEmpresas.DataSource = data;
            //data.DataSource = AdmSuc.ListaSucursales();
            data.DataSource = AdmSuc.ListaSucursales_Empresa(frmLogin.iCodEmpresa);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvEmpresas.ClearSelection();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "nombre";
            label3.Text = "nombre";            
        }
        
        private void dgvEmpresas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvEmpresas.Rows.Count >= 1 && e.Row.Selected)
            {                
                suc.CodSucursal = Convert.ToInt32(e.Row.Cells[codigo.Name].Value); 
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
                frmGestionSucursal frm = new frmGestionSucursal();
                frm.Proceso = 3;
                frm.suc = suc;
                frm.ShowDialog();
            }
        }

        private void biNuevo_Click(object sender, EventArgs e)
        {
            frmGestionSucursal frm = new frmGestionSucursal();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void biModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                frmGestionSucursal frm = new frmGestionSucursal();
                frm.Proceso = 2;
                frm.suc = suc;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpresas.CurrentRow.Index != -1 && suc.CodSucursal != 0 && dgvEmpresas.Rows.Count > 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmSuc.delete(Convert.ToInt32(suc.CodSucursal)))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Empresas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
            else MessageBox.Show("No se Puede Eliminar el Registro");
        }

        private void biActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void biBuscar_Click(object sender, EventArgs e)
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

        private void biImprimir_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 4;
            frm.ShowDialog(); 
        }
        
    }
}
