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
    public partial class frmCatalogoRP : Form
    {
        public DataTable DTable;

        public frmCatalogoRP()
        {
            InitializeComponent();
        }

        private void frmProductosRP_Load(object sender, EventArgs e)
        {
            CRCatalogoPrecios CRep = new CRCatalogoPrecios();
            CRep.Load("CRCatalogoPrecios.rpt");
            CRep.SetDataSource(DTable);
            cRVProductos.ReportSource = CRep;
        }
    }
}
