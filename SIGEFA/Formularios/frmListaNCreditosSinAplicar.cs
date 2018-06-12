using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Entidades;
using SIGEFA.Administradores;

namespace SIGEFA.Formularios
{
    public partial class frmListaNCreditosSinAplicar : Form
    {
        public Int32 CodCliente = 0;
        public clsNotaIngreso nota = new clsNotaIngreso();
        public clsNotaSalida notaS = new clsNotaSalida();
        public clsNotaCredito notaC = new clsNotaCredito();
        clsAdmNotaIngreso AdmNota = new clsAdmNotaIngreso();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public int VentComp = 0; // (1) VENTAS - (2) COMPRAS

        public frmListaNCreditosSinAplicar()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvDocumentos.DataSource = data;
            data.DataSource = AdmNota.CargaNotaCreditoSinAplicar(CodCliente, VentComp);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaNCreditosSinAplicar_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.SelectedRows.Count > 0)
            {
                if (VentComp == 1)
                {
                    notaC.CodNotaCredito = dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                    notaC.DocumentoNotaCredito = dgvDocumentos.Rows[e.RowIndex].Cells[numdoc.Name].Value.ToString();
                    notaC.Pendiente = Convert.ToDouble(dgvDocumentos.Rows[e.RowIndex].Cells[Total.Name].Value.ToString());
                    nota.CodReferencia = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codReferencia.Name].Value.ToString());
                    notaC.FechaRegistro = Convert.ToDateTime(dgvDocumentos.Rows[e.RowIndex].Cells[fecha.Name].Value.ToString());
                    notaC.CodAlmacen = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codAlmacen.Name].Value.ToString());
                }
                else
                {
                    notaS.CodNotaSalida = dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                    notaS.Docref = dgvDocumentos.Rows[e.RowIndex].Cells[numdoc.Name].Value.ToString();
                    notaS.Total = Convert.ToDouble(dgvDocumentos.Rows[e.RowIndex].Cells[Total.Name].Value.ToString());
                    notaS.DocumentoReferencia = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codReferencia.Name].Value.ToString());
                    notaS.FechaRegistro = Convert.ToDateTime(dgvDocumentos.Rows[e.RowIndex].Cells[fecha.Name].Value.ToString());
                    notaS.CodAlmacen = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codAlmacen.Name].Value.ToString());
                }
            }
        }

        private void dgvDocumentos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }
    }
}
