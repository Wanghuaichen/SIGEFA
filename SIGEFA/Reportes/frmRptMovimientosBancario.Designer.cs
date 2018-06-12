namespace SIGEFA.Reportes
{
    partial class frmRptMovimientosBancario
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
            this.cRVMovimientosBancarios = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVMovimientosBancarios
            // 
            this.cRVMovimientosBancarios.ActiveViewIndex = -1;
            this.cRVMovimientosBancarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVMovimientosBancarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVMovimientosBancarios.Location = new System.Drawing.Point(0, 0);
            this.cRVMovimientosBancarios.Name = "cRVMovimientosBancarios";
            this.cRVMovimientosBancarios.SelectionFormula = "";
            this.cRVMovimientosBancarios.Size = new System.Drawing.Size(690, 392);
            this.cRVMovimientosBancarios.TabIndex = 1;
            this.cRVMovimientosBancarios.ViewTimeSelectionFormula = "";
            // 
            // frmRptMovimientosBancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 392);
            this.Controls.Add(this.cRVMovimientosBancarios);
            this.Name = "frmRptMovimientosBancario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVMovimientosBancarios;
    }
}