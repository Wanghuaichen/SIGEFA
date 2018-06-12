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
    public partial class frmTipoArticulos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmTipoArticulo AdmTip = new clsAdmTipoArticulo();
        clsTipoArticulo tip = new clsTipoArticulo();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmTipoArticulos()
        {
            InitializeComponent();
        }

        private void frmTipoArticulos_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codArticulo";
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
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            txtCodigo.Text = tip.CodTipoArticulo.ToString();
            txtReferencia.Text = tip.Referencia;
            txtDescripcion.Text = tip.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    tip.Referencia = txtReferencia.Text;
                    tip.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        tip.CodUser = frmLogin.iCodUser;
                        if (AdmTip.insert(tip))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Tipo Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmTip.update(tip))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Tipo Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvTiposArticulos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvTiposArticulos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvTiposArticulos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvTiposArticulos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTiposArticulos.Rows.Count >= 1 && e.Row.Selected)
            {
                tip.CodTipoArticulo = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                tip.Referencia = e.Row.Cells[referencia.Name].Value.ToString();
                tip.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                tip.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                tip.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvTiposArticulos.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargaLista()
        {
            dgvTiposArticulos.DataSource = data;
            data.DataSource = AdmTip.MuestraTipoArticulos();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvTiposArticulos.ClearSelection();
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
            txtReferencia.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();
        }

        private void dgvTiposArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {
                frmRegistroProducto.codtipo = tip.CodTipoArticulo;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTiposArticulos.CurrentRow.Index != -1 && tip.CodTipoArticulo != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Tipo de Artículos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmTip.delete(tip.CodTipoArticulo))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Tipo de Artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("TiposArticulos");
            // Columnas
            foreach (DataGridViewColumn column in dgvTiposArticulos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvTiposArticulos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvTiposArticulos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvTiposArticulos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            
            frmTipoArticulosRP frm = new frmTipoArticulosRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void frmTipoArticulos_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
