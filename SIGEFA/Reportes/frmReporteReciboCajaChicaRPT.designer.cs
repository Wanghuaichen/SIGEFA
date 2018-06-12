namespace SIGEFA.Reportes
{
    partial class frmReporteReciboCajaChicaRPT
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
            this.crvReciboCajaChica = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReciboCajaChica
            // 
            this.crvReciboCajaChica.ActiveViewIndex = -1;
            this.crvReciboCajaChica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReciboCajaChica.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReciboCajaChica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReciboCajaChica.Location = new System.Drawing.Point(0, 0);
            this.crvReciboCajaChica.Name = "crvReciboCajaChica";
            this.crvReciboCajaChica.Size = new System.Drawing.Size(350, 273);
            this.crvReciboCajaChica.TabIndex = 0;
            this.crvReciboCajaChica.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReporteReciboCajaChicaRPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 273);
            this.Controls.Add(this.crvReciboCajaChica);
            this.Name = "frmReporteReciboCajaChicaRPT";
            this.Text = "Recibos Caja Chica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReporteReciboCajaChicaRPT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvReciboCajaChica;
    }
}