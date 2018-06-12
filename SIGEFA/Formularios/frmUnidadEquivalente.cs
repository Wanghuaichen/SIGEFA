using System;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using System.Windows.Forms;

namespace SIGEFA.Formularios
{
    public partial class frmUnidadEquivalente : DevComponents.DotNetBar.Office2007Form
    {
        public frmUnidadEquivalente()
        {
            InitializeComponent();
        }

        clsAdmTipoPrecio admTp = new clsAdmTipoPrecio();
        clsAdmUnidad admUni = new clsAdmUnidad();
        clsAdmProducto admPro = new clsAdmProducto();
        clsAdmMoneda admmoneda = new clsAdmMoneda();
        clsAdmUnidad admunidad = new clsAdmUnidad();
        clsUnidadEquivalente equi = new clsUnidadEquivalente();
        clsValidar ok = new clsValidar();
        public clsProducto pro = new clsProducto();
        private TextBox txtedit = new TextBox();
        public Int32 codProd;
        public Int32 codunidad;
        public String UnidadB;
        public Int32 interrupto = 0;
        private Decimal precioIGV = 0;
        private Int32 codEquiVenta = 0;

        private void CargaUnidades(ComboBox combo)
        {
            combo.DataSource = admUni.MuestraUnidades();
            combo.DisplayMember = "descripcion";
            combo.ValueMember = "codUnidadMedida";
            combo.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbUnidad.Enabled = true;
            groupBox5.Visible = true;
            groupBox6.Visible = false;
            cbUni2.Enabled = true;
            txtFactor2.Enabled = true;
            txtPrecioUnidad.Text = "0.00";
            txtFactor2.Text = "0.00";
            CargaUnidades(cbUni2);
            CargaUnidades(cmbUnidad);
        }

