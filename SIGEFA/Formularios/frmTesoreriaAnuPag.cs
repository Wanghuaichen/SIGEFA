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

namespace SIGEFA.Formularios
{
    public partial class frmTesoreriaAnuPag : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        clsAdmTipoDocumento admTipo = new clsAdmTipoDocumento();       
        clsAdmEmpresa admEmp = new clsAdmEmpresa();        
        clsAdmNotaSalida admNotaS = new clsAdmNotaSalida();
        clsNotaSalida notaS = new clsNotaSalida();
        clsAdmLetra admLetra = new clsAdmLetra();
        clsLetra let = new clsLetra();
        clsPago pagoRp = new clsPago();
        clsFacturaVenta venta = new clsFacturaVenta();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();

        private int vencidas = 0;
        private int porvencer = 0;
        private int pendientes = 0;
        

        public frmTesoreriaAnuPag()
        {
            InitializeComponent();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            dgvCobros.DataSource = data;
            data.DataSource = AdmVenta.MuestraCobrosVenta(cmbEstado.SelectedIndex, Convert.ToInt32(cmbAlmacen.SelectedValue), dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbTipo.SelectedValue));
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCobros.ClearSelection();
            DarFormato();
        }

        private void DarFormato()
        {
            foreach (DataGridViewRow row in dgvCobros.Rows)
            {
                if (row.Cells[morosidad.Name].Value.ToString() != " - ")
                {
                    if (Convert.ToDouble(row.Cells[morosidad.Name].Value) <= 0 && cmbEstado.SelectedIndex == 0 && row.Index != -1)
                    {
                        row.Cells[morosidad.Name].Style.BackColor = Color.Red;
                        row.Cells[morosidad.Name].Style.ForeColor = Color.White;
                        //row.DefaultCellStyle.BackColor = Color.Red;
                        //row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void frmTesoreriaAnuPag_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            CargaTipoDocumento();
            dtpFecha1.Value = dtpFecha2.Value.AddDays(-30);
            cmbEstado.SelectedIndex = 1;
            cmbAlmacen.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
            label7.Text = "Cliente";
            label6.Text = "cliente";
        }

        private void CalculodeFechasPagos()
        {
            try
            {
                vencidas = 0;
                porvencer = 0;
                pendientes = 0;

                foreach (DataGridViewRow row in dgvCobros.Rows)
                {
                    if (Convert.ToDateTime(row.Cells[fechavenc.Name].Value).Date < Convert.ToDateTime(System.DateTime.Now).Date)
                    {
                        vencidas = vencidas + 1;
                    }
                    else if (Convert.ToDateTime(row.Cells[fechavenc.Name].Value).Date == Convert.ToDateTime(System.DateTime.Now).Date)
                    {
                        porvencer = porvencer + 1;
                    }
                    else
                    {
                        pendientes = pendientes + 1;
                    }
                }
                lblpendientes.Text = Convert.ToString(pendientes);
                lblporvencer.Text = Convert.ToString(porvencer);
                lblvencidos.Text = Convert.ToString(vencidas);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void frmTesoreriaAnuPag_KeyDown(object sender, KeyEventArgs e)
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
        private void CargaAlmacenes()
        {
            cmbAlmacen.DataSource = admAlm.CargaAlmacenes(frmLogin.iNivelUser, frmLogin.iCodEmpresa, frmLogin.iCodUser);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedIndex = -1;
        }
        private void CargaTipoDocumento()
        {
            cmbTipo.DataSource = admTipo.CargaTipoDocumentos();
            cmbTipo.DisplayMember = "descripcion";
            cmbTipo.ValueMember = "codTipoDocumento";
            cmbTipo.SelectedIndex = -1;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvCobros.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvCobros.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvCobros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCobros.Rows.Count >= 1 && e.RowIndex != -1)
            {
                DataGridViewCell celda = dgvCobros.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Int32 itipo = Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[tipo.Name].Value);
                if (celda.Value.ToString() == "Ingresar Pago")
                {
                    if (itipo == 3)
                    {
                        venta.CodFacturaVenta = dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodNota = venta.CodFacturaVenta;
                        form.tipo = itipo;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes) 
                        { 
                            CargaLista(); 
                        }
                    }
                    else if (itipo == 4)
                    {
                        let.CodLetra = Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodLetra = let.CodLetra;
                        form.tipo = itipo;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            CargaLista();
                        }
                    }
                }
                else if (celda.Value.ToString() == "Muestra Pagos")
                {
                    if (itipo == 3)
                    {
                        venta.CodFacturaVenta = dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                        frmMuestraPagos2 form = new frmMuestraPagos2();
                        form.CodNota = Convert.ToInt32(venta.CodFacturaVenta);
                        form.InOut = true;
                        form.tipo = 0;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            CargaLista();
                        }
                    }
                    else if (itipo == 4)
                    {
                        let.CodLetra = Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmMuestraPagos2 form = new frmMuestraPagos2();
                        form.CodNota = let.CodLetra;
                        form.InOut = true;
                        form.tipo = 1;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            CargaLista();
                        }
                    }
                }
            }
        }

        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvCobros.SelectedRows[0];
            venta.CodFacturaVenta = Row.Cells[codnota.Name].Value.ToString();
            frmMuestraPagos2 form = new frmMuestraPagos2();
            form.CodNota = Convert.ToInt32(venta.CodFacturaVenta);
            form.InOut = true;
            form.ShowDialog();
            CargaLista();
        }

        private void canjearPorLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvCobros.SelectedRows.Count>0){
            DataGridViewRow Row = dgvCobros.CurrentRow;
            venta.CodFacturaVenta = Row.Cells[codnota.Name].Value.ToString();
            frmCanjearLetra form = new frmCanjearLetra();
            form.venta = venta;
            form.Procede = 2;
            form.ShowDialog();
            CargaLista();
            }
        }

        private void dgvCobros_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvCobros.SelectedRows.Count > 0 && e.RowIndex != -1)
            //{
                dgvCobros.ContextMenuStrip = new ContextMenuStrip();
                if (e.RowIndex != -1)
                {
                    dgvCobros.Rows[e.RowIndex].Selected = true;
                    if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                    {
                        if (dgvCobros.SelectedCells.Count > 0)
                        {
                            dgvCobros.ContextMenuStrip = contextMenuStrip1;
                            if (Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[tipo.Name].Value) == 3)
                            {
                                canjearPorLetraToolStripMenuItem.Enabled = true;
                                modificarLetraToolStripMenuItem.Enabled = false;
                                imprimirLetraToolStripMenuItem.Enabled = false;
                                ingresoABancoToolStripMenuItem.Enabled = false;
                                if (Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[cantidad.Name].Value) > 0)
                                {
                                    muestraPagosToolStripMenuItem.Enabled = true;
                                }
                                else
                                {
                                    muestraPagosToolStripMenuItem.Enabled = false;
                                }
                            }
                            else if (Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[tipo.Name].Value) == 4)
                            {
                                canjearPorLetraToolStripMenuItem.Enabled = false;
                                modificarLetraToolStripMenuItem.Enabled = true;
                                imprimirLetraToolStripMenuItem.Enabled = true;
                                ingresoABancoToolStripMenuItem.Enabled = true;
                                if (Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[cantidad.Name].Value) > 0)
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
            //}
        }

        private void dgvCobros_Sorted(object sender, EventArgs e)
        {
            DarFormato();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("codnota", typeof(string));
            dt.Columns.Add("vendedor", typeof(string));
            dt.Columns.Add("fechaemision", typeof(DateTime));
            dt.Columns.Add("tipo", typeof(string));
            dt.Columns.Add("numdocumento", typeof(string));
            dt.Columns.Add("documento", typeof(string));
            dt.Columns.Add("codcliente", typeof(string));
            dt.Columns.Add("codperso", typeof(string));
            dt.Columns.Add("cliente", typeof(string));
            dt.Columns.Add("formapago", typeof(string));
            dt.Columns.Add("fechavenc", typeof(DateTime));
            dt.Columns.Add("morosidad", typeof(string));
            dt.Columns.Add("moneda", typeof(string));
            dt.Columns.Add("monto", typeof(decimal));
            dt.Columns.Add("pendiente", typeof(decimal));
            dt.Columns.Add("banco", typeof(string));
            dt.Columns.Add("nuunico", typeof(string));
            dt.Columns.Add("accion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));            
            dt.Columns.Add("contado", typeof(decimal));
            dt.Columns.Add("credito", typeof(decimal));

            dt.Columns.Add("fecha1", typeof(DateTime));
            dt.Columns.Add("fecha2", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("tip", typeof(string));

            foreach (DataGridViewRow dgv in dgvCobros.Rows)
            {
                dt.Rows.Add(dgv.Cells[codnota.Name].Value,
                dgv.Cells[vendedor.Name].Value,
                Convert.ToDateTime(dgv.Cells[fechaemision.Name].Value),
                dgv.Cells[tipo.Name].Value,
                dgv.Cells[numdocumento.Name].Value,
                dgv.Cells[documento.Name].Value,
                dgv.Cells[codcliente.Name].Value,
                dgv.Cells[codperso.Name].Value,
                dgv.Cells[cliente.Name].Value,
                dgv.Cells[formpago.Name].Value,
                Convert.ToDateTime(dgv.Cells[fechavenc.Name].Value),                
                dgv.Cells[morosidad.Name].Value,
                dgv.Cells[moneda.Name].Value,
                Convert.ToDecimal(dgv.Cells[monto.Name].Value),
                Convert.ToDecimal(dgv.Cells[pendiente.Name].Value),
                dgv.Cells[banco.Name].Value,
                dgv.Cells[numunico.Name].Value,
                dgv.Cells[accion.Name].Value,
                Convert.ToDecimal(dgv.Cells[cantidad.Name].Value),
                Convert.ToDecimal(dgv.Cells[contado.Name].Value),
                Convert.ToDecimal(dgv.Cells[credito.Name].Value),
                dtpFecha1.Text,
                dtpFecha2.Text,
                cmbEstado.Text,
                cmbTipo.Text);
            }
            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\CobrosGeneralRPT.xml", XmlWriteMode.WriteSchema);

            CRCobrosGeneral rpt = new CRCobrosGeneral();
            frmRptCobrosGeneral frm = new frmRptCobrosGeneral();
            rpt.SetDataSource(ds);
            frm.crvCobrosGeneral.ReportSource = rpt;
            frm.Show();
        }

        private void ingresoABancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvCobros.CurrentRow;
            frmIngresoBanco form = new frmIngresoBanco();
            form.CodLetra = Convert.ToInt32(Row.Cells[codnota.Name].Value);
            form.Proceso = 1;
            form.ShowDialog();
            CargaLista();
        }

        private void dgvCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                DataGridViewRow row = dgvCobros.CurrentRow;
                Int32 itipo = Convert.ToInt32(row.Cells[tipo.Name].Value);
                if (row.Cells[accion.Name].Value.ToString() == "Ingresar Pago")
                {
                    if (itipo == 3)
                    {
                        venta.CodFacturaVenta = row.Cells[codnota.Name].Value.ToString();
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodNota = venta.CodFacturaVenta;
                        form.tipo = itipo;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            CargaLista();
                        }
                    }
                    else if (itipo == 4)
                    {
                        let.CodLetra = Convert.ToInt32(row.Cells[codnota.Name].Value);
                        frmCancelarPago form = new frmCancelarPago();
                        form.CodLetra = let.CodLetra;
                        form.tipo = itipo;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            CargaLista();
                        }
                    }
                }
            }
        }

        private void frmTesoreriaAnuPag_Shown(object sender, EventArgs e)
        {
            CargaLista();
            txtFiltro.Focus();
        }

        private void dgvCobros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (cmbEstado.Text == "PENDIENTES")
            {
                DarFormato();
            }
        }

        private void dgvCobros_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            CalculodeFechasPagos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        
    }
}
