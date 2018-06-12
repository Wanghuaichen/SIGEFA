namespace SIGEFA.Reportes
{
    partial class frmMenuReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Ventas Contado/Crédito");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ventas por Separación");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Ventas por Vendedor");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Ventas por Vendedor por Articulo");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Ventas por Cliente");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Ventas x Articulo");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Despacho x N° Documento");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Cobros x Día");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Pagos x Día");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Ventas Utilidad");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Productos Uilidad");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Informes Diarios", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Ventas Mensuales por Artículo");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Ventas Mensuales", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Ventas Contado/Crédito");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Cobranzas");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Informes Por Sucursal", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Reportes General");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Stock de Artículos");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Almacen Que Vende Más");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Kardex de Artículos");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Inventario en Unidades", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Despacho x Artículo");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("MercaderiaPorEntregar");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Documentos de Almacen", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24});
            this.tvRptFacturacion = new System.Windows.Forms.TreeView();
            this.tvRptInventarios = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvRptFacturacion
            // 
            this.tvRptFacturacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvRptFacturacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvRptFacturacion.Location = new System.Drawing.Point(0, 29);
            this.tvRptFacturacion.Name = "tvRptFacturacion";
            treeNode1.Name = "tvInfVentCC";
            treeNode1.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.SelectedImageIndex = -2;
            treeNode1.Text = "Ventas Contado/Crédito";
            treeNode2.Name = "VentasSeparacion";
            treeNode2.Text = "Ventas por Separación";
            treeNode3.Name = "tvInfVentVende";
            treeNode3.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.Text = "Ventas por Vendedor";
            treeNode4.Name = "tvInfVentVendArt";
            treeNode4.NodeFont = new System.Drawing.Font("Courier New", 9.75F);
            treeNode4.Text = "Ventas por Vendedor por Articulo";
            treeNode5.Name = "tvInfVentasxClient";
            treeNode5.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Ventas por Cliente";
            treeNode6.Name = "tvVentasxArticulo";
            treeNode6.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Ventas x Articulo";
            treeNode7.Name = "tvDespachoDocumento";
            treeNode7.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode7.Text = "Despacho x N° Documento";
            treeNode8.Name = "tvCobros";
            treeNode8.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode8.Text = "Cobros x Día";
            treeNode9.Name = "tvPagosxDia";
            treeNode9.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode9.Text = "Pagos x Día";
            treeNode10.Name = "VentasUtilidad";
            treeNode10.Text = "Ventas Utilidad";
            treeNode11.Name = "ProductosUtilidad";
            treeNode11.Text = "Productos Uilidad";
            treeNode12.Name = "tvInformes";
            treeNode12.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode12.Text = "Informes Diarios";
            treeNode13.Name = "tvVentasMesArticulo";
            treeNode13.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode13.Text = "Ventas Mensuales por Artículo";
            treeNode14.Name = "Node19";
            treeNode14.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode14.Text = "Ventas Mensuales";
            treeNode15.Name = "tvInfVentCCS";
            treeNode15.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode15.Text = "Ventas Contado/Crédito";
            treeNode16.Name = "tvCobranzas";
            treeNode16.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode16.Text = "Cobranzas";
            treeNode17.Name = "tvInformesSucursal";
            treeNode17.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode17.Text = "Informes Por Sucursal";
            treeNode18.Name = "ReporteCompras";
            treeNode18.NodeFont = new System.Drawing.Font("Courier New", 11.25F);
            treeNode18.Text = "Reportes General";
            this.tvRptFacturacion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode14,
            treeNode17,
            treeNode18});
            this.tvRptFacturacion.Size = new System.Drawing.Size(322, 190);
            this.tvRptFacturacion.TabIndex = 0;
            this.tvRptFacturacion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRptFacturacion_AfterSelect);
            this.tvRptFacturacion.DoubleClick += new System.EventHandler(this.tvRptFacturacion_DoubleClick);
            // 
            // tvRptInventarios
            // 
            this.tvRptInventarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvRptInventarios.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvRptInventarios.Location = new System.Drawing.Point(328, 29);
            this.tvRptInventarios.Name = "tvRptInventarios";
            treeNode19.Name = "tvInvStockArticulos";
            treeNode19.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode19.SelectedImageIndex = -2;
            treeNode19.Text = "Stock de Artículos";
            treeNode20.Name = "tvInvAlmacenVendeMas";
            treeNode20.NodeFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode20.Text = "Almacen Que Vende Más";
            treeNode21.Name = "tvKardex";
            treeNode21.NodeFont = new System.Drawing.Font("Courier New", 11.25F);
            treeNode21.Text = "Kardex de Artículos";
            treeNode22.Name = "tvInformes";
            treeNode22.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode22.Text = "Inventario en Unidades";
            treeNode23.Name = "tvDespachoArticulo";
            treeNode23.NodeFont = new System.Drawing.Font("Courier New", 11.25F);
            treeNode23.Text = "Despacho x Artículo";
            treeNode24.Name = "tvMercaderiaAtender";
            treeNode24.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode24.Text = "MercaderiaPorEntregar";
            treeNode25.Name = "Node28";
            treeNode25.NodeFont = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode25.Text = "Documentos de Almacen";
            this.tvRptInventarios.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode25});
            this.tvRptInventarios.Size = new System.Drawing.Size(327, 190);
            this.tvRptInventarios.TabIndex = 1;
            this.tvRptInventarios.DoubleClick += new System.EventHandler(this.tvInventarios_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FACTURACIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "INVENTARIOS";
            // 
            // frmMenuReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 222);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvRptInventarios);
            this.Controls.Add(this.tvRptFacturacion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenuReportes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.frmMenuReportes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvRptFacturacion;
        private System.Windows.Forms.TreeView tvRptInventarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}