using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIGEFA.Administradores;
using SIGEFA.Entidades;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes; 
namespace SIGEFA.Formularios
{
    public partial class frmVentasSeparacioVer : DevComponents.DotNetBar.OfficeForm
    {
        clsAdmSeparacion admVentas = new clsAdmSeparacion();
        clsSeparacion sepa = new clsSeparacion();
        clsCuotasSeparacion cuotas = new clsCuotasSeparacion();
        clsAdmCuotaSeparacion admCuota = new clsAdmCuotaSeparacion();
        clsReporteVentSeparacion ds = new clsReporteVentSeparacion();
        public frmVentasSeparacioVer()
        {
            InitializeComponent();
        }

        private void frmVentasSeparacioVer_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-90);
            cmbEstado.SelectedIndex = 0;
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                dgvVentasSeparacion.DataSource = admVentas.CargarVentas(frmLogin.iCodAlmacen, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(cmbEstado.SelectedIndex));
                dgvVentasSeparacion.ClearSelection();
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void dgvVentasSeparacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentasSeparacion.Rows.Count >= 1 && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell celda = dgvVentasSeparacion.CurrentCell;
                if (celda.Value.ToString() == "ABONAR")
                {
                    frmPargarSeparacion form = new frmPargarSeparacion();
                    //form.MdiParent = this;
                    Int32 id = Convert.ToInt32(dgvVentasSeparacion.Rows[e.RowIndex].Cells[codigoFactura.Name].Value.ToString());
                    form.codSeparacion = id;
                    form.Proceso = 1;
                    form.ShowDialog();
                }
                else if (celda.Value.ToString() == "GENERAR VENTA")
                {
                    if (Application.OpenForms["frmVenta"] != null)
                    {
                        Application.OpenForms["frmVenta"].Close();
                    }
                    else
                    {
                        frmVenta form = new frmVenta();
                        form.MdiParent = this.MdiParent;
                        form.CodSeparacion = Convert.ToInt32(dgvVentasSeparacion.CurrentRow.Cells[codigoFactura.Name].Value.ToString());
                        form.label38.Text = "Separacion";
                        form.Proceso = 5;
                        form.Show();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentasSeparacion.Rows.Count >= 1 && dgvVentasSeparacion.CurrentRow != null)
                {
                    DataGridViewRow row = dgvVentasSeparacion.CurrentRow;
                    if (btnAnular.Text == "Anular")
                    {
                        if (dgvVentasSeparacion.Rows.Count >= 1 && dgvVentasSeparacion.CurrentRow.Index != -1)
                        {
                            DialogResult dlgResult = MessageBox.Show("Esta seguro que desea anular el documento seleccionado", "Notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlgResult == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                sepa = admVentas.BuscarSeparacion(sepa.CodSeparacion, frmLogin.iCodAlmacen);
                                cuotas = admCuota.BuscarCuotasSeparacion(sepa.CodSeparacion, frmLogin.iCodAlmacen);
                                /*if (cuotas == null)
                                {*/
                                if (admVentas.anular(Convert.ToInt32(sepa.CodSeparacion)))
                                {
                                    MessageBox.Show("El documento ha sido anulado correctamente", "Ventas",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                //}
                                else
                                {
                                    MessageBox.Show("No se puede Anular Ventas ", "Ventas",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void dgvVentasSeparacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentasSeparacion.Rows.Count >= 1 && e.RowIndex != -1)
            {
                if (dgvVentasSeparacion.Rows[e.RowIndex].Cells[estado.Name].Value.ToString() == "ACTIVO")
                {
                    btnAnular.Text = "Anular";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 4;
                }
                else
                {
                    btnAnular.Text = "Activar";
                    btnAnular.Enabled = true;
                    btnAnular.ImageIndex = 6;
                }
            }
        }

        private void dgvVentasSeparacion_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvVentasSeparacion.Rows.Count >= 1 && e.Row.Selected)
            {
                sepa.CodSeparacion = Convert.ToInt32(e.Row.Cells[codigoFactura.Name].Value.ToString());
            }
        }

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void frmVentasSeparacioVer_Shown(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvVentasSeparacion.Rows.Count >= 1 && dgvVentasSeparacion.CurrentRow != null)
            {
                DataGridViewRow row = dgvVentasSeparacion.CurrentRow;
                if (dgvVentasSeparacion.Rows.Count >= 1)
                {
                    frmVenta form = new frmVenta();
                    form.MdiParent = this.MdiParent;
                    form.CodVenta = sepa.CodSeparacion.ToString();
                    form.Proceso = 3;
                    form.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

               /* CRReporteBoleta rpt = new CRReporteBoleta();
                frmRptFactura frm = new frmRptFactura();
                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rpt.PrintOptions;
                rptoption.PrinterName = ser.NombreImpresora;
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(ser.NombreImpresora, ser.PaperSize);
                rpt.SetDataSource(ds.ReporteBoleta(Convert.ToInt32(CodNota)).Tables[0]);
                frm.crvReporteFactura.ReportSource = rpt;
                frm.Show();*/

            
                CRListaVentasSeparacion rpt = new CRListaVentasSeparacion();
                frmListaVentasSeparacion frm = new frmListaVentasSeparacion();
                rpt.SetDataSource(ds.ReporteSeparacion(frmLogin.iCodAlmacen, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(cmbEstado.SelectedIndex)).Tables[0]);
                //rpt.SetDataSource(ds);
                frm.crvListaGuias.ReportSource = rpt;
                frm.Show();
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }
    }
}

       