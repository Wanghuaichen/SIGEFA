namespace SIGEFA.Reportes
{
    partial class FrmRptTransferencia
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
            this.crvreportetrasferencia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvreportetrasferencia
            // 
            this.crvreportetrasferencia.ActiveViewIndex = -1;
            this.crvreportetrasferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvreportetrasferencia.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvreportetrasferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvreportetrasferencia.Location = new System.Drawing.Point(0, 0);
            this.crvreportetrasferencia.Name = "crvreportetrasferencia";
            this.crvreportetrasferencia.Size = new System.Drawing.Size(1087, 568);
            this.crvreportetrasferencia.TabIndex = 0;
            this.crvreportetrasferencia.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmRptTransferencia
            // 
            this.ClientSize = new System.Drawing.Size(1087, 568);
            this.Controls.Add(this.crvreportetrasferencia);
            this.DoubleBuffered = true;
            this.Name = "FrmRptTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmRptTransferencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvreportetrasferencia;

    }
}