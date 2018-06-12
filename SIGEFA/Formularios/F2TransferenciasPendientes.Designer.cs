namespace SIGEFA.Formularios
{
    partial class F2TransferenciasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F2TransferenciasPendientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dgvTransferenciasPendientes = new System.Windows.Forms.DataGridView();
            this.TDirecta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlmacenO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlmacenOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codAlmacenDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacendestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DecripcionRechazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodTDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaentrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codAutorizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codListaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIrNota = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferenciasPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dgvTransferenciasPendientes);
            this.groupBox1.Location = new System.Drawing.Point(-2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1109, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.ImageIndex = 11;
            this.btnBusqueda.ImageList = this.imageList1;
            this.btnBusqueda.Location = new System.Drawing.Point(551, 11);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(80, 33);
            this.btnBusqueda.TabIndex = 32;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
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
            this.imageList1.Images.SetKeyName(22, "img_transferencia.png");
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Pendientes",
            "Aprobadas",
            "Rechazadas",
            "Eniviadas"});
            this.cbTipo.Location = new System.Drawing.Point(402, 17);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 20;
            this.cbTipo.SelectionChangeCommitted += new System.EventHandler(this.cbTipo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tipo :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Desde :";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(77, 18);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 15;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(244, 18);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 14;
            // 
            // dgvTransferenciasPendientes
            // 
            this.dgvTransferenciasPendientes.AllowUserToAddRows = false;
            this.dgvTransferenciasPendientes.AllowUserToDeleteRows = false;
            this.dgvTransferenciasPendientes.AllowUserToOrderColumns = true;
            this.dgvTransferenciasPendientes.AllowUserToResizeRows = false;
            this.dgvTransferenciasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransferenciasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransferenciasPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TDirecta,
            this.codigo,
            this.AlmacenO,
            this.AlmacenOrigen,
            this.codAlmacenDestino,
            this.almacendestino,
            this.DecripcionRechazo,
            this.CodTDoc,
            this.Sigla,
            this.documento,
            this.Moneda,
            this.TipoCambio,
            this.fechaentrega,
            this.montodes,
            this.igv,
            this.estado,
            this.fechapago,
            this.codUsuario,
            this.fecharegistro,
            this.codAutorizado,
            this.codListaPrecio,
            this.formapago,
            this.comentario,
            this.fecha,
            this.Bruto,
            this.importe,
            this.Total});
            this.dgvTransferenciasPendientes.Location = new System.Drawing.Point(3, 56);
            this.dgvTransferenciasPendientes.MultiSelect = false;
            this.dgvTransferenciasPendientes.Name = "dgvTransferenciasPendientes";
            this.dgvTransferenciasPendientes.ReadOnly = true;
            this.dgvTransferenciasPendientes.RowHeadersVisible = false;
            this.dgvTransferenciasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferenciasPendientes.Size = new System.Drawing.Size(1106, 304);
            this.dgvTransferenciasPendientes.TabIndex = 0;
            this.dgvTransferenciasPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransferenciasPendientes_CellDoubleClick);
            // 
            // TDirecta
            // 
            this.TDirecta.DataPropertyName = "TDirecta";
            this.TDirecta.HeaderText = "TDirecta";
            this.TDirecta.Name = "TDirecta";
            this.TDirecta.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codTransDir";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Width = 80;
            // 
            // AlmacenO
            // 
            this.AlmacenO.DataPropertyName = "codAlmacenOrigen";
            this.AlmacenO.HeaderText = "CodAlmacenOrigen";
            this.AlmacenO.Name = "AlmacenO";
            this.AlmacenO.ReadOnly = true;
            this.AlmacenO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AlmacenO.Visible = false;
            this.AlmacenO.Width = 270;
            // 
            // AlmacenOrigen
            // 
            this.AlmacenOrigen.DataPropertyName = "almacenorigen";
            this.AlmacenOrigen.HeaderText = "AlmacenOrigen";
            this.AlmacenOrigen.Name = "AlmacenOrigen";
            this.AlmacenOrigen.ReadOnly = true;
            this.AlmacenOrigen.Width = 200;
            // 
            // codAlmacenDestino
            // 
            this.codAlmacenDestino.DataPropertyName = "codAlmacenDestino";
            this.codAlmacenDestino.HeaderText = "codAlmacenDestino";
            this.codAlmacenDestino.Name = "codAlmacenDestino";
            this.codAlmacenDestino.ReadOnly = true;
            this.codAlmacenDestino.Visible = false;
            // 
            // almacendestino
            // 
            this.almacendestino.DataPropertyName = "almacendestino";
            this.almacendestino.HeaderText = "Almacen Destino";
            this.almacendestino.Name = "almacendestino";
            this.almacendestino.ReadOnly = true;
            this.almacendestino.Width = 200;
            // 
            // DecripcionRechazo
            // 
            this.DecripcionRechazo.DataPropertyName = "decripcionRechazo";
            this.DecripcionRechazo.HeaderText = "DecripcionRechazo";
            this.DecripcionRechazo.Name = "DecripcionRechazo";
            this.DecripcionRechazo.ReadOnly = true;
            this.DecripcionRechazo.Width = 220;
            // 
            // CodTDoc
            // 
            this.CodTDoc.DataPropertyName = "codTipoDocumento";
            this.CodTDoc.HeaderText = "CodTDoc";
            this.CodTDoc.Name = "CodTDoc";
            this.CodTDoc.ReadOnly = true;
            this.CodTDoc.Visible = false;
            // 
            // Sigla
            // 
            this.Sigla.DataPropertyName = "sigla";
            this.Sigla.HeaderText = "Sigla";
            this.Sigla.Name = "Sigla";
            this.Sigla.ReadOnly = true;
            this.Sigla.Width = 50;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "descripcion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.documento.DefaultCellStyle = dataGridViewCellStyle1;
            this.documento.HeaderText = "TipoDoc.";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            this.documento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Visible = false;
            // 
            // TipoCambio
            // 
            this.TipoCambio.DataPropertyName = "tipocambio";
            this.TipoCambio.HeaderText = "TipoCambio";
            this.TipoCambio.Name = "TipoCambio";
            this.TipoCambio.ReadOnly = true;
            this.TipoCambio.Visible = false;
            // 
            // fechaentrega
            // 
            this.fechaentrega.DataPropertyName = "fechaentrega";
            this.fechaentrega.HeaderText = "fechaentrega";
            this.fechaentrega.Name = "fechaentrega";
            this.fechaentrega.ReadOnly = true;
            this.fechaentrega.Visible = false;
            // 
            // montodes
            // 
            this.montodes.DataPropertyName = "montodscto";
            this.montodes.HeaderText = "montodes";
            this.montodes.Name = "montodes";
            this.montodes.ReadOnly = true;
            this.montodes.Visible = false;
            // 
            // igv
            // 
            this.igv.DataPropertyName = "igv";
            this.igv.HeaderText = "igv";
            this.igv.Name = "igv";
            this.igv.ReadOnly = true;
            this.igv.Visible = false;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // fechapago
            // 
            this.fechapago.DataPropertyName = "fechapago";
            this.fechapago.HeaderText = "fechapago";
            this.fechapago.Name = "fechapago";
            this.fechapago.ReadOnly = true;
            this.fechapago.Visible = false;
            // 
            // codUsuario
            // 
            this.codUsuario.DataPropertyName = "codUsuario";
            this.codUsuario.HeaderText = "codUsuario";
            this.codUsuario.Name = "codUsuario";
            this.codUsuario.ReadOnly = true;
            this.codUsuario.Visible = false;
            // 
            // fecharegistro
            // 
            this.fecharegistro.DataPropertyName = "fecharegistro";
            this.fecharegistro.HeaderText = "fecharegistro";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Visible = false;
            // 
            // codAutorizado
            // 
            this.codAutorizado.DataPropertyName = "codAutorizado";
            this.codAutorizado.HeaderText = "codAutorizado";
            this.codAutorizado.Name = "codAutorizado";
            this.codAutorizado.ReadOnly = true;
            this.codAutorizado.Visible = false;
            // 
            // codListaPrecio
            // 
            this.codListaPrecio.DataPropertyName = "codListaPrecio";
            this.codListaPrecio.HeaderText = "codListaPrecio";
            this.codListaPrecio.Name = "codListaPrecio";
            this.codListaPrecio.ReadOnly = true;
            this.codListaPrecio.Visible = false;
            // 
            // formapago
            // 
            this.formapago.DataPropertyName = "formapago";
            this.formapago.HeaderText = "formapago";
            this.formapago.Name = "formapago";
            this.formapago.ReadOnly = true;
            this.formapago.Visible = false;
            // 
            // comentario
            // 
            this.comentario.DataPropertyName = "comentario";
            this.comentario.HeaderText = "comentario";
            this.comentario.Name = "comentario";
            this.comentario.ReadOnly = true;
            this.comentario.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fechaenvio";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fecha.Width = 120;
            // 
            // Bruto
            // 
            this.Bruto.DataPropertyName = "bruto";
            this.Bruto.HeaderText = "Bruto";
            this.Bruto.Name = "Bruto";
            this.Bruto.ReadOnly = true;
            this.Bruto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bruto.Width = 80;
            // 
            // importe
            // 
            this.importe.DataPropertyName = "total";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.importe.Width = 80;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "exit.png");
            this.imageList2.Images.SetKeyName(1, "pedido.png");
            this.imageList2.Images.SetKeyName(2, "carrito.png");
            this.imageList2.Images.SetKeyName(3, "delete-file-icon.png");
            this.imageList2.Images.SetKeyName(4, "DeleteRed.png");
            this.imageList2.Images.SetKeyName(5, "document_delete.png");
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(1018, 371);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.ImageIndex = 10;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(25, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 37);
            this.button1.TabIndex = 34;
            this.button1.Text = "Actualizar Transferencias";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIrNota
            // 
            this.btnIrNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrNota.ImageIndex = 22;
            this.btnIrNota.ImageList = this.imageList1;
            this.btnIrNota.Location = new System.Drawing.Point(911, 371);
            this.btnIrNota.Name = "btnIrNota";
            this.btnIrNota.Size = new System.Drawing.Size(101, 37);
            this.btnIrNota.TabIndex = 35;
            this.btnIrNota.Text = "Ir Tranferencia";
            this.btnIrNota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIrNota.UseVisualStyleBackColor = true;
            this.btnIrNota.Click += new System.EventHandler(this.btnIrNota_Click);
            // 
            // button2
            // 
            this.button2.ImageIndex = 21;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(954, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 33);
            this.button2.TabIndex = 33;
            this.button2.Text = "Reporte Transferencia";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // F2TransferenciasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 417);
            this.Controls.Add(this.btnIrNota);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "F2TransferenciasPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F2TransferenciasPendientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferenciasPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DataGridView dgvTransferenciasPendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIrNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDirecta;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlmacenO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlmacenOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAlmacenDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacendestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn DecripcionRechazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodTDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaentrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn montodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn codUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAutorizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codListaPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button2;


    }
}