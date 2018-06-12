namespace SIGEFA.Formularios
{
    partial class frmUsuariosRP
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
            this.cRVUsuarios = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVUsuarios
            // 
            this.cRVUsuarios.ActiveViewIndex = -1;
            this.cRVUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVUsuarios.DisplayGroupTree = false;
            this.cRVUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVUsuarios.Location = new System.Drawing.Point(0, 0);
            this.cRVUsuarios.Name = "cRVUsuarios";
            this.cRVUsuarios.SelectionFormula = "";
            this.cRVUsuarios.Size = new System.Drawing.Size(794, 352);
            this.cRVUsuarios.TabIndex = 0;
            this.cRVUsuarios.ViewTimeSelectionFormula = "";
            // 
            // frmUsuariosRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 352);
            this.Controls.Add(this.cRVUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUsuariosRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuariosRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUsuariosRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVUsuarios;
    }
}