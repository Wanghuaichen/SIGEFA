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
    public partial class frmProveedoresLista : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmProveedor AdmPro = new clsAdmProveedor();        
        clsProveedor pro = new clsProveedor();
        public Int32 Proceso = 0; //(1) Ingreso (2)Salida (3)Relacion
        public Int32 Procede = 0; //(1) Nota de ingreso (2) Letra        
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public Int32 codProv;


        public frmProveedoresLista()
        {
            InitializeComponent();
        }

        public Int32 GetCodProveeder()
        {
            return Convert.ToInt32(dgvProveedor.CurrentRow.Cells[codigo.Name].Value);
        }

        private void CargaLista()
        {
            dgvProveedor.DataSource = data;
            data.DataSource = AdmPro.RelacionProveedores();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvProveedor.ClearSelection();
            dgvProveedor.Focus();
        }

        private void DepurarLista()
        {
            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                if (Convert.ToInt32(row.Cells[codigo.Name].Value) == codProv)
                {
                    dgvProveedor.Rows.Remove(row);
                }
            }
        }

        private void CargaLista2()
        {
            dgvProveedor.DataSource = data;
            data.DataSource = AdmPro.RelacionProveedores();
            DepurarLista();
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvProveedor.ClearSelection();
            dgvProveedor.Focus();
        }

        private void frmProveedoresLista_Load(object sender, EventArgs e)
        {   
            CargaLista();
            label2.Text = "RUC";
            label3.Text = "ruc";
            if (Procede == 9)
            {
                CargaLista2();
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
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                if (ee.KeyChar != (char)Keys.Down)
                {
                    dgvProveedor.ClearSelection();
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
            txtFiltro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Procede == 1)
            {
                frmNotaIngresoPorOrden form = (frmNotaIngresoPorOrden)Application.OpenForms["frmNotaIngresoPorOrden"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProv.Text = pro.Ruc;
                form.txtNombreProv.Text = pro.RazonSocial;
                form.txtCodProveedor.Text = pro.CodProveedor.ToString();
                this.Close();    
            }
            else if (Procede == 2)
            {
                frmGestionLetra form = (frmGestionLetra)Application.OpenForms["frmGestionLetra"];
                form.CodProveedor = pro.CodProveedor;                
                this.Close();
            }
            else if (Procede == 3)
            {
                frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProv.Text = pro.Ruc;
                form.txtNombreProv.Text = pro.RazonSocial;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            if (Procede == 4)
            {
                frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProv.Text = pro.Ruc;
                form.txtNombreProv.Text = pro.RazonSocial;
                this.Close();
            }
            if (Procede == 5)
            {
                frmListaPreciosProductos form = (frmListaPreciosProductos)Application.OpenForms["frmListaPreciosProductos"];
                if (pro.RazonSocial == null)
                {
                    form.txtProveedorNomb.Focus();
                }
                else
                {
                    form.txtProveedorCod.Text = pro.CodProveedor.ToString();
                    form.txtProveedorNomb.Text = pro.RazonSocial;
                }
                this.Close();
            }

             //NOTA DE CREDITO POR COMPRA
            //MODIFICADO ALEX 23/02/2015
            else if (Procede == 6)
            {
                frmNotadeCreditoCompra form = (frmNotadeCreditoCompra)Application.OpenForms["frmNotadeCreditoCompra"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProveedor.Text = pro.Ruc;
                form.txtNombreProveedor.Text = pro.RazonSocial;
                this.Close();
            }
            //NOTA DE DEBITO POR COMPRA
            //MODIFICADO ALEX 04/03/2015
            else if (Procede == 7)
            {
                frmNotadeDebitoCompra form = (frmNotadeDebitoCompra)Application.OpenForms["frmNotadeDebitoCompra"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodProveedor.Text = pro.Ruc;
                form.txtNombreProveedor.Text = pro.RazonSocial;
                this.Close();
            }
            else if (Procede == 8) // Salida por Devolucion
            {
                frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                form.CodProveedor = pro.CodProveedor;
                form.txtCodCliente.Text = pro.Ruc;
                form.txtNombreCliente.Text = pro.RazonSocial;
                form.btnDetalle.Enabled = true;
                this.Close();
            }
            else if (Procede == 9) //Cambio de Proveedor
            {
                frmCambioProveedor form = (frmCambioProveedor)Application.OpenForms["frmCambioProveedor"];
                form.CodProv = pro.CodProveedor;
                form.txtCodProv2.Text = form.CodProv.ToString();
                this.Close();
            }
        }

        private void dgvProveedor_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dgvProveedor.Rows.Count >= 1 && e.Row.Selected)
            //{
            //    pro.CodProveedor = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
            //    pro.Ruc = e.Row.Cells[ruc.Name].Value.ToString();
            //    pro.RazonSocial = e.Row.Cells[razonsocial.Name].Value.ToString();                
            //}
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count > 0)
            {
                if (Procede == 1)
                {
                    frmNotaIngresoPorOrden form = (frmNotaIngresoPorOrden)Application.OpenForms["frmNotaIngresoPorOrden"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodProv.Text = pro.Ruc;
                    form.txtNombreProv.Text = pro.RazonSocial;
                    form.txtCodProveedor.Text = pro.CodProveedor.ToString();
                    this.Close();
                }
                else if (Procede == 2)
                {
                    frmGestionLetra form = (frmGestionLetra)Application.OpenForms["frmGestionLetra"];
                    form.CodProveedor = pro.CodProveedor;
                    this.Close();
                }
                else if (Procede == 3)
                {
                    frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodProv.Text = pro.Ruc;
                    form.txtNombreProv.Text = pro.RazonSocial;
                    this.Close();
                }
                if (Procede == 4)
                {
                    frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodProv.Text = pro.Ruc;
                    form.txtNombreProv.Text = pro.RazonSocial;
                    this.Close();
                }
                if (Procede == 5)
                {
                    frmListaPreciosProductos form = (frmListaPreciosProductos)Application.OpenForms["frmListaPreciosProductos"];
                    if (pro.RazonSocial == null)
                    {
                        form.txtProveedorNomb.Focus();
                    }
                    else{
                    form.txtProveedorCod.Text = pro.CodProveedor.ToString();
                    form.txtProveedorNomb.Text = pro.RazonSocial;
                    }
                    this.Close();
                }

                 //NOTA DE CREDITO POR COMPRA
                //MODIFICADO ALEX 23/02/2015
                else if (Procede == 6)
                {
                    frmNotadeCreditoCompra form = (frmNotadeCreditoCompra)Application.OpenForms["frmNotadeCreditoCompra"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodProveedor.Text = pro.Ruc;
                    form.txtNombreProveedor.Text = pro.RazonSocial;
                    this.Close();
                }
                //NOTA DE DEBITO POR COMPRA
                //MODIFICADO ALEX 04/03/2015
                else if (Procede == 7)
                {
                    frmNotadeDebitoCompra form = (frmNotadeDebitoCompra)Application.OpenForms["frmNotadeDebitoCompra"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodProveedor.Text = pro.Ruc;
                    form.txtNombreProveedor.Text = pro.RazonSocial;
                    this.Close();
                }
                else if (Procede == 8) //Salida por Devolucion
                {
                    frmNotaSalida form = (frmNotaSalida)Application.OpenForms["frmNotaSalida"];
                    form.CodProveedor = pro.CodProveedor;
                    form.txtCodCliente.Text = pro.Ruc;
                    form.txtNombreCliente.Text = pro.RazonSocial;
                    form.btnDetalle.Enabled = true;
                    this.Close();
                }
                else if (Procede == 9) //Cambio de Proveedor
                {
                    frmCambioProveedor form = (frmCambioProveedor)Application.OpenForms["frmCambioProveedor"];
                    form.CodProv = pro.CodProveedor;
                    form.txtCodProv2.Text = form.CodProv.ToString();
                    this.Close();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmGestionProveedor frm = new frmGestionProveedor();
            frm.Proceso = 1;
            frm.ShowDialog();
            CargaLista();
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)//MOD4
        {
            try
            {
                if (dgvProveedor.Rows.Count >= 1 && e.RowIndex != -1 && dgvProveedor.CurrentRow.Index == e.RowIndex)
                {
                    DataGridViewRow Row = dgvProveedor.Rows[e.RowIndex];
                    pro.CodProveedor = Convert.ToInt32(Row.Cells[codigo.Name].Value);
                    pro.Ruc = Row.Cells[ruc.Name].Value.ToString();
                    pro.RazonSocial = Row.Cells[razonsocial.Name].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dgvProveedor.Rows.Count >0)
                    {
                        int f = dgvProveedor.CurrentRow.Index;
                        pro.CodProveedor = Convert.ToInt32(dgvProveedor.Rows[f].Cells[codigo.Name].Value);
                        pro.Ruc = dgvProveedor.Rows[f].Cells[ruc.Name].Value.ToString();
                        pro.RazonSocial = dgvProveedor.Rows[f].Cells[razonsocial.Name].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (Proceso == 3)
                {
                    btnAceptar.Enabled = true;
                } 
            }


            if (e.KeyCode == Keys.Return)
            {
                if (dgvProveedor.SelectedRows.Count > 0)
                {
                    if (Procede == 1)
                    {
                        frmNotaIngresoPorOrden form = (frmNotaIngresoPorOrden)Application.OpenForms["frmNotaIngresoPorOrden"];
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
                    else if (Procede == 3)
                    {
                        frmOrdenCompra form = (frmOrdenCompra)Application.OpenForms["frmOrdenCompra"];
                        form.CodProveedor = pro.CodProveedor;
                        form.txtCodProv.Text = pro.Ruc;
                        form.txtNombreProv.Text = pro.RazonSocial;
                        this.Close();
                    }
                    if (Procede == 4)
                    {
                        frmNotaIngreso form = (frmNotaIngreso)Application.OpenForms["frmNotaIngreso"];
                        form.CodProveedor = pro.CodProveedor;
                        form.txtCodProv.Text = pro.Ruc;
                        form.txtNombreProv.Text = pro.RazonSocial;
                        this.Close();
                    }
                }
            }
        }

        private void frmProveedoresLista_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvProveedor.Focus();
            }
            dgvProveedor.ClearSelection();
        }
    }
}
