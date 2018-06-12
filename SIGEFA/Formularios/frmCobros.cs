using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmCobros : DevComponents.DotNetBar.Office2007Form
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


        public frmCobros()
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
            data.DataSource = AdmVenta.MuestraCobrosVenta(cmbEstado.SelectedIndex, frmLogin.iCodAlmacen, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbTipo.SelectedValue));
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
                if (Convert.ToInt32(row.Cells[xaprobars.Name].Value) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }
                //MessageBox.Show(row.Cells[numdocumento.Name].Value.ToString().Length.ToString());
                if (row.Cells[numdocumento.Name].Value.ToString().Length <= 8)
                {
                    row.DefaultCellStyle.BackColor = Color.Turquoise;
                }
            }
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            CargaTipoDocumento();
            dtpFecha1.Value = dtpFecha2.Value.AddDays(-30);
            cmbEstado.SelectedIndex = 0;
            cmbAlmacen.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
            label7.Text = "Cliente";
            label6.Text = "cliente";
            EventArgs aven = new EventArgs();
            cmbEstado_SelectionChangeCommitted(cmbEstado, aven);
            EventArgs aventi = new EventArgs();
            cmbTipo_SelectionChangeCommitted(cmbTipo, aventi);
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

        private void frmCobros_KeyDown(object sender, KeyEventArgs e)
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
                        if (Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[xaprobars.Name].Value) > 0)
                        {
                            MessageBox.Show("PENDIENTE DE APROBACION", "IMPOSIBLE REGISTRAR NUEVO PAGO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dgvCobros.Rows[e.RowIndex].Cells[numdocumento.Name].Value.ToString().Length <= 8)
                            {
                                MessageBox.Show("PENDIENTE DE IMPRESIÓN", "IMPOSIBLE REGISTRAR NUEVO PAGO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                            else
                            {
                                venta.CodFacturaVenta = dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                                venta.CodCliente = Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[codcliente.Name].Value.ToString());
                                frmCancelarPago form = new frmCancelarPago();
                                form.CodNota = venta.CodFacturaVenta;
                                form.CodCliente = venta.CodCliente;
                                form.tipo = itipo;
                                form.VentComp = 1;
                                DialogResult dlgResult = form.ShowDialog();
                                //if (dlgResult == DialogResult.Yes) 
                                //{ 
                                //CargaLista();
                                //}    
                            }
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
                            //CargaLista();
                        }
                    }
                }
                else if (celda.Value.ToString() == "Muestra Pagos")
                {
                    if (itipo == 3)
                    {
                        venta.CodFacturaVenta = dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value.ToString();
                        venta.Pendiente = Convert.ToDouble(dgvCobros.Rows[e.RowIndex].Cells[pendiente.Name].Value.ToString());
                        Decimal totalM = Convert.ToDecimal(dgvCobros.Rows[e.RowIndex].Cells[monto.Name].Value.ToString());
                        frmMuestraPagos form = new frmMuestraPagos();
                        form.CodNota = Convert.ToInt32(venta.CodFacturaVenta);
                        if (cmbEstado.SelectedIndex == 0)
                        {
                            form.montoTotal = Convert.ToDecimal(venta.Pendiente);
                        }
                        else if (cmbEstado.SelectedIndex == 1)
                        {
                            form.montoTotal = Convert.ToDecimal(totalM);
                        }
                        form.InOut = true;
                        form.tipo = 0;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            //CargaLista();
                        }
                    }
                    else if (itipo == 4)
                    {
                        let.CodLetra = Convert.ToInt32(dgvCobros.Rows[e.RowIndex].Cells[codnota.Name].Value);
                        frmMuestraPagos form = new frmMuestraPagos();
                        form.CodNota = let.CodLetra;
                        form.InOut = true;
                        form.tipo = 1;
                        DialogResult dlgResult = form.ShowDialog();
                        if (dlgResult == DialogResult.Yes)
                        {
                            //CargaLista();
                        }
                    }
                }
            }
        }

        private void muestraPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dgvCobros.SelectedRows[0];
            venta.CodFacturaVenta = Row.Cells[codnota.Name].Value.ToString();
            venta.Pendiente = Convert.ToDouble(Row.Cells[pendiente.Name].Value.ToString());
            Decimal totalM = Convert.ToDecimal(Row.Cells[monto.Name].Value.ToString());
            frmMuestraPagos form = new frmMuestraPagos();
            form.CodNota = Convert.ToInt32(venta.CodFacturaVenta);
            if (cmbEstado.SelectedIndex == 0)
            {
                form.montoTotal = Convert.ToDecimal(venta.Pendiente);
            }
            else if (cmbEstado.SelectedIndex == 1)
            {
                form.montoTotal = Convert.ToDecimal(totalM);
            }

            form.InOut = true;
            form.ShowDialog();
            //CargaLista();
        }

        private void canjearPorLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCobros.SelectedRows.Count > 0)
            {
                DataGridViewRow Row = dgvCobros.CurrentRow;
                venta.CodFacturaVenta = Row.Cells[codnota.Name].Value.ToString();
                frmCanjearLetra form = new frmCanjearLetra();
                form.venta = venta;
                form.Procede = 2;
                form.ShowDialog();
                //CargaLista();
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
            //CargaLista();
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
                            //CargaLista();
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
                            //CargaLista();
                        }
                    }
                }
            }
        }

        private void frmCobros_Shown(object sender, EventArgs e)
        {
            //CargaLista();
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
            //CargaLista();
        }

        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CargaLista();
            tipocmb = Convert.ToInt32(cmbTipo.SelectedValue);
        }


        private int cbestado;
        private int tipocmb;


        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CargaLista();
            cbestado = cmbEstado.SelectedIndex;
        }

        DataTable mySource;
        private void backCobros_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backCobros.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                backCobrosProcessLogicMethod();
            }
        }

        private void backCobrosProcessLogicMethod()
        {
            Thread.Sleep(2000);
            try
            {
                if (backCobros != null)
                {
                    if (mySource != null)
                    {
                        mySource = null;
                    }
                    else
                    {
                        mySource = AdmVenta.MuestraCobrosVenta(cbestado, Convert.ToInt32(cmbAlmacen.SelectedValue), dtpFecha1.Value, dtpFecha2.Value, tipocmb);
                        foreach (DataRow row in mySource.Rows)
                        {
                            backCobros.ReportProgress(mySource.Rows.IndexOf(row));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backCobros_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataTable mydatOld = null;
            DataTable mydataResult = null;
            if (dgvCobros.DataSource != null)
            {
                mydatOld = new DataTable();
                //mydatOld = (DataTable) dataGpedidos.DataSource;
                mydatOld = (DataTable)data.DataSource;
                // COMPARAR
                mydataResult = new DataTable();
                mydataResult = getDifferentRecords(mydatOld, mySource);
                // COMPARAR
                if (mydataResult != null)
                {
                    if (mydataResult.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        dgvCobros.AutoGenerateColumns = false;
                        //filtro
                        dgvCobros.DataSource = data;
                        data.DataSource = mySource;
                        data.Filter = String.Empty;
                        filtro = String.Empty;
                        //filtro
                        dgvCobros.ClearSelection();
                        DarFormato();
                    }
                }

            }
            else
            {
                dgvCobros.AutoGenerateColumns = false;
                //filtro
                dgvCobros.DataSource = data;
                data.DataSource = mySource;
                data.Filter = String.Empty;
                filtro = String.Empty;
                //filtro
                dgvCobros.ClearSelection();
                DarFormato();
            }
        }

        private DataTable getDifferentRecords(DataTable mydatOld, DataTable mySource)
        {
            //Create Empty Table     
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            try
            {
                //use a Dataset to make use of a DataRelation object     
                using (DataSet ds = new DataSet())
                {
                    //Add tables     
                    ds.Tables.AddRange(new DataTable[] { mydatOld.Copy(), mySource.Copy() });

                    //Get Columns for DataRelation     
                    DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                    for (int i = 0; i < firstColumns.Length; i++)
                    {
                        firstColumns[i] = ds.Tables[0].Columns[i];
                    }

                    DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                    for (int i = 0; i < secondColumns.Length; i++)
                    {
                        secondColumns[i] = ds.Tables[1].Columns[i];
                    }

                    //Create DataRelation     
                    DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                    ds.Relations.Add(r1);

                    DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                    ds.Relations.Add(r2);

                    //Create columns for return table     
                    for (int i = 0; i < mydatOld.Columns.Count; i++)
                    {
                        ResultDataTable.Columns.Add(mydatOld.Columns[i].ColumnName, mydatOld.Columns[i].DataType);
                    }

                    //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.     
                    ResultDataTable.BeginLoadData();
                    foreach (DataRow parentrow in ds.Tables[0].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r1);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }

                    //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.     
                    foreach (DataRow parentrow in ds.Tables[1].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r2);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }
                    ResultDataTable.EndLoadData();
                }

                return ResultDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ResultDataTable = null;
                return ResultDataTable;
            }
        }

        private void backCobros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (backCobros == null)
            {
                this.Close();
            }
            else
            {
                backCobros.RunWorkerAsync();
            }
        }
        private void arrancaBack()
        {
            if (backCobros.IsBusy)
            {
            }
            else
            {
                backCobros.RunWorkerAsync();
            }
        }

        private void frmCobros_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillMe();
        }

        private void KillMe()
        {
            backCobros.CancelAsync();
            backCobros.Dispose();
            backCobros = null;
            GC.Collect();
        }
    }
}
