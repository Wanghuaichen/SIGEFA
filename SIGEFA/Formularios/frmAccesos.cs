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
    public partial class frmAccesos : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmUsuario admUsu = new clsAdmUsuario();
        clsAdmEmpresa admEmp = new clsAdmEmpresa();
        clsAdmAlmacen admAlm = new clsAdmAlmacen();
        clsAdmFormulario admForm = new clsAdmFormulario();
        clsAdmAcceso admAcce = new clsAdmAcceso();
        public clsUsuario usu = new clsUsuario();
        clsAccesos acce = new clsAccesos();
        Int32 EmpresaSeleccionada;
        Int32 AlmacenSeleccionado;

        public List<Int32> codigos = new List<Int32>();




        public frmAccesos()
        {
            InitializeComponent();
        }

        private void frmAccesos_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            cmbEmpresa.SelectedValue = frmLogin.iCodEmpresa;
            EmpresaSeleccionada = Convert.ToInt32(cmbEmpresa.SelectedValue);
            CargaAlmacenes();            
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
            AlmacenSeleccionado = Convert.ToInt32(cmbAlmacen.SelectedValue);
            txtCodUsuario.Text = usu.CodUsuario.ToString();
            lbNombreUsuario.Text = usu.Nombre + " " + usu.Apellido;
            llenaarbol(0, null);
            CargaAccesos();
            
        }

        private void CargaEmpresas()
        {
            cmbEmpresa.DataSource = admEmp.CargaEmpresas();
            cmbEmpresa.DisplayMember = "razonsocial";
            cmbEmpresa.ValueMember = "codEmpresa";
            cmbEmpresa.SelectedIndex = -1;
        }

        private void CargaAlmacenes()
        {
            cmbAlmacen.DataSource = admAlm.CargaAlmacenes(frmLogin.iNivelUser, Convert.ToInt32(cmbEmpresa.SelectedValue), frmLogin.iCodUser);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedIndex = 0;

        }

        private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaAlmacenes();
        }

        private void llenaarbol(Int32 indicePadre, TreeNode nodoPadre)
        {
            DataView hijos = new DataView(admForm.MuestraFormularios());
            hijos.RowFilter = admForm.MuestraFormularios().Columns["padre"].ColumnName + " = " + indicePadre;

            foreach (DataRowView row in hijos)
            {
                TreeNode nuevonodo = new TreeNode();
                nuevonodo.Text = row["descripcion"].ToString();
                nuevonodo.Tag = row["codFormulario"].ToString();
                if (nodoPadre == null)
                {
                    tstvFormularios.Nodes.Add(nuevonodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodoPadre.Nodes.Add(nuevonodo);
                }
                llenaarbol(Int32.Parse(row["codFormulario"].ToString()), nuevonodo);
            }
        }

        private void RecorreArbol()
        {
            codigos.Clear();
            if (tstvFormularios.Enabled)
            {
                foreach (TreeNode nod in tstvFormularios.Nodes)
                {
                    añadenodos(nod);
                }
            }
            usu.CodigosForm = codigos;
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


        private void CargaAccesos()
        {
            codigos = admAcce.MuestraAccesos(usu.CodUsuario, Convert.ToInt32(cmbAlmacen.SelectedValue));
            foreach (TreeNode nod in tstvFormularios.Nodes)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            RecorreArbol();
            admAcce.LimpiarAccesos(usu.CodUsuario, Convert.ToInt32(cmbAlmacen.SelectedValue));   
            if (codigos.Count > 0)
            {                
                acce.CodUsuario = usu.CodUsuario;
                acce.CodAlmacen = AlmacenSeleccionado;
                acce.CodUser = frmLogin.iCodUser;
                foreach (Int32 formu in usu.CodigosForm)
                {
                    acce.CodFormulario = formu;
                    admAcce.insert(acce);
                }
            }
            MessageBox.Show("Los datos se guardaron correctamente", "Otorga Accesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGuardar.Enabled = false;
        }

        private void tstvFormularios_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
        }

        private void cmbEmpresa_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (btnGuardar.Enabled == true)
            {
                DialogResult dlgResult = MessageBox.Show("Desea cambiar de Empresa sin guardar los cambios hechos", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    cmbEmpresa.SelectedValue = EmpresaSeleccionada;
                }
                else
                {
                    EmpresaSeleccionada = Convert.ToInt32(cmbEmpresa.SelectedValue);
                    CargaAlmacenes();
                    CargaAccesos();
                }
            }
            else
            {
                EmpresaSeleccionada = Convert.ToInt32(cmbEmpresa.SelectedValue);
                CargaAlmacenes();
                CargaAccesos();
            }
        }

        private void cmbAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (btnGuardar.Enabled == true)
            {
                DialogResult dlgResult = MessageBox.Show("Desea cambiar de Almacen sin guardar los cambios hechos", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                {
                    cmbAlmacen.SelectedValue = AlmacenSeleccionado;
                }
                else
                {
                    AlmacenSeleccionado = Convert.ToInt32(cmbAlmacen.SelectedValue);
                    CargaAccesos();
                }
            }
            else
            {
                AlmacenSeleccionado = Convert.ToInt32(cmbAlmacen.SelectedValue);
                CargaAccesos();
            }
        }

        private void tstvFormularios_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnGuardar.Enabled = true;
        }
    }
}
