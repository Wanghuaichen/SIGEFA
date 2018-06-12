namespace SIGEFA.Formularios
{
    partial class frmTesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTesoreria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.biSalir = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.biAprobar = new DevComponents.DotNetBar.ButtonItem();
            this.biDesaprobar = new DevComponents.DotNetBar.ButtonItem();
            this.txtMontoLiquidar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoRendido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRendiciones = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoRendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAprobado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRendicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caja_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendiciones)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(22, "EXIT2.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ribbonBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 65);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.ribbonBar2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(979, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 65);
            this.panel2.TabIndex = 9;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            this.ribbonBar2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Images = this.imageList1;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSalir});
            this.ribbonBar2.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(85, 65);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar2.TabIndex = 9;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.TitleVisible = false;
            // 
            // biSalir
            // 
            this.biSalir.Image = ((System.Drawing.Image)(resources.GetObject("biSalir.Image")));
            this.biSalir.ImageIndex = 20;
            this.biSalir.ImagePaddingHorizontal = 30;
            this.biSalir.ImagePaddingVertical = 15;
            this.biSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biSalir.Name = "biSalir";
            this.biSalir.SubItemsExpandWidth = 14;
            this.biSalir.Text = "  Salir";
            this.biSalir.Click += new System.EventHandler(this.biSalir_Click);
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
            //this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAprobar,
            this.biDesaprobar});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1064, 65);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar1.TabIndex = 8;
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
            // biAprobar
            // 
            this.biAprobar.Enabled = false;
            this.biAprobar.Image = ((System.Drawing.Image)(resources.GetObject("biAprobar.Image")));
            this.biAprobar.ImageIndex = 20;
            this.biAprobar.ImagePaddingHorizontal = 30;
            this.biAprobar.ImagePaddingVertical = 15;
            this.biAprobar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biAprobar.Name = "biAprobar";
            this.biAprobar.SubItemsExpandWidth = 14;
            this.biAprobar.Text = "Aprobar";
            // 
            // biDesaprobar
            // 
            this.biDesaprobar.Enabled = false;
            this.biDesaprobar.Image = ((System.Drawing.Image)(resources.GetObject("biDesaprobar.Image")));
            this.biDesaprobar.ImageIndex = 19;
            this.biDesaprobar.ImagePaddingHorizontal = 20;
            this.biDesaprobar.ImagePaddingVertical = 15;
            this.biDesaprobar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biDesaprobar.Name = "biDesaprobar";
            this.biDesaprobar.SubItemsExpandWidth = 14;
            this.biDesaprobar.Text = "Desaprobar";
            // 
            // txtMontoLiquidar
            // 
            this.txtMontoLiquidar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMontoLiquidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMontoLiquidar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoLiquidar.ForeColor = System.Drawing.Color.Blue;
            this.txtMontoLiquidar.Location = new System.Drawing.Point(408, 29);
            this.txtMontoLiquidar.MaxLength = 10;
            this.txtMontoLiquidar.Name = "txtMontoLiquidar";
            this.txtMontoLiquidar.Size = new System.Drawing.Size(90, 22);
            this.txtMontoLiquidar.TabIndex = 44;
            this.txtMontoLiquidar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoLiquidar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoLiquidar_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(298, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "MONTO LIQUIDAR:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(53, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "RESPONSABLE DE ENVIO:";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResponsable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtResponsable.Location = new System.Drawing.Point(202, 53);
            this.txtResponsable.MaxLength = 60;
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(509, 20);
            this.txtResponsable.TabIndex = 41;
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtNumCheque.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCheque.ForeColor = System.Drawing.Color.Blue;
            this.txtNumCheque.Location = new System.Drawing.Point(621, 29);
            this.txtNumCheque.MaxLength = 10;
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(90, 22);
            this.txtNumCheque.TabIndex = 40;
            this.txtNumCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(504, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "N° CHEQUE DE LIQ.:";
            // 
            // txtMontoRendido
            // 
            this.txtMontoRendido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMontoRendido.Enabled = false;
            this.txtMontoRendido.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtMontoRendido.Location = new System.Drawing.Point(202, 29);
            this.txtMontoRendido.MaxLength = 10;
            this.txtMontoRendido.Name = "txtMontoRendido";
            this.txtMontoRendido.ReadOnly = true;
            this.txtMontoRendido.Size = new System.Drawing.Size(90, 22);
            this.txtMontoRendido.TabIndex = 38;
            this.txtMontoRendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(93, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "MONTO RENDIDO:";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSucursal.Enabled = false;
            this.txtSucursal.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtSucursal.Location = new System.Drawing.Point(202, 5);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.ReadOnly = true;
            this.txtSucursal.Size = new System.Drawing.Size(296, 22);
            this.txtSucursal.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(128, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "SUCURSAL:";
            // 
            // dgvRendiciones
            // 
            this.dgvRendiciones.AllowUserToAddRows = false;
            this.dgvRendiciones.AllowUserToDeleteRows = false;
            this.dgvRendiciones.AllowUserToResizeRows = false;
            this.dgvRendiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRendiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numdocumento,
            this.montoRendido,
            this.montoAprobado,
            this.fechaRendicion,
            this.status,
            this.sucursal,
            this.caja_});
            this.dgvRendiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRendiciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRendiciones.Location = new System.Drawing.Point(0, 65);
            this.dgvRendiciones.MultiSelect = false;
            this.dgvRendiciones.Name = "dgvRendiciones";
            this.dgvRendiciones.RowHeadersVisible = false;
            this.dgvRendiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRendiciones.Size = new System.Drawing.Size(1064, 303);
            this.dgvRendiciones.TabIndex = 15;
            this.dgvRendiciones.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvRendiciones_RowStateChanged);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codRendicion";
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            // 
            // numdocumento
            // 
            this.numdocumento.DataPropertyName = "numDocumento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numdocumento.DefaultCellStyle = dataGridViewCellStyle1;
            this.numdocumento.HeaderText = "numdocumento";
            this.numdocumento.Name = "numdocumento";
            // 
            // montoRendido
            // 
            this.montoRendido.DataPropertyName = "montoRendido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.montoRendido.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoRendido.HeaderText = "montoRendido";
            this.montoRendido.Name = "montoRendido";
            // 
            // montoAprobado
            // 
            this.montoAprobado.DataPropertyName = "montoAprobado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.montoAprobado.DefaultCellStyle = dataGridViewCellStyle3;
            this.montoAprobado.HeaderText = "montoAprobado";
            this.montoAprobado.Name = "montoAprobado";
            // 
            // fechaRendicion
            // 
            this.fechaRendicion.DataPropertyName = "fechaRendicion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRendicion.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaRendicion.HeaderText = "fechaRendicion";
            this.fechaRendicion.Name = "fechaRendicion";
            this.fechaRendicion.Width = 120;
            // 
            // status
            // 
            this.status.DataPropertyName = "estatus";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            // 
            // sucursal
            // 
            this.sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sucursal.DataPropertyName = "sucursal";
            this.sucursal.HeaderText = "sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // caja_
            // 
            this.caja_.DataPropertyName = "caja";
            this.caja_.HeaderText = "caja";
            this.caja_.Name = "caja_";
            this.caja_.Visible = false;
            this.caja_.Width = 200;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(547, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "FECHA LIQ.:";
            // 
            // dtpFechaLiquidacion
            // 
            this.dtpFechaLiquidacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaLiquidacion.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dtpFechaLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiquidacion.Location = new System.Drawing.Point(621, 5);
            this.dtpFechaLiquidacion.Name = "dtpFechaLiquidacion";
            this.dtpFechaLiquidacion.Size = new System.Drawing.Size(90, 22);
            this.dtpFechaLiquidacion.TabIndex = 16;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.ImageIndex = 3;
            this.btnGuardar.ImageList = this.imageList2;
            this.btnGuardar.Location = new System.Drawing.Point(717, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 68);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.Text = "Guardar Registro";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.dtpFechaLiquidacion);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtMontoLiquidar);
            this.panel3.Controls.Add(this.txtSucursal);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtMontoRendido);
            this.panel3.Controls.Add(this.txtResponsable);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtNumCheque);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1064, 78);
            this.panel3.TabIndex = 16;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Enabled = false;
            this.btnSalir.ImageIndex = 3;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(965, 357);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 68);
            this.btnSalir.TabIndex = 46;
            this.btnSalir.Text = "Guardar Registro";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.biSalir_Click);
            // 
            // frmTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1054, 432);
            this.Controls.Add(this.dgvRendiciones);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(1070, 470);
            this.Name = "frmTesoreria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tesoreria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTesoreria_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendiciones)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem biAprobar;
        private DevComponents.DotNetBar.ButtonItem biDesaprobar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.TextBox txtMontoRendido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumCheque;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMontoLiquidar;
        private System.Windows.Forms.DataGridView dgvRendiciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaLiquidacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem biSalir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoRendido;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAprobado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRendicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn caja_;

    }
}