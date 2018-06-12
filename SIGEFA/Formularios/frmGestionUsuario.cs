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
    public partial class frmGestionUsuario : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Usuario (2)Editar Usuario
        clsAdmUsuario admUsu = new clsAdmUsuario();
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        clsAdmFormulario admForm = new clsAdmFormulario();
        clsAdmAcceso admAcce = new clsAdmAcceso();
        public clsUsuario usu = new clsUsuario();
        clsAccesos acce = new clsAccesos();

        clsValidar ok = new clsValidar();
        clsConsultasExternas ext = new clsConsultasExternas();

        public List<Int32> codigos = new List<Int32>();

        public frmGestionUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtNombreUsuario.Text != "")
                {
                    usu.Dni = txtDni.Text;
                    usu.FechaNac = dtpFechaNac.Value.Date;
                    usu.Nombre = txtNombreUsuario.Text;
                    usu.Apellido = txtApellidoUsuario.Text;
                    usu.Direccion = txtDirección.Text;
                    usu.Telefono = txtTelefono.Text;
                    usu.Celular = txtCelular.Text;
                    usu.Email = txtEmail.Text;
                    usu.ContraEmail = txtContraEmail.Text;
                    usu.Host = txthost.Text;
                    usu.Usuario = txtUsuario.Text;
                    usu.Estado = cbActivoU.Checked;
                    usu.CodUser = frmLogin.iCodUser;
                    usu.Nivel = Convert.ToInt32(cmbNivel.SelectedValue);
                    //if (rbAdministrador.Checked)
                    //{
                    //    usu.Nivel = 1;
                    //}
                    //else if (rbUsuario.Checked)
                    //{
                    //    usu.Nivel = 0;
                    //}
                    RecorreArbol();

                    if (Proceso == 1)
                    {
                        if (txtCont1.Text == txtCont2.Text && txtCont1.Text != "")
                        {
                            usu.Contraseña = txtCont1.Text;
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden", "Gestion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (codigos.Count > 0)
                        {
                            if (admUsu.insert(usu))
                            {
                                //admAcce.LimpiarAccesos(usu.CodUsuarioNuevo,frmLogin.iCodAlmacen);
                                if (codigos.Count > 0)
                                {
                                    admAcce.InsertAccesoEmp(usu.CodUsuarioNuevo, frmLogin.iCodEmpresa, frmLogin.iCodUser);
                                    acce.CodUsuario = usu.CodUsuarioNuevo;
                                    acce.CodAlmacen = frmLogin.iCodAlmacen;
                                    acce.CodUser = frmLogin.iCodUser;
                                    foreach (Int32 formu in usu.CodigosForm)
                                    {
                                        acce.CodFormulario = formu;
                                        admAcce.insert(acce);
                                    }
                                }
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe brindar accesos al Usuario", "Gestion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (txtCont3.Visible)
                        {
                            if (usu.Contraseña == txtCont1.Text && txtCont2.Text == txtCont3.Text && txtCont2.Text != "")
                            {
                                usu.Contraseña = txtCont2.Text;
                            }
                            else
                            {
                                MessageBox.Show("Las contraseñas no coinciden", "Gestion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (admUsu.update(usu))
                        {
                            admAcce.LimpiarAccesos(usu.CodUsuario, frmLogin.iCodAlmacen);
                            if (codigos.Count > 0)
                            {
                                admAcce.InsertAccesoEmp(usu.CodUsuario, frmLogin.iCodEmpresa,frmLogin.iCodUser);
                                acce.CodUsuario = usu.CodUsuario;
                                acce.CodAlmacen = frmLogin.iCodAlmacen;
                                acce.CodUser = frmLogin.iCodUser;
                                foreach (Int32 formu in usu.CodigosForm)
                                {
                                    acce.CodFormulario = formu;
                                    admAcce.insert(acce);
                                }
                            }
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            CargaNiveles();
            CargaEmpresas();
            cmbEmpresa.SelectedValue = frmLogin.iCodEmpresa;
            CargaAlmacenes();
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
            llenaarbol(0, null);
            if (Proceso == 2)
            {
                cargausuario();
            }
            else if (Proceso == 3)
            {
                cargausuario();
                ext.sololectura(groupBox3.Controls);
                linkLabel1.Visible = false;
                rbUsuario.Enabled = false;
                rbAdministrador.Enabled = false;
                tstvFormularios.Enabled = false;
                btnAceptar.Visible = false;
                btnCancelar.Text = "Aceptar";
                btnCancelar.ImageIndex = 1;
            }
        }

        private void CargaNiveles()
        {
            try
            {
                cmbNivel.DataSource = admUsu.ListaNiveles();
                cmbNivel.ValueMember = "idnivel";
                cmbNivel.DisplayMember = "nombre_nivel";
                //cmbNivel.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargausuario()
        {
            usu = admUsu.MuestraUsuario(usu.CodUsuario);
            txtCodUsuario.Text = usu.CodUsuario.ToString();
            txtDni.Text = usu.Dni;
            txtNombreUsuario.Text = usu.Nombre;
            txtApellidoUsuario.Text = usu.Apellido;
            if (usu.FechaNac > dtpFechaNac.MinDate)
            {
                dtpFechaNac.Value = usu.FechaNac.Date;
            }
            else
            {
                dtpFechaNac.Text = "";
            }
            txtDirección.Text = usu.Direccion;
            txtTelefono.Text = usu.Telefono;
            txtCelular.Text = usu.Celular;
            txtEmail.Text = usu.Email;
            txtContraEmail.Text = usu.ContraEmail;
            txthost.Text = usu.Host;
            txtUsuario.Text = usu.Usuario;
            cbActivoU.Checked = usu.Estado;
            linkLabel1.Visible = true;
            label9.Visible = false;
            label10.Visible = false;
            txtCont1.Visible = false;
            txtCont2.Visible = false;
            cmbNivel.SelectedValue = usu.Nivel;
            //if (usu.Nivel == 1)
            //{
            //    rbAdministrador.Checked = true;
            //}
            //else if (usu.Nivel == 0)
            //{
            //    rbUsuario.Checked = true;
            //    CargaAccesos();
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (label9.Visible)
            {
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                txtCont1.Visible = false;
                txtCont2.Visible = false;
                txtCont3.Visible = false;
            }
            else
            {
                label9.Visible = true;
                label10.Text = "Nueva Contraseña";
                label10.Visible = true;
                label11.Visible = true;
                txtCont1.Visible = true;
                txtCont2.Visible = true;
                txtCont3.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //tstvFormularios.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //tstvFormularios.Enabled = true;
        }

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = -1;
        }

        private void CargaAlmacenes()
        {
            cmbAlmacen.DataSource = admAlm.CargaAlmacenes(frmLogin.iNivelUser, Convert.ToInt32(cmbEmpresa.SelectedValue), frmLogin.iCodUser);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedIndex = -1;
        }

        private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaAlmacenes();
        }

        private void llenaarbol(Int32 indicePadre, TreeNode nodoPadre)
        {
            DataView hijos = new DataView(admForm.MuestraFormularios());
            hijos.RowFilter = admForm.MuestraFormularios().Columns["padre"].ColumnName + " = " + indicePadre;

            foreach (DataRowView row in hijos)
            {
                TreeNode nuevonodo = new TreeNode();
                nuevonodo.Text = row["descripcion"].ToString();
                nuevonodo.Tag = row["codFormulario"].ToString();
                if (nodoPadre == null)
                {
                    tstvFormularios.Nodes.Add(nuevonodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodoPadre.Nodes.Add(nuevonodo);
                }
                llenaarbol(Int32.Parse(row["codFormulario"].ToString()), nuevonodo);
            }
        }



        private void RecorreArbol()
        {
            codigos.Clear();
            if (tstvFormularios.Enabled)
            {
                foreach (TreeNode nod in tstvFormularios.Nodes)
                {
                    añadenodos(nod);
                }
            }
            usu.CodigosForm = codigos;
        }
        private void añadenodos(TreeNode nod)
        {
            if (nod.StateImageIndex == (int)CheckState.Checked)
            {
                codigos.Add(Convert.ToInt32(nod.Tag));
            }
            if (nod.Nodes.Count > 0)
            {
                foreach (TreeNode tn in nod.Nodes)
                {
                    añadenodos(tn);
                }
            }
        }


        private void CargaAccesos()
        {
            codigos = admAcce.MuestraAccesos(usu.CodUsuario, frmLogin.iCodAlmacen);
            foreach (TreeNode nod in tstvFormularios.Nodes)
            {
                marcanodo(nod);
            }
        }
        private void marcanodo(TreeNode nod)
        {
            Int32 codi = Convert.ToInt32(nod.Tag);
            if (codigos.Contains(codi))
            {
                nod.Checked = true;
            }
            if (nod.Nodes.Count > 0)
            {
                foreach (TreeNode tn in nod.Nodes)
                {
                    marcanodo(tn);
                }
            }
        }

        private void txtCodUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
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

        private void customValidator7_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (Proceso == 2)
                {
                    if (e.ControlToValidate.Text.Equals(usu.Contraseña))
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

        private void customValidator6_ValidateValue_1(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (Proceso == 1)
                {
                    if (e.ControlToValidate.Text.Equals(txtCont1.Text))
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

        private void customValidator9_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Visible)
            {
                if (Proceso == 2)
                {
                    if (e.ControlToValidate.Text.Equals(txtCont2.Text))
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

        private void cmbNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbNivel.SelectedValue)==1)
            {
                tstvFormularios.Enabled = false;

            }
            else
            {
                tstvFormularios.Enabled = true;
                CargaAccesos();
            }
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidoUsuario.Focus();
            }
        }

        private void txtApellidoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDirección.Focus();
            }
        }

        private void txtDirección_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCont1.Focus();
            }
        }

        private void txtCont1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCont2.Focus();
            }
        }

        private void txtCont2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCont3.Focus();
            }
        }

        private void txtCont3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDni.Focus();
            }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContraEmail.Focus();
            }
        }

        private void txtContraEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthost.Focus();
            }
        }

        private void txthost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelular.Focus();
            }
        }

        private void frmGestionUsuario_Shown(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }
    }
}
