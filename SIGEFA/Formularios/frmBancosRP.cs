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
    public partial class frmBancosRP : Form
    {
        public DataTable DTable;

        public frmBancosRP()
        {
            InitializeComponent();
        }

        private void frmMarcasRP_Load(object sender, EventArgs e)
        {
            CRBancos CRep = new CRBancos();
            CRep.Load("CRBancos.rpt");
            CRep.SetDataSource(DTable); 
            cRVMarcas.ReportSource = CRep;
        }

        
    }
}
