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
    public partial class frmMuestraPagos2 : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        public Int32 CodNota;
        public Boolean InOut;
        public Int32 tipo;

        public frmMuestraPagos2()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvPagos.DataSource = data;
            data.DataSource = Admpag.MuestraListaPagosPorNota2(CodNota,InOut,tipo);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPagos.ClearSelection();
        }

        private void frmMuestraPagos2_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count >= 1 && dgvPagos.Rows[e.RowIndex].Selected)
            {
                DataGridViewCell celda = dgvPagos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (celda.Value.ToString() == "Anular pago")
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        Pag.CodPago = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codpago.Name].Value);
                        if (Admpag.AnularPago(Pag.CodPago))
                        {
                            MessageBox.Show("Los datos han sido eliminado correctamente", "Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaLista();
                        }
                    }                    
                }                
            }
        }
    }
}
