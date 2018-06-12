using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Formularios
{
    public partial class frmAccesosSucursal : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAccesoSucursales AdmAcceSuc = new clsAdmAccesoSucursales();
        clsAccesosSucursales AcceSuc = new clsAccesosSucursales();
        clsAdmSucursal AdmSuc = new clsAdmSucursal();
        clsSucursal suc = new clsSucursal();
        clsAdmFormulario admForm = new clsAdmFormulario();
        public clsUsuario usu = new clsUsuario();

        DataTable Arbol = new DataTable();
        public List<Int32> codigos = new List<Int32>();




        public frmAccesosSucursal()
        {
            InitializeComponent();
        }

        private void ConsultaArbol()
        {
            Arbol = AdmSuc.CargaSucursalesSeleccion(frmLogin.iCodEmpresa);
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
                    tvSeleccionAlmacenes.Nodes.Add(nuevonodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodoPadre.Nodes.Add(nuevonodo);
                }

                llenaarbol(nivel + 1, Int32.Parse(row["codigo"].ToString()), nuevonodo);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecorreArbol()
        {
            codigos.Clear();
            if (tvSeleccionAlmacenes.Enabled)
            {
                foreach (TreeNode nod in tvSeleccionAlmacenes.Nodes)
                {
                    añadenodos(nod);
                }
            }
            suc.CodigosForm = codigos;
        }

        private void añadenodos(TreeNode nod)
        {
            if (nod.StateImageIndex == (int)CheckState.Checked)
            {
                codigos.Add(Convert.ToInt32(nod.Tag));
            }
            if (nod.Nodes.Count > 0)
            {
                foreach (TreeNode tn in nod.Nodes)
                {
                    añadenodos(tn);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            RecorreArbol();
            AdmAcceSuc.LimpiarAccesos(usu.CodUsuario, frmLogin.iCodEmpresa);
            if (codigos.Count > 0)
            {
                AcceSuc.CodUsuario = usu.CodUsuario;
                AcceSuc.CodEmpresa = frmLogin.iCodEmpresa;
                AcceSuc.CodUser = frmLogin.iCodUser;
                foreach (Int32 formu in suc.CodigosForm)
                {
                    AcceSuc.CodSucursal = formu;
                    AdmAcceSuc.insert(AcceSuc);
                }
            }
            MessageBox.Show("Los datos se guardaron correctamente", "Otorga Accesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGuardar.Enabled = false;
        } 

        private void tvSeleccionAlmacenes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnGuardar.Enabled = true;
        }

        private void CargaAccesos()
        {
            codigos = AdmAcceSuc.MuestraAccesosSucursales(usu.CodUsuario, frmLogin.iCodEmpresa);
            foreach (TreeNode nod in tvSeleccionAlmacenes.Nodes)
            {
                marcanodo(nod);
            }
        }

        private void marcanodo(TreeNode nod)
        {
            Int32 codi = Convert.ToInt32(nod.Tag);
            if (codigos.Contains(codi))
            {
                nod.Checked = true;
            }
            else
            {
                nod.Checked = false;
            }
            if (nod.Nodes.Count > 0)
            {
                foreach (TreeNode tn in nod.Nodes)
                {
                    marcanodo(tn);
                }
            }
        }

        private void frmAccesosSucursal_Load(object sender, EventArgs e)
        {
            //CargaAccesos();
        }

        private void frmAccesosSucursal_Shown(object sender, EventArgs e)
        {
            ConsultaArbol();
            llenaarbol(0, 0, null);
            tvSeleccionAlmacenes.ExpandAll();

            CargaAccesos();
        }
    }
}
