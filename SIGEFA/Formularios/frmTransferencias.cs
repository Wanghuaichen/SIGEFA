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

    public partial class frmTransferencias : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 tipo = 0;
        clsAdmNotaIngreso admNotaIngreso =new clsAdmNotaIngreso();
        clsNotaIngreso notaIngreso=new clsNotaIngreso();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmTransferencias()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargaLista()
        {
            dgvOrdenes.DataSource = data;
            data.DataSource = admNotaIngreso.MuestraTransferenciasVigentes(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                frmTranferenciaDirecta form = new frmTranferenciaDirecta();
                form.MdiParent = this.MdiParent;
                form.CodTransferencia = notaIngreso.CodNotaIngreso;
                form.Proceso = 3;
                form.Show();           
            }
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && e.Row.Selected)
            {
                notaIngreso.CodNotaIngreso =e.Row.Cells[codigo.Name].Value.ToString();
                notaIngreso.CodSerie = Convert.ToInt32(e.Row.Cells[serie.Name].Value);
                notaIngreso.NumDoc = e.Row.Cells[numdocumento.Name].Value.ToString();
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvOrdenes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmTranferenciaDirecta form = new frmTranferenciaDirecta();
                form.MdiParent = this.MdiParent;
                form.CodTransferencia = notaIngreso.CodNotaIngreso;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Convert.ToInt32(notaIngreso.CodNotaIngreso) != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la transferencia seleccionada", "Transferencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (Application.OpenForms["frmVigenciaCotizacion"] != null)
                    {
                        Application.OpenForms["frmVigenciaCotizacion"].Close();
                    }
                    else
                    {
                        frmVigenciaCotizacion form = new frmVigenciaCotizacion();
                        form.Proceso = 2;
                        form.Procede = 2;
                        form.groupBox2.Visible = true;
                        form.groupBox1.Visible = false;
                        form.serie = notaIngreso.CodSerie;
                        form.numeracion = notaIngreso.NumDoc;
                        form.Show();
                        this.Close();
                    }
                }
                CargaLista();

            }
        }

        private void btnAtendido_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Convert.ToInt32(notaIngreso.CodNotaIngreso)!= 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea Aceptar la Transferencia seleccionada", "Transferencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (admNotaIngreso.atender(Convert.ToInt32(notaIngreso.CodNotaIngreso), notaIngreso.CodSerie, notaIngreso.NumDoc, frmLogin.iCodUser))
                    {
                        MessageBox.Show("La Transferencia ha sido Atendida correctamente", "Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                CargaLista();
            }
        }

        private void frmTransferencias_Shown(object sender, EventArgs e)
        {
            CargaLista();
        }

    }
}
