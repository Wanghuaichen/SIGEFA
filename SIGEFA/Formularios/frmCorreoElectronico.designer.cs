namespace SIGEFA.Formularios
{
    partial class frmCorreoElectronico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorreoElectronico));
            this.label1 = new System.Windows.Forms.Label();
            this.gbcabecera = new System.Windows.Forms.GroupBox();
            this.txtasunto = new System.Windows.Forms.TextBox();
            this.txtcc = new System.Windows.Forms.TextBox();
            this.txtpara = new System.Windows.Forms.TextBox();
            this.txtde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvadjuntos = new System.Windows.Forms.DataGridView();
            this.gbopciones = new System.Windows.Forms.GroupBox();
            this.gbmensaje = new System.Windows.Forms.GroupBox();
            this.link_adjunto1 = new System.Windows.Forms.LinkLabel();
            this.link_adjunto = new System.Windows.Forms.LinkLabel();
            this.btnadjuntar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtcuerpo = new System.Windows.Forms.TextBox();
            this.pdestinatarios = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chbusuarios = new System.Windows.Forms.CheckBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.dgvcorreos = new System.Windows.Forms.DataGridView();
            this.seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chbproveedores = new System.Windows.Forms.CheckBox();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.gbcabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvadjuntos)).BeginInit();
            this.gbopciones.SuspendLayout();
            this.gbmensaje.SuspendLayout();
            this.pdestinatarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "De :";
            // 
            // gbcabecera
            // 
            this.gbcabecera.Controls.Add(this.txtasunto);
            this.gbcabecera.Controls.Add(this.txtcc);
            this.gbcabecera.Controls.Add(this.txtpara);
            this.gbcabecera.Controls.Add(this.txtde);
            this.gbcabecera.Controls.Add(this.label4);
            this.gbcabecera.Controls.Add(this.label3);
            this.gbcabecera.Controls.Add(this.label2);
            this.gbcabecera.Controls.Add(this.label1);
            this.gbcabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbcabecera.Location = new System.Drawing.Point(0, 0);
            this.gbcabecera.Name = "gbcabecera";
            this.gbcabecera.Size = new System.Drawing.Size(702, 98);
            this.gbcabecera.TabIndex = 1;
            this.gbcabecera.TabStop = false;
            this.gbcabecera.Text = "Datos";
            // 
            // txtasunto
            // 
            this.txtasunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtasunto.Location = new System.Drawing.Point(66, 69);
            this.txtasunto.Name = "txtasunto";
            this.txtasunto.Size = new System.Drawing.Size(559, 20);
            this.txtasunto.TabIndex = 3;
            // 
            // txtcc
            // 
            this.txtcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcc.Location = new System.Drawing.Point(364, 43);
            this.txtcc.Name = "txtcc";
            this.txtcc.Size = new System.Drawing.Size(261, 20);
            this.txtcc.TabIndex = 2;
            this.txtcc.Click += new System.EventHandler(this.txtcc_Click);
            // 
            // txtpara
            // 
            this.txtpara.Location = new System.Drawing.Point(66, 43);
            this.txtpara.Name = "txtpara";
            this.txtpara.Size = new System.Drawing.Size(261, 20);
            this.txtpara.TabIndex = 1;
            this.superValidator1.SetValidator1(this.txtpara, this.customValidator1);
            this.txtpara.Click += new System.EventHandler(this.txtpara_Click);
            // 
            // txtde
            // 
            this.txtde.Location = new System.Drawing.Point(66, 17);
            this.txtde.Name = "txtde";
            this.txtde.Size = new System.Drawing.Size(261, 20);
            this.txtde.TabIndex = 1;
            this.superValidator1.SetValidator1(this.txtde, this.customValidator2);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "CC :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Asunto :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Para :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(463, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Enviar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(540, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(621, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvadjuntos
            // 
            this.dgvadjuntos.AllowUserToAddRows = false;
            this.dgvadjuntos.AllowUserToDeleteRows = false;
            this.dgvadjuntos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvadjuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvadjuntos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvadjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvadjuntos.Location = new System.Drawing.Point(91, 226);
            this.dgvadjuntos.Name = "dgvadjuntos";
            this.dgvadjuntos.ReadOnly = true;
            this.dgvadjuntos.RowHeadersVisible = false;
            this.dgvadjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvadjuntos.Size = new System.Drawing.Size(500, 0);
            this.dgvadjuntos.TabIndex = 4;
            this.dgvadjuntos.Visible = false;
            // 
            // gbopciones
            // 
            this.gbopciones.Controls.Add(this.btnSalir);
            this.gbopciones.Controls.Add(this.btnAceptar);
            this.gbopciones.Controls.Add(this.btnLimpiar);
            this.gbopciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbopciones.Location = new System.Drawing.Point(0, 374);
            this.gbopciones.Name = "gbopciones";
            this.gbopciones.Size = new System.Drawing.Size(702, 43);
            this.gbopciones.TabIndex = 5;
            this.gbopciones.TabStop = false;
            // 
            // gbmensaje
            // 
            this.gbmensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbmensaje.Controls.Add(this.link_adjunto1);
            this.gbmensaje.Controls.Add(this.link_adjunto);
            this.gbmensaje.Controls.Add(this.btnadjuntar);
            this.gbmensaje.Controls.Add(this.label5);
            this.gbmensaje.Controls.Add(this.txtcuerpo);
            this.gbmensaje.Controls.Add(this.dgvadjuntos);
            this.gbmensaje.Location = new System.Drawing.Point(0, 98);
            this.gbmensaje.Name = "gbmensaje";
            this.gbmensaje.Size = new System.Drawing.Size(702, 272);
            this.gbmensaje.TabIndex = 6;
            this.gbmensaje.TabStop = false;
            this.gbmensaje.Text = "Detalle";
            // 
            // link_adjunto1
            // 
            this.link_adjunto1.AutoSize = true;
            this.link_adjunto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_adjunto1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_adjunto1.Location = new System.Drawing.Point(64, 44);
            this.link_adjunto1.Name = "link_adjunto1";
            this.link_adjunto1.Size = new System.Drawing.Size(0, 12);
            this.link_adjunto1.TabIndex = 10;
            this.link_adjunto1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // link_adjunto
            // 
            this.link_adjunto.AutoSize = true;
            this.link_adjunto.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.link_adjunto.Location = new System.Drawing.Point(63, 16);
            this.link_adjunto.Name = "link_adjunto";
            this.link_adjunto.Size = new System.Drawing.Size(55, 13);
            this.link_adjunto.TabIndex = 3;
            this.link_adjunto.TabStop = true;
            this.link_adjunto.Text = "linkLabel1";
            this.link_adjunto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_adjunto_LinkClicked);
            // 
            // btnadjuntar
            // 
            this.btnadjuntar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadjuntar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnadjuntar.ImageIndex = 0;
            this.btnadjuntar.ImageList = this.imageList1;
            this.btnadjuntar.Location = new System.Drawing.Point(631, 33);
            this.btnadjuntar.Name = "btnadjuntar";
            this.btnadjuntar.Size = new System.Drawing.Size(65, 75);
            this.btnadjuntar.TabIndex = 5;
            this.btnadjuntar.Text = "Adjuntar Archivo";
            this.btnadjuntar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnadjuntar.UseVisualStyleBackColor = true;
            this.btnadjuntar.Click += new System.EventHandler(this.btnadjuntar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Empty;
            this.imageList1.Images.SetKeyName(0, "clip.png");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mensaje :";
            // 
            // txtcuerpo
            // 
            this.txtcuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcuerpo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcuerpo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcuerpo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtcuerpo.Location = new System.Drawing.Point(66, 73);
            this.txtcuerpo.Multiline = true;
            this.txtcuerpo.Name = "txtcuerpo";
            this.txtcuerpo.Size = new System.Drawing.Size(559, 186);
            this.txtcuerpo.TabIndex = 4;
            // 
            // pdestinatarios
            // 
            this.pdestinatarios.Controls.Add(this.btnCancelar);
            this.pdestinatarios.Controls.Add(this.chbusuarios);
            this.pdestinatarios.Controls.Add(this.btnagregar);
            this.pdestinatarios.Controls.Add(this.dgvcorreos);
            this.pdestinatarios.Controls.Add(this.chbproveedores);
            this.pdestinatarios.Location = new System.Drawing.Point(145, 42);
            this.pdestinatarios.Name = "pdestinatarios";
            this.pdestinatarios.Size = new System.Drawing.Size(436, 192);
            this.pdestinatarios.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(318, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chbusuarios
            // 
            this.chbusuarios.AutoSize = true;
            this.chbusuarios.Location = new System.Drawing.Point(105, 12);
            this.chbusuarios.Name = "chbusuarios";
            this.chbusuarios.Size = new System.Drawing.Size(67, 17);
            this.chbusuarios.TabIndex = 4;
            this.chbusuarios.Text = "Usuarios";
            this.chbusuarios.UseVisualStyleBackColor = true;
            this.chbusuarios.CheckStateChanged += new System.EventHandler(this.chbusuarios_CheckStateChanged);
            // 
            // btnagregar
            // 
            this.btnagregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnagregar.Location = new System.Drawing.Point(237, 166);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(75, 23);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // dgvcorreos
            // 
            this.dgvcorreos.AllowUserToAddRows = false;
            this.dgvcorreos.AllowUserToDeleteRows = false;
            this.dgvcorreos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvcorreos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvcorreos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcorreos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccion});
            this.dgvcorreos.Location = new System.Drawing.Point(13, 35);
            this.dgvcorreos.Name = "dgvcorreos";
            this.dgvcorreos.RowHeadersVisible = false;
            this.dgvcorreos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcorreos.Size = new System.Drawing.Size(417, 126);
            this.dgvcorreos.TabIndex = 0;
            // 
            // seleccion
            // 
            this.seleccion.FillWeight = 50F;
            this.seleccion.HeaderText = "";
            this.seleccion.Name = "seleccion";
            this.seleccion.Width = 5;
            // 
            // chbproveedores
            // 
            this.chbproveedores.AutoSize = true;
            this.chbproveedores.Location = new System.Drawing.Point(13, 12);
            this.chbproveedores.Name = "chbproveedores";
            this.chbproveedores.Size = new System.Drawing.Size(86, 17);
            this.chbproveedores.TabIndex = 4;
            this.chbproveedores.Text = "Proveedores";
            this.chbproveedores.UseVisualStyleBackColor = true;
            this.chbproveedores.CheckStateChanged += new System.EventHandler(this.chbproveedores_CheckStateChanged);
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
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Ingrese el email de destino.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator1_ValidateValue);
            // 
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "El usuario no tiene email configurado.";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator2_ValidateValue);
            // 
            // frmCorreoElectronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(702, 417);
            this.Controls.Add(this.pdestinatarios);
            this.Controls.Add(this.gbcabecera);
            this.Controls.Add(this.gbopciones);
            this.Controls.Add(this.gbmensaje);
            this.Name = "frmCorreoElectronico";
            this.Text = "Envío de Archivos a Correo Electrónicos";
            this.Load += new System.EventHandler(this.frmCorreoElectronico_Load);
            this.gbcabecera.ResumeLayout(false);
            this.gbcabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvadjuntos)).EndInit();
            this.gbopciones.ResumeLayout(false);
            this.gbmensaje.ResumeLayout(false);
            this.gbmensaje.PerformLayout();
            this.pdestinatarios.ResumeLayout(false);
            this.pdestinatarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbcabecera;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtasunto;
        private System.Windows.Forms.TextBox txtcc;
        private System.Windows.Forms.TextBox txtpara;
        private System.Windows.Forms.TextBox txtde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvadjuntos;
        private System.Windows.Forms.GroupBox gbopciones;
        private System.Windows.Forms.GroupBox gbmensaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnadjuntar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pdestinatarios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chbusuarios;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.DataGridView dgvcorreos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccion;
        private System.Windows.Forms.CheckBox chbproveedores;
        public System.Windows.Forms.LinkLabel link_adjunto;
        private System.Windows.Forms.LinkLabel link_adjunto1;
        public System.Windows.Forms.TextBox txtcuerpo;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
    }
}