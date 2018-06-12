namespace SIGEFA.Formularios
{
    partial class frmCambioProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioProveedor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodProv1 = new System.Windows.Forms.TextBox();
            this.txtCodProv2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccionProv2 = new System.Windows.Forms.TextBox();
            this.txtProveedor2 = new System.Windows.Forms.TextBox();
            this.txtDireccionProv1 = new System.Windows.Forms.TextBox();
            this.txtCodigoProv2 = new System.Windows.Forms.TextBox();
            this.txtProveedor1 = new System.Windows.Forms.TextBox();
            this.txtCodigoProv1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodProv1);
            this.groupBox1.Controls.Add(this.txtCodProv2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDireccionProv2);
            this.groupBox1.Controls.Add(this.txtProveedor2);
            this.groupBox1.Controls.Add(this.txtDireccionProv1);
            this.groupBox1.Controls.Add(this.txtCodigoProv2);
            this.groupBox1.Controls.Add(this.txtProveedor1);
            this.groupBox1.Controls.Add(this.txtCodigoProv1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // txtCodProv1
            // 
            this.txtCodProv1.Enabled = false;
            this.txtCodProv1.Location = new System.Drawing.Point(526, 27);
            this.txtCodProv1.Name = "txtCodProv1";
            this.txtCodProv1.ReadOnly = true;
            this.txtCodProv1.Size = new System.Drawing.Size(49, 20);
            this.txtCodProv1.TabIndex = 10;
            this.txtCodProv1.Visible = false;
            // 
            // txtCodProv2
            // 
            this.txtCodProv2.Enabled = false;
            this.txtCodProv2.Location = new System.Drawing.Point(526, 91);
            this.txtCodProv2.Name = "txtCodProv2";
            this.txtCodProv2.ReadOnly = true;
            this.txtCodProv2.Size = new System.Drawing.Size(49, 20);
            this.txtCodProv2.TabIndex = 9;
            this.txtCodProv2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Proveedor Actual:";
            // 
            // txtDireccionProv2
            // 
            this.txtDireccionProv2.Enabled = false;
            this.txtDireccionProv2.Location = new System.Drawing.Point(107, 117);
            this.txtDireccionProv2.Name = "txtDireccionProv2";
            this.txtDireccionProv2.ReadOnly = true;
            this.txtDireccionProv2.Size = new System.Drawing.Size(413, 20);
            this.txtDireccionProv2.TabIndex = 6;
            // 
            // txtProveedor2
            // 
            this.txtProveedor2.Enabled = false;
            this.txtProveedor2.Location = new System.Drawing.Point(224, 91);
            this.txtProveedor2.Name = "txtProveedor2";
            this.txtProveedor2.ReadOnly = true;
            this.txtProveedor2.Size = new System.Drawing.Size(296, 20);
            this.txtProveedor2.TabIndex = 5;
            // 
            // txtDireccionProv1
            // 
            this.txtDireccionProv1.Enabled = false;
            this.txtDireccionProv1.Location = new System.Drawing.Point(107, 53);
            this.txtDireccionProv1.Name = "txtDireccionProv1";
            this.txtDireccionProv1.ReadOnly = true;
            this.txtDireccionProv1.Size = new System.Drawing.Size(413, 20);
            this.txtDireccionProv1.TabIndex = 4;
            // 
            // txtCodigoProv2
            // 
            this.txtCodigoProv2.Location = new System.Drawing.Point(107, 91);
            this.txtCodigoProv2.Name = "txtCodigoProv2";
            this.txtCodigoProv2.ReadOnly = true;
            this.txtCodigoProv2.Size = new System.Drawing.Size(111, 20);
            this.txtCodigoProv2.TabIndex = 3;
            this.txtCodigoProv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProv2_KeyDown);
            // 
            // txtProveedor1
            // 
            this.txtProveedor1.Enabled = false;
            this.txtProveedor1.Location = new System.Drawing.Point(224, 27);
            this.txtProveedor1.Name = "txtProveedor1";
            this.txtProveedor1.ReadOnly = true;
            this.txtProveedor1.Size = new System.Drawing.Size(296, 20);
            this.txtProveedor1.TabIndex = 2;
            // 
            // txtCodigoProv1
            // 
            this.txtCodigoProv1.Enabled = false;
            this.txtCodigoProv1.Location = new System.Drawing.Point(107, 27);
            this.txtCodigoProv1.Name = "txtCodigoProv1";
            this.txtCodigoProv1.ReadOnly = true;
            this.txtCodigoProv1.Size = new System.Drawing.Size(111, 20);
            this.txtCodigoProv1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor Anterior:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cross.png");
            this.imageList1.Images.SetKeyName(1, "tick.png");
            this.imageList1.Images.SetKeyName(2, "Clear Green Button.ico");
            this.imageList1.Images.SetKeyName(3, "Donate.ico");
            this.imageList1.Images.SetKeyName(4, "Add.png");
            this.imageList1.Images.SetKeyName(5, "Remove.png");
            this.imageList1.Images.SetKeyName(6, "Write Document.png");
            this.imageList1.Images.SetKeyName(7, "Save-icon.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Location = new System.Drawing.Point(193, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "cross.png";
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(90, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageKey = "tick.png";
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(15, 19);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(69, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCambioProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 222);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmCambioProveedor";
            this.Text = "Cambio de Proveedor";
            this.Load += new System.EventHandler(this.frmCambioProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoProv2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccionProv2;
        private System.Windows.Forms.TextBox txtProveedor2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCodigoProv1;
        private System.Windows.Forms.TextBox txtDireccionProv1;
        private System.Windows.Forms.TextBox txtProveedor1;
        private System.Windows.Forms.TextBox txtCodProv1;
        public System.Windows.Forms.TextBox txtCodProv2;
    }
}