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
using System.Net;
using System.IO;
using System.Xml;
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmComsionPorDocumento : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmVendedor vendedor = new clsAdmVendedor();
        clsAdmZona AdmZona = new clsAdmZona();
       
        public frmComsionPorDocumento()
        {
            InitializeComponent();
        }
        private void CalcularComision()
        {
            int i;
            Decimal comision_total = 0, comision = 0;

            if (dgvComisiones.Rows.Count > 0)
            {

                for (i = 0; i <= dgvComisiones.Rows.Count - 1; i++)
                {

                    comision = Convert.ToDecimal(dgvComisiones.Rows[i].Cells[comison.Name].Value);
                    comision_total = comision_total + comision;
                }
            }
            txtComisionTotal.Text = comision_total.ToString();
        }
        private void CargarComisiones()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisionesPorDocumentoFecha();
            dgvComisiones.ClearSelection();
        }
        private void FiltroComisiones()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisionPorDocumentoFecha(Convert.ToInt32(cmbMes.SelectedValue), Convert.ToInt32(cmbAño.SelectedValue));            
            dgvComisiones.ClearSelection();
        }
        private void FiltroComisionesVendedor()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisionPorDocumentoPorVendedor(Convert.ToInt32(cmbMes.SelectedValue), Convert.ToInt32(cmbAño.SelectedValue), Convert.ToInt32(cbVendedor.SelectedValue));
            dgvComisiones.ClearSelection();
        }
        private void FiltroComisionesVendedorZona()
        {
            dgvComisiones.DataSource = vendedor.MuestraComisionPorDocumentoPorVendedorZona(Convert.ToInt32(cmbMes.SelectedValue), Convert.ToInt32(cmbAño.SelectedValue), Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToInt32(cbZona.SelectedValue));
            dgvComisiones.ClearSelection();
        }
        private void frmComsionPorDocumento_Load(object sender, EventArgs e)
        {            
            llenacombos();
            cmbAño.SelectedValue = DateTime.Now.Year;
            cmbMes.SelectedValue = DateTime.Now.Month;
            CargarVendedores();
            CargaZonas();
            FiltroComisiones();
            CalcularComision();
        }

        private void CargaZonas()
        {
            cbZona.DataSource = AdmZona.MuestraZonas();
            cbZona.DisplayMember = "descripcion";
            cbZona.ValueMember = "codZona";
            cbZona.SelectedIndex = -1;
        }

        private void CargarVendedores()
        {
            cbVendedor.DataSource = vendedor.MuestraVendedoresCombo();
            cbVendedor.DisplayMember = "apellido";
            cbVendedor.ValueMember = "codVendedor";
            cbVendedor.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
            cmbMes.SelectedIndex = -1;

            DataTable dt1 = new DataTable("Tabla1");

            dt1.Columns.Add("Codigo");
            dt1.Columns.Add("Descripcion");

            DataRow dr1;
            dr1 = dt1.NewRow(); dr1[0] = "2013"; dr1[1] = "2013"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2014"; dr1[1] = "2014"; dt1.Rows.Add(dr1);

            cmbAño.DataSource = dt1;
            cmbAño.ValueMember = "Codigo";
            cmbAño.DisplayMember = "Descripcion";
            cmbAño.SelectedIndex = -1;
        }



        private void cmbAño_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltroComisiones();
            CalcularComision();
        }

        private void cmbMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltroComisiones();
            CalcularComision();
        }

        private void cbVendedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltroComisionesVendedor();
            CalcularComision();
        }

        private void cbZona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltroComisionesVendedorZona();
            CalcularComision();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("apellido", typeof(string));
            dt.Columns.Add("sigla", typeof(string));
            dt.Columns.Add("nro_documento", typeof(string));
            dt.Columns.Add("codper", typeof(string));
            dt.Columns.Add("razonsocial", typeof(string));
            dt.Columns.Add("zona", typeof(string));
            dt.Columns.Add("fechasalida", typeof(DateTime));
            dt.Columns.Add("total", typeof(decimal));
            dt.Columns.Add("anulado", typeof(string));
            dt.Columns.Add("notaCredito", typeof(string));
            dt.Columns.Add("monto", typeof(string));
            dt.Columns.Add("basex", typeof(string));
            dt.Columns.Add("comison", typeof(decimal));

            dt.Columns.Add("anio", typeof(string));
            dt.Columns.Add("mes", typeof(string));
            dt.Columns.Add("vendedor", typeof(string));

            foreach (DataGridViewRow dgv in dgvComisiones.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value,
                dgv.Cells[1].Value, dgv.Cells[2].Value,
                dgv.Cells[3].Value,
                dgv.Cells[4].Value,
                dgv.Cells[5].Value,
                Convert.ToDateTime(dgv.Cells[6].Value),
                Convert.ToDecimal(dgv.Cells[7].Value),
                dgv.Cells[8].Value,
                dgv.Cells[9].Value,
                dgv.Cells[10].Value,
                dgv.Cells[11].Value,
                Convert.ToDecimal(dgv.Cells[12].Value),
                cmbAño.Text,
                cmbMes.Text,
                cbVendedor.Text);
            }
            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\ComisionRPT.xml", XmlWriteMode.WriteSchema);

            CRComision rpt = new CRComision();
            frmRptComision frm = new frmRptComision();
            rpt.SetDataSource(ds);
            frm.crvComision.ReportSource = rpt;
            frm.Show();
        }
    }
}
