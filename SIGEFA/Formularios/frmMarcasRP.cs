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
    public partial class frmMarcasRP : Form
    {
        public DataTable DTable;

        public frmMarcasRP()
        {
            InitializeComponent();
        }

        private void frmMarcasRP_Load(object sender, EventArgs e)
        {
            CRMarcas CRep = new CRMarcas();
            CRep.Load("CRMarcas.rpt");
            CRep.SetDataSource(DTable);
            cRVMarcas.ReportSource = CRep;
        }
    }
}
