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
    public partial class frmConsolidado : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmRequerimiento AdmReq = new clsAdmRequerimiento();
        clsRequerimiento Req = new clsRequerimiento();
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Orden = new clsOrdenCompra();
        clsDetalleConsolidado dtaConsolidado = new clsDetalleConsolidado();
        public Int32 Alm = 0;
        public DataTable productosConsolidado = new DataTable();
        public List<Int32> coddetallerequerimientos = new List<Int32>();
        public List<clsDetalleConsolidado> detalle = new List<clsDetalleConsolidado>();
        public List<Int32> seleccion = new List<Int32>();
        public List<Int32> codProd = new List<int>();
        public Int32 CodProveedor;
        public Int32 CodOrdenCompra;
        public Int32 codorden = 0, estadcheck, proceso = 0, proce = 0, Almaori=0;

        public Int32 Contador = 0;

        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto prod = new clsProducto();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        //variables necesarias para el HeaderCheckBox
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;


        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvDetalle.Controls.Add(HeaderCheckBox);
            HeaderCheckBox.Visible = false;
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvDetalle.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells[escoje.Name]).Value = HCheckBox.Checked;

            dgvDetalle.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;
            //calculapesosalida();
            IsHeaderCheckBoxClicked = false;
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvDetalle.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modifiy Counter;            
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }

        public frmConsolidado()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmOrdenCompras fordeC = new frmOrdenCompras();
            fordeC.Close();
        }


        private void sololectura(Boolean estado)
        {
            btnGuardar.Visible = !estado;
        }
        private void txtDocRef_Leave(object sender, EventArgs e)
        {

        }

        public void Cargaconsolidado(Int32 codalma, Int32 codprov)
        {
            dgvDetalle.DataSource = data;
            data.DataSource = AdmReq.Cargaconsolidado(codalma, codprov);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle.ClearSelection();
        }
        public void CargaRequerimientosTotales(Int32 almac, Int32 almaori)
        {
            dgvDetalle.DataSource = data;
            data.DataSource = AdmReq.cargaRequerimientosTotales(almac, almaori);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (proceso != 9)
            {
                //AdmOrden.deleteConsolidado(frmLogin.iCodAlmacen,frmLogin.iCodUser);
                coddetallerequerimientos.Clear();
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (Convert.ToInt32(row.Cells[escoje.Name].Value) == 1)
                    {
                        dtaConsolidado.CodDetalle = Convert.ToInt32(row.Cells[coddetalle.Name].Value);
                        dtaConsolidado.CodProducto = Convert.ToInt32(row.Cells[codProducto.Name].Value);
                        dtaConsolidado.Cantidad = Convert.ToDouble(row.Cells[Cantidad.Name].Value);
                        dtaConsolidado.CodAlmacen = frmLogin.iCodAlmacen;
                        dtaConsolidado.CodUsuario = frmLogin.iCodUser;
                        //AdmOrden.insertdetalleConsolidado(dtaConsolidado);
                        coddetallerequerimientos.Add(dtaConsolidado.CodDetalle);
                    }
                }


                frmOrdenCompras form = (frmOrdenCompras)Application.OpenForms["frmOrdenCompras"];
                form.MdiParent = this.MdiParent;
                form.documento = coddetallerequerimientos;
                this.Close();
                form.Show();
                if (Application.OpenForms["frmOrdenCompras"] != null)
                {
                    Application.OpenForms["frmOrdenCompras"].Activate();
                    form.CargaDetalle();
                }
                else
                {
                    form.Show();
                }
            }
            else
            {
                frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                    {
                        this.Close();
                        form.txtRequerimiento.Text+=""+row.Cells[numeracion.Name].Value+",";
                        prod = AdmPro.MuestraProductosTransferencia(Convert.ToInt32(row.Cells[codProducto.Name].Value), frmLogin.iCodAlmacen);
                        if (proce == 1)
                        {
                            form.dgvDetalle.Rows.Add(row.Cells[coddetalle.Name].Value, row.Cells[codProducto.Name].Value,
                                row.Cells[Referencia.Name].Value, row.Cells[Producto.Name].Value,
                                row.Cells[codUnidadMedida.Name].Value,
                                row.Cells[Unidad.Name].Value, row.Cells[Cantidad.Name].Value, prod.ValorProm, prod.ValorPromsoles, prod.PrecioProm, prod.StockActual);
                        }
                        else if (proce == 2)
                        {
                            form.dgvDetalle.CurrentRow.SetValues(row.Cells[coddetalle.Name].Value, row.Cells[codProducto.Name].Value,
                                row.Cells[Referencia.Name].Value, row.Cells[Producto.Name].Value,
                                row.Cells[codUnidadMedida.Name].Value,
                                row.Cells[Unidad.Name].Value, row.Cells[Cantidad.Name].Value, prod.ValorProm, prod.ValorPromsoles, prod.PrecioProm, prod.StockActual);
                        }

                    }
                }
            }
        }
     

        private void frmConsolidado_Load(object sender, EventArgs e)
        {
            AddHeaderCheckBox();
            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(this.HeaderCheckBox_MouseClick);
            dgvDetalle.CellValueChanged += new DataGridViewCellEventHandler(dgvDetalle_CellValueChanged);

            if (proceso == 0)
            {
                Cargaconsolidado(frmLogin.iCodAlmacen, CodProveedor);
            }
            if (proceso == 2)
            {
                Cargaconsolidado(frmLogin.iCodAlmacen,CodProveedor);           
            }
            if (proceso == 9)
            {
                escoje.Visible = false;
                CargaRequerimientosTotales(Alm, Almaori);
                btnGuardar.Text = "Transferencia";
            }
            if (proceso == 3)
            {
                Cargaconsolidado(frmLogin.iCodAlmacen, CodProveedor);
                escoje.Visible = false;
                btnGuardar.Visible = false;
            }
 
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.Close();
             if (proceso == 9)
            {
                frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
                if (dgvDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                    {
                        form.txtRequerimiento.Text += "" + row.Cells[numeracion.Name].Value + ",";
                        prod = AdmPro.MuestraProductosTransferencia(Convert.ToInt32(row.Cells[codProducto.Name].Value), frmLogin.iCodAlmacen);
                        this.Close();
                        if (proce == 1)
                        {
                            form.dgvDetalle.Rows.Add(row.Cells[coddetalle.Name].Value, row.Cells[codProducto.Name].Value,
                                row.Cells[Referencia.Name].Value, row.Cells[Producto.Name].Value,
                                row.Cells[codUnidadMedida.Name].Value,
                                row.Cells[Unidad.Name].Value, row.Cells[Cantidad.Name].Value, prod.ValorProm,prod.ValorPromsoles,prod.PrecioProm, prod.StockActual );
                        }
                        else if (proce == 2)
                        {
                            form.dgvDetalle.CurrentRow.SetValues(row.Cells[coddetalle.Name].Value, row.Cells[codProducto.Name].Value,
                                row.Cells[Referencia.Name].Value, row.Cells[Producto.Name].Value,
                                row.Cells[codUnidadMedida.Name].Value,
                                row.Cells[Unidad.Name].Value, row.Cells[Cantidad.Name].Value, prod.ValorProm, prod.ValorPromsoles, prod.PrecioProm, prod.StockActual);
                        }
                        
                    }
                }
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                {
                    AdmReq.anularDetalle(Convert.ToInt32(row.Cells[coddetalle.Name].Value));
                }
            }
            Cargaconsolidado(frmLogin.iCodAlmacen, CodProveedor);
        }

        private void dgvDetalle_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (proceso == 2)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (coddetallerequerimientos.Contains(Convert.ToInt32(row.Cells[coddetalle.Name].Value)))
                    {
                        row.Cells[escoje.Name].Value = true;
                    }
                }
            }
            //if(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value!=null){
            //    if (codProd.Contains(Convert.ToInt32(dgvDetalle.CurrentRow.Cells[coddetalle.Name].Value)))
            //    {
            //        MessageBox.Show("El producto ya existe");
            //        dgvDetalle.CurrentRow.Cells[escoje.Name].Value = false;
            //    }
            //}
           
        }

        

        private void dgvDetalle_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.EndEdit();
            if (e.ColumnIndex == dgvDetalle.Columns[escoje.Name].Index)
            {
                //calculapesosalida();
            }
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Visible)
                {
                    ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
                    HeaderCheckBox.Visible = true;
                }
                else
                {
                    HeaderCheckBox.Visible = false;
                }
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsHeaderCheckBoxClicked)
                RowCheckBoxClick((DataGridViewCheckBoxCell)dgvDetalle[e.ColumnIndex, e.RowIndex]);
        }
            
       
    }
}
