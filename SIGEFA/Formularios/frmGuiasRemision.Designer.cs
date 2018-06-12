namespace SIGEFA.Formularios
{
    partial class frmGuiasRemision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuiasRemision));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGuiasRemision = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAnular = new System.Windows.Forms.Button();
            this.btGenVenta = new System.Windows.Forms.Button();
            this.btnIrGuia = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadofacturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroguia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuiasRemision)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvGuiasRemision);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de guias";
            // 
            // dgvGuiasRemision
            // 
            this.dgvGuiasRemision.AllowUserToAddRows = false;
            this.dgvGuiasRemision.AllowUserToDeleteRows = false;
            this.dgvGuiasRemision.AllowUserToOrderColumns = true;
            this.dgvGuiasRemision.AllowUserToResizeRows = false;
            this.dgvGuiasRemision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGuiasRemision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numdoc,
            this.factura,
            this.cliente,
            this.fecha,
            this.fechaemision,
            this.responsable,
            this.facturado,
            this.estadofacturado,
            this.codMotivo,
            this.numeroguia});
            this.dgvGuiasRemision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGuiasRemision.Location = new System.Drawing.Point(3, 16);
            this.dgvGuiasRemision.MultiSelect = false;
            this.dgvGuiasRemision.Name = "dgvGuiasRemision";
            this.dgvGuiasRemision.ReadOnly = true;
            this.dgvGuiasRemision.RowHeadersVisible = false;
            this.dgvGuiasRemision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuiasRemision.Size = new System.Drawing.Size(1198, 402);
            this.dgvGuiasRemision.TabIndex = 0;
            this.dgvGuiasRemision.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidosPendientes_CellDoubleClick);
            this.dgvGuiasRemision.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvPedidosPendientes_RowStateChanged);
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
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnular.ImageIndex = 4;
            this.btnAnular.ImageList = this.imageList1;
            this.btnAnular.Location = new System.Drawing.Point(77, 427);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(96, 37);
            this.btnAnular.TabIndex = 4;
            this.btnAnular.Text = "Anular Guia";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btGenVenta
            // 
            this.btGenVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenVenta.ImageIndex = 2;
            this.btGenVenta.ImageList = this.imageList1;
            this.btGenVenta.Location = new System.Drawing.Point(916, 427);
            this.btGenVenta.Name = "btGenVenta";
            this.btGenVenta.Size = new System.Drawing.Size(96, 37);
            this.btGenVenta.TabIndex = 3;
            this.btGenVenta.Text = "Generar Venta";
            this.btGenVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGenVenta.UseVisualStyleBackColor = true;
            this.btGenVenta.Visible = false;
            this.btGenVenta.Click += new System.EventHandler(this.btGenVenta_Click);
            // 
            // btnIrGuia
            // 
            this.btnIrGuia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrGuia.ImageIndex = 1;
            this.btnIrGuia.ImageList = this.imageList1;
            this.btnIrGuia.Location = new System.Drawing.Point(1018, 427);
            this.btnIrGuia.Name = "btnIrGuia";
            this.btnIrGuia.Size = new System.Drawing.Size(93, 37);
            this.btnIrGuia.TabIndex = 2;
            this.btnIrGuia.Text = "Consultar";
            this.btnIrGuia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIrGuia.UseVisualStyleBackColor = true;
            this.btnIrGuia.Click += new System.EventHandler(this.btnIrPedido_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(1117, 427);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codGuiaRemision";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Width = 80;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "N° Doc.";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            // 
            // factura
            // 
            this.factura.DataPropertyName = "factura";
            this.factura.HeaderText = "Boleta/Factura";
            this.factura.Name = "factura";
            this.factura.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cliente.Width = 270;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "F. Traslado";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fecha.Width = 120;
            // 
            // fechaemision
            // 
            this.fechaemision.DataPropertyName = "fechaemision";
            this.fechaemision.HeaderText = "F. Emision";
            this.fechaemision.Name = "fechaemision";
            this.fechaemision.ReadOnly = true;
            this.fechaemision.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fechaemision.Width = 120;
            // 
            // responsable
            // 
            this.responsable.DataPropertyName = "responsable";
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.responsable.Width = 180;
            // 
            // facturado
            // 
            this.facturado.DataPropertyName = "facturado";
            this.facturado.HeaderText = "facturado";
            this.facturado.Name = "facturado";
            this.facturado.ReadOnly = true;
            this.facturado.Visible = false;
            // 
            // estadofacturado
            // 
            this.estadofacturado.DataPropertyName = "estadofacturado";
            this.estadofacturado.HeaderText = "Estado";
            this.estadofacturado.Name = "estadofacturado";
            this.estadofacturado.ReadOnly = true;
            // 
            // codMotivo
            // 
            this.codMotivo.DataPropertyName = "codMotivo";
            this.codMotivo.HeaderText = "codMotivo";
            this.codMotivo.Name = "codMotivo";
            this.codMotivo.ReadOnly = true;
            this.codMotivo.Visible = false;
            // 
            // numeroguia
            // 
            this.numeroguia.DataPropertyName = "numeroguia";
            this.numeroguia.HeaderText = "numeroguia";
            this.numeroguia.Name = "numeroguia";
            this.numeroguia.ReadOnly = true;
            this.numeroguia.Visible = false;
            // 
            // frmGuiasRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 476);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btGenVenta);
            this.Controls.Add(this.btnIrGuia);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGuiasRemision";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guias Remision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidosPendientes_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuiasRemision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGuiasRemision;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIrGuia;
        private System.Windows.Forms.Button btGenVenta;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadofacturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroguia;
    }
}