namespace SIGEFA.Reportes
{
    partial class frmRptCuotas
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
            this.crvCuotas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCuotas
            // 
            this.crvCuotas.ActiveViewIndex = -1;
            this.crvCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCuotas.DisplayGroupTree = false;
            this.crvCuotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCuotas.Location = new System.Drawing.Point(0, 0);
            this.crvCuotas.Name = "crvCuotas";
            this.crvCuotas.SelectionFormula = "";
            this.crvCuotas.Size = new System.Drawing.Size(284, 262);
            this.crvCuotas.TabIndex = 1;
            this.crvCuotas.ViewTimeSelectionFormula = "";
            // 
            // frmRptCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvCuotas);
            this.Name = "frmRptCuotas";
            this.Text = "frmRptCuotas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCuotas;
    }
}