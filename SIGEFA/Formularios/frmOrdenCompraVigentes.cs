using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{

    public partial class frmOrdenCompraVigentes : DevComponents.DotNetBar.Office2007Form    
    {
        clsAdmOrdenCompra AdmOrden = new clsAdmOrdenCompra();
        clsOrdenCompra Ord = new clsOrdenCompra();
        private clsReporteOrdenCompra ds = new clsReporteOrdenCompra();
        public Int32 Proce = 0; //
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public Int32 OrdCom, codproveedor = 0, CodAlmacenOrden=0;
        public String Docum = "", Flete = "", AtendidoOrd = "", nombreArchivo = "";

        public clsProveedor deta = new clsProveedor();

        public frmOrdenCompraVigentes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaLista()
        {
            if (Proce == 0)
            {
                dgvOrdenes.DataSource = data;
                //data.DataSource = AdmOrden.MuestraOrdenesVigentes(dtpDesde.Value.Date, dtpHasta.Value.Date, frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
            }
            else if (Proce == 5) 
            {
                dgvOrdenes.DataSource = data;
                //data.DataSource = AdmOrden.MuestraOrdenesVigentesParaNota(frmLogin.iCodAlmacen, codproveedor);
                data.Filter = String.Empty;
                filtro = String.Empty;
            }
            else if (Proce == 2)
            {
                dgvOrdenes.DataSource = data;
                //data.DataSource = AdmOrden.MuestraOrdenesHistorial(dtpDesde.Value.Date, dtpHasta.Value.Date, frmLogin.iCodAlmacen);
                data.Filter = String.Empty;
                filtro = String.Empty;
                Atendido.Visible = true;
            }
        }

        private void btnIrCotizacion_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                DataGridViewRow row = dgvOrdenes.CurrentRow;
                frmOrdenCompras form = new frmOrdenCompras();
                form.MdiParent = this.MdiParent;
                form.CodOrdenCompra = Ord.CodOrdenCompra;
                form.Proceso = 3;
                form.Proce = Proce;
                form.Show();            
            }
        }

        private void frmOrdenesVigentes_Load(object sender, EventArgs e)
        {
            if (Proce == 5)
            {
                btnAnular.Visible = false;
                btnIrCotizacion.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
                btnConsultar.Visible = false;
                btnEnviar.Visible = false;
                btnrechazar.Visible = false;
                btnTerminada.Visible = false;
                btnVistaSucursales.Visible = false;
                btnVistaSucursales.Visible = false;
                CargaLista();
                Estado.Visible = false;
            }
        }

        private void dgvCotizaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && e.Row.Selected)
            {
                Ord.CodOrdenCompra = Convert.ToInt32(e.Row.Cells[codigo.Name].Value);
                Docum = e.Row.Cells[Documento.Name].Value.ToString();
                Ord.CodProveedor= Convert.ToInt32(e.Row.Cells[codProveedor1.Name].Value);
                Ord.RazonSocialProveedor = Convert.ToString(e.Row.Cells[proveedor.Name].Value);
                CodAlmacenOrden = Convert.ToInt32(e.Row.Cells[almacen.Name].Value);
                if (Proce != 5)
                {
                    AtendidoOrd = e.Row.Cells[Atendido.Name].Value.ToString();
                }
            }
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvOrdenes.Rows.Count >= 1 && e.RowIndex != -1)
            {
                frmOrdenCompras form = new frmOrdenCompras();
                form.MdiParent = this.MdiParent;
                form.CodOrdenCompra = Ord.CodOrdenCompra;
                form.Proceso = 3;
                form.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow != null && Ord.CodOrdenCompra != 0)
            {
                DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el Requerimiento seleccionado", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (AdmOrden.anular(Ord.CodOrdenCompra))
                    {
                        MessageBox.Show("El requerimiento ha sido anulado correctamente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaLista();
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {                
                frmNotaIngreso form = new frmNotaIngreso();
                form.MdiParent = this.MdiParent;
                OrdCom = Ord.CodOrdenCompra;

                foreach (DataGridViewRow row in dgvOrdenes.Rows)
                {
                    deta.CodProveedor = Convert.ToInt32(row.Cells[codProveedor1.Name].Value);
                    deta.Ruc = row.Cells[RUC.Name].Value.ToString();
                    deta.RazonSocial = row.Cells[proveedor.Name].Value.ToString();
                    Flete = row.Cells[flete1.Name].Value.ToString();
                }
                if (Application.OpenForms["frmNotaIngreso"] != null)
                {
                    Application.OpenForms["frmNotaIngreso"].Activate();
                }
            }
            this.Close();
        }

        private void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvOrdenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            //{
            //    frmNotaIngreso form = new frmNotaIngreso();
            //    form.MdiParent = this.MdiParent;
            //    OrdCom = Ord.CodOrdenCompra;
            //    foreach (DataGridViewRow row in dgvOrdenes.Rows)
            //    {
            //        deta.CodProveedor = Convert.ToInt32(row.Cells[codProveedor.Name].Value);
            //        deta.Ruc = row.Cells[RUC.Name].Value.ToString();
            //        deta.RazonSocial = row.Cells[proveedor.Name].Value.ToString();
            //    }
            //    if (Application.OpenForms["frmNotaIngreso"] != null)
            //    {
            //        Application.OpenForms["frmNotaIngreso"].Activate();
            //    }
            //}
            //this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaLista();          
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenes.CurrentRow != null)
                {
                    DialogResult dlgResult = MessageBox.Show("Esta seguro que desea enviar el Borrador Orden seleccionado", "Orden Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        PdfRtfWordFormatOptions crformattype = new PdfRtfWordFormatOptions();
                        DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
                        ExportOptions objexport;
                        dfoption.DiskFileName = @"C:\Ordenes de Compra\Orden de Compra_" + Docum+ ".pdf";
                        ReportDocument document = new ReportDocument();
                        CROrdenCompra orden = new CROrdenCompra();
                        orden.SetDataSource(ds.RptOrdenCompra(Ord.CodOrdenCompra));
                        objexport = orden.ExportOptions;
                        objexport.ExportDestinationType = ExportDestinationType.DiskFile;
                        objexport.ExportFormatType = ExportFormatType.PortableDocFormat;
                        objexport.DestinationOptions = dfoption;
                        objexport.FormatOptions = crformattype;
                        orden.Export();

                        DirectoryInfo Dir = new DirectoryInfo(@"C:\Ordenes de Compra");

                        foreach (FileInfo Fi in Dir.GetFiles())
                        {
                            //Dt.Rows.Add(idfile, Fi.Name.ToString());
                            //idfile++;
                            if (Fi.Name.Contains(Docum))
                            {
                                nombreArchivo = Fi.Name;
                            }
                        }

                        if (Proce == 0)
                        {
                            if (Application.OpenForms["frmCorreoElectronico"] != null)
                            {
                                Application.OpenForms["frmCorreoElectronico"].Activate();
                            }
                            else
                            {
                                frmCorreoElectronico form = new frmCorreoElectronico();
                                form.link_adjunto.Text = nombreArchivo;
                                form.txtcuerpo.Text = "ESTIMADOS SRs.: " + Ord.RazonSocialProveedor + Environment.NewLine + Environment.NewLine + "\t LES ADJUNTO MI ORDEN DE COMPRA.  N- " + Docum + "." +
                                                                Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +  Environment.NewLine+ "\t\t\t \t\t  ATT. " +
                                                               Environment.NewLine + "\t\t\t\t" + frmLogin.sApellidoUSer + ", " + frmLogin.sNombreUser;
                                form.codpro=Ord.CodProveedor;
                                form.tipo = 1;
                                form.ShowDialog();
                                if (form.enviado == 1)
                                {
                                    MessageBox.Show("La Orden ha envio correctamente", "Orden Compra",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //AdmOrden.Envio(Ord.CodOrdenCompra);
                                    CargaLista();
                                }
                                else
                                {
                                    MessageBox.Show("La Orden de Compra, No se Pudo enviar, Verifique!", "Orden Compra",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargaLista();
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo Enviar la Orden Compra", "Orden Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaLista();      
            }

        }

        private void btnrechazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenes.CurrentRow != null && AtendidoOrd == "ENVIADO") //MOD1 "ENVIADA" POR "ENVIADO"
                {
                    DialogResult dlgResult = MessageBox.Show(
                        "Esta seguro que desea rechazar la Orden seleccionada", "Orden Compra",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //if (AdmOrden.rechazado(Ord.CodOrdenCompra))
                        //{
                        //    MessageBox.Show("La Orden ha sido rechazado correctamente", "Orden Compra",
                        //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    CargaLista();
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("No se puede Rechazar. Verifique");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnTerminada_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenes.CurrentRow != null && AtendidoOrd == "ATENDIDO PARCIALMENTE")
                {
                    DialogResult dlgResult = MessageBox.Show(
                        "Esta seguro que desea Dar Por Terminada la Orden seleccionada", "Orden Compra",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        //if (AdmOrden.terminada(Ord.CodOrdenCompra))
                        //{
                        //    MessageBox.Show("La Orden se Ha dado Por Terminada correctamente", "Orden Compra",
                        //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    CargaLista();

                        //}
                    }
                }
                else
                {
                    MessageBox.Show("No se puede Dar Por Terminada la Orden. Verifique");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void dgvOrdenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Proce == 5)
            {
                if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
                {
                    frmNotaIngreso form = new frmNotaIngreso();
                    form.MdiParent = this.MdiParent;
                    OrdCom = Ord.CodOrdenCompra;

                    foreach (DataGridViewRow row in dgvOrdenes.Rows)
                    {
                        deta.CodProveedor = Convert.ToInt32(row.Cells[codProveedor1.Name].Value);
                        deta.Ruc = row.Cells[RUC.Name].Value.ToString();
                        deta.RazonSocial = row.Cells[proveedor.Name].Value.ToString();
                        Flete = row.Cells[flete1.Name].Value.ToString();
                    }
                    if (Application.OpenForms["frmNotaIngreso"] != null)
                    {
                        Application.OpenForms["frmNotaIngreso"].Activate();
                    }
                }
                this.Close();
            }
            else {
                if (dgvOrdenes.Rows.Count >= 1 && e.RowIndex != -1)
                {
                    frmOrdenCompras form = new frmOrdenCompras();
                    form.MdiParent = this.MdiParent;
                    form.CodOrdenCompra = Ord.CodOrdenCompra;
                    form.Proceso = 3;
                    form.Show();
                }
            }
            
        }

        private void btnVistaSucursales_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow != null)
            {
                if (btnVistaSucursales.Text == "Activar Vista")
                {
                    if (dgvOrdenes.Rows.Count >= 1 && dgvOrdenes.CurrentRow.Index != -1)
                    {
                        DialogResult dlgResult = MessageBox.Show("¿Esta seguro que desea activar la vista de este documento en otras sucursales?", "Ordenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                        //    if (AdmOrden.VistaSucursal(Ord.CodOrdenCompra, 1))
                        //    {
                        //        MessageBox.Show("El documento puede ser visualizado desde cualquier sucursal correctamente", "Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        CargaLista();
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("El documento no puede ser activado para otras sucursales", "Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //}
                    }
                }
            }
        }

    }
}
