namespace SIGEFA.Formularios
{
    partial class frmMuestraPagosProveedor
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
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.codpago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewLinkColumn();
            this.codfacturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aprobados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.AllowUserToResizeRows = false;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codpago,
            this.fecha,
            this.moneda,
            this.monto,
            this.tipopago,
            this.noperacion,
            this.ncheque,
            this.cobrador,
            this.accion,
            this.codfacturas,
            this.aprobados});
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(0, 0);
            this.dgvPagos.MultiSelect = false;
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(903, 218);
            this.dgvPagos.TabIndex = 0;
            this.dgvPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagos_CellContentClick);
            // 
            // codpago
            // 
            this.codpago.DataPropertyName = "codPago";
            this.codpago.HeaderText = "Codigo";
            this.codpago.Name = "codpago";
            this.codpago.ReadOnly = true;
            this.codpago.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fechapago";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // moneda
            // 
            this.moneda.DataPropertyName = "moneda";
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "montopagado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // tipopago
            // 
            this.tipopago.DataPropertyName = "tipo";
            this.tipopago.HeaderText = "Tipo";
            this.tipopago.Name = "tipopago";
            this.tipopago.ReadOnly = true;
            // 
            // noperacion
            // 
            this.noperacion.DataPropertyName = "noperacion";
            this.noperacion.HeaderText = "N° Operacion";
            this.noperacion.Name = "noperacion";
            this.noperacion.ReadOnly = true;
            // 
            // ncheque
            // 
            this.ncheque.DataPropertyName = "ncheque";
            this.ncheque.HeaderText = "N° Cheque";
            this.ncheque.Name = "ncheque";
            this.ncheque.ReadOnly = true;
            // 
            // cobrador
            // 
            this.cobrador.DataPropertyName = "cobrador";
            this.cobrador.HeaderText = "Cobrador";
            this.cobrador.Name = "cobrador";
            this.cobrador.ReadOnly = true;
            // 
            // accion
            // 
            this.accion.DataPropertyName = "accion";
            this.accion.HeaderText = "Acción";
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            this.accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // codfacturas
            // 
            this.codfacturas.DataPropertyName = "codfacturas";
            this.codfacturas.HeaderText = "codfactura";
            this.codfacturas.Name = "codfacturas";
            this.codfacturas.ReadOnly = true;
            this.codfacturas.Visible = false;
            // 
            // aprobados
            // 
            this.aprobados.DataPropertyName = "aprobado";
            this.aprobados.HeaderText = "aprobado";
            this.aprobados.Name = "aprobados";
            this.aprobados.ReadOnly = true;
            this.aprobados.Visible = false;
            // 
            // frmMuestraPagosProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 218);
            this.Controls.Add(this.dgvPagos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMuestraPagosProveedor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muestra Pagos";
            this.Load += new System.EventHandler(this.frmMuestraPagosProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codpago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopago;
        private System.Windows.Forms.DataGridViewTextBoxColumn noperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobrador;
        private System.Windows.Forms.DataGridViewLinkColumn accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codfacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn aprobados;
    }
}