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
    public partial class frmParamDespachoDocumento : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsReporteDespacho ds = new clsReporteDespacho();

        public frmParamDespachoDocumento()
        {
            InitializeComponent();
        }

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = 0;
        }

        private void alinea_botones()
        {
            label1.Location = new Point(17,21);
            label2.Location = new Point(157,21);
            dtpFecha1.Location = new Point(19,39);
            dtpFecha2.Location = new Point(159,40);
        }

        private void frmParamDespachoDocumento_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            alinea_botones();

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRDespachoDocumento rpt = new CRDespachoDocumento();
            frmRptDespachoDocumento frm = new frmRptDespachoDocumento();
            rpt.SetDataSource(ds.documento(frmLogin.iCodAlmacen, dtpFecha1.Value,dtpFecha2.Value).Tables[0]);
            frm.crvDespachoDocumento.ReportSource = rpt;
            frm.Show();
        }
    }
}
