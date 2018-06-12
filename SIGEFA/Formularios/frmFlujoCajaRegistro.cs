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
using SIGEFA.Formularios;

namespace SIGEFA.Formularios
{
    public partial class frmFlujoCajaRegistro : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 CodFlujoCaja = 0;
        public Int32 Proceso = 0;
        public Int32 Procede = 0;

        clsAdmFlujoCaja AdmFlu = new clsAdmFlujoCaja();
        clsFlujoCaja flu = new clsFlujoCaja();
        clsValidar ok = new clsValidar();
        clsCaja aper = new clsCaja();
        clsAdmAperturaCierre AdmAper = new clsAdmAperturaCierre();
        private clsSucursal suc = new clsSucursal();
        private clsAdmSucursal admSuc = new clsAdmSucursal();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmFlujoCajaRegistro()
        {
            InitializeComponent();
        }

        private void HabilitaControles(Boolean Estado)
        {
            txtconcepto.Enabled = Estado;
            txtmonto.Enabled = Estado;
            dtpfecha.Enabled = Estado;
            cboTipo.Enabled = Estado;
            btnGuardar.Enabled = Estado;
            cmbtipopagoser.Enabled = Estado;
        }


        private void carga()
        {
            cmbtipopagoser.DataSource = AdmFlu.ListaPagoCobro(0);
            cmbtipopagoser.DisplayMember = "descripcion";
            cmbtipopagoser.ValueMember = "codtipopagoserv";
            cmbtipopagoser.SelectedIndex = -1;
        }

        private void frmFlujoCajaRegistro_Load(object sender, EventArgs e)
        {
            carga();
            if (Proceso == 1 || Proceso == 2)
            {
                HabilitaControles(true);
            }
            else if (Proceso == 3)
            {
                HabilitaControles(false);
            }
            if (Procede == 2)
            {
                posiciona_elementos();

                dtpfecha.MinDate = Convert.ToDateTime(System.DateTime.Now);
                dtpfecha.MaxDate = Convert.ToDateTime(System.DateTime.Now);
                dtpfecha.Value = Convert.ToDateTime(System.DateTime.Now);
            }
        }

        private void posiciona_elementos()
        {
            suc = admSuc.CargaSucursal(frmLogin.iCodSucursal);
            label2.Location = new Point(16,128);
            txtmonto.Location = new Point(19,144);
            label3.Location = new Point(169,128);
            dtpfecha.Location = new Point(172,144);
            label4.Visible = false;
            cboTipo.Visible = false;
            label5.Visible = false;
            cmbtipopagoser.Visible = false;
            btnGuardar.Location = new Point(138,8);
            btnSalir.Location = new Point(221,8);
            groupBox1.Size = new Size(467,191);
            groupBox2.Size = new Size(468,44);
            txtconcepto.Enabled = false;
            txtconcepto.Text = "APERTURA INICIAL DE CAJA DE LA SUCURSAL "+suc.Nombre;
        } 

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    //flu.Concepto = txtconcepto.Text;
                    //flu.Monto = Convert.ToDecimal(txtmonto.Text);
                    //flu.Fecha = dtpfecha.Value;
                    //flu.FechaRegistro = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    //flu.CodUser = frmLogin.iCodUser;
                    //flu.CodAlmacen = frmLogin.iCodAlmacen;

                    //if (cboTipo.Text == "INGRESO")
                    //{
                    //    flu.Tipo = 1;
                    //    flu.CodPagoServicio = 0;
                    //}
                    //else if (cboTipo.Text == "EGRESO")
                    //{
                    //    flu.Tipo = 2;
                    //    cmbtipopagoser.Enabled = true;
                    //    flu.CodPagoServicio = Convert.ToInt32(cmbtipopagoser.SelectedValue);
                    //}

                    //if (flu.Concepto != "" && flu.Monto != 0 && flu.CodUser != 0 && flu.Tipo != 0)
                    //{
                    if (Proceso != 0)
                    {
                        flu.CodSucursal = frmLogin.iCodSucursal;
                        flu.FechaApertura = dtpfecha.Value;
                        flu.MontoApertura = Convert.ToDecimal(txtmonto.Text);
                        flu.CodUser = frmLogin.iCodUser;

                        if (Proceso == 1)
                        {
                            if (AdmFlu.Insert(flu))
                            {

                                //MessageBox.Show("Los datos se Guardaron Correctamente", "CONTROL DE FLUJO DE CAJA",
                                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Los datos se Guardaron Correctamente", "APERTURA CAJA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmListaCaja frm = (frmListaCaja) Application.OpenForms["frmListaCaja"];
                                frm.biIngreso.Visible = false;
                                frm.biStatusCaja.Visible = true;
                                frm.VerificaSaldoCaja();
                                frm.CalculaTotales();
                                //frm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un Error al Guardar los Datos", "CONTROL DE FLUJO DE CAJA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else if (Proceso == 2)
                        {
                            flu.CodFlujoCaja = CodFlujoCaja;
                            if (AdmFlu.Update(flu))
                            {
                                MessageBox.Show("Los datos se Modificaron Correctamente", "CONTROL DE FLUJO DE CAJA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un Error al Actualizar los Datos", "CONTROL DE FLUJO DE CAJA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        //Proceso = 0;
                        
                    }
                }
                //else
                //{
                //    MessageBox.Show("Faltan Datos, Verifique Informacion!", "CONTROL DE FLUJO DE CAJA",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtconcepto.Focus();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 1 || cboTipo.SelectedIndex == 0)
            {
                cmbtipopagoser.Enabled = false;
                cmbtipopagoser.SelectedValue = 0;
            }
            else if (cboTipo.SelectedIndex == 2)
            {
                carga();
                cmbtipopagoser.Enabled = true;

            }
            btnGuardar.Enabled = true;
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtmonto_KeyUp(object sender, KeyEventArgs e)
        {
            //aper = AdmAper.ValidarAperturaCierre(frmLogin.iCodAlmacen);
            //if (Convert.ToDecimal(txtmonto.Text) >= aper.MontoApertura)
            //{
            //    MessageBox.Show("El Monto Excede del Monto Aperturado", "Fluja Caja", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //}
        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            //aper = AdmAper.ValidarAperturaCierre(frmLogin.iCodAlmacen);
            //if (Convert.ToDecimal(txtmonto.Text) >= aper.MontoApertura)
            //{
            //    MessageBox.Show("El Monto Ingresado Excede del Monto Aperturado ... [MONTO APERTURADO = "+aper.MontoApertura+"]", "Fluja Caja", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    txtmonto.Focus();
            //}
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Procede != 2)
            {
                ComboBox c = (ComboBox) e.ControlToValidate;
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
        }

        private void txtconcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.letras(e);
        }
    }
}
