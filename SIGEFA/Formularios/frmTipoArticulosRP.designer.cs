namespace SIGEFA.Formularios
{
    partial class frmTipoArticulosRP
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
            this.cRVTipoArticulos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVTipoArticulos
            // 
            this.cRVTipoArticulos.ActiveViewIndex = -1;
            this.cRVTipoArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVTipoArticulos.DisplayGroupTree = false;
            this.cRVTipoArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVTipoArticulos.Location = new System.Drawing.Point(0, 0);
            this.cRVTipoArticulos.Name = "cRVTipoArticulos";
            this.cRVTipoArticulos.SelectionFormula = "";
            this.cRVTipoArticulos.Size = new System.Drawing.Size(600, 306);
            this.cRVTipoArticulos.TabIndex = 0;
            this.cRVTipoArticulos.ViewTimeSelectionFormula = "";
            // 
            // frmTipoArticulosRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 306);
            this.Controls.Add(this.cRVTipoArticulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTipoArticulosRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoArticulosRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTipoArticulosRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVTipoArticulos;
    }
}