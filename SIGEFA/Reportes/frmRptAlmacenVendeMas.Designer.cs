namespace SIGEFA.Reportes
{
    partial class frmRptAlmacenVendeMas
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
            this.cRVAlmacenVendeMas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVAlmacenVendeMas
            // 
            this.cRVAlmacenVendeMas.ActiveViewIndex = -1;
            this.cRVAlmacenVendeMas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVAlmacenVendeMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVAlmacenVendeMas.Location = new System.Drawing.Point(0, 0);
            this.cRVAlmacenVendeMas.Name = "cRVAlmacenVendeMas";
            this.cRVAlmacenVendeMas.SelectionFormula = "";
            this.cRVAlmacenVendeMas.Size = new System.Drawing.Size(365, 354);
            this.cRVAlmacenVendeMas.TabIndex = 0;
            this.cRVAlmacenVendeMas.ViewTimeSelectionFormula = "";
            // 
            // frmRptAlmacenVendeMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 354);
            this.Controls.Add(this.cRVAlmacenVendeMas);
            this.Name = "frmRptAlmacenVendeMas";
            this.Text = "frmRptAlmacenVendeMas";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVAlmacenVendeMas;

    }
}