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
    public partial class frmProductosRP : Form
    {
        public DataTable DTable;

        public frmProductosRP()
        {
            InitializeComponent();
        }

        private void frmProductosRP_Load(object sender, EventArgs e)
        {
            CRProductos CRep = new CRProductos();
            CRep.Load("CRProductos.rpt");
            CRep.SetDataSource(DTable);
            cRVProductos.ReportSource = CRep;
        }
    }
}
