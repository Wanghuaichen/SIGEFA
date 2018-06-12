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
    public partial class frmMetodoPago : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmMetodoPago AdmPago = new clsAdmMetodoPago();
        public clsMetodoPago pago = new clsMetodoPago();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)CONSULTA F1
        public Int32 Procedencia = 0; //(1)Nota Ingreso (2)Nota Salida 

        clsValidar ok = new clsValidar();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;


        public frmMetodoPago()
        {
            InitializeComponent();
        }

        private void frmMetodoPago_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Descripcion";
            label3.Text = "descripcion";
            if (Proceso == 3)
            {
                bloquearbotones();
            }
        }

        private void bloquearbotones()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnReporte.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            txtCodigo.Text = pago.CodMetodoPago.ToString();
            
            txtDescripcion.Text = pago.Descripcion;
        }       

        private void CargaLista()
        {
            dgvMetodoPagos.DataSource = data;
            data.DataSource = AdmPago.MuestraMetodoPagos();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvMetodoPagos.ClearSelection();
        }

        private void frmMetodoPago_Shown(object sender, EventArgs e)
        {
            CargaLista();
            txtFiltro.Focus();
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
                    if (Proceso != 0 && txtDescripcion.Text != "")
                    {
                        
                        pago.Descripcion = txtDescripcion.Text;

                        if (Proceso == 1)
                        {
                            pago.CodUser = frmLogin.iCodUser;
                            if (AdmPago.insert(pago))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Metodo de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmPago.update(pago))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Metodo de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        Proceso = 0;
                    }
                }
            }
            else if(btnGuardar.Text == "Aceptar")
            {
                if (Proceso == 3)
                {
                    this.Close();
                }
            }
        }

        private void dgvDocumentos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvMetodoPagos.Rows.Count >= 1 && e.Row.Selected)
            {
                pago.CodMetodoPago = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);                
                pago.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                pago.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                pago.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                if (Proceso == 3)
                {
                    btnGuardar.Enabled = true;
                }
            }
            else if (dgvMetodoPagos.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvDocumentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvMetodoPagos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvMetodoPagos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMetodoPagos.CurrentRow.Index != -1 && pago.CodMetodoPago != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Metodo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmPago.delete(pago.CodMetodoPago))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Metodo de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {                 
                //frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                //form.CodDocumento = doc.CodMetodoPago;
                //form.txtDocRef.Text = doc.Sigla;
                this.Close();
            }
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

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 7;
            frm.ShowDialog();
        }
    }
}
