namespace SIGEFA.Reportes
{
    partial class frmReporteMovimientosCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMovimientosCajaChica));
            this.crvMovimientosdecajachica = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvMovimientosdecajachica
            // 
            this.crvMovimientosdecajachica.ActiveViewIndex = -1;
            this.crvMovimientosdecajachica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMovimientosdecajachica.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvMovimientosdecajachica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMovimientosdecajachica.Location = new System.Drawing.Point(0, 0);
            this.crvMovimientosdecajachica.Name = "crvMovimientosdecajachica";
            this.crvMovimientosdecajachica.Size = new System.Drawing.Size(401, 327);
            this.crvMovimientosdecajachica.TabIndex = 0;
            this.crvMovimientosdecajachica.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReporteMovimientosCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 327);
            this.Controls.Add(this.crvMovimientosdecajachica);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteMovimientosCajaChica";
            this.Text = "Reporte de Movimientos de Caja Chica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReporteMovimientosCajaChica_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvMovimientosdecajachica;

    }
}