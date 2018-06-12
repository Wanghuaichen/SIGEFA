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
//using SIGEFA.SunatFacElec;
using SIGEFA.Reportes.clsReportes;

namespace SIGEFA.Formularios
{
    public partial class frmDespachos : DevComponents.DotNetBar.Office2007Form
    {
        clsReporteFactura ds = new clsReporteFactura();
        clsAdmFacturaVenta AdmVenta = new clsAdmFacturaVenta();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public Int32 codfactura = 0;

        public frmDespachos()
        {
            InitializeComponent();
        }

        private void frmDespachos_Load(object sender, EventArgs e)
        {
            cargalista();
        }

        private void cargalista()
        {
            dgvVentas.DataSource = data;
            data.DataSource = AdmVenta.despachosxventa(codfactura);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvVentas.ClearSelection();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmLogin.iCodAlmacen != 0)
                {

                    frmRptFactura frm = new frmRptFactura();
                    CRSalidaDespacho rpt = new CRSalidaDespacho();
                    rpt.Load("CRSalidaDespacho.rpt");
                    rpt.SetDataSource(ds.salidadespacho(codfactura, Convert.ToInt32(dgvVentas.CurrentRow.Cells[CodDespacho.Name].Value)));
                    frm.crvReporteFactura.ReportSource = rpt;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
