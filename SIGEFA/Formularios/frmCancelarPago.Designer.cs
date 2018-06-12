namespace SIGEFA.Formularios
{
    partial class frmCancelarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelarPago));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontoPendiente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDocRef = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMora = new System.Windows.Forms.TextBox();
            this.lbMora = new System.Windows.Forms.Label();
            this.txtMonedaCta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboNumCta = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboTarjeta = new System.Windows.Forms.ComboBox();
            this.cbovendedor = new System.Windows.Forms.ComboBox();
            this.txtParcial = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtOperacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipoCambio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidator6 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator5 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator4 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator3 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator7 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMoneda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMontoPendiente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del documento";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(253, 32);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(100, 20);
            this.txtMoneda.TabIndex = 3;
            this.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Moneda";
            // 
            // txtMontoPendiente
            // 
            this.txtMontoPendiente.Location = new System.Drawing.Point(147, 32);
            this.txtMontoPendiente.Name = "txtMontoPendiente";
            this.txtMontoPendiente.ReadOnly = true;
            this.txtMontoPendiente.Size = new System.Drawing.Size(100, 20);
            this.txtMontoPendiente.TabIndex = 2;
            this.txtMontoPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Monto Pend.";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(21, 32);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(120, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "N° Documento Ref.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNc);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtDocRef);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.txtSerie);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtMora);
            this.groupBox2.Controls.Add(this.lbMora);
            this.groupBox2.Controls.Add(this.txtMonedaCta);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cboNumCta);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cboBanco);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboTarjeta);
            this.groupBox2.Controls.Add(this.cbovendedor);
            this.groupBox2.Controls.Add(this.txtParcial);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtObservacion);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMontoPago);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCheque);
            this.groupBox2.Controls.Add(this.txtOperacion);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbMetodoPago);
            this.groupBox2.Controls.Add(this.cmbMoneda);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTipoCambio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 381);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Pago";
            // 
            // txtNc
            // 
            this.txtNc.Enabled = false;
            this.txtNc.Location = new System.Drawing.Point(95, 228);
            this.txtNc.Name = "txtNc";
            this.txtNc.Size = new System.Drawing.Size(259, 20);
            this.txtNc.TabIndex = 13;
            this.superValidator1.SetValidator1(this.txtNc, this.customValidator6);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 95;
            this.label15.Text = "N° N. Credito";
            // 
            // txtDocRef
            // 
            this.txtDocRef.Location = new System.Drawing.Point(94, 15);
            this.txtDocRef.Name = "txtDocRef";
            this.txtDocRef.ReadOnly = true;
            this.txtDocRef.Size = new System.Drawing.Size(29, 20);
            this.txtDocRef.TabIndex = 1;
            this.txtDocRef.Visible = false;
            this.txtDocRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocRef_KeyPress);
            this.txtDocRef.Leave += new System.EventHandler(this.txtDocRef_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(186, 15);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(65, 20);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.Visible = false;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(129, 15);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(51, 20);
            this.txtSerie.TabIndex = 2;
            this.txtSerie.Visible = false;
            this.txtSerie.TextChanged += new System.EventHandler(this.txtSerie_TextChanged);
            this.txtSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerie_KeyDown);
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            this.txtSerie.Leave += new System.EventHandler(this.txtSerie_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 92;
            this.label16.Text = "Serie:";
            this.label16.Visible = false;
            // 
            // txtMora
            // 
            this.txtMora.Location = new System.Drawing.Point(94, 309);
            this.txtMora.Name = "txtMora";
            this.txtMora.Size = new System.Drawing.Size(118, 20);
            this.txtMora.TabIndex = 18;
            this.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMora.TextChanged += new System.EventHandler(this.txtMora_TextChanged);
            this.txtMora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMora_KeyPress);
            this.txtMora.Leave += new System.EventHandler(this.txtMora_Leave);
            // 
            // lbMora
            // 
            this.lbMora.AutoSize = true;
            this.lbMora.Location = new System.Drawing.Point(18, 312);
            this.lbMora.Name = "lbMora";
            this.lbMora.Size = new System.Drawing.Size(31, 13);
            this.lbMora.TabIndex = 84;
            this.lbMora.Text = "Mora";
            // 
            // txtMonedaCta
            // 
            this.txtMonedaCta.Location = new System.Drawing.Point(270, 148);
            this.txtMonedaCta.Name = "txtMonedaCta";
            this.txtMonedaCta.ReadOnly = true;
            this.txtMonedaCta.Size = new System.Drawing.Size(83, 20);
            this.txtMonedaCta.TabIndex = 10;
            this.txtMonedaCta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonedaCta.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "N° Cta:";
            // 
            // cboNumCta
            // 
            this.cboNumCta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboNumCta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNumCta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNumCta.FormattingEnabled = true;
            this.cboNumCta.Location = new System.Drawing.Point(94, 147);
            this.cboNumCta.Name = "cboNumCta";
            this.cboNumCta.Size = new System.Drawing.Size(170, 21);
            this.cboNumCta.TabIndex = 9;
            this.superValidator1.SetValidator1(this.cboNumCta, this.customValidator5);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "Banco:";
            // 
            // cboBanco
            // 
            this.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(94, 120);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(259, 21);
            this.cboBanco.TabIndex = 8;
            this.superValidator1.SetValidator1(this.cboBanco, this.customValidator4);
            this.cboBanco.SelectionChangeCommitted += new System.EventHandler(this.cboBanco_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Tarjeta:";
            // 
            // cboTarjeta
            // 
            this.cboTarjeta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTarjeta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarjeta.FormattingEnabled = true;
            this.cboTarjeta.Location = new System.Drawing.Point(94, 94);
            this.cboTarjeta.Name = "cboTarjeta";
            this.cboTarjeta.Size = new System.Drawing.Size(259, 21);
            this.cboTarjeta.TabIndex = 7;
            this.superValidator1.SetValidator1(this.cboTarjeta, this.customValidator3);
            // 
            // cbovendedor
            // 
            this.cbovendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbovendedor.FormattingEnabled = true;
            this.cbovendedor.Location = new System.Drawing.Point(193, 281);
            this.cbovendedor.Name = "cbovendedor";
            this.cbovendedor.Size = new System.Drawing.Size(160, 20);
            this.cbovendedor.TabIndex = 17;
            this.cbovendedor.Text = "Cobrado Por";
            this.cbovendedor.Visible = false;
            // 
            // txtParcial
            // 
            this.txtParcial.Enabled = false;
            this.txtParcial.Location = new System.Drawing.Point(218, 255);
            this.txtParcial.Name = "txtParcial";
            this.txtParcial.ReadOnly = true;
            this.txtParcial.Size = new System.Drawing.Size(135, 20);
            this.txtParcial.TabIndex = 15;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Checked = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(94, 281);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(93, 20);
            this.dtpFecha.TabIndex = 16;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Location = new System.Drawing.Point(94, 335);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(259, 37);
            this.txtObservacion.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Fecha";
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Location = new System.Drawing.Point(94, 255);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(118, 20);
            this.txtMontoPago.TabIndex = 14;
            this.txtMontoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.superValidator1.SetValidator1(this.txtMontoPago, this.customValidator1);
            this.txtMontoPago.TextChanged += new System.EventHandler(this.txtMontoPago_TextChanged);
            this.txtMontoPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPago_KeyPress);
            this.txtMontoPago.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMontoPago_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Monto";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(94, 200);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(259, 20);
            this.txtCheque.TabIndex = 12;
            this.superValidator1.SetValidator1(this.txtCheque, this.customValidator6);
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            // 
            // txtOperacion
            // 
            this.txtOperacion.Location = new System.Drawing.Point(94, 174);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(259, 20);
            this.txtOperacion.TabIndex = 11;
            this.superValidator1.SetValidator1(this.txtOperacion, this.customValidator7);
            this.txtOperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOperacion_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "N° Cheque";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "N° Operación";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMetodoPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(94, 68);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(259, 20);
            this.cmbMetodoPago.TabIndex = 6;
            this.cmbMetodoPago.SelectionChangeCommitted += new System.EventHandler(this.cmbMetodoPago_SelectionChangeCommitted);
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(94, 41);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(106, 20);
            this.cmbMoneda.TabIndex = 4;
            this.cmbMoneda.SelectionChangeCommitted += new System.EventHandler(this.cmbMoneda_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tipo de pago";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(270, 40);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.ReadOnly = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(83, 20);
            this.txtTipoCambio.TabIndex = 5;
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.superValidator1.SetValidator1(this.txtTipoCambio, this.customValidator2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "T.C.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Moneda";
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
            this.imageList1.Images.SetKeyName(7, "DeleteRed.png");
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // customValidator6
            // 
            this.customValidator6.ErrorMessage = "Ingrese el número de cheque.";
            this.customValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator6.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator6_ValidateValue);
            // 
            // customValidator5
            // 
            this.customValidator5.ErrorMessage = "Seleccione la cuenta.";
            this.customValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator5.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator5_ValidateValue);
            // 
            // customValidator4
            // 
            this.customValidator4.ErrorMessage = "Seleccione el banco.";
            this.customValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator4.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator4_ValidateValue);
            // 
            // customValidator3
            // 
            this.customValidator3.ErrorMessage = "Seleccione la tarjeta.";
            this.customValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator3.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator3_ValidateValue);
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Ingrese Monto.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue_1);
            // 
            // customValidator7
            // 
            this.customValidator7.ErrorMessage = "Ingrese el número de operación.";
            this.customValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator7.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator7_ValidateValue);
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Ingrese Tipo de Cambio";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator2_ValidateValue_1);
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
            // btnAceptar
            // 
            this.btnAceptar.ImageIndex = 6;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(193, 455);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(82, 32);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageIndex = 5;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(281, 455);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 32);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageKey = "document-print.png";
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(21, 455);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 32);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmCancelarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 502);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCancelarPago";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCancelarPago_FormClosing);
            this.Load += new System.EventHandler(this.frmCancelarPago_Load);
            this.Shown += new System.EventHandler(this.frmCancelarPago_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.TextBox txtOperacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAceptar;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.TextBox txtParcial;
        private System.Windows.Forms.ComboBox cbovendedor;
        private System.Windows.Forms.TextBox txtMonedaCta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtMontoPendiente;
        public System.Windows.Forms.TextBox txtDocumento;
        public System.Windows.Forms.TextBox txtMontoPago;
        public System.Windows.Forms.ComboBox cmbMetodoPago;
        public System.Windows.Forms.ComboBox cmbMoneda;
        public System.Windows.Forms.TextBox txtTipoCambio;
        public System.Windows.Forms.TextBox txtMoneda;
        public System.Windows.Forms.ComboBox cboNumCta;
        public System.Windows.Forms.ComboBox cboBanco;
        public System.Windows.Forms.ComboBox cboTarjeta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator4;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator5;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator6;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator7;
        public System.Windows.Forms.TextBox txtMora;
        private System.Windows.Forms.Label lbMora;
        private System.Windows.Forms.TextBox txtDocRef;
        private System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNc;
        private System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
        public System.Windows.Forms.DateTimePicker dtpFecha;


    }
}