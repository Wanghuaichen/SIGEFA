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
    public partial class frmDetalleStock : Form
    {
        public Int32 CodProducto = 0;

        clsAdmOrdenCompra admOrden = new clsAdmOrdenCompra();

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        public frmDetalleStock()
        {
            InitializeComponent();
        }

        private void CargaDetalle()
        {
            dgvDetalleStock.DataSource = data;
            data.DataSource = admOrden.StockActualProducto(CodProducto);
            data.Filter = String.Empty;
            filtro = String.Empty;
            dgvDetalleStock.ClearSelection();
        }

        private void frmDetalleStock_Load(object sender, EventArgs e)
        {
            CargaDetalle();
        }
    }
}
