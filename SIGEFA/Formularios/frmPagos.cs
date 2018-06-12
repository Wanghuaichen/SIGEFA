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
    public partial class frmPagos : DevComponents.DotNetBar.Office2007Form
    {

        //-----------------

        clsReportePagos ds = new clsReportePagos();

        //---------------
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmFactura admfac=new clsAdmFactura();
        clsFactura fac=new clsFactura();
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmTipoDocumento admTipo = new clsAdmTipoDocumento();
        //clsAdmNotaIngreso admNotaI = new clsAdmNotaIngreso();
        //clsNotaIngreso notaI = new clsNotaIngreso();
        clsAdmLetra admLetra = new clsAdmLetra();
        clsLetra let = new clsLetra();
        clsPago pagoRp = new clsPago();

        //clsCajaChica Caja = new clsCajaChica();
        //clsAdmCajaChica AdmCaja = new clsAdmCajaChica();
        public Int32 tipocaja = 0;

        public frmPagos()
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
            data.DataSource = admfac.MuestraPagosFactura(cmbEstado.SelectedIndex, Convert.ToInt32(cmbEmpresa.SelectedValue), dtpFecha1.Value, dtpFecha2.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPagos.ClearSelection();
        }
        
        private void frmPagos_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
           
            dtpFecha1.Value = dtpFecha2.Value.AddDays(-90);
            cmbEstado.SelectedIndex = 0;
            //cmbEmpresa.SelectedIndex = 0;            
            label7.Text = "Proveedor";
            label6.Text = "proveedor";
           
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
            cmbEmpresa.SelectedValue = frmLogin.iCodEmpresa;
        }
        
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvPagos.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvPagos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Rows.Count >= 1 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell celda = dgvPagos.CurrentCell;
                Int32 itipo = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[tipo.Name].Value);
                if (celda.Value.ToString() == "Ingresar Pago")
                {
                    if (itipo == 1)
                    {
                        //MOD7 aca poner la validacion si el pago de detraccion aun no ha sido cancelado no debe permitir cancelar la factura
                        fac.CodFactura= Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        fac.CodProveedor = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codproveedore.Name].Value.ToString());
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodNota = fac.CodFactura.ToString();
                        form.tipo = itipo;
                        form.VentComp = 2;
                        form.CodCliente = fac.CodProveedor;
                        form.ShowDialog();
                        CargaLista();
                    }
                    else if (itipo == 2)
                    {
                        let.CodLetra = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodLetra = let.CodLetra;
                        form.tipo = itipo;
                        form.ShowDialog();
                        CargaLista();
                    }
                }
                else if (celda.Value.ToString() == "Muestra Pagos")
                {
                    if (itipo == 1)
                    {
                        fac.CodFactura = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmMuestraPagos form = new frmMuestraPagos();
                        form.CodNota = fac.CodFactura;
                        form.InOut = false;
                        form.tipo = 0;
                        form.ShowDialog();
                        CargaLista();
                    }
                    else if (itipo == 2)
                    {
                        let.CodLetra = Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmMuestraPagos form = new frmMuestraPagos();
                        form.CodNota = let.CodLetra;
                        form.InOut = false;
                        form.tipo = 1;
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
                    if (Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[estado.Name].Value) == 0) // se comprueba que la compra no este cancela para mostrar el menu desplegable
                    {
                        if (dgvPagos.SelectedCells.Count > 0)
                        {
                            dgvPagos.ContextMenuStrip = contextMenuStrip1;
                            if (Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[tipo.Name].Value) == 1)
                            {
                                canjearPorLetraToolStripMenuItem.Enabled = true;
                                modificarLetraToolStripMenuItem.Enabled = false;
                                imprimirLetraToolStripMenuItem.Enabled = false;
                                ingresoABancoToolStripMenuItem.Enabled = false;
                                if (Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[cantidad.Name].Value) > 0)
                                {
                                    muestraPagosToolStripMenuItem.Enabled = true;
                                }
                                else
                                {
                                    muestraPagosToolStripMenuItem.Enabled = false;
                                }
                            }
                            else
                            {
                                canjearPorLetraToolStripMenuItem.Enabled = false;
                                modificarLetraToolStripMenuItem.Enabled = true;
                                imprimirLetraToolStripMenuItem.Enabled = true;
                                ingresoABancoToolStripMenuItem.Enabled = true;
                                if (Convert.ToInt32(dgvPagos.Rows[e.RowIndex].Cells[cantidad.Name].Value) > 0)
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
            }
        }

        Int32 tipodocumento = 0;
        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPagos.SelectedRows[0];
            fac.CodFactura = Convert.ToInt32(Row.Cells[codnota.Name].Value);
            tipodocumento = Convert.ToInt32(Row.Cells[tipo.Name].Value);
            frmMuestraPagosProveedor form = new frmMuestraPagosProveedor();
            form.CodNota = fac.CodFactura;
            form.tipodocumento = tipodocumento;
            form.InOut = false;
            form.ShowDialog();
            CargaLista();
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
            DataGridViewRow Row = dgvPagos.SelectedRows[0];
            fac.CodFactura =Convert.ToInt32(Row.Cells[codnota.Name].Value);
            frmCanjearLetra form = new frmCanjearLetra();
            form.notaI = fac;
            form.Procede = 1;
            form.ShowDialog();
            CargaLista();
        }

        private void nuevaLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            frmGestionLetra form = new frmGestionLetra();
            form.Proceso = 1;
            form.ShowDialog();
            CargaLista();
        }

        private void modificarLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPagos.SelectedRows[0];
            let.CodLetra = Convert.ToInt32(Row.Cells[codnota.Name].Value);
            frmGestionLetra form = new frmGestionLetra();
            form.letra = let;
            form.Proceso = 2;
            form.ShowDialog();
            CargaLista();
        }

        private void ingresoABancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvPagos.CurrentRow;           
            frmIngresoBanco form = new frmIngresoBanco();
            form.CodLetra = Convert.ToInt32(Row.Cells[codnota.Name].Value);
            form.Proceso = 1;
            form.ShowDialog();
            CargaLista();
        }

        private void frmPagos_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

        private void canjearPorCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //----------------------
    }
}
