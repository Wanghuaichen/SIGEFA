namespace SIGEFA.Formularios
{
    partial class frmFamiliasRP
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
            this.cRVFamilias = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVFamilias
            // 
            this.cRVFamilias.ActiveViewIndex = -1;
            this.cRVFamilias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVFamilias.DisplayGroupTree = false;
            this.cRVFamilias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVFamilias.Location = new System.Drawing.Point(0, 0);
            this.cRVFamilias.Name = "cRVFamilias";
            this.cRVFamilias.SelectionFormula = "";
            this.cRVFamilias.Size = new System.Drawing.Size(652, 322);
            this.cRVFamilias.TabIndex = 0;
            this.cRVFamilias.ViewTimeSelectionFormula = "";
            // 
            // frmFamiliasRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 322);
            this.Controls.Add(this.cRVFamilias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmFamiliasRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFamiliasRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFamiliasRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVFamilias;
    }
}