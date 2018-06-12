namespace SIGEFA.Formularios
{
    partial class frmPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.codnota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codproveedore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechavenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numcuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numunico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.muestraPagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjearPorLetraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nuevaLetraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarLetraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirLetraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoABancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add Green Button.png");
            this.imageList1.Images.SetKeyName(1, "Add.png");
            this.imageList1.Images.SetKeyName(2, "Remove.png");
            this.imageList1.Images.SetKeyName(3, "Write Document.png");
            this.imageList1.Images.SetKeyName(4, "New Document.png");
            this.imageList1.Images.SetKeyName(5, "Remove Document.png");
            this.imageList1.Images.SetKeyName(6, "1328102023_Copy.png");
            this.imageList1.Images.SetKeyName(7, "document-print.png");
            this.imageList1.Images.SetKeyName(8, "g-icon-new-update.png");
            this.imageList1.Images.SetKeyName(9, "refresh_256.png");
            this.imageList1.Images.SetKeyName(10, "Refresh-icon.png");
            this.imageList1.Images.SetKeyName(11, "search (1).png");
            this.imageList1.Images.SetKeyName(12, "search (5).png");
            this.imageList1.Images.SetKeyName(13, "search (6).png");
            this.imageList1.Images.SetKeyName(14, "search (8).png");
            this.imageList1.Images.SetKeyName(15, "search_top.png");
            this.imageList1.Images.SetKeyName(16, "folder_open (1).png");
            this.imageList1.Images.SetKeyName(17, "folder-open-icon.png");
            this.imageList1.Images.SetKeyName(18, "Glossy-Open-icon.png");
            this.imageList1.Images.SetKeyName(19, "Ocean Blue Open.png");
            this.imageList1.Images.SetKeyName(20, "Open (1).png");
            this.imageList1.Images.SetKeyName(21, "open_folder_green.png");
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageIndex = 11;
            this.btnBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.SubItemsExpandWidth = 14;
            this.btnBuscar.Text = "Buscar";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImageIndex = 11;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "Buscar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbEmpresa);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Controls.Add(this.btnReporte);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.dtpFecha2);
            this.groupBox1.Controls.Add(this.dtpFecha1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 59);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.Location = new System.Drawing.Point(632, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "x";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(473, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "Por :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(508, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(435, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "Filtro";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(437, 24);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(207, 20);
            this.txtFiltro.TabIndex = 33;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "Empresa";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Enabled = false;
            this.cmbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(9, 25);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(121, 20);
            this.cmbEmpresa.TabIndex = 31;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.ImageIndex = 11;
            this.btnBusqueda.ImageList = this.imageList1;
            this.btnBusqueda.Location = new System.Drawing.Point(789, 17);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(78, 33);
            this.btnBusqueda.TabIndex = 30;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.ImageIndex = 7;
            this.btnReporte.ImageList = this.imageList1;
            this.btnReporte.Location = new System.Drawing.Point(873, 17);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(78, 33);
            this.btnReporte.TabIndex = 29;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(307, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(220, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(133, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "Desde";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "PENDIENTES",
            "CANCELADOS"});
            this.cmbEstado.Location = new System.Drawing.Point(310, 25);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 20);
            this.cmbEstado.TabIndex = 24;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(223, 25);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha2.TabIndex = 22;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(136, 25);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha1.TabIndex = 21;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codnota,
            this.tipo,
            this.numdocumento,
            this.docref,
            this.codproveedore,
            this.ruc,
            this.proveedor,
            this.fechaemision,
            this.fechavenc,
            this.fechacancelado,
            this.moneda,
            this.monto,
            this.pendiente,
            this.banco,
            this.numcuenta,
            this.numunico,
            this.accion,
            this.cantidad,
            this.estado});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(0, 59);
            this.dgvPagos.MultiSelect = false;
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(957, 415);
            this.dgvPagos.TabIndex = 8;
            this.dgvPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagos_CellContentClick);
            this.dgvPagos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPagos_CellMouseDown);
            this.dgvPagos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // codnota
            // 
            this.codnota.DataPropertyName = "codigo";
            this.codnota.HeaderText = "CodNota";
            this.codnota.Name = "codnota";
            this.codnota.ReadOnly = true;
            this.codnota.Visible = false;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // numdocumento
            // 
            this.numdocumento.DataPropertyName = "numdocumento";
            this.numdocumento.HeaderText = "N° Documento";
            this.numdocumento.Name = "numdocumento";
            this.numdocumento.ReadOnly = true;
            this.numdocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numdocumento.Width = 90;
            // 
            // docref
            // 
            this.docref.DataPropertyName = "docref";
            this.docref.HeaderText = "Doc. Ref.";
            this.docref.Name = "docref";
            this.docref.ReadOnly = true;
            this.docref.Width = 90;
            // 
            // codproveedore
            // 
            this.codproveedore.DataPropertyName = "codProveedor";
            this.codproveedore.HeaderText = "Cod Prov";
            this.codproveedore.Name = "codproveedore";
            this.codproveedore.ReadOnly = true;
            this.codproveedore.Visible = false;
            // 
            // ruc
            // 
            this.ruc.DataPropertyName = "ruc";
            this.ruc.HeaderText = "RUC";
            this.ruc.Name = "ruc";
            this.ruc.ReadOnly = true;
            this.ruc.Visible = false;
            // 
            // proveedor
            // 
            this.proveedor.DataPropertyName = "razonsocial";
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proveedor.Width = 200;
            // 
            // fechaemision
            // 
            this.fechaemision.DataPropertyName = "fechaemision";
            this.fechaemision.HeaderText = "Fecha Emi.";
            this.fechaemision.Name = "fechaemision";
            this.fechaemision.ReadOnly = true;
            this.fechaemision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechaemision.Width = 80;
            // 
            // fechavenc
            // 
            this.fechavenc.DataPropertyName = "fechavence";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechavenc.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechavenc.HeaderText = "Fecha Venc.";
            this.fechavenc.Name = "fechavenc";
            this.fechavenc.ReadOnly = true;
            this.fechavenc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechavenc.Width = 80;
            // 
            // fechacancelado
            // 
            this.fechacancelado.DataPropertyName = "fechacancelado";
            this.fechacancelado.HeaderText = "Fec. Canc.";
            this.fechacancelado.Name = "fechacancelado";
            this.fechacancelado.ReadOnly = true;
            this.fechacancelado.Width = 80;
            // 
            // moneda
            // 
            this.moneda.DataPropertyName = "moneda";
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            this.moneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.moneda.Width = 60;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.monto.DefaultCellStyle = dataGridViewCellStyle3;
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.monto.Width = 70;
            // 
            // pendiente
            // 
            this.pendiente.DataPropertyName = "pendiente";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pendiente.DefaultCellStyle = dataGridViewCellStyle4;
            this.pendiente.HeaderText = "Pendiente";
            this.pendiente.Name = "pendiente";
            this.pendiente.ReadOnly = true;
            this.pendiente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pendiente.Width = 70;
            // 
            // banco
            // 
            this.banco.DataPropertyName = "banco";
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            this.banco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.banco.Width = 120;
            // 
            // numcuenta
            // 
            this.numcuenta.DataPropertyName = "ctacte";
            this.numcuenta.HeaderText = "N° Cuenta";
            this.numcuenta.Name = "numcuenta";
            this.numcuenta.ReadOnly = true;
            this.numcuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numcuenta.Width = 120;
            // 
            // numunico
            // 
            this.numunico.DataPropertyName = "num";
            this.numunico.HeaderText = "N° Unico";
            this.numunico.Name = "numunico";
            this.numunico.ReadOnly = true;
            this.numunico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numunico.Width = 80;
            // 
            // accion
            // 
            this.accion.DataPropertyName = "accion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.accion.DefaultCellStyle = dataGridViewCellStyle5;
            this.accion.HeaderText = "Acción";
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            this.accion.Text = "";
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantpagos";
            this.cantidad.HeaderText = "Cant. Pagos";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cantidad.Visible = false;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "cancelado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muestraPagosToolStripMenuItem,
            this.canjearPorLetraToolStripMenuItem,
            this.toolStripSeparator1,
            this.nuevaLetraToolStripMenuItem,
            this.modificarLetraToolStripMenuItem,
            this.imprimirLetraToolStripMenuItem,
            this.ingresoABancoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 142);
            // 
            // muestraPagosToolStripMenuItem
            // 
            this.muestraPagosToolStripMenuItem.Name = "muestraPagosToolStripMenuItem";
            this.muestraPagosToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.muestraPagosToolStripMenuItem.Text = "Muestra Pagos";
            this.muestraPagosToolStripMenuItem.Click += new System.EventHandler(this.muestraPagosToolStripMenuItem_Click);
            // 
            // canjearPorLetraToolStripMenuItem
            // 
            this.canjearPorLetraToolStripMenuItem.Name = "canjearPorLetraToolStripMenuItem";
            this.canjearPorLetraToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.canjearPorLetraToolStripMenuItem.Text = "Canjear por Letra";
            this.canjearPorLetraToolStripMenuItem.Click += new System.EventHandler(this.canjearPorLetraToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // nuevaLetraToolStripMenuItem
            // 
            this.nuevaLetraToolStripMenuItem.Name = "nuevaLetraToolStripMenuItem";
            this.nuevaLetraToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevaLetraToolStripMenuItem.Text = "Nueva Letra";
            this.nuevaLetraToolStripMenuItem.Click += new System.EventHandler(this.nuevaLetraToolStripMenuItem_Click);
            // 
            // modificarLetraToolStripMenuItem
            // 
            this.modificarLetraToolStripMenuItem.Name = "modificarLetraToolStripMenuItem";
            this.modificarLetraToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.modificarLetraToolStripMenuItem.Text = "Modificar Letra";
            this.modificarLetraToolStripMenuItem.Click += new System.EventHandler(this.modificarLetraToolStripMenuItem_Click);
            // 
            // imprimirLetraToolStripMenuItem
            // 
            this.imprimirLetraToolStripMenuItem.Name = "imprimirLetraToolStripMenuItem";
            this.imprimirLetraToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.imprimirLetraToolStripMenuItem.Text = "Imprimir Letra";
            // 
            // ingresoABancoToolStripMenuItem
            // 
            this.ingresoABancoToolStripMenuItem.Name = "ingresoABancoToolStripMenuItem";
            this.ingresoABancoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ingresoABancoToolStripMenuItem.Text = "Ingreso a banco";
            this.ingresoABancoToolStripMenuItem.Click += new System.EventHandler(this.ingresoABancoToolStripMenuItem_Click);
            // 
            // frmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 474);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmPagos";
            this.ShowInTaskbar = false;
            this.Text = "Pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPagos_Load);
            this.Shown += new System.EventHandler(this.frmPagos_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem btnBuscar;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem muestraPagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canjearPorLetraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem nuevaLetraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarLetraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirLetraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoABancoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnota;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn docref;
        private System.Windows.Forms.DataGridViewTextBoxColumn codproveedore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechavenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn numcuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn numunico;
        private System.Windows.Forms.DataGridViewLinkColumn accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}