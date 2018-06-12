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
    public partial class frmDocumentosRP : Form
    {
        public DataTable DTable;

        public frmDocumentosRP()
        {
            InitializeComponent();
        }

        private void frmDocumentosRP_Load(object sender, EventArgs e)
        {
            CRDocumentos CRep = new CRDocumentos();
            CRep.Load("CRDocumentos.rpt");
            CRep.SetDataSource(DTable);
            cRVDocumentos.ReportSource = CRep;
        }
    }
}
