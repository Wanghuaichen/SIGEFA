namespace SIGEFA.Reportes
{
    partial class frmRptGuia
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
            this.crvGuia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvGuia
            // 
            this.crvGuia.ActiveViewIndex = -1;
            this.crvGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvGuia.DisplayGroupTree = false;
            this.crvGuia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvGuia.Location = new System.Drawing.Point(0, 0);
            this.crvGuia.Name = "crvGuia";
            this.crvGuia.SelectionFormula = "";
            this.crvGuia.Size = new System.Drawing.Size(284, 262);
            this.crvGuia.TabIndex = 0;
            this.crvGuia.ViewTimeSelectionFormula = "";
            // 
            // frmRptGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvGuia);
            this.Name = "frmRptGuia";
            this.Text = "frmRptGuia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvGuia;

    }
}