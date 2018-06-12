namespace SIGEFA.Formularios
{
    partial class frmCajaChicaRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajaChicaRegistro));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoPagoCaja = new System.Windows.Forms.ComboBox();
            this.lblTipoPagoCaja = new System.Windows.Forms.Label();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.compareValidator1 = new DevComponents.DotNetBar.Validator.CompareValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.customValidator3 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtGuiaRemision = new System.Windows.Forms.TextBox();
            this.lblGuiaRemision = new System.Windows.Forms.Label();
            this.txtReciboLiquidacion = new System.Windows.Forms.TextBox();
            this.lblReciboLiquidacion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.superValidator2 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter2 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtToneladas = new System.Windows.Forms.TextBox();
            this.lblToneladas = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMontoPendiente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRecibo = new System.Windows.Forms.TextBox();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.lbPlaca = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSaldoCaja = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEgreso = new System.Windows.Forms.Label();
            this.superValidator3 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.compareValidator2 = new DevComponents.DotNetBar.Validator.CompareValidator();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter3 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
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
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.btnSalir);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(486, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 32);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ImageIndex = 4;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(403, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 32);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(97, 14);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(52, 21);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.Aquamarine;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(107, 63);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(457, 40);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descripcion:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(438, 107);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(126, 20);
            this.dtpFecha.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha:";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.BackColor = System.Drawing.Color.Aquamarine;
            this.txtMonto.Location = new System.Drawing.Point(304, 107);
            this.txtMonto.MaxLength = 10;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(75, 20);
            this.txtMonto.TabIndex = 7;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.superValidator1.SetValidator1(this.txtMonto, this.compareValidator1);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMonto_KeyUp);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Monto:";
            // 
            // cboTipoPagoCaja
            // 
            this.cboTipoPagoCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoPagoCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPagoCaja.FormattingEnabled = true;
            this.cboTipoPagoCaja.Location = new System.Drawing.Point(313, 13);
            this.cboTipoPagoCaja.Name = "cboTipoPagoCaja";
            this.cboTipoPagoCaja.Size = new System.Drawing.Size(241, 21);
            this.cboTipoPagoCaja.TabIndex = 1;
            this.cboTipoPagoCaja.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPagoCaja_SelectionChangeCommitted);
            // 
            // lblTipoPagoCaja
            // 
            this.lblTipoPagoCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoPagoCaja.AutoSize = true;
            this.lblTipoPagoCaja.Location = new System.Drawing.Point(240, 18);
            this.lblTipoPagoCaja.Name = "lblTipoPagoCaja";
            this.lblTipoPagoCaja.Size = new System.Drawing.Size(67, 13);
            this.lblTipoPagoCaja.TabIndex = 25;
            this.lblTipoPagoCaja.Text = "Tipo Egreso:";
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // compareValidator1
            // 
            this.compareValidator1.ErrorMessage = "Your error message here.";
            this.compareValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.compareValidator1.Operator = DevComponents.DotNetBar.Validator.eValidationCompareOperator.GreaterThan;
            this.compareValidator1.ValueToCompare = "0";
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
            // cmbDocumento
            // 
            this.cmbDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Items.AddRange(new object[] {
            "FT",
            "BV",
            "RH",
            "OTROS"});
            this.cmbDocumento.Location = new System.Drawing.Point(107, 106);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(94, 21);
            this.cmbDocumento.TabIndex = 4;
            this.superValidator1.SetValidator1(this.cmbDocumento, this.customValidator3);
            this.cmbDocumento.Visible = false;
            // 
            // customValidator3
            // 
            this.customValidator3.ErrorMessage = "Ingrese Tipo de Documento";
            this.customValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator3.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator3_ValidateValue_1);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRazonSocial.BackColor = System.Drawing.Color.Aquamarine;
            this.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazonSocial.Location = new System.Drawing.Point(107, 37);
            this.txtRazonSocial.MaxLength = 200;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(457, 20);
            this.txtRazonSocial.TabIndex = 2;
            this.txtRazonSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.superValidator1.SetValidator1(this.txtRazonSocial, this.customValidator2);
            this.txtRazonSocial.Visible = false;
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Ingrese Razon Social";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator2_ValidateValue_1);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumento.BackColor = System.Drawing.Color.Aquamarine;
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(107, 135);
            this.txtDocumento.MaxLength = 11;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(94, 20);
            this.txtDocumento.TabIndex = 5;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.superValidator2.SetValidator1(this.txtDocumento, this.customValidator1);
            this.txtDocumento.Visible = false;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtGuiaRemision
            // 
            this.txtGuiaRemision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuiaRemision.Enabled = false;
            this.txtGuiaRemision.Location = new System.Drawing.Point(304, 158);
            this.txtGuiaRemision.MaxLength = 11;
            this.txtGuiaRemision.Name = "txtGuiaRemision";
            this.txtGuiaRemision.Size = new System.Drawing.Size(94, 20);
            this.txtGuiaRemision.TabIndex = 9;
            this.txtGuiaRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGuiaRemision.Visible = false;
            this.txtGuiaRemision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuiaRemision_KeyPress);
            // 
            // lblGuiaRemision
            // 
            this.lblGuiaRemision.AutoSize = true;
            this.lblGuiaRemision.Location = new System.Drawing.Point(237, 162);
            this.lblGuiaRemision.Name = "lblGuiaRemision";
            this.lblGuiaRemision.Size = new System.Drawing.Size(61, 13);
            this.lblGuiaRemision.TabIndex = 28;
            this.lblGuiaRemision.Text = "N° Guia R.:";
            this.lblGuiaRemision.Visible = false;
            // 
            // txtReciboLiquidacion
            // 
            this.txtReciboLiquidacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReciboLiquidacion.Enabled = false;
            this.txtReciboLiquidacion.Location = new System.Drawing.Point(304, 131);
            this.txtReciboLiquidacion.MaxLength = 11;
            this.txtReciboLiquidacion.Name = "txtReciboLiquidacion";
            this.txtReciboLiquidacion.Size = new System.Drawing.Size(75, 20);
            this.txtReciboLiquidacion.TabIndex = 8;
            this.txtReciboLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReciboLiquidacion.Visible = false;
            this.txtReciboLiquidacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReciboLiquidacion_KeyPress);
            // 
            // lblReciboLiquidacion
            // 
            this.lblReciboLiquidacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReciboLiquidacion.AutoSize = true;
            this.lblReciboLiquidacion.Location = new System.Drawing.Point(219, 135);
            this.lblReciboLiquidacion.Name = "lblReciboLiquidacion";
            this.lblReciboLiquidacion.Size = new System.Drawing.Size(79, 13);
            this.lblReciboLiquidacion.TabIndex = 30;
            this.lblReciboLiquidacion.Text = "N° Recibo Liq.:";
            this.lblReciboLiquidacion.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "N° Documento:";
            this.label8.Visible = false;
            // 
            // superValidator2
            // 
            this.superValidator2.ContainerControl = this;
            this.superValidator2.ErrorProvider = this.errorProvider2;
            this.superValidator2.Highlighter = this.highlighter2;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Ingrese Nume de Documento";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // highlighter2
            // 
            this.highlighter2.ContainerControl = this;
            // 
            // txtToneladas
            // 
            this.txtToneladas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToneladas.Enabled = false;
            this.txtToneladas.Location = new System.Drawing.Point(438, 155);
            this.txtToneladas.MaxLength = 10;
            this.txtToneladas.Name = "txtToneladas";
            this.txtToneladas.Size = new System.Drawing.Size(70, 20);
            this.txtToneladas.TabIndex = 12;
            this.txtToneladas.Text = "0.00";
            this.txtToneladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.superValidator3.SetValidator1(this.txtToneladas, this.compareValidator2);
            this.txtToneladas.Visible = false;
            // 
            // lblToneladas
            // 
            this.lblToneladas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToneladas.AutoSize = true;
            this.lblToneladas.Location = new System.Drawing.Point(407, 159);
            this.lblToneladas.Name = "lblToneladas";
            this.lblToneladas.Size = new System.Drawing.Size(25, 13);
            this.lblToneladas.TabIndex = 33;
            this.lblToneladas.Text = "TN:";
            this.lblToneladas.Visible = false;
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Enabled = false;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "",
            "CARGA",
            "DESCARGA",
            "CARGA Y DESCARGA",
            "CARGA DESCARGA Y TRASBORDO",
            "TRASBORDO Y DESCARGA"});
            this.cboTipo.Location = new System.Drawing.Point(438, 131);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(126, 21);
            this.cboTipo.TabIndex = 11;
            this.cboTipo.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(401, 135);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 36;
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbDocumento);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMontoPendiente);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRecibo);
            this.panel1.Controls.Add(this.cmbPlaca);
            this.panel1.Controls.Add(this.lbPlaca);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboTipo);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.txtToneladas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblToneladas);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDocumento);
            this.panel1.Controls.Add(this.txtGuiaRemision);
            this.panel1.Controls.Add(this.lblReciboLiquidacion);
            this.panel1.Controls.Add(this.lblGuiaRemision);
            this.panel1.Controls.Add(this.txtReciboLiquidacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 191);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Razon Social:";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Documento:";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Monto A Sustentar:";
            this.label9.Visible = false;
            // 
            // txtMontoPendiente
            // 
            this.txtMontoPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoPendiente.BackColor = System.Drawing.Color.Aquamarine;
            this.txtMontoPendiente.Enabled = false;
            this.txtMontoPendiente.Location = new System.Drawing.Point(365, 8);
            this.txtMontoPendiente.MaxLength = 11;
            this.txtMontoPendiente.Name = "txtMontoPendiente";
            this.txtMontoPendiente.ReadOnly = true;
            this.txtMontoPendiente.Size = new System.Drawing.Size(101, 20);
            this.txtMontoPendiente.TabIndex = 1;
            this.txtMontoPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMontoPendiente.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "N° Recibo:";
            this.label6.Visible = false;
            // 
            // txtRecibo
            // 
            this.txtRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecibo.BackColor = System.Drawing.Color.Aquamarine;
            this.txtRecibo.Location = new System.Drawing.Point(106, 11);
            this.txtRecibo.MaxLength = 11;
            this.txtRecibo.Name = "txtRecibo";
            this.txtRecibo.ReadOnly = true;
            this.txtRecibo.Size = new System.Drawing.Size(95, 20);
            this.txtRecibo.TabIndex = 0;
            this.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRecibo.Visible = false;
            this.txtRecibo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecibo_KeyDown);
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaca.Enabled = false;
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Location = new System.Drawing.Point(106, 160);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(94, 21);
            this.cmbPlaca.TabIndex = 6;
            this.cmbPlaca.Visible = false;
            // 
            // lbPlaca
            // 
            this.lbPlaca.AutoSize = true;
            this.lbPlaca.Location = new System.Drawing.Point(54, 162);
            this.lbPlaca.Name = "lbPlaca";
            this.lbPlaca.Size = new System.Drawing.Size(37, 13);
            this.lbPlaca.TabIndex = 39;
            this.lbPlaca.Text = "Placa:";
            this.lbPlaca.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTipoPagoCaja);
            this.panel2.Controls.Add(this.cboTipoPagoCaja);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 38);
            this.panel2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "SALDO EN CAJA S/.:";
            // 
            // lblSaldoCaja
            // 
            this.lblSaldoCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaldoCaja.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoCaja.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSaldoCaja.Location = new System.Drawing.Point(402, 2);
            this.lblSaldoCaja.Name = "lblSaldoCaja";
            this.lblSaldoCaja.Size = new System.Drawing.Size(126, 20);
            this.lblSaldoCaja.TabIndex = 3;
            this.lblSaldoCaja.Text = "0.000";
            this.lblSaldoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblEgreso);
            this.panel3.Controls.Add(this.lblSaldoCaja);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 25);
            this.panel3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "MONTO  S/.:";
            // 
            // lblEgreso
            // 
            this.lblEgreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEgreso.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgreso.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblEgreso.Location = new System.Drawing.Point(152, 2);
            this.lblEgreso.Name = "lblEgreso";
            this.lblEgreso.Size = new System.Drawing.Size(115, 20);
            this.lblEgreso.TabIndex = 4;
            this.lblEgreso.Text = "0.000";
            this.lblEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // superValidator3
            // 
            this.superValidator3.ContainerControl = this;
            this.superValidator3.ErrorProvider = this.errorProvider3;
            this.superValidator3.Highlighter = this.highlighter3;
            // 
            // compareValidator2
            // 
            this.compareValidator2.ErrorMessage = "Ingrese N° de Toneladas";
            this.compareValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.compareValidator2.Operator = DevComponents.DotNetBar.Validator.eValidationCompareOperator.GreaterThan;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider3.Icon")));
            // 
            // highlighter3
            // 
            this.highlighter3.ContainerControl = this;
            // 
            // frmCajaChicaRegistro
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(585, 302);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox3);
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCajaChicaRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmCajaChicaRegistro_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoPagoCaja;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.Label lblGuiaRemision;
        private System.Windows.Forms.Label lblReciboLiquidacion;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator2;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter2;
        private System.Windows.Forms.Label lblToneladas;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblSaldoCaja;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.TextBox txtMonto;
        public System.Windows.Forms.ComboBox cboTipoPagoCaja;
        public System.Windows.Forms.TextBox txtGuiaRemision;
        public System.Windows.Forms.TextBox txtReciboLiquidacion;
        public System.Windows.Forms.TextBox txtDocumento;
        public System.Windows.Forms.TextBox txtToneladas;
        public System.Windows.Forms.ComboBox cboTipo;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator3;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.CompareValidator compareValidator2;
        private DevComponents.DotNetBar.Validator.CompareValidator compareValidator1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblEgreso;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.Label lbPlaca;
        public System.Windows.Forms.TextBox txtRecibo;
        public System.Windows.Forms.TextBox txtMontoPendiente;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cmbDocumento;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtRazonSocial;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator3;
    }
}