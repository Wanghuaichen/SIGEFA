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
using DataGridViewAutoFilter;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;


namespace SIGEFA.Formularios
{
    public partial class frmPrestamosBancarios : DevComponents.DotNetBar.Office2007Form
    {
        clsConsultasExternas ext = new clsConsultasExternas();
        clsSerie ser = new clsSerie();
        clsAdmPrestamoBancario AdmPreBan = new clsAdmPrestamoBancario();
        clsPrestamoBancario preban = new clsPrestamoBancario();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 Tipo;


        public frmPrestamosBancarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionPrestamoBancario frm = new frmGestionPrestamoBancario();
            frm.Proceso = 1;            
            frm.ShowDialog();
            CargaLista();
        }

        public void CargaLista()
        {
            //dgvProveedores.DataSource = AdmProv.MuestraProveedores();            
            //dgvProveedores.ClearSelection();
            dgvPrestamos.DataSource = data;
            data.DataSource = AdmPreBan.MuestraPrestamos();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPrestamos.ClearSelection();
        }

        private void DarFormato()
        {
            foreach (DataGridViewRow row in dgvPrestamos.Rows)
            {
                if (row.Cells[esta.Name].Value.ToString() == "PENDIENTE" && row.Index != -1)
                {
                    row.Cells[esta.Name].Style.BackColor = Color.Red;
                    row.Cells[esta.Name].Style.ForeColor = Color.White;
                }
             }
        }

        private void dgvClientes_Sorted(object sender, EventArgs e)
        {
            DarFormato();    
        }
        

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Banco";
            label3.Text = "descBanco"; 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!expandablePanel1.Expanded)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
            else
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void frmClientesCompletos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.CurrentRow.Index != -1 && preban.CodPrestamoBancario != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Prestamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmPreBan.delete(Convert.ToInt32(preban.CodPrestamoBancario)))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Prestamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }        

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvPrestamos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvPrestamos.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void dgvClientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvPrestamos.Rows.Count >= 1 && e.Row.Selected)
            {
                preban.CodPrestamoBancario= Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
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

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Prestamos");
            // Columnas
            foreach (DataGridViewColumn column in dgvPrestamos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvPrestamos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvPrestamos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvPrestamos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\PrestamosRPT.xml", XmlWriteMode.WriteSchema);

            CRPrestamos rpt = new CRPrestamos();
            frmPrestamosRP frm = new frmPrestamosRP();
            rpt.SetDataSource(ds);
            frm.cRVClientesRP.ReportSource = rpt;
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmClientesCompletos_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void biFiltros_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(dgvPrestamos);
        }

        private void dgvPrestamos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvPrestamos.ContextMenuStrip = new ContextMenuStrip();
            if (e.RowIndex != -1)
            {
                dgvPrestamos.Rows[e.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {
                    if (dgvPrestamos.SelectedCells.Count > 0)
                    {
                        dgvPrestamos.ContextMenuStrip = contextMenuStrip1;
                        if (dgvPrestamos.Rows[e.RowIndex].Cells[crono.Name].Value.ToString() == "SI")
                        {
                            canjearPorCuotasToolStripMenuItem.Enabled = false;
                            muestraPagosToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            canjearPorCuotasToolStripMenuItem.Enabled = true;
                            muestraPagosToolStripMenuItem.Enabled = false;
                        }
                    }
                }
            }
        }

        private void canjearPorCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPrestamos.SelectedRows[0];
            preban.CodPrestamoBancario= Convert.ToInt32(Row.Cells[codigo.Name].Value);
            frmCanjearCuota form = new frmCanjearCuota();
            form.preBan = preban;
            form.Procede = 1;
            form.ShowDialog();
            CargaLista();
        }

        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPrestamos.SelectedRows[0];
            preban.CodPrestamoBancario = Convert.ToInt32(Row.Cells[codigo.Name].Value);
            frmCanjearCuota form = new frmCanjearCuota();
            form.preBan = preban;
            form.Procede = 2;
            form.ShowDialog();
            CargaLista();
        }

        private void dgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DarFormato();
        }

        private void btnImpCuota_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
            clsReporteCuotas dso = new clsReporteCuotas();
            CRCuotasPrestamo rpt = new CRCuotasPrestamo();
            frmRptCuotas frm = new frmRptCuotas();
            rptoption = rpt.PrintOptions;
            rptoption.PrinterName = ser.NombreImpresora;
            rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
            rpt.SetDataSource(dso.CuotasPrestamo(preban.CodPrestamoBancario).Tables[0]);
            frm.crvCuotas.ReportSource = rpt;
            frm.Show();
        }

        
    }
}
