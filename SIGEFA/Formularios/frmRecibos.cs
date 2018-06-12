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

namespace SIGEFA.Formularios
{
    public partial class frmRecibos : DevComponents.DotNetBar.Office2007Form
    {
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        clsRecibos recibos = new clsRecibos();
        clsAdmRecibo AdmRecibos = new clsAdmRecibo();
       
        public List<Int32> seleccion = new List<Int32>();
        //public List<clsCajaChica> seleccion2 = new List<clsCajaChica>();

        //clsCajaChica Caja = new clsCajaChica();
        //clsAdmCajaChica AdmCaja = new clsAdmCajaChica();
        
        private Decimal xsustentar = 0;
        private Decimal sustentado = 0;
        private Decimal Saldo = 0;
        public Int32 tipocaja = 0;


        public frmRecibos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void biActualizar_Click(object sender, EventArgs e)
        {
            VerificaSaldoCaja();
            RecibosFechas();
        }

        private void RecibosFechas()
        {
            dgvRecibos.DataSource = data;
            data.DataSource = AdmRecibos.ListaRecibos(frmLogin.iCodSucursal, dtpfecha1.Value.Date, dtpfecha2.Value.Date,tipocaja);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvRecibos.ClearSelection();
        }
        private void VerificaSaldoCaja()
        {
            //Saldo = 0;

            //Caja = AdmCaja.VerificaSaldoCajaChica(frmLogin.iCodSucursal,tipocaja);
            //if (Caja != null)
            //{
            //    Saldo = Caja.MontoDisponible;
            //    lblIngresos.Text = String.Format("{0:#,##0.00}", Caja.MontoIngresado.ToString());
            //    lblEgresos.Text = String.Format("{0:#,##0.00}", Caja.MontoEntregado.ToString());
            //    lblAperturaCaja.Text = String.Format("{0:#,##0.00}", Caja.MontoApertura.ToString());
            //    lblSaldoCaja.Text = String.Format("{0:#,##0.00}", Caja.MontoDisponible.ToString());
            //}
            //else
            //{
            //    Saldo = 0;
            //    lblIngresos.Text = "0.000";
            //    lblEgresos.Text = "0.000";
            //    lblAperturaCaja.Text = "0.000";
            //    lblSaldoCaja.Text = "0.000";
            //    //*****************************

            //}

           
        }

        private void frmCajaChica_Load(object sender, EventArgs e)
        {
            RecibosFechas();
            VerificaSaldoCaja();
        }

        private void dtpfecha1_Leave(object sender, EventArgs e)
        {
            dtpfecha2.MinDate = dtpfecha1.Value;
        }

        private void dtpfecha2_Leave(object sender, EventArgs e)
        {
            dtpfecha1.MaxDate = dtpfecha2.Value;
        }

        private void dtpfecha1_ValueChanged(object sender, EventArgs e)
        {
            RecibosFechas();
        }

        private void dtpfecha2_ValueChanged(object sender, EventArgs e)
        {
            RecibosFechas();
        }

        private void biEditar_Click(object sender, EventArgs e)
        {

            if (dgvRecibos.Rows.Count > 0 && dgvRecibos.SelectedRows.Count>0)
            {
                if (Convert.ToDecimal(dgvRecibos.SelectedRows[0].Cells[monto.Name].Value) == (Convert.ToDecimal(dgvRecibos.SelectedRows[0].Cells[montopendiente.Name].Value.ToString())))
                {
                    frmRecibos_CajaChica frm = new frmRecibos_CajaChica();
                    frm.Proceso = 2;
                    //frm.Caja = Caja;
                    //frm.txtCodigo.Text = dgvRecibos.SelectedRows[0].Cells[codigo.Name].Value.ToString();
                    frm.txtDescripcion.Text = dgvRecibos.SelectedRows[0].Cells[concepto.Name].Value.ToString();
                    frm.txtMonto.Text = dgvRecibos.SelectedRows[0].Cells[monto.Name].Value.ToString();
                    //frm.txtSerie.Text = dgvRecibos.SelectedRows[0].Cells[serie.Name].Value.ToString();
                    //frm.txtNumeracion.Text = dgvRecibos.SelectedRows[0].Cells[numeracion.Name].Value.ToString();
                    //frm.txtSerie.Enabled = false;
                    //frm.txtNumeracion.Enabled = false;
                    frm.dtpFecha.Value = Convert.ToDateTime(dgvRecibos.SelectedRows[0].Cells[fecha.Name].Value.ToString());
                   
                    frm.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                    frm.tipocaja = tipocaja;
                    frm.ShowDialog();
                    RecibosFechas();
                    VerificaSaldoCaja();
                }
                else { MessageBox.Show("No se Puede Editar, Ya tiene un Monto sustentado"); }
            }
        }

