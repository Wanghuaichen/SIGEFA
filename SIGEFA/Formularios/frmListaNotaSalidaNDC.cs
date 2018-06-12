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
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmListaNotaSalidaNDC : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        public clsFactura factura = new clsFactura();
        public Int32 CodProveedor = 0;
        public Int32 CodNotaS = 0;
        public String documento = "";

        public frmListaNotaSalidaNDC()
        {
            InitializeComponent();
        }

        private void frmListaNotaSalidaNDC_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            dgvDocumentos.DataSource = data;
            data.DataSource = AdmNotaS.ListarNotaSalidaParaNDCompra(frmLogin.iCodAlmacen, CodProveedor);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count > 0 && e.RowIndex > -1)
            {
                CodNotaS = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codNotaSalida.Name].Value.ToString());
                documento = dgvDocumentos.Rows[e.RowIndex].Cells[Documen.Name].Value.ToString();                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count > 0 && e.RowIndex > -1)
            {
                CodNotaS = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codNotaSalida.Name].Value.ToString());
                documento = dgvDocumentos.Rows[e.RowIndex].Cells[Documen.Name].Value.ToString();
                this.Close();
            }
        }
    }
}
