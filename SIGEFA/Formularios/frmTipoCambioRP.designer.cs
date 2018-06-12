namespace SIGEFA.Formularios
{
    partial class frmTipoCambioRP
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
            this.cRVTipoCambio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVTipoCambio
            // 
            this.cRVTipoCambio.ActiveViewIndex = -1;
            this.cRVTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVTipoCambio.DisplayGroupTree = false;
            this.cRVTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVTipoCambio.Location = new System.Drawing.Point(0, 0);
            this.cRVTipoCambio.Name = "cRVTipoCambio";
            this.cRVTipoCambio.SelectionFormula = "";
            this.cRVTipoCambio.Size = new System.Drawing.Size(615, 291);
            this.cRVTipoCambio.TabIndex = 0;
            this.cRVTipoCambio.ViewTimeSelectionFormula = "";
            // 
            // frmTipoCambioRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 291);
            this.Controls.Add(this.cRVTipoCambio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTipoCambioRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoCambioRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTipoCambioRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVTipoCambio;
    }
}