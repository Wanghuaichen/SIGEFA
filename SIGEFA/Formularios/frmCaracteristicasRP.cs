using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Reportes;

namespace SIGEFA.Formularios
{
    public partial class frmCaracteristicasRP : Form
    {
        public DataTable DTable;

        public frmCaracteristicasRP()
        {
            InitializeComponent();
        }

        private void frmCaracteristicasRP_Load(object sender, EventArgs e)
        {
            CRCaracteristicas CRep = new CRCaracteristicas();
            CRep.Load("CRCaracteristicas.rpt");
            CRep.SetDataSource(DTable);
            cRVCaracteristicas.ReportSource = CRep;
        }
    }
}
