using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Reportes
{
    public partial class frmParamDespachoxArticulo : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsReporteDespacho ds = new clsReporteDespacho();
        public frmParamDespachoxArticulo()
        {
            InitializeComponent();
        }

        private void frmParamDespachoxArticulo_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            cmbEmpresa.SelectedIndex = 0;
        }

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = 0;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRDespachoxArticulo rpt = new CRDespachoxArticulo();
            frmRptDespachoArticulo frm = new frmRptDespachoArticulo();
            rpt.SetDataSource(ds.articulo(frmLogin.iCodAlmacen,dtpFecha1.Value,dtpFecha2.Value).Tables[0]);
            frm.crvDespacho.ReportSource = rpt;
            frm.Show();
        }
    }
}
