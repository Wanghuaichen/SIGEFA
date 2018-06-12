using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmVerCompras : DevComponents.DotNetBar.OfficeForm
    {

        public static BindingSource data = new BindingSource();
        clsAdmFactura admFac = new clsAdmFactura();
        clsFactura fac = new clsFactura();

        String filtro = String.Empty;

        public frmVerCompras()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerCompras_Load(object sender, EventArgs e)
        {
            CargaLista();
            
        }

        private void CambiaColor()
        {
            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                DateTime fecha_vence = Convert.ToDateTime(row.Cells[fechapago.Name].Value);
                Int32 can = Convert.ToInt32(row.Cells[cancelado.Name].Value);
                if (fecha_vence <= Convert.ToDateTime(System.DateTime.Now.ToString()) && can == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                if (can == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
            }
        }

        private void CargaLista()
        {
            dgvFacturas.DataSource = data;
            data.DataSource = admFac.MuestraFactura(dtpDesde.Value.Date, dtpHasta.Value.Date, frmLogin.iCodAlmacen);
            CambiaColor();
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void dgvFacturas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvFacturas.Rows.Count >= 1 && e.Row.Selected)
            {
                fac.CodFactura = Convert.ToInt32(e.Row.Cells[codfactura.Name].Value);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow != null)
            {
                DialogResult dglResult = MessageBox.Show("Esta seguro que desea anular la Factura seleccionada", "Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dglResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admFac.anular(fac.CodFactura))
                    {
                        MessageBox.Show("La Factura ha sido anulada correctamente", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                    else
                    {
                        MessageBox.Show("La Factura no se puede anular", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvFacturas.Rows.Count >= 1 && e.RowIndex != -1)
            //{
            //    frmNotaIngreso form = new frmNotaIngreso();
            //    form.MdiParent = this.MdiParent;
            //    form.CodNota = fac.CodFactura.ToString();
            //    form.Proceso = 3;
            //    form.Show();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                clsReporteOrdeCompra ds = new clsReporteOrdeCompra();
                //clsReporteCaja ds = new clsReporteCaja();

                CRReporteCompra rpt = new CRReporteCompra();
                frmRptCaja frm = new frmRptCaja();
                rpt.SetDataSource(ds.ReporteCompras(dtpDesde.Value.Date, dtpHasta.Value.Date, frmLogin.iCodAlmacen));
                frm.crvKardex.ReportSource = rpt;
                frm.Show();

            } catch (Exception a ) { MessageBox.Show(a.Message); }
        }
    }
}