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
    public partial class frmTransacciones : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        public clsTransaccion tran = new clsTransaccion();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)Buscar Ingreso (4) Buscar Salida

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public List<Int32> config = new List<Int32>();


        public frmTransacciones()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            LimpiaConfiguracion();
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
            cbTipo.SelectedIndex = -1;
            superValidator1.Validate();
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

        private void frmTransacciones_Load(object sender, EventArgs e)
        {
            if (Proceso == 3 || Proceso == 4)
            {
                CargaLista(0);
                tipotext.Visible = false;
                bloquearbotones();
            }
            else
            {
                CargaLista(2);
                label2.Text = "Sigla";
                label3.Text = "sigla";
            }
        }

        private void bloquearbotones()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnReporte.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTransacciones.Rows.Count >= 1 && dgvTransacciones.SelectedRows.Count > 0)
            {
                CambiarEstados(false);
                groupBox2.Text = "Editar Registro";
                Proceso = 2;
                txtSigla.Text = tran.Sigla;
                txtDescripcion.Text = tran.Descripcion;
                cbTipo.SelectedIndex = tran.Tipo;
                CargaConfiguracion();
            }
        }

        private void CargaLista(Int32 caso)
        {     
            try
            {
                if (data.DataSource != null)
                {
                    DataTable dt = (DataTable)data.DataSource;
                    dt.Clear();
                }
                dgvTransacciones.DataSource = data;
                data.DataSource = AdmTran.MuestraTransacciones(caso);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvTransacciones.ClearSelection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        private void CargaConfiguracion()
        {            
            foreach (CheckBox c in tabPage1.Controls)
            {
                Int32 con = Convert.ToInt32(c.TabIndex);
                if (tran.Configuracion.Contains(con))
                {
                   c.Checked = true;
                }
                else
                {
                    c.Checked = false;
                }                
            }
            foreach (CheckBox c in tabPage2.Controls)
            {
                Int32 con = Convert.ToInt32(c.TabIndex);
                if (tran.Configuracion.Contains(con))
                {
                    c.Checked = true;
                }
                else
                {
                    c.Checked = false;
                }
            } 
        }

        private void frmTransacciones_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
            if (Proceso == 3)
            {
                CargaLista(0);
                tipotext.Visible = false;
            }else if(Proceso == 4)
            {
                CargaLista(1);
                tipotext.Visible = false;
            }
            else
            {
                CargaLista(2);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                if (superValidator1.Validate())
                {
                    if (Proceso != 0 && txtSigla.Text != "" && txtDescripcion.Text != "" && cbTipo.SelectedIndex != -1)
                    {
                        tran.Sigla = txtSigla.Text;
                        tran.Descripcion = txtDescripcion.Text;
                        tran.Tipo = cbTipo.SelectedIndex;
                        RecorreConfiguracion();

                        if (Proceso == 1)
                        {
                            tran.CodUser = frmLogin.iCodUser;
                            if (AdmTran.insert(tran))
                            {
                                GuardaConfig();
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Transaccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista(2);
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmTran.update(tran))
                            {
                                GuardaConfig();
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Transacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista(2);
                            }
                        }
                        Proceso = 0;
                    }
                }
            }
            else if (btnGuardar.Text == "Aceptar")
            {
                if (Proceso == 3 || Proceso == 4)
                {
                    this.Close();
                }
            }
        }

        private void GuardaConfig()
        {            
            AdmTran.LimpiarConfiguracion(tran.CodTransaccion);
            if (config.Count > 0)
            {                
                foreach (Int32 con in tran.Configuracion)
                {
                    AdmTran.insertConf(tran.CodTransaccion, con, frmLogin.iCodUser);
                }
            }            
        }

        private void dgvTransacciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTransacciones.Rows.Count >= 1 && e.Row.Selected)
            {
                tran.CodTransaccion = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                tran.Sigla = e.Row.Cells[sigla.Name].Value.ToString();
                tran.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                tran.Tipo = Convert.ToInt32(e.Row.Cells[tipo.Name].Value);
                tran.Configuracion = AdmTran.MuestraConfiguracion(tran.CodTransaccion);
                tran.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                tran.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                if (Proceso == 3 || Proceso == 4)
                {
                    btnGuardar.Enabled = true;
                }
            }
            else if (dgvTransacciones.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void RecorreConfiguracion()
        {
            config.Clear();            
            foreach (CheckBox c in tabPage1.Controls)
            {
                if (c.Checked)
                {
                    config.Add(Convert.ToInt32(c.TabIndex));
                }
            }
            foreach (CheckBox c in tabPage2.Controls)
            {
                if (c.Checked)
                {
                    config.Add(Convert.ToInt32(c.TabIndex));
                }
            }
            tran.Configuracion = config;
        }

        private void LimpiaConfiguracion()
        {
            config.Clear();
            foreach (CheckBox c in tabPage1.Controls)
            {
                c.Checked = false;
            }
            foreach (CheckBox c in tabPage2.Controls)
            {
                c.Checked = false;
            }
            tabControl1.SelectedIndex = 0;
        }

        private void dgvTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Proceso == 3)
            //{
            //    //frmNotaIngreso.CodTransaccion = tran.CodTransaccion;                
            //    frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
            //    form.CodTransaccion = tran.CodTransaccion;
            //    this.Close();
            //}
            //else if (Proceso == 4)
            //{
            //    //frmNotaIngreso.CodTransaccion = tran.CodTransaccion;                
            //    frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
            //    form.CodTransaccion = tran.CodTransaccion;
            //    this.Close();
            //}
            if (Proceso == 3 || Proceso == 4)
            {
                this.Close();
            }
        }

        private void dgvTransacciones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvTransacciones.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvTransacciones.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
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
            if (dgvTransacciones.CurrentRow.Index != -1 && tran.CodTransaccion != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Transaccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmTran.delete(tran.CodTransaccion))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Transaccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista(2);
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Transacciones");
            // Columnas
            foreach (DataGridViewColumn column in dgvTransacciones.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvTransacciones.Rows.Count; i++)
            {
                DataGridViewRow row = dgvTransacciones.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvTransacciones.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmTransaccionesRP frm = new frmTransaccionesRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }
        
    }
}
