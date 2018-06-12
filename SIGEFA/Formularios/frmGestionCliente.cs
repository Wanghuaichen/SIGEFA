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
using Tesseract;
using System.Text.RegularExpressions;
using AForge.Imaging.Filters;
using AForge;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;
using ZXing;
using System.IO;
using DevComponents.DotNetBar;

namespace SIGEFA.Formularios
{
    public partial class frmGestionCliente : DevComponents.DotNetBar.Office2007Form
    {
        public Int32 Proceso = 0; //(1) Nuevo Cliente (2)Editar Cliente (3) Nota Salida
        clsAdmCliente admCli = new clsAdmCliente();
        public clsCliente cli = new clsCliente();
        private Boolean Validacion = true;
        clsConsultasExternas ext = new clsConsultasExternas();
        clsLocalidad local = new clsLocalidad();
        clsAdmFormaPago AdmPago = new clsAdmFormaPago();
        clsAdmListaPrecio admLista = new clsAdmListaPrecio();
        clsAdmZona AdmZona = new clsAdmZona();
        clsZona zona = new clsZona();
        clsAdmVendedor AdmVen = new clsAdmVendedor();
        clsValidar ok = new clsValidar();
        String CodPer = null;
        clsMoneda moneda = new clsMoneda();
        clsAdmMoneda AdmMon = new clsAdmMoneda();

        Sunat MyInfoSunat;
        Reniec MyInfoReniec;
        IntRange red = new IntRange(0, 255);
        IntRange green = new IntRange(0, 255);
        IntRange blue = new IntRange(0, 255);

