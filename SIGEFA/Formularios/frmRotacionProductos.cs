using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmRotacionProductos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        clsRotacionProductos ds = new clsRotacionProductos();
        private Int32 mesInicio = 0;
        private Int32 mesFin = 0;
        public frmRotacionProductos()
        {
            InitializeComponent();
        }

        private void CargaAlmacen()
        {
            cmbAlmacen.DataSource = admAlm.CargaAlmacen2(frmLogin.iCodEmpresa);
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.SelectedIndex = -1;
        }

        private void frmRotacionProductos_Load(object sender, EventArgs e)
        {
            dtpFecha1.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            dtpFecha2.MaxDate = Convert.ToDateTime(System.DateTime.Now);
            cmbMes1.SelectedIndex = 0;
            cmbMes2.SelectedIndex = 0;
            CargaAlmacen();
            rbFechas.Checked = true;
            rbTodoAlmacen.Checked = true;
            cmbAño.SelectedValue = DateTime.Now.Year;
            llenacombos();
        }

        private void llenacombos()
        {
            DataTable dt1 = new DataTable("Tabla1");

            dt1.Columns.Add("Codigo");
            dt1.Columns.Add("Descripcion");

            DataRow dr1;
            dr1 = dt1.NewRow(); dr1[0] = "2013"; dr1[1] = "2013"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2014"; dr1[1] = "2014"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2015"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2016"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2017"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2018"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2019"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2020"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2021"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2022"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2023"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2024"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2025"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2026"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2027"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2028"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2029"; dt1.Rows.Add(dr1);
            dr1 = dt1.NewRow(); dr1[0] = "2015"; dr1[1] = "2030"; dt1.Rows.Add(dr1);

            cmbAño.DataSource = dt1;
            cmbAño.ValueMember = "Codigo";
            cmbAño.DisplayMember = "Descripcion";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechas.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                dtpFecha1.Visible = true;
                dtpFecha2.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                dtpFecha1.Visible = false;
                dtpFecha2.Visible = false;
            }
        }

        private void rbMeses_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMeses.Checked)
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                cmbMes1.Visible = true;
                cmbMes2.Visible = true;
                cmbAño.Visible = true;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                cmbMes1.Visible = false;
                cmbMes2.Visible = false;
                cmbAño.Visible = false;
                cmbMes1.SelectedIndex = -1;
                cmbMes2.SelectedIndex = -1;
            }
        }

        private void rbUnAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnAlmacen.Checked)
            {
                cmbAlmacen.Visible = true;
            }
            else
            {
                cmbAlmacen.Visible = false;
                cmbAlmacen.SelectedIndex = -1;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                mesInicio = (cmbMes1.SelectedIndex + 1);
                mesFin = (cmbMes2.SelectedIndex + 1);
                CRRotacionProducto rpt = new CRRotacionProducto();
                frmRptRotacionProducto frm = new frmRptRotacionProducto();
                DataTable dt = ds.ReportRotacionProductos(rbTodoAlmacen.Checked, rbFechas.Checked, dtpFecha1.Value, dtpFecha2.Value,
                                  mesInicio, mesFin, cmbAño.SelectedText, Convert.ToInt32(cmbAlmacen.SelectedValue)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rpt.SetDataSource(dt);
                    frm.cRVRotacionProducto.ReportSource = rpt;
                    frm.Show();
                }
            }catch(Exception ex)
            {
               MessageBox.Show(ex.Message,"Rotación de Productos");
            }
        }

        private void frmRotacionProductos_Shown(object sender, EventArgs e)
        {
            cmbAño.Focus();
        }       
    }
}
