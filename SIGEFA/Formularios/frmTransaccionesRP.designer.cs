namespace SIGEFA.Formularios
{
    partial class frmTransaccionesRP
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
            this.cRVTransacciones = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVTransacciones
            // 
            this.cRVTransacciones.ActiveViewIndex = -1;
            this.cRVTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVTransacciones.DisplayGroupTree = false;
            this.cRVTransacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVTransacciones.Location = new System.Drawing.Point(0, 0);
            this.cRVTransacciones.Name = "cRVTransacciones";
            this.cRVTransacciones.SelectionFormula = "";
            this.cRVTransacciones.Size = new System.Drawing.Size(651, 336);
            this.cRVTransacciones.TabIndex = 0;
            this.cRVTransacciones.ViewTimeSelectionFormula = "";
            // 
            // frmTransaccionesRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 336);
            this.Controls.Add(this.cRVTransacciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTransaccionesRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransaccionesRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTransaccionesRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVTransacciones;
    }
}