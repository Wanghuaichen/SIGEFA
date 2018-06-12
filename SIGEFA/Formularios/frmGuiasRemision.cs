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

    public partial class frmGuiasRemision : DevComponents.DotNetBar.Office2007Form    
    {        
        clsAdmGuiaRemision AdmGuia = new clsAdmGuiaRemision();
        clsGuiaRemision guia = new clsGuiaRemision();
        public Int32 Proceso = 0; //(1)Eliminar (2)Editar (3)Consulta

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        Int32 numeroGuia = 0;



        public frmGuiasRemision()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvGuiasRemision.DataSource = data;
            data.DataSource = AdmGuia.MuestraGuiaRemisiones(frmLogin.iCodAlmacen);            
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvGuiasRemision.ClearSelection();
        }

        private void btnIrPedido_Click(object sender, EventArgs e)
        {            
            if (dgvGuiasRemision.Rows.Count >= 1 && dgvGuiasRemision.CurrentRow != null)
            {
                DataGridViewRow row = dgvGuiasRemision.CurrentRow;
                frmGuiaRemision form = new frmGuiaRemision();                
                form.MdiParent = this.MdiParent;
                form.CodGuia = guia.CodGuiaRemision;
                form.CodTransaccion = guia.CodMotivo;
                form.numeroGuia = numeroGuia;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void frmPedidosPendientes_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (dgvGuiasRemision.Rows.Count >= 1 && dgvGuiasRemision.CurrentRow != null && Convert.ToBoolean(dgvGuiasRemision.CurrentRow.Cells[facturado.Name].Value) == false)
            {
                if (guia.CodGuiaRemision != "")
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
                        //form.CargaFormaPagos();
                        //form.txtGuias.Text = guia.CodGuiaRemision.ToString();
                        //form.txtGuias.ReadOnly = true;
                        KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                        form.Show();
                        form.txtGuias_KeyPress(sender, ee);
                        form.txtCodCliente.ReadOnly = true;
                    }
                }
            }
        }

        private void dgvPedidosPendientes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvGuiasRemision.Rows.Count >= 1 && e.Row.Selected)
            {
                guia.CodGuiaRemision = e.Row.Cells[codigo.Name].Value.ToString();
                guia.CodMotivo = Convert.ToInt32(e.Row.Cells[codMotivo.Name].Value);
                numeroGuia = Convert.ToInt32(e.Row.Cells[numeroguia.Name].Value);
            }
        }

        private void dgvPedidosPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGuiasRemision.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmGuiaRemision form = new frmGuiaRemision();                
                form.MdiParent = this.MdiParent;
                form.CodGuia = guia.CodGuiaRemision;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvGuiasRemision.CurrentRow != null && guia.CodGuiaRemision != "")
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la guia seleccionada", "Guias Remision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {                    
                    if (AdmGuia.delete(Convert.ToInt32(guia.CodGuiaRemision)))
                    {
                        MessageBox.Show("La guia ha sido anulada correctamente", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }
    }
}
