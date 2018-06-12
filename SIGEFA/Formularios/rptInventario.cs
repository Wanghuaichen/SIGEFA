using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Reportes.clsReportes;
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class rptInventario : Form
    {
        public Int32 alma;
        public Boolean costo;
        public Boolean art;
        public Boolean fam;
        public Boolean lin;
        public Boolean gru;
        public Boolean tip;
        public Boolean todo;
        public Int32 art1;
        public Int32 art2;
        public Boolean cero;
        public Int32 orden;
        public Boolean activos;
        DataSet data = null;

        public rptInventario()
        {
            InitializeComponent();
        }

        private void rptInventario_Load(object sender, EventArgs e)
        {
            generareporte();
        }

        private void generareporte()
        {
            try
            {
                clsReportProductos re = new clsReportProductos();

                data = re.Inventario(alma, costo, art, fam, lin, gru, tip, todo, art1, art2, cero, orden, activos);
                CRInventario2 myDataReport = new CRInventario2();
                myDataReport.SetDataSource(data.Tables[0].DefaultView);
                crystalReportViewer1.ReportSource = myDataReport;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
