namespace SIGEFA.Reportes
{
    partial class frmRptUtilidad
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
            this.crvInventario = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvInventario
            // 
            this.crvInventario.ActiveViewIndex = -1;
            this.crvInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInventario.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInventario.Location = new System.Drawing.Point(0, 0);
            this.crvInventario.Name = "crvInventario";
            this.crvInventario.SelectionFormula = "";
            this.crvInventario.Size = new System.Drawing.Size(1007, 522);
            this.crvInventario.TabIndex = 0;
            this.crvInventario.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvInventario.ViewTimeSelectionFormula = "";
            // 
            // frmRptUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 522);
            this.Controls.Add(this.crvInventario);
            this.Name = "frmRptUtilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRptInventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptKardex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvInventario;

    }
}