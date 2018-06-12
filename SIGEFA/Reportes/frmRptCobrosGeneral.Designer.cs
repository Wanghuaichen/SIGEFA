namespace SIGEFA.Reportes
{
    partial class frmRptCobrosGeneral
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
            this.crvCobrosGeneral = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCobrosGeneral
            // 
            this.crvCobrosGeneral.ActiveViewIndex = -1;
            this.crvCobrosGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCobrosGeneral.DisplayGroupTree = false;
            this.crvCobrosGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCobrosGeneral.Location = new System.Drawing.Point(0, 0);
            this.crvCobrosGeneral.Name = "crvCobrosGeneral";
            this.crvCobrosGeneral.SelectionFormula = "";
            this.crvCobrosGeneral.Size = new System.Drawing.Size(284, 262);
            this.crvCobrosGeneral.TabIndex = 0;
            this.crvCobrosGeneral.ViewTimeSelectionFormula = "";
            // 
            // frmRptCobrosGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvCobrosGeneral);
            this.Name = "frmRptCobrosGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRptCobrosGeneral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCobrosGeneral;

    }
}