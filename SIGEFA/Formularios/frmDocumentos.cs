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
    public partial class frmDocumentos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmTipoDocumento AdmDoc = new clsAdmTipoDocumento();
        public clsTipoDocumento doc = new clsTipoDocumento();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar (3)CONSULTA F1
        public Int32 Procedencia = 0; //(1)Nota Ingreso (2)Nota Salida (2)
        public Int32 direccioncaja = 0; //cuando abre desde cajamovimiento
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public String Transaccion = "";

        public frmDocumentos()
        {
            InitializeComponent();
        }

        private void frmDocumentos_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Sigla";
            label3.Text = "sigla";
            if (Proceso == 3 && Procedencia == 1 && (Transaccion.Equals("IOC") || Transaccion.Equals("TD"))) 
            {
                bloquearbotones();
                CargaLista3();
            }
            //else if (Proceso == 4 && Transaccion.Equals("FT") && Procedencia == 2)
            //{
            //    bloquearbotones();
            //    CargaLista();
            //}
            else if (Proceso == 3 || Proceso == 4)
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
            btnSeries.Visible = false;
            btnGuardar.Text = "Aceptar";
            btnGuardar.ImageIndex = 6;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnGuardar.Visible = !Estado;
            btnSeries.Visible = Estado;
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
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            txtSigla.Text = doc.Sigla;
            txtDescripcion.Text = doc.Descripcion;
        }       

        private void CargaLista()
        {
            if (direccioncaja == 1)
            {
                dgvDocumentos.DataSource = data;
                data.DataSource = AdmDoc.MuestraTipoDocumentosDeCaja();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvDocumentos.ClearSelection();
            }
            else
            {
                dgvDocumentos.DataSource = data;
                data.DataSource = AdmDoc.MuestraTipoDocumentos();
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvDocumentos.ClearSelection();
            }
        }

        private void CargaLista3()
        {
            dgvDocumentos.DataSource = data;
            data.DataSource = AdmDoc.ListaDocumentoNota();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }

        private void frmDocumentos_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
            if (Proceso == 3 && Procedencia == 1 && Transaccion.Equals("IOC") || Transaccion.Equals("TD"))
            {
                bloquearbotones();
                CargaLista3();
            }
            //else if (Proceso == 4 && Transaccion.Equals("FT") && Procedencia == 2)
            //{
            //    //bloquearbotones();
            //    CargaLista3();
            //}
            else
            {
                CargaLista();
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
                    if (Proceso != 0 && txtSigla.Text != "" && txtDescripcion.Text != "")
                    {
                        doc.Sigla = txtSigla.Text;
                        doc.Descripcion = txtDescripcion.Text;

                        if (Proceso == 1)
                        {
                            doc.CodUser = frmLogin.iCodUser;
                            if (AdmDoc.insert(doc))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        else if (Proceso == 2)
                        {
                            if (AdmDoc.update(doc))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Proceso == 3 || Proceso == 4)
                {
                    this.Close();
                }
            }
        }

        private void dgvDocumentos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//MOD4
        {
            //if (dgvDocumentos.Rows.Count >= 1 && e.Row.Selected)
            //{
            //    doc.CodTipoDocumento = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            //    doc.Sigla = e.Row.Cells[sigla.Name].Value.ToString();
            //    doc.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
            //    doc.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
            //    doc.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
            //    btnEditar.Enabled = true;
            //    btnSeries.Enabled = true;
            //    btnEliminar.Enabled = true;
            //    if (Proceso == 3 || Proceso == 4)
            //    {
            //        btnGuardar.Enabled = true;
            //    }
            //}
            //else if (dgvDocumentos.SelectedRows.Count == 0)
            //{
            //    btnEditar.Enabled = false;
            //    btnEliminar.Enabled = false;
            //    btnSeries.Enabled = false;
            //}
        }

        private void dgvDocumentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvDocumentos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvDocumentos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocumentos.CurrentRow.Index != -1 && doc.CodTipoDocumento != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmDoc.delete(doc.CodTipoDocumento))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3 || Proceso == 4)
            {                 
                //frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                //form.CodDocumento = doc.CodTipoDocumento;
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

        private void btnSeries_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSerie"] != null)
            {
                Application.OpenForms["frmSerie"].Activate();
            }
            else
            {
                frmSerie frm = new frmSerie();
                //frm.MdiParent = this.MdiParent;
                frm.DocSeleccionado = doc.CodTipoDocumento;
                frm.Sigla = doc.Sigla;
                frm.ShowDialog();
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Documentos");
            // Columnas
            foreach (DataGridViewColumn column in dgvDocumentos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvDocumentos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvDocumentos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvDocumentos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmDocumentosRP frm = new frmDocumentosRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)//MOD4
        {
            try
            {
                if (dgvDocumentos.Rows.Count >= 1 && e.RowIndex != -1 && dgvDocumentos.CurrentRow.Index == e.RowIndex)
                {
                    DataGridViewRow Row = dgvDocumentos.Rows[e.RowIndex];
                    doc.CodTipoDocumento = Convert.ToInt32(Row.Cells[codigo.Name].Value);
                    doc.Sigla = Row.Cells[sigla.Name].Value.ToString();
                    doc.Descripcion = Row.Cells[descripcion.Name].Value.ToString();
                    doc.CodUser = Convert.ToInt32(Row.Cells[coduser.Name].Value);
                    doc.FechaRegistro = Convert.ToDateTime(Row.Cells[fecha.Name].Value);
                    btnEditar.Enabled = true;
                    btnSeries.Enabled = true;
                    btnEliminar.Enabled = true;
                    if (Proceso == 3 || Proceso == 4)
                    {
                        btnGuardar.Enabled = true;
                    }
                }
                else if (dgvDocumentos.SelectedRows.Count == 0)
                {
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnSeries.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
