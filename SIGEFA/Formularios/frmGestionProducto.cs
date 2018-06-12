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
    public partial class frmGestionProducto : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //
        public Int32 Funcion = 0; //(3)consulta
        clsAdmProducto admPro = new clsAdmProducto();
        clsAdmTipoArticulo admTip = new clsAdmTipoArticulo();
        clsAdmFamilia admFam = new clsAdmFamilia();
        clsAdmLinea admLin = new clsAdmLinea();
        clsAdmGrupo admGru = new clsAdmGrupo();
        clsAdmMarca admMar = new clsAdmMarca();
        clsAdmUnidad admUni = new clsAdmUnidad();
        clsAdmCaracteristica admCar = new clsAdmCaracteristica();
        clsAdmVariante admVar = new clsAdmVariante();
        clsAdmUsuario admUsu = new clsAdmUsuario();
        public clsProducto pro = new clsProducto();
        public clsUsuario usu = new clsUsuario();
        clsCaracteristicaProducto carpro = new clsCaracteristicaProducto();
        clsNotaProducto notapro = new clsNotaProducto();
        clsUnidadEquivalente equi = new clsUnidadEquivalente();
        clsConsultasExternas ext = new clsConsultasExternas();
        Boolean Validacion = true;
        Double IGV = frmLogin.Configuracion.IGV;

        public frmGestionProducto()
        {
            InitializeComponent();
        }

        private void frmGestionProducto_Load(object sender, EventArgs e)
        {
            CargaTipoArticulos();
            CargaFamilias();
            CargaUnidades(cmbUnidadBase);
            CargaMarcas();
            CargaCaracteristicas();
            CargaListaCaracteristicas();
            CargaListaEquivalencias();
            CargaProducto();
            CargaListaNotas();
            CargaStockProducto();
            CargaProductosProveedor();
            if (Funcion == 3)
            {
                sololectura();
            }            
        }

        private void sololectura()
        {
            ext.sololectura(tabPage1.Controls);
            ext.sololectura(tabPage2.Controls);
            ext.sololectura(tabPage3.Controls);
            ext.sololectura(tabPage4.Controls);
            ext.sololectura(tabPage5.Controls);
            ext.sololectura(tabPage6.Controls);
            ext.sololectura(tabPage7.Controls);
            ext.sololectura(tabPage8.Controls);
            ext.sololectura(tabPage9.Controls);           
            ext.sololectura(tabPage11.Controls);
            ext.sololectura(groupBox1.Controls);
            btnAceptar.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0 && txtNombre.Text != "")
            {
                Validacion = true;
                ValidarDatos(this.Controls);
                if (Validacion)
                {
                    pro.CodUsuario = frmLogin.iCodUser;

                    if(rdtGravado.Checked == true && rdtExonerado.Checked == false && rdtInafecto.Checked == false)
                    {
                        pro.TipoImpuesto = 1;
                        pro.CodSunat = "10";
                    }
                    else if(rdtGravado.Checked == false && rdtExonerado.Checked == true && rdtInafecto.Checked == false)
                    {
                        pro.TipoImpuesto = 2;
                        pro.CodSunat = "20";
                    }
                    else if(rdtGravado.Checked == false && rdtExonerado.Checked == false && rdtInafecto.Checked == true)
                    {
                        pro.TipoImpuesto = 3;
                        pro.CodSunat = "30";
                    }
                    
                    pro.Detraccion = cbDetraccion.Checked;
                    pro.ValorVenta = Convert.ToDouble(txtValorVenta.Text);
                    pro.PrecioProm = Convert.ToDecimal(txtPrecioCompra.Text);
                    pro.Recargo = Convert.ToDouble(txtRecargo.Text);
                    pro.PrecioVenta = Convert.ToDouble(txtPfinal.Text);
                    pro.Oferta = cbOferta.Checked;
                    if (txtPorcDscto.Text != "") { pro.PDescuento = Convert.ToDouble(txtPorcDscto.Text); }
                    if (txtMontoDscto.Text != "") { pro.MontoDscto = Convert.ToDouble(txtMontoDscto.Text);}
                    if (txtPrecioOferta.Text != "") { pro.PrecioOferta = Convert.ToDouble(txtPrecioOferta.Text); }
                    pro.PrecioVariable = cbPVariable.Checked;
                    if (txtDscto.Text != "") { pro.MaximoDscto = Convert.ToDouble(txtDscto.Text); }
                    if (txtStockMin.Text != "") { pro.StockMinimo = Convert.ToDouble(txtStockMin.Text); }
                    if (txtStockMax.Text != "") { pro.StockMaximo = Convert.ToDouble(txtStockMax.Text); }
                    if (txtStockRep.Text != "") { pro.StockReposicion = Convert.ToDouble(txtStockRep.Text); }
                    if (txtComision.Text != "") { pro.Comision = Convert.ToDecimal(txtComision.Text); } else { pro.Comision = 0; }
                    //Pro.Operaciones = Operaciones; 
                    if (Proceso == 1)
                    {
                        if (admPro.insertproductoalmacen(pro))
                        {
                            //Operaciones.LimpiarOperaciones(CodPro);
                            //foreach (Int32 formu in pro.Operaciones)
                            //{
                            //    Operaciones.GuargaOperacion(CodPro, formu);
                            //}
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (admPro.updateproductoalmacen(pro))
                        {
                            //acces.LimpiarAccesos(CodUsua);
                            //foreach (Int32 formu in usua.Formularios)
                            //{
                            //    acces.GuargaAcceso(CodUsua, formu);
                            //}
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar los datos", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos requeridos(*)", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

               
        }

        private void ValidarDatos(Control.ControlCollection Coleccion)
        {
            //Validacion = true;
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

        private void CargaProducto()
        {
            pro = admPro.CargaProducto(pro.CodProducto, frmLogin.iCodAlmacen);
            if (pro.PrecioProm == 0) { txtPrecioCompra.Enabled = true; Proceso = 1; } else { txtPrecioCompra.Enabled = false; Proceso = 2; }
            txtCodProducto.Text = pro.CodProducto.ToString();
            txtReferencia.Text = pro.Referencia;
            txtNombre.Text = pro.Descripcion;
            txtFechaReg.Text = pro.FechaRegistro.ToShortDateString();
            txtModificacion.Text = pro.UltimaModificacion.ToShortDateString();
            usu = admUsu.MuestraUsuario(pro.CodUsuario);
            txtUsuario.Text = usu.Nombre;
            cbEstado.Checked = pro.Estado;
            cbTipoArticulo.SelectedValue = pro.CodTipoArticulo;
            cbFamilia.SelectedValue = pro.CodFamilia;
            CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
            cbLinea.SelectedValue = pro.CodLinea;
            CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            cbGrupo.SelectedValue = pro.CodGrupo;
            cbMarca.SelectedValue = pro.CodMarca;
            cmbUnidadBase.SelectedValue = pro.CodUnidadMedida;
            cbControlStock.SelectedIndex = (pro.CodControlStock - 1);
            switch (pro.TipoImpuesto)
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
            
            cbDetraccion.Checked = pro.Detraccion;
            txtComision.Text = Convert.ToString(pro.Comision);
            txtPrecioCata.Text = pro.PrecioCatalogo.ToString();
            txtPorRecibir.Text = pro.StockPorRecibir.ToString();
            txtStockFuturo.Text = pro.StockFuturo.ToString();
            txtStockActual.Text = pro.StockActual.ToString();
            if (Proceso == 2)
            {                
                txtPrecioCompra.Text = pro.PrecioProm.ToString();
                txtValorCompra.Text =  pro.ValorProm.ToString();
                txtRecargo.Text = pro.Recargo.ToString();
                txtValorVenta.Text = pro.ValorVenta.ToString();
                txtPfinal.Text = pro.PrecioVenta.ToString();
                cbOferta.Checked = pro.Oferta;
                if (pro.Oferta)
                {
                    txtPorcDscto.Text = pro.PDescuento.ToString();
                    txtMontoDscto.Text = pro.MontoDscto.ToString();
                    txtPrecioOferta.Text = pro.PrecioOferta.ToString();
                }
                txtDscto.Text = pro.MaximoDscto.ToString();
                cbPVariable.Checked = pro.PrecioVariable;
                
                txtStockDisponible.Text = pro.StockDisponible.ToString();
                if (pro.StockMaximo != 0) { cbStockMax.Checked = true; txtStockMax.Text =  pro.StockMaximo.ToString() ;} else { cbStockMax.Checked = false;}
                if (pro.StockMinimo != 0) { cbStockMin.Checked = true; txtStockMin.Text = pro.StockMinimo.ToString() ; } else { cbStockMin.Checked = false; }
                if (pro.StockReposicion != 0) { cbStockRep.Checked = true; txtStockRep.Text = pro.StockReposicion.ToString(); } else { cbStockRep.Checked = false; }                
            }

        }
        

        private void CargaTipoArticulos()
        {
            cbTipoArticulo.DataSource = admTip.MuestraTipoArticulos();
            cbTipoArticulo.DisplayMember = "descripcion";
            cbTipoArticulo.ValueMember = "codTipoArticulo";
            cbTipoArticulo.SelectedIndex = -1;
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

        private void CargaUnidades(ComboBox combo)
        {
            combo.DataSource = admUni.MuestraUnidades();
            combo.DisplayMember = "descripcion";
            combo.ValueMember = "codUnidadMedida";
            combo.SelectedIndex = -1;
        }

        private void CargaCaracteristicas()
        {
            cbCaracteristica.DataSource = admCar.MuestraCaracteristicas();
            cbCaracteristica.DisplayMember = "descripcion";
            cbCaracteristica.ValueMember = "codCaracteristica";
            cbCaracteristica.SelectedIndex = -1;
        }

        public void CargaProductosProveedor()
        {
            dgvProxProducto.DataSource = admPro.MuestraProductosProveedor(pro.CodProducto, pro.CodAlmacen);            
        }

        private void CargaVariantes(int codCara)
        {
            cbVariante.DataSource = admVar.MuestraVariantes(codCara);
            cbVariante.DisplayMember = "descripcion";
            cbVariante.ValueMember = "codVariante";
            cbVariante.SelectedIndex = -1;
        }

        private void cbFamilia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLineas(Convert.ToInt32(cbFamilia.SelectedValue));
            cbLinea.Enabled = true;
        }

        private void cbLinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaGrupos(Convert.ToInt32(cbLinea.SelectedValue));
            cbGrupo.Enabled = true;
        }

        private void txtRecargo_TextChanged(object sender, EventArgs e)
        {
            if (txtRecargo.Text != "")
            {

            }
        }

        private void txtRecargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtRecargo.Text != "" && txtPrecioCompra.Text != "")                {
                    
                    if (rdtGravado.Checked == true && rdtExonerado.Checked == false && rdtInafecto.Checked == false)
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100));
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text) / (1 + frmLogin.Configuracion.IGV / 100) * (1 + Convert.ToDouble(txtRecargo.Text) / 100));
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == true && rdtInafecto.Checked == false)                                            
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text));
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text) * (1 + Convert.ToDouble(txtRecargo.Text) / 100));
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == false && rdtInafecto.Checked == true)
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text));
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text) * (1 + Convert.ToDouble(txtRecargo.Text) / 100));
                    }
                }
                ProcessTabKey(true);
            }
        }

        private void txtPsinIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtValorVenta.Text != "" && txtPrecioCompra.Text != "")
                {                    
                    if (rdtGravado.Checked == true && rdtExonerado.Checked == false && rdtInafecto.Checked == false)                                            
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == true && rdtInafecto.Checked == false)                                            
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == false && rdtInafecto.Checked == true)
                    {
                        txtPfinal.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorVenta.Text));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                }
                ProcessTabKey(true);
            }
        }
        private void txtPfinal_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtPfinal.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(txtPfinal.Text));
                if (txtPfinal.Text != "" && txtPrecioCompra.Text != "")
                {
                    if (rdtGravado.Checked == true && rdtExonerado.Checked == false && rdtInafecto.Checked == false)                        
                    {
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text) / (1 + IGV / 100));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == true && rdtInafecto.Checked == false)
                    {
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                    else if (rdtGravado.Checked == false && rdtExonerado.Checked == false && rdtInafecto.Checked == true)
                    {
                        txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text));
                        txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    }
                    
                }
                ProcessTabKey(true);
            }
        }

        private void cbOferta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOferta.Checked)
            {
                txtPrecioOferta.Enabled = true;
                txtPorcDscto.Enabled = true;
                txtMontoDscto.Enabled = true;

            }
            else
            {
                txtPrecioOferta.Enabled = false;
                txtPrecioOferta.Text = "";
                txtPorcDscto.Enabled = false;
                txtPorcDscto.Text = "";
                txtMontoDscto.Enabled = false;
                txtMontoDscto.Text = "";
            }
        }

        private void cmbUnidadBase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.GetItemText(c.SelectedItem);
            label15.Text = c.GetItemText(c.SelectedItem) + "(S)";            
        }

        private void cbCaracteristica_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaVariantes(Convert.ToInt32(cbCaracteristica.SelectedValue));
            if (cbCaracteristica.SelectedIndex != -1)
            {
                if (cbVariante.Items.Count >= 1)
                {
                    cbVariante.Enabled = true;
                    txtVariante.Enabled = false;
                }
                else
                {
                    txtVariante.Enabled = true;
                    cbVariante.Enabled = false;
                }
            }
            else
            {
                cbVariante.Enabled = false;
                txtVariante.Enabled = false;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cbCaracteristica.SelectedIndex != -1 && (cbVariante.SelectedIndex != -1 || txtVariante.Text != ""))
            {
                carpro.CodCaracteristica = Convert.ToInt32(cbCaracteristica.SelectedValue);
                carpro.CodProducto = Convert.ToInt32(pro.CodProducto);
                carpro.Valor = cbVariante.Text;
                carpro.CodUser = frmLogin.iCodUser;

                if (admPro.insertcaracteristica(carpro))
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaListaCaracteristicas();
                }
            }
        }

        private void CargaListaCaracteristicas()
        {
            dgvCaracteristicas.DataSource = admPro.MuestraCaracteristicas(pro.CodProducto);
        }

        private void CargaListaNotas()
        {
            dgvNotas.DataSource = admPro.MuestraNotas(pro.CodProducto);
            dgvNotas.ClearSelection();
        }

        private void CargaStockProducto()
        {
            dgvAlmacenes.DataSource = admPro.StockProductoAlmacenes(frmLogin.iCodEmpresa, pro.CodProducto);
        }

        private void CargaListaEquivalencias()
        {
            dgvEquivalentes.DataSource = admPro.MuestraUnidadesEquivalentes(pro.CodProducto,frmLogin.iCodAlmacen);
        }


        private void btnremove_Click(object sender, EventArgs e)
        {
            if (dgvCaracteristicas.CurrentRow.Index != -1 && carpro.CodCaracteristicaProducto != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Caracteristicas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admPro.deletecaracteristica(carpro.CodCaracteristicaProducto))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Caracteristicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaListaCaracteristicas();
                    }
                }
            }
        }

       

        private void txtPrecioOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPfinal.Text != "" && txtPrecioOferta.Text != "")
                {
                    txtPorcDscto.Text = String.Format("{0:#,##0.00}", (1 - (Convert.ToDouble(txtPrecioOferta.Text) / Convert.ToDouble(txtPfinal.Text)))*100);
                    txtMontoDscto.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPrecioOferta.Text) - Convert.ToDouble(txtPfinal.Text)));
                }
                ProcessTabKey(true);
            }
        }

        

        private void txtPorcDscto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {                
                if (txtPfinal.Text != "" && txtPorcDscto.Text != "")
                {                    
                    txtPrecioOferta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text) * (1 - (Convert.ToDouble(txtPorcDscto.Text)/100)));
                    txtMontoDscto.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPrecioOferta.Text) - Convert.ToDouble(txtPfinal.Text)));                    
                }
                ProcessTabKey(true);
            }
        }

        private void txtPrecioOferta_Leave(object sender, EventArgs e)
        {
            if (txtPfinal.Text != "" && txtPrecioOferta.Text != "")
            {
                txtPorcDscto.Text = String.Format("{0:#,##0.00}", (1 - (Convert.ToDouble(txtPrecioOferta.Text) / Convert.ToDouble(txtPfinal.Text))) * 100);
                txtMontoDscto.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPrecioOferta.Text) - Convert.ToDouble(txtPfinal.Text)));
            }
        }

        private void cbStockMin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockMin.Checked)
            {
                txtStockMin.Enabled = true;
            }
            else
            {
                txtStockMin.Enabled = false;
            }
        }

        private void cbStockMax_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockMax.Checked)
            {
                txtStockMax.Enabled = true;
            }
            else
            {
                txtStockMax.Enabled = false;
            }
        }

        private void cbStockRep_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStockRep.Checked)
            {
                txtStockRep.Enabled = true;
            }
            else
            {
                txtStockRep.Enabled = false;
            }
        }


        private void txtMontoDscto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPfinal.Text != "" && txtMontoDscto.Text != "")
                {
                    txtPrecioOferta.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPfinal.Text) - Convert.ToDouble(txtMontoDscto.Text)));
                    txtPorcDscto.Text = String.Format("{0:#,##0.00}", (1 - (Convert.ToDouble(txtPrecioOferta.Text) / Convert.ToDouble(txtPfinal.Text))) * 100);                    
                }
            }
        }

        private void txtPorcDscto_TextChanged(object sender, EventArgs e)
        {            
            //if (txtPfinal.Text != "" && txtPorcDscto.Text != "")
            //{
            //    if (txtDscto.Text != "")
            //    {
            //        if (Convert.ToDouble(txtPorcDscto.Text) > Convert.ToDouble(txtDscto.Text))
            //        {
            //            txtPorcDscto.Text = txtDscto.Text;
            //        }
            //    }
            //    txtPrecioOferta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text) * (1 - (Convert.ToDouble(txtPorcDscto.Text) / 100)));
            //    txtMontoDscto.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPrecioOferta.Text) - Convert.ToDouble(txtPfinal.Text)));
            //}
        }

        private void txtDscto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtDscto.Text != "")
                {
                    if (Convert.ToDouble(txtPorcDscto.Text) > Convert.ToDouble(txtDscto.Text))
                    {
                        txtPorcDscto.Text = txtDscto.Text;
                    }
                }
            }
        }        

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            //if (cbConIGV.Checked)
            //{
            //    txtValorCompra.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text) / (1 + IGV / 100));
            //}
            //else
            //{
            //    txtValorCompra.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text));
            //}
        }

        private void CalculaGanancia ()
        {

            txtGanancia.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) - Convert.ToDouble(txtValorCompra.Text))*(1- (0.02)) );
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtValorCompra.Text != "")
                {
                    if (txtFlete.Text == "")
                    {
                        txtFlete.Text = "0.00";
                    }
                    //if (cbConIGV.Checked)
                    //{
                    //    txtPrecioCompra.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorCompra.Text) + Convert.ToDouble(txtFlete.Text)) * (1 + IGV / 100));
                    //}
                    //else
                    //{
                    //    txtPrecioCompra.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorCompra.Text) + Convert.ToDouble(txtFlete.Text));
                    //}
                    //if (cbConIGV.Checked)
                    //{
                    //    txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    //}
                    //else
                    //{
                    //    txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    //}
                }
                ProcessTabKey(true);
            }
        }

        private void txtValorCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtValorCompra.Text != "")
                {
                    if (txtFlete.Text == "")
                    {
                        txtFlete.Text = "0.00";
                    }
                    //if (cbConIGV.Checked)
                    //{
                    //    txtPrecioCompra.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorCompra.Text) + Convert.ToDouble(txtFlete.Text)) * (1 + IGV / 100));
                    //}
                    //else
                    //{
                    //    txtPrecioCompra.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtValorCompra.Text) + Convert.ToDouble(txtFlete.Text));
                    //}
                    //if (cbConIGV.Checked)
                    //{
                    //    txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    //}
                    //else
                    //{
                    //    txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                    //}
                }
                ProcessTabKey(true);
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPrecioCompra.Text != "")
                {
                    if (txtFlete.Text == "")
                    {
                        txtFlete.Text = "0.00";
                    }
                    if (rdtGravado.Checked)
                    {
                        txtValorCompra.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtPrecioCompra.Text) / (1 + IGV / 100)) - Convert.ToDouble(txtFlete.Text));
                    }
                    else
                    {
                        txtValorCompra.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPrecioCompra.Text) - Convert.ToDouble(txtFlete.Text));
                    }
                    if (txtPfinal.Text != "")
                    {
                        if (rdtGravado.Checked)
                        {
                            txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text) / (1 + IGV / 100));
                            txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) * (1 + IGV / 100) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                        }
                        else
                        {
                            txtValorVenta.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(txtPfinal.Text));
                            txtRecargo.Text = String.Format("{0:#,##0.00}", (Convert.ToDouble(txtValorVenta.Text) / Convert.ToDouble(txtPrecioCompra.Text) - 1) * 100);
                        }
                    }
                    ProcessTabKey(true);
                }
            }
        }

        private void btnOkU1_Click(object sender, EventArgs e)
        {
            if (cbUni1.SelectedIndex == -1) { MessageBox.Show("Seleccione Unidad", "Advertencia"); cbUni1.Focus(); return; }
            if (txtFactor1.Text.Equals("")) { MessageBox.Show("Ingrese factor de conversión", "Advertencia"); txtFactor1.Focus(); return; }
            if (cbUni1.SelectedIndex != -1 && txtFactor1.Text != "")
            {
                equi.CodProducto = Convert.ToInt32(pro.CodProducto);
                equi.CodUnidad = Convert.ToInt32(cbUni1.SelectedValue);
                equi.Factor = Convert.ToDecimal(txtFactor1.Text);
                equi.CodUser = frmLogin.iCodUser;

                if (admPro.insertunidadequivalente(equi))
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaListaEquivalencias();
                    btnCancel.PerformClick();
                }
            }
        }

        private void btnAñadirUnidad_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;            
            CargaUnidades(cbUni1);
            label15.Text = cmbUnidadBase.Text + "(S)";             
           
        }

        private void btnEliminarUnidad_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;            
            CargaUnidades(cbUni1);
            txtFactor1.Text = "";
            label15.Text = "Unidad";        
        }

        private void btnAddNota_Click(object sender, EventArgs e)
        {
            txtDescripcionNota.Text = "";
            txtDescripcionNota.ReadOnly = false;
            btnSaveNota.Enabled = true;
        }

        private void btnDeleteNota_Click(object sender, EventArgs e)
        {
            if (dgvNotas.CurrentRow.Index != -1 && notapro.CodNotaProducto != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admPro.deletenota(notapro.CodNotaProducto))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Caracteristicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaListaNotas();
                        txtDescripcionNota.Text = "";                        
                        txtDescripcionNota.ReadOnly = true;
                        notapro.CodNotaProducto = 0;
                        btnSaveNota.Enabled = false;
                    }
                }
            }
        }

        private void dgvNotas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvNotas.Rows.Count >= 1 && e.Row.Selected)
            {
                notapro.CodNotaProducto = Convert.ToInt32(e.Row.Cells[codnotaproducto.Name].Value);
                txtDescripcionNota.Text = e.Row.Cells[nota.Name].Value.ToString();
            } 
        }

        private void dgvCaracteristicas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCaracteristicas.Rows.Count >= 1 && e.Row.Selected)
            {
                carpro.CodCaracteristicaProducto = Convert.ToInt32(e.Row.Cells[codCaract.Name].Value);
            }
        }

        private void btnSaveNota_Click(object sender, EventArgs e)
        {
            if (txtDescripcionNota.Text != "")
            {
                notapro.CodProducto = Convert.ToInt32(pro.CodProducto);
                notapro.Nota = txtDescripcionNota.Text;
                notapro.CodUser = frmLogin.iCodUser;                

                if (admPro.insertnota(notapro))
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaListaNotas();
                    txtDescripcionNota.Text = "";
                    txtDescripcionNota.ReadOnly = true;
                    notapro.CodNotaProducto = 0;
                    btnSaveNota.Enabled = false;
                }
            }
        }

        private void frmGestionProducto_Shown(object sender, EventArgs e)
        {            
            tabControl1.Controls.Remove(tabPage5);
            tabControl1.Controls.Remove(tabPage3);
            //tabControl1.Controls.Remove(tabPage2);
            tabControl1.Controls.Remove(tabPage8);

        }

        private void lnkListasPrecios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtStockActual.Text == "")
            {
            }
            else
            {
                //frmListasPorProducto frm = new frmListasPorProducto();
                frmUnidadEquivalente frm = new frmUnidadEquivalente();
                frm.codProd = pro.CodProducto;
                frm.ShowDialog();
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                btnCambioProv.Visible = true;
            }
            else btnCambioProv.Visible = false;
        }

        private void btnCambioProv_Click(object sender, EventArgs e)
        {
            frmCambioProveedor frm = new frmCambioProveedor();
            frm.CodProveedor = Convert.ToInt32(dgvProxProducto.CurrentRow.Cells[codigo.Name].Value);
            frm.CodProducto = Convert.ToInt32(txtCodProducto.Text);
            frm.Procede = 1;
            frm.Proceso = 2;
            frm.ShowDialog();
        }

        
    }

        
    

       
}
