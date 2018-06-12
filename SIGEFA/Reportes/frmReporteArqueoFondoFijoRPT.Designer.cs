namespace SIGEFA.Reportes
{
    partial class frmReporteArqueoFondoFijoRPT
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
            this.crvArqueoFondoFijo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvArqueoFondoFijo
            // 
            this.crvArqueoFondoFijo.ActiveViewIndex = -1;
            this.crvArqueoFondoFijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvArqueoFondoFijo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvArqueoFondoFijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvArqueoFondoFijo.Location = new System.Drawing.Point(0, 0);
            this.crvArqueoFondoFijo.Name = "crvArqueoFondoFijo";
            this.crvArqueoFondoFijo.Size = new System.Drawing.Size(292, 273);
            this.crvArqueoFondoFijo.TabIndex = 0;
            this.crvArqueoFondoFijo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReporteArqueoFondoFijoRPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.crvArqueoFondoFijo);
            this.Name = "frmReporteArqueoFondoFijoRPT";
            this.Text = "Reporte Arqueo Fondo Fijo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvArqueoFondoFijo;

    }
}