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
    public partial class frmTipoCambioRP : Form
    {
        public DataTable DTable;

        public frmTipoCambioRP()
        {
            InitializeComponent();
        }

        private void frmTipoCambioRP_Load(object sender, EventArgs e)
        {
            CRTipoCambio CRep = new CRTipoCambio();
            CRep.Load("CRTipoCambio.rpt");
            CRep.SetDataSource(DTable);
            cRVTipoCambio.ReportSource = CRep;
        }
    }
}
