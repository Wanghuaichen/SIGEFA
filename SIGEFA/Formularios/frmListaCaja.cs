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

namespace SIGEFA.Formularios
{
    public partial class frmListaCaja : DevComponents.DotNetBar.Office2007Form
    {
        private DataTable datosCarga = new DataTable();
        private DataTable datosAlmacena = new DataTable();

        private clsCtaCte Cta = new clsCtaCte();
        private clsAdmCtaCte AdmCta = new clsAdmCtaCte();
        private clsFlujoCaja flujo = new clsFlujoCaja();
        private clsAdmFlujoCaja admFlujo = new clsAdmFlujoCaja();
        //private clsCajaChica Caja = new clsCajaChica();
        //private clsAdmCajaChica AdmCaja = new clsAdmCajaChica();
        private clsFlujoCaja flu = new clsFlujoCaja();
        private clsTipoCambio tcambio = new clsTipoCambio();
        private clsAdmTipoCambio admTipoCambio = new clsAdmTipoCambio();
        
        private Decimal Saldo = 0;
        private Decimal Ingresos = 0;
        public Decimal Egresos = 0;
        private Decimal OtrosEgresos = 0;
        public Decimal MontoCierre = 0;
        public DateTime fechaCierre;
        public Decimal Soles = 0;
        public Decimal OtrosIngresos;
        public Int32 Proceso = 0; //(1)Insert  (2)Update
        private Int32 rpta;
        private Decimal MontoDeposito;
        private Decimal TotalVentasDia = 0;

        Int32 FilasChequeadas = 0;
        private Decimal MontoRendido = 0;
        
        public frmListaCaja()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void biActualizar_Click(object sender, EventArgs e)
        {
            VerificaSaldoCaja();
            CalculaTotales();
            ListaIngresosCaja();
        }

        private void ListaIngresosCaja()
        {
            limpia_campos_grilla(true);
            datosAlmacena.Clear();
            datosCarga = AdmCta.ListaCaja(frmLogin.iCodSucursal, dtpfecha1.Value);
            dgvMovimientosCaja.DataSource = datosCarga;
            dgvMovimientosCaja.ClearSelection();
        }

        private void ListaEgresosCaja()
        {
            limpia_campos_grilla(false);
            datosCarga.Clear();
            datosAlmacena = AdmCta.ListaEgresosCaja(frmLogin.iCodSucursal, dtpfecha1.Value);
            dgvMovimientosCaja.DataSource = datosAlmacena;
            dgvMovimientosCaja.ClearSelection();
        }

        private void ListaCajaChicaFechas()
        {
            //dgvMovimientosCaja.DataSource = data;
            //data.DataSource = AdmCaja.ListaCajaChicaFechas(frmLogin.iCodAlmacen, dtpfecha1.Value.Date, dtpfecha2.Value.Date);
            //data.Filter = String.Empty;
            //filtro = String.Empty;
            //dgvMovimientosCaja.ClearSelection();
        }

        public void VerificaSaldoCaja()
        {
            Saldo = 0;

            //Caja = AdmCaja.VerificaSaldoCajaChica(frmLogin.iCodSucursal);
            flu = admFlujo.VerificaSaldoCaja(frmLogin.iCodSucursal);
            if (flu != null)
            {
                //Saldo = Caja.MontoDisponible;
                //lblIngresos.Text = String.Format("{0:#,##0.00}", Caja.MontoIngresado.ToString());
                //lblEgresos.Text = String.Format("{0:#,##0.00}", Caja.MontoEntregado.ToString());
                //lblAperturaCaja.Text = String.Format("{0:#,##0.00}", Caja.MontoApertura.ToString());
                //lblSaldoCaja.Text = String.Format("{0:#,##0.00}", Caja.MontoDisponible.ToString());
                Saldo = flu.MontoDisponible;
                lblOtrosIngresos.Text = String.Format("{0:#, ##0.00}", flu.MontoIngresado);
                lblEgresos.Text = String.Format("{0:#, ##0.00}", flu.MontoDepositado);
                lblAperturaCaja.Text = String.Format("{0:#, ##0.00}", flu.MontoDisponible);
                lblSaldoCaja.Text = String.Format("{0:#, ##0.00}", flu.MontoDisponible);
            }
            else
            {
                Saldo = 0;
                lblIngresos.Text = "0.000";
                lblEgresos.Text = "0.000";
                lblAperturaCaja.Text = "0.000";
                lblSaldoCaja.Text = "0.000";
                //*****************************
                biDeposito.Enabled = false;
            }

            if (Saldo > 0)
            {
                biDeposito.Enabled = true;
                //biAperturaCajachica.Enabled = false;
            }
            else
            {
                //biAperturaCajachica.Enabled = true;
                //**********************************
                biDeposito.Enabled = false;
            }
        }

