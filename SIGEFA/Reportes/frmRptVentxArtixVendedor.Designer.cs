namespace SIGEFA.Reportes
{
    partial class frmRptVentxArtixVendedor
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
            this.crvRptVentxCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRptVentxCliente
            // 
            this.crvRptVentxCliente.ActiveViewIndex = -1;
            this.crvRptVentxCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRptVentxCliente.DisplayGroupTree = false;
            this.crvRptVentxCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRptVentxCliente.Location = new System.Drawing.Point(0, 0);
            this.crvRptVentxCliente.Name = "crvRptVentxCliente";
            this.crvRptVentxCliente.SelectionFormula = "";
            this.crvRptVentxCliente.Size = new System.Drawing.Size(674, 427);
            this.crvRptVentxCliente.TabIndex = 0;
            this.crvRptVentxCliente.ViewTimeSelectionFormula = "";
            // 
            // frmRptVentxArtixVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 427);
            this.Controls.Add(this.crvRptVentxCliente);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptVentxArtixVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Ventas por Articulo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptVentxCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvRptVentxCliente;

    }
}