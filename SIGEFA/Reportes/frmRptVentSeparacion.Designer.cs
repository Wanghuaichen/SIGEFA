namespace SIGEFA.Reportes
{
    partial class frmRptVentSeparacion
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
            this.crvRptVentSeparacion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRptVentSeparacion
            // 
            this.crvRptVentSeparacion.ActiveViewIndex = -1;
            this.crvRptVentSeparacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRptVentSeparacion.CachedPageNumberPerDoc = 10;
            this.crvRptVentSeparacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRptVentSeparacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRptVentSeparacion.Location = new System.Drawing.Point(0, 0);
            this.crvRptVentSeparacion.Name = "crvRptVentSeparacion";
            this.crvRptVentSeparacion.SelectionFormula = "";
            this.crvRptVentSeparacion.Size = new System.Drawing.Size(683, 371);
            this.crvRptVentSeparacion.TabIndex = 0;
            this.crvRptVentSeparacion.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentSeparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 371);
            this.Controls.Add(this.crvRptVentSeparacion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptVentSeparacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Ventas por Separación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptVentCredContDia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRptVentSeparacion;

    }
}