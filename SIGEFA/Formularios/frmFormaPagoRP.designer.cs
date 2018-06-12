namespace SIGEFA.Formularios
{
    partial class frmFormaPagoRP
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
            this.cRVFormaPago = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVFormaPago
            // 
            this.cRVFormaPago.ActiveViewIndex = -1;
            this.cRVFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVFormaPago.DisplayGroupTree = false;
            this.cRVFormaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVFormaPago.Location = new System.Drawing.Point(0, 0);
            this.cRVFormaPago.Name = "cRVFormaPago";
            this.cRVFormaPago.SelectionFormula = "";
            this.cRVFormaPago.Size = new System.Drawing.Size(607, 319);
            this.cRVFormaPago.TabIndex = 0;
            this.cRVFormaPago.ViewTimeSelectionFormula = "";
            // 
            // frmFormaPagoRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 319);
            this.Controls.Add(this.cRVFormaPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmFormaPagoRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFormaPagoRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFormaPagoRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVFormaPago;
    }
}