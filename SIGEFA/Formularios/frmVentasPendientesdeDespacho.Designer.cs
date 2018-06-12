namespace SIGEFA.Formularios
{
    partial class frmVentasPendientesdeDespacho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasPendientesdeDespacho));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.documento = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codcliente = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.fechapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.impreso = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIrPedido = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MuestraDespachosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvVentas);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas Pendientes de Despacho";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AllowUserToResizeRows = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.fecha,
            this.documento,
            this.numdoc,
            this.codcliente,
            this.cliente,
            this.moneda,
            this.importe,
            this.formapago,
            this.fechapago,
            this.estado,
            this.impreso});
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(3, 16);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(875, 311);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVentas_CellMouseDown);
            this.dgvVentas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVentas_CurrentCellDirtyStateChanged);
            this.dgvVentas.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPedidosPendientes_RowStateChanged);
            this.dgvVentas.Click += new System.EventHandler(this.dgvVentas_Click);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codFactura";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Visible = false;
            this.codigo.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fecha.Width = 80;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.documento.DefaultCellStyle = dataGridViewCellStyle3;
            this.documento.HeaderText = "T. doc.";
            this.documento.Name = "documento";
            this.documento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.documento.Width = 60;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "N° Documento";
            this.numdoc.Name = "numdoc";
            // 
            // codcliente
            // 
            this.codcliente.DataPropertyName = "codcliente";
            this.codcliente.HeaderText = "Cod. Cliente";
            this.codcliente.Name = "codcliente";
            this.codcliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codcliente.Visible = false;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cliente.Width = 270;
            // 
            // moneda
            // 
            this.moneda.DataPropertyName = "moneda";
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            // 
            // importe
            // 
            this.importe.DataPropertyName = "total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // formapago
            // 
            this.formapago.DataPropertyName = "formapago";
            this.formapago.HeaderText = "F. pago";
            this.formapago.Name = "formapago";
            this.formapago.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formapago.Visible = false;
            // 
            // fechapago
            // 
            this.fechapago.DataPropertyName = "fechapago";
            this.fechapago.HeaderText = "Fech. Pago";
            this.fechapago.Name = "fechapago";
            this.fechapago.Visible = false;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "anulado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // impreso
            // 
            this.impreso.DataPropertyName = "impreso";
            this.impreso.HeaderText = "Impreso";
            this.impreso.Name = "impreso";
            this.impreso.Visible = false;
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
            this.imageList1.Images.SetKeyName(8, "docbaj.png");
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-15, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Desde :";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(38, 347);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 15;
            this.dtpDesde.CloseUp += new System.EventHandler(this.dtpDesde_CloseUp);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(205, 347);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 14;
            this.dtpHasta.CloseUp += new System.EventHandler(this.dtpHasta_CloseUp);
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
            // btnActualizarLista
            // 
            this.btnActualizarLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActualizarLista.ImageIndex = 8;
            this.btnActualizarLista.ImageList = this.imageList2;
            this.btnActualizarLista.Location = new System.Drawing.Point(322, 338);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(93, 37);
            this.btnActualizarLista.TabIndex = 31;
            this.btnActualizarLista.Text = "Actualizar Lista";
            this.btnActualizarLista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarLista.UseVisualStyleBackColor = true;
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ImageIndex = 7;
            this.btnReporte.ImageList = this.imageList1;
            this.btnReporte.Location = new System.Drawing.Point(599, 336);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(90, 37);
            this.btnReporte.TabIndex = 30;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(794, 336);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIrPedido
            // 
            this.btnIrPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrPedido.Enabled = false;
            this.btnIrPedido.ImageIndex = 1;
            this.btnIrPedido.ImageList = this.imageList1;
            this.btnIrPedido.Location = new System.Drawing.Point(695, 336);
            this.btnIrPedido.Name = "btnIrPedido";
            this.btnIrPedido.Size = new System.Drawing.Size(93, 37);
            this.btnIrPedido.TabIndex = 32;
            this.btnIrPedido.Text = "Consulta";
            this.btnIrPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIrPedido.UseVisualStyleBackColor = true;
            this.btnIrPedido.Click += new System.EventHandler(this.btnIrPedido_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuestraDespachosToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 32);
            // 
            // MuestraDespachosToolStripMenuItem
            // 
            this.MuestraDespachosToolStripMenuItem.Name = "MuestraDespachosToolStripMenuItem";
            this.MuestraDespachosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MuestraDespachosToolStripMenuItem.Text = "Muestra Entregas";
            this.MuestraDespachosToolStripMenuItem.Click += new System.EventHandler(this.muestraPagosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // frmVentasPendientesdeDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 385);
            this.Controls.Add(this.btnIrPedido);
            this.Controls.Add(this.btnActualizarLista);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVentasPendientesdeDespacho";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas Pendientes de Despacho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidosPendientes_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnActualizarLista;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnIrPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn fecha;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn codcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn formapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapago;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn estado;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn impreso;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MuestraDespachosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}