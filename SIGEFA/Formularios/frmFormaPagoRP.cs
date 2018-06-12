using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Reportes;
using SIGEFA.Reportes.clsReportes;


namespace SIGEFA.Formularios
{
    public partial class frmFormaPagoRP : Form
    {
        public DataSet data = null;

        public frmFormaPagoRP()
        {
            InitializeComponent();
        }

        private void frmFormaPagoRP_Load(object sender, EventArgs e)
        {
            generareporte();
        }

        private void generareporte()
        {
            clsDocumentosImpresos doc = new clsDocumentosImpresos();
            try
            {
                data = doc.FormaPago();
                CRFormaPago myDataReport = new CRFormaPago();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                cRVFormaPago.ReportSource = myDataReport;

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
