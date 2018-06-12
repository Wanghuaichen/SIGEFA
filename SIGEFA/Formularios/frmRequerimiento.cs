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
    public partial class frmRequerimiento : DevComponents.DotNetBar.Office2007Form
    {
        public List<clsDetalleRequerimiento> detalle1 = new List<clsDetalleRequerimiento>(); 
        clsDetalleRequerimiento deta1 = new clsDetalleRequerimiento();
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsAdmRequerimiento AdmRequer = new clsAdmRequerimiento();
        clsRequerimiento Ord = new clsRequerimiento();
        public List<Int32> config = new List<Int32>();
        public List<clsDetalleRequerimiento> detalle = new List<clsDetalleRequerimiento>();        
        public Int32 CodProveedor;
        public Int32 CodRequer, CodDetalleRequer, CodProduct;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta
        public Int32 Procede = 0; //(10) Orden de Compra 
        public Int32 proc = 0, proce=0;
        public Int32 Tipo;
        public Int32 CodDocumento;
        public Int32 CodSerie,num;
        public List<Int32> codProd = new List<int>();
        public DataTable data = new DataTable();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
         List<Int32> eliminados=new List<int>();
        public frmRequerimiento()
        {
            InitializeComponent();
        }
      
        private Boolean BuscaSerie()
        {
            ser = Admser.BuscaSerie(txtSerie.Text, CodDocumento, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                num = ser.Numeracion;
                return true;
            }
            else
            {
                CodSerie = 0;
                num = 0;
                return false;
            }

        }
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
                    num = ser.Numeracion;
                    if (CodSerie != 0)
                    {
                        txtcodserie.Text = ser.CodSerie.ToString();
                        txtSerie.Text = ser.Serie;
                    }
                    if (CodSerie != 0) { ProcessTabKey(true); }
                }
            }
            //if (txtcomentario.Text == "")
            //{
            //    txtcomentario.Focus();
            //}
            else {
                btnGuardar.Enabled = true;
            }

        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {

        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
               txtSerie.Focus();
            }
            else
            {
                
                if (Validacion)
                {
                    btnDetalle.Enabled = true;
                }
            }
        }

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            codProd.Clear();
            RecorreDetalle();
            if (Application.OpenForms["frmDetalleGuia"] != null)
            {
                Application.OpenForms["frmDetalleGuia"].Activate();
            }
            else
            {
                frmDetalleGuia form = new frmDetalleGuia();
                form.Procede = 11;
                form.Proceso = 1;
                proce = 1;
                form.Text = "Detalle de Productos";
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        codProd.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
                    }
                }
                else
                {
                    codProd.Add(0);
                }
                form.ShowDialog();
            }

            
        }

       
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            codProd.Clear();
            if (Application.OpenForms["frmDetalleGuia"] != null)
            {
                Application.OpenForms["frmDetalleGuia"].Activate();
            }
            else
            {
                frmDetalleGuia form = new frmDetalleGuia();
                form.Procede = 11;
                form.Proceso = 1;
                form.Text = "Detalle de Productos";
                if (btnNuevo.Text == "Agregar")
                {
                    proce = 3;// agregar registro editando
                }
                else
                {
                    proce = 1;
                }
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        codProd.Add(Convert.ToInt32(row.Cells[codproducto.Name].Value));
                    }
                }
                else
                {
                    codProd.Add(0);
                }
                form.ShowDialog();
            }
        }

     
        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            CodDocumento = 12;
            doc = Admdoc.CargaTipoDocumento(CodDocumento);
            txtCodDoc.Text = doc.CodTipoDocumento.ToString();
            txtDocRef.Text = doc.Sigla;
            lbDocumento.Text = doc.Descripcion;
            if (txtDocRef.Text == "")
            {
                txtSerie.Focus();
            }
            if (Proceso == 1)
            {
            }
            if (Proceso == 2)
            {
                CargaOrdenCompra();
            }
            else if (Proceso == 3)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
            else if (Proceso == 4)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
            else if (Proceso == 5)
            {
                CargaOrdenCompra();
                sololectura(true);
            }
        }

        private void sololectura(Boolean estado)
        {
            if (Tipo == 1)
            {
                btnNuevo.Text = "Agregar";
                btnEditar.Enabled = estado;
                btnNuevo.Enabled = estado;
                btnEliminar.Enabled = estado;
                btnGuardar.Enabled = estado;
            }
            else
            {
                btnEditar.Enabled = !estado;
                btnNuevo.Enabled = !estado;
                btnEliminar.Enabled = !estado;
                btnGuardar.Enabled = !estado;
            }
            txtDocRef.ReadOnly = !estado;
            txtSerie.ReadOnly = !estado;
            btnDetalle.Enabled = !estado;
            btnImprimir.Visible = estado;
        }
       
        private void CargaOrdenCompra()
        {
            try
            {
                Ord = AdmRequer.CargaRequerimiento(Convert.ToInt32(CodRequer));
                if (Ord != null)
                {
                    txtOrdenCompra.Text = Ord.CodRequerimiento.ToString().PadLeft(11, '0');

                    if (txtDocRef.Enabled)
                    {
                        CodDocumento = Ord.CodTipoDocumento;
                        txtDocRef.Text = Ord.SiglaDocumento;
                        lbDocumento.Text = Ord.DescripcionDocumento;
                    }
                    txtSerie.Text = Ord.Serie;
                    txtNumero.Text = Ord.NumDoc;
                    CodSerie = Ord.CodSerie;
                    dtpFechaOrden.Value = Ord.FechaOrden;
                    txtcomentario.Text = Ord.Comentario;
                    txtComentarioRechazado.Text = Ord.comentarioRechazado;
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmRequerimiento frm = new frmRequerimiento();
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource = AdmRequer.CargaDetalle(Convert.ToInt32(CodRequer));
            data = (DataTable)dgvDetalle.DataSource;
            RecorreDetalle();
            Ord.Detalle = detalle;
        }

        private void txtCodProv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmProveedoresLista"] != null)
                {
                    Application.OpenForms["frmProveedoresLista"].Activate();
                }
                else
                {
                    frmProveedoresLista form = new frmProveedoresLista();
                    form.Proceso = 3;
                    form.Procede = Procede;
                }
            }
        }

     
        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (superValidator2.Validate())
            {
                if (Proceso != 0)
                {
                    Ord.CodAlmacen = frmLogin.iCodAlmacen;
                    Ord.Comentario = txtcomentario.Text;
                    Ord.CodTipoDocumento = Convert.ToInt32(txtCodDoc.Text);
                    ser = Admser.BuscaSerie(txtSerie.Text, CodDocumento, frmLogin.iCodAlmacen);
                    Ord.CodSerie = CodSerie;
                    
                    
                    Ord.FechaOrden = dtpFechaOrden.Value.Date;
                    Ord.CodUser = frmLogin.iCodUser;
                    if (Proceso == 1)
                    {
                        //Ord.NumDoc = ser.Numeracion.ToString();
                        //txtNumero.Text = Ord.NumDoc.ToString();
                        if (AdmRequer.insert(Ord))
                        {

                            RecorreDetalle();
                            if (detalle.Count > 0)
                            {
                                foreach (clsDetalleRequerimiento det in detalle)
                                {
                                    AdmRequer.insertdetalle(det);
                                }
                            }
                            btnGuardar.Enabled = false;
                            MessageBox.Show("Los datos se guardaron correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CodRequer = Ord.CodRequerimientoNuevo;
                            CargaOrdenCompra();
                            sololectura(true);
                        }
                    }
                    else if (Proceso == 3)
                    {
                        if (AdmRequer.update(Ord))
                        {
                            RecorreDetalle();
                            if (detalle.Count > 0)
                            {
                                foreach (clsDetalleRequerimiento det in detalle)
                                {
                                    if (det.CodDetalleRequerimiento == 0)
                                    {
                                        AdmRequer.insertdetalle(det);
                                    }
                                    else
                                    {
                                        AdmRequer.updatedetalle(det);
                                    }

                                    
                                }
                                if (eliminados.Count > 0)
                                {
                                    foreach (Int32 x in eliminados)
                                    {
                                        AdmRequer.deletedetalle(x);
                                    }

                                }

                                MessageBox.Show("Los datos se actualizaron correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Tipo = 2;
                                CargaOrdenCompra();
                                sololectura(true);
                                //btnGuardar.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void RecorreDetalle()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle(row);
                }
            }
        }
        private void RecorreDetalle1()
        {
            detalle1.Clear();
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                {
                    añadedetalle1(row);
                }
            }

        }
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleRequerimiento deta =new clsDetalleRequerimiento();
            if (Proceso == 3)
            {
                deta.CodDetalleRequerimiento = Convert.ToInt32(fila.Cells[coddetalle.Name].Value.ToString());
                deta.CodRequerimiento = Convert.ToInt32(Ord.CodRequerimiento);
            }
            else
            {
                deta.CodRequerimiento = Convert.ToInt32(Ord.CodRequerimientoNuevo);
            }
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.Unidad = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta.CodUser = frmLogin.iCodUser;
            detalle.Add(deta);
        }

        private void añadedetalle1(DataGridViewRow fila)
        {
            if (Proceso == 3)
            {
                deta1.CodDetalleRequerimiento = Convert.ToInt32(fila.Cells[coddetalle.Name].Value.ToString());
                deta1.CodRequerimiento = Convert.ToInt32(Ord.CodRequerimiento);
            }
            else
            {
                deta1.CodRequerimiento = Convert.ToInt32(Ord.CodRequerimientoNuevo);
            }
            deta1.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta1.Unidad = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta1.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            deta1.CodUser = frmLogin.iCodUser;
            detalle1.Add(deta1);
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 && dgvDetalle.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDetalle.SelectedRows[0];
                if (Application.OpenForms["frmDetalleGuia"] != null)
                {
                    Application.OpenForms["frmDetalleGuia"].Activate();
                }
                else
                {
                    frmDetalleGuia form = new frmDetalleGuia();
                    form.Procede = 11;
                    proce = 2;
                    form.Proceso = 3;
                    form.txtReferencia.Text = row.Cells[referencia.Name].Value.ToString();
                    form.txtUnidad.Text = row.Cells[unidad.Name].Value.ToString();
                    form.txtReferencia.Enabled=false;
                    form.txtCodUnidad.Text = row.Cells[codunidad.Name].Value.ToString();
                    form.cmbUnidad.SelectedValue = Convert.ToInt32(row.Cells[codunidad.Name].Value);
                    form.txtDescripcion.Text = row.Cells[descripcion.Name].Value.ToString();
                    form.txtCantidad.Focus();
                    form.btnGuardar.Enabled = true;
                    RecorreDetalle1();
                    form.detalle = deta1;
                    form.txtCodigo.Text = row.Cells[codproducto.Name].Value.ToString();
                    form.txtCantidad.Text = row.Cells[cantidad.Name].Value.ToString();
                    form.ShowDialog();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0 && dgvDetalle.Rows.Count>=2)
            {
                if (Proceso == 1)
                {
                     DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (dlgResult == DialogResult.No)
                     {
                         return;
                     }
                     else
                     {
                         codProd.Remove(0);
                         codProd.Remove(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[codproducto.Name].Value));
                         dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

                       
                     }
                }

                else if (Proceso == 3)
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (CodDetalleRequer != 0 /*&& AdmRequer.deletedetalle(CodDetalleRequer)*/)
                        {
                            eliminados.Add(CodDetalleRequer);
                            //MessageBox.Show("Los datos han sido eliminado correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        codProd.Remove(0);
                        codProd.Remove(CodProduct);
                        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("Verifique, El Detalle no puede ser vacio");
            }
        }

      
        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0 && e.ControlToValidate.Visible)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator7_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void txtcomentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtcodserie.Text != "") { btnGuardar.Enabled = true; }
        }

        private void txtcomentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void customValidator8_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator9_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if(dgvDetalle.Rows.Count>0)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.CodCotizacion = Convert.ToInt32(txtOrdenCompra.Text);//codigo del requerimiento
            frm.tipo = 2;
            frm.ShowDialog(); 
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (Proceso == 3)
            { 
                if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
                {
                    CodDetalleRequer = Convert.ToInt32(e.Row.Cells[coddetalle.Name].Value);
                    CodProduct = Convert.ToInt32(e.Row.Cells[codproducto.Name].Value);
                }
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
