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
using System.Drawing.Printing;

namespace SIGEFA.Formularios
{
    public partial class frmSerie : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmSerie Admser = new clsAdmSerie();
        public clsSerie ser = new clsSerie();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento td = new clsTipoDocumento();
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        public Int32 DocSeleccionado;
        public String Sigla;
        public Int32 Proceso = 0; //(1) Nueva Linea (2)Editar Linea (3)f1 ayuda
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsValidar ok = new clsValidar();
        public Int32 CodAlma = 0;
        public frmSerie()
        {
            InitializeComponent();
        }

        private void frmSerie_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            cmbEmpresa.SelectedValue = frmLogin.iCodEmpresa;
            CargaAlmacenes();
            CargaImpresoras();
            //CargaPaperSize();
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
            CargaLista();
            td = Admdoc.BuscaTipoDocumento(Sigla);
            label2.Text = "Codigo";
            label3.Text = "codSerie";
            if (Proceso == 3)
            {
                bloquearbotones();
            }
        }

        private void CargaImpresoras()
        {            
            foreach (String printname in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbImpresoras.Items.Add(printname); 
            }
        }

        private void CargaPaperSize()
        {
            cbDocumentoImpresora.Items.Clear();
            System.Drawing.Printing.PrintDocument printdoc = new System.Drawing.Printing.PrintDocument();
            printdoc.PrinterSettings.PrinterName = cbImpresoras.SelectedItem.ToString();
            //cbDocumentoImpresora.DisplayMember = "PaperName";
            foreach (PaperSize psize in printdoc.PrinterSettings.PaperSizes)
            {
                cbDocumentoImpresora.Items.Add(psize.PaperName);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
            txtTipoDoc.Text = td.Sigla;
            txtDescripcion.Text = td.Descripcion;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            Proceso = 2;
            groupBox2.Text = "Editar Registro";
            txtCodigo.Text = ser.CodSerie.ToString();
            txtTipoDoc.Text = td.Sigla;//ser.CodDocumento.ToString();
            txtDescripcion.Text = td.Descripcion;
            txtSerie.Text = ser.Serie;
            txtInicio.Text = ser.Inicio.ToString();
            txtFinal.Text = ser.Fin.ToString();
            txtCorrelativo.Text = ser.Numeracion.ToString();
            cbImpresoras.Text = ser.NombreImpresora;
            cbDocumentoImpresora.Text = ser.PaperSize;
            txtSerieImpresora.Text = ser.SerieImpresora;
            if (ser.PreImpreso)
            {
                chbManual.Visible = true;
                chbManual.Enabled = false;
            }
            else chbManual.Visible = false;
            chbManual.Checked = ser.PreImpreso;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnGuardar.Text == "Guardar")
                {
                    if (superValidator1.Validate())
                    {
                        if (Proceso != 0 && txtSerie.Text != "")
                        {
                            ser.CodDocumento = DocSeleccionado;
                            ser.CodAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
                            ser.Serie = txtSerie.Text;
                            ser.Inicio = Convert.ToInt32(txtInicio.Text);
                            ser.Fin = Convert.ToInt32(txtFinal.Text);
                            if (chbManual.Checked)
                            {
                                txtCorrelativo.Text = "";
                                txtCorrelativo.ReadOnly = true;
                                ser.Numeracion = 0;
                            }
                            else if (!chbManual.Checked && txtCorrelativo.Text == "")
                            {
                                MessageBox.Show("Debe Ingresar Número Correlativo", "Series", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                txtCorrelativo.Focus();
                                return;

                            }
                            if (!chbManual.Checked) ser.Numeracion = Convert.ToInt32(txtCorrelativo.Text);
                            //ser.Numeracion = Convert.ToInt32(txtCorrelativo.Text);
                            ser.NombreImpresora = cbImpresoras.SelectedItem.ToString();
                            ser.PaperSize = cbDocumentoImpresora.SelectedItem.ToString();
                            ser.SerieImpresora = txtSerieImpresora.Text;
                            ser.PreImpreso = chbManual.Checked;
                            if (Proceso == 1)
                            {
                                ser.CodUser = frmLogin.iCodUser;
                                if (Admser.insert(ser))
                                {
                                    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CambiarEstados(true);
                                    CargaLista();
                                }
                            }
                            else if (Proceso == 2)
                            {
                                if (Admser.update(ser))
                                {
                                    MessageBox.Show("Los datos se guardaron correctamente", "Gestion Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CambiarEstados(true);
                                    CargaLista();
                                }
                            }
                            Proceso = 0;
                        }
                    }
                }
                else if (btnGuardar.Text == "Aceptar")
                {
                    if (Proceso == 3)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe Elegir una impresora");
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

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = -1;
        }

        private void CargaAlmacenes()
        {
            cmbAlmacen.DataSource = admAlm.CargaAlmacenes(frmLogin.iNivelUser, Convert.ToInt32(cmbEmpresa.SelectedValue), frmLogin.iCodUser);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedIndex = -1;
        }

        private void CargaLista()
        {
            if (CodAlma != 0)
            {
                dgvSeries.DataSource = data;
                data.DataSource = Admser.MuestraSeries(DocSeleccionado, CodAlma);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvSeries.ClearSelection();
            }
            else
            {
                dgvSeries.DataSource = data;
                data.DataSource = Admser.MuestraSeries(DocSeleccionado, frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                dgvSeries.ClearSelection();
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
            txtTipoDoc.Text = "";
            txtSerie.Text = "";
            txtInicio.Text = "";
            txtFinal.Text = "";
            txtCorrelativo.Text = "";
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSeries.CurrentRow.Index != -1 && ser.CodSerie != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Serie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (Admser.delete(ser.CodSerie))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void dgvSeries_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvSeries.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvSeries.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void dgvSeries_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvSeries.Rows.Count >= 1 && e.Row.Selected)
            {
                ser.CodSerie = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                ser.CodDocumento = Convert.ToInt32(e.Row.Cells[coddocumento.Name].Value);                
                ser.Descripcion = e.Row.Cells[descripcion.Name].Value.ToString();
                ser.Serie = e.Row.Cells[serie.Name].Value.ToString();
                ser.Inicio = Convert.ToInt32(e.Row.Cells[inicio.Name].Value);
                ser.Fin = Convert.ToInt32(e.Row.Cells[fin.Name].Value);
                ser.Numeracion = Convert.ToInt32(e.Row.Cells[numeracion.Name].Value);
                ser.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                ser.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                ser.NombreImpresora = e.Row.Cells[nombreimpresora.Name].Value.ToString();
                ser.PaperSize = e.Row.Cells[papel.Name].Value.ToString();
                ser.SerieImpresora = e.Row.Cells[serie_impresora.Name].Value.ToString();
                if (e.Row.Cells[manual.Name].Value.ToString() == "MANUAL")
                {
                    ser.PreImpreso = true;
                }
                else ser.PreImpreso = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvSeries.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (chbManual.Checked)
            {
                txtCorrelativo.Text = "";
            }
        }

        private void txtInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void txtFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void dgvSeries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
                btnGuardar.Enabled = true;
        }

        private void dgvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {
                txtSerie.Text = dgvSeries.CurrentRow.Cells[serie.Name].Value.ToString();
                this.Close();
            }
        }

        private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaAlmacenes();
        }

        private void cbImpresoras_SelectedValueChanged(object sender, EventArgs e)
        {
            CargaPaperSize();
        }

        private void customValidator6_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void chbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chbManual.Checked)
            {
                txtCorrelativo.Text = "";
                txtCorrelativo.ReadOnly = true;
            }
        }

        private void frmSerie_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }       
    }
}