        public Int32 CodCli;
        public frmGestionCliente()
        {
            InitializeComponent();
            
        }     
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    if (cbFormaPago.SelectedIndex != 0 && Convert.ToDouble(txtLineaCredito.Text) == 0.0000)
                    {
                        MessageBox.Show("Debe Ingresar linea de Credito", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLineaCredito.Focus();

                    }
                    else
                    {
                        clsCliente cli = new clsCliente();
                        cli.CodigoPersonalizado = txtCodigoPersonalizado.Text;
                        //if (txtDni.Text != "") { cli.Dni = txtDni.Text; } else { cli.Dni = null; }
                        if (txtRUC.Text.Length == 8) { cli.Dni = txtRUC.Text; cli.Ruc = null; } else if (txtRUC.Text.Length == 11) { cli.Ruc = txtRUC.Text; cli.Dni = null; } 
                        cli.RazonSocial = txtRazonSocial.Text;
                        cli.Nombre = txtRazonSocial.Text;
                        cli.DireccionLegal = txtDireccionLegal.Text;
                        cli.DireccionEntrega = txtDireccionEntrega.Text;
                        cli.Telefono = txtTelefono.Text;
                        cli.Email = txtEmail.Text;
                        cli.Web = txtWeb.Text;
                        //cli.Pais = cbPais.SelectedText;
                        if (cbDepartamento.SelectedIndex != -1) { cli.Departamento = cbDepartamento.SelectedValue.ToString(); }
                        if (cbProvincia.SelectedIndex != -1) { cli.Provincia = cbProvincia.SelectedValue.ToString(); }
                        if (cbDistrito.SelectedIndex != -1) { cli.Distrito = cbDistrito.SelectedValue.ToString(); }
                        if (cbZona.SelectedIndex != -1) { cli.Zona = Convert.ToInt32(cbZona.SelectedValue); }
                        cli.Estado = cbActivo.Checked;
                        if (txtDscto.Text != "") { cli.Descuento = Convert.ToDecimal(txtDscto.Text); }
                        if (cbListaPrecios.SelectedIndex != -1) { cli.CodListaPrecio = Convert.ToInt32(cbListaPrecios.SelectedValue); }
                        if (cmbVendedores.SelectedIndex != -1) { cli.CodVendedor = Convert.ToInt32(cmbVendedores.SelectedValue); }
                        if (cbFormaPago.SelectedIndex != -1) { cli.FormaPago = Convert.ToInt32(cbFormaPago.SelectedValue); }
                        if (cbMoneda.SelectedIndex != -1) { cli.Moneda = Convert.ToInt32(cbMoneda.SelectedValue); }
                        if (txtLineaCredito.Text != "") { cli.LineaCredito = Convert.ToDecimal(txtLineaCredito.Text); }
                        cli.Banco = txtBanco.Text;
                        cli.CtaCte = txtCtaCte.Text;
                        cli.Contacto = txtContacto.Text;
                        cli.TelefonoContacto = txtTelefonoContacto.Text;
                        if (cbCalificacion.SelectedIndex != -1) { cli.Calificacion = Convert.ToInt32(cbCalificacion.SelectedValue); }
                        cli.Comentario = txtComentario.Text;
                        cli.CodUser = frmLogin.iCodUser;
                        cli.ClienteFacturasVencidas = chbCliFacturasVencidas.Checked;
                        if (txttasa.Text != "") cli.Tasa = Convert.ToInt32(txttasa.Text); else cli.Tasa = 0;
                        cli.CliEspecial = chkCliEspecial.Checked;
                        cli.CodCliente = CodCli;
                        if (Proceso == 1 || Proceso == 3 || Proceso == 4)
                        {
                            if (admCli.insert(cli))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Proceso == 1) { muestralista(); }
                                this.Close();
                            }
                        }
                        else if (Proceso == 2)
                        {
                            cli.CodCliente = Convert.ToInt32(txtCodigo.Text);
                            
                            if (admCli.update(cli))
                            {
                                MessageBox.Show("Los datos se guardaron correctamente", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                muestralista();
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos requeridos(*)", "Gestion Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarDatos(Control.ControlCollection Coleccion)
        {
            Validacion = true;
            foreach (Control c in Coleccion)
            {
                if (Convert.ToInt32(c.Tag) == 1)
                {
                    if (c.Enabled == true && c.Text == "")
                    {
                        c.BackColor = Color.LightPink;
                        c.Focus();
                        Validacion = false;
                    }
                }
                if (c.HasChildren)
                {
                    ValidarDatos(c.Controls);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGestionCliente_Load(object sender, EventArgs e)
        {
            CargaMoneda();
            CargaFormaPagos();
            CargaListaPrecios();
            CargaZonas();
            CargaVendedores();
            CargaLocalidades(cbDepartamento, "000000", 1);
            if (Proceso == 1 || Proceso == 4)
            {
                CodPer = admCli.CodigoPersonalizado(); //ultimo codigo personalizado para generar NUEVO
                generaCodPer(CodPer);
                cbActivo.Visible = false;
                if (Proceso == 4)
                {
                    tabControl1.Controls.Remove(tabPage2);
                    //tabPage2.Hide();
                }
            }
            else if (Proceso == 2)
            {
                CargaCliente(cli.CodCliente);
            }
            else if (Proceso == 3)
            {
                CargaCliente(cli.CodCliente);
                ext.sololectura(tabControl1.Controls);
                btnAceptar.Visible = false;
                btnCancelar.Text = "Aceptar";
                btnCancelar.ImageIndex = 1;
            }
            CodCli = cli.CodCliente;
        }

        private void CargaMoneda()
        {
            cbMoneda.DataSource = AdmMon.CargaMonedasHabiles();
            cbMoneda.DisplayMember = "descripcion";
            cbMoneda.ValueMember = "codMoneda";
            cbMoneda.SelectedIndex = 0;
        }

        private void generaCodPer(string codper)
        {
            bool isValid = char.IsLetter(codper.FirstOrDefault());
            if (isValid)
            {
                codper = codper.Remove(0, 1);
            }

            int newcod = Convert.ToInt32(codper) + 1;
            string nuevocod = newcod.ToString().PadLeft(8, '0');
            txtCodigoPersonalizado.Text = "C" + nuevocod;

        }

        private void CargaVendedores()
        {
            cmbVendedores.DataSource = AdmVen.MuestraVendedoresDestaque();
            cmbVendedores.DisplayMember = "apellido";
            cmbVendedores.ValueMember = "codVendedor";
            cmbVendedores.SelectedIndex = -1;
        }

        private void CargaFormaPagos()
        {
            cbFormaPago.DataSource = AdmPago.CargaFormaPagos(1);
            cbFormaPago.DisplayMember = "descripcion";
            cbFormaPago.ValueMember = "codFormaPago";
            cbFormaPago.SelectedIndex = 0;
        }

        private void CargaZonas()
        {
            cbZona.DataSource = AdmZona.MuestraZonas();
            cbZona.DisplayMember = "descripcion";
            cbZona.ValueMember = "codZona";
            cbZona.SelectedIndex = -1;
        }

        private void CargaListaPrecios()
        {
            //cbListaPrecios.DataSource = admLista.MuestraListaPrecioxFormaPago(frmLogin.iCodSucursal,Convert.ToInt32(cbFormaPago.SelectedValue));
            //cbListaPrecios.DisplayMember = "nombre";
            //cbListaPrecios.ValueMember = "codListaPrecio";
            //cbListaPrecios.SelectedIndex = 0;
        }

        private void CargaLocalidades(ComboBox Combo,String Padre, Int32 Nivel )
        {
            Combo.DataSource = local.CargaLocalidades(Padre, Nivel);
            Combo.DisplayMember = "nombre";
            Combo.ValueMember = "codLocalidad";
            Combo.SelectedIndex = -1;
        }

        private void CargaCliente(Int32 codCliente)
        {
            try
            {
                cli = admCli.MuestraCliente(codCliente);
                txtCodigo.Text = cli.CodCliente.ToString();
                txtCodigoPersonalizado.Text = cli.CodigoPersonalizado;
                txtDni.Text = cli.Dni;
                txtRUC.Text = cli.Ruc;
                txtRazonSocial.Text = cli.RazonSocial;
                txtDireccionLegal.Text = cli.DireccionLegal;
                txtDireccionEntrega.Text = cli.DireccionEntrega;
                txtTelefono.Text = cli.Telefono;
                txtEmail.Text = cli.Email;
                txtWeb.Text = cli.Web;
                cbPais.SelectedValue = cli.Pais;
                cbDepartamento.SelectedValue = cli.Departamento;
                if (cli.Departamento != "")
                {
                    cbDepartamento.SelectedValue = cli.Departamento;
                    CargaLocalidades(cbProvincia, cli.Departamento.ToString(), 2);
                    cbProvincia.Enabled = true;

                    if (cli.Provincia != "")
                    {
                        cbProvincia.SelectedValue = cli.Provincia;
                        CargaLocalidades(cbDistrito, cli.Provincia.ToString(), 3);
                        cbDistrito.Enabled = true;
                        cbDistrito.SelectedValue = cli.Distrito;
                    }
                }

                cbZona.SelectedValue = cli.Zona;
                cbActivo.Checked = cli.Estado;
                txtDscto.Text = cli.Descuento.ToString();
                cbFormaPago.SelectedValue = cli.FormaPago;
                cbMoneda.SelectedValue = cli.Moneda;
                CargaListaPrecios();
                //  cbListaPrecios.SelectedValue = cli.CodListaPrecio;
                cmbVendedores.SelectedValue = cli.CodVendedor;
                txtLineaCredito.Text = cli.LineaCredito.ToString();
                txtBanco.Text = cli.Banco;
                txtCtaCte.Text = cli.CtaCte;
                txtContacto.Text = cli.Contacto;
                txtTelefonoContacto.Text = cli.TelefonoContacto;
                cbCalificacion.SelectedIndex = cli.Calificacion;
                txtComentario.Text = cli.Comentario;
                txtFechaRegistro.Text = cli.FechaRegistro.Date.ToShortDateString();
                if (cli.Habilitado) { label29.Visible = false; } else { label29.Visible = true; }
                chbCliFacturasVencidas.Checked = cli.ClienteFacturasVencidas;
                if (cli.Tasa != 0) txttasa.Text = cli.Tasa.ToString();
                if (cli.CliEspecial) { chkCliEspecial.Checked = true; } else { chkCliEspecial.Checked = false; }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }
        


        

        private void muestralista()
        {          
            if (Application.OpenForms["frmClientesCompletos"] != null)
            {
                frmClientesCompletos form = (frmClientesCompletos) Application.OpenForms["frmClientesCompletos"];
                form.Activate();
                form.CargaLista();                    
            }
            else
            {
                frmClientesCompletos form = new frmClientesCompletos();
                form.MdiParent = Application.OpenForms["mdi_Menu"];                
                form.Show();
            }           
        }
                

        private void btnSunat_Click(object sender, EventArgs e)
        {
            if (ext.rucsunat(txtRUC.Text))
            {
                txtRazonSocial.Text = ext.RazonSocial;
                txtDireccionLegal.Text = ext.DireccionLegal;
            }
            else
            {
                ext.limpiar(this.Controls);
            }
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {   
                if (ext.rucsunat(txtRUC.Text))
                {
                    txtRazonSocial.Text = ext.RazonSocial;
                    txtDireccionLegal.Text = ext.DireccionLegal;
                }
                else
                {
                    ext.limpiar(this.Controls);
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtDni.Focus();
            }
        }

        private void cbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLocalidades(cbProvincia, cbDepartamento.SelectedValue.ToString(), 2);            
            cbProvincia.Enabled = true;
            cbProvincia.Focus();
        }

        private void cbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaLocalidades(cbDistrito, cbProvincia.SelectedValue.ToString(), 3);
            cbDistrito.Enabled = true;
            cbDistrito.Focus();
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

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {

                    //Cursor = Cursors.WaitCursor;
                    switch (this.txtRUC.Text.Length)
                    {
                        case 1:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo un digito Ingresado",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 2:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo dos digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 3:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo tres digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 4:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo cuatro digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 5:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo cinco digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 6:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo seis digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 7:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Solo siete digitos Ingresados",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 8:
                            cli = admCli.ConsultaCliente(txtRUC.Text);
                            if (cli != null)
                            {
                                MessageBox.Show("El Numero de Documento Ingresado" + Environment.NewLine + "Ya se Encuentra Registrado",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            }
                            else
                            {
                                CargarImagenReniec();
                                CargaDNI();                                
                            }
                            
                            break;

                        case 9:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Ingreso nueve digitos ",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            break;

                        case 10:
                            MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Ingreso diez digitos ",
                                "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                            txtRUC.SelectAll();
                            txtRUC.Focus();
                            break;

                        case 11:
                            cli = admCli.ConsultaCliente(txtRUC.Text);
                            if (cli != null)
                            {
                                //CodCliente = cli.CodCliente;
                                //txtNombreCliente.Text = cli.Nombre;
                                //txtDireccion.Text = cli.DireccionLegal;

                                //if (cli.FormaPago != 0)
                                //{
                                //    cmbFormaPago.SelectedValue = cli.FormaPago;
                                //    EventArgs ee = new EventArgs();
                                //    cmbFormaPago_SelectionChangeCommitted(cmbFormaPago, ee);
                                //}
                                //else
                                //{
                                //    dtpFechaPago.Value = DateTime.Today;
                                //}
                            }
                            else
                            {
                                CargarImagenSunat();
                                CargaRUC();
                                
                            }                           

                            break;

                        default:
                            ValidaLongitud();
                            break;
                    }

                    //cbFamilia.Select();                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    CargarImagenSunat();
                }
            }
        }

        private void ValidaLongitud()
        {
            if (txtRUC.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Ningun digito Ingresado",
                               "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
            }
            else if (txtRUC.Text.Length > 11)
            {
                MessageBox.Show("Ingrese Numero de Documento Valido" + Environment.NewLine + "Ha Ingresado " + txtRUC.Text.Length + " Digitos",
                               "Consulta Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);// para advertencia
                txtRUC.SelectAll();
                txtRUC.Focus();
            }
        }

        private void CargaDNI()
        {
            MyInfoReniec.GetInfo(this.txtRUC.Text, this.txtSunat_Capchat.Text);
            switch (MyInfoReniec.GetResul)
            {
                case Reniec.Resul.Ok:
                    limpiarSunat();
                    txtRUC.Text = MyInfoReniec.Dni;
                    String apellidos = MyInfoReniec.ApePaterno + " " + MyInfoReniec.ApeMaterno;
                    txtRazonSocial.Text = MyInfoReniec.Nombres + " " + apellidos;
                    txtDireccionLegal.Text = "S/D";
                    break;
                case Reniec.Resul.NoResul:
                    limpiarSunat();
                    MessageBox.Show("No Existe DNI");
                    break;
                case Reniec.Resul.ErrorCapcha:
                    limpiarSunat();
                    MessageBox.Show("Ingrese imagen correctamente");
                    break;
                default:
                    MessageBox.Show("Error Desconocido");
                    break;
            }
            //Comentar esta linea para consultar multiples DNI usando un solo captcha.
            CargarImagenReniec();
        }

        #region RENIEC

        private void AplicacionFiltros()
        {
            Bitmap bmp = new Bitmap(pbCapchatS.Image);
            FiltroInvertir(bmp);
            ColorFiltros();
            Bitmap bmp1 = new Bitmap(pbCapchatS.Image);
            FiltroInvertir(bmp1);
            Bitmap bmp2 = new Bitmap(pbCapchatS.Image);
            FiltroSharpen(bmp2);
        }

        private void FiltroInvertir(Bitmap bmp)
        {
            IFilter Filtro = new Invert();
            Bitmap XImage = Filtro.Apply(bmp);
            pbCapchatS.Image = XImage;
        }

        private void ColorFiltros()
        {
            //Red Min - MAX
            red.Min = Math.Min(red.Max, byte.Parse("229"));
            red.Max = Math.Max(red.Min, byte.Parse("255"));
            //Verde Min - MAX
            green.Min = Math.Min(green.Max, byte.Parse("0"));
            green.Max = Math.Max(green.Min, byte.Parse("255"));
            //Azul Min - MAX
            blue.Min = Math.Min(blue.Max, byte.Parse("0"));
            blue.Max = Math.Max(blue.Min, byte.Parse("130"));
            ActualizarFiltro();
        }

        private void ActualizarFiltro()
        {
            ColorFiltering FiltroColor = new ColorFiltering();
            FiltroColor.Red = red;
            FiltroColor.Green = green;
            FiltroColor.Blue = blue;
            IFilter Filtro = FiltroColor;
            Bitmap bmp = new Bitmap(pbCapchatS.Image);
            Bitmap XImage = Filtro.Apply(bmp);
            pbCapchatS.Image = XImage;
        }

        private void FiltroSharpen(Bitmap bmp)
        {
            IFilter Filtro = new Sharpen();
            Bitmap XImage = Filtro.Apply(bmp);
            pbCapchatS.Image = XImage;
        }
        private void CargarImagenReniec()
        {
            try
            {
                if (MyInfoReniec == null)
                    MyInfoReniec = new Reniec();
                this.pbCapchatS.Image = MyInfoReniec.GetCapcha;
                AplicacionFiltros();
                LeerCaptchaReniec();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LeerCaptchaReniec()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var image = new System.Drawing.Bitmap(pbCapchatS.Image))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                            string CaptchaTexto = page.GetText();
                            char[] eliminarChars = { '\n', ' ' };
                            CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars);
                            CaptchaTexto = CaptchaTexto.Replace(" ", string.Empty);
                            CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z0-9]+", string.Empty);
                            if (CaptchaTexto != string.Empty & CaptchaTexto.Length == 4)
                                txtSunat_Capchat.Text = CaptchaTexto.ToUpper();
                            //else
                            //    CargarImagenReniec();
                        }
                    }
                }
            }
        }

        #endregion

        #region metodos Sunat

        private void CargaRUC()
        {
            if (this.txtRUC.Text.Length == 11)
            {
                LeerDatos();
            }
        }
        private void LeerDatos()
        {
            //llamamos a los metodos de la libreria ConsultaReniec...
            MyInfoSunat.GetInfo(this.txtRUC.Text, this.txtSunat_Capchat.Text);
            switch (MyInfoSunat.GetResul)
            {
                case Sunat.Resul.Ok:
                    limpiarSunat();
                    txtRUC.Text = MyInfoSunat.Ruc;
                    txtDireccionLegal.Text = MyInfoSunat.Direcion;
                    txtRazonSocial.Text = MyInfoSunat.RazonSocial;
                    //Ciudad(MyInfoSunat.Direcion);
                    BloqueaDatos();
                    break;
                case Sunat.Resul.NoResul:
                    limpiarSunat();
                    MessageBox.Show("No Existe RUC");
                    break;
                case Sunat.Resul.ErrorCapcha:
                    limpiarSunat();
                    MessageBox.Show("Ingrese imagen correctamente");
                    break;
                default:
                    MessageBox.Show("Error Desconocido");
                    break;
            }
            //CargarImagenSunat();
        }
        private void CargarImagenSunat()
        {
            try
            {
                if (MyInfoSunat == null)
                    MyInfoSunat = new Sunat();
                this.pbCapchatS.Image = MyInfoSunat.GetCapcha;
                LeerCaptchaSunat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LeerCaptchaSunat()
        {
            //string ruta = Directory.GetCurrentDirectory()+"\\tessdata";
            //string RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata\\");
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var image = new System.Drawing.Bitmap(pbCapchatS.Image))
                    {
                        using (var pix = PixConverter.ToPix(image))
                        {
                            using (var page = engine.Process(pix))
                            {
                                var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                                string CaptchaTexto = page.GetText();
                                char[] eliminarChars = { '\n', ' ' };
                                CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars);
                                CaptchaTexto = CaptchaTexto.Replace(" ", string.Empty);
                                CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z]+", string.Empty);
                                if (CaptchaTexto != string.Empty & CaptchaTexto.Length == 4)
                                    txtSunat_Capchat.Text = CaptchaTexto.ToUpper();
                                else
                                    CargarImagenSunat();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Ciudad(string Direccion)
        {
            String[] array = Direccion.Split('-');
            if (array.Length > 1)
            {
                int a = array.Length;
                String DirTemp = array[a - 3].Trim();
                DirTemp = DirTemp.TrimEnd(' ');
                String[] ArrayDir = DirTemp.Split(' ');
                int i = ArrayDir.Length;
                //cbDepartamento.Text = ArrayDir[i - 1].Trim();
                //cbProvincia.Text = array[a - 2].Trim();
                //cbDistrito.Text = array[a - 1].Trim();
            }
        }
        private void limpiarSunat()
        {
            txtRazonSocial.Text = "";
            txtSunat_Capchat.Text = string.Empty;
        }
        private void BloqueaDatos()
        {
            /*txtRUC.ReadOnly = true; */
            txtDireccionLegal.ReadOnly = false; txtRazonSocial.ReadOnly = true;
        }

        #endregion

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.enteros(e);
        }

        private void txtLineaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ok.SOLONumeros(sender,e);
        }

        private void cbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaListaPrecios();
        }

        private void frmGestionCliente_Shown(object sender, EventArgs e)
        {
            txtRazonSocial.Focus();
        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccionLegal.Focus();
            }
        }

        private void txtDireccionEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbDepartamento.Focus();
            }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeb.Focus();
            }
        }

        private void txtWeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbZona.Focus();
            }
        }

        private void cbZona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAceptar.Focus();
        }

        private void cbPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDepartamento.Focus();
        }

        private void cbDistrito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtRUC.Focus();
        }

        private void txtDireccionLegal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccionEntrega.Focus();
            }
        }

        
    }
}
