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
    public partial class frmNotaOrdenAlmacen : Form
    {
        private clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        private clsOrdenCompra Orden = new clsOrdenCompra();
        private clsAdmNotaIngreso admNotaIng = new clsAdmNotaIngreso();
        private clsNotaIngreso nota = new clsNotaIngreso();
        private clsDetalleNotaIngreso detaNota = new clsDetalleNotaIngreso();
        public clsProveedor deta = new clsProveedor();
       public clsCliente detaCli = new clsCliente();
        public clsNotaSalida salida = new clsNotaSalida();
        private clsAdmNotaSalida AdmSalida = new clsAdmNotaSalida();
        

        public DataTable notaingresoConsolidado = new DataTable();
        public List<Int32> coddetallenota = new List<Int32>();
        public List<clsDetalleNotaIngreso> detalle = new List<clsDetalleNotaIngreso>();
        public List<clsNotaIngreso> notaIn = new List<clsNotaIngreso>();
        public List<clsDetalleFacturaVenta> detalle1 = new List<clsDetalleFacturaVenta>();
        public List<Int32> coddetalleventa = new List<Int32>();
        public List<clsDetalleCotizacion> detalle2 = new List<clsDetalleCotizacion>();
        public List<Int32> coddetallecoti = new List<Int32>();
        public DataGridView dat = new DataGridView();
        public List<Int32> ltaCodListaPrecio = new List<Int32>();
        public List<Int32> ltacodnotasalida = new List<Int32>();

        public Int32 OrdCom, CodSalida;
        public Int32 CodProveedor;
        public Int32 CodCli, CodDoc, tipomoneda;
        public Int32 CodFac, codforma, codlista;
        public Int32 CodOrdenCompra;
        public Int32 codorden = 0, estadcheck, proceso = 0, procede = 0;
        public String unir = "", unir2 = "";
        public Int32 Contador = 0;
        public Double tipocambio;

        public String codigopersonalizado = "", nombreCliente = "", direccionCliente = "";
        public Int32 codcli;
        private Int32 estado = 0;
        public Int32 tipo = 0;
        Int32 vOrigOC = 0;

        public static BindingSource data = new BindingSource();
        private String filtro = String.Empty;

        public frmNotaOrdenAlmacen()
        {
            InitializeComponent();
        }

        

        private void NotaOrdenAlmacen_Load(object sender, EventArgs e)
        {
            btnbuscar_Click(sender, e);
        }

        private void CargaNotaAlmacen()
        {
            dgvDetalle2.DataSource = data;
            data.DataSource = AdmSalida.MuestraNotaAlmacen(frmLogin.iCodAlmacen, tipo);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle2.ClearSelection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sololectura(Boolean estado)
        {
            btnAceptar.Visible = !estado;
        }

        public void Cargaconsolidado()
        {

            dgvDetalle.DataSource = data;
            data.DataSource = admNotaIng.MuestraNotaIngresoOrden(frmLogin.iCodAlmacen, dtpDesde.Value.Date, dtpHasta.Value.Date);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle.ClearSelection();
            //proceso = this.proceso;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (proceso == 7)
            {
                coddetallenota.Clear();
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToInt32(row.Cells[escoge.Name].Value) == 1 &&
                        Convert.ToInt32(row.Cells[codOrdenC.Name].Value) == Convert.ToInt32(textBox1.Text))
                    {
                        estado = 1;
                    }
                    else if (Convert.ToInt32(row.Cells[escoge.Name].Value) == 1 &&
                             Convert.ToInt32(row.Cells[codOrdenC.Name].Value)
                             != Convert.ToInt32(textBox1.Text))
                    {
                        estado = 0;
                        break;
                    }
                }
                if (estado == 1)
                {
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        vOrigOC = Convert.ToInt32(row.Cells[codOrdenC.Name].Value);
                        if (Convert.ToInt32(row.Cells[escoge.Name].Value) == 1 &&
                            Convert.ToInt32(row.Cells[codOrdenC.Name].Value) == Convert.ToInt32(textBox1.Text))
                        {
                            admNotaIng.insertdetalleConsolidado(Convert.ToInt32(row.Cells[codOrdenC.Name].Value),
                                Convert.ToInt32(row.Cells[codnoting.Name].Value), frmLogin.iCodAlmacen,
                                frmLogin.iCodUser);
                            detaNota.CodNotaIngreso = Convert.ToInt32(row.Cells[codnoting.Name].Value.ToString());
                            coddetallenota.Add(detaNota.CodNotaIngreso);
                            unir += row.Cells[documento.Name].Value + ", ";
                        }
                    }

                    frmNotaIngresoPorOrden form =
                        (frmNotaIngresoPorOrden) Application.OpenForms["frmNotaIngresoPorOrden"];
                    form.documento = coddetallenota;
                    form.datoscarga2.Clear();
                    String doc="";
                    foreach (int c in form.documento)
                    {
                        form.txtOrdenCompra.Text = unir;
                        nota = admNotaIng.CargaNotaIngreso(c);
                        form.cmbFormaPago.SelectedValue = nota.FormaPago;
                        form.cmbFormaPago_SelectionChangeCommitted(form.cmbFormaPago, null);//MOD7
                        form.dtpFechaPago.Value = nota.FechaPago;
                        form.cmbMoneda.SelectedValue = nota.Moneda;
                        form.txtTipoCambio.Visible = true;
                        form.label16.Visible = true;
                        form.txtTipoCambio.Text = nota.TipoCambio.ToString();
                        form.txtFlete.Text = nota.Flete.ToString();
                        form.txtCodProv.Text = nota.RUCProveedor;
                        form.txtNombreProv.Text = nota.RazonSocialProveedor;
                        form.txtCodProveedor.Text = nota.CodProveedor.ToString();
                        doc=doc+c+",";
                    }
                    form.txtCodNota.Text = doc;
                    form.vOrigOC = vOrigOC;
                    form.llenardetalle2();
                    Close();
                }
                else
                {
                    MessageBox.Show("Escoja Ordenes Iguales");
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        row.Cells[escoge.Name].Value = 0;
                    }
                }
            }
            else if (proceso == 11)
            {
                if (dgvDetalle2.Rows.Count > 0 && dgvDetalle2.SelectedRows != null)
                {
                    salida.CodNotaSalida = dgvDetalle2.CurrentRow.Cells[codnotasalida.Name].Value.ToString();
                }
                this.Close();
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDetalle.CurrentRow.Cells[escoge.Name].Value) == 1)
            {
                textBox1.Text = dgvDetalle.CurrentRow.Cells[codOrdenC.Name].Value.ToString();
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            frmNotaIngreso form = new frmNotaIngreso();
            form.CodNota = nota.CodNotaIngreso;
            form.Proceso = 3;
            form.Tipo = 2;
            form.Show();
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvDetalle.Rows.Count >= 1 && e.Row.Selected)
            {
                nota.CodNotaIngreso = Convert.ToString(e.Row.Cells[codnoting.Name].Value);
            }
        }

        private void dgvDetalle2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                salida.CodNotaSalida = dgvDetalle2.Rows[e.RowIndex].Cells[codnotasalida.Name].Value.ToString();
            }
            this.Close();
        }

        private void dgvDetalle2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Cargaconsolidado();
            if (proceso == 7)
            {
                admNotaIng.deleteConsolidado(frmLogin.iCodAlmacen, frmLogin.iCodUser);
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (coddetallenota.Contains(Convert.ToInt32(row.Cells[codnoting.Name].Value)))
                    {
                        row.Cells[escoge.Name].Value = true;
                        textBox1.Text = row.Cells[codOrdenC.Name].Value.ToString();
                    }
                }
            }
               
            //else if (proceso == 11)
            //{
            //    dgvDetalle.Visible = false;
            //    dgvDetalle2.Visible = true;
            //    CargaNotaAlmacen();
            //}

            else if (proceso == 1)
            {
                Cargaconsolidado();
                btnAceptar.Visible = false;
                btnconsultar.Visible = true;
                escoge.Visible = false;
            }
        }

        private void dgvDetalle_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvDetalle.Columns[e.ColumnIndex].HeaderText;
            label4.Text = dgvDetalle.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label4.Text.Trim(), txtFiltro.Text.Trim());
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

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            //Flecha Hacia ABAJO 
            if (e.KeyCode == Keys.Down)
            {
                dgvDetalle.Focus();
            } 
        }

        private void frmNotaOrdenAlmacen_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }

}

