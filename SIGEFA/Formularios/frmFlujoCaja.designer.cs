namespace SIGEFA.Formularios
{
    partial class frmFlujoCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlujoCaja));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.biNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.biEditar = new DevComponents.DotNetBar.ButtonItem();
            this.biEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.biActualizar = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.biImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.dgvFlujoCaja = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlujoCaja)).BeginInit();
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
            this.imageList1.Images.SetKeyName(16, "icon-47203_640.png");
            this.imageList1.Images.SetKeyName(17, "Folder open.png");
            this.imageList1.Images.SetKeyName(18, "por-periodo-de-sesiones-icono-8745-96.png");
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.Images = this.imageList1;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biNuevo,
            this.biEditar,
            this.biEliminar,
            this.biActualizar,
            this.buttonItem7,
            this.biImprimir,
            this.buttonItem9});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1146, 65);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar1.TabIndex = 6;
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
            // biNuevo
            // 
            this.biNuevo.ImageIndex = 4;
            this.biNuevo.ImagePaddingHorizontal = 10;
            this.biNuevo.ImagePaddingVertical = 15;
            this.biNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biNuevo.Name = "biNuevo";
            this.biNuevo.SubItemsExpandWidth = 14;
            this.biNuevo.Text = "Nuevo";
            this.biNuevo.Click += new System.EventHandler(this.buttonItem3_Click);
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
            // biEliminar
            // 
            this.biEliminar.ImageIndex = 5;
            this.biEliminar.ImagePaddingHorizontal = 10;
            this.biEliminar.ImagePaddingVertical = 15;
            this.biEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEliminar.Name = "biEliminar";
            this.biEliminar.SubItemsExpandWidth = 14;
            this.biEliminar.Text = "Eliminar";
            this.biEliminar.Click += new System.EventHandler(this.biEliminar_Click);
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
            this.biActualizar.Click += new System.EventHandler(this.buttonItem6_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImageIndex = 11;
            this.buttonItem7.ImagePaddingHorizontal = 10;
            this.buttonItem7.ImagePaddingVertical = 15;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlB);
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Text = "Buscar";
            this.buttonItem7.Visible = false;
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
            this.biImprimir.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // buttonItem9
            // 
            this.buttonItem9.ImageIndex = 18;
            this.buttonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.SubItemsExpandWidth = 14;
            this.buttonItem9.Text = "Salir";
            this.buttonItem9.Click += new System.EventHandler(this.buttonItem9_Click);
            // 
            // dgvFlujoCaja
            // 
            this.dgvFlujoCaja.AllowUserToAddRows = false;
            this.dgvFlujoCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlujoCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.fecha,
            this.concepto,
            this.monto,
            this.tipo,
            this.codAlmacen});
            this.dgvFlujoCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlujoCaja.Location = new System.Drawing.Point(0, 65);
            this.dgvFlujoCaja.MultiSelect = false;
            this.dgvFlujoCaja.Name = "dgvFlujoCaja";
            this.dgvFlujoCaja.ReadOnly = true;
            this.dgvFlujoCaja.RowHeadersVisible = false;
            this.dgvFlujoCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlujoCaja.Size = new System.Drawing.Size(1146, 458);
            this.dgvFlujoCaja.TabIndex = 7;
            this.dgvFlujoCaja.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlujoCaja_CellDoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codFlujoCaja";
            this.codigo.HeaderText = "CODIGO";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            this.codigo.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "FECHA";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 90;
            // 
            // concepto
            // 
            this.concepto.DataPropertyName = "concepto";
            this.concepto.HeaderText = "CONCEPTO";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 750;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            this.monto.HeaderText = "MONTO";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 120;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "TIPO";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 250;
            // 
            // codAlmacen
            // 
            this.codAlmacen.DataPropertyName = "codAlmacen";
            this.codAlmacen.HeaderText = "ALMACEN";
            this.codAlmacen.Name = "codAlmacen";
            this.codAlmacen.ReadOnly = true;
            this.codAlmacen.Visible = false;
            // 
            // frmFlujoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 523);
            this.Controls.Add(this.dgvFlujoCaja);
            this.Controls.Add(this.ribbonBar1);
            this.DoubleBuffered = true;
            this.Name = "frmFlujoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONTROL DE FLUJO CAJA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFlujoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlujoCaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem biNuevo;
        private DevComponents.DotNetBar.ButtonItem biEditar;
        private DevComponents.DotNetBar.ButtonItem biEliminar;
        private DevComponents.DotNetBar.ButtonItem biActualizar;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem biImprimir;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        public System.Windows.Forms.DataGridView dgvFlujoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAlmacen;
    }
}