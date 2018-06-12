namespace SIGEFA.Formularios
{
    partial class frmAlmacenesRP
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
            this.cRVAlmacenes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVAlmacenes
            // 
            this.cRVAlmacenes.ActiveViewIndex = -1;
            this.cRVAlmacenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVAlmacenes.DisplayGroupTree = false;
            this.cRVAlmacenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVAlmacenes.Location = new System.Drawing.Point(0, 0);
            this.cRVAlmacenes.Name = "cRVAlmacenes";
            this.cRVAlmacenes.SelectionFormula = "";
            this.cRVAlmacenes.Size = new System.Drawing.Size(632, 325);
            this.cRVAlmacenes.TabIndex = 0;
            this.cRVAlmacenes.ViewTimeSelectionFormula = "";
            // 
            // frmAlmacenesRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 325);
            this.Controls.Add(this.cRVAlmacenes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAlmacenesRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAlmacenesRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAlmacenesRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVAlmacenes;
    }
}