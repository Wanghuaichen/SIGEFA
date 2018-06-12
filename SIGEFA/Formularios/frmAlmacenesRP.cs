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
    public partial class frmAlmacenesRP : Form
    {
        public DataTable DTable;
        
        public frmAlmacenesRP()
        {
            InitializeComponent();
        }

        private void frmAlmacenesRP_Load(object sender, EventArgs e)
        {
            CRAlmacenes CRep = new CRAlmacenes();
            CRep.Load("CRAlmacenes.rpt");
            CRep.SetDataSource(DTable);
            cRVAlmacenes.ReportSource = CRep;
        }
    }
}
