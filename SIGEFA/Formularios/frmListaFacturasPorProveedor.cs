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
    public partial class frmListaFacturasPorProveedor : DevComponents.DotNetBar.Office2007Form
    {
        public clsNotaIngreso nota = new clsNotaIngreso();
        public Int32 CodProveedor = 0;
        clsAdmNotaIngreso AdmNota = new clsAdmNotaIngreso();

        clsAdmFactura AdmFactura = new clsAdmFactura();
        public clsFactura factura = new clsFactura();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public List<Int32> seleccion = new List<Int32>();
        public Int32 tipo = 0;

        public frmListaFacturasPorProveedor()
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
            data.DataSource = AdmFactura.MuestraFacturasProveedor(frmLogin.iCodAlmacen, CodProveedor, tipo);
            //data.DataSource = AdmNota.ListaFacturasPorProveedor(CodProveedor);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection(); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            RecorreDetalle();
            this.Close();
        }

        private void frmListaFacturasPorProveedor_Shown(object sender, EventArgs e)
        {
            //CargaLista();
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
            if (dgvDocumentos.Rows.Count > 0 && e.RowIndex > -1){
            //nota.CodNotaIngreso = dgvDocumentos.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
            factura.CodFactura = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codfacturas.Name].Value.ToString());
            factura.DocumentoFactura = dgvDocumentos.Rows[e.RowIndex].Cells[documentos.Name].Value.ToString();
            //if (Convert.ToInt32(nota.CodNotaIngreso)!=0)
            }
        }
        private void CargaDetalle()
        {
        }
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        //private void RecorreDetalle()
        //{
        //    if (dgvDetalle.SelectedRows.Count>0)
        //    {
        //        foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
        //        {
        //            añadedetalle(row);
        //        }
        //    }
            
        //}
        private void RecorreDetalle()
        {
            //seleccion.Clear();
            //if (dgvDetalle.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
            //    {
            //        seleccion.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
            //    }
            //}
        }

        private void añadedetalle(DataGridViewRow row)
        {
            //try
            //{
            //    foreach (int cod in seleccion)
            //    {
            //        if (Application.OpenForms["frmDetalleIngreso"] != null)
            //        {
            //            Application.OpenForms["frmDetalleIngreso"].Close();
            //        }
            //        frmDetalleIngreso form = new frmDetalleIngreso();
            //        form.Proceso = Proceso;
            //        form.Seleccion = 2;
            //        form.Procede = Procede;
            //        form.bvalorventa = bvalorventa;
            //        form.txtCodigo.Text = cod.ToString();
            //        if (form.repetido == 1) { form.Close(); this.Close(); }
            //        else
            //        {
            //            form.txtCantidad.Focus();
            //            form.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error Añade detalle");
            //}
        }
    }
}
