using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmPargarSeparacion : DevComponents.DotNetBar.OfficeForm
    {
        public Int32 codSeparacion;
        clsAdmSeparacion admSepa = new clsAdmSeparacion();
        clsSeparacion sepa = new clsSeparacion();
        clsCuotasSeparacion cuotasepa = new clsCuotasSeparacion();
        clsAdmCuotaSeparacion admcuotas = new clsAdmCuotaSeparacion();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsAdmTipoDocumento admDoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        public Int32 Proceso = 0;
        Double SumAbono = 0;

        public frmPargarSeparacion()
        {
            InitializeComponent();
        }

        private void frmPargarSeparacion_Load(object sender, EventArgs e)
        {
            if (codSeparacion != 0)
            {
                CargaMoneda();
                CargarDatos();
                DataTable dt = CargaTablaDatos();
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
                
                dgvCuotas.AutoGenerateColumns = false;
                dgvCuotas.DataSource = dt;

                //mostramos el valor de 0 en la fila que agregamos
                DataGridViewRow rowtotal = dgvCuotas.Rows[dgvCuotas.Rows.Count - 1];
                rowtotal.Cells["Monto"].Value = 0;

                
                CalcularTotal();
            }
        }

        private void CargaMoneda()
        {
            dtpFecha.MaxDate = DateTime.Today.Date;
            tc = AdmTc.CargaTipoCambio(dtpFecha.Value.Date, 2);
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void CalcularTotal()
        {
            Double resul = dgvCuotas.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Monto"].Value));            
            DataGridViewRow rowtotal = dgvCuotas.Rows[dgvCuotas.Rows.Count - 1];
            rowtotal.Cells["Monto"].Value =  resul;
            SumAbono = resul;
            if (resul == Convert.ToDouble(txtTotal.Text))
            {
                btnGuardar.Enabled = false;
                rowtotal.Cells["Monto"].Style.BackColor = Color.Red;
                
            }
            else
            {
                rowtotal.Cells["Monto"].Style.BackColor = Color.LightCyan;
            }
        }

        private DataTable CargaTablaDatos()
        {
            DataTable dt = new DataTable();
            dt = admcuotas.CargaCuotas(codSeparacion);
            return dt;
        }

        

        private void CargarDatos()
        {
            sepa = admSepa.BuscarSeparacion(codSeparacion, frmLogin.iCodAlmacen);
            txtDocumento.Text = sepa.Sigla;
            txtNumDocumento.Text = sepa.NumDocumento;
            txtSerie.Text = sepa.Serie;
            txtCliente.Text = sepa.NomCliente;
            txtTotal.Text = sepa.Total.ToString();
            CargarAbonos(codSeparacion);
        }

        private void CargarAbonos(Int32 codSeparacion)
        {
            dgvCuotas.DataSource = admcuotas.CargaCuotas(codSeparacion);
        }      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Double total = 0;
                Double pendiente = 0;
                DialogResult boton = MessageBox.Show("Desea Guardar abono?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (boton == DialogResult.OK)
                {
                    if (Proceso == 1)
                    {
                        if (txtAbonar.Text != "")
                        {
                            total = Convert.ToDouble(txtTotal.Text);
                            pendiente = total - SumAbono;
                            if (Convert.ToDouble(txtAbonar.Text) <= pendiente)
                            {
                                cuotasepa.CodSeparacion = codSeparacion;
                                cuotasepa.FechaRegistro = dtpFecha.Value;
                                cuotasepa.Monto = Convert.ToDecimal(txtAbonar.Text);
                                cuotasepa.CodUsuario = frmLogin.iCodUser;
                                cuotasepa.Total = Convert.ToDecimal(txtTotal.Text);
                                cuotasepa.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                                cuotasepa.TipoCambio = Convert.ToDecimal(tc.Venta);
                                cuotasepa.CodAlmacen = frmLogin.iCodAlmacen;
                                if (txtSerie.Text != "" && txtDocumento.Text != "")
                                {
                                    cuotasepa.Serie = txtSerie.Text;
                                    cuotasepa.NumDocumento = txtNumDocumento.Text;
                                    cuotasepa.CodTipoDocumento = Convert.ToInt32(txtCodDocumento.Text);
                                    cuotasepa.Desdocumento = txtDocumento.Text;
                                    cuotasepa.CodSerie = CodSerie;
                                    if (admcuotas.insert(cuotasepa))
                                    {
                                        MessageBoxEx.Show("Se Guardo de forma correcta: ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBoxEx.Show("Ha ocurrido un problema: ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBoxEx.Show("Debe Expecificar El documento: ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("El monto abonado supera al total: ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Ingrese el monto a Abonar ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Int32 idValor = 0;
        private void dgvCuotas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult boton = MessageBox.Show("Desea Elimnar abono?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                idValor = Convert.ToInt32(dgvCuotas.Rows[e.RowIndex].Cells["CodAbono"].Value.ToString());
                if (admcuotas.delete(idValor))
                {
                    MessageBoxEx.Show("Se elimino de forma correcta: ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    CargarAbonos(cuotasepa.CodSeparacion);
                }
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmDocumentos"] != null)
                {
                    Application.OpenForms["frmDocumentos"].Activate();
                }
                else
                {
                    frmDocumentos form = new frmDocumentos();
                    form.Proceso = 3;
                    form.ShowDialog();
                    doc = form.doc;
                    CodDocumento = doc.CodTipoDocumento;
                    txtCodDocumento.Text = CodDocumento.ToString();
                    txtDocumento.Text = doc.Sigla;
                    
                    if (CodDocumento != 0) { ProcessTabKey(true); }

                }
            }
        }

        public Int32 CodDocumento = 0;
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtDocumento.Text != "")
                {
                    if (BuscaTipoDocumento())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool BuscaTipoDocumento()
        {
            doc = admDoc.BuscaTipoDocumento(txtDocumento.Text);
            if (doc != null)
            {
                CodDocumento = doc.CodTipoDocumento;
                txtCodDocumento.Text = CodDocumento.ToString();
                return true;
            }
            else
            {
                CodDocumento = 0;
                txtCodDocumento.Text = CodDocumento.ToString();
                return false;
            }
        }
        clsValidar ok = new clsValidar();
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                //if (txtSerie.Text != "")
                //{
                if (BuscaSerie())
                {
                    txtSerie.Text = ser.Serie.ToString();
                    if (ser.PreImpreso)
                    {
                        txtNumDocumento.Visible = true;
                        txtNumDocumento.Enabled = false;

                        txtNumDocumento.Focus();
                        txtNumDocumento.Text = "";
                    }
                    else
                    {
                        txtNumDocumento.Text = "";
                        //txtNumero.Enabled = true;
                        txtNumDocumento.Enabled = false;
                        //txtNumero.Visible = false;
                        txtNumDocumento.Text = ser.Numeracion.ToString();
                    }

                    ProcessTabKey(true);
                    
                }

            }
            
        }
        public Int32 CodSerie = 0;
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();

        private bool BuscaSerie()
        {
            ser = Admser.BuscaSeriexDocumento(CodDocumento, frmLogin.iCodAlmacen);
            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }
        }

        public Int32 numSerie = 0;
        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmSerie"] != null)
                {
                    Application.OpenForms["frmSerie"].Activate();
                }
                else
                {
                    frmSerie form = new frmSerie();
                    form.Proceso = 3;
                    form.DocSeleccionado = CodDocumento;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                 
                    if (CodSerie != 0)
                    {
                        txtSerie.Text = ser.Serie;
                        txtNumDocumento.Text = ser.Numeracion.ToString();
                       
                    }
                    if (CodSerie != 0) { ProcessTabKey(true); }
                }
            }
        }
    }
}