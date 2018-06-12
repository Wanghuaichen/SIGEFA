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
    public partial class frmFamiliasRP : Form
    {
        public DataTable DTable;

        public frmFamiliasRP()
        {
            InitializeComponent();
        }

        private void frmFamiliasRP_Load(object sender, EventArgs e)
        {

            CRFamilias CRep = new CRFamilias();
            CRep.Load("CRFamilias.rpt");
            CRep.SetDataSource(DTable);
            cRVFamilias.ReportSource = CRep;
        }
    }
}
