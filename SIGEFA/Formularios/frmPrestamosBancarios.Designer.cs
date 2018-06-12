namespace SIGEFA.Formularios
{
    partial class frmPrestamosBancarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrestamosBancarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnModificar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.btnCopiar = new DevComponents.DotNetBar.ButtonItem();
            this.btnActualizar = new DevComponents.DotNetBar.ButtonItem();
            this.btnBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.btnImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.biFiltros = new DevComponents.DotNetBar.ButtonItem();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codperso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonsocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionlegal = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zona = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montomora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaprecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esta = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.cancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.muestraPagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjearPorCuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImpCuota = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.expandablePanel1.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(16, "folder-open-icon.png");
            this.imageList1.Images.SetKeyName(17, "dagobert83-neg.png");
            this.imageList1.Images.SetKeyName(18, "pouce_bas.png");
            this.imageList1.Images.SetKeyName(19, "OK_png.png");
            this.imageList1.Images.SetKeyName(20, "clientes-satisfechos.png");
            this.imageList1.Images.SetKeyName(21, "13630_13798_128_filter_icon.png");
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Top;
            //this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Images = this.imageList1;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNuevo,
            this.btnModificar,
            this.btnEliminar,
            this.btnCopiar,
            this.btnActualizar,
            this.btnBuscar,
            this.btnImprimir,
            this.btnImpCuota,
            this.buttonItem1,
            this.buttonItem2,
            this.biFiltros});
            this.ribbonBar2.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(778, 55);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar2.TabIndex = 5;
            this.ribbonBar2.Text = "ribbonBar2";
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
            // btnNuevo
            // 
            this.btnNuevo.ImageIndex = 4;
            this.btnNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ImageIndex = 3;
            this.btnModificar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.SubItemsExpandWidth = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageIndex = 5;
            this.btnEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.ImageIndex = 16;
            this.btnCopiar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.SubItemsExpandWidth = 14;
            this.btnCopiar.Text = "Consultar";
            this.btnCopiar.Visible = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ImageIndex = 8;
            this.btnActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.SubItemsExpandWidth = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageIndex = 11;
            this.btnBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.SubItemsExpandWidth = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageIndex = 7;
            this.btnImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.SubItemsExpandWidth = 14;
            this.btnImprimir.Text = "Listado";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImageIndex = 17;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "Inhabilitar";
            this.buttonItem1.Visible = false;
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImageIndex = 19;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "Habilitar";
            this.buttonItem2.Visible = false;
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // biFiltros
            // 
            this.biFiltros.ImageIndex = 21;
            this.biFiltros.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biFiltros.Name = "biFiltros";
            this.biFiltros.SubItemsExpandWidth = 14;
            this.biFiltros.Text = "Filtro";
            this.biFiltros.Click += new System.EventHandler(this.biFiltros_Click);
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AllowUserToResizeColumns = false;
            this.dgvPrestamos.AllowUserToResizeRows = false;
            this.dgvPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.codperso,
            this.dni,
            this.ruc,
            this.razonsocial,
            this.direccionlegal,
            this.telefono,
            this.zona,
            this.pendiente,
            this.montomora,
            this.listaprecio,
            this.habilitado,
            this.fechacancelado,
            this.crono,
            this.esta,
            this.cancelado,
            this.descripcion});
            this.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrestamos.Location = new System.Drawing.Point(0, 55);
            this.dgvPrestamos.MultiSelect = false;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersVisible = false;
            this.dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.Size = new System.Drawing.Size(778, 419);
            this.dgvPrestamos.TabIndex = 16;
            this.dgvPrestamos.Sorted += new System.EventHandler(this.dgvClientes_Sorted);
            this.dgvPrestamos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientes_ColumnHeaderMouseClick);
            this.dgvPrestamos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrestamos_CellMouseDown);
            this.dgvPrestamos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrestamos_CellFormatting);
            this.dgvPrestamos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientes_CellMouseDoubleClick);
            this.dgvPrestamos.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvClientes_RowStateChanged);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codPrestamoBancario";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 80;
            // 
            // codperso
            // 
            this.codperso.DataPropertyName = "CodBanco";
            this.codperso.HeaderText = "codBanco";
            this.codperso.Name = "codperso";
            this.codperso.ReadOnly = true;
            this.codperso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codperso.Visible = false;
            this.codperso.Width = 70;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "descBanco";
            this.dni.HeaderText = "Banco";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dni.Width = 200;
            // 
            // ruc
            // 
            this.ruc.DataPropertyName = "CodMoneda";
            this.ruc.HeaderText = "codMoneda";
            this.ruc.Name = "ruc";
            this.ruc.ReadOnly = true;
            this.ruc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ruc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ruc.Visible = false;
            // 
            // razonsocial
            // 
            this.razonsocial.DataPropertyName = "descMoneda";
            this.razonsocial.HeaderText = "Moneda";
            this.razonsocial.Name = "razonsocial";
            this.razonsocial.ReadOnly = true;
            this.razonsocial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.razonsocial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.razonsocial.Width = 150;
            // 
            // direccionlegal
            // 
            this.direccionlegal.DataPropertyName = "montoprestamo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.direccionlegal.DefaultCellStyle = dataGridViewCellStyle6;
            this.direccionlegal.HeaderText = "Prestamo";
            this.direccionlegal.Name = "direccionlegal";
            this.direccionlegal.ReadOnly = true;
            this.direccionlegal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.direccionlegal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.direccionlegal.Width = 80;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "montointeres";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.telefono.DefaultCellStyle = dataGridViewCellStyle7;
            this.telefono.HeaderText = "Interes";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.telefono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.telefono.Width = 80;
            // 
            // zona
            // 
            this.zona.AutomaticSortingEnabled = false;
            this.zona.DataPropertyName = "montodevolver";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.zona.DefaultCellStyle = dataGridViewCellStyle8;
            this.zona.HeaderText = "Total Deuda";
            this.zona.Name = "zona";
            this.zona.ReadOnly = true;
            this.zona.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.zona.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.zona.Width = 80;
            // 
            // pendiente
            // 
            this.pendiente.DataPropertyName = "pendiente";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pendiente.DefaultCellStyle = dataGridViewCellStyle9;
            this.pendiente.HeaderText = "Saldo";
            this.pendiente.Name = "pendiente";
            this.pendiente.ReadOnly = true;
            this.pendiente.Width = 80;
            // 
            // montomora
            // 
            this.montomora.DataPropertyName = "montomora";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.montomora.DefaultCellStyle = dataGridViewCellStyle10;
            this.montomora.HeaderText = "Mora";
            this.montomora.Name = "montomora";
            this.montomora.ReadOnly = true;
            this.montomora.Width = 80;
            // 
            // listaprecio
            // 
            this.listaprecio.DataPropertyName = "fechaaprobacion";
            this.listaprecio.HeaderText = "Aprobado";
            this.listaprecio.Name = "listaprecio";
            this.listaprecio.ReadOnly = true;
            this.listaprecio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.listaprecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.listaprecio.Width = 80;
            // 
            // habilitado
            // 
            this.habilitado.DataPropertyName = "fechavencimiento";
            this.habilitado.HeaderText = "Vencimiento";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            this.habilitado.Width = 80;
            // 
            // fechacancelado
            // 
            this.fechacancelado.DataPropertyName = "fechacancelado";
            this.fechacancelado.HeaderText = "Cancelado";
            this.fechacancelado.Name = "fechacancelado";
            this.fechacancelado.ReadOnly = true;
            // 
            // crono
            // 
            this.crono.DataPropertyName = "crono";
            this.crono.HeaderText = "Cronograma";
            this.crono.Name = "crono";
            this.crono.ReadOnly = true;
            this.crono.Width = 80;
            // 
            // esta
            // 
            this.esta.DataPropertyName = "esta";
            this.esta.HeaderText = "Estado";
            this.esta.Name = "esta";
            this.esta.ReadOnly = true;
            this.esta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.esta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cancelado
            // 
            this.cancelado.DataPropertyName = "cancelado";
            this.cancelado.HeaderText = "cancelado";
            this.cancelado.Name = "cancelado";
            this.cancelado.ReadOnly = true;
            this.cancelado.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 200;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandablePanel1.AnimationTime = 200;
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.expandablePanel1.Controls.Add(this.label4);
            this.expandablePanel1.Controls.Add(this.label1);
            this.expandablePanel1.Controls.Add(this.label3);
            this.expandablePanel1.Controls.Add(this.label2);
            this.expandablePanel1.Controls.Add(this.txtFiltro);
            this.expandablePanel1.Controls.Add(this.btnSalir);
            //this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(547, 0, 231, 93);
            this.expandablePanel1.Location = new System.Drawing.Point(547, 0);
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
            this.expandablePanel1.TabIndex = 17;
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, -59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Por :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, -89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Busqueda";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightBlue;
            this.label3.Location = new System.Drawing.Point(186, -59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "x";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, -59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "X";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(13, -38);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(207, 20);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(213, -93);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(18, 22);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "x";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muestraPagosToolStripMenuItem,
            this.canjearPorCuotasToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 54);
            // 
            // muestraPagosToolStripMenuItem
            // 
            this.muestraPagosToolStripMenuItem.Name = "muestraPagosToolStripMenuItem";
            this.muestraPagosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.muestraPagosToolStripMenuItem.Text = "Muestra Cuotas";
            this.muestraPagosToolStripMenuItem.Click += new System.EventHandler(this.muestraPagosToolStripMenuItem_Click);
            // 
            // canjearPorCuotasToolStripMenuItem
            // 
            this.canjearPorCuotasToolStripMenuItem.Name = "canjearPorCuotasToolStripMenuItem";
            this.canjearPorCuotasToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.canjearPorCuotasToolStripMenuItem.Text = "Canjear por Cuotas";
            this.canjearPorCuotasToolStripMenuItem.Click += new System.EventHandler(this.canjearPorCuotasToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // btnImpCuota
            // 
            this.btnImpCuota.ImageIndex = 7;
            this.btnImpCuota.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImpCuota.Name = "btnImpCuota";
            this.btnImpCuota.SubItemsExpandWidth = 14;
            this.btnImpCuota.Text = "Cuotas";
            this.btnImpCuota.Click += new System.EventHandler(this.btnImpCuota_Click);
            // 
            // frmPrestamosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 474);
            this.Controls.Add(this.expandablePanel1);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.ribbonBar2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmPrestamosBancarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prestamos Bancarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientesCompletos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btnNuevo;
        private DevComponents.DotNetBar.ButtonItem btnModificar;
        private DevComponents.DotNetBar.ButtonItem btnEliminar;
        private DevComponents.DotNetBar.ButtonItem btnCopiar;
        private DevComponents.DotNetBar.ButtonItem btnActualizar;
        private DevComponents.DotNetBar.ButtonItem btnBuscar;
        private DevComponents.DotNetBar.ButtonItem btnImprimir;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnSalir;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem biFiltros;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem muestraPagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canjearPorCuotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codperso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonsocial;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn direccionlegal;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn montomora;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaprecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn crono;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn esta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private DevComponents.DotNetBar.ButtonItem btnImpCuota;
    }
}