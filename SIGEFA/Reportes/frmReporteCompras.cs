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
    public partial class frmReporteCompras : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteVentasxVendedor ds = new clsReporteVentasxVendedor();
        clsVendedor vend = new clsVendedor();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmVendedor admVen = new clsAdmVendedor();
        CRCompras rpt;
        CRNIngreso rptNI; 
        clsAdmZona admZona = new clsAdmZona();
        DataTable dt = new DataTable();
        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void UtilidadProductos_Load(object sender, EventArgs e)
        {
           
           
            cmbtipo.SelectedIndex = 0;
            cmbtipo.SelectedIndex = -1;

        }

        private void CargaFormaPagos()
        {
            cmbtipo.DataSource = AdmPago.CargaFormaPagosReporte();
            cmbtipo.DisplayMember = "descripcion";
            cmbtipo.ValueMember = "codFormaPago";
            cmbtipo.SelectedIndex = 0;
        }

       

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbtipo.SelectedIndex == -1) { MessageBox.Show("Seleccione Tipo de Movimiento"); return; }

                
                frmRptVentxVendedor frm = new frmRptVentxVendedor();
                
                //rpt.SetDataSource(ds.Reporte(frmLogin.iCodSucursal, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue),Convert.ToInt32(cmbVendedor.SelectedValue), Convert.ToInt32(cmbZona.SelectedValue)).Tables[0]);
                switch (cmbtipo.SelectedIndex) { 
                    case 0: //Compras
                        rpt = new CRCompras();
                        dt = ds.ReporteCompras(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0];
                        break;  
                    case 1: //NIngresos
                        rptNI = new CRNIngreso();
                        dt = ds.ReporteNotasIngreso(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0];
                        break;
                    case 2: //NSalidas 
                        dt = ds.ReporteNotasIngreso(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0];
                        break;
                    case 3: //Transferencias
                        dt = ds.ReporteNotasIngreso(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen).Tables[0];
                        break;


                    
                }
                
                if (dt.Rows.Count > 0)
                {

                    switch (cmbtipo.SelectedIndex)
                    {
                        case 0: //Compras
                            rpt.SetDataSource(dt);
                            frm.crvRptVentxVendedor.ReportSource = rpt;
                            break;
                        case 1: //NIngresos
                           
                            break;
                        case 2: //NSalidas 
                           
                            break;
                        case 3: //Transferencias
                           
                            break;



                    }


                   
                    frm.Show();
                }
                else {
                    MessageBox.Show("No hay información para este rango de fechas..!","Reportes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

              
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

      

      
    }
}
