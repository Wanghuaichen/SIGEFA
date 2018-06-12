namespace SIGEFA.Formularios
{
    partial class frmDetalleStock
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
            this.dgvDetalleStock = new System.Windows.Forms.DataGridView();
            this.almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_act = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalleStock
            // 
            this.dgvDetalleStock.AllowUserToAddRows = false;
            this.dgvDetalleStock.AllowUserToDeleteRows = false;
            this.dgvDetalleStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.almacen,
            this.stock_act});
            this.dgvDetalleStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleStock.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalleStock.Name = "dgvDetalleStock";
            this.dgvDetalleStock.ReadOnly = true;
            this.dgvDetalleStock.RowHeadersVisible = false;
            this.dgvDetalleStock.Size = new System.Drawing.Size(263, 182);
            this.dgvDetalleStock.TabIndex = 0;
            // 
            // almacen
            // 
            this.almacen.DataPropertyName = "almacen";
            this.almacen.HeaderText = "ALMACEN";
            this.almacen.Name = "almacen";
            this.almacen.ReadOnly = true;
            this.almacen.Width = 150;
            // 
            // stock_act
            // 
            this.stock_act.DataPropertyName = "StockActual";
            this.stock_act.HeaderText = "STOCK ACTUAL";
            this.stock_act.Name = "stock_act";
            this.stock_act.ReadOnly = true;
            this.stock_act.Width = 110;
            // 
            // frmDetalleStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 182);
            this.Controls.Add(this.dgvDetalleStock);
            this.Name = "frmDetalleStock";
            this.Text = "StockActualPorAlmacen";
            this.Load += new System.EventHandler(this.frmDetalleStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalleStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_act;
    }
}