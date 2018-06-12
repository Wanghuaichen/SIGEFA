namespace SIGEFA.Formularios
{
    partial class frmAutorizadoRP
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
            this.cRVAutorizado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVAutorizado
            // 
            this.cRVAutorizado.ActiveViewIndex = -1;
            this.cRVAutorizado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVAutorizado.DisplayGroupTree = false;
            this.cRVAutorizado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVAutorizado.Location = new System.Drawing.Point(0, 0);
            this.cRVAutorizado.Name = "cRVAutorizado";
            this.cRVAutorizado.SelectionFormula = "";
            this.cRVAutorizado.Size = new System.Drawing.Size(769, 334);
            this.cRVAutorizado.TabIndex = 0;
            this.cRVAutorizado.ViewTimeSelectionFormula = "";
            // 
            // frmAutorizadoRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 334);
            this.Controls.Add(this.cRVAutorizado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAutorizadoRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAutorizadoRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAutorizadoRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVAutorizado;
    }
}