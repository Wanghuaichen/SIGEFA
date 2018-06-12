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
using DataGridViewAutoFilter;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;


namespace SIGEFA.Formularios
{
    public partial class frmClientesCompletos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 Tipo;


        public frmClientesCompletos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionCliente frm = new frmGestionCliente();
            frm.Proceso = 1;            
            frm.ShowDialog();
            CargaLista();
        }

        public void CargaLista()
        {
            //dgvProveedores.DataSource = AdmProv.MuestraProveedores();            
            //dgvProveedores.ClearSelection();
            dgvClientes.DataSource = data;
            data.DataSource = AdmCli.MuestraClientes();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvClientes.ClearSelection();
            DarFormato();
        }

        private void DarFormato()
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.Cells[habilitado.Name].Value.ToString() == "INHABILITADO" && row.Index != -1)
                    {
                        row.Cells[habilitado.Name].Style.BackColor = Color.Red;
                        row.Cells[habilitado.Name].Style.ForeColor = Color.White;
                        //row.DefaultCellStyle.BackColor = Color.Red;
                        //row.DefaultCellStyle.ForeColor = Color.White;
                    }
             }
        }

        private void dgvClientes_Sorted(object sender, EventArgs e)
        {
            DarFormato();    
        }
        

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargaLista();
            label2.Text = "Razon Social";
            label3.Text = "razonsocial"; 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                frmGestionCliente frm = new frmGestionCliente();
                frm.Proceso = 2;
                frm.cli = cli;
                frm.ShowDialog();
                CargaLista();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!expandablePanel1.Expanded)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
            else
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void frmClientesCompletos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                expandablePanel1.Expanded = true;
                txtFiltro.Focus();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index != -1 && cli.CodCliente != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCli.delete(Convert.ToInt32(cli.CodCliente)))
                    {
                        MessageBox.Show("Los datos han sido eliminado correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                frmGestionCliente frm = new frmGestionCliente();
                frm.Proceso = 3;
                frm.cli = cli;
                frm.ShowDialog();
            }
        }        

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvClientes.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvClientes.Columns[e.ColumnIndex].DataPropertyName;
            if (expandablePanel1.Expanded)
            {
                txtFiltro.Focus();
            }
        }

        private void dgvClientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvClientes.Rows.Count >= 1 && e.Row.Selected)
            {
                cli.CodCliente = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label3.Text.Trim(), txtFiltro.Text.Trim());
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

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                frmGestionCliente frm = new frmGestionCliente();
                frm.Proceso = 3;
                frm.cli = cli;
                frm.ShowDialog();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Clientes");
            // Columnas
            foreach (DataGridViewColumn column in dgvClientes.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvClientes.Rows.Count; i++)
            {
                DataGridViewRow row = dgvClientes.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvClientes.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\ClientesRPT.xml", XmlWriteMode.WriteSchema);

            //ExportOptions opciones = new ExportOptions();
            //ExcelFormatOptions excelopc = new ExcelFormatOptions();
            //excelopc.ExcelUseConstantColumnWidth = true;
            //opciones.ExportFormatOptions = excelopc;
           
            CRClientesCompletos rpt = new CRClientesCompletos();
            frmClientesRP frm = new frmClientesRP();
            rpt.SetDataSource(ds);
            frm.cRVClientesRP.ReportSource = rpt;
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                expandablePanel1.Expanded = false;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index != -1 && cli.CodCliente != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Inhabilitar al cliente seleccionado", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCli.CambioHabilitado(Convert.ToInt32(cli.CodCliente),false))
                    {
                        MessageBox.Show("El cliente se ha Inhabilitado", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index != -1 && cli.CodCliente != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Habilitar al cliente seleccionado", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCli.CambioHabilitado(Convert.ToInt32(cli.CodCliente), true))
                    {
                        MessageBox.Show("El cliente ha sido Habilitado", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void frmClientesCompletos_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void biFiltros_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(dgvClientes);
        }

        
    }
}
