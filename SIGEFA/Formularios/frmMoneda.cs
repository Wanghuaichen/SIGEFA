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
    public partial class frmMoneda : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmMoneda AdmMoneda = new clsAdmMoneda();
        public clsMoneda moneda = new clsMoneda();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)CONSULTA F1
        public Int32 Procedencia = 0; //(1)Nota Ingreso (2)Nota Salida 

        clsValidar ok = new clsValidar();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;


        public frmMoneda()
        {
            InitializeComponent();
        }

        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Descripcion";
            label3.Text = "descripcion";
            if (Proceso == 3)
            {
                bloquearbotones();
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

        private void CargaPais()
        {
            cmbPais.DataSource = AdmMoneda.CargaPais();
            cmbPais.DisplayMember = "PAI_NOMBRE";
            cmbPais.ValueMember = "PA_COD";
            cmbPais.SelectedIndex = -1;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            CargaPais();
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
            cmbPais.Enabled = !Estado;
            txtDescripcion.Text = "";
            superValidator1.Validate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            CargaPais();
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            cmbPais.SelectedValue = moneda.IcodPais;
            txtDescripcion.Text = moneda.SDescripcion;
        }       

        private void CargaLista()
        {
            dgvFormaPagos.DataSource = data;
            data.DataSource = AdmMoneda.ListaMonedas();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvFormaPagos.ClearSelection();
        }

        private void frmFormaPago_Shown(object sender, EventArgs e)
        {
            CargaLista();
            txtFiltro.Focus();
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
                    if (Proceso != 0 && cmbPais.SelectedIndex>=0 && txtDescripcion.Text != "")
                    {
                        moneda.IcodPais = Convert.ToInt32(cmbPais.SelectedValue);
                        moneda.SDescripcion = txtDescripcion.Text;

                        if (Proceso == 1)
                        {
                            moneda.ICodUser = frmLogin.iCodUser;
                            if (AdmMoneda.insert(moneda))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmMoneda.update(moneda))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        Proceso = 0;
                    }
                }
            }
            else if(btnGuardar.Text == "Aceptar")
            {
                if (Proceso == 3)
                {
                    this.Close();
                }
            }
        }


        private void dgvDocumentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvFormaPagos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvFormaPagos.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFormaPagos.CurrentRow.Index != -1 && moneda.IcodMoneda != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Moneda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmMoneda.delete(moneda.IcodMoneda))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {                 
                //frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                //form.CodDocumento = doc.CodFormaPago;
                //form.txtDocRef.Text = doc.Sigla;
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

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable("FormaPago");
            //// Columnas
            //foreach (DataGridViewColumn column in dgvFormaPagos.Columns)
            //{
            //    DataColumn dc = new DataColumn(column.Name.ToString());
            //    dt.Columns.Add(dc);
            //}
            //// Datos
            //for (int i = 0; i < dgvFormaPagos.Rows.Count; i++)
            //{
            //    DataGridViewRow row = dgvFormaPagos.Rows[i];
            //    DataRow dr = dt.NewRow();
            //    for (int j = 0; j < dgvFormaPagos.Columns.Count; j++)
            //    {
            //        dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
            //    }
            //    dt.Rows.Add(dr);
            //}

            //frmFormaPagoRP frm = new frmFormaPagoRP();
            //frm.DTable = dt;
            //frm.Show();
        }

        private void dgvFormaPagos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvFormaPagos.Rows.Count >= 1 && e.Row.Selected)
            {
                moneda.IcodMoneda = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                moneda.SDescripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                moneda.IcodPais = Convert.ToInt32(e.Row.Cells[codigoPais.Name].Value);
                moneda.SNombrePais = e.Row.Cells[Pais.Name].Value.ToString();
                moneda.ICodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                moneda.DtFechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                if (Proceso == 3)
                {
                    btnGuardar.Enabled = true;
                }
            }
            else if (dgvFormaPagos.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0 && c.Visible)
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
