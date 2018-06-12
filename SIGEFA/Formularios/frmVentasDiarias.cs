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
    public partial class frmVentasDiarias : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProveedor AdmPro = new clsAdmProveedor();        
        clsProveedor pro = new clsProveedor();
        public Int32 Proceso = 0; //(1) Ingreso (2)Salida (3)Relacion
        public Int32 Procede = 0; //(1) Nota de ingreso (2) Letra        
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 codVendedor;
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        public frmVentasDiarias()
        {
            InitializeComponent();
        }

        private void CargaLista()
        {
            dataGridView1.DataSource = data;
            data.DataSource = AdmVenta.VentasDiarias(frmLogin.iCodAlmacen, dtpFecha.Value, codVendedor);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dataGridView1.ClearSelection();
            if(dataGridView1.RowCount > 0)
                btnAceptar.Enabled = true;
            else
                btnAceptar.Enabled = false;
        }

        private void frmProveedoresLista_Load(object sender, EventArgs e)
        {   
            CargaLista();
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

        private void dgvProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label2.Text = dgvProveedor.Columns[e.ColumnIndex].HeaderText;
            label3.Text = dgvProveedor.Columns[e.ColumnIndex].DataPropertyName;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Procede == 1)
            {
                frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProv.Text = pro.Ruc;
                form.txtNombreProv.Text = pro.RazonSocial;
                this.Close();
            }
            else if (Procede == 2)
            {
                frmGestionLetra form = (frmGestionLetra)Application.OpenForms["frmGestionLetra"];
                form.CodProveedor = pro.CodProveedor;                
                this.Close();
            }
        }

        private void dgvProveedor_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvProveedor.Rows.Count >= 1 && e.Row.Selected)
            {
                pro.CodProveedor = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                pro.Ruc = e.Row.Cells[ruc.Name].Value.ToString();
                pro.RazonSocial = e.Row.Cells[razonsocial.Name].Value.ToString();                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
           frmConsultorExt form = (frmConsultorExt)Application.OpenForms["frmConsultorExt"];
           form.CodVendedor = codVendedor;
           if (dataGridView1.Rows.Count > 0)
           {
               foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                    String flg=Convert.ToString(row.Cells[Seleccionar.Name].Value);
                    if (flg == "1")
                    {
                        form.listNotas.Add(Convert.ToInt32(row.Cells[codFactura.Name].Value));
                    }
               }
           }
           this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionProveedor frm = new frmGestionProveedor();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proceso == 3)
            {
                btnAceptar.Enabled = true;
            }
        }

        private void dgvProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (dgvProveedor.SelectedRows.Count > 0)
            //    {
            //        if (Procede == 1)
            //        {
            //            frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
            //            form.CodProveedor = pro.CodProveedor;
            //            form.txtCodProv.Text = pro.Ruc;
            //            form.txtNombreProv.Text = pro.RazonSocial;
            //            this.Close();
            //        }
            //        else if (Procede == 2)
            //        {
            //            frmGestionLetra form = (frmGestionLetra)Application.OpenForms["frmGestionLetra"];
            //            form.CodProveedor = pro.CodProveedor;
            //            this.Close();
            //        }
            //    }
            //}
        }

        private void dgvProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (dgvProveedor.SelectedRows.Count > 0)
                {
                    if (Procede == 1)
                    {
                        frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                        form.CodProveedor = pro.CodProveedor;
                        form.txtCodProv.Text = pro.Ruc;
                        form.txtNombreProv.Text = pro.RazonSocial;
                        this.Close();
                    }
                    else if (Procede == 2)
                    {
                        frmGestionLetra form = (frmGestionLetra)Application.OpenForms["frmGestionLetra"];
                        form.CodProveedor = pro.CodProveedor;
                        this.Close();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
