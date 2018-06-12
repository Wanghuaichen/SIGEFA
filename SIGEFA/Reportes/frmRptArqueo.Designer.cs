namespace SIGEFA.Reportes
{
    partial class frmRptArqueo
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
            this.crvArqueo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvArqueo
            // 
            this.crvArqueo.ActiveViewIndex = -1;
            this.crvArqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvArqueo.DisplayGroupTree = false;
            this.crvArqueo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvArqueo.Location = new System.Drawing.Point(0, 0);
            this.crvArqueo.Name = "crvArqueo";
            this.crvArqueo.SelectionFormula = "";
            this.crvArqueo.Size = new System.Drawing.Size(629, 438);
            this.crvArqueo.TabIndex = 0;
            this.crvArqueo.ViewTimeSelectionFormula = "";
            // 
            // frmRptArqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 438);
            this.Controls.Add(this.crvArqueo);
            this.Name = "frmRptArqueo";
            this.Text = "frmRptArqueo";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvArqueo;

    }
}