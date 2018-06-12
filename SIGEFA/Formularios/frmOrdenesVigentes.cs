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

    public partial class frmOrdenesVigentes : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Ord = new clsOrdenCompra();        
        public Int32 Proceso = 0; //

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;        



        public frmOrdenesVigentes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvOrdenes.DataSource = data;
            data.DataSource = AdmOrden.MuestraOrdenes(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvOrdenes.ClearSelection();
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                frmOrdenCompra form = new frmOrdenCompra();
                form.MdiParent = this.MdiParent;
                form.CodOrdenCompra = Ord.CodOrdenCompra;
                form.Proceso = 3;
                form.Show();            
            }
        }

        private void frmOrdenesVigentes_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && e.Row.Selected)
            {
                Ord.CodOrdenCompra = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);               
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvOrdenes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmOrdenCompra form = new frmOrdenCompra();
                form.MdiParent = this.MdiParent;
                form.CodOrdenCompra = Ord.CodOrdenCompra;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Ord.CodOrdenCompra != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la orden de compra seleccionada", "Órdenes de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmOrden.delete(Ord.CodOrdenCompra))
                    {
                        MessageBox.Show("La orden de compra ha sido anulada correctamente", "Órdenes de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                frmNotaIngreso form = new frmNotaIngreso();
                form.MdiParent = this.MdiParent;
                form.CodOrdenCompra = Ord.CodOrdenCompra;
                form.Proceso = 7; // 7 orden de compra
                form.Show();
            }
        }
    }
}
