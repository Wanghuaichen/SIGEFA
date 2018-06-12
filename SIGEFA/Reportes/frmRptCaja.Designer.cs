namespace SIGEFA.Reportes
{
    partial class frmRptCaja
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
            this.crvKardex = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvKardex
            // 
            this.crvKardex.ActiveViewIndex = -1;
            this.crvKardex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvKardex.DisplayGroupTree = false;
            this.crvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvKardex.Location = new System.Drawing.Point(0, 0);
            this.crvKardex.Name = "crvKardex";
            this.crvKardex.SelectionFormula = "";
            this.crvKardex.Size = new System.Drawing.Size(284, 262);
            this.crvKardex.TabIndex = 2;
            this.crvKardex.ViewTimeSelectionFormula = "";
            // 
            // frmRptCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvKardex);
            this.Name = "frmRptCaja";
            this.Text = "frmRptCaja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvKardex;
    }
}