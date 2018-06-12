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
    public partial class frmDestaques : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmZona AdmZona = new clsAdmZona();
        clsAdmVendedor AdmVen = new clsAdmVendedor();
        
        clsValidar valida = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        public clsDestaque des = new clsDestaque();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Consulta

        

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmDestaques()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvDestaques.DataSource = data;
            data.DataSource = AdmZona.MuestraDestaques();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDestaques.ClearSelection();
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;                       
            btnNuevo.Enabled = Estado;
            
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            ext.limpiar(groupBox2.Controls);
            superValidator1.Validate();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            ext.limpiar(groupBox2.Controls);
        }
               

        private void frmDestaques_Load(object sender, EventArgs e)
        {
            CargaLista();
            CargaVendedores();
            CargaZonas();
            label2.Text = "Codigo";
            label3.Text = "codDestaque";
            if (Proceso == 3)
            {
                bloquearbotones();
            }
        }

        private void bloquearbotones()
        {
            btnNuevo.Visible = false;
            
            btnEliminar.Visible = false;
            btnReporte.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestaques.CurrentRow.Index != -1 && des.CodDestaque != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Destaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmZona.deletedestaque(des.CodDestaque))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Destaque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                        CargaVendedores();
                        CargaZonas();
                    }
                }
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
            if (superValidator1.Validate())
            {
                if (Proceso != 0)
                {   
                    des.CodVendedor = Convert.ToInt32(cmbVendedores.SelectedValue);
                    des.CodZona = Convert.ToInt32(cmbZona.SelectedValue);

                    if (Proceso == 1)
                    {
                        des.CodUser = frmLogin.iCodUser;
                        if (AdmZona.insertdestaque(des))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Destaques", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                            CargaVendedores();
                            CargaZonas();
                            Proceso = 0;
                        }
                    }                    
                    //Proceso = 0;
                }
            }
        }

        private void dgvDestaques_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDestaques.Rows.Count >= 1 && e.Row.Selected)
            {
                des.CodDestaque = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                //cond.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                //cond.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                //cond.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
               
                btnEliminar.Enabled = true;               
            }
            else if(dgvDestaques.Rows.Count == 0)
            {
                
                btnEliminar.Enabled = false;
            }
        }

        private void dgvDestaques_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvDestaques.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvDestaques.Columns[e.ColumnIndex].DataPropertyName;
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

        private void dgvDestaques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {               
                this.Close();
            }
        }

        private void dgvDestaques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 14;
            frm.ShowDialog();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.enteros(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida.enteros(e);
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

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void CargaVendedores()
        {
            cmbVendedores.DataSource = AdmVen.MuestraVendedoresDestaque();
            cmbVendedores.DisplayMember = "apellido";
            cmbVendedores.ValueMember = "codVendedor";
            cmbVendedores.SelectedIndex = -1;
        }

        private void CargaZonas()
        {
            cmbZona.DataSource = AdmZona.MuestraZonasDestaque();
            cmbZona.DisplayMember = "descripcion";
            cmbZona.ValueMember = "codZona";
            cmbZona.SelectedIndex = -1;
        }

        private void frmDestaques_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
