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
    public partial class frmAlmacenes : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAlmacen AdmAlm = new clsAdmAlmacen();
        clsAlmacen alm = new clsAlmacen();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmAlmacenes()
        {
            InitializeComponent();
        }

        private void frmAlmacenes_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Nombre";
            label3.Text = "nombre"; 
        }

        private void CargaLista()
        {
            dgvAlmacenes.DataSource = data;
            data.DataSource = AdmAlm.MuestraAlmacenes(frmLogin.iCodEmpresa);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvAlmacenes.ClearSelection();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmGestionAlmacen frm = new frmGestionAlmacen();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {

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

        private void biActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void frmAlmacenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }

        private void biEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlmacenes.SelectedRows.Count > 0)
            {
                frmGestionAlmacen frm = new frmGestionAlmacen();
                frm.Proceso = 2;
                frm.alm = alm;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void frmAlmacenes_Shown(object sender, EventArgs e)
        {
            //expandablePanel1.Expanded = false;
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlmacenes.CurrentRow.Index != -1 && alm.CodAlmacen != 0 && dgvAlmacenes.Rows.Count > 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Almacenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmAlm.delete(Convert.ToInt32(alm.CodAlmacen)))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Almacenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
            else MessageBox.Show("No se Puede Eliminar el Registro ");
        }

        private void dgvAlmacenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAlmacenes.SelectedRows.Count > 0)
            {
                frmGestionAlmacen frm = new frmGestionAlmacen();
                frm.Proceso = 3;
                frm.alm = alm;
                frm.ShowDialog();
            }
        }

        private void dgvAlmacenes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvAlmacenes.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvAlmacenes.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void dgvAlmacenes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvAlmacenes.Rows.Count >= 1 && e.Row.Selected)
            {
                alm.CodAlmacen = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
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

        private void biCopiar_Click(object sender, EventArgs e)
        {
            if (dgvAlmacenes.SelectedRows.Count > 0)
            {
                frmGestionAlmacen frm = new frmGestionAlmacen();
                frm.Proceso = 3;
                frm.alm = alm;
                frm.ShowDialog();
            }
        }

        private void biImprimir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Almacenes");
            // Columnas
            foreach (DataGridViewColumn column in dgvAlmacenes.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvAlmacenes.Rows.Count; i++)
            {
                DataGridViewRow row = dgvAlmacenes.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvAlmacenes.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmAlmacenesRP frm = new frmAlmacenesRP();
            frm.DTable = dt;
            frm.Show();
        }
        
    }
}
