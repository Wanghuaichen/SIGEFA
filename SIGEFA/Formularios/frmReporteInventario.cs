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
    public partial class frmReporteInventario : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAlmacen AdmAlm = new clsAdmAlmacen();
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto pro = new clsProducto();
        clsAlmacen alma = new clsAlmacen();      
        public Int32 codArticulo1;
        public Int32 codArticulo2;
        public Int32 CodLista = 0;


        public frmReporteInventario()
        {
            InitializeComponent();
        }

        private void frmReporteInventario_Load(object sender, EventArgs e)
        {
            carga_almacen();
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
            rbTodos.Checked = true;
            cbArticulos.Checked = true;
            cmbOrden.SelectedIndex = 0;
        }

        private void carga_almacen()
        {
            cmbAlmacen.DataSource = AdmAlm.CargaAlmacenes(frmLogin.iNivelUser, frmLogin.iCodEmpresa, frmLogin.iCodUser);
            cmbAlmacen.DisplayMember = "nombre";
            cmbAlmacen.ValueMember = "codAlmacen";
            cmbAlmacen.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                rptInventario frm = new rptInventario();
                frm.alma = Convert.ToInt32(cmbAlmacen.SelectedValue);
                frm.costo = cbCosto.Checked;
                frm.art = cbArticulos.Checked;
                frm.fam = cbFamilias.Checked;
                frm.lin = cbLineas.Checked;
                frm.gru = cbGrupos.Checked;
                frm.tip = cbTipos.Checked;
                frm.todo = rbTodos.Checked;
                frm.art1 = codArticulo1;
                frm.art2 = codArticulo2;
                frm.cero = cbCero.Checked;
                frm.activos = cbActivos.Checked;
                frm.orden = Convert.ToInt32(cmbOrden.SelectedIndex);
                frm.ShowDialog();
            }
            catch (Exception ex) {MessageBox.Show(ex.Message,"Reporte_Inventario"); }
        }

        private void txtInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosListaReport frm = new frmProductosListaReport();
                frm.Proceso = 3;
                frm.Inicio = 0;
                frm.codAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
                frm.ShowDialog();
                codArticulo1 = frm.pro.CodProducto;
                txtInicio.Text = frm.pro.Referencia;
            }
        }

        private void rbRango_CheckedChanged(object sender, EventArgs e)
        {
            txtInicio.Enabled = rbRango.Checked;
            txtFin.Enabled = rbRango.Checked;
            label1.Enabled = rbRango.Checked;
            label2.Enabled = rbRango.Checked;
        }

        private void customValidator1_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator2_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator3_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate.Text != "")
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void customValidator4_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (codArticulo2 < codArticulo1)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private void txtFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmProductosListaReport frm = new frmProductosListaReport();
                frm.Proceso = 3;
                frm.Inicio = codArticulo1;
                frm.codAlmacen = Convert.ToInt32(cmbAlmacen.SelectedValue);
                frm.ShowDialog();
                codArticulo2 = frm.pro.CodProducto;
                txtFin.Text = frm.pro.Referencia;
            }
        }

        private void txtFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtFin.Text != "")
                {
                    if (BuscaProducto(txtFin.Text))
                    {
                        ProcessTabKey(true);
                        codArticulo2 = pro.CodProducto;
                        txtFin.Text = pro.Referencia;
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtInicio.Text != "")
                {
                    if (BuscaProducto(txtInicio.Text))
                    {
                        ProcessTabKey(true);
                        codArticulo1 = pro.CodProducto;
                        txtInicio.Text = pro.Referencia;
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe, Presione F1 para consultar la tabla de ayuda", "DETALLE DE ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Boolean BuscaProducto(String referencia)
        {
            pro = AdmPro.CargaProductoDetalleR(referencia, Convert.ToInt32(cmbAlmacen.SelectedValue), 2, CodLista);
            if (pro != null)
            {                
                return true;
            }
            else
            {                                
                return false;
            }
        }

    }
}
