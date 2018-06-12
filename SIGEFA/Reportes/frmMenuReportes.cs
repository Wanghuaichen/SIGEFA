using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIGEFA.Formularios;

namespace SIGEFA.Reportes
{
    public partial class frmMenuReportes : DevComponents.DotNetBar.Office2007Form
    {
        public frmMenuReportes()
        {
            InitializeComponent();
        }

        private void tvRptFacturacion_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tvRptFacturacion.SelectedNode; //
            if (node.Name == "tvInfVentCC")
            {
                frmParamVentCredCont form = new frmParamVentCredCont();
                form.ShowDialog();
            }
            if (node.Name == "VentasSeparacion")
            {
                frmParamVentSeparacion form = new frmParamVentSeparacion();
                form.ShowDialog();
            }

            if (node.Name == "tvInfVentasxClient")
            {
                frmParamVentxCliente form = new frmParamVentxCliente();
                form.ShowDialog();
            }

            if (node.Name == "tvVentasMesArticulo")
            {
                frmParamVentasMesArticulo form = new frmParamVentasMesArticulo();
                form.criterio = 0; // (0) ARTICULO
                form.ShowDialog();
            }

            if (node.Name == "tvInfVentVende")
            {
                frmParamVentxVendedor form = new frmParamVentxVendedor();
                form.ShowDialog();
            }

            if (node.Name == "tvDespachoDocumento")
            {
                frmParamDespachoDocumento form = new frmParamDespachoDocumento();
                form.ShowDialog();
            }

            if (node.Name == "tvCobros")
            {
                frmParamCobrosDia form = new frmParamCobrosDia();
                form.ShowDialog();
            }

            if (node.Name == "tvPagosxDia")
            {
                frmParamPagosDia form = new frmParamPagosDia();
                form.ShowDialog();
            }

            if (node.Name == "tvArticulo")
            {
                frmParamRankingxArticulo form = new frmParamRankingxArticulo();
                form.ShowDialog();
            }

            if (node.Name == "tvCliente")
            {
                frmParamRankingxCliente form = new frmParamRankingxCliente();
                form.ShowDialog();
            }

            if (node.Name == "tvVentasxArticulo")
            {
                frmParamVentxArticulo form = new frmParamVentxArticulo();
                form.ShowDialog();
            }
            if (node.Name == "tvInfVentVendArt")
            {
                frmParamVentxArticuloxVendedor form = new frmParamVentxArticuloxVendedor();
                form.ShowDialog();
            }
            if (node.Name == "tvInfVentCCS")
            {
                frmParamVentCredContSucursal form = new frmParamVentCredContSucursal();
                form.ShowDialog();
            }
            if (node.Name == "tvCobranzas")
            {
                frmParamCobranzaSucursal form = new frmParamCobranzaSucursal();
                form.ShowDialog();
            }

            if (node.Name == "tvVentasxClient")
            {
                frmParamVentasXClientes form = new frmParamVentasXClientes();
                form.ShowDialog();
            }
            if (node.Name == "VentasUtilidad")
            {
                UtilidadVentas form = new UtilidadVentas();
                form.ShowDialog();
            }
            if (node.Name == "ProductosUtilidad")
            {
                UtilidadProductos form = new UtilidadProductos();
                form.ShowDialog();
            }
            if (node.Name == "ReporteCompras")
            {
                frmReporteCompras form = new frmReporteCompras();
                form.ShowDialog();
            }
        }

        private void tvInventarios_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tvRptInventarios.SelectedNode;
            if (node.Name == "tvInvStockArticulos")
            {
                frmReporteInventario form = new frmReporteInventario();
                form.ShowDialog();
            }

            if (node.Name == "tvInvStockArtMens")
            {
                FrmParamStockArticulosMensu form = new FrmParamStockArticulosMensu();
                form.ShowDialog();
            }

            if (node.Name == "tvKardex")
            {
                frmParamKardexArticulo form = new frmParamKardexArticulo();
                form.ShowDialog();
            }

            if (node.Name == "tvDespachoArticulo")
            {
                frmParamDespachoxArticulo form = new frmParamDespachoxArticulo();
                form.ShowDialog();
            }

            if (node.Name == "tvMercaderiaAtender")
            {
                frmParamMercaderiaEntregar form = new frmParamMercaderiaEntregar();
                form.ShowDialog();
            }
            if (node.Name == "tvInvAlmacenVendeMas")
            {
                frmAlmacenVendeMas form = new frmAlmacenVendeMas();
                form.ShowDialog();
            }
            
        }

        private void tvRptFacturacion_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void frmMenuReportes_Load(object sender, EventArgs e)
        {

        }
    }
}