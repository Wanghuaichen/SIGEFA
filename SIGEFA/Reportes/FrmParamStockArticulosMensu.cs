using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;
using SIGEFA.Administradores;
using SIGEFA.Entidades;

namespace SIGEFA.Reportes
{
    public partial class FrmParamStockArticulosMensu : DevComponents.DotNetBar.Office2007Form
    {
        clsAdmAlmacen AdmAlm = new clsAdmAlmacen();
        clsAdmEmpresa AdmEmp = new clsAdmEmpresa();
        clsAdmProducto AdmPro = new clsAdmProducto();
        clsProducto pro = new clsProducto();
        clsAlmacen alma = new clsAlmacen();
        public Int32 codArticulo1;
        public Int32 codArticulo2;

        public FrmParamStockArticulosMensu()
        {
            InitializeComponent();
        }

        private void FrmParamStockArticulosMensu_Load(object sender, EventArgs e)
        {
            carga_almacen();
            cmbAlmacen.SelectedValue = frmLogin.iCodAlmacen;
            rbTodos.Checked = true;
            cbArticulos.Checked = true;
        }

        private void rbRango_CheckedChanged(object sender, EventArgs e)
        {
            txtInicio.Enabled = rbRango.Checked;
            txtFin.Enabled = rbRango.Checked;
            label1.Enabled = rbRango.Checked;
            label2.Enabled = rbRango.Checked;
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
    }
}
