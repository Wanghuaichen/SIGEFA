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
    public partial class frmProveedoresRP : Form
    {
        public DataTable DTable;

        public frmProveedoresRP()
        {
            InitializeComponent();
        }

        private void frmProveedoresRP_Load(object sender, EventArgs e)
        {

            CRProveedores CRep = new CRProveedores();
            CRep.Load("CRProveedores.rpt");
            CRep.SetDataSource(DTable);
            cRVProveedores.ReportSource = CRep;
        }
    }
}
