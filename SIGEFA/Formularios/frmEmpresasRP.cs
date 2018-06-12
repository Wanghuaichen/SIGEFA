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
    public partial class frmEmpresasRP : Form
    {
        public DataTable DTable;

        public frmEmpresasRP()
        {
            InitializeComponent();
        }

        private void frmEmpresasRP_Load(object sender, EventArgs e)
        {

            CREmpresas CRep = new CREmpresas();
            CRep.Load("CREmpresas.rpt");
            CRep.SetDataSource(DTable);
            cRVEmpresas.ReportSource = CRep;
        }
    }
}
