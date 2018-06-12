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
    public partial class frmCuentasCorrienteRP : Form
    {
        public DataTable DTable;

        public frmCuentasCorrienteRP()
        {
            InitializeComponent();
        }

        private void frmCuentasCorrienteRP_Load(object sender, EventArgs e)
        {
            CRCtasCte CRep = new CRCtasCte();
            CRep.Load("CRCtasCte.rpt");
            CRep.SetDataSource(DTable);
            CRVCtasCte.ReportSource = CRep;
        }
    }
}
