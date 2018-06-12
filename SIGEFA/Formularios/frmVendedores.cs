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
    public partial class frmVendedores : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Vendedor (2)Editar Vendedor
        clsAdmVendedor admVen = new clsAdmVendedor();
      
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        clsAdmFormulario admForm = new clsAdmFormulario();
        clsAdmAcceso admAcce = new clsAdmAcceso();
        public clsVendedor ven = new clsVendedor();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
      

        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();

       

        public frmVendedores()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtNombreUsuario.Text != "")
                {
                    ven.Dni = txtDni.Text;
                    ven.FechaNac = dtpFechaNac.Value.Date;
                    ven.Nombre = txtNombreUsuario.Text;
                    ven.Apellido = txtApellidoUsuario.Text;
                    ven.Direccion = txtDireccion.Text;
                    ven.Telefono = txtTelefono.Text;
                    ven.Celular = txtCelular.Text;
                    ven.Email = txtEmail.Text;                   
                    
                    ven.CodUser = frmLogin.iCodUser;
                    
                    if (Proceso == 1)
                    {                       
                        if (admVen.insert(ven))
                        {                          
                            
                            MessageBox.Show("Los datos se guardaron correctamente", "Vendedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                            Proceso = 0;
                        }
                    }
                    else if (Proceso == 2)
                    {
                       
                        if (admVen.update(ven))
                        {

                            MessageBox.Show("Los datos se guardaron correctamente", "Vendedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                            Proceso = 0;
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible)
            {
                this.Close();
            }
            else
            {
                Proceso = 0;
                CambiarEstados(true);
            }
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            CargaLista();
            label9.Text = "Codigo";
            label8.Text = "codVendedor";
            if (Proceso == 3)
            {
                bloquearbotones();
            }
        }

        private void cargavendedor()
        {            
            ven = admVen.MuestraVendedor(ven.CodVendedor);
            if (ven != null)
            {
                txtCodigo.Text = ven.CodVendedor.ToString();
                txtDni.Text = ven.Dni;
                dtpFechaNac.Value = ven.FechaNac;
                txtNombreUsuario.Text = ven.Nombre;
                txtApellidoUsuario.Text = ven.Apellido;
                txtTelefono.Text = ven.Telefono;
                txtCelular.Text = ven.Celular;
                txtEmail.Text = ven.Email;
                txtDireccion.Text = ven.Direccion;
                
            }
        }
        
        private void txtCodUsuario_TextChanged(object sender, EventArgs e)
        {
            
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
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (Proceso == 1)
                {
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                }
                else
                {
                    e.IsValid = true;
                }
            }
            else
            {
                e.IsValid = true;
            }
        }               
       

        

        private void customValidator8_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        

        private void customValidator10_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (Proceso == 2)
                {
                    if (e.ControlToValidate.Text != "")
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                }
                else
                {
                    e.IsValid = true;
                }
            }
            else
            {
                e.IsValid = true;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label8.Text.Trim(), txtFiltro.Text.Trim());
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox3.Text = "Registro Nuevo";
            Proceso = 1;
            ext.limpiar(groupBox3.Controls);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow.Index != -1 && ven.CodVendedor != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Vendedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admVen.delete(ven.CodVendedor))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ext.limpiar(groupBox2.Controls);
            CambiarEstados(false);
            groupBox3.Text = "Editar Registro";
            Proceso = 2;
            cargavendedor();
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox2.Visible = Estado;
            groupBox3.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            ext.limpiar(groupBox3.Controls);
            superValidator1.Validate();
        }

        private void CargaLista()
        {
            dgvVendedores.DataSource = data;
            data.DataSource = admVen.MuestraVendedores();
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void customValidator11_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
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

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void dgvVendedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {
                this.Close();
            }
        }

        private void dgvVendedores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label9.Text = dgvVendedores.Columns[e.ColumnIndex].HeaderText;
            label8.Text = dgvVendedores.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvVendedores_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvVendedores.Rows.Count >= 1 && e.Row.Selected)
            {
                ven.CodVendedor = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                //cond.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                //cond.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                //cond.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvVendedores.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 13;
            frm.ShowDialog();
        }

        private void frmVendedores_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

    }
}
