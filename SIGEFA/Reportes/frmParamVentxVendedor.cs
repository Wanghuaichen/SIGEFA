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
    public partial class frmParamVentxVendedor : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteVentasxVendedor ds = new clsReporteVentasxVendedor();
        clsVendedor vend = new clsVendedor();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmVendedor admVen = new clsAdmVendedor();

        clsAdmZona admZona = new clsAdmZona();

        public frmParamVentxVendedor()
        {
            InitializeComponent();
        }

        private void frmParamVentxVendedor_Load(object sender, EventArgs e)
        {
            label3.Location = new Point(17, 58);
            cmbVendedor.Location = new Point(19,78);
            CargaFormaPagos();
            CargaVendedores();
            //CargaZonas();
            cmbFormaPago.SelectedIndex = 0;
            //cmbZona.SelectedIndex = 0;

        }

       

        //private void CargaZonas()
        //{
        //    cmbZona.DataSource = admZona.CargaZonasReporte();
        //    cmbZona.DisplayMember = "descripcion";
        //    cmbZona.ValueMember = "codZona";
        //    cmbZona.SelectedIndex = 0;
        //}

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagosReporte();
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
        }

        private void CargaVendedores()
        {
            cmbVendedor.DataSource = admVen.CargaVendedoresReporte();
            cmbVendedor.DisplayMember = "apellido";
            cmbVendedor.ValueMember = "codVendedor";
            cmbVendedor.SelectedIndex = 0;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRVentasVendedor rpt = new CRVentasVendedor();
            frmRptVentxVendedor frm = new frmRptVentxVendedor();
            //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue),Convert.ToInt32(cmbVendedor.SelectedValue), Convert.ToInt32(cmbZona.SelectedValue)).Tables[0]);
            DataTable dt = ds.Reporte(frmLogin.iCodAlmacen, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue), Convert.ToInt32(cmbVendedor.SelectedValue)).Tables[0];
            if(dt.Rows.Count>0){
                rpt.SetDataSource(dt);
                frm.crvRptVentxVendedor.ReportSource = rpt;
                frm.Show();
            }
        }
    }
}
