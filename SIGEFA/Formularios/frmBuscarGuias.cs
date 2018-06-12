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
using SIGEFA.Conexion;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmBuscarGuias : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmGuiaRemision AdmGuia = new clsAdmGuiaRemision();
        clsGuiaRemision guia = new clsGuiaRemision();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmBuscarGuias()
        {
            InitializeComponent();
        }

        public Int32 GetCodigoGuia()
        {
            return Convert.ToInt32(dgvGuiasRemision.CurrentRow.Cells[codigo.Name].Value);
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void CargaLista()
        {
            dgvGuiasRemision.DataSource = data;
            data.DataSource = AdmGuia.MuestraGuias(dtpFecha1.Value,dtpFecha2.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvGuiasRemision.ClearSelection();
        }

        private void frmBuscarGuias_Load(object sender, EventArgs e)
        {
            dtpFecha1.Value = dtpFecha2.Value.AddDays(-30);
            label7.Text = "Cliente";
            label6.Text = "cliente";
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
            DataTable dt = new DataTable("ListaGuias");
            // Columnas
            foreach (DataGridViewColumn column in dgvGuiasRemision.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvGuiasRemision.Rows.Count; i++)
            {
                DataGridViewRow row = dgvGuiasRemision.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvGuiasRemision.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\ListaGuiasRPT.xml", XmlWriteMode.WriteSchema);


            CRListaGuias rpt = new CRListaGuias();
            frmListaGuias frm = new frmListaGuias();
            rpt.SetDataSource(ds);
            frm.crvListaGuias.ReportSource = rpt;
            frm.Show();
        }

        private void dgvGuiasRemision_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvGuiasRemision.Columns[e.ColumnIndex].HeaderText;
            label6.Text = dgvGuiasRemision.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvGuiasRemision_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvGuiasRemision.Rows.Count >= 1 && dgvGuiasRemision.CurrentRow != null)
            {
                DataGridViewRow row = dgvGuiasRemision.CurrentRow;
                frmGuiaRemision form = new frmGuiaRemision();
                form.MdiParent = this.MdiParent;
                form.CodGuia = GetCodigoGuia().ToString();
                form.Proceso = 3;
                form.Show();
            }
        }

        private void frmBuscarGuias_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvGuiasRemision.Focus();
            } 
        }
    }
}
