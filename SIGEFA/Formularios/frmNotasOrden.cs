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
    public partial class frmNotasOrden : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmNotaIngreso AdmNotaI = new clsAdmNotaIngreso();
        clsNotaIngreso notaI = new clsNotaIngreso();
        clsAdmNotaSalida AdmNotaS = new clsAdmNotaSalida();
        clsNotaSalida notaS = new clsNotaSalida();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmNotasOrden()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaLista(0);
            
        }

        private void CargaLista(Int32 caso)
        {
            dgvDocumentos.DataSource = data;
            data.DataSource = AdmNotaI.MuestraNotasIngreso(caso, frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDocumentos.ClearSelection();
        }


        private void btnIrNota_Click(object sender, EventArgs e)
        {
            if(dgvDocumentos.Rows.Count>0){
                DataGridViewRow row = dgvDocumentos.SelectedRows[0];
                if (dgvDocumentos.Rows.Count >= 1)
                {
                    if (row.Cells[tipo.Name].Value.ToString() == "NI")
                    {
                        frmNotaIngresoPorOrden form = new frmNotaIngresoPorOrden();
                        form.CodNota = notaI.CodNotaIngreso;
                        form.Proceso = this.Proceso;
                        form.Show();
                    }
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            if (Proceso == 4)
            {
                btnEliminar.Visible = true;
            }
            else if (Proceso == 5)
            {
                btnAnular.Visible = true;
            }
        }

        private void dgvDocumentos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDocumentos.Rows.Count >= 1 && e.Row.Selected)
            {
                if (e.Row.Cells[tipo.Name].Value.ToString() == "NI")
                {
                    notaI.CodNotaIngreso = e.Row.Cells[numero.Name].Value.ToString();
                }
            }
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count >= 1 && e.RowIndex != -1)
            {
                if (dgvDocumentos.Rows[e.RowIndex].Cells[tipo.Name].Value.ToString() == "NI")
                {
                    frmNotaIngreso form = new frmNotaIngreso();
                    //form.MdiParent = this.MdiParent;
                    form.CodNota = notaI.CodNotaIngreso;
                    form.Proceso = this.Proceso;
                    //form.Show();
                    form.ShowDialog();
                }
            }
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocumentos.Rows.Count >= 1 && e.RowIndex != -1)
            {
                btnIrNota.Enabled = true;
                btnEliminar.Enabled = true;
                if (dgvDocumentos.Rows[e.RowIndex].Cells[anulado.Name].Value.ToString() == "ACTIVO")
                {
                    btnAnular.Text = "Anular";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 10;
                }
                else 
                {
                    btnAnular.Text = "Activar";
                    btnAnular.Enabled = true; 
                    btnAnular.ImageIndex = 11;
                }
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDocumentos.SelectedRows[0];
            if (dgvDocumentos.Rows.Count >= 1 && dgvDocumentos.CurrentRow.Index != -1)
            {
                if (row.Cells[tipo.Name].Value.ToString() == "NI")
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar los datos definitivamente", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (AdmNotaI.delete(Convert.ToInt32(notaI.CodNotaIngreso)))
                        {
                            MessageBox.Show("Los datos han sido eliminado correctamente", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaLista(0);
                        }
                    }
                }
            }            
        }

        private void btrnAnular_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDocumentos.CurrentRow;
            if(btnAnular.Text == "Anular")
            {
                if (dgvDocumentos.Rows.Count >= 1 && dgvDocumentos.CurrentRow.Index != -1)
                {
                    if (row.Cells[tipo.Name].Value.ToString() == "NI")
                    {
                        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el documento seleccionado", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            if (AdmNotaI.anular1(Convert.ToInt32(notaI.CodNotaIngreso)))
                            {
                                MessageBox.Show("El documento ha sido anulado correctamente", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaLista(0);
                            }
                        }
                    }
                }
            } 
            else if (btnAnular.Text == "Activar")
            {
                if (dgvDocumentos.Rows.Count >= 1 && dgvDocumentos.CurrentRow.Index != -1)
                {
                    if (row.Cells[tipo.Name].Value.ToString() == "NI")
                    {
                        DialogResult dlgResult = MessageBox.Show("Esta seguro que desea activar el documento seleccionado", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            if (AdmNotaI.activar(Convert.ToInt32(notaI.CodNotaIngreso)))
                            {
                                MessageBox.Show("El documento ha sido activado correctamente", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaLista(0);
                            }
                        }
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("NotasIngresoSalida");
            // Columnas
            foreach (DataGridViewColumn column in dgvDocumentos.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Datos
            for (int i = 0; i < dgvDocumentos.Rows.Count; i++)
            {
                DataGridViewRow row = dgvDocumentos.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgvDocumentos.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            ds.WriteXml("C:\\XML\\NotasIngresoSaidaRPT.xml", XmlWriteMode.WriteSchema);


            CRNotasIngresoSalida rpt = new CRNotasIngresoSalida();
            frmNotasIngresoSalida frm = new frmNotasIngresoSalida();
            rpt.SetDataSource(ds);
            frm.crvNotasIngresoSalida.ReportSource = rpt;
            frm.Show();
        }
    }
}
