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
    public partial class frmVehiculoTransporte : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmVehiculoTransporte AdmVT = new clsAdmVehiculoTransporte();
        clsAdmMarcaTransporte admMT = new clsAdmMarcaTransporte();
        clsAdmModeloTransporte admMoT = new clsAdmModeloTransporte();
        clsValidar valida = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();
        public clsVehiculoTransporte veh = new clsVehiculoTransporte();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Consulta


        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmVehiculoTransporte()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvVehiculoTransporte.DataSource = data;
            data.DataSource = AdmVT.MuestraVehiculoTransportes();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVehiculoTransporte.ClearSelection();
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
            txtConstancia.Text = "";
            superValidator1.Validate();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            ext.limpiar(groupBox2.Controls);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ext.limpiar(groupBox2.Controls);
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            cargaVehiculoTransporte();
        }

        private void cargaVehiculoTransporte()
        {
            veh = AdmVT.MuestraVehiculoTransporte(veh.CodVehiculoTransporte);
            if (veh != null)
            {
                txtCodigo.Text = veh.CodVehiculoTransporte.ToString();
                txtAño.Text = veh.Año.ToString();
                txtPlaca.Text = veh.Placa;
                txtConstancia.Text = veh.ConstanciaInscripcion;
                cmbMarca.SelectedValue = veh.CodMarca;
                CargaModelos(veh.CodMarca);
                cmbModelo.Enabled = true;
                cmbModelo.SelectedValue = veh.CodModelo;
                txtSoat.Text = veh.Soat;
                txtConfVehicular.Text = veh.ConfVehicular;
                txtmtc.Text = veh.MTC;
            }
        }

        private void frmVehiculoTransporte_Load(object sender, EventArgs e)
        {
            CargaLista();
            CargaMarcas();
            label2.Text = "Codigo";
            label3.Text = "codVehiculoTransporte";
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculoTransporte.CurrentRow.Index != -1 && veh.CodVehiculoTransporte != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "VehiculoTransporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmVT.delete(veh.CodVehiculoTransporte))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "VehiculoTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
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
                    
                    veh.Placa = txtPlaca.Text;
                    veh.ConstanciaInscripcion = txtConstancia.Text;
                    veh.Año = Convert.ToInt32(txtAño.Text);
                    veh.CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                    veh.CodModelo = Convert.ToInt32(cmbModelo.SelectedValue);
                    veh.ConfVehicular = txtConfVehicular.Text;
                    veh.Soat = txtSoat.Text;
                    veh.MTC = txtmtc.Text;
                    if (Proceso == 1)
                    {
                        veh.CodUser = frmLogin.iCodUser;
                        if (AdmVT.insert(veh))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion VehiculoTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                            Proceso = 0;
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmVT.update(veh))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion VehiculoTransporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                            Proceso = 0;
                        }
                    }
                    //Proceso = 0;
                }
            }
        }

        private void dgvVehiculoTransportes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvVehiculoTransporte.Rows.Count >= 1 && e.Row.Selected && e.Row!=null)
            {
                veh.CodVehiculoTransporte = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                //cond.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                //cond.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                //cond.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;               
            }
            else if(dgvVehiculoTransporte.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvVehiculoTransportes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvVehiculoTransporte.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvVehiculoTransporte.Columns[e.ColumnIndex].DataPropertyName;
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

        private void dgvVehiculoTransportes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {               
                this.Close();
            }
        }

        private void dgvVehiculoTransportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrptCotizacion frm = new frmrptCotizacion();
            frm.tipo = 9;
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

                

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.enteros(e);
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

        private void cmbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaModelos(Convert.ToInt32(cmbMarca.SelectedValue));
            cmbModelo.Enabled = true;
        }

        private void CargaMarcas()
        {
            cmbMarca.DataSource = admMT.MuestraMarcaTransportes();
            cmbMarca.DisplayMember = "descripcion";
            cmbMarca.ValueMember = "codMarcaTransporte";
            cmbMarca.SelectedIndex = -1;
        }

        private void CargaModelos(Int32 CodMar)
        {
            cmbModelo.DataSource = admMoT.MuestraModeloTransportes(CodMar);
            cmbModelo.DisplayMember = "descripcion";
            cmbModelo.ValueMember = "codModeloTransporte";
            cmbModelo.SelectedIndex = -1;
        }

        private void frmVehiculoTransporte_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
