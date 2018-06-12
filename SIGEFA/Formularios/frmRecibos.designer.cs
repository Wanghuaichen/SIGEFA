namespace SIGEFA.Formularios
{
    partial class frmRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.biEditar = new DevComponents.DotNetBar.ButtonItem();
            this.biBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.biImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.biActualizar = new DevComponents.DotNetBar.ButtonItem();
            this.biAnular = new DevComponents.DotNetBar.ButtonItem();
            this.dgvRecibos = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montopendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montorendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sustentado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpfecha2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtxsustentar = new System.Windows.Forms.Label();
            this.txtsustentado = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSaldoCaja = new System.Windows.Forms.Label();
            this.lblAperturaCaja = new System.Windows.Forms.Label();
            this.lblEgresos = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.lblProperty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblColumna = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biEditar,
            this.biBuscar,
            this.biImprimir,
            this.biActualizar,
            this.biAnular});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(591, 65);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar1.TabIndex = 8;
            this.ribbonBar1.Text = "ribbonBar1";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
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
            this.imageList1.Images.SetKeyName(16, "icon-47203_640.png");
            this.imageList1.Images.SetKeyName(17, "Folder open.png");
            this.imageList1.Images.SetKeyName(18, "por-periodo-de-sesiones-icono-8745-96.png");
            this.imageList1.Images.SetKeyName(19, "egreso.png");
            this.imageList1.Images.SetKeyName(20, "ingreso.png");
            this.imageList1.Images.SetKeyName(21, "icon_shelfs.png");
            // 
            // biEditar
            // 
            this.biEditar.ImageIndex = 3;
            this.biEditar.ImagePaddingHorizontal = 10;
            this.biEditar.ImagePaddingVertical = 15;
            this.biEditar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEditar.Name = "biEditar";
            this.biEditar.SubItemsExpandWidth = 14;
            this.biEditar.Text = "Editar";
            this.biEditar.Click += new System.EventHandler(this.biEditar_Click);
            // 
            // biBuscar
            // 
            this.biBuscar.ImageIndex = 11;
            this.biBuscar.ImagePaddingHorizontal = 10;
            this.biBuscar.ImagePaddingVertical = 15;
            this.biBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biBuscar.Name = "biBuscar";
            this.biBuscar.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlB);
            this.biBuscar.SubItemsExpandWidth = 14;
            this.biBuscar.Text = "Buscar";
            this.biBuscar.Click += new System.EventHandler(this.biBuscar_Click);
            // 
            // biImprimir
            // 
            this.biImprimir.ImageIndex = 7;
            this.biImprimir.ImagePaddingHorizontal = 10;
            this.biImprimir.ImagePaddingVertical = 15;
            this.biImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biImprimir.Name = "biImprimir";
            this.biImprimir.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.biImprimir.SubItemsExpandWidth = 14;
            this.biImprimir.Text = "Imprimir";
            this.biImprimir.Visible = false;
            this.biImprimir.Click += new System.EventHandler(this.biImprimir_Click);
            // 
            // biActualizar
            // 
            this.biActualizar.ImageIndex = 8;
            this.biActualizar.ImagePaddingHorizontal = 10;
            this.biActualizar.ImagePaddingVertical = 15;
            this.biActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biActualizar.Name = "biActualizar";
            this.biActualizar.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.biActualizar.SubItemsExpandWidth = 14;
            this.biActualizar.Text = "Actualizar";
            this.biActualizar.Click += new System.EventHandler(this.biActualizar_Click);
            // 
            // biAnular
            // 
            this.biAnular.ImageIndex = 21;
            this.biAnular.ImagePaddingHorizontal = 10;
            this.biAnular.ImagePaddingVertical = 15;
            this.biAnular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biAnular.Name = "biAnular";
            this.biAnular.SubItemsExpandWidth = 14;
            this.biAnular.Text = "Anular";
            this.biAnular.Visible = false;
            this.biAnular.Click += new System.EventHandler(this.biAnular_Click);
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.AllowUserToAddRows = false;
            this.dgvRecibos.AllowUserToDeleteRows = false;
            this.dgvRecibos.AllowUserToResizeRows = false;
            this.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecibos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.concepto,
            this.monto,
            this.fecha,
            this.serie,
            this.numeracion,
            this.numDocumento,
            this.montopendiente,
            this.montorendido,
            this.sustentado1,
            this.anulado});
            this.dgvRecibos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecibos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRecibos.Location = new System.Drawing.Point(0, 65);
            this.dgvRecibos.MultiSelect = false;
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.ReadOnly = true;
            this.dgvRecibos.RowHeadersVisible = false;
            this.dgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibos.Size = new System.Drawing.Size(1241, 276);
            this.dgvRecibos.TabIndex = 9;
            this.dgvRecibos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientosCajaChica_CellDoubleClick);
            this.dgvRecibos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMovimientosCajaChica_ColumnHeaderMouseClick);
            this.dgvRecibos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvMovimientosCajaChica_RowsAdded);
            this.dgvRecibos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvMovimientosCajaChica_CurrentCellDirtyStateChanged);
            this.dgvRecibos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvMovimientosCajaChica_RowsRemoved);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codRecibo";
            this.codigo.HeaderText = "COD";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            this.codigo.Width = 70;
            // 
            // concepto
            // 
            this.concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.concepto.DataPropertyName = "concepto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.concepto.DefaultCellStyle = dataGridViewCellStyle1;
            this.concepto.HeaderText = "CONCEPTO";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 400;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.monto.HeaderText = "MONTO";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.fecha.HeaderText = "FECHA";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 80;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "SERIE";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Visible = false;
            // 
            // numeracion
            // 
            this.numeracion.DataPropertyName = "numeracion";
            this.numeracion.HeaderText = "NUMERACIÓN";
            this.numeracion.Name = "numeracion";
            this.numeracion.ReadOnly = true;
            this.numeracion.Visible = false;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numerodocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumento.DefaultCellStyle = dataGridViewCellStyle4;
            this.numDocumento.HeaderText = "N° DOC.";
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.ReadOnly = true;
            // 
            // montopendiente
            // 
            this.montopendiente.DataPropertyName = "montopendiente";
            this.montopendiente.HeaderText = "MONTO POR SUSTENTAR";
            this.montopendiente.Name = "montopendiente";
            this.montopendiente.ReadOnly = true;
            // 
            // montorendido
            // 
            this.montorendido.DataPropertyName = "montorendido";
            this.montorendido.HeaderText = "MONTO SUSTENTADO";
            this.montorendido.Name = "montorendido";
            this.montorendido.ReadOnly = true;
            // 
            // sustentado1
            // 
            this.sustentado1.DataPropertyName = "sustentado";
            this.sustentado1.HeaderText = "SUSTENTADO";
            this.sustentado1.Name = "sustentado1";
            this.sustentado1.ReadOnly = true;
            // 
            // anulado
            // 
            this.anulado.DataPropertyName = "anulado";
            this.anulado.HeaderText = "ANULADO";
            this.anulado.Name = "anulado";
            this.anulado.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(1013, 90);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ribbonBar1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 65);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpfecha1);
            this.panel2.Controls.Add(this.dtpfecha2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(591, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 65);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(243, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Y";
            // 
            // dtpfecha1
            // 
            this.dtpfecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha1.Location = new System.Drawing.Point(143, 22);
            this.dtpfecha1.Name = "dtpfecha1";
            this.dtpfecha1.Size = new System.Drawing.Size(99, 20);
            this.dtpfecha1.TabIndex = 13;
            this.dtpfecha1.ValueChanged += new System.EventHandler(this.dtpfecha1_ValueChanged);
            this.dtpfecha1.Leave += new System.EventHandler(this.dtpfecha1_Leave);
            // 
            // dtpfecha2
            // 
            this.dtpfecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha2.Location = new System.Drawing.Point(260, 22);
            this.dtpfecha2.Name = "dtpfecha2";
            this.dtpfecha2.Size = new System.Drawing.Size(99, 20);
            this.dtpfecha2.TabIndex = 14;
            this.dtpfecha2.ValueChanged += new System.EventHandler(this.dtpfecha2_ValueChanged);
            this.dtpfecha2.Leave += new System.EventHandler(this.dtpfecha2_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(43, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "BUSCAR ENTRE:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList2;
            this.btnExit.Location = new System.Drawing.Point(568, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 50);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "Salir";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "400_F_3572.png");
            this.imageList2.Images.SetKeyName(1, "como-eliminar-el-acne.png");
            this.imageList2.Images.SetKeyName(2, "cancel-148744_640.png");
            this.imageList2.Images.SetKeyName(3, "Filter.png");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtxsustentar);
            this.panel4.Controls.Add(this.txtsustentado);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 351);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1241, 70);
            this.panel4.TabIndex = 14;
            // 
            // txtxsustentar
            // 
            this.txtxsustentar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtxsustentar.BackColor = System.Drawing.Color.Transparent;
            this.txtxsustentar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtxsustentar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxsustentar.ForeColor = System.Drawing.Color.DarkRed;
            this.txtxsustentar.Location = new System.Drawing.Point(269, 40);
            this.txtxsustentar.Name = "txtxsustentar";
            this.txtxsustentar.Size = new System.Drawing.Size(100, 20);
            this.txtxsustentar.TabIndex = 48;
            this.txtxsustentar.Text = "0.000";
            this.txtxsustentar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtsustentado
            // 
            this.txtsustentado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsustentado.BackColor = System.Drawing.Color.Transparent;
            this.txtsustentado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtsustentado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsustentado.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtsustentado.Location = new System.Drawing.Point(269, 14);
            this.txtsustentado.Name = "txtsustentado";
            this.txtsustentado.Size = new System.Drawing.Size(100, 20);
            this.txtsustentado.TabIndex = 47;
            this.txtsustentado.Text = "0.000";
            this.txtsustentado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(103, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "MONTO POR SUSTENTAR S/:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(121, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "MONTO SUSTENTADO S/:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lblSaldoCaja);
            this.panel3.Controls.Add(this.lblAperturaCaja);
            this.panel3.Controls.Add(this.lblEgresos);
            this.panel3.Controls.Add(this.lblIngresos);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(591, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 70);
            this.panel3.TabIndex = 13;
            // 
            // lblSaldoCaja
            // 
            this.lblSaldoCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoCaja.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldoCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaldoCaja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoCaja.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSaldoCaja.Location = new System.Drawing.Point(543, 37);
            this.lblSaldoCaja.Name = "lblSaldoCaja";
            this.lblSaldoCaja.Size = new System.Drawing.Size(100, 20);
            this.lblSaldoCaja.TabIndex = 46;
            this.lblSaldoCaja.Text = "0.000";
            this.lblSaldoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSaldoCaja.Visible = false;
            // 
            // lblAperturaCaja
            // 
            this.lblAperturaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAperturaCaja.BackColor = System.Drawing.Color.Transparent;
            this.lblAperturaCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAperturaCaja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaCaja.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAperturaCaja.Location = new System.Drawing.Point(543, 11);
            this.lblAperturaCaja.Name = "lblAperturaCaja";
            this.lblAperturaCaja.Size = new System.Drawing.Size(100, 20);
            this.lblAperturaCaja.TabIndex = 45;
            this.lblAperturaCaja.Text = "0.000";
            this.lblAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAperturaCaja.Visible = false;
            // 
            // lblEgresos
            // 
            this.lblEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEgresos.BackColor = System.Drawing.Color.Transparent;
            this.lblEgresos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEgresos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgresos.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEgresos.Location = new System.Drawing.Point(90, 36);
            this.lblEgresos.Name = "lblEgresos";
            this.lblEgresos.Size = new System.Drawing.Size(100, 20);
            this.lblEgresos.TabIndex = 44;
            this.lblEgresos.Text = "0.000";
            this.lblEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEgresos.Visible = false;
            // 
            // lblIngresos
            // 
            this.lblIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIngresos.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIngresos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblIngresos.Location = new System.Drawing.Point(90, 10);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(100, 20);
            this.lblIngresos.TabIndex = 43;
            this.lblIngresos.Text = "0.000";
            this.lblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblIngresos.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "EGRESOS S/:";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "INGRESOS S/:";
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(476, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "SALDO S/:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(424, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "APERTURA CAJA S/:";
            this.label4.Visible = false;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandablePanel1.AnimationTime = 200;
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.expandablePanel1.Controls.Add(this.lblProperty);
            this.expandablePanel1.Controls.Add(this.label8);
            this.expandablePanel1.Controls.Add(this.label9);
            this.expandablePanel1.Controls.Add(this.label10);
            this.expandablePanel1.Controls.Add(this.lblColumna);
            this.expandablePanel1.Controls.Add(this.txtFiltro);
            this.expandablePanel1.Controls.Add(this.btnclose);
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(1004, 0, 231, 93);
            this.expandablePanel1.Location = new System.Drawing.Point(1004, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.ShowFocusRectangle = true;
            this.expandablePanel1.Size = new System.Drawing.Size(231, 0);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.expandablePanel1.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarPopupBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 19;
            this.expandablePanel1.TitleHeight = 0;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Title Bar";
            this.expandablePanel1.Visible = false;
            // 
            // lblProperty
            // 
            this.lblProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProperty.AutoSize = true;
            this.lblProperty.ForeColor = System.Drawing.Color.LightBlue;
            this.lblProperty.Location = new System.Drawing.Point(210, -59);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(12, 13);
            this.lblProperty.TabIndex = 11;
            this.lblProperty.Text = "x";
            this.lblProperty.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, -59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Por :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, -89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "Busqueda";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.LightBlue;
            this.label10.Location = new System.Drawing.Point(186, -59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "x";
            this.label10.Visible = false;
            // 
            // lblColumna
            // 
            this.lblColumna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColumna.AutoSize = true;
            this.lblColumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumna.Location = new System.Drawing.Point(45, -59);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(15, 13);
            this.lblColumna.TabIndex = 6;
            this.lblColumna.Text = "X";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(13, -38);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(207, 20);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(213, -93);
            this.btnclose.Margin = new System.Windows.Forms.Padding(1);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(18, 22);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "x";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 341);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1241, 10);
            this.panel6.TabIndex = 20;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotal.Location = new System.Drawing.Point(301, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 20);
            this.lblTotal.TabIndex = 48;
            this.lblTotal.Text = "0.000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(234, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "TOTAL S/:";
            // 
            // frmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1241, 421);
            this.Controls.Add(this.expandablePanel1);
            this.Controls.Add(this.dgvRecibos);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.Name = "frmRecibos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.frmCajaChica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem biEditar;
        private DevComponents.DotNetBar.ButtonItem biActualizar;
        private DevComponents.DotNetBar.ButtonItem biBuscar;
        private DevComponents.DotNetBar.ButtonItem biImprimir;
        private System.Windows.Forms.DataGridView dgvRecibos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpfecha1;
        private System.Windows.Forms.DateTimePicker dtpfecha2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblColumna;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSaldoCaja;
        private System.Windows.Forms.Label lblAperturaCaja;
        private System.Windows.Forms.Label lblEgresos;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonItem biAnular;
        private System.Windows.Forms.Label txtxsustentar;
        private System.Windows.Forms.Label txtsustentado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn montopendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn montorendido;
        private System.Windows.Forms.DataGridViewTextBoxColumn sustentado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn anulado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
    }
}