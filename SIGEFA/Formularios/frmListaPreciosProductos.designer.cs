namespace SIGEFA.Formularios
{
    partial class frmListaPreciosProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPreciosProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator6 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator7 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator5 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator3 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator4 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbmargen = new System.Windows.Forms.Label();
            this.chbModificaMargen = new System.Windows.Forms.CheckBox();
            this.cboLinea = new System.Windows.Forms.ComboBox();
            this.cboFamilia = new System.Windows.Forms.ComboBox();
            this.chbFamilia = new System.Windows.Forms.CheckBox();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.chbRango = new System.Windows.Forms.CheckBox();
            this.txtCodPro2 = new System.Windows.Forms.TextBox();
            this.txtCodPro1 = new System.Windows.Forms.TextBox();
            this.lbLinea = new System.Windows.Forms.Label();
            this.txtProveedorCod = new System.Windows.Forms.TextBox();
            this.txtProveedorNomb = new System.Windows.Forms.TextBox();
            this.txtRango2 = new System.Windows.Forms.TextBox();
            this.txtRProduc2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRango1 = new System.Windows.Forms.TextBox();
            this.txtRProduc1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvDetalleListaPrecio = new System.Windows.Forms.DataGridView();
            this.Modificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codUnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorprom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.margp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreciovSoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleListaPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.btnSalir);
            this.groupBox3.Controls.Add(this.btnReporte);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Location = new System.Drawing.Point(316, 448);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 48);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(173, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 32);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Write Document.png");
            this.imageList1.Images.SetKeyName(1, "New Document.png");
            this.imageList1.Images.SetKeyName(2, "Remove Document.png");
            this.imageList1.Images.SetKeyName(3, "document-print.png");
            this.imageList1.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList1.Images.SetKeyName(5, "exit.png");
            this.imageList1.Images.SetKeyName(6, "OK_Verde.png");
            this.imageList1.Images.SetKeyName(7, "converseen-24.png");
            this.imageList1.Images.SetKeyName(8, "checkmark.png");
            // 
            // btnReporte
            // 
            this.btnReporte.ImageIndex = 3;
            this.btnReporte.ImageList = this.imageList1;
            this.btnReporte.Location = new System.Drawing.Point(6, 10);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(78, 32);
            this.btnReporte.TabIndex = 23;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageIndex = 4;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(90, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 32);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(99, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(312, 20);
            this.txtNombre.TabIndex = 106;
            this.superValidator1.SetValidator1(this.txtNombre, this.customValidator1);
            this.txtNombre.WordWrap = false;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Ingrese el nombre para la lista.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue);
            // 
            // customValidator6
            // 
            this.customValidator6.ErrorMessage = "Ingrese forma de Pago.";
            this.customValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator6.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator6_ValidateValue);
            // 
            // customValidator7
            // 
            this.customValidator7.ErrorMessage = "Lista Origen";
            this.customValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator7.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator7_ValidateValue);
            // 
            // customValidator5
            // 
            this.customValidator5.ErrorMessage = "Ingrese el porcentaje de variación.";
            this.customValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator5.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator5_ValidateValue);
            // 
            // customValidator3
            // 
            this.customValidator3.ErrorMessage = "Ingrese el margen de ganancia.";
            this.customValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator3.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator3_ValidateValue);
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Escoja una lista de origen.";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator2_ValidateValue);
            // 
            // customValidator4
            // 
            this.customValidator4.ErrorMessage = "Ingrese Forma de Pago.";
            this.customValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtNombre);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.lbmargen);
            this.groupBox4.Controls.Add(this.chbModificaMargen);
            this.groupBox4.Controls.Add(this.cboLinea);
            this.groupBox4.Controls.Add(this.cboFamilia);
            this.groupBox4.Controls.Add(this.chbFamilia);
            this.groupBox4.Controls.Add(this.chbProveedor);
            this.groupBox4.Controls.Add(this.chbRango);
            this.groupBox4.Controls.Add(this.txtCodPro2);
            this.groupBox4.Controls.Add(this.txtCodPro1);
            this.groupBox4.Controls.Add(this.lbLinea);
            this.groupBox4.Controls.Add(this.txtProveedorCod);
            this.groupBox4.Controls.Add(this.txtProveedorNomb);
            this.groupBox4.Controls.Add(this.txtRango2);
            this.groupBox4.Controls.Add(this.txtRProduc2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtRango1);
            this.groupBox4.Controls.Add(this.txtRProduc1);
            this.groupBox4.Location = new System.Drawing.Point(6, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(899, 169);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Nombre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(730, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "%";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(671, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 104;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lbmargen
            // 
            this.lbmargen.AutoSize = true;
            this.lbmargen.Location = new System.Drawing.Point(619, 137);
            this.lbmargen.Name = "lbmargen";
            this.lbmargen.Size = new System.Drawing.Size(46, 13);
            this.lbmargen.TabIndex = 103;
            this.lbmargen.Text = "Margen:";
            // 
            // chbModificaMargen
            // 
            this.chbModificaMargen.AutoSize = true;
            this.chbModificaMargen.Enabled = false;
            this.chbModificaMargen.Location = new System.Drawing.Point(773, 136);
            this.chbModificaMargen.Name = "chbModificaMargen";
            this.chbModificaMargen.Size = new System.Drawing.Size(108, 17);
            this.chbModificaMargen.TabIndex = 34;
            this.chbModificaMargen.Text = "Modificar Margen";
            this.chbModificaMargen.UseVisualStyleBackColor = true;
            this.chbModificaMargen.CheckedChanged += new System.EventHandler(this.chbModificaMargen_CheckedChanged);
            // 
            // cboLinea
            // 
            this.cboLinea.FormattingEnabled = true;
            this.cboLinea.Location = new System.Drawing.Point(543, 98);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Size = new System.Drawing.Size(338, 21);
            this.cboLinea.TabIndex = 102;
            this.cboLinea.Visible = false;
            this.cboLinea.SelectionChangeCommitted += new System.EventHandler(this.cboLinea_SelectionChangeCommitted);
            this.cboLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboLinea_KeyDown);
            // 
            // cboFamilia
            // 
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.Location = new System.Drawing.Point(543, 65);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(338, 21);
            this.cboFamilia.TabIndex = 101;
            this.cboFamilia.Visible = false;
            this.cboFamilia.SelectionChangeCommitted += new System.EventHandler(this.cboFamilia_SelectionChangeCommitted);
            this.cboFamilia.Leave += new System.EventHandler(this.cboFamilia_Leave);
            this.cboFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFamilia_KeyDown);
            // 
            // chbFamilia
            // 
            this.chbFamilia.AutoSize = true;
            this.chbFamilia.Location = new System.Drawing.Point(463, 67);
            this.chbFamilia.Name = "chbFamilia";
            this.chbFamilia.Size = new System.Drawing.Size(61, 17);
            this.chbFamilia.TabIndex = 100;
            this.chbFamilia.Text = "Familia:";
            this.chbFamilia.UseVisualStyleBackColor = true;
            this.chbFamilia.TextChanged += new System.EventHandler(this.btnCalularPrecios_Click);
            this.chbFamilia.CheckedChanged += new System.EventHandler(this.chbFamilia_CheckedChanged);
            // 
            // chbProveedor
            // 
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Location = new System.Drawing.Point(6, 123);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(78, 17);
            this.chbProveedor.TabIndex = 99;
            this.chbProveedor.Text = "Proveedor:";
            this.chbProveedor.UseVisualStyleBackColor = true;
            this.chbProveedor.CheckedChanged += new System.EventHandler(this.chbProveedor_CheckedChanged);
            // 
            // chbRango
            // 
            this.chbRango.AutoSize = true;
            this.chbRango.Location = new System.Drawing.Point(6, 51);
            this.chbRango.Name = "chbRango";
            this.chbRango.Size = new System.Drawing.Size(61, 17);
            this.chbRango.TabIndex = 98;
            this.chbRango.Text = "Rango:";
            this.chbRango.UseVisualStyleBackColor = true;
            this.chbRango.CheckedChanged += new System.EventHandler(this.chbRango_CheckedChanged);
            // 
            // txtCodPro2
            // 
            this.txtCodPro2.Enabled = false;
            this.txtCodPro2.Location = new System.Drawing.Point(434, 93);
            this.txtCodPro2.Name = "txtCodPro2";
            this.txtCodPro2.Size = new System.Drawing.Size(20, 20);
            this.txtCodPro2.TabIndex = 97;
            this.txtCodPro2.Visible = false;
            // 
            // txtCodPro1
            // 
            this.txtCodPro1.Enabled = false;
            this.txtCodPro1.Location = new System.Drawing.Point(434, 68);
            this.txtCodPro1.Name = "txtCodPro1";
            this.txtCodPro1.Size = new System.Drawing.Size(20, 20);
            this.txtCodPro1.TabIndex = 96;
            this.txtCodPro1.Visible = false;
            // 
            // lbLinea
            // 
            this.lbLinea.AutoSize = true;
            this.lbLinea.Location = new System.Drawing.Point(480, 102);
            this.lbLinea.Name = "lbLinea";
            this.lbLinea.Size = new System.Drawing.Size(36, 13);
            this.lbLinea.TabIndex = 90;
            this.lbLinea.Text = "Linea:";
            this.lbLinea.Visible = false;
            // 
            // txtProveedorCod
            // 
            this.txtProveedorCod.Enabled = false;
            this.txtProveedorCod.Location = new System.Drawing.Point(434, 120);
            this.txtProveedorCod.Name = "txtProveedorCod";
            this.txtProveedorCod.Size = new System.Drawing.Size(20, 20);
            this.txtProveedorCod.TabIndex = 84;
            this.txtProveedorCod.Visible = false;
            // 
            // txtProveedorNomb
            // 
            this.txtProveedorNomb.Location = new System.Drawing.Point(90, 121);
            this.txtProveedorNomb.Name = "txtProveedorNomb";
            this.txtProveedorNomb.ReadOnly = true;
            this.txtProveedorNomb.Size = new System.Drawing.Size(338, 20);
            this.txtProveedorNomb.TabIndex = 83;
            this.txtProveedorNomb.Visible = false;
            this.txtProveedorNomb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProveedorNomb_KeyDown);
            // 
            // txtRango2
            // 
            this.txtRango2.Enabled = false;
            this.txtRango2.Location = new System.Drawing.Point(180, 94);
            this.txtRango2.Name = "txtRango2";
            this.txtRango2.Size = new System.Drawing.Size(248, 20);
            this.txtRango2.TabIndex = 81;
            this.txtRango2.Visible = false;
            // 
            // txtRProduc2
            // 
            this.txtRProduc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRProduc2.Location = new System.Drawing.Point(90, 94);
            this.txtRProduc2.Name = "txtRProduc2";
            this.txtRProduc2.ReadOnly = true;
            this.txtRProduc2.Size = new System.Drawing.Size(84, 20);
            this.txtRProduc2.TabIndex = 80;
            this.txtRProduc2.Visible = false;
            this.txtRProduc2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRProduc2_KeyDown);
            this.txtRProduc2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRProduc2_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(36, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Fin :";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(36, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Inicio :";
            this.label11.Visible = false;
            // 
            // txtRango1
            // 
            this.txtRango1.Enabled = false;
            this.txtRango1.Location = new System.Drawing.Point(180, 68);
            this.txtRango1.Name = "txtRango1";
            this.txtRango1.Size = new System.Drawing.Size(248, 20);
            this.txtRango1.TabIndex = 77;
            this.txtRango1.Visible = false;
            // 
            // txtRProduc1
            // 
            this.txtRProduc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRProduc1.Location = new System.Drawing.Point(90, 68);
            this.txtRProduc1.Name = "txtRProduc1";
            this.txtRProduc1.ReadOnly = true;
            this.txtRProduc1.Size = new System.Drawing.Size(84, 20);
            this.txtRProduc1.TabIndex = 76;
            this.txtRProduc1.Visible = false;
            this.txtRProduc1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRProduc1_KeyDown);
            this.txtRProduc1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRProduc1_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvDetalleListaPrecio);
            this.groupBox5.Location = new System.Drawing.Point(6, 172);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(899, 273);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            // 
            // dgvDetalleListaPrecio
            // 
            this.dgvDetalleListaPrecio.AllowUserToAddRows = false;
            this.dgvDetalleListaPrecio.AllowUserToDeleteRows = false;
            this.dgvDetalleListaPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleListaPrecio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modificar,
            this.codprod,
            this.refe,
            this.descprod,
            this.codUnidadMedida,
            this.unidad,
            this.valorprom,
            this.margp,
            this.net,
            this.preciov,
            this.PreciovSoles,
            this.igv});
            this.dgvDetalleListaPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleListaPrecio.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalleListaPrecio.Name = "dgvDetalleListaPrecio";
            this.dgvDetalleListaPrecio.RowHeadersVisible = false;
            this.dgvDetalleListaPrecio.Size = new System.Drawing.Size(893, 254);
            this.dgvDetalleListaPrecio.TabIndex = 22;
            this.dgvDetalleListaPrecio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleListaPrecio_CellValueChanged);
            this.dgvDetalleListaPrecio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleListaPrecio_CellDoubleClick);
            this.dgvDetalleListaPrecio.Leave += new System.EventHandler(this.dgvDetalleListaPrecio_Leave);
            this.dgvDetalleListaPrecio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleListaPrecio_CellClick);
            this.dgvDetalleListaPrecio.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleListaPrecio_EditingControlShowing);
            this.dgvDetalleListaPrecio.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalleListaPrecio_DataError);
            this.dgvDetalleListaPrecio.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDetalleListaPrecio_RowsRemoved);
            this.dgvDetalleListaPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDetalleListaPrecio_KeyPress);
            this.dgvDetalleListaPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetalleListaPrecio_KeyUp);
            this.dgvDetalleListaPrecio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleListaPrecio_CellContentClick);
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.Width = 60;
            // 
            // codprod
            // 
            this.codprod.DataPropertyName = "codProducto";
            this.codprod.HeaderText = "CodProducto";
            this.codprod.Name = "codprod";
            this.codprod.Visible = false;
            // 
            // refe
            // 
            this.refe.DataPropertyName = "referencia";
            this.refe.HeaderText = "Referencia";
            this.refe.Name = "refe";
            this.refe.ReadOnly = true;
            // 
            // descprod
            // 
            this.descprod.DataPropertyName = "descripcion";
            this.descprod.HeaderText = "Descripcion";
            this.descprod.Name = "descprod";
            this.descprod.ReadOnly = true;
            this.descprod.Width = 200;
            // 
            // codUnidadMedida
            // 
            this.codUnidadMedida.DataPropertyName = "codUnidadMedida";
            this.codUnidadMedida.HeaderText = "codUnidadMedida";
            this.codUnidadMedida.Name = "codUnidadMedida";
            this.codUnidadMedida.ReadOnly = true;
            this.codUnidadMedida.Visible = false;
            // 
            // unidad
            // 
            this.unidad.DataPropertyName = "unidad";
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            // 
            // valorprom
            // 
            this.valorprom.DataPropertyName = "valorpromedio";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.valorprom.DefaultCellStyle = dataGridViewCellStyle6;
            this.valorprom.HeaderText = "ValorProm ($.)";
            this.valorprom.Name = "valorprom";
            this.valorprom.ReadOnly = true;
            this.valorprom.Width = 80;
            // 
            // margp
            // 
            this.margp.DataPropertyName = "margen";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.margp.DefaultCellStyle = dataGridViewCellStyle7;
            this.margp.HeaderText = "% Margen ($.)";
            this.margp.Name = "margp";
            this.margp.ReadOnly = true;
            // 
            // net
            // 
            this.net.DataPropertyName = "precioneto";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.net.DefaultCellStyle = dataGridViewCellStyle8;
            this.net.HeaderText = "Neto ($.)";
            this.net.Name = "net";
            this.net.ReadOnly = true;
            this.net.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.net.Width = 80;
            // 
            // preciov
            // 
            this.preciov.DataPropertyName = "precio";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.preciov.DefaultCellStyle = dataGridViewCellStyle9;
            this.preciov.HeaderText = "Precio Venta Dolares ($.)";
            this.preciov.Name = "preciov";
            this.preciov.ReadOnly = true;
            this.preciov.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PreciovSoles
            // 
            this.PreciovSoles.DataPropertyName = "preciosoles";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.PreciovSoles.DefaultCellStyle = dataGridViewCellStyle10;
            this.PreciovSoles.HeaderText = "Precio Venta Soles (S/.)";
            this.PreciovSoles.Name = "PreciovSoles";
            this.PreciovSoles.ReadOnly = true;
            this.PreciovSoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // igv
            // 
            this.igv.DataPropertyName = "igv";
            this.igv.HeaderText = "igv";
            this.igv.Name = "igv";
            this.igv.ReadOnly = true;
            this.igv.Visible = false;
            // 
            // frmListaPreciosProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(909, 501);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListaPreciosProductos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas de Precios Productos";
            this.Load += new System.EventHandler(this.frmListaPrecios_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleListaPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnReporte;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator5;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbLinea;
        public System.Windows.Forms.TextBox txtProveedorNomb;
        public System.Windows.Forms.TextBox txtProveedorCod;
        private System.Windows.Forms.TextBox txtRProduc2;
        private System.Windows.Forms.TextBox txtRProduc1;
        private System.Windows.Forms.TextBox txtRango2;
        private System.Windows.Forms.TextBox txtRango1;
        private System.Windows.Forms.TextBox txtCodPro1;
        private System.Windows.Forms.TextBox txtCodPro2;
        private System.Windows.Forms.CheckBox chbProveedor;
        private System.Windows.Forms.CheckBox chbRango;
        private System.Windows.Forms.CheckBox chbFamilia;
        private System.Windows.Forms.ComboBox cboLinea;
        private System.Windows.Forms.ComboBox cboFamilia;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvDetalleListaPrecio;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator4;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator6;
        private System.Windows.Forms.CheckBox chbModificaMargen;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbmargen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn refe;
        private System.Windows.Forms.DataGridViewTextBoxColumn descprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn codUnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorprom;
        private System.Windows.Forms.DataGridViewTextBoxColumn margp;
        private System.Windows.Forms.DataGridViewTextBoxColumn net;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciov;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreciovSoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn igv;
    }
}