using System;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{

    public partial class frmPedidosPendientes : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmPedido AdmPedido = new clsAdmPedido();
        clsPedido pedido = new clsPedido();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;



        public frmPedidosPendientes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargaLista()
        {
            dgvPedidosPendientes.DataSource = data;
            data.DataSource = AdmPedido.MuestraPedidos(frmLogin.iCodUser, frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPedidosPendientes.ClearSelection();
        }

        private void frmPedidosPendientes_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-6);
            CargaLista();
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && dgvPedidosPendientes.CurrentRow != null)
            {
                if (pedido.CodPedido != "")
                {
                    if (Application.OpenForms["frmVenta"] != null)
                    {
                        Application.OpenForms["frmVenta"].Close();
                    }
                    else
                    {
                        frmVenta form = new frmVenta();
                        form.MdiParent = this.MdiParent;
                        form.Proceso = 4;
                        //form.VericarPedido = true;
                        form.CodPedido = Convert.ToInt32(dgvPedidosPendientes.CurrentRow.Cells[Pedido_.Name].Value);
                        //form.txtPedido.ReadOnly = true;
                        //KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                        //form.txtPedido_KeyPress(form.txtPedido, ee);
                        form.Show();
                    }
                }

            }

        }

        private void dgvPedidosPendientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && e.Row.Selected)
            {
                pedido.CodPedido = e.Row.Cells[codigo.Name].Value.ToString();

            }
        }

        private void dgvPedidosPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmPedido form = new frmPedido();
                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;
                form.Proceso = 2;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.SelectedRows.Count > 0)
            {
                if (dgvPedidosPendientes.CurrentRow != null && pedido.CodPedido != "")
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el pedido seleccionado",
                        "Pedidos Pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (AdmPedido.delete(Convert.ToInt32(pedido.CodPedido)))
                        {
                            MessageBox.Show("El pedido ha sido anulado correctamente", "Pedidos", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            CargaLista();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", "codPedido", txtFiltro.Text);
                }
                else
                {
                    data.Filter = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIrNota_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPedidosPendientes.SelectedRows[0];
                if (dgvPedidosPendientes.Rows.Count >= 1)
                {
                    frmPedido form = new frmPedido();
                    form.MdiParent = this.MdiParent;
                    form.CodPedido = pedido.CodPedido;
                    form.Proceso = 2;
                    form.Show();
                }
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

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            CargaLista();
        }
    }
}
