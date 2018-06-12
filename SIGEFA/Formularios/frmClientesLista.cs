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
    public partial class frmClientesLista : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmCliente AdmCli = new clsAdmCliente();
        public clsCliente cli = new clsCliente();
        public Int32 Proceso = 0; //(1) Ingreso (2)Salida (3)Relacion
        public Int32 Procede = 0; //(1)Venta  (2)NotaSalida
        public Int32 Tipo = 0; //(0)DNI (1)RUC
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Boolean exit = false;

        public frmClientesLista()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvCliente.DataSource = data;
            data.DataSource = AdmCli.RelacionClientes();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCliente.ClearSelection();
        }

        private void frmClientesLista_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Razon Social";
            label3.Text = "Razonsocial";
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
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                if (ee.KeyChar != (char)Keys.Down)
                {
                    dgvCliente.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvCliente_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvCliente.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvCliente.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
            //form.CodCliente = cli.CodCliente;
            //if (Tipo == 0)
            //{
            //    form.txtCodCliente.Text = cli.Dni;
            //    form.txtNombreCliente.Text = cli.Nombre;
            //    form.txtDireccion.Text = cli.DireccionLegal;
            //}
            //else
            //{
            //    form.txtCodCliente.Text = cli.Ruc;
            //    form.txtNombreCliente.Text = cli.RazonSocial;
            //    form.txtDireccion.Text = cli.DireccionLegal;
            //}
            this.Close(); 
        }

        private void dgvCliente_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//MOD4
        {
            //if (dgvCliente.Rows.Count >= 1 && e.Row.Selected)
            //{
            //    //cli = new clsCliente();
            //    cli.CodCliente = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            //    cli.CodigoPersonalizado = e.Row.Cells[codperso.Name].Value.ToString();
            //    cli.Dni = e.Row.Cells[dni.Name].Value.ToString();
            //    cli.Ruc = e.Row.Cells[ruc.Name].Value.ToString();
            //    cli.RazonSocial = e.Row.Cells[razonsocial.Name].Value.ToString();
            //    //cli.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
            //    cli.DireccionLegal = e.Row.Cells[direccionlegal.Name].Value.ToString();
            //}
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionCliente frm = new frmGestionCliente();
            frm.Proceso = 4;            
            frm.ShowDialog();
            CargaLista();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                //frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                //form.CodCliente = cli.CodCliente;
                //if (Tipo == 0)
                //{
                //    form.txtCodCliente.Text = cli.Dni;
                //    form.txtNombreCliente.Text = cli.Nombre;
                //    form.txtDireccion.Text = cli.DireccionLegal;
                //}
                //else
                //{
                //    form.txtCodCliente.Text = cli.Ruc;
                //    form.txtNombreCliente.Text = cli.RazonSocial;
                //    form.txtDireccion.Text = cli.DireccionLegal;
                //}
                this.Close(); 
            }
           
        }

        private void txtFiltro_TextChanged_1(object sender, EventArgs e)
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

        public int GetCodigoCliente()
        {
            return cli.CodCliente;
        }

        private void frmClientesLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cli.CodCliente != 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)//MOD4
        {
            try
            {
                if (dgvCliente.Rows.Count >= 1 && e.RowIndex != -1 && dgvCliente.CurrentRow.Index == e.RowIndex)
                {
                    DataGridViewRow Row = dgvCliente.Rows[e.RowIndex];
                    cli.CodCliente = Convert.ToInt32(Row.Cells[codigo.Name].Value);
                    cli.CodigoPersonalizado = Row.Cells[codperso.Name].Value.ToString();
                    cli.Dni = Row.Cells[dni.Name].Value.ToString();
                    cli.Ruc = Row.Cells[ruc.Name].Value.ToString();
                    cli.RazonSocial = Row.Cells[razonsocial.Name].Value.ToString();
                    //cli.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                    cli.DireccionLegal = Row.Cells[direccionlegal.Name].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvCliente.Focus();
                dgvCliente.Rows[0].Selected = true;
            } 
        }

        private void dgvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dgvCliente.Rows.Count > 0)
                    {
                        int f = dgvCliente.CurrentRow.Index;
                        cli.CodCliente = Convert.ToInt32(dgvCliente.Rows[f].Cells[codigo.Name].Value);
                        cli.CodigoPersonalizado = dgvCliente.Rows[f].Cells[codperso.Name].Value.ToString();
                        cli.Dni = dgvCliente.Rows[f].Cells[dni.Name].Value.ToString();
                        cli.Ruc = dgvCliente.Rows[f].Cells[ruc.Name].Value.ToString();
                        cli.RazonSocial = dgvCliente.Rows[f].Cells[razonsocial.Name].Value.ToString();
                        //cli.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                        cli.DireccionLegal = dgvCliente.Rows[f].Cells[direccionlegal.Name].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            } 
        }

        private void frmClientesLista_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
            dgvCliente.ClearSelection();
        }
    }
}
