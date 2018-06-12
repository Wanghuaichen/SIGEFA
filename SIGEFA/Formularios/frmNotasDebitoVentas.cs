using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmNotasDebitoVentas : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsFacturaVenta venta = new clsFacturaVenta();

        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;        

        public frmNotasDebitoVentas()
        {
            InitializeComponent();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            dgvNotasCredito.DataSource = data;
            data.DataSource = AdmVenta.ListaNotasDebito(frmLogin.iCodAlmacen, dtpDesde.Value, dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvNotasCredito.ClearSelection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIrGuia_Click(object sender, EventArgs e)
        {
            if (dgvNotasCredito.Rows.Count >= 1 && dgvNotasCredito.CurrentRow != null)
            {
                DataGridViewRow row = dgvNotasCredito.CurrentRow;
                frmNotadeDebito form = new frmNotadeDebito();
                form.MdiParent = this.MdiParent;
                form.CodNota = venta.CodFacturaVenta;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void dgvNotasCredito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNotasCredito.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmNotadeDebito form = new frmNotadeDebito();
                form.MdiParent = this.MdiParent;
                form.CodNota = venta.CodFacturaVenta;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void dgvNotasCredito_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvNotasCredito.Rows.Count >= 1 && e.Row.Selected)
            {
                venta.CodFacturaVenta = e.Row.Cells[codigo.Name].Value.ToString();
            }
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (venta.CodFacturaVenta != "")
            {
                if (Application.OpenForms["frmVenta"] != null)
                {
                    Application.OpenForms["frmVenta"].Close();
                }
                else
                {
                    frmVenta form = new frmVenta();
                    form.MdiParent = this.MdiParent;
                    //nota = AdmNota.CargaNotaIngreso(Convert.ToInt32(dgvNotasCredito.CurrentRow.Cells[codreferencia.Name].Value));
                    form.CodVenta = dgvNotasCredito.CurrentRow.Cells[CodFacturaVentaRef.Name].Value.ToString();
                    form.Proceso = 3;
                    form.Show();
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvNotasCredito.CurrentRow != null && venta.CodFacturaVenta != "")
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la nota seleccionada", "Notas de Débito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmVenta.anular(Convert.ToInt32(venta.CodFacturaVenta)))
                    {
                        MessageBox.Show("La nota ha sido anulada correctamente", "Notas de Débito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }        

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ListaNotasDebito");
            // Columnas
            foreach (DataGridViewColumn column in dgvNotasCredito.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvNotasCredito.Rows.Count; i++)
            {
                DataGridViewRow row = dgvNotasCredito.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvNotasCredito.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\ListaNotasDebitoRPT.xml", XmlWriteMode.WriteSchema);


            CRListaNotasDebito rpt = new CRListaNotasDebito();
            frmListaNotasDebito frm = new frmListaNotasDebito();
            rpt.SetDataSource(ds);
            frm.crvNotasDebito.ReportSource = rpt;
            frm.Show();
        }

        private void frmNotasDebitoVentas_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = dtpDesde.Value.AddDays(-90);
            CargaLista();
        }

        private void frmNotasDebitoVentas_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

        private void dgvNotasCredito_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvNotasCredito.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvNotasCredito.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvNotasCredito.Focus();
            } 
        }
    }
}
