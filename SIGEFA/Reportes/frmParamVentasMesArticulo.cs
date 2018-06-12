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
    public partial class frmParamVentasMesArticulo : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteVentaMesArticulo ds = new clsReporteVentaMesArticulo();
        clsAdmMoneda admMon = new clsAdmMoneda();
        clsValidar ok = new clsValidar();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();

        Int32 m1=0, m2 = 0;
        public Int32 criterio = 0;

        public frmParamVentasMesArticulo()
        {
            InitializeComponent();
        }

        private void frmParamVentasMesArticulo_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            CargaFormaPagos();
            CargaMoneda();
            LlenarComboAños();
            cmbMoneda.SelectedIndex = 0;
            cmbMes1.SelectedIndex = 0;
            cmbMes2.SelectedIndex = 0;
            cmbCriterio.SelectedIndex = criterio;
            posiciona_botones();
        }

        private void posiciona_botones()
        {
            label1.Location = new Point(17,13);
            label8.Location = new Point(122,13);
            cmbMes1.Location = new Point(19,31);
            cmbMes2.Location = new Point(124,31);
            label3.Location = new Point(235,13);
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = admMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = 0;
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagosReporte();
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = 0;
        }

        private void rbArt_CheckedChanged(object sender, EventArgs e)
        {
            txtUnArt.Text = "";
            txtUnArt.Enabled = rbArt.Checked;
            txtUnArt.Focus();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (!cmbAños.SelectedItem.Equals(""))
            {
                m1 = cmbMes1.SelectedIndex + 1;
                m2 = cmbMes2.SelectedIndex + 1;
                CRVentaMesArticulo rpt = new CRVentaMesArticulo();
                frmRptVentaMesArticulo frm = new frmRptVentaMesArticulo();
                rpt.SetDataSource(
                    ds.Reporte(m1, m2, Convert.ToInt32(cmbFormaPago.SelectedValue), cmbCriterio.SelectedIndex,
                        txtUnArt.Text, rbTodosArt.Checked, Convert.ToInt32(cmbMoneda.SelectedValue),
                        frmLogin.iCodAlmacen, Convert.ToInt32(cmbAños.SelectedItem)).Tables[0]);
                frm.crvRptVentaMesArticulo.ReportSource = rpt;
                frm.Show();
            }
            else
            {
                MessageBox.Show("¡Ingrese Año!", "Reporte de Mes por Articulo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender,e);
        }

        private void txtUnArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosLista frm = new frmProductosLista();
                frm.Procede = 15; //(15) Procede desde el formulario frmParamVentxVendedor
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if(frm.pro.CodProducto!=0)
                        CargaProducto(frm.pro.CodProducto);
                }
            }
        }

        private void CargaProducto(Int32 Codigo)
        {
            pro = AdmPro.CargaProducto(Codigo, frmLogin.iCodAlmacen);
            txtUnArt.Text = pro.Referencia;
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
                }
            }
        }

        private Boolean BuscaProducto()
        {
            pro = AdmPro.CargaProductoDetalleR(txtUnArt.Text, frmLogin.iCodAlmacen, 1, 0);
            if (pro != null)
            {
                txtUnArt.Text = pro.Referencia;
                txtArticulo.Text = pro.Descripcion;
                return true;
            }
            else
            {
                txtUnArt.Text = "";
                txtArticulo.Text = "";
                return false;
            }
        }

        public void LlenarComboAños()
        {
            int fechactual;
            DateTime fecha;
            fecha = DateTime.Now;
            fechactual = fecha.Year;
            do
            {
                cmbAños.Items.Add(fechactual);
                fechactual--;
            } while (fechactual >= 2012);
            cmbAños.SelectedIndex = 0;
        }

        private void rbTodosArt_CheckedChanged(object sender, EventArgs e)
        {
            txtArticulo.Text = "";
            txtUnArt.Text = "";
        }                
    }
}
