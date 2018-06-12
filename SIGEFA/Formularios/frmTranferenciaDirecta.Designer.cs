namespace SIGEFA.Formularios
{
    partial class frmTranferenciaDirecta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranferenciaDirecta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTipoCambio = new System.Windows.Forms.TextBox();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRazonSocialTransporte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRUCTransporte = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbTransportista = new System.Windows.Forms.ComboBox();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTraslado = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chkReqDet = new System.Windows.Forms.CheckBox();
            this.cmbAlmacenDestino = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocRef = new System.Windows.Forms.TextBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodDoc = new System.Windows.Forms.TextBox();
            this.txtAlmacenDestino = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbAlmacen = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTransferencia = new System.Windows.Forms.ComboBox();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.cmbAlmacen = new System.Windows.Forms.ComboBox();
            this.txtAlmacenOri = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAceptarTransferencia = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.coddetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codunidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorpromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorpromediosoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciopromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockactual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentario_usu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.customValidator3 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator4 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.cachedCRCuotasPrestamo1 = new SIGEFA.Reportes.clsReportes.CachedCRCuotasPrestamo();
            this.cachedCRCuotasPrestamo2 = new SIGEFA.Reportes.clsReportes.CachedCRCuotasPrestamo();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtcodserie = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTipoCambio);
            this.groupBox1.Controls.Add(this.txtReq);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.dtpTraslado);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpEmision);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkReqDet);
            this.groupBox1.Controls.Add(this.cmbAlmacenDestino);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDocRef);
            this.groupBox1.Controls.Add(this.txtNumDoc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.txtcodserie);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.txtCodDoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAlmacenDestino);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.lbAlmacen);
            this.groupBox1.Controls.Add(this.btnDetalle);
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTransferencia);
            this.groupBox1.Controls.Add(this.txtTransaccion);
            this.groupBox1.Controls.Add(this.cmbAlmacen);
            this.groupBox1.Controls.Add(this.txtAlmacenOri);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 319);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoCambio.Location = new System.Drawing.Point(689, 175);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.ReadOnly = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(81, 20);
            this.txtTipoCambio.TabIndex = 85;
            this.txtTipoCambio.Tag = "15";
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReq
            // 
            this.txtReq.Location = new System.Drawing.Point(749, 98);
            this.txtReq.Name = "txtReq";
            this.txtReq.Size = new System.Drawing.Size(23, 20);
            this.txtReq.TabIndex = 84;
            this.txtReq.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtRazonSocialTransporte);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtRUCTransporte);
            this.groupBox5.Location = new System.Drawing.Point(353, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(413, 75);
            this.groupBox5.TabIndex = 83;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Empresa de Tranportes";
            // 
            // txtRazonSocialTransporte
            // 
            this.txtRazonSocialTransporte.Location = new System.Drawing.Point(78, 40);
            this.txtRazonSocialTransporte.Name = "txtRazonSocialTransporte";
            this.txtRazonSocialTransporte.ReadOnly = true;
            this.txtRazonSocialTransporte.Size = new System.Drawing.Size(327, 20);
            this.txtRazonSocialTransporte.TabIndex = 23;
            this.txtRazonSocialTransporte.Tag = "5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "RUC";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Raz. Social";
            // 
            // txtRUCTransporte
            // 
            this.txtRUCTransporte.Location = new System.Drawing.Point(78, 14);
            this.txtRUCTransporte.Name = "txtRUCTransporte";
            this.txtRUCTransporte.Size = new System.Drawing.Size(147, 20);
            this.txtRUCTransporte.TabIndex = 22;
            this.txtRUCTransporte.Tag = "5";
            this.txtRUCTransporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRUCTransporte_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbTransportista);
            this.groupBox4.Controls.Add(this.cmbVehiculo);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(6, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 81);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos del Transporte / Conductor";
            // 
            // cmbTransportista
            // 
            this.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportista.FormattingEnabled = true;
            this.cmbTransportista.Location = new System.Drawing.Point(91, 23);
            this.cmbTransportista.Name = "cmbTransportista";
            this.cmbTransportista.Size = new System.Drawing.Size(235, 21);
            this.cmbTransportista.TabIndex = 71;
            this.superValidator1.SetValidator1(this.cmbTransportista, this.customValidator3);
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehiculo.FormattingEnabled = true;
            this.cmbVehiculo.Location = new System.Drawing.Point(91, 49);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(235, 21);
            this.cmbVehiculo.TabIndex = 72;
            this.superValidator1.SetValidator1(this.cmbVehiculo, this.customValidator3);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Vehiculo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Transportista:";
            // 
            // dtpTraslado
            // 
            this.dtpTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTraslado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTraslado.Location = new System.Drawing.Point(565, 282);
            this.dtpTraslado.Name = "dtpTraslado";
            this.dtpTraslado.Size = new System.Drawing.Size(81, 20);
            this.dtpTraslado.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 288);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Fecha Traslado:";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(220, 282);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(81, 20);
            this.dtpEmision.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Fecha Emision Guia:";
            // 
            // chkReqDet
            // 
            this.chkReqDet.AutoSize = true;
            this.chkReqDet.Location = new System.Drawing.Point(689, 101);
            this.chkReqDet.Name = "chkReqDet";
            this.chkReqDet.Size = new System.Drawing.Size(60, 17);
            this.chkReqDet.TabIndex = 78;
            this.chkReqDet.Text = "chkRD";
            this.chkReqDet.UseVisualStyleBackColor = true;
            this.chkReqDet.Visible = false;
            // 
            // cmbAlmacenDestino
            // 
            this.cmbAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacenDestino.FormattingEnabled = true;
            this.cmbAlmacenDestino.Location = new System.Drawing.Point(448, 72);
            this.cmbAlmacenDestino.Name = "cmbAlmacenDestino";
            this.cmbAlmacenDestino.Size = new System.Drawing.Size(235, 21);
            this.cmbAlmacenDestino.TabIndex = 6;
            this.cmbAlmacenDestino.Tag = "";
            this.superValidator1.SetValidator1(this.cmbAlmacenDestino, this.customValidator3);
            this.cmbAlmacenDestino.SelectionChangeCommitted += new System.EventHandler(this.cmbAlmacenDestino_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 74;
            this.label8.Tag = "";
            this.label8.Text = "Almacen Destino";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Doc. Ref.";
            // 
            // txtDocRef
            // 
            this.txtDocRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocRef.Location = new System.Drawing.Point(102, 45);
            this.txtDocRef.Name = "txtDocRef";
            this.txtDocRef.Size = new System.Drawing.Size(42, 20);
            this.txtDocRef.TabIndex = 2;
            this.txtDocRef.Tag = "";
            this.txtDocRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocRef_KeyDown);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.Location = new System.Drawing.Point(516, 42);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.Size = new System.Drawing.Size(115, 20);
            this.txtNumDoc.TabIndex = 66;
            this.txtNumDoc.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Num. Doc.";
            this.label7.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Transacción";
            // 
            // txtCodDoc
            // 
            this.txtCodDoc.Enabled = false;
            this.txtCodDoc.Location = new System.Drawing.Point(431, 46);
            this.txtCodDoc.Name = "txtCodDoc";
            this.txtCodDoc.ReadOnly = true;
            this.txtCodDoc.Size = new System.Drawing.Size(10, 20);
            this.txtCodDoc.TabIndex = 60;
            this.txtCodDoc.Visible = false;
            // 
            // txtAlmacenDestino
            // 
            this.txtAlmacenDestino.Location = new System.Drawing.Point(102, 99);
            this.txtAlmacenDestino.Name = "txtAlmacenDestino";
            this.txtAlmacenDestino.Size = new System.Drawing.Size(581, 20);
            this.txtAlmacenDestino.TabIndex = 44;
            this.txtAlmacenDestino.Tag = "";
            this.txtAlmacenDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequerimiento_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 43;
            this.label20.Tag = "";
            this.label20.Text = "Direccion A.D.";
            // 
            // lbAlmacen
            // 
            this.lbAlmacen.AutoSize = true;
            this.lbAlmacen.Location = new System.Drawing.Point(17, 77);
            this.lbAlmacen.Name = "lbAlmacen";
            this.lbAlmacen.Size = new System.Drawing.Size(82, 13);
            this.lbAlmacen.TabIndex = 41;
            this.lbAlmacen.Tag = "";
            this.lbAlmacen.Text = "Almacen Origen";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.Location = new System.Drawing.Point(691, 283);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnDetalle.TabIndex = 13;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComentario.Location = new System.Drawing.Point(102, 125);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(581, 61);
            this.txtComentario.TabIndex = 12;
            this.txtComentario.Tag = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 17;
            this.label9.Tag = "";
            this.label9.Text = "Comentario";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(685, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha.TabIndex = 7;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha :";
            // 
            // cmbTransferencia
            // 
            this.cmbTransferencia.FormattingEnabled = true;
            this.cmbTransferencia.Items.AddRange(new object[] {
            "TRANSFERENCIA DIRECTA"});
            this.cmbTransferencia.Location = new System.Drawing.Point(102, 18);
            this.cmbTransferencia.Name = "cmbTransferencia";
            this.cmbTransferencia.Size = new System.Drawing.Size(339, 21);
            this.cmbTransferencia.TabIndex = 1;
            this.cmbTransferencia.Tag = "";
            this.superValidator1.SetValidator1(this.cmbTransferencia, this.customValidator3);
            this.cmbTransferencia.SelectedIndexChanged += new System.EventHandler(this.cmbTransferencia_SelectedIndexChanged);
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransaccion.Location = new System.Drawing.Point(102, 20);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(28, 20);
            this.txtTransaccion.TabIndex = 64;
            this.txtTransaccion.Visible = false;
            // 
            // cmbAlmacen
            // 
            this.cmbAlmacen.FormattingEnabled = true;
            this.cmbAlmacen.Location = new System.Drawing.Point(102, 72);
            this.cmbAlmacen.Name = "cmbAlmacen";
            this.cmbAlmacen.Size = new System.Drawing.Size(235, 21);
            this.cmbAlmacen.TabIndex = 5;
            this.cmbAlmacen.Tag = "";
            this.superValidator1.SetValidator1(this.cmbAlmacen, this.customValidator3);
            // 
            // txtAlmacenOri
            // 
            this.txtAlmacenOri.Location = new System.Drawing.Point(102, 72);
            this.txtAlmacenOri.Name = "txtAlmacenOri";
            this.txtAlmacenOri.Size = new System.Drawing.Size(235, 20);
            this.txtAlmacenOri.TabIndex = 77;
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
            this.groupBox3.Controls.Add(this.btnAceptarTransferencia);
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Controls.Add(this.btnSalir);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 560);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 50);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // btnAceptarTransferencia
            // 
            this.btnAceptarTransferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarTransferencia.ImageIndex = 11;
            this.btnAceptarTransferencia.ImageList = this.imageList3;
            this.btnAceptarTransferencia.Location = new System.Drawing.Point(358, 12);
            this.btnAceptarTransferencia.Name = "btnAceptarTransferencia";
            this.btnAceptarTransferencia.Size = new System.Drawing.Size(147, 32);
            this.btnAceptarTransferencia.TabIndex = 19;
            this.btnAceptarTransferencia.Text = "Aceptar Transferencia";
            this.btnAceptarTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptarTransferencia.UseVisualStyleBackColor = true;
            this.btnAceptarTransferencia.Visible = false;
            this.btnAceptarTransferencia.Click += new System.EventHandler(this.btnAceptarTransferencia_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "Write Document.png");
            this.imageList3.Images.SetKeyName(1, "New Document.png");
            this.imageList3.Images.SetKeyName(2, "Remove Document.png");
            this.imageList3.Images.SetKeyName(3, "document-print.png");
            this.imageList3.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList3.Images.SetKeyName(5, "exit.png");
            this.imageList3.Images.SetKeyName(6, "search (1).png");
            this.imageList3.Images.SetKeyName(7, "Glossy-Open-icon.png");
            this.imageList3.Images.SetKeyName(8, "folder-open-icon (1).png");
            this.imageList3.Images.SetKeyName(9, "document_delete.png");
            this.imageList3.Images.SetKeyName(10, "DeleteRed.png");
            this.imageList3.Images.SetKeyName(11, "OK_Verde.png");
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageIndex = 3;
            this.btnImprimir.ImageList = this.imageList1;
            this.btnImprimir.Location = new System.Drawing.Point(534, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(78, 32);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Im&primir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(704, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 32);
            this.btnSalir.TabIndex = 17;
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
            this.btnGuardar.Location = new System.Drawing.Point(621, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 32);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageIndex = 2;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(20, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 32);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 241);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coddetalle,
            this.codproducto,
            this.referencia,
            this.descripcion,
            this.codunidad,
            this.unidad,
            this.cantidad,
            this.valorpromedio,
            this.valorpromediosoles,
            this.preciopromedio,
            this.stockactual,
            this.comentario_usu,
            this.estadototal});
            this.dgvDetalle.Location = new System.Drawing.Point(3, 19);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(772, 204);
            this.dgvDetalle.TabIndex = 25;
            this.superValidator1.SetValidator1(this.dgvDetalle, this.customValidator4);
            // 
            // coddetalle
            // 
            this.coddetalle.DataPropertyName = "codDetalle";
            this.coddetalle.HeaderText = "CodDetalle";
            this.coddetalle.Name = "coddetalle";
            this.coddetalle.ReadOnly = true;
            this.coddetalle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.coddetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coddetalle.Visible = false;
            // 
            // codproducto
            // 
            this.codproducto.DataPropertyName = "codProducto";
            this.codproducto.HeaderText = "CodProducto";
            this.codproducto.Name = "codproducto";
            this.codproducto.ReadOnly = true;
            this.codproducto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codproducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codproducto.Visible = false;
            // 
            // referencia
            // 
            this.referencia.DataPropertyName = "referencia";
            this.referencia.HeaderText = "Codigo";
            this.referencia.Name = "referencia";
            this.referencia.ReadOnly = true;
            this.referencia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.referencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "producto";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // codunidad
            // 
            this.codunidad.DataPropertyName = "codUnidadMedida";
            this.codunidad.HeaderText = "Cod. Unidad";
            this.codunidad.Name = "codunidad";
            this.codunidad.ReadOnly = true;
            this.codunidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codunidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codunidad.Visible = false;
            // 
            // unidad
            // 
            this.unidad.DataPropertyName = "unidad";
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            this.unidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.unidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "Cantidad a Enviar";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // valorpromedio
            // 
            this.valorpromedio.DataPropertyName = "valorpromedio";
            this.valorpromedio.HeaderText = "valorpromedio";
            this.valorpromedio.Name = "valorpromedio";
            this.valorpromedio.ReadOnly = true;
            // 
            // valorpromediosoles
            // 
            this.valorpromediosoles.DataPropertyName = "valorpromediosoles";
            this.valorpromediosoles.HeaderText = "valorpromediosoles";
            this.valorpromediosoles.Name = "valorpromediosoles";
            this.valorpromediosoles.ReadOnly = true;
            // 
            // preciopromedio
            // 
            this.preciopromedio.DataPropertyName = "preciopromedio";
            this.preciopromedio.HeaderText = "preciopromedio";
            this.preciopromedio.Name = "preciopromedio";
            this.preciopromedio.ReadOnly = true;
            // 
            // stockactual
            // 
            this.stockactual.DataPropertyName = "stockactual";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.stockactual.DefaultCellStyle = dataGridViewCellStyle4;
            this.stockactual.HeaderText = "Stock Actual";
            this.stockactual.Name = "stockactual";
            this.stockactual.ReadOnly = true;
            // 
            // comentario_usu
            // 
            this.comentario_usu.HeaderText = "Comentario de Usuario de Req.";
            this.comentario_usu.Name = "comentario_usu";
            this.comentario_usu.ReadOnly = true;
            // 
            // estadototal
            // 
            this.estadototal.HeaderText = "estadototal";
            this.estadototal.Name = "estadototal";
            this.estadototal.ReadOnly = true;
            this.estadototal.Visible = false;
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // customValidator3
            // 
            this.customValidator3.ErrorMessage = "Seleccione almacen.";
            this.customValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator3.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator3_ValidateValue);
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Your error message here.";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator2_ValidateValue_1);
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Your error message here.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue_1);
            // 
            // customValidator4
            // 
            this.customValidator4.ErrorMessage = "Llene Detalle.";
            this.customValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator4.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator4_ValidateValue);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Serie.";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(333, 46);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(65, 20);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.Tag = "";
            this.superValidator1.SetValidator1(this.txtNumero, this.customValidator1);
            // 
            // txtcodserie
            // 
            this.txtcodserie.Location = new System.Drawing.Point(409, 46);
            this.txtcodserie.Name = "txtcodserie";
            this.txtcodserie.Size = new System.Drawing.Size(16, 20);
            this.txtcodserie.TabIndex = 62;
            this.txtcodserie.Visible = false;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(264, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(61, 20);
            this.txtSerie.TabIndex = 3;
            this.superValidator1.SetValidator1(this.txtSerie, this.customValidator2);
            this.txtSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerie_KeyDown);
            // 
            // frmTranferenciaDirecta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(778, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmTranferenciaDirecta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransferenciaDirecta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNotaSalida_Load);
            this.Shown += new System.EventHandler(this.frmTranferenciaDirecta_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lbAlmacen;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbAlmacen;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.TextBox txtAlmacenDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodDoc;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        public System.Windows.Forms.TextBox txtDocRef;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator4;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAlmacenDestino;
        private System.Windows.Forms.ComboBox cmbTransferencia;
        private System.Windows.Forms.TextBox txtAlmacenOri;
        public System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.CheckBox chkReqDet;
        private System.Windows.Forms.DateTimePicker dtpTraslado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnAceptarTransferencia;
        private System.Windows.Forms.ImageList imageList3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbTransportista;
        private System.Windows.Forms.ComboBox cmbVehiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TextBox txtRazonSocialTransporte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtRUCTransporte;
        public System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.TextBox txtTipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn codproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codunidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorpromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorpromediosoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciopromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockactual;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario_usu;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadototal;
        private Reportes.clsReportes.CachedCRCuotasPrestamo cachedCRCuotasPrestamo1;
        private Reportes.clsReportes.CachedCRCuotasPrestamo cachedCRCuotasPrestamo2;
        public System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtcodserie;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
    }
}