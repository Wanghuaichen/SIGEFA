namespace SIGEFA.Formularios
{
    partial class frmBancosRP
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
            this.cRVMarcas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVMarcas
            // 
            this.cRVMarcas.ActiveViewIndex = -1;
            this.cRVMarcas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVMarcas.DisplayGroupTree = false;
            this.cRVMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVMarcas.Location = new System.Drawing.Point(0, 0);
            this.cRVMarcas.Name = "cRVMarcas";
            this.cRVMarcas.SelectionFormula = "";
            this.cRVMarcas.Size = new System.Drawing.Size(595, 354);
            this.cRVMarcas.TabIndex = 0;
            this.cRVMarcas.ViewTimeSelectionFormula = "";
            // 
            // frmBancosRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 354);
            this.Controls.Add(this.cRVMarcas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBancosRP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANCOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMarcasRP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVMarcas;
    }
}