namespace SIGEFA.Formularios
{
    partial class frmNotaOrdenAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaOrdenAlmacen));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.escoge = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codnoting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codOrdenC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecreg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalle2 = new System.Windows.Forms.DataGridView();
            this.codnotasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnconsultar = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalle);
            this.groupBox1.Controls.Add(this.dgvDetalle2);
            this.groupBox1.Location = new System.Drawing.Point(0, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToOrderColumns = true;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.escoge,
            this.codnoting,
            this.codOrdenC,
            this.codDocumento,
            this.documento,
            this.razonSocial,
            this.fecing,
            this.fecreg,
            this.codUsu,
            this.docOrden,
            this.almacen_1});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(727, 303);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalle_ColumnHeaderMouseClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvDetalle_RowStateChanged);
            // 
            // escoge
            // 
            this.escoge.HeaderText = "Elige";
            this.escoge.Name = "escoge";
            this.escoge.Width = 50;
            // 
            // codnoting
            // 
            this.codnoting.DataPropertyName = "codNota";
            this.codnoting.HeaderText = "Nota Ingreso";
            this.codnoting.Name = "codnoting";
            this.codnoting.Visible = false;
            // 
            // codOrdenC
            // 
            this.codOrdenC.DataPropertyName = "ordenCompra";
            this.codOrdenC.HeaderText = "codOrdenCompra";
            this.codOrdenC.Name = "codOrdenC";
            this.codOrdenC.Visible = false;
            // 
            // codDocumento
            // 
            this.codDocumento.DataPropertyName = "codDocumento";
            this.codDocumento.HeaderText = "codDocumento";
            this.codDocumento.Name = "codDocumento";
            this.codDocumento.Visible = false;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // razonSocial
            // 
            this.razonSocial.DataPropertyName = "razonsocial";
            this.razonSocial.HeaderText = "Proveedor";
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.Width = 200;
            // 
            // fecing
            // 
            this.fecing.DataPropertyName = "fechaingreso";
            this.fecing.HeaderText = "FechaIngreso";
            this.fecing.Name = "fecing";
            this.fecing.ReadOnly = true;
            // 
            // fecreg
            // 
            this.fecreg.DataPropertyName = "fecharegistro";
            this.fecreg.HeaderText = "FechaRegistro";
            this.fecreg.Name = "fecreg";
            this.fecreg.ReadOnly = true;
            this.fecreg.Visible = false;
            // 
            // codUsu
            // 
            this.codUsu.DataPropertyName = "codUser";
            this.codUsu.HeaderText = "codUsuario";
            this.codUsu.Name = "codUsu";
            this.codUsu.Visible = false;
            // 
            // docOrden
            // 
            this.docOrden.DataPropertyName = "docOrden";
            this.docOrden.HeaderText = "Orden";
            this.docOrden.Name = "docOrden";
            this.docOrden.ReadOnly = true;
            this.docOrden.Width = 120;
            // 
            // almacen_1
            // 
            this.almacen_1.DataPropertyName = "almacen";
            this.almacen_1.HeaderText = "Almacen";
            this.almacen_1.Name = "almacen_1";
            this.almacen_1.Width = 150;
            // 
            // dgvDetalle2
            // 
            this.dgvDetalle2.AllowUserToAddRows = false;
            this.dgvDetalle2.AllowUserToDeleteRows = false;
            this.dgvDetalle2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codnotasalida,
            this.fechasalida,
            this.tipodoc,
            this.serie,
            this.numdoc,
            this.almacen,
            this.docref});
            this.dgvDetalle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle2.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalle2.MultiSelect = false;
            this.dgvDetalle2.Name = "dgvDetalle2";
            this.dgvDetalle2.ReadOnly = true;
            this.dgvDetalle2.RowHeadersVisible = false;
            this.dgvDetalle2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle2.Size = new System.Drawing.Size(727, 303);
            this.dgvDetalle2.TabIndex = 3;
            this.dgvDetalle2.Visible = false;
            this.dgvDetalle2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle2_CellDoubleClick);
            this.dgvDetalle2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalle2_CellMouseDoubleClick);
            // 
            // codnotasalida
            // 
            this.codnotasalida.DataPropertyName = "codNotaSalida";
            this.codnotasalida.HeaderText = "CodNotaSalida";
            this.codnotasalida.Name = "codnotasalida";
            this.codnotasalida.ReadOnly = true;
            this.codnotasalida.Visible = false;
            // 
            // fechasalida
            // 
            this.fechasalida.DataPropertyName = "fechasalida";
            this.fechasalida.HeaderText = "Fecha Salida";
            this.fechasalida.Name = "fechasalida";
            this.fechasalida.ReadOnly = true;
            // 
            // tipodoc
            // 
            this.tipodoc.DataPropertyName = "sigla";
            this.tipodoc.HeaderText = "Tipo Doc.";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.ReadOnly = true;
            this.tipodoc.Width = 80;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Width = 70;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "N° Doc.";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            this.numdoc.Width = 90;
            // 
            // almacen
            // 
            this.almacen.DataPropertyName = "nomalmacen";
            this.almacen.HeaderText = "Almacen";
            this.almacen.Name = "almacen";
            this.almacen.ReadOnly = true;
            this.almacen.Width = 135;
            // 
            // docref
            // 
            this.docref.DataPropertyName = "documentoreferencia";
            this.docref.HeaderText = "Doc.Ref";
            this.docref.Name = "docref";
            this.docref.ReadOnly = true;
            this.docref.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(12, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cross.png");
            this.imageList1.Images.SetKeyName(1, "tick.png");
            this.imageList1.Images.SetKeyName(2, "Clear Green Button.ico");
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(643, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 30);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Write Document.png");
            this.imageList2.Images.SetKeyName(1, "New Document.png");
            this.imageList2.Images.SetKeyName(2, "Remove Document.png");
            this.imageList2.Images.SetKeyName(3, "document-print.png");
            this.imageList2.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList2.Images.SetKeyName(5, "exit.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnconsultar);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 45);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnconsultar
            // 
            this.btnconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnconsultar.ImageIndex = 1;
            this.btnconsultar.ImageList = this.imageList3;
            this.btnconsultar.Location = new System.Drawing.Point(190, 9);
            this.btnconsultar.Name = "btnconsultar";
            this.btnconsultar.Size = new System.Drawing.Size(90, 30);
            this.btnconsultar.TabIndex = 9;
            this.btnconsultar.Text = "Ir a Guia";
            this.btnconsultar.UseVisualStyleBackColor = true;
            this.btnconsultar.Visible = false;
            this.btnconsultar.Click += new System.EventHandler(this.btnconsultar_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "exit.png");
            this.imageList3.Images.SetKeyName(1, "pedido.png");
            this.imageList3.Images.SetKeyName(2, "carrito.png");
            this.imageList3.Images.SetKeyName(3, "delete-file-icon.png");
            this.imageList3.Images.SetKeyName(4, "DeleteRed.png");
            this.imageList3.Images.SetKeyName(5, "document_delete.png");
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(601, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(36, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(560, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(477, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(519, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(99, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(102, 25);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(81, 20);
            this.dtpHasta.TabIndex = 38;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(15, 25);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(81, 20);
            this.dtpDesde.TabIndex = 37;
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnbuscar.ImageIndex = 6;
            this.btnbuscar.ImageList = this.imageList4;
            this.btnbuscar.Location = new System.Drawing.Point(199, 20);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(105, 35);
            this.btnbuscar.TabIndex = 41;
            this.btnbuscar.Text = " Consultar";
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "Write Document.png");
            this.imageList4.Images.SetKeyName(1, "New Document.png");
            this.imageList4.Images.SetKeyName(2, "Remove Document.png");
            this.imageList4.Images.SetKeyName(3, "document-print.png");
            this.imageList4.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList4.Images.SetKeyName(5, "exit.png");
            this.imageList4.Images.SetKeyName(6, "search (1).png");
            this.imageList4.Images.SetKeyName(7, "Glossy-Open-icon.png");
            this.imageList4.Images.SetKeyName(8, "folder-open-icon (1).png");
            this.imageList4.Images.SetKeyName(9, "document_delete.png");
            this.imageList4.Images.SetKeyName(10, "DeleteRed.png");
            this.imageList4.Images.SetKeyName(11, "OK_Verde.png");
            this.imageList4.Images.SetKeyName(12, "Remove.png");
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(529, 29);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(204, 20);
            this.txtFiltro.TabIndex = 42;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(370, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "Por :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(405, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(332, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Location = new System.Drawing.Point(385, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "x";
            this.label4.Visible = false;
            // 
            // frmNotaOrdenAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 451);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmNotaOrdenAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guias de Compra";
            this.Load += new System.EventHandler(this.NotaOrdenAlmacen_Load);
            this.Shown += new System.EventHandler(this.frmNotaOrdenAlmacen_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnconsultar;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.DataGridView dgvDetalle;
        public System.Windows.Forms.DataGridView dgvDetalle2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn docref;
        private System.Windows.Forms.DataGridViewCheckBoxColumn escoge;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnoting;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenC;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecing;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecreg;
        private System.Windows.Forms.DataGridViewTextBoxColumn codUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn docOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.ImageList imageList4;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
    }
}