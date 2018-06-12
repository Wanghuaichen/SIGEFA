namespace SIGEFA.Formularios
{
    partial class frmVentasSeparacioVer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasSeparacioVer));
            this.button1 = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnIrPedido = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVistaSucursales = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvVentasSeparacion = new System.Windows.Forms.DataGridView();
            this.codigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldopen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldocan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cachedCRCuotasPrestamo1 = new SIGEFA.Reportes.clsReportes.CachedCRCuotasPrestamo();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasSeparacion)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageIndex = 8;
            this.button1.Location = new System.Drawing.Point(1316, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 44;
            this.button1.Text = "Actualizar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ImageIndex = 7;
            this.btnReporte.Location = new System.Drawing.Point(1479, 570);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(90, 37);
            this.btnReporte.TabIndex = 43;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1152, 579);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(979, 579);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Desde :";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(1032, 576);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 40;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(1199, 576);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 39;
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.ImageIndex = 4;
            this.btnAnular.Location = new System.Drawing.Point(568, 570);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(96, 37);
            this.btnAnular.TabIndex = 38;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            // 
            // btnIrPedido
            // 
            this.btnIrPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrPedido.ImageIndex = 1;
            this.btnIrPedido.Location = new System.Drawing.Point(1575, 570);
            this.btnIrPedido.Name = "btnIrPedido";
            this.btnIrPedido.Size = new System.Drawing.Size(93, 37);
            this.btnIrPedido.TabIndex = 37;
            this.btnIrPedido.Text = "Consulta";
            this.btnIrPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIrPedido.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.Location = new System.Drawing.Point(1674, 570);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 36;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnVistaSucursales
            // 
            this.btnVistaSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVistaSucursales.ImageIndex = 19;
            this.btnVistaSucursales.ImageList = this.imageList2;
            this.btnVistaSucursales.Location = new System.Drawing.Point(123, 468);
            this.btnVistaSucursales.Name = "btnVistaSucursales";
            this.btnVistaSucursales.Size = new System.Drawing.Size(92, 37);
            this.btnVistaSucursales.TabIndex = 55;
            this.btnVistaSucursales.Text = "Activar Vista";
            this.btnVistaSucursales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVistaSucursales.UseVisualStyleBackColor = true;
            this.btnVistaSucursales.Visible = false;
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
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ImageIndex = 9;
            this.button2.ImageList = this.imageList2;
            this.button2.Location = new System.Drawing.Point(825, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 37);
            this.button2.TabIndex = 54;
            this.button2.Text = "Actualizar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.ImageIndex = 7;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(988, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 37);
            this.button3.TabIndex = 53;
            this.button3.Text = "Reporte";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Hasta :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Desde :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(541, 474);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 50;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(708, 474);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 49;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.ImageIndex = 4;
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(1, 468);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 37);
            this.button4.TabIndex = 48;
            this.button4.Text = "Anular";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.ImageIndex = 1;
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point(1084, 468);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 37);
            this.button5.TabIndex = 47;
            this.button5.Text = "Consulta";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.ImageIndex = 0;
            this.button6.ImageList = this.imageList1;
            this.button6.Location = new System.Drawing.Point(1183, 468);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 37);
            this.button6.TabIndex = 46;
            this.button6.Text = "Salir";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvVentasSeparacion);
            this.groupBox1.Location = new System.Drawing.Point(-5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1275, 461);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // dgvVentasSeparacion
            // 
            this.dgvVentasSeparacion.AllowUserToAddRows = false;
            this.dgvVentasSeparacion.AllowUserToDeleteRows = false;
            this.dgvVentasSeparacion.AllowUserToOrderColumns = true;
            this.dgvVentasSeparacion.AllowUserToResizeRows = false;
            this.dgvVentasSeparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentasSeparacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoFactura,
            this.Fecha,
            this.codCliente,
            this.cliente,
            this.estado,
            this.pendiente,
            this.total,
            this.saldopen,
            this.saldocan,
            this.accion});
            this.dgvVentasSeparacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentasSeparacion.Location = new System.Drawing.Point(3, 16);
            this.dgvVentasSeparacion.MultiSelect = false;
            this.dgvVentasSeparacion.Name = "dgvVentasSeparacion";
            this.dgvVentasSeparacion.ReadOnly = true;
            this.dgvVentasSeparacion.RowHeadersVisible = false;
            this.dgvVentasSeparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentasSeparacion.Size = new System.Drawing.Size(1269, 442);
            this.dgvVentasSeparacion.TabIndex = 0;
            this.dgvVentasSeparacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentasSeparacion_CellClick);
            this.dgvVentasSeparacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentasSeparacion_CellContentClick);
            this.dgvVentasSeparacion.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvVentasSeparacion_RowStateChanged);
            // 
            // codigoFactura
            // 
            this.codigoFactura.DataPropertyName = "codFactura";
            this.codigoFactura.HeaderText = "Codigo Venta";
            this.codigoFactura.Name = "codigoFactura";
            this.codigoFactura.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha Registro";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // codCliente
            // 
            this.codCliente.DataPropertyName = "codcliente";
            this.codCliente.HeaderText = "Codigo Cliente";
            this.codCliente.Name = "codCliente";
            this.codCliente.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 300;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // pendiente
            // 
            this.pendiente.DataPropertyName = "pendiente";
            this.pendiente.HeaderText = "Situacion";
            this.pendiente.Name = "pendiente";
            this.pendiente.ReadOnly = true;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // saldopen
            // 
            this.saldopen.DataPropertyName = "salpen";
            this.saldopen.HeaderText = "Pendiente";
            this.saldopen.Name = "saldopen";
            this.saldopen.ReadOnly = true;
            // 
            // saldocan
            // 
            this.saldocan.DataPropertyName = "salcan";
            this.saldocan.HeaderText = "Cancelado";
            this.saldocan.Name = "saldocan";
            this.saldocan.ReadOnly = true;
            // 
            // accion
            // 
            this.accion.DataPropertyName = "accion";
            this.accion.HeaderText = "accion";
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            this.accion.Width = 200;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "CANCELADO",
            "PENDIENTE"});
            this.cmbEstado.Location = new System.Drawing.Point(344, 473);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 56;
            this.cmbEstado.SelectionChangeCommitted += new System.EventHandler(this.cmbEstado_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 481);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Estado de Pago";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmVentasSeparacioVer
            // 
            this.ClientSize = new System.Drawing.Size(1265, 506);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnVistaSucursales);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnIrPedido);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.Name = "frmVentasSeparacioVer";
            this.ShowInTaskbar = false;
            this.Text = "frmVentasSeparacioVer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVentasSeparacioVer_Load);
            this.Shown += new System.EventHandler(this.frmVentasSeparacioVer_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasSeparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnIrPedido;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnVistaSucursales;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVentasSeparacion;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldopen;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldocan;
        private System.Windows.Forms.DataGridViewLinkColumn accion;
        private Reportes.clsReportes.CachedCRCuotasPrestamo cachedCRCuotasPrestamo1;
    }
}