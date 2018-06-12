namespace SIGEFA.Reportes
{
    partial class frmRptRankingArticulo
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
            this.crvRankingArticulo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRankingArticulo
            // 
            this.crvRankingArticulo.ActiveViewIndex = -1;
            this.crvRankingArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRankingArticulo.DisplayGroupTree = false;
            this.crvRankingArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRankingArticulo.Location = new System.Drawing.Point(0, 0);
            this.crvRankingArticulo.Name = "crvRankingArticulo";
            this.crvRankingArticulo.SelectionFormula = "";
            this.crvRankingArticulo.Size = new System.Drawing.Size(284, 262);
            this.crvRankingArticulo.TabIndex = 0;
            this.crvRankingArticulo.ViewTimeSelectionFormula = "";
            // 
            // frmRptRankingArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvRankingArticulo);
            this.Name = "frmRptRankingArticulo";
            this.Text = "frmRptRankingArticulo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRankingArticulo;
    }
}