        public void CalculaTotales()
        {
            Ingresos = 0;
            if (dgvMovimientosCaja.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMovimientosCaja.Rows)
                {
                    if (Convert.ToString(row.Cells[mon.Name].Value) == "DOLARES AMERICANOS")
                    {
                        Soles = Soles +
                                (Convert.ToDecimal(row.Cells[total.Name].Value)*
                                 Convert.ToDecimal(row.Cells[tcventa.Name].Value));
                        Ingresos = Ingresos + Soles;
                    }
                    else Ingresos = Ingresos + Convert.ToDecimal(row.Cells[total.Name].Value);
                }
                TotalVentasDia = Ingresos;
                Soles = 0;
                Cta = AdmCta.VerificaEgresoCaja(frmLogin.iCodSucursal, dtpfecha1.Value);
                if (Cta != null)
                {
                    MontoDeposito = Cta.ingreso;
                    Ingresos = Ingresos + flu.MontoIngresado;
                }
                else MontoDeposito = Convert.ToDecimal(0.000);

                lblEgresos.Text = String.Format("{0:#,##0.000}", MontoDeposito);
                lblIngresos.Text = String.Format("{0:#,##0.000}", Ingresos);
                
                Saldo = (Saldo + Ingresos - Egresos);
                lblSaldoCaja.Text = String.Format("{0:#,##0.000}", Saldo);
            }
        }

        private void CalculaOtrosEgresos()
        {
            foreach (DataGridViewRow row in dgvMovimientosCaja.Rows)
            {
                if (Convert.ToInt32(row.Cells[tipoproc.Name].Value) == 2)
                {
                    OtrosEgresos = OtrosEgresos + Convert.ToDecimal(row.Cells[ingreso.Name].Value);
                }
            }
            lblOtrosEgresos.Text = String.Format("{0:#,##0.000}", OtrosEgresos);
        }

        public void agrega()
        {
            lblSaldoCaja.Text = lblSaldoCaja.Text.Replace(" ", "").Trim();
            lblSaldoCaja.Text = lblSaldoCaja.Text.Replace(",", "").Trim();
            if (Convert.ToDecimal(lblSaldoCaja.Text.Trim()) > 0)
            //if (Saldo > 0)
            {
                flujo.FechaApertura = dtpfecha1.Value;
                flujo.CodSucursal = frmLogin.iCodSucursal;
                flujo.CodUser = frmLogin.iCodUser;
                admFlujo.Insert(flujo);
                VerificaSaldoCaja();
                CalculaTotales();
            }
        }
        
        private void frmListaCaja_Load(object sender, EventArgs e)
        {
            dtpfecha1.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            dtpfecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            dtpfecha2.MinDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            dtpfecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            activa_elementos(true);
            cboMovimientos.SelectedIndex = 0;
            VerificaSaldoCaja();
            agrega();
            ListaIngresosCaja();
            CalculaTotales();
            rpta = admFlujo.VerificaAperturaCaja(frmLogin.iCodSucursal);
            if (rpta > 0) biStatusCaja.Visible = true;
            //else biStatusCaja.Visible = false;
            
        }

        private void activa_elementos(Boolean activo)
        {
            label14.Visible = activo;
            label12.Visible = activo;
            lblOtrosIngresos.Visible = activo;
            lblOtrosEgresos.Visible = activo;
        }

