namespace SIGEFA.Formularios
{
    partial class frmCatalogoRP
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
            this.cRVProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVProductos
            // 
            this.cRVProductos.ActiveViewIndex = -1;
            this.cRVProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVProductos.DisplayGroupTree = false;
            this.cRVProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVProductos.Location = new System.Drawing.Point(0, 0);
            this.cRVProductos.Name = "cRVProductos";
            this.cRVProductos.SelectionFormula = "";
            this.cRVProductos.Size = new System.Drawing.Size(680, 323);
            this.cRVProductos.TabIndex = 0;
            this.cRVProductos.ViewTimeSelectionFormula = "";
            // 
            // frmCatalogoRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 323);
            this.Controls.Add(this.cRVProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCatalogoRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductosRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductosRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVProductos;

    }
}