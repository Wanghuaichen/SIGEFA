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
using SIGEFA.Formularios;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Reportes
{
    public partial class frmParamVentSeparacion : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsAdmSucursal AdmSucur = new clsAdmSucursal();

        clsReporteVentSeparacion ds = new clsReporteVentSeparacion(); 

        public frmParamVentSeparacion()
        {
            InitializeComponent();
        }

        private void frmParamVentCredCont_Load(object sender, EventArgs e)
        {

            CargaFormaPagos();
            cmbFormaPago.SelectedIndex = 0;
        }

      

        //private void CargaSucursales()
        //{
        //    cmbEmpresa.DataSource = AdmSucur.
        //}

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagosReporte();
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                CRVentSeparacion rpt = new CRVentSeparacion();

                frmRptVentSeparacion frm = new frmRptVentSeparacion();
                //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue)).Tables[0]);
                DataTable dt = ds.Reporte(frmLogin.iCodEmpresa, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue), frmLogin.iCodSucursal, frmLogin.iCodAlmacen).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rpt.SetDataSource(dt);
                    frm.crvRptVentSeparacion.ReportSource = rpt;
                    //frm.crvRptVentCredContDia.ReportSource = rpt;
                    frm.Show();
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
