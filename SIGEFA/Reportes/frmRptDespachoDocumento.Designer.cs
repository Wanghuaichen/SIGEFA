namespace SIGEFA.Reportes
{
    partial class frmRptDespachoDocumento
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
            this.crvDespachoDocumento = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvDespachoDocumento
            // 
            this.crvDespachoDocumento.ActiveViewIndex = -1;
            this.crvDespachoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDespachoDocumento.DisplayGroupTree = false;
            this.crvDespachoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDespachoDocumento.Location = new System.Drawing.Point(0, 0);
            this.crvDespachoDocumento.Name = "crvDespachoDocumento";
            this.crvDespachoDocumento.SelectionFormula = "";
            this.crvDespachoDocumento.Size = new System.Drawing.Size(284, 262);
            this.crvDespachoDocumento.TabIndex = 0;
            this.crvDespachoDocumento.ViewTimeSelectionFormula = "";
            // 
            // frmRptDespachoDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvDespachoDocumento);
            this.Name = "frmRptDespachoDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Despachos por Documento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvDespachoDocumento;

    }
}