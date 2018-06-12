namespace SIGEFA.Reportes
{
    partial class frmRptLiquidacionCaja
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
            this.cRVLiquidacionCaja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVLiquidacionCaja
            // 
            this.cRVLiquidacionCaja.ActiveViewIndex = -1;
            this.cRVLiquidacionCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVLiquidacionCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVLiquidacionCaja.Location = new System.Drawing.Point(0, 0);
            this.cRVLiquidacionCaja.Name = "cRVLiquidacionCaja";
            this.cRVLiquidacionCaja.SelectionFormula = "";
            this.cRVLiquidacionCaja.Size = new System.Drawing.Size(386, 385);
            this.cRVLiquidacionCaja.TabIndex = 0;
            this.cRVLiquidacionCaja.ViewTimeSelectionFormula = "";
            // 
            // frmRptLiquidacionCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 385);
            this.Controls.Add(this.cRVLiquidacionCaja);
            this.Name = "frmRptLiquidacionCaja";
            this.Text = "frmRptLiquidacionCaja";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVLiquidacionCaja;
    }
}