﻿namespace SIGEFA.Reportes
{
    partial class frmRptComision
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
            this.crvComision = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvComision
            // 
            this.crvComision.ActiveViewIndex = -1;
            this.crvComision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvComision.DisplayGroupTree = false;
            this.crvComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvComision.Location = new System.Drawing.Point(0, 0);
            this.crvComision.Name = "crvComision";
            this.crvComision.SelectionFormula = "";
            this.crvComision.Size = new System.Drawing.Size(284, 262);
            this.crvComision.TabIndex = 0;
            this.crvComision.ViewTimeSelectionFormula = "";
            // 
            // frmRptComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvComision);
            this.Name = "frmRptComision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRptComision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvComision;

    }
}