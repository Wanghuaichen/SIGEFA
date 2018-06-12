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
using MySql.Data.MySqlClient;
using SIGEFA.Conexion;

namespace SIGEFA.Formularios
{
    public partial class frmCajaVentasMovimientos : DevComponents.DotNetBar.Office2007Form
    {
        clsConsultasExternas ext = new clsConsultasExternas();
        clsSerie ser = new clsSerie();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public List<Int32> seleccion = new List<Int32>();
        clsAdmSeparacion AdmSepa = new clsAdmSeparacion();
        //public List<clsCajaChica> seleccion2 = new List<clsCajaChica>();

        clsCaja Caja = new clsCaja();
        clsAdmAperturaCierre AdmCaja = new clsAdmAperturaCierre();
        
        
        private Decimal Saldo = 0;
        private Decimal Ingresos = 0;
        private Decimal Egresos = 0;
        private Decimal totalVenta = 0;
        private Decimal totalDisponible = 0;
        private Decimal totalIngresos = 0;

        int FilasChequeadas = 0;
        private Decimal MontoRendido = 0;

        
        public frmCajaVentasMovimientos()
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
            VerificaSaldoCajaVentas();
            ListaCajaChicaDiaria();
        }
        DataTable tabla = new DataTable();
        private void ListaCajaChicaDiaria()
        {
            dgvMovimientosCajaChica.Rows.Clear();
            tabla = AdmCaja.ListaCajaDiaria(frmLogin.iCodSucursal, dtpfecha1.Value.Date, Caja.Codcaja, frmLogin.iCodAlmacen);
           
            foreach (DataRow row in tabla.Rows)
            {
                dgvMovimientosCajaChica.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),
                    row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString()
                    , row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(), row[15].ToString(), row[16].ToString()
                    , row[17].ToString(), row[18].ToString(), row[19].ToString(), row[20].ToString(), row[21].ToString(), row[22].ToString()
                    , row[23].ToString(), row[24].ToString(), row[25].ToString(), row[26].ToString());
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

        private void VerificaSaldoCajaVentas()
        {
            Saldo = 0;

            Caja = AdmCaja.ValidarAperturaDia(frmLogin.iCodSucursal, dtpfecha1.Value.Date, 1, frmLogin.iCodAlmacen, frmLogin.iCodUser);// 1 caja ventas
            if (Caja != null)
            {
                totalVenta = AdmCaja.SumaVentaEfectivoCaja(frmLogin.iCodSucursal, dtpfecha1.Value.Date, Caja.Codcaja);
                //MessageBox.Show(totalVenta + "");
                Saldo = Caja.Montoapertura;
                totalDisponible = (Caja.TotalDisponible); /*- Caja.Montoentregado;*/
                totalIngresos = Caja.TotalIngreso;
                lblIngresos.Text = String.Format("{0:#,##0.00}", totalIngresos.ToString());
                lblEgresos.Text = String.Format("{0:#,##0.00}", Caja.TotalEgreso.ToString());
                lblAperturaCaja.Text = String.Format("{0:#,##0.00}", Caja.Montoapertura.ToString());                
                lblSaldoCaja.Text = String.Format("{0:#,##0.00}", totalDisponible);
                lbDeposito.Text = String.Format("{0:#,##0.00}", Caja.Totaldeposito);
                lbCheque.Text = String.Format("{0:#,##0.00}", Caja.Totalcheque);
            }
            else
            {
                Saldo = 0;
                lblIngresos.Text = "0.000";
                lblEgresos.Text = "0.000";
                lblAperturaCaja.Text = "0.000";
                lblSaldoCaja.Text = "0.000";
                //*****************************
                biIngreso.Enabled = false;
                biEgreso.Enabled = false;
            }

            if (Caja.TotalDisponible > 0)
            {
                biIngreso.Enabled = true;
                biEgreso.Enabled = true;
                //biAperturaCajachica.Enabled = false;
            }
            else
            {
                //biAperturaCajachica.Enabled = true;
                //**********************************
                biIngreso.Enabled = false;
                biEgreso.Enabled = false;
            }
        }
                