        private void biIngreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmFlujoCajaRegistro"] != null)
            {
                Application.OpenForms["frmFlujoCajaRegistro"].Activate();
            }
            else
            {
                /* ******** ME QUEDO AQUI */
                frmFlujoCajaRegistro form = new frmFlujoCajaRegistro();
                form.Proceso = 1;
                form.Procede = 2;
                form.Text = "APERTURA DE CAJA";
                form.Size = new Size(511,281);
                form.ShowDialog();
                VerificaSaldoCaja();
                ListaIngresosCaja();
                CalculaTotales();
            }
        }

        private void biHistorialRendiciones_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["frmCajaChicaRendicionHistorial"] != null)
            //{
            //    Application.OpenForms["frmCajaChicaRendicionHistorial"].Activate();
            //}
            //else
            //{
            //    frmCajaChicaRendicionHistorial form = new frmCajaChicaRendicionHistorial();
            //    form.ShowDialog();
            //    ListaIngresosCaja();

            //}
        }
        
        private void biEgreso_Click(object sender, EventArgs e)
        {
            //frmMovimientosControl frm = new frmMovimientosControl();
            //frm.Proceso = 1;
            //frm.Procede = 2;
            //frm.Text = "Movimientos Bancarios";
            //frm.label5.Visible = false;
            //frm.cmbtipopagoser.Visible = false;
            //frm.ShowDialog();
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboMovimientos.SelectedIndex = 0;
            ListaIngresosCaja();
        }

        private void dtpfecha1_Leave(object sender, EventArgs e)
        {
            //dtpfecha2.MinDate = dtpfecha1.Value;
        }

        private void dtpfecha2_Leave(object sender, EventArgs e)
        {
            //dtpfecha1.MaxDate = dtpfecha2.Value;
        }

        private void dtpfecha1_ValueChanged(object sender, EventArgs e)
        {
            //ListaCajaChicaFechas();
        }

        private void dtpfecha2_ValueChanged(object sender, EventArgs e)
        {
           // ListaCajaChicaFechas();
        }

        private void biEditar_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientosCaja.Rows.Count >0)
            //{
            //    frmCajaChicaRegistro frm = new frmCajaChicaRegistro();
            //    if ((dgvMovimientosCaja.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "INGRESO")
            //    { frm.Tipo = 1; }
            //    else if ((dgvMovimientosCaja.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "EGRESO")
            //    { frm.Tipo = 2; }
            //    frm.Proceso = 2;
            //    //frm.Caja = Caja;
            //    frm.txtCodigo.Text = dgvMovimientosCaja.SelectedRows[0].Cells[codigo.Name].Value.ToString();
            //    frm.cboTipoPagoCaja.SelectedValue = Convert.ToInt32(dgvMovimientosCaja.SelectedRows[0].Cells[codTipoPagoCaja.Name].Value);
            //    frm.CodtipoCajaChica = Convert.ToInt32(dgvMovimientosCaja.SelectedRows[0].Cells[codTipoPagoCaja.Name].Value);
            //    frm.txtDescripcion.Text = dgvMovimientosCaja.SelectedRows[0].Cells[concepto.Name].Value.ToString();
            //    frm.txtDocumento.Text = dgvMovimientosCaja.SelectedRows[0].Cells[numDocumento.Name].Value.ToString();
            //    frm.txtMonto.Text = dgvMovimientosCaja.SelectedRows[0].Cells[monto.Name].Value.ToString();
            //    frm.dtpFecha.Value = Convert.ToDateTime(dgvMovimientosCaja.SelectedRows[0].Cells[fecha.Name].Value.ToString());
            //    frm.txtGuiaRemision.Text = dgvMovimientosCaja.SelectedRows[0].Cells[numGuia.Name].Value.ToString();
            //    frm.txtReciboLiquidacion.Text = dgvMovimientosCaja.SelectedRows[0].Cells[numRecLiquidacion.Name].Value.ToString();                
            //    Int32 TipoTarea = 0;
            //    if (dgvMovimientosCaja.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "")
            //    { frm.cboTipo.SelectedIndex = 0; }
            //    else if (dgvMovimientosCaja.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "CARGA")
            //    { frm.cboTipo.SelectedIndex = 1; }
            //    else if (dgvMovimientosCaja.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "DESCARGA")
            //    { frm.cboTipo.SelectedIndex = 2; }
            //    frm.txtToneladas.Text = dgvMovimientosCaja.SelectedRows[0].Cells[toneladas.Name].Value.ToString();
            //    frm.lblEgreso.Text = dgvMovimientosCaja.SelectedRows[0].Cells[monto.Name].Value.ToString();
            //    frm.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
            //    frm.ShowDialog();
            //    ListaIngresosCaja();
            //    VerificaSaldoCaja();
            //}
        }

        private void dgvMovimientosCajaChica_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvMovimientosCajaChica.Rows.Count >= 1 && e.Row.Selected)
            //{
            //    if (e.Row.Cells[apertura.Name].Value.ToString() == "2")
            //    {
            //        biEditar.Enabled = false;
            //    }
            //    else
            //    { biEditar.Enabled = true; }
            //    //*****************************************************
            //    if (e.Row.Cells[apertura.Name].Value.ToString() == "2")
            //    {

            //    }
            //}
        }

        private void dgvMovimientosCajaChica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    if (e.RowIndex != -1)
        //    {
        //        frmCajaChicaRegistro frm = new frmCajaChicaRegistro();
        //        if ((dgvMovimientosCaja.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "INGRESO")
        //        { frm.Tipo = 1; }
        //        else if ((dgvMovimientosCaja.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "EGRESO")
        //        { frm.Tipo = 2; }
        //        frm.Proceso = 3;
        //        //frm.Caja = Caja;
        //        frm.ShowDialog();
        //    }
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientosCaja.Rows.Count > 0)
            //{
            //    Caja.CodCajaChica = Convert.ToInt32(dgvMovimientosCaja.SelectedRows[0].Cells[codigo.Name].Value.ToString());
            //    if (Caja.CodCajaChica != 0)
            //    {
            //        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Familia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dlgResult == DialogResult.No)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            if (AdmCaja.delete(Caja.CodCajaChica))
            //            {
            //                MessageBox.Show("El dato ha sido eliminado correctamente", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                VerificaSaldoCaja();
            //                ListaIngresosCaja();
            //            }
            //        }
            //    }
            //}
        }

        private void CalculoSaldo()
        {
            try
            {
                //Ingresos = 0;
                //Egresos = 0;
                ////Saldo = 0;

                //foreach (DataGridViewRow row in dgvMovimientosCaja.Rows)
                //{
                //    if (row.Cells[tipoMovimiento.Name].Value.ToString() == "INGRESO")
                //    {
                //        Ingresos = Ingresos + (Convert.ToDecimal(row.Cells[monto.Name].Value));
                //    }
                //    else if (row.Cells[tipoMovimiento.Name].Value.ToString() == "EGRESO")
                //    {
                //        Egresos = Egresos + (Convert.ToDecimal(row.Cells[monto.Name].Value));
                //    }
                //}
                
                ////lblAperturaCaja.Text = AperturaCaja.ToString();
                //lblIngresos.Text = String.Format("{0:#,##0.00}", Ingresos.ToString());
                //lblEgresos.Text = String.Format("{0:#,##0.00}", Egresos.ToString());
                //Decimal SaldoCaja = ((Saldo + Ingresos) - Egresos);
                //lblSaldoCaja.Text = String.Format("{0:#,##0.00}", SaldoCaja.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void dgvMovimientosCajaChica_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //CalculoSaldo();
        }

        private void dgvMovimientosCajaChica_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //CalculoSaldo();
        }

        private void biRendicionesContables_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["frmCajaChicaRendicion"] != null)
            //{
            //    Application.OpenForms["frmCajaChicaRendicion"].Activate();
            //}
            //else
            //{
            //    frmCajaChicaRendicion form = new frmCajaChicaRendicion();
            //    form.MdiParent = this.MdiParent;
            //    form.Show();
            //}
        }

        private void biRencicionCaja_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientosCaja.RowCount > 0)
            //{
            //    if (FilasChequeadas > 0)
            //    {
            //        DialogResult dlgResult = MessageBox.Show("Desea Rendir Caja Chica", "Gestion de Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dlgResult == DialogResult.No)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            Caja.Monto = MontoRendido;
            //            Caja.FechaRendicion = Convert.ToDateTime(System.DateTime.Now);
            //            Caja.CodUser = frmLogin.iCodUser;
            //            Caja.CodSucursal = frmLogin.iCodSucursal;
            //            MontoRendido = 0;

            //            if (Caja != null)
            //            {
            //                if (AdmCaja.InsertRendicion(Caja))
            //                {                                
            //                    //foreach (clsCajaChica clsCaja in seleccion2)
            //                    //{
            //                    //    clsCaja.CodRendicion = Caja.CodRendicion;
            //                    //    AdmCaja.InsertDetalleRendicion(clsCaja);
            //                    //}
            //                    //seleccion2.Clear();
            //                }
            //            }
            //            MessageBox.Show("Rendicion Generada! Puede Consultarla en 'Verificar rendiciones!'", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            cboMovimientos.SelectedIndex = 0;
            //            //ListaCajaChica(); 
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Seleccione Gastos Para Proseguir con la Rendicion de Caja Chica", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void biVerificarRendicion_Click(object sender, EventArgs e)
        {
            //frmCajaChicaRendicionListado frm = new frmCajaChicaRendicionListado();
            //frm.ShowDialog();
            //VerificaSaldoCaja();
            //ListaIngresosCaja();
        }

        private void dgvMovimientosCajaChica_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvMovimientosCaja.IsCurrentCellDirty)
            //{
            //    dgvMovimientosCaja.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void dgvMovimientosCajaChica_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dgvMovimientosCaja.Columns[e.ColumnIndex].Name == Item.Name)
                //{
                //    DataGridViewRow row = dgvMovimientosCaja.Rows[e.RowIndex];

                //    DataGridViewCheckBoxCell cellSelecion = row.Cells[Item.Name] as DataGridViewCheckBoxCell;

                //    clsCajaChica CajaChica = new clsCajaChica();
                //    if (Convert.ToBoolean(cellSelecion.Value))
                //    {
                //        FilasChequeadas = FilasChequeadas + 1;
                //        MontoRendido = MontoRendido + (Convert.ToDecimal(row.Cells[monto.Name].Value));
                //        seleccion.Add(Convert.ToInt32(row.Cells[codigo.Name].Value));
                //        //*****************************************************************************
                //        CajaChica.CodRendicion = Caja.CodRendicion;
                //        CajaChica.CodCajaChica = Convert.ToInt32(row.Cells[codigo.Name].Value);
                //        CajaChica.Monto = Convert.ToInt32(row.Cells[monto.Name].Value);
                //        CajaChica.CodUser = frmLogin.iCodUser;
                //        CajaChica.CodSucursal = frmLogin.iCodSucursal;
                //        //*****************************************************************************                                                
                //        seleccion2.Add(CajaChica);
                //    }
                //    else
                //    {
                //        FilasChequeadas = FilasChequeadas - 1;
                //        MontoRendido = MontoRendido - (Convert.ToDecimal(row.Cells[monto.Name].Value));
                //        seleccion.Remove(Convert.ToInt32(row.Cells[codigo.Name].Value));
                //        //seleccion2.RemoveAll(CajaChica => CajaChica.CodCajaChica == Convert.ToInt32(row.Cells[codigo.Name].Value));
                //    }

                //    if (FilasChequeadas > 0)
                //    { biRencicionCaja.Enabled = true; }
                //    else
                //    { biRencicionCaja.Enabled = false; }
                //}
            }
        }

        private void biBuscar_Click(object sender, EventArgs e)
        {
            if (cboMovimientos.SelectedIndex == 0)
            {
                lblColumna.Text = "Num.Doc";
                lblProperty.Text = "ndoc";
            }
            else
            {
                lblColumna.Text = "Banco";
                lblProperty.Text = "codban";
            }
            

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

        private void btnclose_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void dgvMovimientosCajaChica_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMovimientosCaja.Columns[e.ColumnIndex].Index > 0)
            {
                lblColumna.Text = dgvMovimientosCaja.Columns[e.ColumnIndex].HeaderText;
                lblProperty.Text = dgvMovimientosCaja.Columns[e.ColumnIndex].DataPropertyName;

                if (expandablePanel1.Expanded)
                {
                    txtFiltro.Focus();
                }
            }
        }

        private void frmListaCaja_Shown(object sender, EventArgs e)
        {
            lblAperturaCaja.Text = lblAperturaCaja.Text.Replace(" ", "").Trim();
            lblAperturaCaja.Text = lblAperturaCaja.Text.Replace(",", "").Trim();
            if (Saldo != 0 && Convert.ToDecimal(lblAperturaCaja.Text) != 0)
            {
                //lblAperturaCaja.Text = Saldo.ToString();
                //biIngreso.Enabled = true;
                biEgreso.Visible = false;
                biDeposito.Enabled = true;
                biStatusCaja.Visible = true;
            }
            else
            {
                lblAperturaCaja.Text = "0.000";
                biIngreso.Visible = true;
                biIngreso.Enabled = true;
                biDeposito.Enabled = false;
                if (Saldo == 0 || Convert.ToDecimal(lblAperturaCaja.Text) == 0)
                {

                    if (Application.OpenForms["frmFlujoCajaRegistro"] != null)
                    {
                        Application.OpenForms["frmFlujoCajaRegistro"].Activate();
                    }
                    else
                    {
                        frmFlujoCajaRegistro form = new frmFlujoCajaRegistro();
                        form.Proceso = 1;
                        form.Procede = 2;
                        form.Text = "APERTURA DE CAJA";
                        form.Size = new Size(511, 281);
                        form.ShowDialog();
                        //VerificaSaldoCaja();
                        //ListaIngresosCaja();
                        //CalculaTotales();
                    }
                }
            }
            lblSaldoCaja.Text = lblSaldoCaja.Text.Replace(" ", "").Trim();
            lblSaldoCaja.Text = lblSaldoCaja.Text.Replace(",", "").Trim();
            if (Convert.ToDecimal(lblSaldoCaja.Text) > 0 || Convert.ToDecimal(lblAperturaCaja.Text) >= 0)
            {
                biStatusCaja.Visible = true;
            }
        }

        private void biAperturaCajachica_Click(object sender, EventArgs e)
        {
            if (Saldo == 0)
            {
                if (Application.OpenForms["frmCajaChicaRegistro"] != null)
                {
                    Application.OpenForms["frmCajaChicaRegistro"].Activate();
                }
                else
                {
                    frmCajaChicaRegistro form = new frmCajaChicaRegistro();
                    form.Tipo = 1;
                    form.Proceso = 1;
                    form.AperturaCaja = 1;
                    form.ShowDialog();
                    ListaIngresosCaja();
                    VerificaSaldoCaja();
                }
            }
        }

        private void limpia_campos_grilla(Boolean estado)
        {
            dgvMovimientosCaja.Columns["ndoc"].Visible = estado;
            dgvMovimientosCaja.Columns["fechas"].Visible = estado;
            dgvMovimientosCaja.Columns["codCli"].Visible = estado;
            dgvMovimientosCaja.Columns["cliente"].Visible = estado;
            dgvMovimientosCaja.Columns["total"].Visible = estado;
            dgvMovimientosCaja.Columns["mon"].Visible = estado;
            dgvMovimientosCaja.Columns["tcventa"].Visible = estado;
            dgvMovimientosCaja.Columns["tcventa"].HeaderText = "TipoCambio";
            dgvMovimientosCaja.Columns["banco"].Visible = !estado;
            dgvMovimientosCaja.Columns["ctacte"].Visible = !estado;
            dgvMovimientosCaja.Columns["numoperacion"].Visible = !estado;
            dgvMovimientosCaja.Columns["fechamov"].Visible = !estado;
            dgvMovimientosCaja.Columns["ingreso"].Visible = !estado;
            dgvMovimientosCaja.Columns["concepto"].Visible = !estado;
            dgvMovimientosCaja.Columns["documentoref"].Visible = !estado;
        }
        
        private void biRendicionLiquidada_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRendicionesVigentes"] != null)
            {
                Application.OpenForms["frmRendicionesVigentes"].Activate();
            }
            else
            {
                frmRendicionesVigentes frm = new frmRendicionesVigentes();
                frm.ShowDialog();
                VerificaSaldoCaja();
                ListaIngresosCaja();
            }
        }

        private void cboMovimientos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMovimientos.SelectedIndex == 0)
            {
                datosAlmacena.Clear();
                ListaIngresosCaja();
                label12.Visible = false;
                lblOtrosEgresos.Visible = false;
            }
            else
            {
                if (cboMovimientos.SelectedIndex == 1)
                {
                    datosCarga.Clear();
                    ListaEgresosCaja();
                    //label12.Visible = true;
                    //lblOtrosEgresos.Visible = true;
                    CalculaOtrosEgresos();
                }
            }
        }

        private void biStatusCaja_Click(object sender, EventArgs e)
        {
            frmCaja frm = new frmCaja();
            frm.ShowDialog();
        }

        private void biDeposito_Click(object sender, EventArgs e)
        {
            frmMovimientosControl frm = new frmMovimientosControl();
            frm.Proceso = 1;
            frm.Procede = 2;
            //frm.TipoProcedencia = 1;
            frm.Soles = TotalVentasDia;
            frm.Text = "Movimientos Bancarios";
            frm.totalv = TotalVentasDia;
            frm.label5.Visible = false;
            frm.cmbtipopagoser.Visible = false;
            frm.ShowDialog();
            VerificaSaldoCaja();
        }
    }
}
