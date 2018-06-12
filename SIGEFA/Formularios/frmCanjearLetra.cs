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
    public partial class frmCanjearLetra : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsPago Pag = new clsPago();
        clsAdmPago Admpag = new clsAdmPago();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsAdmFactura Admfac=new clsAdmFactura();
        public  clsFactura notaI=new clsFactura();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        public clsNotaSalida notaS = new clsNotaSalida();
        clsAdmLetra Admletra = new clsAdmLetra();
        clsLetra letra = new clsLetra();
        public clsFacturaVenta venta = new clsFacturaVenta();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        Boolean bok = false;
        public Int32 Procede = 0;
        DateTimePicker selfecha = new DateTimePicker();
        Int32 CodDocumento = 9; // aca debe ir el codigo del tipo documento letra el cual se debe indicar en los parametros de configuracion principal
        String documento = "";

        public frmCanjearLetra()
        {
            InitializeComponent();
        }

        private void frmCanjearLetra_Load(object sender, EventArgs e)
        {
            cargaMoneda();
           
            if (Procede == 1)
            {
                CargaFormaPagos(0);
                CargaCuentaxPagar();
            }
            else if (Procede == 2)
            {
                CargaFormaPagos(1);
                CargaCuentaxCobrar();
            }

            selfecha.Format = DateTimePickerFormat.Short;
            selfecha.Visible = false;
            selfecha.Width = 100;
            dgvLetras.Controls.Add(selfecha);
            selfecha.ValueChanged += new System.EventHandler(this.selfecha_ValueChanged);           

        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedValue = 1;
        }


        private void CargaFormaPagos(Int32 tipo)
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(tipo);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;
        }

        private void CargaCuentaxPagar()
        {
            notaI = Admfac.CargaFactura(Convert.ToInt32(notaI.CodFactura));
            txtCodCliente.Text = notaI.RUCProveedor;
            txtNombreProveedor.Text = notaI.RazonSocialProveedor;
            cmbFormaPago.SelectedValue = notaI.FormaPago;
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            txtMonto.Text = String.Format("{0:#,##0.00}", notaI.Pendiente);
            cmbMoneda.SelectedValue  = notaI.Moneda;
            txtTipoCambio.Text = notaI.TipoCambio.ToString();
            //documento = notaI.DocumentoFactura;
        }

        private void CargaCuentaxCobrar()
        {
            venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(venta.CodFacturaVenta));
            txtCodCliente.Text = venta.DNI;
            txtNombreProveedor.Text = venta.RazonSocialCliente;
            cmbFormaPago.SelectedValue = venta.FormaPago;
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            txtMonto.Text = String.Format("{0:#,##0.00}", venta.Total);
            cmbMoneda.SelectedValue = venta.Moneda;
            txtTipoCambio.Text = venta.TipoCambio.ToString();
            documento = venta.SiglaDocumento + "-" + venta.Serie + "-" + venta.NumDoc;
        }

        private void nudCuotas_ValueChanged(object sender, EventArgs e)
        {
            LlenarProgramaLetras();
        }

        
        private void LlenarProgramaLetras()
        {
            dgvLetras.Rows.Clear();
            
            if (nudCuotas.Value != -1 && txtMonto.Text != "" && Convert.ToInt32(cmbFormaPago.SelectedValue) != -1)
            {
                Double cuota = 0;
                if (Procede == 1)
                {
                    cuota = notaI.Pendiente / Convert.ToDouble(nudCuotas.Value);
                }
                else if(Procede == 2)
                {
                    cuota = venta.Total / Convert.ToDouble(nudCuotas.Value);
                }

                for (int i = 1; i <= nudCuotas.Value; i++)
                {
                    dgvLetras.Rows.Add("LT - " + i ,dtpFecha.Value.Date.ToShortDateString(), CalcularFechaCuota().ToShortDateString(),documento,cmbMoneda.Text,cuota, cuota);                    
                }
                btnGuardar.Enabled = true;
            }
        }

        private DateTime CalcularFechaCuota()
        {
            DateTime fechaanterior = new DateTime();
            DateTime fechaactual = new DateTime();
            Int32 dias = 0;
            dias = fpago.Dias;
            dias = dias / Convert.ToInt32(nudCuotas.Value);

            if (dgvLetras.Rows.Count == 0)
            {
                fechaanterior = dtpFecha.Value.Date;                
            }
            else
            {
                fechaanterior = Convert.ToDateTime(dgvLetras.Rows[(dgvLetras.Rows.Count - 1)].Cells[fechavence.Name].Value); 
            }
            if (Convert.ToInt32(cmbFormaPago.SelectedValue) != -1 && fpago != null)
            {
                
                fechaactual = fechaanterior.AddDays(dias);
            }
            return fechaactual;
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fpago = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            LlenarProgramaLetras();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LlenarProgramaLetras();
        }

        private void selfecha_ValueChanged(object sender, EventArgs e)
        {
            dgvLetras.CurrentCell.Value = selfecha.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Procede == 1)
            {
                foreach (DataGridViewRow row in dgvLetras.Rows)
                {
                    letra.CodAlmacen = frmLogin.iCodAlmacen;
                    letra.CodDocumento = CodDocumento;
                    letra.NumDocumento = Convert.ToString(row.Cells[numdocumento.Name].Value);
                    letra.CodNota = Convert.ToInt32(notaI.CodNotaIngreso);
                    letra.Codfactura = notaI.CodFactura;
                    letra.Codfacturaventa = 0;
                    letra.DocumentoReferencia = notaI.DocumentoFactura;
                    letra.CodProveedor = notaI.CodProveedor;
                    letra.FechaEmision = Convert.ToDateTime(row.Cells[fechaemision.Name].Value);
                    letra.FechaVencimiento = Convert.ToDateTime(row.Cells[fechavence.Name].Value);
                    letra.IngresoEgreso = false;
                    letra.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    letra.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                    letra.Monto = Convert.ToDouble(row.Cells[monto.Name].Value);
                    letra.MontoPendiente = Convert.ToDouble(row.Cells[monto.Name].Value);
                    if (letra.NumDocumento != "")
                    {
                        if (Admletra.insert(letra))
                        {
                            bok = true;
                        }
                        else
                        {
                            bok = false;
                        }
                    }
                    else
                    {
                        bok = false;
                        MessageBox.Show("Ingrese numero de documentos de las letras", "Letras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (bok)
                {
                    MessageBox.Show("Se generarón las letras correctamente", "Letras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;
                }
            }
            else if (Procede == 2)
            {
                foreach (DataGridViewRow row in dgvLetras.Rows)
                {
                    letra.CodAlmacen = frmLogin.iCodAlmacen;
                    letra.CodDocumento = CodDocumento;
                    letra.CodSerie = 11; // codigo de serie 001 de letras cuando son emitidas por la empresa                    
                    letra.CodNota = Convert.ToInt32(venta.CodFacturaVenta);
                    letra.DocumentoReferencia = venta.SiglaDocumento+"-"+venta.Serie+"-"+venta.NumDoc;
                    //letra.DocumentoReferencia = venta.NumDoc;
                    letra.CodLiberado = venta.CodCliente;
                    letra.FechaEmision = Convert.ToDateTime(row.Cells[fechaemision.Name].Value);
                    letra.FechaVencimiento = Convert.ToDateTime(row.Cells[fechavence.Name].Value);
                    letra.IngresoEgreso = true;
                    letra.CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    letra.TipoCambio = Convert.ToDouble(txtTipoCambio.Text);
                    letra.Monto = Convert.ToDouble(row.Cells[monto.Name].Value);
                    letra.MontoPendiente = Convert.ToDouble(row.Cells[pendiente.Name].Value);
                    if (Admletra.insert(letra))
                    {
                        bok = true;
                    }
                    else
                    {
                        bok = false;
                    }
                }
                if (bok)
                {
                    MessageBox.Show("Se generarón las letras correctamente", "Letras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLetras.DataSource = Admletra.MuestraListaLetrasNota(Convert.ToInt32(venta.CodFacturaVenta));
                    btnGuardar.Enabled = false;
                } 
            }
        }

        private void dgvLetras_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvLetras.Focused && e.ColumnIndex == dgvLetras.Columns[fechavence.Name].Index)
                {
                    selfecha.Location = dgvLetras.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    selfecha.Visible = true;
                    if (dgvLetras.CurrentCell.Value != DBNull.Value)
                    {
                        selfecha.Value = Convert.ToDateTime(dgvLetras.CurrentCell.Value);
                    }
                    else
                    {
                        selfecha.Value = DateTime.Today;
                    }
                }
                else
                {
                    selfecha.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLetras_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLetras.Focused && e.ColumnIndex == dgvLetras.Columns[fechavence.Name].Index)
                {
                    dgvLetras.CurrentCell.Value = selfecha.Value.Date;
                }
                if (dgvLetras.Focused && e.ColumnIndex == dgvLetras.Columns[monto.Name].Index)
                {
                    dgvLetras.CurrentRow.Cells[pendiente.Name].Value = dgvLetras.CurrentCell.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
