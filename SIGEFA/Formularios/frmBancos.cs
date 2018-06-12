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
    public partial class frmBancos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmBanco AdmBan = new clsAdmBanco();
        clsBanco ban = new clsBanco();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmBancos()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codBanco";
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            Proceso = 2;
            groupBox2.Text = "Editar Registro";
            txtCodigo.Text = ban.CodBanco.ToString();
            txtDescripcion.Text = ban.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "" && txtSigla.Text != "")
                {
                    ban.Descripcion = txtDescripcion.Text;
                    ban.SiglaBanco = txtSigla.Text;

                    if (Proceso == 1)
                    {
                        ban.CodUser = frmLogin.iCodUser;
                        if (AdmBan.insert(ban))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmBan.update(ban))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
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

        private void dgvMarcas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvBancos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvBancos.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void dgvMarcas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvBancos.Rows.Count >= 1 && e.Row.Selected)
            {
                ban.CodBanco = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                ban.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                ban.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                ban.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvBancos.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargaLista()
        {
            dgvBancos.DataSource = data;
            data.DataSource = AdmBan.MuestraBancos();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvBancos.ClearSelection();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow.Index != -1 && ban.CodBanco != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmBan.delete(ban.CodBanco))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Marcas");
            // Columnas
            foreach (DataGridViewColumn column in dgvBancos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvBancos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvBancos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvBancos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmBancosRP frm = new frmBancosRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void frmBancos_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