        private void biIngreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaDiariaRegistro"] != null)
            {
                Application.OpenForms["frmCajaDiariaRegistro"].Activate();
            }
            else
            {
                frmCajaDiariaRegistro form = new frmCajaDiariaRegistro();
                form.Tipo = true;
                form.codigocaja = Caja.Codcaja;
                form.Proceso = 1;
                form.direccioncaja = 1;
                form.SaldoCaja = Convert.ToDecimal(lblSaldoCaja.Text.Trim());
                form.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                form.ShowDialog();
                VerificaSaldoCajaVentas();
                ListaCajaChicaDiaria();
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
                ListaCajaChicaDiaria();
            }
        }

        private void biEgreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCajaDiariaRegistro"] != null)
            {
                Application.OpenForms["frmCajaDiariaRegistro"].Activate();
            }
            else
            {
                frmCajaDiariaRegistro form = new frmCajaDiariaRegistro();
                form.Tipo = false;
                form.codigocaja = Caja.Codcaja;
                form.Proceso = 1;
                form.direccioncaja = 1;
                form.SaldoCaja = Convert.ToDecimal(lblSaldoCaja.Text.Trim());
                form.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                form.ShowDialog();
                VerificaSaldoCajaVentas();
                ListaCajaChicaDiaria();
            }            
        }       

        private void dgvMovimientosCajaChica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmCajaChicaRegistro frm = new frmCajaChicaRegistro();
                if ((dgvMovimientosCajaChica.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "INGRESO")
                { frm.Tipo = 1; }
                else if ((dgvMovimientosCajaChica.SelectedRows[0].Cells[tipoMovimiento.Name].Value.ToString()) == "EGRESO")
                { frm.Tipo = 2; }
                frm.Proceso = 3;
                //frm.Caja = Caja;
                frm.ShowDialog();
            }
        }

        private void biEliminar_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientosCajaChica.Rows.Count > 0)
            //{
            //    Caja.CodCajaChica = Convert.ToInt32(dgvMovimientosCajaChica.SelectedRows[0].Cells[codigo.Name].Value.ToString());
            //    if (Caja.CodCajaChica != 0)
            //    {
            //        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dlgResult == DialogResult.No)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            if (AdmCaja.deleteMovimientoDiario(Caja.CodCajaChica))
            //            {
            //                MessageBox.Show("El dato ha sido eliminado correctamente", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                VerificaSaldoCajaDiaria();
            //                ListaCajaChicaDiaria();
            //            }
            //        }
            //    }
            //}
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
                                saldogrilla = (saldogrilla + (Convert.ToDecimal(row.Cells[monto.Name].Value)));
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
                                    saldogrilla = (saldogrilla + (Convert.ToDecimal(row.Cells[monto.Name].Value) ));
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
                                row.DefaultCellStyle.BackColor = Color.PeachPuff;
                            }
                        }
                    }
                    else if (Convert.ToInt32(row.Cells[CODTIPO.Name].Value) == 2) // EGRESO
                    {
                        if (Convert.ToInt32(row.Cells[CODTIPOMOV.Name].Value) == 2) // MOVIMIENTO
                        {
                            if (Convert.ToInt32(row.Cells[codTipoPagoCaja.Name].Value) == 9)
                            {
                                row.Cells[saldocaja.Name].Value = String.Format("{0:#,##0.0000}", saldogrilla);
                                row.DefaultCellStyle.BackColor = Color.PeachPuff;   
                            }
                            else
                            {                                

                                if (Convert.ToInt32(row.Cells[CODMONEDA.Name].Value) == 2)
                                {
                                    saldogrilla = (saldogrilla - (Convert.ToDecimal(row.Cells[monto.Name].Value)));
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
            if (Application.OpenForms["frmCajaChicaRendicion"] != null)
            {
                Application.OpenForms["frmCajaChicaRendicion"].Activate();
            }
            else
            {
                frmCajaChicaRendicion form = new frmCajaChicaRendicion();
                form.MdiParent = this.MdiParent;
                form.Show();
            }
        }

        private void biRencicionCaja_Click(object sender, EventArgs e)
        {
            //if (dgvMovimientosCajaChica.RowCount > 0)
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
            //                    foreach (clsCajaChica clsCaja in seleccion2)
            //                    {
            //                        clsCaja.CodRendicion = Caja.CodRendicion;
            //                        AdmCaja.InsertDetalleRendicion(clsCaja);
            //                    }
            //                    seleccion2.Clear();
            //                }
            //            }
            //            MessageBox.Show("Rendicion Generada! Puede Consultarla en 'Verificar rendiciones!'", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            cboMovimientos.SelectedIndex = 0;
            //            //ListaCajaChicaDiaria(); 
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Seleccione Gastos Para Proseguir con la Rendicion de Caja Chica", "Gestion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }
       
        private void dgvMovimientosCajaChica_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMovimientosCajaChica.IsCurrentCellDirty)
            {
                dgvMovimientosCajaChica.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvMovimientosCajaChica_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    if (dgvMovimientosCajaChica.Columns[e.ColumnIndex].Name == Item.Name)
            //    {
            //        DataGridViewRow row = dgvMovimientosCajaChica.Rows[e.RowIndex];

            //        DataGridViewCheckBoxCell cellSelecion = row.Cells[Item.Name] as DataGridViewCheckBoxCell;

            //        clsCajaChica CajaChica = new clsCajaChica();
            //        if (Convert.ToBoolean(cellSelecion.Value))
            //        {
            //            FilasChequeadas = FilasChequeadas + 1;
            //            MontoRendido = MontoRendido + (Convert.ToDecimal(row.Cells[monto.Name].Value));
            //            seleccion.Add(Convert.ToInt32(row.Cells[codigo.Name].Value));
            //            //*****************************************************************************
            //            //CajaChica.CodRendicion = Caja.CodRendicion;
            //            CajaChica.CodCajaChica = Convert.ToInt32(row.Cells[codigo.Name].Value);
            //            CajaChica.Monto = Convert.ToInt32(row.Cells[monto.Name].Value);
            //            CajaChica.CodUser = frmLogin.iCodUser;
            //            CajaChica.CodSucursal = frmLogin.iCodSucursal;
            //            //*****************************************************************************                                                
            //            seleccion2.Add(CajaChica);
            //        }
            //        else
            //        {
            //            FilasChequeadas = FilasChequeadas - 1;
            //            MontoRendido = MontoRendido - (Convert.ToDecimal(row.Cells[monto.Name].Value));
            //            seleccion.Remove(Convert.ToInt32(row.Cells[codigo.Name].Value));
            //            //seleccion2.RemoveAll(CajaChica => CajaChica.CodCajaChica == Convert.ToInt32(row.Cells[codigo.Name].Value));
            //        }

            //        if (FilasChequeadas > 0)
            //        { biRencicionCaja.Enabled = true; }
            //        else
            //        { biRencicionCaja.Enabled = false; }
            //    }
            //}
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
                    form.Tipo = 1;
                    form.Proceso = 1;
                    form.AperturaCaja = 1;
                    form.ShowDialog();
                    ListaCajaChicaDiaria();
                    VerificaSaldoCajaVentas();
                }
            }
        }

        private void cboMovimientos_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    MontoRendido = 0;
            //    biRencicionCaja.Enabled = false;
            //    seleccion.Clear();
            //    seleccion2.Clear();
            //    //************************************
            //    if (cboMovimientos.SelectedIndex == 0)
            //    {
            //        Item.Visible = false;
            //        ListaCajaChicaDiaria();
            //    }
            //    else
            //    {
            //        if (cboMovimientos.SelectedIndex == 2)
            //        {
            //            Item.Visible = true;
            //        }
            //        else
            //        {
            //            Item.Visible = false;
            //        }
            //        //************************************
            //        if (cboMovimientos.Items.Count > 0)
            //        {
            //            data.Filter = String.Format("[{0}] like '*{1}*'", "TipoMovimiento", cboMovimientos.Text);
            //        }
            //        else
            //        {
            //            data.Filter = String.Empty;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}
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
                VerificaSaldoCajaVentas();
                ListaCajaChicaDiaria();
            }
        }       

        private void frmCajaVentasMovimientos_Load(object sender, EventArgs e)
        {
            cboMovimientos.SelectedIndex = 0;
            VerificaSaldoCajaVentas();
            ListaCajaChicaDiaria();
            VerificaCajaSeparacion();
        }

        private void VerificaCajaSeparacion()
        {
            Double saldoseparacion = AdmSepa.CargarTotalSeparacion(frmLogin.iCodAlmacen);
            lblCajaSeparacion.Text = String.Format("{0:#,##0.00}", saldoseparacion);
        }

        private void frmCajaVentasMovimientos_Shown(object sender, EventArgs e)
        {
            if (Caja.TotalDisponible != 0)
            {               
                biIngreso.Enabled = true;
                biEgreso.Enabled = true;
            }
            else
            {
                lblAperturaCaja.Text = "0.000";
                biIngreso.Enabled = false;
                biEgreso.Enabled = false;                
            }
        }

        private void btnCierreyArqueoCajaVentas_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea cerra caja", "Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
            {
                return;
            }
            else
            {
               // Caja.Codcaja = 32;

                if (AdmCaja.CerrarCajaVentas(frmLogin.iCodSucursal, dtpfecha1.Value.Date, Caja.Codcaja, frmLogin.iCodAlmacen))
                {
                    MessageBox.Show("El cierre de caja se ha realizado correctamente", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
                    clsReporteCaja dso = new clsReporteCaja();
                    CRCierre rpt = new CRCierre();
                    frmRptCaja frm = new frmRptCaja();
                    //rptoption = rpt.PrintOptions;
                    //rptoption.PrinterName = ser.NombreImpresora;
                    //rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                    rpt.SetDataSource(dso.RptMuestraCierreCaja(frmLogin.iCodSucursal, dtpfecha1.Value.Date, Caja.Codcaja, frmLogin.iCodAlmacen).Tables[0]);
                    frm.crvKardex.ReportSource = rpt;
                    frm.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("No se puede cerrar caja ", "Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDetalleCajaVentas_Click(object sender, EventArgs e)
        {
            try
            {
                clsReporteCaja ds = new clsReporteCaja();
                CRDetalleCaja rpt = new CRDetalleCaja();
                frmRptCaja frm = new frmRptCaja();
                rpt.SetDataSource(ds.ReporteMovimientosCajaVentas(frmLogin.iCodSucursal, dtpfecha1.Value, Caja.Codcaja, frmLogin.iCodAlmacen));
                frm.crvKardex.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
