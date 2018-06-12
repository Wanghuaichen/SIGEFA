using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net.Mail;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmCorreoElectronico : Form
    {
        private clsAdmProveedor admproveedor = new clsAdmProveedor();
        private clsAdmUsuario admuser = new clsAdmUsuario();
        private clsUsuario user = new clsUsuario();
        private clsUsuario clsentuser = new clsUsuario();
        public Int32 enviado = 0;
        public Int32 codpro = 0, tipo=0;// tipo : 1) Orden Compra 2)cotizacion
        DataTable aux = new DataTable();
        private Int32 Proceso = 0;///// (1)txt Para//////(2)txt CC
        public frmCorreoElectronico()
        {
            InitializeComponent();
        }

        private void txtpara_Click(object sender, EventArgs e)
        {
                txtpara.Text = "";
                Proceso = 1;
                pdestinatarios.Enabled = true;
                pdestinatarios.Visible = true;
                gbcabecera.Enabled = false;
                gbmensaje.Enabled = false;
                dgvadjuntos.Enabled = false;
                gbopciones.Enabled = false;
                gbmensaje.SendToBack();
                pdestinatarios.BringToFront();

                if (tipo == 1) chbproveedores.Visible = true;
                else if (tipo == 2) chbproveedores.Visible = false;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbcabecera.Enabled = true;
            gbcabecera.Visible = true;
            gbmensaje.Enabled = true;
            gbmensaje.Visible = true;
            gbopciones.Enabled = true;
            gbopciones.Visible = true;
            pdestinatarios.Enabled = false;
            pdestinatarios.Visible = false;
        }
        private void GenerarAdjunto() { 
        
        }
        private void btnadjuntar_Click(object sender, EventArgs e)
        {
            GenerarAdjunto();
            gbcabecera.Enabled = false;
            gbmensaje.Enabled = false;
            gbopciones.Enabled = false;
            dgvadjuntos.SendToBack();
            OpenFileDialog BuscarArchivo = new OpenFileDialog();
            BuscarArchivo.Filter = "Archivos |*.*";
            //Aquí incluiremos los filtros que queramos.
            BuscarArchivo.FileName = "";
            BuscarArchivo.Title = "Titulo del Dialogo";
            if (tipo == 1) BuscarArchivo.InitialDirectory = @"C:\Ordenes de Compra";
            else if (tipo == 2) BuscarArchivo.InitialDirectory = @"C:\Cotizaciones";
            //BuscarArchivo.InitialDirectory = @"C:\Ordenes de Compra";
            BuscarArchivo.Multiselect=true;            
            if (BuscarArchivo.ShowDialog() == DialogResult.OK)
            {
                DataTable Dt = new DataTable();
                Int32 idfile = 1;
                Dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
                Dt.Columns.Add(new DataColumn("Archivo", typeof(String)));

                DataTable Dt2 = (DataTable)dgvadjuntos.DataSource;
                foreach (String Fi in BuscarArchivo.FileNames)
                {
                    Dt.Rows.Add(idfile, Fi.ToString());
                }
                foreach (String Fi in BuscarArchivo.SafeFileNames)
                {
                    link_adjunto1.Text += Fi + "  ";
                    link_adjunto1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                }
                if (Dt2 == null)
                {
                    dgvadjuntos.DataSource = Dt;
                }
                else if (Dt.Rows != null)
                {
                    Dt2.Merge(Dt);
                    dgvadjuntos.DataSource = Dt2;
                }
            }

            gbcabecera.Enabled = true;
            gbmensaje.Enabled = true;
            gbopciones.Enabled = true;
            //gbGestionEnvio.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        
        {//Agrega Correos
            if (dgvcorreos.RowCount >= 1)
            {
                if (Proceso == 1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Int32 iFila = 0;
                    Int32 iRow = 0;
                    DataGridViewRow Row;

                    iRow = dgvcorreos.Rows.Count;
                    for (iFila = 0; iFila < iRow; iFila++)
                    {
                        Row = dgvcorreos.Rows[iFila];
                        if (Row.Cells[0].Value != null)
                        {
                            if (System.Convert.ToBoolean(Row.Cells[0].Value.ToString()) == true)
                            {
                                if (txtpara.Text.Trim() == "")
                                {
                                    txtpara.Text = Row.Cells[2].Value.ToString().Trim();
                                }
                                else
                                {
                                    txtpara.Text = txtpara.Text.Trim() + ", " + Row.Cells[2].Value.ToString().Trim();
                                }
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else if(Proceso==2){
                    this.Cursor = Cursors.WaitCursor;
                    Int32 iFila = 0;
                    Int32 iRow = 0;
                    DataGridViewRow Row;

                    iRow = dgvcorreos.Rows.Count;
                    for (iFila = 0; iFila < iRow; iFila++)
                    {
                        Row = dgvcorreos.Rows[iFila];
                        if (Row.Cells[0].Value != null)
                        {
                            if (System.Convert.ToBoolean(Row.Cells[0].Value.ToString()) == true)
                            {
                                if (txtcc.Text.Trim() == "")
                                {
                                    txtcc.Text = Row.Cells[2].Value.ToString().Trim();
                                }
                                else
                                {
                                    txtcc.Text = txtcc.Text.Trim() + ", " + Row.Cells[2].Value.ToString().Trim();
                                }
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            pdestinatarios.Enabled = false;
            pdestinatarios.Visible = false;
            gbcabecera.Enabled = true;
            gbcabecera.Visible = true;
            gbmensaje.Enabled = true;
            gbmensaje.Visible = true;
            gbopciones.Enabled = true;
            gbopciones.Visible = true;
            //gbGestionEnvio.Enabled = true;
            this.Cursor = Cursors.Default;
            txtasunto.Focus();
        }

        private void btncancela_adjuntos_Click(object sender, EventArgs e)
        {
            gbcabecera.Enabled = true;
            gbcabecera.Visible = true;
            gbmensaje.Enabled = true;
            gbmensaje.Visible = true;
            gbopciones.Enabled = true;
            gbopciones.Visible = true;
        }

        private void frmCorreoElectronico_Load(object sender, EventArgs e)
        {
            clsentuser = admuser.MuestraUsuario(frmLogin.iCodUser);
            txtde.Text = clsentuser.Email;
            txtde.Enabled = false;
            pdestinatarios.Enabled = false;
            pdestinatarios.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String sRutaPrincipal = "";
            String sArchivo = "";
            String sRutaFinal = "";
            //String sUserCredential = clsentuser.Email.Substring(0, clsentuser.Email.Length - 11);
            String sUserCredential = clsentuser.Email;
            String sPassCredential = clsentuser.ContraEmail;
            //Int32 iLength = sCorreoU.Length;
            //sUserCredential = sCorreoU.Substring(0, iLength - 10);
            //sPassCredential = sClaveU;

            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            //String ipp = ClsConexion.GetPublicIP().ToString();
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();

            //if (ipp.Equals("190.41.176.185"))
            //{
            //    smtp = new System.Net.Mail.SmtpClient("192.168.1.14");
            //}
            //else //if (ipp.Equals("190.41.176.186"))
            //{
               //smtp = new System.Net.Mail.SmtpClient("190.41.176.185");
            //}
            
            smtp.Host = clsentuser.Host;
            //smtp.Port = 587;
            if (clsentuser.Host == "smtp.gmail.com" || clsentuser.Host == "smtp.live.com")
            {
                smtp.EnableSsl = true;
            }
            //fuera de la red local - 4to PISO
            //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("190.41.176.185");

            //dentro de la red local - 2do PISO
            //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("192.168.1.14");

            // la credencial depende del usuario
            smtp.Credentials = new System.Net.NetworkCredential(sUserCredential, sPassCredential);
            //smtp.EnableSsl = true;
            //smtp.gmail.com
            //smtp.live.com
            
            //correo.From = new System.Net.Mail.MailAddress(sCorreoU);
            correo.From = new System.Net.Mail.MailAddress(clsentuser.Email);
            if (txtpara.Text.Trim() != "") correo.To.Add(txtpara.Text.Trim()+ "," + admuser.MuestraUsuarioNivel().Email);
          
            correo.Subject = txtasunto.Text;
            correo.Body = txtcuerpo.Text;
            correo.IsBodyHtml = false;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            String arch_adj="";
            //aquí se añaden los archivos adjuntos
            if(tipo==1)arch_adj = @"C:\Ordenes de Compra\" + link_adjunto.Text;
            else if(tipo==2) arch_adj = @"C:\Cotizaciones\" + link_adjunto.Text;
            //String arch_adj = @"C:\Ordenes de Compra\" + link_adjunto.Text;
            correo.Attachments.Add(new Attachment(arch_adj));
            if (dgvadjuntos.RowCount >= 1)
            {
                Int32 iFila = 0;
                Int32 iRow = 0;
                DataGridViewRow Row;

                iRow = dgvadjuntos.Rows.Count;
                for (iFila = 0; iFila < iRow; iFila++)
                {
                    Row = dgvadjuntos.Rows[iFila];
                    sArchivo = Row.Cells[1].Value.ToString().Trim();
                    sRutaFinal = sArchivo;
                    correo.Attachments.Add(new Attachment(sRutaFinal));
                }
            }
            smtp.Send(correo);
            //lblResultado.Text = "Correo Enviado Satisfactoriamente a: " + txtPara.Text;
            MessageBox.Show("Correo Enviado Satisfactoriamente a: "+txtpara.Text);
            enviado = 1;
            btnAceptar.Enabled = true;
        }

        private void txtcc_Click(object sender, EventArgs e)
        {
            txtcc.Text = "";
            Proceso = 2;
            pdestinatarios.Enabled = true;
            pdestinatarios.Visible = true;
            gbcabecera.Enabled = false;
            gbmensaje.Enabled = false;
            dgvadjuntos.Enabled = false;
            gbopciones.Enabled = false;
            gbmensaje.SendToBack();
            pdestinatarios.BringToFront();

            if(tipo==1) chbproveedores.Visible = true;
            else if (tipo == 2) chbproveedores.Visible = false;
        }

        private void Verifica_CheckStateChanged(object sender, EventArgs e)
        {
            if (tipo == 1) 
            {
                DataTable dt = new DataTable();
                aux.Clear();
                if (chbproveedores.CheckState == CheckState.Checked)
                {
                    if (aux != null)
                    {
                        dt = admproveedor.ListaCorreosProveedores(codpro);
                        aux.Merge(dt);
                    }
                    else
                    {
                        dt = admproveedor.ListaCorreosProveedores(codpro);
                        aux = dt;
                    }
                }
                if (chbusuarios.CheckState == CheckState.Checked)
                {
                    if (aux != null)
                    {
                        dt = admuser.ListaCorreoUsuarios();
                        aux.Merge(dt);
                    }
                    else
                    {
                        dt = admuser.ListaCorreoUsuarios();
                        aux = dt;
                    }
                }
                dgvcorreos.DataSource = aux;

            }
            else if (tipo == 2) 
            {
                DataTable dt = new DataTable();
                aux.Clear();
                
                if (chbusuarios.CheckState == CheckState.Checked)
                {
                    if (aux != null)
                    {
                        dt = admuser.ListaCorreoUsuarios();
                        aux.Merge(dt);
                    }
                    else
                    {
                        dt = admuser.ListaCorreoUsuarios();
                        aux = dt;
                    }
                }
                dgvcorreos.DataSource = aux;
            }
            
        }

        private void chbproveedores_CheckStateChanged(object sender, EventArgs e)
        {
            Verifica_CheckStateChanged(sender, null);
        }

        private void chbusuarios_CheckStateChanged(object sender, EventArgs e)
        {
            Verifica_CheckStateChanged(sender, null);
        }

        private void link_adjunto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tipo == 1) 
            {
                String path = @"C:\Ordenes de Compra\" + link_adjunto.Text;
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Mostrar el archivo", ex.Message);
                }
            }
            else if (tipo == 2) {
                String path = @"C:\Cotizaciones\" + link_adjunto.Text;
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Mostrar el archivo", ex.Message);
                }
            }
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            link_adjunto1.Text = "";
            DataTable dtx = new DataTable();
            dtx = (DataTable) dgvadjuntos.DataSource;
            dtx.Clear();
            dgvadjuntos.DataSource = dtx;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Enabled)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Enabled)
                if (e.ControlToValidate.Text != "")
                    e.IsValid = true;
                else
                    e.IsValid = false;
            else
                e.IsValid = true;
        }        
    }
}
