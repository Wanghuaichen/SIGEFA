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
    public partial class frmRecibosSinSustentar : DevComponents.DotNetBar.Office2007Form
    {
        clsRecibos recibos = new clsRecibos();
        clsAdmRecibo AdmRecibos = new clsAdmRecibo();
        String doc = "";
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 tipocaja =0;
        public frmRecibosSinSustentar()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dgvRecibos.DataSource = data;
            data.DataSource = AdmRecibos.ListaRecibosEgreso(frmLogin.iCodSucursal , tipocaja);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvRecibos.ClearSelection();
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvRecibos.SelectedRows.Count > 0)
            {
                frmCajaChicaRegistro form = (frmCajaChicaRegistro)Application.OpenForms["frmCajaChicaRegistro"];
                form.codRec = recibos.CodRecibos;
                form.txtRecibo.Text = doc;
                form.monto = recibos.Monto;
                form.txtMontoPendiente.Text = recibos.Monto.ToString();
                this.Close();  
            }
        }

        private void frmRecibosSinSustentar_Load(object sender, EventArgs e)
        {

            CargaLista();
            label2.Text = "Documento";
            label3.Text = "documento";
        }

        private void dgvRecibos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            btnAceptar.Enabled = true;
          
        }

        private void dgvRecibos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvRecibos.Rows.Count >= 1 && e.Row.Selected)
            {
                recibos.CodRecibos = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                recibos.Monto = Convert.ToDecimal(e.Row.Cells[montopendiente.Name].Value);
                doc = e.Row.Cells[documento.Name].Value.ToString();
            }
        }

        private void dgvRecibos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvRecibos.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvRecibos.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void dgvRecibos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCajaChicaRegistro form = (frmCajaChicaRegistro)Application.OpenForms["frmCajaChicaRegistro"];
            form.codRec = recibos.CodRecibos;
            form.txtRecibo.Text = doc;
            form.monto= recibos.Monto;
            form.txtMontoPendiente.Text = recibos.Monto.ToString();
            this.Close(); 
        }

        private void frmRecibosSinSustentar_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

    }
}
