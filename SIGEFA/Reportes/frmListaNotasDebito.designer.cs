namespace SIGEFA.Reportes.clsReportes
{
    partial class frmListaNotasDebito
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
            this.crvNotasDebito = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvNotasDebito
            // 
            this.crvNotasDebito.ActiveViewIndex = -1;
            this.crvNotasDebito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNotasDebito.DisplayGroupTree = false;
            this.crvNotasDebito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvNotasDebito.Location = new System.Drawing.Point(0, 0);
            this.crvNotasDebito.Name = "crvNotasDebito";
            this.crvNotasDebito.SelectionFormula = "";
            this.crvNotasDebito.Size = new System.Drawing.Size(284, 262);
            this.crvNotasDebito.TabIndex = 1;
            this.crvNotasDebito.ViewTimeSelectionFormula = "";
            // 
            // frmListaNotasDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvNotasDebito);
            this.Name = "frmListaNotasDebito";
            this.Text = "Notas Débito Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvNotasDebito;
    }
}