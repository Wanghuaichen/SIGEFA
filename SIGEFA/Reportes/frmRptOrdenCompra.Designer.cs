namespace SIGEFA.Reportes
{
    partial class frmRptOrdenCompra
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
            this.crvOrdenCompra = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvOrdenCompra
            // 
            this.crvOrdenCompra.ActiveViewIndex = -1;
            this.crvOrdenCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvOrdenCompra.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvOrdenCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvOrdenCompra.Location = new System.Drawing.Point(0, 0);
            this.crvOrdenCompra.Name = "crvOrdenCompra";
            this.crvOrdenCompra.SelectionFormula = "";
            this.crvOrdenCompra.Size = new System.Drawing.Size(284, 262);
            this.crvOrdenCompra.TabIndex = 0;
            this.crvOrdenCompra.ViewTimeSelectionFormula = "";
            // 
            // frmRptOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvOrdenCompra);
            this.Name = "frmRptOrdenCompra";
            this.Text = "Reporte - Orden Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvOrdenCompra;

    }
}