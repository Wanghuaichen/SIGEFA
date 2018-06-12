namespace SIGEFA.Formularios
{
    partial class frmProveedoresRP
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
            this.cRVProveedores = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVProveedores
            // 
            this.cRVProveedores.ActiveViewIndex = -1;
            this.cRVProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVProveedores.DisplayGroupTree = false;
            this.cRVProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVProveedores.Location = new System.Drawing.Point(0, 0);
            this.cRVProveedores.Name = "cRVProveedores";
            this.cRVProveedores.SelectionFormula = "";
            this.cRVProveedores.Size = new System.Drawing.Size(637, 322);
            this.cRVProveedores.TabIndex = 0;
            this.cRVProveedores.ViewTimeSelectionFormula = "";
            // 
            // frmProveedoresRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 322);
            this.Controls.Add(this.cRVProveedores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProveedoresRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProveedoresRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProveedoresRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVProveedores;
    }
}