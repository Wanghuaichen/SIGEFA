namespace SIGEFA.Reportes
{
    partial class frmRptVentasxCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptVentasxCliente));
            this.crvReporteVentasCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReporteVentasCliente
            // 
            this.crvReporteVentasCliente.ActiveViewIndex = -1;
            this.crvReporteVentasCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.crvReporteVentasCliente.CachedPageNumberPerDoc = 10;
            this.crvReporteVentasCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReporteVentasCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteVentasCliente.Location = new System.Drawing.Point(0, 0);
            this.crvReporteVentasCliente.Name = "crvReporteVentasCliente";
            this.crvReporteVentasCliente.Size = new System.Drawing.Size(744, 449);
            this.crvReporteVentasCliente.TabIndex = 0;
            // 
            // frmRptVentasxCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 449);
            this.Controls.Add(this.crvReporteVentasCliente);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptVentasxCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reprote de Ventas por Cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteVentasCliente;

    }
}