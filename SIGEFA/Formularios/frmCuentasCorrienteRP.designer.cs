namespace SIGEFA.Formularios
{
    partial class frmCuentasCorrienteRP
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
            this.CRVCtasCte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVCtasCte
            // 
            this.CRVCtasCte.ActiveViewIndex = -1;
            this.CRVCtasCte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVCtasCte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVCtasCte.Location = new System.Drawing.Point(0, 0);
            this.CRVCtasCte.Name = "CRVCtasCte";
            this.CRVCtasCte.SelectionFormula = "";
            this.CRVCtasCte.Size = new System.Drawing.Size(733, 475);
            this.CRVCtasCte.TabIndex = 0;
            this.CRVCtasCte.ViewTimeSelectionFormula = "";
            // 
            // frmCuentasCorrienteRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 475);
            this.Controls.Add(this.CRVCtasCte);
            this.Name = "frmCuentasCorrienteRP";
            this.Text = "frmCuentasCorrienteRP";
            this.Load += new System.EventHandler(this.frmCuentasCorrienteRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CRVCtasCte;

    }
}