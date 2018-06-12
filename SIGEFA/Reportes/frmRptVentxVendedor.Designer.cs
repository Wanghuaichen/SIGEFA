namespace SIGEFA.Reportes
{
    partial class frmRptVentxVendedor
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
            this.crvRptVentxVendedor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRptVentxVendedor
            // 
            this.crvRptVentxVendedor.ActiveViewIndex = -1;
            this.crvRptVentxVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRptVentxVendedor.DisplayGroupTree = false;
            this.crvRptVentxVendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRptVentxVendedor.Location = new System.Drawing.Point(0, 0);
            this.crvRptVentxVendedor.Name = "crvRptVentxVendedor";
            this.crvRptVentxVendedor.SelectionFormula = "";
            this.crvRptVentxVendedor.Size = new System.Drawing.Size(284, 262);
            this.crvRptVentxVendedor.TabIndex = 0;
            this.crvRptVentxVendedor.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentxVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvRptVentxVendedor);
            this.Name = "frmRptVentxVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Ventas por Vendedor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRptVentxVendedor;

    }
}