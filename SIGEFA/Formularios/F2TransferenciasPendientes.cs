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
    public partial class F2TransferenciasPendientes : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmTransferencia admtrans = new clsAdmTransferencia();
        clsTransferencia trans=new clsTransferencia();

        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;


        public F2TransferenciasPendientes()
        {
            InitializeComponent();
        }

        private void F2TransferenciasPendientes_Load(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now.AddDays(-6);            
            CargaLista();
        }

        public void CargaLista()
        {
            dgvTransferenciasPendientes.AutoGenerateColumns = false;
            dgvTransferenciasPendientes.DataSource = data; 
            data.DataSource = admtrans.MuestraTranferencias(Convert.ToInt32(cbTipo.SelectedIndex),frmLogin.iCodUser, frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            
            if (cbTipo.SelectedIndex == 0)
            {
                dgvTransferenciasPendientes.Columns["DecripcionRechazo"].Visible = false;
                
                for (int i = 0; i < dgvTransferenciasPendientes.RowCount; i++)
                {
                    dgvTransferenciasPendientes["TDirecta", i].Style.BackColor = Color.FromArgb(255, 255, 183);
                }
            }
            else if (cbTipo.SelectedIndex == 1)
            {
                dgvTransferenciasPendientes.Columns["DecripcionRechazo"].Visible = false;
               
                for (int i = 0; i < dgvTransferenciasPendientes.RowCount; i++)
                {
                    dgvTransferenciasPendientes["TDirecta", i].Style.BackColor = Color.FromArgb(228, 255, 187);
                }
            }
            else if (cbTipo.SelectedIndex == 2)
            {
                dgvTransferenciasPendientes.Columns["DecripcionRechazo"].Visible = true;
               
               for (int i = 0; i < dgvTransferenciasPendientes.RowCount; i++)
               {
                   dgvTransferenciasPendientes["TDirecta", i].Style.BackColor = Color.FromArgb(255, 139, 139);
               }
            }
            else if (cbTipo.SelectedIndex == 3)
            {
                dgvTransferenciasPendientes.Columns["DecripcionRechazo"].Visible = true;
                for (int i = 0; i < dgvTransferenciasPendientes.RowCount; i++)
                {
                    dgvTransferenciasPendientes["TDirecta", i].Style.BackColor = Color.FromArgb(195, 240, 246);
                }
            }
            dgvTransferenciasPendientes.ClearSelection();
        }

        private void dgvTransferenciasPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTransferenciasPendientes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                F2TransferenciaEntreAlmacenes form = new F2TransferenciaEntreAlmacenes();
                form.MdiParent = this.MdiParent;
                form.CodTransDirecta = Convert.ToInt32(dgvTransferenciasPendientes.CurrentRow.Cells[codigo.Name].Value);
                
                form.Proceso = 3;
                form.caso = cbTipo.SelectedIndex;
                form.Show();
                CargaLista();
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btnIrNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferenciasPendientes.Rows.Count > 0 && dgvTransferenciasPendientes.SelectedRows.Count > 0)
                {
                    F2TransferenciaEntreAlmacenes form = new F2TransferenciaEntreAlmacenes();
                    form.MdiParent = this.MdiParent;
                    form.CodTransDirecta =
                        Convert.ToInt32(dgvTransferenciasPendientes.CurrentRow.Cells[codigo.Name].Value);
                    form.Proceso = 3;
                    form.caso = cbTipo.SelectedIndex;
                    form.Show();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLista();
        }

        clsReporteTransferencia ds2 = new clsReporteTransferencia();
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable nuevo = new DataTable();
            CRTransferencia rpt = new CRTransferencia();
            FrmRptTransferencia frm = new FrmRptTransferencia();
            nuevo = ds2.RptTransferencia(Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value), Convert.ToInt32(frmLogin.iCodAlmacen)).Tables[0];
            rpt.SetDataSource(nuevo);
            frm.crvreportetrasferencia.ReportSource = rpt;
            frm.ShowDialog();
        }
    }
}
