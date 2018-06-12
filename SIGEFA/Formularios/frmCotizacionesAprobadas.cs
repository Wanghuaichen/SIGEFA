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
    public partial class frmCotizacionesAprobadas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmCotizacion AdmCotizacion = new clsAdmCotizacion();
        clsCotizacion cotizacion = new clsCotizacion();
        public Int32 Proceso = 0; //

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;        

        public frmCotizacionesAprobadas()
        {
            InitializeComponent();
        }

        private void frmCotizacionesAprobadas_Load(object sender, EventArgs e)
        {
            CargaLista();
        }
    

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvCotizaciones.DataSource = data;
            data.DataSource = AdmCotizacion.MuestraCotizaciones(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCotizaciones.ClearSelection();
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            if (dgvCotizaciones.Rows.Count >= 1 && dgvCotizaciones.CurrentRow != null)
            {
                DataGridViewRow row = dgvCotizaciones.CurrentRow;
                frmGestionCotizacion form = new frmGestionCotizacion();
                form.MdiParent = this.MdiParent;
                form.CodCotizacion = cotizacion.CodCotizacion;
                form.txtDocRef.Text = "CT";
                form.aprobado = Convert.ToInt32(dgvCotizaciones.SelectedRows[0].Cells[aprob.Name].Value);
                form.Proceso = 3;
                form.Show();
            }
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCotizaciones.Rows.Count >= 1 && e.Row.Selected)
            {
                cotizacion.CodCotizacion = e.Row.Cells[codigo.Name].Value.ToString();
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCotizaciones.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmGestionCotizacion form = new frmGestionCotizacion();
                form.MdiParent = this.MdiParent;
                form.CodCotizacion = cotizacion.CodCotizacion;
                form.aprobado = Convert.ToInt32(dgvCotizaciones.SelectedRows[0].Cells[aprob.Name].Value);
                form.Proceso = 3;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvCotizaciones.CurrentRow != null && cotizacion.CodCotizacion != "")
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la cotizacion seleccionada", "Cotizaciones Vigentes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCotizacion.delete(Convert.ToInt32(cotizacion.CodCotizacion)))
                    {
                        MessageBox.Show("La cotizacion ha sido anulada correctamente", "Cotizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }
    }
}
