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
    public partial class frmGuiaRemision : DevComponents.DotNetBar.Office2007Form
    {
        clsGuia ds = new clsGuia();
        clsAdmTransaccion AdmTran = new clsAdmTransaccion();
        clsTransaccion tran = new clsTransaccion();
        clsAdmTipoDocumento Admdoc = new clsAdmTipoDocumento();
        clsTipoDocumento doc = new clsTipoDocumento();
        clsAdmSerie Admser = new clsAdmSerie();
        clsSerie ser = new clsSerie();
        clsAdmTipoCambio AdmTc = new clsAdmTipoCambio();
        clsTipoCambio tc = new clsTipoCambio();
        clsAdmEmpresaTransporte AdmET = new clsAdmEmpresaTransporte();
        clsEmpresaTransporte empT = new clsEmpresaTransporte();
        clsAdmConductor AdmCond = new clsAdmConductor();
        clsConductor cond = new clsConductor();
        clsAdmVehiculoTransporte AdmVeh = new clsAdmVehiculoTransporte();
        clsVehiculoTransporte veh = new clsVehiculoTransporte();
        clsAdmProveedor AdmProv = new clsAdmProveedor();
        clsProveedor prov = new clsProveedor();
        clsAdmCliente AdmCli = new clsAdmCliente();
        clsCliente cli = new clsCliente();
        clsAdmGuiaRemision AdmGuia = new clsAdmGuiaRemision();
        clsGuiaRemision guia = new clsGuiaRemision();
        clsPedido pedido = new clsPedido();
        clsAdmPedido Admped = new clsAdmPedido();
        clsValidar ok = new clsValidar();
        clsNotaSalida nota = new clsNotaSalida();
        clsAdmNotaSalida AdmNota = new clsAdmNotaSalida();
        clsFacturaVenta venta = new clsFacturaVenta();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        clsTransferencia clstran = new clsTransferencia();
        clsAdmTransferencia AdmTransf = new clsAdmTransferencia();

        DataTable datosCarga = new DataTable();
        DataTable datosCarga2 = new DataTable();
        DataTable datosAlmacena = new DataTable();
        
        clsConsultasExternas ext = new clsConsultasExternas();
        clsFacturaVenta facturav = new clsFacturaVenta();

        TextBox txtedit = new TextBox();

        public List<Int32> config = new List<Int32>();
        public List<clsDetalleGuiaRemision> detalle = new List<clsDetalleGuiaRemision>();
        public String CodGuia;
        public Int32 CodVehiculo;
        public Int32 CodConductor;        
        public Int32 CodEmpresaTransporte;
        public Int32 CodTransaccion;
        public Int32 numeroGuia;
        public Int32 CodProveedor;
        public Int32 CodCliente;
        public Int32 CodDocumento;
        public Int32 CodPedido;
        public Int32 CodTranferencia;
        public Int32 CodSerie;
        public Int32 Tipo;
        public Int32 CodNota, CodVenta;
        Boolean Validacion = true;
        public Int32 Proceso = 0; //(1) Nuevo (2) Editar (3) Consulta

        public String rpta = "", rpta2 = "";
        private String dat = "", dat2 = "";
        public List<Int32> lta = new List<Int32>();

        public frmGuiaRemision()
        {
            InitializeComponent();
        }        

        private void CargaCliente()
        {
            cli = AdmCli.MuestraCliente(CodCliente);
            if (cli != null)
            {
                txtCodCliente.Text = cli.RucDni;
                txtNombreCliente.Text = cli.RazonSocial;
                if (cli.DireccionEntrega.Trim() != "")
                {
                    txtDireccion.Text = cli.DireccionEntrega;
                }
                else 
                {
                    txtDireccion.Text = cli.DireccionLegal;
                }
            }
        }

        private Boolean BuscaCliente()
        {
            cli = AdmCli.BuscaCliente(txtCodCliente.Text, Tipo);
            if (cli != null)
            {
                txtNombreCliente.Text = cli.RazonSocial;
                CodCliente = cli.CodCliente;
                if (cli.DireccionEntrega != "")
                {
                    txtDireccion.Text = cli.DireccionEntrega;
                }
                else
                {
                    txtDireccion.Text = cli.DireccionLegal;
                }            
                return true;
            }
            else
            {
                txtNombreCliente.Text = "";
                CodCliente = 0;
                txtDireccion.Text = "";                
                return false;
            }
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmClientesLista"] != null)
                {
                    Application.OpenForms["frmClientesLista"].Activate();
                }
                else
                {
                    frmClientesLista form = new frmClientesLista();
                    form.Proceso = 3;
                    //form.Tipo = cmbTipoCodigo.SelectedIndex;
                    form.ShowDialog();
                    cli = form.cli;
                    CodCliente = cli.CodCliente;
                    if (CodCliente != 0) { CargaCliente(); ProcessTabKey(true); }
                }
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (CodCliente == 0)
            {
                txtCodCliente.Focus();
            }
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtCodCliente.Text != "")
                {
                    if (BuscaCliente())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no existe, Presione F1 para consultar la tabla de ayuda", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }
        

       

        private void txtDocRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (txtDocRef.Text != "")
            //    {
            //        if (BuscaTipoDocumento())
            //        {
            //            ProcessTabKey(true);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Codigo de Documento no existe, Presione F1 para consultar la tabla de ayuda", "NOTA DE SALIDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }

        //private Boolean BuscaTipoDocumento()
        //{
        //    doc = Admdoc.BuscaTipoDocumento(txtDocRef.Text);
        //    if (doc != null)
        //    {
        //        CodDocumento = doc.CodTipoDocumento;
        //        return true;
        //    }
        //    else
        //    {
        //        CodDocumento = 0;
        //        return false;
        //    }

        //}

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //{
            //    if (Application.OpenForms["frmDocumentos"] != null)
            //    {
            //        Application.OpenForms["frmDocumentos"].Activate();
            //    }
            //    else
            //    {
            //        frmDocumentos form = new frmDocumentos();
            //        form.Proceso = 3;
            //        form.ShowDialog();
            //        doc = form.doc;
            //        CodDocumento = doc.CodTipoDocumento;
            //        txtDocRef.Text = doc.Sigla;
            //        if (CodDocumento != 0) { ProcessTabKey(true); }                    
            //    }
            //}
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void VerificarCabecera()
        {
            Validacion = true;
            //if (CodDocumento == 0)
            //{
            //    Validacion = false;
            //}
            if (txtCodCliente.Visible && CodCliente == 0)
            {
                Validacion = false;
            }            
            if ((cond.CodConductor == 0 || veh.CodVehiculoTransporte == 0) && empT.CodEmpresaTranporte == 0)
            {
                Validacion = false;
            }
            if (cmbMotivo.SelectedIndex == -1)
            {
                Validacion = false;
            }
            //if (txtPedido.Visible && CodPedido == 0)
            //{
            //    Validacion = false;
            //}
        }

        private void frmNotaSalida_Load(object sender, EventArgs e)
        {
            CargaVehiculosTransporte();
            CargaConductores();
            EventArgs eee = new EventArgs();
            cmbConductor_SelectionChangeCommitted(cmbConductor, eee);
            cmbVehiculos_SelectionChangeCommitted(cmbVehiculos,eee);
            if (Proceso == 1) cmbMotivo.SelectedIndex = 0;
            activamenu(false);
            if (Proceso == 2)
            {
                CargaGuiaRemision();
                activamenu(true);
            }
            else if (Proceso == 3)
            {
                CargaGuiaRemision();
                sololectura(true);
                activamenu(false);
            }
            else if (Proceso == 4)
            {
                CargaGuiaRemision();
                sololectura(true);
                activamenu(false);
            }
        }

        private void activamenu(Boolean valor)
        {
            btnNuevo.Visible = valor;
            btnEditar.Visible = valor;
            btnEliminar.Visible = valor;
        }

        private void CargaVehiculosTransporte()
        {
            cmbVehiculos.DataSource = AdmVeh.CargaVehiculoTransportes();
            cmbVehiculos.DisplayMember = "placa";
            cmbVehiculos.ValueMember = "codVehiculoTransporte";
            //cmbVehiculos.SelectedIndex = -1;
        }

        private void CargaConductores()
        {
            cmbConductor.DataSource = AdmCond.CargaConductores();
            cmbConductor.DisplayMember = "nombre";
            cmbConductor.ValueMember = "codConductor";
            //cmbConductor.SelectedIndex = -1;
        }

        private Int32 i = 0;

        private void CargaGuiaRemision()
        {
            try
            {
                guia = AdmGuia.CargaGuiaRemision(Convert.ToInt32(CodGuia));
                ser = Admser.MuestraSerie(guia.CodSerie,frmLogin.iCodAlmacen);
                if (guia != null)
                {
                    txtNumDoc.Text = guia.CodGuiaRemision;               
                    
                    if (txtCodCliente.Enabled)
                    {
                        if (guia.CodCliente != 0)
                        {
                            CodCliente = guia.CodCliente;
                            if(guia.RUCCliente != "") txtCodCliente.Text = guia.RUCCliente;
                            else txtCodCliente.Text = guia.DNI;
                            txtNombreCliente.Text = guia.RazonSocialCliente;
                            txtDireccion.Text = guia.Direccion;
                        }
                        else
                        {
                            CodCliente = guia.CodAlmacenDestino;
                            txtCodCliente.Text = guia.RUCCliente;
                            txtNombreCliente.Text = guia.NomAlmacenDestino;
                            txtDireccion.Text = guia.UbicacionAlmacenDest;
                        }                     
                    }
                    dtpFecha.Value = guia.FechaEmision;
                    dtpFechaTransporte.Value = guia.FechaTraslado;
                    cmbMotivo.SelectedIndex = guia.CodMotivo;

                    if (guia.CodPedido != 0)
                    {
                        pedido = Admped.CargaPedido(Convert.ToInt32(guia.CodPedido));
                        txtPedido.Text = pedido.CodPedido; 
                    }
                    
                    if (guia.CodVehiculoTransporte != 0)
                    {
                        cmbVehiculos.SelectedValue = guia.CodVehiculoTransporte;
                        txtMarcaVehiculo.Text = guia.Marca;
                        txtConstancia.Text = guia.ConstanciaInscripcion;
                    }
                    if (guia.CodConductor != 0)
                    {
                        cmbConductor.SelectedValue = guia.CodConductor;
                        txtLicencia.Text = guia.Licencia;
                    }
                    if (guia.CodEmpresaTransporte != 0)
                    {
                        txtRUCTransporte.Text = guia.RUCEmpresaTransporte;
                        txtRazonSocialTransporte.Text = guia.RazonSocialTransporte;
                        txtDireccionTransporte.Text = guia.DireccionTransporte;
                    }
                    txtSerie.Text = guia.Serie;
                    txtNumero.Text = guia.NumDoc;

                    //if (txtDocRef.Enabled)
                    //{
                    //    CodDocumento = guia.CodTipoDocumento;
                    //    txtDocRef.Text = guia.SiglaDocumento;
                    //    txtNumero.Text = guia.NumDoc;
                    //}
                    if (txtPedido.Enabled)
                    {
                        //se carga el codigo de la orden de compra
                        //txtOrdenCompra.Text = 
                    }
                    txtComentario.Text = guia.Comentario;
                    datosAlmacena = AdmGuia.CargaFacturasGuia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen);
                    if (datosAlmacena != null && datosAlmacena.Rows.Count > 0)
                    {
                        while (i < datosAlmacena.Rows.Count)
                        {
                            Int32 codigo = Convert.ToInt32(datosAlmacena.Rows[i]["codFactura"]);
                            Int32 almacen = Convert.ToInt32(datosAlmacena.Rows[i]["codAlmacen"]);

                            if (codigo != 0)
                            {

                                facturav = AdmVenta.BuscaFacturaVenta(codigo, almacen);

                                dat = facturav.SiglaDocumento + " " + facturav.Serie + "-" + facturav.NumDoc;
                                dat2 = txtFactura.Text;
                                if (txtFactura.Text == "") txtFactura.Text = dat;
                                else if (txtFactura.Text.Equals(dat)) txtFactura.Text = dat;
                                else txtFactura.Text = dat2 + ',' + dat;
                            }
                            else
                            {
                                Int32 codigoT = Convert.ToInt32(datosAlmacena.Rows[i]["codTransferencia"]); ;
                                clstran = AdmTransf.BuscaTransferencia(Convert.ToString(codigoT), almacen);

                                dat = clstran.SiglaDocumento + " " + clstran.Serie + "-" + clstran.CodTransDir;
                                dat2 = txtTranferencia.Text;
                                if (txtFactura.Text == "") txtTranferencia.Text = dat;
                                else if (txtFactura.Text.Equals(dat)) txtTranferencia.Text = dat;
                                else txtFactura.Text = dat2 + ',' + dat;
                            }

                            i++;
                        }
                    }
                    else
                    {
                        dat = guia.SiglaDocumento + " " + guia.Serie + "-" + guia.NumDoc;
                        dat2 = txtFactura.Text;
                        if (txtFactura.Text == "") txtFactura.Text = dat;
                    }
                    CargaDetalle();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Nota de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void sololectura(Boolean estado)
        {
            txtNumero.Enabled = estado;
            txtSerie.Enabled = estado;
            dtpFecha.Enabled = !estado;
            dtpFechaTransporte.Enabled = !estado;
            txtCodCliente.ReadOnly = estado;
            cmbMotivo.Enabled = !estado;           
            txtPedido.ReadOnly = estado;
            txtFactura.ReadOnly = estado;
            txtComentario.ReadOnly = estado;
            ext.sololectura(groupBox4.Controls);
            ext.sololectura(groupBox5.Controls);
            btnGuardar.Visible = !estado;
            btnImprimir.Visible = estado;
            btnNuevaGuia.Visible = estado;
        }

        private void CargaDetalle()
        {
            dgvDetalle.DataSource =  AdmGuia.CargaDetalle(Convert.ToInt32(guia.CodGuiaRemision));
        }

        private void frmNotaSalida_Shown(object sender, EventArgs e)
        {
            if (Proceso == 2)
            {
                CargaGuiaRemision();
                activamenu(true);
            }
            else if (Proceso == 3)
            {
                //CargaGuiaRemision();
                //sololectura(true);
                //activamenu(false);
            }
            else if (Proceso == 4)
            {
                CargaGuiaRemision();
                sololectura(true);
                activamenu(false);
            }
        }

        private void txtDocRef_Leave(object sender, EventArgs e)
        {
            //BuscaTipoDocumento();
            //if (CodDocumento == 0)
            //{
            //    txtDocRef.Focus();
            //}
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmSerie"] != null)
                {
                    Application.OpenForms["frmSerie"].Activate();
                }
                else
                {
                    frmSerie form = new frmSerie();
                    form.Proceso = 3;
                    form.DocSeleccionado = 11;
                    form.ShowDialog();
                    ser = form.ser;
                    CodSerie = ser.CodSerie;
                    if (CodSerie != 0) { ProcessTabKey(true); }

                }
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (BuscaSerie())
                {
                    txtSerie.Text = ser.Serie.ToString();
                    if (ser.PreImpreso)
                    {
                        txtNumero.Text = "";
                        txtNumero.Visible = true;
                        txtNumero.Focus();
                    }
                    else
                    {
                        txtNumero.Text = "";
                        txtNumero.Visible = false;
                        txtNumero.Text = ser.Numeracion.ToString();
                    }

                    ProcessTabKey(true);
                }
                else
                {
                    MessageBox.Show("Serie no existe, Presione F1 para consultar la tabla de ayuda",
                                "Facturación Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (BuscaSerie())
            {
                txtSerie.Text = ser.Serie.ToString();
                if (ser.PreImpreso)
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = true;
                    txtNumero.Focus();
                }
                else
                {
                    txtNumero.Text = "";
                    txtNumero.Visible = false;
                    txtNumero.Text = ser.Numeracion.ToString();
                }
            }
        }

        private Boolean BuscaSerie()
        {
            ser = Admser.MuestraSerie(CodSerie, frmLogin.iCodAlmacen);

            if (ser != null)
            {
                CodSerie = ser.CodSerie;
                return true;
            }
            else
            {
                CodSerie = 0;
                return false;
            }

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessTabKey(true);
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
            {
                txtNumero.Focus();
            }
            else
            {
                VerificarCabecera();
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDetalleGuia"] != null)
            {
                Application.OpenForms["frmDetalleGuia"].Activate();
            }
            else
            {
                frmDetalleGuia form = new frmDetalleGuia();
                form.Procede = 5;
                form.Proceso = 1;
                form.ShowDialog();
            }
        }

        private void dgvDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            //if (txtPrecioVenta.Text != "")
            //{
            //    btnGuardar.Enabled = true;
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Proceso != 0)
                {
                    guia.CodAlmacen = frmLogin.iCodAlmacen;
                    guia.CodTipoDocumento = 11;//codigo de documento Guia de Remision
                    //guia.CodSerie = 10;//codigo de serie 001 de la guia de remision
                    guia.CodSerie = CodSerie;
                    guia.Serie = txtSerie.Text;
                    guia.NumDoc = txtNumero.Text;
                    guia.CodMotivo = cmbMotivo.SelectedIndex;
                    if (CodPedido != 0) { guia.CodPedido = CodPedido; }
                    guia.FechaEmision = dtpFecha.Value;
                    guia.FechaTraslado = dtpFechaTransporte.Value;
                    guia.CodCliente = cli.CodCliente;
                    if (CodEmpresaTransporte != 0) { guia.CodEmpresaTransporte = empT.CodEmpresaTranporte; }
                    //if (CodVehiculo != 0) { guia.CodVehiculoTransporte = veh.CodVehiculoTransporte; }
                    //if (CodConductor != 0) { guia.CodConductor = cond.CodConductor; }
                    if (CodVehiculo != 0) { guia.CodVehiculoTransporte = Convert.ToInt32(cmbVehiculos.SelectedValue); }
                    if (CodConductor != 0) { guia.CodConductor = Convert.ToInt32(cmbConductor.SelectedValue); }
                    if (txtFactura.Text != "") { guia.Facturado = 1; }
                    guia.CodFactura = CodVenta;
                    guia.Comentario = txtComentario.Text;
                    guia.CodUser = frmLogin.iCodUser;
                    guia.Estado = 1;// Para saber si la nota esta activa o anulada. El estado se podra cambiar en una ventana especifica para anular notas
                    if (txtTranferencia.Text == "" || txtTranferencia.Text == " ") { txtTranferencia.Text = "0"; } 
                    guia.CodTransferencia =Convert.ToInt32(txtTranferencia.Text);
                    if (Proceso == 1)
                    {

                        if (dgvDetalle.Rows.Count < 0)
                        {
                            MessageBox.Show("Debe Ingresar algun tipo de docuemento para realizar la guia",
                                "Guia de Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (AdmGuia.insert(guia))
                            {
                                RecorreDetalle();
                                if (detalle.Count > 0)
                                {
                                    foreach (clsDetalleGuiaRemision det in detalle)
                                    {
                                        AdmGuia.insertdetalle(det);
                                        AdmNota.ActualizaCantidadPendienteVenta(det.Cantidad, det.CodProducto, det.CodVenta);
                                        AdmGuia.insertrelacionguia(Convert.ToInt32(guia.CodGuiaRemision), det.CodVenta, frmLogin.iCodAlmacen, frmLogin.iCodUser, guia.CodTransferencia);
                                    }
                                }
                                MessageBox.Show("Los datos se guardaron correctamente", "Guia Remision",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //this.Close();
                                CodGuia = guia.CodGuiaRemision;
                                //fnImprimir();
                                btnImprimir.Visible = true;
                                CargaGuiaRemision();
                                sololectura(true);
                            }
                        }
                    }
                    else if (Proceso == 2)
                    {
                        if (AdmGuia.update(guia))
                        {
                            RecorreDetalle();
                            foreach (clsDetalleGuiaRemision det in guia.Detalle)
                            {
                                foreach (clsDetalleGuiaRemision det1 in detalle)
                                {
                                    if (det.Equals(det1))
                                    {
                                        AdmGuia.updatedetalle(det1);
                                        return;
                                    }
                                }
                                AdmGuia.deletedetalle(det.CodGuiaRemision);
                            }
                            foreach (clsDetalleGuiaRemision deta in detalle)
                            {
                                if (deta.CodGuiaRemision == 0)
                                {
                                    AdmGuia.insertdetalle(deta);
                                }
                            }

                            MessageBox.Show("Los datos se actualizaron correctamente", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void RecorreDetalle()
        {
            detalle.Clear();
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    añadedetalle(row);
                }
            }
            //nota.Detalle = detalle;
        }
        private void añadedetalle(DataGridViewRow fila)
        {
            clsDetalleGuiaRemision deta = new clsDetalleGuiaRemision();
            deta.CodProducto = Convert.ToInt32(fila.Cells[codproducto.Name].Value);
            deta.CodGuiaRemision = Convert.ToInt32(guia.CodGuiaRemision);
            deta.CodAlmacen = frmLogin.iCodAlmacen;
            deta.UnidadIngresada = Convert.ToInt32(fila.Cells[codunidad.Name].Value);
            deta.SerieLote = fila.Cells[serielote.Name].Value.ToString();
            deta.Cantidad = Convert.ToDouble(fila.Cells[cantidad.Name].Value);
            if (Convert.ToBoolean(guia.Facturado)) { deta.CantidadPendiente = 0; deta.Pendiente = false; } else { deta.CantidadPendiente = deta.Cantidad; deta.Pendiente = true; }
            deta.CodUser = frmLogin.iCodUser;
            deta.CodVenta = Convert.ToInt32(fila.Cells[codigoventa.Name].Value);
            detalle.Add(deta);
        }

        private void cmbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //pag = AdmPago.CargaFormaPago(Convert.ToInt32(cmbFormaPago.SelectedValue));
            //dtpFechaPago.Value = dtpFecha.Value.AddDays(pag.Dias);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0 & dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmDetalleGuia"] != null)
                {
                    Application.OpenForms["frmDetalleGuia"].Activate();
                }
                else
                {
                    frmDetalleGuia form = new frmDetalleGuia();
                    form.Procede = 5;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtComentario_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
        }

        private void cmbVehiculos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            veh = AdmVeh.MuestraVehiculoTransporte(Convert.ToInt32(cmbVehiculos.SelectedValue));
            if (veh != null)
            {
                CodVehiculo = veh.CodVehiculoTransporte;
                txtMarcaVehiculo.Text = veh.Marca;
                txtConstancia.Text = veh.ConstanciaInscripcion;
            }
            else
            {
                CodVehiculo = 0;
                txtMarcaVehiculo.Text = "";
                txtConstancia.Text = "";
            }
        }

        private void cmbConductor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cond = AdmCond.MuestraConductor(Convert.ToInt32(cmbConductor.SelectedValue));
            if (cond != null)
            {
                CodConductor = cond.CodConductor;
                txtLicencia.Text = cond.Licencia;
            }
            else
            {
                CodConductor = 0;
                txtLicencia.Text = "";
            }
        }

        private void txtRUCTransporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Application.OpenForms["frmEmpresaTransporte"] != null)
                {
                    Application.OpenForms["frmEmpresaTransporte"].Activate();
                }
                else
                {
                    frmEmpresaTransporte form = new frmEmpresaTransporte();
                    form.Proceso = 3;
                    form.ShowDialog();
                    empT = form.emp;
                    CodEmpresaTransporte = empT.CodEmpresaTranporte;
                    if (CodEmpresaTransporte != 0) { CargaEmpresaTransporte(); ProcessTabKey(true); }
                }
            }
        }

        private void CargaEmpresaTransporte()
        {
            empT = AdmET.MuestraEmpresaTranporte(empT.CodEmpresaTranporte);
            if (empT != null)
            {
                txtRUCTransporte.Text = empT.Ruc;
                txtRazonSocialTransporte.Text = empT.RazonSocial;
                txtDireccionTransporte.Text = empT.Direccion;
            }
            else 
            {
                txtRUCTransporte.Text = "";
                txtRazonSocialTransporte.Text = "";
                txtDireccionTransporte.Text = "";
            }
        }

        private void txtRUCTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtRUCTransporte.Text != "")
                {
                    if (BuscaEmpresaTransporte())
                    {
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("La empresa no existe, Presione F1 para consultar la tabla de ayuda", "Guia Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaEmpresaTransporte()
        {
            empT = AdmET.BuscaEmpresaTransporte(txtRUCTransporte.Text);

            if (empT != null)
            {
                txtRazonSocialTransporte.Text = empT.RazonSocial;
                txtDireccionTransporte.Text = empT.Direccion;
                CodEmpresaTransporte = empT.CodEmpresaTranporte;
                return true;
            }
            else
            {
                txtRazonSocialTransporte.Text = "";
                txtDireccionTransporte.Text = "";
                CodEmpresaTransporte = 0;
                return false;
            }
        }

        private void cmbVehiculos_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void cmbConductor_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void txtRUCTransporte_Leave(object sender, EventArgs e)
        {
            VerificarCabecera();
            if (Validacion && Proceso == 1)
            {
                btnDetalle.Enabled = true;
            }
        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtPedido.Text != "")
                {
                    if (BuscaPedido())
                    {
                        CargaPedido();
                        ProcessTabKey(true);
                    }
                    else
                    {
                        MessageBox.Show("Pedido no existe, Presione F1 para consultar la tabla de ayuda", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaPedido()
        {
            pedido = Admped.BuscaPedido(txtPedido.Text, frmLogin.iCodAlmacen);
            if (pedido != null)
            {
                CodPedido = Convert.ToInt32(pedido.CodPedido);
                return true;
            }
            else
            {
                CodPedido = 0;
                return false;
            }

        }

        private void CargaPedido()
        {
            try
            {
                pedido = Admped.CargaPedido(Convert.ToInt32(CodPedido));
                if (pedido != null)
                {
                    txtPedido.Text = pedido.CodPedido;

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = pedido.CodCliente;
                        cli = AdmCli.MuestraCliente(CodCliente);
                        txtCodCliente.Text = pedido.CodigoPersonalizado;
                        txtNombreCliente.Text = pedido.Nombre;
                        txtDireccion.Text = pedido.Direccion;

                    }                     
                    
                    txtComentario.Text = pedido.Comentario;                    
                    CargaDetallePedido();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CargaDetallePedido()
        {
            dgvDetalle.DataSource = Admped.CargaDetalleGuia(Convert.ToInt32(pedido.CodPedido));
        }

        private void CargaDetalleNota()
        {
            datosCarga = AdmVenta.MuestraDetalleVentaGuia(Convert.ToInt32(venta.CodFacturaVenta), venta.CodAlmacen);
            if (datosCarga != null)
            {
                datosCarga2.Merge(datosCarga);
            }

            dgvDetalle.DataSource = datosCarga2;
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (txtFactura.Text != "")
            //    {
            //        if (BuscaNotaSalida())
            //        {
            //            CargaNotaSalida();
            //            ProcessTabKey(true);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Documento no existe, Presione F1 para consultar la tabla de ayuda", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }

        private Boolean BuscaNotaSalida()
        {
            pedido = Admped.BuscaPedido(txtPedido.Text, frmLogin.iCodAlmacen);
            if (pedido != null)
            {
                CodPedido = Convert.ToInt32(pedido.CodPedido);
                return true;
            }
            else
            {
                CodPedido = 0;
                return false;
            }
        }

        private void CargaNotaSalida()
        {
            try
            {
                venta = AdmVenta.CargaFacturaVenta(Convert.ToInt32(CodVenta));
                ser = Admser.MuestraSerie(venta.CodSerie, venta.CodAlmacen);
                if (venta != null)
                {
                    rpta = venta.SiglaDocumento + " " + ser.Serie + "-" + venta.NumDoc;
                    rpta2 = txtFactura.Text;
                    if (txtFactura.Text == "") txtFactura.Text = rpta;
                    else txtFactura.Text = rpta2 + ',' + rpta;

                    if (txtCodCliente.Enabled)
                    {
                        CodCliente = venta.CodCliente;
                        cli = AdmCli.MuestraCliente(CodCliente);
                        txtCodCliente.Text = cli.RucDni;
                        txtNombreCliente.Text = cli.Nombre;
                        if (cli.DireccionEntrega != null && cli.DireccionEntrega.Trim() != "")
                        {
                            txtDireccion.Text = cli.DireccionEntrega;
                        }
                        else 
                        {
                            txtDireccion.Text = cli.DireccionLegal;
                        }

                    }

                    txtComentario.Text = venta.Comentario;
                    CargaDetalleNota();
                }
                else
                {
                    MessageBox.Show("El documento solicitado no existe", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void fnImprimir()
        {
            //try
            //{
                ser = Admser.MuestraSerie(guia.CodSerie, frmLogin.iCodAlmacen);
                if (txtCodCliente.Text == "")
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rd.Load("CRGuiaRemision.rpt");
                    CRGuiaRemision rpt = new CRGuiaRemision();
                    rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                    CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                    rptoption.PrinterName = ser.NombreImpresora;
                    rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                    //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                    //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                    rd.PrintToPrinter(1, false, 1, 1);
                    rd.Close();
                    rd.Dispose();

                }
                else
                {
                    //MessageBox.Show("SI");
                    if (frmLogin.iCodAlmacen == 20 || frmLogin.iCodAlmacen == 21)
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemionVentaNewFormat.rpt");
                        CRGuiaRemionVentaNewFormat rpt = new CRGuiaRemionVentaNewFormat();
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                    else 
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemisionVenta.rpt");
                        CRGuiaRemisionVenta rpt = new CRGuiaRemisionVenta();
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ser = Admser.MuestraSerie(guia.CodSerie, frmLogin.iCodAlmacen);
                if (CodTransaccion==5)
                {
                    if (frmLogin.iCodAlmacen == 20 || frmLogin.iCodAlmacen == 21)
                    {
                        CodTransaccion = 15;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemisionNewFormat.rpt");
                        CRGuiaRemisionNewFormat rpt = new CRGuiaRemisionNewFormat();
                        //rd.SetDataSource(ds.GuiaRemisionTranferencia(numeroGuia, frmLogin.iCodAlmacen, CodTransaccion));
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                    else
                    {
                        CodTransaccion = 15;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemision.rpt");
                        CRGuiaRemision rpt = new CRGuiaRemision();
                        //rd.SetDataSource(ds.GuiaRemisionTranferencia(numeroGuia, frmLogin.iCodAlmacen, CodTransaccion));
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                }
                else
                {
                   // MessageBox.Show("Otro");
                    if (frmLogin.iCodAlmacen == 20 || frmLogin.iCodAlmacen == 21)
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemionVentaNewFormat.rpt");
                        CRGuiaRemionVentaNewFormat rpt = new CRGuiaRemionVentaNewFormat();
                        if (Proceso == 3 && CodTransaccion == 4)
                        {
                            CodTransaccion = 12;
                        }
                        //rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(txtNumDoc.Text), frmLogin.iCodAlmacen, CodTransaccion));
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rd.Load("CRGuiaRemisionVenta.rpt");
                        CRGuiaRemisionVenta rpt = new CRGuiaRemisionVenta();
                        if (Proceso == 3 && CodTransaccion == 4)
                        {
                            CodTransaccion = 12;
                        }
                        //rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(txtNumDoc.Text), frmLogin.iCodAlmacen, CodTransaccion));
                        rd.SetDataSource(ds.GuiaRemisionTranferencia(Convert.ToInt32(guia.CodGuiaRemision), frmLogin.iCodAlmacen, CodTransaccion));
                        CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                        rptoption.PrinterName = ser.NombreImpresora;
                        rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                        //rptoption.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(512, 850, 30, 500));
                        //CrystalDecisions.Shared.PageMargins margenes = rd.PrintOptions.PageMargins;
                        rd.PrintToPrinter(1, false, 1, 1);
                        rd.Close();
                        rd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFactura_Leave(object sender, EventArgs e)
        {
            if (txtFactura.Text != "") btnDetalle.Visible = false;
            else btnDetalle.Visible = true;
        }

        private void txtFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodCliente.Text != "")
            {
                if (e.KeyCode == Keys.F1)
                {
                    txtFactura.Text = "";
                    if (Application.OpenForms["frmListaDocumentosSinGuia"] != null)
                    {
                        Application.OpenForms["frmListaDocumentosSinGuia"].Activate();
                    }
                    else
                    {
                        frmListaDocumentosSinGuia form = new frmListaDocumentosSinGuia();
                        form.CodCliente = CodCliente;
                        if (txtNumero.Visible) form.Tipo = 2;
                        else form.Tipo = 1;
                        form.ShowDialog();
                        lta = form.ltaCod;
                        datosCarga2.Clear();
                        foreach (Int32 c in lta)
                        {
                            if (c != 0)
                            {
                                CodVenta = c;
                            }
                            if (CodVenta != 0)
                            {
                                CargaNotaSalida();
                                ProcessTabKey(true);
                                btnEliminar.Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un Cliente", "Guia Remision", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnNuevaGuia_Click(object sender, EventArgs e)
        {
            frmGuiaRemision form2 = new frmGuiaRemision();
            form2.MdiParent = this.MdiParent;
            form2.Proceso = 1;
            form2.Show();
            this.Close();
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtNumero.Visible = false;
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((Convert.ToDecimal(txtedit.Text) >
                        Convert.ToDecimal(dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value)|| Convert.ToDecimal(txtedit.Text) ==0  )&& dgvDetalle.Columns[dgvDetalle.CurrentCell.ColumnIndex].Name == "cantidad")
            {
                MessageBox.Show("Cantidad Debe Ser Menor o Igual que: " + dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value);
                dgvDetalle.CurrentRow.Cells[cantidad.Name].Value = dgvDetalle.CurrentRow.Cells[cantidadnueva.Name].Value;
            }
        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtedit = e.Control as TextBox;
            if (txtedit != null)
            {
                txtedit.KeyPress -= new KeyPressEventHandler(dgvDetalle_KeyPress);
                txtedit.KeyPress += new KeyPressEventHandler(dgvDetalle_KeyPress);
                txtedit.KeyUp -= new KeyEventHandler(dgvDetalle_KeyUp);
                txtedit.KeyUp += new KeyEventHandler(dgvDetalle_KeyUp);
                txtedit.Leave -= new EventHandler(dgvDetalle_Leave);
                txtedit.Leave += new EventHandler(dgvDetalle_Leave);
            }
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == cantidad.Index)//Cantidad
            {
                ok.SOLONumeros(sender, e);
            }
        }

        private void dgvDetalle_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvDetalle_Leave(object sender, EventArgs e)
        {

        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (c.SelectedIndex != -1)
                        e.IsValid = true;
                    else
                        e.IsValid = false;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (txtRUCTransporte.Text == "")
                        if (c.SelectedIndex != -1)
                            e.IsValid = true;
                        else
                            e.IsValid = false;
                    else
                        e.IsValid = true;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            ComboBox c = (ComboBox)e.ControlToValidate;
            if (c.Enabled)
                if (Proceso != 0)
                    if (txtRUCTransporte.Text == "")
                        if (c.SelectedIndex != -1)
                            e.IsValid = true;
                        else
                            e.IsValid = false;
                    else
                        e.IsValid = true;
                else
                    e.IsValid = true;
            else
                e.IsValid = true;
        }

        private void customValidator5_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (Proceso != 0)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void txtTranferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtTranferencia.Text != "")
                {
                    if (BuscaTranferencia())
                    {
                        CargaTransferencia();
                    }
                    else
                    {
                        MessageBox.Show("Transferencia no existe, Presione F1 para consultar la tabla de ayuda", "Guia Remision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CargaTransferencia()
        {
            try
            {
                clstran = AdmTransf.CargaTransferencia(Convert.ToInt32(txtTranferencia.Text));
                if(clstran != null)
                {
                    txtTranferencia.Text = clstran.CodTransDir;
                    txtComentario.Text = clstran.Comentario;
                    CargaDetalleTranferencia();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CargaDetalleTranferencia()
        {
            dgvDetalle.DataSource = AdmTransf.CargaDetalleGuiaT(clstran.CodTransDir);
        }

        private Boolean BuscaTranferencia()
        {
            clstran = AdmTransf.CargaTransferencia(Convert.ToInt32(txtTranferencia.Text));
            if (clstran != null)
            {
                CodTranferencia = Convert.ToInt32(clstran.CodTransDir);
                return true;
            }
            else
            {
                CodTranferencia = 0;
                return false;
            }
        }

      
       
    }
}
