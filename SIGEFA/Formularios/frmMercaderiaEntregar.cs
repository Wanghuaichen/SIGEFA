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
    public partial class frmMercaderiaEntregar : Form
    {
        public static BindingSource data = new BindingSource();
        private String filtro = String.Empty;

        public clsNotaSalida salida = new clsNotaSalida();
        private clsAdmNotaSalida AdmSalida = new clsAdmNotaSalida();

        public Int32 proceso = 0;
        public Int32 tipo = 0;
        public frmMercaderiaEntregar()
        {
            InitializeComponent();
        }

        private void CargaNotaAlmacen()
        {
            dgvDetalle2.DataSource = data;
            data.DataSource = AdmSalida.MuestraNotaAlmacen(frmLogin.iCodAlmacen, tipo);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle2.ClearSelection();
        }

        private void frmMercaderiaEntregar_Load(object sender, EventArgs e)
        {
            if (proceso == 11)
            {
                CargaNotaAlmacen();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (proceso == 11)
            {
                if (dgvDetalle2.Rows.Count > 0 && dgvDetalle2.SelectedRows != null)
                {
                    salida.CodNotaSalida = dgvDetalle2.CurrentRow.Cells[codnotasalida.Name].Value.ToString();
                }
                this.Close();
            }
        }

        private void dgvDetalle2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                salida.CodNotaSalida = dgvDetalle2.Rows[e.RowIndex].Cells[codnotasalida.Name].Value.ToString();
            }
            this.Close();
        }

        private void dgvDetalle2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
