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
    public partial class frmUtilidad : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteKardex ds = new clsReporteKardex();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();

        public frmUtilidad()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
           

            CRUtilidad2 rpt1 = new CRUtilidad2();
            frmRptUtilidad frm = new frmRptUtilidad();
            DataTable nuevo = new DataTable();

            try
            {
                if (rbArt.Checked)
                {
                    if (txtUnArt.Text != "")
                    {
                        /*nuevo = ds.kardex4(dtpFecha1.Value, dtpFecha2.Value, rbTodosArt.Checked, txtUnArt.Text, frmLogin.iCodAlmacen).Tables[0];
                        rpt1.SetDataSource(nuevo);
                        frm.crvInventario.ReportSource = rpt1;
                        frm.Show();*/
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
                        rpt1.SetDataSource(ds.UtilidadProducto(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen, frmLogin.iCodSucursal,Convert.ToInt32(pro.CodProducto)).Tables[0]);
                        nuevo = ds.Utilidad(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen, frmLogin.iCodSucursal).Tables[0];
                        frm.crvInventario.ReportSource = rpt1;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe elegir un producto");
                    }
                }

                if (rbTodosArt.Checked)
                {
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
                    rpt1.SetDataSource(ds.Utilidad2(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen, frmLogin.iCodSucursal).Tables[0]);
                    nuevo = ds.Utilidad(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen, frmLogin.iCodSucursal).Tables[0];
                    frm.crvInventario.ReportSource = rpt1;
                    frm.Show();
                }
                //nuevo = ds.Utilidad(dtpFecha1.Value, dtpFecha2.Value, frmLogin.iCodAlmacen,frmLogin.iCodSucursal).Tables[0];
                /*if (nuevo != null)
                {
                    rpt1.SetDataSource(nuevo);
                    frm.crvInventario.ReportSource = rpt1;
                    frm.Show();
                }
                else {
                    MessageBox.Show("No Hay registros por mostrar..!","Utilidad",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }*/
                


               
                //this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUnArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosLista frm = new frmProductosLista();
                frm.Procede = 20;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargaProducto(frm.GetCodigoProducto());
                }
            }
        }

        private void CargaProducto(Int32 Codigo)
        {
            pro = AdmPro.CargaProducto(Codigo, frmLogin.iCodAlmacen);
            txtUnArt.Text = pro.Referencia;
            txtArticulo.Text = pro.Descripcion;
        }

        private void rbArt_CheckedChanged(object sender, EventArgs e)
        {
            txtUnArt.Text = "";
            txtArticulo.Text = "";
            txtUnArt.Enabled = rbArt.Checked;
            txtUnArt.Focus();
            pro.CodProducto = 0;
        }

        private void frmParamKardexArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
