using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Entidades;
using SIGEFA.Administradores;
using SIGEFA.Reportes;


namespace SIGEFA.Formularios
{
    public partial class frmGestionTipoEgreso : DevComponents.DotNetBar.Office2007Form
    {
        clsTipoPagoCaja tipoPag = new clsTipoPagoCaja();
        clsAdmTipoPagoCaja admTipoPag = new clsAdmTipoPagoCaja();
        private Int32 Proceso = 0;

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmGestionTipoEgreso()
        {
            InitializeComponent();
        }

        private void frmGestionTipoEgreso_Load(object sender, EventArgs e)
        {
            CargaLista();
            groupBox1.Height = 270;
            label4.Text = "Descripcion";
            label5.Text = "Descripcion";
        }

        private void CargaLista()
        {
            dgvTipoPagoCaja.DataSource = data;
            data.DataSource = admTipoPag.ListaTipoPagoCaja();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvTipoPagoCaja.ClearSelection();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label5.Text.Trim(), txtFiltro.Text.Trim());
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            txtDescripcion.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            Proceso = 2;
            groupBox2.Text = "Editar Registro";
            txtCodigo.Text = tipoPag.CodTipoPagoServicio.ToString();
            txtDescripcion.Text = tipoPag.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    tipoPag.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        tipoPag.CodUser = frmLogin.iCodUser;
                        if (admTipoPag.insert(tipoPag))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Tipo Egreso Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (admTipoPag.update(tipoPag))
                        {
                            MessageBox.Show("Los datos se actualizaron correctamente", "Gestion Tipo Egreso Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvTipoPagoCaja_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label4.Text = dgvTipoPagoCaja.Columns[e.ColumnIndex].HeaderText;
            label5.Text = dgvTipoPagoCaja.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvTipoPagoCaja_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTipoPagoCaja.Rows.Count >= 1 && e.Row.Selected)
            {
                tipoPag.CodTipoPagoServicio = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                tipoPag.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                tipoPag.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                tipoPag.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvTipoPagoCaja.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTipoPagoCaja.CurrentRow.Index != -1 && tipoPag.CodTipoPagoServicio != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admTipoPag.delete(tipoPag.CodTipoPagoServicio))
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
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("TipoEgresoCaja");
            // Columnas
            foreach (DataGridViewColumn column in dgvTipoPagoCaja.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvTipoPagoCaja.Rows.Count; i++)
            {
                DataGridViewRow row = dgvTipoPagoCaja.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvTipoPagoCaja.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\TipoEgresoCajaRPT.xml", XmlWriteMode.WriteSchema);

            CRTipoEgresoCaja rpt = new CRTipoEgresoCaja();
            frmGestionTipoEgresoRP frm = new frmGestionTipoEgresoRP();
            rpt.SetDataSource(ds);
            frm.cRVTipoEgresoCaja.ReportSource = rpt;
            frm.Show();
        }

        private void frmGestionTipoEgreso_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
