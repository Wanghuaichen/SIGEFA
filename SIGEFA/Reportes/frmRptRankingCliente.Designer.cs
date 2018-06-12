namespace SIGEFA.Reportes
{
    partial class frmRptRankingCliente
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
            this.crvRankingCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRankingCliente
            // 
            this.crvRankingCliente.ActiveViewIndex = -1;
            this.crvRankingCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRankingCliente.DisplayGroupTree = false;
            this.crvRankingCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRankingCliente.Location = new System.Drawing.Point(0, 0);
            this.crvRankingCliente.Name = "crvRankingCliente";
            this.crvRankingCliente.SelectionFormula = "";
            this.crvRankingCliente.Size = new System.Drawing.Size(284, 262);
            this.crvRankingCliente.TabIndex = 0;
            this.crvRankingCliente.ViewTimeSelectionFormula = "";
            // 
            // frmRptRankingCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvRankingCliente);
            this.Name = "frmRptRankingCliente";
            this.Text = "frmRptRankingCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRankingCliente;

    }
}