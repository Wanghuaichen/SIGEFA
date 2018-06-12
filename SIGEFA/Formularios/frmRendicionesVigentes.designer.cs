namespace SIGEFA.Formularios
{
    partial class frmRendicionesVigentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRendicionesVigentes));
            this.dgvLiquidaciones = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoLiquidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRendicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaLiquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.biIngresarCaja = new DevComponents.DotNetBar.ButtonItem();
            this.biRencicionCaja = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.s = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiquidaciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLiquidaciones
            // 
            this.dgvLiquidaciones.AllowUserToAddRows = false;
            this.dgvLiquidaciones.AllowUserToDeleteRows = false;
            this.dgvLiquidaciones.AllowUserToResizeColumns = false;
            this.dgvLiquidaciones.AllowUserToResizeRows = false;
            this.dgvLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLiquidaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numDocumento,
            this.montoLiquidado,
            this.fechaRendicion,
            this.fechaLiquidacion,
            this.estatus,
            this.responsable});
            this.dgvLiquidaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiquidaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLiquidaciones.Location = new System.Drawing.Point(0, 0);
            this.dgvLiquidaciones.MultiSelect = false;
            this.dgvLiquidaciones.Name = "dgvLiquidaciones";
            this.dgvLiquidaciones.RowHeadersVisible = false;
            this.dgvLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLiquidaciones.Size = new System.Drawing.Size(766, 131);
            this.dgvLiquidaciones.TabIndex = 0;
            this.dgvLiquidaciones.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvLiquidaciones_RowStateChanged);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codRendicion";
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.Visible = false;
            // 
            // numDocumento
            // 
            this.numDocumento.DataPropertyName = "numCheque";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numDocumento.DefaultCellStyle = dataGridViewCellStyle1;
            this.numDocumento.HeaderText = "numDocumento";
            this.numDocumento.Name = "numDocumento";
            // 
            // montoLiquidado
            // 
            this.montoLiquidado.DataPropertyName = "montoLiquidado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.montoLiquidado.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoLiquidado.HeaderText = "montoLiquidado";
            this.montoLiquidado.Name = "montoLiquidado";
            // 
            // fechaRendicion
            // 
            this.fechaRendicion.DataPropertyName = "fechaRendicion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaRendicion.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaRendicion.HeaderText = "fechaRendicion";
            this.fechaRendicion.Name = "fechaRendicion";
            this.fechaRendicion.Width = 130;
            // 
            // fechaLiquidacion
            // 
            this.fechaLiquidacion.DataPropertyName = "fechaliquidacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaLiquidacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaLiquidacion.HeaderText = "fechaLiquidacion";
            this.fechaLiquidacion.Name = "fechaLiquidacion";
            this.fechaLiquidacion.Width = 130;
            // 
            // estatus
            // 
            this.estatus.DataPropertyName = "estatus";
            this.estatus.HeaderText = "estatus";
            this.estatus.Name = "estatus";
            this.estatus.Visible = false;
            // 
            // responsable
            // 
            this.responsable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.responsable.DataPropertyName = "responsable";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.responsable.DefaultCellStyle = dataGridViewCellStyle5;
            this.responsable.HeaderText = "responsable";
            this.responsable.Name = "responsable";
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            this.ribbonBar2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.Class = "";
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biIngresarCaja,
            this.biRencicionCaja});
            this.ribbonBar2.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(701, 70);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar2.TabIndex = 15;
            this.ribbonBar2.Text = "ribbonBar2";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.Class = "";
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.Class = "";
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.TitleVisible = false;
            // 
            // biIngresarCaja
            // 
            this.biIngresarCaja.Enabled = false;
            this.biIngresarCaja.Image = ((System.Drawing.Image)(resources.GetObject("biIngresarCaja.Image")));
            this.biIngresarCaja.ImagePaddingHorizontal = 20;
            this.biIngresarCaja.ImagePaddingVertical = 10;
            this.biIngresarCaja.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biIngresarCaja.Name = "biIngresarCaja";
            this.biIngresarCaja.SubItemsExpandWidth = 14;
            this.biIngresarCaja.Text = "Ingresar a Caja";
            this.biIngresarCaja.Click += new System.EventHandler(this.biIngresarCaja_Click);
            // 
            // biRencicionCaja
            // 
            this.biRencicionCaja.Enabled = false;
            this.biRencicionCaja.Image = ((System.Drawing.Image)(resources.GetObject("biRencicionCaja.Image")));
            this.biRencicionCaja.ImagePaddingHorizontal = 10;
            this.biRencicionCaja.ImagePaddingVertical = 10;
            this.biRencicionCaja.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biRencicionCaja.Name = "biRencicionCaja";
            this.biRencicionCaja.SubItemsExpandWidth = 14;
            this.biRencicionCaja.Text = "Rendir   Caja Chica";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ribbonBar2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 70);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ribbonBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(701, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 70);
            this.panel2.TabIndex = 0;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.Class = "";
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.s});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbonBar1.Size = new System.Drawing.Size(65, 70);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.ribbonBar1.TabIndex = 16;
            this.ribbonBar1.Text = "ribbonBar1";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.Class = "";
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.Class = "";
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            // 
            // s
            // 
            this.s.Image = ((System.Drawing.Image)(resources.GetObject("s.Image")));
            this.s.ImagePaddingHorizontal = 20;
            this.s.ImagePaddingVertical = 10;
            this.s.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.s.Name = "s";
            this.s.SubItemsExpandWidth = 14;
            this.s.Text = "Salir";
            this.s.Click += new System.EventHandler(this.s_Click);
            // 
            // frmRendicionesVigentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 201);
            this.Controls.Add(this.dgvLiquidaciones);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(782, 240);
            this.Name = "frmRendicionesVigentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendiciones Vigentes";
            this.Load += new System.EventHandler(this.frmRendicionesVigentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiquidaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLiquidaciones;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem biIngresarCaja;
        private DevComponents.DotNetBar.ButtonItem biRencicionCaja;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem s;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoLiquidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRendicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsable;
    }
}