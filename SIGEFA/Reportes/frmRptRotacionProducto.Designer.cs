namespace SIGEFA.Reportes
{
    partial class frmRptRotacionProducto
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
            this.cRVRotacionProducto = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVRotacionProducto
            // 
            this.cRVRotacionProducto.ActiveViewIndex = -1;
            this.cRVRotacionProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVRotacionProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVRotacionProducto.Location = new System.Drawing.Point(0, 0);
            this.cRVRotacionProducto.Name = "cRVRotacionProducto";
            this.cRVRotacionProducto.SelectionFormula = "";
            this.cRVRotacionProducto.Size = new System.Drawing.Size(532, 437);
            this.cRVRotacionProducto.TabIndex = 0;
            this.cRVRotacionProducto.ViewTimeSelectionFormula = "";
            // 
            // frmRptRotacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 437);
            this.Controls.Add(this.cRVRotacionProducto);
            this.Name = "frmRptRotacionProducto";
            this.Text = "frmRptRotacionProducto";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cRVRotacionProducto;

    }
}