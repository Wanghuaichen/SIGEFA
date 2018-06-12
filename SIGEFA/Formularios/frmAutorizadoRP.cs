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
    public partial class frmAutorizadoRP : Form
    {
        public DataTable DTable;
        public frmAutorizadoRP()
        {
            InitializeComponent();
        }

        private void frmAutorizadoRP_Load(object sender, EventArgs e)
        {
            CRAutorizado CRep = new CRAutorizado();
            CRep.Load("CRAutorizado.rpt");
            CRep.SetDataSource(DTable);
            cRVAutorizado.ReportSource = CRep;
        }
    }
}
