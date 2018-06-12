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
    public partial class frmCajaChica : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public List<Int32> seleccion = new List<Int32>();
        

        clsCaja CajaChica = new clsCaja();
        clsAdmAperturaCierre AdmCaja = new clsAdmAperturaCierre();

        public Int32 tipo = 0;//tipo 1- cajaventas 2 - caja Chica
        private Decimal Saldo = 0;
        private Decimal Ingresos = 0;
        private Decimal Egresos = 0;
        public DateTime fechaactual = new DateTime().Date;
        int FilasChequeadas = 0;
        private Decimal MontoRendido = 0;
        
        public frmCajaChica()
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
            ListaCajaChica();
        }
        DataTable tabla = new DataTable();
        private void ListaCajaChica()
        {          
            dgvMovimientosCajaChica.Rows.Clear();
            tabla = AdmCaja.ListaCajaChica(frmLogin.iCodSucursal, dtpfecha1.Value.Date, CajaChica.Codcaja, frmLogin.iCodAlmacen);

            foreach (DataRow row in tabla.Rows)
            {
                dgvMovimientosCajaChica.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                    row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString()
                    , row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(), row[15].ToString(), row[16].ToString()
                    , row[17].ToString(), row[18].ToString(), row[19].ToString(), row[20].ToString(), row[21].ToString(), row[22].ToString()
                    , row[23].ToString(), row[24].ToString(), row[25].ToString(), row[26].ToString(), row[27].ToString(), row[28].ToString());
            }           
            CalculoSaldo();
            darformato();
        }

        private void darformato()
        {
            foreach (DataGridViewRow row in dgvMovimientosCajaChica.Rows)
            {
                if (Convert.ToInt32(row.Cells[CODTIPO.Name].Value) == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Cells[monto.Name].Style.ForeColor = Color.Blue;
                    row.Cells[tipopagocaja.Name].Style.ForeColor = Color.Blue;
                }
                else if (Convert.ToInt32(row.Cells[CODTIPO.Name].Value) == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Cells[monto.Name].Style.ForeColor = Color.Red;
                    row.Cells[tipopagocaja.Name].Style.ForeColor = Color.Red;
                }
            }
        }

        private void CalculoSaldo()
        {
            try
            {
                Decimal saldogrilla = 0;
                foreach (DataGridViewRow row in dgvMovimientosCajaChica.Rows)
                {
                    if (Convert.ToInt32(row.Cells[CODTIPO.Name].Value) == 1) // INGRESO
                    {
                        if (Convert.ToInt32(row.Cells[CODTIPOMOV.Name].Value) == 1) // APERTURA
                        {
                            if (Convert.ToInt32(row.Cells[CODMONEDA.Name].Value) == 2)
                            {
                                saldogrilla = saldogrilla + Convert.ToDecimal(row.Cells[monto.Name].Value);
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                row.Cells[monto.Name].Value = String.Format("{0:#,##0.0000}", Convert.ToDecimal(row.Cells[monto.Name].Value) / Convert.ToDecimal(row.Cells[TCVENTA.Name].Value));
                            }
                            else
                            {
                                saldogrilla = saldogrilla + Convert.ToDecimal(row.Cells[monto.Name].Value);
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                            }
                        }
                        if (Convert.ToInt32(row.Cells[CODTIPOMOV.Name].Value) == 2) // MOVIMIENTO
                        {
                            if (Convert.ToInt32(row.Cells[codTipoPagoCaja.Name].Value) == 5)
                            {
                                if (Convert.ToInt32(row.Cells[CODMONEDA.Name].Value) == 2)
                                {
                                    saldogrilla = saldogrilla + Convert.ToDecimal(row.Cells[monto.Name].Value);
                                    row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                    row.Cells[monto.Name].Value = String.Format("{0:#,##0.0000}", Convert.ToDecimal(row.Cells[monto.Name].Value) / Convert.ToDecimal(row.Cells[TCVENTA.Name].Value));
                                }
                                else
                                {
                                    saldogrilla = saldogrilla + Convert.ToDecimal(row.Cells[monto.Name].Value);
                                    row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                }
                            }
                            else
                            {
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                row.DefaultCellStyle.BackColor = Color.Coral;
                            }
                        }
                    }
                    else if (Convert.ToInt32(row.Cells[CODTIPO.Name].Value) == 2) // EGRESO
                    {
                        if (Convert.ToInt32(row.Cells[CODTIPOMOV.Name].Value) == 2) // MOVIMIENTO
                        {
                            if (Convert.ToInt32(row.Cells[CODMONEDA.Name].Value) == 2)
                            {
                                saldogrilla = saldogrilla - Convert.ToDecimal(row.Cells[monto.Name].Value);
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                row.Cells[monto.Name].Value = String.Format("{0:#,##0.0000}", Convert.ToDecimal(row.Cells[monto.Name].Value) / Convert.ToDecimal(row.Cells[TCVENTA.Name].Value));
                            }
                            else
                            {
                                saldogrilla = saldogrilla - Convert.ToDecimal(row.Cells[monto.Name].Value);
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        public Int32 codcajachica = 0;
        private void ListaCajaChicaFechas()
        {
            //dgvMovimientosCajaChica.DataSource = data;
            //data.DataSource = AdmCaja.ListaCajaChicaFechas(frmLogin.iCodSucursal, dtpfecha1.Value.Date, dtpfecha2.Value.Date, tipo);
            //data.Filter = String.Empty;
            //filtro = String.Empty;
            //MontoRendido = 0;
            //dgvMovimientosCajaChica.ClearSelection();
            //darformato();
        }       
    
        private void VerificaSaldoCaja()
        {
            Saldo = 0;

            CajaChica = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, dtpfecha1.Value, tipo, frmLogin.iCodAlmacen, frmLogin.iCodUser);
            if (CajaChica != null)
            {
                codcajachica = CajaChica.Codcaja;
                Saldo = CajaChica.TotalDisponible;
                lblIngresos.Text = String.Format("{0:#,##0.00}", CajaChica.TotalIngreso.ToString());
                lblEgresos.Text = String.Format("{0:#,##0.00}", CajaChica.TotalEgreso.ToString());
                lblAperturaCaja.Text = String.Format("{0:#,##0.00}", CajaChica.Montoapertura.ToString());
                lblSaldoCaja.Text = String.Format("{0:#,##0.00}", CajaChica.TotalDisponible.ToString());
                //lblEgresoSinRecibo.Text = (CajaChica.MontoEntregado - (CajaChica.MontoSustentado + CajaChica.MontoPorSustentar)).ToString();
            }
            else
            {
                Saldo = 0;
                lblIngresos.Text = "0.000";
                lblEgresos.Text = "0.000";
                lblAperturaCaja.Text = "0.000";
                lblSaldoCaja.Text = "0.000";
                //lblSustentado.Text = "0.000";
                //lblPorSustentar.Text = "0.000";
                //*****************************
                biIngreso.Enabled = false;
                biEgreso.Enabled = false;
            }

            if (Saldo > 0)
            {
                biIngreso.Enabled = true;
                biEgreso.Enabled = true;
                biAperturaCajachica.Enabled = false;
            }
            else
            {
                biAperturaCajachica.Enabled = true;
                //**********************************
                biIngreso.Enabled = false;
                biEgreso.Enabled = false;
            }
        }

        private void frmCajaChica_Load(object sender, EventArgs e)
        {
            fechaactual = DateTime.Now.Date;
            cboMovimientos.SelectedIndex = 0;
            VerificaSaldoCaja();
            ListaCajaChica();
        }

        private void biIngreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaChicaRegistro"] != null)
            {
                Application.OpenForms["frmCajaChicaRegistro"].Activate();
            }
            else
            {
                frmCajaChicaRegistro form = new frmCajaChicaRegistro();
                form.tipoCaja = tipo;
                form.Tipo = 1;//ingreso
                form.Proceso = 1;
                form.ShowDialog();
                VerificaSaldoCaja();
                ListaCajaChica();
            }
        }

        private void biHistorialRendiciones_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaChicaRendicionHistorial"] != null)
            {
                Application.OpenForms["frmCajaChicaRendicionHistorial"].Activate();
            }
            else
            {
                frmCajaChicaRendicionHistorial form = new frmCajaChicaRendicionHistorial();
                form.ShowDialog();
                ListaCajaChica();
            }
        }

        private void biEgreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaChicaRegistro"] != null)
            {
                Application.OpenForms["frmCajaChicaRegistro"].Activate();
            }
            else
            {
                frmCajaChicaRegistro form = new frmCajaChicaRegistro();
                form.tipoCaja = tipo;
                form.Tipo = 2;//egreso
                form.Proceso = 1;
                form.SaldoCaja = Convert.ToDecimal(lblSaldoCaja.Text.Trim());
                form.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                form.ShowDialog();
                VerificaSaldoCaja();
                ListaCajaChica();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboMovimientos.SelectedIndex = 0;
            //dtpfecha1.Value = System.DateTime.Now;
            //dtpfecha2.Value = System.DateTime.Now;
            ListaCajaChica();
        }

        private void dtpfecha1_Leave(object sender, EventArgs e)
        {
            dtpfecha2.MinDate = dtpfecha1.Value;
        }

        private void dtpfecha2_Leave(object sender, EventArgs e)
        {
            dtpfecha1.MaxDate = dtpfecha2.Value;
        }

        private void dtpfecha1_ValueChanged(object sender, EventArgs e)
        {
            ListaCajaChicaFechas();
        }

        private void dtpfecha2_ValueChanged(object sender, EventArgs e)
        {
            ListaCajaChicaFechas();
        }

        private void biEditar_Click(object sender, EventArgs e)
        {
            CajaChica = AdmCaja.GetUltimaCajaVentas(frmLogin.iCodSucursal, tipo, frmLogin.iCodAlmacen);
            Decimal ultimontocierre = AdmCaja.traersaldo();
            DialogResult dlgResult = MessageBox.Show(" SI => Saldo Actual: " + lblSaldoCaja.Text + " " + Environment.NewLine +
                "NO => Ultimo Monto Cierre: " + ultimontocierre + " ", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
            {
                if (Application.OpenForms["frmArqueoFondoFijo"] != null)
                {
                    Application.OpenForms["frmArqueoFondoFijo"].Activate();
                }
                else
                {
                    frmArqueoFondoFijo form = new frmArqueoFondoFijo();
                    form.Proceso = 1;
                    form.monto = ultimontocierre;
                    form.ShowDialog();                    
                }
            }
            else
            {
                if (Application.OpenForms["frmArqueoFondoFijo"] != null)
                {
                    Application.OpenForms["frmArqueoFondoFijo"].Activate();
                }
                else
                {
                    frmArqueoFondoFijo form = new frmArqueoFondoFijo();
                    form.Proceso = 1;
                    form.monto = Convert.ToDecimal(lblSaldoCaja.Text);
                    form.ShowDialog();
                }
            }
            //if (dgvMovimientosCajaChica.Rows.Count >0 && dgvMovimientosCajaChica.SelectedRows.Count>0)
            //{
            //    if (Convert.ToInt32(dgvMovimientosCajaChica.SelectedRows[0].Cells[apertura.Name].Value) !=2
            //        ) {
            //        frmCajaChicaRegistro frm = new frmCajaChicaRegistro();
            //        if ((dgvMovimientosCajaChica.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "INGRESO")
            //        { frm.Tipo = 1; }
            //        else if ((dgvMovimientosCajaChica.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "EGRESO")
            //        { frm.Tipo = 2; }
            //        frm.Proceso = 2;
            //        //frm.Caja = Caja;
            //        frm.txtCodigo.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[codigo.Name].Value.ToString();
            //        frm.cboTipoPagoCaja.SelectedValue = Convert.ToInt32(dgvMovimientosCajaChica.SelectedRows[0].Cells[codTipoPagoCaja.Name].Value);
            //        frm.CodtipoCajaChica = Convert.ToInt32(dgvMovimientosCajaChica.SelectedRows[0].Cells[codTipoPagoCaja.Name].Value);
            //        frm.txtDescripcion.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[concepto.Name].Value.ToString();
            //        frm.txtDocumento.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[numDocumento.Name].Value.ToString();
            //        frm.txtMonto.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[monto.Name].Value.ToString();
            //        frm.dtpFecha.Value = Convert.ToDateTime(dgvMovimientosCajaChica.SelectedRows[0].Cells[fecha.Name].Value.ToString());
            //        frm.txtGuiaRemision.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[numGuia.Name].Value.ToString();
            //        frm.txtReciboLiquidacion.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[numRecLiquidacion.Name].Value.ToString();
            //        Int32 TipoTarea = 0;
            //        if (dgvMovimientosCajaChica.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "")
            //        { frm.cboTipo.SelectedIndex = 0; }
            //        else if (dgvMovimientosCajaChica.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "CARGA")
            //        { frm.cboTipo.SelectedIndex = 1; }
            //        else if (dgvMovimientosCajaChica.SelectedRows[0].Cells[cargadescarga.Name].Value.ToString() == "DESCARGA")
            //        { frm.cboTipo.SelectedIndex = 2; }
            //        frm.txtToneladas.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[toneladas.Name].Value.ToString();
            //        frm.lblEgreso.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[monto.Name].Value.ToString();
            //        frm.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
            //        frm.txtRecibo.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[recibo.Name].Value.ToString();
            //        frm.txtMontoPendiente.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[montopendiente.Name].Value.ToString();
            //        frm.txtRecibo.Enabled = false;
            //        frm.monto = Convert.ToDecimal(frm.txtMontoPendiente.Text) + Convert.ToDecimal(frm.txtMonto.Text);
            //        frm.cmbDocumento.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[tipodocumento.Name].Value.ToString();
            //        frm.txtRazonSocial.Text = dgvMovimientosCajaChica.SelectedRows[0].Cells[razonSocial.Name].Value.ToString();
            //        frm.tipoCaja = tipo;
            //        frm.ShowDialog();
            //        ListaCajaChica();
            //        VerificaSaldoCaja();
            //    }
                
            //}
        }

        private void dgvMovimientosCajaChica_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvMovimientosCajaChica.Rows.Count >= 1 && e.Row.Selected)
            {
                //if (e.Row.Cells[apertura.Name].Value.ToString() == "2")
                //{
                //    biEditar.Enabled = false;
                //}
                //else 
                //{ biEditar.Enabled = true; }
                ////*****************************************************
                //if (e.Row.Cells[apertura.Name].Value.ToString() == "2")
                //{

                //}
            }

        }

       

        private void biEliminar_Click(object sender, EventArgs e)
        {
            Decimal montocierre = Convert.ToDecimal( lblSaldoCaja.Text);
            tipo = 1;

            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Cerrar Caja" + Environment.NewLine +
                "Monto Cierre: " + lblSaldoCaja.Text + " ", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                if (AdmCaja.CerrarCajaVentas(frmLogin.iCodSucursal, dtpfecha1.Value.Date, CajaChica.Codcaja, frmLogin.iCodAlmacen))
                {
                    MessageBox.Show("El cierre de caja se ha realizado correctamente", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
                    clsReporteCaja dso = new clsReporteCaja();
                    CRCierreCajaChica rpt = new CRCierreCajaChica();
                    frmRptCaja frm = new frmRptCaja();
                    //rptoption = rpt.PrintOptions;
                    //rptoption.PrinterName = ser.NombreImpresora;
                    //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                    rpt.SetDataSource(dso.ReporteMovimientosCajaChica(frmLogin.iCodSucursal, dtpfecha1.Value.Date, CajaChica.Codcaja, frmLogin.iCodAlmacen).Tables[0]);
                    frm.crvKardex.ReportSource = rpt;
                    frm.Show();
                    this.Close();
                }
            }
            else
            {
                //if (AdmCaja.CerrarCajaChica(frmLogin.iCodSucursal, tipo, montocierre, codcajachica))
                //{
                //    MessageBox.Show("La Caja se Cerro Correctamente", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    biAperturaCajachica.Enabled = true;
                //}
            }
            
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
            if (Application.OpenForms["frmCajaChicaRendicion"] != null)
            {
                Application.OpenForms["frmCajaChicaRendicion"].Activate();
            }
            else
            {
                frmCajaChicaRendicion form = new frmCajaChicaRendicion();
                form.tipocaja = tipo;
                form.MdiParent = this.MdiParent;
                form.Show();
            }
        }

        private void biRencicionCaja_Click(object sender, EventArgs e)
        {
            //Decimal ultimontocierre = AdmCaja.traersaldo();
            //DialogResult dlgResult = MessageBox.Show(" SI => Saldo Actual: " + lblSaldoCaja.Text + " " + Environment.NewLine +
            //    "NO => Ultimo Monto Cierre: " + ultimontocierre + " ", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dlgResult == DialogResult.No)
            //{
            //    return;
            //}
            //else
            //{
                
            //}
        }

        private void biVerificarRendicion_Click(object sender, EventArgs e)
        {
            frmCajaChicaRendicionListado frm = new frmCajaChicaRendicionListado();
            frm.tipocaja = tipo;
            frm.ShowDialog();
            VerificaSaldoCaja();
            ListaCajaChica();
        }

        private void dgvMovimientosCajaChica_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMovimientosCajaChica.IsCurrentCellDirty)
            {
                dgvMovimientosCajaChica.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

     
       

        private void biBuscar_Click(object sender, EventArgs e)
        {
            lblColumna.Text = "CODIGO";
            lblProperty.Text = "codPersonalizado"; 
            
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
            if (dgvMovimientosCajaChica.Columns[e.ColumnIndex].Index > 0)
            {
                lblColumna.Text = dgvMovimientosCajaChica.Columns[e.ColumnIndex].HeaderText;
                lblProperty.Text = dgvMovimientosCajaChica.Columns[e.ColumnIndex].DataPropertyName;

                if (expandablePanel1.Expanded)
                {
                    txtFiltro.Focus();
                }
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
                    form.tipoCaja = tipo;
                    form.Tipo = 1;
                    form.Proceso = 1;
                    form.AperturaCaja = 1;
                    form.ShowDialog();
                    ListaCajaChica();
                    VerificaSaldoCaja();
                }
            }
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
                frm.tipocaja = tipo;
                frm.ShowDialog();
                VerificaSaldoCaja();
                ListaCajaChica();
            }
        }

        private void biRecibo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecibos_CajaChica"] != null)
            {
                Application.OpenForms["frmRecibos_CajaChica"].Activate();
            }
            else
            {
                frmRecibos_CajaChica form = new frmRecibos_CajaChica();
                form.tipocaja = tipo;
                form.Proceso = 1;
                form.CodCaja = CajaChica.Codcaja;
                form.SaldoCaja = Convert.ToDecimal(lblSaldoCaja.Text.Trim());
                form.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                form.ShowDialog();
                VerificaSaldoCaja();
                ListaCajaChica();
            }
        }

        private void biHistorialRecibos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecibos_CajaChica"] != null)
            {
                Application.OpenForms["frmRecibos_CajaChica"].Activate();
            }
            else
            {
                frmRecibos form = new frmRecibos();
                form.tipocaja = tipo;
                //form.MdiParent = this;
                form.ShowDialog();
            }
        }

        private void dgvMovimientosCajaChica_Sorted(object sender, EventArgs e)
        {
            darformato();
        }

        private void dgvMovimientosCajaChica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            darformato();
        }

        private void biImprimir_Click(object sender, EventArgs e)
        {
            clsReporteCaja dso = new clsReporteCaja();
            CRReporteMovimientosCajaChica rpt = new CRReporteMovimientosCajaChica();
            frmReporteMovimientosCajaChica frm = new frmReporteMovimientosCajaChica();
            rpt.SetDataSource(dso.ReporteMovimientosCajaChica(frmLogin.iCodSucursal, dtpfecha1.Value, CajaChica.Codcaja, frmLogin.iCodAlmacen));
            frm.crvMovimientosdecajachica.ReportSource = rpt;
            frm.Show();
        }

    }
}
