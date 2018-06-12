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
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmCuentasCte : DevComponents.DotNetBar.Office2007Form
    {
        clsCtaCte cta = new clsCtaCte();
        clsAdmCtaCte AdmCta = new clsAdmCtaCte();
        clsMoneda mon = new clsMoneda();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsBanco ban = new clsBanco();
        clsAdmBanco AdmBan = new clsAdmBanco();
        clsValidar ok = new clsValidar();

        public Int32 Proceso = 0; //(1) Nuevo (2)Editar

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmCuentasCte()
        {
            InitializeComponent();
        }
        
        private void CargaLista()
        {
            dgvCtaCte.DataSource = data;
            data.DataSource = AdmCta.ListaCtaCte(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCtaCte.ClearSelection();
        }

        private void CargaBancos()
        {
            cmbBanco.DataSource = AdmBan.MuestraBancos();
            cmbBanco.DisplayMember = "descripcion";
            cmbBanco.ValueMember = "codBanco";
            cmbBanco.SelectedIndex = -1;
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }
        private void frmCuentasCte_Load(object sender, EventArgs e)
        {
            CargaBancos();
            CargaMoneda();
            CargaLista();
            label2.Text = "Banco";
            label3.Text = "banco";
            groupBox1.Height = 317;
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

        private void CambiarEstados(Boolean Estado)
        {
            groupBox1.Visible = Estado;
            groupBox2.Visible = !Estado;
            btnGuardar.Enabled = !Estado;
            btnNuevo.Enabled = Estado;
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnReporte.Enabled = Estado;
            cmbBanco.SelectedIndex = -1;
            cmbMoneda.SelectedIndex = -1;
            txtCtaCte.Text = "";
            txtTipoCta.Text = "";
            superValidator1.Validate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Editar Registro";
            Proceso = 2;
            cmbBanco.SelectedValue = cta.CodBanco.ToString();
            txtCtaCte.Text = cta.CtaCte;
            txtTipoCta.Text = cta.TipoCuenta;
            cmbMoneda.SelectedValue = cta.Moneda;
        }

        private void frmCuentasCte_Shown(object sender, EventArgs e)
        {
            CargaLista();
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
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && cmbBanco.SelectedValue.ToString() != "" && txtCtaCte.Text != "" &&
                    txtTipoCta.Text != "" && cmbMoneda.SelectedValue.ToString() != "")
                {
                    cta.CodBanco = Convert.ToInt32(cmbBanco.SelectedValue);
                    cta.CtaCte = txtCtaCte.Text;
                    cta.TipoCuenta = txtTipoCta.Text;
                    cta.Moneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    cta.Coduser = frmLogin.iCodUser;
                    cta.CodAlmacen = frmLogin.iCodAlmacen;

                    if (Proceso == 1)
                    {
                        if (AdmCta.Insert(cta))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Gestion CtaCte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmCta.Update(cta))
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

        private void dgvCtaCte_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCtaCte.Rows.Count >= 1 && e.Row.Selected)
            {
                cta.CodCtaCte = Convert.ToInt32(e.Row.Cells[codCtaCte.Name].Value);
                cta.CodBanco = Convert.ToInt32(e.Row.Cells[codBanco.Name].Value);
                cta.CtaCte = e.Row.Cells[ctacte.Name].Value.ToString();
                cta.TipoCuenta = e.Row.Cells[tipoCuenta.Name].Value.ToString();
                cta.Moneda = Convert.ToInt32(e.Row.Cells[codMoneda.Name].Value);
                cta.Coduser = Convert.ToInt32(e.Row.Cells[codUser.Name].Value);
                cta.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecharegistro.Name].Value);
                cta.Estado = Convert.ToBoolean(e.Row.Cells[estado.Name].Value);
                cta.CodAlmacen = Convert.ToInt32(e.Row.Cells[codAlmacen.Name].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (dgvCtaCte.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvCtaCte_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvCtaCte.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvCtaCte.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCtaCte.CurrentRow.Index != -1 && cta.CodCtaCte != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "CtaCte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCta.Delete(cta.CodCtaCte, frmLogin.iCodAlmacen))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "CtaCte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            groupBox2.Text = "Registro Nuevo";
            Proceso = 1;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("CuentasCte");
            // Columnas
            foreach (DataGridViewColumn column in dgvCtaCte.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvCtaCte.Rows.Count; i++)
            {
                DataGridViewRow row = dgvCtaCte.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvCtaCte.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\CuentasCteRPT.xml", XmlWriteMode.WriteSchema);

            CRCtasCte rpt = new CRCtasCte();
            frmCuentasCorrienteRP frm = new frmCuentasCorrienteRP();
            rpt.SetDataSource(ds);
            frm.CRVCtasCte.ReportSource = rpt;
            frm.Show();
        }

        private void txtTipoCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.letras(e);
        }

        private void txtCtaCte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.NumerosEnteros(e);
            if (e.KeyChar == '-')
            {

                e.Handled = false;

            }
            else if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
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
    }
}
