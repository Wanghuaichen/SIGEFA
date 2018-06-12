using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
namespace SIGEFA.Formularios
{
    partial class frmEnvioSunat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioSunat));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_documentos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Repoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correlativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadosunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensajesunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pdf = new System.Windows.Forms.DataGridViewImageColumn();
            this.Xml = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nombredoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_envio = new DevComponents.DotNetBar.ButtonX();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.lblTotalDocumentos = new DevComponents.DotNetBar.LabelX();
            this.totaldocs = new DevComponents.DotNetBar.LabelX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_documentos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Controls.Add(this.cb_estado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // cb_estado
            // 
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Items.AddRange(new object[] {
            "NO ENVIADOS",
            "ENVIADOS"});
            this.cb_estado.Location = new System.Drawing.Point(986, 32);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(121, 21);
            this.cb_estado.TabIndex = 3;
            this.cb_estado.SelectedIndexChanged += new System.EventHandler(this.cb_estado_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(901, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ESTADO: ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(377, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOCUMENTOS A ENVIAR A SUNAT";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FloralWhite;
            this.groupBox2.Controls.Add(this.dg_documentos);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1123, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Boletas y Notas de Crédito / Débito asociadas";
            // 
            // dg_documentos
            // 
            this.dg_documentos.AllowUserToAddRows = false;
            this.dg_documentos.AllowUserToDeleteRows = false;
            this.dg_documentos.AllowUserToOrderColumns = true;
            this.dg_documentos.AllowUserToResizeRows = false;
            this.dg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_documentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Repoid,
            this.Tipodoc,
            this.Fechaemision,
            this.Serie,
            this.Correlativo,
            this.Monto,
            this.Estadosunat,
            this.Mensajesunat,
            this.Pdf,
            this.Xml,
            this.Nombredoc});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_documentos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dg_documentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_documentos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_documentos.Location = new System.Drawing.Point(3, 16);
            this.dg_documentos.MultiSelect = false;
            this.dg_documentos.Name = "dg_documentos";
            this.dg_documentos.ReadOnly = true;
            this.dg_documentos.RowHeadersVisible = false;
            this.dg_documentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_documentos.Size = new System.Drawing.Size(1117, 286);
            this.dg_documentos.TabIndex = 0;
            // 
            // Repoid
            // 
            this.Repoid.DataPropertyName = "Repoid";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Repoid.DefaultCellStyle = dataGridViewCellStyle1;
            this.Repoid.HeaderText = "ID";
            this.Repoid.Name = "Repoid";
            this.Repoid.ReadOnly = true;
            this.Repoid.Visible = false;
            this.Repoid.Width = 40;
            // 
            // Tipodoc
            // 
            this.Tipodoc.DataPropertyName = "Tipodoc";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipodoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tipodoc.HeaderText = "T. DOC";
            this.Tipodoc.Name = "Tipodoc";
            this.Tipodoc.ReadOnly = true;
            this.Tipodoc.Visible = false;
            this.Tipodoc.Width = 50;
            // 
            // Fechaemision
            // 
            this.Fechaemision.DataPropertyName = "Fechaemision";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Fechaemision.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fechaemision.HeaderText = "F. EMISION";
            this.Fechaemision.Name = "Fechaemision";
            this.Fechaemision.ReadOnly = true;
            this.Fechaemision.Width = 90;
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "Serie";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Serie.DefaultCellStyle = dataGridViewCellStyle4;
            this.Serie.HeaderText = "SERIE";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Width = 50;
            // 
            // Correlativo
            // 
            this.Correlativo.DataPropertyName = "Correlativo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Correlativo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Correlativo.HeaderText = "CORRELATIVO";
            this.Correlativo.Name = "Correlativo";
            this.Correlativo.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle6;
            this.Monto.HeaderText = "MONTO";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 70;
            // 
            // Estadosunat
            // 
            this.Estadosunat.DataPropertyName = "Estadosunat";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Estadosunat.DefaultCellStyle = dataGridViewCellStyle7;
            this.Estadosunat.HeaderText = "EST. SUNAT";
            this.Estadosunat.Name = "Estadosunat";
            this.Estadosunat.ReadOnly = true;
            // 
            // Mensajesunat
            // 
            this.Mensajesunat.DataPropertyName = "Mensajesunat";
            this.Mensajesunat.HeaderText = "MENSAJE SUNAT";
            this.Mensajesunat.Name = "Mensajesunat";
            this.Mensajesunat.ReadOnly = true;
            this.Mensajesunat.Width = 350;
            // 
            // Pdf
            // 
            this.Pdf.DataPropertyName = "Pdf";
            this.Pdf.HeaderText = "PDF";
            this.Pdf.Name = "Pdf";
            this.Pdf.ReadOnly = true;
            this.Pdf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pdf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pdf.Width = 70;
            // 
            // Xml
            // 
            this.Xml.DataPropertyName = "Xml";
            this.Xml.HeaderText = "XML";
            this.Xml.Name = "Xml";
            this.Xml.ReadOnly = true;
            this.Xml.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Xml.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Xml.Width = 70;
            // 
            // Nombredoc
            // 
            this.Nombredoc.DataPropertyName = "Nombredoc";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nombredoc.DefaultCellStyle = dataGridViewCellStyle8;
            this.Nombredoc.HeaderText = "NOMBRE DOCUMENTO";
            this.Nombredoc.Name = "Nombredoc";
            this.Nombredoc.ReadOnly = true;
            this.Nombredoc.Width = 200;
            // 
            // btn_envio
            // 
            this.btn_envio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_envio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_envio.Enabled = false;
            this.btn_envio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_envio.Image = ((System.Drawing.Image)(resources.GetObject("btn_envio.Image")));
            this.btn_envio.Location = new System.Drawing.Point(1026, 417);
            this.btn_envio.Name = "btn_envio";
            this.btn_envio.Size = new System.Drawing.Size(106, 23);
            this.btn_envio.TabIndex = 2;
            this.btn_envio.Text = "ENVIAR";
            this.btn_envio.Click += new System.EventHandler(this.btn_envio_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(12, 417);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTotalDocumentos
            // 
            // 
            // 
            // 
            this.lblTotalDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTotalDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDocumentos.Location = new System.Drawing.Point(411, 417);
            this.lblTotalDocumentos.Name = "lblTotalDocumentos";
            this.lblTotalDocumentos.Size = new System.Drawing.Size(132, 23);
            this.lblTotalDocumentos.TabIndex = 4;
            this.lblTotalDocumentos.Text = "Total Documentos: ";
            this.lblTotalDocumentos.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // totaldocs
            // 
            // 
            // 
            // 
            this.totaldocs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totaldocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldocs.Location = new System.Drawing.Point(549, 417);
            this.totaldocs.Name = "totaldocs";
            this.totaldocs.Size = new System.Drawing.Size(63, 23);
            this.totaldocs.TabIndex = 5;
            this.totaldocs.Text = ".";
            this.totaldocs.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmEnvioSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1147, 452);
            this.Controls.Add(this.totaldocs);
            this.Controls.Add(this.lblTotalDocumentos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btn_envio);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEnvioSunat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envío de documentos";
            this.Load += new System.EventHandler(this.frmEnvioSunat_Load);
            this.Shown += new System.EventHandler(this.frmEnvioSunat_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_documentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DataGridViewX dg_documentos;
        private ButtonX btn_envio;
        private ButtonX btnSalir;
        private LabelX lblTotalDocumentos;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Repoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correlativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadosunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensajesunat;
        private System.Windows.Forms.DataGridViewImageColumn Pdf;
        private System.Windows.Forms.DataGridViewImageColumn Xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombredoc;
        private LabelX totaldocs;
    }
}