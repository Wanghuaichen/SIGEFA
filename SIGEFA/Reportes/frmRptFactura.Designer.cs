namespace SIGEFA.Reportes
{
    partial class frmRptFactura
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
            this.crvReporteFactura = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReporteFactura
            // 
            this.crvReporteFactura.ActiveViewIndex = -1;
            this.crvReporteFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteFactura.DisplayGroupTree = false;
            this.crvReporteFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteFactura.Location = new System.Drawing.Point(0, 0);
            this.crvReporteFactura.Name = "crvReporteFactura";
            this.crvReporteFactura.SelectionFormula = "";
            this.crvReporteFactura.Size = new System.Drawing.Size(284, 262);
            this.crvReporteFactura.TabIndex = 0;
            this.crvReporteFactura.ViewTimeSelectionFormula = "";
            // 
            // frmRptFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvReporteFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRptFactura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteFactura;

    }
}