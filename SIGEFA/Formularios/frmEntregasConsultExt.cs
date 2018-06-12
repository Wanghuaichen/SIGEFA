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

    public partial class frmEntregasConsultExt : DevComponents.DotNetBar.Office2007Form    
    {
        clsConsultasExternas ext = new clsConsultasExternas();
        clsSerie ser = new clsSerie();
        clsAdmPedido AdmPedido = new clsAdmPedido();
        clsPedido pedido = new clsPedido();        
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 entregadovend;
        public String cadEstado;



        public frmEntregasConsultExt()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvPedidosPendientes.DataSource = data;
            data.DataSource = AdmPedido.MuestraEntregasConsultorExt(frmLogin.iCodAlmacen, dtpDesde.Value, dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvPedidosPendientes.ClearSelection();
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && dgvPedidosPendientes.CurrentRow != null)
            {
                DataGridViewRow row = dgvPedidosPendientes.CurrentRow;
                frmConsultorExt form = new frmConsultorExt();
               
                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;

                if(cadEstado == "ANULADO"){
                    form.Proceso = 4;
                }
                else
                {
                    if (entregadovend == 1)//entregado
                        form.Proceso = 3;

                    else if (entregadovend == 0)//liquidado
                        form.Proceso = 4;
                }
                form.Show();
                CargaLista();
            }
            this.Close();
        }

        private void frmPedidosPendientes_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {



            if (dgvPedidosPendientes.Rows.Count >= 1 && dgvPedidosPendientes.CurrentRow != null)
            {
                DataGridViewRow row = dgvPedidosPendientes.CurrentRow;
                frmConsultorExt form = new frmConsultorExt();
                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;
                form.Proceso = 2;
                form.Show();
            }
            
            
            
            /*
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
                        form.Proceso = 1;
                        //form.txtPedido.Text = pedido.CodPedido.ToString();
                        //form.txtPedido.ReadOnly = true;
                        KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                        //form.txtPedido_KeyPress(form.txtPedido, ee);
                        form.Show();
                    }
                }
            }

            */
        }

        private void dgvPedidosPendientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && e.Row.Selected)
            {
                pedido.CodPedido = e.Row.Cells[codigo.Name].Value.ToString();


                entregadovend = Int32.Parse(e.Row.Cells[codentregado.Name].Value.ToString());
                cadEstado=Convert.ToString(e.Row.Cells[entregado.Name].Value);

                btnIrPedido.Enabled = true;
                btnAnular.Enabled = true;
                btGenVenta.Enabled = true;
                if (cadEstado == "ANULADO")
                {
                    btnAnular.Visible = false;
                    btnIrPedido.Text = "Consultar";
                }
                else if (entregadovend == 1)//entregado{
                {
                    btnIrPedido.Text = "Liquidar Entrega";
                    btnAnular.Visible = true;
                    //btGenVenta.Visible = true;

                }
                else if (entregadovend == 0)//liquidado
                {
                    btnIrPedido.Text = "Consultar Liquidado";
                    btnAnular.Visible = false;
                    //btGenVenta.Visible = false;

                }

            }
        }

        private void dgvPedidosPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPedidosPendientes.Rows.Count >= 1 && dgvPedidosPendientes.CurrentRow != null)
            {
                DataGridViewRow row = dgvPedidosPendientes.CurrentRow;
                frmConsultorExt form = new frmConsultorExt();

                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;
                form.Proceso = 4;
                form.Show();

                CargaLista();
            }



            /*
            if (dgvPedidosPendientes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmPedido form = new frmPedido();
                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;
                form.Proceso = 3;
                form.Show();
            }*/
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.CurrentRow != null && pedido.CodPedido != "")
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea eliminar la entrega seleccionada", "Entregas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmPedido.deleteEntConsExt(Convert.ToInt32(pedido.CodPedido)))
                    {
                        MessageBox.Show("La entrega ha sido anulada correctamente", "Entregas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                      form.Proceso = 1;
                      //form.txtPedido.Text = pedido.CodPedido.ToString();
                      //form.txtPedido.ReadOnly = true;
                      KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                      //form.txtPedido_KeyPress(form.txtPedido, ee);
                      form.Show();
                  }
              }
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

        private void dgvPedidosPendientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvPedidosPendientes.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvPedidosPendientes.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvPedidosPendientes.Rows.Count >= 1 && dgvPedidosPendientes.CurrentRow != null)
            {
                DataGridViewRow row = dgvPedidosPendientes.CurrentRow;
                frmConsultorExt form = new frmConsultorExt();
        
                form.MdiParent = this.MdiParent;
                form.CodPedido = pedido.CodPedido;
                form.Proceso = 4;
                form.Show();

                CargaLista();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmVenta"] != null)
            {
                Application.OpenForms["frmVenta"].Activate();
            }
            else
            {
                frmVenta form1 = new frmVenta();
                form1.MdiParent = this;
              //  form1.CodVendedor = Int32.Parse(e.Row.Cells[codVendedor.Name].Value.ToString());
            //    form1.CodSalConsulExt = Int32.Parse(e.Row.Cells[codSalConsulExt.Name].Value.ToString());
                form1.consultorext = true;
                form1.Proceso = 1;
                form1.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption;
            clsReportePedidos dso = new clsReportePedidos();
            CRConsultorEnt rpt = new CRConsultorEnt();
            frmRptEntregaConsultor frm = new frmRptEntregaConsultor();
            rptoption = rpt.PrintOptions;
            rptoption.PrinterName = ser.NombreImpresora;
            rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
            rpt.SetDataSource(dso.RptMuestraEntregaConsultorExt(Convert.ToInt32(pedido.CodPedido)).Tables[0]);
            frm.crvKardex.ReportSource = rpt;
            frm.Show();
        }
    }
}
