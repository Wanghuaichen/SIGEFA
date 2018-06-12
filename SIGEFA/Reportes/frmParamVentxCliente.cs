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
    public partial class frmParamVentxCliente : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsReporteVentxCliente ds = new clsReporteVentxCliente();
        public clsCliente cli = new clsCliente();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsProducto pro = new clsProducto();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsAdmMoneda AdmMon = new clsAdmMoneda();
        private Int32 Tipo = 0;

        public frmParamVentxCliente()
        {
            InitializeComponent();
        }

        private void frmParamVentxCliente_Load(object sender, EventArgs e)
        {
            CargaFormaPagos();
            cmbFormaPago.SelectedIndex = 0;
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


        //private void CargaFormaPagos()
        //{
        //    cmbFormaPago.DataSource = AdmPago.CargaFormaPagosReporte();
        //    cmbFormaPago.DisplayMember = "descripcion";
        //    cmbFormaPago.ValueMember = "codFormaPago";
        //    cmbFormaPago.SelectedIndex = 0;
        //}
        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;
        }

        private void rbCli_CheckedChanged(object sender, EventArgs e)
        {
            txtUnCli.Text = "";
            txtCliente.Text = "";
            txtUnCli.Enabled = rbCli.Checked;
            txtUnCli.Focus();
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
            CRVentxCliente rpt = new CRVentxCliente();
            frmRptVentxCliente frm = new frmRptVentxCliente();
                rpt.SetDataSource(ds.Reporte(frmLogin.iCodAlmacen, dtpFecha1.Value, dtpFecha2.Value,
                        Convert.ToInt32(cmbFormaPago.SelectedValue), rbTodosCli.Checked, rbTodosArt.Checked,
                        txtUnArt.Text, txtUnCli.Text,Convert.ToInt32(cmbMoneda.SelectedValue)).Tables[0]);
                frm.crvRptVentxCliente.ReportSource = rpt;
                frm.Show();
        }

        private void txtUnCli_KeyDown(object sender, KeyEventArgs e)
        {
            if (rbCli.Checked)
            {
                if (e.KeyCode == Keys.F1)
                {
                    frmClientesLista frm = new frmClientesLista();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargaCliente(frm.GetCodigoCliente());
                    }
                    else txtUnCli.Focus();
                }
            }
        }

        private void txtUnArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (rbArt.Checked)
            {
                if (e.KeyCode == Keys.F1)
                {
                    frmProductosLista frm = new frmProductosLista();
                    frm.Procede = 15; //(8) Procede desde el formulario frmParamVentxVendedor
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.pro.CodProducto != 0)
                            CargaProducto(frm.pro.CodProducto);
                    }
                }
            }
        }

        private void CargaProducto(Int32 Codigo)
        {
            pro = AdmPro.CargaProducto(Codigo, frmLogin.iCodAlmacen);
            txtUnArt.Text = pro.Referencia;
            txtArticulo.Text = pro.Descripcion;
            txtCodProd.Text = pro.CodProducto.ToString();
        }

        private void CargaCliente(Int32 Codigo)
        {
            cli = AdmCli.MuestraCliente(Codigo);
            txtUnCli.Text = cli.RucDni;
            txtCodCli.Text = cli.CodCliente.ToString();
            txtCliente.Text = cli.RazonSocial;
        }

        private void txtUnCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtUnCli.Text != "")
                {
                    if (BuscaCliente())
                    {
                        ProcessTabKey(true);

                    }
                    else
                    {
                        MessageBox.Show("El Cliente no existe, Presione F1 para consultar la tabla de ayuda", "Facturacion Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                 }
            }
        }

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtUnCli.Text, Tipo);
            if (cli != null)
            {
                txtUnCli.Text = cli.RucDni;
                txtCliente.Text = cli.RazonSocial;
                txtCodCli.Text = cli.CodCliente.ToString();
                return true;
            }
            else
            {
                txtUnCli.Text = "";
                txtCliente.Text = "";
                txtCodCli.Text = "";
                return false;
            }
        }

        private void txtUnCli_TextChanged(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtCodCli.Text = "";
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
                    else
                    {
                        MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaProducto()
        {
            pro = AdmPro.CargaProductoDetalleR(txtUnArt.Text, frmLogin.iCodAlmacen, 1, 0);
            if (pro != null)
            {
                txtCodProd.Text = pro.CodProducto.ToString();
                txtUnArt.Text = pro.Referencia;
                txtArticulo.Text = pro.Descripcion;
                return true;
            }
            else
            {
                txtCodProd.Text = "";
                txtUnArt.Text = "";
                txtArticulo.Text = "";
                return false;
            }
        }

        private void txtUnArt_TextChanged(object sender, EventArgs e)
        {
            txtCodProd.Text = "";
            txtArticulo.Text = "";
        }


    }
}
