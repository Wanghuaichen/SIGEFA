namespace SIGEFA.Formularios
{
    partial class frmPagosDetraccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosDetraccion));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.biAprobar = new DevComponents.DotNetBar.ButtonItem();
            this.biDesaprobar = new DevComponents.DotNetBar.ButtonItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRendicion = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.DOCUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTOCOBRADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONEDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backAprobacion = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
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
            this.panel1.Controls.Add(this.ribbonBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 77);
            this.panel1.TabIndex = 13;
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
            this.ribbonBar1.Controls.Add(this.btnBusqueda);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.cmbEstado);
            this.ribbonBar1.Controls.Add(this.dtpFecha2);
            this.ribbonBar1.Controls.Add(this.dtpFecha1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAprobar,
            this.biDesaprobar});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1164, 77);
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
            // btnBusqueda
            // 
            this.btnBusqueda.ImageIndex = 11;
            this.btnBusqueda.ImageList = this.imageList1;
            this.btnBusqueda.Location = new System.Drawing.Point(676, 28);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(98, 33);
            this.btnBusqueda.TabIndex = 47;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(501, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(414, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(327, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "Desde";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "CANCELADOS",
            "PENDIENTES"});
            this.cmbEstado.Location = new System.Drawing.Point(504, 36);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 20);
            this.cmbEstado.TabIndex = 39;
            this.cmbEstado.SelectionChangeCommitted += new System.EventHandler(this.cmbEstado_SelectionChangeCommitted);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(417, 36);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha2.TabIndex = 38;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(330, 36);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha1.TabIndex = 37;
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
            this.biAprobar.Click += new System.EventHandler(this.biAprobar_Click);
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
            this.biDesaprobar.Click += new System.EventHandler(this.biDesaprobar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRendicion});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 26);
            // 
            // tsmiRendicion
            // 
            this.tsmiRendicion.Image = ((System.Drawing.Image)(resources.GetObject("tsmiRendicion.Image")));
            this.tsmiRendicion.Name = "tsmiRendicion";
            this.tsmiRendicion.Size = new System.Drawing.Size(173, 22);
            this.tsmiRendicion.Text = "Eliminar Rendicion";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOCUMENTO,
            this.proveedor,
            this.MONTOCOBRADO,
            this.MONEDA,
            this.OBSERVACION,
            this.Aprobado1,
            this.codPago});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 77);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1164, 315);
            this.dgvDetalle.TabIndex = 18;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            this.dgvDetalle.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvDetalle_RowStateChanged);
            // 
            // DOCUMENTO
            // 
            this.DOCUMENTO.DataPropertyName = "documento";
            this.DOCUMENTO.HeaderText = "DOCUMENTO";
            this.DOCUMENTO.Name = "DOCUMENTO";
            this.DOCUMENTO.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.DataPropertyName = "razonsocial";
            this.proveedor.HeaderText = "PROVEEDOR";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 300;
            // 
            // MONTOCOBRADO
            // 
            this.MONTOCOBRADO.DataPropertyName = "montopagado";
            this.MONTOCOBRADO.HeaderText = "MONTO";
            this.MONTOCOBRADO.Name = "MONTOCOBRADO";
            this.MONTOCOBRADO.ReadOnly = true;
            // 
            // MONEDA
            // 
            this.MONEDA.DataPropertyName = "moneda";
            this.MONEDA.HeaderText = "MONEDA";
            this.MONEDA.Name = "MONEDA";
            this.MONEDA.ReadOnly = true;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.DataPropertyName = "observacion";
            this.OBSERVACION.HeaderText = "OBSERVACION";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.ReadOnly = true;
            this.OBSERVACION.Width = 200;
            // 
            // Aprobado1
            // 
            this.Aprobado1.DataPropertyName = "Aprobado";
            this.Aprobado1.HeaderText = "Aprobado1";
            this.Aprobado1.Name = "Aprobado1";
            this.Aprobado1.ReadOnly = true;
            this.Aprobado1.Visible = false;
            // 
            // codPago
            // 
            this.codPago.DataPropertyName = "codPago";
            this.codPago.HeaderText = "codPago";
            this.codPago.Name = "codPago";
            this.codPago.ReadOnly = true;
            this.codPago.Visible = false;
            // 
            // backAprobacion
            // 
            this.backAprobacion.WorkerReportsProgress = true;
            this.backAprobacion.WorkerSupportsCancellation = true;
            this.backAprobacion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backAprobacion_DoWork);
            this.backAprobacion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backAprobacion_RunWorkerCompleted);
            this.backAprobacion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backAprobacion_ProgressChanged);
            // 
            // frmPagosDetraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 392);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPagosDetraccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aprobacion Pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAprobacionPagos_Load);
            this.panel1.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem biAprobar;
        private DevComponents.DotNetBar.ButtonItem biDesaprobar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRendicion;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.ComponentModel.BackgroundWorker backAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCUMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTOCOBRADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONEDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aprobado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPago;

    }
}