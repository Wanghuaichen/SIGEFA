namespace SIGEFA.Formularios
{
    partial class frmNotasDebitoCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotasDebitoCompras));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAnular = new System.Windows.Forms.Button();
            this.btGenVenta = new System.Windows.Forms.Button();
            this.btnIrGuia = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNotasCredito = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codreferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerorefencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProveedors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReporte);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notas de Credito";
            // 
            // btnReporte
            // 
            this.btnReporte.ImageIndex = 11;
            this.btnReporte.Location = new System.Drawing.Point(500, 26);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(78, 33);
            this.btnReporte.TabIndex = 60;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(462, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 59;
            this.label6.Text = "x";
            this.label6.Visible = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(99, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(81, 20);
            this.dtpHasta.TabIndex = 58;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged_1);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(12, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(81, 20);
            this.dtpDesde.TabIndex = 57;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged_1);
            // 
            // txtFiltro
            // 
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltro.Location = new System.Drawing.Point(249, 33);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(207, 20);
            this.txtFiltro.TabIndex = 56;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "Desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(247, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "Filtro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(285, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "Por :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(320, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(97, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(23, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "Desde";
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
            this.btnAnular.Location = new System.Drawing.Point(18, 13);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(102, 37);
            this.btnAnular.TabIndex = 4;
            this.btnAnular.Text = "Anular Nota de Credito";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Visible = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btGenVenta
            // 
            this.btGenVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenVenta.ImageIndex = 2;
            this.btGenVenta.ImageList = this.imageList1;
            this.btGenVenta.Location = new System.Drawing.Point(922, 13);
            this.btGenVenta.Name = "btGenVenta";
            this.btGenVenta.Size = new System.Drawing.Size(96, 37);
            this.btGenVenta.TabIndex = 3;
            this.btGenVenta.Text = "Documento Referencia";
            this.btGenVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGenVenta.UseVisualStyleBackColor = true;
            this.btGenVenta.Click += new System.EventHandler(this.btGenVenta_Click);
            // 
            // btnIrGuia
            // 
            this.btnIrGuia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrGuia.ImageIndex = 1;
            this.btnIrGuia.ImageList = this.imageList1;
            this.btnIrGuia.Location = new System.Drawing.Point(1024, 13);
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
            this.btnSalir.Location = new System.Drawing.Point(1123, 13);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 37);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAnular);
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.btGenVenta);
            this.groupBox2.Controls.Add(this.btnIrGuia);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1204, 56);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // dgvNotasCredito
            // 
            this.dgvNotasCredito.AllowUserToAddRows = false;
            this.dgvNotasCredito.AllowUserToDeleteRows = false;
            this.dgvNotasCredito.AllowUserToOrderColumns = true;
            this.dgvNotasCredito.AllowUserToResizeRows = false;
            this.dgvNotasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNotasCredito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numdoc,
            this.cliente,
            this.fechaemision,
            this.docref,
            this.codreferencia,
            this.anulado,
            this.responsable,
            this.numerorefencias,
            this.codProveedors,
            this.NotaIngreso});
            this.dgvNotasCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotasCredito.Location = new System.Drawing.Point(0, 70);
            this.dgvNotasCredito.MultiSelect = false;
            this.dgvNotasCredito.Name = "dgvNotasCredito";
            this.dgvNotasCredito.ReadOnly = true;
            this.dgvNotasCredito.RowHeadersVisible = false;
            this.dgvNotasCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotasCredito.Size = new System.Drawing.Size(1204, 406);
            this.dgvNotasCredito.TabIndex = 52;
            this.dgvNotasCredito.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotasCredito_CellDoubleClick);
            this.dgvNotasCredito.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNotasCredito_ColumnHeaderMouseClick);
            this.dgvNotasCredito.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvNotasCredito_RowStateChanged_1);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codNotaSalida";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.Width = 80;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "N. Doc.";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "razonsocial";
            this.cliente.HeaderText = "Proveedor";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cliente.Width = 270;
            // 
            // fechaemision
            // 
            this.fechaemision.DataPropertyName = "fecha";
            this.fechaemision.HeaderText = "F. Emision";
            this.fechaemision.Name = "fechaemision";
            this.fechaemision.ReadOnly = true;
            this.fechaemision.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fechaemision.Width = 120;
            // 
            // docref
            // 
            this.docref.DataPropertyName = "documentoreferencia";
            this.docref.HeaderText = "Doc. Ref.";
            this.docref.Name = "docref";
            this.docref.ReadOnly = true;
            this.docref.Visible = false;
            // 
            // codreferencia
            // 
            this.codreferencia.DataPropertyName = "codReferencia";
            this.codreferencia.HeaderText = "Cod. ref";
            this.codreferencia.Name = "codreferencia";
            this.codreferencia.ReadOnly = true;
            this.codreferencia.Visible = false;
            // 
            // anulado
            // 
            this.anulado.DataPropertyName = "anulado";
            this.anulado.HeaderText = "Estado";
            this.anulado.Name = "anulado";
            this.anulado.ReadOnly = true;
            // 
            // responsable
            // 
            this.responsable.DataPropertyName = "responsable";
            this.responsable.HeaderText = "Responsable";
            this.responsable.Name = "responsable";
            this.responsable.ReadOnly = true;
            this.responsable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.responsable.Width = 150;
            // 
            // numerorefencias
            // 
            this.numerorefencias.DataPropertyName = "numerorefencia";
            this.numerorefencias.HeaderText = "Num. Doc. Ref";
            this.numerorefencias.Name = "numerorefencias";
            this.numerorefencias.ReadOnly = true;
            // 
            // codProveedors
            // 
            this.codProveedors.DataPropertyName = "codProveedor";
            this.codProveedors.HeaderText = "codProveedor";
            this.codProveedors.Name = "codProveedors";
            this.codProveedors.ReadOnly = true;
            this.codProveedors.Visible = false;
            // 
            // NotaIngreso
            // 
            this.NotaIngreso.DataPropertyName = "codNotaIngreso";
            this.NotaIngreso.HeaderText = "NotaIngreso";
            this.NotaIngreso.Name = "NotaIngreso";
            this.NotaIngreso.ReadOnly = true;
            this.NotaIngreso.Visible = false;
            // 
            // frmNotasDebitoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 476);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvNotasCredito);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotasDebitoCompras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas de Debito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNotasDebitoCompras_Load);
            this.Shown += new System.EventHandler(this.frmNotasDebitoCompras_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasCredito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIrGuia;
        private System.Windows.Forms.Button btGenVenta;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvNotasCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn docref;
        private System.Windows.Forms.DataGridViewTextBoxColumn codreferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn anulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerorefencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProveedors;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaIngreso;
    }
}