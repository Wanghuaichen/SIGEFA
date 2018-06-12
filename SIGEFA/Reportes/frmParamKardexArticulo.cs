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
    public partial class frmParamKardexArticulo : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteKardex ds = new clsReporteKardex();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();

        public frmParamKardexArticulo()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //CRKardex rpt = new CRKardex();
            //frmRptKardex frm = new frmRptKardex();
            //rpt.SetDataSource(ds.kardex(dtpFecha1.Value, dtpFecha2.Value,pro.CodProducto,frmLogin.iCodAlmacen).Tables[0]);
            //frm.crvKardex.ReportSource = rpt;
            //frm.Show();

            CRKardex4 rpt1 = new CRKardex4();
            frmRptKardex frm = new frmRptKardex();
            DataTable nuevo = new DataTable();

            try
            {
                if (rbArt.Checked)
                {
                    if (txtUnArt.Text != "")
                    {
                        nuevo = ds.kardex4(dtpFecha1.Value, dtpFecha2.Value, rbTodosArt.Checked, txtUnArt.Text, frmLogin.iCodAlmacen).Tables[0];
                        rpt1.SetDataSource(nuevo);
                        frm.crvKardex.ReportSource = rpt1;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debe elegir un producto");
                    }
                }
                if (rbTodosArt.Checked)
                {
                    nuevo = ds.kardex4(dtpFecha1.Value, dtpFecha2.Value, rbTodosArt.Checked, txtUnArt.Text, frmLogin.iCodAlmacen).Tables[0];
                    rpt1.SetDataSource(nuevo);
                    frm.crvKardex.ReportSource = rpt1;
                    frm.Show();
                }
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
            }else if(e.KeyCode==Keys.Enter){
                try
                {
                   
                    if (txtUnArt.Text != "")
                    {
                        Int32 codPro = AdmPro.GetCodProducto_xDescripcion(txtUnArt.Text);

                        if (codPro != 0)
                        {
                            CargaProducto(codPro);


                        }
                    }
                    else {
                        MessageBox.Show("Faltan datos..!");
                    }
                }
                catch (Exception a) { MessageBox.Show(a.Message); }
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
