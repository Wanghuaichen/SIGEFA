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
    public partial class frmTransaccionesRP : Form
    {
        public DataTable DTable;

        public frmTransaccionesRP()
        {
            InitializeComponent();
        }

        private void frmTransaccionesRP_Load(object sender, EventArgs e)
        {
            CRTransacciones CRep = new CRTransacciones();
            CRep.Load("CRTransacciones.rpt");
            CRep.SetDataSource(DTable);
            cRVTransacciones.ReportSource = CRep;
        }
    }
}
