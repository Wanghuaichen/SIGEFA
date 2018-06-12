namespace SIGEFA.Formularios
{
    partial class frmCaracteristicasRP
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
            this.cRVCaracteristicas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVCaracteristicas
            // 
            this.cRVCaracteristicas.ActiveViewIndex = -1;
            this.cRVCaracteristicas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVCaracteristicas.DisplayGroupTree = false;
            this.cRVCaracteristicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVCaracteristicas.Location = new System.Drawing.Point(0, 0);
            this.cRVCaracteristicas.Name = "cRVCaracteristicas";
            this.cRVCaracteristicas.SelectionFormula = "";
            this.cRVCaracteristicas.Size = new System.Drawing.Size(667, 307);
            this.cRVCaracteristicas.TabIndex = 0;
            this.cRVCaracteristicas.ViewTimeSelectionFormula = "";
            // 
            // frmCaracteristicasRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 307);
            this.Controls.Add(this.cRVCaracteristicas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCaracteristicasRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCaracteristicasRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCaracteristicasRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVCaracteristicas;
    }
}