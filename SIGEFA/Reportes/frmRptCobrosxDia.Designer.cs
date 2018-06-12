namespace SIGEFA.Reportes
{
    partial class frmRptCobrosxDia
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
            this.crvCobros = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCobros
            // 
            this.crvCobros.ActiveViewIndex = -1;
            this.crvCobros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCobros.DisplayGroupTree = false;
            this.crvCobros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCobros.Location = new System.Drawing.Point(0, 0);
            this.crvCobros.Name = "crvCobros";
            this.crvCobros.SelectionFormula = "";
            this.crvCobros.Size = new System.Drawing.Size(284, 262);
            this.crvCobros.TabIndex = 0;
            this.crvCobros.ViewTimeSelectionFormula = "";
            // 
            // frmRptCobrosxDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvCobros);
            this.Name = "frmRptCobrosxDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Cobros por Dia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCobros;

    }
}