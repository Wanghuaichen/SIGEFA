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
    public partial class frmListaDocumentosSinGuia : DevComponents.DotNetBar.Office2007Form
    {
        public clsNotaSalida nota = new clsNotaSalida();
        clsAdmNotaSalida AdmNota = new clsAdmNotaSalida();

        public clsFacturaVenta venta = new clsFacturaVenta();
        clsAdmFacturaVenta admVenta = new clsAdmFacturaVenta();
        public int Procede = 0;
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public List<Int32> ltaCod = new List<Int32>();
        public List<clsFacturaVenta> ltaFat = new List<clsFacturaVenta>();
        private Int32 codigo;

        public Int32 CodCliente, Tipo;

        public frmListaDocumentosSinGuia()
        {
            InitializeComponent();
        }

        public int GetCodigo()
        {
            if (dgvDocumentos.Rows.Count > 0)
            {
                return Convert.ToInt32(dgvDocumentos.CurrentRow.Cells[codnota.Name].Value);
            }
            else
            {
                return 0;
            }
        }

        private void frmListaDocumentosSinGuia_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {

            dgvDocumentos.DataSource = data;
            data.DataSource = AdmNota.DocumentosSinGuia(frmLogin.iCodAlmacen, CodCliente, Tipo);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }

        private void recorrelista()
        {
            ltaCod.Clear();
            if (dgvDocumentos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDocumentos.SelectedRows)
                {
                    ltaCod.Add(Convert.ToInt32(row.Cells[codnota.Name].Value));
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDocumentos.SelectedRows!=null)
            {
                recorrelista();
                this.Close();
            }
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
            if (e.RowIndex != -1)
            {
                recorrelista();
                this.Close();
               // venta.CodFacturaVenta = dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
            }
            //this.Close();
        }

        private void dgvDocumentos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                venta.CodFacturaVenta= dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
            }


        }
    }
}
