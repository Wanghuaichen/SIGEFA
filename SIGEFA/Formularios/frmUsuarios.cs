using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Conexion;

namespace SIGEFA.Formularios
{
    public partial class frmUsuarios : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmUsuario AdmUsu = new clsAdmUsuario();
        clsUsuario usu = new clsUsuario();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmGestionUsuario frm = new frmGestionUsuario();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargaLista();
                label2.Text = "Nombres";
                label3.Text = "nombre";
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            //dgvUsuarios.DataSource = AdmUsu.MuestraUsuarios();            
            //dgvUsuarios.ClearSelection();
            dgvUsuarios.DataSource = data;
            //data.DataSource = AdmUsu.MuestraUsuarios();
            data.DataSource = AdmUsu.ListaUsuarios_Empresa(frmLogin.iCodEmpresa);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvUsuarios.ClearSelection();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmGestionUsuario frm = new frmGestionUsuario();
                frm.Proceso = 2;
                frm.usu = usu;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void frmUsuarios_Shown(object sender, EventArgs e)
        {
            //expandablePanel1.Expanded = false;
            CargaLista();
        }        

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow.Index != -1 && usu.CodUsuario != 0 && dgvUsuarios.Rows.Count > 1)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos del Usuario definitivamente", "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmUsu.delete(Convert.ToInt32(usu.CodUsuario)))
                    {
                        MessageBox.Show("El Usuario ha sido eliminado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();                        
                    }
                }
            }
            else MessageBox.Show("No se Puede Eliminar el Registro ");
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (!expandablePanel1.Expanded)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
            else
            {
                expandablePanel1.Expanded = false;
            }

            //if (Application.OpenForms["frmBusqueda"] != null)
            //{
            //    Application.OpenForms["frmBusqueda"].Close();
            //}
            //else
            //{
            //    showbuscar();
            //}            
        }

        private void showbuscar()
        {
            frmBusqueda search = new frmBusqueda();
            search.Owner = this;
            search.label1.Text = dgvUsuarios.Columns[dgvUsuarios.CurrentCell.ColumnIndex].HeaderText;
            search.label2.Text = dgvUsuarios.Columns[dgvUsuarios.CurrentCell.ColumnIndex].DataPropertyName;
            search.Top = 50;
            search.Left = Application.OpenForms["mdi_Menu"].Width - search.Width - 20;
            search.Show();
        }
       
        private void dgvUsuarios_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvUsuarios.Rows.Count >= 1 && e.Row.Selected)
            {
                usu.CodUsuario = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                //usu.FechaNac = Convert.ToDateTime(e.Row.Cells[fechanac.Name].Value);
                //usu.Dni = e.Row.Cells[dni.Name].Value.ToString();
                //usu.Nombre = e.Row.Cells[nombre.Name].Value.ToString();
                //usu.Apellido = e.Row.Cells[apellido.Name].Value.ToString();
                //usu.Direccion = e.Row.Cells[direccion.Name].Value.ToString();
                //usu.Telefono = e.Row.Cells[telefono.Name].Value.ToString();
                //usu.Celular = e.Row.Cells[celular.Name].Value.ToString();
                //usu.Email = e.Row.Cells[email.Name].Value.ToString();
                //usu.Usuario = e.Row.Cells[usuario.Name].Value.ToString();
                //usu.Contraseña = e.Row.Cells[contra.Name].Value.ToString();
                //usu.Estado = Convert.ToBoolean(e.Row.Cells[estado.Name].Value);
                //usu.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fechareg.Name].Value);
                //*************************************************************************
                //if (e.Row.Cells[Nivel.Name].Value != null)
                //   {
                if (Convert.ToInt32(e.Row.Cells[Nivel.Name].Value) != 1)
                { biAccesosSucursal.Enabled = true; }
                else
                { biAccesosSucursal.Enabled = false; }
                //   }
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmAccesos frm = new frmAccesos();
                frm.usu = usu;                
                frm.ShowDialog();                
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvUsuarios.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
            if (Application.OpenForms["frmBusqueda"] != null)
            {
                frmBusqueda search = (frmBusqueda)Application.OpenForms["frmBusqueda"];
                search.label1.Text = dgvUsuarios.Columns[e.ColumnIndex].HeaderText;
                search.label2.Text = dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName;
                search.txtFiltro.Focus();
            }
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

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void frmUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
                //showbuscar();
            }
        }

        private void dgvUsuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmGestionUsuario frm = new frmGestionUsuario();
                frm.Proceso = 3;
                frm.usu = usu;
                frm.ShowDialog();
            }
        }

        private void biConsultar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmGestionUsuario frm = new frmGestionUsuario();
                frm.Proceso = 3;
                frm.usu = usu;
                frm.ShowDialog();
            }
        }

        private void biImprimir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Usuarios");
            // Columnas
            foreach (DataGridViewColumn column in dgvUsuarios.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvUsuarios.Rows.Count; i++)
            {
                DataGridViewRow row = dgvUsuarios.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvUsuarios.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmUsuariosRP frm = new frmUsuariosRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                frmAccesosSucursal frm = new frmAccesosSucursal();
                frm.usu = usu;
                frm.ShowDialog();
            } 
        }

      

       
        

       




       
    }
}