        private void CargaListaEquivalencias()
        {
            pro.CodProducto = codProd;
            dataGridView2.DataSource = admPro.MuestraUnidadesEquivalentesCompra(pro.CodProducto, frmLogin.iCodAlmacen);
            dataGridView1.DataSource = admPro.MuestraUnidadesEquivalentesVenta1(pro.CodProducto, frmLogin.iCodAlmacen);
            dataGridView3.DataSource = admPro.MuestraUnidadesEquivalentes(pro.CodProducto, frmLogin.iCodAlmacen);

            //cmbUnidad.SelectedValue = codunidad;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox6.Visible = true;
            CargaUnidades(cbUni2);
            CargaUnidades(cmbUnidad);
            txtFactor2.Text = "";
        }
        Int32 proceso = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (proceso == 0)
            {
                if (txtFactor2.Text.Trim() == "") txtFactor2.Text = "0";
                if (txtPrecioUnidad.Text.Trim() == "") txtPrecioUnidad.Text = "0.00";
                if (cmbCompraVenta.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione Disponibilidad!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCompraVenta.Focus();
                }
                else
                {
                    if (cmbCompraVenta.SelectedIndex == 0) //COMPRA
                    {
                        if (cbUni2.SelectedIndex == -1 || Convert.ToDecimal(txtPrecioUnidad.Text) == 0 || comboBox1.SelectedIndex == -1)
                        {
                            MessageBox.Show("Ingrese datos correctamente!", "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            cbUni2.Focus();
                        }
                        else
                        {
                            equi.CodUnidad = Convert.ToInt32(cbUni2.SelectedValue);
                            txtFactor2.Text = 0.ToString();
                            equi.CodProducto = Convert.ToInt32(pro.CodProducto);
                            equi.Precio = Convert.ToDecimal(txtPrecioUnidad.Text);
                            equi.CodUser = frmLogin.iCodUser;
                            equi.Tipo = Convert.ToInt32(cmbTipo.SelectedValue);
                            equi.CodAlmacen = frmLogin.iCodAlmacen;
                            equi.CompraVenta = cmbCompraVenta.SelectedIndex;
                            //String moneda = comboBox1.SelectedValue.ToString();
                            //equi.ICodMoneda = this.CodMonedaxDescrip(moneda);
                            equi.ICodMoneda = Convert.ToInt32(comboBox1.SelectedValue);
                            btnSalir.Enabled = true;
                            if (admPro.insertunidadequivalente(equi))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaListaEquivalencias();
                                groupBox5.Visible = false;
                                groupBox6.Visible = true;
                            }
                        }
                    }
                    else if (cmbCompraVenta.SelectedIndex == 1) //VENTA
                    {
                        if (cbUni2.SelectedIndex == -1 || cmbTipo.SelectedIndex == -1 || comboBox1.SelectedIndex == -1 || 
                            Convert.ToDecimal(txtPrecioUnidad.Text) == 0)
                        {
                            MessageBox.Show("Ingrese datos correctamente!", "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            cbUni2.Focus();
                        }
                        else
                        {
                            equi.CodUnidad = Convert.ToInt32(cbUni2.SelectedValue);
                            txtFactor2.Text = 0.ToString();
                            equi.CodProducto = Convert.ToInt32(pro.CodProducto);
                            equi.Tipo = Convert.ToInt32(cmbTipo.SelectedValue);
                            equi.Precio = Convert.ToDecimal(txtPrecioUnidad.Text);
                            equi.CodUser = frmLogin.iCodUser;
                            equi.CodAlmacen = frmLogin.iCodAlmacen;
                            equi.CompraVenta = cmbCompraVenta.SelectedIndex;
                            //String moneda = comboBox1.SelectedValue.ToString();
                            //equi.ICodMoneda = this.CodMonedaxDescrip(moneda);
                            equi.ICodMoneda = Convert.ToInt32(comboBox1.SelectedValue);
                            btnSalir.Enabled = true;
                            if (admPro.insertunidadequivalente(equi))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Unidad Equivalencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //// modificaciones del bochi
                                Int32 validaMo = admunidad.ValidaMoneda();
                                if (validaMo > 0)
                                {
                                    Boolean resultado = admunidad.ActualizaPrecioEnDolares();
                                    //Int32 resultado2 = admunidad.CantidadProductosDolares();
                                    if (resultado == false)
                                    {
                                        MessageBox.Show("Error");
                                    }
                                }
                                //////////////// hasta aki
                                CargaListaEquivalencias();
                                groupBox5.Visible = false;
                                groupBox6.Visible = true;
                            }
                        }
                    }
                    else if (cmbCompraVenta.SelectedIndex == 2)
                    {
                        if (cbUni2.SelectedIndex == -1 || Convert.ToInt32(txtFactor2.Text) == 0 || cmbUnidad.SelectedIndex == -1 || comboBox1.SelectedIndex == -1)
                         {
                             MessageBox.Show("Ingrese datos correctamente!", "Advertencia", MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                             cbUni2.Focus();
                         }
                         else
                         {
                             equi.CodProducto = Convert.ToInt32(pro.CodProducto);
                             equi.CodEquivalente = Convert.ToInt32(cmbUnidad.SelectedValue);
                             equi.Precio = 0;
                             equi.Factor = Convert.ToDecimal(txtFactor2.Text);
                             equi.CodUser = frmLogin.iCodUser;
                             equi.Tipo = Convert.ToInt32(cmbTipo.SelectedValue);
                             equi.CodAlmacen = frmLogin.iCodAlmacen;
                             equi.CompraVenta = cmbCompraVenta.SelectedIndex;
                             //String moneda = comboBox1.SelectedValue.ToString();
                             //equi.ICodMoneda = this.CodMonedaxDescrip(moneda);
                             equi.ICodMoneda = Convert.ToInt32(comboBox1.SelectedValue);
                             btnSalir.Enabled = true;
                             if (admPro.insertunidadequivalente(equi))
                             {
                                 MessageBox.Show("Los datos se guardaron correctamente", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 CargaListaEquivalencias();
                                 groupBox5.Visible = false;
                                 groupBox6.Visible = true;
                             }
                         }
                     }
                }
            }
        }

        private Int32 CodMonedaxDescrip(String descripcion)
        {
            Int32 codigo = 0;
            try
            {
                codigo = admmoneda.BuscamonedaXdescripcion(descripcion);
                return codigo;
            }
            catch (Exception ex) {
                return 0;
            }
        }

        private void frmUnidadEquivalente_Load(object sender, EventArgs e)
        {
            CargaUnidades(cmbUnidad);
            cargaMoneda();
            CargaTipos();
            CargaListaEquivalencias();
            cmbTipo.Enabled = true;
            cmbUnidad.Enabled = true;
            cbUni2.Enabled = true;
            cmbCompraVenta.Enabled = true;
            cmbCompraVenta.SelectedIndex = -1;
            cbUni2.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
           
        }

        //Modifique el 02/07/2016
        private void cargaMoneda()
        {
            comboBox1.DataSource = admmoneda.ListaMonedas();
            comboBox1.ValueMember = "codMoneda";
            comboBox1.DisplayMember = "descripcion";
            comboBox1.SelectedIndex = -1;
        }

        private void CargaTipos()
        {
            cmbTipo.DataSource = admTp.listaPrecios();
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "codT";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Unidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    if (dataGridView1.RowCount > 0)
                    {

                        int cod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[codigo.Name].Value);
                        if (admPro.deleteunidadequivalente(cod))
                        {
                            MessageBox.Show("Los datos se Eliminaron correctamente", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaListaEquivalencias();
                            //groupBox5.Visible = true;
                            //groupBox6.Visible = false;

                        }
                    }
                }
            }
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Unidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    if (dataGridView2.RowCount > 0)
                    {

                        int cod = Convert.ToInt32(dataGridView2.CurrentRow.Cells[codi.Name].Value);
                        if (admPro.deleteunidadequivalente(cod))
                        {
                            MessageBox.Show("Los datos se Eliminaron correctamente", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaListaEquivalencias();
                            //groupBox5.Visible = true;
                            //groupBox6.Visible = false;

                        }
                    }
                }
            }
            else if (dataGridView3.SelectedRows.Count > 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Unidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    if (dataGridView3.RowCount > 0)
                    {

                        int cod = Convert.ToInt32(dataGridView3.CurrentRow.Cells[codtabla.Name].Value);
                        if (admPro.deleteunidadequivalente(cod))
                        {
                            MessageBox.Show("Los datos se Eliminaron correctamente", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaListaEquivalencias();
                            //groupBox5.Visible = true;
                            //groupBox6.Visible = false;

                        }
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtFactor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.NumerosDecimales(e, txtFactor2);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView3.ClearSelection();
        }

        private void cmbCompraVenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCompraVenta.SelectedIndex == 0)
            {
                label8.Visible = false;
                txtFactor2.Visible = false;
                txtFactor2.Enabled = false;
                cmbUnidad.Visible = false;
                cmbUnidad.Enabled = false;
                cmbTipo.SelectedValue = 9;
                lbPrecioCosto.Text = "Costo con IGV";
                //cmbTipo.Text = "COMPRA";
                cmbTipo.Enabled = false;
                txtPrecioUnidad.Visible = true;
                lbPrecioCosto.Visible = true;
            }
            if (cmbCompraVenta.SelectedIndex == 1)
            {
                label8.Visible = false;
                txtFactor2.Visible = false;
                txtFactor2.Enabled = false;
                cmbUnidad.Visible = false;
                cmbUnidad.Enabled = false;
                cmbTipo.Enabled = true;
                cmbTipo.SelectedIndex = -1;
                lbPrecioCosto.Text = "Precio con IGV";
                //cmbTipo.Text = "MAYOR";
                txtPrecioUnidad.Visible = true;
                lbPrecioCosto.Visible = true;
            }
            if (cmbCompraVenta.SelectedIndex == 2)
            {
                label8.Visible = true;
                txtFactor2.Visible = true;
                txtFactor2.Enabled = true;
                cmbUnidad.Visible = true;
                cmbUnidad.Enabled = true;
                txtPrecioUnidad.Visible = false;
                cmbTipo.SelectedValue = 9;
                //cmbTipo.Text = "COMPRA";
                cmbTipo.Enabled = false;
                lbPrecioCosto.Visible = false;
            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void cmbUnidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int UnidCompra = 0;
            if (cbUni2.SelectedIndex >= 0)
            {
                UnidCompra = admPro.getUnidadCompra(codProd);
                equi.CodUnidad = Convert.ToInt32(cbUni2.SelectedValue);
                if (equi.CodUnidad == UnidCompra)
                {
                    if (cmbUnidad.Text == UnidadB && interrupto == 0)
                    {
                        //MessageBox.Show("Gracias por Considerar La Unidad Basica: " + UnidadB, "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        interrupto++;
                    }
                    else if (interrupto == 0)
                    {
                        //MessageBox.Show("La Unidad Basica para este Producto es: " + UnidadB + Environment.NewLine + "Debe Usarla como la Unidad de Medida Minima en sus Equivalencias", "Unidad Equivalencia", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Seleccione Unidad", "Advertencia");
                cbUni1.Focus();
                return;
            }
        }

        private void txtPrecioUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.NumerosDecimales(e, txtPrecioUnidad);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                ok.SOLONumeros(sender, e);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtedit = e.Control as TextBox;
            if (txtedit != null)
            {
                txtedit.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
                txtedit.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                txtedit.KeyUp -= new KeyEventHandler(dataGridView1_KeyUp);
                txtedit.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
                txtedit.Leave -= new EventHandler(dataGridView1_Leave);
                txtedit.Leave += new EventHandler(dataGridView1_Leave);
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.RowCount > 0)
            {
                if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells[precios1.Name].Value) == 0)
                {
                    dataGridView1.CurrentRow.Cells[precios1.Name].Value = precioIGV;
                }
                else
                {
                    if (MessageBox.Show("¿Permitir modificar el precio de la unidad?", "Unidad Equivalencia",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 codEquiv = Convert.ToInt32(dataGridView1.CurrentRow.Cells[codigo.Name].Value);
                        precioIGV = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[precios1.Name].Value);
                        admPro.updateunidadequivalente(codEquiv, precioIGV);
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells[precios1.Name].Value = precioIGV;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.RowCount > 0)
            {
                precioIGV = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[precios1.Name].Value);
            }
        }
    }
}