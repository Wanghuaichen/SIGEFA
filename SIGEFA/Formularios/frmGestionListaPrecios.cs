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
    public partial class frmGestionListaPrecios : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsFormaPago fpago = new clsFormaPago();
        clsAdmListaPrecio AdmLista = new clsAdmListaPrecio();
        clsListaPrecio origen = new clsListaPrecio();
        clsConsultasExternas ext = new clsConsultasExternas();
        public clsListaPrecio lista = new clsListaPrecio();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Buscar Ingreso (4) Buscar Salida
        clsValidar ok = new clsValidar();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public Int32 CodListaOrigen = 0;


        public frmGestionListaPrecios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            ext.limpiar(groupBox2.Controls);
            
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            linkLabel1.Enabled = Estado;
            btnGuardar.Enabled = !Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnAnular.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            label15.Text = "";
            cmbRedondeo.SelectedIndex = -1;
            superValidator1.Validate();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void frmListaPrecios_Load(object sender, EventArgs e)
        {
            CargaFormaPagos();
            if (Proceso == 3)
            {
                CargaListas();                
                bloquearbotones();
            }
            else
            {
                CargaListas();
                label2.Text = "Codigo";
                label3.Text = "codigo";
            }
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
        }

        private void bloquearbotones()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnAnular.Visible = false;
            btnReporte.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            CargaLista();

        }

        private void CargaLista()
        {
            lista = AdmLista.CargaListaPrecio(lista.CodListaPrecio);
            if (lista != null)
            {
                txtCodigo.Text = lista.CodListaPrecio.ToString();
                txtNombre.Text = lista.Nombre;
                cbPrecioProm.Checked = lista.PrecioProm;
                if (!lista.PrecioProm)
                {
                    txtListaOrigen.Text = lista.ListaOrigen.ToString();
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    txtListaOrigen_KeyPress(txtListaOrigen, ee);
                    txtVariacion.Text = lista.Variacion.ToString();                    
                }
                cbMargenProv.Checked = lista.MargenProv;
                if (!lista.MargenProv)
                {
                    txtMargen.Text = lista.Margen.ToString();
                }
                cbRedondear.Checked = lista.Redondear;
                cmbFormaPago.SelectedValue = lista.CodFormaPago;
                if (lista.Redondear)
                {
                    cmbRedondeo.SelectedIndex = lista.Decimales;
                }
                cbActualiza.Checked = lista.Update;
            }
            else
            {
                MessageBox.Show("No se encuentra la lista solicitada", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void CargaListas()
        {
            dgvListaPrecios.DataSource = data;
            data.DataSource = AdmLista.MuestraListas(frmLogin.iCodSucursal);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvListaPrecios.ClearSelection();
        }
       
        private void frmTransacciones_Shown(object sender, EventArgs e)
        {
            CargaListas();
            txtFiltro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                this.Close();
            }
            else
            {
                Proceso = 0;
                CambiarEstados(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                if (superValidator1.Validate())
                {
                    if (Proceso != 0)
                    {
                        lista.CodSucursal = frmLogin.iCodSucursal;
                        lista.Nombre = txtNombre.Text;
                        lista.PrecioProm = cbPrecioProm.Checked;
                        if (!cbPrecioProm.Checked) { lista.ListaOrigen = CodListaOrigen; lista.Variacion = Convert.ToDouble(txtVariacion.Text); } else { lista.ListaOrigen = 0; lista.Variacion = 0; }
                        lista.MargenProv = cbMargenProv.Checked;
                        if (!cbMargenProv.Checked && cbMargenProv.Enabled) { lista.Margen = Convert.ToDouble(txtMargen.Text); }
                        lista.Descuento1 = 0; lista.Descuento2 = 0; lista.Descuento3 = 0;
                        lista.CodFormaPago = Convert.ToInt32(cmbFormaPago.SelectedValue);
                        lista.Redondear = cbRedondear.Checked;
                        if (cbRedondear.Checked) { lista.Decimales = cmbRedondeo.SelectedIndex; } else { lista.Decimales = -1; }
                        lista.Update = cbActualiza.Checked;

                        if (Proceso == 1)
                        {
                            lista.CodUser = frmLogin.iCodUser;
                            if (AdmLista.insert(lista))
                            {
                                if (AdmLista.GeneraLista(lista.CodListaPrecio, frmLogin.iCodAlmacen,lista.Decimales))
                                {
                                    MessageBox.Show("Los datos se guardaron correctamente", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);                                    
                                }
                                else
                                {
                                    MessageBox.Show("No se generó correctamente la Lista de Precios", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                CambiarEstados(true);
                                CargaListas();
                                Proceso = 0;
                            }                            
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmLista.update(lista))
                            {
                                if (AdmLista.GeneraLista(lista.CodListaPrecio, frmLogin.iCodAlmacen, lista.Decimales))
                                {
                                    MessageBox.Show("Los datos se actualizaron correctamente", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    MessageBox.Show("No se actualizó correctamente la Lista de Precios", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                CambiarEstados(true);
                                CargaListas();
                                Proceso = 0;
                            }                              
                        }
                        //Proceso = 0;
                    }
                }
            }
            else if (btnGuardar.Text == "Aceptar")
            {
                if (Proceso == 3 || Proceso == 4)
                {
                    this.Close();
                }
            }
        }

       

        private void dgvTransacciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (!this.Visible)
                return;
            if (dgvListaPrecios.Rows.Count >= 1 && e.Row.Selected)
            {
                lista.CodListaPrecio = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                lista.Decimales = Convert.ToInt32(e.Row.Cells[decimales.Name].Value);
                lista.Nombre = e.Row.Cells[descripcion.Name].Value.ToString(); 
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAnular.Enabled = true;
                //if (Proceso == 3 || Proceso == 4)
                //{
                //    btnGuardar.Enabled = true;
                //}
            }
            else if (dgvListaPrecios.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnAnular.Enabled = false;
            }
        }  

        private void dgvListaPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (Proceso == 3)
            {
                this.Close();
            }
        }

        private void dgvListaPrecios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvListaPrecios.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvListaPrecios.Columns[e.ColumnIndex].DataPropertyName;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaPrecios.CurrentRow.Index != -1 && lista.CodListaPrecio != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Listas de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmLista.delete(lista.CodListaPrecio))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaListas();
                    }
                }
            }
        }

        private void dgvListaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {
                btnGuardar.Enabled = true;
            }
            if (dgvListaPrecios.Rows.Count >= 1 && e.RowIndex != -1)
            {
                if (dgvListaPrecios.Rows[e.RowIndex].Cells[anulado.Name].Value.ToString() == "ACTIVO")
                {
                    btnAnular.Text = "Anular";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 4;
                }
                else
                {
                    btnAnular.Text = "Activar";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 6;
                }
            }
        }
       

        private void cbPrecioProm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrecioProm.Checked)
            {
                txtVariacion.Enabled = false;
                txtListaOrigen.Enabled = false;
                cbMargenProv.Enabled = true;
                if (cbMargenProv.Checked)
                {
                    txtMargen.Enabled = false;
                    txtMargen.Text = "";
                }
                else
                {
                    txtMargen.Enabled = true;
                }
                txtListaOrigen.Text = "";
                txtVariacion.Text = "";
            }
            else
            {
                cbMargenProv.Enabled = false;
                txtMargen.Enabled = false;
                txtListaOrigen.Enabled = true;
                txtVariacion.Enabled = true;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 8;
            frm.ShowDialog();
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if(e.ControlToValidate.Enabled)
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void cbMargenProv_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMargenProv.Checked)
            {
                txtMargen.Enabled = false;
                txtMargen.Text = "";
            }
            else
            {
                txtMargen.Enabled = true;
            }
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRedondear.Checked)
            {
                cmbRedondeo.Enabled = true;
            }
            else
            {
                cmbRedondeo.Enabled = false;
            }
        }

        private void btnCalularPrecios_Click(object sender, EventArgs e)
        {
            if (lista != null)
            {
                if (AdmLista.GeneraLista(lista.CodListaPrecio, frmLogin.iCodAlmacen, lista.Decimales))
                {
                    MessageBox.Show("Se generó la lista de precios correctamente", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se generó correctamente la Lista de Precios", "Listas de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void txtListaOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtListaOrigen.Text != "")
                {
                    if (BuscaListaPrecio())
                    {
                        txtVariacion.Focus();
                        //ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El codigo buscado no existe", "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaListaPrecio()
        {
            origen = AdmLista.CargaListaPrecio(Convert.ToInt32(txtListaOrigen.Text));
            if (origen != null)
            {
                CodListaOrigen = origen.CodListaPrecio;
                txtListaOrigen.Text = origen.CodListaPrecio.ToString();
                label15.Text = origen.Nombre;
                label15.Visible = true;
                return true;
            }
            else
            {
                CodListaOrigen = 0;
                txtListaOrigen.Text = "";
                label15.Text = "";
                label15.Visible = false;
                return false;
            }
        }

        private void txtListaOrigen_Leave(object sender, EventArgs e)
        {

            if (txtListaOrigen.Text != "")
            {
                if (BuscaListaPrecio())
                {
                    txtVariacion.Focus();
                    //ProcessTabKey(true);
                }
                else
                {
                    MessageBox.Show("El codigo buscado no existe", "Lista de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtVariacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtMargen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.decimalesNegativos(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (dgvListaPrecios.Rows.Count >= 1 && dgvListaPrecios.SelectedRows.Count > 0)
            {
                frmListaPreciosProductos listapro = new frmListaPreciosProductos();
                if (Application.OpenForms["frmListaPreciosProductos"] != null)
                {
                    Application.OpenForms["frmListaPreciosProductos"].Activate();
                }
                else
                {
                    foreach (DataGridViewRow row in dgvListaPrecios.Rows)
                    {
                        listapro.decimales = lista.Decimales;
                        listapro.txtNombre.Text = lista.Nombre;
                        listapro.codlista = lista.CodListaPrecio;
                    }
                    listapro.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Seleccione Lista");
            }
        }

        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void txtListaOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmListaPrecios"] != null)
                {
                    Application.OpenForms["frmListaPrecios"].Activate();
                }
                else
                {
                    frmListaPrecios form = new frmListaPrecios();
                    form.ShowDialog();
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvListaPrecios.Rows.Count >= 1 && dgvListaPrecios.CurrentRow != null)
            {
                DataGridViewRow row = dgvListaPrecios.CurrentRow;
                if (btnAnular.Text == "Anular")
                {
                    if (dgvListaPrecios.CurrentRow.Index != -1 && lista.CodListaPrecio != 0)
                    {
                        DialogResult dlgResult =
                            MessageBox.Show("¿Esta seguro que desea anular la Lista de Precio seleccionada?",
                                "Listas de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            if (AdmLista.anular(frmLogin.iCodSucursal, lista.CodListaPrecio))
                            {
                                MessageBox.Show("La lista de precio ha sido anulada correctamente", "Listas de Precios",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaListas();
                            }
                        }
                    }
                }
                else if (btnAnular.Text == "Activar")
                {
                    if (dgvListaPrecios.Rows.Count >= 1 && dgvListaPrecios.CurrentRow.Index != -1 &&
                        lista.CodListaPrecio != 0)
                    {
                        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea activar esta Lista de Precio",
                            "Listas de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            if (AdmLista.activar(frmLogin.iCodSucursal, lista.CodListaPrecio))
                            {
                                MessageBox.Show("La lista de precio ha sido activada correctamente", "Listas de Precios",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaListas();
                            }
                        }
                    }
                }
            }
        }

        
        
    }
}
