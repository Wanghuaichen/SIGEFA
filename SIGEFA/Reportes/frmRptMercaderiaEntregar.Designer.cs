namespace SIGEFA.Reportes
{
    partial class frmRptMercaderiaEntregar
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
            this.cRMercaderiaEntregar = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRMercaderiaEntregar
            // 
            this.cRMercaderiaEntregar.ActiveViewIndex = -1;
            this.cRMercaderiaEntregar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRMercaderiaEntregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRMercaderiaEntregar.Location = new System.Drawing.Point(0, 0);
            this.cRMercaderiaEntregar.Name = "cRMercaderiaEntregar";
            this.cRMercaderiaEntregar.SelectionFormula = "";
            this.cRMercaderiaEntregar.Size = new System.Drawing.Size(404, 300);
            this.cRMercaderiaEntregar.TabIndex = 0;
            this.cRMercaderiaEntregar.ViewTimeSelectionFormula = "";
            // 
            // frmRptMercaderiaEntregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 300);
            this.Controls.Add(this.cRMercaderiaEntregar);
            this.Name = "frmRptMercaderiaEntregar";
            this.Text = "RptMercaderiaPorEntregar";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRMercaderiaEntregar;
    }
}