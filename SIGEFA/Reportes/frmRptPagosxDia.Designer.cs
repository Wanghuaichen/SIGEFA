namespace SIGEFA.Reportes
{
    partial class frmRptPagosxDia
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
            this.crvPagosDia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPagosDia
            // 
            this.crvPagosDia.ActiveViewIndex = -1;
            this.crvPagosDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPagosDia.DisplayGroupTree = false;
            this.crvPagosDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPagosDia.Location = new System.Drawing.Point(0, 0);
            this.crvPagosDia.Name = "crvPagosDia";
            this.crvPagosDia.SelectionFormula = "";
            this.crvPagosDia.Size = new System.Drawing.Size(284, 262);
            this.crvPagosDia.TabIndex = 0;
            this.crvPagosDia.ViewTimeSelectionFormula = "";
            // 
            // frmRptPagosxDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvPagosDia);
            this.Name = "frmRptPagosxDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Pagos por Dia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvPagosDia;

    }
}