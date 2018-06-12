namespace SIGEFA.Formularios
{
    partial class frmConciliacionesBancarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConciliacionesBancarias));
            this.txtTipoCta = new System.Windows.Forms.TextBox();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Conciliar = new System.Windows.Forms.GroupBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsaldosegunlibro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChequenoCobrados = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtsaldosegunextracto = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.codMovimientos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCtaCorriente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentacorriente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desctipomovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codnotasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codnotaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionactivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldocuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalNoCobrado = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGuardar2 = new System.Windows.Forms.Button();
            this.btnNuevo2 = new System.Windows.Forms.Button();
            this.btnReporte2 = new System.Windows.Forms.Button();
            this.btnEditar2 = new System.Windows.Forms.Button();
            this.btnConciliar = new System.Windows.Forms.Button();
            this.Conciliar.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTipoCta
            // 
            this.txtTipoCta.Location = new System.Drawing.Point(136, 100);
            this.txtTipoCta.Name = "txtTipoCta";
            this.txtTipoCta.ReadOnly = true;
            this.txtTipoCta.Size = new System.Drawing.Size(211, 20);
            this.txtTipoCta.TabIndex = 10;
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(136, 62);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(210, 21);
            this.cmbCuenta.TabIndex = 9;
            // 
            // cmbBanco
            // 
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(137, 28);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(210, 21);
            this.cmbBanco.TabIndex = 8;
            this.cmbBanco.SelectionChangeCommitted += new System.EventHandler(this.cmbBanco_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tipo Cta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cta. Corriente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Banco:";
            // 
            // Conciliar
            // 
            this.Conciliar.Controls.Add(this.cmbMoneda);
            this.Conciliar.Controls.Add(this.label7);
            this.Conciliar.Controls.Add(this.label5);
            this.Conciliar.Controls.Add(this.txtsaldosegunlibro);
            this.Conciliar.Controls.Add(this.label4);
            this.Conciliar.Controls.Add(this.txtChequenoCobrados);
            this.Conciliar.Controls.Add(this.label16);
            this.Conciliar.Controls.Add(this.txtsaldosegunextracto);
            this.Conciliar.Controls.Add(this.cmbBanco);
            this.Conciliar.Controls.Add(this.txtTipoCta);
            this.Conciliar.Controls.Add(this.label1);
            this.Conciliar.Controls.Add(this.cmbCuenta);
            this.Conciliar.Controls.Add(this.label2);
            this.Conciliar.Controls.Add(this.label3);
            this.Conciliar.Location = new System.Drawing.Point(12, 12);
            this.Conciliar.Name = "Conciliar";
            this.Conciliar.Size = new System.Drawing.Size(357, 280);
            this.Conciliar.TabIndex = 14;
            this.Conciliar.TabStop = false;
            this.Conciliar.Text = "Conciliacion";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(135, 132);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(210, 21);
            this.cmbMoneda.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Moneda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Saldo Segun Libro:";
            // 
            // txtsaldosegunlibro
            // 
            this.txtsaldosegunlibro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsaldosegunlibro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsaldosegunlibro.Enabled = false;
            this.txtsaldosegunlibro.Location = new System.Drawing.Point(179, 246);
            this.txtsaldosegunlibro.Name = "txtsaldosegunlibro";
            this.txtsaldosegunlibro.Size = new System.Drawing.Size(166, 20);
            this.txtsaldosegunlibro.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Cheques Girados No Cobrados:";
            // 
            // txtChequenoCobrados
            // 
            this.txtChequenoCobrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequenoCobrados.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChequenoCobrados.Enabled = false;
            this.txtChequenoCobrados.Location = new System.Drawing.Point(179, 209);
            this.txtChequenoCobrados.Name = "txtChequenoCobrados";
            this.txtChequenoCobrados.Size = new System.Drawing.Size(166, 20);
            this.txtChequenoCobrados.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Saldo Segun Extracto:";
            // 
            // txtsaldosegunextracto
            // 
            this.txtsaldosegunextracto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsaldosegunextracto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsaldosegunextracto.Enabled = false;
            this.txtsaldosegunextracto.Location = new System.Drawing.Point(179, 170);
            this.txtsaldosegunextracto.Name = "txtsaldosegunextracto";
            this.txtsaldosegunextracto.Size = new System.Drawing.Size(166, 20);
            this.txtsaldosegunextracto.TabIndex = 31;
            this.txtsaldosegunextracto.Leave += new System.EventHandler(this.txtsaldosegunextracto_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Conciliar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetalle);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtTotalNoCobrado);
            this.splitContainer1.Size = new System.Drawing.Size(991, 350);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 15;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.ColumnHeadersVisible = false;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codMovimientos,
            this.codBanco,
            this.banco,
            this.codCtaCorriente,
            this.cuentacorriente,
            this.numTransaccion,
            this.fechaMov,
            this.transaccion,
            this.desctipomovimiento,
            this.tipomovimiento,
            this.haber,
            this.debe,
            this.tipoCV,
            this.saldo,
            this.tipoCC,
            this.codnotasalida,
            this.codnotaingreso,
            this.fecharegistro,
            this.nombre,
            this.direccion,
            this.dni,
            this.descripcion,
            this.activo,
            this.descripcionactivo,
            this.saldocuenta});
            this.dgvDetalle.Location = new System.Drawing.Point(23, 12);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(567, 211);
            this.dgvDetalle.TabIndex = 37;
            // 
            // codMovimientos
            // 
            this.codMovimientos.DataPropertyName = "codCtaCteMovimiento";
            this.codMovimientos.HeaderText = "codMovimientos";
            this.codMovimientos.Name = "codMovimientos";
            this.codMovimientos.ReadOnly = true;
            this.codMovimientos.Visible = false;
            // 
            // codBanco
            // 
            this.codBanco.DataPropertyName = "codBanco";
            this.codBanco.HeaderText = "codBanco";
            this.codBanco.Name = "codBanco";
            this.codBanco.ReadOnly = true;
            this.codBanco.Visible = false;
            // 
            // banco
            // 
            this.banco.DataPropertyName = "NomBanco";
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            this.banco.Width = 150;
            // 
            // codCtaCorriente
            // 
            this.codCtaCorriente.DataPropertyName = "codCuentaCorriente";
            this.codCtaCorriente.HeaderText = "codCtaCorriente";
            this.codCtaCorriente.Name = "codCtaCorriente";
            this.codCtaCorriente.ReadOnly = true;
            this.codCtaCorriente.Visible = false;
            // 
            // cuentacorriente
            // 
            this.cuentacorriente.DataPropertyName = "cuentacorriente";
            this.cuentacorriente.HeaderText = "CuentaCorriente";
            this.cuentacorriente.Name = "cuentacorriente";
            this.cuentacorriente.ReadOnly = true;
            this.cuentacorriente.Width = 150;
            // 
            // numTransaccion
            // 
            this.numTransaccion.DataPropertyName = "NumTransaccion";
            this.numTransaccion.HeaderText = "NumTransaccion";
            this.numTransaccion.Name = "numTransaccion";
            this.numTransaccion.ReadOnly = true;
            this.numTransaccion.Visible = false;
            // 
            // fechaMov
            // 
            this.fechaMov.DataPropertyName = "fechaMovimiento";
            this.fechaMov.HeaderText = "Fecha Movimiento";
            this.fechaMov.Name = "fechaMov";
            this.fechaMov.ReadOnly = true;
            // 
            // transaccion
            // 
            this.transaccion.DataPropertyName = "Transaccion";
            this.transaccion.HeaderText = "Transaccion";
            this.transaccion.Name = "transaccion";
            this.transaccion.ReadOnly = true;
            this.transaccion.Visible = false;
            // 
            // desctipomovimiento
            // 
            this.desctipomovimiento.DataPropertyName = "desctipomovimiento";
            this.desctipomovimiento.HeaderText = "MOVIMIENTO";
            this.desctipomovimiento.Name = "desctipomovimiento";
            this.desctipomovimiento.ReadOnly = true;
            this.desctipomovimiento.Width = 200;
            // 
            // tipomovimiento
            // 
            this.tipomovimiento.HeaderText = "Tipo Movimiento";
            this.tipomovimiento.Name = "tipomovimiento";
            this.tipomovimiento.ReadOnly = true;
            this.tipomovimiento.Visible = false;
            this.tipomovimiento.Width = 200;
            // 
            // haber
            // 
            this.haber.DataPropertyName = "ingreso";
            this.haber.HeaderText = "INGRESO (DEUDOR)";
            this.haber.Name = "haber";
            this.haber.ReadOnly = true;
            // 
            // debe
            // 
            this.debe.DataPropertyName = "egreso";
            this.debe.HeaderText = "EGRESO (ACREEDOR)";
            this.debe.Name = "debe";
            this.debe.ReadOnly = true;
            // 
            // tipoCV
            // 
            this.tipoCV.DataPropertyName = "tcventa";
            this.tipoCV.HeaderText = "TipoCambio Venta";
            this.tipoCV.Name = "tipoCV";
            this.tipoCV.ReadOnly = true;
            this.tipoCV.Visible = false;
            // 
            // saldo
            // 
            this.saldo.DataPropertyName = "saldo";
            this.saldo.HeaderText = "SALDO";
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
            this.saldo.Visible = false;
            this.saldo.Width = 80;
            // 
            // tipoCC
            // 
            this.tipoCC.DataPropertyName = "tccompra";
            this.tipoCC.HeaderText = "TipoCambio Compra";
            this.tipoCC.Name = "tipoCC";
            this.tipoCC.ReadOnly = true;
            this.tipoCC.Visible = false;
            // 
            // codnotasalida
            // 
            this.codnotasalida.HeaderText = "codnotasalida";
            this.codnotasalida.Name = "codnotasalida";
            this.codnotasalida.ReadOnly = true;
            this.codnotasalida.Visible = false;
            // 
            // codnotaingreso
            // 
            this.codnotaingreso.HeaderText = "codnotaingreso";
            this.codnotaingreso.Name = "codnotaingreso";
            this.codnotaingreso.ReadOnly = true;
            this.codnotaingreso.Visible = false;
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "fecharegistro";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "NOMBRE";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            this.nombre.Width = 150;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "DIRECCION";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Visible = false;
            this.direccion.Width = 150;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Visible = false;
            this.descripcion.Width = 200;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Visible = false;
            // 
            // descripcionactivo
            // 
            this.descripcionactivo.DataPropertyName = "descripcionactivo";
            this.descripcionactivo.HeaderText = "Desc. Pago";
            this.descripcionactivo.Name = "descripcionactivo";
            this.descripcionactivo.ReadOnly = true;
            // 
            // saldocuenta
            // 
            this.saldocuenta.DataPropertyName = "saldocuenta";
            this.saldocuenta.HeaderText = "saldocuenta";
            this.saldocuenta.Name = "saldocuenta";
            this.saldocuenta.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Total de Cheques Girados No Cobrados:";
            // 
            // txtTotalNoCobrado
            // 
            this.txtTotalNoCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNoCobrado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalNoCobrado.Location = new System.Drawing.Point(340, 251);
            this.txtTotalNoCobrado.Name = "txtTotalNoCobrado";
            this.txtTotalNoCobrado.Size = new System.Drawing.Size(125, 20);
            this.txtTotalNoCobrado.TabIndex = 35;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.btnSalir);
            this.groupBox4.Controls.Add(this.btnGuardar2);
            this.groupBox4.Controls.Add(this.btnNuevo2);
            this.groupBox4.Controls.Add(this.btnReporte2);
            this.groupBox4.Controls.Add(this.btnEditar2);
            this.groupBox4.Controls.Add(this.btnConciliar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(991, 52);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(893, 13);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(61, 32);
            this.btnSalir.TabIndex = 1;
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
            this.imageList1.Images.SetKeyName(6, "-arriba-icono.jpg");
            this.imageList1.Images.SetKeyName(7, "thumb.png");
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.Enabled = false;
            this.btnGuardar2.ImageIndex = 4;
            this.btnGuardar2.ImageList = this.imageList1;
            this.btnGuardar2.Location = new System.Drawing.Point(788, 13);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(86, 32);
            this.btnGuardar2.TabIndex = 0;
            this.btnGuardar2.Text = "Guardar";
            this.btnGuardar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar2.UseVisualStyleBackColor = true;
            this.btnGuardar2.Click += new System.EventHandler(this.btnGuardar2_Click);
            // 
            // btnNuevo2
            // 
            this.btnNuevo2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo2.ImageIndex = 1;
            this.btnNuevo2.ImageList = this.imageList1;
            this.btnNuevo2.Location = new System.Drawing.Point(8, 13);
            this.btnNuevo2.Name = "btnNuevo2";
            this.btnNuevo2.Size = new System.Drawing.Size(71, 32);
            this.btnNuevo2.TabIndex = 2;
            this.btnNuevo2.Text = "Nuevo";
            this.btnNuevo2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo2.UseVisualStyleBackColor = true;
            this.btnNuevo2.Visible = false;
            // 
            // btnReporte2
            // 
            this.btnReporte2.ImageIndex = 3;
            this.btnReporte2.ImageList = this.imageList1;
            this.btnReporte2.Location = new System.Drawing.Point(449, 13);
            this.btnReporte2.Name = "btnReporte2";
            this.btnReporte2.Size = new System.Drawing.Size(78, 32);
            this.btnReporte2.TabIndex = 59;
            this.btnReporte2.Text = "Reporte";
            this.btnReporte2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte2.UseVisualStyleBackColor = true;
            this.btnReporte2.Visible = false;
            // 
            // btnEditar2
            // 
            this.btnEditar2.Enabled = false;
            this.btnEditar2.ImageIndex = 0;
            this.btnEditar2.ImageList = this.imageList1;
            this.btnEditar2.Location = new System.Drawing.Point(85, 13);
            this.btnEditar2.Name = "btnEditar2";
            this.btnEditar2.Size = new System.Drawing.Size(66, 32);
            this.btnEditar2.TabIndex = 57;
            this.btnEditar2.Text = "Editar";
            this.btnEditar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar2.UseVisualStyleBackColor = true;
            this.btnEditar2.Visible = false;
            // 
            // btnConciliar
            // 
            this.btnConciliar.ImageIndex = 7;
            this.btnConciliar.ImageList = this.imageList1;
            this.btnConciliar.Location = new System.Drawing.Point(211, 12);
            this.btnConciliar.Name = "btnConciliar";
            this.btnConciliar.Size = new System.Drawing.Size(91, 32);
            this.btnConciliar.TabIndex = 58;
            this.btnConciliar.Text = "Conciliar";
            this.btnConciliar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConciliar.UseVisualStyleBackColor = true;
            this.btnConciliar.Click += new System.EventHandler(this.btnConciliar_Click);
            // 
            // frmConciliacionesBancarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 350);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "frmConciliacionesBancarias";
            this.Text = "frmConciliacionesBancarias";
            this.Load += new System.EventHandler(this.frmConciliacionesBancarias_Load);
            this.Conciliar.ResumeLayout(false);
            this.Conciliar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtTipoCta;
        public System.Windows.Forms.ComboBox cmbCuenta;
        public System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Conciliar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtChequenoCobrados;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtsaldosegunextracto;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtsaldosegunlibro;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtTotalNoCobrado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar2;
        private System.Windows.Forms.Button btnNuevo2;
        private System.Windows.Forms.Button btnReporte2;
        private System.Windows.Forms.Button btnEditar2;
        private System.Windows.Forms.Button btnConciliar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgvDetalle;
        public System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCtaCorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentacorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn desctipomovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionactivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldocuenta;
    }
}