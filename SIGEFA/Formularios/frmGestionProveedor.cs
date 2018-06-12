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
    public partial class frmGestionProveedor : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Proveedor (2)Editar Proveedor (3)Nota Ingreso
        clsAdmProveedor admProv = new clsAdmProveedor();
        public clsProveedor prov = new clsProveedor();
        clsConsultasExternas ext = new clsConsultasExternas();
        clsAdmListaPrecio AdmLista = new clsAdmListaPrecio();
        clsListaPrecio lista = new clsListaPrecio();
        Boolean margechange = false; // variable para validar si se ha realizado algun cambio en el margen de ganancia del proveedor
        clsLocalidad local = new clsLocalidad();

        public frmGestionProveedor()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Proceso != 0 && txtRUC.Text != "")
            {                
                prov.Ruc = txtRUC.Text;
                prov.RazonSocial = txtRazonSocial.Text;
                prov.Direccion = txtDireccion.Text;
                prov.Telefono = txtTelefono.Text;
                prov.Fax = txtFax.Text;
                prov.Representante = txtRepresentante.Text;
                prov.Mail = txtmail.Text;
                prov.Contacto = txtContacto.Text;
                prov.TelefonoContacto = txtTelCon.Text;
                if (txtVisita.Text != "") { prov.FrecuenciaVisita = Convert.ToInt32(txtVisita.Text); }
                if (txtRecargo.Text != "") { prov.Margen = Convert.ToDouble(txtRecargo.Text); } else { prov.Margen = 0; }
                prov.Banco = txtBanco.Text;
                prov.CtaCte = txtCtaCte.Text;
                prov.Comentario = txtComentario.Text;
                prov.CodUser = frmLogin.iCodUser;
                prov.Estado = cbActivo.Checked;

                if (Proceso == 1 || Proceso == 3)
                {
                    if (admProv.insert(prov))
                    {
                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else if (Proceso == 2)
                {
                    if (admProv.update(prov))
                    {
                        if (margechange)
                        {
                            DialogResult dlgResult = MessageBox.Show("Desea recalcular la listas de precios con el margen actual", "Proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgResult == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                foreach (Int32 codlista in AdmLista.MuestraListasProveedor(frmLogin.iCodAlmacen))
                                {
                                    lista = AdmLista.CargaListaPrecio(codlista);
                                    if (AdmLista.GeneraListaProveedor(lista.CodListaPrecio, frmLogin.iCodAlmacen, lista.Decimales, prov.CodProveedor))
                                    {
                                        MessageBox.Show("Se actualizo la lista " + lista.Nombre + " ", "Gestion Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Los datos se guardaron correctamente", "Gestion Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionProveedor_Load(object sender, EventArgs e)
        {
            CargaLocalidades(cbDepartamento, "000000", 1);
            if (Proceso == 2)
            {
                cargaproveedor();
            }
            else if(Proceso == 3)
            {
                cargaproveedor();
                ext.sololectura(groupBox1.Controls);
                btnAceptar.Visible = false;
                btnCancelar.Text = "Aceptar";
                btnCancelar.ImageIndex = 1;
            }
        }
        private void cbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLocalidades(cbProvincia, cbDepartamento.SelectedValue.ToString(), 2);
            cbProvincia.Enabled = true;
            cbProvincia.Focus();
        }

        private void cbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLocalidades(cbDistrito, cbProvincia.SelectedValue.ToString(), 3);
            cbDistrito.Enabled = true;
            cbDistrito.Focus();
        }

        private void CargaLocalidades(ComboBox Combo, String Padre, Int32 Nivel)
        {
            Combo.DataSource = local.CargaLocalidades(Padre, Nivel);
            Combo.DisplayMember = "nombre";
            Combo.ValueMember = "codLocalidad";
            Combo.SelectedIndex = -1;
        }

        private void cargaproveedor()
        {
            prov = admProv.MuestraProveedor(prov.CodProveedor);
            txtRUC.Text = prov.Ruc;
            txtRazonSocial.Text = prov.RazonSocial;
            txtDireccion.Text = prov.Direccion;
            txtTelefono.Text = prov.Telefono;
            txtFax.Text = prov.Fax;
            txtRepresentante.Text = prov.Representante;
            txtmail.Text = prov.Mail;
            txtContacto.Text = prov.Contacto;
            txtTelCon.Text = prov.TelefonoContacto;
            txtVisita.Text = prov.FrecuenciaVisita.ToString();
            txtRecargo.Text = prov.Margen.ToString();
            txtBanco.Text = prov.Banco;
            txtCtaCte.Text = prov.CtaCte;
            txtComentario.Text = prov.Comentario;
            cbActivo.Checked = prov.Estado;
            cbDepartamento.SelectedValue = prov.Departamento;
            if (prov.Departamento != "")
            {
                cbDepartamento.SelectedValue = prov.Departamento;
                CargaLocalidades(cbProvincia, prov.Departamento.ToString(), 2);
                cbProvincia.Enabled = true;

                if (prov.Provincia != "")
                {
                    cbProvincia.SelectedValue = prov.Provincia;
                    CargaLocalidades(cbDistrito, prov.Provincia.ToString(), 3);
                    cbDistrito.Enabled = true;
                    cbDistrito.SelectedValue = prov.Distrito;
                }
            }
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //ruc(txtRUC.Text);

                if (ext.rucsunat(txtRUC.Text))
                {
                    txtRazonSocial.Text = ext.RazonSocial;
                    txtDireccion.Text = ext.DireccionLegal;
                }
                else
                {
                    ext.limpiar(this.Controls);
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtRazonSocial.Focus();
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtRecargo_TextChanged(object sender, EventArgs e)
        {
            margechange = true;
        }

        private void frmGestionProveedor_Shown(object sender, EventArgs e)
        {
            margechange = false;
            txtRUC.Focus();
        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbDepartamento.Focus();
            }
        }

        private void cbDistrito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTelefono.Focus();
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFax.Focus();
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentante.Focus();
            }
        }

        private void txtRepresentante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmail.Focus();
            }
        }

        private void txtmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContacto.Focus();
            }
        }

        private void txtContacto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelCon.Focus();
            }
        }

        private void txtTelCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVisita.Focus();
            }
        }

        private void txtVisita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRecargo.Focus();
            }
        }

        private void txtRecargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBanco.Focus();
            }
        }

        private void txtBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCtaCte.Focus();
            }
        }

        private void txtCtaCte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComentario.Focus();
            }
        }

        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }
    }
}
