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
    public partial class frmConsolidadoTransferencia : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmRequerimiento AdmReq = new clsAdmRequerimiento();
        clsRequerimiento Req = new clsRequerimiento();
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Orden = new clsOrdenCompra();
        clsDetalleConsolidado dtaConsolidado = new clsDetalleConsolidado();
        clsValidar val = new clsValidar();
        
        public DataTable productosConsolidado = new DataTable();
        public List<Int32> coddetallerequerimientos = new List<Int32>();
        public List<clsDetalleConsolidado> detalle = new List<clsDetalleConsolidado>();
        public List<Int32> seleccion = new List<Int32>();

        public Int32 CodProveedor;
        public Int32 CodOrdenCompra;
        public Int32 codorden = 0, estadcheck, proceso = 0, proce = 0;

        public Int32 Alm = 0, Almaori = 0;

        public Int32 Contador = 0;

        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto prod = new clsProducto();

        public static BindingSource data = new BindingSource();
        public static BindingSource data_detalle = new BindingSource();
        String filtro = String.Empty;

        //public frmTranferenciaDirecta form_auxiliar;

        public DataTable DtAuxiliar = new DataTable();
        public DataTable DtAuxiliar_pasados = new DataTable();

        private Int32 posicion_dgdetalle = -1;

        public frmConsolidadoTransferencia()
        {
            InitializeComponent();
        }

        private void frmConsolidadoTransferencia_Load(object sender, EventArgs e)
        {
            //form_auxiliar = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];
            agregafilasDT();
        }

        private void agregafilasDT() 
        {

            DtAuxiliar.Clear();
            DtAuxiliar_pasados.Clear();

            //dt.Columns.Add("NombreCol", typeof(System.Double));

            //agregamos filas al dt auxiliar
            DtAuxiliar.Columns.Add("coddetalle", typeof(System.Int32));
            DtAuxiliar.Columns.Add("codProducto", typeof(System.Int32));
            DtAuxiliar.Columns.Add("Referencia", typeof(System.String));
            DtAuxiliar.Columns.Add("codUnidadMedida", typeof(System.Int32));
            DtAuxiliar.Columns.Add("Producto", typeof(System.String));
            DtAuxiliar.Columns.Add("Unidad", typeof(System.String));
            DtAuxiliar.Columns.Add("Cantidad", typeof(System.Decimal));
            DtAuxiliar.Columns.Add("comentario_usu", typeof(System.String));
            DtAuxiliar.Columns.Add("codrequerimiento", typeof(System.Decimal));

            //agregamos filas al dt auxiliar_pasados
            DtAuxiliar_pasados.Columns.Add("coddetalle", typeof(System.Int32));
            DtAuxiliar_pasados.Columns.Add("codProducto", typeof(System.Int32));
            DtAuxiliar_pasados.Columns.Add("Referencia", typeof(System.String));
            DtAuxiliar_pasados.Columns.Add("codUnidadMedida", typeof(System.Int32));
            DtAuxiliar_pasados.Columns.Add("Producto", typeof(System.String));
            DtAuxiliar_pasados.Columns.Add("Unidad", typeof(System.String));
            DtAuxiliar_pasados.Columns.Add("Cantidad", typeof(System.Decimal));
            DtAuxiliar_pasados.Columns.Add("comentario_usu", typeof(System.String));
            DtAuxiliar_pasados.Columns.Add("codrequerimiento", typeof(System.Decimal));

            //agregamos filas al dt auxiliar
            //DtAuxiliar_pasados = DtAuxiliar;
        } 

        private void LlenadoAuxiliar() 
        {
            foreach (DataGridViewRow rowGrid in dgvDetalle.Rows)
            {
                DataRow row = DtAuxiliar.NewRow();
                
                /*row["coddetalle"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["codProducto"] = Convert.ToInt32(rowGrid.Cells[9].Value);
                row["Producto"] = Convert.ToInt32(rowGrid.Cells[7].Value);
                row["Referencia"] = Convert.ToString(rowGrid.Cells[8].Value);
                row["Unidad"] = Convert.ToString(rowGrid.Cells[10].Value);
                row["Cantidad"] = Convert.ToDecimal(rowGrid.Cells[11].Value);
                row["codUnidadMedida"] = Convert.ToInt32(rowGrid.Cells[14].Value);*/

                row["coddetalle"] = rowGrid.Cells[coddetalle.Name].Value;
                row["codProducto"] = rowGrid.Cells[codProducto.Name].Value;
                row["Producto"] = rowGrid.Cells[Referencia.Name].Value;
                row["Referencia"] = rowGrid.Cells[Producto.Name].Value;
                row["Unidad"] = rowGrid.Cells[Unidad.Name].Value;
                row["Cantidad"] = rowGrid.Cells[Cantidad.Name].Value;
                row["codUnidadMedida"] = rowGrid.Cells[codUnidadMedida.Name].Value;
                row["comentario_usu"] = rowGrid.Cells[comentario_usu.Name].Value;
                row["codrequerimiento"] = rowGrid.Cells[codrequerimiento.Name].Value;

                DtAuxiliar.Rows.Add(row);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaListaHistorial(Almaori, Alm, 1);
        }

        private void CargaListaHistorial(Int32 alma, Int32 almades, Int32 tip)
        {
            dgvDetalle.Visible = false;
            dgvOrdenes.Visible = true;
            dgvOrdenes.DataSource = data;
            data.DataSource = AdmReq.ListaRequerimientoHistorial_x_almacen(alma, almades, dtpDesde.Value.Date, dtpHasta.Value.Date, tip);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvOrdenes.ClearSelection();
            btnVerDetalle.Enabled = true;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            DtAuxiliar.Clear();
            DtAuxiliar_pasados.Clear();
            if (dgvOrdenes.SelectedRows.Count > 0)
            {
                btnCerrarDetalle.Enabled = true;
                CargaRequerimientosTotales(Alm, Almaori);
                dgvDetalle.Visible = true;
                dgvOrdenes.Visible = false;
                btnGuardar.Visible = true;
                LlenadoAuxiliar();
                btnGuardar.Visible = false;
            }
            else 
            {
                MessageBox.Show("Debe seleccionar un valor para ver su detalle.");
            }
        }

        private void dgvOrdenes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && e.Row.Selected)
            {
                Req.CodRequerimiento = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                Req.CodAlmacen = Alm;
                //Req.CodAlmacen = Convert.ToInt32(e.Row.Cells[codAlmacen.Name].Value);
                //AtendidoReq = e.Row.Cells[Atendido.Name].Value.ToString();
            }
        }

        public void CargaRequerimientosTotales(Int32 almac, Int32 almaori)
        {
            dgvDetalle.DataSource = data_detalle;
            data_detalle.DataSource = AdmReq.cargaRequerimientosTotales_x_requerimiento(Req.CodRequerimiento);
            data_detalle.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalle.ClearSelection();
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            btnCerrarDetalle.Enabled = false;
            dgvDetalle.Visible = false;
            dgvOrdenes.Visible = true;
            btnGuardar.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean cantidad_checks = false;

            cantidad_checks = cuenta_cheks();

            if (cantidad_checks == true)
            {

                frmTranferenciaDirecta form = (frmTranferenciaDirecta)Application.OpenForms["frmTranferenciaDirecta"];

                //frmConsolidadoTransferencia form = (frmConsolidadoTransferencia)Application.OpenForms["frmConsolidadoTransferencia"];
                if (dgvDetalle.Rows.Count > 0)
                {
                    //foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
                    foreach (DataGridViewRow row in dgvDetalle.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[escoje.Name].Value) == true)
                        {
                            this.Close();
                            //form.txtRequerimiento.Text += "" + row.Cells[numeracion.Name].Value + ",";
                            form.txtAlmacenDestino.Text = Convert.ToString(row.Cells[numeracion.Name].Value);
                            form.txtReq.Text =Req.CodRequerimiento.ToString();
                            //prod = AdmPro.MuestraProductosTransferencia(Convert.ToInt32(row.Cells[codProducto.Name].Value), frmLogin.iCodAlmacen);
                            prod = AdmPro.MuestraProductosTransferencia_nuevo(Convert.ToInt32(row.Cells[codProducto.Name].Value), Almaori);

                            if (proce == 1)
                            {

                                /*if (prod.ValorProm == null) prod.ValorProm = 0;
                                if (prod.ValorPromsoles == null)prod.ValorPromsoles = 0;
                                if (prod.PrecioProm == null) prod.PrecioProm = 0;
                                if (prod.StockActual == null) prod.StockActual = 0;*/

                                if (prod.Cantidad == 0)
                                {
                                    form.dgvDetalle.Rows.Add
                                    (
                                        row.Cells[coddetalle.Name].Value,
                                        row.Cells[codProducto.Name].Value,
                                        row.Cells[Referencia.Name].Value,
                                        row.Cells[Producto.Name].Value,
                                        row.Cells[codUnidadMedida.Name].Value,
                                        row.Cells[Unidad.Name].Value,
                                        row.Cells[Cantidad.Name].Value,
                                        //prod.ValorProm, 
                                        //prod.ValorPromsoles, 
                                        //prod.PrecioProm,
                                        0, 0, 0, row.Cells[stockgeneral.Name].Value,
                                        //prod.StockActual,
                                        row.Cells[comentario_usu.Name].Value,
                                        row.Cells[codrequerimiento.Name].Value
                                     );
                                }
                                else 
                                {
                                    form.dgvDetalle.Rows.Add
                                   (
                                       row.Cells[coddetalle.Name].Value,
                                       row.Cells[codProducto.Name].Value,
                                       row.Cells[Referencia.Name].Value,
                                       row.Cells[Producto.Name].Value,
                                       row.Cells[codUnidadMedida.Name].Value,
                                       row.Cells[Unidad.Name].Value,
                                       row.Cells[Cantidad.Name].Value,

                                       prod.ValorProm, 
                                       prod.ValorPromsoles, 
                                       prod.PrecioProm,
                                       row.Cells[stockgeneral.Name].Value,
                                       //prod.StockActual,
                                       row.Cells[comentario_usu.Name].Value,
                                       row.Cells[codrequerimiento.Name].Value
                                    );
                                }

                                DataRow row_aux = DtAuxiliar_pasados.NewRow();
                                row_aux["coddetalle"] = Convert.ToInt32(row.Cells[coddetalle.Name].Value);
                                row_aux["codProducto"] = Convert.ToInt32(row.Cells[codProducto.Name].Value);
                                row_aux["Referencia"] = Convert.ToString(row.Cells[Referencia.Name].Value);
                                row_aux["Producto"] = Convert.ToString(row.Cells[Producto.Name].Value);
                                row_aux["codUnidadMedida"] = Convert.ToInt32(row.Cells[codUnidadMedida.Name].Value);
                                row_aux["Unidad"] = Convert.ToString(row.Cells[Unidad.Name].Value);
                                row_aux["Cantidad"] = Convert.ToDecimal(row.Cells[Cantidad.Name].Value);
                                row_aux["comentario_usu"] = Convert.ToString(row.Cells[comentario_usu.Name].Value);
                                row_aux["codrequerimiento"] = Convert.ToInt32(row.Cells[codrequerimiento.Name].Value);
                                DtAuxiliar_pasados.Rows.Add(row_aux);

                            }
                            else if (proce == 2)
                            {
                                form.dgvDetalle.CurrentRow.SetValues(row.Cells[coddetalle.Name].Value, row.Cells[codProducto.Name].Value,
                                row.Cells[Referencia.Name].Value, row.Cells[Producto.Name].Value,
                                row.Cells[codUnidadMedida.Name].Value,
                                row.Cells[Unidad.Name].Value, row.Cells[Cantidad.Name].Value, prod.ValorProm, prod.ValorPromsoles, prod.PrecioProm, prod.StockActual);
                            }
                        }
                        Int32 can = DtAuxiliar_pasados.Rows.Count;
                    }

                    //form.DtValida = DtAuxiliar;

                    form.DtAuxiliar_pr = DtAuxiliar;
                    form.DtAuxiliar_pasados_pr = DtAuxiliar_pasados;
                }
            }
            else 
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Debe validar todo el detalle del requerimiento","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool cuenta_cheks() 
        {
            int cantidad_elemento = dgvDetalle.Rows.Count;
            int veces = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (Convert.ToBoolean(row.Cells[escoje.Name].Value) == true)
                {
                    veces++;
                }
            }

            return (veces == cantidad_elemento) ? true : false;
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.Enabled = false;

            txtCantidad.Text = "";
            txtComentario.Text = "";

            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

            ch1 = (DataGridViewCheckBoxCell)dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value=false;
            
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }

            if (ch1.Value.ToString().Equals("True"))
            {
                //accion_envia(dgvDetalle.CurrentRow.Index);
                posicion_dgdetalle = dgvDetalle.CurrentRow.Index;
                groupBox4.Visible = true;
            }
            else 
            {
                posicion_dgdetalle = dgvDetalle.CurrentRow.Index;

                //dgvDetalle.Rows[posicion_dgdetalle].Cells["Cantidad"].Value = "";
                dgvDetalle.Rows[posicion_dgdetalle].Cells["comentario_usu"].Value = "";

                for (int i = 0; i<= DtAuxiliar.Rows.Count; i++)
                {
                    if (i == posicion_dgdetalle) 
                    {
                        dgvDetalle.Rows[posicion_dgdetalle].Cells["Cantidad"].Value = DtAuxiliar.Rows[i]["Cantidad"].ToString();
                    }
                    //mi_variable = DataTable.Rows[i]["NombreCampo"].ToString();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            accion_envia();
        }

        private void accion_envia() 
        {
            Int32 pos = posicion_dgdetalle;

            Decimal cantidad_ingresada = 0;
            Decimal cantidad_celda = 0;
            Decimal cantidad_almacen = 0;
            //String comentario_envio = "";

            cantidad_celda = Convert.ToDecimal(dgvDetalle.Rows[pos].Cells["Cantidad"].Value.ToString());

            cantidad_almacen = Convert.ToDecimal(dgvDetalle.Rows[pos].Cells["stockgeneral"].Value.ToString());

            if (txtCantidad.Text != "")
            {
                cantidad_ingresada = Convert.ToDecimal(txtCantidad.Text);

                if (cantidad_almacen >= cantidad_ingresada)
                {

                    if (cantidad_ingresada < cantidad_celda)
                    {
                        if (txtComentario.Text == "")
                        {
                            MessageBox.Show("Como la cantidad ingresada es menor a la solicitada, debe ingresar un comentario");
                        }
                        else
                        {
                            dgvDetalle.Rows[pos].Cells["Cantidad"].Value = cantidad_ingresada;
                            dgvDetalle.Rows[pos].Cells["comentario_usu"].Value = txtComentario.Text;

                            //if (AdmReq.actualiza_det_requerimientos_comentario(Convert.ToInt32(dgvDetalle.Rows[pos].Cells["coddetalle"].Value), txtComentario.Text))
                            //{
                            MessageBox.Show("Se cargaron los datos correctamente");
                            dgvDetalle.Enabled = true;
                            groupBox4.Visible = false;

                            btnGuardar.Visible = (cuenta_cheks() == true) ? true : false;
                            //}
                        }
                    }
                    else
                    {
                        dgvDetalle.Rows[pos].Cells["Cantidad"].Value = cantidad_ingresada;
                        dgvDetalle.Rows[pos].Cells["comentario_usu"].Value = txtComentario.Text;
                        MessageBox.Show("Se cargaron los datos correctamente");
                        dgvDetalle.Enabled = true;
                        groupBox4.Visible = false;

                        btnGuardar.Visible = (cuenta_cheks() == true) ? true : false;
                    }
                }
                else 
                {
                    MessageBox.Show("No tiene cantidad suficiente para cumplir con el requerimiento");
                }
            }
            else 
            {
                MessageBox.Show("Debe ingresar un cantidad");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SOLONumeros(sender, e);
        }
        
    }
}
