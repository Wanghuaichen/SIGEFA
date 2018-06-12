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
    public partial class frmTipoArticulosRP : Form
    {
        public DataTable DTable;

        public frmTipoArticulosRP()
        {
            InitializeComponent();
        }

        private void frmTipoArticulosRP_Load(object sender, EventArgs e)
        {
            CRTipoArticulos CRep = new CRTipoArticulos();
            CRep.Load("CRTipoArticulos.rpt");
            CRep.SetDataSource(DTable);
            cRVTipoArticulos.ReportSource = CRep;
        }
    }
}
