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
    public partial class frmParamVentxArticulo : DevComponents.DotNetBar.Office2007Form
    {
        clsReporteVentaxArticulo ds = new clsReporteVentaxArticulo();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmVendedor admVen = new clsAdmVendedor();
        clsAdmMoneda AdmMon = new clsAdmMoneda();

        public frmParamVentxArticulo()
        {
            InitializeComponent();
        }

        private void frmParamVentxArticulo_Load(object sender, EventArgs e)
        {
            CargaVendedores();
            CargaMoneda();
            cmbMoneda.SelectedIndex = 0;
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }    

        private void CargaVendedores()
        {
            cmbVendedor.DataSource = admVen.CargaVendedoresReporte();
            cmbVendedor.DisplayMember = "apellido";
            cmbVendedor.ValueMember = "codVendedor";
            cmbVendedor.SelectedIndex = 0;
        }


        private void rbArt_CheckedChanged(object sender, EventArgs e)
        {
            txtUnArt.Text = "";
            txtArticulo.Text = "";
            txtUnArt.Enabled = rbArt.Checked;
            txtUnArt.Focus();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRVentaxArticulo rpt = new CRVentaxArticulo();
            FrmRptVentaxArticulo frm = new FrmRptVentaxArticulo();
            rpt.SetDataSource(ds.Reporte(Convert.ToInt32(txtCodProducto.Text), dtpFecha1.Value, dtpFecha2.Value, rbTodosArt.Checked, Convert.ToInt32(cmbVendedor.SelectedValue),
                frmLogin.iCodAlmacen, Convert.ToInt32(cmbMoneda.SelectedValue)).Tables[0]);
            frm.crvVentaxArticulo.ReportSource = rpt;
            frm.Show();
        }

        private void txtUnArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosLista frm = new frmProductosLista();
                frm.Procede = 15; //(15) Procede desde el formulario frmParamVentxVendedor
                if (frm.ShowDialog() == DialogResult.OK){
                    if (frm.pro.CodProducto != 0)
                        CargaProducto(frm.pro.CodProducto);
                }
            }
        }

        private void CargaProducto(Int32 Codigo)
        {
            pro = AdmPro.CargaProducto(Codigo, frmLogin.iCodAlmacen);
            txtUnArt.Text = pro.Referencia;
            txtCodProducto.Text = pro.CodProducto.ToString();
            txtArticulo.Text = pro.Descripcion;
        }

        private void txtUnArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtUnArt.Text != "")
                {
                    if (BuscaProducto())
                    {
                        ProcessTabKey(true);
                    }
                    //else
                    //{
                    //    MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    //}
                }
            }
        }

        private Boolean BuscaProducto()
        {
            pro = AdmPro.CargaProductoDetalleR(txtUnArt.Text, frmLogin.iCodAlmacen, 1, 0);
            if (pro != null)
            {
                txtCodProducto.Text = pro.CodProducto.ToString();
                txtUnArt.Text = pro.Referencia;
                txtArticulo.Text = pro.Descripcion;
                return true;
            }
            else
            {
                txtCodProducto.Text = "";
                txtUnArt.Text = "";
                txtArticulo.Text = "";
                return false;
            }
        }
    }
}
