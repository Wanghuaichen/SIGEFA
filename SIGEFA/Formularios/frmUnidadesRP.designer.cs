namespace SIGEFA.Formularios
{
    partial class frmUnidadesRP
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
            this.cRVUnidades = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVUnidades
            // 
            this.cRVUnidades.ActiveViewIndex = -1;
            this.cRVUnidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVUnidades.DisplayGroupTree = false;
            this.cRVUnidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVUnidades.Location = new System.Drawing.Point(0, 0);
            this.cRVUnidades.Name = "cRVUnidades";
            this.cRVUnidades.SelectionFormula = "";
            this.cRVUnidades.Size = new System.Drawing.Size(644, 316);
            this.cRVUnidades.TabIndex = 0;
            this.cRVUnidades.ViewTimeSelectionFormula = "";
            // 
            // frmUnidadesRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 316);
            this.Controls.Add(this.cRVUnidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUnidadesRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUnidadesRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUnidadesRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVUnidades;
    }
}