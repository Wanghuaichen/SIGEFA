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
    public partial class frmRegistroProducto : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Usuario (2)Editar Usuario
        clsAdmProducto admPro = new clsAdmProducto();
        clsAdmTipoArticulo admTip = new clsAdmTipoArticulo();
        clsAdmFamilia admFam = new clsAdmFamilia();
        clsFamilia fam = new clsFamilia();
        clsAdmLinea admLin = new clsAdmLinea();
        clsLinea lin = new clsLinea();
        clsAdmGrupo admGru = new clsAdmGrupo();
        clsGrupo gru = new clsGrupo();
        clsAdmMarca admMar = new clsAdmMarca();
        clsAdmUnidad admUni = new clsAdmUnidad();
        public clsProducto pro = new clsProducto();
        Boolean Validacion = true;
        clsValidar val = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        clsUnidadEquivalente equi = new clsUnidadEquivalente();
        public static Int32 codtipo;
        public Int32 tipoimpuestosunat = 1;

        public frmRegistroProducto()
        {
            InitializeComponent();
        }

        private void frmRegistroProducto_Load(object sender, EventArgs e)
        {
            CargaTipoArticulos();
            CargaFamilias();
            CargaUnidades();
            CargaMarcas();
            if (Proceso == 2)
            {
                CargaProducto();
                if (cbLinea.SelectedIndex != -1)
                {
                    btnLinea.Enabled = true;
                }
                if (cbGrupo.SelectedIndex != -1)
                {
                    btnGrupo.Enabled = true;
                }
                txtPrecioCom.Visible = false;
                txtPrecioVen.Visible = false;
                lbLabelCompra.Visible = false;
                lbPrecioVenta.Visible = false;
            }
            else if (Proceso == 3)
            {
                CargaProducto();
                sololectura();
                txtPrecioCom.Visible = false;
                txtPrecioVen.Visible = false;
                lbLabelCompra.Visible = false;
                lbPrecioVenta.Visible = false;
            }          

        }

        private void sololectura()
        {
            ext.sololectura(groupBox1.Controls);
            btnGuardar.Visible = false;
        }

        private void CargaProducto()
        {
            pro = admPro.CargaProducto(pro.CodProducto,frmLogin.iCodAlmacen);
            txtCodProducto.Text = pro.CodProducto.ToString();
            txtReferencia.Text = pro.Referencia;
            txtNombre.Text = pro.Descripcion;
            cbEstado.Checked = pro.Estado;
            cbTipoArticulo.SelectedValue = pro.CodTipoArticulo;
            cbFamilia.SelectedValue = pro.CodFamilia;
            CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
            cbLinea.Enabled = true;
            cbLinea.SelectedValue = pro.CodLinea;
            CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            cbGrupo.Enabled = true;
            cbGrupo.SelectedValue = pro.CodGrupo;
            cbMarca.SelectedValue = pro.CodMarca;
            cmbUnidadBase.SelectedValue = pro.CodUnidadMedida;
            cbControlStock.SelectedIndex = (pro.CodControlStock-1);
            switch(pro.TipoImpuesto)
            {
                case 1:
                        rdtGravado.Checked = true;
                        rdtExonerado.Checked = false;
                        rdtInafecto.Checked = false;
                break;

                case 2:
                        rdtGravado.Checked = false;
                        rdtExonerado.Checked = true;
                        rdtInafecto.Checked = false;
                break;

                case 3:
                        rdtGravado.Checked = false;
                        rdtExonerado.Checked = false;
                        rdtInafecto.Checked = true;
                break;
            }
            
            //cbPrecioIGV.Checked = pro.ConIgv;
            cbDetraccion.Checked = pro.Detraccion;
            txtComision.Text = Convert.ToString(pro.Comision);
            txtPrecioCata.Text = pro.PrecioCatalogo.ToString();
            txtMaxPorcDesc.Text = pro.MaxPorcDesc.ToString();
            txtPeso.Text = pro.Peso.ToString();
        }


        private void CargaTipoArticulos()
        {
            cbTipoArticulo.DataSource = admTip.MuestraTipoArticulos();
            cbTipoArticulo.DisplayMember = "descripcion";
            cbTipoArticulo.ValueMember = "codTipoArticulo";
            cbTipoArticulo.SelectedIndex = 0;
        }

        private void CargaFamilias()
        {
            cbFamilia.DataSource = admFam.MuestraFamilias();
            cbFamilia.DisplayMember = "descripcion";
            cbFamilia.ValueMember = "codFamilia";
            cbFamilia.SelectedIndex = -1;
        }

        private void CargaLineas(int codFami)
        {
            cbLinea.DataSource = admLin.MuestraLineas(codFami);
            cbLinea.DisplayMember = "descripcion";
            cbLinea.ValueMember = "codLinea";
            cbLinea.SelectedIndex = -1;
        }

        private void CargaGrupos(int codLine)
        {
            cbGrupo.DataSource = admGru.MuestraGrupos(codLine);
            cbGrupo.DisplayMember = "descripcion";
            cbGrupo.ValueMember = "codGrupo";
            cbGrupo.SelectedIndex = -1;
        }

        private void CargaMarcas()
        {
            cbMarca.DataSource = admMar.MuestraMarcas();
            cbMarca.DisplayMember = "descripcion";
            cbMarca.ValueMember = "codMarca";
            cbMarca.SelectedIndex = -1;
        }

        private void CargaUnidades()
        {
            cmbUnidadBase.DataSource = admUni.MuestraUnidades();
            cmbUnidadBase.DisplayMember = "descripcion";
            cmbUnidadBase.ValueMember = "codUnidadMedida";
            cmbUnidadBase.SelectedIndex = -1;
        }

        private void ValidarDatos(Control.ControlCollection Coleccion)
        {
            Validacion = true;
            foreach (Control c in Coleccion)
            {
                if (Convert.ToInt32(c.Tag) == 1)
                {
                    if (c.Enabled == true && c.Text == "")
                    {
                        c.BackColor = Color.LightPink;
                        c.Focus();
                        Validacion = false;
                    }
                }
                if (c.HasChildren)
                {
                    ValidarDatos(c.Controls);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Proceso != 0 && txtNombre.Text != "")
                {
                    ValidarDatos(this.Controls);
                    if (Validacion)
                    {
                        pro.CodUsuario = frmLogin.iCodUser;
                        pro.CodTipoArticulo = Convert.ToInt32(cbTipoArticulo.SelectedValue);
                        pro.CodFamilia = Convert.ToInt32(cbFamilia.SelectedValue);
                        pro.CodLinea = Convert.ToInt32(cbLinea.SelectedValue);
                        pro.CodGrupo = Convert.ToInt32(cbGrupo.SelectedValue);
                        pro.CodMarca = Convert.ToInt32(cbMarca.SelectedValue);
                        pro.CodUnidadMedida = Convert.ToInt32(cmbUnidadBase.SelectedValue);
                        pro.CodControlStock = Convert.ToInt32(cbControlStock.SelectedIndex + 1);
                        pro.Referencia = txtReferencia.Text;
                        pro.Descripcion = txtNombre.Text;
                        pro.Estado = cbEstado.Checked;
                        if (rdtGravado.Checked == true && rdtExonerado.Checked == false && rdtInafecto.Checked == false)
                        {
                            pro.TipoImpuesto = 1;
                            pro.CodSunat = "10";
                        }
                        else if (rdtGravado.Checked == false && rdtExonerado.Checked == true && rdtInafecto.Checked == false)
                        {
                            pro.TipoImpuesto = 2;
                            pro.CodSunat = "20";
                        }
                        else if (rdtGravado.Checked == false && rdtExonerado.Checked == false && rdtInafecto.Checked == true)
                        {
                            pro.TipoImpuesto = 3;
                            pro.CodSunat = "30";
                        }
                       
                        if (cbDetraccion.Checked == true) { pro.Detraccion = true; }
                        else { pro.Detraccion = false; }
                        if (txtComision.Text != "") { pro.Comision = Convert.ToDecimal(txtComision.Text); } else { pro.Comision = 0; }
                        if (txtPrecioCata.Text != "") { pro.PrecioCatalogo = Convert.ToDecimal(txtPrecioCata.Text); } else { pro.PrecioCatalogo = 0; }

                        if (txtMaxPorcDesc.Text != "") { pro.MaxPorcDesc = Convert.ToDecimal(txtMaxPorcDesc.Text.Trim()); }
                        pro.Peso = Convert.ToDecimal(txtPeso.Text);



                        if (Proceso == 1)
                        {
                            if (admPro.insert(pro))
                            {
                                txtCodProducto.Text = pro.CodProducto.ToString();
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                GuardaUnidadesCompra();
                                GuardaUnidadesVenta();
                                GuardaUnidadesEquivalencia();

                                limpiarformulario(groupBox1.Controls);
                                this.Close();
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (admPro.update(pro))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos requeridos(*)", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GuardaUnidadesEquivalencia()
        {
            equi.CodProducto = Convert.ToInt32(txtCodProducto.Text);
            equi.CodEquivalente = Convert.ToInt32(cmbUnidadBase.SelectedValue);
            equi.Precio = 0;
            equi.Factor = 1;
            equi.CodUser = frmLogin.iCodUser;
            equi.Tipo = Convert.ToInt32(9);
            equi.CodAlmacen = frmLogin.iCodAlmacen;
            equi.CompraVenta = 2;
            equi.ICodMoneda = Convert.ToInt32(1);
            if (admPro.insertunidadequivalente(equi))
            {
            }
        }

        private void GuardaUnidadesVenta()
        {
            equi.CodUnidad = Convert.ToInt32(cmbUnidadBase.SelectedValue);
            equi.CodProducto = Convert.ToInt32(txtCodProducto.Text);
            equi.Tipo = Convert.ToInt32(10);
            equi.Precio = Convert.ToDecimal(txtPrecioVen.Text);
            equi.CodUser = frmLogin.iCodUser;
            equi.CodAlmacen = frmLogin.iCodAlmacen;
            equi.CompraVenta = 1;
            equi.ICodMoneda = Convert.ToInt32(1);
            if (admPro.insertunidadequivalente(equi))
            {

            }
        }

        private void GuardaUnidadesCompra()
        {
            equi.CodUnidad = Convert.ToInt32(cmbUnidadBase.SelectedValue);
            equi.CodProducto = Convert.ToInt32(txtCodProducto.Text);
            equi.Precio = Convert.ToDecimal(txtPrecioCom.Text);
            equi.CodUser = frmLogin.iCodUser;
            equi.Tipo = 9;
            equi.CodAlmacen = frmLogin.iCodAlmacen;
            equi.CompraVenta = 0;
            equi.ICodMoneda = 1;
            if (admPro.insertunidadequivalente(equi))
            {
            }
        }


        private void limpiarformulario(Control.ControlCollection Coleccion)
        {
            foreach (Control c in Coleccion)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }

                if (c.HasChildren)
                {
                    limpiarformulario(c.Controls);
                }
            }
        }

        

        private void cbFamilia_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            fam = admFam.CargaFamilia(Convert.ToInt32(cbFamilia.SelectedValue));
            CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
            CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            cbGrupo.Text = "";
            if (cbFamilia.SelectedIndex != -1)
            {
                cbLinea.Enabled = true;
                btnLinea.Enabled = true;
            }
            else
            {
                cbLinea.Enabled = false;
                btnLinea.Enabled = false;
            }
        }

        private void cbLinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //fam = admFam.CargaFamilia(Convert.ToInt32(cbFamilia.SelectedValue));
            lin = admLin.CargaLinea(Convert.ToInt32(cbLinea.SelectedValue));
            CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            if (cbLinea.SelectedIndex != -1)
            {
                cbGrupo.Enabled = true;
                btnGrupo.Enabled = true;
            }
            else
            {
                cbGrupo.Enabled = false;
                btnGrupo.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnTipoArticulo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTipoArticulos"] != null)
            {
                Application.OpenForms["frmTipoArticulos"].Activate();
            }
            else
            {
                frmTipoArticulos form = new frmTipoArticulos();
                //form.MdiParent = this;               
                form.ShowDialog();
                CargaTipoArticulos();
                cbTipoArticulo.SelectedValue = codtipo;
            }
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmFamilias"] != null)
            {
                Application.OpenForms["frmFamilias"].Activate();
            }
            else
            {
                frmFamilias form = new frmFamilias();
                //form.MdiParent = this;
                form.ShowDialog();
                CargaFamilias();
            }
        }

        private void btnLinea_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmLineas"] != null)
            {
                Application.OpenForms["frmLineas"].Activate();
            }
            else
            {
                frmLineas frm = new frmLineas();
                //frm.MdiParent = this.MdiParent;
                //frm.FamiliaSeleccionada = Convert.ToInt32(cbFamilia.SelectedValue);
                //frm.Cabecera = fam.Referencia + " " + fam.Descripcion;
                frm.fam = fam;
                frm.ShowDialog();
                CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
            }
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGrupo"] != null)
            {
                Application.OpenForms["frmGrupo"].Activate();
            }
            else
            {
                frmGrupo frm = new frmGrupo();
                //frm.MdiParent = this.MdiParent;
                //frm.LineaSeleccionada = Convert.ToInt32(cbLinea.SelectedValue);
                frm.lin = lin;
                frm.ShowDialog();
                CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMarcas"] != null)
            {
                Application.OpenForms["frmMarcas"].Activate();
            }
            else
            {
                frmMarcas form = new frmMarcas();
                //form.MdiParent = this;
                form.ShowDialog();
                CargaMarcas();
            }
        }

        private void btnUnidad_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmUnidades"] != null)
            {
                Application.OpenForms["frmUnidades"].Activate();
            }
            else
            {
                frmUnidades form = new frmUnidades();
                //form.MdiParent = this;
                form.ShowDialog();
                CargaMarcas();
            }
        }

        private void cbFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                fam = admFam.CargaFamilia(Convert.ToInt32(cbFamilia.SelectedValue));
                CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
                CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
                cbGrupo.Text = "";
                if (cbFamilia.SelectedIndex != -1)
                {
                    cbLinea.Enabled = true;
                    btnLinea.Enabled = true;
                }
                else
                {
                    cbLinea.Enabled = false;
                    btnLinea.Enabled = false;
                }
            }
        }

        private void cbLinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                lin = admLin.CargaLinea(Convert.ToInt32(cbLinea.SelectedValue));
                CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
                if (cbLinea.SelectedIndex != -1)
                {
                    cbGrupo.Enabled = true;
                    btnGrupo.Enabled = true;
                }
                else
                {
                    cbGrupo.Enabled = false;
                    btnGrupo.Enabled = false;
                }
            }
        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void txtPrecioCata_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void frmRegistroProducto_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }

        private void linkConfiguraUnidadesEquivalentes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmListasPorProducto frm = new frmListasPorProducto();
            frmUnidadEquivalente frm = new frmUnidadEquivalente();
            frm.codProd = pro.CodProducto;
            frm.ShowDialog();
        }

        private void rdtGravado_CheckedChanged(object sender, EventArgs e)
        {
            /*--------Mi codigo Fabio Requena-----*/
            if (rdtGravado.Checked)
            {
                tipoimpuestosunat = 1;
                rdtExonerado.Checked = false;
                rdtInafecto.Checked = false;
            }
        }

        private void rdtExonerado_CheckedChanged(object sender, EventArgs e)
        {
            /*--------Mi codigo Fabio Requena-----*/
            if (rdtExonerado.Checked)
            {
                tipoimpuestosunat = 2;
                rdtGravado.Checked = false;
                rdtInafecto.Checked = false;
            }
        }

        private void rdtInafecto_CheckedChanged(object sender, EventArgs e)
        {
            /*--------Mi codigo Fabio Requena-----*/
            if (rdtInafecto.Checked)
            {
                tipoimpuestosunat = 3;
                rdtGravado.Checked = false;
                rdtExonerado.Checked = false;
            }
        }

        private void txtPrecioVen_Leave(object sender, EventArgs e)
        {
            txtPrecioCata.Text = txtPrecioVen.Text;
        }  
    }
}
