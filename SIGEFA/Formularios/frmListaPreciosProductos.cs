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
    public partial 
        class frmListaPreciosProductos : DevComponents.DotNetBar.Office2007Form
    {
        
        private clsAdmTipoCambio admTipo=new clsAdmTipoCambio();
        private clsTipoCambio tipo=new clsTipoCambio();
        private clsAdmListaPrecio AdmLista = new clsAdmListaPrecio();
        private clsDetalleListaPrecio DtLista = new clsDetalleListaPrecio();
        private clsConsultasExternas ext = new clsConsultasExternas();
        public clsListaPrecio lista = new clsListaPrecio();
        private clsAdmFamilia admFam = new clsAdmFamilia();
        private clsAdmLinea admLin = new clsAdmLinea();
        private clsAdmProducto admProd = new clsAdmProducto();
        private clsFamilia fam = new clsFamilia();
        private clsLinea lin = new clsLinea();
        private clsProducto prod = new clsProducto();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        public Int32 codlista = 0;
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Buscar Ingreso (4) Buscar Salida
        public Int32 Procede = 0;
        public Int32 Codlista = 0;
        private clsValidar ok = new clsValidar();
        public Int32 decimales = 0;
        public static BindingSource data = new BindingSource();
        private String filtro = String.Empty;
        TextBox txtedit = new TextBox();
        clsValidar val = new clsValidar();

        Decimal valor = 0;
        Decimal mar = 0;
        Decimal neto = 0;
        Decimal precion = 0;
        Decimal preciod = 0;

        private Int32 CodListaOrigen = 0;

        public frmListaPreciosProductos()
        {
            InitializeComponent();    
        }

        private void CargaFamilias()
        {
            cboFamilia.DataSource = admFam.MuestraFamilias();
            cboFamilia.DisplayMember = "descripcion";
            cboFamilia.ValueMember = "codFamilia";
            cboFamilia.SelectedIndex = -1;
        }

        private void CargaLineas(int codFami)
        {
            cboLinea.DataSource = admLin.MuestraLineas(codFami);
            cboLinea.DisplayMember = "descripcion";
            cboLinea.ValueMember = "codLinea";
            cboLinea.SelectedIndex = -1;
        }

        private void frmListaPrecios_Load(object sender, EventArgs e)
        {
            CargaFamilias();
            tipo = admTipo.CargaTipoCambio(DateTime.Now, 2);
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalleListaPrecio.Rows.Count > 0)
                {
                    String estado = "";
                    if (btnGuardar.Text == "Guardar")
                    {
                        foreach (DataGridViewRow row in dgvDetalleListaPrecio.Rows)
                        {
                            DtLista.Margen = Convert.ToDouble(row.Cells[margp.Name].Value);
                            DtLista.Descuento1 = 0;
                            DtLista.Descuento2 = 0;
                            DtLista.Descuento3 = 0;
                            DtLista.PrecioNeto = Convert.ToDouble(row.Cells[net.Name].Value);
                            DtLista.Precio = Convert.ToDouble(row.Cells[preciov.Name].Value);
                            DtLista.CodProducto = Convert.ToInt32(row.Cells[codprod.Name].Value);
                            DtLista.CodListaPrecio = codlista;
                            //lista.PrecioProm
                            if (Convert.ToInt32(row.Cells[Modificar.Name].Value) == 1)
                            {
                                if (AdmLista.updatedetallePorFiltro(DtLista))
                                {
                                    estado = estado + "1";


                                }
                                else
                                {
                                    estado = estado + "0";
                                }
                            }
                        }
                        if (estado.Contains("0"))
                        {
                            MessageBox.Show("Verifique", "Listas de Precios Productos",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Los datos se actualizaron correctamente", "Listas de Precios Productos",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGuardar.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Verifique! No hay Datos a Guardar", "Lista Precios Productos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique!", "Lista Precios Productos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



       
        private void customValidator1_ValidateValue(object sender,
            DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

     
        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void customValidator2_ValidateValue(object sender,
            DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Enabled)
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

       private void customValidator3_ValidateValue(object sender,
            DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Enabled)
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender,
            DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void btnCalularPrecios_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                if (AdmLista.GeneraLista(lista.CodListaPrecio, frmLogin.iCodAlmacen, lista.Decimales))
                {
                    MessageBox.Show("Se generó la lista de precios correctamente", "Listas de Precios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se generó correctamente la Lista de Precios", "Listas de Precios",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void customValidator5_ValidateValue(object sender,
            DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Enabled)
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void txtMargen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtProveedorNomb_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = 5;
                    form.ShowDialog();

                }
                cargadatas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           
        }

    

        private void txtRProduc1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    frmProductosLista frm = new frmProductosLista();
                    frm.Procede = 13;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.referenciaPro == null)
                        {
                            txtRProduc1.Focus();
                        }
                        else
                        {
                            txtRProduc1.Text = frm.referenciaPro; //referencia
                            txtRango1.Text = frm.descripcionPro; //descripcion
                            txtCodPro1.Text = frm.codigoPro.ToString(); //codigo 
                            txtRProduc2.Focus();
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            
        }

        private void txtRProduc2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    frmProductosLista frm = new frmProductosLista();
                    frm.Procede = 14;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.referenciaPro== null)
                        {
                            txtRProduc2.Focus();
                        }
                        else
                        {
                            txtRProduc2.Text = frm.referenciaPro.ToString(); //referencia
                            txtRango2.Text = frm.descripcionPro.ToString(); //descripcion
                            txtCodPro2.Text = frm.codigoPro.ToString(); //codigo 
                        }
                    }
                }
                cargadatas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            
        }

        private void cargadatas()
        {
            try
            {
                if (chbRango.Checked == true && chbProveedor.Checked == true && chbFamilia.Checked == true)
                {
                    if (txtRProduc1.Text != "" && txtRProduc2.Text != "" && txtProveedorNomb.Text != "" &&
                        (cboFamilia.SelectedValue != null ) && cboLinea.SelectedValue != null)
                    {
                        cargaData6();
                    }
                    else if (txtRProduc1.Text != "" && txtRProduc2.Text != "" && txtProveedorNomb.Text != "" &&
                        cboFamilia.SelectedValue!= null && cboLinea.SelectedValue==null)
                    {
                        cargaData9();
                    }
                    else
                    {
                        //dgvDetalleListaPrecio.Rows.Clear();
                    }
                }
                else if (chbRango.Checked == false && chbProveedor.Checked == false && chbFamilia.Checked == false)
                {
                    if (data.DataSource != null)
                    {
                        DataTable dt = (DataTable)data.DataSource;
                        dt.Clear();
                    }
                }
                else if (chbRango.Checked == true && chbProveedor.Checked == false && chbFamilia.Checked == false)
                {
                    if (txtRProduc1.Text != "" && txtRProduc2.Text != "")
                    {
                        cargaData();
                    }
                    else
                    {
                       // dgvDetalleListaPrecio.Rows.Clear();
                    }
                }
                else if (chbRango.Checked == false && chbProveedor.Checked == true && chbFamilia.Checked == false)
                {
                     if (txtProveedorNomb.Text != "" )
                    {
                        cargaData2();
                    }
                     else
                     {
                        // dgvDetalleListaPrecio.Rows.Clear();
                     }
                }
                else if (chbRango.Checked == false && chbProveedor.Checked == false && chbFamilia.Checked == true)
                {
                    if (cboFamilia.SelectedValue != null && cboLinea.SelectedValue != null)
                    {
                        cargaData5();
                    }
                    else if (cboFamilia.SelectedValue!= null  && cboLinea.SelectedValue == null)
                    {
                        cargaData4();
                    }
                    else
                    {
                       //dgvDetalleListaPrecio.Rows.Clear(); 
                    }
                }
                else
                {
                    if (chbRango.Checked == true && chbFamilia.Checked == true && chbProveedor.Checked==false)
                    {
                        if (txtRProduc1.Text != "" && txtRProduc2.Text != "" && 
                        cboFamilia.SelectedValue != null && cboLinea.SelectedValue != null)
                        {
                            cargaData10();
                        }
                        else if (txtRProduc1.Text != "" && txtRProduc2.Text != "" &&
                                 cboFamilia.SelectedValue != null && cboLinea.SelectedValue == null)
                        {
                            cargaData7();
                        }
                        else
                        {
                            //dgvDetalleListaPrecio.Rows.Clear(); 
                        }
                    }
                    else if (chbRango.Checked == true && chbFamilia.Checked == false && chbProveedor.Checked == true)
                    {
                        if (txtRProduc1.Text != "" && txtRProduc2.Text != "" && txtProveedorNomb.Text != "" )
                        {
                            cargaData3();
                        }
                        else { dgvDetalleListaPrecio.Rows.Clear(); }

                    }else if (chbRango.Checked == false && chbFamilia.Checked == true && chbProveedor.Checked == true)
                    {
                        if (txtProveedorNomb.Text != "" && chbProveedor.Checked == true &&
                        cboFamilia.SelectedValue != null && cboLinea.SelectedValue != null 
                        && chbFamilia.Checked == true)
                        {
                            cargaData11();
                        }

                        else if (txtProveedorNomb.Text != "" && chbProveedor.Checked == true &&
                        cboFamilia.SelectedValue!= null && cboLinea.SelectedValue == null
                        && chbFamilia.Checked == true)
                        {
                            cargaData8();
                        }
                        else
                        {
                            //dgvDetalleListaPrecio.Rows.Clear();
                        }
                        } 
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            

        }

        private void cargaData()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorFiltro(frmLogin.iCodAlmacen, Convert.ToInt32(txtCodPro1.Text),
                Convert.ToInt32(txtCodPro2.Text), codlista,decimales);
            data.Filter = String.Empty;
            filtro= String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Proveedor
        private void cargaData2()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorProveedor(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtProveedorCod.Text), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Rango y Proveedor
        private void cargaData3()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorRangoProv(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtCodPro1.Text), Convert.ToInt32(txtCodPro2.Text),
                Convert.ToInt32(txtProveedorCod.Text), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Familia
        private void cargaData4()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorFamilia(frmLogin.iCodAlmacen,
                Convert.ToInt32(cboFamilia.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Linea
        private void cargaData5()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorLinea(frmLogin.iCodAlmacen,
                Convert.ToInt32(cboFamilia.SelectedValue), Convert.ToInt32(cboLinea.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Todos (Rango, Proveedor, Familia, Linea)
        private void cargaData6()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorTodos(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtCodPro1.Text), Convert.ToInt32(txtCodPro2.Text),
                Convert.ToInt32(txtProveedorCod.Text), Convert.ToInt32(cboFamilia.SelectedValue),
                Convert.ToInt32(cboLinea.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Rango y Familia
        private void cargaData7()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorRangoFam(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtCodPro1.Text), Convert.ToInt32(txtCodPro2.Text),
                Convert.ToInt32(cboFamilia.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro= String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Proveedor y Familia
        private void cargaData8()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorProveedorFam(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtProveedorCod.Text), Convert.ToInt32(cboFamilia.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio Parcial (Rango, Proveedor, Familia)
        private void cargaData9()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasParcial(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtCodPro1.Text), Convert.ToInt32(txtCodPro2.Text),
                Convert.ToInt32(txtProveedorCod.Text), Convert.ToInt32(cboFamilia.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Rango, Familia y Linea
        private void cargaData10()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorRangoFamLin(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtCodPro1.Text), Convert.ToInt32(txtCodPro2.Text),
                Convert.ToInt32(cboFamilia.SelectedValue), Convert.ToInt32(cboLinea.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        //Muestra ListaPrecio x Proveedor, Familia y Linea
        private void cargaData11()
        {
            dgvDetalleListaPrecio.DataSource = data;
            data.DataSource = AdmLista.MuestraListasPorProveedorFamLin(frmLogin.iCodAlmacen,
                Convert.ToInt32(txtProveedorCod.Text), Convert.ToInt32(cboFamilia.SelectedValue),
                Convert.ToInt32(cboLinea.SelectedValue), codlista, decimales);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleListaPrecio.ClearSelection();
        }

        private void chbRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRango.Checked == true)
            {
                txtRProduc1.Visible = true;
                txtRango1.Visible = true;
                txtRProduc2.Visible = true;
                txtRango2.Visible = true;
                label11.Visible = true;
                label10.Visible = true;
               
            }
            else
            {
                txtRProduc1.Visible = false;
                txtRango1.Visible = false;
                txtRProduc2.Visible = false;
                txtRango2.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
                txtRProduc1.Text = "";
                txtRProduc2.Text = "";
                txtRango1.Text = "";
                txtRango2.Text = "";
                cargadatas();
            }
           
           
        }

        private void chbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProveedor.Checked == true)
            {
                txtProveedorNomb.Visible = true;
            }
            else
            {
                txtProveedorNomb.Visible = false;
                txtProveedorNomb.Text = "";
                cargadatas();
            }
            
        }


        private void chbFamilia_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFamilia.Checked == true)
            {
                cboFamilia.Visible = true;
                lbLinea.Visible = true;
                cboFamilia.SelectedIndex = -1;
            }
            else
            {
                cboFamilia.Visible = false;
                cboLinea.Visible = false;
                lbLinea.Visible = false;
                cboFamilia.SelectedIndex = -1;
                cboLinea.SelectedIndex = -1;
                cargadatas();
            }
           
        }



        private void cboFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                fam = admFam.CargaFamilia(Convert.ToInt32(cboFamilia.SelectedValue));
                CargaLineas(Convert.ToInt32(cboFamilia.SelectedValue));

                if (cboFamilia.SelectedIndex != -1)
                {
                    cboLinea.Visible = true;
                }
                else
                {
                    cboLinea.Visible = false;
                }
              
            }
           
        }

        private void cboFamilia_Leave(object sender, EventArgs e)
        {
            fam = admFam.CargaFamilia(Convert.ToInt32(cboFamilia.SelectedValue));
            CargaLineas(Convert.ToInt32(cboFamilia.SelectedValue));

            if (cboFamilia.SelectedIndex != -1)
            {
                cboLinea.Visible = true;
            }
            else
            {
                cboLinea.Visible = false;
            }
        }

        
        private void cboLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                lin = admLin.CargaLinea(Convert.ToInt32(cboLinea.SelectedValue));
            }
        }

        private void cboLinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
           lin = admLin.CargaLinea(Convert.ToInt32(cboLinea.SelectedValue));
           cargadatas();
        }

        private void cboProducto_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cboFamilia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fam = admFam.CargaFamilia(Convert.ToInt32(cboFamilia.SelectedValue));
            CargaLineas(Convert.ToInt32(cboFamilia.SelectedValue));
            if (cboFamilia.SelectedIndex != -1)
            {
                cboLinea.Visible = true;
            }
            else
            {
                cboLinea.Visible = false;
            }
            cargadatas();
        }


        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0 && c.Visible)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator7_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void chbModificaMargen_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvDetalleListaPrecio.Rows.Count >= 1)
            {
            if (chbModificaMargen.Checked == true && textBox1.Text.Length > 0)
            {
                foreach (DataGridViewRow row in dgvDetalleListaPrecio.Rows)
                {
                    row.Cells[Modificar.Name].Value =1;
                    if (Convert.ToDecimal(row.Cells[valorprom.Name].Value) > 0 && Convert.ToDecimal(row.Cells[margp.Name].Value) > 0)
                    {
                        row.Cells[margp.Name].Value = textBox1.Text;
                        row.Cells[net.Name].Value = Decimal.Round(Convert.ToDecimal(row.Cells[valorprom.Name].Value) * (1 + (Convert.ToDecimal(row.Cells[margp.Name].Value) / 100)), decimales);
                        row.Cells[preciov.Name].Value = Decimal.Round(Convert.ToDecimal(row.Cells[net.Name].Value) * (1 + (Convert.ToDecimal(row.Cells[igv.Name].Value) / 100)), decimales);
                        row.Cells[PreciovSoles.Name].Value = Decimal.Round((Convert.ToDecimal(row.Cells[preciov.Name].Value) * Convert.ToDecimal(tipo.Venta)), decimales);
                    }
                    else
                    {
                        row.Cells[margp.Name].Value = 0;
                    }
                  }
            }
            else
            {
                cargadatas();
            }
            }

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (chbModificaMargen.Checked == true && textBox1.Text.Length > 0)
            {
                chbModificaMargen_CheckedChanged(sender, e);
            }else if (chbModificaMargen.Checked == false && textBox1.Text.Length > 0)
            {
                 chbModificaMargen.Enabled = true; }
            else { chbModificaMargen.Enabled = false;
            chbModificaMargen.Checked = false; cargadatas();
            }
        }

        private void dgvDetalleListaPrecio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDetalleListaPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                valor = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[valorprom.Name].Value);
                neto = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value);
                precion = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value);
                preciod = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value);

                if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "net" && txtedit.Text != "")
                {
                    dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = neto;
                    if (valor > 0)
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = Decimal.Round(((neto - valor)/valor)*100, decimales);
                    }
                    else
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                    }
                    dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = Decimal.Round(neto * (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                    precion = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value);
                    dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = Decimal.Round((precion * Convert.ToDecimal(tipo.Venta)), decimales);
                }
                if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "preciov" && txtedit.Text != "")
                {
                    dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = precion;
                    dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = Decimal.Round(precion * Convert.ToDecimal(tipo.Venta), decimales);
                    dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = Decimal.Round(precion / (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                    if (valor > 0)
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = Decimal.Round(((neto - valor) / valor) * 100, decimales);
                    }
                    else
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                    }
                }
                if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "PreciovSoles" &&
                    txtedit.Text != "")
                {
                    dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = preciod;
                    dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value =
                        Decimal.Round(preciod/Convert.ToDecimal(tipo.Venta), decimales);
                    dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value =
                        Decimal.Round(
                            precion/
                            (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value)/100)),
                            decimales);
                    if (valor > 0)
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value =
                            Decimal.Round(((neto - valor)/valor)*100, decimales);
                    }
                    else
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                    }
                }

                if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value) == "") { cargadatas(); }
                if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value) == "") { cargadatas(); }
                if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value) == "") { cargadatas(); }
                if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value) == "") { cargadatas(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void dgvDetalleListaPrecio_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtedit = e.Control as TextBox;
            if (txtedit != null)
            {
                txtedit.KeyPress -= new KeyPressEventHandler(dgvDetalleListaPrecio_KeyPress);
                txtedit.KeyPress += new KeyPressEventHandler(dgvDetalleListaPrecio_KeyPress);
                txtedit.Leave -= new EventHandler(dgvDetalleListaPrecio_Leave);
                txtedit.Leave += new EventHandler(dgvDetalleListaPrecio_Leave);
                txtedit.KeyUp -= new KeyEventHandler(dgvDetalleListaPrecio_KeyUp);
                txtedit.KeyUp += new KeyEventHandler(dgvDetalleListaPrecio_KeyUp);
            }
        }

        private void dgvDetalleListaPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvDetalleListaPrecio.CurrentCell.ColumnIndex == 7) //neto
                {
                    val.decimalesNegativos(sender,e);
                }

                if (dgvDetalleListaPrecio.CurrentCell.ColumnIndex == 8) //neto
                {
                    val.SOLONumeros(sender,e);
                }

                if (dgvDetalleListaPrecio.CurrentCell.ColumnIndex == 9)//precio venta
                {
                    val.SOLONumeros(sender, e);
                }

                if (dgvDetalleListaPrecio.CurrentCell.ColumnIndex == 10)//precio venta soles
                {
                    val.SOLONumeros(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);

            }
        }

        private void dgvDetalleListaPrecio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvDetalleListaPrecio.CurrentRow.Cells[Modificar.Name].Value) == 1)
                {
                    valor = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[valorprom.Name].Value);
                    neto = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value);
                    precion = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value);
                    preciod = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value);

                    if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "net" && txtedit.Text != "")
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = neto;
                        if (valor > 0)
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = Decimal.Round(((neto - valor) / valor) * 100, decimales);
                        }
                        else
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                        }
                        dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = Decimal.Round(neto * (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                        precion = Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value);
                        dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = Decimal.Round((precion * Convert.ToDecimal(tipo.Venta)), decimales);
                    }
                    else if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "preciov" && txtedit.Text != "")
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = precion;
                        dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = Decimal.Round(precion * Convert.ToDecimal(tipo.Venta), decimales);
                        dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = Decimal.Round(precion / (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                        if (valor > 0)
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = Decimal.Round(((neto - valor) / valor) * 100, decimales);
                        }
                        else
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                        }
                    }
                    else if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "PreciovSoles" && txtedit.Text != "")
                    {
                        dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = preciod;
                        dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = Decimal.Round(preciod / Convert.ToDecimal(tipo.Venta), decimales);
                        dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = Decimal.Round(precion / (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                        if (valor > 0)
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = Decimal.Round(((neto - valor) / valor) * 100, decimales);
                        }
                        else
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                        }
                    }
                    else if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "margp" && txtedit.Text != "")
                    {
                        if (valor > 0)
                        {
                            tipo = admTipo.CargaTipoCambio(DateTime.Now, 2);
                            dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = Decimal.Round(Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[valorprom.Name].Value) * (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value) / 100)), decimales);
                            dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = Decimal.Round(Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value) * (1 + (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[igv.Name].Value) / 100)), decimales);
                            dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = Decimal.Round((Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value) * Convert.ToDecimal(tipo.Venta)), decimales);
                        }
                        else
                        {
                            dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value = 0;
                            dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value = 0;
                            dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value = 0;
                            dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value = 0;
                        }

                    }
                    if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].Value) == "") { cargadatas(); }
                    if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value) == "") { cargadatas(); }
                    if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value) == "") { cargadatas(); }
                    if (Convert.ToString(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value) == "") { cargadatas(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void dgvDetalleListaPrecio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDetalleListaPrecio.CurrentRow.Cells[Modificar.Name].Value) == 1)
            {
                dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].ReadOnly = false;
                dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].ReadOnly = false;
                dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].ReadOnly = false;
                dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].ReadOnly = false;
            }
            else
            {
                dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].ReadOnly = true;
                dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].ReadOnly = true;
                dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].ReadOnly = true;
                dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].ReadOnly = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.decimalesNegativos(sender,e);
        }

        private void dgvDetalleListaPrecio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            cargadatas();
        }
        private void txtRProduc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtRProduc1.Text != "")
                {
                    if (BuscaProducto(txtRProduc1.Text,"1"))
                    {
                        ProcessTabKey(true);
                    }
                }
            }
        }
        private Boolean BuscaProducto(String txtPro, String cajatxt)
        {
            prod = admProd.CargaProductoDetalleR(txtPro, frmLogin.iCodAlmacen, 1, 0);
            if (prod != null)
            {
               if(cajatxt=="1"){
                    txtRProduc1.Text = prod.Referencia;
                    txtRango1.Text = prod.Descripcion;
                    txtCodPro1.Text = prod.CodProducto.ToString();
                    return true;
                }
                else
                {
                   txtRProduc2.Text = prod.Referencia;
                    txtRango2.Text = prod.Descripcion;
                    txtCodPro2.Text = prod.CodProducto.ToString();
                return true;
                }
            }
            else
            {
                MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void txtRProduc2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtRProduc2.Text != "")
                {
                    if (BuscaProducto(txtRProduc2.Text, "2"))
                    {
                        ProcessTabKey(true);
                    }
                }
            }
        }

        private void dgvDetalleListaPrecio_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dgvDetalleListaPrecio_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToInt32(dgvDetalleListaPrecio.CurrentRow.Cells[Modificar.Name].Value) == 1)
            {
                if (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value) == 0 && Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value) == 0 &&
                    Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value) == 0 && codlista > 1)
                {
                    dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].ReadOnly = true;

                    if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "margp" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "net" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "preciov" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "PreciovSoles")
                    {
                        MessageBox.Show("No puede Modificar. No hay una Lista de Precios Base!!" + Environment.NewLine +
                                "Lista Base:[CONTADO]", "Lista de Precios", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvDetalleListaPrecio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDetalleListaPrecio.CurrentRow.Cells[Modificar.Name].Value) == 1)
            {
                if (Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].Value) == 0 && Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].Value) == 0 &&
                    Convert.ToDecimal(dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].Value) == 0 && codlista > 1)
                {
                    dgvDetalleListaPrecio.CurrentRow.Cells[margp.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[net.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[preciov.Name].ReadOnly = true;
                    dgvDetalleListaPrecio.CurrentRow.Cells[PreciovSoles.Name].ReadOnly = true;

                    if (dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "margp" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "net" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "preciov" ||
                    dgvDetalleListaPrecio.Columns[dgvDetalleListaPrecio.CurrentCell.ColumnIndex].Name == "PreciovSoles")
                    {
                        MessageBox.Show("No puede Modificar. No hay una Lista de Precios Base!!" + Environment.NewLine +
                                "Lista Base:[CONTADO]", "Lista de Precios", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
            }
        }


        //private void dgvDetalleListaPrecio_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    if (dgvDetalleListaPrecio.Rows.Count >= 1)
        //    {
        //        textBox1.Enabled = true;
        //    }
        //    else
        //    {
        //        textBox1.Enabled = false;
        //    }
        //}

    }
}
