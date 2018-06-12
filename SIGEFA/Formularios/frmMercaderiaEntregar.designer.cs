namespace SIGEFA.Formularios
{
    partial class frmMercaderiaEntregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMercaderiaEntregar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.dgvDetalle2 = new System.Windows.Forms.DataGridView();
            this.codnotasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalle2);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cross.png");
            this.imageList1.Images.SetKeyName(1, "tick.png");
            this.imageList1.Images.SetKeyName(2, "Clear Green Button.ico");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Write Document.png");
            this.imageList2.Images.SetKeyName(1, "New Document.png");
            this.imageList2.Images.SetKeyName(2, "Remove Document.png");
            this.imageList2.Images.SetKeyName(3, "document-print.png");
            this.imageList2.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList2.Images.SetKeyName(5, "exit.png");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "exit.png");
            this.imageList3.Images.SetKeyName(1, "pedido.png");
            this.imageList3.Images.SetKeyName(2, "carrito.png");
            this.imageList3.Images.SetKeyName(3, "delete-file-icon.png");
            this.imageList3.Images.SetKeyName(4, "DeleteRed.png");
            this.imageList3.Images.SetKeyName(5, "document_delete.png");
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "Write Document.png");
            this.imageList4.Images.SetKeyName(1, "New Document.png");
            this.imageList4.Images.SetKeyName(2, "Remove Document.png");
            this.imageList4.Images.SetKeyName(3, "document-print.png");
            this.imageList4.Images.SetKeyName(4, "guardar-documento-icono-7840-48.png");
            this.imageList4.Images.SetKeyName(5, "exit.png");
            this.imageList4.Images.SetKeyName(6, "search (1).png");
            this.imageList4.Images.SetKeyName(7, "Glossy-Open-icon.png");
            this.imageList4.Images.SetKeyName(8, "folder-open-icon (1).png");
            this.imageList4.Images.SetKeyName(9, "document_delete.png");
            this.imageList4.Images.SetKeyName(10, "DeleteRed.png");
            this.imageList4.Images.SetKeyName(11, "OK_Verde.png");
            this.imageList4.Images.SetKeyName(12, "Remove.png");
            // 
            // dgvDetalle2
            // 
            this.dgvDetalle2.AllowUserToAddRows = false;
            this.dgvDetalle2.AllowUserToDeleteRows = false;
            this.dgvDetalle2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codnotasalida,
            this.fechasalida,
            this.tipodoc,
            this.serie,
            this.numdoc,
            this.almacen,
            this.docref});
            this.dgvDetalle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle2.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalle2.MultiSelect = false;
            this.dgvDetalle2.Name = "dgvDetalle2";
            this.dgvDetalle2.ReadOnly = true;
            this.dgvDetalle2.RowHeadersVisible = false;
            this.dgvDetalle2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle2.Size = new System.Drawing.Size(483, 324);
            this.dgvDetalle2.TabIndex = 4;
            this.dgvDetalle2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle2_CellDoubleClick);
            this.dgvDetalle2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetalle2_CellMouseDoubleClick);
            // 
            // codnotasalida
            // 
            this.codnotasalida.DataPropertyName = "codNotaSalida";
            this.codnotasalida.HeaderText = "CodNotaSalida";
            this.codnotasalida.Name = "codnotasalida";
            this.codnotasalida.ReadOnly = true;
            this.codnotasalida.Visible = false;
            // 
            // fechasalida
            // 
            this.fechasalida.DataPropertyName = "fechasalida";
            this.fechasalida.HeaderText = "Fecha Salida";
            this.fechasalida.Name = "fechasalida";
            this.fechasalida.ReadOnly = true;
            // 
            // tipodoc
            // 
            this.tipodoc.DataPropertyName = "sigla";
            this.tipodoc.HeaderText = "Tipo Doc.";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.ReadOnly = true;
            this.tipodoc.Width = 80;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Width = 70;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "N° Doc.";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            this.numdoc.Width = 90;
            // 
            // almacen
            // 
            this.almacen.DataPropertyName = "nomalmacen";
            this.almacen.HeaderText = "Almacen";
            this.almacen.Name = "almacen";
            this.almacen.ReadOnly = true;
            this.almacen.Width = 135;
            // 
            // docref
            // 
            this.docref.DataPropertyName = "documentoreferencia";
            this.docref.HeaderText = "Doc.Ref";
            this.docref.Name = "docref";
            this.docref.ReadOnly = true;
            this.docref.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(144, 361);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 55;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageIndex = 5;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(240, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 30);
            this.btnSalir.TabIndex = 56;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMercaderiaEntregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 398);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMercaderiaEntregar";
            this.Text = "Mercaderia Por Entregar";
            this.Load += new System.EventHandler(this.frmMercaderiaEntregar_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList4;
        public System.Windows.Forms.DataGridView dgvDetalle2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codnotasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn docref;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;

    }
}