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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using SIGEFA.Reportes.clsReportes;
using System.IO;

namespace SIGEFA.Formularios
{

    public partial class frmCotizacionesVigentes : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmCotizacion AdmCotizacion = new clsAdmCotizacion();
        clsCotizacion cotizacion = new clsCotizacion();        
        public Int32 Proceso = 0; //

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsCliente cli= new clsCliente();

        private clsDocumentosImpresos ds = new clsDocumentosImpresos();//cotizacion
        public String nombreArchivo = "";

        public frmCotizacionesVigentes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            dgvCotizaciones.DataSource = data;
            data.DataSource = AdmCotizacion.MuestraCotizaciones(frmLogin.iCodAlmacen);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCotizaciones.ClearSelection();
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            
            if (dgvCotizaciones.Rows.Count >= 1 && dgvCotizaciones.CurrentRow != null)
            {
                DataGridViewRow row = dgvCotizaciones.CurrentRow;
                frmGestionCotizacion form = new frmGestionCotizacion();
                form.MdiParent = this.MdiParent;
                form.CodCotizacion = cotizacion.CodCotizacion;
                //form.aprobado = Convert.ToInt32(dgvCotizaciones.SelectedRows[0].Cells[aprob.Name].Value);
                form.Proceso = 3;
                //form.chbAprobado.Visible = true;
                //form.btnAceptar.Visible = true;
                //form.btnAceptar.Location = new Point(934,11);
                form.Show();            
            }
        }

        private void frmCotizacionesVigentes_Load(object sender, EventArgs e)
        {
            //CargaLista();
            label7.Text = "Cliente";
            label1.Text = "Cliente";
            cmbVigente.SelectedIndex = 1;
            consultar();
        }

        private void btGenVenta_Click(object sender, EventArgs e)
        {
            if (cotizacion.CodCotizacion != "" &&  dgvCotizaciones.CurrentRow != null )
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
                    form.Procede = 3;
                    form.txtCotizacion.Text = dgvCotizaciones.CurrentRow.Cells[codigo.Name].Value.ToString();
                    KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Return);
                    //form.inicializar_formulario();
                    form.Show();
                    form.txtCotizacion_KeyPress(form.txtCotizacion, ee);
                    form.txtCotizacion.Visible = true;
                    form.label4.Visible = true;
                    form.label38.Visible = false;
                    form.txtcodpedido.Visible = false;
                    //form.cmbFormaPago_SelectionChangeCommitted(sender,e);
                    form.btnGuardar.Enabled = true;
                    form.btnNuevo.Enabled = true;
                    //form.btnEditar.Enabled = true;
                    form.btnEliminar.Enabled = true;
                }
            }
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCotizaciones.Rows.Count >= 1 && e.Row.Selected)
            {
                cotizacion.CodCotizacion = e.Row.Cells[codigo.Name].Value.ToString();
                cotizacion.RazonSocialCliente = e.Row.Cells[cliente.Name].Value.ToString(); 
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvCotizaciones.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmGestionCotizacion form = new frmGestionCotizacion();
                form.MdiParent = this.MdiParent;
                form.CodCotizacion = cotizacion.CodCotizacion;
                form.Proceso = 3;
                //form.chbAprobado.Visible = true;
                form.btnAceptar.Visible = true;
                form.btnAceptar.Location = new Point(934, 11);
                form.Show();            
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvCotizaciones.CurrentRow != null && cotizacion.CodCotizacion != "")
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular la cotizacion seleccionada", "Cotizaciones Vigentes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmCotizacion.delete(Convert.ToInt32(cotizacion.CodCotizacion)))
                    {
                        MessageBox.Show("La cotizacion ha sido anulada correctamente", "Cotizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        consultar();
                    }
                }
            }
        }

        private void dgvCotizaciones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label7.Text = dgvCotizaciones.Columns[e.ColumnIndex].HeaderText;
            label1.Text = dgvCotizaciones.Columns[e.ColumnIndex].DataPropertyName;
            txtFiltro.Focus();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text.Length >= 2)
                {
                    data.Filter = String.Format("[{0}] like '*{1}*'", label1.Text.Trim(), txtFiltro.Text.Trim());
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

        private void consultar()
        {
            dgvCotizaciones.DataSource = data;
            data.DataSource = AdmCotizacion.MuestraCotizacionesxVigente(frmLogin.iCodAlmacen, cmbVigente.SelectedIndex, dtpDesde.Value,dtpHasta.Value);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvCotizaciones.ClearSelection();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultar();

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            consultar();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            consultar();
        }

        private void cmbVigente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            consultar();
            if (cmbVigente.SelectedIndex == 1) btnAnular.Visible = true;
            else btnAnular.Visible = false;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCotizaciones.CurrentRow != null && cmbVigente.SelectedIndex==1)
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar la Cotización", "Cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        PdfRtfWordFormatOptions crformattype = new PdfRtfWordFormatOptions();
                        DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
                        ExportOptions objexport;
                        dfoption.DiskFileName = @"C:\Cotizaciones\Cotizacion_" + cotizacion.CodCotizacion + ".pdf";
                        ReportDocument document = new ReportDocument();
                        CRCotizacion cot = new CRCotizacion();
                        cot.SetDataSource(ds.Cotizacion(Convert.ToInt32(cotizacion.CodCotizacion)));
                        objexport = cot.ExportOptions;
                        objexport.ExportDestinationType = ExportDestinationType.DiskFile;
                        objexport.ExportFormatType = ExportFormatType.PortableDocFormat;
                        objexport.DestinationOptions = dfoption;
                        objexport.FormatOptions = crformattype;
                        cot.Export();

                        DirectoryInfo Dir = new DirectoryInfo(@"C:\Cotizaciones");

                        foreach (FileInfo Fi in Dir.GetFiles())
                        {
                            //Dt.Rows.Add(idfile, Fi.Name.ToString());
                            //idfile++;
                            if (Fi.Name.Contains(cotizacion.CodCotizacion))
                            {
                                nombreArchivo = Fi.Name;
                            }
                        }


                        if (Application.OpenForms["frmCorreoElectronico"] != null)
                        {
                            Application.OpenForms["frmCorreoElectronico"].Activate();
                        }
                        else
                        {
                            frmCorreoElectronico form = new frmCorreoElectronico();
                            form.link_adjunto.Text = nombreArchivo;
                            form.txtcuerpo.Text = "ESTIMADOS SRs.: " + cotizacion.RazonSocialCliente + Environment.NewLine + Environment.NewLine + "\t LES ADJUNTO LA COTIZACIÓN.  N- " + cotizacion.CodCotizacion + "." +
                                                            Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "\t\t\t \t\t  ATT. " +
                                                           Environment.NewLine + "\t\t\t\t" + frmLogin.sApellidoUSer + ", " + frmLogin.sNombreUser;
                            form.tipo = 2;
                            form.ShowDialog();
                            if (form.enviado == 1)
                            {
                                MessageBox.Show("La Cotización ha envio correctamente", "Cotización",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                consultar();
                            }
                            else
                            {
                                MessageBox.Show("La Cotización, No se Pudo enviar, Verifique!", "Cotización",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                                consultar();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Enviar la Cotización", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                consultar();
            }
        }

        private void frmCotizacionesVigentes_Shown(object sender, EventArgs e)
        {
            txtFiltro.Focus();
        }
    }
}
