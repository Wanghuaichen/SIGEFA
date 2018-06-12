namespace SIGEFA.Formularios
{
    partial class frmEmpresasRP
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
            this.cRVEmpresas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVEmpresas
            // 
            this.cRVEmpresas.ActiveViewIndex = -1;
            this.cRVEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVEmpresas.DisplayGroupTree = false;
            this.cRVEmpresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVEmpresas.Location = new System.Drawing.Point(0, 0);
            this.cRVEmpresas.Name = "cRVEmpresas";
            this.cRVEmpresas.SelectionFormula = "";
            this.cRVEmpresas.Size = new System.Drawing.Size(625, 341);
            this.cRVEmpresas.TabIndex = 0;
            this.cRVEmpresas.ViewTimeSelectionFormula = "";
            // 
            // frmEmpresasRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 341);
            this.Controls.Add(this.cRVEmpresas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmpresasRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmpresasRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmpresasRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVEmpresas;
    }
}