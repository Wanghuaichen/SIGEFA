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
    public partial class frmCajaChicaRendicionListado : DevComponents.DotNetBar.Office2007Form
    {
       
        public Int32 tipocaja=0;
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        Decimal Total = 0;



        public frmCajaChicaRendicionListado()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dgvRendiciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    if (dgvRendiciones.Rows.Count >= 1 && e.Row.Selected)
        //    {
        //        Caja.CodCajaChica = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
        //    }
        //}

        //private void ListaRendiciones()
        //{
        //    dgvRendiciones.DataSource = data;
        //    data.DataSource = AdmCaja.ListaRendiciones(frmLogin.iCodSucursal,tipocaja);
        //    data.Filter = String.Empty;
        //    filtro = String.Empty;
        //}

        private void frmCajaChicaRendicionListado_Load(object sender, EventArgs e)
        {
            //ListaRendiciones();
        }

        private void tsmiEliminarRendicion(object sender, EventArgs e)
        {
            //if (dgvRendiciones.Rows.Count > 0)
            //{
            //    if (Caja.CodCajaChica != 0)
            //    {
            //        DialogResult dlgResult = MessageBox.Show("Esta Seguro que Desea Eliminar el Dato?", "Rendiciones de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dlgResult == DialogResult.No)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            if (AdmCaja.AnulaRendicionCajaChica(Caja.CodCajaChica))
            //            {
            //                MessageBox.Show("El Dato ha sido Eliminado Correctamente", "Rendiciones de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                ListaRendiciones();
            //            }
            //            return;
            //        }
            //    }
            //}
        }

        private void dgvRendiciones_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                foreach (DataGridViewRow dr in dgvRendiciones.SelectedRows)
                {
                    dr.Selected = false;
                }

                dgvRendiciones.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void CalculaMontos()
        {
            try
            {
                Total = 0;
                if (dgvRendiciones.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dgvRendiciones.Rows)
                    {
                        Total = Total + (Convert.ToDecimal(row.Cells[monto.Name].Value));
                    }
                }
                else
                { Total = 0; }

                lblTotal.Text = Total.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void dgvRendiciones_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculaMontos();
        }

        private void dgvRendiciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculaMontos();
        }

        //private void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    if (dgvRendiciones.SelectedRows.Count > 0)
        //    {
        //        foreach (DataGridViewRow row in dgvRendiciones.SelectedRows)
        //        {
        //            AdmCaja.AnulaRendicionCajaChica(Convert.ToInt32(row.Cells[codigo.Name].Value));
        //        }
        //        MessageBox.Show("Datos Eliminados Correctamente", "Rendiciones de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ListaRendiciones();  
        //    }
        //}

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.CodCotizacion = tipocaja;
            frm.tipo = 17;
            frm.ShowDialog();
        }
    }
}
