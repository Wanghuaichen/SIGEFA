using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar.Validator;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmMovimientosControl : DevComponents.DotNetBar.Office2007Form
    {
        Thread p1;

        clsAdmBanco admban = new clsAdmBanco();
        clsAdmCtaCte admcta = new clsAdmCtaCte();
        clsCtaCte cta = new clsCtaCte();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        DataTable dt = new DataTable();
        clsFlujoCaja flujo = new clsFlujoCaja();
        clsAdmFlujoCaja AdmFlu = new clsAdmFlujoCaja();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsValidar ok = new clsValidar();

        public static BindingSource data = new BindingSource();

        public Int32 Proceso = 0; // (1)Registrar (2)Actualizar
        public Int32 CodMovimiento = 0;
        public String tipo;
        public Int32 Procede = 0; //(1)Movimientos (2)ListaCaja
        public Int32 TipoProcedencia = 0;
        public Decimal totalv = 0;
        public Decimal Soles;
        public frmMovimientosControl()
        {
            InitializeComponent();
        }

        private void carga(Int32 tipo)
        {
            cmbtipopagoser.DataSource = AdmFlu.ListaPagoCobro(tipo);
            cmbtipopagoser.DisplayMember = "descripcion";
            cmbtipopagoser.ValueMember = "codTipoPagoCaja";
            cmbtipopagoser.SelectedIndex = -1;
        }

        private void CargaBancos()
        {
            cmbBanco.DataSource = admban.MuestraBancos();
            cmbBanco.DisplayMember = "descripcion";
            cmbBanco.ValueMember = "codBanco";
            cmbBanco.SelectedIndex = -1;
        }
        
        public void CargaCtaCte()
        {
            cmbCuenta.DataSource = admcta.ListaCtasBanco(Convert.ToInt32(cmbBanco.SelectedValue), frmLogin.iCodAlmacen);
            cmbCuenta.DisplayMember = "cuentaCorriente";
            cmbCuenta.ValueMember = "codCuentaCorriente";
        }
        
        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = -1;
        }

        private void Cargartiposcuenta()
        {
            cta = admcta.CargaTipoCuenta(Convert.ToInt32(cmbCuenta.SelectedValue.ToString()), frmLogin.iCodAlmacen);

            if (cta != null)
            {
                txtTipoCta.Text = cta.TipoCuenta;
               
                if (cta.Moneda>0)
                {
                    cmbMoneda.SelectedValue = cta.Moneda;
                }
                else
                {
                    cmbMoneda.SelectedIndex = -1;
                    txtTipoCta.Text = "";
                }
                if (Proceso == 2)txtDescripcion.Text = cta.descripcion;
                if (cta.saldo != 0)
                {
                    txtTotalCuenta.Text = cta.saldo.ToString();
                }
                else
                {
                    txtTotalCuenta.Text = (0).ToString();
                }
            }
        }

        private void CargaTipoCambio()
        {
            tc = AdmTc.CargaTipoCambio(DateTime.Today, 2);
            if (tc != null)
            {
                txtCambioCom.Text = Convert.ToString(tc.Compra);
                txtCambioVen.Text = Convert.ToString(tc.Venta);
            }
        }
        
        public void frmMovimientosControl_Load(object sender, EventArgs e)
        {
            CargaMoneda();
            CargaBancos();
            CargaTipoCambio();
            cmbBanco.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            dtpFechaCierre.MaxDate = System.DateTime.Now;
            //dtpFechaCierre.MinDate = System.DateTime.Now;
            Control.CheckForIllegalCrossThreadCalls = false;
            
            if (Proceso == 1)
            {
                HabilitaControles(true);
            }
            else if (Proceso == 2)
            {
                HabilitaControles(true);
                Carga_Datos();
            
            }
            else if (Proceso == 3)
            {
                HabilitaControles(false);
                Carga_Datos();
                btnReporte2.Visible = true;
            }

            if (Procede == 2)
            {
                cmbTipo.SelectedIndex = 0;
                cmbTipo.Enabled = false;
                TipoProcedencia = 1;
                btnGuardar2.Enabled = false;
                cmbMoneda.Enabled = false;
            }
            
               
        }

        private void Carga_Datos() //verifica
        {
           // MessageBox.Show(CodMovimiento.ToString() +" "+frmLogin.iCodAlmacen.ToString());
            cta = admcta.BuscaMovimiento(CodMovimiento, frmLogin.iCodAlmacen);
            if (cta != null)
            {
                cmbBanco.SelectedValue = cta.CodBanco;
                CargaCtaCte();
                cmbCuenta.SelectedValue = cta.CodCtaCte;
                txtTipoCta.Text = cta.TipoCuenta;
                cmbMoneda.SelectedValue = cta.Moneda;
                
                txtDescripcion.Text = cta.descripcion;
                if (tipo == "INGRESO") cta.Tipo = 1;
                else cta.Tipo = 0;
                if (cta.Tipo == 1)
                {
                    cmbTipo.Text = "INGRESO";
                    cmbTipo.SelectedIndex = 0;
                    cmbTipo_SelectionChangeCommitted(new object(), new EventArgs());
                    txtmonto.Text = cta.ingreso.ToString();
                }
                else
                {
                    cmbTipo.Text = "EGRESO";
                    cmbTipo.SelectedIndex = 1;
                    cmbTipo_SelectionChangeCommitted(new object(), new EventArgs());
                    txtmonto.Text = cta.egreso.ToString();
                }

                cmbtipopagoser.SelectedValue = cta.CodTipoPagoServicio;
                txtCambioCom.Text = cta.tipocambio.ToString();
                txtCambioVen.Text = cta.TipoCVenta.ToString();
                txtCodTransaccion.Text = cta.NumTransaccion;
                txtTotalCuenta.Text = cta.saldo.ToString();
                txtNombre.Text = cta.Nombre;
                txtDireccion.Text = cta.Direccion;
                txtDni.Text = cta.Dni;
                txtdoc.Text = cta.Correlativo.ToString().PadLeft(9, '0');

            }
        }
        
        private void Cuentas()
        {
            CargaCtaCte();
            cmbCuenta.Enabled = true;
            if (cmbCuenta.Items.Count > 0 && cmbCuenta.Text != "")
            {
                Cargartiposcuenta();
                

            }
            else
            {
                txtTipoCta.Text = "";
                cmbMoneda.SelectedIndex = -1;
                cmbCuenta.Enabled = false;
            }
        }
        
        public void cmbBanco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cuentas();
            btnGuardar2.Enabled = true;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cargartiposcuenta();
            
        }

        private void Limpiar()
        {
            cmbBanco.SelectedIndex = -1;
            cmbCuenta.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbMoneda.SelectedIndex = -1;
            txtmonto.Text = "";
            txtDescripcion.Text = "";
            txtTipoCta.Text = "";
            txtTotalCuenta.Text = "";
            txtCodTransaccion.Text = "";
        }

        private void HabilitaControles(Boolean Estado)
        {
            txtDescripcion.Enabled = Estado;
            txtmonto.Enabled = Estado;
            dtpFecha.Enabled = Estado;
            cmbTipo.Enabled = Estado;
            btnGuardar2.Enabled = Estado;
            cmbtipopagoser.Enabled = Estado;
            cmbBanco.Enabled = Estado;
            cmbMoneda.Enabled = Estado;
            cmbCuenta.Enabled = Estado;
            txtCodTransaccion.Enabled = Estado;
            txtTotalCuenta.Enabled = Estado;
            txtNombre.Enabled = Estado;
            txtDireccion.Enabled = Estado;
            txtDni.Enabled = Estado;
            txtdoc.Enabled = Estado;
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
              /*  if (superValidator1.Validate())
                {*/
                    if (txtCodTransaccion.Text != "")
                    {
                       //Validación para Ingresos y Egresos..                        
                        if (Convert.ToDecimal(txtmonto.Text) <= Convert.ToDecimal(txtTotalCuenta.Text) &&
                            cmbTipo.Text == "EGRESO" ||
                            Convert.ToDecimal(txtmonto.Text) >= Convert.ToDecimal(txtTotalCuenta.Text) &&
                            cmbTipo.Text == "INGRESO" || Convert.ToDecimal(txtmonto.Text) <= Convert.ToDecimal(txtTotalCuenta.Text) &&
                            cmbTipo.Text == "INGRESO")
                        {
                        
                        
                            cta.CodBanco = Convert.ToInt32(cmbBanco.SelectedValue);
                            cta.CodCtaCte = Convert.ToInt32(cmbCuenta.SelectedValue);
                            cta.NumTransaccion = txtCodTransaccion.Text.Trim();
                            cta.descripcion = txtDescripcion.Text.Trim();
                            cta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                            cta.TipoCuenta = txtTipoCta.Text.Trim();
                           
                            if (cmbTipo.Text == "INGRESO")
                            {
                                cta.Tipo = 1;
                            }
                            else
                            {
                                cta.Tipo = 0;
                            }
                            cta.tipocambio = Convert.ToDecimal(txtCambioCom.Text.Trim());
                            cta.TipoCVenta = Convert.ToDecimal(txtCambioVen.Text.Trim());
                            cta.Dmonto = Convert.ToDecimal(txtmonto.Text);
                            cta.Coduser = frmLogin.iCodUser;
                            
                            cta.CodTipoPagoServicio = Convert.ToInt32(cmbtipopagoser.SelectedValue);
                            
                            cta.FechaMovimiento = dtpFecha.Value;
                            cta.CodAlmacen = frmLogin.iCodAlmacen;
                            cta.CodSucursal = frmLogin.iCodSucursal;
                            cta.TipoProcedencia = TipoProcedencia;
                            cta.FechaCierreCaja = dtpFechaCierre.Value;
                            cta.Nombre = txtNombre.Text;
                            cta.Direccion = txtDireccion.Text;
                            cta.Dni = txtDni.Text;
                            cta.Correlativo = Convert.ToInt32(txtdoc.Text);
                            if (cmbTipo.SelectedIndex == 0) 
                            {
                                cta.Igresoegreso = 1;
                            }
                            else if (cmbTipo.SelectedIndex == 1)
                            {
                                cta.Igresoegreso = 0;
                            }

                            if (Proceso == 1)
                            {
                                if (admcta.InsertMovi(cta))
                                {
                                    MessageBox.Show("Los datos se Guardaron Correctamente",
                                        "CONTROL DE MOVIMIENTOS DE BANCO",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    CodMovimiento = cta.CodCtaCteNuevo;
                                   
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrio un Error al Guardar los Datos",
                                        "CONTROL DE MOVIMIENTOS DE BANCO",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else if (Proceso == 2) //falta revisar esta parte :P
                            {
                                cta.CodMovi = CodMovimiento;
                                if (admcta.UpdateMovi(cta))
                                {
                                    MessageBox.Show("Los datos se Actualizaron Correctamente",
                                        "CONTROL DE MOVIMIENTOS DE BANCO",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrio un Error al Actualizar los Datos",
                                        "CONTROL DE MOVIMIENTOS DE BANCO",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("EL MONTO INGRESADO EXCEDE DEL TOTAL DE LA CUENTA",
                                        "CONTROL DE MOVIMIENTOS DE BANCO",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                      
                        Proceso = 0;
                        Carga_Datos();
                        HabilitaControles(false);
                        btnReporte2.Visible = true;
                        

                    }
                    else
                    {
                        MessageBox.Show("INGRESE CÓDIGO DE TRANSACCIÓN", "MENSAJE", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        txtCodTransaccion.Focus();
                    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //cta.TipoCuenta = txttipocambios.text;
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            //// deshabilitar();
            //deshabilitar();
            //CargaBancos();

            //txtDescripcion.Enabled = true;
            //txtmonto.Enabled = true;
            //if (cmbCuenta.Items.Count > 0 && cmbCuenta.Text != "")
            //{
            //    cargartiposcuenta();
            //}
            //btnGuardar2.Text = "Modificar";
            //cmbBanco.Text = Convert.ToString(dgvDetalle.SelectedRows[0].Cells[banco.Name].Value);
            //cmbCuenta.Text = Convert.ToString(dgvDetalle.SelectedRows[0].Cells[cuentacorriente.Name].Value);
            //txtmonto.Text = Convert.ToString(dgvDetalle.SelectedRows[0].Cells[saldo.Name].Value);

            //if (dgvDetalle.CurrentRow.Cells["Transaccion"].Value.ToString() == "INGRESO")
            //{
            //    cmbTipo.SelectedIndex = 0;
            //}
            //else if (dgvDetalle.CurrentRow.Cells["Transaccion"].Value.ToString() == "EGRESO")
            //{
            //    cmbTipo.SelectedIndex = 1;
            //}
            //else
            //{
            //    cmbTipo.SelectedIndex = -1;
            //}
            //txtDescripcion.Text = Convert.ToString(dgvDetalle.SelectedRows[0].Cells[descripcion.Name].Value);
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargaBancos();
            //habilitar();
            //CargaLista();
            cmbCuenta.Enabled = false;
            //DarFormato();
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //deshabilitar();
            txtDescripcion.Enabled = true;
            txtmonto.Text = "";
            btnEliminar2.Enabled = true;
            btnEditar2.Enabled = true;
            btnGuardar2.Enabled = false;
            //DarFormato();
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            //if (dgvDetalle.SelectedRows.Count > 0)
            //{
            //    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar el Movimiento", "Autorizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dlgResult == DialogResult.No)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        if (admcta.DeleteMov(Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells[codMovimientos.Name].Value), frmLogin.iCodAlmacen))
            //        {
            //            MessageBox.Show("Eliminación Exitosa !! ", " Mensaje !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            CargaLista();
            //            deshabilitar();
            //            limpiar();
            //            btnEliminar2.Enabled = false;
            //            DarFormato();
            //        }
            //    }

            //}
            //else
            //{

            //}
        }

        private void txtCodTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTipo.Text == "INGRESO")
            {
                cmbtipopagoser.Enabled = true;
                carga(1);
                
            }
            else if (cmbTipo.Text == "EGRESO")
            {
                cmbtipopagoser.Enabled = true;
                carga(0);
            }
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 tip = Convert.ToInt32(cmbtipopagoser.SelectedValue);
                

                if (tip == 1)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeEgresos rpt = new CRRecibodeEgresos();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                    
                }
                else if (tip == 2)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosMovilidadAgazajosFestividades rpt = new CRReciboEgresosMovilidadAgazajosFestividades();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 3)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosMovilidsd rpt = new CRReciboEgresosMovilidsd();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();                    
                }
                else if (tip == 4)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresosPorTerceros rpt = new CRReciboEgresosPorTerceros();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 5)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRReciboEgresoDietasyEstimulos rpt = new CRReciboEgresoDietasyEstimulos();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento));
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show(); 
                }
                else if (tip == 6)
                {
                    //clsReporteCaja dso = new clsReporteCaja();
                    //CRRecibodeIngresosSecretariadeBienestar rpt = new CRRecibodeIngresosSecretariadeBienestar();
                    //frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    //rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, cod).Tables[0]);
                    //frm.crvReciboCajaChica.ReportSource = rpt;
                    //frm.Show();
                }
                else if (tip == 7)
                {
                    //clsReporteCaja dso = new clsReporteCaja();
                    //CRRecibodeIngresos rpt = new CRRecibodeIngresos();
                    //frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    //rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, cod).Tables[0]);
                    //frm.crvReciboCajaChica.ReportSource = rpt;
                    //frm.Show();
                }
                else if (tip == 8)
                {
                    //clsReporteCaja dso = new clsReporteCaja();
                    //CRRecibodeIngresosChequeUgel rpt = new CRRecibodeIngresosChequeUgel();
                    //frmReporteChequeUgelRPT frm = new frmReporteChequeUgelRPT();
                    //rpt.SetDataSource(dso.ReciboChequeUgel(tip, cod).Tables[0]);
                    //frm.crvChequeUgelRPT.ReportSource = rpt;
                    //frm.Show();
                }
                else if (tip == 9)
                {
                    //clsReporteCaja dso = new clsReporteCaja();
                    //CRReciboIngresoMortuorio rpt = new CRReciboIngresoMortuorio();
                    //frmPendientesMortuorioRP frm = new frmPendientesMortuorioRP();
                    //rpt.SetDataSource(dso.PendientesFondoMortuorio(tip, cod).Tables[0]);
                    //frm.crvPendientesMortuorioRPT.ReportSource = rpt;
                    //frm.Show();
                }
                else if (tip == 10)
                {
                    //clsReporteCaja dso = new clsReporteCaja();
                    //CRReciboEgresoMortuorio rpt = new CRReciboEgresoMortuorio();
                    //frmRecibodeEgresosMortuorioRP frm = new frmRecibodeEgresosMortuorioRP();
                    //rpt.SetDataSource(dso.PendientesFondoMortuorio(tip, cod).Tables[0]);
                    //frm.crvEgresosMortuorio.ReportSource = rpt;
                    //frm.Show();
                }
                else if (tip == 11)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeIngresos rpt = new CRRecibodeIngresos();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento).Tables[0]);
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }
                else if (tip == 12)
                {
                    clsReporteCaja dso = new clsReporteCaja();
                    CRRecibodeIngresos rpt = new CRRecibodeIngresos();
                    frmReporteReciboCajaChicaRPT frm = new frmReporteReciboCajaChicaRPT();
                    rpt.SetDataSource(dso.ReciboDietasyEstimulo(tip, CodMovimiento).Tables[0]);
                    frm.crvReciboCajaChica.ReportSource = rpt;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento el siguiente error" + ex.ToString(), "Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbMoneda.Items.Count > 0)
                {
                    if (Convert.ToInt32(cmbMoneda.SelectedValue) == 1)
                    {
                        txtmonto.Text = Convert.ToString(Soles);
                    }
                    else
                    {
                        txtmonto.Text = Convert.ToString(Soles / Convert.ToDecimal(txtCambioCom.Text));
                    }
                }
                CargaTipoCambio();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ok.letras(e);
        }

        private void customValidator1_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator5_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator6_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator7_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
        {
            /*flujo = AdmFlu.VerificaDepositoCaja(frmLogin.iCodSucursal, dtpFechaCierre.Value);
            if (flujo != null)
            {
                txtmonto.Text = flujo.MontoIngresado.ToString();
            }
            else
            {
                if (dtpFechaCierre.Value.Date.Equals(Convert.ToDateTime(System.DateTime.Now.Date)))
                {
                    txtmonto.Text = totalv.ToString();
                }
                else txtmonto.Text = "0.00";
            }*/
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {
            if (Procede == 2)
            {
                if (txtmonto.Text != "")
                {
                    if (Convert.ToDecimal(txtmonto.Text) > 0)
                    {
                        btnGuardar2.Enabled = true;
                    }
                    else
                    {
                        btnGuardar2.Enabled = false;
                    }
                }
            }
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbtipopagoser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Int32 numeracion = admcta.Correlativo(Convert.ToInt32(cmbtipopagoser.SelectedValue));
            txtdoc.Text = numeracion.ToString().PadLeft(9, '0');
        }

        private void txtTotalCuenta_TextChanged(object sender, EventArgs e)
        {

        }

       

        








    }
}
