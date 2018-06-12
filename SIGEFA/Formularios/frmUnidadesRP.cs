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
    public partial class frmUnidadesRP : Form
    {
        public DataTable DTable;

        public frmUnidadesRP()
        {
            InitializeComponent();
        }

        private void frmUnidadesRP_Load(object sender, EventArgs e)
        {
            CRUnidades CRep = new CRUnidades();
            CRep.Load("CRUnidades.rpt");
            CRep.SetDataSource(DTable);
            cRVUnidades.ReportSource = CRep;
        }
    }
}
