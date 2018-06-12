namespace SIGEFA.Formularios
{
    partial class frmFacturasManuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturasManuales));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvNumSerie = new System.Windows.Forms.DataGridView();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvNumSerie);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Correlativos que Faltan";
            // 
            // dgvNumSerie
            // 
            this.dgvNumSerie.AllowUserToAddRows = false;
            this.dgvNumSerie.AllowUserToDeleteRows = false;
            this.dgvNumSerie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumSerie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numSerie});
            this.dgvNumSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNumSerie.Location = new System.Drawing.Point(3, 16);
            this.dgvNumSerie.MultiSelect = false;
            this.dgvNumSerie.Name = "dgvNumSerie";
            this.dgvNumSerie.ReadOnly = true;
            this.dgvNumSerie.RowHeadersVisible = false;
            this.dgvNumSerie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNumSerie.Size = new System.Drawing.Size(134, 218);
            this.dgvNumSerie.TabIndex = 0;
            this.dgvNumSerie.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumSerie_CellDoubleClick);
            this.dgvNumSerie.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumSerie_CellContentDoubleClick);
            // 
            // numSerie
            // 
            this.numSerie.HeaderText = "NumeroSerie";
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Visible = false;
            this.numSerie.Width = 200;
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
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageList = this.imageList2;
            this.btnAceptar.Location = new System.Drawing.Point(6, 255);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 32);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "cross.png");
            this.imageList2.Images.SetKeyName(1, "tick.png");
            this.imageList2.Images.SetKeyName(2, "Clear Green Button.ico");
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(89, 255);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 32);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmFacturasManuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 298);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmFacturasManuales";
            this.Text = "frmFacturasManuales";
            this.Load += new System.EventHandler(this.frmFacturasManuales_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumSerie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dgvNumSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnSalir;
    }
}