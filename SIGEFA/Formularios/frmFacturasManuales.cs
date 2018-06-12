using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SIGEFA.Formularios
{
    public partial class frmFacturasManuales : DevComponents.DotNetBar.Office2007Form
    {
        public List<Int32> num_correlativo = new List<Int32>();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        public DataTable tabla = new DataTable();

        public frmFacturasManuales()
        {
            InitializeComponent();
        }

        private Int32 i = 0;
        private void llena_grilla()
        {
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "NumeroSerie";
            tabla.Columns.Add(column);
            
            foreach (Int32 c in num_correlativo)
            {
                if (i < num_correlativo.Count)
                {
                    row = tabla.NewRow();
                    row["NumeroSerie"] = c;
                    tabla.Rows.Add(row);
                    i++;
                }
            }
            dgvNumSerie.DataSource = tabla;
            
        }

        private void frmFacturasManuales_Load(object sender, EventArgs e)
        {
            //dgvNumSerie.DataSource = tabla;
            llena_grilla();
        }

        private void dgvNumSerie_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvNumSerie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmVenta frm = (frmVenta)Application.OpenForms["frmVenta"];
            frm.Proceso = 1;
            frm.Procede = 4;
            frm.numSerie = tabla.Rows[e.RowIndex][0].ToString();
            frm.txtNumero.Text = frm.numSerie;
            frm.dtpFecha.MinDate = frm.fecha1;
            frm.dtpFecha.MaxDate = frm.fecha2;
            frm.Show();
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmVenta frm = (frmVenta)Application.OpenForms["frmVenta"];
            frm.Proceso = 1;
            frm.Procede = 4;
            frm.numSerie = tabla.Rows[0]["NumeroSerie"].ToString();
            frm.txtNumero.Text = frm.numSerie;
            frm.dtpFecha.MinDate = frm.fecha1;
            frm.dtpFecha.MaxDate = frm.fecha2;
            frm.Show();
            Close();
        }

    }
}
