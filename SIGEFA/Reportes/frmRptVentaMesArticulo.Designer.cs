namespace SIGEFA.Reportes
{
    partial class frmRptVentaMesArticulo
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
            this.crvRptVentaMesArticulo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRptVentaMesArticulo
            // 
            this.crvRptVentaMesArticulo.ActiveViewIndex = -1;
            this.crvRptVentaMesArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRptVentaMesArticulo.DisplayGroupTree = false;
            this.crvRptVentaMesArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRptVentaMesArticulo.Location = new System.Drawing.Point(0, 0);
            this.crvRptVentaMesArticulo.Name = "crvRptVentaMesArticulo";
            this.crvRptVentaMesArticulo.SelectionFormula = "";
            this.crvRptVentaMesArticulo.Size = new System.Drawing.Size(638, 395);
            this.crvRptVentaMesArticulo.TabIndex = 0;
            this.crvRptVentaMesArticulo.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentaMesArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 395);
            this.Controls.Add(this.crvRptVentaMesArticulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptVentaMesArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Venta de Articulo por Mes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRptVentaMesArticulo;

    }
}