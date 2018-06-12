namespace SIGEFA.Reportes
{
    partial class frmRptVentCredContDia
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
            this.crvRptVentCredContDia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRptVentCredContDia
            // 
            this.crvRptVentCredContDia.ActiveViewIndex = -1;
            this.crvRptVentCredContDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRptVentCredContDia.DisplayGroupTree = false;
            this.crvRptVentCredContDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRptVentCredContDia.Location = new System.Drawing.Point(0, 0);
            this.crvRptVentCredContDia.Name = "crvRptVentCredContDia";
            this.crvRptVentCredContDia.SelectionFormula = "";
            this.crvRptVentCredContDia.Size = new System.Drawing.Size(683, 371);
            this.crvRptVentCredContDia.TabIndex = 0;
            this.crvRptVentCredContDia.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentCredContDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 371);
            this.Controls.Add(this.crvRptVentCredContDia);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptVentCredContDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Ventas al Credito/Contado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRptVentCredContDia;

    }
}