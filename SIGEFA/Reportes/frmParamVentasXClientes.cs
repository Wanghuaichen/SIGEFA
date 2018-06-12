using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Formularios;
using SIGEFA.Entidades;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Reportes
{
    public partial class frmParamVentasXClientes : DevComponents.DotNetBar.OfficeForm
    {

        clsAdmMoneda AdmMon = new clsAdmMoneda();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        public clsCliente cli = new clsCliente();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsReporteVentxCliente ds = new clsReporteVentxCliente();
        private Int32 Tipo = 0;

        public frmParamVentasXClientes()
        {
            InitializeComponent();
        }

        private void frmParamVentasXClientes_Load(object sender, EventArgs e)
        {
            CargaFormaPagos();
            cmbFormaPago.SelectedIndex = 0;
            CargaMoneda();
            cmbMoneda.SelectedIndex = 0;
        }

        private void CargaFormaPagos()
        {
            cmbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "codFormaPago";
            cmbFormaPago.SelectedIndex = -1;
        }

        private void CargaMoneda()
        {
            cmbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cmbMoneda.DisplayMember = "descripcion";
            cmbMoneda.ValueMember = "codMoneda";
            cmbMoneda.SelectedIndex = 0;
        }

        private void rbCli_CheckedChanged(object sender, EventArgs e)
        {
            txtUnCli.Text = "";
            txtCliente.Text = "";
            txtUnCli.Enabled = rbCli.Checked;
            txtUnCli.Focus();
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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmRptVentasxCliente frm = new frmRptVentasxCliente();
            CRVentasxCliente rpt = new CRVentasxCliente();
            rpt.SetDataSource(ds.ReporteVentasCliente(frmLogin.iCodAlmacen, dtpFecha1.Value, dtpFecha2.Value, Convert.ToInt32(cmbFormaPago.SelectedValue), rbTodosCli.Checked, txtUnCli.Text, Convert.ToInt32(cmbMoneda.SelectedValue)).Tables[0]);
            frm.crvReporteVentasCliente.ReportSource = rpt;
            frm.Show();
        }
    }
}