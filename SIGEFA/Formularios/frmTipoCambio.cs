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
    public partial class frmTipoCambio : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio Tc = new clsTipoCambio();
        clsValidar ok = new clsValidar();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsMoneda Mon = new clsMoneda();
        clsAdmUnidad admunidad = new clsAdmUnidad();
        public Int32 Proceso = 0; //(1) Nuevo (2)Editar
        DataTable TipoCam = new DataTable();
        DataTable tb_unidadequivalente = new DataTable();


        public frmTipoCambio()
        {
            InitializeComponent();
        }

        public void btnNuevo_Click(object sender, EventArgs e)
        {
            CambiarEstados(false);
            cargaMoneda();
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
            txtCompra.Text = "";
            txtVenta.Text = "";
            dtpFecha.Value = DateTime.Now.Date;
            superValidator1.Validate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTipoCambio.Rows.Count >= 1 && dgvTipoCambio.SelectedRows.Count > 0)
            {
                CambiarEstados(false);
                cargaMoneda();
                groupBox2.Text = "Editar Registro";
                Proceso = 2;
                dtpFecha.Value = Tc.Fecha.Date;
                cmbMoneda.SelectedValue = Tc.ICodMoneda;
                txtCompra.Text = Tc.Compra.ToString();
                txtVenta.Text = Tc.Venta.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTipoCambio.Rows.Count >= 1 && dgvTipoCambio.SelectedRows.Count > 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Tipo de cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmTc.delete(Tc.CodTipoCambio))
                    {
                        MessageBox.Show("El Tipo de Cambio ha sido eliminado", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void CargaLista()
        {
            dgvTipoCambio.DataSource = AdmTc.MuestraTipoCambios(Convert.ToInt32(cmbMes.SelectedValue), Convert.ToInt32(cmbAño.SelectedValue));
            dgvTipoCambio.ClearSelection();
        }

        private void llenacombos()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descripcion");

            DataRow dr;

            dr = dt.NewRow(); dr[0] = "1"; dr[1] = "ENERO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "2"; dr[1] = "FEBRERO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "3"; dr[1] = "MARZO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "4"; dr[1] = "ABRIL"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "5"; dr[1] = "MAYO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "6"; dr[1] = "JUNIO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "7"; dr[1] = "JULIO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "8"; dr[1] = "AGOSTO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "9"; dr[1] = "SETIEMBRE"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "10"; dr[1] = "OCTUBRE"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "11"; dr[1] = "NOVIEMBRE"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr[0] = "12"; dr[1] = "DICIEMBRE"; dt.Rows.Add(dr);

            cmbMes.DataSource = dt;
            cmbMes.ValueMember = "Codigo";
            cmbMes.DisplayMember = "Descripcion";

            DataTable dt1 = new DataTable("Tabla1");

            dt1.Columns.Add("Codigo");
            dt1.Columns.Add("Descripcion");

            DataRow dr1;
            dr1 = dt1.NewRow(); dr1[0] = "2013"; dr1[1] = "2013"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2014"; dr1[1] = "2014"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2015"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2016"; dr1[1] = "2016"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2017"; dr1[1] = "2017"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2018"; dr1[1] = "2018"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2019"; dr1[1] = "2019"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2020"; dr1[1] = "2020"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2021"; dr1[1] = "2021"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2022"; dr1[1] = "2022"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2023"; dr1[1] = "2023"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2024"; dr1[1] = "2024"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2025"; dr1[1] = "2025"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2026"; dr1[1] = "2026"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2027"; dr1[1] = "2027"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2028"; dr1[1] = "2028"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2029"; dr1[1] = "2029"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2030"; dr1[1] = "2030"; dt1.Rows.Add(dr1);

            cmbAño.DataSource = dt1;
            cmbAño.ValueMember = "Codigo";
            cmbAño.DisplayMember = "Descripcion";
        }

        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            llenacombos();
            //cargaMoneda();
            cmbMes.SelectedValue = DateTime.Now.Month;
            cmbAño.SelectedValue = DateTime.Now.Year;
            CargaLista();
        }

        private void cargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.ListaMonedas();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                this.Dispose();
                //Close();
            }
            else
            {
                Proceso = 0;
                CambiarEstados(true);
            }
        }

        private void dgvTipoCambio_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTipoCambio.Rows.Count >= 1 && e.Row.Selected)
            {
                Tc.CodTipoCambio = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                Tc.Fecha = Convert.ToDateTime(e.Row.Cells[fecha.Name].Value);
                Tc.Compra = Convert.ToDouble(e.Row.Cells[compra.Name].Value);
                Tc.Venta = Convert.ToDouble(e.Row.Cells[venta.Name].Value);
                Tc.CodUser = Convert.ToInt32(e.Row.Cells[coduser.Name].Value);
                Tc.ICodMoneda = Convert.ToInt32(e.Row.Cells[codmoneda.Name].Value);
                Tc.FechaRegistro = Convert.ToDateTime(e.Row.Cells[fecharegistro.Name].Value);
                btnEditar.Enabled = true;
            }
            else if (dgvTipoCambio.SelectedRows.Count == 0)
            {
                btnEditar.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                if (Proceso != 0 && txtCompra.Text != "" && txtVenta.Text != "")
                {
                    //tb_unidadequivalente.Clear();
                    Tc.Fecha = dtpFecha.Value.Date;
                    Tc.Compra = Convert.ToDouble(txtCompra.Text);
                    Tc.Venta = Convert.ToDouble(txtVenta.Text);
                    if (label3.Text != "")
                    {
                        Tc.ICodMoneda = 2;
                    }
                    else
                    {
                        Tc.ICodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
                    }
                    if (Proceso == 1)
                    {
                        Tc.CodUser = frmLogin.iCodUser;
                        if (!AdmTc.VerificaTCFecha(dtpFecha.Value.Date))
                        {
                            if (AdmTc.insert(Tc))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Int32 validaMo = admunidad.ValidaMoneda();
                                if (validaMo > 0)
                                {
                                    Boolean resultado = admunidad.ActualizaPrecioEnDolares();
                                    //Int32 resultado2 = admunidad.CantidadProductosDolares();
                                    if (resultado == false)
                                    {
                                        MessageBox.Show("Error");
                                    }
                                }
                                CambiarEstados(true);
                                CargaLista();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un Tipo de cambio registrado en esta fecha", "Gestion Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmTc.update(Tc))
                        {
                            MessageBox.Show("Los datos se guardaron correctamente", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CambiarEstados(true);
                            CargaLista();
                        }
                    }
                    Proceso = 0;
                }
            }
        }

        private void cmbMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLista();
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("TipoCambio");
            // Columnas
            foreach (DataGridViewColumn column in dgvTipoCambio.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvTipoCambio.Rows.Count; i++)
            {
                DataGridViewRow row = dgvTipoCambio.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvTipoCambio.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            frmTipoCambioRP frm = new frmTipoCambioRP();
            frm.DTable = dt;
            frm.Show();
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultartipocambio(dtpFecha.Value);
        }

        private void consultartipocambio(DateTime Fechabuscada)
        {
            clsConsultasExternas ext = new clsConsultasExternas();
            TipoCam = ext.ConsultaTCSunat(Fechabuscada);
            if (TipoCam != null)
            {
                //var sdiabuscado = TipoCam.Select("Día = '" + Fechabuscada.Date.Day.ToString() + "'");
                String cadenabusqueda = "[Día] like '*" + Fechabuscada.Date.Day.ToString() + "*'";
                DataRow[] foundRows = TipoCam.Select(cadenabusqueda);
                //if (sdiabuscado.Length != 0)
                if (foundRows.Length != 0)
                {
                    foreach (DataRow r in TipoCam.Rows)
                    {
                        if (Convert.ToInt32(r[0]) == Fechabuscada.Date.Day)
                        {
                            txtCompra.Text = r[1].ToString();
                            txtVenta.Text = r[2].ToString();
                            label3.Text = Fechabuscada.ToShortDateString();
                            Mon = AdmMon.Buscamoneda("DOLARES AMERICANOS");
                            cmbMoneda.SelectedValue = Mon.IcodMoneda;
                            //cmbMoneda.SelectedIndex=(cmbMoneda.SelectedText="DOLARES");
                        }
                    }
                }
                else
                {
                    consultartipocambio(Fechabuscada.AddDays(-1));
                }
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