        private void dgvMovimientosCajaChica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frmRecibos_CajaChica frm = new frmRecibos_CajaChica();
                frm.Proceso = 3;
                //frm.txtCodigo.Text = dgvRecibos.SelectedRows[0].Cells[codigo.Name].Value.ToString();
                frm.txtDescripcion.Text = dgvRecibos.SelectedRows[0].Cells[concepto.Name].Value.ToString();
                frm.txtMonto.Text = dgvRecibos.SelectedRows[0].Cells[monto.Name].Value.ToString();
                //frm.txtSerie.Text = dgvRecibos.SelectedRows[0].Cells[serie.Name].Value.ToString();
                //frm.txtNumeracion.Text = dgvRecibos.SelectedRows[0].Cells[numeracion.Name].Value.ToString();
                //frm.txtSerie.Enabled = false;
                //frm.txtNumeracion.Enabled = false;
                frm.dtpFecha.Value = Convert.ToDateTime(dgvRecibos.SelectedRows[0].Cells[fecha.Name].Value.ToString());
                
                frm.lblSaldoCaja.Text = lblSaldoCaja.Text.Trim();
                frm.ShowDialog();
            }
        }


        private void CalculoSaldo()
        {
            try
            {
                xsustentar = 0;
                sustentado = 0;
                //Saldo = 0;

                foreach (DataGridViewRow row in dgvRecibos.Rows)
                {
                    
                    xsustentar = xsustentar + (Convert.ToDecimal(row.Cells[montopendiente.Name].Value));
                    sustentado=sustentado + (Convert.ToDecimal(row.Cells[montorendido.Name].Value));
                }
                txtxsustentar.Text = String.Format("{0:#,##0.00}", xsustentar.ToString());
                txtsustentado.Text = String.Format("{0:#,##0.00}", sustentado.ToString());
                lblTotal.Text = String.Format("{0:#,##0.00}", (xsustentar + sustentado).ToString());

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void dgvMovimientosCajaChica_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculoSaldo();
        }

        private void dgvMovimientosCajaChica_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculoSaldo();
        }

       
        private void dgvMovimientosCajaChica_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRecibos.IsCurrentCellDirty)
            {
                dgvRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void biBuscar_Click(object sender, EventArgs e)
        {
            lblColumna.Text = "CONCEPTO";
            lblProperty.Text = "concepto"; 
            
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            expandablePanel1.Expanded = false;
        }

        private void dgvMovimientosCajaChica_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvRecibos.Columns[e.ColumnIndex].Index > 0)
            {
                lblColumna.Text = dgvRecibos.Columns[e.ColumnIndex].HeaderText;
                lblProperty.Text = dgvRecibos.Columns[e.ColumnIndex].DataPropertyName;

                if (expandablePanel1.Expanded)
                {
                    txtFiltro.Focus();
                }
            }
        }


        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", lblColumna.Text.Trim(), txtFiltro.Text.Trim());
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

       
        private void biImprimir_Click(object sender, EventArgs e)
        {

        }

        private void biEliminar_Click(object sender, EventArgs e)
        {

        }

        private void biAnular_Click(object sender, EventArgs e)
        {

        }

    }
}
