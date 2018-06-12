namespace SIGEFA.Formularios
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.biNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.biEditar = new DevComponents.DotNetBar.ButtonItem();
            this.biEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.biAccesos = new DevComponents.DotNetBar.ButtonItem();
            this.biAccesosSucursal = new DevComponents.DotNetBar.ButtonItem();
            this.biConsultar = new DevComponents.DotNetBar.ButtonItem();
            this.biActualizar = new DevComponents.DotNetBar.ButtonItem();
            this.biBuscar = new DevComponents.DotNetBar.ButtonItem();
            this.biImprimir = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechanac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coduser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechareg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "buttonItem1";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "buttonItem2";
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
            this.ribbonBar2.Images = this.imageList1;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biNuevo,
            this.biEditar,
            this.biEliminar,
            this.biAccesos,
            this.biAccesosSucursal,
            this.biConsultar,
            this.biActualizar,
            this.biBuscar,
            this.biImprimir});
            this.ribbonBar2.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(778, 70);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar2.TabIndex = 2;
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
            this.imageList1.Images.SetKeyName(9, "search (1).png");
            this.imageList1.Images.SetKeyName(10, "89868_65787_exit_64x64.png");
            this.imageList1.Images.SetKeyName(11, "folder_open (1).png");
            this.imageList1.Images.SetKeyName(12, "folder-open-icon (1).png");
            this.imageList1.Images.SetKeyName(13, "superSecure.png");
            // 
            // biNuevo
            // 
            this.biNuevo.ImageIndex = 4;
            this.biNuevo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biNuevo.Name = "biNuevo";
            this.biNuevo.SubItemsExpandWidth = 14;
            this.biNuevo.Text = "Nuevo";
            this.biNuevo.Click += new System.EventHandler(this.buttonItem16_Click);
            // 
            // biEditar
            // 
            this.biEditar.ImageIndex = 3;
            this.biEditar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEditar.Name = "biEditar";
            this.biEditar.SubItemsExpandWidth = 14;
            this.biEditar.Text = "Modificar";
            this.biEditar.Click += new System.EventHandler(this.buttonItem6_Click);
            // 
            // biEliminar
            // 
            this.biEliminar.ImageIndex = 5;
            this.biEliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biEliminar.Name = "biEliminar";
            this.biEliminar.SubItemsExpandWidth = 14;
            this.biEliminar.Text = "Eliminar";
            this.biEliminar.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // biAccesos
            // 
            this.biAccesos.ImageIndex = 10;
            this.biAccesos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biAccesos.Name = "biAccesos";
            this.biAccesos.SubItemsExpandWidth = 14;
            this.biAccesos.Text = "Accesos";
            this.biAccesos.Click += new System.EventHandler(this.buttonItem10_Click);
            // 
            // biAccesosSucursal
            // 
            this.biAccesosSucursal.Enabled = false;
            this.biAccesosSucursal.ImageIndex = 13;
            this.biAccesosSucursal.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biAccesosSucursal.Name = "biAccesosSucursal";
            this.biAccesosSucursal.SubItemsExpandWidth = 14;
            this.biAccesosSucursal.Text = "Accesos Sucursal";
            this.biAccesosSucursal.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // biConsultar
            // 
            this.biConsultar.ImageIndex = 12;
            this.biConsultar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biConsultar.Name = "biConsultar";
            this.biConsultar.SubItemsExpandWidth = 14;
            this.biConsultar.Text = "Consultar";
            this.biConsultar.Click += new System.EventHandler(this.biConsultar_Click);
            // 
            // biActualizar
            // 
            this.biActualizar.ImageIndex = 8;
            this.biActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biActualizar.Name = "biActualizar";
            this.biActualizar.SubItemsExpandWidth = 14;
            this.biActualizar.Text = "Actualizar";
            this.biActualizar.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // biBuscar
            // 
            this.biBuscar.ImageIndex = 9;
            this.biBuscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biBuscar.Name = "biBuscar";
            this.biBuscar.SubItemsExpandWidth = 14;
            this.biBuscar.Text = "Buscar";
            this.biBuscar.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // biImprimir
            // 
            this.biImprimir.ImageIndex = 7;
            this.biImprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biImprimir.Name = "biImprimir";
            this.biImprimir.SubItemsExpandWidth = 14;
            this.biImprimir.Text = "Imprimir";
            this.biImprimir.Click += new System.EventHandler(this.biImprimir_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.ImageIndex = 6;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Text = "Nota de Ingreso";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.dni,
            this.nombre,
            this.apellido,
            this.fechanac,
            this.direccion,
            this.telefono,
            this.celular,
            this.email,
            this.usuario,
            this.contra,
            this.estado,
            this.coduser,
            this.fechareg,
            this.Nivel});
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 70);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(778, 404);
            this.dgvUsuarios.TabIndex = 4;
            this.dgvUsuarios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_ColumnHeaderMouseClick);
            this.dgvUsuarios.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_CellMouseDoubleClick);
            this.dgvUsuarios.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvUsuarios_RowStateChanged_1);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codUsuario";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Visible = false;
            this.codigo.Width = 80;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dni.DefaultCellStyle = dataGridViewCellStyle6;
            this.dni.HeaderText = "Dni";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dni.Width = 80;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombres";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nombre.Width = 200;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellidos";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.apellido.Width = 200;
            // 
            // fechanac
            // 
            this.fechanac.DataPropertyName = "fechanac";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.fechanac.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechanac.HeaderText = "Fecha Nac.";
            this.fechanac.Name = "fechanac";
            this.fechanac.ReadOnly = true;
            this.fechanac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechanac.Width = 80;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.direccion.Width = 200;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.telefono.DefaultCellStyle = dataGridViewCellStyle8;
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.telefono.Width = 80;
            // 
            // celular
            // 
            this.celular.DataPropertyName = "celular";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.celular.DefaultCellStyle = dataGridViewCellStyle9;
            this.celular.HeaderText = "Celular";
            this.celular.Name = "celular";
            this.celular.ReadOnly = true;
            this.celular.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.celular.Width = 80;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "Username";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contra
            // 
            this.contra.DataPropertyName = "contrasena";
            this.contra.HeaderText = "Contaseña";
            this.contra.Name = "contra";
            this.contra.ReadOnly = true;
            this.contra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contra.Visible = false;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado.Width = 80;
            // 
            // coduser
            // 
            this.coduser.DataPropertyName = "codUser";
            this.coduser.HeaderText = "CodUser";
            this.coduser.Name = "coduser";
            this.coduser.ReadOnly = true;
            this.coduser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.coduser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coduser.Visible = false;
            // 
            // fechareg
            // 
            this.fechareg.DataPropertyName = "fecharegistro";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.fechareg.DefaultCellStyle = dataGridViewCellStyle10;
            this.fechareg.HeaderText = "Fecha Reg.";
            this.fechareg.Name = "fechareg";
            this.fechareg.ReadOnly = true;
            this.fechareg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechareg.Width = 80;
            // 
            // Nivel
            // 
            this.Nivel.DataPropertyName = "nivel";
            this.Nivel.HeaderText = "nivel";
            this.Nivel.Name = "Nivel";
            this.Nivel.ReadOnly = true;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandablePanel1.AnimationTime = 200;
            this.expandablePanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.expandablePanel1.Controls.Add(this.label4);
            this.expandablePanel1.Controls.Add(this.label3);
            this.expandablePanel1.Controls.Add(this.label2);
            this.expandablePanel1.Controls.Add(this.txtFiltro);
            this.expandablePanel1.Controls.Add(this.label1);
            this.expandablePanel1.Controls.Add(this.btnSalir);
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
            this.expandablePanel1.TabIndex = 7;
            this.expandablePanel1.TitleHeight = 0;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Title Bar";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, -59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Por :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, -89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Busqueda";
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
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 474);
            this.Controls.Add(this.expandablePanel1);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.ribbonBar2);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.Shown += new System.EventHandler(this.frmUsuarios_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonItem biNuevo;
        private DevComponents.DotNetBar.ButtonItem biEditar;
        private DevComponents.DotNetBar.ButtonItem biEliminar;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem biConsultar;
        private DevComponents.DotNetBar.ButtonItem biActualizar;
        private DevComponents.DotNetBar.ButtonItem biBuscar;
        private DevComponents.DotNetBar.ButtonItem biImprimir;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private DevComponents.DotNetBar.ButtonItem biAccesos;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonItem biAccesosSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechanac;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn contra;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn coduser;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechareg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;

    }
}