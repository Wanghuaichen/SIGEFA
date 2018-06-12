using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmProductos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto pro = new clsProducto();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        TreeNode nodoselect = new TreeNode();
        DataTable Arbol = new DataTable();
        public double tc_hoy = 0;
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            //CargaLista();
            ConsultaArbol();
            llenaarbol(0,0, null);
            label7.Text = "Referencia";
            label6.Text = "referencia"; 
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            //frmGestionProducto frm = new frmGestionProducto();
            frmRegistroProducto frm = new frmRegistroProducto();
            frm.Proceso = 1;
            frm.ShowDialog();
            nodoselect = tvClasificacion.SelectedNode;
            tvClasificacion.Nodes.Clear();
            ConsultaArbol();
            llenaarbol(0, 0, null);
            if (tvClasificacion.SelectedNode != null) { CargaLista(nodoselect); }
        }      

        private void frmProductos_Shown(object sender, EventArgs e)
        {
            //CargaLista();
        }

        private void CargaLista(TreeNode nodoseleccionado)
        {
            //dgvProductos.DataSource = AdmPro.MuestraProductos();            
            //dgvUsuarios.ClearSelection();
            //DataTable dt = new DataTable();
            try
            {
                if (data.DataSource != null)
                {
                    DataTable dt = (DataTable)data.DataSource;
                    dt.Clear();
                }
                dgvProductos.DataSource = data;                
                data.DataSource = AdmPro.MuestraProductos(nodoseleccionado.Level, Convert.ToInt32(nodoseleccionado.Tag), frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvProductos.ClearSelection();
                DarFormato();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {  }
        }

        private void ConsultaArbol()
        {
            Arbol = AdmPro.ArbolProductos();
        }

        private void llenaarbol(Int32 nivel, Int32 indicePadre, TreeNode nodoPadre)
        {            
            DataView hijos = new DataView(Arbol);
            hijos.RowFilter = Arbol.Columns["codpadre"].ColumnName + " = " + indicePadre;
            hijos.RowFilter += " AND " + Arbol.Columns["nivel"].ColumnName + " = " + nivel;
            foreach (DataRowView row in hijos)
            {
                TreeNode nuevonodo = new TreeNode();
                nuevonodo.Text = row["descripcion"].ToString();
                nuevonodo.Tag = row["codigo"].ToString();
                if (nodoPadre == null)
                {
                    tvClasificacion.Nodes.Add(nuevonodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodoPadre.Nodes.Add(nuevonodo);
                }

                llenaarbol(nivel + 1,Int32.Parse(row["codigo"].ToString()), nuevonodo);
            }
        }

        private void tvClasificacion_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                CargaLista(e.Node);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                //frmRegistroProducto frm = new frmRegistroProducto();
                frmGestionProducto frm = new frmGestionProducto();
                frm.Proceso = 2;
                frm.pro = pro;
                frm.ShowDialog();
                nodoselect = tvClasificacion.SelectedNode;
                tvClasificacion.Nodes.Clear();
                ConsultaArbol();
                llenaarbol(0, 0, null);
                if (tvClasificacion.SelectedNode != null) { CargaLista(nodoselect); }
            }
        }

        private void dgvProductos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvProductos.Rows.Count >= 1 && e.Row.Selected)
            {
                pro.CodProducto = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value);          
            }
        }

        private void DarFormato()
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (Convert.ToDouble(row.Cells[stock.Name].Value) <= Convert.ToDouble(row.Cells[stockmin.Name].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (Convert.ToDouble(row.Cells[stock.Name].Value) <= Convert.ToDouble(row.Cells[stockrepo.Name].Value))
                {   
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.ForeColor = Color.White;                   
                }
                
                else if (Convert.ToDouble(row.Cells[stock.Name].Value) >= Convert.ToDouble(row.Cells[stockmax.Name].Value) && Convert.ToDouble(row.Cells[stockmax.Name].Value)> 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White; 
                }
            }
        }

        private void CargaListaCaracteristicas()
        {
            dgvCaracteristicas.DataSource = AdmPro.MuestraCaracteristicas(pro.CodProducto);
            dgvCaracteristicas.ClearSelection();
        }

        private void CargaListaNotas()
        {
            dgvNotas.DataSource = AdmPro.MuestraNotas(pro.CodProducto);
            dgvNotas.ClearSelection();
        }
               
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                frmGestionProducto frm = new frmGestionProducto();
                //frm.Proceso = 2;
                frm.pro = pro;
                frm.ShowDialog();
                if (tvClasificacion.SelectedNode != null) { CargaLista(tvClasificacion.SelectedNode); }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Double var=0;
            try
            {
                if (pro.CodProducto != 0 && e.RowIndex != -1)
                {
                    DataGridViewRow Row = dgvProductos.Rows[e.RowIndex];
                    txtCodProducto.Text = Row.Cells[codproducto.Name].Value.ToString();
                    txtReferencia.Text = Row.Cells[referencia.Name].Value.ToString();
                    txtNombre.Text = Row.Cells[nombre.Name].Value.ToString();
                    txtValorCompra.Text= String.Format("{0:#,##0.00}",Row.Cells[precioprom.Name].Value.ToString());
                    txtValorCompraSoles.Text = String.Format("{0:#,##0.00}",Row.Cells[valorpromsoles.Name].Value);
                    CargaListaCaracteristicas();
                    CargaListaNotas();
                }
            }
            catch (Exception ex)
            {
                return;
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
            if (tvClasificacion.SelectedNode != null) { CargaLista(tvClasificacion.SelectedNode); }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                frmGestionProducto frm = new frmGestionProducto();
                frm.Funcion = 3;
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
                frmGestionProducto frm = new frmGestionProducto();
                frm.Funcion = 3;
                frm.pro = pro;
                frm.ShowDialog();
            }
        }

        private void dgvProductos_Sorted(object sender, EventArgs e)
        {
            DarFormato();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            CRVarolizacion rpt = new CRVarolizacion();
            frmRptKardex frm = new frmRptKardex();
            clsReportProductos cls = new clsReportProductos();
            DataTable nuevo = new DataTable();
            //nuevo = cls.ReporteValorizacion(frmLogin.iCodAlmacen);
            rpt.SetDataSource(cls.ReporteValorizacion(frmLogin.iCodAlmacen));
            frm.crvKardex.ReportSource = rpt;
            frm.Show();
        }

    }
}
