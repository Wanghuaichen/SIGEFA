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
    public partial class frmGestionTipoEgresoRP : Form
    {
        public DataTable DTable;

        public frmGestionTipoEgresoRP()
        {
            InitializeComponent();
        }

        private void frmGestionTipoEgresoRP_Load(object sender, EventArgs e)
        {
            CRTipoEgresoCaja CRep = new CRTipoEgresoCaja();
            CRep.Load("CRTipoEgresoCaja.rpt");
            CRep.SetDataSource(DTable);
            cRVTipoEgresoCaja.ReportSource = CRep;
        }
    }
}
