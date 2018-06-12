namespace SIGEFA.Formularios
{
    partial class frmListadoDeCajas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoDeCajas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCarjas = new System.Windows.Forms.DataGridView();
            this.codigo = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.montoapertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaapertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montocierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalsalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalventaefectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnIrPedido = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarjas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCarjas);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 296);
            this.panel1.TabIndex = 0;
            // 
            // dgvCarjas
            // 
            this.dgvCarjas.AllowUserToAddRows = false;
            this.dgvCarjas.AllowUserToDeleteRows = false;
            this.dgvCarjas.AllowUserToOrderColumns = true;
            this.dgvCarjas.AllowUserToResizeRows = false;
            this.dgvCarjas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCarjas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.montoapertura,
            this.fechaapertura,
            this.montocierre,
            this.fechacierre,
            this.totalingreso,
            this.totalsalida,
            this.totalventaefectivo});
            this.dgvCarjas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarjas.Location = new System.Drawing.Point(0, 0);
            this.dgvCarjas.MultiSelect = false;
            this.dgvCarjas.Name = "dgvCarjas";
            this.dgvCarjas.RowHeadersVisible = false;
            this.dgvCarjas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarjas.Size = new System.Drawing.Size(717, 296);
            this.dgvCarjas.TabIndex = 1;
            this.dgvCarjas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarjas_CellClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codcaja";
            this.codigo.HeaderText = "Codigo Caja";
            this.codigo.Name = "codigo";
            this.codigo.Visible = false;
            // 
            // montoapertura
            // 
            this.montoapertura.DataPropertyName = "montoapertura";
            this.montoapertura.HeaderText = "Monto apertura";
            this.montoapertura.Name = "montoapertura";
            // 
            // fechaapertura
            // 
            this.fechaapertura.DataPropertyName = "fechaapertura";
            this.fechaapertura.HeaderText = "Fecha de Apertura";
            this.fechaapertura.Name = "fechaapertura";
            // 
            // montocierre
            // 
            this.montocierre.DataPropertyName = "montocierre";
            this.montocierre.HeaderText = "Monto de Cierre";
            this.montocierre.Name = "montocierre";
            // 
            // fechacierre
            // 
            this.fechacierre.DataPropertyName = "fechacierre";
            this.fechacierre.HeaderText = "Fecha de Cierre";
            this.fechacierre.Name = "fechacierre";
            // 
            // totalingreso
            // 
            this.totalingreso.DataPropertyName = "totalIngreso";
            this.totalingreso.HeaderText = "Total Ingresos";
            this.totalingreso.Name = "totalingreso";
            // 
            // totalsalida
            // 
            this.totalsalida.DataPropertyName = "totalEgreso";
            this.totalsalida.HeaderText = "Total Salida";
            this.totalsalida.Name = "totalsalida";
            // 
            // totalventaefectivo
            // 
            this.totalventaefectivo.DataPropertyName = "totalVentaEfectivo";
            this.totalventaefectivo.HeaderText = "Venta de Efectivo";
            this.totalventaefectivo.Name = "totalventaefectivo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit.png");
            this.imageList1.Images.SetKeyName(1, "pedido.png");
            this.imageList1.Images.SetKeyName(2, "carrito.png");
            this.imageList1.Images.SetKeyName(3, "delete-file-icon.png");
            this.imageList1.Images.SetKeyName(4, "DeleteRed.png");
            this.imageList1.Images.SetKeyName(5, "document_delete.png");
            this.imageList1.Images.SetKeyName(6, "OK_Verde.png");
            this.imageList1.Images.SetKeyName(7, "document_print.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Add Green Button.png");
            this.imageList2.Images.SetKeyName(1, "Add.png");
            this.imageList2.Images.SetKeyName(2, "Remove.png");
            this.imageList2.Images.SetKeyName(3, "Write Document.png");
            this.imageList2.Images.SetKeyName(4, "New Document.png");
            this.imageList2.Images.SetKeyName(5, "Remove Document.png");
            this.imageList2.Images.SetKeyName(6, "1328102023_Copy.png");
            this.imageList2.Images.SetKeyName(7, "document-print.png");
            this.imageList2.Images.SetKeyName(8, "g-icon-new-update.png");
            this.imageList2.Images.SetKeyName(9, "refresh_256.png");
            this.imageList2.Images.SetKeyName(10, "Refresh-icon.png");
            this.imageList2.Images.SetKeyName(11, "search (1).png");
            this.imageList2.Images.SetKeyName(12, "search (5).png");
            this.imageList2.Images.SetKeyName(13, "search (6).png");
            this.imageList2.Images.SetKeyName(14, "search (8).png");
            this.imageList2.Images.SetKeyName(15, "search_top.png");
            this.imageList2.Images.SetKeyName(16, "icon-47203_640.png");
            this.imageList2.Images.SetKeyName(17, "Folder open.png");
            this.imageList2.Images.SetKeyName(18, "por-periodo-de-sesiones-icono-8745-96.png");
            this.imageList2.Images.SetKeyName(19, "img_visto.jpg");
            // 
            // btnIrPedido
            // 
            this.btnIrPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrPedido.ImageIndex = 1;
            this.btnIrPedido.ImageList = this.imageList1;
            this.btnIrPedido.Location = new System.Drawing.Point(670, 336);
            this.btnIrPedido.Name = "btnIrPedido";
            this.btnIrPedido.Size = new System.Drawing.Size(93, 37);
            this.btnIrPedido.TabIndex = 4;
            this.btnIrPedido.Text = "Consulta";
            this.btnIrPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIrPedido.UseVisualStyleBackColor = true;
            this.btnIrPedido.Click += new System.EventHandler(this.btnIrPedido_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(769, 336);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Desde :";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(208, 336);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 19;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(375, 336);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(508, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 32;
            this.button1.Text = "Actualizar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmListadoDeCajas
            // 
            this.ClientSize = new System.Drawing.Size(856, 385);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnIrPedido);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListadoDeCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado De Cajas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListadoDeCajas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarjas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCarjas;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoapertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaapertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn montocierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalsalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalventaefectivo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnIrPedido;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button button1;

    }
}