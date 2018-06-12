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
    public partial class frmCliVisitados : Form
    {
        clsAdmCliente AdmCliente = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        public static BindingSource data = new BindingSource();
        public Int32 codEntConsExt;
        public Int32 proceso = 0;
        Int32 flgCodCli = 0;
        Int32 codCliDel = 0;

        public frmCliVisitados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void CargaLista()
        {
            dgvClientes.DataSource = data;
            data.DataSource = AdmCliente.ListaClientesConsultor(codEntConsExt);
            dgvClientes.ClearSelection();
        }

        private void frmCliVisitados_Load(object sender, EventArgs e)
        {
            if (proceso == 4) 
            {
                txtDNIRUC.Enabled = false;
                txtRazSocial.Enabled = false;
                txtDireccion.Enabled = false;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            CargaLista();
        }

        private void txtDNIRUC_Leave(object sender, EventArgs e)
        {
            try
            {
                cli = AdmCliente.ConsultaCliente(txtDNIRUC.Text);
                txtRazSocial.Text = cli.RazonSocial;
                txtDireccion.Text = cli.DireccionLegal;
                flgCodCli = 1;
            }
            catch (NullReferenceException ex) 
            {
                flgCodCli = 0;
                txtRazSocial.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (flgCodCli == 0)
            {
                cli = new clsCliente();
                if ((txtDNIRUC.Text).Length > 8)
                {
                    cli.Ruc = txtDNIRUC.Text;
                    cli.RazonSocial = txtRazSocial.Text;
                    cli.DireccionLegal = txtDireccion.Text;
                }
                else 
                {
                    cli.Dni = txtDNIRUC.Text;
                    cli.Nombre = txtRazSocial.Text;
                    cli.RazonSocial = txtRazSocial.Text;
                    cli.DireccionLegal = txtDireccion.Text;
                }
                cli.FormaPago = 6;
                cli.CodUser = frmLogin.iCodUser;
                AdmCliente.insert(cli);
                cli.CodCliente = cli.CodClienteNuevo;
            }
            AdmCliente.insertConCli(codEntConsExt, cli.CodCliente);
            CargaLista();
            flgCodCli = 0;
            txtDNIRUC.Text = "";
            txtRazSocial.Text = "";
            txtDireccion.Text = "";
            txtDNIRUC.Focus();
        }

        private void dgvClientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvClientes.Rows.Count >= 1 && e.Row.Selected)
            {
                codCliDel = Convert.ToInt32(e.Row.Cells[codCliente.Name].Value);
                btnEliminar.Enabled = true;
            }
            else if (dgvClientes.SelectedRows.Count == 0)
            {
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Clientes Asesorados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCliente.deleteConCli(codEntConsExt, codCliDel))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Clientes Asesorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                        codCliDel = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Cliente", "Clientes Asesorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
