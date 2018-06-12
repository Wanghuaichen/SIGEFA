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
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
using MySql.Data.MySqlClient;

namespace SIGEFA.Formularios
{
    public partial class frmPagosPresBancarios : DevComponents.DotNetBar.Office2007Form
    {

        //-----------------

        clsReportePagos ds = new clsReportePagos();

        //---------------
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmFactura admfac=new clsAdmFactura();
        clsAdmPrestamoBancario admPreBan = new clsAdmPrestamoBancario();
        clsCuota cuoPreBan = new clsCuota();
        clsFactura fac=new clsFactura();
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmTipoDocumento admTipo = new clsAdmTipoDocumento();
        //clsAdmNotaIngreso admNotaI = new clsAdmNotaIngreso();
        //clsNotaIngreso notaI = new clsNotaIngreso();
        clsAdmLetra admLetra = new clsAdmLetra();
        clsLetra let = new clsLetra();
        clsPago pagoRp = new clsPago();

        public frmPagosPresBancarios()
        {
            InitializeComponent();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {            
            CargaLista();
        }

        private void CargaLista()
        {
            dgvPagos.DataSource = data;
            data.DataSource =admPreBan.MuestraPagosPrestamo(cmbEstado.SelectedIndex, Convert.ToInt32(cmbEmpresa.SelectedValue), dtpFecha1.Value, dtpFecha2.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPagos.ClearSelection();
        }
        
        private void frmPagos_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            //CargaTipoDocumento();
            dtpFecha1.Value = dtpFecha2.Value.AddDays(-90);
            dtpFecha2.Value = dtpFecha2.Value.AddDays(30);
            cmbEstado.SelectedIndex = 0;
            cmbEmpresa.SelectedIndex = 0;            
            label7.Text = "Banco";
            label6.Text = "proveedor"; 
            
        }

        private void frmPagos_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label6.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = 0;
        }
        
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvPagos.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvPagos.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count >= 1 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell celda = dgvPagos.CurrentCell;
                Int32 itipo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[tipo.Name].Value);
                if (celda.Value.ToString() == "Ingresar Pago")
                {
                    if (itipo == 5)
                    {
                        cuoPreBan.CodCuotaPrestamo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmCancelarPago form = new frmCancelarPago();
                        form.codCuota = cuoPreBan.CodCuotaPrestamo;
                        form.tipo = itipo;
                        form.ShowDialog();
                        CargaLista();
                    }
                }
                else if (celda.Value.ToString() == "Muestra Pagos")
                {
                    if (itipo == 5)
                    {
                        cuoPreBan.CodCuotaPrestamo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmMuestraPagos form = new frmMuestraPagos();
                        form.codCuota = cuoPreBan.CodCuotaPrestamo;
                        form.InOut = false;
                        form.tipo = itipo;
                        form.ShowDialog();
                        CargaLista();
                    }
                }
            }
        }

        private void dgvPagos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvPagos.ContextMenuStrip = new ContextMenuStrip();
            if (e.RowIndex != -1)
            {
                dgvPagos.Rows[e.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {
                    if (dgvPagos.SelectedCells.Count > 0)
                    {
                        dgvPagos.ContextMenuStrip = contextMenuStrip1;
                        if (Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[cantidad.Name].Value) > 0) // se comprueba que el prestamo tenga pagos
                        {
                            muestraPagosToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            muestraPagosToolStripMenuItem.Enabled = false;
                        }
                    }
                }
            }
        }

        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //-------------------
        private void btnReporte_Click(object sender, EventArgs e)
        {
            //CRReportePagos  rpt = new CRReportePagos();
            //frmRptPagos frm = new frmRptPagos();
            //rpt.SetDataSource(ds.Pago(Convert.ToInt32(cmbEmpresa.SelectedValue), dtpFecha1.Value,dtpFecha2.Value,cmbEstado.SelectedIndex).Tables[0]);
            //frm.crvReportePagos.ReportSource = rpt;
            //frm.Show();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Pagos");
            // Columnas
            foreach (DataGridViewColumn column in dgvPagos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvPagos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvPagos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvPagos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\PagoRPT.xml", XmlWriteMode.WriteSchema);

            CRReportePagos rpt = new CRReportePagos();
            frmRptPagos frm = new frmRptPagos();
            rpt.SetDataSource(ds);
            frm.crvReportePagos.ReportSource = rpt;
            frm.Show();
        }

        private void canjearPorLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresoABancoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void canjearPorCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void muestraPagosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPagos.SelectedRows[0];
            Int32 itipo = Convert.ToInt32(Row.Cells[tipo.Name].Value);
            cuoPreBan.CodCuotaPrestamo = Convert.ToInt32(Row.Cells[codnota.Name].Value);
            frmMuestraPagos form = new frmMuestraPagos();
            form.codCuota = cuoPreBan.CodCuotaPrestamo;
            form.InOut = false;
            form.tipo = itipo;
            form.ShowDialog();
            CargaLista();
        }
        //----------------------
    }
}
