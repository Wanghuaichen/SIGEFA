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
    public partial class frmParamVentxArticuloxVendedor : DevComponents.DotNetBar.Office2007Form
    {       
        clsReporteVentxCliente ds = new clsReporteVentxCliente();     
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmVendedor admVen = new clsAdmVendedor();

        public Int32 codArticulo1;
        public Int32 codArticulo2;
        public String Referencia1;
        public String Referencia2;


        public frmParamVentxArticuloxVendedor()
        {
            InitializeComponent();
        }

        private void frmParamVentxCliente_Load(object sender, EventArgs e)
        {
            CargaVendedores();           
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
            txtUnArt2.Text = "";
            txtArticulo2.Text = "";
            txtUnArt.Enabled = rbArt.Checked;
            txtUnArt2.Enabled = rbArt.Checked;
            txtUnArt.Focus();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            CRVentxArtixVend rpt = new CRVentxArtixVend();
            frmRptVentxArtixVendedor frm = new frmRptVentxArtixVendedor();
            DataTable dt =ds.Reporte22(frmLogin.iCodAlmacen, dtpFecha1.Value, dtpFecha2.Value,
                     Convert.ToInt32(cmbVendedor.SelectedValue), txtUnArt.Text,
                     txtUnArt2.Text, rbTodosArt.Checked, rbArt.Checked).Tables[0];
            if (dt.Rows.Count>0)
            {
                rpt.SetDataSource(dt);
                frm.crvRptVentxCliente.ReportSource = rpt;
                frm.Show();
            }
            
        }

       

        private void txtUnArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //frmProductosLista frm = new frmProductosLista();
                //frm.Procede = 8; //(8) Procede desde el formulario frmParamVentxVendedor
                frmProductosListaReport frm = new frmProductosListaReport();
                frm.Proceso = 3;
                frm.Inicio = 0;
                frm.codAlmacen = Convert.ToInt32(frmLogin.iCodAlmacen);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    codArticulo1 = frm.pro.CodProducto;
                    Referencia1 = frm.pro.Referencia;
                    txtUnArt.Text = frm.pro.Referencia;
                    txtArticulo.Text = frm.pro.Descripcion;
                    txtRan1.Text = frm.pro.CodProducto.ToString();
                    //CargaProducto(frm.GetCodigoProducto());
                }
            }
        }

        private void CargaProducto(Int32 Codigo)
        {
            pro = AdmPro.CargaProducto(Codigo, frmLogin.iCodAlmacen);
            txtUnArt.Text = pro.Referencia;
            txtArticulo.Text = pro.Descripcion;
        }

        

        private void txtUnArt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosListaReport frm = new frmProductosListaReport();
                frm.Proceso = 3;
                frm.Inicio = codArticulo1;
                frm.codAlmacen = frmLogin.iCodAlmacen;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    codArticulo2 = frm.pro.CodProducto;
                    Referencia2 = frm.pro.Referencia;
                    txtUnArt2.Text = frm.pro.Referencia;
                    txtArticulo2.Text = frm.pro.Descripcion;
                    txtRan2.Text = frm.pro.CodProducto.ToString();
                }
            }
        }

        private void txtUnArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtUnArt.Text != "")
                {
                    if (BuscaProducto(txtUnArt.Text))
                    {
                        ProcessTabKey(true);
                        codArticulo1 = pro.CodProducto;
                        Referencia1 = pro.Referencia;
                        txtUnArt.Text = pro.Referencia;
                        txtArticulo.Text = pro.Descripcion;
                        txtRan1.Text = pro.CodProducto.ToString();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtUnArt2_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtUnArt2.Text != "")
                {
                    if (BuscaProducto(txtUnArt2.Text))
                    {
                        ProcessTabKey(true);
                        codArticulo2 = pro.CodProducto;
                        Referencia2 = pro.Referencia;
                        txtUnArt2.Text = pro.Referencia;
                        txtArticulo2.Text = pro.Descripcion;
                        txtRan2.Text = pro.CodProducto.ToString();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaProducto(String referencia)
        {
            pro = AdmPro.CargaProductoDetalleR(referencia, frmLogin.iCodAlmacen, 2, 0);
            if (pro != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
