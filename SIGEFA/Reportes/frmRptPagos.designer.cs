namespace SIGEFA.Formularios
{
    partial class frmRptPagos
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
            this.crvReportePagos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRReportePagos1 = new SIGEFA.Reportes.CRReportePagos();
            this.SuspendLayout();
            // 
            // crvReportePagos
            // 
            this.crvReportePagos.ActiveViewIndex = -1;
            this.crvReportePagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportePagos.DisplayGroupTree = false;
            this.crvReportePagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportePagos.Location = new System.Drawing.Point(0, 0);
            this.crvReportePagos.Name = "crvReportePagos";
            this.crvReportePagos.SelectionFormula = "";
            this.crvReportePagos.Size = new System.Drawing.Size(629, 438);
            this.crvReportePagos.TabIndex = 0;
            this.crvReportePagos.ViewTimeSelectionFormula = "";
            // 
            // frmRptPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 438);
            this.Controls.Add(this.crvReportePagos);
            this.Name = "frmRptPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRptPagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportePagos;
        private SIGEFA.Reportes.CRReportePagos CRReportePagos1;



    }
}