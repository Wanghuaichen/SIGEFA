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
    public partial class frmMuestraNotasIngresoProveedor : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmNotaIngreso AdmNotaI = new clsAdmNotaIngreso();
        public Int32 CodProveedor = 0;
        public Int32 CodNotaI = 0;
        DataTable dt1 = new DataTable();

        public frmMuestraNotasIngresoProveedor()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();            
        }

        private void frmMuestraNotasIngresoProveedor_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = dtpDesde.Value.AddDays(-90);
            CargaLista();
        }

        private void CargaLista()
        {
            dgvDocumentos.DataSource = data;
            data.DataSource = AdmNotaI.CargaNotaIngresoSD(CodProveedor, frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count > 0 && e.RowIndex > -1)
            {
                CodNotaI = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codNota.Name].Value.ToString());
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count > 0 && e.RowIndex > -1)
            {
                CodNotaI = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells[codNota.Name].Value.ToString());
                Guardar();
                this.Close();
            }
        }

        public void Guardar()
        {            
            dt1 = AdmNotaI.CargaDetalle(CodNotaI);
            frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
            form.dgvDetalle.Rows.Clear();
            foreach (DataRow dtRow in dt1.Rows)
            {
                Decimal precioventa = Convert.ToDecimal(dtRow["importe"]);
                form.dgvDetalle.Rows.Add("", "", Convert.ToInt32(dtRow["codProducto"]), dtRow["referencia"].ToString(), dtRow["producto"].ToString(),
                Convert.ToInt32(dtRow["codUnidadMedida"]), dtRow["unidad"].ToString(), 0/* CONTROLSTOCK */, Convert.ToInt32(dtRow["cantidad"]), "", 
                Convert.ToDecimal(dtRow["preciounitario"]), Convert.ToDecimal(dtRow["subtotal"])/* BRUTO */, Convert.ToDecimal(dtRow["descuento1"]), "", "",
                Convert.ToDecimal(dtRow["montodscto"]), Convert.ToDecimal(dtRow["valorventa"]), Convert.ToDecimal(dtRow["igv"]), 
                precioventa, Convert.ToDecimal(dtRow["precioreal"]), Convert.ToDecimal(dtRow["valoreal"]), 0)/* maxPorcDescto*/;
            }
            form.CodNotaI = CodNotaI;
        }
    }
}
