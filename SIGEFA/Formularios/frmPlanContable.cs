using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;

namespace SIGEFA.Formularios
{
    public partial class frmPlanContable : Form
    {       
        DataTable Arbol = new DataTable();
        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;
        clsAdmPlanContable admplan = new clsAdmPlanContable();

        public frmPlanContable()
        {
            InitializeComponent();            
        }

        Int32 codplan = 0;       
        private Int32 RetornaCodPlan() {
            DataTable dt = new DataTable();
            //dt = admplantilla.ListaDestino();
            foreach (DataRow row in dt.Rows) {
                codplan =Convert.ToInt32(row[0]);
            }
            return codplan;
        }

        private void ConsultarArbol() {
            //RetornaCodPlan();
            //Arbol = admplan.ListaPlanContableArbol(codplan,frmLogin.iCodEmpresa);
            Arbol = admplan.ListaPlanContableArbol();
        }

        private void llenaarbol(Int32 nivel, Int32 indicePadre, TreeNode nodoPadre)
        {
            DataView hijos = new DataView(Arbol);
            hijos.RowFilter = Arbol.Columns["codpadre"].ColumnName + " = " + indicePadre;
            hijos.RowFilter += " AND " + Arbol.Columns["nivel"].ColumnName + " = " + nivel;
            foreach (DataRowView row in hijos)
            {
                TreeNode nuevonodo = new TreeNode();
                nuevonodo.Text = row["descripcion"].ToString();
                nuevonodo.Tag = row["codigo"].ToString();
               
                if (nodoPadre == null)
                {
                    nuevonodo.NodeFont = new Font("Arial", 8, FontStyle.Bold);
                    tvClasificacion.Nodes.Add(nuevonodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodoPadre.Nodes.Add(nuevonodo);
                }

                llenaarbol(nivel + 1, Int32.Parse(row["codigo"].ToString()), nuevonodo);
            }
        }         

        private void frmPlanContable_Load(object sender, EventArgs e)
        {
            ConsultarArbol();
            llenaarbol(0, 0, null);
        }

        


    }
}
