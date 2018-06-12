namespace SIGEFA.Reportes
{
    partial class frmReporteFlujoCaja
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
            this.cRVFlujoCaja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVFlujoCaja
            // 
            this.cRVFlujoCaja.ActiveViewIndex = -1;
            this.cRVFlujoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVFlujoCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVFlujoCaja.Location = new System.Drawing.Point(0, 0);
            this.cRVFlujoCaja.Name = "cRVFlujoCaja";
            this.cRVFlujoCaja.SelectionFormula = "";
            this.cRVFlujoCaja.Size = new System.Drawing.Size(451, 403);
            this.cRVFlujoCaja.TabIndex = 0;
            this.cRVFlujoCaja.ViewTimeSelectionFormula = "";
            // 
            // frmReporteFlujoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 403);
            this.Controls.Add(this.cRVFlujoCaja);
            this.Name = "frmReporteFlujoCaja";
            this.Text = "frmReporteFlujoCaja";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVFlujoCaja;

    }
}