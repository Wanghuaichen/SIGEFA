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
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmCatalogo : DevComponents.DotNetBar.Office2007Form
    {
        clsReportProductos ds = new clsReportProductos();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmComposicionQuimica admCompQuim = new clsAdmComposicionQuimica();
        clsAdmDosis admDos = new clsAdmDosis();
        clsProducto pro = new clsProducto();
        public static BindingSource data = new BindingSource();
        public static BindingSource dataComp = new BindingSource();
        public static BindingSource dataDisis = new BindingSource();
        String filtro = String.Empty;
        TreeNode nodoselect = new TreeNode();
        DataTable Arbol = new DataTable();
        public Double tc_hoy = 0;
        public frmCatalogo()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargaLista();
            //ConsultaArbol();
            //llenaarbol(0,0, null);
            label7.Text = "Referencia";
            label6.Text = "referencia"; 
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            try
            {
                //frmGestionProducto frm = new frmGestionProducto();
                frmRegistroProducto frm = new frmRegistroProducto();
                frm.Proceso = 1;
                frm.ShowDialog();
                CargaLista();
            }
            catch (Exception ex)
            {
            }
        }      

        private void frmProductos_Shown(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            //dgvProductos.DataSource = AdmPro.MuestraProductos();            
            //dgvUsuarios.ClearSelection();
            dgvProductos.DataSource = data;
            data.DataSource = AdmPro.CatalogoProductos();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvProductos.ClearSelection();
        }

        private void ConsultaArbol()
        {
            Arbol = AdmPro.ArbolProductos();
        }

        

        

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                frmRegistroProducto frm = new frmRegistroProducto();
                frm.Proceso = 2;
                frm.pro = pro;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void dgvProductos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvProductos.Rows.Count >= 1 && e.Row.Selected)
            {
                pro.CodProducto = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value);          
            }
        }

        

        private void CargaListaNotas()
        {
            dgvNotas.DataSource = AdmPro.MuestraNotas(pro.CodProducto);
            dgvNotas.ClearSelection();
        }

        private void CargaListaEquivalencias()
        {
            dataGridView1.DataSource = AdmPro.MuestraUnidadesEquivalentesVenta1(pro.CodProducto, frmLogin.iCodAlmacen);
            dataGridView1.ClearSelection();
        }

        private void CargaStockProducto()
        {
            dgvAlmacenes.DataSource = AdmPro.StockProductoAlmacenes(frmLogin.iCodEmpresa, pro.CodProducto);
        }

        private void CargaProductosProveedor()
        {
            dgvProxProducto.DataSource = AdmPro.MuestraProductosProveedor(pro.CodProducto, pro.CodAlmacen);
        }


        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pro.CodProducto != 0 && e.RowIndex != -1)
            {
                DataGridViewRow Row = dgvProductos.Rows[e.RowIndex];
                txtCodProducto.Text = Row.Cells[codproducto.Name].Value.ToString();
                txtReferencia.Text = Row.Cells[referencia.Name].Value.ToString();
                txtNombre.Text = Row.Cells[nombre.Name].Value.ToString();
                txtPrecioCatalogo.Text =  (Convert.ToDouble(Row.Cells[preciocatalogo.Name].Value) / tc_hoy).ToString();
                txtPrecioCatalogoSoles.Text = Row.Cells[preciocatalogo.Name].Value.ToString();

                CargaListaNotas();
                CargaListaEquivalencias();
                CargaStockProducto();
                CargaProductosProveedor();
            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Productos");
            // Columnas
            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvProductos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvProductos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmProductosRP frm = new frmProductosRP();
            frm.DTable = dt;
            frm.Show();
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
                    data.Filter = String.Format("[{0}] like '*{1}*'", label6.Text.Trim(), txtFiltro.Text.Trim());
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

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
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

        private void frmProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvProductos.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvProductos.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {           
            CargaLista();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {                
                frmRegistroProducto frm = new frmRegistroProducto();
                frm.Proceso = 3;
                frm.pro = pro;
                frm.ShowDialog();                                
            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                frmRegistroProducto frm = new frmRegistroProducto();
                frm.Proceso = 3;
                frm.pro = pro;
                frm.ShowDialog();
            }
        }

        private void biCatalogo_Click(object sender, EventArgs e)
        {
            CRCatalogoPrecios rpt = new CRCatalogoPrecios();
            frmCatalogoRP frm = new frmCatalogoRP();
            rpt.SetDataSource(ds.CatalogoConPrecio().Tables[0]);
            frm.cRVProductos.ReportSource = rpt;
            frm.Show();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                frmCompQuimicaDosis frm = new frmCompQuimicaDosis();
                frm.codPro = pro.CodProducto;
                frm.ShowDialog();
                CargaLista();
            }
            else
            {
                MessageBox.Show("Seleccione un Producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
