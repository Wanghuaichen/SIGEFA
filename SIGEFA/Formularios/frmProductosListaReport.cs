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
    public partial class frmProductosListaReport : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmTipoArticulo AdmTip = new clsAdmTipoArticulo();
        public clsProducto pro = new clsProducto();
        public Int32 Proceso = 0; //(1) Ingreso (2)Salida (3)Relacion
        public Int32 Inicio = 0;
        public Int32 Procede = 0; //(1)Nota de Salida (2)Venta
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public List<Int32> seleccion = new List<Int32>();
        public Int32 codAlmacen;

        public frmProductosListaReport()
        {
            InitializeComponent();
        }

        private void frmProductosListaReport_Load(object sender, EventArgs e)
        {
            CargaTipoArticulos();
            cbTipoArticulo.SelectedIndex = 0;
            CargaLista(Inicio);
            label2.Text = "Referencia";
            label3.Text = "referencia";
        }

        private void dgvProductos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvProductos.Rows.Count >= 1 && e.Row.Selected)
            {
                pro.CodProducto = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                pro.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
                pro.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
            }
        }

        private void CargaLista(Int32 inicio)
        {  
            dgvProductos.DataSource = data;
            data.DataSource = AdmPro.ListaProductosReporte(codAlmacen,Convert.ToInt32(cbTipoArticulo.SelectedValue),inicio);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvProductos.ClearSelection();
        }

        private void CargaTipoArticulos()
        {
            cbTipoArticulo.DataSource = AdmTip.MuestraTipoArticulos();
            cbTipoArticulo.DisplayMember = "descripcion";
            cbTipoArticulo.ValueMember = "codTipoArticulo";
            cbTipoArticulo.SelectedIndex = -1;
        }

        private void frmProductosListaReport_Shown(object sender, EventArgs e)
        {
            CargaLista(Inicio);
            txtFiltro.Focus();
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

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvProductos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvProductos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
            
            //if (Proceso == 3)
            //{
            //    foreach (int cod in seleccion)
            //    {
            //        if (Application.OpenForms["ReporteInventario"] != null)
            //        {
            //            Application.OpenForms["ReporteInventario"].Close();
            //        }
            //        ReporteInventario form = new ReporteInventario();
            //        form.txtInicio.Text = row.Cells[referencia.Name].Value.ToString();
            //        form.codArticulo1 = Convert.ToInt32(row.Cells[codigo.Name].Value);
            //        form.ShowDialog();
            //    }
            //}
            //this.Close();
            this.DialogResult = DialogResult.Yes;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (dgvProductos.SelectedRows.Count > 1)
            //{
            //    DataGridViewRow row = dgvProductos.SelectedRows[0];
            //    //this.Close();
            //    if (Proceso == 3)
            //    {
            //        foreach (int cod in seleccion)
            //        {
            //            if (Application.OpenForms["ReporteInventario"] != null)
            //            {
            //                Application.OpenForms["ReporteInventario"].Close();
            //            }
            //            ReporteInventario form = new ReporteInventario();
            //            form.txtInicio.Text = row.Cells[referencia.Name].Value.ToString();
            //            form.codArticulo1 = Convert.ToInt32(row.Cells[codigo.Name].Value);
            //            form.ShowDialog();
            //        }
            //    }
            //    this.Close();
            //}
            //else
            //{

            //}
            //this.Close();
            this.DialogResult = DialogResult.Yes;
        }       

        private void cbTipoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLista(Inicio);
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvProductos.Focus();
            } 
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    int f = dgvProductos.CurrentRow.Index;
                    pro.CodProducto = Convert.ToInt32(dgvProductos.Rows[f].Cells[codigo.Name].Value);
                    pro.Referencia = dgvProductos.Rows[f].Cells[referencia.Name].Value.ToString();
                    pro.Descripcion = dgvProductos.Rows[f].Cells[descripcion.Name].Value.ToString();
                }
            }
        }
    }
}
