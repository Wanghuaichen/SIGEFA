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
    public partial class frmCaracteristicas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmCaracteristica AdmCar = new clsAdmCaracteristica();
        clsCaracteristica car = new clsCaracteristica();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmCaracteristicas()
        {
            InitializeComponent();
        }

        private void frmCaracteristicas_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Codigo";
            label3.Text = "codCaracteristica";
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
            txtCodigo.Text = car.CodCaracteristica.ToString();
            txtDescripcion.Text = car.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtDescripcion.Text != "")
                {
                    car.Descripcion = txtDescripcion.Text;
                    if (Proceso == 1)
                    {
                        car.CodUser = frmLogin.iCodUser;
                        if (AdmCar.insert(car))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Caracteristica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmCar.update(car))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion Caracteristica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvCaracteristicas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvCaracteristicas.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvCaracteristicas.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvCaracteristicas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCaracteristicas.Rows.Count >= 1 && e.Row.Selected)
            {
                car.CodCaracteristica = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                car.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                car.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                car.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnVariantes.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvCaracteristicas.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnVariantes.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void CargaLista()
        {
            dgvCaracteristicas.DataSource = data;
            data.DataSource = AdmCar.MuestraCaracteristicas();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCaracteristicas.ClearSelection();
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnGuardar.Visible = !Estado;
            btnVariantes.Visible = Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            superValidator1.Validate();
        }

        private void btnVariantes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmVariantes"] != null)
            {
                Application.OpenForms["frmVariantes"].Activate();
            }
            else
            {
                frmVariantes frm = new frmVariantes();
                //frm.MdiParent = this.MdiParent;
                frm.CaracteristicaSeleccionada = car.CodCaracteristica;
                frm.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCaracteristicas.CurrentRow.Index != -1 && car.CodCaracteristica != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Caracteristica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCar.delete(car.CodCaracteristica))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Caracteristica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable dt = new DataTable("Almacenes");
            // Columnas
            foreach (DataGridViewColumn column in dgvCaracteristicas.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvCaracteristicas.Rows.Count; i++)
            {
                DataGridViewRow row = dgvCaracteristicas.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvCaracteristicas.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmCaracteristicasRP frm = new frmCaracteristicasRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void frmCaracteristicas_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
