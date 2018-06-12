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
using DevComponents.DotNetBar.Validator;


namespace SIGEFA.Formularios
{
    public partial class frmUnidades : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmUnidad AdmUni = new clsAdmUnidad();
        clsUnidadMedida uni = new clsUnidadMedida();
        public Int32 Proceso = 0; //(1) Nueva Unidad (2)Editar Unidad
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmUnidades()
        {
            InitializeComponent();
        }

        private void frmUnidades_Load(object sender, EventArgs e)
        {            
            CargaLista();
            label2.Text = "Sigla";
            label3.Text = "sigla";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            //frmGestionUnidad frm = new frmGestionUnidad();
            //frm.Proceso = 1;
            //frm.ShowDialog();
            //CargaLista();
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;            
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
            txtSigla.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();      
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //if (dgvUnidades.SelectedRows.Count > 0)
            //{
            //    frmGestionUnidad frm = new frmGestionUnidad();
            //    frm.Proceso = 2;
            //    frm.uni = uni;
            //    frm.ShowDialog();
            //    CargaLista();
            //}  
            if (dgvUnidades.SelectedRows.Count > 0)
            {
                CambiarEstados(false);
                Proceso = 2;
                groupBox2.Text = "Editar Registro";
                txtSigla.Text = uni.Sigla;
                txtDescripcion.Text = uni.Descripcion;
            }
        }

        private void dgvUnidades_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvUnidades.Rows.Count >= 1 && e.Row.Selected)
            {
                uni.CodUnidad = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                uni.Sigla = e.Row.Cells[sigla.Name].Value.ToString();
                uni.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                uni.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                uni.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvUnidades.Rows.Count == 0)
            {            
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargaLista()
        {            
            dgvUnidades.DataSource = data;
            data.DataSource = AdmUni.MuestraUnidades();
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void frmUnidades_Shown(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvUnidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            //label2.Text = dgvUnidades.Columns[dgvUnidades.CurrentCell.ColumnIndex].HeaderText;                            
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

        private void dgvUnidades_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvUnidades.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvUnidades.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
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
                if (Proceso != 0 && txtSigla.Text != "" && txtDescripcion.Text != "")
                {
                    uni.Sigla = txtSigla.Text;
                    uni.Descripcion = txtDescripcion.Text;

                    if (Proceso == 1)
                    {
                        uni.CodUser = frmLogin.iCodUser;
                        if (AdmUni.insert(uni))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmUni.update(uni))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUnidades.CurrentRow.Index != -1 && uni.CodUnidad != 0 )
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmUni.delete(uni.CodUnidad))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if(Proceso!=0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
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
            DataTable dt = new DataTable("Unidades");
            // Columnas
            foreach (DataGridViewColumn column in dgvUnidades.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvUnidades.Rows.Count; i++)
            {
                DataGridViewRow row = dgvUnidades.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvUnidades.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmUnidadesRP frm = new frmUnidadesRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void frmUnidades_Shown_1(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
