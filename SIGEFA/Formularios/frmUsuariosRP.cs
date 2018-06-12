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
    public partial class frmUsuariosRP : Form
    {
        public DataTable DTable;

        public frmUsuariosRP()
        {
            InitializeComponent();
        }

        private void frmUsuariosRP_Load(object sender, EventArgs e)
        {
            CRUsuarios CRep = new CRUsuarios();
            CRep.Load("CRUsuarios.rpt");
            CRep.SetDataSource(DTable);
            cRVUsuarios.ReportSource = CRep;
        }
    }
}
