namespace SIGEFA.Reportes
{
    partial class frmParamVentxArticuloxVendedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRan2 = new System.Windows.Forms.TextBox();
            this.txtRan1 = new System.Windows.Forms.TextBox();
            this.txtArticulo2 = new System.Windows.Forms.TextBox();
            this.txtUnArt2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.txtUnArt = new System.Windows.Forms.TextBox();
            this.rbArt = new System.Windows.Forms.RadioButton();
            this.rbTodosArt = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbVendedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpFecha2);
            this.groupBox1.Controls.Add(this.dtpFecha1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 69);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(229, 31);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(166, 20);
            this.cmbVendedor.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(227, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "Vendedor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(122, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "Hasta";
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(124, 31);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(99, 20);
            this.dtpFecha2.TabIndex = 28;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(19, 31);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(99, 20);
            this.dtpFecha1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "Desde";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.Location = new System.Drawing.Point(408, 238);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.ImageIndex = 1;
            this.btnReporte.Location = new System.Drawing.Point(327, 238);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 13;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRan2);
            this.groupBox4.Controls.Add(this.txtRan1);
            this.groupBox4.Controls.Add(this.txtArticulo2);
            this.groupBox4.Controls.Add(this.txtUnArt2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtArticulo);
            this.groupBox4.Controls.Add(this.txtUnArt);
            this.groupBox4.Controls.Add(this.rbArt);
            this.groupBox4.Controls.Add(this.rbTodosArt);
            this.groupBox4.Location = new System.Drawing.Point(12, 87);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(471, 140);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Por Artículo";
            // 
            // txtRan2
            // 
            this.txtRan2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRan2.Enabled = false;
            this.txtRan2.Location = new System.Drawing.Point(435, 92);
            this.txtRan2.Name = "txtRan2";
            this.txtRan2.Size = new System.Drawing.Size(30, 20);
            this.txtRan2.TabIndex = 69;
            this.txtRan2.Visible = false;
            // 
            // txtRan1
            // 
            this.txtRan1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRan1.Enabled = false;
            this.txtRan1.Location = new System.Drawing.Point(435, 66);
            this.txtRan1.Name = "txtRan1";
            this.txtRan1.Size = new System.Drawing.Size(30, 20);
            this.txtRan1.TabIndex = 68;
            this.txtRan1.Visible = false;
            // 
            // txtArticulo2
            // 
            this.txtArticulo2.Enabled = false;
            this.txtArticulo2.Location = new System.Drawing.Point(184, 92);
            this.txtArticulo2.Name = "txtArticulo2";
            this.txtArticulo2.Size = new System.Drawing.Size(248, 20);
            this.txtArticulo2.TabIndex = 67;
            // 
            // txtUnArt2
            // 
            this.txtUnArt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnArt2.Enabled = false;
            this.txtUnArt2.Location = new System.Drawing.Point(94, 92);
            this.txtUnArt2.Name = "txtUnArt2";
            this.txtUnArt2.Size = new System.Drawing.Size(84, 20);
            this.txtUnArt2.TabIndex = 66;
            this.txtUnArt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnArt2_KeyDown);
            this.txtUnArt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnArt2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(61, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Fin :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(50, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Inicio :";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Enabled = false;
            this.txtArticulo.Location = new System.Drawing.Point(184, 66);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(248, 20);
            this.txtArticulo.TabIndex = 63;
            // 
            // txtUnArt
            // 
            this.txtUnArt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnArt.Enabled = false;
            this.txtUnArt.Location = new System.Drawing.Point(94, 66);
            this.txtUnArt.Name = "txtUnArt";
            this.txtUnArt.Size = new System.Drawing.Size(84, 20);
            this.txtUnArt.TabIndex = 61;
            this.txtUnArt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnArt_KeyDown);
            this.txtUnArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnArt_KeyPress);
            // 
            // rbArt
            // 
            this.rbArt.AutoSize = true;
            this.rbArt.BackColor = System.Drawing.Color.Transparent;
            this.rbArt.Location = new System.Drawing.Point(19, 42);
            this.rbArt.Name = "rbArt";
            this.rbArt.Size = new System.Drawing.Size(57, 17);
            this.rbArt.TabIndex = 57;
            this.rbArt.Text = "Rango";
            this.rbArt.UseVisualStyleBackColor = false;
            this.rbArt.CheckedChanged += new System.EventHandler(this.rbArt_CheckedChanged);
            // 
            // rbTodosArt
            // 
            this.rbTodosArt.AutoSize = true;
            this.rbTodosArt.BackColor = System.Drawing.Color.Transparent;
            this.rbTodosArt.Checked = true;
            this.rbTodosArt.Location = new System.Drawing.Point(19, 19);
            this.rbTodosArt.Name = "rbTodosArt";
            this.rbTodosArt.Size = new System.Drawing.Size(115, 17);
            this.rbTodosArt.TabIndex = 54;
            this.rbTodosArt.TabStop = true;
            this.rbTodosArt.Text = "Todos los artículos";
            this.rbTodosArt.UseVisualStyleBackColor = false;
            // 
            // frmParamVentxArticuloxVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(495, 273);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParamVentxArticuloxVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ventas Vendedor / Articulo";
            this.Load += new System.EventHandler(this.frmParamVentxCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox txtUnArt;
        private System.Windows.Forms.RadioButton rbArt;
        private System.Windows.Forms.RadioButton rbTodosArt;
        public System.Windows.Forms.TextBox txtArticulo;
        public System.Windows.Forms.TextBox txtArticulo2;
        public System.Windows.Forms.TextBox txtUnArt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRan2;
        public System.Windows.Forms.TextBox txtRan1;
    }
}