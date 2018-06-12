namespace SIGEFA.Reportes
{
    partial class frmRptNotaCredito
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
            this.crvNotaCredito = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvNotaCredito
            // 
            this.crvNotaCredito.ActiveViewIndex = -1;
            this.crvNotaCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNotaCredito.DisplayGroupTree = false;
            this.crvNotaCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvNotaCredito.Location = new System.Drawing.Point(0, 0);
            this.crvNotaCredito.Name = "crvNotaCredito";
            this.crvNotaCredito.SelectionFormula = "";
            this.crvNotaCredito.Size = new System.Drawing.Size(284, 262);
            this.crvNotaCredito.TabIndex = 0;
            this.crvNotaCredito.ViewTimeSelectionFormula = "";
            // 
            // frmRptNotaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvNotaCredito);
            this.Name = "frmRptNotaCredito";
            this.Text = "frmRptNotaCredito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvNotaCredito;

    }
}