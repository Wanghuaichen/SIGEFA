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

    public partial class frmNotasDebitoCompras : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmNotaIngreso AdmNota = new clsAdmNotaIngreso();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaIngreso nota = new clsNotaIngreso();
        clsNotaSalida notaS = new clsNotaSalida();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;


        Int32 codnotaI = 0;
        Int32 codFact = 0;
        String DocRef = "";

        clsFactura fac = new clsFactura();
        clsAdmFactura AdmFact = new clsAdmFactura();

        public frmNotasDebitoCompras()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvNotasCredito.DataSource = data;              
            data.DataSource = AdmFact.ListaNotasDebitoCompra(frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvNotasCredito.ClearSelection();
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {
            
            if (dgvNotasCredito.Rows.Count >= 1 && dgvNotasCredito.CurrentRow != null)
            {
                DataGridViewRow row = dgvNotasCredito.CurrentRow;
                frmNotadeDebitoCompra form = new frmNotadeDebitoCompra();
                form.MdiParent = this.MdiParent;
                form.CodNotaS = Convert.ToInt32(codFact);
                form.DocRef = DocRef;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void frmNotasCredito_Load(object sender, EventArgs e)
        {
            
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (nota.CodNotaIngreso != "")
            {
                if (Application.OpenForms["frmNotaIngreso"] != null)
                {
                    Application.OpenForms["frmNotaIngreso"].Close();
                }
                else
                {
                    frmNotaIngreso form = new frmNotaIngreso();
                    form.MdiParent = this.MdiParent;
                    form.CodNota = Convert.ToString(codnotaI);
                    form.Proceso = 3;
                    form.Show();

                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvNotasCredito.CurrentRow != null && codFact != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la nota seleccionada", "Notas de Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmFact.anular(codFact))
                    {
                        MessageBox.Show("La nota ha sido anulada correctamente", "Notas de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label6.Text.Trim(), txtFiltro.Text.Trim());
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ListaNotasCredito");
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
            ds.WriteXml("C:\\XML\\ListaNotasCreditoRPT.xml", XmlWriteMode.WriteSchema);


            CRListaNotas rpt = new CRListaNotas();
            frmListaNotasCredito frm = new frmListaNotasCredito();
            rpt.SetDataSource(ds);
            frm.crvNotasCredito.ReportSource = rpt;
            frm.Show();
        }

        private void dgvNotasCredito_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvNotasCredito.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvNotasCredito.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dtpDesde_ValueChanged_1(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpHasta_ValueChanged_1(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dgvNotasCredito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNotasCredito.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmNotadeDebitoCompra form = new frmNotadeDebitoCompra();
                form.MdiParent = this.MdiParent;
                form.CodNotaS = Convert.ToInt32(codFact);
                form.DocRef = DocRef;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void frmNotasDebitoCompras_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = dtpDesde.Value.AddDays(-90);
            CargaLista();
            label7.Text = "Cliente";
            label6.Text = "cliente";
        }

        private void dgvNotasCredito_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvNotasCredito.DataSource != null)
            {
                if (dgvNotasCredito.Rows.Count >= 1 && e.Row.Selected)
                {
                    codFact = Convert.ToInt32(e.Row.Cells[codigo.Name].Value.ToString());
                    DocRef = e.Row.Cells[numerorefencias.Name].Value.ToString();
                    codnotaI = Convert.ToInt32(e.Row.Cells[NotaIngreso.Name].Value.ToString());
                }
            }
        }

        private void frmNotasDebitoCompras_Shown(object sender, EventArgs e)
        {
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
