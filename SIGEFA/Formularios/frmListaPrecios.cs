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
    public partial class frmListaPrecios : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmListaPrecio AdmLista = new clsAdmListaPrecio();
        public clsListaPrecio listaprecio = new clsListaPrecio();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Buscar Ingreso (4) Buscar Salida
        String filtro = String.Empty;
        public static BindingSource data = new BindingSource();

        public Int32 CodListaOrigen = 0;


        public frmListaPrecios()
        {
            InitializeComponent();
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

        private void frmListaPrecios_Load(object sender, EventArgs e)
        {
           CargaListas();   
        }

        private void CargaListas()
        {
            dgvListaPrecios.DataSource = data;
            data.DataSource = AdmLista.MuestraListas(frmLogin.iCodSucursal);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvListaPrecios.ClearSelection();
        }
       
        private void frmTransacciones_Shown(object sender, EventArgs e)
        {
            CargaListas();
            txtFiltro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvListaPrecios.SelectedRows.Count > 0)
            {
                frmGestionListaPrecios form = (frmGestionListaPrecios)Application.OpenForms["frmGestionListaPrecios"];
                form.txtListaOrigen.Text = listaprecio.CodListaPrecio.ToString();
                form.label15.Text = listaprecio.Nombre;
                this.Close();
            }
        }

       

        private void dgvTransacciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvListaPrecios.Rows.Count >= 1 && e.Row.Selected)
            {
                listaprecio.CodListaPrecio = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                listaprecio.Nombre = e.Row.Cells[descripcion.Name].Value.ToString(); 
            }
           
        }  

        private void dgvListaPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaPrecios.SelectedRows.Count > 0)
            {
                frmGestionListaPrecios form = (frmGestionListaPrecios)Application.OpenForms["frmGestionListaPrecios"];
                form.txtListaOrigen.Text = listaprecio.CodListaPrecio.ToString();
                form.label15.Text = listaprecio.Nombre;
                this.Close();
            }
        }

        private void dgvListaPrecios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvListaPrecios.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvListaPrecios.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }
        
    }
}
