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
    public partial class frmListaDocumentosPorCliente : DevComponents.DotNetBar.Office2007Form
    {
        public clsFacturaVenta venta = new clsFacturaVenta();
        public Int32 CodCliente = 0;
        clsAdmFacturaVenta Admventa = new clsAdmFacturaVenta();
        clsAdmNotaSalida AdmNota = new clsAdmNotaSalida();
        clsNotaSalida nota = new clsNotaSalida();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 tipo;

        public frmListaDocumentosPorCliente()
        {
            InitializeComponent();
        }

        private void frmListaDocumentosSinGuia_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            dgvDocumentos.DataSource = data;
            //data.DataSource = AdmNota.DocumentosPorCliente(CodCliente);
            data.DataSource = AdmNota.DocumentosPorCliente(CodCliente, tipo);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();  
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaDocumentosSinGuia_Shown(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvDocumentos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvDocumentos.Rows.Count >= 1 && e.Row.Selected)
            //{
            //    nota.CodNotaSalida = e.Row.Cells[codnota.Name].Value.ToString();
            //}            
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }

        private void dgvDocumentos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDocumentos.SelectedRows.Count>0)
            venta.CodFacturaVenta = dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString(); 
        }
    }
}
