namespace SIGEFA.Reportes
{
    partial class frmRptImpresionPago
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
            this.cRVImpresionPago = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVImpresionPago
            // 
            this.cRVImpresionPago.ActiveViewIndex = -1;
            this.cRVImpresionPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVImpresionPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVImpresionPago.Location = new System.Drawing.Point(0, 0);
            this.cRVImpresionPago.Name = "cRVImpresionPago";
            this.cRVImpresionPago.SelectionFormula = "";
            this.cRVImpresionPago.Size = new System.Drawing.Size(380, 386);
            this.cRVImpresionPago.TabIndex = 0;
            this.cRVImpresionPago.ViewTimeSelectionFormula = "";
            // 
            // frmRptImpresionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 386);
            this.Controls.Add(this.cRVImpresionPago);
            this.Name = "frmRptImpresionPago";
            this.Text = "frmRptImpresionPago";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVImpresionPago;

    }
}