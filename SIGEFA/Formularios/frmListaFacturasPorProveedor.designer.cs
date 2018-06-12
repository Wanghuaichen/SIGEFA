namespace SIGEFA.Formularios
{
    partial class frmListaFacturasPorProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaFacturasPorProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.codfacturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechasalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonsocials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProveedors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.ImageIndex = 6;
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(578, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 32);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 40);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDocumentos);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 305);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Facturas";
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToResizeColumns = false;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codfacturas,
            this.fechasalida,
            this.ruc,
            this.razonsocials,
            this.documentos,
            this.codProveedors,
            this.responsables,
            this.comentarios,
            this.Estados});
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.Location = new System.Drawing.Point(3, 16);
            this.dgvDocumentos.MultiSelect = false;
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowHeadersVisible = false;
            this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentos.Size = new System.Drawing.Size(679, 286);
            this.dgvDocumentos.TabIndex = 10;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellClick);
            this.dgvDocumentos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocumentos_CellMouseDoubleClick);
            // 
            // codfacturas
            // 
            this.codfacturas.DataPropertyName = "codFactura";
            this.codfacturas.HeaderText = "codigo";
            this.codfacturas.Name = "codfacturas";
            this.codfacturas.ReadOnly = true;
            this.codfacturas.Visible = false;
            // 
            // fechasalida
            // 
            this.fechasalida.DataPropertyName = "fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechasalida.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechasalida.HeaderText = "Fecha";
            this.fechasalida.Name = "fechasalida";
            this.fechasalida.ReadOnly = true;
            // 
            // ruc
            // 
            this.ruc.DataPropertyName = "ruc";
            this.ruc.HeaderText = "RUC";
            this.ruc.Name = "ruc";
            this.ruc.ReadOnly = true;
            this.ruc.Visible = false;
            // 
            // razonsocials
            // 
            this.razonsocials.DataPropertyName = "razonsocial";
            this.razonsocials.HeaderText = "Razon Social";
            this.razonsocials.Name = "razonsocials";
            this.razonsocials.ReadOnly = true;
            this.razonsocials.Width = 150;
            // 
            // documentos
            // 
            this.documentos.DataPropertyName = "documento";
            this.documentos.HeaderText = "Documento";
            this.documentos.Name = "documentos";
            this.documentos.ReadOnly = true;
            // 
            // codProveedors
            // 
            this.codProveedors.DataPropertyName = "codProveedor";
            this.codProveedors.HeaderText = "codProveedor";
            this.codProveedors.Name = "codProveedors";
            this.codProveedors.ReadOnly = true;
            this.codProveedors.Visible = false;
            // 
            // responsables
            // 
            this.responsables.DataPropertyName = "responsable";
            this.responsables.HeaderText = "Responsable";
            this.responsables.Name = "responsables";
            this.responsables.ReadOnly = true;
            // 
            // comentarios
            // 
            this.comentarios.DataPropertyName = "comentario";
            this.comentarios.HeaderText = "Comentario";
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            // 
            // Estados
            // 
            this.Estados.DataPropertyName = "Estado";
            this.Estados.HeaderText = "Estado";
            this.Estados.Name = "Estados";
            this.Estados.ReadOnly = true;
            // 
            // frmListaFacturasPorProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAceptar;
            this.ClientSize = new System.Drawing.Size(691, 345);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListaFacturasPorProveedor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas de Compra";
            this.Load += new System.EventHandler(this.frmListaDocumentosSinGuia_Load);
            this.Shown += new System.EventHandler(this.frmListaFacturasPorProveedor_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codfacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechasalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonsocials;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProveedors;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsables;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estados;
    }
}