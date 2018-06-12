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
    public partial class frmConciliacionesBancarias : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        clsAdmCtaCte admcta = new clsAdmCtaCte();
        clsAdmBanco admban = new clsAdmBanco();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsCtaCte cta = new clsCtaCte();

        clsConciliacionBancaria conban = new clsConciliacionBancaria();
        clsDetalleConciliacion detcon = new clsDetalleConciliacion();
        clsAdmConciliacionBancaria admconban = new clsAdmConciliacionBancaria();
        List<clsDetalleConciliacion> detalle = new List<clsDetalleConciliacion>();
        List<clsDetalleConciliacion> detalle_conci = new List<clsDetalleConciliacion>();
        public Int32 bandera=0;
        public Int32 estado_conciliacion;
        public Int32 Proceso = 0, CodConciliacion = 0;

        public frmConciliacionesBancarias()
        {
            InitializeComponent();
        }

        private void frmConciliacionesBancarias_Load(object sender, EventArgs e)
        {
            CargaMoneda();
            CargaBancos();
        }

        private void CargaBancos()
        {
            cmbBanco.DataSource = admban.MuestraBancos();
            cmbBanco.DisplayMember = "descripcion";
            cmbBanco.ValueMember = "codBanco";
            cmbBanco.SelectedIndex = -1;
        }

        private void CargaMovimientosDesactivados(Int32 codbanco, Int32 codcuenta, Int32 codalma)
        {
            dgvDetalle.DataSource = data;
            data.DataSource = admcta.ListaMovimientosDesactivos(codbanco, codcuenta, codalma);
            data.Filter = String.Empty;
            dgvDetalle.ClearSelection();
        }

        private void cmbBanco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cuentas();
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

        private void Cargartiposcuenta()
        {
            cta = admcta.CargaTipoCuenta(Convert.ToInt32(cmbCuenta.SelectedValue.ToString()), frmLogin.iCodAlmacen);

            if (cta != null)
            {
                txtTipoCta.Text = cta.TipoCuenta;

                if (cta.Moneda > 0)
                {
                    cmbMoneda.SelectedValue = cta.Moneda;
                }
                else
                {
                    cmbMoneda.SelectedIndex = -1;
                    txtTipoCta.Text = "";
                }
                //if (Proceso == 2) txtDescripcion.Text = cta.descripcion;
                //txtTotalCuenta.Text = cta.saldo.ToString();
            }
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

        private void btnConciliar_Click(object sender, EventArgs e)
        {
            decimal totalcuenta = 0;
            CargaMovimientosDesactivados(Convert.ToInt32(cmbBanco.SelectedValue), Convert.ToInt32(cmbCuenta.SelectedValue),frmLogin.iCodAlmacen);
            CalcularTotaldeChequesNoCobrados();
            totalcuenta = admcta.TotalConciliacion(frmLogin.iCodAlmacen, Convert.ToInt32(cmbBanco.SelectedValue), Convert.ToInt32(cmbCuenta.SelectedValue));
            txtsaldosegunlibro.Text = String.Format("{0:#,##0.00}", totalcuenta);
        }

        private void CalcularTotaldeChequesNoCobrados()
        {
            Decimal total = 0, saldocuenta1 = 0;
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[debe.Name].Value) > 0)
                    {
                        row.Cells[debe.Name].Style.ForeColor = Color.Red;
                        total = total + Convert.ToDecimal(row.Cells[debe.Name].Value);
                        saldocuenta1 = Convert.ToDecimal(row.Cells[saldocuenta.Name].Value);
                    }
                }
            }

            txtTotalNoCobrado.Text = String.Format("{0:#,##0.00}", total);
            txtChequenoCobrados.Text = String.Format("{0:#,##0.00}", total);
            //txtsaldosegunlibro.Text = String.Format("{0:#,##0.00}", saldocuenta1);
            txtsaldosegunextracto.Enabled = true;
            //btnGuardar2.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            if (txtsaldosegunextracto.Text != "")
            {
                
                conban.Codbanco = Convert.ToInt32(cmbBanco.SelectedValue);
                conban.Codcuenta = Convert.ToInt32(cmbCuenta.SelectedValue);
                conban.Codmoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                conban.Saldoextracto = Convert.ToDecimal(txtsaldosegunextracto.Text);
                conban.Montonocobrado = Convert.ToDecimal(txtChequenoCobrados.Text);
                conban.Saldolibro = Convert.ToDecimal(txtsaldosegunlibro.Text);
                conban.Coduser = frmLogin.iCodUser;

                if (Proceso == 1)
                {

                   if (admconban.insert(conban) )
                    {

                        CodConciliacion = conban.CodconciliacionNuevo;
                        //recorregrilla();
                        Carga_Movimientos();  
                       
                        /*===GUARDA TODO EL DETALLE===*/
                       if (detalle_conci.Count > 0)
                        {
                            foreach (clsDetalleConciliacion det in detalle_conci)
                            {                               
                                if (det.Bandera == 1)
                                {
                                    admconban.update(frmLogin.iCodAlmacen, conban.Codbanco, conban.Codcuenta, det.Codctamovimiento);
                                    //actualiza bandera
                                    admconban.UpdateBandera(frmLogin.iCodAlmacen, conban.Codbanco, conban.Codcuenta, det.Codctamovimiento);
                                    admconban.insertdetalle(det);
                                }
                                else {
                                    if (det.Bandera == 2) { 
                                        //ver
                                    }
                                }
                                
                            }
                        }
                      
                            MessageBox.Show("Los datos se Guardaron Correctamente");
                            detalle_conci.Clear();
                            this.Close();
                    }
                    else { MessageBox.Show("Error al Guardar"); }
                }
            }
        }

        private void recorregrilla()
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {


                    if (Convert.ToDecimal(row.Cells[debe.Name].Value) > 0)
                    {
                        detcon = new clsDetalleConciliacion();
                        detcon.Codconciliacion = CodConciliacion;
                        detcon.Codctamovimiento = Convert.ToInt32(row.Cells[codMovimientos.Name].Value);
                        detcon.Monto = Convert.ToDecimal(row.Cells[debe.Name].Value);
                        detcon.Coduser = frmLogin.iCodUser;

                        detalle.Add(detcon);

                    }
                }
              
            }
        }

        private void txtsaldosegunextracto_Leave(object sender, EventArgs e)
        {
            if (txtsaldosegunextracto.Text != "") 
            {
                if (Convert.ToDecimal(txtsaldosegunextracto.Text) > 0) 
                {
                    Decimal saldoextracto = Convert.ToDecimal(txtsaldosegunextracto.Text);
                    Decimal montonocobrado = Convert.ToDecimal(txtTotalNoCobrado.Text);
                    Decimal saldolibro = Convert.ToDecimal(txtsaldosegunlibro.Text);

                    if ((saldoextracto - montonocobrado) == saldolibro)
                    {
                        MessageBox.Show("saldo Correcto");
                        btnGuardar2.Enabled = true;
                    }
                    else { MessageBox.Show("saldo Incorrecto"); }
                }
            }
        }

        /*Carga Movimientos*/
        public void Carga_Movimientos() {
           
            DataTable datos = new DataTable();
            datos = admcta.ListarMovientoscta(frmLogin.iCodAlmacen, conban.Codbanco,conban.Codcuenta);
            
            foreach (DataRow row in datos.Rows)
            {   
               
                detcon = new clsDetalleConciliacion();
                int activo_conci, dato;
                dato = Convert.ToInt32(row[22]);
                bandera = Convert.ToInt32(row[23]);
                estado_conciliacion = Convert.ToInt32(row[24]);
                if (dato == 2 )
                {
                    activo_conci = 2;
                }
                else
                {
                    activo_conci = 1;
                }
                detcon.Codconciliacion = CodConciliacion;
                detcon.Codctamovimiento = Convert.ToInt32(row[0]);
                detcon.Monto = Convert.ToDecimal(row[11]);
                detcon.Actico_conci = Convert.ToInt32(activo_conci);
                detcon.Coduser = frmLogin.iCodUser;
                detcon.Bandera = bandera;
                detalle_conci.Add(detcon);
               
            }
           
        }

       
           
       

        
    }
}
